Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace POP
    Public Class POPFactory
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

        Private Sub HandleException(ByVal ex As Exception)
            Me._mExceptionMessages.Add(ex.Message)
            If ex.InnerException IsNot Nothing Then
                Me.HandleException(ex.InnerException)
            End If
        End Sub

#End Region

#Region "Operations"
        Public Function CreatePOReceipt(ByVal POTrx As POPReceipt) As Boolean
            Dim POFactory As New POPFactory
            Dim taPO As New eConnect.Serialization.POPReceivingsType
            Dim taPOPHdr As New eConnect.Serialization.taPopRcptHdrInsert
            Dim taPOPLines() As eConnect.Serialization.taPopRcptLineInsert_ItemsTaPopRcptLineInsert
            Dim taPOPSerialNumbers() As eConnect.Serialization.taPopRcptSerialInsert_ItemsTaPopRcptSerialInsert
            Dim taPOPLotNumbers() As eConnect.Serialization.taPopRcptLotInsert_ItemsTaPopRcptLotInsert

            Dim POLine As POPReceiptLine
            Dim POSerialLot As POPSerialLotLine

            Try
                Me.ExceptionMessages.Clear()
                'validate

                'set header values
                If POTrx.ReceiptNumber = String.Empty Then
                    POTrx.ReceiptNumber = CommonLogic.GetNextPOPReceiptDocNumber(Me.MSGPConnectionString)
                End If
                With taPOPHdr
                    .BACHNUMB = POTrx.BatchId
                    .receiptdate = POTrx.ReceiptDate.ToShortDateString
                    .POPRCTNM = POTrx.ReceiptNumber
                    .ACTLSHIP = POTrx.ActualShipDate.ToShortDateString
                    .NOTETEXT = POTrx.NoteText
                    .POPTYPE = POTrx.Type
                    .REFRENCE = POTrx.Reference
                    .VNDDOCNM = POTrx.VendorDocumentReference
                    .VENDORID = POTrx.VendorId
                    If POTrx.AutoCost = True Then
                        .AUTOCOST = 1
                    Else
                        .AUTOCOST = 0
                    End If
                    .TRDISAMT = 0
                End With

                'iterate through line items and set line details
                ReDim taPOPLines(POTrx.POLines.Count - 1)
                For j As Integer = 0 To POTrx.POLines.Count - 1
                    taPOPLines(j) = New eConnect.Serialization.taPopRcptLineInsert_ItemsTaPopRcptLineInsert
                    POLine = POTrx.POLines(j)
                    With taPOPLines(j)
                        .PONUMBER = POLine.PONumber
                        .ITEMNMBR = POLine.ItemNumber
                        .QTYINVCD = POLine.QuantityInvoiced
                        .QTYSHPPD = POLine.QuantityShipped
                        .UNITCOST = POLine.UnitCost
                        .receiptdate = POLine.ReceiptDate
                        .POPRCTNM = POTrx.ReceiptNumber
                        .VENDORID = taPOPHdr.VENDORID
                        .POPTYPE = POTrx.Type
                        .UOFM = POLine.UnitOfMeasure
                        .LOCNCODE = POLine.SiteId
                        .RCPTLNNM = 16384 * (j + 1)
                        If POLine.AutoCost = True Then
                            .AUTOCOST = 1
                        Else
                            .AUTOCOST = 0
                        End If

                        'If POLine.ExtendedCost.HasValue Then
                        '    .EXTDCOST = POLine.ExtendedCost
                        'End If

                    End With

                    'handle serial/lot numbers
                    If POLine.SerialLotLines.Count > 0 Then
                        'handle serial numbers
                        If POLine.SerialLotLines.SerialLotType = SerialLotTypes.SerialNumber Then
                            ReDim Preserve taPOPSerialNumbers(POLine.SerialLotLines.Count)
                            For k As Integer = 0 To POLine.SerialLotLines.Count - 1
                                POSerialLot = POLine.SerialLotLines(k)
                                taPOPSerialNumbers(taPOPSerialNumbers.Length - 1) = New eConnect.Serialization.taPopRcptSerialInsert_ItemsTaPopRcptSerialInsert
                                With taPOPSerialNumbers(taPOPSerialNumbers.Length - 1)
                                    .ITEMNMBR = POLine.ItemNumber
                                    .LOCNCODE = POLine.SiteId
                                    .POPRCTNM = POTrx.ReceiptNumber
                                    .RCPTLNNM = taPOPLines(j).RCPTLNNM
                                    .SERLTNUM = POSerialLot.SerialLotNumber
                                End With
                            Next
                            taPO.taPopRcptSerialInsert_Items = taPOPSerialNumbers
                        End If
                        'handle lot numbers
                        If POLine.SerialLotLines.SerialLotType = SerialLotTypes.LotNumber Then
                            ReDim Preserve taPOPLotNumbers(POLine.SerialLotLines.Count)
                            For k As Integer = 0 To POLine.SerialLotLines.Count - 1
                                POSerialLot = POLine.SerialLotLines(k)
                                taPOPLotNumbers(taPOPLotNumbers.Length - 1) = New eConnect.Serialization.taPopRcptLotInsert_ItemsTaPopRcptLotInsert
                                With taPOPLotNumbers(taPOPLotNumbers.Length - 1)
                                    .ITEMNMBR = POLine.ItemNumber
                                    .LOCNCODE = POLine.SiteId
                                    .POPRCTNM = POTrx.ReceiptNumber
                                    .RCPTLNNM = taPOPLines(j).RCPTLNNM
                                    .SERLTNUM = POSerialLot.SerialLotNumber
                                    .SERLTQTY = POSerialLot.TrxQty
                                End With
                            Next
                            taPO.taPopRcptLotInsert_Items = taPOPLotNumbers
                        End If
                    End If

                Next
                taPO.taPopRcptHdrInsert = taPOPHdr
                taPO.taPopRcptLineInsert_Items = taPOPLines
                Return CommonLogic.eConnectCreate(Me.MSGPConnectionString, taPO)

            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try

        End Function

        Public Function GetNextPoNumber() As String
            Dim ndn As New eConnect.GetNextDocNumbers
            With ndn
                Return .GetNextPONumber(eConnect.IncrementDecrement.Increment, MSGPConnectionString)
            End With
        End Function

        ''' <summary>
        ''' Create a PO Header. Creates only; does not update.
        ''' </summary>
        ''' <param name="PoHeader"></param>
        ''' <returns></returns>
        Public Function CreatePoHeader(ByRef PoHeader As POHeader) As String
            Me._mExceptionMessages.Clear()

            Try
                Helper.ValidateMSGPRequiredFieldsComplete(PoHeader)

                Dim POP As New Microsoft.Dynamics.GP.eConnect.Serialization.POPTransactionType

                Dim taPoHdr As New eConnect.Serialization.taPoHdr
                Dim taPoLine_Item As eConnect.Serialization.taPoLine_ItemsTaPoLine
                Dim taPoLine_Items() As eConnect.Serialization.taPoLine_ItemsTaPoLine
                Dim PoLine As POP.POLine

                With taPoHdr
                    .POTYPE = PoHeader.PoType
                    .POTYPESpecified = PoHeader.PoType > 0
                    .PONUMBER = PoHeader.PoNumber.PadRight(17) ' required
                    .VENDORID = PoHeader.VendorId ' required
                    .VENDNAME = PoHeader.VendorName
                    .DOCDATE = PoHeader.DocumentDate
                    .TRDISAMT = PoHeader.TradeDiscountAmount
                    .TRDISAMTSpecified = PoHeader.TradeDiscountAmount > 0
                    .FRTAMNT = PoHeader.FreightAmount
                    .FRTAMNTSpecified = PoHeader.FreightAmount > 0
                    .MSCCHAMT = PoHeader.MiscellaneousChargeAmount
                    .MSCCHAMTSpecified = PoHeader.MiscellaneousChargeAmount > 0
                    .TAXAMNT = PoHeader.TaxAmount
                    .TAXAMNTSpecified = PoHeader.TaxAmount > 0
                    .SUBTOTAL = PoHeader.Subtotal ' required
                    .CUSTNMBR = PoHeader.CustomerNumber
                    .PRSTADCD = PoHeader.ShipToAddressCode
                    .CMPNYNAM = PoHeader.CompanyName
                    .CONTACT = PoHeader.Contact
                    .ADDRESS1 = PoHeader.Address1
                    .ADDRESS2 = PoHeader.Address2
                    .ADDRESS3 = PoHeader.Address3
                    .CITY = PoHeader.City
                    .STATE = PoHeader.State
                    .ZIPCODE = PoHeader.Zip
                    .VADCDPAD = PoHeader.VendorAddressCode
                    .PURCHCMPNYNAM = PoHeader.PurchaseCompanyName
                    .PURCHCONTACT = PoHeader.PurchaseContact
                    .PURCHADDRESS1 = PoHeader.PurchaseAddress1
                    .PURCHADDRESS2 = PoHeader.PurchaseAddress2
                    .PURCHADDRESS3 = PoHeader.PurchaseAddress3
                    .PURCHCITY = PoHeader.PurchaseCity
                    .PURCHSTATE = PoHeader.PurchaseState
                    .PURCHZIPCODE = PoHeader.PurchaseZip
                    .PRBTADCD = PoHeader.BillToAddressCode
                    .SHIPMTHD = PoHeader.ShippingMethod
                    .PYMTRMID = PoHeader.PaymentTermsId
                    If PoHeader.DueDate.HasValue Then
                        .DUEDATE = PoHeader.DueDate.Value.ToString("MM/dd/yyyy")
                    End If
                    .TAXSCHID = PoHeader.TaxScheduleId
                    .USERID = PoHeader.UserToEnter
                    .POSTATUS = PoHeader.PoStatus
                    .POSTATUSSpecified = PoHeader.PoStatus > 0
                    .NOTETEXT = PoHeader.NoteText
                    .USRDEFND1 = PoHeader.UserDefined1
                    .USRDEFND2 = PoHeader.UserDefined2
                    .USRDEFND3 = PoHeader.UserDefined3
                    .USRDEFND4 = PoHeader.UserDefined4
                    .USRDEFND5 = PoHeader.UserDefined5
                    ' DO NOT UPDATE - ONLY CREATE
                    .UpdateIfExists = 0
                End With

                'dimension the line item details to hold the incoming details
                ReDim taPoLine_Items(PoHeader.POLines.Count - 1)

                ' existing lines will be removed from the list as they're matched to lines on the order; remaining items will be used to create line delete transaction objects
                For j As Integer = 0 To PoHeader.POLines.Count - 1
                    PoLine = PoHeader.POLines(j)
                    Helper.ValidateMSGPRequiredFieldsComplete(PoLine)

                    taPoLine_Items(j) = New eConnect.Serialization.taPoLine_ItemsTaPoLine()

                    ' Populate the line values
                    With taPoLine_Items(j)
                        .PONUMBER = taPoHdr.PONUMBER ' required
                        .VENDORID = taPoHdr.VENDORID ' required
                        .DOCDATE = PoLine.DocumentDate
                        .ITEMNMBR = PoLine.ItemNumber
                        .ITEMDESC = PoLine.ItemDescription
                        .UOFM = PoLine.UnitOfMeasure
                        .QUANTITY = PoLine.Quantity
                        .QUANTITYSpecified = True
                        .UNITCOST = PoLine.UnitCost
                        .UNITCOSTSpecified = PoLine.UnitCost > 0
                        .POLNESTA = PoLine.PoLineStatus
                        .POLNESTASpecified = PoLine.PoLineStatus > 0
                        .POTYPE = PoLine.PoType
                        .POTYPESpecified = PoLine.PoType > 0
                        If Not String.IsNullOrEmpty(PoLine.NonInventory) Then
                            .NONINVEN = PoLine.NonInventory
                        End If
                        If Not String.IsNullOrEmpty(PoLine.LocationId) Then
                            .LOCNCODE = PoLine.LocationId
                        End If
                        If Not String.IsNullOrEmpty(PoLine.VendorItemNumber) Then
                            .VNDITNUM = PoLine.VendorItemNumber
                        End If
                        If Not String.IsNullOrEmpty(PoLine.VendorItemDescription) Then
                            .VNDITDSC = PoLine.VendorItemDescription
                        End If
                        If Not String.IsNullOrEmpty(PoLine.InventoryAccountIndex) Then
                            .IVIVINDX = PoLine.InventoryAccountIndex
                        End If
                        If Not String.IsNullOrEmpty(PoLine.InventoryAccount) Then
                            .InventoryAccount = PoLine.InventoryAccount
                        End If
                        If Not String.IsNullOrEmpty(PoLine.ShippingMethod) Then
                            .SHIPMTHD = PoLine.ShippingMethod
                        End If
                        If String.IsNullOrEmpty(taPoHdr.CUSTNMBR) Then
                            .CUSTNMBR = taPoHdr.CUSTNMBR
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined1) Then
                            .USRDEFND1 = PoLine.UserDefined1
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined2) Then
                            .USRDEFND2 = PoLine.UserDefined2
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined3) Then
                            .USRDEFND3 = PoLine.UserDefined3
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined4) Then
                            .USRDEFND4 = PoLine.UserDefined4
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined5) Then
                            .USRDEFND5 = PoLine.UserDefined5
                        End If
                        ' DO NOT UPDATE - CREATE ONLY
                        .UpdateIfExists = 0
                        .ORDSpecified = .ORD > 0
                    End With
                Next

                With POP
                    .taPoHdr = taPoHdr
                    .taPoLine_Items = taPoLine_Items
                End With

                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, POP) <> True Then
                    Return String.Empty
                End If

                Return PoHeader.PoNumber
            Catch ex As Exception

                Me.HandleException(ex)
                Return String.Empty
            End Try

        End Function

        ''' <summary>
        ''' Update an existing PO Header. Updates only; does not create.
        ''' </summary>
        ''' <param name="PoHeader"></param>
        ''' <returns></returns>
        Public Function UpdatePoHeader(ByRef PoHeader As POHeader) As String
            Me._mExceptionMessages.Clear()

            Try
                Helper.ValidateMSGPRequiredFieldsComplete(PoHeader)

                Dim taPoHdr As eConnect.Serialization.taPoHdr = GetPoHeaderForTransaction(PoHeader.PoNumber)
                If taPoHdr Is Nothing Then
                    Throw New ArgumentException("Could not find an existing PO Header.", "PoHeader")
                End If

                Dim POP As New Microsoft.Dynamics.GP.eConnect.Serialization.POPTransactionType
                Dim taPoLine_Items() As eConnect.Serialization.taPoLine_ItemsTaPoLine
                Dim ltaPoLine_Items = New List(Of eConnect.Serialization.taPoLine_ItemsTaPoLine)()
                Dim PoLine As POP.POLine

                ' empty/null/0 values are not posted when updating (field level)
                With taPoHdr
                    .PONUMBER = PoHeader.PoNumber.PadRight(17) ' required
                    .VENDORID = PoHeader.VendorId ' required
                    .DOCDATE = PoHeader.DocumentDate
                    If Not String.IsNullOrEmpty(PoHeader.VendorName) Then
                        .VENDNAME = PoHeader.VendorName
                    End If
                    If PoHeader.PoType > 0 Then
                        .POTYPE = PoHeader.PoType
                        .POTYPESpecified = True
                    End If
                    If PoHeader.TradeDiscountAmount > 0 Then
                        .TRDISAMT = PoHeader.TradeDiscountAmount
                        .TRDISAMTSpecified = True
                    End If
                    If PoHeader.FreightAmount > 0 Then
                        .FRTAMNT = PoHeader.FreightAmount
                        .FRTAMNTSpecified = True
                    End If
                    If PoHeader.MiscellaneousChargeAmount > 0 Then
                        .MSCCHAMT = PoHeader.MiscellaneousChargeAmount
                        .MSCCHAMTSpecified = True
                    End If
                    If PoHeader.TaxAmount > 0 Then
                        .TAXAMNT = PoHeader.TaxAmount
                        .TAXAMNTSpecified = True
                    End If
                    If PoHeader.Subtotal > 0 Then
                        .SUBTOTAL = PoHeader.Subtotal
                        .SUBTOTALSpecified = True
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.CustomerNumber) Then
                        .CUSTNMBR = PoHeader.CustomerNumber
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.ShipToAddressCode) Then
                        .PRSTADCD = PoHeader.ShipToAddressCode
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.CompanyName) Then
                        .CMPNYNAM = PoHeader.CompanyName
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.Contact) Then
                        .CONTACT = PoHeader.Contact
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.Address1) Then
                        .ADDRESS1 = PoHeader.Address1
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.Address2) Then
                        .ADDRESS2 = PoHeader.Address2
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.Address3) Then
                        .ADDRESS3 = PoHeader.Address3
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.City) Then
                        .CITY = PoHeader.City
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.State) Then
                        .STATE = PoHeader.State
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.Zip) Then
                        .ZIPCODE = PoHeader.Zip
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.VendorAddressCode) Then
                        .VADCDPAD = PoHeader.VendorAddressCode
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseCompanyName) Then
                        .PURCHCMPNYNAM = PoHeader.PurchaseCompanyName
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseContact) Then
                        .PURCHCONTACT = PoHeader.PurchaseContact
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseAddress1) Then
                        .PURCHADDRESS1 = PoHeader.PurchaseAddress1
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseAddress2) Then
                        .PURCHADDRESS2 = PoHeader.PurchaseAddress2
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseAddress3) Then
                        .PURCHADDRESS3 = PoHeader.PurchaseAddress3
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseCity) Then
                        .PURCHCITY = PoHeader.PurchaseCity
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseState) Then
                        .PURCHSTATE = PoHeader.PurchaseState
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PurchaseZip) Then
                        .PURCHZIPCODE = PoHeader.PurchaseZip
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.BillToAddressCode) Then
                        .PRBTADCD = PoHeader.BillToAddressCode
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.ShippingMethod) Then
                        .SHIPMTHD = PoHeader.ShippingMethod
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.PaymentTermsId) Then
                        .PYMTRMID = PoHeader.PaymentTermsId
                    End If
                    If PoHeader.DueDate.HasValue Then
                        .DUEDATE = PoHeader.DueDate.Value.ToString("MM/dd/yyyy")
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.TaxScheduleId) Then
                        .TAXSCHID = PoHeader.TaxScheduleId
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.UserToEnter) Then
                        .USERID = PoHeader.UserToEnter
                    End If
                    If PoHeader.PoStatus > 0 Then
                        .POSTATUS = PoHeader.PoStatus
                        .POSTATUSSpecified = True
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.NoteText) Then
                        .NOTETEXT = PoHeader.NoteText
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.UserDefined1) Then
                        .USRDEFND1 = PoHeader.UserDefined1
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.UserDefined2) Then
                        .USRDEFND2 = PoHeader.UserDefined2
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.UserDefined3) Then
                        .USRDEFND3 = PoHeader.UserDefined3
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.UserDefined4) Then
                        .USRDEFND4 = PoHeader.UserDefined4
                    End If
                    If Not String.IsNullOrEmpty(PoHeader.UserDefined5) Then
                        .USRDEFND5 = PoHeader.UserDefined5
                    End If
                    .UpdateIfExists = 1
                End With

                ' retrieve existing lines on header
                Dim lExistingLines = GetPoLinesForTransactionHeader(taPoHdr)

                ' existing lines will be removed from the list as they're matched to lines on the order; remaining items will be used to create line delete transaction objects
                For j As Integer = 0 To PoHeader.POLines.Count - 1
                    PoLine = PoHeader.POLines(j)
                    Helper.ValidateMSGPRequiredFieldsComplete(PoLine)

                    ' Use list to find existing item number on order. If exists use that, otherwise create new.
                    Dim currentLine As eConnect.Serialization.taPoLine_ItemsTaPoLine
                    currentLine = lExistingLines.Find(Function(l) l.ITEMNMBR.Trim() = PoLine.ItemNumber.Trim())
                    If currentLine Is Nothing Then
                        currentLine = New eConnect.Serialization.taPoLine_ItemsTaPoLine()
                    Else
                        ' Remove from the list; remaining items will be used to create line delete transaction objects.
                        lExistingLines.Remove(currentLine)
                    End If

                    ' Populate the line values
                    With currentLine
                        .PONUMBER = taPoHdr.PONUMBER ' required
                        .VENDORID = taPoHdr.VENDORID ' required
                        .DOCDATE = PoLine.DocumentDate
                        .ITEMNMBR = PoLine.ItemNumber
                        If PoLine.Quantity > 0 Then
                            .QUANTITY = PoLine.Quantity
                            .QUANTITYSpecified = True
                        End If
                        If PoLine.UnitCost > 0 Then
                            .UNITCOST = PoLine.UnitCost
                            .UNITCOSTSpecified = True
                        End If
                        If PoLine.PoLineStatus > 0 Then
                            .POLNESTA = PoLine.PoLineStatus
                            .POLNESTASpecified = True
                        End If
                        If PoLine.PoType > 0 Then
                            .POTYPE = PoLine.PoType
                            .POTYPESpecified = True
                        End If
                        If Not String.IsNullOrEmpty(PoLine.ItemDescription) Then
                            .ITEMDESC = PoLine.ItemDescription
                        End If
                        If Not String.IsNullOrEmpty(PoLine.UnitOfMeasure) Then
                            .UOFM = PoLine.UnitOfMeasure
                        End If
                        If Not String.IsNullOrEmpty(PoLine.NonInventory) Then
                            .NONINVEN = PoLine.NonInventory
                        End If
                        If Not String.IsNullOrEmpty(PoLine.LocationId) Then
                            .LOCNCODE = PoLine.LocationId
                        End If
                        If Not String.IsNullOrEmpty(PoLine.VendorItemNumber) Then
                            .VNDITNUM = PoLine.VendorItemNumber
                        End If
                        If Not String.IsNullOrEmpty(PoLine.VendorItemDescription) Then
                            .VNDITDSC = PoLine.VendorItemDescription
                        End If
                        If Not String.IsNullOrEmpty(PoLine.InventoryAccountIndex) Then
                            .IVIVINDX = PoLine.InventoryAccountIndex
                        End If
                        If Not String.IsNullOrEmpty(PoLine.InventoryAccount) Then
                            .InventoryAccount = PoLine.InventoryAccount
                        End If
                        If Not String.IsNullOrEmpty(PoLine.ShippingMethod) Then
                            .SHIPMTHD = PoLine.ShippingMethod
                        End If
                        If String.IsNullOrEmpty(taPoHdr.CUSTNMBR) Then
                            .CUSTNMBR = taPoHdr.CUSTNMBR
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined1) Then
                            .USRDEFND1 = PoLine.UserDefined1
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined2) Then
                            .USRDEFND2 = PoLine.UserDefined2
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined3) Then
                            .USRDEFND3 = PoLine.UserDefined3
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined4) Then
                            .USRDEFND4 = PoLine.UserDefined4
                        End If
                        If String.IsNullOrEmpty(PoLine.UserDefined5) Then
                            .USRDEFND5 = PoLine.UserDefined5
                        End If
                        .UpdateIfExists = 1
                        .ORDSpecified = .ORD > 0
                    End With

                    ltaPoLine_Items.Add(currentLine)
                Next

                ' mark remaining existing lines as cancelled (6)
                For Each existingLine In lExistingLines
                    If existingLine.POLNESTA <> 6 Then
                        ' Populate the line values
                        With existingLine
                            .POLNESTA = 6
                            .POLNESTASpecified = True
                            .UpdateIfExists = 1
                        End With
                        ltaPoLine_Items.Add(existingLine)
                    End If
                Next

                'dimension the line item details to hold the incoming details from the list
                ReDim taPoLine_Items(ltaPoLine_Items.Count - 1)
                For j As Integer = 0 To ltaPoLine_Items.Count - 1
                    taPoLine_Items(j) = ltaPoLine_Items(j)
                Next

                With POP
                    .taPoHdr = taPoHdr
                    .taPoLine_Items = taPoLine_Items
                End With

                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, POP) <> True Then
                    Return String.Empty
                End If

                Return taPoHdr.PONUMBER
            Catch ex As Exception

                Me.HandleException(ex)
                Return String.Empty
            End Try

        End Function

        ''' <summary>
        ''' Uses the GP Object Library to return a list of existing order lines as serialization transaction objects for an order.
        ''' </summary>
        ''' <param name="PoHeader"></param>
        ''' <param name="IncludeCancelled">Indicates whether or not to include PO Lines with the "Cancelled" (6) status. Default is true .</param>
        ''' <returns></returns>
        Public Function GetPoLinesForTransactionHeader(ByVal PoHeader As eConnect.Serialization.taPoHdr, Optional IncludeCancelled As Boolean = True) As List(Of eConnect.Serialization.taPoLine_ItemsTaPoLine)
            Dim uowUnitOfWork As UnitOfWork
            Dim xpcPoLines As XPCollection(Of GP2010ObjectLibrary.Module.Objects.POP.POPLine)
            Dim gpoGroupOperator As GroupOperator
            Dim taPoLines As New List(Of eConnect.Serialization.taPoLine_ItemsTaPoLine)

            uowUnitOfWork = New UnitOfWork
            uowUnitOfWork.ConnectionString = MSGPConnectionString

            gpoGroupOperator = New GroupOperator
            With gpoGroupOperator
                .Operands.Add(New BinaryOperator("Oid.PONUMBER", PoHeader.PONUMBER))
                If Not IncludeCancelled Then
                    .Operands.Add(CriteriaOperator.Parse("POLNESTA <> 6"))
                End If
            End With

            xpcPoLines = New XPCollection(Of GP2010ObjectLibrary.Module.Objects.POP.POPLine)(uowUnitOfWork, gpoGroupOperator)

            For Each poLine In xpcPoLines
                taPoLines.Add(GetPoLineForTransaction(poLine, PoHeader))
            Next

            Return taPoLines
        End Function

        Public Function GetPoHeaderForTransaction(ByVal PoNumber As String) As eConnect.Serialization.taPoHdr
            Dim uowUnitOfWork As UnitOfWork
            Dim poHeader As GP2010ObjectLibrary.Module.Objects.POP.POPHeader
            Dim gpoGroupOperator As GroupOperator
            Dim taPoHdr As eConnect.Serialization.taPoHdr = Nothing
            uowUnitOfWork = New UnitOfWork
            uowUnitOfWork.ConnectionString = MSGPConnectionString

            gpoGroupOperator = New GroupOperator
            With gpoGroupOperator
                .Operands.Add(New BinaryOperator("PONUMBER", PoNumber))
            End With

            poHeader = uowUnitOfWork.FindObject(Of GP2010ObjectLibrary.Module.Objects.POP.POPHeader)(gpoGroupOperator)
            If poHeader IsNot Nothing Then
                taPoHdr = New eConnect.Serialization.taPoHdr
                With taPoHdr
                    .POTYPE = poHeader.POTYPE
                    .POTYPESpecified = poHeader.POTYPE > 0
                    .PONUMBER = PoNumber
                    .HOLD = poHeader.HOLD
                    .ALLOWSOCMTS = poHeader.ALLOWSOCMTS
                    .ALLOWSOCMTSSpecified = poHeader.ALLOWSOCMTS > 0
                    .TAXSCHID = poHeader.TAXSCHID
                    .BUYERID = poHeader.BUYERID
                    .XCHGRATE = poHeader.XCHGRATE
                    .EXCHDATE = poHeader.EXCHDATE
                    .TIME1 = poHeader.TIME1
                    .Purchase_Freight_Taxable = poHeader.Purchase_Freight_Taxable
                    .Purchase_Freight_TaxableSpecified = poHeader.Purchase_Freight_Taxable > 0
                    .Purchase_Misc_Taxable = poHeader.Purchase_Misc_Taxable
                    .Purchase_Misc_TaxableSpecified = poHeader.Purchase_Misc_Taxable > 0
                    .FRTSCHID = poHeader.FRTSCHID
                    .MSCSCHID = poHeader.MSCSCHID
                    .PURCHADDRESS1 = poHeader.PURCHADDRESS1
                    .PURCHADDRESS2 = poHeader.PURCHADDRESS2
                    .PURCHADDRESS3 = poHeader.PURCHADDRESS3
                    .PURCHCITY = poHeader.PURCHCITY
                    .PURCHSTATE = poHeader.PURCHSTATE
                    .PURCHZIPCODE = poHeader.PURCHZIPCODE
                    .PURCHCCode = poHeader.PURCHCCode
                    .PURCHCOUNTRY = poHeader.PURCHCOUNTRY
                    .PURCHPHONE1 = poHeader.PURCHPHONE1
                    .PURCHPHONE2 = poHeader.PURCHPHONE2
                    .PURCHPHONE3 = poHeader.PURCHPHONE3
                    .PURCHFAX = poHeader.PURCHFAX
                    .PURCHCONTACT = poHeader.PURCHCONTACT
                    .PURCHCMPNYNAM = poHeader.PURCHCMPNYNAM
                    .CNTRLBLKTBY = poHeader.CNTRLBLKTBY
                    .FRTTXAMT = poHeader.FRTTXAMT
                    .MSCTXAMT = poHeader.MSCTXAMT
                    .BCKTXAMT = poHeader.BCKTXAMT
                    .BCKTXAMTSpecified = poHeader.BCKTXAMT > 0
                    .BackoutFreightTaxAmt = poHeader.BackoutFreightTaxAmt
                    .BackoutFreightTaxAmtSpecified = poHeader.BackoutFreightTaxAmt > 0
                    .BackoutMiscTaxAmt = poHeader.BackoutMiscTaxAmt
                    .BackoutMiscTaxAmtSpecified = poHeader.BackoutMiscTaxAmt > 0
                    .BackoutTradeDiscTax = poHeader.BackoutTradeDiscTax
                    .BackoutTradeDiscTaxSpecified = poHeader.BackoutTradeDiscTax > 0
                    .CONTENDDTE = poHeader.CONTENDDTE
                    .RATETPID = poHeader.RATETPID
                    .CURNCYID = poHeader.CURNCYID
                    .MSCCHAMT = poHeader.MSCCHAMT
                    .MSCCHAMTSpecified = poHeader.MSCCHAMT > 0
                    .TAXAMNT = poHeader.TAXAMNT
                    .TAXAMNTSpecified = poHeader.TAXAMNT > 0
                    .VENDORID = poHeader.VENDORID
                    .VENDNAME = poHeader.VENDNAME
                    .VADCDPAD = poHeader.VADCDPAD
                    .FRTAMNT = poHeader.FRTAMNT
                    .FRTAMNTSpecified = poHeader.FRTAMNT > 0
                    .PRSTADCD = poHeader.PRSTADCD
                    .CMPNYNAM = poHeader.CMPNYNAM
                    .CONTACT = poHeader.CONTACT
                    .ADDRESS1 = poHeader.ADDRESS1
                    .ADDRESS2 = poHeader.ADDRESS2
                    .ADDRESS3 = poHeader.ADDRESS3
                    .CITY = poHeader.CITY
                    .STATE = poHeader.STATE
                    .ZIPCODE = poHeader.ZIPCODE
                    .COUNTRY = poHeader.COUNTRY
                    .CCode = poHeader.CCode
                    .PHONE1 = poHeader.PHONE1
                    .PHONE2 = poHeader.PHONE2
                    .PHONE3 = poHeader.PHONE3
                    .FAX = poHeader.FAX
                    .PRBTADCD = poHeader.PRBTADCD
                    .TRDISAMT = poHeader.TRDISAMT
                    .TRDISAMTSpecified = poHeader.TRDISAMT > 0
                    .SUBTOTAL = poHeader.SUBTOTAL
                    .SUBTOTALSpecified = poHeader.SUBTOTAL > 0
                    .POSTATUS = poHeader.POSTATUS
                    .POSTATUSSpecified = poHeader.POSTATUS > 0
                    .USERID = poHeader.USER2ENT
                    .CONFIRM1 = poHeader.CONFIRM1
                    .DOCDATE = poHeader.DOCDATE
                    .PRMDATE = poHeader.PRMDATE
                    .PRMSHPDTE = poHeader.PRMSHPDTE
                    .REQDATE = poHeader.REQDATE
                    .REQTNDT = poHeader.REQTNDT
                    .SHIPMTHD = poHeader.SHIPMTHD
                    .TXRGNNUM = poHeader.TXRGNNUM
                    .COMMNTID = poHeader.COMMNTID
                    .PYMTRMID = poHeader.PYMTRMID
                    .DSCDLRAM = poHeader.DSCDLRAM
                    .DSCDLRAMSpecified = poHeader.DSCDLRAM > 0
                    .DISAMTAV = poHeader.DISAMTAV
                    .DISAMTAVSpecified = poHeader.DISAMTAV > 0
                    .DISCDATE = poHeader.DISCDATE
                    .DUEDATE = poHeader.DUEDATE
                    .CUSTNMBR = poHeader.CUSTNMBR
                    .DSCPCTAM = poHeader.DSCPCTAM
                    .DSCPCTAMSpecified = poHeader.DSCPCTAM > 0
                End With
            End If
            Return taPoHdr
        End Function

        ''' <summary>
        ''' Uses GP Object Library input to return an order line for a transaction. Returns null if not found.
        ''' </summary>
        ''' <param name="poLine"></param>
        ''' <returns></returns>
        Public Function GetPoLineForTransaction(ByVal poLine As GP2010ObjectLibrary.Module.Objects.POP.POPLine, ByVal PoHeader As eConnect.Serialization.taPoHdr) As eConnect.Serialization.taPoLine_ItemsTaPoLine
            Dim uowUnitOfWork As UnitOfWork
            uowUnitOfWork = New UnitOfWork
            uowUnitOfWork.ConnectionString = MSGPConnectionString

            Dim taSopLine = New eConnect.Serialization.taPoLine_ItemsTaPoLine
            With taSopLine
                .POTYPE = poLine.POTYPE
                .POTYPESpecified = poLine.POTYPE > 0
                .PONUMBER = poLine.Oid.PONUMBER ' required
                .DOCDATE = PoHeader.DOCDATE
                .VENDORID = PoHeader.VENDORID ' required
                .LOCNCODE = poLine.LOCNCODE
                .VNDITNUM = poLine.VNDITNUM
                .ITEMNMBR = poLine.ITEMNMBR
                .VNDITDSC = poLine.VNDITDSC
                .QUANTITY = poLine.QTYORDER
                .QUANTITYSpecified = poLine.QTYORDER > 0
                .UNITCOST = poLine.UNITCOST
                .UNITCOSTSpecified = poLine.UNITCOST > 0
                .NONINVEN = poLine.NONINVEN
                .IVIVINDX = poLine.INVINDX
                .IVIVINDXSpecified = poLine.INVINDX > 0
                .ITEMDESC = poLine.ITEMDESC
                .UOFM = poLine.UOFM
                .SHIPMTHD = poLine.SHIPMTHD
                .CUSTNMBR = PoHeader.CUSTNMBR
                .LineNumber = poLine.LineNumber
                .LineNumberSpecified = poLine.LineNumber > 0
                .ADRSCODE = poLine.ADRSCODE
                .ADDRESS1 = poLine.ADDRESS1
                .ADDRESS2 = poLine.ADDRESS2
                .ADDRESS3 = poLine.ADDRESS3
                .CITY = poLine.CITY
                .STATE = poLine.STATE
                .ZIPCODE = poLine.ZIPCODE
                .CONTACT = poLine.CONTACT
                .COMMNTID = poLine.COMMNTID
                .CCode = poLine.CCode
                .COUNTRY = poLine.COUNTRY
                .FAX = poLine.FAX
                .PHONE1 = poLine.PHONE1
                .PHONE2 = poLine.PHONE2
                .PHONE3 = poLine.PHONE3
                .CMPNYNAM = poLine.CMPNYNAM
                .QTYCANCE = poLine.QTYCANCE
                .QTYCANCESpecified = poLine.QTYCANCE > 0
                .REQDATE = poLine.REQDATE
                .TAXAMNT = poLine.TAXAMNT
                .TAXAMNTSpecified = poLine.TAXAMNT > 0
                .Purchase_IV_Item_Taxable = poLine.Purchase_IV_Item_Taxable
                .Purchase_IV_Item_TaxableSpecified = poLine.Purchase_IV_Item_Taxable > 0
                .Purchase_Site_Tax_Schedu = poLine.Purchase_Site_Tax_Schedu
                .BSIVCTTL = poLine.BSIVCTTL
                .BSIVCTTLSpecified = poLine.BSIVCTTL > 0
                .BCKTXAMT = poLine.BCKTXAMT
                .BCKTXAMTSpecified = poLine.BCKTXAMT > 0
                .Landed_Cost_Group_ID = poLine.Landed_Cost_Group_ID
                .PLNNDSPPLID = poLine.PLNNDSPPLID
                .PLNNDSPPLIDSpecified = .PLNNDSPPLID > 0
                .BackoutTradeDiscTax = poLine.BackoutTradeDiscTax
                .BackoutTradeDiscTaxSpecified = poLine.BackoutTradeDiscTax > 0
                .POLNESTA = poLine.POLNESTA
                .POLNESTASpecified = .POLNESTA > 0
                .ORD = poLine.Oid.ORD
                .ORDSpecified = .ORD > 0
                .FREEONBOARD = poLine.FREEONBOARD
                .FREEONBOARDSpecified = .FREEONBOARD > 0
                .REQSTDBY = poLine.REQSTDBY
                .COMMNTID = poLine.COMMNTID
                .RELEASEBYDATE = poLine.RELEASEBYDATE
                .PRMDATE = poLine.PRMDATE
                .PRMSHPDTE = poLine.PRMSHPDTE
                .ProjNum = poLine.ProjNum
                .CostCatID = poLine.CostCatID
                .CURNCYID = poLine.CURNCYID
                .UpdateIfExists = 1

                ' Retrieve associated accounts (eConnect expects full account strings, but GP fields only hold indexes)
                Dim GLAcct = uowUnitOfWork.FindObject(Of GP2010ObjectLibrary.Module.Objects.GL.GLAccountIndexMaster)(CriteriaOperator.Parse("ACTINDX = ?", poLine.INVINDX))
                If GLAcct IsNot Nothing Then
                    .InventoryAccount = GLAcct.ACTNUMST
                End If

                ' Fields not available from GP Object Library
                '.USRDEFND1 = poLine.UserDefined1
                '.USRDEFND2 = poLine.UserDefined2
                '.USRDEFND3 = poLine.UserDefined3
                '.USRDEFND4 = poLine.UserDefined4
                '.USRDEFND5 = poLine.UserDefined5
                '.CMMTTEXT = poLine.CMMTTEXT
                '.COMMENT_1 = poLine.Comment1
                '.COMMENT_2 = poLine.Comment2
                '.COMMENT_3 = poLine.Comment3
                '.COMMENT_4 = poLine.Comment4
                '.NOTETEXT = poLine.NOTETEXT
                '.RequesterTrx = poLine.RequesterTrx

            End With

            Return taSopLine
        End Function

#End Region
    End Class
End Namespace
