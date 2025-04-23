Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP

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
#End Region
#Region "Operations"
        Public Function CreatePOHeader(ByVal POTrx As POPHeader) As String
            Dim taPO As New eConnect.Serialization.POPTransactionType
            Dim lstLines As New List(Of eConnect.Serialization.taPoLine_ItemsTaPoLine)
            Dim eclLine As eConnect.Serialization.taPoLine_ItemsTaPoLine

            Try
                Me.ExceptionMessages.Clear()
                taPO.taPoHdr = New eConnect.Serialization.taPoHdr
                With taPO.taPoHdr
                    .PONUMBER = POTrx.PONumber
                    If .PONUMBER = String.Empty Then
                        .PONUMBER = CommonLogic.GetNextPOPPurchaseOrderDocNumber(Me.MSGPConnectionString)
                    End If
                    .VENDORID = POTrx.VendorId
                    .USERID = POTrx.CreatedByUsername
                End With

                For Each objLine In POTrx.Lines
                    eclLine = New eConnect.Serialization.taPoLine_ItemsTaPoLine
                    With eclLine
                        .PONUMBER = taPO.taPoHdr.PONUMBER
                        If String.IsNullOrEmpty(objLine.Description) = False Then
                            .ITEMDESC = objLine.Description
                        End If
                        If String.IsNullOrEmpty(objLine.UOM) = False Then
                            .UOFM = objLine.UOM
                        End If
                        .LOCNCODE = objLine.LocationCode
                        .ITEMNMBR = objLine.ItemNumber
                        .QUANTITY = objLine.Quantity
                        .QUANTITYSpecified = True
                        .REQDATE = DateTime.Today.ToString("yyyy-MM-dd")
                        .VENDORID = POTrx.VendorId
                        If objLine.Price > 0 Then
                            .UNITCOST = objLine.Price
                            .UNITCOSTSpecified = True
                        End If

                    End With
                    lstLines.Add(eclLine)
                Next

                taPO.taPoLine_Items = lstLines.ToArray
                Return CommonLogic.eConnectCreate(Me.MSGPConnectionString, taPO)

            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try


        End Function
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
#End Region
    End Class
End Namespace
