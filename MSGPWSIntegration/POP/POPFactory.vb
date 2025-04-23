
Imports GP2010Service = MSGPWSIntegration.DynamicsWCFService
Imports GP10Service = MSGPWSIntegration.GP10Service
Namespace POP

    Public Class POPFactory
        Private _mExceptions As System.Collections.ObjectModel.Collection(Of MSGPWSIntegrationException)
        Public Property Exceptions As System.Collections.ObjectModel.Collection(Of MSGPWSIntegrationException)
            Get
                Return _mExceptions
            End Get
            Set(ByVal Value As System.Collections.ObjectModel.Collection(Of MSGPWSIntegrationException))
                _mExceptions = Value
            End Set
        End Property


        Private _mGPConfiguration As Object
        Public Property GPConfiguration As Object
            Get
                Return _mGPConfiguration
            End Get
            Set(ByVal Value As Object)
                _mGPConfiguration = Value
            End Set
        End Property


        Public Shared Function GetNextPONumber(GPConfiguration As GPSystemConfiguration) As String
            Select Case GPConfiguration.GPVersion
                'Case GPSystemConfiguration.AvailableGPVersions.GP10
                'MSGP2010eConnectIntegration.CommonLogic.GetNextPOPPurchaseOrderDocNumber(GPConfiguration.eConnectConnectionString)
                'Case GPSystemConfiguration.AvailableGPVersions.GP2010
                'MSGP2010eConnectIntegration.CommonLogic.GetNextPOPPurchaseOrderDocNumber(GPConfiguration.eConnectConnectionString)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function


        Public Function CreateGPPurchaseOrder(ByVal PurchaseOrder As POP.POPTransaction, ByVal GPConfiguration As GPSystemConfiguration) As String

            Select Case GPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    'Return CreateGP10PurchaseOrder(PurchaseOrder)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010PurchaseOrder(PurchaseOrder, GPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function

        Public Function CreateGPPurchaseReceipt(ByVal PurchaseReceipt As POP.POPReceiptTransaction, ByVal GPConfiguration As GPSystemConfiguration) As String

            Select Case GPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    'Return CreateGP10PurchaseOrder(PurchaseOrder)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010PurchaseReceipt(PurchaseReceipt, GPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function

        Public Function CreateGPPurchaseInvoice(ByVal PurchaseReceipt As POP.POPReceiptTransaction, ByVal GPConfiguration As GPSystemConfiguration) As String

            Select Case GPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    'Return CreateGP10PurchaseOrder(PurchaseOrder)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010PurchaseInvoice(PurchaseReceipt, GPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function

        ''' <summary>
        ''' Creates a purchase order in GP 10
        ''' </summary>
        ''' <param name="PurchaseOrder"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Private Shared Function CreateGP10PurchaseOrder(ByVal PurchaseOrder As POP.POPTransaction) As String
        '    Try
        '        Dim companyKey As GP10Service.CompanyKey
        '        Dim context As GP10Service.Context
        '        Dim purchaseOrderKey As GP10Service.PurchaseTransactionKey
        '        Dim vendorKey As GP10Service.VendorKey
        '        Dim purchaseOrder As GP10Service.PurchaseOrder
        '        Dim purchaseOrderLines As GP10Service.PurchaseOrderLine()
        '        Dim purchaseOrderLine As GP10Service.PurchaseOrderLine
        '        Dim warehouseKey As GP10Service.WarehouseKey
        '        Dim quantityOrdered As GP10Service.Quantity
        '        Dim purchaseOrderCreatePolicy As GP10Service.Policy
        '        Dim PurchaseAddress As GP10Service.BusinessAddress
        '        Dim ShipToAddress As GP10Service.BusinessAddress
        '        Dim PhoneNum As GP10Service.PhoneNumber
        '        Dim BuyerKey As GP10Service.BuyerKey
        '        Dim itemKey As GP10Service.ItemKey
        '        Dim PaymentTermsKey As GP10Service.PaymentTermsKey
        '        Dim CommentKey As GP10Service.CommentKey
        '        Dim ShippingMethodKey As GP10Service.ShippingMethodKey
        '        Dim MoneyAmount As GP10Service.MoneyAmount
        '        Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
        '        'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity

        '        Helper.SetupWSWithConfiguration(PurchaseOrder.POPConfiguration.GPSystemConfiguration)
        '        'If Helper.wsDynamicsGP Is Nothing Then
        '        '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP10Service.DynamicsGPClient("LegacyDynamicsGP", PurchaseOrder.POPConfiguration.GPSystemConfiguration.GPWSUrl)
        '        '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(PurchaseOrder.POPConfiguration.GPSystemConfiguration.GPWSUserName, PurchaseOrder.POPConfiguration.GPSystemConfiguration.GPWSPassword, PurchaseOrder.POPConfiguration.GPSystemConfiguration.GPWSDomain)
        '        'End If

        '        Dim GPPONumber As String = String.Empty
        '        GPPONumber = PurchaseOrder.POPConfiguration.POPDocumentKey

        '        purchaseOrder = New GP10Service.PurchaseOrder
        '        context = New GP10Service.Context
        '        companyKey = New GP10Service.CompanyKey

        '        companyKey.Id = PurchaseOrder.POPConfiguration.GPSystemConfiguration.GPWSCompanyId
        '        context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
        '        context.CultureName = "en-US"

        '        purchaseOrderKey = New GP10Service.PurchaseTransactionKey
        '        purchaseOrderKey.Id = GPPONumber
        '        purchaseOrder.Key = purchaseOrderKey

        '        With PurchaseOrder

        '            'Create PO Header
        '            purchaseOrder.Date = IIf(.POPHeader.OrderDate.Year < 1901, Date.Parse(Date.Today.ToShortDateString), Date.Parse(.POPHeader.OrderDate.ToShortDateString))

        '            vendorKey = New GP10Service.VendorKey
        '            vendorKey.Id = .POPHeader.VendorID
        '            purchaseOrder.VendorKey = vendorKey

        '            If .POPHeader.VendorName IsNot Nothing AndAlso .POPHeader.VendorName.ToString.Trim <> String.Empty Then
        '                purchaseOrder.VendorName = .POPHeader.VendorName
        '            End If

        '            purchaseOrder.Type = .POPHeader.POType

        '            If .POPHeader.BuyerID IsNot Nothing AndAlso .POPHeader.BuyerID.ToString.Trim <> String.Empty Then
        '                BuyerKey = New GP10Service.BuyerKey
        '                BuyerKey.Id = .POPHeader.BuyerID
        '                purchaseOrder.BuyerKey = BuyerKey
        '            End If

        '            purchaseOrder.RequestedDate = IIf(.POPHeader.RequestedShipDate <= Today, Nothing, Date.Parse(.POPHeader.RequestedShipDate.ToShortDateString))

        '            If .POPHeader.ShipMethod IsNot Nothing AndAlso .POPHeader.ShipMethod.ToString.Trim <> String.Empty Then
        '                ShippingMethodKey = New GP10Service.ShippingMethodKey
        '                ShippingMethodKey.Id = .POPHeader.ShipMethod
        '                purchaseOrder.ShippingMethodKey = ShippingMethodKey
        '            End If

        '            If .POPHeader.PaymentTerms IsNot Nothing AndAlso .POPHeader.PaymentTerms.ToString.Trim <> String.Empty Then
        '                PaymentTermsKey = New GP10Service.PaymentTermsKey
        '                PaymentTermsKey.Id = .POPHeader.PaymentTerms
        '                purchaseOrder.PaymentTermsKey = PaymentTermsKey
        '            End If

        '            If .POPHeader.CommentID IsNot Nothing AndAlso .POPHeader.CommentID.ToString.Trim <> String.Empty Then
        '                CommentKey = New GP10Service.CommentKey
        '                CommentKey.Id = .POPHeader.CommentID
        '                purchaseOrder.CommentKey = CommentKey
        '            End If

        '            If .POPHeader.Comment IsNot Nothing AndAlso .POPHeader.Comment.ToString.Trim <> String.Empty Then
        '                purchaseOrder.Comment = .POPHeader.Comment
        '            End If

        '            purchaseOrder.DoesAllowSalesOrderCommitments = .POPHeader.DoesAllowSalesOrderCommitments

        '            PurchaseAddress = New GP10Service.BusinessAddress
        '            With PurchaseAddress
        '                .Name = PurchaseOrder.POPHeader.PurchaseAddress.Name
        '                .Line1 = PurchaseOrder.POPHeader.PurchaseAddress.Address1
        '                .Line2 = PurchaseOrder.POPHeader.PurchaseAddress.Address2
        '                .Line3 = PurchaseOrder.POPHeader.PurchaseAddress.Address3
        '                .City = PurchaseOrder.POPHeader.PurchaseAddress.City
        '                .State = PurchaseOrder.POPHeader.PurchaseAddress.State
        '                .PostalCode = PurchaseOrder.POPHeader.PurchaseAddress.Zip
        '                .CountryRegion = PurchaseOrder.POPHeader.PurchaseAddress.Country
        '                .ContactPerson = PurchaseOrder.POPHeader.PurchaseAddress.ContactPerson
        '                PhoneNum = New GP10Service.PhoneNumber
        '                PhoneNum.Value = PurchaseOrder.POPHeader.PurchaseAddress.PhoneNumber
        '                .Phone1 = PhoneNum
        '            End With
        '            purchaseOrder.PurchaseAddress = PurchaseAddress

        '            ShipToAddress = New GP10Service.BusinessAddress
        '            With PurchaseAddress
        '                .Name = PurchaseOrder.POPHeader.ShipToAddress.Name
        '                .Line1 = PurchaseOrder.POPHeader.ShipToAddress.Address1
        '                .Line2 = PurchaseOrder.POPHeader.ShipToAddress.Address2
        '                .Line3 = PurchaseOrder.POPHeader.ShipToAddress.Address3
        '                .City = PurchaseOrder.POPHeader.ShipToAddress.City
        '                .State = PurchaseOrder.POPHeader.ShipToAddress.State
        '                .PostalCode = PurchaseOrder.POPHeader.ShipToAddress.Zip
        '                .CountryRegion = PurchaseOrder.POPHeader.ShipToAddress.Country
        '                .ContactPerson = PurchaseOrder.POPHeader.ShipToAddress.ContactPerson
        '                PhoneNum = New GP10Service.PhoneNumber
        '                PhoneNum.Value = PurchaseOrder.POPHeader.ShipToAddress.PhoneNumber
        '                .Phone1 = PhoneNum
        '            End With
        '            purchaseOrder.ShipToAddress = ShipToAddress
        '        End With
        '        'Create PO line Items
        '        ReDim purchaseOrderLines(PurchaseOrder.POPDetails.Count - 1)

        '        For i As Integer = 0 To PurchaseOrder.POPDetails.Count - 1

        '            purchaseOrderLine = New GP10Service.PurchaseOrderLine

        '            itemKey = New GP10Service.ItemKey
        '            itemKey.Id = PurchaseOrder.POPDetails.Item(i).ItemNumber
        '            purchaseOrderLine.ItemKey = itemKey

        '            quantityOrdered = New GP10Service.Quantity
        '            quantityOrdered.Value = PurchaseOrder.POPDetails.Item(i).Quantity
        '            purchaseOrderLine.QuantityOrdered = quantityOrdered

        '            If PurchaseOrder.POPDetails.Item(i).UOM IsNot Nothing AndAlso PurchaseOrder.POPDetails.Item(i).UOM.ToString.Trim <> String.Empty Then
        '                purchaseOrderLine.UofM = PurchaseOrder.POPDetails.Item(i).UOM
        '            End If

        '            If PurchaseOrder.POPDetails.Item(i).SiteID IsNot Nothing AndAlso PurchaseOrder.POPDetails.Item(i).SiteID.ToString.Trim <> String.Empty Then
        '                warehouseKey = New GP10Service.WarehouseKey
        '                warehouseKey.Id = PurchaseOrder.POPDetails.Item(i).SiteID
        '                purchaseOrderLine.WarehouseKey = warehouseKey
        '            End If

        '            MoneyAmount = New GP10Service.MoneyAmount
        '            MoneyAmount.Value = PurchaseOrder.POPDetails.Item(i).UnitCost
        '            MoneyAmount.Currency = PurchaseOrder.POPConfiguration.GPSystemConfiguration.CurrencyCode
        '            purchaseOrderLine.UnitCost = MoneyAmount

        '            MoneyAmount = New GP10Service.MoneyAmount
        '            MoneyAmount.Value = PurchaseOrder.POPDetails.Item(i).ExtendedCost
        '            MoneyAmount.Currency = PurchaseOrder.POPConfiguration.GPSystemConfiguration.CurrencyCode
        '            purchaseOrderLine.ExtendedCost = MoneyAmount

        '            If PurchaseOrder.POPDetails.Item(i).CommentKey IsNot Nothing AndAlso PurchaseOrder.POPDetails.Item(i).CommentKey.ToString.Trim <> String.Empty Then
        '                CommentKey = New GP10Service.CommentKey
        '                CommentKey.Id = PurchaseOrder.POPDetails.Item(i).CommentKey
        '                purchaseOrderLine.CommentKey = CommentKey
        '            End If

        '            If PurchaseOrder.POPDetails.Item(i).CommentText IsNot Nothing AndAlso PurchaseOrder.POPDetails.Item(i).CommentText.ToString.Trim <> String.Empty Then
        '                purchaseOrderLine.Comment = PurchaseOrder.POPDetails.Item(i).CommentText
        '            End If

        '            purchaseOrderLine.RequestedDate = IIf(PurchaseOrder.POPDetails.Item(i).RequestedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(PurchaseOrder.POPDetails.Item(i).RequestedDate.ToShortDateString))

        '            purchaseOrderLines(i) = purchaseOrderLine
        '        Next

        '        purchaseOrder.Lines = purchaseOrderLines
        '        purchaseOrderCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreatePurchaseOrder", context)
        '        objGPConfiguration.GPWS10.CreatePurchaseOrder(purchaseOrder, context, purchaseOrderCreatePolicy)

        '        Return GPPONumber
        '    Catch ex As Exception
        '        Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
        '    End Try


        'End Function


        ''' <summary>
        ''' Creates a POP Purchase Order GP
        ''' </summary>
        ''' <param name="POTrx"></param>
        ''' <param name="GPConfiguration"></param>
        ''' <returns>
        ''' PO Number Created or empty if failure
        ''' </returns>
        ''' <remarks></remarks>
        Private Function CreateGP2010PurchaseOrder(ByVal POTrx As POP.POPTransaction, ByVal GPConfiguration As GPSystemConfiguration) As String

            Dim CompanyKey As GP2010Service.CompanyKey
            Dim Context As GP2010Service.Context
            Dim PurchaseOrderKey As GP2010Service.PurchaseTransactionKey
            Dim VendorKey As GP2010Service.VendorKey
            Dim GPPO As GP2010Service.PurchaseOrder
            Dim PurchaseOrderLines As GP2010Service.PurchaseOrderLine()
            Dim GPPOLine As GP2010Service.PurchaseOrderLine
            Dim warehouseKey As GP2010Service.WarehouseKey
            Dim QuantityOrdered As GP2010Service.Quantity
            Dim purchaseOrderCreatePolicy As GP2010Service.Policy
            Dim PurchaseAddress As GP2010Service.BusinessAddress
            Dim ShipToAddress As GP2010Service.BusinessAddress
            Dim PhoneNum As GP2010Service.PhoneNumber
            Dim BuyerKey As GP2010Service.BuyerKey
            Dim itemKey As GP2010Service.ItemKey
            Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
            Dim CommentKey As GP2010Service.CommentKey
            Dim ShippingMethodKey As GP2010Service.ShippingMethodKey
            Dim MoneyAmount As GP2010Service.MoneyAmount
            Dim GPPONumber As String = String.Empty

            Dim POHdr As POPHeader
            Dim POLines As POPDetails



            'init exceptions collection
            Me.Exceptions = New System.Collections.ObjectModel.Collection(Of MSGPWSIntegrationException)

            Try
                If POTrx Is Nothing Then
                    Throw New MSGPWSIntegrationException("No POTransaction provided")
                End If
                If POTrx.POPHeader Is Nothing Then
                    Throw New MSGPWSIntegrationException("POTrx.POHeader is nothing")
                End If
                If POTrx.POPDetails Is Nothing OrElse POTrx.POPDetails.Count = 0 Then
                    Throw New MSGPWSIntegrationException("POTrx.PODetails is nothing or contains no PO lines")
                End If
                POHdr = POTrx.POPHeader
                POLines = POTrx.POPDetails

                If String.IsNullOrEmpty(POTrx.POPHeader.PONumber) Then
                    Throw New Exception("Please provide a PO number")
                    'GPPONumber = MSGP2010eConnectIntegration.CommonLogic.GetNextPOPPurchaseOrderDocNumber(GPConfiguration.eConnectConnectionString)
                Else
                    GPPONumber = POTrx.POPHeader.PONumber
                End If

                'build GP Context
                Context = GPConfiguration.GP2010GetContext
                CompanyKey = GPConfiguration.GP2010GetCompanyKey
                GPPO = New GP2010Service.PurchaseOrder

                With GPPO
                    .Key = New GP2010Service.PurchaseTransactionKey
                    .Key.Id = GPPONumber
                    .VendorKey = New GP2010Service.VendorKey
                    .VendorKey.Id = POHdr.VendorID
                    If POHdr.OrderDate.HasValue Then
                        .Date = POHdr.OrderDate.Value.Date
                    End If
                    If Not String.IsNullOrEmpty(POHdr.VendorName) Then
                        .VendorName = POHdr.VendorName
                    End If
                    .Type = POHdr.POType
                    If Not String.IsNullOrEmpty(POHdr.BuyerID) Then
                        .BuyerKey = New GP2010Service.BuyerKey
                        .BuyerKey.Id = POHdr.BuyerID
                    End If
                    If POHdr.RequestedShipDate.HasValue Then
                        .RequestedDate = POHdr.RequestedShipDate.Value.Date
                    End If
                    If Not String.IsNullOrEmpty(POHdr.ShipMethod) Then
                        .ShippingMethodKey = New GP2010Service.ShippingMethodKey
                        .ShippingMethodKey.Id = POHdr.ShipMethod
                    End If
                    If Not String.IsNullOrEmpty(POHdr.PaymentTerms) Then
                        .PaymentTermsKey = New GP2010Service.PaymentTermsKey
                        .PaymentTermsKey.Id = POHdr.PaymentTerms
                    End If
                    If Not String.IsNullOrEmpty(POHdr.CommentID) Then
                        .CommentKey = New GP2010Service.CommentKey
                        .CommentKey.Id = POHdr.CommentID
                    End If
                    If Not String.IsNullOrEmpty(POHdr.Comment) Then
                        .Comment = POHdr.Comment
                    End If
                    .DoesAllowSalesOrderCommitments = POHdr.DoesAllowSalesOrderCommitments
                    If POHdr.PurchaseAddress IsNot Nothing Then
                        .PurchaseAddress = New GP2010Service.BusinessAddress
                        With .PurchaseAddress
                            .Name = POHdr.PurchaseAddress.Name
                            .Line1 = POHdr.PurchaseAddress.Address1
                            .Line2 = POHdr.PurchaseAddress.Address2
                            .Line3 = POHdr.PurchaseAddress.Address3
                            .City = POHdr.PurchaseAddress.City
                            .State = POHdr.PurchaseAddress.State
                            .PostalCode = POHdr.PurchaseAddress.Zip
                            .CountryRegion = POHdr.PurchaseAddress.Country
                            .ContactPerson = POHdr.PurchaseAddress.ContactPerson
                            .Phone1 = New GP2010Service.PhoneNumber
                            .Phone1.Value = POHdr.PurchaseAddress.PhoneNumber
                        End With
                    End If
                    If POHdr.ShipToAddress IsNot Nothing Then
                        .ShipToAddress = New GP2010Service.BusinessAddress
                        With .ShipToAddress
                            .Name = POHdr.ShipToAddress.Name
                            .Line1 = POHdr.ShipToAddress.Address1
                            .Line2 = POHdr.ShipToAddress.Address2
                            .Line3 = POHdr.ShipToAddress.Address3
                            .City = POHdr.ShipToAddress.City
                            .State = POHdr.ShipToAddress.State
                            .PostalCode = POHdr.ShipToAddress.Zip
                            .CountryRegion = POHdr.ShipToAddress.Country
                            .ContactPerson = POHdr.ShipToAddress.ContactPerson
                            .Phone1 = New GP2010Service.PhoneNumber
                            .Phone1.Value = POHdr.ShipToAddress.PhoneNumber
                        End With
                    End If

                    'do line items
                    ReDim PurchaseOrderLines(POLines.Count - 1) '=GP2010Service.PurchaseOrderLine
                    Dim POL As POPDetail
                    For l As Integer = 0 To POLines.Count - 1
                        GPPOLine = New GP2010Service.PurchaseOrderLine
                        POL = POLines(l)
                        With GPPOLine
                            If Not String.IsNullOrEmpty(POL.UOM) Then
                                .UofM = POL.UOM
                            End If
                            If Not String.IsNullOrEmpty(POL.InventoryGLAccount) Then
                                .InventoryGLAccountKey = New GP2010Service.GLAccountNumberKey
                                With .InventoryGLAccountKey
                                    .Id = POL.InventoryGLAccount
                                End With
                            End If

                            .VendorItemNumber = POL.ItemNumber
                            .QuantityOrdered = New GP2010Service.Quantity
                            .QuantityOrdered.Value = POL.Quantity
                            If Not String.IsNullOrEmpty(POL.SiteID) Then
                                .WarehouseKey = New GP2010Service.WarehouseKey
                                .WarehouseKey.Id = POL.SiteID
                            End If
                            .UnitCost = New GP2010Service.MoneyAmount
                            .UnitCost.Currency = GPConfiguration.CurrencyCode
                            .UnitCost.Value = POL.UnitCost
                            .ExtendedCost = New GP2010Service.MoneyAmount
                            .ExtendedCost.Currency = GPConfiguration.CurrencyCode
                            If POL.ExtendedCost.HasValue Then
                                .ExtendedCost.Value = POL.ExtendedCost
                            Else
                                .ExtendedCost.Value = POL.Quantity * POL.UnitCost
                            End If

                            If Not String.IsNullOrEmpty(POL.CommentKey) Then
                                .CommentKey = New GP2010Service.CommentKey
                                .CommentKey.Id = POL.CommentKey
                            End If
                            If Not String.IsNullOrEmpty(POL.CommentText) Then
                                .Comment = POL.CommentText
                            End If
                            If POL.RequestedDate.HasValue Then
                                .RequestedDate = POL.RequestedDate.Value.Date.ToShortDateString
                            End If
                        End With
                        PurchaseOrderLines(l) = GPPOLine
                    Next
                    .Lines = PurchaseOrderLines
                End With
                purchaseOrderCreatePolicy = GPConfiguration.GPWS2010.GetPolicyByOperation("CreatePurchaseOrder", Context)
                GPConfiguration.GPWS2010.CreatePurchaseOrder(GPPO, Context, purchaseOrderCreatePolicy)
                Return GPPONumber

            Catch ex As MSGPWSIntegrationException
                Me.Exceptions.Add(ex)

            Catch ex As Exception
                Throw ex

            End Try



            'With POTrx

            '    'Create PO Header
            '    purchaseOrder.Date = IIf(.POPHeader.OrderDate.Year < 1901, Date.Parse(Date.Today.ToShortDateString), Date.Parse(.POPHeader.OrderDate.ToShortDateString))

            '    VendorKey = New GP2010Service.VendorKey
            '    VendorKey.Id = .POPHeader.VendorID
            '    purchaseOrder.VendorKey = VendorKey

            '    If .POPHeader.VendorName IsNot Nothing AndAlso .POPHeader.VendorName.ToString.Trim <> String.Empty Then
            '        purchaseOrder.VendorName = .POPHeader.VendorName
            '    End If

            '    purchaseOrder.Type = .POPHeader.POType

            '    If .POPHeader.BuyerID IsNot Nothing AndAlso .POPHeader.BuyerID.ToString.Trim <> String.Empty Then
            '        BuyerKey = New GP2010Service.BuyerKey
            '        BuyerKey.Id = .POPHeader.BuyerID
            '        purchaseOrder.BuyerKey = BuyerKey
            '    End If

            '    purchaseOrder.RequestedDate = IIf(.POPHeader.RequestedShipDate <= Today, Nothing, Date.Parse(.POPHeader.RequestedShipDate.ToShortDateString))

            '    If .POPHeader.ShipMethod IsNot Nothing AndAlso .POPHeader.ShipMethod.ToString.Trim <> String.Empty Then
            '        ShippingMethodKey = New GP2010Service.ShippingMethodKey
            '        ShippingMethodKey.Id = .POPHeader.ShipMethod
            '        purchaseOrder.ShippingMethodKey = ShippingMethodKey
            '    End If

            '    If .POPHeader.PaymentTerms IsNot Nothing AndAlso .POPHeader.PaymentTerms.ToString.Trim <> String.Empty Then
            '        PaymentTermsKey = New GP2010Service.PaymentTermsKey
            '        PaymentTermsKey.Id = .POPHeader.PaymentTerms
            '        purchaseOrder.PaymentTermsKey = PaymentTermsKey
            '    End If

            '    If .POPHeader.CommentID IsNot Nothing AndAlso .POPHeader.CommentID.ToString.Trim <> String.Empty Then
            '        CommentKey = New GP2010Service.CommentKey
            '        CommentKey.Id = .POPHeader.CommentID
            '        purchaseOrder.CommentKey = CommentKey
            '    End If

            '    If .POPHeader.Comment IsNot Nothing AndAlso .POPHeader.Comment.ToString.Trim <> String.Empty Then
            '        purchaseOrder.Comment = .POPHeader.Comment
            '    End If

            '    purchaseOrder.DoesAllowSalesOrderCommitments = .POPHeader.DoesAllowSalesOrderCommitments

            '    PurchaseAddress = New GP2010Service.BusinessAddress
            '    With PurchaseAddress
            '        .Name = POTrx.POPHeader.PurchaseAddress.Name
            '        .Line1 = POTrx.POPHeader.PurchaseAddress.Address1
            '        .Line2 = POTrx.POPHeader.PurchaseAddress.Address2
            '        .Line3 = POTrx.POPHeader.PurchaseAddress.Address3
            '        .City = POTrx.POPHeader.PurchaseAddress.City
            '        .State = POTrx.POPHeader.PurchaseAddress.State
            '        .PostalCode = POTrx.POPHeader.PurchaseAddress.Zip
            '        .CountryRegion = POTrx.POPHeader.PurchaseAddress.Country
            '        .ContactPerson = POTrx.POPHeader.PurchaseAddress.ContactPerson
            '        PhoneNum = New GP2010Service.PhoneNumber
            '        PhoneNum.Value = POTrx.POPHeader.PurchaseAddress.PhoneNumber
            '        .Phone1 = PhoneNum
            '    End With
            '    purchaseOrder.PurchaseAddress = PurchaseAddress

            '    ShipToAddress = New GP2010Service.BusinessAddress
            '    With PurchaseAddress
            '        .Name = POTrx.POPHeader.ShipToAddress.Name
            '        .Line1 = POTrx.POPHeader.ShipToAddress.Address1
            '        .Line2 = POTrx.POPHeader.ShipToAddress.Address2
            '        .Line3 = POTrx.POPHeader.ShipToAddress.Address3
            '        .City = POTrx.POPHeader.ShipToAddress.City
            '        .State = POTrx.POPHeader.ShipToAddress.State
            '        .PostalCode = POTrx.POPHeader.ShipToAddress.Zip
            '        .CountryRegion = POTrx.POPHeader.ShipToAddress.Country
            '        .ContactPerson = POTrx.POPHeader.ShipToAddress.ContactPerson
            '        PhoneNum = New GP2010Service.PhoneNumber
            '        PhoneNum.Value = POTrx.POPHeader.ShipToAddress.PhoneNumber
            '        .Phone1 = PhoneNum
            '    End With
            '    purchaseOrder.ShipToAddress = ShipToAddress
            'End With
            ''Create PO line Items
            'ReDim PurchaseOrderLines(POTrx.POPDetails.Count - 1)

            'For i As Integer = 0 To POTrx.POPDetails.Count - 1

            '    purchaseOrderLine = New GP2010Service.PurchaseOrderLine

            '    itemKey = New GP2010Service.ItemKey
            '    itemKey.Id = POTrx.POPDetails.Item(i).ItemNumber
            '    purchaseOrderLine.ItemKey = itemKey

            '    QuantityOrdered = New GP2010Service.Quantity
            '    QuantityOrdered.Value = POTrx.POPDetails.Item(i).Quantity
            '    purchaseOrderLine.QuantityOrdered = QuantityOrdered

            '    If POTrx.POPDetails.Item(i).UOM IsNot Nothing AndAlso POTrx.POPDetails.Item(i).UOM.ToString.Trim <> String.Empty Then
            '        purchaseOrderLine.UofM = POTrx.POPDetails.Item(i).UOM
            '    End If

            '    If POTrx.POPDetails.Item(i).SiteID IsNot Nothing AndAlso POTrx.POPDetails.Item(i).SiteID.ToString.Trim <> String.Empty Then
            '        warehouseKey = New GP2010Service.WarehouseKey
            '        warehouseKey.Id = POTrx.POPDetails.Item(i).SiteID
            '        purchaseOrderLine.WarehouseKey = warehouseKey
            '    End If

            '    MoneyAmount = New GP2010Service.MoneyAmount
            '    MoneyAmount.Value = POTrx.POPDetails.Item(i).UnitCost
            '    MoneyAmount.Currency = GPConfiguration.CurrencyCode
            '    purchaseOrderLine.UnitCost = MoneyAmount

            '    MoneyAmount = New GP2010Service.MoneyAmount
            '    MoneyAmount.Value = POTrx.POPDetails.Item(i).ExtendedCost
            '    MoneyAmount.Currency = GPConfiguration.CurrencyCode
            '    purchaseOrderLine.ExtendedCost = MoneyAmount

            '    If POTrx.POPDetails.Item(i).CommentKey IsNot Nothing AndAlso POTrx.POPDetails.Item(i).CommentKey.ToString.Trim <> String.Empty Then
            '        CommentKey = New GP2010Service.CommentKey
            '        CommentKey.Id = POTrx.POPDetails.Item(i).CommentKey
            '        purchaseOrderLine.CommentKey = CommentKey
            '    End If

            '    If POTrx.POPDetails.Item(i).CommentText IsNot Nothing AndAlso POTrx.POPDetails.Item(i).CommentText.ToString.Trim <> String.Empty Then
            '        purchaseOrderLine.Comment = POTrx.POPDetails.Item(i).CommentText
            '    End If

            '    purchaseOrderLine.RequestedDate = IIf(POTrx.POPDetails.Item(i).RequestedDate.Year < 1901, Date.Parse("1/1/1900"), Date.Parse(POTrx.POPDetails.Item(i).RequestedDate.ToShortDateString))

            '    PurchaseOrderLines(i) = purchaseOrderLine
            'Next

            'purchaseOrder.Lines = PurchaseOrderLines
            'purchaseOrderCreatePolicy = GPConfiguration.GPWS2010.GetPolicyByOperation("CreatePurchaseOrder", Context)
            'GPConfiguration.GPWS2010.CreatePurchaseOrder(purchaseOrder, Context, purchaseOrderCreatePolicy)


            '    Return GPPONumber

            'Catch ex As MSGPWSIntegrationException
            '    Me.Exceptions.Add(ex)

            'Catch ex As Exception
            '    Throw ex

            'End Try


        End Function


        Private Function CreateGP2010PurchaseReceipt(ByVal POTrx As POP.POPReceiptTransaction, ByVal GPConfiguration As GPSystemConfiguration) As String
            Dim CompanyKey As GP2010Service.CompanyKey
            Dim Context As GP2010Service.Context
            Dim GPPOR As GP2010Service.PurchaseReceipt
            Dim GPPORLines As GP2010Service.PurchaseReceiptLine()
            Dim GPPORLIne As GP2010Service.PurchaseReceiptLine
            Dim PurchaseOrderReceiptCreatePolicy As GP2010Service.Policy
            Dim GPPORNumber As String = String.Empty
            Dim PORHdr As POPReceipt
            Dim PORLines As POPReceiptLines



            'init exceptions collection
            Me.Exceptions = New System.Collections.ObjectModel.Collection(Of MSGPWSIntegrationException)

            Try
                If POTrx Is Nothing Then
                    Throw New MSGPWSIntegrationException("No POTransaction provided")
                End If
                If POTrx.ReceiptHeader Is Nothing Then
                    Throw New MSGPWSIntegrationException("PO Receipt is nothing")
                End If
                If POTrx.ReceiptLines Is Nothing OrElse POTrx.ReceiptLines.Count = 0 Then
                    Throw New MSGPWSIntegrationException("PO Receipts contains no PO lines")
                End If
                PORHdr = POTrx.ReceiptHeader
                PORLines = POTrx.ReceiptLines

                If String.IsNullOrEmpty(POTrx.ReceiptHeader.ReceiptNumber) Then
                    Throw New Exception("Please provide A Receipt Number")
                    'GPPORNumber = MSGP2010eConnectIntegration.CommonLogic.GetNextPOPReceiptDocNumber(GPConfiguration.eConnectConnectionString)
                Else
                    GPPORNumber = POTrx.ReceiptHeader.ReceiptNumber
                End If

                'build GP Context
                Context = GPConfiguration.GP2010GetContext
                CompanyKey = GPConfiguration.GP2010GetCompanyKey
                GPPOR = New GP2010Service.PurchaseReceipt

                With GPPOR
                    .Key = New GP2010Service.PurchaseTransactionKey
                    .Key.Id = GPPORNumber
                    .VendorKey = New GP2010Service.VendorKey
                    .VendorKey.Id = PORHdr.VendorId
                    If PORHdr.ReceiptDate.HasValue Then
                        .Date = PORHdr.ReceiptDate
                    End If

                    If PORHdr.ReceiptDate.HasValue Then
                        .Date = PORHdr.ReceiptDate.Value.Date
                    End If
                    If Not String.IsNullOrEmpty(PORHdr.VendorName) Then
                        .VendorName = PORHdr.VendorName
                    End If

                    'do line items
                    ReDim GPPORLines(PORLines.Count - 1) '=GP2010Service.PurchaseOrderLine
                    Dim PORL As POPReceiptLine
                    For l As Integer = 0 To PORLines.Count - 1
                        GPPORLIne = New GP2010Service.PurchaseReceiptLine
                        PORL = PORLines(l)
                        With GPPORLIne
                            If Not String.IsNullOrEmpty(PORL.UnitOfMeasure) Then
                                .UofM = PORL.UnitOfMeasure
                            End If
                            If Not String.IsNullOrEmpty(PORL.InventoryGLAccount) Then
                                .InventoryGLAccountKey = New GP2010Service.GLAccountNumberKey
                                With .InventoryGLAccountKey
                                    .Id = PORL.InventoryGLAccount
                                End With
                            End If

                            .VendorItemNumber = PORL.ItemNumber
                            .QuantityShipped = New GP2010Service.Quantity
                            .QuantityShipped.Value = PORL.QuantityShipped
                            If Not String.IsNullOrEmpty(PORL.SiteId) Then
                                .WarehouseKey = New GP2010Service.WarehouseKey
                                .WarehouseKey.Id = PORL.SiteId
                            End If
                            .UnitCost = New GP2010Service.MoneyAmount
                            .UnitCost.Currency = GPConfiguration.CurrencyCode
                            .UnitCost.Value = PORL.UnitCost
                            .ExtendedCost = New GP2010Service.MoneyAmount
                            .ExtendedCost.Currency = GPConfiguration.CurrencyCode
                            If PORL.ExtendedCost.HasValue Then
                                .ExtendedCost.Value = PORL.ExtendedCost
                            Else
                                .ExtendedCost.Value = PORL.QuantityShipped * PORL.UnitCost
                            End If

               
                        End With
                        GPPORLines(l) = GPPORLIne
                    Next
                    .Lines = GPPORLines
                End With
                PurchaseOrderReceiptCreatePolicy = GPConfiguration.GPWS2010.GetPolicyByOperation("CreatePurchaseReceipt", Context)
                GPConfiguration.GPWS2010.CreatePurchaseReceipt(GPPOR, Context, PurchaseOrderReceiptCreatePolicy)
                Return GPPORNumber

            Catch ex As MSGPWSIntegrationException
                Me.Exceptions.Add(ex)

            Catch ex As Exception
                Throw ex

            End Try



        End Function

        Private Function CreateGP2010PurchaseInvoice(ByVal POTrx As POP.POPReceiptTransaction, ByVal GPConfiguration As GPSystemConfiguration) As String

            Dim CompanyKey As GP2010Service.CompanyKey
            Dim Context As GP2010Service.Context
            Dim PurchaseOrderKey As GP2010Service.PurchaseTransactionKey
            Dim VendorKey As GP2010Service.VendorKey
            Dim GPPOR As GP2010Service.PurchaseInvoice
            Dim GPPORLines As GP2010Service.PurchaseInvoiceLine()
            Dim GPPORLIne As GP2010Service.PurchaseInvoiceLine
            Dim warehouseKey As GP2010Service.WarehouseKey
            Dim QuantityOrdered As GP2010Service.Quantity
            Dim PurchaseOrderReceiptCreatePolicy As GP2010Service.Policy
            Dim PurchaseAddress As GP2010Service.BusinessAddress
            Dim ShipToAddress As GP2010Service.BusinessAddress
            Dim PhoneNum As GP2010Service.PhoneNumber
            Dim BuyerKey As GP2010Service.BuyerKey
            Dim itemKey As GP2010Service.ItemKey
            Dim PaymentTermsKey As GP2010Service.PaymentTermsKey
            Dim CommentKey As GP2010Service.CommentKey
            Dim ShippingMethodKey As GP2010Service.ShippingMethodKey
            Dim MoneyAmount As GP2010Service.MoneyAmount
            Dim GPPORNumber As String = String.Empty

            Dim PORHdr As POPReceipt
            Dim PORLines As POPReceiptLines



            'init exceptions collection
            Me.Exceptions = New System.Collections.ObjectModel.Collection(Of MSGPWSIntegrationException)

            Try
                If POTrx Is Nothing Then
                    Throw New MSGPWSIntegrationException("No POTransaction provided")
                End If
                If POTrx.ReceiptHeader Is Nothing Then
                    Throw New MSGPWSIntegrationException("PO Receipt is nothing")
                End If
                If POTrx.ReceiptLines Is Nothing OrElse POTrx.ReceiptLines.Count = 0 Then
                    Throw New MSGPWSIntegrationException("PO Receipts contains no PO lines")
                End If
                PORHdr = POTrx.ReceiptHeader
                PORLines = POTrx.ReceiptLines

                If String.IsNullOrEmpty(POTrx.ReceiptHeader.ReceiptNumber) Then
                    Throw New Exception("Please provide A Receipt Number")
                    'GPPORNumber = MSGP2010eConnectIntegration.CommonLogic.GetNextPOPReceiptDocNumber(GPConfiguration.eConnectConnectionString)
                Else
                    GPPORNumber = POTrx.ReceiptHeader.ReceiptNumber
                End If

                'build GP Context
                Context = GPConfiguration.GP2010GetContext
                CompanyKey = GPConfiguration.GP2010GetCompanyKey
                GPPOR = New GP2010Service.PurchaseInvoice

                With GPPOR
                    .Key = New GP2010Service.PurchaseTransactionKey
                    .Key.Id = GPPORNumber
                    .VendorKey = New GP2010Service.VendorKey
                    .VendorKey.Id = PORHdr.VendorId
                    .VendorDocumentNumber = PORHdr.ReceiptNumber
                    If PORHdr.ReceiptDate.HasValue Then
                        .Date = PORHdr.ReceiptDate
                    End If

                    If PORHdr.ReceiptDate.HasValue Then
                        .Date = PORHdr.ReceiptDate.Value.Date
                    End If
                    If Not String.IsNullOrEmpty(PORHdr.VendorName) Then
                        .VendorName = PORHdr.VendorName
                    End If

                    'do line items
                    ReDim GPPORLines(PORLines.Count - 1) '=GP2010Service.PurchaseOrderLine
                    Dim PORL As POPReceiptLine
                    For l As Integer = 0 To PORLines.Count - 1
                        GPPORLIne = New GP2010Service.PurchaseInvoiceLine
                        PORL = PORLines(l)
                        With GPPORLIne
                            If Not String.IsNullOrEmpty(PORL.UnitOfMeasure) Then
                                .UofM = PORL.UnitOfMeasure
                            End If
                  

                            .VendorItemNumber = PORL.ItemNumber
                            .QuantityInvoiced = New GP2010Service.Quantity
                            .QuantityInvoiced.Value = PORL.QuantityInvoiced
                            'If Not String.IsNullOrEmpty(PORL.SiteId) Then
                            '    .WarehouseKey = New GP2010Service.WarehouseKey
                            '    .WarehouseKey.Id = PORL.SiteId
                            'End If
                            .UnitCost = New GP2010Service.MoneyAmount
                            .UnitCost.Currency = GPConfiguration.CurrencyCode
                            .UnitCost.Value = PORL.UnitCost
                            .ExtendedCost = New GP2010Service.MoneyAmount
                            .ExtendedCost.Currency = GPConfiguration.CurrencyCode
                            If PORL.ExtendedCost.HasValue Then
                                .ExtendedCost.Value = PORL.ExtendedCost
                            Else
                                .ExtendedCost.Value = PORL.QuantityShipped * PORL.UnitCost
                            End If


                        End With
                        GPPORLines(l) = GPPORLIne
                    Next
                    .Lines = GPPORLines
                End With
                PurchaseOrderReceiptCreatePolicy = GPConfiguration.GPWS2010.GetPolicyByOperation("CreatePurchaseInvoice", Context)
                GPConfiguration.GPWS2010.CreatePurchaseInvoice(GPPOR, Context, PurchaseOrderReceiptCreatePolicy)
                Return GPPORNumber

            Catch ex As MSGPWSIntegrationException
                Me.Exceptions.Add(ex)

            Catch ex As Exception
                Throw ex

            End Try



        End Function

    End Class
End Namespace
