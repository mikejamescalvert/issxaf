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
                    POTrx.ReceiptNumber = CommonLogic.GetDocNumber(Me.MSGPConnectionString, CommonLogic.DocNumberTypes.POPReceipt)
                End If
                With taPOPHdr
                    .BACHNUMB = POTrx.BatchId
                    .receiptdate = POTrx.ReceiptDate
                    .POPRCTNM = POTrx.ReceiptNumber
                    .ACTLSHIP = POTrx.ActualShipDate
                    .NOTETEXT = POTrx.NoteText
                    .POPTYPE = 2
                    .REFRENCE = POTrx.Reference
                    .VNDDOCNM = POTrx.VendorDocumentReference
                    .VENDORID = POTrx.VendorId
                    .AUTOCOST = 1

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
                        .receiptdate = POLine.ReceiptDate
                        .POPRCTNM = POTrx.ReceiptNumber
                        .VENDORID = taPOPHdr.VENDORID
                        .POPTYPE = 1
                        .UOFM = POLine.UnitOfMeasure
                        .LOCNCODE = POLine.SiteId
                        .RCPTLNNM = 16384 * (j + 1)
                        .AUTOCOST = 1

                    End With

                    'handle serial/lot numbers
                    If POLine.SerialLotLines.Count > 0 Then
                        'handle serial numbers
                        If POLine.SerialLotLines.SerialLotType = SerialLotTypes.SerialNumber Then
                            For k As Integer = 0 To POLine.SerialLotLines.Count - 1
                                'extend array to hold next item
                                If taPOPSerialNumbers IsNot Nothing Then
                                    ReDim Preserve taPOPSerialNumbers(taPOPSerialNumbers.Length)
                                Else
                                    ReDim Preserve taPOPSerialNumbers(0)
                                End If
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

                        End If
                        'handle lot numbers
                        If POLine.SerialLotLines.SerialLotType = SerialLotTypes.LotNumber Then

                            For k As Integer = 0 To POLine.SerialLotLines.Count - 1
                                'extend array to hold next item
                                If taPOPLotNumbers IsNot Nothing Then
                                    ReDim Preserve taPOPLotNumbers(taPOPLotNumbers.Length + 1)
                                Else
                                    ReDim Preserve taPOPLotNumbers(0)
                                End If
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
                        End If
                    End If

                Next
                taPO.taPopRcptHdrInsert = taPOPHdr
                taPO.taPopRcptLineInsert_Items = taPOPLines
                taPO.taPopRcptLotInsert_Items = taPOPLotNumbers
                taPO.taPopRcptSerialInsert_Items = taPOPSerialNumbers
                Return CommonLogic.eConnectCreate(Me.MSGPConnectionString, taPO)

            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try

        End Function
#End Region
    End Class
End Namespace
