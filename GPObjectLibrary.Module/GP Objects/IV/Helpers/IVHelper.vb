Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Net
Imports System.IO
Imports System.Reflection
Imports System.Data.SqlClient

Namespace Objects.IV.Helpers
    Public Class IVHelper
        Public Enum SerialLotTracking
            None = 1
            SerialNumber = 2
            LotNumber = 3
        End Enum
        Public Enum ItemAccountTypeDefinition
            InventoryOnHand
            InventoryOffset
            CostOfGoodsSold
            Sales
            Markdowns
            SalesReturns
            InUse
            InService
            Damaged
            Variance
            DropShipItems
            PurchasePriceVariance
            UnrealizedPurchasePriceVariance
            InventoryReturns
            AssemblyVariance

        End Enum

        ''' <summary>
        ''' Return the GL Account number for the item and account type
        ''' </summary>
        ''' <param name="Session"></param>
        ''' <param name="Item"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        Public Shared Function GetItemAccount(Session As Session, Item As IVItem, AccountType As ItemAccountTypeDefinition) As String
            Dim intAccountIndex As Integer
            Dim gpoGL As GL.GLAccountIndexMaster
            Select Case AccountType
                Case ItemAccountTypeDefinition.AssemblyVariance
                    intAccountIndex = Item.ASMVRIDX
                Case ItemAccountTypeDefinition.CostOfGoodsSold
                    intAccountIndex = Item.IVCOGSIX
                Case ItemAccountTypeDefinition.Damaged
                    intAccountIndex = Item.IVDMGIDX
                Case ItemAccountTypeDefinition.DropShipItems
                    intAccountIndex = Item.DPSHPIDX
                Case ItemAccountTypeDefinition.InService
                    intAccountIndex = Item.IVINSVIX
                Case ItemAccountTypeDefinition.InUse
                    intAccountIndex = Item.IVINUSIX
                Case ItemAccountTypeDefinition.InventoryOffset
                    intAccountIndex = Item.IVIVOFIX
                Case ItemAccountTypeDefinition.InventoryOnHand
                    intAccountIndex = Item.IVIVINDX
                Case ItemAccountTypeDefinition.InventoryReturns
                    intAccountIndex = Item.IVRETIDX
                Case ItemAccountTypeDefinition.Markdowns
                    intAccountIndex = Item.IVSLDSIX
                Case ItemAccountTypeDefinition.PurchasePriceVariance
                    intAccountIndex = Item.PURPVIDX
                Case ItemAccountTypeDefinition.Sales
                    intAccountIndex = Item.IVSLSIDX
                Case ItemAccountTypeDefinition.SalesReturns
                    intAccountIndex = Item.IVSLRNIX
                Case ItemAccountTypeDefinition.UnrealizedPurchasePriceVariance
                    intAccountIndex = Item.UPPVIDX
                Case ItemAccountTypeDefinition.Variance
                    intAccountIndex = Item.IVVARIDX
            End Select

            gpoGL = GL.Helpers.GLHelper.GetGLAccountIndexMasterByAccountIndex(Session, intAccountIndex)
            If gpoGL IsNot Nothing Then
                Return gpoGL.ACTNUMST
            End If
            Return Nothing
        End Function



        ''' <summary>
        ''' Returns a collection of item lot number information
        ''' </summary>
        ''' <param name="session"></param>
        ''' <param name="ItemNumber"></param>
        ''' <param name="Location"></param>
        ''' <param name="LotNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetItemLotDetails(ByVal session As Session, Optional ByVal ItemNumber As String = Nothing, Optional ByVal Location As String = Nothing, Optional ByVal LotNumber As String = Nothing) As XPCollection(Of IV.IVItemQuantityLot)

            Dim xpoGO As New GroupOperator

            With xpoGO.Operands
                If ItemNumber IsNot Nothing Then
                    .Add(New BinaryOperator("ITEMNMBR", ItemNumber, BinaryOperatorType.Equal))
                End If
                If Location IsNot Nothing Then
                    .Add(New BinaryOperator("LOCNCODE", Location, BinaryOperatorType.Equal))
                End If
                If LotNumber IsNot Nothing Then
                    .Add(New BinaryOperator("LOTNUMBR", LotNumber, BinaryOperatorType.Equal))
                End If

            End With
            Return New XPCollection(Of IVItemQuantityLot)(session, xpoGO)




        End Function

        Public Shared Function SeriaNumberExist(ByVal session As Session, ByVal ItemNumber As String, SerialNumber As String) As Boolean
            Dim xpoGO As New GroupOperator
            With xpoGO.Operands
                .Add(New BinaryOperator("ITEMNMBR", ItemNumber, BinaryOperatorType.Equal))
                .Add(New BinaryOperator("SERLNMBR", SerialNumber, BinaryOperatorType.Equal))
            End With
            Return session.FindObject(Of IVItemSerialNumber)(xpoGO) IsNot Nothing

        End Function


        ''' <summary>
        ''' Will return the quantity available for the item/location/lot number passed
        ''' if the item/location/lot cannot be found will return nothing
        ''' </summary>
        ''' <param name="session"></param>
        ''' <param name="ItemNumber"></param>
        ''' <param name="Location"></param>
        ''' <param name="LotNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetItemLotQty(ByVal session As Session, ByVal ItemNumber As String, ByVal Location As String, ByVal LotNumber As String) As Double?
            Dim dblRemainingQty As Double
            Dim xclItemLotQty As XPCollection(Of IVItemQuantityLot)
            Dim xpoGO As New GroupOperator
            With xpoGO.Operands
                .Add(New BinaryOperator("ITEMNMBR", ItemNumber, BinaryOperatorType.Equal))
                .Add(New BinaryOperator("LOCNCODE", Location, BinaryOperatorType.Equal))
                .Add(New BinaryOperator("LOTNUMBR", LotNumber, BinaryOperatorType.Equal))
            End With
            xclItemLotQty = New XPCollection(Of IVItemQuantityLot)(session, xpoGO)
            If xclItemLotQty.Count = 0 Then
                Return Nothing

            End If
            For Each xpoIQL As IVItemQuantityLot In xclItemLotQty
                dblRemainingQty += (xpoIQL.QTYRECVD - (xpoIQL.QTYSOLD + xpoIQL.ATYALLOC))
            Next
            Return dblRemainingQty
        End Function
        Public Shared Function GetKitItemsForParentItem(ByVal ParentItemNumber As String, ByVal session As Session) As XPCollection(Of IVKitItem)
            Dim gpoGroupOperator As New GroupOperator
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.ITEMNMBR", ParentItemNumber))
            Return New XPCollection(Of IVKitItem)(session, gpoGroupOperator)
        End Function
        Public Shared Function GetItemPriceByPriceLevelAndUOM(ByVal Session As Session, ByVal ItemCode As String, ByVal CurrencyCode As String, ByVal PriceLevel As String, ByVal UOM As String, ByVal Quantity As Decimal) As Decimal
            Dim xpoItem As IVItem = GetItem(Session, ItemCode)
            Dim xpoItemPrice As IVItemPriceList
            If xpoItem IsNot Nothing Then
                If CurrencyCode > String.Empty Then
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, PriceLevel, UOM, CurrencyCode, Quantity)
                Else
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, PriceLevel, UOM, Quantity)
                End If
                If xpoItemPrice IsNot Nothing Then
                    Return xpoItem.GetPriceForItemBasedOnMethod(xpoItemPrice.UOMPRICE, xpoItemPrice.QTYBSUOM)
                End If
            End If
            Return 0

        End Function
        Public Shared Function GetItemPriceByPriceLevel(ByVal Session As Session, ByVal ItemCode As String, ByVal CurrencyCode As String, ByVal PriceLevel As String, ByVal Quantity As Decimal) As Decimal
            Dim xpoItem As IVItem = GetItem(Session, ItemCode)
            Dim xpoItemPrice As IVItemPriceList
            If xpoItem IsNot Nothing Then
                If CurrencyCode > String.Empty Then
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, PriceLevel, xpoItem.SELNGUOM, CurrencyCode, Quantity)
                Else
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, PriceLevel, xpoItem.SELNGUOM, Quantity)
                End If
                If xpoItemPrice IsNot Nothing Then
                    Return xpoItem.GetPriceForItemBasedOnMethod(xpoItemPrice.UOMPRICE, xpoItemPrice.QTYBSUOM)
                End If
            End If
            Return 0

        End Function
        Public Shared Function GetItemPriceByUOM(ByVal Session As Session, ByVal ItemCode As String, ByVal CurrencyCode As String, ByVal UOM As String, ByVal Quantity As Decimal) As Decimal
            Dim xpoItem As IVItem = GetItem(Session, ItemCode)
            Dim xpoItemPrice As IVItemPriceList
            If xpoItem IsNot Nothing Then
                If CurrencyCode > String.Empty Then
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, xpoItem.PRCLEVEL, UOM, CurrencyCode, Quantity)
                Else
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, xpoItem.PRCLEVEL, UOM, Quantity)
                End If
                If xpoItemPrice IsNot Nothing Then
                    Return xpoItem.GetPriceForItemBasedOnMethod(xpoItemPrice.UOMPRICE, xpoItemPrice.QTYBSUOM)
                End If
            End If
            Return 0

        End Function
        Public Shared Function GetItemBasePrice(ByVal Session As Session, ByVal ItemCode As String, ByVal CurrencyCode As String, ByVal Quantity As Decimal) As Decimal
            Dim xpoItem As IVItem = GetItem(Session, ItemCode)
            Dim xpoItemPrice As IVItemPriceList
            If xpoItem IsNot Nothing Then
                If CurrencyCode > String.Empty Then
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, xpoItem.PRCLEVEL, xpoItem.SELNGUOM, CurrencyCode, Quantity)
                Else
                    xpoItemPrice = GetItemPriceListEntry(Session, xpoItem.ITEMNMBR, xpoItem.PRCLEVEL, xpoItem.SELNGUOM, Quantity)
                End If
                If xpoItemPrice IsNot Nothing Then
                    Return xpoItem.GetPriceForItemBasedOnMethod(xpoItemPrice.UOMPRICE, xpoItemPrice.QTYBSUOM)
                End If
            End If
            Return 0

        End Function
        Public Shared Function GetItem(ByVal session As Session, ByVal ItemCode As String) As IVItem
            Dim Item As IVItem = session.FindObject(GetType(IVItem), New BinaryOperator("ITEMNMBR", ItemCode, BinaryOperatorType.Equal))
            Return Item
        End Function
        Public Shared Function GetItemQuantityDetail(ByVal ItemNumber As String, ByVal LocationCode As String, ByVal CurrentSession As Session) As IVItemQuantity
            Dim gpoGroupOperator As New GroupOperator
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.ITEMNMBR", ItemNumber))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LOCNCODE", LocationCode))
            Return CurrentSession.FindObject(Of IVItemQuantity)(gpoGroupOperator)
        End Function
        ''' <summary>
        ''' Return the Item Price List entry based on the parameters provided
        ''' </summary>
        ''' <param name="Session"></param>
        ''' <param name="ItemCode"></param>
        ''' <param name="PriceLevel"></param>
        ''' <param name="UOM"></param>
        ''' <param name="CurrencyCode"></param>
        ''' <param name="Qty"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetItemPriceListEntry(ByVal Session As Session, ByVal ItemCode As String, ByVal PriceLevel As String, ByVal UOM As String, ByVal CurrencyCode As String, ByVal Qty As Decimal) As IVItemPriceList
            Dim xpoGO As New GroupOperator
            With xpoGO
                With .Operands
                    .Add(New BinaryOperator("ITEMNMBR", ItemCode, BinaryOperatorType.Equal))
                    .Add(New BinaryOperator("PRCLEVEL", PriceLevel, BinaryOperatorType.Equal))
                    .Add(New BinaryOperator("UOFM", UOM, BinaryOperatorType.Equal))
                    .Add(New BinaryOperator("CURNCYID", CurrencyCode, BinaryOperatorType.Equal))
                End With
            End With
            Dim xpcItemPrice As New XPCollection(Of IVItemPriceList)(Session, xpoGO)
            xpcItemPrice.Sorting.Add(New SortProperty("FROMQTY", DB.SortingDirection.Descending))
            For Each xpoItemPrice As IVItemPriceList In xpcItemPrice
                If xpoItemPrice.FROMQTY <= Qty And xpoItemPrice.TOQTY >= Qty Then
                    Return xpoItemPrice
                End If
            Next
            Return Nothing

        End Function

        ''' <summary>
        ''' Return the Item Price List entry based on the parameters provided
        ''' </summary>
        ''' <param name="Session"></param>
        ''' <param name="ItemCode"></param>
        ''' <param name="PriceLevel"></param>
        ''' <param name="UOM"></param>
        ''' <param name="Qty"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetItemPriceListEntry(ByVal Session As Session, ByVal ItemCode As String, ByVal PriceLevel As String, ByVal UOM As String, ByVal Qty As Decimal) As IVItemPriceList
            Dim xpoGO As New GroupOperator
            With xpoGO
                With .Operands
                    .Add(New BinaryOperator("ITEMNMBR", ItemCode, BinaryOperatorType.Equal))
                    .Add(New BinaryOperator("PRCLEVEL", PriceLevel, BinaryOperatorType.Equal))
                    .Add(New BinaryOperator("UOFM", UOM, BinaryOperatorType.Equal))
                End With
            End With
            Dim xpcItemPrice As New XPCollection(Of IVItemPriceList)(Session, xpoGO)
            xpcItemPrice.Sorting.Add(New SortProperty("FROMQTY", DB.SortingDirection.Descending))
            For Each xpoItemPrice As IVItemPriceList In xpcItemPrice
                If xpoItemPrice.FROMQTY <= Qty And xpoItemPrice.TOQTY >= Qty Then
                    Return xpoItemPrice
                End If
            Next
            Return Nothing

        End Function

        Public Shared Function GetItemPurchaseUOMSchedules(ByVal Session As Session, ByVal Item As IVItem) As XPCollection(Of IVUOMScheduleDetail)
            Dim xpc As New XPCollection(Of IVUOMScheduleDetail)(Session, New BinaryOperator("UOMSCHDL", Item.UOMSCHDL, BinaryOperatorType.Equal))
            Return xpc
        End Function
        Public Shared Function GetItemPurchaseUOMSchedules(ByVal Session As Session, ByVal ItemCode As String) As XPCollection(Of IVUOMScheduleDetail)
            Dim xpc As New XPCollection(Of IVUOMScheduleDetail)(Session, False)
            Dim Item As IVItem = Session.FindObject(GetType(IVItem), New BinaryOperator("ITEMNMBR", ItemCode, BinaryOperatorType.Equal))
            If Item IsNot Nothing Then
                Return GetItemPurchaseUOMSchedules(Session, Item)
            Else
                Throw New Exception("Item not found")
            End If
        End Function
        Public Shared Function GetUOMScheduleDetail(ByVal session As Session, ByVal UOMSCHDL As String, ByVal UOFM As String) As IVUOMScheduleDetail
            Dim xpoGO As New GroupOperator
            With xpoGO
                .OperatorType = GroupOperatorType.And
                .Operands.Add(New BinaryOperator("UOFM", UOFM, BinaryOperatorType.Equal))
                .Operands.Add(New BinaryOperator("UOMSCHDL", UOMSCHDL, BinaryOperatorType.Equal))
            End With
            Dim IVUOM As IVUOMScheduleDetail = session.FindObject(GetType(IVUOMScheduleDetail), xpoGO)
            Return IVUOM
        End Function
        Public Shared Function GetUOMScheduleDetailForItem(ByVal session As Session, ByVal Item As IV.IVItem) As XPCollection(Of IVUOMScheduleDetail)
            Dim xpoGO As New GroupOperator
            With xpoGO
                .OperatorType = GroupOperatorType.And
                .Operands.Add(New BinaryOperator("UOMSCHDL", Item.UOMSCHDL, BinaryOperatorType.Equal))
            End With
            Return New XPCollection(Of IV.IVUOMScheduleDetail)(session, xpoGO)
        End Function
        Public Shared Function GetUOMScheduleDetailForItem(ByVal session As Session, ByVal ItemNumber As String) As XPCollection(Of IVUOMScheduleDetail)
            Dim iviItem As GPObjectLibrary.Module.Objects.IV.IVItem
            iviItem = session.FindObject(Of IV.IVItem)(New BinaryOperator("ITEMNMBR", ItemNumber))
            If iviItem Is Nothing Then
                Return Nothing
            End If
            Dim xpoGO As New GroupOperator
            With xpoGO
                .OperatorType = GroupOperatorType.And
                .Operands.Add(New BinaryOperator("UOMSCHDL", iviItem.UOMSCHDL, BinaryOperatorType.Equal))
            End With
            Return New XPCollection(Of IV.IVUOMScheduleDetail)(session, xpoGO)
        End Function
        Public Shared Function ItemSerialLotTrackingType(ByVal Session As Session, ByVal ItemKey As String) As SerialLotTracking
            Dim gpIVItem As IVItem
            'validate serial number exist if serialized
            gpIVItem = Session.FindObject(GetType(IVItem), New BinaryOperator("ITEMNMBR", ItemKey, BinaryOperatorType.Equal))
            Return gpIVItem.ITMTRKOP

        End Function
        Public Shared Function ItemSerialLotTrackingType(ByVal Item As IVItem) As SerialLotTracking
            Return Item.ITMTRKOP
        End Function

        Public Shared Function GetItemStockCountLines(ByVal Session As Session, ByVal CountID As String) As XPCollection(Of IVItemStockCountLine)
            Dim xclLInes As New XPCollection(Of IVItemStockCountLine)(Session, New BinaryOperator("STCKCNTID", CountID, BinaryOperatorType.Equal))
            Return xclLInes

        End Function

        Public Shared Function UpdateGPItemStockCount(ByVal Session As Session, ByVal CountId As String, ByVal ItemStockCounts As IV.Helpers.ItemStockCounts, ByVal SkipMissingItems As Boolean) As String
            Dim gpIVItemStockCount As IVItemStockCount
            Dim gpIVItemStockCountUOM As IVItemStockCountUOM
            Dim gpItem As IV.IVItem

            Dim gpItemStockCountLines As XPCollection(Of IVItemStockCountLine)
            Dim gpItemStockCountSerialNumber As IVItemStockCountSerialLot
            Dim gpItemStockCountSerialNumbers As XPCollection(Of IVItemStockCountSerialLot)

            Dim ExceptionMessage As New Text.StringBuilder

            Dim gcItemStockSerialNumberCriteria As New GroupOperator
            Dim gcItemStockLineCriteria As New GroupOperator

            'attempt ot find the stock count batch
            'if not found then throw exception
            gpIVItemStockCount = Session.FindObject(GetType(IVItemStockCount), New BinaryOperator("STCKCNTID", CountId, BinaryOperatorType.Equal))
            If gpIVItemStockCount Is Nothing Then
                Throw New Exception("Stock Count Batch " & CountId & "Not Found")
            End If

            'validate  count items
            'load stock line items collection &  stock line item serial lot numbers
            gpItemStockCountLines = New XPCollection(Of IVItemStockCountLine)(Session)
            gpItemStockCountSerialNumbers = New XPCollection(Of IVItemStockCountSerialLot)(Session)
            'iterate through each item count and validate against GP
            For Each ItemCount As ItemStockCount In ItemStockCounts
                'validate item master exists
                gpItem = Session.FindObject(GetType(IV.IVItem), New BinaryOperator("ITEMNMBR", ItemCount.ItemKey, BinaryOperatorType.Equal))
                If gpItem Is Nothing Then
                    ExceptionMessage.AppendLine("Item " & ItemCount.ItemKey & " not found in item master")
                End If

                'validate item in count
                gcItemStockLineCriteria = New GroupOperator
                gcItemStockLineCriteria.Operands.Add(New BinaryOperator("LOCNCODE", ItemCount.Location, BinaryOperatorType.Equal))
                gcItemStockLineCriteria.Operands.Add(New BinaryOperator("ITEMNMBR", ItemCount.ItemKey, BinaryOperatorType.Equal))
                gcItemStockLineCriteria.Operands.Add(New BinaryOperator("STCKCNTID", CountId, BinaryOperatorType.Equal))
                gpItemStockCountLines.Criteria = gcItemStockLineCriteria
                If gpItemStockCountLines.Count = 0 Then
                    ExceptionMessage.AppendLine(String.Format("Count Id [{0}] Item [{1}] Location [{2}] not found in stock count lines", CountId, ItemCount.ItemKey, ItemCount.Location))
                End If
                If gpItemStockCountLines.Count > 1 Then
                    ExceptionMessage.AppendLine(String.Format("Count Id [{0}] Item [{1}] Location [{2}]  has multiple lines.  Cannot update multiple lines", CountId, ItemCount.ItemKey, ItemCount.Location))
                End If

            Next

            'If SkipMissingItems = False And ExceptionMessage.Length > 0 Then
            '    Throw New Exception(ExceptionMessage.ToString)
            'End If

            '*** ITEM COUNTS VALID UPDATE GP ***
            For Each ItemCount As ItemStockCount In ItemStockCounts
                'get item master
                gpItem = Session.FindObject(GetType(IV.IVItem), New BinaryOperator("ITEMNMBR", ItemCount.ItemKey, BinaryOperatorType.Equal))

                'find item in stockcount line and update 
                gcItemStockLineCriteria = New GroupOperator
                gcItemStockLineCriteria.Operands.Add(New BinaryOperator("LOCNCODE", ItemCount.Location, BinaryOperatorType.Equal))
                gcItemStockLineCriteria.Operands.Add(New BinaryOperator("ITEMNMBR", ItemCount.ItemKey, BinaryOperatorType.Equal))
                gcItemStockLineCriteria.Operands.Add(New BinaryOperator("STCKCNTID", CountId, BinaryOperatorType.Equal))
                gpItemStockCountLines.Criteria = gcItemStockLineCriteria
                If gpItemStockCountLines.Count = 1 Then

                    'handle count UOM
                    'remove any existing UOM records for this item count
                    RemoveStockCountUOMEntries(Session, CountId, ItemCount.Location, ItemCount.ItemKey)
                    'add stock count UOM
                    gpIVItemStockCountUOM = New IV.IVItemStockCountUOM(Session)
                    With gpIVItemStockCountUOM
                        .COUNTEDQTY = ItemCount.ItemCount
                        If ItemCount.ItemBaseUOMFactor > 0 Then
                            .QTYBSUOM = ItemCount.ItemBaseUOMFactor 'ItemCount.ItemCount * GetItemUOMConversionToBaseUOMFactor(Session, ItemCount.ItemKey, ItemCount.UOM)
                        Else
                            .QTYBSUOM = 1
                        End If

                        .ITEMNMBR = ItemCount.ItemKey
                        .UOFM = ItemCount.UOM
                        .STCKCNTID = CountId
                        .LOCNCODE = ItemCount.Location
                        .DECPLQTY = GetIVSetup(Session).DECPLQTY
                        .BINNMBR = ""
                        .Save()
                    End With

                    'update line item count

                    gpItemStockCountLines(0).COUNTEDQTY = ItemCount.ItemBaseUOMCount
                    gpItemStockCountLines(0).VARIANCEQTY = gpItemStockCountLines(0).COUNTEDQTY - gpItemStockCountLines(0).CAPTUREDQTY
                    gpItemStockCountLines(0).STCKSRLLTVRNC = gpItemStockCountLines(0).VARIANCEQTY

                    gpItemStockCountLines(0).COUNTDATE = ItemCount.CountDate
                    gpItemStockCountLines(0).DECPLQTY = GetIVSetup(Session).DECPLQTY
                    gpItemStockCountLines(0).VERIFIED = 1

                    Dim decTotal As Decimal = 0
                    For Each slcCount In ItemCount.SerialNumbers
                        If slcCount.SeriaLotType = ItemStockCountSerialLotNumber.SerialLotTypes.LotNumber Then
                            decTotal += slcCount.LotQty
                        Else
                            decTotal += 1
                        End If
                    Next
                    If ItemCount.SerialNumbers.Count > 0 AndAlso ItemCount.SerialNumbers(0).SeriaLotType = ItemStockCountSerialLotNumber.SerialLotTypes.LotNumber Then
                        gpItemStockCountLines(0).Stock_Serial_Lot_Count = decTotal
                    Else
                        gpItemStockCountLines(0).Stock_Serial_Lot_Count = ItemCount.SerialNumbers.Count
                    End If

                    gpItemStockCountLines(0).Save()

                    'Update serial number stock count for serial numbers counted
                    For Each ItemSerialNumber As IV.Helpers.ItemStockCountSerialLotNumber In ItemCount.SerialNumbers
                        gcItemStockSerialNumberCriteria = New GroupOperator
                        gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("ITEMNMBR", ItemCount.ItemKey, BinaryOperatorType.Equal))
                        gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("SERLTNUM", ItemSerialNumber.SerialLotNumber, BinaryOperatorType.Equal))
                        gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("STCKCNTID", CountId, BinaryOperatorType.Equal))
                        gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("LOCNCODE", ItemCount.Location, BinaryOperatorType.Equal))
                        gpItemStockCountSerialNumbers.Criteria = gcItemStockSerialNumberCriteria
                        If gpItemStockCountSerialNumbers.Count = 1 Then
                            gpItemStockCountSerialNumber = gpItemStockCountSerialNumbers(0)
                            gpItemStockCountSerialNumber.Save()
                        ElseIf gpItemStockCountSerialNumbers.Count = 0 Then
                            gpItemStockCountSerialNumber = New IV.IVItemStockCountSerialLot(Session)
                            With gpItemStockCountSerialNumber
                                .BINNMBR = ""
                                .CAPTUREDQTY = 0
                                .COUNTEDQTY = 0
                                .DATERECD = ItemCount.CountDate
                                .DTSEQNUM = GetNextStockSerialLotNumberLineSequence(gpItemStockCountSerialNumbers, ItemCount, CountId)
                                .EXPNDATE = "01/01/1900"
                                .ITEMNMBR = ItemCount.ItemKey
                                .LOCNCODE = ItemCount.Location
                                .MFGDATE = "01/01/1900"
                                .QTYTYPE = 1
                                .SERLTNUM = ItemSerialNumber.SerialLotNumber
                                .STCKCNTID = CountId
                            End With
                            gpItemStockCountSerialNumber.Save()
                            gpItemStockCountSerialNumbers.Add(gpItemStockCountSerialNumber)
                        End If
                        'update counted for serial/lot
                        If gpItemStockCountSerialNumber IsNot Nothing Then
                            If ItemSerialNumber.SeriaLotType = ItemStockCountSerialLotNumber.SerialLotTypes.LotNumber Then
                                gpItemStockCountSerialNumber.SERIALSTATUS = 3
                                gpItemStockCountSerialNumber.ITMTRKOP = 3
                                gpItemStockCountSerialNumber.COUNTEDQTY += ItemSerialNumber.LotQty
                                gpItemStockCountSerialNumber.VARIANCEQTY = gpItemStockCountSerialNumber.COUNTEDQTY - gpItemStockCountSerialNumber.CAPTUREDQTY
                                gpItemStockCountSerialNumber.VERIFIED = 1
                                gpItemStockCountSerialNumber.Save()
                            Else
                                gpItemStockCountSerialNumber.SERIALSTATUS = 2
                                gpItemStockCountSerialNumber.ITMTRKOP = 2
                                gpItemStockCountSerialNumber.COUNTEDQTY = 1
                                gpItemStockCountSerialNumber.VARIANCEQTY = gpItemStockCountSerialNumber.COUNTEDQTY - gpItemStockCountSerialNumber.CAPTUREDQTY
                                gpItemStockCountSerialNumber.VERIFIED = 1
                                gpItemStockCountSerialNumber.Save()
                            End If
                        End If

                    Next
                    'Update serial number stock count for serial numbers NOT counted
                    For Each ItemSerialNumber As IV.Helpers.ItemStockCountSerialLotNumber In ItemCount.SerialNumbers
                        gcItemStockSerialNumberCriteria = New GroupOperator
                        gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("ITEMNMBR", ItemCount.ItemKey, BinaryOperatorType.Equal))
                        gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("STCKCNTID", CountId, BinaryOperatorType.Equal))
                        gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("LOCNCODE", ItemCount.Location, BinaryOperatorType.Equal))
                        gpItemStockCountSerialNumbers.Criteria = gcItemStockSerialNumberCriteria
                        For j As Integer = 0 To gpItemStockCountSerialNumbers.Count - 1
                            If gpItemStockCountSerialNumbers(j).VERIFIED = 0 Then
                                gpItemStockCountSerialNumbers(j).SERIALSTATUS = 3
                                gpItemStockCountSerialNumbers(j).VARIANCEQTY = gpItemStockCountSerialNumbers(j).CAPTUREDQTY * -1
                                gpItemStockCountSerialNumbers(j).VERIFIED = 1
                                gpItemStockCountSerialNumbers(j).Save()
                            End If
                        Next
                    Next
                End If

            Next
            If ExceptionMessage.Length > 0 Then
                Return "These items were skipped from processing" & vbCrLf & ExceptionMessage.ToString
            Else
                Return Nothing
            End If

        End Function
        Public Shared Sub UpdateCountsAsVerified(ByVal Session As Session, ByVal CountDate As Date)
            Dim xpcCounts As New XPCollection(Of IV.IVItemStockCountLine)(Session, New BinaryOperator("VERIFIED", 0, BinaryOperatorType.Equal))
            Dim xpcSerialNumbers As XPCollection(Of IV.IVItemStockCountSerialLot)
            Dim xgoItemStockLineCriteria = New GroupOperator
            For Each xpoCount As IV.IVItemStockCountLine In xpcCounts
                'handle serial numbers
                xgoItemStockLineCriteria = New GroupOperator
                xgoItemStockLineCriteria.Operands.Add(New BinaryOperator("LOCNCODE", xpoCount.LOCNCODE, BinaryOperatorType.Equal))
                xgoItemStockLineCriteria.Operands.Add(New BinaryOperator("ITEMNMBR", xpoCount.ITEMNMBR, BinaryOperatorType.Equal))
                xgoItemStockLineCriteria.Operands.Add(New BinaryOperator("STCKCNTID", xpoCount.STCKCNTID, BinaryOperatorType.Equal))
                xpcSerialNumbers = New XPCollection(Of IV.IVItemStockCountSerialLot)(Session, xgoItemStockLineCriteria)
                For Each xpoSerialNumber In xpcSerialNumbers
                    With xpoSerialNumber
                        .SERIALSTATUS = 3
                        .VARIANCEQTY = -1 * .CAPTUREDQTY
                        .VERIFIED = 1
                        .Save()
                    End With
                Next

                With xpoCount
                    .COUNTEDQTY = 0
                    .COUNTDATE = CountDate
                    .VARIANCEQTY = .CAPTUREDQTY * -1
                    .DECPLQTY = GetIVSetup(Session).DECPLQTY
                    .Stock_Serial_Lot_Count = 0
                    .STCKSRLLTVRNC = .CAPTUREDQTY * -1
                    .VERIFIED = 1
                    .Save()
                End With
            Next
        End Sub
        Private Shared Function GetNextStockSerialLotNumberLineSequence(ByVal gpItemStockCountSerialNumbers As XPCollection(Of IV.IVItemStockCountSerialLot), ByVal ItemCount As ItemStockCount, ByVal CountId As String) As Decimal
            Dim gcItemStockSerialNumberCriteria = New GroupOperator
            gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("ITEMNMBR", ItemCount.ItemKey, BinaryOperatorType.Equal))
            gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("STCKCNTID", CountId, BinaryOperatorType.Equal))
            gcItemStockSerialNumberCriteria.Operands.Add(New BinaryOperator("LOCNCODE", ItemCount.Location, BinaryOperatorType.Equal))

            gpItemStockCountSerialNumbers.Criteria = gcItemStockSerialNumberCriteria
            gpItemStockCountSerialNumbers.Sorting.Add(New DevExpress.Xpo.SortProperty("DTSEQNUM", DB.SortingDirection.Descending))
            If gpItemStockCountSerialNumbers.Count > 0 Then
                Return gpItemStockCountSerialNumbers(0).DTSEQNUM + 1
            Else
                Return 1
            End If
        End Function

        Public Shared Sub RemoveStockCountUOMEntries(ByVal Session As Session, ByVal StockCountID As String, ByVal Location As String, ByVal ItemKey As String)
            Dim goParams As New GroupOperator
            Dim gpStockCountUOMS As XPCollection(Of IV.IVItemStockCountUOM)

            With goParams
                .Operands.Add(New BinaryOperator("STCKCNTID", StockCountID, BinaryOperatorType.Equal))
                .Operands.Add(New BinaryOperator("ITEMNMBR", ItemKey, BinaryOperatorType.Equal))
                .Operands.Add(New BinaryOperator("LOCNCODE", Location, BinaryOperatorType.Equal))

            End With
            gpStockCountUOMS = New XPCollection(Of IV.IVItemStockCountUOM)(Session, goParams)
            For j As Integer = gpStockCountUOMS.Count - 1 To 0 Step -1
                gpStockCountUOMS(j).Delete()
            Next
            'Session.PurgeDeletedObjects()


        End Sub
        Public Shared Function GetItemUOMConversionToBaseUOMFactor(ByVal Session As Session, ByVal ItemKey As String, ByVal FromUOM As String) As Decimal
            Dim gpItem As IV.IVItem
            Dim gpUOMScheduleDetails As XPCollection(Of IV.IVUOMScheduleDetail)
            Dim goUOMFilter As New GroupOperator
            Dim strBaseUOM As String
            gpItem = Session.FindObject(GetType(IVItem), New BinaryOperator("ITEMNMBR", ItemKey, BinaryOperatorType.Equal))
            If gpItem IsNot Nothing Then
                strBaseUOM = GetItemBaseUOM(Session, gpItem.UOMSCHDL)
                'build UOM schedule detail filter
                goUOMFilter.Operands.Add(New BinaryOperator("UOMSCHDL", gpItem.UOMSCHDL))
                goUOMFilter.Operands.Add(New BinaryOperator("UOFM", FromUOM, BinaryOperatorType.Equal))
                goUOMFilter.Operands.Add(New BinaryOperator("EQUIVUOM", strBaseUOM, BinaryOperatorType.Equal))
                gpUOMScheduleDetails = New XPCollection(Of IV.IVUOMScheduleDetail)(Session, goUOMFilter)
                If gpUOMScheduleDetails.Count = 1 Then
                    Return gpUOMScheduleDetails(0).EQUOMQTY
                Else
                    Throw New Exception(String.Format("Could not find UOM conversion schedule detail for conversion of [{0}] to [{1}]", FromUOM, strBaseUOM))
                End If

            Else
                Throw New Exception(String.Format("Could not find Item [{0}]", ItemKey))
            End If
        End Function
        Public Shared Function GetItemBaseUOM(ByVal Session As Session, ByVal UOMSCHDL As String) As String
            Dim gpUOMSchedule As IV.IVUOMSchedule
            gpUOMSchedule = Session.FindObject(GetType(IV.IVUOMSchedule), New BinaryOperator("UOMSCHDL", UOMSCHDL))
            If gpUOMSchedule IsNot Nothing Then
                Return gpUOMSchedule.BASEUOFM
            Else
                Throw New Exception(String.Format("UOM Schedule not found for [{0}]", UOMSCHDL))
            End If
        End Function
        Public Shared Function GetIVSetup(ByVal session As Session) As IV.IVSetup
            Return session.FindObject(GetType(IV.IVSetup), New BinaryOperator("SETUPKEY", "1"))

        End Function
        ''' <summary>
        ''' Return prices for the passed in price sheet
        ''' </summary>
        ''' <param name="session"></param>
        ''' <param name="SheetID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSheetPriceValues(ByVal session As Session, ByVal SheetID As String, Optional ByVal BasePrices As List(Of IV.NonPersistent.IVExtendedPricingItemPrice) = Nothing, Optional ByVal ItemsToInclude As List(Of String) = Nothing) As List(Of IV.NonPersistent.IVExtendedPricingItemPrice)
            Dim lstPrices As New List(Of IV.NonPersistent.IVExtendedPricingItemPrice)
            Dim prcPriceSheetHeader As SOP.SOPPricesheetHeader
            Dim prcPriceDetailPrice As IV.IVPricesheetLineItemDetailPrice
            Dim xpcPriceSheetPrices As XPCollection(Of IV.IVPricesheetLineItemDetailPrice)
            Dim ivpPrice As IV.NonPersistent.IVExtendedPricingItemPrice
            Dim ivdDetail As IV.IVPricesheetLineItemDetail
            Dim iviItem As GPObjectLibrary.Module.Objects.IV.IVItem
            Dim xpcItemPriceGroupAssignments As XPCollection(Of IVItemPriceGroupItemAssignment)
            Dim blnFoundGroupAssignment As Boolean
            prcPriceSheetHeader = session.FindObject(Of SOP.SOPPricesheetHeader)(New BinaryOperator("PRCSHID", SheetID))
            If prcPriceSheetHeader Is Nothing Then
                Return lstPrices
            End If
            ivdDetail = session.FindObject(Of IV.IVPricesheetLineItemDetail)(New BinaryOperator("Oid.PRCSHID", SheetID))
            If ivdDetail Is Nothing Then
                Return lstPrices
            End If
            xpcPriceSheetPrices = New XPCollection(Of IV.IVPricesheetLineItemDetailPrice)(session, New BinaryOperator("Oid.PRCSHID", SheetID))
            For Each prcPriceDetailPrice In xpcPriceSheetPrices
                If prcPriceDetailPrice.Oid.EPITMTYP = "I" Then
                    If ItemsToInclude IsNot Nothing AndAlso ItemsToInclude.Contains(prcPriceDetailPrice.Oid.ITEMNMBR) = False Then
                        Continue For
                    End If
                    iviItem = session.GetObjectByKey(Of GPObjectLibrary.Module.Objects.IV.IVItem)(prcPriceDetailPrice.Oid.ITEMNMBR)
                    If iviItem Is Nothing Then
                        Continue For
                    End If
                    ivpPrice = New IV.NonPersistent.IVExtendedPricingItemPrice
                    ivpPrice.ItemNumber = prcPriceDetailPrice.Oid.ITEMNMBR
                    ivpPrice.UOM = prcPriceDetailPrice.Oid.UOFM
                    If ivdDetail.PRODTCOD = "N" Then
                        ivpPrice.Price = prcPriceDetailPrice.PSITMVAL
                    ElseIf ivdDetail.PRODTCOD = "P" Then
                        For Each ilvLevel As IV.NonPersistent.IVExtendedPricingItemPrice In BasePrices
                            If ilvLevel.ItemNumber = ivpPrice.ItemNumber Then
                                ivpPrice.Price = ilvLevel.Price * (prcPriceDetailPrice.PSITMVAL / 100)
                            End If
                        Next

                    ElseIf ivdDetail.PRODTCOD = "V" Then
                        For Each ilvLevel As IV.NonPersistent.IVExtendedPricingItemPrice In BasePrices
                            If ilvLevel.ItemNumber = ivpPrice.ItemNumber Then
                                ivpPrice.Price = ilvLevel.Price - prcPriceDetailPrice.PSITMVAL
                            End If
                        Next
                    End If
                    blnFoundGroupAssignment = False
                    For Each ivpTempPrice As IV.NonPersistent.IVExtendedPricingItemPrice In lstPrices
                        If ivpTempPrice.ItemNumber = ivpPrice.ItemNumber AndAlso ivpTempPrice.UpdatedFromGroupAssignment = True Then
                            blnFoundGroupAssignment = True
                        End If
                    Next
                    If blnFoundGroupAssignment = False Then
                        lstPrices.Add(ivpPrice)
                    End If

                ElseIf prcPriceDetailPrice.Oid.EPITMTYP = "G" Then
                    'get all items in group
                    xpcItemPriceGroupAssignments = New XPCollection(Of IVItemPriceGroupItemAssignment)(session, New BinaryOperator("Oid.PRCGRPID", prcPriceDetailPrice.Oid.ITEMNMBR))
                    For Each pgaPriceGroupAssignment As IVItemPriceGroupItemAssignment In xpcItemPriceGroupAssignments
                        If ItemsToInclude IsNot Nothing AndAlso ItemsToInclude.Contains(pgaPriceGroupAssignment.Oid.ITEMNMBR) = False Then
                            Continue For
                        End If
                        iviItem = session.GetObjectByKey(Of GPObjectLibrary.Module.Objects.IV.IVItem)(pgaPriceGroupAssignment.Oid.ITEMNMBR)
                        If iviItem Is Nothing Then
                            Continue For
                        End If
                        ivpPrice = New IV.NonPersistent.IVExtendedPricingItemPrice
                        ivpPrice.ItemNumber = iviItem.ITEMNMBR
                        ivpPrice.UpdatedFromGroupAssignment = True
                        ivpPrice.UOM = prcPriceDetailPrice.Oid.UOFM
                        If ivdDetail.PRODTCOD = "N" Then
                            ivpPrice.Price = prcPriceDetailPrice.PSITMVAL
                        ElseIf ivdDetail.PRODTCOD = "P" Then
                            For Each ilvLevel As IV.NonPersistent.IVExtendedPricingItemPrice In BasePrices
                                If ilvLevel.ItemNumber = ivpPrice.ItemNumber Then
                                    ivpPrice.Price = ilvLevel.Price * (prcPriceDetailPrice.PSITMVAL / 100)
                                End If
                            Next

                        ElseIf ivdDetail.PRODTCOD = "V" Then
                            For Each ilvLevel As IV.NonPersistent.IVExtendedPricingItemPrice In BasePrices
                                If ilvLevel.ItemNumber = ivpPrice.ItemNumber Then
                                    ivpPrice.Price = ilvLevel.Price - prcPriceDetailPrice.PSITMVAL
                                End If
                            Next
                        End If
                        blnFoundGroupAssignment = False
                        For Each ivpTempPrice As IV.NonPersistent.IVExtendedPricingItemPrice In lstPrices
                            If ivpTempPrice.ItemNumber = ivpPrice.ItemNumber AndAlso ivpTempPrice.UpdatedFromGroupAssignment = False Then
                                ivpTempPrice.Price = ivpPrice.Price
                                ivpTempPrice.UpdatedFromGroupAssignment = True
                                blnFoundGroupAssignment = True
                            End If
                        Next
                        If blnFoundGroupAssignment = False Then
                            lstPrices.Add(ivpPrice)
                        End If
                    Next
                End If

            Next
            Return lstPrices
        End Function

        ''' <summary>
        ''' Fetches a list of generated customer levels based on the base book passed in.  Creates a separate level for each customer pricing that has values which are different than the base.
        ''' </summary>
        ''' <param name="session"></param>
        ''' <param name="ItemsToInclude"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetExtendedPricingInformation(ByVal session As Session, Optional ByVal ItemsToInclude As List(Of String) = Nothing) As List(Of NonPersistent.IVExtendedPriceLevel)
            Dim gpoGroupOperator As GroupOperator
            Dim xpcSheetsForBook As XPCollection(Of RM.RMPricebookPricesheetLink)
            Dim xpcBooks As New XPCollection(Of SOP.SOPPricebookHeader)
            Dim prcPriceSheet As SOP.SOPPricesheetHeader
            Dim ivlBaseLevel As IV.NonPersistent.IVExtendedPriceLevel = Nothing
            Dim ivlLevel As IV.NonPersistent.IVExtendedPriceLevel
            Dim lstLevels As New List(Of IV.NonPersistent.IVExtendedPriceLevel)
            Dim lstValues As List(Of IV.NonPersistent.IVExtendedPricingItemPrice)
            Dim levValue As IV.NonPersistent.IVExtendedPricingItemPrice
            Dim xpcSheets As XPCollection(Of RM.RMPricebookPricesheetLink)
            Dim iepExtendedPrice As IV.NonPersistent.IVExtendedPricingItemPrice
            Dim vluTempValue As IV.NonPersistent.IVExtendedPricingItemPrice
            'bbhBaseBookHeader = session.FindObject(Of SOP.SOPPricebookHeader)(New BinaryOperator("ISBASE", 1))
            'If bbhBaseBookHeader Is Nothing Then
            '    Throw New Exception("Base price book not found!")
            'End If
            'ivlBaseLevel = New IV.NonPersistent.IVExtendedPriceLevel
            'ivlBaseLevel.IsBase = True
            'ivlBaseLevel.PriceLevelName = bbhBaseBookHeader.PRCBKID

            'lstLevels.Add(ivlBaseLevel)

            ''Fetch all sheets in the book and creates their price matching.
            'gpoGroupOperator = New GroupOperator
            'gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.PRODTCOD", "P"))
            'gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LINKCODE", ivlBaseLevel.PriceLevelName))
            'xpcSheetsForBook = New XPCollection(Of RM.RMPricebookPricesheetLink)(session, gpoGroupOperator)
            'For Each pblLink As RM.RMPricebookPricesheetLink In xpcSheetsForBook
            '    prcPriceSheet = session.GetObjectByKey(Of SOP.SOPPricesheetHeader)(pblLink.Oid.PRCSHID)
            '    If prcPriceSheet.STRTDATE <= Today AndAlso (prcPriceSheet.ENDDATE = Nothing OrElse prcPriceSheet.ENDDATE >= Today) Then
            '        ivlBaseLevel.PriceLevelEntries.AddRange(GetSheetPriceValues(session, prcPriceSheet.PRCSHID))
            '    End If
            'Next

            xpcBooks = New XPCollection(Of SOP.SOPPricebookHeader)(session)
            For Each bkgBook As SOP.SOPPricebookHeader In xpcBooks
                ivlLevel = New IV.NonPersistent.IVExtendedPriceLevel
                ivlLevel.PriceLevelName = bkgBook.PRCBKID
                gpoGroupOperator = New GroupOperator
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.PRODTCOD", "P"))
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LINKCODE", ivlLevel.PriceLevelName))
                xpcSheetsForBook = New XPCollection(Of RM.RMPricebookPricesheetLink)(session, gpoGroupOperator)
                For Each pblLink As RM.RMPricebookPricesheetLink In xpcSheetsForBook
                    prcPriceSheet = session.GetObjectByKey(Of SOP.SOPPricesheetHeader)(pblLink.Oid.PRCSHID)
                    If prcPriceSheet.STRTDATE <= Today AndAlso (prcPriceSheet.ENDDATE = Nothing OrElse prcPriceSheet.ENDDATE >= Today) Then
                        ivlLevel.PriceLevelEntries.AddRange(GetSheetPriceValues(session, prcPriceSheet.PRCSHID, Nothing, ItemsToInclude))
                    End If
                Next
                lstLevels.Add(ivlLevel)
                If bkgBook.ISBASE = 1 Then
                    ivlBaseLevel = ivlLevel
                    ivlBaseLevel.IsBase = True
                End If
            Next

            If ivlBaseLevel Is Nothing Then
                Throw New Exception("Base price book not found!")
            End If

            ''Checks all book assignments to customer, and creates customer specific level if their book assignment is different.
            'xpcPriceBookAssignmentsToCustomer = New XPCollection(Of SOP.SOPCustomerPricebookAssignment)(session)
            'For Each pbaPriceBookAssignment As SOP.SOPCustomerPricebookAssignment In xpcPriceBookAssignmentsToCustomer
            '    If pbaPriceBookAssignment.Oid.PRCBKID <> ivlBaseLevel.PriceLevelName Then
            '        ivlLevel = New IV.NonPersistent.IVExtendedPriceLevel
            '        ivlLevel.PriceLevelName = pbaPriceBookAssignment.Oid.LINKCODE
            '        lstLevels.Add(ivlLevel)
            '        gpoGroupOperator = New GroupOperator
            '        gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.PRODTCOD", "P"))
            '        gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LINKCODE", pbaPriceBookAssignment.Oid.PRCBKID))
            '        xpcSheetsForBook = New XPCollection(Of RM.RMPricebookPricesheetLink)(session, gpoGroupOperator)
            '        For Each pblLink As RM.RMPricebookPricesheetLink In xpcSheetsForBook
            '            prcPriceSheet = session.GetObjectByKey(Of SOP.SOPPricesheetHeader)(pblLink.Oid.PRCSHID)
            '            If prcPriceSheet.STRTDATE <= Today AndAlso (prcPriceSheet.ENDDATE = Nothing OrElse prcPriceSheet.ENDDATE >= Today) Then
            '                ivlLevel.PriceLevelEntries.AddRange(GetSheetPriceValues(session, prcPriceSheet.PRCSHID, ivlBaseLevel.PriceLevelEntries))
            '            End If
            '        Next
            '    End If
            'Next

            'Checks all sheet assignments to customers and creates customer specific assignments.  If one exists from book assignment, it merges it in.
            xpcSheets = New XPCollection(Of RM.RMPricebookPricesheetLink)(session, New BinaryOperator("Oid.PRODTCOD", "C"))
            For Each shtSheet As RM.RMPricebookPricesheetLink In xpcSheets
                prcPriceSheet = session.GetObjectByKey(Of SOP.SOPPricesheetHeader)(shtSheet.Oid.PRCSHID)
                If prcPriceSheet.STRTDATE <= Today AndAlso (prcPriceSheet.ENDDATE = Nothing OrElse prcPriceSheet.ENDDATE >= Today) Then
                    ivlLevel = Nothing
                    For Each ivlTempLevel As IV.NonPersistent.IVExtendedPriceLevel In lstLevels
                        If ivlTempLevel.PriceLevelName = shtSheet.Oid.LINKCODE Then
                            ivlLevel = ivlTempLevel
                        End If
                    Next
                    If ivlLevel Is Nothing Then
                        ivlLevel = New IV.NonPersistent.IVExtendedPriceLevel
                        ivlLevel.PriceLevelName = shtSheet.Oid.LINKCODE
                        'Add base assignments if custom book not created already.
                        For Each bprBasePrice As IV.NonPersistent.IVExtendedPricingItemPrice In ivlBaseLevel.PriceLevelEntries
                            iepExtendedPrice = New IV.NonPersistent.IVExtendedPricingItemPrice
                            iepExtendedPrice.ItemNumber = bprBasePrice.ItemNumber
                            iepExtendedPrice.Price = bprBasePrice.Price
                            iepExtendedPrice.UOM = bprBasePrice.UOM
                            ivlLevel.PriceLevelEntries.Add(iepExtendedPrice)
                        Next
                        lstLevels.Add(ivlLevel)
                    End If
                    lstValues = GetSheetPriceValues(session, prcPriceSheet.PRCSHID, ivlBaseLevel.PriceLevelEntries, ItemsToInclude)
                    For Each vluValue As IV.NonPersistent.IVExtendedPricingItemPrice In lstValues
                        levValue = Nothing
                        For Each vluTempValue In ivlLevel.PriceLevelEntries
                            If vluTempValue.ItemNumber = vluValue.ItemNumber And vluTempValue.UOM = vluValue.UOM Then
                                levValue = vluTempValue
                            End If
                        Next
                        If levValue Is Nothing Then
                            vluTempValue = New IV.NonPersistent.IVExtendedPricingItemPrice
                            vluTempValue.ItemNumber = vluValue.ItemNumber
                            vluTempValue.Price = vluValue.Price
                            vluTempValue.UOM = vluValue.UOM
                            vluTempValue.UpdatedFromGroupAssignment = vluValue.UpdatedFromGroupAssignment
                            ivlLevel.PriceLevelEntries.Add(vluValue)
                        Else
                            If vluValue.UpdatedFromGroupAssignment = True Then
                                levValue.Price = vluValue.Price
                                levValue.UpdatedFromGroupAssignment = vluValue.UpdatedFromGroupAssignment
                            End If
                        End If
                    Next
                End If
            Next
            For intLoop As Integer = lstLevels.Count - 1 To 0 Step -1
                If lstLevels(intLoop).PriceLevelEntries.Count = 0 Then
                    lstLevels.RemoveAt(intLoop)
                End If
            Next
            Return lstLevels
        End Function
        Public Shared Sub AssignItemPriceToSheet(ByVal SheetID As String, ByVal ItemNumber As String, ByVal UOM As String, ByVal StartQuantity As Decimal, ByVal EndQuantity As Decimal, ByVal Price As Decimal, ByVal Session As Session)
            Dim gpoGroupOperator As New GroupOperator
            Dim pspPrice As IV.IVPricesheetLineItemDetailPrice
            Dim pskPriceKey As IV.IVPricesheetLineItemDetailPrice.IVPriceSheetItemDetailPriceKey
            Dim xpcPriceSheetPrices As XPCollection(Of IV.IVPricesheetLineItemDetailPrice)
            Dim ivqQuantity As IV.IVUOMScheduleDetail
            Dim gpoUOMFind As New GroupOperator
            Dim gpoParentFind As New GroupOperator
            Dim gpiItem As IV.IVItem
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.PRCSHID", SheetID))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.ITEMNMBR", ItemNumber))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.UOM", UOM))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.QTYFROM", StartQuantity))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.QTYTO", EndQuantity))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.EPITMTYP", "I"))
            pspPrice = Session.FindObject(Of IV.IVPricesheetLineItemDetailPrice)(gpoGroupOperator)
            If pspPrice Is Nothing Then
                pskPriceKey = New IV.IVPricesheetLineItemDetailPrice.IVPriceSheetItemDetailPriceKey
                pskPriceKey.ITEMNMBR = ItemNumber
                pskPriceKey.PRCSHID = SheetID
                pskPriceKey.QTYFROM = StartQuantity
                pskPriceKey.QTYTO = EndQuantity
                pskPriceKey.UOFM = UOM
                pspPrice = New IV.IVPricesheetLineItemDetailPrice(Session)
                pspPrice.Oid = pskPriceKey
                gpoParentFind.Operands.Add(New BinaryOperator("Oid.PRCSHID", SheetID))
                gpoParentFind.Operands.Add(New BinaryOperator("Oid.ITEMNMBR", ItemNumber))
                gpoParentFind.Operands.Add(New BinaryOperator("Oid.EPITMTYP", "I"))
                xpcPriceSheetPrices = New XPCollection(Of IV.IVPricesheetLineItemDetailPrice)(Session, gpoParentFind)
                pspPrice.SEQNUMBR = (xpcPriceSheetPrices.Count * 16384) + 16384
                gpiItem = Session.FindObject(Of IV.IVItem)(New BinaryOperator("ITEMNMBR", ItemNumber))
                If gpiItem Is Nothing Then
                    Throw New Exception("No GP Item Found!")
                End If
                gpoUOMFind = New GroupOperator
                gpoUOMFind.Operands.Add(New BinaryOperator("Oid.UOMSCHDL", gpiItem.UOMSCHDL))
                gpoUOMFind.Operands.Add(New BinaryOperator("Oid.UOFM", UOM))
                ivqQuantity = Session.FindObject(Of IV.IVUOMScheduleDetail)(gpoGroupOperator)
                If ivqQuantity Is Nothing Then
                    Throw New Exception("No GP UOM Mapping Found!")
                End If
                pspPrice.QTYBSUOM = pspPrice.QTYBSUOM
                pspPrice.EQUOMQTY = ivqQuantity.EQUOMQTY
            End If
            pspPrice.PSITMVAL = Price
        End Sub

        Private Shared Function j() As Integer
            Throw New NotImplementedException
        End Function
        Public Shared Function GetItemsAtSiteInPriceLevel() '(Session As Session, SiteID As String, PriceLevel As String) As XPCollection(Of IVItem)
            Dim ASM As Assembly = [Assembly].Load("GPObjectLibrarySQLRepository")
            Dim TR As New StreamReader(ASM.GetManifestResourceStream("GPObjectLibrarySQLRepository.GetItems.sql"))
            'Session.ExecuteQuery(TR.ReadToEnd)
            Return Nothing
        End Function

        Private Shared Function GetOutputParameter(ByVal parameterId As String, ByVal OutputType As SqlDbType, Optional ByVal paramSize As Integer = 0)
            Dim prmOutput As New SqlParameter()
            prmOutput.Direction = ParameterDirection.Output
            prmOutput.SqlDbType = OutputType
            prmOutput.ParameterName = parameterId
            prmOutput.Size = paramSize
            Return prmOutput
        End Function

        Public Class OmniResult
            Public Property Price As Decimal = 0
            Public Property OutputVariables As New Dictionary(Of String, String)
        End Class

        Public Shared Function GetOmniItemPrice(ByVal CustomerNumber As String, ByVal ItemNumber As String, ByVal OriginalPrice As Decimal, ByVal DateToCheck As DateTime, ByVal Quantity As Decimal, ByVal UOM As String, ByVal GPConnectionString As String) As OmniResult
            Dim cmd As SqlCommand
            Dim prmPriceOut As SqlParameter
            Dim sdrReader As SqlDataReader
            Dim objOmniResult As New OmniResult
            Try
                Using con As New SqlConnection(GPConnectionString)
                    cmd = New SqlCommand(String.Format("select * from [OPCalculateUnitPrice2] ('{0}','{1}','{2}','{3}',null,null,null,null,null,null,null,'{4}','{5}',null,null,null,null,null,null,null,null,null,null)", OriginalPrice, CustomerNumber, ItemNumber, DateToCheck.ToShortDateString, UOM, Quantity), con)
                    con.Open()
                    sdrReader = cmd.ExecuteReader()
                    While sdrReader.Read
                        If Not TypeOf sdrReader.Item("CalcUnitPrice") Is System.DBNull Then
                            objOmniResult.Price = sdrReader.Item("CalcUnitPrice")
                        Else
                            objOmniResult.Price = 0
                        End If
                    End While

                End Using
                Return objOmniResult
            Catch ex As Exception
                Throw
            End Try
            '             

        End Function


        Public Shared Function GetExtendedItemPrice(ByVal CustomerNumber As String, ByVal ItemNumber As String, ByVal OriginalPrice As Decimal, ByVal DateToCheck As DateTime, ByVal Quantity As Decimal, ByVal UOM As String, ByVal GPConnectionString As String) As OmniResult
            Dim cmd As SqlCommand
            Dim prmPriceOut As SqlParameter
            Dim prmMiscOut As SqlParameter
            Dim lstOutputParameters As List(Of SqlParameter)
            Dim objOmniResult As New OmniResult
            Try
                Using con As New SqlConnection(GPConnectionString)
                    cmd = New SqlCommand("sopExtPricingGetPrice", con)
                    cmd.CommandType = System.Data.CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@piST_DorP", "C")
                    cmd.Parameters.AddWithValue("@piST_CustomerNumber", CustomerNumber)
                    cmd.Parameters.AddWithValue("@piST_ItemNumber", ItemNumber)
                    cmd.Parameters.AddWithValue("@piST_UofM", UOM)
                    cmd.Parameters.AddWithValue("@piDA_Date", DateToCheck)
                    cmd.Parameters.AddWithValue("@piDE_Qty", Quantity)
                    cmd.Parameters.AddWithValue("@piIN_GetPromotion", "0")
                    cmd.Parameters.AddWithValue("@piST_Currency", "Z-US$")



                    prmPriceOut = New SqlParameter()
                    prmPriceOut.Direction = ParameterDirection.Output
                    prmPriceOut.SqlDbType = SqlDbType.Decimal
                    prmPriceOut.ParameterName = "@poDE_Price"
                    cmd.Parameters.Add(prmPriceOut)
                    cmd.Parameters.Add(GetOutputParameter("@poIN_PromFound", SqlDbType.Int))
                    cmd.Parameters.Add(GetOutputParameter("@poIN_PromType", SqlDbType.Int))
                    cmd.Parameters.Add(GetOutputParameter("@poDE_PromPrice", SqlDbType.Decimal))
                    cmd.Parameters.Add(GetOutputParameter("@poST_SchemeCode", SqlDbType.Char, 15))
                    cmd.Parameters.Add(GetOutputParameter("@poST_SchemeItemType", SqlDbType.Char, 1))
                    cmd.Parameters.Add(GetOutputParameter("@poST_SchemeGroup", SqlDbType.Char, 31))
                    cmd.Parameters.Add(GetOutputParameter("@poDE_QtyFrom", SqlDbType.Decimal))
                    cmd.Parameters.Add(GetOutputParameter("@poDE_QtyTo", SqlDbType.Decimal))
                    cmd.Parameters.Add(GetOutputParameter("@poIN_CurrPriceFound", SqlDbType.Int))
                    cmd.Parameters.Add(GetOutputParameter("@Description", SqlDbType.Int))
                    cmd.Parameters.Add(GetOutputParameter("@StartDate", SqlDbType.DateTime))
                    cmd.Parameters.Add(GetOutputParameter("@EndDate", SqlDbType.DateTime))
                    cmd.Parameters.Add(GetOutputParameter("@QuantityFree", SqlDbType.Decimal))
                    cmd.Parameters.Add(GetOutputParameter("@QuantityFrom", SqlDbType.Decimal))
                    cmd.Parameters.Add(GetOutputParameter("@QuantityTo", SqlDbType.Decimal))
                    cmd.Parameters.Add(GetOutputParameter("@PriceSheetID", SqlDbType.Char, 15))




                    con.Open()
                    cmd.ExecuteNonQuery()

                    For Each prm As SqlParameter In cmd.Parameters
                        If prm.Direction = ParameterDirection.Output Then
                            objOmniResult.OutputVariables.Add(prm.ParameterName, prm.Value.ToString)
                        End If

                    Next

                    If Not TypeOf prmPriceOut.Value Is System.DBNull Then
                        objOmniResult.Price = prmPriceOut.Value
                    End If


                End Using
                Return objOmniResult
            Catch ex As Exception
                Throw
            End Try
            '             

        End Function

    End Class
End Namespace