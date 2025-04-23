Imports System.Text
Imports System.Xml
Imports ISS.ShippingMethods.UpsRest.Models
Imports ISS.ShippingMethods.UpsRest.Models.Json
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports RestSharp

Public Class RatingService
    Private _mUpsConfiguration As UPSConfiguration
    Private _mAuthenticationService As AuthenticationService
    Public Sub New(ByVal Config As UPSConfiguration)
        _mUpsConfiguration = Config
        _mAuthenticationService = New AuthenticationService(_mUpsConfiguration)
    End Sub

    Public Function GetUPSTimeInTransit(ByVal theUPSRequest As UPSRequest) As UPSTimeInTransitOutput
        Dim client = New RestClient(_mUpsConfiguration.UpsAuthUrl)
        Dim request = New RestRequest("/api/shipments/v1/transittimes", Method.POST)
        Dim upsRequest As New Models.Json.UpsTransitTimeRequest
        Dim upsResponse As Models.Json.UpsTransitTimeResponse
        Dim lstUPSShippingMethods As New List(Of UPSShippingRate)
        Dim rsp As RestResponse
        Dim rse As Json.ResponseError

        request.AddHeader("transID", "")
        request.AddHeader("transactionSrc", "ShipQuote")
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken)
        Dim lstMethods As New List(Of UPSTimeInTransitEntry)
        Dim otpOutput As New UPSTimeInTransitOutput

        Dim RTShipRequest As String = String.Empty
        Dim RTShipResponse As String = String.Empty
        Try

            ' Check for m_ShipmentWeight
            If theUPSRequest.TotalWeight = 0 Then
                otpOutput.Result = UPSOutput.RequestStatuses.Failure
                otpOutput.ErrorMessage = "Shipment Weight must be great than 0."
                Return otpOutput
            End If

            'Dim maxWeight As Decimal = AppLogic.AppConfigUSDecimal("RTShipping.UPS.MaxWeight")
            'If maxWeight = 0 Then
            '    maxWeight = 150
            'End If
            If theUPSRequest.TotalWeight > _mUpsConfiguration.MaxWeight And _mUpsConfiguration.MaxWeight > 0 Then
                otpOutput.Result = UPSOutput.RequestStatuses.Failure
                otpOutput.ErrorMessage = String.Format("Weight must be less than {0}.", _mUpsConfiguration.MaxWeight)
                Return otpOutput
            End If
            RTShipRequest = String.Empty
            RTShipResponse = String.Empty
            upsRequest = New UpsTransitTimeRequest
            With upsRequest
                .destinationCityName = theUPSRequest.DestinationAddress.City
                .destinationStateProvince = theUPSRequest.DestinationAddress.StateCode
                .destinationPostalCode = theUPSRequest.DestinationAddress.PostalCode
                .destinationCountryCode = theUPSRequest.DestinationAddress.CountryCode

                .originCityName = _mUpsConfiguration.OriginAddress.City
                .originStateProvince = _mUpsConfiguration.OriginAddress.StateCode
                .originPostalCode = _mUpsConfiguration.OriginAddress.PostalCode
                .originCountryCode = _mUpsConfiguration.OriginAddress.CountryCode

                .shipDate = String.Format("{0}-{1}-{2}", Now.Year, Now.Month.ToString.PadLeft(2, "0"), Now.Day.ToString.PadLeft(2, "0"))
                .shipmentContentsValue = (theUPSRequest.Packages.Sum(Function(pck) pck.Value)).ToString
                .shipmentContentsCurrencyCode = "USD"
                .weight = theUPSRequest.TotalWeight.ToString
                .weightUnitOfMeasure = "LBS"
            End With


            ' Set the rate request Xml

            request.AddJsonBody(upsRequest)

            rsp = client.Execute(request)
            If rsp.StatusCode = Net.HttpStatusCode.OK Then

                upsResponse = JsonConvert.DeserializeObject(Of Json.UpsTransitTimeResponse)(rsp.Content)
                Dim tempService As String = String.Empty
                Dim strTempRate As String
                Dim decTempRate As Decimal

                For Each obj In upsResponse.emsResponse.services
                    tempService = UPSServiceCodeDescription(obj.serviceLevel)
                    strTempRate = obj.businessTransitDays.ToString

                    Dim s_method As UPSTimeInTransitEntry = New UPSTimeInTransitEntry

                    s_method.MethodName = tempService
                    s_method.TransitTime = strTempRate + " day(s)"
                    lstMethods.Add(s_method)

                Next


            Else
                rse = JsonConvert.DeserializeObject(Of Json.ResponseError)(rsp.Content)
                otpOutput.Result = UPSOutput.RequestStatuses.Failure
                otpOutput.ErrorMessage = "UPS Error: "
                If rse.errors IsNot Nothing Then
                    For Each objError In rse.errors
                        otpOutput.ErrorMessage &= objError.code + ":" + objError.message + Environment.NewLine
                    Next
                End If
                Return otpOutput
            End If

        Catch ex As Exception
            otpOutput.Result = UPSOutput.RequestStatuses.Failure
            otpOutput.ErrorMessage = String.Format("Error Retrieving UPS Rates: {0}", ex.ToString)
            Return otpOutput
        End Try
        otpOutput.Result = UPSOutput.RequestStatuses.Success
        otpOutput.TransitTimes = lstMethods
        Return otpOutput

    End Function

    Public Function GetUPSAddressValidationResults(ByVal theUPSRequest As UPSRequest) As UPSAddressValidationOutput

        Dim client = New RestClient(_mUpsConfiguration.UpsAuthUrl)
        Dim request = New RestRequest("api/addressvalidation/v1/3?maximumcandidatelistsize=10", Method.POST)
        Dim upsRequest As New Models.Json.UpsAddressValidationRequest

        Dim upsResponse As Models.Json.UpsAddressValidationResponse

        Dim rsp As RestResponse
        Dim rse As Json.ResponseError

        request.AddHeader("transID", "")
        request.AddHeader("transactionSrc", "ShipQuote")
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken)
        Dim lstMethods As New List(Of UPSTimeInTransitEntry)
        Dim otpOutput As New UPSAddressValidationOutput

        Dim RTShipRequest As String = String.Empty
        Dim RTShipResponse As String = String.Empty
        Try

            RTShipRequest = String.Empty
            RTShipResponse = String.Empty


            upsRequest = New UpsAddressValidationRequest
            With upsRequest
                .XAVRequest = New XAVRequest
                .XAVRequest.AddressKeyFormat.Add(New AddressKeyFormat)
                .XAVRequest.AddressKeyFormat(0).AddressLine = New List(Of String)({theUPSRequest.DestinationAddress.Address1, theUPSRequest.DestinationAddress.Address2})
                .XAVRequest.AddressKeyFormat(0).PoliticalDivision1 = theUPSRequest.DestinationAddress.StateCode
                .XAVRequest.AddressKeyFormat(0).PoliticalDivision2 = theUPSRequest.DestinationAddress.City
                .XAVRequest.AddressKeyFormat(0).PostcodePrimaryLow = theUPSRequest.DestinationAddress.PostalCode
                .XAVRequest.AddressKeyFormat(0).CountryCode = theUPSRequest.DestinationAddress.CountryCode
            End With




            ' Set the rate request Xml

            request.AddJsonBody(upsRequest)

            rsp = client.Execute(request)
            If rsp.StatusCode = Net.HttpStatusCode.OK Then

                upsResponse = JsonConvert.DeserializeObject(Of Json.UpsAddressValidationResponse)(rsp.Content)


                If rsp.Content.Contains("NoCandidatesIndicator") = True OrElse (rsp.Content.Contains("AmbiguousAddressIndicator") = False AndAlso rsp.Content.Contains("ValidAddressIndicator") = False) Then
                    otpOutput.Result = UPSOutput.RequestStatuses.Failure
                    otpOutput.ErrorMessage = String.Format("Address Validation Failure")
                    Try
                        Dim adr As UPSAddress

                        For Each objAddress In upsResponse.XAVResponse.Candidate
                            adr = New UPSAddress
                            With adr
                                .Address1 = objAddress.AddressKeyFormat.AddressLine(0)
                                If objAddress.AddressKeyFormat.AddressLine.Count > 1 Then
                                    .Address2 = objAddress.AddressKeyFormat.AddressLine(1)

                                End If

                                .City = objAddress.AddressKeyFormat.PoliticalDivision2
                                .StateCode = objAddress.AddressKeyFormat.PoliticalDivision1
                                .PostalCode = objAddress.AddressKeyFormat.PostcodePrimaryLow
                                .CountryCode = objAddress.AddressKeyFormat.CountryCode
                            End With
                            otpOutput.SuggestedAddresses.Add(adr)

                        Next


                    Catch ex As Exception

                    End Try

                    'todo: look for suggestions

                    Return otpOutput
                Else
                    Try
                        Dim adr As UPSAddress

                        For Each objAddress In upsResponse.XAVResponse.Candidate
                            adr = New UPSAddress
                            With adr
                                .Address1 = objAddress.AddressKeyFormat.AddressLine(0)
                                If objAddress.AddressKeyFormat.AddressLine.Count > 1 Then
                                    .Address2 = objAddress.AddressKeyFormat.AddressLine(1)

                                End If

                                .City = objAddress.AddressKeyFormat.PoliticalDivision2
                                .StateCode = objAddress.AddressKeyFormat.PoliticalDivision1
                                .PostalCode = objAddress.AddressKeyFormat.PostcodePrimaryLow
                                .CountryCode = objAddress.AddressKeyFormat.CountryCode
                            End With
                            otpOutput.SuggestedAddresses.Add(adr)

                        Next



                    Catch ex As Exception

                    End Try
                End If


                ' Get Response code: 0 = Fail, 1 = Success

                If upsResponse.XAVResponse.Response.ResponseStatus.Code <> "1" Then ' Success
                    otpOutput.Result = UPSOutput.RequestStatuses.Failure
                    otpOutput.ErrorMessage = "Error Validating Address: "
                    For Each alert In upsResponse.XAVResponse.Response.Alert
                        otpOutput.ErrorMessage &= alert.Code + ": " + alert.Description + Environment.NewLine
                    Next

                    Return otpOutput
                Else
                    Try


                        If upsResponse.XAVResponse.AddressClassification.Code = "1" Then
                            otpOutput.Residential = False
                        End If
                    Catch ex As Exception

                    End Try
                End If


                Return otpOutput


            Else
                rse = JsonConvert.DeserializeObject(Of Json.ResponseError)(rsp.Content)
                otpOutput.Result = UPSOutput.RequestStatuses.Failure
                otpOutput.ErrorMessage = "UPS Error: "
                If rse.errors IsNot Nothing Then
                    For Each objError In rse.errors
                        otpOutput.ErrorMessage &= objError.code + ":" + objError.message + Environment.NewLine
                    Next
                End If
                Return otpOutput
            End If


        Catch ex As Exception
            otpOutput.Result = UPSOutput.RequestStatuses.Failure
            otpOutput.ErrorMessage = String.Format("Error Retrieving UPS Rates: {0}", ex.ToString)
            Return otpOutput
        End Try

        otpOutput.Result = UPSOutput.RequestStatuses.Success
        Return otpOutput
    End Function

    Public Function PreprocessJson(ByVal SourceJson As String) As String
        Dim jsonObject As JObject = JObject.Parse(SourceJson)
        Dim jtk As JToken
        Dim jar As JArray
        If jsonObject.ContainsKey("RateResponse") AndAlso jsonObject("RateResponse")("RatedShipment") IsNot Nothing AndAlso jsonObject("RateResponse")("RatedShipment").GetType() Is GetType(JObject) Then
            jar = New JArray
            jtk = jsonObject("RateResponse")("RatedShipment")
            jar.Add(jtk)
            jsonObject("RateResponse")("RatedShipment") = jar
            Return jsonObject.ToString
        End If

        Return SourceJson
    End Function
    Public Function GetUPSShippingMethods(ByVal theUPSRequest As UPSRequest, ByVal CostValue As Boolean) As UPSOutput
        Dim client = New RestClient(_mUpsConfiguration.UpsAuthUrl)
        Dim request As RestRequest
        Dim upsRequest As New Models.Json.UpsRatingRequest
        Dim lstUPSShippingMethods As New List(Of UPSShippingRate)
        Dim otpOutput As New UPSOutput
        Dim rsp As RestResponse
        Dim pck As Models.Json.Package
        Dim decValue As Decimal = 0
        Dim rsj As Json.UpsRateResponse
        Dim rse As Json.ResponseError

        'If CostValue = True Then
        request = New RestRequest("/api/rating/v1/Shoptimeintransit?additionalinfo=", Method.POST)
        '        Else
        'request = New RestRequest("/api/rating/v1/rate?additionalinfo=", Method.POST)
        'End If


        If theUPSRequest.TotalWeight > _mUpsConfiguration.MaxWeight And _mUpsConfiguration.MaxWeight > 0 Then
            otpOutput.Result = UPSOutput.RequestStatuses.Failure
            otpOutput.ErrorMessage = String.Format("Weight must be less than {0}.", _mUpsConfiguration.MaxWeight)
            Return otpOutput
        End If

        request.AddHeader("transID", "")
        request.AddHeader("transactionSrc", "ShipQuote")
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken)

        With upsRequest
            .RateRequest = New Json.RateRequest
            .RateRequest.Request = New Json.Request

            'If CostValue = True Then
            If theUPSRequest.DestinationAddress.CountryCode = "US" Or theUPSRequest.DestinationAddress.CountryCode = "" Then
                .RateRequest.Request.RequestOption = "Shoptimeintransit"
            Else
                .RateRequest.Request.RequestOption = "Shop"
            End If
            'Else

            '    .RateRequest.Request.RequestOption = "Rate"

            'End If


            .RateRequest.Request.TransactionReference = New Json.TransactionReference

            If theUPSRequest.DestinationAddress.CountryCode = "US" Or theUPSRequest.DestinationAddress.CountryCode = "" Then
                .RateRequest.Request.TransactionReference.CustomerContext = "Rating and Service"
            Else
                .RateRequest.Request.TransactionReference.CustomerContext = "Bare Bones Rate Request"
            End If



            '.RateRequest.PickupType = New PickupType
            'If _mUpsConfiguration.PickupCodeOverride > String.Empty Then
            '    .RateRequest.PickupType.Code = _mUpsConfiguration.PickupCodeOverride
            'End If



            .RateRequest.Shipment = New Json.Shipment



            .RateRequest.Shipment.DeliveryTimeInformation = New DeliveryTimeInformation
            .RateRequest.Shipment.DeliveryTimeInformation.PackageBillType = "03"
            If theUPSRequest.RequestedShipDate <> Nothing Then
                .RateRequest.Shipment.DeliveryTimeInformation.Pickup = New PickupDate
                .RateRequest.Shipment.DeliveryTimeInformation.Pickup.Date = theUPSRequest.RequestedShipDate.ToString("yyyyMMdd")

            End If

            If CostValue = True Then
                .RateRequest.Shipment.ShipmentRatingOptions = New NegotiatedShipmentRatingOptions
                .RateRequest.Shipment.PaymentDetails = New PaymentDetails
                .RateRequest.Shipment.PaymentDetails.ShipmentCharge = New ShipmentCharge
                .RateRequest.Shipment.PaymentDetails.ShipmentCharge.Type = "01"
                .RateRequest.Shipment.PaymentDetails.ShipmentCharge.BillShipper = New BillShipper
                .RateRequest.Shipment.PaymentDetails.ShipmentCharge.BillShipper.AccountNumber = _mUpsConfiguration.AccountNumber
                'Else
                '    .RateRequest.Shipment.ShipmentRatingOptions = New RateChartShipmentRatingOptions
            End If

            .RateRequest.Shipment.Shipper = New Json.Shipper
            If CostValue = True Then
                .RateRequest.Shipment.Shipper.ShipperNumber = _mUpsConfiguration.AccountNumber
            End If

            .RateRequest.Shipment.Shipper.Address = New Json.Address
            If String.IsNullOrEmpty(_mUpsConfiguration.OriginAddress.Address1) = False Then
                .RateRequest.Shipment.Shipper.Address.AddressLine.Add(_mUpsConfiguration.OriginAddress.Address1)
            End If
            If String.IsNullOrEmpty(_mUpsConfiguration.OriginAddress.Address2) = False Then
                .RateRequest.Shipment.Shipper.Address.AddressLine.Add(_mUpsConfiguration.OriginAddress.Address2)
            End If


            .RateRequest.Shipment.Shipper.Address.City = _mUpsConfiguration.OriginAddress.City
            .RateRequest.Shipment.Shipper.Address.StateProvinceCode = _mUpsConfiguration.OriginAddress.StateCode
            .RateRequest.Shipment.Shipper.Address.PostalCode = _mUpsConfiguration.OriginAddress.PostalCode
            .RateRequest.Shipment.Shipper.Address.CountryCode = _mUpsConfiguration.OriginAddress.CountryCode


            .RateRequest.Shipment.ShipTo = New Json.ShipTo

            .RateRequest.Shipment.ShipTo.Address = New Json.Address


            If String.IsNullOrEmpty(theUPSRequest.DestinationAddress.Address1) = False Then
                .RateRequest.Shipment.ShipTo.Address.AddressLine.Add(theUPSRequest.DestinationAddress.Address1)
            End If
            If String.IsNullOrEmpty(theUPSRequest.DestinationAddress.Address2) = False Then
                .RateRequest.Shipment.ShipTo.Address.AddressLine.Add(theUPSRequest.DestinationAddress.Address2)
            End If

            .RateRequest.Shipment.ShipTo.Address.City = theUPSRequest.DestinationAddress.City
            .RateRequest.Shipment.ShipTo.Address.StateProvinceCode = theUPSRequest.DestinationAddress.StateCode
            .RateRequest.Shipment.ShipTo.Address.PostalCode = theUPSRequest.DestinationAddress.PostalCode
            .RateRequest.Shipment.ShipTo.Address.CountryCode = theUPSRequest.DestinationAddress.CountryCode
            If theUPSRequest.DestinationAddress.Residential Then
                .RateRequest.Shipment.ShipTo.Address.ResidentialAddressIndicator = "Y"
            End If

            .RateRequest.Shipment.ShipFrom = New ShipFrom
            .RateRequest.Shipment.ShipFrom.Address = .RateRequest.Shipment.Shipper.Address
            .RateRequest.Shipment.ShipFrom.Name = .RateRequest.Shipment.Shipper.Name

            .RateRequest.Shipment.ShipmentTotalWeight = New ShipmentTotalWeight
            .RateRequest.Shipment.ShipmentTotalWeight.UnitOfMeasurement = New UnitOfMeasurement
            .RateRequest.Shipment.ShipmentTotalWeight.UnitOfMeasurement.Code = _mUpsConfiguration.WeightUnits
            .RateRequest.Shipment.ShipmentTotalWeight.Weight = theUPSRequest.TotalWeight.ToString

            .RateRequest.Shipment.NumOfPieces = theUPSRequest.Packages.Count.ToString

            .RateRequest.Shipment.Package = New List(Of Package)

            For Each sp In theUPSRequest.Packages

                If sp.Weight < _mUpsConfiguration.MinimumPackageWeight Then
                    sp.Weight = _mUpsConfiguration.MinimumPackageWeight
                End If

                pck = New Package
                pck.PackagingType = New PackagingType
                pck.PackagingType.Code = "02"


                If sp.Length > 0 Or sp.Width > 0 Or sp.Height > 0 Then
                    pck.Dimensions = New Dimensions
                    pck.Dimensions.UnitOfMeasurement = New UnitOfMeasurement

                    If _mUpsConfiguration.WeightUnits = "LBS" Then
                        pck.Dimensions.UnitOfMeasurement.Code = "IN"
                    Else
                        pck.Dimensions.UnitOfMeasurement.Code = "CM"
                    End If
                    pck.Dimensions.Length = sp.Length.ToString
                    pck.Dimensions.Width = sp.Width.ToString
                    pck.Dimensions.Height = sp.Height.ToString

                End If
                pck.PackageWeight = New PackageWeight
                pck.PackageWeight.UnitOfMeasurement = New UnitOfMeasurement
                pck.PackageWeight.UnitOfMeasurement.Code = _mUpsConfiguration.WeightUnits
                pck.PackageWeight.Weight = sp.Weight.ToString.PadLeft(6, "0")


                If _mUpsConfiguration.AllowInsurance = True AndAlso (sp.Insure = True) Then
                    pck.PackageServiceOptions = New PackageServiceOptions
                    pck.PackageServiceOptions.DeclaredValue = New MonetaryValue
                    pck.PackageServiceOptions.DeclaredValue.MonetaryValue = sp.Value.ToString
                    pck.PackageServiceOptions.DeclaredValue.CurrencyCode = "USD"
                    decValue = decValue + sp.Value
                End If
                .RateRequest.Shipment.Package.Add(pck)
            Next
            If decValue = 0 Then
                decValue = 1
            End If
            .RateRequest.Shipment.InvoiceLineTotal = New MonetaryValue
            .RateRequest.Shipment.InvoiceLineTotal.MonetaryValue = decValue.ToString
            .RateRequest.Shipment.InvoiceLineTotal.CurrencyCode = "USD"
        End With




        request.AddJsonBody(upsRequest)
        otpOutput.UPSRequest = JsonConvert.SerializeObject(upsRequest)

        rsp = client.Execute(request)
        otpOutput.UPSResponse = rsp.Content
        If rsp.StatusCode = Net.HttpStatusCode.OK Then
            rsp.Content = PreprocessJson(rsp.Content)
            rsj = JsonConvert.DeserializeObject(Of Json.UpsRateResponse)(rsp.Content)
            If rsj.RateResponse IsNot Nothing AndAlso rsj.RateResponse.Response IsNot Nothing AndAlso rsj.RateResponse.Response.ResponseStatus IsNot Nothing AndAlso rsj.RateResponse.Response.ResponseStatus.Code = "1" Then
                'success, process results

                For Each objShipment In rsj.RateResponse.RatedShipment
                    Dim tempService As String = String.Empty
                    Dim strTempRate As String
                    Dim decTempRate As Decimal
                    Dim strSaturday As String
                    Dim intDisplayOrder As Integer = UPSServiceCodeDisplayOrder(objShipment.Service.Code)

                    tempService = UPSServiceCodeDescription(objShipment.Service.Code)



                    If CostValue = False Then
                        strTempRate = objShipment.TotalCharges.MonetaryValue
                    Else
                        Try
                            'todo: find new value
                            strTempRate = objShipment.NegotiatedRateCharges.TotalCharge.MonetaryValue
                        Catch ex As Exception
                            strTempRate = objShipment.TotalCharges.MonetaryValue
                        End Try

                    End If
                    'If ShippingMethodIsAllowed(tempService, "UPS") Then

                    If Decimal.TryParse(strTempRate, decTempRate) = False Then
                        otpOutput.Result = UPSOutput.RequestStatuses.Failure
                        otpOutput.ErrorMessage = String.Format("Invalid Rate Passed From UPS: {0}", strTempRate)
                        Return otpOutput
                    End If

                    If _mUpsConfiguration.MarkupPercent <> 0 Then
                        decTempRate = Decimal.Round(decTempRate * (1D + (_mUpsConfiguration.MarkupPercent / 100D)), 2, MidpointRounding.AwayFromZero)
                    End If
                    decTempRate += _mUpsConfiguration.MarkupFee


                    'Dim vat As Decimal = Decimal.Round(tempRate * ShippingTaxRate, 2, MidpointRounding.AwayFromZero)

                    Dim s_method As UPSShippingRate = New UPSShippingRate

                    s_method.RateName = tempService
                    s_method.Rate = decTempRate
                    s_method.DisplayOrder = intDisplayOrder
                    lstUPSShippingMethods.Add(s_method)

                    If objShipment.TimeInTransit IsNot Nothing AndAlso objShipment.TimeInTransit.ServiceSummary IsNot Nothing Then
                        If objShipment.TimeInTransit.ServiceSummary.SaturdayDelivery IsNot Nothing Then
                            strSaturday = objShipment.TimeInTransit.ServiceSummary.SaturdayDelivery
                        Else
                            strSaturday = "0"
                        End If
                        If objShipment.TimeInTransit.ServiceSummary.EstimatedArrival IsNot Nothing AndAlso objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival IsNot Nothing Then
                            s_method.EstimatedDeliveryDate = New Date(objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival.Date.Substring(0, 4), objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival.Date.Substring(4, 2), objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival.Date.Substring(6, 2))
                        End If
                    End If


                    If strSaturday = "1" Then
                        s_method = New UPSShippingRate
                        s_method.RateName = tempService + " - Saturday Delivery"
                        s_method.Rate = decTempRate * 1.05
                        lstUPSShippingMethods.Add(s_method)
                    End If

                    If objShipment.TimeInTransit IsNot Nothing AndAlso objShipment.TimeInTransit.ServiceSummary IsNot Nothing AndAlso objShipment.TimeInTransit.ServiceSummary.EstimatedArrival IsNot Nothing AndAlso objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival IsNot Nothing Then
                        s_method.EstimatedDeliveryDate = New Date(objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival.Date.Substring(0, 4), objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival.Date.Substring(4, 2), objShipment.TimeInTransit.ServiceSummary.EstimatedArrival.Arrival.Date.Substring(6, 2))
                    End If
                    'If s_method.RateName = "UPS Next Day Air Early AM" Or s_method.RateName = "UPS Next Day Air" Then
                    '    s_method = New UPSShippingRate
                    '    s_method.RateName = tempService + " - Saturday Delivery"
                    '    s_method.Rate = decTempRate * 1.05
                    '    lstUPSShippingMethods.Add(s_method)
                    'End If

                    'End If


                Next

            Else
                rse = JsonConvert.DeserializeObject(Of Json.ResponseError)(rsp.Content)
                otpOutput.Result = UPSOutput.RequestStatuses.Failure
                otpOutput.ErrorMessage = "UPS Error: "
                If rsj.RateResponse IsNot Nothing AndAlso rsj.RateResponse.Response IsNot Nothing AndAlso rsj.RateResponse.Response.Alert IsNot Nothing Then

                    For Each objError In rsj.RateResponse.Response.Alert
                        otpOutput.ErrorMessage &= objError.Code + ":" + objError.Description + Environment.NewLine
                    Next
                End If
                Return otpOutput
            End If
        Else
            rse = JsonConvert.DeserializeObject(Of Json.ResponseError)(rsp.Content)
            otpOutput.Result = UPSOutput.RequestStatuses.Failure
            otpOutput.ErrorMessage = "UPS Error: "
            If rse.errors IsNot Nothing Then
                For Each objError In rse.errors
                    otpOutput.ErrorMessage &= objError.code + ":" + objError.message + Environment.NewLine
                Next
            End If
            Return otpOutput
        End If
        otpOutput.Result = UPSOutput.RequestStatuses.Success
        otpOutput.Rates = lstUPSShippingMethods
        If otpOutput.Rates IsNot Nothing Then
            otpOutput.Rates = otpOutput.Rates.OrderBy(Function(m) m.DisplayOrder).ToList
        End If
        Return otpOutput
    End Function
    Private Shared Function MapUPSPickupType(ByVal s As String) As String
        s = s.Trim().ToLowerInvariant()
        If s = "upsdailypickup" Then
            Return "01"
        End If
        If s = "upscustomercounter" Then
            Return "03"
        End If
        If s = "upsonetimepickup" Then
            Return "06"
        End If
        If s = "upsoncallair" Then
            Return "07"
        End If
        If s = "upssuggestedretailrates" Then
            Return "11"
        End If
        If s = "upslettercenter" Then
            Return "19"
        End If
        If s = "upsairservicecenter" Then
            Return "20"
        End If
        Return "03" ' find some default
    End Function

    Private Shared Function UPSServiceCodeDisplayOrder(ByVal code As String) As Integer
        Dim result As Integer = 999
        Select Case code
            Case "01", "1DA"
                result = 100
            Case "02", "2DA"
                result = 20
            Case "03", "GND"
                result = 0
            Case "07"
                result = 20
            Case "08"
                result = 20
            Case "11"
                result = 10
            Case "12", "3DS"
                result = 30
            Case "13", "1DP"
                result = 10
            Case "14", "1DM", "15"
                result = 10
            Case "54"
                result = 20
            Case "59", "2DM"
                result = 20
            Case "65"
                result = 20

                'Saturday delivery
            Case "41"
                result = 20
            Case "44"
                result = 20

        End Select

        Return result
    End Function

    ''' <summary>
    ''' Convert the input number to the textual description of the Service Code
    ''' </summary>
    ''' <param name="code">The Service Code number to be converted</param>
    ''' <returns></returns>
    Private Shared Function UPSServiceCodeDescription(ByVal code As String) As String
        Dim result As String = String.Empty
        Select Case code
            Case "01", "1DA"
                result = "UPS Next Day Air"
            Case "02", "2DA"
                result = "UPS 2nd Day Air"
            Case "03", "GND"
                result = "UPS Ground"
            Case "07"
                result = "UPS Worldwide Express"
            Case "08"
                result = "UPS Worldwide Expedited"
            Case "11"
                result = "UPS Standard"
            Case "12", "3DS"
                result = "UPS 3-Day Select"
            Case "13", "1DP"
                result = "UPS Next Day Air Saver"
            Case "14", "1DM", "15"
                result = "UPS Next Day Air Early AM"
            Case "54"
                result = "UPS Worldwide Express Plus"
            Case "59", "2DM"
                result = "UPS 2nd Day Air AM"
            Case "65"
                result = "UPS Express Saver"

                'Saturday delivery
            Case "41"
                result = "Next Day Air Early A.M. - Saturday Delivery"
            Case "44"
                result = "Next Day Air - Saturday Delivery"
            Case Else
                result = code
        End Select

        Return result
    End Function
End Class

