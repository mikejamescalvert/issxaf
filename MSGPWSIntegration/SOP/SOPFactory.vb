Imports GP2010Service = MSGPWSIntegration.DynamicsWCFService

Namespace SOP

    Public Class SOPFactory

        ''' <summary>
        ''' Create GP Fulfillment Order
        ''' </summary>
        ''' <param name="objFulfillmentOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPFulfillmentOrder(ByVal objFulfillmentOrder As SOP.SalesFulfillmentOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10FulfillmentOrder(objFulfillmentOrder, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010FulfillmentOrder(objFulfillmentOrder, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Create GP 2010 Fulfillment Order
        ''' </summary>
        ''' <param name="objFulfillmentOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010FulfillmentOrder(ByVal objFulfillmentOrder As SOP.SalesFulfillmentOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim fulfillmentOrder As GP2010Service.SalesFulfillmentOrder
                Dim salesDocumentKey As GP2010Service.SalesDocumentKey
                Dim customerKey As GP2010Service.CustomerKey
                Dim batchKey As GP2010Service.BatchKey
                Dim salesOrderLine As GP2010Service.SalesFulfillmentOrderLine
                Dim orderedItem As GP2010Service.ItemKey
                Dim freightAmount As GP2010Service.MoneyAmount
                Dim orderedQty As GP2010Service.Quantity
                Dim ShipMethodKey As GP2010Service.ShippingMethodKey
                Dim salesOrderCreatePolicy As GP2010Service.Policy
                Dim itemPrice As GP2010Service.MoneyAmount
                Dim ShipToAddressKey As GP2010Service.CustomerAddressKey
                Dim PhoneNumber As GP2010Service.PhoneNumber
                Dim SalespersonKey As GP2010Service.SalespersonKey
                Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
                Dim ShipToAddress As GP2010Service.BusinessAddress
                Dim BillToAddressKey As GP2010Service.CustomerAddressKey
                Dim salesPayments As GP2010Service.SalesPayment()
                Dim salesPayment As GP2010Service.SalesPayment
                Dim paymentCardTypeKey As GP2010Service.PaymentCardTypeKey
                Dim moneyAmount As GP2010Service.MoneyAmount
                Dim bankAccountKey As GP2010Service.BankAccountKey
                Dim salesUserDefined As GP2010Service.SalesUserDefined
                Dim salesDocumentTypeKey As GP2010Service.SalesDocumentTypeKey
                Dim taxScheduleKey As GP2010Service.TaxScheduleKey
                Dim tdpTradeDiscountPercent As GP2010Service.MoneyPercentChoice
                Dim GPSalesOrderNo As String = String.Empty

                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP2010Service.Context
                companyKey = New GP2010Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP2010Service.OrganizationKey)
                context.CultureName = "en-US"
                fulfillmentOrder = New GP2010Service.SalesFulfillmentOrder
                batchKey = New GP2010Service.BatchKey
                batchKey.Id = objFulfillmentOrder.SalesDocumentHeader.SOPBatchId
                fulfillmentOrder.BatchKey = batchKey


                If objFulfillmentOrder.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesOrderNo = objFulfillmentOrder.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP2010Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesOrderNo
                    fulfillmentOrder.Key = salesDocumentKey
                End If

                'Get next fulfillment number
                If objFulfillmentOrder.SalesDocumentHeader.SalesDocumentTypeKey <> Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesDocumentTypeKey) Then
                    salesDocumentTypeKey = New GP2010Service.SalesDocumentTypeKey
                    salesDocumentTypeKey.Id = objFulfillmentOrder.SalesDocumentHeader.SalesDocumentTypeKey
                    salesDocumentTypeKey.Type = GP2010Service.SalesDocumentType.Invoice
                    fulfillmentOrder.DocumentTypeKey = salesDocumentTypeKey
                End If


                If objFulfillmentOrder.SalesDocumentHeader.PriceLevel > String.Empty Then
                    fulfillmentOrder.PriceLevelKey = New GP2010Service.PriceLevelKey
                    fulfillmentOrder.PriceLevelKey.Id = objFulfillmentOrder.SalesDocumentHeader.PriceLevel
                End If


                If objFulfillmentOrder.SalesDocumentHeader.TradeDiscountPercent > 0 Then
                    tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP2010Service.Percent
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.Percent).Value = objFulfillmentOrder.SalesDocumentHeader.TradeDiscountPercent
                    fulfillmentOrder.TradeDiscount = tdpTradeDiscountPercent
                ElseIf objFulfillmentOrder.SalesDocumentHeader.TradeDiscountFlatAmount > 0 Then
                    tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP2010Service.MoneyAmount
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Value = objFulfillmentOrder.SalesDocumentHeader.TradeDiscountFlatAmount
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                    fulfillmentOrder.TradeDiscount = tdpTradeDiscountPercent
                End If
                fulfillmentOrder.TaxExemptNumber1 = objFulfillmentOrder.SalesDocumentHeader.TaxExempt1
                fulfillmentOrder.TaxExemptNumber2 = objFulfillmentOrder.SalesDocumentHeader.TaxExempt2
                fulfillmentOrder.TaxRegistrationNumber = objFulfillmentOrder.SalesDocumentHeader.TaxRegistrationNumber
                'Create Order Header
                With objFulfillmentOrder
                    customerKey = New GP2010Service.CustomerKey
                    customerKey.Id = .SalesDocumentHeader.CustomerId
                    fulfillmentOrder.CustomerKey = customerKey

                    If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                        SalespersonKey = New GP2010Service.SalespersonKey
                        SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                        fulfillmentOrder.SalespersonKey = SalespersonKey
                    End If

                    fulfillmentOrder.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                    fulfillmentOrder.Date = Date.Parse(Date.Today.ToShortDateString)
                    fulfillmentOrder.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                    fulfillmentOrder.RequestedShipDate = IIf(.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.RequestedShipDate.ToShortDateString)))
                    fulfillmentOrder.ActualShipDate = IIf(.SalesDocumentHeader.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.ActualShipDate.ToShortDateString)))

                    If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                        PaymentTermsKey = New GP2010Service.PaymentTermsKey
                        PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                        fulfillmentOrder.PaymentTermsKey = PaymentTermsKey
                    End If

                    fulfillmentOrder.Note = .SalesDocumentHeader.CustomerNote
                End With

                'Create Shipping Address
                ShipToAddress = New GP2010Service.BusinessAddress
                With ShipToAddress
                    .Name = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.City
                    .State = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.State
                    .PostalCode = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.ContactPerson
                    .CountryRegion = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Country
                    If objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP2010Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If
                    PhoneNumber = New GP2010Service.PhoneNumber
                    PhoneNumber.Value = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                End With
                fulfillmentOrder.ShipToAddress = ShipToAddress

                If objFulfillmentOrder.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.ShipToAddressKey.Trim) Then
                    ShipToAddressKey = New GP2010Service.CustomerAddressKey
                    ShipToAddressKey.CompanyKey = companyKey
                    ShipToAddressKey.CustomerKey = customerKey
                    ShipToAddressKey.Id = objFulfillmentOrder.SalesDocumentHeader.ShipToAddressKey
                    fulfillmentOrder.ShipToAddressKey = ShipToAddressKey
                End If


                If objFulfillmentOrder.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.BillToAddressKey.Trim) Then
                    BillToAddressKey = New GP2010Service.CustomerAddressKey
                    BillToAddressKey.CompanyKey = companyKey
                    BillToAddressKey.CustomerKey = customerKey
                    BillToAddressKey.Id = objFulfillmentOrder.SalesDocumentHeader.BillToAddressKey
                    fulfillmentOrder.BillToAddressKey = BillToAddressKey
                End If

                If objFulfillmentOrder.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objFulfillmentOrder.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP2010Service.ShippingMethodKey
                    ShipMethodKey.Id = objFulfillmentOrder.SalesDocumentHeader.ShipmethodKey
                    fulfillmentOrder.ShippingMethodKey = ShipMethodKey
                End If

                If objFulfillmentOrder.SalesDocumentHeader.PaymentAmount > 0 Then
                    moneyAmount = New GP2010Service.MoneyAmount
                    moneyAmount.Value = objFulfillmentOrder.SalesDocumentHeader.PaymentAmount
                    moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                    fulfillmentOrder.PaymentAmount = moneyAmount
                End If

                If Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.TaxScheduleKey) Then
                    taxScheduleKey = New GP2010Service.TaxScheduleKey
                    taxScheduleKey.Id = objFulfillmentOrder.SalesDocumentHeader.TaxScheduleKey
                    fulfillmentOrder.TaxScheduleKey = taxScheduleKey
                End If

                freightAmount = New GP2010Service.MoneyAmount
                freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                freightAmount.Value = objFulfillmentOrder.SalesDocumentHeader.FreightAmount
                fulfillmentOrder.FreightAmount = freightAmount

                If objFulfillmentOrder.SalesDocumentHeader.SalesPayments.Count > 0 Then
                    ReDim salesPayments(objFulfillmentOrder.SalesDocumentHeader.SalesPayments.Count - 1)
                    For i As Integer = 0 To objFulfillmentOrder.SalesDocumentHeader.SalesPayments.Count - 1
                        salesPayment = New GP2010Service.SalesPayment


                        Select Case objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).SalesPaymentType
                            Case SOP.SalesPayment.PaymentType.Cash_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.CashDeposit
                            Case SOP.SalesPayment.PaymentType.Cash_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.CashPayment
                            Case SOP.SalesPayment.PaymentType.Check_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.CheckPayment
                            Case SOP.SalesPayment.PaymentType.Check_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.CheckDeposit
                            Case SOP.SalesPayment.PaymentType.Payment_Card_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.PaymentCardDeposit
                            Case SOP.SalesPayment.PaymentType.Payment_Card_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.PaymentCardPayment
                        End Select


                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey > String.Empty Then
                            paymentCardTypeKey = New GP2010Service.PaymentCardTypeKey
                            paymentCardTypeKey.Id = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey
                            salesPayment.PaymentCardTypeKey = paymentCardTypeKey
                        End If




                        moneyAmount = New GP2010Service.MoneyAmount
                        moneyAmount.Value = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentAmount
                        moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesPayment.PaymentAmount = moneyAmount


                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode) Then
                            salesPayment.AuthorizationCode = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey) Then
                            bankAccountKey = New GP2010Service.BankAccountKey
                            bankAccountKey.Id = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey
                            salesPayment.BankAccountKey = bankAccountKey
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber) Then
                            salesPayment.PaymentCardNumber = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber) Then
                            salesPayment.CheckNumber = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).Number IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).Number) Then
                            salesPayment.Number = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).Number
                        End If

                        salesPayment.ExpirationDate = IIf(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.ToShortDateString))

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode) Then
                            salesPayment.AuditTrailCode = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode
                        End If
                        salesPayment.DeleteOnUpdate = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).DeleteOnUpdate


                        salesPayments(i) = salesPayment
                    Next

                    fulfillmentOrder.Payments = salesPayments
                End If

                'create up SalesUserDefined
                If objFulfillmentOrder.SalesDocumentHeader.SalesUserDefined IsNot Nothing Then
                    salesUserDefined = New GP2010Service.SalesUserDefined

                    With objFulfillmentOrder.SalesDocumentHeader.SalesUserDefined
                        If .Date01 <> Nothing Then
                            salesUserDefined.Date01 = Date.Parse(.Date01.ToShortDateString)
                        End If
                        If .Date02 <> Nothing Then
                            salesUserDefined.Date02 = Date.Parse(.Date02.ToShortDateString)
                        End If
                        If .List01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List01) Then
                            salesUserDefined.List01 = .List01
                        End If
                        If .List02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List02) Then
                            salesUserDefined.List02 = .List02
                        End If
                        If .List03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List03) Then
                            salesUserDefined.List03 = .List03
                        End If
                        If .Text01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text01) Then
                            salesUserDefined.Text01 = .Text01
                        End If
                        If .Text02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text02) Then
                            salesUserDefined.Text02 = .Text02
                        End If
                        If .Text03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text03) Then
                            salesUserDefined.Text03 = .Text03
                        End If
                        If .Text04 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text04) Then
                            salesUserDefined.Text04 = .Text04
                        End If
                        If .Text05 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text05) Then
                            salesUserDefined.Text05 = .Text05
                        End If
                    End With
                    fulfillmentOrder.UserDefined = salesUserDefined
                End If

                'Create Line Items
                Dim orders As GP2010Service.SalesFulfillmentOrderLine()
                ReDim orders(objFulfillmentOrder.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objFulfillmentOrder.SalesDocumentDetails.Count - 1
                    salesOrderLine = New GP2010Service.SalesFulfillmentOrderLine

                    With objFulfillmentOrder.SalesDocumentDetails.Item(i)
                        orderedItem = New GP2010Service.ItemKey
                        orderedItem.Id = .ItemNumber
                        salesOrderLine.ItemKey = orderedItem

                        orderedQty = New GP2010Service.Quantity
                        orderedQty.Value = .Quantity
                        salesOrderLine.Quantity = orderedQty

                        itemPrice = New GP2010Service.MoneyAmount
                        itemPrice.Value = .SellPrice
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesOrderLine.UnitPrice = itemPrice
                        If .DiscountAmount > 0 Then
                            tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                            tdpTradeDiscountPercent.Item = New GP2010Service.MoneyAmount
                            CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Value = .DiscountAmount
                            CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            salesOrderLine.Discount = tdpTradeDiscountPercent
                        End If
                        salesOrderLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))
                        salesOrderLine.ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.ActualShipDate.ToShortDateString())))
                        If .UOM > String.Empty Then
                            salesOrderLine.UofM = .UOM
                        End If

                        If .ItemDescription > String.Empty Then
                            salesOrderLine.ItemDescription = .ItemDescription
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP2010Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesOrderLine.ShippingMethodKey = ShipMethodKey
                        End If

                        If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                            ShipToAddressKey = New GP2010Service.CustomerAddressKey
                            ShipToAddressKey.Id = .ShipToAddressKey
                            ShipToAddressKey.CustomerKey = fulfillmentOrder.CustomerKey
                            salesOrderLine.ShipToAddressKey = ShipToAddressKey
                        End If

                        If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                            taxScheduleKey = New GP2010Service.TaxScheduleKey
                            taxScheduleKey.Id = .TaxScheduleKey
                            salesOrderLine.TaxScheduleKey = taxScheduleKey
                        End If

                        If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                            taxScheduleKey = New GP2010Service.TaxScheduleKey
                            taxScheduleKey.Id = .ItemTaxScheduleKey
                            salesOrderLine.ItemTaxScheduleKey = taxScheduleKey
                        End If
                        salesOrderLine.IsDropShip = .DropShip
                        'salesOrderLine.ItemDescription = "Test"
                        'salesOrderLine.UofM = "each"

                        'Dim PriceLevelKey As New PriceLevelKey
                        'PriceLevelKey.Id = "EACH"
                        'salesOrderLine.PriceLevelKey = PriceLevelKey

                    End With
                    orders(i) = salesOrderLine
                Next
                fulfillmentOrder.Lines = orders

                salesOrderCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateSalesFulfillmentOrder", context)
                objGPConfiguration.GPWS2010.CreateSalesFulfillmentOrder(fulfillmentOrder, context, salesOrderCreatePolicy)

                orders = Nothing
                fulfillmentOrder = Nothing
                'GPSalesOrderNo = fulfillmentOrder.Key.Id
                Return IIf(String.IsNullOrEmpty(GPSalesOrderNo.Trim), "Success", GPSalesOrderNo)
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Create GP 10 Fulfillment Order
        ''' </summary>
        ''' <param name="objFulfillmentOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10FulfillmentOrder(ByVal objFulfillmentOrder As SOP.SalesFulfillmentOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim fulfillmentOrder As GP10Service.SalesFulfillmentOrder
                Dim salesDocumentKey As GP10Service.SalesDocumentKey
                Dim customerKey As GP10Service.CustomerKey
                Dim batchKey As GP10Service.BatchKey
                Dim salesOrderLine As GP10Service.SalesFulfillmentOrderLine
                Dim orderedItem As GP10Service.ItemKey
                Dim freightAmount As GP10Service.MoneyAmount
                Dim orderedQty As GP10Service.Quantity
                Dim ShipMethodKey As GP10Service.ShippingMethodKey
                Dim salesOrderCreatePolicy As GP10Service.Policy
                Dim itemPrice As GP10Service.MoneyAmount
                Dim ShipToAddressKey As GP10Service.CustomerAddressKey
                Dim PhoneNumber As GP10Service.PhoneNumber
                Dim SalespersonKey As GP10Service.SalespersonKey
                Dim PaymentTermsKey As GP10Service.PaymentTermsKey
                Dim ShipToAddress As GP10Service.BusinessAddress
                Dim BillToAddressKey As GP10Service.CustomerAddressKey
                Dim salesPayments As GP10Service.SalesPayment()
                Dim salesPayment As GP10Service.SalesPayment
                Dim paymentCardTypeKey As GP10Service.PaymentCardTypeKey
                Dim moneyAmount As GP10Service.MoneyAmount
                Dim bankAccountKey As GP10Service.BankAccountKey
                Dim salesUserDefined As GP10Service.SalesUserDefined
                Dim salesDocumentTypeKey As GP10Service.SalesDocumentTypeKey
                Dim taxScheduleKey As GP10Service.TaxScheduleKey
                Dim tdpTradeDiscountPercent As GP10Service.MoneyPercentChoice
                Dim GPSalesOrderNo As String = String.Empty

                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"
                fulfillmentOrder = New GP10Service.SalesFulfillmentOrder
                batchKey = New GP10Service.BatchKey
                batchKey.Id = objFulfillmentOrder.SalesDocumentHeader.SOPBatchId
                fulfillmentOrder.BatchKey = batchKey


                If objFulfillmentOrder.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesOrderNo = objFulfillmentOrder.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP10Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesOrderNo
                    fulfillmentOrder.Key = salesDocumentKey
                End If

                If objFulfillmentOrder.SalesDocumentHeader.SalesDocumentTypeKey <> Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesDocumentTypeKey) Then
                    salesDocumentTypeKey = New GP10Service.SalesDocumentTypeKey
                    salesDocumentTypeKey.Id = objFulfillmentOrder.SalesDocumentHeader.SalesDocumentTypeKey
                    salesDocumentTypeKey.Type = GP10Service.SalesDocumentType.FulfillmentOrder
                    fulfillmentOrder.DocumentTypeKey = salesDocumentTypeKey
                End If





                If objFulfillmentOrder.SalesDocumentHeader.TradeDiscountPercent > 0 Then
                    tdpTradeDiscountPercent = New GP10Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP10Service.Percent
                    CType(tdpTradeDiscountPercent.Item, GP10Service.Percent).Value = objFulfillmentOrder.SalesDocumentHeader.TradeDiscountPercent
                    fulfillmentOrder.TradeDiscount = tdpTradeDiscountPercent
                ElseIf objFulfillmentOrder.SalesDocumentHeader.TradeDiscountFlatAmount > 0 Then
                    tdpTradeDiscountPercent = New GP10Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP10Service.MoneyAmount
                    CType(tdpTradeDiscountPercent.Item, GP10Service.MoneyAmount).Value = objFulfillmentOrder.SalesDocumentHeader.TradeDiscountFlatAmount
                    fulfillmentOrder.TradeDiscount = tdpTradeDiscountPercent
                End If

                'Create Order Header
                With objFulfillmentOrder
                    customerKey = New GP10Service.CustomerKey
                    customerKey.Id = .SalesDocumentHeader.CustomerId
                    fulfillmentOrder.CustomerKey = customerKey
                    If .SalesDocumentHeader.PriceLevel > String.Empty Then
                        fulfillmentOrder.PriceLevelKey = New GP10Service.PriceLevelKey
                        fulfillmentOrder.PriceLevelKey.Id = .SalesDocumentHeader.PriceLevel
                    End If
                    If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                        SalespersonKey = New GP10Service.SalespersonKey
                        SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                        fulfillmentOrder.SalespersonKey = SalespersonKey
                    End If

                    fulfillmentOrder.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                    fulfillmentOrder.Date = Date.Parse(Date.Today.ToShortDateString)
                    fulfillmentOrder.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                    fulfillmentOrder.RequestedShipDate = IIf(.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.RequestedShipDate.ToShortDateString)))
                    fulfillmentOrder.ActualShipDate = IIf(.SalesDocumentHeader.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.ActualShipDate.ToShortDateString)))

                    If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                        PaymentTermsKey = New GP10Service.PaymentTermsKey
                        PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                        fulfillmentOrder.PaymentTermsKey = PaymentTermsKey
                    End If

                    fulfillmentOrder.Note = .SalesDocumentHeader.CustomerNote
                End With
                fulfillmentOrder.TaxExemptNumber1 = objFulfillmentOrder.SalesDocumentHeader.TaxExempt1
                fulfillmentOrder.TaxExemptNumber2 = objFulfillmentOrder.SalesDocumentHeader.TaxExempt2
                fulfillmentOrder.TaxRegistrationNumber = objFulfillmentOrder.SalesDocumentHeader.TaxRegistrationNumber
                'Create Shipping Address
                ShipToAddress = New GP10Service.BusinessAddress
                With ShipToAddress
                    .Name = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.City
                    .State = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.State
                    .PostalCode = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.ContactPerson
                    .CountryRegion = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.Country
                    If objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP10Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If
                    PhoneNumber = New GP10Service.PhoneNumber
                    PhoneNumber.Value = objFulfillmentOrder.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                End With
                fulfillmentOrder.ShipToAddress = ShipToAddress

                If objFulfillmentOrder.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.ShipToAddressKey.Trim) Then
                    ShipToAddressKey = New GP10Service.CustomerAddressKey
                    ShipToAddressKey.CustomerKey = customerKey
                    ShipToAddressKey.Id = objFulfillmentOrder.SalesDocumentHeader.ShipToAddressKey
                    fulfillmentOrder.ShipToAddressKey = ShipToAddressKey
                End If

                If objFulfillmentOrder.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.BillToAddressKey.Trim) Then
                    BillToAddressKey = New GP10Service.CustomerAddressKey
                    BillToAddressKey.CustomerKey = customerKey
                    BillToAddressKey.Id = objFulfillmentOrder.SalesDocumentHeader.BillToAddressKey
                    fulfillmentOrder.BillToAddressKey = BillToAddressKey
                End If

                If objFulfillmentOrder.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objFulfillmentOrder.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP10Service.ShippingMethodKey
                    ShipMethodKey.Id = objFulfillmentOrder.SalesDocumentHeader.ShipmethodKey
                    fulfillmentOrder.ShippingMethodKey = ShipMethodKey
                End If

                If objFulfillmentOrder.SalesDocumentHeader.PaymentAmount > 0 Then
                    moneyAmount = New GP10Service.MoneyAmount
                    moneyAmount.Value = objFulfillmentOrder.SalesDocumentHeader.PaymentAmount
                    moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                    fulfillmentOrder.PaymentAmount = moneyAmount
                End If

                If Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.TaxScheduleKey) Then
                    taxScheduleKey = New GP10Service.TaxScheduleKey
                    taxScheduleKey.Id = objFulfillmentOrder.SalesDocumentHeader.TaxScheduleKey
                    fulfillmentOrder.TaxScheduleKey = taxScheduleKey
                End If

                freightAmount = New GP10Service.MoneyAmount
                freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                freightAmount.Value = objFulfillmentOrder.SalesDocumentHeader.FreightAmount
                fulfillmentOrder.FreightAmount = freightAmount

                If objFulfillmentOrder.SalesDocumentHeader.SalesPayments.Count > 0 Then
                    ReDim salesPayments(objFulfillmentOrder.SalesDocumentHeader.SalesPayments.Count - 1)
                    For i As Integer = 0 To objFulfillmentOrder.SalesDocumentHeader.SalesPayments.Count - 1
                        salesPayment = New GP10Service.SalesPayment

                        salesPayment.Type = GP10Service.SalesPaymentType.PaymentCardDeposit

                        paymentCardTypeKey = New GP10Service.PaymentCardTypeKey
                        paymentCardTypeKey.Id = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey
                        salesPayment.PaymentCardTypeKey = paymentCardTypeKey

                        moneyAmount = New GP10Service.MoneyAmount
                        moneyAmount.Value = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentAmount
                        moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesPayment.PaymentAmount = moneyAmount


                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode) Then
                            salesPayment.AuthorizationCode = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey) Then
                            bankAccountKey = New GP10Service.BankAccountKey
                            bankAccountKey.Id = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey
                            salesPayment.BankAccountKey = bankAccountKey
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber) Then
                            salesPayment.PaymentCardNumber = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber) Then
                            salesPayment.CheckNumber = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber
                        End If

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).Number IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).Number) Then
                            salesPayment.Number = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).Number
                        End If

                        salesPayment.ExpirationDate = IIf(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.ToShortDateString))

                        If objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode) Then
                            salesPayment.AuditTrailCode = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode
                        End If
                        salesPayment.DeleteOnUpdate = objFulfillmentOrder.SalesDocumentHeader.SalesPayments(i).DeleteOnUpdate


                        salesPayments(i) = salesPayment
                    Next

                    fulfillmentOrder.Payments = salesPayments
                End If

                'create up SalesUserDefined
                If objFulfillmentOrder.SalesDocumentHeader.SalesUserDefined IsNot Nothing Then
                    salesUserDefined = New GP10Service.SalesUserDefined

                    With objFulfillmentOrder.SalesDocumentHeader.SalesUserDefined
                        If .Date01 <> Nothing Then
                            salesUserDefined.Date01 = Date.Parse(.Date01.ToShortDateString)
                        End If
                        If .Date02 <> Nothing Then
                            salesUserDefined.Date02 = Date.Parse(.Date02.ToShortDateString)
                        End If
                        If .List01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List01) Then
                            salesUserDefined.List01 = .List01
                        End If
                        If .List02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List02) Then
                            salesUserDefined.List02 = .List02
                        End If
                        If .List03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List03) Then
                            salesUserDefined.List03 = .List03
                        End If
                        If .Text01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text01) Then
                            salesUserDefined.Text01 = .Text01
                        End If
                        If .Text02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text02) Then
                            salesUserDefined.Text02 = .Text02
                        End If
                        If .Text03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text03) Then
                            salesUserDefined.Text03 = .Text03
                        End If
                        If .Text04 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text04) Then
                            salesUserDefined.Text04 = .Text04
                        End If
                        If .Text05 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text05) Then
                            salesUserDefined.Text05 = .Text05
                        End If
                    End With
                    fulfillmentOrder.UserDefined = salesUserDefined
                End If

                'Create Line Items
                Dim orders As GP10Service.SalesFulfillmentOrderLine()
                ReDim orders(objFulfillmentOrder.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objFulfillmentOrder.SalesDocumentDetails.Count - 1
                    salesOrderLine = New GP10Service.SalesFulfillmentOrderLine

                    With objFulfillmentOrder.SalesDocumentDetails.Item(i)
                        orderedItem = New GP10Service.ItemKey
                        orderedItem.Id = .ItemNumber
                        salesOrderLine.ItemKey = orderedItem

                        orderedQty = New GP10Service.Quantity
                        orderedQty.Value = .Quantity
                        salesOrderLine.Quantity = orderedQty

                        itemPrice = New GP10Service.MoneyAmount
                        itemPrice.Value = .SellPrice
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesOrderLine.UnitPrice = itemPrice
                        If .DiscountAmount > 0 Then
                            tdpTradeDiscountPercent = New GP10Service.MoneyPercentChoice
                            tdpTradeDiscountPercent.Item = New GP10Service.MoneyAmount
                            CType(tdpTradeDiscountPercent.Item, GP10Service.MoneyAmount).Value = .DiscountAmount
                            salesOrderLine.Discount = tdpTradeDiscountPercent
                        End If
                        salesOrderLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))
                        salesOrderLine.ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.ActualShipDate.ToShortDateString())))
                        If .UOM > String.Empty Then
                            salesOrderLine.UofM = .UOM
                        End If

                        If .ItemDescription > String.Empty Then
                            salesOrderLine.ItemDescription = .ItemDescription
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP10Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesOrderLine.ShippingMethodKey = ShipMethodKey
                        End If

                        If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                            ShipToAddressKey = New GP10Service.CustomerAddressKey
                            ShipToAddressKey.Id = .ShipToAddressKey
                            ShipToAddressKey.CustomerKey = fulfillmentOrder.CustomerKey
                            salesOrderLine.ShipToAddressKey = ShipToAddressKey
                        End If

                        If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                            taxScheduleKey = New GP10Service.TaxScheduleKey
                            taxScheduleKey.Id = .TaxScheduleKey
                            salesOrderLine.TaxScheduleKey = taxScheduleKey
                        End If

                        If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                            taxScheduleKey = New GP10Service.TaxScheduleKey
                            taxScheduleKey.Id = .ItemTaxScheduleKey
                            salesOrderLine.ItemTaxScheduleKey = taxScheduleKey
                        End If
                        salesOrderLine.IsDropShip = .DropShip
                        'salesOrderLine.ItemDescription = "Test"
                        'salesOrderLine.UofM = "each"

                        'Dim PriceLevelKey As New PriceLevelKey
                        'PriceLevelKey.Id = "EACH"
                        'salesOrderLine.PriceLevelKey = PriceLevelKey

                    End With
                    orders(i) = salesOrderLine
                Next
                fulfillmentOrder.Lines = orders

                salesOrderCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateSalesFulfillmentOrder", context)
                objGPConfiguration.GPWS10.CreateSalesFulfillmentOrder(fulfillmentOrder, context, salesOrderCreatePolicy)

                orders = Nothing
                fulfillmentOrder = Nothing
                'GPSalesOrderNo = fulfillmentOrder.Key.Id
                Return IIf(String.IsNullOrEmpty(GPSalesOrderNo.Trim), "Success", GPSalesOrderNo)
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Create GP Sales Order
        ''' </summary>
        ''' <param name="objSalesOrder"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPSalesOrder(ByVal objSalesOrder As SOP.SalesOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10SalesOrder(objSalesOrder, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010SalesOrder(objSalesOrder, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Create GP 2010 Sales Order
        ''' </summary>
        ''' <param name="objSalesOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010SalesOrder(ByVal objSalesOrder As SOP.SalesOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim salesOrder As GP2010Service.SalesOrder
                Dim salesDocumentKey As GP2010Service.SalesDocumentKey
                Dim customerKey As GP2010Service.CustomerKey
                Dim batchKey As GP2010Service.BatchKey
                Dim salesOrderLine As GP2010Service.SalesOrderLine
                Dim orderedItem As GP2010Service.ItemKey
                Dim freightAmount As GP2010Service.MoneyAmount
                Dim orderedQty As GP2010Service.Quantity
                Dim ShipMethodKey As GP2010Service.ShippingMethodKey
                Dim salesOrderCreatePolicy As GP2010Service.Policy
                Dim itemPrice As GP2010Service.MoneyAmount
                Dim ShipToAddressKey As GP2010Service.CustomerAddressKey
                Dim PhoneNumber As GP2010Service.PhoneNumber
                Dim SalespersonKey As GP2010Service.SalespersonKey
                Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
                Dim ShipToAddress As GP2010Service.BusinessAddress
                Dim BillToAddressKey As GP2010Service.CustomerAddressKey
                Dim salesPayments As GP2010Service.SalesPayment()
                Dim salesPayment As GP2010Service.SalesPayment
                Dim paymentCardTypeKey As GP2010Service.PaymentCardTypeKey
                Dim moneyAmount As GP2010Service.MoneyAmount
                Dim bankAccountKey As GP2010Service.BankAccountKey
                Dim salesUserDefined As GP2010Service.SalesUserDefined
                Dim salesDocumentTypeKey As GP2010Service.SalesDocumentTypeKey
                Dim taxScheduleKey As GP2010Service.TaxScheduleKey
                Dim tdpTradeDiscountPercent As GP2010Service.MoneyPercentChoice
                Dim GPSalesOrderNo As String = String.Empty
                Dim trkTrackingNumber As GP2010Service.SalesTrackingNumber
                Dim blnFoundTracking As Boolean
                Dim lstNumbers As New List(Of GP2010Service.SalesTrackingNumber)
                'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity

                'Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = objGPConfiguration.GP2010GetContext
                companyKey = objGPConfiguration.GP2010GetCompanyKey
                salesOrder = New GP2010Service.SalesOrder
                batchKey = New GP2010Service.BatchKey
                batchKey.Id = objSalesOrder.SalesDocumentHeader.SOPBatchId
                salesOrder.BatchKey = batchKey

                If objSalesOrder.SalesDocumentHeader.PriceLevel > String.Empty Then
                    salesOrder.PriceLevelKey = New GP2010Service.PriceLevelKey
                    salesOrder.PriceLevelKey.Id = objSalesOrder.SalesDocumentHeader.PriceLevel
                End If
                If objSalesOrder.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesOrderNo = objSalesOrder.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP2010Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesOrderNo
                    salesOrder.Key = salesDocumentKey
                End If

                If objSalesOrder.SalesDocumentHeader.SalesDocumentTypeKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesDocumentTypeKey) Then
                    salesDocumentTypeKey = New GP2010Service.SalesDocumentTypeKey
                    salesDocumentTypeKey.Id = objSalesOrder.SalesDocumentHeader.SalesDocumentTypeKey
                    salesOrder.DocumentTypeKey = salesDocumentTypeKey
                End If





                If objSalesOrder.SalesDocumentHeader.TradeDiscountPercent > 0 Then
                    tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP2010Service.Percent
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.Percent).Value = objSalesOrder.SalesDocumentHeader.TradeDiscountPercent
                    salesOrder.TradeDiscount = tdpTradeDiscountPercent
                ElseIf objSalesOrder.SalesDocumentHeader.TradeDiscountFlatAmount > 0 Then
                    tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP2010Service.MoneyAmount
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Value = objSalesOrder.SalesDocumentHeader.TradeDiscountFlatAmount
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Currency = objGPConfiguration.CurrencyCode
                    salesOrder.TradeDiscount = tdpTradeDiscountPercent
                End If


                Dim stsNumbers() As GP2010Service.SalesTrackingNumber = {}
                If objSalesOrder.SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                    For intLoop As Integer = 0 To objSalesOrder.SalesDocumentHeader.TrackingNumbers.Count - 1
                        blnFoundTracking = False
                        For Each trkTrackingNumber In lstNumbers
                            If trkTrackingNumber.Key.Id = objSalesOrder.SalesDocumentHeader.TrackingNumbers(intLoop) Then
                                blnFoundTracking = True
                            End If
                        Next
                        If blnFoundTracking = False Then
                            trkTrackingNumber = New GP2010Service.SalesTrackingNumber
                            trkTrackingNumber.Key = New GP2010Service.SalesTrackingNumberKey
                            trkTrackingNumber.Key.SalesDocumentKey = salesOrder.Key
                            trkTrackingNumber.Key.Id = objSalesOrder.SalesDocumentHeader.TrackingNumbers(intLoop)
                            lstNumbers.Add(trkTrackingNumber)
                        End If
                    Next
                    salesOrder.TrackingNumbers = lstNumbers.ToArray
                End If

                'Create Order Header
                With objSalesOrder
                    customerKey = New GP2010Service.CustomerKey
                    customerKey.Id = .SalesDocumentHeader.CustomerId
                    salesOrder.CustomerKey = customerKey
                    salesOrder.CustomerName = .SalesDocumentHeader.CustomerName
                    If .SalesDocumentHeader.DefaultSiteId IsNot Nothing Then
                        salesOrder.WarehouseKey = New GP2010Service.WarehouseKey
                        salesOrder.WarehouseKey.Id = .SalesDocumentHeader.DefaultSiteId
                    End If
                    If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                        SalespersonKey = New GP2010Service.SalespersonKey
                        SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                        salesOrder.SalespersonKey = SalespersonKey
                    End If

                    salesOrder.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                    If .SalesDocumentHeader.OrderDate.HasValue = True Then
                        salesOrder.Date = Date.Parse(.SalesDocumentHeader.OrderDate.Value.ToShortDateString)
                    Else
                        salesOrder.Date = Date.Parse(Date.Today.ToShortDateString)
                    End If
                    salesOrder.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                    salesOrder.RequestedShipDate = IIf(.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.RequestedShipDate.ToShortDateString)))
                    salesOrder.ActualShipDate = IIf(.SalesDocumentHeader.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.ActualShipDate.ToShortDateString)))

                    If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                        PaymentTermsKey = New GP2010Service.PaymentTermsKey
                        PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                        salesOrder.PaymentTermsKey = PaymentTermsKey
                    End If

                    salesOrder.Note = .SalesDocumentHeader.CustomerNote
                End With

                If objSalesOrder.SalesDocumentHeader.FreightTaxKey > String.Empty Then
                    taxScheduleKey = New GP2010Service.TaxScheduleKey
                    taxScheduleKey.Id = objSalesOrder.SalesDocumentHeader.FreightTaxKey
                    salesOrder.FreightTaxScheduleKey = taxScheduleKey

                End If

                salesOrder.TaxExemptNumber1 = objSalesOrder.SalesDocumentHeader.TaxExempt1
                salesOrder.TaxExemptNumber2 = objSalesOrder.SalesDocumentHeader.TaxExempt2
                salesOrder.TaxRegistrationNumber = objSalesOrder.SalesDocumentHeader.TaxRegistrationNumber
                'Create Shipping Address
                ShipToAddress = New GP2010Service.BusinessAddress
                With ShipToAddress
                    .Name = objSalesOrder.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objSalesOrder.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objSalesOrder.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objSalesOrder.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objSalesOrder.SalesDocumentHeader.ShipToAddress.City
                    .State = objSalesOrder.SalesDocumentHeader.ShipToAddress.State
                    .PostalCode = objSalesOrder.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objSalesOrder.SalesDocumentHeader.ShipToAddress.ContactPerson
                    .CountryRegion = objSalesOrder.SalesDocumentHeader.ShipToAddress.Country
                    If objSalesOrder.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP2010Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objSalesOrder.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If
                    PhoneNumber = New GP2010Service.PhoneNumber
                    PhoneNumber.Value = objSalesOrder.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                End With
                salesOrder.ShipToAddress = ShipToAddress

                If objSalesOrder.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.BillToAddressKey.Trim) Then
                    BillToAddressKey = New GP2010Service.CustomerAddressKey
                    BillToAddressKey.CompanyKey = companyKey
                    BillToAddressKey.CustomerKey = customerKey
                    BillToAddressKey.Id = objSalesOrder.SalesDocumentHeader.BillToAddressKey
                    salesOrder.BillToAddressKey = BillToAddressKey
                End If


                If objSalesOrder.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.ShipToAddressKey.Trim) Then
                    ShipToAddressKey = New GP2010Service.CustomerAddressKey
                    ShipToAddressKey.CustomerKey = customerKey
                    ShipToAddressKey.Id = objSalesOrder.SalesDocumentHeader.ShipToAddressKey
                    salesOrder.ShipToAddressKey = ShipToAddressKey
                End If

                If objSalesOrder.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objSalesOrder.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP2010Service.ShippingMethodKey
                    ShipMethodKey.Id = objSalesOrder.SalesDocumentHeader.ShipmethodKey
                    salesOrder.ShippingMethodKey = ShipMethodKey
                End If

                If objSalesOrder.SalesDocumentHeader.PaymentAmount > 0 Then
                    moneyAmount = New GP2010Service.MoneyAmount
                    moneyAmount.Value = objSalesOrder.SalesDocumentHeader.PaymentAmount
                    moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                    salesOrder.PaymentAmount = moneyAmount
                End If

                If Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.TaxScheduleKey) Then
                    taxScheduleKey = New GP2010Service.TaxScheduleKey
                    taxScheduleKey.Id = objSalesOrder.SalesDocumentHeader.TaxScheduleKey
                    salesOrder.TaxScheduleKey = taxScheduleKey
                End If

                freightAmount = New GP2010Service.MoneyAmount
                freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                freightAmount.Value = objSalesOrder.SalesDocumentHeader.FreightAmount
                salesOrder.FreightAmount = freightAmount

                If objSalesOrder.SalesDocumentHeader.SalesPayments.Count > 0 Then
                    ReDim salesPayments(objSalesOrder.SalesDocumentHeader.SalesPayments.Count - 1)
                    For i As Integer = 0 To objSalesOrder.SalesDocumentHeader.SalesPayments.Count - 1
                        salesPayment = New DynamicsWCFService.SalesPayment

                        Select Case objSalesOrder.SalesDocumentHeader.SalesPayments(i).SalesPaymentType
                            Case SOP.SalesPayment.PaymentType.Cash_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.CashDeposit
                            Case SOP.SalesPayment.PaymentType.Cash_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.CashPayment
                            Case SOP.SalesPayment.PaymentType.Check_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.CheckPayment
                            Case SOP.SalesPayment.PaymentType.Check_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.CheckDeposit
                            Case SOP.SalesPayment.PaymentType.Payment_Card_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.PaymentCardDeposit
                            Case SOP.SalesPayment.PaymentType.Payment_Card_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.PaymentCardPayment
                        End Select


                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey > String.Empty Then
                            paymentCardTypeKey = New GP2010Service.PaymentCardTypeKey
                            paymentCardTypeKey.Id = objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey
                            salesPayment.PaymentCardTypeKey = paymentCardTypeKey
                        End If


                        moneyAmount = New GP2010Service.MoneyAmount
                        moneyAmount.Value = objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentAmount
                        moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesPayment.PaymentAmount = moneyAmount


                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode) Then
                            salesPayment.AuthorizationCode = objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode
                        End If

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey) Then
                            bankAccountKey = New GP2010Service.BankAccountKey
                            bankAccountKey.Id = objSalesOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey
                            salesPayment.BankAccountKey = bankAccountKey
                        End If

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber) Then
                            salesPayment.PaymentCardNumber = objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber
                        End If

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber) Then
                            salesPayment.CheckNumber = objSalesOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber
                        End If
                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).Number IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).Number) Then
                            salesPayment.Number = objSalesOrder.SalesDocumentHeader.SalesPayments(i).Number
                        End If

                        salesPayment.ExpirationDate = IIf(objSalesOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.ToShortDateString))

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode) Then
                            salesPayment.AuditTrailCode = objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode
                        End If
                        salesPayment.DeleteOnUpdate = objSalesOrder.SalesDocumentHeader.SalesPayments(i).DeleteOnUpdate


                        salesPayments(i) = salesPayment
                    Next

                    salesOrder.Payments = salesPayments
                End If

                'create up SalesUserDefined
                If objSalesOrder.SalesDocumentHeader.SalesUserDefined IsNot Nothing Then
                    salesUserDefined = New GP2010Service.SalesUserDefined

                    With objSalesOrder.SalesDocumentHeader.SalesUserDefined
                        If .Date01 <> Nothing Then
                            salesUserDefined.Date01 = Date.Parse(.Date01.ToShortDateString)
                        End If
                        If .Date02 <> Nothing Then
                            salesUserDefined.Date02 = Date.Parse(.Date02.ToShortDateString)
                        End If
                        If .List01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List01) Then
                            salesUserDefined.List01 = .List01
                        End If
                        If .List02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List02) Then
                            salesUserDefined.List02 = .List02
                        End If
                        If .List03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List03) Then
                            salesUserDefined.List03 = .List03
                        End If
                        If .Text01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text01) Then
                            salesUserDefined.Text01 = .Text01
                        End If
                        If .Text02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text02) Then
                            salesUserDefined.Text02 = .Text02
                        End If
                        If .Text03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text03) Then
                            salesUserDefined.Text03 = .Text03
                        End If
                        If .Text04 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text04) Then
                            salesUserDefined.Text04 = .Text04
                        End If
                        If .Text05 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text05) Then
                            salesUserDefined.Text05 = .Text05
                        End If
                    End With
                    salesOrder.UserDefined = salesUserDefined
                End If

                'Create Line Items
                Dim orders As GP2010Service.SalesOrderLine()
                ReDim orders(objSalesOrder.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objSalesOrder.SalesDocumentDetails.Count - 1
                    salesOrderLine = New GP2010Service.SalesOrderLine

                    With objSalesOrder.SalesDocumentDetails.Item(i)
                        orderedItem = New GP2010Service.ItemKey
                        orderedItem.Id = .ItemNumber
                        salesOrderLine.ItemKey = orderedItem
                        If .UnitCost.HasValue = True Then
                            salesOrderLine.UnitCost = New GP2010Service.MoneyAmount()
                            salesOrderLine.UnitCost.Value = .UnitCost.Value
                            salesOrderLine.UnitCost.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        End If
                        If .NonInventory Then
                            salesOrderLine.IsNonInventory = True
                        End If
                        orderedQty = New GP2010Service.Quantity
                        orderedQty.Value = .Quantity
                        salesOrderLine.Quantity = orderedQty

                        itemPrice = New GP2010Service.MoneyAmount
                        itemPrice.Value = .SellPrice
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesOrderLine.UnitPrice = itemPrice
                        If .DiscountAmount > 0 Then
                            tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                            tdpTradeDiscountPercent.Item = New GP2010Service.MoneyAmount
                            CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Value = .DiscountAmount
                            CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Currency = objGPConfiguration.CurrencyCode
                            salesOrderLine.Discount = tdpTradeDiscountPercent
                        End If
                        salesOrderLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))
                        salesOrderLine.ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.ActualShipDate.ToShortDateString())))
                        If .UOM > String.Empty Then
                            salesOrderLine.UofM = .UOM
                        End If
                        If .SiteID IsNot Nothing Then
                            salesOrderLine.WarehouseKey = New GP2010Service.WarehouseKey
                            salesOrderLine.WarehouseKey.Id = .SiteID
                        End If
                        If .ItemDescription > String.Empty Then
                            salesOrderLine.ItemDescription = .ItemDescription
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP2010Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesOrderLine.ShippingMethodKey = ShipMethodKey
                        End If

                        If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                            ShipToAddressKey = New GP2010Service.CustomerAddressKey
                            ShipToAddressKey.Id = .ShipToAddressKey
                            ShipToAddressKey.CustomerKey = salesOrder.CustomerKey
                            salesOrderLine.ShipToAddressKey = ShipToAddressKey
                        End If

                        If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                            taxScheduleKey = New GP2010Service.TaxScheduleKey
                            taxScheduleKey.Id = .TaxScheduleKey
                            salesOrderLine.TaxScheduleKey = taxScheduleKey
                        End If

                        If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                            taxScheduleKey = New GP2010Service.TaxScheduleKey
                            taxScheduleKey.Id = .ItemTaxScheduleKey
                            salesOrderLine.ItemTaxScheduleKey = taxScheduleKey
                        End If
                        salesOrderLine.IsDropShip = .DropShip
                        'salesOrderLine.ItemDescription = "Test"
                        'salesOrderLine.UofM = "each"

                        'Dim PriceLevelKey As New PriceLevelKey
                        'PriceLevelKey.Id = "EACH"
                        'salesOrderLine.PriceLevelKey = PriceLevelKey

                    End With
                    orders(i) = salesOrderLine
                Next
                salesOrder.Lines = orders

                salesOrderCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateSalesOrder", context)
                objGPConfiguration.GPWS2010.CreateSalesOrder(salesOrder, context, salesOrderCreatePolicy)

                orders = Nothing
                salesOrder = Nothing
                'GPSalesOrderNo = salesOrder.Key.Id
                Return IIf(String.IsNullOrEmpty(GPSalesOrderNo.Trim), "Success", GPSalesOrderNo)
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException("Error Creating Sales Order", ex)
            End Try
        End Function
        ''' <summary>
        ''' Create GP 10 Sales Order
        ''' </summary>
        ''' <param name="objSalesOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10SalesOrder(ByVal objSalesOrder As SOP.SalesOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim salesOrder As GP10Service.SalesOrder
                Dim salesDocumentKey As GP10Service.SalesDocumentKey
                Dim customerKey As GP10Service.CustomerKey
                Dim batchKey As GP10Service.BatchKey
                Dim salesOrderLine As GP10Service.SalesOrderLine
                Dim orderedItem As GP10Service.ItemKey
                Dim freightAmount As GP10Service.MoneyAmount
                Dim orderedQty As GP10Service.Quantity
                Dim ShipMethodKey As GP10Service.ShippingMethodKey
                Dim salesOrderCreatePolicy As GP10Service.Policy
                Dim itemPrice As GP10Service.MoneyAmount
                Dim ShipToAddressKey As GP10Service.CustomerAddressKey
                Dim PhoneNumber As GP10Service.PhoneNumber
                Dim SalespersonKey As GP10Service.SalespersonKey
                Dim PaymentTermsKey As GP10Service.PaymentTermsKey
                Dim ShipToAddress As GP10Service.BusinessAddress
                Dim BillToAddressKey As GP10Service.CustomerAddressKey
                Dim salesPayments As GP10Service.SalesPayment()
                Dim salesPayment As GP10Service.SalesPayment
                Dim paymentCardTypeKey As GP10Service.PaymentCardTypeKey
                Dim moneyAmount As GP10Service.MoneyAmount
                Dim bankAccountKey As GP10Service.BankAccountKey
                Dim salesUserDefined As GP10Service.SalesUserDefined
                Dim salesDocumentTypeKey As GP10Service.SalesDocumentTypeKey
                Dim taxScheduleKey As GP10Service.TaxScheduleKey
                Dim tdpTradeDiscountPercent As GP10Service.MoneyPercentChoice
                Dim GPSalesOrderNo As String = String.Empty

                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity

                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"
                salesOrder = New GP10Service.SalesOrder
                batchKey = New GP10Service.BatchKey
                batchKey.Id = objSalesOrder.SalesDocumentHeader.SOPBatchId
                salesOrder.BatchKey = batchKey


                If objSalesOrder.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesOrderNo = objSalesOrder.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP10Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesOrderNo
                    salesOrder.Key = salesDocumentKey
                End If

                salesOrder.TaxExemptNumber1 = objSalesOrder.SalesDocumentHeader.TaxExempt1
                salesOrder.TaxExemptNumber2 = objSalesOrder.SalesDocumentHeader.TaxExempt2
                salesOrder.TaxRegistrationNumber = objSalesOrder.SalesDocumentHeader.TaxRegistrationNumber

                If objSalesOrder.SalesDocumentHeader.SalesDocumentTypeKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesDocumentTypeKey) Then
                    salesDocumentTypeKey = New GP10Service.SalesDocumentTypeKey
                    salesDocumentTypeKey.Id = objSalesOrder.SalesDocumentHeader.SalesDocumentTypeKey
                    salesOrder.DocumentTypeKey = salesDocumentTypeKey
                End If


                If objSalesOrder.SalesDocumentHeader.PriceLevel > String.Empty Then
                    salesOrder.PriceLevelKey = New GP10Service.PriceLevelKey
                    salesOrder.PriceLevelKey.Id = objSalesOrder.SalesDocumentHeader.PriceLevel
                End If

                salesOrder.Comment = objSalesOrder.SalesDocumentHeader.Comment
                If objSalesOrder.SalesDocumentHeader.CommentKey > String.Empty Then
                    salesOrder.CommentKey = New GP10Service.CommentKey
                    salesOrder.CommentKey.Id = objSalesOrder.SalesDocumentHeader.CommentKey
                End If
                

                If objSalesOrder.SalesDocumentHeader.TradeDiscountPercent > 0 Then
                    tdpTradeDiscountPercent = New GP10Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP10Service.Percent
                    CType(tdpTradeDiscountPercent.Item, GP10Service.Percent).Value = objSalesOrder.SalesDocumentHeader.TradeDiscountPercent
                    salesOrder.TradeDiscount = tdpTradeDiscountPercent
                ElseIf objSalesOrder.SalesDocumentHeader.TradeDiscountFlatAmount > 0 Then
                    tdpTradeDiscountPercent = New GP10Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP10Service.MoneyAmount
                    CType(tdpTradeDiscountPercent.Item, GP10Service.MoneyAmount).Value = objSalesOrder.SalesDocumentHeader.TradeDiscountFlatAmount
                    salesOrder.TradeDiscount = tdpTradeDiscountPercent
                End If

                'Create Order Header
                With objSalesOrder
                    customerKey = New GP10Service.CustomerKey
                    customerKey.Id = .SalesDocumentHeader.CustomerId
                    salesOrder.CustomerKey = customerKey

                    If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                        SalespersonKey = New GP10Service.SalespersonKey
                        SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                        salesOrder.SalespersonKey = SalespersonKey
                    End If

                    salesOrder.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                    salesOrder.Date = Date.Parse(Date.Today.ToShortDateString)
                    salesOrder.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                    salesOrder.RequestedShipDate = IIf(.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.RequestedShipDate.ToShortDateString)))
                    salesOrder.ActualShipDate = IIf(.SalesDocumentHeader.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.SalesDocumentHeader.ActualShipDate.ToShortDateString)))

                    If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                        PaymentTermsKey = New GP10Service.PaymentTermsKey
                        PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                        salesOrder.PaymentTermsKey = PaymentTermsKey
                    End If

                    salesOrder.Note = .SalesDocumentHeader.CustomerNote
                End With

                'Create Shipping Address
                ShipToAddress = New GP10Service.BusinessAddress
                With ShipToAddress
                    .Name = objSalesOrder.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objSalesOrder.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objSalesOrder.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objSalesOrder.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objSalesOrder.SalesDocumentHeader.ShipToAddress.City
                    .State = objSalesOrder.SalesDocumentHeader.ShipToAddress.State
                    .PostalCode = objSalesOrder.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objSalesOrder.SalesDocumentHeader.ShipToAddress.ContactPerson
                    .CountryRegion = objSalesOrder.SalesDocumentHeader.ShipToAddress.Country
                    If objSalesOrder.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP10Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objSalesOrder.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If

                    PhoneNumber = New GP10Service.PhoneNumber
                    PhoneNumber.Value = objSalesOrder.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                End With
                salesOrder.ShipToAddress = ShipToAddress

                If objSalesOrder.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.BillToAddressKey.Trim) Then
                    BillToAddressKey = New GP10Service.CustomerAddressKey
                    BillToAddressKey.CustomerKey = customerKey
                    BillToAddressKey.Id = objSalesOrder.SalesDocumentHeader.BillToAddressKey
                    salesOrder.BillToAddressKey = BillToAddressKey
                End If

                If objSalesOrder.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.ShipToAddressKey.Trim) Then
                    ShipToAddressKey = New GP10Service.CustomerAddressKey
                    ShipToAddressKey.CustomerKey = customerKey
                    ShipToAddressKey.Id = objSalesOrder.SalesDocumentHeader.ShipToAddressKey
                    salesOrder.ShipToAddressKey = ShipToAddressKey
                End If

                If objSalesOrder.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objSalesOrder.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP10Service.ShippingMethodKey
                    ShipMethodKey.Id = objSalesOrder.SalesDocumentHeader.ShipmethodKey
                    salesOrder.ShippingMethodKey = ShipMethodKey
                End If

                If objSalesOrder.SalesDocumentHeader.PaymentAmount > 0 Then
                    moneyAmount = New GP10Service.MoneyAmount
                    moneyAmount.Value = objSalesOrder.SalesDocumentHeader.PaymentAmount
                    moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                    salesOrder.PaymentAmount = moneyAmount
                End If

                If Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.TaxScheduleKey) Then
                    taxScheduleKey = New GP10Service.TaxScheduleKey
                    taxScheduleKey.Id = objSalesOrder.SalesDocumentHeader.TaxScheduleKey
                    salesOrder.TaxScheduleKey = taxScheduleKey
                End If



                freightAmount = New GP10Service.MoneyAmount
                freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                freightAmount.Value = objSalesOrder.SalesDocumentHeader.FreightAmount
                salesOrder.FreightAmount = freightAmount

                If objSalesOrder.SalesDocumentHeader.SalesPayments.Count > 0 Then
                    ReDim salesPayments(objSalesOrder.SalesDocumentHeader.SalesPayments.Count - 1)
                    For i As Integer = 0 To objSalesOrder.SalesDocumentHeader.SalesPayments.Count - 1
                        salesPayment = New GP10Service.SalesPayment

                        salesPayment.Type = GP10Service.SalesPaymentType.PaymentCardDeposit

                        paymentCardTypeKey = New GP10Service.PaymentCardTypeKey
                        paymentCardTypeKey.Id = objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey
                        salesPayment.PaymentCardTypeKey = paymentCardTypeKey

                        moneyAmount = New GP10Service.MoneyAmount
                        moneyAmount.Value = objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentAmount
                        moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesPayment.PaymentAmount = moneyAmount


                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode) Then
                            salesPayment.AuthorizationCode = objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuthorizationCode
                        End If

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey) Then
                            bankAccountKey = New GP10Service.BankAccountKey
                            bankAccountKey.Id = objSalesOrder.SalesDocumentHeader.SalesPayments(i).BankAccountKey
                            salesPayment.BankAccountKey = bankAccountKey
                        End If

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber) Then
                            salesPayment.PaymentCardNumber = objSalesOrder.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber
                        End If

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber) Then
                            salesPayment.CheckNumber = objSalesOrder.SalesDocumentHeader.SalesPayments(i).CheckNumber
                        End If

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).Number IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).Number) Then
                            salesPayment.Number = objSalesOrder.SalesDocumentHeader.SalesPayments(i).Number
                        End If

                        salesPayment.ExpirationDate = IIf(objSalesOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesOrder.SalesDocumentHeader.SalesPayments(i).ExpirationDate.ToShortDateString))

                        If objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode) Then
                            salesPayment.AuditTrailCode = objSalesOrder.SalesDocumentHeader.SalesPayments(i).AuditTrailCode
                        End If
                        salesPayment.DeleteOnUpdate = objSalesOrder.SalesDocumentHeader.SalesPayments(i).DeleteOnUpdate


                        salesPayments(i) = salesPayment
                    Next

                    salesOrder.Payments = salesPayments
                End If

                Dim lstNumbers As New List(Of GP10Service.SalesTrackingNumber)
                Dim blnFoundTracking As Boolean
                Dim trkTrackingNumber As GP10Service.SalesTrackingNumber
                If objSalesOrder.SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                    For intLoop As Integer = 0 To objSalesOrder.SalesDocumentHeader.TrackingNumbers.Count - 1
                        blnFoundTracking = False
                        For Each trkTrackingNumber In lstNumbers
                            If trkTrackingNumber.Key.Id = objSalesOrder.SalesDocumentHeader.TrackingNumbers(intLoop) Then
                                blnFoundTracking = True
                            End If
                        Next
                        If blnFoundTracking = False Then
                            trkTrackingNumber = New GP10Service.SalesTrackingNumber
                            trkTrackingNumber.Key = New GP10Service.SalesTrackingNumberKey
                            trkTrackingNumber.Key.SalesDocumentKey = salesOrder.Key
                            trkTrackingNumber.Key.Id = objSalesOrder.SalesDocumentHeader.TrackingNumbers(intLoop)
                            lstNumbers.Add(trkTrackingNumber)
                        End If
                    Next
                    salesOrder.TrackingNumbers = lstNumbers.ToArray
                End If

                'create up SalesUserDefined
                If objSalesOrder.SalesDocumentHeader.SalesUserDefined IsNot Nothing Then
                    salesUserDefined = New GP10Service.SalesUserDefined

                    With objSalesOrder.SalesDocumentHeader.SalesUserDefined
                        If .Date01 <> Nothing Then
                            salesUserDefined.Date01 = Date.Parse(.Date01.ToShortDateString)
                        End If
                        If .Date02 <> Nothing Then
                            salesUserDefined.Date02 = Date.Parse(.Date02.ToShortDateString)
                        End If
                        If .List01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List01) Then
                            salesUserDefined.List01 = .List01
                        End If
                        If .List02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List02) Then
                            salesUserDefined.List02 = .List02
                        End If
                        If .List03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List03) Then
                            salesUserDefined.List03 = .List03
                        End If
                        If .Text01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text01) Then
                            salesUserDefined.Text01 = .Text01
                        End If
                        If .Text02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text02) Then
                            salesUserDefined.Text02 = .Text02
                        End If
                        If .Text03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text03) Then
                            salesUserDefined.Text03 = .Text03
                        End If
                        If .Text04 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text04) Then
                            salesUserDefined.Text04 = .Text04
                        End If
                        If .Text05 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text05) Then
                            salesUserDefined.Text05 = .Text05
                        End If
                    End With
                    salesOrder.UserDefined = salesUserDefined
                End If

                'Create Line Items
                Dim orders As GP10Service.SalesOrderLine()
                ReDim orders(objSalesOrder.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objSalesOrder.SalesDocumentDetails.Count - 1
                    salesOrderLine = New GP10Service.SalesOrderLine

                    With objSalesOrder.SalesDocumentDetails.Item(i)
                        orderedItem = New GP10Service.ItemKey
                        orderedItem.Id = .ItemNumber
                        salesOrderLine.ItemKey = orderedItem

                        orderedQty = New GP10Service.Quantity
                        orderedQty.Value = .Quantity
                        salesOrderLine.Quantity = orderedQty

                        itemPrice = New GP10Service.MoneyAmount
                        itemPrice.Value = .SellPrice
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesOrderLine.UnitPrice = itemPrice
                        If .DiscountAmount > 0 Then
                            tdpTradeDiscountPercent = New GP10Service.MoneyPercentChoice
                            tdpTradeDiscountPercent.Item = New GP10Service.MoneyAmount

                            CType(tdpTradeDiscountPercent.Item, GP10Service.MoneyAmount).Value = .DiscountAmount
                            CType(tdpTradeDiscountPercent.Item, GP10Service.MoneyAmount).Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            salesOrderLine.Discount = tdpTradeDiscountPercent
                        End If
                        salesOrderLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))
                        salesOrderLine.ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.ActualShipDate.ToShortDateString())))
                        If .UOM > String.Empty Then
                            salesOrderLine.UofM = .UOM
                        End If

                        If .ItemDescription > String.Empty Then
                            salesOrderLine.ItemDescription = .ItemDescription
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP10Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesOrderLine.ShippingMethodKey = ShipMethodKey
                        End If

                        If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                            ShipToAddressKey = New GP10Service.CustomerAddressKey
                            ShipToAddressKey.Id = .ShipToAddressKey
                            ShipToAddressKey.CustomerKey = salesOrder.CustomerKey
                            salesOrderLine.ShipToAddressKey = ShipToAddressKey
                        End If

                        If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                            taxScheduleKey = New GP10Service.TaxScheduleKey
                            taxScheduleKey.Id = .TaxScheduleKey
                            salesOrderLine.TaxScheduleKey = taxScheduleKey
                        End If

                        If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                            taxScheduleKey = New GP10Service.TaxScheduleKey
                            taxScheduleKey.Id = .ItemTaxScheduleKey
                            salesOrderLine.ItemTaxScheduleKey = taxScheduleKey
                        End If
                        salesOrderLine.IsDropShip = .DropShip
                        'salesOrderLine.ItemDescription = "Test"
                        'salesOrderLine.UofM = "each"

                        'Dim PriceLevelKey As New PriceLevelKey
                        'PriceLevelKey.Id = "EACH"
                        'salesOrderLine.PriceLevelKey = PriceLevelKey

                    End With
                    orders(i) = salesOrderLine
                Next
                salesOrder.Lines = orders

                salesOrderCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateSalesOrder", context)
                objGPConfiguration.GPWS10.CreateSalesOrder(salesOrder, context, salesOrderCreatePolicy)

                orders = Nothing
                salesOrder = Nothing
                'GPSalesOrderNo = salesOrder.Key.Id
                Return IIf(String.IsNullOrEmpty(GPSalesOrderNo.Trim), "Success", GPSalesOrderNo)
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Update GP Sales Order
        ''' </summary>
        ''' <param name="objSalesOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateGPSalesOrder(ByVal objSalesOrder As SOP.SalesOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return UpdateGP10SalesOrder(objSalesOrder, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return UpdateGP2010SalesOrder(objSalesOrder, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Update GP 10 Sales Order
        ''' </summary>
        ''' <param name="objSalesOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function UpdateGP10SalesOrder(ByVal objSalesOrder As SOP.SalesOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim salesOrder As GP10Service.SalesOrder
                Dim salesDocumentKey As GP10Service.SalesDocumentKey
                Dim customerKey As GP10Service.CustomerKey
                Dim batchKey As GP10Service.BatchKey
                Dim salesOrderUpdatePolicy As GP10Service.Policy
                Dim SalespersonKey As GP10Service.SalespersonKey
                Dim PaymentTermsKey As GP10Service.PaymentTermsKey
                Dim GPSalesOrderNo As String = String.Empty
                Dim freightAmount As GP10Service.MoneyAmount
                Dim miscAmount As GP10Service.MoneyAmount
                Dim blnFoundLine As Boolean
                Dim stsNumbers As GP10Service.SalesTrackingNumber()
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"


                If objSalesOrder.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesOrderNo = objSalesOrder.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP10Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesOrderNo
                Else
                    Throw New ArgumentException("Sales Order Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                salesOrder = objGPConfiguration.GPWS10.GetSalesOrderByKey(salesDocumentKey, context)

                'Update Sales Order Header
                If salesOrder IsNot Nothing Then
                    With objSalesOrder

                        If .SalesDocumentHeader.SOPBatchId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SOPBatchId.ToString.Trim) Then
                            batchKey = New GP10Service.BatchKey
                            batchKey.Id = objSalesOrder.SalesDocumentHeader.SOPBatchId
                            salesOrder.BatchKey = batchKey
                        End If

                        If objSalesOrder.SalesDocumentHeader.FreightAmount > 0 Then
                            freightAmount = New GP10Service.MoneyAmount
                            freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            freightAmount.Value = objSalesOrder.SalesDocumentHeader.FreightAmount
                            salesOrder.FreightAmount = freightAmount
                        End If

                        If .SalesDocumentHeader.CustomerId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerId.ToString.Trim) Then
                            customerKey = New GP10Service.CustomerKey
                            customerKey.Id = .SalesDocumentHeader.CustomerId
                            salesOrder.CustomerKey = customerKey
                        End If


                        If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                            SalespersonKey = New GP10Service.SalespersonKey
                            SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                            salesOrder.SalespersonKey = SalespersonKey
                        End If

                        If .SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerPO.ToString.Trim) Then
                            salesOrder.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                        End If

                        If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                            PaymentTermsKey = New GP10Service.PaymentTermsKey
                            PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                            salesOrder.PaymentTermsKey = PaymentTermsKey
                        End If

                        If .SalesDocumentHeader.CustomerNote IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerNote.ToString.Trim) Then
                            salesOrder.Note = .SalesDocumentHeader.CustomerNote
                        End If

                        If .SalesDocumentHeader.MiscAmount <> Nothing AndAlso .SalesDocumentHeader.MiscAmount > 0 Then
                            miscAmount = New GP10Service.MoneyAmount
                            miscAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            miscAmount.Value = .SalesDocumentHeader.MiscAmount
                            salesOrder.MiscellaneousAmount = miscAmount
                        End If

                        If .SalesDocumentHeader.ActualShipDate <> Nothing Then
                            salesOrder.ActualShipDate = .SalesDocumentHeader.ActualShipDate
                        End If

                        If .SalesDocumentHeader.FulfillDate <> Nothing Then
                            salesOrder.FulfillDate = .SalesDocumentHeader.FulfillDate
                        End If

                        If .SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                            stsNumbers = salesOrder.TrackingNumbers
                            ReDim Preserve stsNumbers(stsNumbers.Count + .SalesDocumentHeader.TrackingNumbers.Count - 1)
                            For intLoop As Integer = 0 To .SalesDocumentHeader.TrackingNumbers.Count - 1
                                stsNumbers(stsNumbers.Count - intLoop - 1) = New GP10Service.SalesTrackingNumber
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key = New GP10Service.SalesTrackingNumberKey
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.SalesDocumentKey = salesOrder.Key
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.Id = .SalesDocumentHeader.TrackingNumbers(intLoop)
                            Next
                            salesOrder.TrackingNumbers = stsNumbers
                        End If

                    End With

                    'Update Line Items
                    Dim orders As GP10Service.SalesOrderLine()
                    Dim blnItemFound As Boolean = False
                    ReDim orders(objSalesOrder.SalesDocumentDetails.Count - 1)

                    For i As Integer = 0 To objSalesOrder.SalesDocumentDetails.Count - 1
                        blnFoundLine = False
                        For j As Integer = 0 To salesOrder.Lines.Length - 1
                            If salesOrder.Lines(j).Key Is Nothing Then
                                Continue For
                            End If
                            If salesOrder.Lines(j).Key.LineSequenceNumber = objSalesOrder.SalesDocumentDetails(i).LineSequenceNumber Then
                                blnFoundLine = True
                                If objSalesOrder.SalesDocumentDetails(i).DeleteLine = True Then
                                    salesOrder.Lines(j).DeleteOnUpdate = True
                                    Exit For
                                Else
                                    If objSalesOrder.SalesDocumentDetails(i).ItemNumber > String.Empty Then
                                        If objSalesOrder.SalesDocumentDetails(i).Quantity > -1 Then
                                            salesOrder.Lines(j).Quantity.Value = objSalesOrder.SalesDocumentDetails(i).Quantity
                                        End If

                                        If objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder > -1 Then
                                            salesOrder.Lines(j).QuantityToBackorder.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice > -1 Then
                                            salesOrder.Lines(j).QuantityToInvoice.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).QuantityCanceled > -1 Then
                                            salesOrder.Lines(j).QuantityCanceled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityCanceled
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled > -1 Then
                                            salesOrder.Lines(j).QuantityFulfilled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled
                                        End If
                                        salesOrder.Lines(j).FulfillDate = IIf(objSalesOrder.SalesDocumentDetails(i).FulfillDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(objSalesOrder.SalesDocumentDetails(i).FulfillDate.ToShortDateString())))
                                        If objSalesOrder.SalesDocumentDetails(i).LotNumber > String.Empty Then
                                            Dim salesLotLine As New GP10Service.SalesLineLot
                                            salesLotLine.LotNumber = objSalesOrder.SalesDocumentDetails(i).LotNumber
                                            salesOrder.Lines(j).Lots = {salesLotLine}
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).ActualShipDate <> Nothing Then
                                            salesOrder.Lines(j).ActualShipDate = objSalesOrder.SalesDocumentDetails(i).ActualShipDate
                                        End If

                                        If objSalesOrder.SalesDocumentDetails(i).FulfillDate <> Nothing Then
                                            salesOrder.Lines(j).FulfillDate = objSalesOrder.SalesDocumentDetails(i).FulfillDate
                                        End If
                                        Exit For
                                    End If
                                End If

                            End If
                        Next
                        If blnFoundLine = False Then
                            Dim orderedItem As GP10Service.ItemKey
                            Dim orderedQty As GP10Service.Quantity
                            Dim itemPrice As GP10Service.MoneyAmount
                            Dim ShipMethodKey As GP10Service.ShippingMethodKey
                            Dim ShipToAddressKey As GP10Service.CustomerAddressKey
                            Dim TaxScheduleKey As GP10Service.TaxScheduleKey

                            Array.Resize(salesOrder.Lines, salesOrder.Lines.Length + 1)
                            salesOrder.Lines(salesOrder.Lines.Length - 1) = New GP10Service.SalesOrderLine

                            With objSalesOrder.SalesDocumentDetails.Item(i)
                                orderedItem = New GP10Service.ItemKey
                                orderedItem.Id = .ItemNumber
                                salesOrder.Lines(salesOrder.Lines.Length - 1).ItemKey = orderedItem

                                orderedQty = New GP10Service.Quantity
                                orderedQty.Value = .Quantity
                                salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity = orderedQty

                                itemPrice = New GP10Service.MoneyAmount
                                itemPrice.Value = .SellPrice
                                itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                                salesOrder.Lines(salesOrder.Lines.Length - 1).UnitPrice = itemPrice
                                salesOrder.Lines(salesOrder.Lines.Length - 1).RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))
                                salesOrder.Lines(salesOrder.Lines.Length - 1).ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.ActualShipDate.ToShortDateString())))

                                If .ItemDescription > String.Empty Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ItemDescription = .ItemDescription
                                End If

                                If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                                    ShipMethodKey = New GP10Service.ShippingMethodKey
                                    ShipMethodKey.Id = .ShippingMethodKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ShippingMethodKey = ShipMethodKey
                                End If

                                If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                                    ShipToAddressKey = New GP10Service.CustomerAddressKey
                                    ShipToAddressKey.Id = .ShipToAddressKey
                                    ShipToAddressKey.CustomerKey = salesOrder.CustomerKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ShipToAddressKey = ShipToAddressKey
                                End If

                                If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                                    TaxScheduleKey = New GP10Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .TaxScheduleKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).TaxScheduleKey = TaxScheduleKey
                                End If

                                If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                                    TaxScheduleKey = New GP10Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .ItemTaxScheduleKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ItemTaxScheduleKey = TaxScheduleKey
                                End If

                                If objSalesOrder.SalesDocumentDetails(i).Quantity > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity = New GP10Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity.Value = objSalesOrder.SalesDocumentDetails(i).Quantity
                                End If

                                If objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToBackorder = New GP10Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToBackorder.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder
                                End If
                                If objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToInvoice = New GP10Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToInvoice.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice
                                End If
                                If objSalesOrder.SalesDocumentDetails(i).QuantityCanceled > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityCanceled = New GP10Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityCanceled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityCanceled
                                End If
                                If objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityFulfilled = New GP10Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityFulfilled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled
                                End If
                                If objSalesOrder.SalesDocumentDetails(i).LotNumber > String.Empty Then
                                    Dim salesLotLine As New GP10Service.SalesLineLot
                                    salesLotLine.LotNumber = objSalesOrder.SalesDocumentDetails(i).LotNumber
                                    salesLotLine.Quantity = salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).Lots = {salesLotLine}

                                End If
                                'salesOrderLine.ItemDescription = "Test"
                                'salesOrderLine.UofM = "each"

                                'Dim PriceLevelKey As New PriceLevelKey
                                'PriceLevelKey.Id = "EACH"
                                'salesOrderLine.PriceLevelKey = PriceLevelKey

                            End With
                        End If
                    Next
                    If objSalesOrder.SalesDocumentHeader.ClearProcessHolds = True Then
                        For Each pchHold As GP10Service.SalesProcessHold In salesOrder.ProcessHolds
                            pchHold.DeleteOnUpdate = True
                            pchHold.IsDeleted = True
                        Next
                    End If
                    salesOrderUpdatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("UpdateSalesOrder", context)
                    objGPConfiguration.GPWS10.UpdateSalesOrder(salesOrder, context, salesOrderUpdatePolicy)

                    orders = Nothing
                    salesOrder = Nothing
                    Return "Success"
                Else
                    Return String.Format("Order Number Not Found '{0}'!", GPSalesOrderNo)
                End If
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Update GP 2010 Sales Order
        ''' </summary>
        ''' <param name="objSalesOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function UpdateGP2010SalesOrder(ByVal objSalesOrder As SOP.SalesOrder, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim salesOrder As GP2010Service.SalesOrder
                Dim salesDocumentKey As GP2010Service.SalesDocumentKey
                Dim customerKey As GP2010Service.CustomerKey
                Dim batchKey As GP2010Service.BatchKey
                Dim salesOrderUpdatePolicy As GP2010Service.Policy
                Dim SalespersonKey As GP2010Service.SalespersonKey
                Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
                Dim GPSalesOrderNo As String = String.Empty
                Dim freightAmount As GP2010Service.MoneyAmount
                Dim miscAmount As GP2010Service.MoneyAmount
                Dim blnFoundLine As Boolean
                Dim stsNumbers() As GP2010Service.SalesTrackingNumber = {}
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP2010Service.Context
                companyKey = New GP2010Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP2010Service.OrganizationKey)
                context.CultureName = "en-US"


                If objSalesOrder.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesOrder.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesOrderNo = objSalesOrder.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP2010Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesOrderNo
                Else
                    Throw New ArgumentException("Sales Order Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                salesOrder = objGPConfiguration.GPWS2010.GetSalesOrderByKey(salesDocumentKey, context)

                'Update Sales Order Header
                If salesOrder IsNot Nothing Then
                    With objSalesOrder

                        If .SalesDocumentHeader.SOPBatchId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SOPBatchId.ToString.Trim) Then
                            batchKey = New GP2010Service.BatchKey
                            batchKey.Id = objSalesOrder.SalesDocumentHeader.SOPBatchId
                            salesOrder.BatchKey = batchKey
                        End If

                        If objSalesOrder.SalesDocumentHeader.FreightAmount > 0 Then
                            freightAmount = New GP2010Service.MoneyAmount
                            freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            freightAmount.Value = objSalesOrder.SalesDocumentHeader.FreightAmount
                            salesOrder.FreightAmount = freightAmount
                        End If

                        If .SalesDocumentHeader.CustomerId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerId.ToString.Trim) Then
                            customerKey = New GP2010Service.CustomerKey
                            customerKey.Id = .SalesDocumentHeader.CustomerId
                            salesOrder.CustomerKey = customerKey
                        End If


                        If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                            SalespersonKey = New GP2010Service.SalespersonKey
                            SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                            salesOrder.SalespersonKey = SalespersonKey
                        End If

                        If .SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerPO.ToString.Trim) Then
                            salesOrder.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                        End If

                        If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                            PaymentTermsKey = New GP2010Service.PaymentTermsKey
                            PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                            salesOrder.PaymentTermsKey = PaymentTermsKey
                        End If

                        If .SalesDocumentHeader.CustomerNote IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerNote.ToString.Trim) Then
                            salesOrder.Note = .SalesDocumentHeader.CustomerNote
                        End If

                        If .SalesDocumentHeader.MiscAmount <> Nothing AndAlso .SalesDocumentHeader.MiscAmount > 0 Then
                            miscAmount = New GP2010Service.MoneyAmount
                            miscAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            miscAmount.Value = .SalesDocumentHeader.MiscAmount
                            salesOrder.MiscellaneousAmount = miscAmount
                        End If

                        If .SalesDocumentHeader.ActualShipDate <> Nothing Then
                            salesOrder.ActualShipDate = .SalesDocumentHeader.ActualShipDate
                        End If

                        If .SalesDocumentHeader.FulfillDate <> Nothing Then
                            salesOrder.FulfillDate = .SalesDocumentHeader.FulfillDate
                        End If

                        If .SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                            stsNumbers = salesOrder.TrackingNumbers
                            ReDim Preserve stsNumbers(stsNumbers.Count + .SalesDocumentHeader.TrackingNumbers.Count - 1)
                            For intLoop As Integer = 0 To .SalesDocumentHeader.TrackingNumbers.Count - 1
                                stsNumbers(stsNumbers.Count - intLoop - 1) = New GP2010Service.SalesTrackingNumber
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key = New GP2010Service.SalesTrackingNumberKey
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.SalesDocumentKey = salesOrder.Key
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.Id = .SalesDocumentHeader.TrackingNumbers(intLoop)
                            Next
                            salesOrder.TrackingNumbers = stsNumbers
                        End If


                    End With

                    'Update Line Items
                    Dim orders As GP2010Service.SalesOrderLine()
                    Dim blnItemFound As Boolean = False
                    ReDim orders(objSalesOrder.SalesDocumentDetails.Count - 1)

                    For i As Integer = 0 To objSalesOrder.SalesDocumentDetails.Count - 1
                        blnFoundLine = False
                        For j As Integer = 0 To salesOrder.Lines.Length - 1
                            If salesOrder.Lines(j).Key Is Nothing Then
                                Continue For
                            End If
                            If salesOrder.Lines(j).Key.LineSequenceNumber = objSalesOrder.SalesDocumentDetails(i).LineSequenceNumber Then
                                blnFoundLine = True
                                If objSalesOrder.SalesDocumentDetails(i).DeleteLine = True Then
                                    salesOrder.Lines(j).DeleteOnUpdate = True
                                    Exit For
                                Else
                                    If objSalesOrder.SalesDocumentDetails(i).ItemNumber > String.Empty Then
                                        If objSalesOrder.SalesDocumentDetails(i).Quantity > -1 Then
                                            salesOrder.Lines(j).Quantity.Value = objSalesOrder.SalesDocumentDetails(i).Quantity
                                        End If

                                        If objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder > -1 Then
                                            salesOrder.Lines(j).QuantityToBackorder.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice > -1 Then
                                            salesOrder.Lines(j).QuantityToInvoice.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).QuantityCanceled > -1 Then
                                            salesOrder.Lines(j).QuantityCanceled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityCanceled
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled > -1 Then
                                            salesOrder.Lines(j).QuantityFulfilled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled
                                        End If
                                        salesOrder.Lines(j).FulfillDate = IIf(objSalesOrder.SalesDocumentDetails(i).FulfillDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(objSalesOrder.SalesDocumentDetails(i).FulfillDate.ToShortDateString())))
                                        If objSalesOrder.SalesDocumentDetails(i).LotNumber > String.Empty Then
                                            Dim salesLotLine As New DynamicsWCFService.SalesLineLot
                                            salesLotLine.LotNumber = objSalesOrder.SalesDocumentDetails(i).LotNumber
                                            salesOrder.Lines(j).Lots = {salesLotLine}
                                        End If
                                        If objSalesOrder.SalesDocumentDetails(i).ActualShipDate <> Nothing Then
                                            salesOrder.Lines(j).ActualShipDate = objSalesOrder.SalesDocumentDetails(i).ActualShipDate
                                        End If

                                        If objSalesOrder.SalesDocumentDetails(i).FulfillDate <> Nothing Then
                                            salesOrder.Lines(j).FulfillDate = objSalesOrder.SalesDocumentDetails(i).FulfillDate
                                        End If
                                        Exit For
                                    End If
                                End If

                            End If
                        Next
                        If blnFoundLine = False Then
                            Dim orderedItem As GP2010Service.ItemKey
                            Dim orderedQty As GP2010Service.Quantity
                            Dim itemPrice As GP2010Service.MoneyAmount
                            Dim ShipMethodKey As GP2010Service.ShippingMethodKey
                            Dim ShipToAddressKey As GP2010Service.CustomerAddressKey
                            Dim TaxScheduleKey As GP2010Service.TaxScheduleKey

                            Array.Resize(salesOrder.Lines, salesOrder.Lines.Length + 1)
                            salesOrder.Lines(salesOrder.Lines.Length - 1) = New GP2010Service.SalesOrderLine

                            With objSalesOrder.SalesDocumentDetails.Item(i)
                                orderedItem = New GP2010Service.ItemKey
                                orderedItem.Id = .ItemNumber
                                salesOrder.Lines(salesOrder.Lines.Length - 1).ItemKey = orderedItem

                                orderedQty = New GP2010Service.Quantity
                                orderedQty.Value = .Quantity
                                salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity = orderedQty

                                itemPrice = New GP2010Service.MoneyAmount
                                itemPrice.Value = .SellPrice
                                itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                                salesOrder.Lines(salesOrder.Lines.Length - 1).UnitPrice = itemPrice
                                salesOrder.Lines(salesOrder.Lines.Length - 1).RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))
                                salesOrder.Lines(salesOrder.Lines.Length - 1).ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.ActualShipDate.ToShortDateString())))

                                If .ItemDescription > String.Empty Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ItemDescription = .ItemDescription
                                End If

                                If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                                    ShipMethodKey = New GP2010Service.ShippingMethodKey
                                    ShipMethodKey.Id = .ShippingMethodKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ShippingMethodKey = ShipMethodKey
                                End If

                                If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                                    ShipToAddressKey = New GP2010Service.CustomerAddressKey
                                    ShipToAddressKey.Id = .ShipToAddressKey
                                    ShipToAddressKey.CustomerKey = salesOrder.CustomerKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ShipToAddressKey = ShipToAddressKey
                                End If

                                If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                                    TaxScheduleKey = New GP2010Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .TaxScheduleKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).TaxScheduleKey = TaxScheduleKey
                                End If

                                If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                                    TaxScheduleKey = New GP2010Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .ItemTaxScheduleKey
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).ItemTaxScheduleKey = TaxScheduleKey
                                End If

                                If objSalesOrder.SalesDocumentDetails(i).Quantity > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity = New GP2010Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity.Value = objSalesOrder.SalesDocumentDetails(i).Quantity
                                End If

                                If objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToBackorder = New GP2010Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToBackorder.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToBackOrder
                                End If
                                If objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToInvoice = New GP2010Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityToInvoice.Value = objSalesOrder.SalesDocumentDetails(i).QuantityToInvoice
                                End If
                                If objSalesOrder.SalesDocumentDetails(i).QuantityCanceled > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityCanceled = New GP2010Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityCanceled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityCanceled
                                End If
                                If objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled > -1 Then
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityFulfilled = New GP2010Service.Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).QuantityFulfilled.Value = objSalesOrder.SalesDocumentDetails(i).QuantityFullFilled
                                End If

                                If objSalesOrder.SalesDocumentDetails(i).LotNumber > String.Empty Then
                                    Dim salesLotLine As New DynamicsWCFService.SalesLineLot
                                    salesLotLine.LotNumber = objSalesOrder.SalesDocumentDetails(i).LotNumber
                                    salesLotLine.Quantity = salesOrder.Lines(salesOrder.Lines.Length - 1).Quantity
                                    salesOrder.Lines(salesOrder.Lines.Length - 1).Lots = {salesLotLine}
                                End If

                                'salesOrderLine.ItemDescription = "Test"
                                'salesOrderLine.UofM = "each"

                                'Dim PriceLevelKey As New PriceLevelKey
                                'PriceLevelKey.Id = "EACH"
                                'salesOrderLine.PriceLevelKey = PriceLevelKey

                            End With
                        End If
                    Next
                    If objSalesOrder.SalesDocumentHeader.ClearProcessHolds = True Then
                        For Each pchHold As GP2010Service.SalesProcessHold In salesOrder.ProcessHolds
                            pchHold.DeleteOnUpdate = True
                            pchHold.IsDeleted = True
                        Next
                    End If

                    salesOrderUpdatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("UpdateSalesOrder", context)
                    objGPConfiguration.GPWS2010.UpdateSalesOrder(salesOrder, context, salesOrderUpdatePolicy)
                    orders = Nothing
                    salesOrder = Nothing
                    Return "Success"
                Else
                    Return String.Format("Order Number Not Found '{0}'!", GPSalesOrderNo)
                End If
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Update GP Sales Order
        ''' </summary>
        ''' <param name="objSalesReturn"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateGPSalesReturn(ByVal objSalesReturn As SOP.SalesReturn, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return UpdateGP10SalesReturn(objSalesReturn, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return UpdateGP2010SalesReturn(objSalesReturn, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Update GP 10 Sales Order
        ''' </summary>
        ''' <param name="objSalesReturn"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function UpdateGP10SalesReturn(ByVal objSalesReturn As SOP.SalesReturn, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim SalesReturn As GP10Service.SalesReturn
                Dim salesDocumentKey As GP10Service.SalesDocumentKey
                Dim customerKey As GP10Service.CustomerKey
                Dim batchKey As GP10Service.BatchKey
                Dim SalesReturnUpdatePolicy As GP10Service.Policy
                Dim SalespersonKey As GP10Service.SalespersonKey
                Dim PaymentTermsKey As GP10Service.PaymentTermsKey
                Dim GPSalesReturnNo As String = String.Empty
                Dim freightAmount As GP10Service.MoneyAmount
                Dim miscAmount As GP10Service.MoneyAmount
                Dim blnFoundLine As Boolean
                Dim stsNumbers As GP10Service.SalesTrackingNumber()
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"


                If objSalesReturn.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesReturn.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesReturnNo = objSalesReturn.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP10Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesReturnNo
                Else
                    Throw New ArgumentException("Sales Order Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                SalesReturn = objGPConfiguration.GPWS10.GetSalesReturnByKey(salesDocumentKey, context)

                'Update Sales Order Header
                If SalesReturn IsNot Nothing Then
                    With objSalesReturn

                        If .SalesDocumentHeader.SOPBatchId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SOPBatchId.ToString.Trim) Then
                            batchKey = New GP10Service.BatchKey
                            batchKey.Id = objSalesReturn.SalesDocumentHeader.SOPBatchId
                            SalesReturn.BatchKey = batchKey
                        End If

                        If objSalesReturn.SalesDocumentHeader.FreightAmount > 0 Then
                            freightAmount = New GP10Service.MoneyAmount
                            freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            freightAmount.Value = objSalesReturn.SalesDocumentHeader.FreightAmount
                            SalesReturn.FreightAmount = freightAmount
                        End If

                        If .SalesDocumentHeader.CustomerId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerId.ToString.Trim) Then
                            customerKey = New GP10Service.CustomerKey
                            customerKey.Id = .SalesDocumentHeader.CustomerId
                            SalesReturn.CustomerKey = customerKey
                        End If


                        If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                            SalespersonKey = New GP10Service.SalespersonKey
                            SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                            SalesReturn.SalespersonKey = SalespersonKey
                        End If

                        If .SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerPO.ToString.Trim) Then
                            SalesReturn.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                        End If

                        If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                            PaymentTermsKey = New GP10Service.PaymentTermsKey
                            PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                            SalesReturn.PaymentTermsKey = PaymentTermsKey
                        End If

                        If .SalesDocumentHeader.CustomerNote IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerNote.ToString.Trim) Then
                            SalesReturn.Note = .SalesDocumentHeader.CustomerNote
                        End If

                        If .SalesDocumentHeader.MiscAmount <> Nothing AndAlso .SalesDocumentHeader.MiscAmount > 0 Then
                            miscAmount = New GP10Service.MoneyAmount
                            miscAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            miscAmount.Value = .SalesDocumentHeader.MiscAmount
                            SalesReturn.MiscellaneousAmount = miscAmount
                        End If


                        If .SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                            stsNumbers = SalesReturn.TrackingNumbers
                            ReDim Preserve stsNumbers(stsNumbers.Count + .SalesDocumentHeader.TrackingNumbers.Count - 1)
                            For intLoop As Integer = 0 To .SalesDocumentHeader.TrackingNumbers.Count - 1
                                stsNumbers(stsNumbers.Count - intLoop - 1) = New GP10Service.SalesTrackingNumber
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key = New GP10Service.SalesTrackingNumberKey
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.SalesDocumentKey = SalesReturn.Key
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.Id = .SalesDocumentHeader.TrackingNumbers(intLoop)
                            Next
                            SalesReturn.TrackingNumbers = stsNumbers
                        End If

                    End With

                    'Update Line Items
                    Dim orders As GP10Service.SalesReturnLine()
                    Dim blnItemFound As Boolean = False
                    ReDim orders(objSalesReturn.SalesDocumentDetails.Count - 1)

                    For i As Integer = 0 To objSalesReturn.SalesDocumentDetails.Count - 1
                        blnFoundLine = False
                        For j As Integer = 0 To SalesReturn.Lines.Length - 1
                            If SalesReturn.Lines(j).Key Is Nothing Then
                                Continue For
                            End If
                            If SalesReturn.Lines(j).Key.LineSequenceNumber = objSalesReturn.SalesDocumentDetails(i).LineSequenceNumber Then
                                blnFoundLine = True
                                If objSalesReturn.SalesDocumentDetails(i).DeleteLine = True Then
                                    SalesReturn.Lines(j).DeleteOnUpdate = True
                                    Exit For
                                Else
                                    If objSalesReturn.SalesDocumentDetails(i).ItemNumber > String.Empty Then
                                        If objSalesReturn.SalesDocumentDetails(i).Quantity > -1 Then
                                            SalesReturn.Lines(j).Quantity.Value = objSalesReturn.SalesDocumentDetails(i).Quantity
                                        End If
                                    End If
                                End If

                            End If
                        Next
                        If blnFoundLine = False Then
                            Dim orderedItem As GP10Service.ItemKey
                            Dim orderedQty As GP10Service.Quantity
                            Dim itemPrice As GP10Service.MoneyAmount
                            Dim ShipMethodKey As GP10Service.ShippingMethodKey
                            Dim ShipToAddressKey As GP10Service.CustomerAddressKey
                            Dim TaxScheduleKey As GP10Service.TaxScheduleKey

                            Array.Resize(SalesReturn.Lines, SalesReturn.Lines.Length + 1)
                            SalesReturn.Lines(SalesReturn.Lines.Length - 1) = New GP10Service.SalesReturnLine

                            With objSalesReturn.SalesDocumentDetails.Item(i)
                                orderedItem = New GP10Service.ItemKey
                                orderedItem.Id = .ItemNumber
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).ItemKey = orderedItem

                                orderedQty = New GP10Service.Quantity
                                orderedQty.Value = .Quantity
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).Quantity = orderedQty

                                itemPrice = New GP10Service.MoneyAmount
                                itemPrice.Value = .SellPrice
                                itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).UnitPrice = itemPrice
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))

                                If .ItemDescription > String.Empty Then
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ItemDescription = .ItemDescription
                                End If

                                If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                                    ShipMethodKey = New GP10Service.ShippingMethodKey
                                    ShipMethodKey.Id = .ShippingMethodKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ShippingMethodKey = ShipMethodKey
                                End If

                                If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                                    ShipToAddressKey = New GP10Service.CustomerAddressKey
                                    ShipToAddressKey.Id = .ShipToAddressKey
                                    ShipToAddressKey.CustomerKey = SalesReturn.CustomerKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ShipToAddressKey = ShipToAddressKey
                                End If

                                If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                                    TaxScheduleKey = New GP10Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .TaxScheduleKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).TaxScheduleKey = TaxScheduleKey
                                End If

                                If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                                    TaxScheduleKey = New GP10Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .ItemTaxScheduleKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ItemTaxScheduleKey = TaxScheduleKey
                                End If

                                If objSalesReturn.SalesDocumentDetails(i).Quantity > -1 Then
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).Quantity = New GP10Service.Quantity
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).Quantity.Value = objSalesReturn.SalesDocumentDetails(i).Quantity
                                End If

                                'SalesReturnLine.ItemDescription = "Test"
                                'SalesReturnLine.UofM = "each"

                                'Dim PriceLevelKey As New PriceLevelKey
                                'PriceLevelKey.Id = "EACH"
                                'SalesReturnLine.PriceLevelKey = PriceLevelKey

                            End With
                        End If
                    Next
                    If objSalesReturn.SalesDocumentHeader.ClearProcessHolds = True Then
                        For Each pchHold As GP10Service.SalesProcessHold In SalesReturn.ProcessHolds
                            pchHold.DeleteOnUpdate = True
                            pchHold.IsDeleted = True
                        Next
                    End If
                    SalesReturnUpdatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("UpdateSalesReturn", context)
                    objGPConfiguration.GPWS10.UpdateSalesReturn(SalesReturn, context, SalesReturnUpdatePolicy)

                    orders = Nothing
                    SalesReturn = Nothing
                    Return "Success"
                Else
                    Return String.Format("Order Number Not Found '{0}'!", GPSalesReturnNo)
                End If
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Update GP 2010 Sales Order
        ''' </summary>
        ''' <param name="objSalesReturn"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function UpdateGP2010SalesReturn(ByVal objSalesReturn As SOP.SalesReturn, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim SalesReturn As GP2010Service.SalesReturn
                Dim salesDocumentKey As GP2010Service.SalesDocumentKey
                Dim customerKey As GP2010Service.CustomerKey
                Dim batchKey As GP2010Service.BatchKey
                Dim SalesReturnUpdatePolicy As GP2010Service.Policy
                Dim SalespersonKey As GP2010Service.SalespersonKey
                Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
                Dim GPSalesReturnNo As String = String.Empty
                Dim freightAmount As GP2010Service.MoneyAmount
                Dim miscAmount As GP2010Service.MoneyAmount
                Dim blnFoundLine As Boolean
                Dim stsNumbers() As GP2010Service.SalesTrackingNumber = {}
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP2010Service.Context
                companyKey = New GP2010Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP2010Service.OrganizationKey)
                context.CultureName = "en-US"


                If objSalesReturn.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesReturn.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesReturnNo = objSalesReturn.SalesDocumentHeader.SOPDocumentKey
                    salesDocumentKey = New GP2010Service.SalesDocumentKey
                    salesDocumentKey.Id = GPSalesReturnNo
                Else
                    Throw New ArgumentException("Sales Order Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                SalesReturn = objGPConfiguration.GPWS2010.GetSalesReturnByKey(salesDocumentKey, context)

                'Update Sales Order Header
                If SalesReturn IsNot Nothing Then
                    With objSalesReturn

                        If .SalesDocumentHeader.SOPBatchId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SOPBatchId.ToString.Trim) Then
                            batchKey = New GP2010Service.BatchKey
                            batchKey.Id = objSalesReturn.SalesDocumentHeader.SOPBatchId
                            SalesReturn.BatchKey = batchKey
                        End If

                        If objSalesReturn.SalesDocumentHeader.FreightAmount > 0 Then
                            freightAmount = New GP2010Service.MoneyAmount
                            freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            freightAmount.Value = objSalesReturn.SalesDocumentHeader.FreightAmount
                            SalesReturn.FreightAmount = freightAmount
                        End If

                        If .SalesDocumentHeader.CustomerId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerId.ToString.Trim) Then
                            customerKey = New GP2010Service.CustomerKey
                            customerKey.Id = .SalesDocumentHeader.CustomerId
                            SalesReturn.CustomerKey = customerKey
                        End If


                        If .SalesDocumentHeader.SalesPersonId IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.SalesPersonId.ToString.Trim) Then
                            SalespersonKey = New GP2010Service.SalespersonKey
                            SalespersonKey.Id = .SalesDocumentHeader.SalesPersonId
                            SalesReturn.SalespersonKey = SalespersonKey
                        End If

                        If .SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerPO.ToString.Trim) Then
                            SalesReturn.CustomerPONumber = .SalesDocumentHeader.CustomerPO
                        End If

                        If .SalesDocumentHeader.RequestedPaymentTerms IsNot Nothing AndAlso .SalesDocumentHeader.RequestedPaymentTerms.Trim <> String.Empty Then
                            PaymentTermsKey = New GP2010Service.PaymentTermsKey
                            PaymentTermsKey.Id = .SalesDocumentHeader.RequestedPaymentTerms
                            SalesReturn.PaymentTermsKey = PaymentTermsKey
                        End If

                        If .SalesDocumentHeader.CustomerNote IsNot Nothing AndAlso Not String.IsNullOrEmpty(.SalesDocumentHeader.CustomerNote.ToString.Trim) Then
                            SalesReturn.Note = .SalesDocumentHeader.CustomerNote
                        End If

                        If .SalesDocumentHeader.MiscAmount <> Nothing AndAlso .SalesDocumentHeader.MiscAmount > 0 Then
                            miscAmount = New GP2010Service.MoneyAmount
                            miscAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            miscAmount.Value = .SalesDocumentHeader.MiscAmount
                            SalesReturn.MiscellaneousAmount = miscAmount
                        End If

                        If .SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                            stsNumbers = SalesReturn.TrackingNumbers
                            ReDim Preserve stsNumbers(stsNumbers.Count + .SalesDocumentHeader.TrackingNumbers.Count - 1)
                            For intLoop As Integer = 0 To .SalesDocumentHeader.TrackingNumbers.Count - 1
                                stsNumbers(stsNumbers.Count - intLoop - 1) = New GP2010Service.SalesTrackingNumber
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key = New GP2010Service.SalesTrackingNumberKey
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.SalesDocumentKey = SalesReturn.Key
                                stsNumbers(stsNumbers.Count - intLoop - 1).Key.Id = .SalesDocumentHeader.TrackingNumbers(intLoop)
                            Next
                            SalesReturn.TrackingNumbers = stsNumbers
                        End If
                        If .ReturnDate > DateTime.MinValue Then
                            SalesReturn.ReturnDate = .ReturnDate
                        End If

                    End With

                    'Update Line Items
                    Dim orders As GP2010Service.SalesReturnLine()
                    Dim blnItemFound As Boolean = False
                    ReDim orders(objSalesReturn.SalesDocumentDetails.Count - 1)

                    For i As Integer = 0 To objSalesReturn.SalesDocumentDetails.Count - 1
                        blnFoundLine = False
                        For j As Integer = 0 To SalesReturn.Lines.Length - 1
                            If SalesReturn.Lines(j).Key Is Nothing Then
                                Continue For
                            End If
                            If SalesReturn.Lines(j).Key.LineSequenceNumber = objSalesReturn.SalesDocumentDetails(i).LineSequenceNumber Then
                                blnFoundLine = True
                                If objSalesReturn.SalesDocumentDetails(i).DeleteLine = True Then
                                    SalesReturn.Lines(j).DeleteOnUpdate = True
                                    Exit For
                                Else
                                    If objSalesReturn.SalesDocumentDetails(i).ItemNumber > String.Empty Then
                                        If objSalesReturn.SalesDocumentDetails(i).Quantity > -1 Then
                                            SalesReturn.Lines(j).Quantity.Value = objSalesReturn.SalesDocumentDetails(i).Quantity
                                        End If

                                        Exit For
                                    End If
                                End If

                            End If
                        Next
                        If blnFoundLine = False Then
                            Dim orderedItem As GP2010Service.ItemKey
                            Dim orderedQty As GP2010Service.Quantity
                            Dim itemPrice As GP2010Service.MoneyAmount
                            Dim ShipMethodKey As GP2010Service.ShippingMethodKey
                            Dim ShipToAddressKey As GP2010Service.CustomerAddressKey
                            Dim TaxScheduleKey As GP2010Service.TaxScheduleKey

                            Array.Resize(SalesReturn.Lines, SalesReturn.Lines.Length + 1)
                            SalesReturn.Lines(SalesReturn.Lines.Length - 1) = New GP2010Service.SalesReturnLine

                            With objSalesReturn.SalesDocumentDetails.Item(i)
                                orderedItem = New GP2010Service.ItemKey
                                orderedItem.Id = .ItemNumber
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).ItemKey = orderedItem

                                orderedQty = New GP2010Service.Quantity
                                orderedQty.Value = .Quantity
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).Quantity = orderedQty

                                itemPrice = New GP2010Service.MoneyAmount
                                itemPrice.Value = .SellPrice
                                itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).UnitPrice = itemPrice
                                SalesReturn.Lines(SalesReturn.Lines.Length - 1).RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(Date.Parse(.RequestedShipDate.ToShortDateString())))

                                If .ItemDescription > String.Empty Then
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ItemDescription = .ItemDescription
                                End If

                                If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                                    ShipMethodKey = New GP2010Service.ShippingMethodKey
                                    ShipMethodKey.Id = .ShippingMethodKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ShippingMethodKey = ShipMethodKey
                                End If

                                If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                                    ShipToAddressKey = New GP2010Service.CustomerAddressKey
                                    ShipToAddressKey.Id = .ShipToAddressKey
                                    ShipToAddressKey.CustomerKey = SalesReturn.CustomerKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ShipToAddressKey = ShipToAddressKey
                                End If

                                If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                                    TaxScheduleKey = New GP2010Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .TaxScheduleKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).TaxScheduleKey = TaxScheduleKey
                                End If

                                If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                                    TaxScheduleKey = New GP2010Service.TaxScheduleKey
                                    TaxScheduleKey.Id = .ItemTaxScheduleKey
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).ItemTaxScheduleKey = TaxScheduleKey
                                End If

                                If objSalesReturn.SalesDocumentDetails(i).Quantity > -1 Then
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).Quantity = New GP2010Service.Quantity
                                    SalesReturn.Lines(SalesReturn.Lines.Length - 1).Quantity.Value = objSalesReturn.SalesDocumentDetails(i).Quantity
                                End If


                                'SalesReturnLine.ItemDescription = "Test"
                                'SalesReturnLine.UofM = "each"

                                'Dim PriceLevelKey As New PriceLevelKey
                                'PriceLevelKey.Id = "EACH"
                                'SalesReturnLine.PriceLevelKey = PriceLevelKey

                            End With
                        End If
                    Next
                    If objSalesReturn.SalesDocumentHeader.ClearProcessHolds = True Then
                        For Each pchHold As GP2010Service.SalesProcessHold In SalesReturn.ProcessHolds
                            pchHold.DeleteOnUpdate = True
                            pchHold.IsDeleted = True
                        Next
                    End If

                    SalesReturnUpdatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("UpdateSalesReturn", context)
                    objGPConfiguration.GPWS2010.UpdateSalesReturn(SalesReturn, context, SalesReturnUpdatePolicy)
                    orders = Nothing
                    SalesReturn = Nothing
                    Return "Success"
                Else
                    Return String.Format("Order Number Not Found '{0}'!", GPSalesReturnNo)
                End If
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function



        ''' <summary>
        ''' Get GP Sales Order by SOP Number
        ''' </summary>
        ''' <param name="SOPNUMBE"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetGPSalesOrder(ByVal SOPNUMBE As String, ByVal objGPConfiguration As GPSystemConfiguration) As SOP.SalesOrder
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return GetGP10SalesOrder(SOPNUMBE, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return GetGP2010SalesOrder(SOPNUMBE, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Get GP 10 Sales Order by SOP Number
        ''' </summary>
        ''' <param name="SOPNUMBE"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetGP10SalesOrder(ByVal SOPNUMBE As String, ByVal objGPConfiguration As GPSystemConfiguration) As SOP.SalesOrder
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim salesOrder As GP10Service.SalesOrder
                Dim salesDocumentKey As GP10Service.SalesDocumentKey
                Dim objSalesOrder As New SOP.SalesOrder
                'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                Helper.SetupWSWithConfiguration(objGPConfiguration)
                'If Helper.wsDynamicsGP Is Nothing Then
                '    Helper.wsDynamicsGP = New GP10.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
                '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
                'End If

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"


                If Not String.IsNullOrEmpty(SOPNUMBE) Then
                    salesDocumentKey = New GP10Service.SalesDocumentKey
                    salesDocumentKey.Id = SOPNUMBE
                Else
                    Throw New ArgumentException("Sales Order Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                salesOrder = objGPConfiguration.GPWS10.GetSalesOrderByKey(salesDocumentKey, context)

                'Populate Sales Order Header

                With salesOrder
                    objSalesOrder.SalesDocumentHeader.SOPDocumentKey = .Key.Id
                    objSalesOrder.SalesDocumentHeader.SOPBatchId = .BatchKey.Id
                    objSalesOrder.SalesDocumentHeader.FreightAmount = .FreightAmount.Value
                    objSalesOrder.SalesDocumentHeader.CustomerId = .CustomerKey.Id
                    objSalesOrder.SalesDocumentHeader.CustomerPO = .CustomerPONumber
                    objSalesOrder.SalesDocumentHeader.CustomerNote = .Note
                    objSalesOrder.SalesDocumentHeader.FreightAmount = .FreightAmount.Value

                    If .SalespersonKey IsNot Nothing Then
                        objSalesOrder.SalesDocumentHeader.SalesPersonId = .SalespersonKey.Id
                    End If
                    If .ActualShipDate.HasValue = True Then
                        objSalesOrder.SalesDocumentHeader.ActualShipDate = .ActualShipDate.Value
                    End If
                    If .PaymentTermsKey IsNot Nothing Then
                        objSalesOrder.SalesDocumentHeader.RequestedPaymentTerms = .PaymentTermsKey.Id
                    End If
                    If .ShipToAddressKey IsNot Nothing Then
                        objSalesOrder.SalesDocumentHeader.ShipToAddressKey = .ShipToAddressKey.Id
                    End If

                End With

                If salesOrder.TrackingNumbers IsNot Nothing Then
                    For Each trackingnumber As GP10Service.SalesTrackingNumber In salesOrder.TrackingNumbers
                        If trackingnumber.Key IsNot Nothing Then
                            objSalesOrder.SalesDocumentHeader.TrackingNumbers.Add(trackingnumber.Key.Id)
                        End If
                    Next
                End If


                'Populate Line Items
                For i As Integer = 0 To salesOrder.Lines.Length - 1
                    Dim LineItem As New MSGPWSIntegration.SOP.SalesDocumentDetail
                    With LineItem
                        If salesOrder.Lines(i).ItemKey IsNot Nothing Then
                            .ItemNumber = salesOrder.Lines(i).ItemKey.Id
                        End If
                        If salesOrder.Lines(i).Key IsNot Nothing Then
                            .LineSequenceNumber = salesOrder.Lines(i).Key.LineSequenceNumber
                        End If

                        .Quantity = salesOrder.Lines(i).Quantity.Value
                        .QuantityCanceled = salesOrder.Lines(i).QuantityCanceled.Value
                        .QuantityFullFilled = salesOrder.Lines(i).QuantityFulfilled.Value
                        .QuantityToBackOrder = salesOrder.Lines(i).QuantityToBackorder.Value
                        .QuantityToInvoice = salesOrder.Lines(i).QuantityToInvoice.Value
                        .SellPrice = salesOrder.Lines(i).UnitPrice.Value

                        If salesOrder.Lines(i).RequestedShipDate.HasValue = True Then
                            .RequestedShipDate = salesOrder.Lines(i).RequestedShipDate
                        End If
                        If salesOrder.Lines(i).ActualShipDate.HasValue = True Then
                            .ActualShipDate = salesOrder.Lines(i).ActualShipDate
                        End If
                    End With
                    objSalesOrder.SalesDocumentDetails.Add(LineItem)
                Next

                Return objSalesOrder
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Get GP 2010 Sales Order by SOP Number
        ''' </summary>
        ''' <param name="SOPNUMBE"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetGP2010SalesOrder(ByVal SOPNUMBE As String, ByVal objGPConfiguration As GPSystemConfiguration) As SOP.SalesOrder
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim salesOrder As GP2010Service.SalesOrder
                Dim salesDocumentKey As GP2010Service.SalesDocumentKey
                Dim objSalesOrder As New SOP.SalesOrder
                Dim stsNumbers() As GP2010Service.SalesTrackingNumber = {}
                'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                'Helper.SetupWSWithConfiguration(objGPConfiguration)
                'If Helper.wsDynamicsGP Is Nothing Then
                '    Helper.wsDynamicsGP = New GP2010.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
                '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
                'End If

                context = objGPConfiguration.GP2010GetContext
                companyKey = objGPConfiguration.GP2010GetCompanyKey


                If Not String.IsNullOrEmpty(SOPNUMBE) Then
                    salesDocumentKey = New GP2010Service.SalesDocumentKey
                    salesDocumentKey.Id = SOPNUMBE
                Else
                    Throw New ArgumentException("Sales Order Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                salesOrder = objGPConfiguration.GPWS2010.GetSalesOrderByKey(salesDocumentKey, context)

                'Populate Sales Order Header

                With salesOrder
                    objSalesOrder.SalesDocumentHeader.SOPDocumentKey = .Key.Id
                    objSalesOrder.SalesDocumentHeader.SOPBatchId = .BatchKey.Id
                    objSalesOrder.SalesDocumentHeader.FreightAmount = .FreightAmount.Value
                    objSalesOrder.SalesDocumentHeader.CustomerId = .CustomerKey.Id
                    objSalesOrder.SalesDocumentHeader.CustomerPO = .CustomerPONumber
                    objSalesOrder.SalesDocumentHeader.CustomerNote = .Note
                    objSalesOrder.SalesDocumentHeader.FreightAmount = .FreightAmount.Value

                    If .SalespersonKey IsNot Nothing Then
                        objSalesOrder.SalesDocumentHeader.SalesPersonId = .SalespersonKey.Id
                    End If
                    If .ActualShipDate.HasValue = True Then
                        objSalesOrder.SalesDocumentHeader.ActualShipDate = .ActualShipDate.Value
                    End If
                    If .PaymentTermsKey IsNot Nothing Then
                        objSalesOrder.SalesDocumentHeader.RequestedPaymentTerms = .PaymentTermsKey.Id
                    End If
                    If .ShipToAddressKey IsNot Nothing Then
                        objSalesOrder.SalesDocumentHeader.ShipToAddressKey = .ShipToAddressKey.Id
                    End If

                End With



                If objSalesOrder.SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                    stsNumbers = salesOrder.TrackingNumbers
                    ReDim Preserve stsNumbers(stsNumbers.Count + objSalesOrder.SalesDocumentHeader.TrackingNumbers.Count - 1)
                    For intLoop As Integer = 0 To objSalesOrder.SalesDocumentHeader.TrackingNumbers.Count - 1
                        stsNumbers(stsNumbers.Count - intLoop - 1) = New GP2010Service.SalesTrackingNumber
                        stsNumbers(stsNumbers.Count - intLoop - 1).Key = New GP2010Service.SalesTrackingNumberKey
                        stsNumbers(stsNumbers.Count - intLoop - 1).Key.SalesDocumentKey = salesOrder.Key
                        stsNumbers(stsNumbers.Count - intLoop - 1).Key.Id = objSalesOrder.SalesDocumentHeader.TrackingNumbers(intLoop)
                    Next
                    salesOrder.TrackingNumbers = stsNumbers
                End If



                'Populate Line Items
                For i As Integer = 0 To salesOrder.Lines.Length - 1
                    Dim LineItem As New MSGPWSIntegration.SOP.SalesDocumentDetail
                    With LineItem
                        If salesOrder.Lines(i).ItemKey IsNot Nothing Then
                            .ItemNumber = salesOrder.Lines(i).ItemKey.Id
                        End If
                        If salesOrder.Lines(i).Key IsNot Nothing Then
                            .LineSequenceNumber = salesOrder.Lines(i).Key.LineSequenceNumber
                        End If

                        .Quantity = salesOrder.Lines(i).Quantity.Value
                        .QuantityCanceled = salesOrder.Lines(i).QuantityCanceled.Value
                        .QuantityFullFilled = salesOrder.Lines(i).QuantityFulfilled.Value
                        .QuantityToBackOrder = salesOrder.Lines(i).QuantityToBackorder.Value
                        .QuantityToInvoice = salesOrder.Lines(i).QuantityToInvoice.Value
                        .SellPrice = salesOrder.Lines(i).UnitPrice.Value

                        If salesOrder.Lines(i).RequestedShipDate.HasValue = True Then
                            .RequestedShipDate = salesOrder.Lines(i).RequestedShipDate
                        End If
                        If salesOrder.Lines(i).ActualShipDate.HasValue = True Then
                            .ActualShipDate = salesOrder.Lines(i).ActualShipDate
                        End If
                    End With
                    objSalesOrder.SalesDocumentDetails.Add(LineItem)
                Next

                Return objSalesOrder
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Get GP Sales Invoice by SOP Number
        ''' </summary>
        ''' <param name="SOPNUMBE"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetGPSalesInvoice(ByVal SOPNUMBE As String, ByVal objGPConfiguration As GPSystemConfiguration) As SOP.SalesInvoice
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return GetGP10SalesInvoice(SOPNUMBE, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return GetGP2010SalesInvoice(SOPNUMBE, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Get GP 2010 Sales Invoice by SOP Number
        ''' </summary>
        ''' <param name="SOPNUMBE"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetGP2010SalesInvoice(ByVal SOPNUMBE As String, ByVal objGPConfiguration As GPSystemConfiguration) As SOP.SalesInvoice
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim salesInvoice As GP2010Service.SalesInvoice
                Dim salesDocumentKey As GP2010Service.SalesDocumentKey
                Dim objSalesInvoice As New SOP.SalesInvoice
                Helper.SetupWSWithConfiguration(objGPConfiguration)

                context = New GP2010Service.Context
                companyKey = New GP2010Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP2010Service.OrganizationKey)
                context.CultureName = "en-US"


                If Not String.IsNullOrEmpty(SOPNUMBE) Then
                    salesDocumentKey = New GP2010Service.SalesDocumentKey
                    salesDocumentKey.Id = SOPNUMBE
                Else
                    Throw New ArgumentException("Sales Invoice Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                salesInvoice = objGPConfiguration.GPWS2010.GetSalesInvoiceByKey(salesDocumentKey, context)

                'Populate Sales Order Header

                With salesInvoice
                    objSalesInvoice.SalesDocumentHeader.SOPDocumentKey = .Key.Id
                    objSalesInvoice.SalesDocumentHeader.SOPBatchId = .BatchKey.Id
                    objSalesInvoice.SalesDocumentHeader.FreightAmount = .FreightAmount.Value
                    objSalesInvoice.SalesDocumentHeader.CustomerId = .CustomerKey.Id
                    If .SalespersonKey IsNot Nothing Then
                        objSalesInvoice.SalesDocumentHeader.SalespersonKey = .SalespersonKey.Id
                    End If

                    objSalesInvoice.SalesDocumentHeader.CustomerPO = .CustomerPONumber
                    If .PaymentTermsKey IsNot Nothing Then
                        objSalesInvoice.SalesDocumentHeader.PaymentTermsKey = .PaymentTermsKey.Id
                    End If
                    objSalesInvoice.SalesDocumentHeader.CustomerNote = .Note
                    objSalesInvoice.SalesDocumentHeader.ShipToAddressKey = .ShipToAddressKey.Id
                    If .PostedDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.PostedDate = .PostedDate
                    End If
                    If .InvoiceDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.InvoiceDate = .InvoiceDate
                    End If
                    If .FulfillDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.FulfillDate = .FulfillDate
                    End If
                    If .ActualShipDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.ActualShipDate = .ActualShipDate
                    End If
                End With

                For Each trackingnumber As GP2010Service.SalesTrackingNumber In salesInvoice.TrackingNumbers
                    objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Add(trackingnumber.Key.Id)
                Next

                'Populate Line Items
                For i As Integer = 0 To salesInvoice.Lines.Length - 1
                    Dim LineItem As New MSGPWSIntegration.SOP.SalesDocumentDetail
                    With LineItem
                        .ItemNumber = salesInvoice.Lines(i).ItemKey.Id
                        .LineSequenceNumber = salesInvoice.Lines(i).Key.LineSequenceNumber
                        .Quantity = salesInvoice.Lines(i).Quantity.Value
                        .QuantityCanceled = salesInvoice.Lines(i).QuantityCanceled.Value
                        .QuantityFullFilled = salesInvoice.Lines(i).QuantityFulfilled.Value
                        .QuantityToBackOrder = salesInvoice.Lines(i).QuantityToBackorder.Value
                        .BillingQuantity = salesInvoice.Lines(i).BillingQuantity.Value
                        .RequestedShipDate = salesInvoice.Lines(i).RequestedShipDate
                        .ActualShipDate = salesInvoice.Lines(i).ActualShipDate
                        .SellPrice = salesInvoice.Lines(i).UnitPrice.Value

                    End With
                    objSalesInvoice.SalesDocumentDetails.Add(LineItem)
                Next

                Return objSalesInvoice
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Get GP 10 Sales Invoice by SOP Number
        ''' </summary>
        ''' <param name="SOPNUMBE"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetGP10SalesInvoice(ByVal SOPNUMBE As String, ByVal objGPConfiguration As GPSystemConfiguration) As SOP.SalesInvoice
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim salesInvoice As GP10Service.SalesInvoice
                Dim salesDocumentKey As GP10Service.SalesDocumentKey
                Dim objSalesInvoice As New SOP.SalesInvoice
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                Helper.SetupWSWithConfiguration(objGPConfiguration)
                'If Helper.wsDynamicsGP Is Nothing Then
                '    Helper.wsDynamicsGP = New GP10.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
                '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
                'End If

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"


                If Not String.IsNullOrEmpty(SOPNUMBE) Then
                    salesDocumentKey = New GP10Service.SalesDocumentKey
                    salesDocumentKey.Id = SOPNUMBE
                Else
                    Throw New ArgumentException("Sales Invoice Document Key is required")
                End If

                'Retrieve Sales Order By Document Key
                salesInvoice = objGPConfiguration.GPWS10.GetSalesInvoiceByKey(salesDocumentKey, context)

                'Populate Sales Order Header

                With salesInvoice
                    objSalesInvoice.SalesDocumentHeader.SOPDocumentKey = .Key.Id
                    objSalesInvoice.SalesDocumentHeader.SOPBatchId = .BatchKey.Id
                    objSalesInvoice.SalesDocumentHeader.FreightAmount = .FreightAmount.Value
                    objSalesInvoice.SalesDocumentHeader.CustomerId = .CustomerKey.Id
                    If .SalespersonKey IsNot Nothing Then
                        objSalesInvoice.SalesDocumentHeader.SalespersonKey = .SalespersonKey.Id
                    End If

                    objSalesInvoice.SalesDocumentHeader.CustomerPO = .CustomerPONumber
                    If .PaymentTermsKey IsNot Nothing Then
                        objSalesInvoice.SalesDocumentHeader.PaymentTermsKey = .PaymentTermsKey.Id
                    End If
                    objSalesInvoice.SalesDocumentHeader.CustomerNote = .Note
                    objSalesInvoice.SalesDocumentHeader.ShipToAddressKey = .ShipToAddressKey.Id
                    If .PostedDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.PostedDate = .PostedDate
                    End If
                    If .InvoiceDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.InvoiceDate = .InvoiceDate
                    End If
                    If .FulfillDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.FulfillDate = .FulfillDate
                    End If
                    If .ActualShipDate.HasValue Then
                        objSalesInvoice.SalesDocumentHeader.ActualShipDate = .ActualShipDate
                    End If
                End With

                For Each trackingnumber As GP10Service.SalesTrackingNumber In salesInvoice.TrackingNumbers
                    objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Add(trackingnumber.Key.Id)
                Next

                'Populate Line Items
                For i As Integer = 0 To salesInvoice.Lines.Length - 1
                    Dim LineItem As New MSGPWSIntegration.SOP.SalesDocumentDetail
                    With LineItem
                        .ItemNumber = salesInvoice.Lines(i).ItemKey.Id
                        .LineSequenceNumber = salesInvoice.Lines(i).Key.LineSequenceNumber
                        .Quantity = salesInvoice.Lines(i).Quantity.Value
                        .QuantityCanceled = salesInvoice.Lines(i).QuantityCanceled.Value
                        .QuantityFullFilled = salesInvoice.Lines(i).QuantityFulfilled.Value
                        .QuantityToBackOrder = salesInvoice.Lines(i).QuantityToBackorder.Value
                        .BillingQuantity = salesInvoice.Lines(i).BillingQuantity.Value
                        .RequestedShipDate = salesInvoice.Lines(i).RequestedShipDate
                        .ActualShipDate = salesInvoice.Lines(i).ActualShipDate
                        .SellPrice = salesInvoice.Lines(i).UnitPrice.Value

                    End With
                    objSalesInvoice.SalesDocumentDetails.Add(LineItem)
                Next

                Return objSalesInvoice
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Create GP Sales Quote
        ''' </summary>
        ''' <param name="objSalesQuote"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPSalesQuote(ByRef objSalesQuote As SOP.SalesQuote, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10SalesQuote(objSalesQuote, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010SalesQuote(objSalesQuote, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Create GP 10 Sales Quote
        ''' </summary>
        ''' <param name="objSalesQuote"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10SalesQuote(ByRef objSalesQuote As SOP.SalesQuote, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim QuoteDocumentKey As GP10Service.SalesDocumentKey
                Dim customerKey As GP10Service.CustomerKey
                Dim PaymentTermsKey As GP10Service.PaymentTermsKey
                Dim ShipMethodKey As GP10Service.ShippingMethodKey
                Dim CommentKey As GP10Service.CommentKey
                Dim batchKey As GP10Service.BatchKey
                Dim quoteItem As GP10Service.ItemKey
                Dim itemPrice As GP10Service.MoneyAmount
                Dim WarehouseKey As GP10Service.WarehouseKey
                Dim itemQuantity As GP10Service.Quantity
                Dim quoteItemQuantity As GP10Service.Quantity
                Dim salesQuote As GP10Service.SalesQuote
                Dim quotes As GP10Service.SalesQuoteLine()
                Dim salesQuoteLine As GP10Service.SalesQuoteLine
                Dim salesQuoteCreatePolicy As GP10Service.Policy
                Dim SalespersonKey As GP10Service.SalespersonKey
                Dim BillToAddressKey As GP10Service.CustomerAddressKey
                Dim ShipToAddressKey As GP10Service.CustomerAddressKey
                Dim ShipToAddress As GP10Service.BusinessAddress
                Dim PhoneNumber As GP10Service.PhoneNumber
                Dim GPSalesQuoteNo As String = String.Empty
                Dim salesTerritoryKey As GP10Service.SalesTerritoryKey
                Dim retSalesQuote As GP10Service.SalesQuote
                Helper.SetupWSWithConfiguration(objGPConfiguration)


                GPSalesQuoteNo = objSalesQuote.SalesDocumentHeader.SOPDocumentKey

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"
                salesQuote = New GP10Service.SalesQuote
                batchKey = New GP10Service.BatchKey
                batchKey.Id = objSalesQuote.SalesDocumentHeader.SOPBatchId
                salesQuote.BatchKey = batchKey

                '' Create a sales document type key
                QuoteDocumentKey = New GP10Service.SalesDocumentKey
                QuoteDocumentKey.Id = GPSalesQuoteNo
                salesQuote.Key = QuoteDocumentKey

                'Create Quote Header

                ' Create a customer key
                customerKey = New GP10Service.CustomerKey()
                customerKey.Id = objSalesQuote.SalesDocumentHeader.CustomerId
                salesQuote.CustomerKey = customerKey

                If objSalesQuote.SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.CustomerPO.ToString.Trim <> String.Empty Then
                    salesQuote.CustomerPONumber = objSalesQuote.SalesDocumentHeader.CustomerPO
                End If

                salesQuote.Date = Date.Parse(Date.Today.ToShortDateString)
                salesQuote.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                salesQuote.QuoteDate = Date.Parse(Date.Today.ToShortDateString)
                salesQuote.RequestedShipDate = IIf(objSalesQuote.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesQuote.SalesDocumentHeader.RequestedShipDate.ToShortDateString))
                salesQuote.ExpirationDate = IIf(objSalesQuote.SalesDocumentHeader.ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesQuote.SalesDocumentHeader.ExpirationDate.ToShortDateString))

                If objSalesQuote.SalesDocumentHeader.PaymentTermsKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.PaymentTermsKey.ToString.Trim <> String.Empty Then
                    PaymentTermsKey = New GP10Service.PaymentTermsKey
                    PaymentTermsKey.Id = objSalesQuote.SalesDocumentHeader.PaymentTermsKey
                    salesQuote.PaymentTermsKey = PaymentTermsKey
                End If
                If objSalesQuote.SalesDocumentHeader.PriceLevel > String.Empty Then
                    salesQuote.PriceLevelKey = New GP10Service.PriceLevelKey
                    salesQuote.PriceLevelKey.Id = objSalesQuote.SalesDocumentHeader.PriceLevel
                End If

                If objSalesQuote.SalesDocumentHeader.CommentKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.CommentKey.ToString.Trim <> String.Empty Then
                    CommentKey = New GP10Service.CommentKey
                    CommentKey.Id = objSalesQuote.SalesDocumentHeader.CommentKey
                    salesQuote.CommentKey = CommentKey
                End If

                If objSalesQuote.SalesDocumentHeader.Comment IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.Comment.ToString.Trim <> String.Empty Then
                    salesQuote.Comment = objSalesQuote.SalesDocumentHeader.Comment
                End If

                salesQuote.TaxExemptNumber1 = objSalesQuote.SalesDocumentHeader.TaxExempt1
                salesQuote.TaxExemptNumber2 = objSalesQuote.SalesDocumentHeader.TaxExempt2
                salesQuote.TaxRegistrationNumber = objSalesQuote.SalesDocumentHeader.TaxRegistrationNumber
                If objSalesQuote.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP10Service.ShippingMethodKey
                    ShipMethodKey.Id = objSalesQuote.SalesDocumentHeader.ShipmethodKey
                    salesQuote.ShippingMethodKey = ShipMethodKey
                End If

                If objSalesQuote.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.BillToAddressKey.ToString.ToString.Trim <> String.Empty Then
                    BillToAddressKey = New GP10Service.CustomerAddressKey
                    BillToAddressKey.Id = objSalesQuote.SalesDocumentHeader.BillToAddressKey
                    salesQuote.BillToAddressKey = BillToAddressKey
                End If
                If objSalesQuote.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.ShipToAddressKey.ToString.Trim <> String.Empty Then
                    ShipToAddressKey = New GP10Service.CustomerAddressKey
                    ShipToAddressKey.Id = objSalesQuote.SalesDocumentHeader.ShipToAddressKey
                    salesQuote.ShipToAddressKey = ShipToAddressKey
                End If


                If objSalesQuote.SalesDocumentHeader.SalespersonKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.SalespersonKey.ToString.Trim <> String.Empty Then
                    SalespersonKey = New GP10Service.SalespersonKey
                    SalespersonKey.Id = objSalesQuote.SalesDocumentHeader.SalespersonKey
                    salesQuote.SalespersonKey = SalespersonKey
                End If

                salesQuote.UserDefined = New GP10Service.SalesUserDefined

                If objSalesQuote.SalesDocumentHeader.FreightAccount IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.FreightAccount.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text01 = objSalesQuote.SalesDocumentHeader.FreightAccount.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.WarrantyDays <> Nothing AndAlso objSalesQuote.SalesDocumentHeader.WarrantyDays.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text02 = objSalesQuote.SalesDocumentHeader.WarrantyDays.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.FOB IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.FOB.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text03 = objSalesQuote.SalesDocumentHeader.FOB.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.TestProtocol IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.TestProtocol.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text05 = objSalesQuote.SalesDocumentHeader.TestProtocol.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.SalesTerritoryKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim <> String.Empty Then
                    salesTerritoryKey = New GP10Service.SalesTerritoryKey
                    salesTerritoryKey.Id = objSalesQuote.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim
                    salesQuote.SalesTerritoryKey = salesTerritoryKey
                End If

                'Create Shipping Address
                ShipToAddress = New GP10Service.BusinessAddress
                With ShipToAddress
                    .Name = objSalesQuote.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objSalesQuote.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objSalesQuote.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objSalesQuote.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objSalesQuote.SalesDocumentHeader.ShipToAddress.City
                    .State = objSalesQuote.SalesDocumentHeader.ShipToAddress.State
                    .CountryRegion = objSalesQuote.SalesDocumentHeader.ShipToAddress.Country
                    .PostalCode = objSalesQuote.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objSalesQuote.SalesDocumentHeader.ShipToAddress.ContactPerson
                    .CountryRegion = objSalesQuote.SalesDocumentHeader.ShipToAddress.Country
                    If objSalesQuote.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP10Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objSalesQuote.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If
                    PhoneNumber = New GP10Service.PhoneNumber
                    PhoneNumber.Value = objSalesQuote.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                End With
                salesQuote.ShipToAddress = ShipToAddress

                'Create a sales quote line
                ReDim quotes(objSalesQuote.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objSalesQuote.SalesDocumentDetails.Count - 1
                    salesQuoteLine = New GP10Service.SalesQuoteLine

                    With objSalesQuote.SalesDocumentDetails.Item(i)
                        quoteItem = New GP10Service.ItemKey()
                        quoteItem.Id = .ItemNumber
                        salesQuoteLine.ItemKey = quoteItem

                        itemQuantity = New GP10Service.Quantity()
                        itemQuantity.Value = .QuantityToInvoice
                        salesQuoteLine.QuantityToInvoice = itemQuantity

                        itemQuantity = New GP10Service.Quantity()
                        itemQuantity.Value = .Quantity
                        salesQuoteLine.QuantityToOrder = itemQuantity

                        quoteItemQuantity = New GP10Service.Quantity()
                        quoteItemQuantity.Value = .Quantity
                        salesQuoteLine.Quantity = quoteItemQuantity

                        itemPrice = New GP10Service.MoneyAmount
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        itemPrice.Value = .SellPrice
                        salesQuoteLine.UnitPrice = itemPrice

                        If .UOM IsNot Nothing AndAlso .UOM.ToString.Trim <> String.Empty Then
                            salesQuoteLine.UofM = .UOM
                        End If

                        If .SiteID IsNot Nothing AndAlso .SiteID.ToString.Trim <> String.Empty Then
                            WarehouseKey = New GP10Service.WarehouseKey
                            WarehouseKey.Id = .SiteID
                            salesQuoteLine.WarehouseKey = WarehouseKey
                        End If
                        If .CommentKey IsNot Nothing AndAlso .CommentKey.ToString.Trim <> String.Empty Then
                            CommentKey = New GP10Service.CommentKey
                            CommentKey.Id = .CommentKey
                            salesQuoteLine.CommentKey = CommentKey
                        End If

                        If .CommentText IsNot Nothing AndAlso .CommentText.ToString.Trim <> String.Empty Then
                            salesQuoteLine.Comment = .CommentText
                        End If

                        If .SalesTerritoryKey IsNot Nothing AndAlso .SalesTerritoryKey.ToString.Trim <> String.Empty Then
                            salesTerritoryKey = New GP10Service.SalesTerritoryKey
                            salesTerritoryKey.Id = .SalesTerritoryKey
                            salesQuoteLine.SalesTerritoryKey = salesTerritoryKey
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP10Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesQuoteLine.ShippingMethodKey = ShipMethodKey
                        End If

                        salesQuoteLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(.RequestedShipDate.ToShortDateString))

                    End With
                    quotes(i) = salesQuoteLine
                Next

                ' Add the sales quote line to the sales quote object
                salesQuote.Lines = quotes
                ' Get the create policy for sales quotes
                salesQuoteCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateSalesQuote", context)
                objGPConfiguration.GPWS10.CreateSalesQuote(salesQuote, context, salesQuoteCreatePolicy)

                'Get SalesQuote after inserted successfully
                retSalesQuote = objGPConfiguration.GPWS10.GetSalesQuoteByKey(QuoteDocumentKey, context)
                For j As Integer = 0 To retSalesQuote.Lines.Length - 1
                    objSalesQuote.SalesDocumentDetails(j).LineSequenceNumber = retSalesQuote.Lines(j).Key.LineSequenceNumber
                Next
                quotes = Nothing
                salesQuote = Nothing
                Return GPSalesQuoteNo
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Create GP 2010 Sales Quote
        ''' </summary>
        ''' <param name="objSalesQuote"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010SalesQuote(ByRef objSalesQuote As SOP.SalesQuote, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim QuoteDocumentKey As GP2010Service.SalesDocumentKey
                Dim customerKey As GP2010Service.CustomerKey
                Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
                Dim ShipMethodKey As GP2010Service.ShippingMethodKey
                Dim CommentKey As GP2010Service.CommentKey
                Dim batchKey As GP2010Service.BatchKey
                Dim quoteItem As GP2010Service.ItemKey
                Dim itemPrice As GP2010Service.MoneyAmount
                Dim WarehouseKey As GP2010Service.WarehouseKey
                Dim itemQuantity As GP2010Service.Quantity
                Dim quoteItemQuantity As GP2010Service.Quantity
                Dim salesQuote As GP2010Service.SalesQuote
                Dim quotes As GP2010Service.SalesQuoteLine()
                Dim salesQuoteLine As GP2010Service.SalesQuoteLine
                Dim salesQuoteCreatePolicy As GP2010Service.Policy
                Dim SalespersonKey As GP2010Service.SalespersonKey
                Dim BillToAddressKey As GP2010Service.CustomerAddressKey
                Dim ShipToAddressKey As GP2010Service.CustomerAddressKey
                Dim ShipToAddress As GP2010Service.BusinessAddress
                Dim PhoneNumber As GP2010Service.PhoneNumber
                Dim GPSalesQuoteNo As String = String.Empty
                Dim salesTerritoryKey As GP2010Service.SalesTerritoryKey
                Dim retSalesQuote As DynamicsWCFService.SalesQuote
                Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity

                GPSalesQuoteNo = objSalesQuote.SalesDocumentHeader.SOPDocumentKey

                context = New GP2010Service.Context
                companyKey = New GP2010Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP2010Service.OrganizationKey)
                context.CultureName = "en-US"
                salesQuote = New DynamicsWCFService.SalesQuote
                batchKey = New GP2010Service.BatchKey
                batchKey.Id = objSalesQuote.SalesDocumentHeader.SOPBatchId
                salesQuote.BatchKey = batchKey

                '' Create a sales document type key
                QuoteDocumentKey = New DynamicsWCFService.SalesDocumentKey
                QuoteDocumentKey.Id = GPSalesQuoteNo
                salesQuote.Key = QuoteDocumentKey

                'Create Quote Header

                ' Create a customer key
                customerKey = New GP2010Service.CustomerKey()
                customerKey.Id = objSalesQuote.SalesDocumentHeader.CustomerId
                salesQuote.CustomerKey = customerKey

                If objSalesQuote.SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.CustomerPO.ToString.Trim <> String.Empty Then
                    salesQuote.CustomerPONumber = objSalesQuote.SalesDocumentHeader.CustomerPO
                End If

                salesQuote.Date = Date.Parse(Date.Today.ToShortDateString)
                salesQuote.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                salesQuote.QuoteDate = Date.Parse(Date.Today.ToShortDateString)
                salesQuote.RequestedShipDate = IIf(objSalesQuote.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesQuote.SalesDocumentHeader.RequestedShipDate.ToShortDateString))
                salesQuote.ExpirationDate = IIf(objSalesQuote.SalesDocumentHeader.ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesQuote.SalesDocumentHeader.ExpirationDate.ToShortDateString))

                If objSalesQuote.SalesDocumentHeader.PaymentTermsKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.PaymentTermsKey.ToString.Trim <> String.Empty Then
                    PaymentTermsKey = New GP2010Service.PaymentTermsKey
                    PaymentTermsKey.Id = objSalesQuote.SalesDocumentHeader.PaymentTermsKey
                    salesQuote.PaymentTermsKey = PaymentTermsKey
                End If


                If objSalesQuote.SalesDocumentHeader.CommentKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.CommentKey.ToString.Trim <> String.Empty Then
                    CommentKey = New GP2010Service.CommentKey
                    CommentKey.Id = objSalesQuote.SalesDocumentHeader.CommentKey
                    salesQuote.CommentKey = CommentKey
                End If

                If objSalesQuote.SalesDocumentHeader.Comment IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.Comment.ToString.Trim <> String.Empty Then
                    salesQuote.Comment = objSalesQuote.SalesDocumentHeader.Comment
                End If

                If objSalesQuote.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP2010Service.ShippingMethodKey
                    ShipMethodKey.Id = objSalesQuote.SalesDocumentHeader.ShipmethodKey
                    salesQuote.ShippingMethodKey = ShipMethodKey
                End If
                If objSalesQuote.SalesDocumentHeader.PriceLevel > String.Empty Then
                    salesQuote.PriceLevelKey = New GP2010Service.PriceLevelKey
                    salesQuote.PriceLevelKey.Id = objSalesQuote.SalesDocumentHeader.PriceLevel
                End If
                If objSalesQuote.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.BillToAddressKey.ToString.ToString.Trim <> String.Empty Then
                    BillToAddressKey = New GP2010Service.CustomerAddressKey
                    BillToAddressKey.Id = objSalesQuote.SalesDocumentHeader.BillToAddressKey
                    salesQuote.BillToAddressKey = BillToAddressKey
                End If
                If objSalesQuote.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.ShipToAddressKey.ToString.Trim <> String.Empty Then
                    ShipToAddressKey = New GP2010Service.CustomerAddressKey
                    ShipToAddressKey.Id = objSalesQuote.SalesDocumentHeader.ShipToAddressKey
                    salesQuote.ShipToAddressKey = ShipToAddressKey
                End If


                If objSalesQuote.SalesDocumentHeader.SalespersonKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.SalespersonKey.ToString.Trim <> String.Empty Then
                    SalespersonKey = New GP2010Service.SalespersonKey
                    SalespersonKey.Id = objSalesQuote.SalesDocumentHeader.SalespersonKey
                    salesQuote.SalespersonKey = SalespersonKey
                End If

                salesQuote.UserDefined = New GP2010Service.SalesUserDefined

                salesQuote.TaxExemptNumber1 = objSalesQuote.SalesDocumentHeader.TaxExempt1
                salesQuote.TaxExemptNumber2 = objSalesQuote.SalesDocumentHeader.TaxExempt2
                salesQuote.TaxRegistrationNumber = objSalesQuote.SalesDocumentHeader.TaxRegistrationNumber
                If objSalesQuote.SalesDocumentHeader.FreightAccount IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.FreightAccount.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text01 = objSalesQuote.SalesDocumentHeader.FreightAccount.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.WarrantyDays <> Nothing AndAlso objSalesQuote.SalesDocumentHeader.WarrantyDays.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text02 = objSalesQuote.SalesDocumentHeader.WarrantyDays.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.FOB IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.FOB.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text03 = objSalesQuote.SalesDocumentHeader.FOB.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.TestProtocol IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.TestProtocol.ToString.Trim <> String.Empty Then
                    salesQuote.UserDefined.Text05 = objSalesQuote.SalesDocumentHeader.TestProtocol.ToString.Trim
                End If

                If objSalesQuote.SalesDocumentHeader.SalesTerritoryKey IsNot Nothing AndAlso objSalesQuote.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim <> String.Empty Then
                    salesTerritoryKey = New GP2010Service.SalesTerritoryKey
                    salesTerritoryKey.Id = objSalesQuote.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim
                    salesQuote.SalesTerritoryKey = salesTerritoryKey
                End If

                'Create Shipping Address
                ShipToAddress = New GP2010Service.BusinessAddress
                With ShipToAddress
                    .Name = objSalesQuote.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objSalesQuote.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objSalesQuote.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objSalesQuote.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objSalesQuote.SalesDocumentHeader.ShipToAddress.City
                    .State = objSalesQuote.SalesDocumentHeader.ShipToAddress.State
                    .CountryRegion = objSalesQuote.SalesDocumentHeader.ShipToAddress.Country
                    .PostalCode = objSalesQuote.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objSalesQuote.SalesDocumentHeader.ShipToAddress.ContactPerson
                    .CountryRegion = objSalesQuote.SalesDocumentHeader.ShipToAddress.Country
                    If objSalesQuote.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP2010Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objSalesQuote.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If
                    PhoneNumber = New GP2010Service.PhoneNumber
                    PhoneNumber.Value = objSalesQuote.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                End With
                salesQuote.ShipToAddress = ShipToAddress

                'Create a sales quote line
                ReDim quotes(objSalesQuote.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objSalesQuote.SalesDocumentDetails.Count - 1
                    salesQuoteLine = New GP2010Service.SalesQuoteLine

                    With objSalesQuote.SalesDocumentDetails.Item(i)
                        quoteItem = New GP2010Service.ItemKey()
                        quoteItem.Id = .ItemNumber
                        salesQuoteLine.ItemKey = quoteItem

                        itemQuantity = New GP2010Service.Quantity()
                        itemQuantity.Value = .QuantityToInvoice
                        salesQuoteLine.QuantityToInvoice = itemQuantity

                        itemQuantity = New GP2010Service.Quantity()
                        itemQuantity.Value = .Quantity
                        salesQuoteLine.QuantityToOrder = itemQuantity

                        quoteItemQuantity = New GP2010Service.Quantity()
                        quoteItemQuantity.Value = .Quantity
                        salesQuoteLine.Quantity = quoteItemQuantity

                        itemPrice = New GP2010Service.MoneyAmount
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        itemPrice.Value = .SellPrice
                        salesQuoteLine.UnitPrice = itemPrice

                        If .UOM IsNot Nothing AndAlso .UOM.ToString.Trim <> String.Empty Then
                            salesQuoteLine.UofM = .UOM
                        End If

                        If .SiteID IsNot Nothing AndAlso .SiteID.ToString.Trim <> String.Empty Then
                            WarehouseKey = New GP2010Service.WarehouseKey
                            WarehouseKey.Id = .SiteID
                            salesQuoteLine.WarehouseKey = WarehouseKey
                        End If
                        If .CommentKey IsNot Nothing AndAlso .CommentKey.ToString.Trim <> String.Empty Then
                            CommentKey = New GP2010Service.CommentKey
                            CommentKey.Id = .CommentKey
                            salesQuoteLine.CommentKey = CommentKey
                        End If

                        If .CommentText IsNot Nothing AndAlso .CommentText.ToString.Trim <> String.Empty Then
                            salesQuoteLine.Comment = .CommentText
                        End If

                        If .SalesTerritoryKey IsNot Nothing AndAlso .SalesTerritoryKey.ToString.Trim <> String.Empty Then
                            salesTerritoryKey = New GP2010Service.SalesTerritoryKey
                            salesTerritoryKey.Id = .SalesTerritoryKey
                            salesQuoteLine.SalesTerritoryKey = salesTerritoryKey
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP2010Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesQuoteLine.ShippingMethodKey = ShipMethodKey
                        End If

                        salesQuoteLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(.RequestedShipDate.ToShortDateString))

                    End With
                    quotes(i) = salesQuoteLine
                Next

                ' Add the sales quote line to the sales quote object
                salesQuote.Lines = quotes
                ' Get the create policy for sales quotes
                salesQuoteCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateSalesQuote", context)
                objGPConfiguration.GPWS2010.CreateSalesQuote(salesQuote, context, salesQuoteCreatePolicy)

                'Get SalesQuote after inserted successfully
                retSalesQuote = objGPConfiguration.GPWS2010.GetSalesQuoteByKey(QuoteDocumentKey, context)
                For j As Integer = 0 To retSalesQuote.Lines.Length - 1
                    objSalesQuote.SalesDocumentDetails(j).LineSequenceNumber = retSalesQuote.Lines(j).Key.LineSequenceNumber
                Next
                quotes = Nothing
                salesQuote = Nothing
                Return GPSalesQuoteNo
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Create Great Plains Sales Invoice
        ''' </summary>
        ''' <param name="objSalesInvoice"></param>
        ''' <returns>Sales Invoice Number</returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPSalesInvoice(ByVal objSalesInvoice As SOP.SalesInvoice, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10SalesInvoice(objSalesInvoice, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010SalesInvoice(objSalesInvoice, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function

        ''' <summary>
        ''' Create Great Plains 10 Sales Invoice
        ''' </summary>
        ''' <param name="objSalesInvoice"></param>
        ''' <returns>Sales Invoice Number</returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10SalesInvoice(ByVal objSalesInvoice As SOP.SalesInvoice, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim SalesDocumentKey As GP10Service.SalesDocumentKey
                Dim customerKey As GP10Service.CustomerKey
                Dim PaymentTermsKey As GP10Service.PaymentTermsKey
                Dim ShipMethodKey As GP10Service.ShippingMethodKey
                Dim CustomerAddressKey As GP10Service.CustomerAddressKey
                Dim CommentKey As GP10Service.CommentKey
                Dim batchKey As GP10Service.BatchKey
                Dim quoteItem As GP10Service.ItemKey
                Dim itemPrice As GP10Service.MoneyAmount
                Dim freightAmount As GP10Service.MoneyAmount
                Dim WarehouseKey As GP10Service.WarehouseKey
                Dim itemQuantity As GP10Service.Quantity
                Dim SalespersonKey As GP10Service.SalespersonKey
                Dim BillToAddressKey As GP10Service.CustomerAddressKey
                Dim ShipToAddressKey As GP10Service.CustomerAddressKey
                Dim ShipToAddress As GP10Service.BusinessAddress
                Dim PhoneNumber As GP10Service.PhoneNumber
                Dim salesTerritoryKey As GP10Service.SalesTerritoryKey
                Dim salesInvoice As GP10Service.SalesInvoice
                Dim salesInvoiceLines As GP10Service.SalesInvoiceLine()
                Dim salesInvoiceLine As GP10Service.SalesInvoiceLine
                Dim salesInvoiceCreatePolicy As GP10Service.Policy
                Dim GPSalesInvoiceNo As String = String.Empty
                Dim salesUserDefined As GP10Service.SalesUserDefined
                Dim moneyAmount As GP10Service.MoneyAmount
                Dim paymentCardTypeKey As GP10Service.PaymentCardTypeKey
                Dim salesPayments As GP10Service.SalesPayment()
                Dim salesPayment As GP10Service.SalesPayment
                Dim bankAccountKey As GP10Service.BankAccountKey
                Dim salesDocumentTypeKey As GP10Service.SalesDocumentTypeKey
                Dim taxScheduleKey As GP10Service.TaxScheduleKey
                Dim tdpTradeDiscountPercent As GP10Service.MoneyPercentChoice
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity

                Helper.SetupWSWithConfiguration(objGPConfiguration)

                'If objGPConfiguration.GPWS10 Is Nothing Then
                '    objGPConfiguration.GPWS10 = New GP10Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
                '    objGPConfiguration.GPWS10.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
                'End If

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"
                salesInvoice = New GP10Service.SalesInvoice
                batchKey = New GP10Service.BatchKey
                batchKey.Id = objSalesInvoice.SalesDocumentHeader.SOPBatchId
                salesInvoice.BatchKey = batchKey

                If objSalesInvoice.SalesDocumentHeader.SalesDocumentTypeKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesDocumentTypeKey) Then
                    salesDocumentTypeKey = New GP10Service.SalesDocumentTypeKey
                    salesDocumentTypeKey.Id = objSalesInvoice.SalesDocumentHeader.SalesDocumentTypeKey
                    salesDocumentTypeKey.Type = GP10Service.SalesDocumentType.Invoice
                    salesInvoice.DocumentTypeKey = salesDocumentTypeKey
                End If

                If objSalesInvoice.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesInvoiceNo = objSalesInvoice.SalesDocumentHeader.SOPDocumentKey
                    SalesDocumentKey = New GP10Service.SalesDocumentKey
                    SalesDocumentKey.Id = GPSalesInvoiceNo
                    salesInvoice.Key = SalesDocumentKey
                End If

                ' Create a customer key
                customerKey = New GP10Service.CustomerKey()
                customerKey.Id = objSalesInvoice.SalesDocumentHeader.CustomerId
                salesInvoice.CustomerKey = customerKey

                If objSalesInvoice.SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.CustomerPO.ToString.Trim <> String.Empty Then
                    salesInvoice.CustomerPONumber = objSalesInvoice.SalesDocumentHeader.CustomerPO
                End If

                salesInvoice.Date = Date.Parse(Date.Today.ToShortDateString)
                salesInvoice.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                salesInvoice.QuoteDate = Date.Parse(Date.Today.ToShortDateString)
                salesInvoice.RequestedShipDate = IIf(objSalesInvoice.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesInvoice.SalesDocumentHeader.RequestedShipDate.ToShortDateString))
                salesInvoice.ActualShipDate = IIf(objSalesInvoice.SalesDocumentHeader.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesInvoice.SalesDocumentHeader.ActualShipDate.ToShortDateString))

                If objSalesInvoice.SalesDocumentHeader.PriceLevel > String.Empty Then
                    salesInvoice.PriceLevelKey = New GP10Service.PriceLevelKey
                    salesInvoice.PriceLevelKey.Id = objSalesInvoice.SalesDocumentHeader.PriceLevel
                End If

                If objSalesInvoice.SalesDocumentHeader.PaymentTermsKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.PaymentTermsKey.ToString.Trim <> String.Empty Then
                    PaymentTermsKey = New GP10Service.PaymentTermsKey
                    PaymentTermsKey.Id = objSalesInvoice.SalesDocumentHeader.PaymentTermsKey
                    salesInvoice.PaymentTermsKey = PaymentTermsKey
                End If
                salesInvoice.TaxExemptNumber1 = objSalesInvoice.SalesDocumentHeader.TaxExempt1
                salesInvoice.TaxExemptNumber2 = objSalesInvoice.SalesDocumentHeader.TaxExempt2
                salesInvoice.TaxRegistrationNumber = objSalesInvoice.SalesDocumentHeader.TaxRegistrationNumber
                Dim stsNumbers() As GP10Service.SalesTrackingNumber = {}
                Dim lstNumbers As New List(Of GP10Service.SalesTrackingNumber)
                Dim trkTrackingNumber As GP10Service.SalesTrackingNumber
                Dim blnFoundTracking As Boolean
                If objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                    For intLoop As Integer = 0 To objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Count - 1
                        blnFoundTracking = False
                        For Each trkTrackingNumber In lstNumbers
                            If trkTrackingNumber.Key.Id = objSalesInvoice.SalesDocumentHeader.TrackingNumbers(intLoop) Then
                                blnFoundTracking = True
                            End If
                        Next
                        If blnFoundTracking = False Then
                            trkTrackingNumber = New GP10Service.SalesTrackingNumber
                            trkTrackingNumber.Key = New GP10Service.SalesTrackingNumberKey
                            trkTrackingNumber.Key.SalesDocumentKey = salesInvoice.Key
                            trkTrackingNumber.Key.Id = objSalesInvoice.SalesDocumentHeader.TrackingNumbers(intLoop)
                            lstNumbers.Add(trkTrackingNumber)
                        End If
                    Next
                    salesInvoice.TrackingNumbers = lstNumbers.ToArray
                End If

                If objSalesInvoice.SalesDocumentHeader.CommentKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.CommentKey.ToString.Trim <> String.Empty Then
                    CommentKey = New GP10Service.CommentKey
                    CommentKey.Id = objSalesInvoice.SalesDocumentHeader.CommentKey
                    salesInvoice.CommentKey = CommentKey
                End If

                If objSalesInvoice.SalesDocumentHeader.Comment IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.Comment.ToString.Trim <> String.Empty Then
                    salesInvoice.Comment = objSalesInvoice.SalesDocumentHeader.Comment
                End If

                If objSalesInvoice.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP10Service.ShippingMethodKey
                    ShipMethodKey.Id = objSalesInvoice.SalesDocumentHeader.ShipmethodKey
                    salesInvoice.ShippingMethodKey = ShipMethodKey
                End If

                If objSalesInvoice.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.BillToAddressKey.ToString.ToString.Trim <> String.Empty Then
                    BillToAddressKey = New GP10Service.CustomerAddressKey
                    BillToAddressKey.Id = objSalesInvoice.SalesDocumentHeader.BillToAddressKey
                    salesInvoice.BillToAddressKey = BillToAddressKey
                End If
                If objSalesInvoice.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ShipToAddressKey.ToString.Trim <> String.Empty Then
                    ShipToAddressKey = New GP10Service.CustomerAddressKey
                    ShipToAddressKey.Id = objSalesInvoice.SalesDocumentHeader.ShipToAddressKey
                    salesInvoice.ShipToAddressKey = ShipToAddressKey
                End If


                If objSalesInvoice.SalesDocumentHeader.SalespersonKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.SalespersonKey.ToString.Trim <> String.Empty Then
                    SalespersonKey = New GP10Service.SalespersonKey
                    SalespersonKey.Id = objSalesInvoice.SalesDocumentHeader.SalespersonKey
                    salesInvoice.SalespersonKey = SalespersonKey
                End If

                salesInvoice.UserDefined = New GP10Service.SalesUserDefined

                If objSalesInvoice.SalesDocumentHeader.FreightAccount IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.FreightAccount.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text01 = objSalesInvoice.SalesDocumentHeader.FreightAccount.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.WarrantyDays <> Nothing AndAlso objSalesInvoice.SalesDocumentHeader.WarrantyDays.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text02 = objSalesInvoice.SalesDocumentHeader.WarrantyDays.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.FOB IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.FOB.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text03 = objSalesInvoice.SalesDocumentHeader.FOB.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.TestProtocol IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.TestProtocol.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text05 = objSalesInvoice.SalesDocumentHeader.TestProtocol.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.SalesTerritoryKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim <> String.Empty Then
                    salesTerritoryKey = New GP10Service.SalesTerritoryKey
                    salesTerritoryKey.Id = objSalesInvoice.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim
                    salesInvoice.SalesTerritoryKey = salesTerritoryKey
                End If

                If objSalesInvoice.SalesDocumentHeader.CustomerNote IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ToString.Trim <> String.Empty Then
                    salesInvoice.Note = objSalesInvoice.SalesDocumentHeader.CustomerNote
                End If

                'Create Shipping Address
                ShipToAddress = New GP10Service.BusinessAddress
                With ShipToAddress
                    .Name = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objSalesInvoice.SalesDocumentHeader.ShipToAddress.City
                    .State = objSalesInvoice.SalesDocumentHeader.ShipToAddress.State
                    .CountryRegion = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Country
                    .PostalCode = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objSalesInvoice.SalesDocumentHeader.ShipToAddress.ContactPerson
                    .CountryRegion = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Country
                    If objSalesInvoice.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP10Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objSalesInvoice.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If
                    PhoneNumber = New GP10Service.PhoneNumber
                    PhoneNumber.Value = objSalesInvoice.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                End With
                salesInvoice.ShipToAddress = ShipToAddress

                If Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.TaxScheduleKey) Then
                    taxScheduleKey = New GP10Service.TaxScheduleKey
                    taxScheduleKey.Id = objSalesInvoice.SalesDocumentHeader.TaxScheduleKey
                    salesInvoice.TaxScheduleKey = taxScheduleKey
                End If

                If objSalesInvoice.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ShipToAddressKey.ToString.Trim <> String.Empty Then
                    CustomerAddressKey = New GP10Service.CustomerAddressKey
                    CustomerAddressKey.CustomerKey = customerKey
                    CustomerAddressKey.Id = objSalesInvoice.SalesDocumentHeader.ShipToAddressKey
                    salesInvoice.ShipToAddressKey = CustomerAddressKey
                End If

                freightAmount = New GP10Service.MoneyAmount
                freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                freightAmount.Value = objSalesInvoice.SalesDocumentHeader.FreightAmount
                salesInvoice.FreightAmount = freightAmount

                If objSalesInvoice.SalesDocumentHeader.PaymentAmount > 0 Then
                    moneyAmount = New GP10Service.MoneyAmount
                    moneyAmount.Value = objSalesInvoice.SalesDocumentHeader.PaymentAmount
                    moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                    salesInvoice.PaymentAmount = moneyAmount
                End If

                'Dim trackingnumber As GP10Service.SalesTrackingNumber
                'For Each strTrackingNumber As String In objSalesInvoice.SalesDocumentHeader.TrackingNumbers
                '    trackingnumber = New GP10Service.SalesTrackingNumber
                '    trackingnumber.Key = New GP10Service.SalesTrackingNumberKey
                '    trackingnumber.Key.Id = strTrackingNumber
                'Next


                'For Each trackingnumber As SalesTrackingNumber In salesInvoice.TrackingNumbers
                '    If trackingnumber.Key IsNot Nothing Then
                '        objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Add(trackingnumber.Key.Id)
                '    End If
                'Next


                If objSalesInvoice.SalesDocumentHeader.SalesPayments.Count > 0 Then
                    ReDim salesPayments(objSalesInvoice.SalesDocumentHeader.SalesPayments.Count - 1)
                    For i As Integer = 0 To objSalesInvoice.SalesDocumentHeader.SalesPayments.Count - 1
                        salesPayment = New GP10Service.SalesPayment

                        salesPayment.Type = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).SalesPaymentType

                        paymentCardTypeKey = New GP10Service.PaymentCardTypeKey
                        paymentCardTypeKey.Id = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey
                        salesPayment.PaymentCardTypeKey = paymentCardTypeKey

                        moneyAmount = New GP10Service.MoneyAmount
                        moneyAmount.Value = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentAmount
                        moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesPayment.PaymentAmount = moneyAmount


                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuthorizationCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuthorizationCode) Then
                            salesPayment.AuthorizationCode = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuthorizationCode
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).BankAccountKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).BankAccountKey) Then
                            bankAccountKey = New GP10Service.BankAccountKey
                            bankAccountKey.Id = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).BankAccountKey
                            salesPayment.BankAccountKey = bankAccountKey
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber) Then
                            salesPayment.PaymentCardNumber = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).CheckNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).CheckNumber) Then
                            salesPayment.CheckNumber = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).CheckNumber
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).Number IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).Number) Then
                            salesPayment.Number = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).Number
                        End If

                        salesPayment.ExpirationDate = IIf(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).ExpirationDate.ToShortDateString))

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuditTrailCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuditTrailCode) Then
                            salesPayment.AuditTrailCode = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuditTrailCode
                        End If

                        salesPayment.Date = IIf(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentDate.Year < 1901, Date.Parse(Now.ToShortDateString), Date.Parse(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentDate.ToShortDateString))

                        salesPayment.DeleteOnUpdate = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).DeleteOnUpdate

                        salesPayments(i) = salesPayment
                    Next

                    salesInvoice.Payments = salesPayments
                End If

                'create up SalesUserDefined
                If objSalesInvoice.SalesDocumentHeader.SalesUserDefined IsNot Nothing Then
                    salesUserDefined = New GP10Service.SalesUserDefined

                    With objSalesInvoice.SalesDocumentHeader.SalesUserDefined
                        If .Date01 <> Nothing Then
                            salesUserDefined.Date01 = Date.Parse(.Date01.ToShortDateString)
                        End If
                        If .Date02 <> Nothing Then
                            salesUserDefined.Date02 = Date.Parse(.Date02.ToShortDateString)
                        End If
                        If .List01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List01) Then
                            salesUserDefined.List01 = .List01
                        End If
                        If .List02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List02) Then
                            salesUserDefined.List02 = .List02
                        End If
                        If .List03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List03) Then
                            salesUserDefined.List03 = .List03
                        End If
                        If .Text01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text01) Then
                            salesUserDefined.Text01 = .Text01
                        End If
                        If .Text02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text02) Then
                            salesUserDefined.Text02 = .Text02
                        End If
                        If .Text03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text03) Then
                            salesUserDefined.Text03 = .Text03
                        End If
                        If .Text04 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text04) Then
                            salesUserDefined.Text04 = .Text04
                        End If
                        If .Text05 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text05) Then
                            salesUserDefined.Text05 = .Text05
                        End If

                    End With

                    salesInvoice.UserDefined = salesUserDefined
                End If

                'Create  sales invoice lines
                ReDim salesInvoiceLines(objSalesInvoice.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objSalesInvoice.SalesDocumentDetails.Count - 1
                    salesInvoiceLine = New GP10Service.SalesInvoiceLine

                    With objSalesInvoice.SalesDocumentDetails.Item(i)
                        quoteItem = New GP10Service.ItemKey()
                        quoteItem.Id = .ItemNumber
                        salesInvoiceLine.ItemKey = quoteItem

                        itemQuantity = New GP10Service.Quantity()
                        itemQuantity.Value = .Quantity
                        salesInvoiceLine.Quantity = itemQuantity

                        itemPrice = New GP10Service.MoneyAmount
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        itemPrice.Value = .SellPrice
                        salesInvoiceLine.UnitPrice = itemPrice
                        If .DiscountAmount > 0 Then
                            tdpTradeDiscountPercent = New GP10Service.MoneyPercentChoice
                            tdpTradeDiscountPercent.Item = New GP10Service.MoneyAmount
                            CType(tdpTradeDiscountPercent.Item, GP10Service.MoneyAmount).Value = .DiscountAmount
                            salesInvoiceLine.Discount = tdpTradeDiscountPercent
                        End If
                        'itemPrice = New MoneyAmount
                        'itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        'itemPrice.Value = .ExtendedPrice
                        'salesInvoiceLine.ExtendedCost = itemPrice

                        If .UOM IsNot Nothing AndAlso .UOM.ToString.Trim <> String.Empty Then
                            salesInvoiceLine.UofM = .UOM
                        End If
                        If .ItemDescription > String.Empty Then
                            salesInvoiceLine.ItemDescription = .ItemDescription
                        End If
                        If .SiteID IsNot Nothing AndAlso .SiteID.ToString.Trim <> String.Empty Then
                            WarehouseKey = New GP10Service.WarehouseKey
                            WarehouseKey.Id = .SiteID
                            salesInvoiceLine.WarehouseKey = WarehouseKey
                        End If
                        If .CommentKey IsNot Nothing AndAlso .CommentKey.ToString.Trim <> String.Empty Then
                            CommentKey = New GP10Service.CommentKey
                            CommentKey.Id = .CommentKey
                            salesInvoiceLine.CommentKey = CommentKey
                        End If

                        If .CommentText IsNot Nothing AndAlso .CommentText.ToString.Trim <> String.Empty Then
                            salesInvoiceLine.Comment = .CommentText
                        End If

                        If .SalesTerritoryKey IsNot Nothing AndAlso .SalesTerritoryKey.ToString.Trim <> String.Empty Then
                            salesTerritoryKey = New GP10Service.SalesTerritoryKey
                            salesTerritoryKey.Id = .SalesTerritoryKey
                            salesInvoiceLine.SalesTerritoryKey = salesTerritoryKey
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP10Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesInvoiceLine.ShippingMethodKey = ShipMethodKey
                        End If

                        If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                            ShipToAddressKey = New GP10Service.CustomerAddressKey
                            ShipToAddressKey.Id = .ShipToAddressKey
                            ShipToAddressKey.CustomerKey = salesInvoice.CustomerKey
                            salesInvoiceLine.ShipToAddressKey = ShipToAddressKey
                        End If

                        If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                            taxScheduleKey = New GP10Service.TaxScheduleKey
                            taxScheduleKey.Id = .TaxScheduleKey
                            salesInvoiceLine.TaxScheduleKey = taxScheduleKey
                        End If

                        If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                            taxScheduleKey = New GP10Service.TaxScheduleKey
                            taxScheduleKey.Id = .ItemTaxScheduleKey
                            salesInvoiceLine.ItemTaxScheduleKey = taxScheduleKey
                        End If

                        salesInvoiceLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(.RequestedShipDate.ToShortDateString))
                        salesInvoiceLine.ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(.ActualShipDate.ToShortDateString))
                        salesInvoiceLine.IsDropShip = .DropShip
                    End With
                    salesInvoiceLines(i) = salesInvoiceLine
                Next
                salesInvoice.Lines = salesInvoiceLines
                salesInvoiceCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateSalesInvoice", context)
                objGPConfiguration.GPWS10.CreateSalesInvoice(salesInvoice, context, salesInvoiceCreatePolicy)

                salesInvoiceLines = Nothing
                salesInvoice = Nothing
                Return IIf(String.IsNullOrEmpty(GPSalesInvoiceNo.Trim), "Success", GPSalesInvoiceNo)
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' Create Great Plains 2010 Sales Invoice
        ''' </summary>
        ''' <param name="objSalesInvoice"></param>
        ''' <returns>Sales Invoice Number</returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010SalesInvoice(ByVal objSalesInvoice As SOP.SalesInvoice, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim SalesDocumentKey As GP2010Service.SalesDocumentKey
                Dim customerKey As GP2010Service.CustomerKey
                Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
                Dim ShipMethodKey As GP2010Service.ShippingMethodKey
                Dim CustomerAddressKey As GP2010Service.CustomerAddressKey
                Dim CommentKey As GP2010Service.CommentKey
                Dim batchKey As GP2010Service.BatchKey
                Dim quoteItem As GP2010Service.ItemKey
                Dim itemPrice As GP2010Service.MoneyAmount
                Dim freightAmount As GP2010Service.MoneyAmount
                Dim WarehouseKey As GP2010Service.WarehouseKey
                Dim itemQuantity As GP2010Service.Quantity
                Dim SalespersonKey As GP2010Service.SalespersonKey
                Dim BillToAddressKey As GP2010Service.CustomerAddressKey
                Dim ShipToAddressKey As GP2010Service.CustomerAddressKey
                Dim ShipToAddress As GP2010Service.BusinessAddress
                Dim PhoneNumber As GP2010Service.PhoneNumber
                Dim salesTerritoryKey As GP2010Service.SalesTerritoryKey
                Dim salesInvoice As GP2010Service.SalesInvoice
                Dim salesInvoiceLines As GP2010Service.SalesInvoiceLine()
                Dim salesInvoiceLine As GP2010Service.SalesInvoiceLine
                Dim salesInvoiceCreatePolicy As GP2010Service.Policy
                Dim GPSalesInvoiceNo As String = String.Empty
                Dim salesUserDefined As GP2010Service.SalesUserDefined
                Dim moneyAmount As GP2010Service.MoneyAmount
                Dim paymentCardTypeKey As GP2010Service.PaymentCardTypeKey
                Dim salesPayments As GP2010Service.SalesPayment()
                Dim salesPayment As GP2010Service.SalesPayment
                Dim bankAccountKey As GP2010Service.BankAccountKey
                Dim salesDocumentTypeKey As GP2010Service.SalesDocumentTypeKey
                Dim taxScheduleKey As GP2010Service.TaxScheduleKey
                Dim tdpTradeDiscountPercent As GP2010Service.MoneyPercentChoice


                context = objGPConfiguration.GP2010GetContext
                companyKey = objGPConfiguration.GP2010GetCompanyKey
                salesInvoice = New GP2010Service.SalesInvoice
                batchKey = New GP2010Service.BatchKey
                batchKey.Id = objSalesInvoice.SalesDocumentHeader.SOPBatchId
                salesInvoice.BatchKey = batchKey

                If objSalesInvoice.SalesDocumentHeader.SalesDocumentTypeKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesDocumentTypeKey) Then
                    salesDocumentTypeKey = New GP2010Service.SalesDocumentTypeKey
                    salesDocumentTypeKey.Id = objSalesInvoice.SalesDocumentHeader.SalesDocumentTypeKey
                    salesInvoice.DocumentTypeKey = salesDocumentTypeKey
                End If

                If objSalesInvoice.SalesDocumentHeader.SOPDocumentKey <> Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SOPDocumentKey) Then
                    GPSalesInvoiceNo = objSalesInvoice.SalesDocumentHeader.SOPDocumentKey
                    SalesDocumentKey = New GP2010Service.SalesDocumentKey
                    SalesDocumentKey.Id = GPSalesInvoiceNo
                    salesInvoice.Key = SalesDocumentKey
                End If

                ' Create a customer key
                customerKey = New GP2010Service.CustomerKey()
                customerKey.Id = objSalesInvoice.SalesDocumentHeader.CustomerId
                salesInvoice.CustomerKey = customerKey

                If objSalesInvoice.SalesDocumentHeader.CustomerPO IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.CustomerPO.ToString.Trim <> String.Empty Then
                    salesInvoice.CustomerPONumber = objSalesInvoice.SalesDocumentHeader.CustomerPO
                End If
                If objSalesInvoice.SalesDocumentHeader.InvoiceDate <> Nothing Then
                    salesInvoice.Date = Date.Parse(objSalesInvoice.SalesDocumentHeader.InvoiceDate.ToShortDateString)
                    salesInvoice.CreatedDate = Date.Parse(objSalesInvoice.SalesDocumentHeader.InvoiceDate.ToShortDateString)
                    salesInvoice.QuoteDate = Date.Parse(objSalesInvoice.SalesDocumentHeader.InvoiceDate.ToShortDateString)
                    salesInvoice.InvoiceDate = Date.Parse(objSalesInvoice.SalesDocumentHeader.InvoiceDate.ToShortDateString)
                    salesInvoice.FulfillDate = Date.Parse(objSalesInvoice.SalesDocumentHeader.InvoiceDate.ToShortDateString)
                Else
                    salesInvoice.Date = Date.Parse(Date.Today.ToShortDateString)
                    salesInvoice.CreatedDate = Date.Parse(Date.Today.ToShortDateString)
                    salesInvoice.QuoteDate = Date.Parse(Date.Today.ToShortDateString)
                End If



                salesInvoice.RequestedShipDate = IIf(objSalesInvoice.SalesDocumentHeader.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesInvoice.SalesDocumentHeader.RequestedShipDate.ToShortDateString))
                salesInvoice.ActualShipDate = IIf(objSalesInvoice.SalesDocumentHeader.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesInvoice.SalesDocumentHeader.ActualShipDate.ToShortDateString))

                Dim lstNumbers As New List(Of GP2010Service.SalesTrackingNumber)
                Dim trkTrackingNumber As GP2010Service.SalesTrackingNumber
                Dim blnFoundTracking As Boolean
                If objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Count > 0 Then
                    'stsNumbers = salesInvoice.TrackingNumbers

                    For intLoop As Integer = 0 To objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Count - 1
                        blnFoundTracking = False
                        For Each trkTrackingNumber In lstNumbers
                            If trkTrackingNumber.Key.Id = objSalesInvoice.SalesDocumentHeader.TrackingNumbers(intLoop) Then
                                blnFoundTracking = True
                            End If
                        Next
                        If blnFoundTracking = False Then
                            trkTrackingNumber = New GP2010Service.SalesTrackingNumber
                            trkTrackingNumber.Key = New GP2010Service.SalesTrackingNumberKey
                            trkTrackingNumber.Key.SalesDocumentKey = salesInvoice.Key
                            trkTrackingNumber.Key.Id = objSalesInvoice.SalesDocumentHeader.TrackingNumbers(intLoop)
                            lstNumbers.Add(trkTrackingNumber)
                        End If
                    Next
                    salesInvoice.TrackingNumbers = lstNumbers.ToArray
                End If


                If objSalesInvoice.SalesDocumentHeader.TradeDiscountPercent > 0 Then
                    tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP2010Service.Percent

                    CType(tdpTradeDiscountPercent.Item, GP2010Service.Percent).Value = objSalesInvoice.SalesDocumentHeader.TradeDiscountPercent
                    salesInvoice.TradeDiscount = tdpTradeDiscountPercent
                ElseIf objSalesInvoice.SalesDocumentHeader.TradeDiscountFlatAmount > 0 Then
                    tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                    tdpTradeDiscountPercent.Item = New GP2010Service.MoneyAmount
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Value = objSalesInvoice.SalesDocumentHeader.TradeDiscountFlatAmount
                    CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Currency = objGPConfiguration.CurrencyCode
                    salesInvoice.TradeDiscount = tdpTradeDiscountPercent
                End If

                If objSalesInvoice.SalesDocumentHeader.PaymentTermsKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.PaymentTermsKey.ToString.Trim <> String.Empty Then
                    PaymentTermsKey = New GP2010Service.PaymentTermsKey
                    PaymentTermsKey.Id = objSalesInvoice.SalesDocumentHeader.PaymentTermsKey
                    salesInvoice.PaymentTermsKey = PaymentTermsKey
                End If

                If objSalesInvoice.SalesDocumentHeader.PriceLevel > String.Empty Then
                    salesInvoice.PriceLevelKey = New GP2010Service.PriceLevelKey
                    salesInvoice.PriceLevelKey.Id = objSalesInvoice.SalesDocumentHeader.PriceLevel
                End If
                If objSalesInvoice.SalesDocumentHeader.CommentKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.CommentKey.ToString.Trim <> String.Empty Then
                    CommentKey = New GP2010Service.CommentKey
                    CommentKey.Id = objSalesInvoice.SalesDocumentHeader.CommentKey
                    salesInvoice.CommentKey = CommentKey
                End If

                If objSalesInvoice.SalesDocumentHeader.Comment IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.Comment.ToString.Trim <> String.Empty Then
                    salesInvoice.Comment = objSalesInvoice.SalesDocumentHeader.Comment
                End If

                If objSalesInvoice.SalesDocumentHeader.ShipmethodKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ShipmethodKey.ToString.Trim <> String.Empty Then
                    ShipMethodKey = New GP2010Service.ShippingMethodKey
                    ShipMethodKey.Id = objSalesInvoice.SalesDocumentHeader.ShipmethodKey
                    salesInvoice.ShippingMethodKey = ShipMethodKey
                End If

                If objSalesInvoice.SalesDocumentHeader.BillToAddressKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.BillToAddressKey.ToString.ToString.Trim <> String.Empty Then
                    BillToAddressKey = New GP2010Service.CustomerAddressKey
                    BillToAddressKey.Id = objSalesInvoice.SalesDocumentHeader.BillToAddressKey
                    salesInvoice.BillToAddressKey = BillToAddressKey
                End If
                If objSalesInvoice.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ShipToAddressKey.ToString.Trim <> String.Empty Then
                    ShipToAddressKey = New GP2010Service.CustomerAddressKey
                    ShipToAddressKey.Id = objSalesInvoice.SalesDocumentHeader.ShipToAddressKey
                    salesInvoice.ShipToAddressKey = ShipToAddressKey
                End If


                If objSalesInvoice.SalesDocumentHeader.SalespersonKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.SalespersonKey.ToString.Trim <> String.Empty Then
                    SalespersonKey = New GP2010Service.SalespersonKey
                    SalespersonKey.Id = objSalesInvoice.SalesDocumentHeader.SalespersonKey
                    salesInvoice.SalespersonKey = SalespersonKey
                End If
                salesInvoice.TaxExemptNumber1 = objSalesInvoice.SalesDocumentHeader.TaxExempt1
                salesInvoice.TaxExemptNumber2 = objSalesInvoice.SalesDocumentHeader.TaxExempt2
                salesInvoice.TaxRegistrationNumber = objSalesInvoice.SalesDocumentHeader.TaxRegistrationNumber
                salesInvoice.UserDefined = New GP2010Service.SalesUserDefined

                If objSalesInvoice.SalesDocumentHeader.FreightAccount IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.FreightAccount.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text01 = objSalesInvoice.SalesDocumentHeader.FreightAccount.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.WarrantyDays <> Nothing AndAlso objSalesInvoice.SalesDocumentHeader.WarrantyDays.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text02 = objSalesInvoice.SalesDocumentHeader.WarrantyDays.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.FOB IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.FOB.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text03 = objSalesInvoice.SalesDocumentHeader.FOB.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.TestProtocol IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.TestProtocol.ToString.Trim <> String.Empty Then
                    salesInvoice.UserDefined.Text05 = objSalesInvoice.SalesDocumentHeader.TestProtocol.ToString.Trim
                End If

                If objSalesInvoice.SalesDocumentHeader.SalesTerritoryKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim <> String.Empty Then
                    salesTerritoryKey = New GP2010Service.SalesTerritoryKey
                    salesTerritoryKey.Id = objSalesInvoice.SalesDocumentHeader.SalesTerritoryKey.ToString.Trim
                    salesInvoice.SalesTerritoryKey = salesTerritoryKey
                End If

                If objSalesInvoice.SalesDocumentHeader.CustomerNote IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ToString.Trim <> String.Empty Then
                    salesInvoice.Note = objSalesInvoice.SalesDocumentHeader.CustomerNote
                End If

                'Create Shipping Address
                ShipToAddress = New GP2010Service.BusinessAddress
                With ShipToAddress
                    .Name = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Name
                    .Line1 = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Address1
                    .Line2 = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Address2
                    .Line3 = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Address3
                    .City = objSalesInvoice.SalesDocumentHeader.ShipToAddress.City
                    .State = objSalesInvoice.SalesDocumentHeader.ShipToAddress.State
                    .CountryRegion = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Country
                    .PostalCode = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Zip
                    .ContactPerson = objSalesInvoice.SalesDocumentHeader.ShipToAddress.ContactPerson

                    PhoneNumber = New GP2010Service.PhoneNumber
                    PhoneNumber.Value = objSalesInvoice.SalesDocumentHeader.ShipToAddress.PhoneNumber
                    .Phone1 = PhoneNumber
                    .CountryRegion = objSalesInvoice.SalesDocumentHeader.ShipToAddress.Country
                    If objSalesInvoice.SalesDocumentHeader.ShipToAddress.CountryCode > String.Empty Then
                        .CountryRegionCodeKey = New GP2010Service.CountryRegionCodeKey
                        .CountryRegionCodeKey.Id = objSalesInvoice.SalesDocumentHeader.ShipToAddress.CountryCode
                    End If
                End With

                salesInvoice.ShipToAddress = ShipToAddress

                If Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.TaxScheduleKey) Then
                    taxScheduleKey = New GP2010Service.TaxScheduleKey
                    taxScheduleKey.Id = objSalesInvoice.SalesDocumentHeader.TaxScheduleKey
                    salesInvoice.TaxScheduleKey = taxScheduleKey
                    salesInvoice.TaxScheduleKey.Id = objSalesInvoice.SalesDocumentHeader.TaxScheduleKey
                End If

                If objSalesInvoice.SalesDocumentHeader.ShipToAddressKey IsNot Nothing AndAlso objSalesInvoice.SalesDocumentHeader.ShipToAddressKey.ToString.Trim <> String.Empty Then
                    CustomerAddressKey = New GP2010Service.CustomerAddressKey
                    CustomerAddressKey.CustomerKey = customerKey
                    CustomerAddressKey.Id = objSalesInvoice.SalesDocumentHeader.ShipToAddressKey
                    salesInvoice.ShipToAddressKey = CustomerAddressKey
                End If

                freightAmount = New GP2010Service.MoneyAmount
                freightAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                freightAmount.Value = objSalesInvoice.SalesDocumentHeader.FreightAmount
                salesInvoice.FreightAmount = freightAmount

                If objSalesInvoice.SalesDocumentHeader.PaymentAmount > 0 Then
                    moneyAmount = New GP2010Service.MoneyAmount
                    moneyAmount.Value = objSalesInvoice.SalesDocumentHeader.PaymentAmount
                    moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                    salesInvoice.PaymentAmount = moneyAmount
                End If
                If objSalesInvoice.SalesDocumentHeader.SalesTaxAmount > 0 Then
                    salesInvoice.TaxAmount = New GP2010Service.MoneyAmount
                    With salesInvoice.TaxAmount
                        .Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        .Value = objSalesInvoice.SalesDocumentHeader.SalesTaxAmount
                    End With
                End If

                'Dim trackingnumber As GP2010Service.SalesTrackingNumber
                'For Each strTrackingNumber As String In objSalesInvoice.SalesDocumentHeader.TrackingNumbers
                '    trackingnumber = New GP2010Service.SalesTrackingNumber
                '    trackingnumber.Key = New GP2010Service.SalesTrackingNumberKey
                '    trackingnumber.Key.Id = strTrackingNumber
                'Next


                'For Each trackingnumber As SalesTrackingNumber In salesInvoice.TrackingNumbers
                '    If trackingnumber.Key IsNot Nothing Then
                '        objSalesInvoice.SalesDocumentHeader.TrackingNumbers.Add(trackingnumber.Key.Id)
                '    End If
                'Next


                If objSalesInvoice.SalesDocumentHeader.SalesPayments.Count > 0 Then
                    ReDim salesPayments(objSalesInvoice.SalesDocumentHeader.SalesPayments.Count - 1)
                    For i As Integer = 0 To objSalesInvoice.SalesDocumentHeader.SalesPayments.Count - 1
                        salesPayment = New GP2010Service.SalesPayment


                        Select Case objSalesInvoice.SalesDocumentHeader.SalesPayments(i).SalesPaymentType
                            Case SOP.SalesPayment.PaymentType.Cash_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.CashDeposit
                            Case SOP.SalesPayment.PaymentType.Cash_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.CashPayment
                            Case SOP.SalesPayment.PaymentType.Check_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.CheckPayment
                            Case SOP.SalesPayment.PaymentType.Check_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.CheckDeposit
                            Case SOP.SalesPayment.PaymentType.Payment_Card_Deposit
                                salesPayment.Type = GP2010Service.SalesPaymentType.PaymentCardDeposit
                            Case SOP.SalesPayment.PaymentType.Payment_Card_Payment
                                salesPayment.Type = GP2010Service.SalesPaymentType.PaymentCardPayment
                        End Select


                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey > String.Empty Then
                            paymentCardTypeKey = New GP2010Service.PaymentCardTypeKey
                            paymentCardTypeKey.Id = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardTypeKey
                            salesPayment.PaymentCardTypeKey = paymentCardTypeKey
                        End If




                        moneyAmount = New GP2010Service.MoneyAmount
                        moneyAmount.Value = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentAmount
                        moneyAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        salesPayment.PaymentAmount = moneyAmount


                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuthorizationCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuthorizationCode) Then
                            salesPayment.AuthorizationCode = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuthorizationCode
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).BankAccountKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).BankAccountKey) Then
                            bankAccountKey = New GP2010Service.BankAccountKey
                            bankAccountKey.Id = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).BankAccountKey
                            salesPayment.BankAccountKey = bankAccountKey
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber) Then
                            salesPayment.PaymentCardNumber = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentCardNumber
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).CheckNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).CheckNumber) Then
                            salesPayment.CheckNumber = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).CheckNumber
                        End If

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).Number IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).Number) Then
                            salesPayment.Number = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).Number
                        End If

                        salesPayment.ExpirationDate = IIf(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).ExpirationDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).ExpirationDate.ToShortDateString))

                        If objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuditTrailCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuditTrailCode) Then
                            salesPayment.AuditTrailCode = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).AuditTrailCode
                        End If

                        salesPayment.Date = IIf(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentDate.Year < 1901, Date.Parse(Now.ToShortDateString), Date.Parse(objSalesInvoice.SalesDocumentHeader.SalesPayments(i).PaymentDate.ToShortDateString))

                        salesPayment.DeleteOnUpdate = objSalesInvoice.SalesDocumentHeader.SalesPayments(i).DeleteOnUpdate

                        salesPayments(i) = salesPayment
                    Next

                    salesInvoice.Payments = salesPayments
                End If

                'create up SalesUserDefined
                If objSalesInvoice.SalesDocumentHeader.SalesUserDefined IsNot Nothing Then
                    salesUserDefined = New GP2010Service.SalesUserDefined

                    With objSalesInvoice.SalesDocumentHeader.SalesUserDefined
                        If .Date01 <> Nothing Then
                            salesUserDefined.Date01 = Date.Parse(.Date01.ToShortDateString)
                        End If
                        If .Date02 <> Nothing Then
                            salesUserDefined.Date02 = Date.Parse(.Date02.ToShortDateString)
                        End If
                        If .List01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List01) Then
                            salesUserDefined.List01 = .List01
                        End If
                        If .List02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List02) Then
                            salesUserDefined.List02 = .List02
                        End If
                        If .List03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.List03) Then
                            salesUserDefined.List03 = .List03
                        End If
                        If .Text01 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text01) Then
                            salesUserDefined.Text01 = .Text01
                        End If
                        If .Text02 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text02) Then
                            salesUserDefined.Text02 = .Text02
                        End If
                        If .Text03 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text03) Then
                            salesUserDefined.Text03 = .Text03
                        End If
                        If .Text04 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text04) Then
                            salesUserDefined.Text04 = .Text04
                        End If
                        If .Text05 IsNot Nothing AndAlso Not String.IsNullOrEmpty(.Text05) Then
                            salesUserDefined.Text05 = .Text05
                        End If

                    End With

                    salesInvoice.UserDefined = salesUserDefined
                End If

                'Create  sales invoice lines
                ReDim salesInvoiceLines(objSalesInvoice.SalesDocumentDetails.Count - 1)

                For i As Integer = 0 To objSalesInvoice.SalesDocumentDetails.Count - 1
                    salesInvoiceLine = New GP2010Service.SalesInvoiceLine

                    With objSalesInvoice.SalesDocumentDetails.Item(i)
                        quoteItem = New GP2010Service.ItemKey()
                        quoteItem.Id = .ItemNumber
                        salesInvoiceLine.ItemKey = quoteItem

                        itemQuantity = New GP2010Service.Quantity()
                        itemQuantity.Value = .Quantity
                        salesInvoiceLine.Quantity = itemQuantity

                        itemPrice = New GP2010Service.MoneyAmount
                        itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        itemPrice.Value = .SellPrice
                        salesInvoiceLine.UnitPrice = itemPrice
                        If .DiscountAmount > 0 Then
                            tdpTradeDiscountPercent = New GP2010Service.MoneyPercentChoice
                            tdpTradeDiscountPercent.Item = New GP2010Service.MoneyAmount
                            CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Value = .DiscountAmount
                            CType(tdpTradeDiscountPercent.Item, GP2010Service.MoneyAmount).Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                            salesInvoiceLine.Discount = tdpTradeDiscountPercent
                        End If
                        'itemPrice = New MoneyAmount
                        'itemPrice.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
                        'itemPrice.Value = .ExtendedPrice
                        'salesInvoiceLine.ExtendedCost = itemPrice

                        If .UOM IsNot Nothing AndAlso .UOM.ToString.Trim <> String.Empty Then
                            salesInvoiceLine.UofM = .UOM
                        End If
                        If .ItemDescription > String.Empty Then
                            salesInvoiceLine.ItemDescription = .ItemDescription
                        End If
                        If .SiteID IsNot Nothing AndAlso .SiteID.ToString.Trim <> String.Empty Then
                            WarehouseKey = New GP2010Service.WarehouseKey
                            WarehouseKey.Id = .SiteID
                            salesInvoiceLine.WarehouseKey = WarehouseKey
                        End If
                        If .CommentKey IsNot Nothing AndAlso .CommentKey.ToString.Trim <> String.Empty Then
                            CommentKey = New GP2010Service.CommentKey
                            CommentKey.Id = .CommentKey
                            salesInvoiceLine.CommentKey = CommentKey
                        End If

                        If .CommentText IsNot Nothing AndAlso .CommentText.ToString.Trim <> String.Empty Then
                            salesInvoiceLine.Comment = .CommentText
                        End If

                        If .SalesTerritoryKey IsNot Nothing AndAlso .SalesTerritoryKey.ToString.Trim <> String.Empty Then
                            salesTerritoryKey = New GP2010Service.SalesTerritoryKey
                            salesTerritoryKey.Id = .SalesTerritoryKey
                            salesInvoiceLine.SalesTerritoryKey = salesTerritoryKey
                        End If

                        If .ShippingMethodKey IsNot Nothing AndAlso .ShippingMethodKey.ToString.Trim <> String.Empty Then
                            ShipMethodKey = New GP2010Service.ShippingMethodKey
                            ShipMethodKey.Id = .ShippingMethodKey
                            salesInvoiceLine.ShippingMethodKey = ShipMethodKey
                        End If

                        If Not String.IsNullOrEmpty(.ShipToAddressKey) Then
                            ShipToAddressKey = New GP2010Service.CustomerAddressKey
                            ShipToAddressKey.Id = .ShipToAddressKey
                            ShipToAddressKey.CustomerKey = salesInvoice.CustomerKey
                            salesInvoiceLine.ShipToAddressKey = ShipToAddressKey
                        End If

                        If Not String.IsNullOrEmpty(.TaxScheduleKey) Then
                            taxScheduleKey = New GP2010Service.TaxScheduleKey
                            taxScheduleKey.Id = .TaxScheduleKey
                            salesInvoiceLine.TaxScheduleKey = taxScheduleKey
                        End If

                        If Not String.IsNullOrEmpty(.ItemTaxScheduleKey) Then
                            taxScheduleKey = New GP2010Service.TaxScheduleKey
                            taxScheduleKey.Id = .ItemTaxScheduleKey
                            salesInvoiceLine.ItemTaxScheduleKey = taxScheduleKey
                        End If
                        If .NonTaxable Then
                            salesInvoiceLine.TaxBasis = New GP2010Service.SalesTaxBasis
                            salesInvoiceLine.TaxBasis = DynamicsWCFService.SalesTaxBasis.Nontaxable
                        End If
                        'If .TaxAmount.HasValue Then
                        '    ReDim salesInvoiceLineTaxes(0)
                        '    salesInvoiceLineTax = New GP2010Service.SalesLineTax

                        '    salesInvoiceLineTax.TaxAmount = New GP2010Service.MoneyAmount
                        '    salesInvoiceLineTax.TaxAmount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim()
                        '    salesInvoiceLineTax.TaxAmount.Value = .TaxAmount.Value
                        '    salesInvoiceLineTaxes(0) = salesInvoiceLineTax
                        '    salesInvoiceLine.Taxes = salesInvoiceLineTaxes
                        'End If
                        salesInvoiceLine.RequestedShipDate = IIf(.RequestedShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(.RequestedShipDate.ToShortDateString))
                        salesInvoiceLine.ActualShipDate = IIf(.ActualShipDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(.ActualShipDate.ToShortDateString))
                        salesInvoiceLine.IsDropShip = .DropShip
                    End With
                    salesInvoiceLines(i) = salesInvoiceLine
                Next
                salesInvoice.Lines = salesInvoiceLines
                salesInvoiceCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateSalesInvoice", context)
                objGPConfiguration.GPWS2010.CreateSalesInvoice(salesInvoice, context, salesInvoiceCreatePolicy)


                salesInvoiceLines = Nothing
                salesInvoice = Nothing
                Return GPSalesInvoiceNo
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

    End Class

End Namespace
