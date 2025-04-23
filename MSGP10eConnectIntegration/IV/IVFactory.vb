Imports System.Text.RegularExpressions
Imports System.IO
Imports system.Xml
Imports system.Xml.Serialization
Imports system.Text
Imports microsoft.Dynamics.GP
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
                    If IVTrx.TrxLines(j).SerialLotLines.Count > 0 Then
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
                    Exit Function
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

        'TODO: HWR 03/17/2012 - Complete this and copy to GP2010 assembly
        ''' <summary>
        ''' Creates or Updates and Item Master
        ''' If UpdateIfExists is false no update will be invoked and no error will be thrown
        ''' </summary>
        ''' <param name="IVItem"></param>
        ''' <param name="UpdateIfExists"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateUpdateIVItem(ByVal IVItem As IVItemMaster, Optional ByVal UpdateIfExists As Boolean = True) As Boolean
            Dim taIV As New eConnect.Serialization.IVItemMasterType
            Dim taIVItem As New eConnect.Serialization.taUpdateCreateItemRcd

            With taIVItem
                .ITEMNMBR = IVItem.ItemNumber
                .ITEMDESC = IVItem.ItemDescription
                .ITMSHNAM = IVItem.ItemShortName
                .ITMGEDSC = IVItem.ItemGenericDescription
                .ITMCLSCD = IVItem.ItemClassCode
                .ITEMTYPE = IVItem.ItemType
                .ITEMTYPESpecified = True
                .TAXOPTNS = IVItem.Taxable
                .TAXOPTNSSpecified = True
                .UOMSCHDL = IVItem.UnitOfMeasureScheduleId
                If IVItem.ItemType = IVItemMaster.ItemTypes.SalesInventory Or IVItem.ItemType = IVItemMaster.ItemTypes.Discontinued Or IVItem.ItemType = IVItemMaster.ItemTypes.Kit Then
                    If IVItem.ShippingWeight.HasValue Then
                        .ITEMSHWT = IVItem.ShippingWeight
                        .ITEMSHWTSpecified = True
                    End If
                End If
                If Not String.IsNullOrEmpty(IVItem.NoteText) Then
                    .NOTETEXT = IVItem.NoteText
                End If
                If IVItem.ListPrice.HasValue Then
                    .LISTPRCE = IVItem.ListPrice
                End If
                .UseItemClass = 1
                If UpdateIfExists Then
                    .UpdateIfExists = 1
                Else
                    .UpdateIfExists = 2
                End If

            End With
            Return CommonLogic.eConnectCreate(Me.MSGPConnectionString, IVItem)

        End Function

#End Region
    End Class
End Namespace

