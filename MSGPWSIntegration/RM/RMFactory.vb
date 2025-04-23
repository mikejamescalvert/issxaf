Imports GP2010Service = MSGPWSIntegration.DynamicsWCFService

Namespace RM
    Public Class RMFactory


        ''' <summary>
        ''' Creates a cash receipt for an invoice in GP
        ''' </summary>
        ''' <param name="SendingCashReceipt"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPCashReceiptForInvoice(ByVal SendingCashReceipt As RMCashReceipt, ByVal objGPConfiguration As GPSystemConfiguration)
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10CashReceiptForInvoice(SendingCashReceipt, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010CashReceiptForInvoice(SendingCashReceipt, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Creates a cash receipt for an invoice in GP 10
        ''' </summary>
        ''' <param name="SendingCashReceipt"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10CashReceiptForInvoice(ByVal SendingCashReceipt As RMCashReceipt, ByVal objGPConfiguration As GPSystemConfiguration)
            Dim companyKey As GP10Service.CompanyKey
            Dim context As GP10Service.Context
            Dim csrReceipt As GP10Service.CashReceipt
            Dim customerPolicy As GP10Service.Policy
            Dim crcCriteria As GP10Service.CashReceiptCriteria
            Dim crsReceiptSummary() As GP10Service.CashReceiptSummary
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP10Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If
            ' Create a context with which to call the web service 
            context = New GP10Service.Context()

            companyKey = New GP10Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId

            ' Set up the context 
            context.OrganizationKey = DirectCast(companyKey, GP10Service.OrganizationKey)
            context.CultureName = "en-US"

            csrReceipt = New GP10Service.CashReceipt
            csrReceipt.Amount = New GP10Service.MoneyAmount()
            csrReceipt.Amount.Value = SendingCashReceipt.Amount
            csrReceipt.Amount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
            csrReceipt.Type = GP10Service.CashReceiptType.PaymentCard
            csrReceipt.CheckCardNumber = SendingCashReceipt.CreditCardNumber
            'TODO: Unknown  
            csrReceipt.CurrencyKey = New GP10Service.CurrencyKey
            csrReceipt.CurrencyKey.ISOCode = objGPConfiguration.CurrencyCode.ToString.Trim
            csrReceipt.CustomerKey = New GP10Service.CustomerKey
            csrReceipt.CustomerKey.Id = SendingCashReceipt.CustomerNumber
            csrReceipt.PaymentCardTypeKey = New GP10Service.PaymentCardTypeKey
            csrReceipt.PaymentCardTypeKey.Id = SendingCashReceipt.PaymentTypeKey
            csrReceipt.Key = New GP10Service.ReceivablesDocumentKey
            csrReceipt.Key.Id = "CRP000" + SendingCashReceipt.InvoiceNumber
            csrReceipt.Date = Today
            csrReceipt.Description = SendingCashReceipt.Description

            csrReceipt.Type = GP10Service.CashReceiptType.PaymentCard
            customerPolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateCashReceipt", context)
            objGPConfiguration.GPWS10.CreateCashReceipt(csrReceipt, context, customerPolicy)

            'crcCriteria = New CashReceiptCriteria
            'crcCriteria.CustomerId = New ListRestrictionOfString
            'crcCriteria.CustomerId.EqualValue = SendingCashReceipt.CustomerNumber
            'crcCriteria.TransactionState = New ListRestrictionOfNullableOfReceivablesTransactionState
            'Dim arrayListInfo As New List(Of System.Nullable(Of ReceivablesTransactionState))
            'arrayListInfo.Add(ReceivablesTransactionState.Work)
            'arrayListInfo.Add(ReceivablesTransactionState.Open)
            'crcCriteria.TransactionState.Items = arrayListInfo.ToArray()
            'crsReceiptSummary = Helper.wsDynamicsGP.GetCashReceiptList(crcCriteria, context)
            'For Each crsSummary As CashReceiptSummary In crsReceiptSummary
            '    If crsSummary.Amount.Value = SendingCashReceipt.Amount Then
            '        Return crsSummary.Key.Id
            '    End If
            'Next
            Return csrReceipt.Key.Id
        End Function
        ''' <summary>
        ''' Creates a cash receipt for an invoice in GP 2010
        ''' </summary>
        ''' <param name="SendingCashReceipt"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010CashReceiptForInvoice(ByVal SendingCashReceipt As RMCashReceipt, ByVal objGPConfiguration As GPSystemConfiguration)
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim csrReceipt As GP2010Service.CashReceipt
            Dim customerPolicy As GP2010Service.Policy
            Dim crcCriteria As GP2010Service.CashReceiptCriteria
            Dim crsReceiptSummary() As GP2010Service.CashReceiptSummary
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP2010Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If
            ' Create a context with which to call the web service 
            context = New GP2010Service.Context()

            companyKey = New GP2010Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId

            ' Set up the context 
            context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
            context.CultureName = "en-US"

            csrReceipt = New GP2010Service.CashReceipt
            csrReceipt.Amount = New GP2010Service.MoneyAmount()
            csrReceipt.Amount.Value = SendingCashReceipt.Amount
            csrReceipt.Amount.Currency = objGPConfiguration.CurrencyCode.ToString.Trim
            csrReceipt.Type = GP2010Service.CashReceiptType.PaymentCard
            csrReceipt.CheckCardNumber = SendingCashReceipt.CreditCardNumber
            'TODO: Unknown  
            csrReceipt.CurrencyKey = New GP2010Service.CurrencyKey
            csrReceipt.CurrencyKey.ISOCode = objGPConfiguration.CurrencyCode.ToString.Trim
            csrReceipt.CustomerKey = New GP2010Service.CustomerKey
            csrReceipt.CustomerKey.Id = SendingCashReceipt.CustomerNumber
            csrReceipt.PaymentCardTypeKey = New GP2010Service.PaymentCardTypeKey
            csrReceipt.PaymentCardTypeKey.CompanyKey = companyKey
            csrReceipt.PaymentCardTypeKey.Id = SendingCashReceipt.PaymentTypeKey
            csrReceipt.Key = New GP2010Service.ReceivablesDocumentKey
            csrReceipt.Key.CompanyKey = companyKey
            csrReceipt.Key.Id = "CRP000" + SendingCashReceipt.InvoiceNumber
            csrReceipt.Date = Today
            csrReceipt.Description = SendingCashReceipt.Description

            csrReceipt.Type = GP2010Service.CashReceiptType.PaymentCard
            customerPolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateCashReceipt", context)
            objGPConfiguration.GPWS2010.CreateCashReceipt(csrReceipt, context, customerPolicy)

            'crcCriteria = New CashReceiptCriteria
            'crcCriteria.CustomerId = New ListRestrictionOfString
            'crcCriteria.CustomerId.EqualValue = SendingCashReceipt.CustomerNumber
            'crcCriteria.TransactionState = New ListRestrictionOfNullableOfReceivablesTransactionState
            'Dim arrayListInfo As New List(Of System.Nullable(Of ReceivablesTransactionState))
            'arrayListInfo.Add(ReceivablesTransactionState.Work)
            'arrayListInfo.Add(ReceivablesTransactionState.Open)
            'crcCriteria.TransactionState.Items = arrayListInfo.ToArray()
            'crsReceiptSummary = Helper.wsDynamicsGP.GetCashReceiptList(crcCriteria, context)
            'For Each crsSummary As CashReceiptSummary In crsReceiptSummary
            '    If crsSummary.Amount.Value = SendingCashReceipt.Amount Then
            '        Return crsSummary.Key.Id
            '    End If
            'Next
            Return csrReceipt.Key.Id
        End Function

        ''' <summary>
        ''' Create a new GP customer
        ''' </summary>
        ''' <param name="objCustomer"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateUpdateCustomer(ByVal objCustomer As RMCustomer, ByVal objGPConfiguration As GPSystemConfiguration, Optional ByVal UpdateCustomer As UpdateObjectMode = UpdateObjectMode.CreateNewOnlyThrowErrorIfExists) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateUpdateGP10Customer(objCustomer, objGPConfiguration, UpdateCustomer)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateUpdateGP2010Customer(objCustomer, objGPConfiguration, UpdateCustomer)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Create a new GP 10 customer
        ''' </summary>
        ''' <param name="objCustomer"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateUpdateGP10Customer(ByVal objCustomer As RMCustomer, ByVal objGPConfiguration As GPSystemConfiguration, Optional ByVal UpdateCustomer As Boolean = False) As String

            Dim companyKey As GP10Service.CompanyKey
            Dim context As GP10Service.Context
            Dim customer As GP10Service.Customer
            Dim customerKey As GP10Service.CustomerKey
            Dim customerPolicy As GP10Service.Policy
            Dim CustomerClassKey As GP10Service.CustomerClassKey
            Dim PaymentTermsKey As GP10Service.PaymentTermsKey
            Dim PriceLevelKey As GP10Service.PriceLevelKey
            Dim TradeDiscountPercent As GP10Service.Percent
            Dim customerAddress As GP10Service.CustomerAddress
            Dim customerAddresses As GP10Service.CustomerAddress()
            Dim customerAddressKey As GP10Service.CustomerAddressKey
            Dim countryRegionCodeKey As GP10Service.CountryRegionCodeKey
            Dim phoneNumber As GP10Service.PhoneNumber
            Dim salespersonKey As GP10Service.SalespersonKey
            Dim salesTerritoryKey As GP10Service.SalesTerritoryKey
            Dim shippingMethodKey As GP10Service.ShippingMethodKey
            Dim taxScheduleKey As GP10Service.TaxScheduleKey
            Dim warehouseKey As GP10Service.WarehouseKey
            Dim InternetFields As MSGPWSIntegration.GP10Service.InternetAddresses

            ' Create a context with which to call the web service 
            context = objGPConfiguration.GP10GetContext

            companyKey = objGPConfiguration.GP10GetCompanyKey

            ' Create a new customer object 
            customer = New GP10Service.Customer()

            ' Create a customer key 
            customerKey = New GP10Service.CustomerKey()
            customerKey.Id = objCustomer.CustomerKey
            customer.Key = customerKey

            ' Set properties for the new customer 
            If objCustomer.CustomerName IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerName) Then
                customer.Name = objCustomer.CustomerName
            End If

            If objCustomer.ClassKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.ClassKey) Then
                CustomerClassKey = New GP10Service.CustomerClassKey
                CustomerClassKey.Id = objCustomer.ClassKey
                customer.ClassKey = CustomerClassKey
            End If

            If objCustomer.Comment1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Comment1) Then
                customer.Comment1 = objCustomer.Comment1
            End If

            If objCustomer.Comment2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Comment2) Then
                customer.Comment2 = objCustomer.Comment2
            End If

            customer.CreatedDate = IIf(objCustomer.CreatedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomer.CreatedDate.ToShortDateString))
            customer.IsOnHold = objCustomer.IsOnHold
            customer.IsActive = objCustomer.IsActive

            If objCustomer.CustomerName IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerName) Then
                customer.Name = objCustomer.CustomerName
            End If

            If objCustomer.Notes IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Notes) Then
                customer.Notes = objCustomer.Notes
            End If

            If objCustomer.Shortname IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Shortname) Then
                customer.Shortname = objCustomer.Shortname
            End If

            If objCustomer.Priority > 0 Then
                customer.Priority = objCustomer.Priority
            End If


            If objCustomer.PaymentTermsKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.PaymentTermsKey) Then
                PaymentTermsKey = New GP10Service.PaymentTermsKey
                PaymentTermsKey.Id = objCustomer.PaymentTermsKey
                customer.PaymentTermsKey = PaymentTermsKey
            End If
            ReDim customer.TaxExemptNumbers(0)
            customer.TaxExemptNumbers(0) = objCustomer.TaxExemptNumber1


            customer.ShipCompleteOnly = objCustomer.ShipCompleteOnly

            If objCustomer.UserDefined1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.UserDefined1) Then
                customer.UserDefined1 = objCustomer.UserDefined1
            End If

            If objCustomer.UserDefined2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.UserDefined2) Then
                customer.UserDefined2 = objCustomer.UserDefined2
            End If

            If objCustomer.TaxRegistrationNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.TaxRegistrationNumber) Then
                customer.TaxRegistrationNumber = objCustomer.TaxRegistrationNumber
            End If

            If objCustomer.StatementName IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.StatementName) Then
                customer.StatementName = objCustomer.StatementName
            End If

            customer.DiscountGracePeriod = objCustomer.DiscountGracePeriod
            customer.DueDateGracePeriod = objCustomer.DueDateGracePeriod

            If objCustomer.PriceLevelKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.PriceLevelKey) Then
                PriceLevelKey = New GP10Service.PriceLevelKey
                PriceLevelKey.Id = objCustomer.PriceLevelKey
                customer.PriceLevelKey = PriceLevelKey
            End If

            TradeDiscountPercent = New GP10Service.Percent
            TradeDiscountPercent.Value = objCustomer.TradeDiscountPercent
            customer.TradeDiscountPercent = TradeDiscountPercent

            If objCustomer.BillToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.BillToAddressKey) Then
                customerAddressKey = New GP10Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.BillToAddressKey
                customer.BillToAddressKey = customerAddressKey
            End If
            If objCustomer.ShipToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.ShipToAddressKey) Then
                customerAddressKey = New GP10Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.ShipToAddressKey
                customer.ShipToAddressKey = customerAddressKey
            End If
            If objCustomer.DefaultAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.DefaultAddressKey) Then
                customerAddressKey = New GP10Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.DefaultAddressKey
                customer.DefaultAddressKey = customerAddressKey
            End If
            If objCustomer.StatementToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.StatementToAddressKey) Then
                customerAddressKey = New GP10Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.StatementToAddressKey
                customer.StatementToAddressKey = customerAddressKey
            End If
            customer.CreatedDate = Date.Parse(Now.ToShortDateString)
            'Create Customer addresses
            If objCustomer.CustomerAddresses.Count > 0 Then
                ReDim customerAddresses(objCustomer.CustomerAddresses.Count - 1)
                For i As Integer = 0 To objCustomer.CustomerAddresses.Count - 1
                    customerAddress = New GP10Service.CustomerAddress

                    ' Create a customer address key 
                    customerAddressKey = New GP10Service.CustomerAddressKey()
                    customerAddressKey.CustomerKey = customerKey
                    customerAddressKey.Id = objCustomer.CustomerAddresses(i).CustomerAddressKey
                    customerAddress.Key = customerAddressKey

                    If objCustomer.CustomerAddresses(i).Name IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Name) Then
                        customerAddress.Name = objCustomer.CustomerAddresses(i).Name
                    End If

                    ' Populate properties with address information 
                    If objCustomer.CustomerAddresses(i).Line1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Line1) Then
                        customerAddress.Line1 = objCustomer.CustomerAddresses(i).Line1
                    End If
                    If objCustomer.CustomerAddresses(i).Line2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Line2) Then
                        customerAddress.Line2 = objCustomer.CustomerAddresses(i).Line2
                    End If
                    If objCustomer.CustomerAddresses(i).Line3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Line3) Then
                        customerAddress.Line3 = objCustomer.CustomerAddresses(i).Line3
                    End If
                    If objCustomer.CustomerAddresses(i).City IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).City) Then
                        customerAddress.City = objCustomer.CustomerAddresses(i).City
                    End If
                    If objCustomer.CustomerAddresses(i).State IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).State) Then
                        customerAddress.State = objCustomer.CustomerAddresses(i).State
                    End If
                    If objCustomer.CustomerAddresses(i).PostalCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).PostalCode) Then
                        customerAddress.PostalCode = objCustomer.CustomerAddresses(i).PostalCode
                    End If
                    If objCustomer.CustomerAddresses(i).CountryRegion IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).CountryRegion) Then
                        customerAddress.CountryRegion = objCustomer.CustomerAddresses(i).CountryRegion
                    End If
                    If objCustomer.CustomerAddresses(i).CountryRegionCodeKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).CountryRegionCodeKey) Then
                        countryRegionCodeKey = New GP10Service.CountryRegionCodeKey
                        countryRegionCodeKey.Id = objCustomer.CustomerAddresses(i).CountryRegionCodeKey
                        customerAddress.CountryRegionCodeKey = countryRegionCodeKey
                    End If

                    customerAddress.CreatedDate = IIf(objCustomer.CustomerAddresses(i).CreatedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomer.CustomerAddresses(i).CreatedDate.ToShortDateString))
                    customerAddress.DeleteOnUpdate = objCustomer.CustomerAddresses(i).DeleteOnUpdate

                    If objCustomer.CustomerAddresses(i).ContactPerson IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).ContactPerson) Then
                        customerAddress.ContactPerson = objCustomer.CustomerAddresses(i).ContactPerson
                    End If

                    If objCustomer.CustomerAddresses(i).Fax IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Fax) Then
                        phoneNumber = New GP10Service.PhoneNumber
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Fax
                        customerAddress.Fax = phoneNumber
                        If objCustomer.CustomerAddresses(i).FaxExtension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).FaxExtension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).FaxExtension
                        End If
                    End If

                    If objCustomer.CustomerAddresses(i).Phone1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone1) Then
                        phoneNumber = New GP10Service.PhoneNumber
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Phone1
                        customerAddress.Phone1 = phoneNumber
                        If objCustomer.CustomerAddresses(i).Phone1Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone1Extension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).Phone1Extension
                        End If

                    End If

                    If objCustomer.CustomerAddresses(i).Phone2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone2) Then
                        phoneNumber = New GP10Service.PhoneNumber
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Phone2
                        customerAddress.Phone2 = phoneNumber
                        If objCustomer.CustomerAddresses(i).Phone2Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone2Extension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).Phone2Extension
                        End If
                    End If

                    If objCustomer.CustomerAddresses(i).Phone3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone3) Then
                        phoneNumber = New GP10Service.PhoneNumber
                        If objCustomer.CustomerAddresses(i).Phone3Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone3Extension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).Phone3Extension
                        End If
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Phone3
                        customerAddress.Phone3 = phoneNumber
                    End If

                    customerAddress.ModifiedDate = IIf(objCustomer.CustomerAddresses(i).ModifiedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomer.CustomerAddresses(i).ModifiedDate.ToShortDateString))

                    If objCustomer.CustomerAddresses(i).SalespersonKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).SalespersonKey) Then
                        salespersonKey = New GP10Service.SalespersonKey
                        salespersonKey.Id = objCustomer.CustomerAddresses(i).SalespersonKey
                        customerAddress.SalespersonKey = salespersonKey
                    End If

                    If objCustomer.CustomerAddresses(i).SalesTerritoryKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).SalesTerritoryKey) Then
                        salesTerritoryKey = New GP10Service.SalesTerritoryKey
                        salesTerritoryKey.Id = objCustomer.CustomerAddresses(i).SalesTerritoryKey
                        customerAddress.SalesTerritoryKey = salesTerritoryKey
                    End If

                    If objCustomer.CustomerAddresses(i).ShippingMethodKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).ShippingMethodKey) Then
                        shippingMethodKey = New GP10Service.ShippingMethodKey
                        shippingMethodKey.Id = objCustomer.CustomerAddresses(i).ShippingMethodKey
                        customerAddress.ShippingMethodKey = shippingMethodKey
                    End If

                    If objCustomer.CustomerAddresses(i).TaxScheduleKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).TaxScheduleKey) Then
                        taxScheduleKey = New GP10Service.TaxScheduleKey
                        taxScheduleKey.Id = objCustomer.CustomerAddresses(i).TaxScheduleKey
                        customerAddress.TaxScheduleKey = taxScheduleKey
                    End If

                    If objCustomer.CustomerAddresses(i).UPSZone IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).UPSZone) Then
                        customerAddress.UPSZone = objCustomer.CustomerAddresses(i).UPSZone
                    End If

                    If objCustomer.CustomerAddresses(i).UserDefined1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).UserDefined1) Then
                        customerAddress.UserDefined1 = objCustomer.CustomerAddresses(i).UserDefined1
                    End If

                    If objCustomer.CustomerAddresses(i).UserDefined2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).UserDefined2) Then
                        customerAddress.UserDefined2 = objCustomer.CustomerAddresses(i).UserDefined2
                    End If

                    If objCustomer.CustomerAddresses(i).WarehouseKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).WarehouseKey) Then
                        warehouseKey = New GP10Service.WarehouseKey
                        warehouseKey.Id = objCustomer.CustomerAddresses(i).WarehouseKey
                        customerAddress.WarehouseKey = warehouseKey
                    End If

                    If objCustomer.CustomerAddresses(i).InternetAddresses IsNot Nothing Then
                        InternetFields = New MSGPWSIntegration.GP10Service.InternetAddresses
                        With objCustomer.CustomerAddresses(i).InternetAddresses
                            If Not String.IsNullOrEmpty(.InternetField1) Then
                                InternetFields.InternetField1 = .InternetField1
                            End If
                            If Not String.IsNullOrEmpty(.InternetField2) Then
                                InternetFields.InternetField2 = .InternetField2
                            End If
                            If Not String.IsNullOrEmpty(.InternetField3) Then
                                InternetFields.InternetField3 = .InternetField3
                            End If
                            If Not String.IsNullOrEmpty(.InternetField4) Then
                                InternetFields.InternetField4 = .InternetField4
                            End If
                            If Not String.IsNullOrEmpty(.InternetField5) Then
                                InternetFields.InternetField5 = .InternetField5
                            End If
                            If Not String.IsNullOrEmpty(.InternetField6) Then
                                InternetFields.InternetField6 = .InternetField6
                            End If
                            If Not String.IsNullOrEmpty(.InternetField7) Then
                                InternetFields.InternetField7 = .InternetField7
                            End If
                            If Not String.IsNullOrEmpty(.InternetField8) Then
                                InternetFields.InternetField8 = .InternetField8
                            End If
                            If Not String.IsNullOrEmpty(.AdditionalInformation) Then
                                InternetFields.AdditionalInformation = .AdditionalInformation
                            End If
                        End With
                        customerAddress.InternetAddresses = InternetFields

                    End If
                    customerAddresses(i) = customerAddress
                Next
                customer.Addresses = customerAddresses
            End If

            If UpdateCustomer Then
                customerPolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("UpdateCustomer", context)
                objGPConfiguration.GPWS10.UpdateCustomer(customer, context, customerPolicy)
            Else
                customerPolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateCustomer", context)
                objGPConfiguration.GPWS10.CreateCustomer(customer, context, customerPolicy)
            End If

            Return "Success"
        End Function
        ''' <summary>
        ''' Create a new GP 2010 customer
        ''' </summary>
        ''' <param name="objCustomer"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateUpdateGP2010Customer(ByVal objCustomer As RMCustomer, ByVal objGPConfiguration As GPSystemConfiguration, Optional ByVal UpdateCustomer As UpdateObjectMode = UpdateObjectMode.CreateNewOnlyThrowErrorIfExists) As String

            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim customer As GP2010Service.Customer
            Dim customerKey As GP2010Service.CustomerKey
            Dim customerPolicy As GP2010Service.Policy
            Dim CustomerClassKey As GP2010Service.CustomerClassKey
            Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
            Dim PriceLevelKey As GP2010Service.PriceLevelKey
            Dim TradeDiscountPercent As GP2010Service.Percent
            Dim customerAddress As GP2010Service.CustomerAddress
            Dim customerAddresses As GP2010Service.CustomerAddress()
            Dim customerAddressKey As GP2010Service.CustomerAddressKey
            Dim countryRegionCodeKey As GP2010Service.CountryRegionCodeKey
            Dim phoneNumber As GP2010Service.PhoneNumber
            Dim salespersonKey As GP2010Service.SalespersonKey
            Dim salesTerritoryKey As GP2010Service.SalesTerritoryKey
            Dim shippingMethodKey As GP2010Service.ShippingMethodKey
            Dim taxScheduleKey As GP2010Service.TaxScheduleKey
            Dim warehouseKey As GP2010Service.WarehouseKey
            Dim InternetFields As GP2010Service.InternetAddresses

            'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            'objGPConfiguration.UpdateWebServiceConnectionFromConfiguration()
            'Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP2010Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If

            ' Create a context with which to call the web service 
            context = objGPConfiguration.GP2010GetContext()
            companyKey = objGPConfiguration.GP2010GetCompanyKey()

            ' Create a new customer object 
            customer = New GP2010Service.Customer()

            ' Create a customer key 
            customerKey = New GP2010Service.CustomerKey()
            customerKey.Id = objCustomer.CustomerKey
            customer.Key = customerKey

            ' Set properties for the new customer 
            If objCustomer.CustomerName IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerName) Then
                customer.Name = objCustomer.CustomerName
            End If

            If objCustomer.ClassKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.ClassKey) Then
                CustomerClassKey = New GP2010Service.CustomerClassKey
                CustomerClassKey.Id = objCustomer.ClassKey
                customer.ClassKey = CustomerClassKey
            End If

            If objCustomer.Comment1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Comment1) Then
                customer.Comment1 = objCustomer.Comment1
            End If

            If objCustomer.Comment2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Comment2) Then
                customer.Comment2 = objCustomer.Comment2
            End If

            customer.CreatedDate = IIf(objCustomer.CreatedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomer.CreatedDate.ToShortDateString))
            customer.IsOnHold = objCustomer.IsOnHold
            customer.IsActive = objCustomer.IsActive


            If objCustomer.Notes IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Notes) Then
                customer.Notes = objCustomer.Notes
            End If

            If objCustomer.Shortname IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.Shortname) Then
                customer.Shortname = objCustomer.Shortname
            End If

            If objCustomer.Priority > 0 Then
                customer.Priority = objCustomer.Priority
            End If


            If objCustomer.PaymentTermsKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.PaymentTermsKey) Then
                PaymentTermsKey = New GP2010Service.PaymentTermsKey
                PaymentTermsKey.Id = objCustomer.PaymentTermsKey
                customer.PaymentTermsKey = PaymentTermsKey
            End If
            ReDim customer.TaxExemptNumbers(0)
            customer.TaxExemptNumbers(0) = objCustomer.TaxExemptNumber1


            customer.ShipCompleteOnly = objCustomer.ShipCompleteOnly

            If objCustomer.UserDefined1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.UserDefined1) Then
                customer.UserDefined1 = objCustomer.UserDefined1
            End If

            If objCustomer.UserDefined2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.UserDefined2) Then
                customer.UserDefined2 = objCustomer.UserDefined2
            End If

            If objCustomer.TaxRegistrationNumber IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.TaxRegistrationNumber) Then
                customer.TaxRegistrationNumber = objCustomer.TaxRegistrationNumber
            End If

            If objCustomer.StatementName IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.StatementName) Then
                customer.StatementName = objCustomer.StatementName
            End If

            customer.DiscountGracePeriod = objCustomer.DiscountGracePeriod
            customer.DueDateGracePeriod = objCustomer.DueDateGracePeriod

            If objCustomer.PriceLevelKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.PriceLevelKey) Then
                PriceLevelKey = New GP2010Service.PriceLevelKey
                PriceLevelKey.Id = objCustomer.PriceLevelKey
                customer.PriceLevelKey = PriceLevelKey
            End If

            TradeDiscountPercent = New GP2010Service.Percent
            TradeDiscountPercent.Value = objCustomer.TradeDiscountPercent
            customer.TradeDiscountPercent = TradeDiscountPercent

            If objCustomer.BillToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.BillToAddressKey) Then
                customerAddressKey = New GP2010Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.BillToAddressKey
                customer.BillToAddressKey = customerAddressKey
            End If
            If objCustomer.ShipToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.ShipToAddressKey) Then
                customerAddressKey = New GP2010Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.ShipToAddressKey
                customer.ShipToAddressKey = customerAddressKey
            End If
            If objCustomer.DefaultAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.DefaultAddressKey) Then
                customerAddressKey = New GP2010Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.DefaultAddressKey
                customer.DefaultAddressKey = customerAddressKey
            End If
            If objCustomer.StatementToAddressKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.StatementToAddressKey) Then
                customerAddressKey = New GP2010Service.CustomerAddressKey
                customerAddressKey.Id = objCustomer.StatementToAddressKey
                customer.StatementToAddressKey = customerAddressKey
            End If
            customer.CreatedDate = Date.Parse(Now.ToShortDateString)
            'Create Customer addresses
            If objCustomer.CustomerAddresses.Count > 0 Then
                ReDim customerAddresses(objCustomer.CustomerAddresses.Count - 1)
                For i As Integer = 0 To objCustomer.CustomerAddresses.Count - 1
                    customerAddress = New GP2010Service.CustomerAddress

                    ' Create a customer address key 
                    customerAddressKey = New GP2010Service.CustomerAddressKey()
                    customerAddressKey.CustomerKey = customerKey
                    customerAddressKey.Id = objCustomer.CustomerAddresses(i).CustomerAddressKey
                    customerAddress.Key = customerAddressKey

                    If objCustomer.CustomerAddresses(i).Name IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Name) Then
                        customerAddress.Name = objCustomer.CustomerAddresses(i).Name
                    End If

                    ' Populate properties with address information 
                    If objCustomer.CustomerAddresses(i).Line1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Line1) Then
                        customerAddress.Line1 = objCustomer.CustomerAddresses(i).Line1
                    End If
                    If objCustomer.CustomerAddresses(i).Line2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Line2) Then
                        customerAddress.Line2 = objCustomer.CustomerAddresses(i).Line2
                    End If
                    If objCustomer.CustomerAddresses(i).Line3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Line3) Then
                        customerAddress.Line3 = objCustomer.CustomerAddresses(i).Line3
                    End If
                    If objCustomer.CustomerAddresses(i).City IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).City) Then
                        customerAddress.City = objCustomer.CustomerAddresses(i).City
                    End If
                    If objCustomer.CustomerAddresses(i).State IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).State) Then
                        customerAddress.State = objCustomer.CustomerAddresses(i).State
                    End If
                    If objCustomer.CustomerAddresses(i).PostalCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).PostalCode) Then
                        customerAddress.PostalCode = objCustomer.CustomerAddresses(i).PostalCode
                    End If
                    If objCustomer.CustomerAddresses(i).CountryRegion IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).CountryRegion) Then
                        customerAddress.CountryRegion = objCustomer.CustomerAddresses(i).CountryRegion
                    End If
                    If objCustomer.CustomerAddresses(i).CountryRegionCodeKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).CountryRegionCodeKey) Then
                        countryRegionCodeKey = New GP2010Service.CountryRegionCodeKey
                        countryRegionCodeKey.Id = objCustomer.CustomerAddresses(i).CountryRegionCodeKey
                        customerAddress.CountryRegionCodeKey = countryRegionCodeKey
                    End If

                    customerAddress.CreatedDate = IIf(objCustomer.CustomerAddresses(i).CreatedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomer.CustomerAddresses(i).CreatedDate.ToShortDateString))
                    customerAddress.DeleteOnUpdate = objCustomer.CustomerAddresses(i).DeleteOnUpdate

                    If objCustomer.CustomerAddresses(i).ContactPerson IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).ContactPerson) Then
                        customerAddress.ContactPerson = objCustomer.CustomerAddresses(i).ContactPerson
                    End If

                    If objCustomer.CustomerAddresses(i).Fax IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Fax) Then
                        phoneNumber = New GP2010Service.PhoneNumber
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Fax
                        customerAddress.Fax = phoneNumber
                        If objCustomer.CustomerAddresses(i).FaxExtension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).FaxExtension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).FaxExtension
                        End If
                    End If

                    If objCustomer.CustomerAddresses(i).Phone1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone1) Then
                        phoneNumber = New GP2010Service.PhoneNumber
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Phone1
                        customerAddress.Phone1 = phoneNumber
                        If objCustomer.CustomerAddresses(i).Phone1Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone1Extension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).Phone1Extension
                        End If

                    End If

                    If objCustomer.CustomerAddresses(i).Phone2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone2) Then
                        phoneNumber = New GP2010Service.PhoneNumber
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Phone2
                        customerAddress.Phone2 = phoneNumber
                        If objCustomer.CustomerAddresses(i).Phone2Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone2Extension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).Phone2Extension
                        End If
                    End If

                    If objCustomer.CustomerAddresses(i).Phone3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone3) Then
                        phoneNumber = New GP2010Service.PhoneNumber
                        If objCustomer.CustomerAddresses(i).Phone3Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).Phone3Extension) Then
                            phoneNumber.Extension = objCustomer.CustomerAddresses(i).Phone3Extension
                        End If
                        phoneNumber.Value = objCustomer.CustomerAddresses(i).Phone3
                        customerAddress.Phone3 = phoneNumber
                    End If

                    customerAddress.ModifiedDate = IIf(objCustomer.CustomerAddresses(i).ModifiedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomer.CustomerAddresses(i).ModifiedDate.ToShortDateString))

                    If objCustomer.CustomerAddresses(i).SalespersonKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).SalespersonKey) Then
                        salespersonKey = New GP2010Service.SalespersonKey
                        salespersonKey.Id = objCustomer.CustomerAddresses(i).SalespersonKey
                        customerAddress.SalespersonKey = salespersonKey
                    End If

                    If objCustomer.CustomerAddresses(i).SalesTerritoryKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).SalesTerritoryKey) Then
                        salesTerritoryKey = New GP2010Service.SalesTerritoryKey
                        salesTerritoryKey.Id = objCustomer.CustomerAddresses(i).SalesTerritoryKey
                        customerAddress.SalesTerritoryKey = salesTerritoryKey
                    End If

                    If objCustomer.CustomerAddresses(i).ShippingMethodKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).ShippingMethodKey) Then
                        shippingMethodKey = New GP2010Service.ShippingMethodKey
                        shippingMethodKey.Id = objCustomer.CustomerAddresses(i).ShippingMethodKey
                        customerAddress.ShippingMethodKey = shippingMethodKey
                    End If

                    If objCustomer.CustomerAddresses(i).TaxScheduleKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).TaxScheduleKey) Then
                        taxScheduleKey = New GP2010Service.TaxScheduleKey
                        taxScheduleKey.Id = objCustomer.CustomerAddresses(i).TaxScheduleKey
                        customerAddress.TaxScheduleKey = taxScheduleKey
                    End If

                    If objCustomer.CustomerAddresses(i).UPSZone IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).UPSZone) Then
                        customerAddress.UPSZone = objCustomer.CustomerAddresses(i).UPSZone
                    End If

                    If objCustomer.CustomerAddresses(i).UserDefined1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).UserDefined1) Then
                        customerAddress.UserDefined1 = objCustomer.CustomerAddresses(i).UserDefined1
                    End If

                    If objCustomer.CustomerAddresses(i).UserDefined2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).UserDefined2) Then
                        customerAddress.UserDefined2 = objCustomer.CustomerAddresses(i).UserDefined2
                    End If

                    If objCustomer.CustomerAddresses(i).WarehouseKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomer.CustomerAddresses(i).WarehouseKey) Then
                        warehouseKey = New GP2010Service.WarehouseKey
                        warehouseKey.Id = objCustomer.CustomerAddresses(i).WarehouseKey
                        customerAddress.WarehouseKey = warehouseKey
                    End If

                    If objCustomer.CustomerAddresses(i).InternetAddresses IsNot Nothing Then
                        InternetFields = New GP2010Service.InternetAddresses
                        With objCustomer.CustomerAddresses(i).InternetAddresses
                            If Not String.IsNullOrEmpty(.InternetField1) Then
                                InternetFields.InternetField1 = .InternetField1
                            End If
                            If Not String.IsNullOrEmpty(.InternetField2) Then
                                InternetFields.InternetField2 = .InternetField2
                            End If
                            If Not String.IsNullOrEmpty(.InternetField3) Then
                                InternetFields.InternetField3 = .InternetField3
                            End If
                            If Not String.IsNullOrEmpty(.InternetField4) Then
                                InternetFields.InternetField4 = .InternetField4
                            End If
                            If Not String.IsNullOrEmpty(.InternetField5) Then
                                InternetFields.InternetField5 = .InternetField5
                            End If
                            If Not String.IsNullOrEmpty(.InternetField6) Then
                                InternetFields.InternetField6 = .InternetField6
                            End If
                            If Not String.IsNullOrEmpty(.InternetField7) Then
                                InternetFields.InternetField7 = .InternetField7
                            End If
                            If Not String.IsNullOrEmpty(.InternetField8) Then
                                InternetFields.InternetField8 = .InternetField8
                            End If
                            If Not String.IsNullOrEmpty(.AdditionalInformation) Then
                                InternetFields.AdditionalInformation = .AdditionalInformation
                            End If
                        End With
                        customerAddress.InternetAddresses = InternetFields
                    End If
                    customerAddresses(i) = customerAddress
                Next
                customer.Addresses = customerAddresses
            End If

            Select Case UpdateCustomer
                Case UpdateObjectMode.UpdateExistingOnly
                    customerPolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("UpdateCustomer", context)
                    objGPConfiguration.GPWS2010.UpdateCustomer(customer, context, customerPolicy)

                Case UpdateObjectMode.CreateNewOnlyThrowErrorIfExists
                    customerPolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateCustomer", context)
                    objGPConfiguration.GPWS2010.CreateCustomer(customer, context, customerPolicy)

                Case UpdateObjectMode.CreateNewOnlyThrowNoErrorIfExists
                    If GP2010GetCustomerByKey(objGPConfiguration, customer.Key.Id) Is Nothing Then
                        customerPolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateCustomer", context)
                        objGPConfiguration.GPWS2010.CreateCustomer(customer, context, customerPolicy)
                    End If



                Case UpdateObjectMode.UpdateExistingOrCreateNew
                    Try
                        GP2010GetCustomerByKey(objGPConfiguration, customer.Key.Id)
                    Catch ex As System.ServiceModel.FaultException
                        customerPolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateCustomer", context)
                        objGPConfiguration.GPWS2010.CreateCustomer(customer, context, customerPolicy)
                    End Try

            End Select
            Return "Success"
        End Function

        Public Shared Function GP2010GetCustomerByKey(GPConfiguration As GPSystemConfiguration, CustomerKey As String) As GP2010Service.Customer
            Dim context As GP2010Service.Context = GPConfiguration.GP2010GetContext
            Dim gpCustomerKey As New GP2010Service.CustomerKey

            gpCustomerKey.Id = CustomerKey
            Return GPConfiguration.GPWS2010.GetCustomerByKey(gpCustomerKey, context)



        End Function


        ''' <summary>
        ''' create a new GP customer address
        ''' </summary>
        ''' <param name="objCustomerAddress"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPCustomerAddress(ByVal objCustomerAddress As RMCustomerAddress, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10CustomerAddress(objCustomerAddress, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010CustomerAddress(objCustomerAddress, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' create a new GP 10 customer address
        ''' </summary>
        ''' <param name="objCustomerAddress"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10CustomerAddress(ByVal objCustomerAddress As RMCustomerAddress, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Dim companyKey As GP10Service.CompanyKey
            Dim context As GP10Service.Context
            Dim customerKey As GP10Service.CustomerKey
            Dim customerAddressKey As GP10Service.CustomerAddressKey
            Dim customerAddress As GP10Service.CustomerAddress
            Dim customerAddressCreatePolicy As GP10Service.Policy
            Dim countryRegionCodeKey As GP10Service.CountryRegionCodeKey
            Dim phoneNumber As GP10Service.PhoneNumber
            Dim salespersonKey As GP10Service.SalespersonKey
            Dim salesTerritoryKey As GP10Service.SalesTerritoryKey
            Dim shippingMethodKey As GP10Service.ShippingMethodKey
            Dim taxScheduleKey As GP10Service.TaxScheduleKey
            Dim warehouseKey As GP10Service.WarehouseKey
            'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP10Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If

            ' Create a context with which to call the web service 
            context = New GP10Service.Context()

            ' Specify which company to use (sample company) 
            companyKey = New GP10Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId

            ' Set up the context object 
            context.OrganizationKey = DirectCast(companyKey, GP10Service.OrganizationKey)
            context.CultureName = "en-US"

            ' Create a customer key to specify the customer 
            customerKey = New GP10Service.CustomerKey()
            customerKey.Id = objCustomerAddress.CustomerKey

            ' Create a customer address key 
            customerAddressKey = New GP10Service.CustomerAddressKey()
            customerAddressKey.CustomerKey = customerKey
            customerAddressKey.Id = objCustomerAddress.CustomerAddressKey

            ' Create a customer address object 
            customerAddress = New GP10Service.CustomerAddress()
            customerAddress.Key = customerAddressKey

            If objCustomerAddress.Name IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Name) Then
                customerAddress.Name = objCustomerAddress.Name
            End If

            ' Populate properties with address information 
            If objCustomerAddress.Line1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Line1) Then
                customerAddress.Line1 = objCustomerAddress.Line1
            End If
            If objCustomerAddress.Line2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Line2) Then
                customerAddress.Line2 = objCustomerAddress.Line2
            End If
            If objCustomerAddress.Line3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Line3) Then
                customerAddress.Line3 = objCustomerAddress.Line3
            End If
            If objCustomerAddress.City IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.City) Then
                customerAddress.City = objCustomerAddress.City
            End If
            If objCustomerAddress.State IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.State) Then
                customerAddress.State = objCustomerAddress.State
            End If
            If objCustomerAddress.PostalCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.PostalCode) Then
                customerAddress.PostalCode = objCustomerAddress.PostalCode
            End If
            If objCustomerAddress.CountryRegion IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.CountryRegion) Then
                customerAddress.CountryRegion = objCustomerAddress.CountryRegion
            End If
            If objCustomerAddress.CountryRegionCodeKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.CountryRegionCodeKey) Then
                countryRegionCodeKey = New GP10Service.CountryRegionCodeKey
                countryRegionCodeKey.Id = objCustomerAddress.CountryRegionCodeKey
                customerAddress.CountryRegionCodeKey = countryRegionCodeKey
            End If

            customerAddress.CreatedDate = IIf(objCustomerAddress.CreatedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomerAddress.CreatedDate.ToShortDateString))
            customerAddress.DeleteOnUpdate = objCustomerAddress.DeleteOnUpdate

            If objCustomerAddress.ContactPerson IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.ContactPerson) Then
                customerAddress.ContactPerson = objCustomerAddress.ContactPerson
            End If

            If objCustomerAddress.Fax IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Fax) Then
                phoneNumber = New GP10Service.PhoneNumber
                If objCustomerAddress.FaxExtension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.FaxExtension) Then
                    phoneNumber.Extension = objCustomerAddress.FaxExtension
                End If
                phoneNumber.Value = objCustomerAddress.Fax
                customerAddress.Fax = phoneNumber
            End If

            If objCustomerAddress.Phone1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone1) Then
                phoneNumber = New GP10Service.PhoneNumber
                If objCustomerAddress.Phone1Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone1Extension) Then
                    phoneNumber.Extension = objCustomerAddress.Phone1Extension
                End If
                phoneNumber.Value = objCustomerAddress.Phone1
                customerAddress.Phone1 = phoneNumber
            End If

            If objCustomerAddress.Phone2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone2) Then
                phoneNumber = New GP10Service.PhoneNumber
                If objCustomerAddress.Phone2Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone2Extension) Then
                    phoneNumber.Extension = objCustomerAddress.Phone2Extension
                End If
                phoneNumber.Value = objCustomerAddress.Phone2
                customerAddress.Phone2 = phoneNumber
            End If

            If objCustomerAddress.Phone3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone3) Then
                phoneNumber = New GP10Service.PhoneNumber
                If objCustomerAddress.Phone3Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone3Extension) Then
                    phoneNumber.Extension = objCustomerAddress.Phone3Extension
                End If
                phoneNumber.Value = objCustomerAddress.Phone3
                customerAddress.Phone3 = phoneNumber
            End If

            customerAddress.ModifiedDate = IIf(objCustomerAddress.ModifiedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomerAddress.ModifiedDate.ToShortDateString))

            If objCustomerAddress.SalespersonKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.SalespersonKey) Then
                salespersonKey = New GP10Service.SalespersonKey
                salespersonKey.Id = objCustomerAddress.SalespersonKey
                customerAddress.SalespersonKey = salespersonKey
            End If

            If objCustomerAddress.SalesTerritoryKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.SalesTerritoryKey) Then
                salesTerritoryKey = New GP10Service.SalesTerritoryKey
                salesTerritoryKey.Id = objCustomerAddress.SalesTerritoryKey
                customerAddress.SalesTerritoryKey = salesTerritoryKey
            End If

            If objCustomerAddress.ShippingMethodKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.ShippingMethodKey) Then
                shippingMethodKey = New GP10Service.ShippingMethodKey
                shippingMethodKey.Id = objCustomerAddress.ShippingMethodKey
                customerAddress.ShippingMethodKey = shippingMethodKey
            End If

            If objCustomerAddress.TaxScheduleKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.TaxScheduleKey) Then
                taxScheduleKey = New GP10Service.TaxScheduleKey
                taxScheduleKey.Id = objCustomerAddress.TaxScheduleKey
                customerAddress.TaxScheduleKey = taxScheduleKey
            End If

            If objCustomerAddress.UPSZone IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.UPSZone) Then
                customerAddress.UPSZone = objCustomerAddress.UPSZone
            End If

            If objCustomerAddress.UserDefined1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.UserDefined1) Then
                customerAddress.UserDefined1 = objCustomerAddress.UserDefined1
            End If

            If objCustomerAddress.UserDefined2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.UserDefined2) Then
                customerAddress.UserDefined2 = objCustomerAddress.UserDefined2
            End If

            If objCustomerAddress.WarehouseKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.WarehouseKey) Then
                warehouseKey = New GP10Service.WarehouseKey
                warehouseKey.Id = objCustomerAddress.WarehouseKey
                customerAddress.WarehouseKey = warehouseKey
            End If

            'customerAddress.DeleteOnUpdate = objCustomerAddress.DeleteOnUpdate

            If objCustomerAddress.DeleteOnUpdate = True Then
                customerAddressCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("UpdateCustomerAddress", context)
                objGPConfiguration.GPWS10.UpdateCustomerAddress(customerAddress, context, customerAddressCreatePolicy)
            Else
                customerAddressCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateCustomerAddress", context)
                objGPConfiguration.GPWS10.CreateCustomerAddress(customerAddress, context, customerAddressCreatePolicy)
            End If


            Return "Success"

        End Function
        ''' <summary>
        ''' create a new GP 2010 customer address
        ''' </summary>
        ''' <param name="objCustomerAddress"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010CustomerAddress(ByVal objCustomerAddress As RMCustomerAddress, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim customerKey As GP2010Service.CustomerKey
            Dim customerAddressKey As GP2010Service.CustomerAddressKey
            Dim customerAddress As GP2010Service.CustomerAddress
            Dim customerAddressCreatePolicy As GP2010Service.Policy
            Dim countryRegionCodeKey As GP2010Service.CountryRegionCodeKey
            Dim phoneNumber As GP2010Service.PhoneNumber
            Dim salespersonKey As GP2010Service.SalespersonKey
            Dim salesTerritoryKey As GP2010Service.SalesTerritoryKey
            Dim shippingMethodKey As GP2010Service.ShippingMethodKey
            Dim taxScheduleKey As GP2010Service.TaxScheduleKey
            Dim warehouseKey As GP2010Service.WarehouseKey
            'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP2010Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If

            ' Create a context with which to call the web service 
            context = New GP2010Service.Context()

            ' Specify which company to use (sample company) 
            companyKey = New GP2010Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId

            ' Set up the context object 
            context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
            context.CultureName = "en-US"

            ' Create a customer key to specify the customer 
            customerKey = New GP2010Service.CustomerKey()
            customerKey.Id = objCustomerAddress.CustomerKey

            ' Create a customer address key 
            customerAddressKey = New GP2010Service.CustomerAddressKey()
            customerAddressKey.CustomerKey = customerKey
            customerAddressKey.Id = objCustomerAddress.CustomerAddressKey

            ' Create a customer address object 
            customerAddress = New GP2010Service.CustomerAddress()
            customerAddress.Key = customerAddressKey

            If objCustomerAddress.Name IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Name) Then
                customerAddress.Name = objCustomerAddress.Name
            End If

            ' Populate properties with address information 
            If objCustomerAddress.Line1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Line1) Then
                customerAddress.Line1 = objCustomerAddress.Line1
            End If
            If objCustomerAddress.Line2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Line2) Then
                customerAddress.Line2 = objCustomerAddress.Line2
            End If
            If objCustomerAddress.Line3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Line3) Then
                customerAddress.Line3 = objCustomerAddress.Line3
            End If
            If objCustomerAddress.City IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.City) Then
                customerAddress.City = objCustomerAddress.City
            End If
            If objCustomerAddress.State IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.State) Then
                customerAddress.State = objCustomerAddress.State
            End If
            If objCustomerAddress.PostalCode IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.PostalCode) Then
                customerAddress.PostalCode = objCustomerAddress.PostalCode
            End If
            If objCustomerAddress.CountryRegion IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.CountryRegion) Then
                customerAddress.CountryRegion = objCustomerAddress.CountryRegion
            End If
            If objCustomerAddress.CountryRegionCodeKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.CountryRegionCodeKey) Then
                countryRegionCodeKey = New GP2010Service.CountryRegionCodeKey
                countryRegionCodeKey.Id = objCustomerAddress.CountryRegionCodeKey
                customerAddress.CountryRegionCodeKey = countryRegionCodeKey
            End If

            customerAddress.CreatedDate = IIf(objCustomerAddress.CreatedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomerAddress.CreatedDate.ToShortDateString))
            customerAddress.DeleteOnUpdate = objCustomerAddress.DeleteOnUpdate

            If objCustomerAddress.ContactPerson IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.ContactPerson) Then
                customerAddress.ContactPerson = objCustomerAddress.ContactPerson
            End If

            If objCustomerAddress.Fax IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Fax) Then
                phoneNumber = New GP2010Service.PhoneNumber
                If objCustomerAddress.FaxExtension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.FaxExtension) Then
                    phoneNumber.Extension = objCustomerAddress.FaxExtension
                End If
                phoneNumber.Value = objCustomerAddress.Fax
                customerAddress.Fax = phoneNumber
            End If

            If objCustomerAddress.Phone1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone1) Then
                phoneNumber = New GP2010Service.PhoneNumber
                If objCustomerAddress.Phone1Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone1Extension) Then
                    phoneNumber.Extension = objCustomerAddress.Phone1Extension
                End If
                phoneNumber.Value = objCustomerAddress.Phone1
                customerAddress.Phone1 = phoneNumber
            End If

            If objCustomerAddress.Phone2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone2) Then
                phoneNumber = New GP2010Service.PhoneNumber
                If objCustomerAddress.Phone2Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone2Extension) Then
                    phoneNumber.Extension = objCustomerAddress.Phone2Extension
                End If
                phoneNumber.Value = objCustomerAddress.Phone2
                customerAddress.Phone2 = phoneNumber
            End If

            If objCustomerAddress.Phone3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone3) Then
                phoneNumber = New GP2010Service.PhoneNumber
                If objCustomerAddress.Phone3Extension IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.Phone3Extension) Then
                    phoneNumber.Extension = objCustomerAddress.Phone3Extension
                End If
                phoneNumber.Value = objCustomerAddress.Phone3
                customerAddress.Phone3 = phoneNumber
            End If

            customerAddress.ModifiedDate = IIf(objCustomerAddress.ModifiedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(objCustomerAddress.ModifiedDate.ToShortDateString))

            If objCustomerAddress.SalespersonKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.SalespersonKey) Then
                salespersonKey = New GP2010Service.SalespersonKey
                salespersonKey.Id = objCustomerAddress.SalespersonKey
                customerAddress.SalespersonKey = salespersonKey
            End If

            If objCustomerAddress.SalesTerritoryKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.SalesTerritoryKey) Then
                salesTerritoryKey = New GP2010Service.SalesTerritoryKey
                salesTerritoryKey.Id = objCustomerAddress.SalesTerritoryKey
                customerAddress.SalesTerritoryKey = salesTerritoryKey
            End If

            If objCustomerAddress.ShippingMethodKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.ShippingMethodKey) Then
                shippingMethodKey = New GP2010Service.ShippingMethodKey
                shippingMethodKey.Id = objCustomerAddress.ShippingMethodKey
                customerAddress.ShippingMethodKey = shippingMethodKey
            End If

            If objCustomerAddress.TaxScheduleKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.TaxScheduleKey) Then
                taxScheduleKey = New GP2010Service.TaxScheduleKey
                taxScheduleKey.Id = objCustomerAddress.TaxScheduleKey
                customerAddress.TaxScheduleKey = taxScheduleKey
            End If

            If objCustomerAddress.UPSZone IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.UPSZone) Then
                customerAddress.UPSZone = objCustomerAddress.UPSZone
            End If

            If objCustomerAddress.UserDefined1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.UserDefined1) Then
                customerAddress.UserDefined1 = objCustomerAddress.UserDefined1
            End If

            If objCustomerAddress.UserDefined2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.UserDefined2) Then
                customerAddress.UserDefined2 = objCustomerAddress.UserDefined2
            End If

            If objCustomerAddress.WarehouseKey IsNot Nothing AndAlso Not String.IsNullOrEmpty(objCustomerAddress.WarehouseKey) Then
                warehouseKey = New GP2010Service.WarehouseKey
                warehouseKey.Id = objCustomerAddress.WarehouseKey
                customerAddress.WarehouseKey = warehouseKey
            End If


            If objCustomerAddress.InternetAddresses IsNot Nothing Then
                customerAddress.InternetAddresses = New GP2010Service.InternetAddresses
                With objCustomerAddress.InternetAddresses
                    If Not String.IsNullOrEmpty(.InternetField1) Then
                        customerAddress.InternetAddresses.InternetField1 = .InternetField1
                        customerAddress.InternetAddresses.EmailToAddress = .InternetField1
                    End If
                    If Not String.IsNullOrEmpty(.InternetField2) Then
                        customerAddress.InternetAddresses.InternetField2 = .InternetField2
                    End If
                    If Not String.IsNullOrEmpty(.InternetField3) Then
                        customerAddress.InternetAddresses.InternetField3 = .InternetField3
                    End If
                    If Not String.IsNullOrEmpty(.InternetField4) Then
                        customerAddress.InternetAddresses.InternetField4 = .InternetField4
                    End If
                    If Not String.IsNullOrEmpty(.InternetField5) Then
                        customerAddress.InternetAddresses.InternetField5 = .InternetField5
                    End If
                    If Not String.IsNullOrEmpty(.InternetField6) Then
                        customerAddress.InternetAddresses.InternetField6 = .InternetField6
                    End If
                    If Not String.IsNullOrEmpty(.InternetField7) Then
                        customerAddress.InternetAddresses.InternetField7 = .InternetField7
                    End If
                    If Not String.IsNullOrEmpty(.InternetField8) Then
                        customerAddress.InternetAddresses.InternetField8 = .InternetField8
                    End If
                    If Not String.IsNullOrEmpty(.AdditionalInformation) Then
                        customerAddress.InternetAddresses.AdditionalInformation = .AdditionalInformation
                    End If
                End With
            End If

            'customerAddress.DeleteOnUpdate = objCustomerAddress.DeleteOnUpdate

            If objCustomerAddress.DeleteOnUpdate = True Then
                customerAddressCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("UpdateCustomerAddress", context)
                objGPConfiguration.GPWS2010.UpdateCustomerAddress(customerAddress, context, customerAddressCreatePolicy)
            Else
                customerAddressCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateCustomerAddress", context)
                objGPConfiguration.GPWS2010.CreateCustomerAddress(customerAddress, context, customerAddressCreatePolicy)
            End If


            Return "Success"

        End Function

        ''' <summary>
        ''' Get GP Default Address Key
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetGPDefaultAddressKey(ByVal GPCustomerKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return GetGP10DefaultAddressKey(GPCustomerKey, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return GetGP2010DefaultAddressKey(GPCustomerKey, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Get GP 10 Default Address Key
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetGP10DefaultAddressKey(ByVal GPCustomerKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Dim companyKey As GP10Service.CompanyKey
            Dim context As GP10Service.Context
            Dim customerKey As GP10Service.CustomerKey
            Dim customer As GP10Service.Customer
            'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP10Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If


            ' Create a context with which to call the web service 
            context = New GP10Service.Context()

            companyKey = New GP10Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId
            context.OrganizationKey = DirectCast(companyKey, GP10Service.OrganizationKey)
            context.CultureName = "en-US"

            ' Create a customer key to specify the customer 
            customerKey = New GP10Service.CustomerKey()
            customerKey.Id = GPCustomerKey

            ' Retrieve the customer object 
            customer = objGPConfiguration.GPWS10.GetCustomerByKey(customerKey, context)

            'Return customer.DefaultAddressKey.Id
            Return customer.ShipToAddressKey.Id

        End Function
        ''' <summary>
        ''' Get GP 2010 Default Address Key
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetGP2010DefaultAddressKey(ByVal GPCustomerKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim customerKey As GP2010Service.CustomerKey
            Dim customer As GP2010Service.Customer
            Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP2010Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If


            ' Create a context with which to call the web service 
            context = New GP2010Service.Context()

            companyKey = New GP2010Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId
            context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
            context.CultureName = "en-US"

            ' Create a customer key to specify the customer 
            customerKey = New GP2010Service.CustomerKey()
            customerKey.Id = GPCustomerKey

            ' Retrieve the customer object 
            customer = objGPConfiguration.GPWS2010.GetCustomerByKey(customerKey, context)

            'Return customer.DefaultAddressKey.Id
            Return customer.ShipToAddressKey.Id

        End Function

        ''' <summary>
        ''' Checks if an address exists in GP
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="GPAddressKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function DoesGPAddressKeyExist(ByVal GPCustomerKey As String, ByVal GPAddressKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As Boolean
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return DoesGP10AddressKeyExist(GPCustomerKey, GPAddressKey, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return DoesGP2010AddressKeyExist(GPCustomerKey, GPAddressKey, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Checks if an address exists in GP 10
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="GPAddressKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function DoesGP10AddressKeyExist(ByVal GPCustomerKey As String, ByVal GPAddressKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As Boolean
            Dim companyKey As GP10Service.CompanyKey
            Dim context As GP10Service.Context
            Dim customerKey As GP10Service.CustomerKey
            Dim customerAddressKey As GP10Service.CustomerAddressKey
            Dim customerAddress As GP10Service.CustomerAddress
            Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP10Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If

            ' Create a context with which to call the web service 
            context = New GP10Service.Context()

            companyKey = New GP10Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId
            context.OrganizationKey = DirectCast(companyKey, GP10Service.OrganizationKey)
            context.CultureName = "en-US"

            customerKey = New GP10Service.CustomerKey()
            customerKey.Id = GPCustomerKey

            customerAddressKey = New GP10Service.CustomerAddressKey()
            customerAddressKey.CustomerKey = customerKey
            customerAddressKey.Id = GPAddressKey

            Try
                customerAddress = objGPConfiguration.GPWS10.GetCustomerAddressByKey(customerAddressKey, context)
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function
        ''' <summary>
        ''' Checks if an address exists in GP 2010
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="GPAddressKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function DoesGP2010AddressKeyExist(ByVal GPCustomerKey As String, ByVal GPAddressKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As Boolean
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim customerKey As GP2010Service.CustomerKey
            Dim customerAddressKey As GP2010Service.CustomerAddressKey
            Dim customerAddress As GP2010Service.CustomerAddress
            Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP2010Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If

            ' Create a context with which to call the web service 
            context = New GP2010Service.Context()

            companyKey = New GP2010Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId
            context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
            context.CultureName = "en-US"

            customerKey = New GP2010Service.CustomerKey()
            customerKey.Id = GPCustomerKey

            customerAddressKey = New GP2010Service.CustomerAddressKey()
            customerAddressKey.CustomerKey = customerKey
            customerAddressKey.Id = GPAddressKey

            Try
                customerAddress = objGPConfiguration.GPWS2010.GetCustomerAddressByKey(customerAddressKey, context)
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Deletes an address
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="GPAddressKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function DeleteGPAddress(ByVal GPCustomerKey As String, ByVal GPAddressKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As Boolean
            Select Case objGPConfiguration.GPVersion

                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return DeleteGP10Address(GPCustomerKey, GPAddressKey, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return DeleteGP2010Address(GPCustomerKey, GPAddressKey, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        '
        ''' <summary>
        ''' Deletes an address in GP 10
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="GPAddressKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function DeleteGP10Address(ByVal GPCustomerKey As String, ByVal GPAddressKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As Boolean
            Dim companyKey As GP10Service.CompanyKey
            Dim context As GP10Service.Context
            Dim customerKey As GP10Service.CustomerKey
            Dim customerAddressKey As GP10Service.CustomerAddressKey
            Dim customerAddress As GP10Service.CustomerAddress
            Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP10Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If

            ' Create a context with which to call the web service 
            context = New GP10Service.Context()

            companyKey = New GP10Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId
            context.OrganizationKey = DirectCast(companyKey, GP10Service.OrganizationKey)
            context.CultureName = "en-US"

            customerKey = New GP10Service.CustomerKey()
            customerKey.Id = GPCustomerKey

            customerAddressKey = New GP10Service.CustomerAddressKey()
            customerAddressKey.CustomerKey = customerKey
            customerAddressKey.Id = GPAddressKey

            Try
                objGPConfiguration.GPWS10.DeleteCustomerAddress(customerAddressKey, context, objGPConfiguration.GPWS10.GetPolicyByOperation("DeleteCustomerAddress", context))
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function
        ''' <summary>
        ''' Deletes an address in GP 2010
        ''' </summary>
        ''' <param name="GPCustomerKey"></param>
        ''' <param name="GPAddressKey"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function DeleteGP2010Address(ByVal GPCustomerKey As String, ByVal GPAddressKey As String, ByVal objGPConfiguration As GPSystemConfiguration) As Boolean
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim customerKey As GP2010Service.CustomerKey
            Dim customerAddressKey As GP2010Service.CustomerAddressKey
            Dim customerAddress As GP2010Service.CustomerAddress
            Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
            Helper.SetupWSWithConfiguration(objGPConfiguration)
            'If Helper.wsDynamicsGP Is Nothing Then
            '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP2010Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
            '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
            'End If

            ' Create a context with which to call the web service 
            context = New GP2010Service.Context()

            companyKey = New GP2010Service.CompanyKey()
            companyKey.Id = objGPConfiguration.GPWSCompanyId
            context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
            context.CultureName = "en-US"

            customerKey = New GP2010Service.CustomerKey()
            customerKey.Id = GPCustomerKey

            customerAddressKey = New GP2010Service.CustomerAddressKey()
            customerAddressKey.CustomerKey = customerKey
            customerAddressKey.Id = GPAddressKey

            Try
                objGPConfiguration.GPWS2010.DeleteCustomerAddress(customerAddressKey, context, objGPConfiguration.GPWS2010.GetPolicyByOperation("DeleteCustomerAddress", context))
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function
    End Class

End Namespace