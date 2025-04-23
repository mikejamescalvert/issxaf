Imports System.Text
Imports System.Xml
Imports System.Web
Imports System.Net
Imports System.IO

Namespace Helpers
    Public Class UPSHelper

        Public Function GetUPSShippingMethods(ByVal theUPSRequest As UPSRequest, ByVal theUPSConfiguration As UPSConfiguration) As UPSOutput
            Dim lstUPSShippingMethods As New List(Of UPSShippingRate)
            Dim otpOutput As New UPSOutput

            Dim strUPSServer As String
            Dim RTShipRequest As String = String.Empty
            Dim RTShipResponse As String = String.Empty
            Try
                ' check all required info
                If theUPSConfiguration.Username = String.Empty OrElse theUPSConfiguration.Password = String.Empty OrElse theUPSConfiguration.LicenseKey = String.Empty Then
                    otpOutput.Result = UPSOutput.RequestStatuses.Failure
                    otpOutput.ErrorMessage = "UPS Login Information Not Provided"
                    Return otpOutput
                End If

                ' Check for test mode
                If theUPSConfiguration.TestMode = True Then
                    strUPSServer = theUPSConfiguration.TestServerAddress
                Else
                    strUPSServer = theUPSConfiguration.LiveServerAddress
                End If

                ' Check server setting
                If strUPSServer = String.Empty Then
                    otpOutput.Result = UPSOutput.RequestStatuses.Failure
                    otpOutput.ErrorMessage = "UPS Server Information Not Provided"
                    Return otpOutput
                End If

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
                If theUPSRequest.TotalWeight > theUPSConfiguration.MaxWeight Then
                    otpOutput.Result = UPSOutput.RequestStatuses.Failure
                    otpOutput.ErrorMessage = String.Format("Weight must be less than {0}.", theUPSConfiguration.MaxWeight)
                    Return otpOutput
                End If
                RTShipRequest = String.Empty
                RTShipResponse = String.Empty

                ' Set the access request Xml
                Dim accessRequest As String = String.Format("<?xml version=""1.0""?><AccessRequest xml:lang=""en-us""><AccessLicenseNumber>{0}</AccessLicenseNumber><UserId>{1}</UserId><Password>{2}</Password></AccessRequest>", theUPSConfiguration.LicenseKey, theUPSConfiguration.Username, theUPSConfiguration.Password)

                ' Set the rate request Xml
                Dim shipmentRequest As StringBuilder = New StringBuilder(1024)
                shipmentRequest.Append("<?xml version=""1.0""?>")
                shipmentRequest.Append("<RatingServiceSelectionRequest xml:lang=""en-US"">")
                shipmentRequest.Append("<Request>")
                shipmentRequest.Append("<RequestAction>Rate</RequestAction>")
                shipmentRequest.Append("<RequestOption>Shop</RequestOption>")
                shipmentRequest.Append("<TransactionReference>")
                shipmentRequest.Append("<CustomerContext>Rating and Service</CustomerContext>")
                shipmentRequest.Append("<XpciVersion>1.0001</XpciVersion>")
                shipmentRequest.Append("</TransactionReference>")
                shipmentRequest.Append("</Request>")
                shipmentRequest.Append("<PickupType>")
                shipmentRequest.Append("<Code>")
                shipmentRequest.Append("01")
                shipmentRequest.Append("</Code>")
                shipmentRequest.Append("</PickupType>")
                shipmentRequest.Append("<Shipment>")
                shipmentRequest.Append("<Shipper>")
                shipmentRequest.Append("<Address>")
                shipmentRequest.Append("<City>")
                shipmentRequest.Append(theUPSConfiguration.OriginAddress.City)
                shipmentRequest.Append("</City>")
                shipmentRequest.Append("<StateProvinceCode>")
                shipmentRequest.Append(theUPSConfiguration.OriginAddress.StateCode)
                shipmentRequest.Append("</StateProvinceCode>")
                shipmentRequest.Append("<PostalCode>")
                shipmentRequest.Append(theUPSConfiguration.OriginAddress.PostalCode)
                shipmentRequest.Append("</PostalCode>")
                shipmentRequest.Append("<CountryCode>")
                shipmentRequest.Append(theUPSConfiguration.OriginAddress.CountryCode)
                shipmentRequest.Append("</CountryCode>")
                shipmentRequest.Append("</Address>")
                shipmentRequest.Append("</Shipper>")
                shipmentRequest.Append("<ShipTo>")
                shipmentRequest.Append("<Address>")
                shipmentRequest.Append("<City>")
                shipmentRequest.Append(theUPSRequest.DestinationAddress.City)
                shipmentRequest.Append("</City>")
                shipmentRequest.Append("<StateProvinceCode>")
                shipmentRequest.Append(theUPSRequest.DestinationAddress.StateCode)
                shipmentRequest.Append("</StateProvinceCode>")
                shipmentRequest.Append("<PostalCode>")
                shipmentRequest.Append(theUPSRequest.DestinationAddress.PostalCode)
                shipmentRequest.Append("</PostalCode>")
                shipmentRequest.Append("<CountryCode>")
                shipmentRequest.Append(theUPSRequest.DestinationAddress.CountryCode)
                shipmentRequest.Append("</CountryCode>")
                
                'shipmentRequest.Append(CommonLogic.IIF(Me.m_DestinationResidenceType = ResidenceTypes.Commercial, "", "<ResidentialAddressIndicator/>"))
                shipmentRequest.Append("</Address>")
                shipmentRequest.Append("</ShipTo>")
                shipmentRequest.Append("<ShipmentWeight>")
                shipmentRequest.Append("<UnitOfMeasurement>")
                shipmentRequest.Append("<Code>")
                shipmentRequest.Append(theUPSConfiguration.WeightUnits)
                shipmentRequest.Append("</Code>")
                shipmentRequest.Append("</UnitOfMeasurement>")
                shipmentRequest.Append("<Weight>")
                shipmentRequest.Append(theUPSRequest.TotalWeight.ToString)
                shipmentRequest.Append("</Weight>")
                shipmentRequest.Append("</ShipmentWeight>")


                ' loop through the packages
                For Each sp As UPSPackage In theUPSRequest.Packages
                    'Check for invalid weights and assign a new value if necessary
                    If sp.Weight < theUPSConfiguration.MinimumPackageWeight Then
                        sp.Weight = theUPSConfiguration.MinimumPackageWeight
                    End If

                    shipmentRequest.Append("<Package>")
                    shipmentRequest.Append("<PackagingType>")
                    shipmentRequest.Append("<Code>02</Code>")
                    shipmentRequest.Append("</PackagingType>")
                    shipmentRequest.Append("<Dimensions>")
                    shipmentRequest.Append("<UnitOfMeasurement>")

                    If theUPSConfiguration.WeightUnits = "LBS" Then
                        shipmentRequest.Append("<Code>IN</Code>")
                    Else
                        shipmentRequest.Append("<Code>CM</Code>")
                    End If

                    shipmentRequest.Append("</UnitOfMeasurement>")
                    shipmentRequest.Append("<Length>")
                    shipmentRequest.Append(sp.Length.ToString)
                    shipmentRequest.Append("</Length>")
                    shipmentRequest.Append("<Width>")
                    shipmentRequest.Append(sp.Width.ToString)
                    shipmentRequest.Append("</Width>")
                    shipmentRequest.Append("<Height>")
                    shipmentRequest.Append(sp.Height.ToString)
                    shipmentRequest.Append("</Height>")
                    shipmentRequest.Append("</Dimensions>")
                    shipmentRequest.Append("<Description>")
                    shipmentRequest.Append(sp.Description)
                    shipmentRequest.Append("</Description>")
                    shipmentRequest.Append("<PackageWeight>")
                    shipmentRequest.Append("<UnitOfMeasure>")
                    shipmentRequest.Append("<Code>")
                    shipmentRequest.Append(theUPSConfiguration.WeightUnits)
                    shipmentRequest.Append("</Code>")
                    shipmentRequest.Append("</UnitOfMeasure>")
                    shipmentRequest.Append("<Weight>")
                    shipmentRequest.Append(sp.Weight.ToString)
                    shipmentRequest.Append("</Weight>")
                    shipmentRequest.Append("</PackageWeight>")
                    shipmentRequest.Append("<OversizePackage />")

                    If theUPSConfiguration.AllowInsurance = True AndAlso (sp.Insure = True) Then
                        shipmentRequest.Append("<PackageServiceOptions>")
                        shipmentRequest.Append("<InsuredValue>")
                        shipmentRequest.Append("<CurrencyCode>USD</CurrencyCode>")
                        shipmentRequest.Append("<MonetaryValue>")
                        shipmentRequest.Append(sp.Value.ToString)
                        shipmentRequest.Append("</MonetaryValue>")
                        shipmentRequest.Append("</InsuredValue>")
                        shipmentRequest.Append("</PackageServiceOptions>")
                    End If

                    shipmentRequest.Append("</Package>")
                Next sp

                shipmentRequest.Append("<ShipmentServiceOptions/></Shipment></RatingServiceSelectionRequest>")

                ' Concat the requests
                Dim fullUPSRequest As String = accessRequest & shipmentRequest.ToString()
                otpOutput.UPSRequest = fullUPSRequest
                RTShipRequest = fullUPSRequest

                ' Send request & capture response

                Dim result As String = POSTandReceiveData(fullUPSRequest, strUPSServer)

                RTShipResponse = result

                ' Load Xml into a XmlDocument object
                Dim UPSResponse As XmlDocument = New XmlDocument()
                Try
                    UPSResponse.LoadXml(result)
                Catch
                    otpOutput.Result = UPSOutput.RequestStatuses.Failure
                    otpOutput.ErrorMessage = "UPS Gateway Did Not Respond"
                    Return otpOutput
                End Try

                ' Get Response code: 0 = Fail, 1 = Success
                Dim UPSResponseCode As XmlNodeList = UPSResponse.GetElementsByTagName("ResponseStatusCode")

                If UPSResponseCode(0).InnerText = "1" Then ' Success
                    ' Loop through elements & get rates
                    Dim ratedShipments As XmlNodeList = UPSResponse.GetElementsByTagName("RatedShipment")
                    Dim tempService As String = String.Empty
                    Dim strTempRate As String
                    Dim decTempRate As Decimal
                    For i As Integer = 0 To ratedShipments.Count - 1
                        Dim shipmentX As XmlNode = ratedShipments.Item(i)
                        tempService = UPSServiceCodeDescription(shipmentX("Service")("Code").InnerText)

                        'If ShippingMethodIsAllowed(tempService, "UPS") Then
                        strTempRate = shipmentX("TotalCharges")("MonetaryValue").InnerText
                        If Decimal.TryParse(strTempRate, decTempRate) = False Then
                            otpOutput.Result = UPSOutput.RequestStatuses.Failure
                            otpOutput.ErrorMessage = String.Format("Invalid Rate Passed From UPS: {0}", strTempRate)
                            Return otpOutput
                        End If

                        If theUPSConfiguration.MarkupPercent <> 0 Then
                            decTempRate = Decimal.Round(decTempRate * (1D + (theUPSConfiguration.MarkupPercent / 100D)), 2, MidpointRounding.AwayFromZero)
                        End If
                        decTempRate += theUPSConfiguration.MarkupFee


                        'Dim vat As Decimal = Decimal.Round(tempRate * ShippingTaxRate, 2, MidpointRounding.AwayFromZero)

                        Dim s_method As UPSShippingRate = New UPSShippingRate

                        s_method.RateName = tempService
                        s_method.Rate = decTempRate
                        lstUPSShippingMethods.Add(s_method)

                        'End If
                    Next
                Else ' Error
                    Dim UPSError As XmlNodeList = UPSResponse.GetElementsByTagName("ErrorDescription")
                    otpOutput.Result = UPSOutput.RequestStatuses.Failure
                    otpOutput.ErrorMessage = String.Format("UPS Error: {0}", UPSError(0).InnerText)
                    Return otpOutput
                    UPSError = Nothing
                End If

                ' Some clean up
                UPSResponseCode = Nothing
                UPSResponse = Nothing
            Catch ex As Exception
                otpOutput.Result = UPSOutput.RequestStatuses.Failure
                otpOutput.ErrorMessage = String.Format("Error Retrieving UPS Rates: {0}", ex.ToString)
                Return otpOutput
            End Try
            otpOutput.Result = UPSOutput.RequestStatuses.Success
            otpOutput.Rates = lstUPSShippingMethods
            Return otpOutput
        End Function

        ''' <summary>
        ''' Send and capture data using GET
        ''' </summary>
        ''' <param name="Request">The Xml Request to be sent</param>
        ''' <param name="Server">The server the request should be sent to</param>
        ''' <returns>String</returns>
        Private Shared Function GETandReceiveData(ByVal Request As String, ByVal Server As String) As String
            Dim requestX As HttpWebRequest = CType(WebRequest.Create(Server & "?" & Request), HttpWebRequest)
            Dim response As HttpWebResponse = CType(requestX.GetResponse(), HttpWebResponse)
            Dim sr As StreamReader = New StreamReader(response.GetResponseStream())
            Dim result As String = sr.ReadToEnd()
            response.Close()
            sr.Close()
            Return result
        End Function
        ''' <summary>
        ''' Send and capture data using Post
        ''' </summary>
        ''' <param name="Request">The Xml Request to be sent</param>
        ''' <param name="Server">The server the request should be sent to</param>
        ''' <returns>String</returns>
        Private Shared Function POSTandReceiveData(ByVal Request As String, ByVal Server As String) As String
            ' check for cache hit:
            'Dim CacheName As String = Server & Request
            'Dim s As String = CType(HttpContext.Current.Cache.Get(CacheName), String)
            'If Not s Is Nothing Then
            '    Return s
            'End If
            ' Set encoding & get content Length
            Dim encoding As ASCIIEncoding = New ASCIIEncoding()
            Dim data As Byte() = encoding.GetBytes(Request) ' Request

            ' Prepare post request
            Dim shipRequest As HttpWebRequest = CType(WebRequest.Create(Server), HttpWebRequest) ' Server
            shipRequest.Method = "POST"
            shipRequest.ContentType = "application/x-www-form-urlencoded"
            shipRequest.ContentLength = data.Length
            Dim requestStream As Stream = shipRequest.GetRequestStream()
            ' Send the data
            requestStream.Write(data, 0, data.Length)
            requestStream.Close()
            ' get the response
            Dim shipResponse As WebResponse = Nothing
            Dim response As String = String.Empty
            Try
                shipResponse = shipRequest.GetResponse()
                Using sr As StreamReader = New StreamReader(shipResponse.GetResponseStream())
                    response = sr.ReadToEnd()
                    sr.Close()
                End Using
            Catch exc As Exception
                response = exc.ToString()
            Finally
                If Not shipResponse Is Nothing Then
                    shipResponse.Close()
                End If
            End Try

            shipRequest = Nothing
            requestStream = Nothing
            shipResponse = Nothing

            ' cache result. if there was no error in it!
            'If response.ToLowerInvariant().IndexOf("error:") <> -1 OrElse response.ToLowerInvariant().IndexOf("exception") <> -1 Then
            '    Try
            '        HttpContext.Current.Cache.Remove(CacheName)
            '    Catch
            '    End Try
            'Else
            '    HttpContext.Current.Cache.Insert(CacheName, response, Nothing, System.DateTime.Now.AddMinutes(15), TimeSpan.Zero)
            'End If

            Return response
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
        ''' <summary>
        ''' Convert the input number to the textual description of the Service Code
        ''' </summary>
        ''' <param name="code">The Service Code number to be converted</param>
        ''' <returns></returns>
        Private Shared Function UPSServiceCodeDescription(ByVal code As String) As String
            Dim result As String = String.Empty
            Select Case code
                Case "01"
                    result = "UPS Next Day Air"
                Case "02"
                    result = "UPS 2nd Day Air"
                Case "03"
                    result = "UPS Ground"
                Case "07"
                    result = "UPS Worldwide Express"
                Case "08"
                    result = "UPS Worldwide Expedited"
                Case "11"
                    result = "UPS Standard"
                Case "12"
                    result = "UPS 3-Day Select"
                Case "13"
                    result = "UPS Next Day Air Saver"
                Case "14"
                    result = "UPS Next Day Air Early AM"
                Case "54"
                    result = "UPS Worldwide Express Plus"
                Case "59"
                    result = "UPS 2nd Day Air AM"
                Case "65"
                    result = "UPS Express Saver"
            End Select

            Return result
        End Function

    End Class
End Namespace

