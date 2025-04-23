Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP
Namespace PM
    Public Class PMFactory
        Private _mMSGPConnectionString As String
        Private _mExceptionMessages As New System.Collections.Specialized.StringCollection
#Region "Properties"
        Public Property MSGPConnectionString() As String
            Get
                Return _mMSGPConnectionString
            End Get
            Set(ByVal value As String)
                If _mMSGPConnectionString = value Then
                    Return
                End If
                _mMSGPConnectionString = value
            End Set
        End Property
        Public ReadOnly Property ExceptionMessages() As System.Collections.Specialized.StringCollection
            Get
                Return _mExceptionMessages
            End Get
        End Property
#End Region
#Region "Public Methods"
        Public Function CreateUpdateVendorAddress(ByVal VendorAddress As PMVendorAddress) As Boolean
            Dim PM As New eConnect.Serialization.PMVendorMasterType
            Dim taPmVendorAddress As New eConnect.Serialization.taCreateVendorAddress_ItemsTaCreateVendorAddress
            Try
                Me._mExceptionMessages.Clear()
                With taPmVendorAddress
                    .VENDORID = VendorAddress.VendorId
                    .ADRSCODE = VendorAddress.AddressCode
                    .VNDCNTCT = VendorAddress.ContactPerson
                    If VendorAddress.ShipMethod > String.Empty Then
                        .SHIPMTHD = VendorAddress.ShipMethod
                    End If
                    If VendorAddress.TaxSchedule > String.Empty Then
                        .TAXSCHID = VendorAddress.TaxSchedule
                    End If

                    .ADDRESS1 = VendorAddress.Address1
                    .ADDRESS2 = VendorAddress.Address2
                    .ADDRESS3 = VendorAddress.Address3
                    .CITY = VendorAddress.City
                    .STATE = VendorAddress.State
                    .ZIPCODE = VendorAddress.ZipCode
                    .COUNTRY = VendorAddress.Country
                    .UpdateIfExists = 1
                End With
                PM.taCreateVendorAddress_Items = {taPmVendorAddress}
                Return CommonLogic.eConnectCreate(Me._mMSGPConnectionString, PM)
            Catch ex As Exception
                Me.HandleException(ex)
                Return Nothing
            End Try
        End Function
        ''' <summary>
        ''' Creates a PM Transaction
        ''' </summary>
        ''' <param name="PMTrx"></param>
        ''' This value will be used for the trx header reference and for each GlTrxLIne reference that is blank
        ''' <returns>Return voucher number if successful, otherwise return nothing</returns>
        ''' <remarks></remarks>
        Public Function CreatePMTransaction(ByVal PMTrx As PMTrx) As String
            Me._mExceptionMessages.Clear()
            'TODO: Process hold?  Check Hold Status.
            'TODO: Ask about creating/updating vendors
            Try
                Dim PM As New eConnect.Serialization.PMTransactionType
                Dim taPMTrx As New eConnect.Serialization.taPMTransactionInsert
                Dim taPMTrxDistributionLines() As eConnect.Serialization.taPMDistribution_ItemsTaPMDistribution
                Dim PMTrxDistributionLine As PMTrxDistributionLine
                Dim taUpdateCreateVendorRcd As New eConnect.Serialization.taUpdateCreateVendorRcd
                Dim strNextVoucher As String

                If PMTrx.VoucherNumber = String.Empty Then
                    strNextVoucher = CommonLogic.GetDocNumber(Me._mMSGPConnectionString, CommonLogic.DocNumberTypes.PMVoucherNumber)
                    PMTrx.SetVoucherNumber(strNextVoucher)
                End If

                With taPMTrx
                    .BACHNUMB = PMTrx.BatchID
                    .DOCTYPE = PMTrx.DocumentType
                    .DUEDATE = PMTrx.DueDate
                    .FRTAMNT = PMTrx.Freight
                    'ISS Todo
                    'taPMTrx.Hold = PMTrx.Hold
                    .TRXDSCRN = PMTrx.PMDescription
                    .DOCDATE = PMTrx.PMDocDate
                    .DOCNUMBR = PMTrx.PMDocumentNumber
                    .PYMTRMID = PMTrx.PMPaymentTerms
                    .TAXSCHID = PMTrx.TaxScheduleID
                    .TAXAMNT = PMTrx.TaxAmount
                    .DISCDATE = PMTrx.TermsDiscDate
                    .TRDISAMT = PMTrx.TradeDiscount
                    .VENDORID = PMTrx.VendorID
                    .VCHNUMWK = PMTrx.VoucherNumber
                    .PRCHAMNT = PMTrx.PurchaseAmount
                    .PORDNMBR = PMTrx.PONumber
                    .DOCAMNT = PMTrx.DocumentAmount
                    .CHRGAMNT = PMTrx.ChargeAmount

                    If PMTrx.PMTrxDistributionLines.Count = 0 Then
                        .CREATEDIST = 1
                    Else
                        .CREATEDIST = 0
                    End If
                End With

                ReDim taPMTrxDistributionLines(PMTrx.PMTrxDistributionLines.Count)
                For intLoop As Integer = 0 To PMTrx.PMTrxDistributionLines.Count - 1
                    PMTrxDistributionLine = PMTrx.PMTrxDistributionLines(intLoop)
                    taPMTrxDistributionLines(intLoop) = New eConnect.Serialization.taPMDistribution_ItemsTaPMDistribution
                    'Select Case PMTrxDistributionLine.DistributionType
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Avail
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Cash
                    '        taPMTrx.CASHAMNT = PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Fnchg
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Freight
                    '        taPMTrx.FRTAMNT = PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Gst
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Misc
                    '        taPMTrx.MSCCHAMT = PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Other
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Pay
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Purch
                    '        taPMTrx.PRCHAMNT = PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Round
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Taken
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Taxes
                    '        taPMTrx.TAXAMNT = PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Trade
                    '        taPMTrx.TRDISAMT = PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Unit
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Wh
                    '        '?
                    '    Case MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Write
                    '        '?
                    'End Select
                    'If PMTrxDistributionLine.DistributionType = MSGP10eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Avail Then

                    'End If
                    With taPMTrxDistributionLines(intLoop)
                        .VCHRNMBR = PMTrx.VoucherNumber
                        .ACTNUMST = PMTrxDistributionLine.AccountNumber
                        .CRDTAMNT = PMTrxDistributionLine.CreditAmount
                        .DEBITAMT = PMTrxDistributionLine.DebitAmount
                        .DistRef = PMTrxDistributionLine.DistributionReference
                        .DISTTYPE = PMTrxDistributionLine.DistributionType.GetHashCode
                        .VENDORID = PMTrxDistributionLine.VendorID
                        .DOCTYPE = PMTrxDistributionLine.DocType.GetHashCode
                    End With
                Next

                With PM
                    .taPMTransactionInsert = taPMTrx
                    .taPMDistribution_Items = taPMTrxDistributionLines
                End With
                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, PM) = True Then
                    Return PMTrx.VoucherNumber
                Else
                    Return Nothing
                End If


            Catch ex As Exception

                Me.HandleException(ex)
                Return Nothing
            End Try

        End Function
#End Region

        Private Sub HandleException(ByVal ex As Exception)
            Me._mExceptionMessages.Add(ex.ToString)
            'If ex.InnerException IsNot Nothing Then
            'Me.HandleException(ex.InnerException)
            'End If
        End Sub

    End Class
End Namespace

