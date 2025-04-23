Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace IV
    ''' <summary>
    ''' The factory for initiating transactions with MSGP Inventory
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IVFactory
        Private _mMSGPConnectionString As String
        Private _mExceptionMessages As New System.Collections.Specialized.StringCollection

#Region "Properties"
        Public Property MSGPConnectionString() As String
            Get
                Return _mMSGPConnectionString
            End Get
            Set(ByVal value As String)
                _mMSGPConnectionString = value
            End Set
        End Property
        Public Property ExceptionMessages() As System.Collections.Specialized.StringCollection
            Get
                Return _mExceptionMessages
            End Get
            Set(ByVal value As System.Collections.Specialized.StringCollection)
                _mExceptionMessages = value
            End Set
        End Property
#End Region
#Region "Public Methods"

        ''' <summary>
        ''' Creates only using doc exchange. Does not perform updates.
        ''' </summary>
        ''' <param name="ItemMaster"></param>
        ''' <returns></returns>
        Public Function CreateItemMaster(ItemMaster As IVItemMaster) As String
            Try
                Me.ExceptionMessages.Clear()

                Helper.ValidateMSGPRequiredFieldsComplete(ItemMaster)

                Dim taIV As New eConnect.Serialization.IVItemMasterType
                'Dim taIVItems As eConnect.Serialization.taCreateItemVendors_ItemsTaCreateItemVendors

                With taIV
                    .taUpdateCreateItemRcd = New eConnect.Serialization.taUpdateCreateItemRcd
                    With .taUpdateCreateItemRcd
                        .ITEMNMBR = ItemMaster.ItemNumber.PadRight(31)
                        .ITEMDESC = ItemMaster.ItemDescription
                        .ITMCLSCD = ItemMaster.ItemClassId.PadRight(11)
                        .LOCNCODE = ItemMaster.LocationId.PadRight(11)
                        .UOMSCHDL = ItemMaster.UOMSchedule
                        .UpdateIfExists = 0
                    End With

                    ' Create IV Item Vendors
                    '.taCreateItemVendors_Items

                    If ItemMaster.PriceList IsNot Nothing Then

                        If ItemMaster.PriceList.Count > 0 Then
                            .taIVCreateItemPriceListLine_Items = GetSerializationPriceListLines(ItemMaster.PriceList, 0)
                        End If
                    End If
                End With

                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, taIV) <> True Then
                    Return String.Empty
                End If

                Return ItemMaster.ItemNumber
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Updates only using field level updates. Does not perform doc exchange.
        ''' </summary>
        ''' <param name="ItemMaster"></param>
        ''' <returns></returns>
        Public Function UpdateItemMaster(ItemMaster As IVItemMaster) As String
            Try
                Me.ExceptionMessages.Clear()

                Helper.ValidateMSGPRequiredFieldsComplete(ItemMaster)

                Dim taUpdateCreateItemRcd As eConnect.Serialization.taUpdateCreateItemRcd = GetItemMasterForTransaction(ItemMaster.ItemNumber)
                If taUpdateCreateItemRcd Is Nothing Then
                    Throw New ArgumentException("Could not find an existing item.", "ItemMaster")
                End If

                Dim taIV As New eConnect.Serialization.IVItemMasterType
                'Dim taIVItems As eConnect.Serialization.taCreateItemVendors_ItemsTaCreateItemVendors

                With taIV
                    .taUpdateCreateItemRcd = taUpdateCreateItemRcd
                    With .taUpdateCreateItemRcd
                        .ITEMNMBR = ItemMaster.ItemNumber?.PadRight(31)
                        .ITEMDESC = ItemMaster.ItemDescription
                        .ITMCLSCD = ItemMaster.ItemClassId?.PadRight(11)
                        .LOCNCODE = ItemMaster.LocationId?.PadRight(11)
                        .UOMSCHDL = ItemMaster.UOMSchedule
                        .UpdateIfExists = 1
                    End With

                    ' Create IV Item Vendors
                    '.taCreateItemVendors_Items

                    ' Check for existing price list
                    Dim existingPriceListLines = GetPriceListLinesForTransaction(ItemMaster.ItemNumber)
                    If ItemMaster.PriceList?.Count > 0 OrElse existingPriceListLines.Length > 0 Then
                        ' Get lines for transaction if any exist (already queried, passed as parameter) or are to be added
                        .taIVCreateItemPriceListLine_Items = GetSerializationPriceListLinesForTransaction(ItemMaster.PriceList, existingPriceListLines)
                    End If

                End With

                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, taIV) <> True Then
                    Return String.Empty
                End If

                Return ItemMaster.ItemNumber
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        Public Function CreatePriceLevel(priceLevel As IVPriceLevel) As String
            Try
                Me.ExceptionMessages.Clear()

                Helper.ValidateMSGPRequiredFieldsComplete(priceLevel)

                Dim taIV As New eConnect.Serialization.IVCreatePriceLevelType

                With taIV
                    .taIVCreatePriceLevel = New eConnect.Serialization.taIVCreatePriceLevel
                    With .taIVCreatePriceLevel
                        .PRCLEVEL = priceLevel.PriceLevel?.PadRight(11)
                        If Not String.IsNullOrEmpty(priceLevel.Description) Then
                            .DSCRIPTN = priceLevel.Description
                        End If
                    End With
                End With

                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, taIV) <> True Then
                    Return String.Empty
                End If

                Return priceLevel.PriceLevel
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        Public Function CreatePriceList(priceList As IVPriceList) As String
            Try
                Me.ExceptionMessages.Clear()

                Helper.ValidateMSGPRequiredFieldsComplete(priceList)

                Dim taIV As New eConnect.Serialization.IVCreateItemPriceListType
                Dim taUpdateCreateItemRcd As New eConnect.Serialization.taIVCreateItemPriceListHeader

                With taIV
                    If priceList.Count > 0 Then
                        .taIVCreateItemPriceListLine_Items = GetSerializationPriceListLines(priceList, 0)
                    End If
                End With

                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, taIV) <> True Then
                    Return String.Empty
                End If

                Return priceList.ItemNumber
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        Public Function UpdatePriceList(priceList As IVPriceList) As String
            Try
                Me.ExceptionMessages.Clear()

                Helper.ValidateMSGPRequiredFieldsComplete(priceList)

                ' Check for existing price list
                Dim existingPriceListLines = GetPriceListLinesForTransaction(priceList.ItemNumber)
                If existingPriceListLines Is Nothing Then
                    Throw New ArgumentException("Could not find an existing price list for its item number. To avoid this error, create the price list before attempting to update.", "priceList")
                End If

                Dim taIV As New eConnect.Serialization.IVCreateItemPriceListType
                Dim taUpdateCreateItemRcd As New eConnect.Serialization.taIVCreateItemPriceListHeader

                With taIV
                    If priceList?.Count > 0 OrElse existingPriceListLines.Length > 0 Then
                        ' Get lines for transaction if any exist (already queried, passed as parameter) or are to be added
                        .taIVCreateItemPriceListLine_Items = GetSerializationPriceListLinesForTransaction(priceList, existingPriceListLines)
                    End If
                End With

                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, taIV) <> True Then
                    Return String.Empty
                End If

                Return priceList.ItemNumber
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Use to create a vendor item reference
        ''' </summary>
        ''' <param name="VendorItem"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateUpdateVendorItem(VendorItem As IVVendorItem) As Boolean
            Try
                Me.ExceptionMessages.Clear()
                Dim taIV As New eConnect.Serialization.IVVendorItemType
                'Dim taIVItems As eConnect.Serialization.taCreateItemVendors_ItemsTaCreateItemVendors
                With taIV
                    ReDim .taCreateItemVendors_Items(0)
                    .taCreateItemVendors_Items(0) = New eConnect.Serialization.taCreateItemVendors_ItemsTaCreateItemVendors
                    With .taCreateItemVendors_Items(0)
                        .ITEMNMBR = VendorItem.ItemNumber
                        .VENDORID = VendorItem.VendorId
                        .VNDITNUM = VendorItem.VendorItemNumber

                    End With
                End With
                Return CommonLogic.eConnectCreate(Me.MSGPConnectionString, taIV)
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Use to create inventory transfer transactions
        ''' </summary>
        ''' <param name="IVTrx"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateInventoryTransfer(ByVal IVTrx As IVTransfer) As Boolean
            Dim taIV As New eConnect.Serialization.IVInventoryTransferType
            Dim taIVHdr As New eConnect.Serialization.taIVTransferHeaderInsert
            Dim taIVLines() As eConnect.Serialization.taIVTransferLineInsert_ItemsTaIVTransferLineInsert
            Dim taIVSerialNumbers() As eConnect.Serialization.taIVTransferSerialInsert_ItemsTaIVTransferSerialInsert
            Dim taIVLotNumbers() As eConnect.Serialization.taIVTransferLotInsert_ItemsTaIVTransferLotInsert
            Dim IVLine As IV.IVTransferLine
            Dim IVSerialLot As IVSerialLotLine

            Try
                Me.ExceptionMessages.Clear()
                'validate


                'set header values
                If IVTrx.TrxNumber = String.Empty Then
                    IVTrx.TrxNumber = CommonLogic.GetDocNumber(Me.MSGPConnectionString, CommonLogic.DocNumberTypes.IVTransfer)
                End If
                With taIVHdr
                    .BACHNUMB = IVTrx.TrxBatchNo
                    .DOCDATE = IVTrx.TrxDate
                    .IVDOCNBR = IVTrx.TrxNumber
                    .POSTTOGL = 1
                End With
                'iterate through line items and set line details
                ReDim taIVLines(IVTrx.TrxLines.Count - 1)
                For j As Integer = 0 To IVTrx.TrxLines.Count - 1
                    taIVLines(j) = New eConnect.Serialization.taIVTransferLineInsert_ItemsTaIVTransferLineInsert
                    With taIVLines(j)
                        .IVDOCNBR = IVTrx.TrxNumber
                        .ITEMNMBR = IVTrx.TrxLines(j).ItemCode
                        .TRXLOCTN = IVTrx.TrxLines(j).FromSite
                        .TRNSTLOC = IVTrx.TrxLines(j).ToSite
                        .TRFQTYTY = IVTrx.TrxLines(j).FromSiteType
                        .TRTQTYTY = IVTrx.TrxLines(j).ToSiteType
                        .TRXQTY = IVTrx.TrxLines(j).TrxQty
                        .LNSEQNBR = 16384 * (j + 1)
                    End With

                    'handle serial/lot numbers
                    If IVTrx.TrxLines(j).SerialLotLines IsNot Nothing AndAlso IVTrx.TrxLines(j).SerialLotLines.Count > 0 Then
                        'handle serial numbers
                        If IVTrx.TrxLines(j).SerialLotLines.SerialLotType = SerialLotTypes.SerialNumber Then
                            For k As Integer = 0 To IVTrx.TrxLines(j).SerialLotLines.Count - 1
                                'extend array to hold next item
                                If taIVSerialNumbers IsNot Nothing Then
                                    ReDim Preserve taIVSerialNumbers(taIVSerialNumbers.Length)
                                Else
                                    ReDim Preserve taIVSerialNumbers(0)
                                End If
                                IVSerialLot = IVTrx.TrxLines(j).SerialLotLines(k)
                                taIVSerialNumbers(taIVSerialNumbers.Length - 1) = New eConnect.Serialization.taIVTransferSerialInsert_ItemsTaIVTransferSerialInsert
                                With taIVSerialNumbers(taIVSerialNumbers.Length - 1)
                                    .IVDOCNBR = IVTrx.TrxNumber
                                    .AUTOCREATESERIAL = 1
                                    .CreateBin = 1
                                    .LNSEQNBR = taIVLines(j).LNSEQNBR
                                    .ITEMNMBR = IVTrx.TrxLines(j).ItemCode
                                    .LOCNCODE = IVTrx.TrxLines(j).ToSite
                                    .QTYTYPE = IVTrx.TrxLines(j).ToSiteType
                                    .SERLNMBR = IVSerialLot.SerialLotNumber
                                End With
                            Next

                        End If
                        'handle lot numbers
                        If IVTrx.TrxLines(j).SerialLotLines.SerialLotType = SerialLotTypes.LotNumber Then

                            For k As Integer = 0 To IVTrx.TrxLines(j).SerialLotLines.Count - 1
                                'extend array to hold next item
                                If taIVLotNumbers IsNot Nothing Then
                                    ReDim Preserve taIVLotNumbers(taIVLotNumbers.Length)
                                Else
                                    ReDim Preserve taIVLotNumbers(0)
                                End If
                                IVSerialLot = IVTrx.TrxLines(j).SerialLotLines(k)
                                taIVLotNumbers(taIVLotNumbers.Length - 1) = New eConnect.Serialization.taIVTransferLotInsert_ItemsTaIVTransferLotInsert
                                With taIVLotNumbers(taIVLotNumbers.Length - 1)
                                    .IVDOCNBR = IVTrx.TrxNumber
                                    .LNSEQNBR = taIVLines(j).LNSEQNBR
                                    .ITEMNMBR = IVTrx.TrxLines(j).ItemCode
                                    .QTYTYPE = IVTrx.TrxLines(j).FromSiteType
                                    .LOTNUMBR = IVSerialLot.SerialLotNumber
                                    .SERLTQTY = IVSerialLot.TrxQty
                                    .LOCNCODE = IVTrx.TrxLines(j).FromSite
                                End With
                            Next
                        End If
                    End If

                Next
                taIV.taIVTransferHeaderInsert = taIVHdr
                taIV.taIVTransferLineInsert_Items = taIVLines
                If taIVSerialNumbers IsNot Nothing AndAlso taIVSerialNumbers.Length > 0 Then
                    taIV.taIVTransferSerialInsert_Items = taIVSerialNumbers
                End If
                If taIVLotNumbers IsNot Nothing AndAlso taIVLotNumbers.Length > 0 Then
                    taIV.taIVTransferLotInsert_Items = taIVLotNumbers
                End If
                Return CommonLogic.eConnectCreate(Me.MSGPConnectionString, taIV)
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' Use to create inventory adjustment transactions
        ''' </summary>
        ''' <param name="IVTrx"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateInventoryAdjustment(ByVal IVTrx As IVAdjustment) As Boolean
            Dim taIV As New eConnect.Serialization.IVInventoryTransactionType
            Dim taIVHdr As New eConnect.Serialization.taIVTransactionHeaderInsert
            Dim taIVLines() As eConnect.Serialization.taIVTransactionLineInsert_ItemsTaIVTransactionLineInsert
            Dim taIVSerialNumbers() As eConnect.Serialization.taIVTransactionSerialInsert_ItemsTaIVTransactionSerialInsert
            Dim taIVLotNumbers() As eConnect.Serialization.taIVTransactionLotInsert_ItemsTaIVTransactionLotInsert

            Dim IVLine As IVAdjustmentLine
            Dim IVSerialLot As IVSerialLotLine

            Try
                Me.ExceptionMessages.Clear()
                'validate
                If Me.ValidateIVAdjustmentTrx(IVTrx) = False Then
                    Return False
                End If

                'set header values
                If IVTrx.TrxNumber = String.Empty Then
                    IVTrx.TrxNumber = CommonLogic.GetDocNumber(Me.MSGPConnectionString, CommonLogic.DocNumberTypes.IVAdjustment)
                End If
                With taIVHdr
                    .BACHNUMB = IVTrx.TrxBatchNo
                    .DOCDATE = IVTrx.TrxDate
                    .IVDOCNBR = IVTrx.TrxNumber
                    .POSTTOGL = 1
                    .IVDOCTYP = 1
                End With
                'iterate through line items and set line details
                ReDim taIVLines(IVTrx.TrxLines.Count - 1)
                For j As Integer = 0 To IVTrx.TrxLines.Count - 1
                    taIVLines(j) = New eConnect.Serialization.taIVTransactionLineInsert_ItemsTaIVTransactionLineInsert
                    IVLine = IVTrx.TrxLines(j)
                    With taIVLines(j)
                        .IVDOCNBR = IVTrx.TrxNumber
                        .ITEMNMBR = IVTrx.TrxLines(j).ItemCode
                        .IVDOCTYP = 1
                        .TRXLOCTN = IVLine.SiteId
                        .TRXQTY = IVLine.TrxQty
                        .LNSEQNBR = 16384 * (j + 1)
                        If IVLine.UnitCost <> 0 Then
                            .UNITCOST = IVLine.UnitCost
                            .UNITCOSTSpecified = True
                        End If

                        'handle serial/lot numbers
                        If IVLine.SerialLotLines.Count > 0 Then
                            'handle serial numbers
                            If IVLine.SerialLotLines.SerialLotType = SerialLotTypes.SerialNumber Then
                                For k As Integer = 0 To IVLine.SerialLotLines.Count - 1
                                    'extend array to hold next item
                                    If taIVSerialNumbers IsNot Nothing Then
                                        ReDim Preserve taIVSerialNumbers(taIVSerialNumbers.Length)
                                    Else
                                        ReDim Preserve taIVSerialNumbers(0)
                                    End If
                                    IVSerialLot = IVLine.SerialLotLines(k)
                                    'set the last array element values
                                    taIVSerialNumbers(taIVSerialNumbers.Length - 1) = New eConnect.Serialization.taIVTransactionSerialInsert_ItemsTaIVTransactionSerialInsert
                                    With taIVSerialNumbers(taIVSerialNumbers.Length - 1)
                                        .IVDOCNBR = IVTrx.TrxNumber
                                        .LNSEQNBR = taIVLines(j).LNSEQNBR
                                        .ITEMNMBR = IVLine.ItemCode
                                        .IVDOCTYP = 1
                                        .LOCNCODE = IVLine.SiteId
                                        If IVSerialLot.TrxQty >= 0 Then
                                            'If IVLine.TrxQty >= 0 Then
                                            .ADJTYPE = 0
                                        Else
                                            .ADJTYPE = 1
                                        End If
                                        .SERLNMBR = IVSerialLot.SerialLotNumber
                                    End With
                                Next

                            End If
                            'handle lot numbers
                            If IVLine.SerialLotLines.SerialLotType = SerialLotTypes.LotNumber Then
                                For k As Integer = 0 To IVLine.SerialLotLines.Count - 1
                                    'extend array to hold next item
                                    If taIVLotNumbers IsNot Nothing Then
                                        ReDim Preserve taIVLotNumbers(taIVLotNumbers.Length + 1)
                                    Else
                                        ReDim Preserve taIVLotNumbers(0)
                                    End If
                                    IVSerialLot = IVLine.SerialLotLines(k)
                                    taIVLotNumbers(taIVLotNumbers.Length - 1) = New eConnect.Serialization.taIVTransactionLotInsert_ItemsTaIVTransactionLotInsert
                                    With taIVLotNumbers(taIVLotNumbers.Length - 1)
                                        .IVDOCNBR = IVTrx.TrxNumber
                                        .LNSEQNBR = taIVLines(j).LNSEQNBR
                                        .ITEMNMBR = IVLine.ItemCode
                                        .IVDOCTYP = 1
                                        If IVSerialLot.TrxQty >= 0 Then
                                            'If IVLine.TrxQty >= 0 Then
                                            .ADJTYPE = 0
                                        Else
                                            .ADJTYPE = 1
                                        End If
                                        .LOTNUMBR = IVSerialLot.SerialLotNumber
                                        .SERLTQTY = IVSerialLot.TrxQty
                                    End With
                                Next
                            End If
                        End If
                    End With
                Next
                taIV.taIVTransactionHeaderInsert = taIVHdr
                taIV.taIVTransactionLineInsert_Items = taIVLines
                taIV.taIVTransactionSerialInsert_Items = taIVSerialNumbers

                CommonLogic.eConnectCreate(Me.MSGPConnectionString, taIV)
                Return True
            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        Private Function ValidateIVTransferTrx(ByVal IvTrx As IVTransfer) As Boolean
            Dim decLotQtySum As Decimal

            'check serial lot situation
            Me.ExceptionMessages.Clear()
            For Each IVTrxLine As IVTransferLine In IvTrx.TrxLines
                If IVTrxLine.SerialLotLines.SerialLotType = SerialLotTypes.SerialNumber Then
                    If IVTrxLine.SerialLotLines.Count <> IVTrxLine.TrxQty Then
                        Me.ExceptionMessages.Add("[" & IVTrxLine.ItemCode & "] Item serial details do not match the item qty")
                    End If
                ElseIf IVTrxLine.SerialLotLines.SerialLotType = SerialLotTypes.LotNumber Then
                    decLotQtySum = 0
                    For Each IVLot As IVSerialLotLine In IVTrxLine.SerialLotLines
                        decLotQtySum += IVLot.TrxQty
                    Next
                    If decLotQtySum <> IVTrxLine.TrxQty Then
                        Me.ExceptionMessages.Add("[" & IVTrxLine.ItemCode & "] Item lot details do not match the item qty")
                    End If
                End If

            Next
            If Me.ExceptionMessages.Count > 0 Then
                Return False
            Else
                Return True

            End If

        End Function

        Private Function ValidateIVAdjustmentTrx(ByVal IVTrx As IVAdjustment) As Boolean
            Dim decLotQtySum As Decimal
            Dim intCounted As Integer = 0

            'check serial lot situation
            Me.ExceptionMessages.Clear()
            For Each IVTrxLine As IVAdjustmentLine In IVTrx.TrxLines
                If IVTrxLine.SerialLotLines.SerialLotType = SerialLotTypes.SerialNumber Then
                    intCounted = 0
                    For Each IVSer As IVSerialLotLine In IVTrxLine.SerialLotLines
                        If IVSer.TrxQty >= 0 Then
                            intCounted += 1
                        Else
                            intCounted -= 1
                        End If
                    Next
                    If intCounted <> IVTrxLine.TrxQty Then
                        Me.ExceptionMessages.Add("[" & IVTrxLine.ItemCode & "] Item serial details do not match the item qty")
                    End If
                ElseIf IVTrxLine.SerialLotLines.SerialLotType = SerialLotTypes.LotNumber Then
                    decLotQtySum = 0
                    For Each IVLot As IVSerialLotLine In IVTrxLine.SerialLotLines
                        decLotQtySum += IVLot.TrxQty
                    Next
                    If decLotQtySum <> IVTrxLine.TrxQty Then
                        Me.ExceptionMessages.Add("[" & IVTrxLine.ItemCode & "] Item lot details do not match the item qty")
                    End If
                End If

            Next
            If Me.ExceptionMessages.Count > 0 Then
                Return False
            Else
                Return True

            End If
        End Function

        ''' <summary>
        ''' Returns serialized object for Item Master retrieved using the item number and the GP Object Library.
        ''' </summary>
        ''' <param name="itemNumber"></param>
        ''' <returns></returns>
        Private Function GetItemMasterForTransaction(itemNumber As String) As eConnect.Serialization.taUpdateCreateItemRcd
            Dim uowUnitOfWork As UnitOfWork
            Dim ivItemMaster As GP2010ObjectLibrary.Module.Objects.IV.IVItem
            Dim gpoGroupOperator As GroupOperator
            Dim taUpdateCreateItemRcd As eConnect.Serialization.taUpdateCreateItemRcd = Nothing
            uowUnitOfWork = New UnitOfWork
            uowUnitOfWork.ConnectionString = MSGPConnectionString

            gpoGroupOperator = New GroupOperator
            With gpoGroupOperator
                .Operands.Add(New BinaryOperator("ITEMNMBR", itemNumber))
            End With

            ivItemMaster = uowUnitOfWork.FindObject(Of GP2010ObjectLibrary.Module.Objects.IV.IVItem)(gpoGroupOperator)
            If ivItemMaster IsNot Nothing Then
                taUpdateCreateItemRcd = New eConnect.Serialization.taUpdateCreateItemRcd
                With taUpdateCreateItemRcd
                    .ITEMNMBR = itemNumber
                    .ITEMDESC = ivItemMaster.ITEMDESC
                    .ITMCLSCD = ivItemMaster.ITMCLSCD
                    .LOCNCODE = ivItemMaster.LOCNCODE
                    .UOMSCHDL = ivItemMaster.UOMSCHDL
                    .UpdateIfExists = 1
                End With
            End If
            Return taUpdateCreateItemRcd
        End Function

        ''' <summary>
        ''' Returns an array of serialized objects for Item Site retrieved using the item number and the GP Object Library.
        ''' </summary>
        ''' <param name="itemNumber"></param>
        ''' <returns></returns>
        Private Function GetItemSitesForTransaction(itemNumber As String) As eConnect.Serialization.taItemSite_ItemsTaItemSite()
            Dim uowUnitOfWork As UnitOfWork
            uowUnitOfWork = New UnitOfWork
            uowUnitOfWork.ConnectionString = MSGPConnectionString

            Dim lItemSites As New List(Of eConnect.Serialization.taItemSite_ItemsTaItemSite)
            Dim taUpdateCreateItemRcd As eConnect.Serialization.taItemSite_ItemsTaItemSite = Nothing
            Dim xpcItemSites As New XPCollection(Of GP2010ObjectLibrary.Module.Objects.IV.IVItemQuantity)(uowUnitOfWork, CriteriaOperator.Parse("ITEMNMBR = ?", itemNumber))

            For Each ivItemSite In xpcItemSites
                taUpdateCreateItemRcd = New eConnect.Serialization.taItemSite_ItemsTaItemSite
                With taUpdateCreateItemRcd
                    .ITEMNMBR = ivItemSite.Oid.ITEMNMBR
                    .LOCNCODE = ivItemSite.Oid.LOCNCODE
                    .UpdateIfExists = 1
                End With
                lItemSites.Add(taUpdateCreateItemRcd)
            Next

            Return lItemSites.ToArray()
        End Function

        ''' <summary>
        ''' Get serialization object array for price list lines on the price list header.
        ''' </summary>
        ''' <param name="priceList"></param>
        ''' <param name="UpdateIfExists">Defaults to 1. Set to 0 to use doc exchange for creation.</param>
        ''' <returns></returns>
        Private Function GetSerializationPriceListLines(priceList As IVPriceList, Optional UpdateIfExists As Short = 1) As eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine()
            Dim priceListLines As New List(Of eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine)

            ' Create list of lines from headers on price list parameter
            For Each header In priceList
                Dim maxQtyExists As Boolean = False

                For Each currentLine In header.PriceListLines
                    Helper.ValidateMSGPRequiredFieldsComplete(currentLine)
                    Dim taIVCreateItemPriceListLine_Item As New eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine
                    With taIVCreateItemPriceListLine_Item
                        .ITEMNMBR = priceList.ItemNumber?.PadRight(31)
                        .CURNCYID = header.CurrencyId?.PadRight(15)
                        .PRCLEVEL = header.PriceLevel?.PadRight(11)
                        .UOFM = header.UnitOfMeasure?.PadRight(9)
                        .TOQTY = currentLine.ToQuantity
                        .UOMPRICE = currentLine.UnitPrice
                        .UpdateIfExists = UpdateIfExists
                    End With
                    priceListLines.Add(taIVCreateItemPriceListLine_Item)

                    ' Ensure at least one list line has the maximum "To Quantity" for each header
                    If currentLine.ToQuantity = 999999999999 Then
                        maxQtyExists = True
                    End If
                Next

                ' Check max qty exists
                If Not maxQtyExists Then
                    Throw New ArgumentOutOfRangeException("The price list must contain at least one line with the maximum ""To Quantity"" value (999999999999) for each header.")
                End If
            Next

            Return priceListLines.ToArray()
        End Function

        ''' <summary>
        ''' Get serialization object array for price list lines on the price list header. Calls to GP Object Library to retrieve existing lines. Updates if exists.
        ''' </summary>
        ''' <param name="priceList">IV Price List Header</param>
        ''' <param name="ExistingLines">If has value, does not query GP and adds parameter lines to returned value.</param>
        ''' <returns></returns>
        Private Function GetSerializationPriceListLinesForTransaction(priceList As IVPriceList, Optional ExistingLines As eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine() = Nothing) As eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine()
            ' List to add/modify existing and new lines; return as array
            Dim serializationPriceListLines As New List(Of eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine)
            Dim headerMaxQtyExists As Boolean = False

            ' Create list and ensure at least one list line has the maximum "To Quantity"
            If ExistingLines IsNot Nothing Then
                For Each line In ExistingLines
                    serializationPriceListLines.Add(line)
                Next
            Else
                For Each line In GetPriceListLinesForTransaction(priceList.ItemNumber)
                    serializationPriceListLines.Add(line)
                Next
            End If

            ' Check for max qty on existing lines; skip if new lines added (checked while adding)
            If priceList?.Count = 0 Then
                For Each existingLine In serializationPriceListLines
                    If existingLine.TOQTY = 999999999999 Then
                        headerMaxQtyExists = True
                    End If
                Next
            End If

            ' Create list of lines from headers on price list parameter
            For Each header In priceList
                headerMaxQtyExists = False

                For Each currentLine In header.PriceListLines
                    Helper.ValidateMSGPRequiredFieldsComplete(currentLine)
                    Dim taIVCreateItemPriceListLine_Item As eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine = Nothing

                    ' Iterate over existing lines to check for max qty and existing line
                    For Each existingLine In serializationPriceListLines
                        ' Check for max qty on current header
                        If header.PriceLevel = existingLine.PRCLEVEL And header.CurrencyId = existingLine.CURNCYID And header.UnitOfMeasure = existingLine.UOFM Then
                            If existingLine.TOQTY = 999999999999 Then
                                headerMaxQtyExists = True
                            End If
                        End If

                        ' Check for existing line
                        If existingLine.PRCLEVEL = header.PriceLevel?.PadRight(11) AndAlso existingLine.TOQTY = currentLine.ToQuantity Then
                            taIVCreateItemPriceListLine_Item = existingLine
                        End If
                    Next

                    ' Create new if no existing line
                    If taIVCreateItemPriceListLine_Item Is Nothing Then
                        taIVCreateItemPriceListLine_Item = New eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine
                    End If

                    With taIVCreateItemPriceListLine_Item
                        .ITEMNMBR = priceList.ItemNumber?.PadRight(31)
                        .CURNCYID = header.CurrencyId?.PadRight(15)
                        .PRCLEVEL = header.PriceLevel?.PadRight(11)
                        .UOFM = header.UnitOfMeasure?.PadRight(9)
                        .TOQTY = currentLine.ToQuantity
                        .UOMPRICE = currentLine.UnitPrice
                        .UpdateIfExists = 1
                    End With
                    serializationPriceListLines.Add(taIVCreateItemPriceListLine_Item)

                    ' Ensure at least one list line has the maximum "To Quantity"
                    If currentLine.ToQuantity = 999999999999 Then
                        headerMaxQtyExists = True
                    End If
                Next

                ' Check max qty exists
                If Not headerMaxQtyExists Then
                    Throw New ArgumentOutOfRangeException("The price list must contain at least one line with the maximum ""To Quantity"" value (999999999999).")
                End If
            Next

            Return serializationPriceListLines.ToArray()
        End Function

        ''' <summary>
        ''' Retrieve the serialization price list lines for an item number using the GP Object Library. Updates if exists.
        ''' </summary>
        ''' <param name="ItemNumber"></param>
        ''' <returns></returns>
        Private Function GetPriceListLinesForTransaction(ItemNumber As String) As eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine()
            Dim taIVCreateItemPriceListLine_Items As eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine()
            Dim uowUnitOfWork = New UnitOfWork
            uowUnitOfWork.ConnectionString = MSGPConnectionString

            Dim xpcPriceListLines As New XPCollection(Of GP2010ObjectLibrary.Module.Objects.IV.IVItemPriceList)(uowUnitOfWork, CriteriaOperator.Parse("ITEMNMBR = ?", ItemNumber.PadRight(31)))

            ReDim taIVCreateItemPriceListLine_Items(xpcPriceListLines.Count - 1)
            For j As Integer = 0 To xpcPriceListLines.Count - 1
                Dim currentLine = xpcPriceListLines(j)
                taIVCreateItemPriceListLine_Items(j) = New eConnect.Serialization.taIVCreateItemPriceListLine_ItemsTaIVCreateItemPriceListLine
                With taIVCreateItemPriceListLine_Items(j)
                    .ITEMNMBR = ItemNumber?.PadRight(31)
                    .CURNCYID = currentLine.CURNCYID?.PadRight(15)
                    .PRCLEVEL = currentLine.PRCLEVEL?.PadRight(11)
                    .UOFM = currentLine.UOFM?.PadRight(9)
                    .TOQTY = currentLine.TOQTY
                    .UOMPRICE = currentLine.UOMPRICE
                    .UpdateIfExists = 1
                End With
            Next

            Return taIVCreateItemPriceListLine_Items
        End Function

#End Region
    End Class
End Namespace

