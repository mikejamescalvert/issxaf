Imports GP2010Service = MSGPWSIntegration.DynamicsWCFService
Imports System.Runtime.InteropServices

Namespace IV
    Public Class IVFactory

        ''' <summary>
        ''' Creats a GP Vendor
        ''' </summary>
        ''' <param name="objItemVendor"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPItemVendor(ByVal objItemVendor As IVItemVendor, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10ItemVendor(objItemVendor, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010ItemVendor(objItemVendor, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Creates a GP 10 Vendor
        ''' </summary>
        ''' <param name="objItemVendor"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10ItemVendor(ByVal objItemVendor As IVItemVendor, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim itemVendor As GP10Service.ItemVendor
                Dim itemKey As GP10Service.ItemKey
                Dim vendorKey As GP10Service.VendorKey
                Dim itemVendorKey As GP10Service.ItemVendorKey
                Dim itemVendorCreatePolicy As GP10Service.Policy
                Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                'Helper.SetupWSWithConfiguration(objItemVendor.GPSystemConfiguration)
                'If Helper.wsDynamicsGP Is Nothing Then
                '    Helper.wsDynamicsGP = New MSGPWSIntegration.DynamicsWCFService.DynamicsGPClient("LegacyDynamicsGP", objItemVendor.GPSystemConfiguration.GPWSUrl)
                '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objItemVendor.GPSystemConfiguration.GPWSUserName, objItemVendor.GPSystemConfiguration.GPWSPassword, objItemVendor.GPSystemConfiguration.GPWSDomain)
                'End If

                context = New GP10Service.Context()
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId

                ' Set up the context object
                context.OrganizationKey = DirectCast(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"

                ' Create an item vendor object
                itemVendor = New GP10Service.ItemVendor()

                ' Create an item key to specify the item
                itemKey = New GP10Service.ItemKey()
                itemKey.Id = objItemVendor.ItemNumber

                ' Create a vendor key to specify the vendor
                vendorKey = New GP10Service.VendorKey()
                vendorKey.Id = objItemVendor.VendorKey

                ' Create an item vendor key
                itemVendorKey = New GP10Service.ItemVendorKey()
                itemVendorKey.ItemKey = itemKey
                itemVendorKey.VendorKey = vendorKey

                If Not String.IsNullOrEmpty(objItemVendor.VendorItemNumber) Then
                    itemVendor.VendorItemNumber = objItemVendor.VendorItemNumber
                End If

                If Not String.IsNullOrEmpty(objItemVendor.VendorItemDescription) Then
                    itemVendor.VendorItemDescription = objItemVendor.VendorItemDescription
                End If

                ' Populate the item vendor objects key property
                itemVendor.Key = itemVendorKey

                ' Get the create policy for item vendor
                itemVendorCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateItemVendor", context)
                objGPConfiguration.GPWS10.CreateItemVendor(itemVendor, context, itemVendorCreatePolicy)

                Return "Success"
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Creates a GP 2010 Vendor
        ''' </summary>
        ''' <param name="objItemVendor"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010ItemVendor(ByVal objItemVendor As IVItemVendor, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim itemVendor As GP2010Service.ItemVendor
                Dim itemKey As GP2010Service.ItemKey
                Dim vendorKey As GP2010Service.VendorKey
                Dim itemVendorKey As GP2010Service.ItemVendorKey
                Dim itemVendorCreatePolicy As GP2010Service.Policy
                'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
                'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity
                'Helper.SetupWSWithConfiguration(objItemVendor.GPSystemConfiguration)
                'If Helper.wsDynamicsGP Is Nothing Then
                '    Helper.wsDynamicsGP = New MSGPWSIntegration.DynamicsWCFService.DynamicsGPClient("LegacyDynamicsGP", objItemVendor.GPSystemConfiguration.GPWSUrl)
                '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objItemVendor.GPSystemConfiguration.GPWSUserName, objItemVendor.GPSystemConfiguration.GPWSPassword, objItemVendor.GPSystemConfiguration.GPWSDomain)
                'End If

                context = objGPConfiguration.GP2010GetContext
                companyKey = objGPConfiguration.GP2010GetCompanyKey

                ' Create an item vendor object
                itemVendor = New GP2010Service.ItemVendor()

                ' Create an item key to specify the item
                itemKey = New GP2010Service.ItemKey()
                itemKey.Id = objItemVendor.ItemNumber

                ' Create a vendor key to specify the vendor
                vendorKey = New GP2010Service.VendorKey()
                vendorKey.Id = objItemVendor.VendorKey

                ' Create an item vendor key
                itemVendorKey = New GP2010Service.ItemVendorKey()
                itemVendorKey.ItemKey = itemKey
                itemVendorKey.VendorKey = vendorKey

                If Not String.IsNullOrEmpty(objItemVendor.VendorItemNumber) Then
                    itemVendor.VendorItemNumber = objItemVendor.VendorItemNumber
                End If

                If Not String.IsNullOrEmpty(objItemVendor.VendorItemDescription) Then
                    itemVendor.VendorItemDescription = objItemVendor.VendorItemDescription
                End If

                ' Populate the item vendor objects key property
                itemVendor.Key = itemVendorKey

                ' Get the create policy for item vendor
                itemVendorCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateItemVendor", context)
                objGPConfiguration.GPWS2010.CreateItemVendor(itemVendor, context, itemVendorCreatePolicy)

                Return "Success"
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

        'TODO - neeed to deal with GP version selection
        Public Shared Function CreateGPItemSite(ByVal ItemSite As IVItemSite, ByVal objGPConfiguration As GPSystemConfiguration)
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim GPPolicy As GP2010Service.Policy
            context = New GP2010Service.Context()
            companyKey = New GP2010Service.CompanyKey
            companyKey.Id = objGPConfiguration.GPWSCompanyId

            ' Set up the context object
            context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
            context.CultureName = "en-US"

            Dim GPIVItemSite As New GP2010Service.ItemWarehouse
            With GPIVItemSite
                .Key = New GP2010Service.ItemWarehouseKey
                With .Key
                    .ItemKey = New GP2010Service.ItemKey
                    With .ItemKey
                        .Id = ItemSite.ItemKey
                    End With
                    .WarehouseKey = New GP2010Service.WarehouseKey
                    With .WarehouseKey
                        .Id = ItemSite.SiteId
                    End With

                End With
            End With
            ' Get the create policy for item vendor
            GPPolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateItemWarehouse", context)
            objGPConfiguration.GPWS2010.CreateItemWarehouse(GPIVItemSite, context, GPPolicy)

        End Function

        ''' <summary>
        ''' Create Sales Item in MS Great Plains
        ''' </summary>
        ''' <param name="objSalesItem"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns>string</returns>
        ''' <remarks></remarks>
        Public Shared Function CreateGPSalesItem(ByVal objSalesItem As IVSalesItem, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Select Case objGPConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return CreateGP10SalesItem(objSalesItem, objGPConfiguration)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return CreateGP2010SalesItem(objSalesItem, objGPConfiguration)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        ''' <summary>
        ''' Create Sales Item in MS Great Plains 10
        ''' </summary>
        ''' <param name="objSalesItem"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns>string</returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP10SalesItem(ByVal objSalesItem As IVSalesItem, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Dim companyKey As GP10Service.CompanyKey
            Dim context As GP10Service.Context
            Dim itemKey As GP10Service.ItemKey
            Dim unitOfMeasureKey As GP10Service.UofMScheduleKey
            Dim salesItem As GP10Service.SalesItem
            Dim salesItemCreatePolicy As GP10Service.Policy
            Dim ItemClassKey As GP10Service.ItemClassKey
            'Dim epaEndpointAddress As System.ServiceModel.EndpointAddress
            'Dim igeException As MSGPWSIntegration.MSGPWSIntegrationException
            'Dim epiEndpointIdentity As System.ServiceModel.EndpointIdentity

            'Dim plkPriceLevelKey As GP10Service.PriceLevelKey
            'Dim crkCurrencyKey As GP10Service.CurrencyKey
            'Dim prkPricingKey As GP10Service.PricingKey
            'Dim prcPricing As GP10Service.Pricing
            'Dim prdPricingDetail As GP10Service.PricingDetail
            'Dim pdkPricingDetailKey As GP10Service.PricingDetailKey
            'Dim qtyQuantity As GP10Service.Quantity
            'Dim pdpPricingDetailPrice As GP10Service.PricingDetailPrice
            'Dim praPriceAmount As GP10Service.MoneyAmount
            'Dim plcPricingCreatePolicy As GP10Service.Policy


            Try
                Helper.SetupWSWithConfiguration(objGPConfiguration)
                'If Helper.wsDynamicsGP Is Nothing Then
                '    Helper.wsDynamicsGP = New MSGPWSIntegration.GP10Service.DynamicsGPClient("LegacyDynamicsGP", objGPConfiguration.GPWSUrl)
                '    Helper.wsDynamicsGP.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(objGPConfiguration.GPWSUserName, objGPConfiguration.GPWSPassword, objGPConfiguration.GPWSDomain)
                'End If

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"

                ' Create a sales item object 
                salesItem = New GP10Service.SalesItem()

                ' Create a sales item key object to identify the sales item 
                If String.IsNullOrEmpty(objSalesItem.SalesItemKey.Trim) Then
                    Throw New ApplicationException("Sales Item Key Is Required.")
                ElseIf String.IsNullOrEmpty(objSalesItem.SalesItemDescription.Trim) Then
                    Throw New ApplicationException("Sales Item Description Is Required.")
                    'ElseIf String.IsNullOrEmpty(objSalesItem.UnitOfMeasure.Trim) Then
                    '    Throw New ApplicationException("Unit Of Measure Is Required.")
                End If

                itemKey = New GP10Service.ItemKey()
                itemKey.Id = objSalesItem.SalesItemKey

                salesItem.Key = itemKey
                salesItem.Description = objSalesItem.SalesItemDescription

                If Not String.IsNullOrEmpty(objSalesItem.UnitOfMeasureSchedule) Then
                    salesItem.UofMScheduleKey = New GP10Service.UofMScheduleKey()
                    salesItem.UofMScheduleKey.Id = objSalesItem.UnitOfMeasureSchedule
                End If



                If Not String.IsNullOrEmpty(objSalesItem.ItemClassKey.Trim) Then
                    ItemClassKey = New GP10Service.ItemClassKey
                    ItemClassKey.Id = objSalesItem.ItemClassKey
                    salesItem.ClassKey = ItemClassKey
                End If
      
                salesItem.PriceMethod = GP10Service.PriceMethod.CurrencyAmount

                ' Get the create policy for sales item 
                salesItemCreatePolicy = objGPConfiguration.GPWS10.GetPolicyByOperation("CreateSalesItem", context)

                ' Create the sales item 
                objGPConfiguration.GPWS10.CreateSalesItem(salesItem, context, salesItemCreatePolicy)

                'plkPriceLevelKey = New PriceLevelKey
                'plkPriceLevelKey.Id = objSalesItem.PricingLevelKey

                'crkCurrencyKey = New CurrencyKey
                'crkCurrencyKey.ISOCode = objSalesItem.CurrencyISOCode

                'prkPricingKey = New PricingKey
                'prkPricingKey.ItemKey = itemKey
                'prkPricingKey.PriceLevelKey = plkPriceLevelKey
                'prkPricingKey.CurrencyKey = crkCurrencyKey
                'prkPricingKey.UofM = objSalesItem.UnitOfMeasure

                'prcPricing = New Pricing
                'prcPricing.Key = prkPricingKey

                'prdPricingDetail = New PricingDetail
                'pdkPricingDetailKey = New PricingDetailKey
                'pdkPricingDetailKey.PricingKey = prkPricingKey

                'qtyQuantity = New Quantity
                'qtyQuantity.Value = 9999999999

                'pdkPricingDetailKey.ToQuantity = qtyQuantity
                'prdPricingDetail.Key = pdkPricingDetailKey

                'pdpPricingDetailPrice = New PricingDetailPrice

                'praPriceAmount = New MoneyAmount
                'praPriceAmount.Value = objSalesItem.Price
                'praPriceAmount.Currency = objSalesItem.CurrencyKey

                'pdpPricingDetailPrice.Item = praPriceAmount

                'prdPricingDetail.UofMPrice = pdpPricingDetailPrice

                'Dim prdPricingDetails As PricingDetail() = {prdPricingDetail}

                'prcPricing.Details = prdPricingDetails

                'plcPricingCreatePolicy = Helper.wsDynamicsGP.GetPolicyByOperation("CreatePricing", context)

                'Helper.wsDynamicsGP.CreatePricing(prcPricing, context, plcPricingCreatePolicy)

                Return "Success"
            Catch ex As Exception
                'igeException = New MSGPWSIntegration.MSGPWSIntegrationException("Error During Item Creation")
                'igeException.TargetException = ex
                Throw ex
            End Try

        End Function
        ''' <summary>
        ''' Create Sales Item in MS Great Plains 2010
        ''' </summary>
        ''' <param name="objSalesItem"></param>
        ''' <param name="objGPConfiguration"></param>
        ''' <returns>string</returns>
        ''' <remarks></remarks>
        Private Shared Function CreateGP2010SalesItem(ByVal objSalesItem As IVSalesItem, ByVal objGPConfiguration As GPSystemConfiguration) As String
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim itemKey As GP2010Service.ItemKey
            'Dim unitOfMeasureKey As GP2010Service.UofMScheduleKey
            Dim salesItem As GP2010Service.SalesItem
            Dim salesItemCreatePolicy As GP2010Service.Policy
            Dim ItemClassKey As GP2010Service.ItemClassKey
            Dim ItemSite As IVItemSite


            Try

                context = New GP2010Service.Context
                companyKey = New GP2010Service.CompanyKey
                companyKey.Id = objGPConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP2010Service.OrganizationKey)
                context.CultureName = "en-US"

                ' Create a sales item object 
                salesItem = New GP2010Service.SalesItem()

                ' Create a sales item key object to identify the sales item 
                If String.IsNullOrEmpty(objSalesItem.SalesItemKey.Trim) Then
                    Throw New ApplicationException("Sales Item Key Is Required.")
                ElseIf String.IsNullOrEmpty(objSalesItem.SalesItemDescription.Trim) Then
                    Throw New ApplicationException("Sales Item Description Is Required.")
                End If

                itemKey = New GP2010Service.ItemKey()
                itemKey.Id = objSalesItem.SalesItemKey

                salesItem.Key = itemKey
                salesItem.Description = objSalesItem.SalesItemDescription
                salesItem.ShortDescription = objSalesItem.SalesItemShortDescription

                If Not String.IsNullOrEmpty(objSalesItem.UnitOfMeasureSchedule) Then
                    salesItem.UofMScheduleKey = New GP2010Service.UofMScheduleKey
                    With salesItem.UofMScheduleKey
                        .Id = objSalesItem.UnitOfMeasureSchedule
                    End With
                End If

                If Not String.IsNullOrEmpty(objSalesItem.SellingUnitOfMeasure) Then
                    salesItem.DefaultSellingUofM = objSalesItem.SellingUnitOfMeasure
             
                End If


                If Not String.IsNullOrEmpty(objSalesItem.PurchaseUnitOfMeasure) Then
                    salesItem.PurchaseUofM = objSalesItem.PurchaseUnitOfMeasure
               
                End If

                If Not String.IsNullOrEmpty(objSalesItem.DefaultPricingLevelKey) Then
                    salesItem.DefaultPriceLevelKey = New GP2010Service.PriceLevelKey
                    With salesItem.DefaultPriceLevelKey
                        .Id = objSalesItem.DefaultPricingLevelKey
                    End With
                End If


                If Not String.IsNullOrEmpty(objSalesItem.ItemClassKey.Trim) Then
                    ItemClassKey = New GP2010Service.ItemClassKey
                    ItemClassKey.Id = objSalesItem.ItemClassKey
                    salesItem.ClassKey = ItemClassKey
                End If
                If Not String.IsNullOrEmpty(objSalesItem.DefaultSite) Then
                    salesItem.DefaultWarehouseKey = New GP2010Service.WarehouseKey
                    salesItem.DefaultWarehouseKey.Id = objSalesItem.DefaultSite
                End If
   
                ' Get the create policy for sales item 
                salesItemCreatePolicy = objGPConfiguration.GPWS2010.GetPolicyByOperation("CreateSalesItem", context)
                ' Create the sales item 
                objGPConfiguration.GPWS2010.CreateSalesItem(salesItem, context, salesItemCreatePolicy)


                'create list price
                If objSalesItem.Price.HasValue Then
                    IVFactory.CreateGP2010ItemListPrice(objGPConfiguration, objSalesItem.SalesItemKey, objGPConfiguration.CurrencyCode, objSalesItem.Price)
                End If
                'Create Pricing levels
                For Each ItemPrice As IVItemPrice In objSalesItem.Prices
                    IVFactory.CreateGP2010ItemPrice(objGPConfiguration,objSalesItem.SalesItemKey,ItemPrice)
                Next


                For Each SiteId As String In objSalesItem.ItemSites
                    'do not create default site if exists at item level, web service automatically creates this
                    If SiteId <> objSalesItem.DefaultSite Then
                        ItemSite = New IVItemSite
                        ItemSite.SiteId = SiteId
                        ItemSite.ItemKey = objSalesItem.SalesItemKey
                        IVFactory.CreateGPItemSite(ItemSite, objGPConfiguration)
                    End If

                Next

                Return "Success"
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Shared Function CreateGP2010ItemPrice(ByVal GPConfiguration As GPSystemConfiguration, ItemKey As String, ItemPrice As IVItemPrice)
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim GPPolicy As GP2010Service.Policy
            Dim GPIVItemPrice As GP2010Service.Pricing
            Dim GPIVItemPriceDetails As GP2010Service.PricingDetail()
            Dim GPIVItemPriceDetail As GP2010Service.PricingDetail
            context = New GP2010Service.Context()
            companyKey = New GP2010Service.CompanyKey


            If ItemPrice.ItemPriceDetails.Count = 0 Then
                Throw New MSGPWSIntegrationException("Item Price must have at least one ItemPrice Detail defined", "CreateGP2010ItemPrice")
            End If

            context = GPConfiguration.GP2010GetContext
            companyKey = GPConfiguration.GP2010GetCompanyKey

            GPIVItemPrice = New GP2010Service.Pricing
            With GPIVItemPrice
                .Key = New GP2010Service.PricingKey
                With .Key
                    .ItemKey = New GP2010Service.ItemKey
                    .ItemKey.Id = ItemKey
                    .CurrencyKey = New GP2010Service.CurrencyKey
                    .CurrencyKey.ISOCode = GPConfiguration.CurrencyCode
                    .PriceLevelKey = New GP2010Service.PriceLevelKey
                    .PriceLevelKey.Id = ItemPrice.PriceLevelKey
                    .UofM = ItemPrice.UnitOfMeasure
                End With
                ReDim GPIVItemPriceDetails(ItemPrice.ItemPriceDetails.Count - 1)
                Dim IPD As IVItemPriceDetail
                For j As Integer = 0 To ItemPrice.ItemPriceDetails.Count - 1
                    IPD = ItemPrice.ItemPriceDetails(j)
                    GPIVItemPriceDetail = New GP2010Service.PricingDetail
                    Dim MA As New GP2010Service.MoneyAmount
                    With MA
                        .Currency = GPConfiguration.CurrencyCode
                        .Value = IPD.Price
                        .DecimalDigits = 0
                    End With

                    With GPIVItemPriceDetail
                        .Key = New GP2010Service.PricingDetailKey
                        .Key.PricingKey = New GP2010Service.PricingKey
                        .Key.PricingKey = GPIVItemPrice.Key
                        'With .Key.PricingKey
                        '    .ItemKey = New GP2010Service.ItemKey
                        '    .ItemKey.Id = ItemKey
                        '    .CurrencyKey = New GP2010Service.CurrencyKey
                        '    .CurrencyKey.ISOCode = GPConfiguration.CurrencyCode
                        '    .PriceLevelKey = New GP2010Service.PriceLevelKey
                        '    .PriceLevelKey.Id = ItemPrice.PriceLevelKey
                        '    .UofM = ItemPrice.UnitOfMeasure
                        'End With
                        .Key.ToQuantity = New GP2010Service.Quantity
                        .Key.ToQuantity.Value = IPD.ToQuantity
                        .UofMPrice = New GP2010Service.PricingDetailPrice
                        .UofMPrice.Item = MA
                    End With
                    GPIVItemPriceDetails(j) = GPIVItemPriceDetail

                Next

            End With
            GPIVItemPrice.Details = GPIVItemPriceDetails

            GPPolicy = GPConfiguration.GPWS2010.GetPolicyByOperation("CreatePricing", context)
            GPConfiguration.GPWS2010.CreatePricing(GPIVItemPrice, context, GPPolicy)

        End Function

        'TODO - neeed to deal with GP version selection
        Public Shared Function CreateGP2010ItemListPrice(ByVal GPConfiguration As GPSystemConfiguration, ItemKey As String, CurrencyKey As String, ListPriceAmount As Double)
            Dim companyKey As GP2010Service.CompanyKey
            Dim context As GP2010Service.Context
            Dim GPPolicy As GP2010Service.Policy
            context = New GP2010Service.Context()
            companyKey = New GP2010Service.CompanyKey
            companyKey.Id = GPConfiguration.GPWSCompanyId

            ' Set up the context object
            context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
            context.CultureName = "en-US"

            Dim GPIVItemPrice As New GP2010Service.ItemCurrency
            With GPIVItemPrice
                .Key = New GP2010Service.ItemCurrencyKey
                With .Key
                    .ItemKey = New GP2010Service.ItemKey
                    .ItemKey.Id = ItemKey
                    .CurrencyKey = New GP2010Service.CurrencyKey
                    .CurrencyKey.ISOCode = GPConfiguration.CurrencyCode
                End With
                .ListPrice = New GP2010Service.MoneyAmount
                .ListPrice.Value = ListPriceAmount
                .ListPrice.Currency = GPConfiguration.CurrencyCode

            End With
            ' Get the create policy for item vendor
            GPPolicy = GPConfiguration.GPWS2010.GetPolicyByOperation("CreateItemCurrency", context)
            GPConfiguration.GPWS2010.CreateItemCurrency(GPIVItemPrice, context, GPPolicy)
        End Function



        ''' <summary>
        ''' Updates a GP Inventory Adjustment Transaction
        ''' </summary>
        ''' <param name="objInventoryAdjustment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateGPInventoryAdjustment(ByVal objInventoryAdjustment As IVInventoryAdjustment) As String
            Select Case objInventoryAdjustment.GPSystemConfiguration.GPVersion
                Case GPSystemConfiguration.AvailableGPVersions.GP10
                    Return UpdateGP10InventoryAdjustment(objInventoryAdjustment)
                Case GPSystemConfiguration.AvailableGPVersions.GP2010
                    Return UpdateGP2010InventoryAdjustment(objInventoryAdjustment)
                Case Else
                    Throw New NotImplementedException("Version not yet implemented by library")
            End Select
        End Function
        Private Shared Function UpdateGP10InventoryAdjustment(ByVal objInventoryAdjustment As IVInventoryAdjustment) As String
            Try
                Dim companyKey As GP10Service.CompanyKey
                Dim context As GP10Service.Context
                Dim inventoryAdjustmentKey As New GP10Service.InventoryKey
                Dim inventoryAdjustment As GP10Service.InventoryAdjustment
                Dim inventoryAdjustmentPolicy As GP10Service.Policy

                Helper.SetupWSWithConfiguration(objInventoryAdjustment.GPSystemConfiguration)

                context = New GP10Service.Context
                companyKey = New GP10Service.CompanyKey
                companyKey.Id = objInventoryAdjustment.GPSystemConfiguration.GPWSCompanyId
                context.OrganizationKey = CType(companyKey, GP10Service.OrganizationKey)
                context.CultureName = "en-US"

                With inventoryAdjustmentKey
                    .Id = objInventoryAdjustment.DocumentNumber
                End With

                '' Set up the context object
                'context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
                'context.CultureName = "en-US"

                ' Get the create policy for item vendor
                inventoryAdjustment = objInventoryAdjustment.GPSystemConfiguration.GPWS10.GetInventoryAdjustmentByKey(inventoryAdjustmentKey, context)
                With inventoryAdjustment
                    If objInventoryAdjustment.BatchID > String.Empty Then
                        .BatchKey = New GP10Service.BatchKey
                        .BatchKey.Id = objInventoryAdjustment.BatchID
                    End If
                    If objInventoryAdjustment.TransactionDate > Date.MinValue Then
                        .Date = objInventoryAdjustment.TransactionDate
                        .ModifiedDate = objInventoryAdjustment.TransactionDate
                    End If
                End With
                inventoryAdjustmentPolicy = objInventoryAdjustment.GPSystemConfiguration.GPWS10.GetPolicyByOperation("CreateInventoryAdjustment", context)
                objInventoryAdjustment.GPSystemConfiguration.GPWS10.CreateInventoryAdjustment(inventoryAdjustment, context, inventoryAdjustmentPolicy)

                Return "Success"
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function
        Private Shared Function UpdateGP2010InventoryAdjustment(ByVal objInventoryAdjustment As IVInventoryAdjustment) As String
            Try
                Dim companyKey As GP2010Service.CompanyKey
                Dim context As GP2010Service.Context
                Dim inventoryAdjustmentKey As New GP2010Service.InventoryKey
                Dim inventoryAdjustment As GP2010Service.InventoryAdjustment
                Dim inventoryAdjustmentPolicy As GP2010Service.Policy

                Helper.SetupWSWithConfiguration(objInventoryAdjustment.GPSystemConfiguration)

                context = New GP2010Service.Context()
                companyKey = New GP2010Service.CompanyKey
                companyKey.Id = objInventoryAdjustment.GPSystemConfiguration.GPWSCompanyId

                With inventoryAdjustmentKey
                    .CompanyKey = companyKey
                    .Id = objInventoryAdjustment.DocumentNumber
                End With

                ' Set up the context object
                context.OrganizationKey = DirectCast(companyKey, GP2010Service.OrganizationKey)
                context.CultureName = "en-US"

                ' Get the create policy for item vendor
                inventoryAdjustment = objInventoryAdjustment.GPSystemConfiguration.GPWS2010.GetInventoryAdjustmentByKey(inventoryAdjustmentKey, context)
                With inventoryAdjustment
                    If objInventoryAdjustment.BatchID > String.Empty Then
                        .BatchKey = New DynamicsWCFService.BatchKey
                        .BatchKey.CompanyKey = companyKey
                        .BatchKey.Id = objInventoryAdjustment.BatchID

                    End If
                    If objInventoryAdjustment.TransactionDate > Date.MinValue Then
                        .Date = objInventoryAdjustment.TransactionDate
                        .ModifiedDate = objInventoryAdjustment.TransactionDate
                    End If

                End With
                inventoryAdjustmentPolicy = objInventoryAdjustment.GPSystemConfiguration.GPWS2010.GetPolicyByOperation("CreateInventoryAdjustment", context)
                objInventoryAdjustment.GPSystemConfiguration.GPWS2010.CreateInventoryAdjustment(inventoryAdjustment, context, inventoryAdjustmentPolicy)

                Return "Success"
            Catch ex As Exception
                Throw New MSGPWSIntegration.MSGPWSIntegrationException(ex.Message)
            End Try
        End Function

    End Class
End Namespace
