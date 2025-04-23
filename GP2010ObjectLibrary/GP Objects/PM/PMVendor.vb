Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation



Namespace Objects.PM
    ''' <summary>
    ''' GP Table PM00200
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("PM00200")> _
    <DefaultProperty("npSummaryInfo")> _
<OptimisticLocking(False)> _
    Public Class PMVendor
        Inherits XPBaseObject

#Region "Behaviors"

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub


#End Region

#Region "Non Persistent Properties"
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <VisibleInLookupListView(False)>
        <System.ComponentModel.DisplayName("Summary Info")>
        <PersistentAlias("concat(VENDORID,' - ',VENDNAME)")>
        Public ReadOnly Property npSummaryInfo As String
            Get
                Return EvaluateAlias("npSummaryInfo")
            End Get
        End Property

        <PersistentAlias("[<SYShippingMethod>][SHIPMTHD = ^.SHIPMTHD].Single()")>
        Public ReadOnly Property ShippingMethod As SY.SYShippingMethod
            Get
                Return TryCast(EvaluateAlias("ShippingMethod"), SY.SYShippingMethod)
            End Get
        End Property
        'Private _mShippingMethod As SY.SYShippingMethod
        'Public ReadOnly Property npShippingMethod As SY.SYShippingMethod
        '    Get
        '        If _mShippingMethod Is Nothing Then
        '            If Not String.IsNullOrEmpty(Me.SHIPMTHD) Then
        '                _mShippingMethod = Session.FindObject(Of SY.SYShippingMethod)(New BinaryOperator("SHIPMTHD", Me.SHIPMTHD))
        '            Else
        '                _mShippingMethod = Nothing
        '            End If
        '        End If
        '        Return _mShippingMethod
        '    End Get
        'End Property

        <PersistentAlias("[<SYPaymentTerms>][PYMTRMID = ^.PYMTRMID].Single()")>
        Public ReadOnly Property PaymentTerms As SY.SYPaymentTerms
            Get
                Return TryCast(EvaluateAlias("PaymentTerms"), SY.SYPaymentTerms)
            End Get
        End Property
        'Private _mPaymentTerms As SY.SYPaymentTerms
        'Public ReadOnly Property npPaymentTerms As SY.SYPaymentTerms
        '    Get
        '        If _mPaymentTerms Is Nothing Then
        '            If Not String.IsNullOrEmpty(Me.PYMTRMID) Then
        '                _mPaymentTerms = Session.FindObject(Of SY.SYPaymentTerms)(New BinaryOperator("PYMTRMID", Me.PYMTRMID))
        '            Else
        '                _mPaymentTerms = Nothing
        '            End If
        '        End If
        '        Return _mPaymentTerms
        '    End Get
        'End Property

        <PersistentAlias("[<TXTaxScheduleKey>][TAXSCHID = ^.TAXSCHID].Single()")>
        Public ReadOnly Property TaxSchedule As TX.TXTaxScheduleKey
            Get
                Return TryCast(EvaluateAlias("TaxSchedule"), TX.TXTaxScheduleKey)
            End Get
        End Property
        'Private _mTaxSchedule As TX.TXTaxScheduleKey
        'Public ReadOnly Property npTaxSchedule As TX.TXTaxScheduleKey
        '    Get
        '        If _mTaxSchedule Is Nothing Then
        '            If Not String.IsNullOrEmpty(Me.TAXSCHID) Then
        '                _mTaxSchedule = Session.FindObject(Of TX.TXTaxScheduleKey)(New BinaryOperator("TAXSCHID", Me.TAXSCHID))
        '            Else
        '                _mTaxSchedule = Nothing
        '            End If
        '        End If
        '        Return _mTaxSchedule

        '    End Get
        'End Property

        Private _mAddresses As XPCollection(Of PMVendorAddress)
        Public ReadOnly Property npVendorAddresses As XPCollection(Of PMVendorAddress)
            Get
                If _mAddresses Is Nothing Then
                    _mAddresses = New XPCollection(Of PMVendorAddress)(Session, New BinaryOperator("Oid.VENDORID", Me.VENDORID))

                End If
                Return _mAddresses
            End Get
        End Property

        <PersistentAlias("[<PMVendorAddress>][Oid.VENDORID = ^.VENDORID AND Oid.ADRSCODE = ^.VADCDPAD].Single()")>
        Public ReadOnly Property PurchaseAddress As PMVendorAddress
            Get
                Return TryCast(EvaluateAlias("PurchaseAddress"), PMVendorAddress)
            End Get
        End Property

        'Private _mPurchaseAddress As PMVendorAddress
        'Public ReadOnly Property npPurchaseAddress As PMVendorAddress
        '    Get
        '        If _mPurchaseAddress Is Nothing AndAlso Me.VADCDPAD IsNot Nothing Then
        '            Dim xpoGO As New GroupOperator
        '            With xpoGO.Operands
        '                .Add(New BinaryOperator("Oid.VENDORID", Me.VENDORID))
        '                .Add(New BinaryOperator("Oid.ADRSCODE", Me.VADCDPAD))
        '            End With
        '            Return Session.FindObject(Of PMVendorAddress)(xpoGO)
        '        Else
        '            Return Nothing

        '        End If
        '    End Get
        'End Property

        <PersistentAlias("[<PMVendorAddress>][Oid.VENDORID = ^.VENDORID AND Oid.ADRSCODE = ^.VADCDTRO].Single()")>
        Public ReadOnly Property RemitToAddress As PMVendorAddress
            Get
                Return TryCast(EvaluateAlias("RemitToAddress"), PMVendorAddress)
            End Get
        End Property
        'Private _mRemitToAddress As PMVendorAddress
        'Public ReadOnly Property npRemitToAddress As PMVendorAddress
        '    Get
        '        If _mRemitToAddress Is Nothing AndAlso Me.VADCDPAD IsNot Nothing Then
        '            Dim xpoGO As New GroupOperator
        '            With xpoGO.Operands
        '                .Add(New BinaryOperator("Oid.VENDORID", Me.VENDORID))
        '                .Add(New BinaryOperator("Oid.ADRSCODE", Me.VADCDTRO))
        '            End With
        '            Return Session.FindObject(Of PMVendorAddress)(xpoGO)
        '        Else
        '            Return Nothing

        '        End If
        '    End Get
        'End Property

        <PersistentAlias("[<PMVendorAddress>][Oid.VENDORID = ^.VENDORID AND Oid.ADRSCODE = ^.VADCDSFR].Single()")>
        Public ReadOnly Property ShipFromAddress As PMVendorAddress
            Get
                Return TryCast(EvaluateAlias("ShipFromAddress"), PMVendorAddress)
            End Get
        End Property
        'Private _mShipFromAddress As PMVendorAddress
        'Public ReadOnly Property npShipFromAddress As PMVendorAddress
        '    Get
        '        If _mShipFromAddress Is Nothing AndAlso Me.VADCDPAD IsNot Nothing Then
        '            Dim xpoGO As New GroupOperator
        '            With xpoGO.Operands
        '                .Add(New BinaryOperator("Oid.VENDORID", Me.VENDORID))
        '                .Add(New BinaryOperator("Oid.ADRSCODE", Me.VADCDSFR))
        '            End With
        '            Return Session.FindObject(Of PMVendorAddress)(xpoGO)
        '        Else
        '            Return Nothing

        '        End If
        '    End Get
        'End Property

#End Region


#Region "Properties"

        Dim fVENDORID As String

        <VisibleInListView(True)>
        <Key()> _
        <Size(15)> _
        Public Property VENDORID() As String
            Get
                Return fVENDORID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDORID", fVENDORID, value)
            End Set
        End Property
        Dim fVENDNAME As String

        <VisibleInListView(True)>
        <Size(65)> _
        Public Property VENDNAME() As String
            Get
                Return fVENDNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDNAME", fVENDNAME, value)
            End Set
        End Property
        Dim fVNDCHKNM As String
        <Size(65)> _
        Public Property VNDCHKNM() As String
            Get
                Return fVNDCHKNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDCHKNM", fVNDCHKNM, value)
            End Set
        End Property
        Dim fVENDSHNM As String
        <Size(15)> _
        Public Property VENDSHNM() As String
            Get
                Return fVENDSHNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDSHNM", fVENDSHNM, value)
            End Set
        End Property
        Dim fVADDCDPR As String
        <Size(15)> _
        Public Property VADDCDPR() As String
            Get
                Return fVADDCDPR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADDCDPR", fVADDCDPR, value)
            End Set
        End Property
        Dim fVADCDPAD As String
        <Size(15)> _
        Public Property VADCDPAD() As String
            Get
                Return fVADCDPAD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADCDPAD", fVADCDPAD, value)
            End Set
        End Property
        Dim fVADCDSFR As String
        <Size(15)> _
        Public Property VADCDSFR() As String
            Get
                Return fVADCDSFR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADCDSFR", fVADCDSFR, value)
            End Set
        End Property
        Dim fVADCDTRO As String
        <Size(15)> _
        Public Property VADCDTRO() As String
            Get
                Return fVADCDTRO
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADCDTRO", fVADCDTRO, value)
            End Set
        End Property
        Dim fVNDCLSID As String
        <Size(11)> _
        Public Property VNDCLSID() As String
            Get
                Return fVNDCLSID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDCLSID", fVNDCLSID, value)
            End Set
        End Property
        Dim fVNDCNTCT As String
        <Size(61)> _
        Public Property VNDCNTCT() As String
            Get
                Return fVNDCNTCT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDCNTCT", fVNDCNTCT, value)
            End Set
        End Property
        Dim fADDRESS1 As String
        <Size(61)> _
        Public Property ADDRESS1() As String
            Get
                Return fADDRESS1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS1", fADDRESS1, value)
            End Set
        End Property
        Dim fADDRESS2 As String
        <Size(61)> _
        Public Property ADDRESS2() As String
            Get
                Return fADDRESS2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS2", fADDRESS2, value)
            End Set
        End Property
        Dim fADDRESS3 As String
        <Size(61)> _
        Public Property ADDRESS3() As String
            Get
                Return fADDRESS3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS3", fADDRESS3, value)
            End Set
        End Property
        Dim fCITY As String
        <Size(35)> _
        Public Property CITY() As String
            Get
                Return fCITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CITY", fCITY, value)
            End Set
        End Property
        Dim fSTATE As String
        <Size(29)> _
        Public Property STATE() As String
            Get
                Return fSTATE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STATE", fSTATE, value)
            End Set
        End Property
        Dim fZIPCODE As String
        <Size(11)> _
        Public Property ZIPCODE() As String
            Get
                Return fZIPCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIPCODE", fZIPCODE, value)
            End Set
        End Property
        Dim fCOUNTRY As String
        <Size(61)> _
        Public Property COUNTRY() As String
            Get
                Return fCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
            End Set
        End Property
        Dim fPHNUMBR1 As String
        <Size(21)> _
        Public Property PHNUMBR1() As String
            Get
                Return fPHNUMBR1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHNUMBR1", fPHNUMBR1, value)
            End Set
        End Property
        Dim fPHNUMBR2 As String
        <Size(21)> _
        Public Property PHNUMBR2() As String
            Get
                Return fPHNUMBR2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHNUMBR2", fPHNUMBR2, value)
            End Set
        End Property
        Dim fPHONE3 As String
        <Size(21)> _
        Public Property PHONE3() As String
            Get
                Return fPHONE3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE3", fPHONE3, value)
            End Set
        End Property
        Dim fFAXNUMBR As String
        <Size(21)> _
        Public Property FAXNUMBR() As String
            Get
                Return fFAXNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FAXNUMBR", fFAXNUMBR, value)
            End Set
        End Property
        Dim fUPSZONE As String
        <Size(3)> _
        Public Property UPSZONE() As String
            Get
                Return fUPSZONE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UPSZONE", fUPSZONE, value)
            End Set
        End Property
        Dim fSHIPMTHD As String
        <Size(15)> _
        Public Property SHIPMTHD() As String
            Get
                Return fSHIPMTHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHIPMTHD", fSHIPMTHD, value)
            End Set
        End Property
        Dim fTAXSCHID As String
        <Size(15)> _
        Public Property TAXSCHID() As String
            Get
                Return fTAXSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXSCHID", fTAXSCHID, value)
            End Set
        End Property
        Dim fACNMVNDR As String
        <Size(21)> _
        Public Property ACNMVNDR() As String
            Get
                Return fACNMVNDR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ACNMVNDR", fACNMVNDR, value)
            End Set
        End Property
        Dim fTXIDNMBR As String
        <Size(11)> _
        Public Property TXIDNMBR() As String
            Get
                Return fTXIDNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXIDNMBR", fTXIDNMBR, value)
            End Set
        End Property
        Dim fVENDSTTS As Short
        Public Property VENDSTTS() As Short
            Get
                Return fVENDSTTS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("VENDSTTS", fVENDSTTS, value)
            End Set
        End Property
        Dim fCURNCYID As String
        <Size(15)> _
        Public Property CURNCYID() As String
            Get
                Return fCURNCYID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CURNCYID", fCURNCYID, value)
            End Set
        End Property
        Dim fTXRGNNUM As String
        <Size(25)> _
        Public Property TXRGNNUM() As String
            Get
                Return fTXRGNNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXRGNNUM", fTXRGNNUM, value)
            End Set
        End Property
        Dim fPARVENID As String
        <Size(15)> _
        Public Property PARVENID() As String
            Get
                Return fPARVENID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PARVENID", fPARVENID, value)
            End Set
        End Property
        Dim fTRDDISCT As Short
        Public Property TRDDISCT() As Short
            Get
                Return fTRDDISCT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TRDDISCT", fTRDDISCT, value)
            End Set
        End Property
        Dim fTEN99TYPE As Short
        Public Property TEN99TYPE() As Short
            Get
                Return fTEN99TYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TEN99TYPE", fTEN99TYPE, value)
            End Set
        End Property
        Dim fTEN99BOXNUMBER As Short
        Public Property TEN99BOXNUMBER() As Short
            Get
                Return fTEN99BOXNUMBER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TEN99BOXNUMBER", fTEN99BOXNUMBER, value)
            End Set
        End Property
        Dim fMINORDER As Decimal
        Public Property MINORDER() As Decimal
            Get
                Return fMINORDER
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MINORDER", fMINORDER, value)
            End Set
        End Property
        Dim fPYMTRMID As String
        <Size(21)> _
        Public Property PYMTRMID() As String
            Get
                Return fPYMTRMID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PYMTRMID", fPYMTRMID, value)
            End Set
        End Property
        Dim fMINPYTYP As Short
        Public Property MINPYTYP() As Short
            Get
                Return fMINPYTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MINPYTYP", fMINPYTYP, value)
            End Set
        End Property
        Dim fMINPYPCT As Short
        Public Property MINPYPCT() As Short
            Get
                Return fMINPYPCT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MINPYPCT", fMINPYPCT, value)
            End Set
        End Property
        Dim fMINPYDLR As Decimal
        Public Property MINPYDLR() As Decimal
            Get
                Return fMINPYDLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MINPYDLR", fMINPYDLR, value)
            End Set
        End Property
        Dim fMXIAFVND As Short
        Public Property MXIAFVND() As Short
            Get
                Return fMXIAFVND
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MXIAFVND", fMXIAFVND, value)
            End Set
        End Property
        Dim fMAXINDLR As Decimal
        Public Property MAXINDLR() As Decimal
            Get
                Return fMAXINDLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MAXINDLR", fMAXINDLR, value)
            End Set
        End Property
        Dim fCOMMENT1 As String
        <Size(31)> _
        Public Property COMMENT1() As String
            Get
                Return fCOMMENT1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT1", fCOMMENT1, value)
            End Set
        End Property
        Dim fCOMMENT2 As String
        <Size(31)> _
        Public Property COMMENT2() As String
            Get
                Return fCOMMENT2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT2", fCOMMENT2, value)
            End Set
        End Property
        Dim fUSERDEF1 As String
        <Size(21)> _
        Public Property USERDEF1() As String
            Get
                Return fUSERDEF1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF1", fUSERDEF1, value)
            End Set
        End Property
        Dim fUSERDEF2 As String
        <Size(21)> _
        Public Property USERDEF2() As String
            Get
                Return fUSERDEF2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF2", fUSERDEF2, value)
            End Set
        End Property
        Dim fCRLMTDLR As Decimal
        Public Property CRLMTDLR() As Decimal
            Get
                Return fCRLMTDLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CRLMTDLR", fCRLMTDLR, value)
            End Set
        End Property
        Dim fPYMNTPRI As String
        <Size(3)> _
        Public Property PYMNTPRI() As String
            Get
                Return fPYMNTPRI
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PYMNTPRI", fPYMNTPRI, value)
            End Set
        End Property
        Dim fKPCALHST As Byte
        Public Property KPCALHST() As Byte
            Get
                Return fKPCALHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPCALHST", fKPCALHST, value)
            End Set
        End Property
        Dim fKGLDSTHS As Byte
        Public Property KGLDSTHS() As Byte
            Get
                Return fKGLDSTHS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KGLDSTHS", fKGLDSTHS, value)
            End Set
        End Property
        Dim fKPERHIST As Byte
        Public Property KPERHIST() As Byte
            Get
                Return fKPERHIST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPERHIST", fKPERHIST, value)
            End Set
        End Property
        Dim fKPTRXHST As Byte
        Public Property KPTRXHST() As Byte
            Get
                Return fKPTRXHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPTRXHST", fKPTRXHST, value)
            End Set
        End Property
        Dim fHOLD As Byte
        Public Property HOLD() As Byte
            Get
                Return fHOLD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("HOLD", fHOLD, value)
            End Set
        End Property
        Dim fPTCSHACF As Short
        Public Property PTCSHACF() As Short
            Get
                Return fPTCSHACF
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PTCSHACF", fPTCSHACF, value)
            End Set
        End Property
        Dim fCREDTLMT As Short
        Public Property CREDTLMT() As Short
            Get
                Return fCREDTLMT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CREDTLMT", fCREDTLMT, value)
            End Set
        End Property
        Dim fWRITEOFF As Short
        Public Property WRITEOFF() As Short
            Get
                Return fWRITEOFF
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WRITEOFF", fWRITEOFF, value)
            End Set
        End Property
        Dim fMXWOFAMT As Decimal
        Public Property MXWOFAMT() As Decimal
            Get
                Return fMXWOFAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MXWOFAMT", fMXWOFAMT, value)
            End Set
        End Property
        Dim fSBPPSDED As Byte
        Public Property SBPPSDED() As Byte
            Get
                Return fSBPPSDED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SBPPSDED", fSBPPSDED, value)
            End Set
        End Property
        Dim fPPSTAXRT As Short
        Public Property PPSTAXRT() As Short
            Get
                Return fPPSTAXRT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PPSTAXRT", fPPSTAXRT, value)
            End Set
        End Property
        Dim fDXVARNUM As String
        <Size(25)> _
        Public Property DXVARNUM() As String
            Get
                Return fDXVARNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DXVARNUM", fDXVARNUM, value)
            End Set
        End Property
        Dim fCRTCOMDT As DateTime
        Public Property CRTCOMDT() As DateTime
            Get
                Return fCRTCOMDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CRTCOMDT", fCRTCOMDT, value)
            End Set
        End Property
        Dim fCRTEXPDT As DateTime
        Public Property CRTEXPDT() As DateTime
            Get
                Return fCRTEXPDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CRTEXPDT", fCRTEXPDT, value)
            End Set
        End Property
        Dim fRTOBUTKN As Byte
        Public Property RTOBUTKN() As Byte
            Get
                Return fRTOBUTKN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("RTOBUTKN", fRTOBUTKN, value)
            End Set
        End Property
        Dim fXPDTOBLG As Byte
        Public Property XPDTOBLG() As Byte
            Get
                Return fXPDTOBLG
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("XPDTOBLG", fXPDTOBLG, value)
            End Set
        End Property
        Dim fPRSPAYEE As Byte
        Public Property PRSPAYEE() As Byte
            Get
                Return fPRSPAYEE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("PRSPAYEE", fPRSPAYEE, value)
            End Set
        End Property
        Dim fPMAPINDX As Integer
        Public Property PMAPINDX() As Integer
            Get
                Return fPMAPINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMAPINDX", fPMAPINDX, value)
            End Set
        End Property
        Dim fPMCSHIDX As Integer
        Public Property PMCSHIDX() As Integer
            Get
                Return fPMCSHIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMCSHIDX", fPMCSHIDX, value)
            End Set
        End Property
        Dim fPMDAVIDX As Integer
        Public Property PMDAVIDX() As Integer
            Get
                Return fPMDAVIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMDAVIDX", fPMDAVIDX, value)
            End Set
        End Property
        Dim fPMDTKIDX As Integer
        Public Property PMDTKIDX() As Integer
            Get
                Return fPMDTKIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMDTKIDX", fPMDTKIDX, value)
            End Set
        End Property
        Dim fPMFINIDX As Integer
        Public Property PMFINIDX() As Integer
            Get
                Return fPMFINIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMFINIDX", fPMFINIDX, value)
            End Set
        End Property
        Dim fPMMSCHIX As Integer
        Public Property PMMSCHIX() As Integer
            Get
                Return fPMMSCHIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMMSCHIX", fPMMSCHIX, value)
            End Set
        End Property
        Dim fPMFRTIDX As Integer
        Public Property PMFRTIDX() As Integer
            Get
                Return fPMFRTIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMFRTIDX", fPMFRTIDX, value)
            End Set
        End Property
        Dim fPMTAXIDX As Integer
        Public Property PMTAXIDX() As Integer
            Get
                Return fPMTAXIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMTAXIDX", fPMTAXIDX, value)
            End Set
        End Property
        Dim fPMWRTIDX As Integer
        Public Property PMWRTIDX() As Integer
            Get
                Return fPMWRTIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMWRTIDX", fPMWRTIDX, value)
            End Set
        End Property
        Dim fPMPRCHIX As Integer
        Public Property PMPRCHIX() As Integer
            Get
                Return fPMPRCHIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMPRCHIX", fPMPRCHIX, value)
            End Set
        End Property
        Dim fPMRTNGIX As Integer
        Public Property PMRTNGIX() As Integer
            Get
                Return fPMRTNGIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMRTNGIX", fPMRTNGIX, value)
            End Set
        End Property
        Dim fPMTDSCIX As Integer
        Public Property PMTDSCIX() As Integer
            Get
                Return fPMTDSCIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PMTDSCIX", fPMTDSCIX, value)
            End Set
        End Property
        Dim fACPURIDX As Integer
        Public Property ACPURIDX() As Integer
            Get
                Return fACPURIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACPURIDX", fACPURIDX, value)
            End Set
        End Property
        Dim fPURPVIDX As Integer
        Public Property PURPVIDX() As Integer
            Get
                Return fPURPVIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PURPVIDX", fPURPVIDX, value)
            End Set
        End Property
        Dim fNOTEINDX As Decimal
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fCHEKBKID As String
        <Size(15)> _
        Public Property CHEKBKID() As String
            Get
                Return fCHEKBKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHEKBKID", fCHEKBKID, value)
            End Set
        End Property
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
            End Set
        End Property
        Dim fCREATDDT As DateTime
        Public Property CREATDDT() As DateTime
            Get
                Return fCREATDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CREATDDT", fCREATDDT, value)
            End Set
        End Property
        Dim fRATETPID As String
        <Size(15)> _
        Public Property RATETPID() As String
            Get
                Return fRATETPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RATETPID", fRATETPID, value)
            End Set
        End Property
        Dim fRevalue_Vendor As Byte
        Public Property Revalue_Vendor() As Byte
            Get
                Return fRevalue_Vendor
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Revalue_Vendor", fRevalue_Vendor, value)
            End Set
        End Property
        Dim fPost_Results_To As Short
        Public Property Post_Results_To() As Short
            Get
                Return fPost_Results_To
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Post_Results_To", fPost_Results_To, value)
            End Set
        End Property
        Dim fFREEONBOARD As Short
        Public Property FREEONBOARD() As Short
            Get
                Return fFREEONBOARD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FREEONBOARD", fFREEONBOARD, value)
            End Set
        End Property
        Dim fGOVCRPID As String
        <Size(31)> _
        Public Property GOVCRPID() As String
            Get
                Return fGOVCRPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GOVCRPID", fGOVCRPID, value)
            End Set
        End Property
        Dim fGOVINDID As String
        <Size(31)> _
        Public Property GOVINDID() As String
            Get
                Return fGOVINDID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GOVINDID", fGOVINDID, value)
            End Set
        End Property
        Dim fDISGRPER As Short
        Public Property DISGRPER() As Short
            Get
                Return fDISGRPER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DISGRPER", fDISGRPER, value)
            End Set
        End Property
        Dim fDUEGRPER As Short
        Public Property DUEGRPER() As Short
            Get
                Return fDUEGRPER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DUEGRPER", fDUEGRPER, value)
            End Set
        End Property
        Dim fDOCFMTID As String
        <Size(15)> _
        Public Property DOCFMTID() As String
            Get
                Return fDOCFMTID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DOCFMTID", fDOCFMTID, value)
            End Set
        End Property
        Dim fTaxInvRecvd As Byte
        Public Property TaxInvRecvd() As Byte
            Get
                Return fTaxInvRecvd
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TaxInvRecvd", fTaxInvRecvd, value)
            End Set
        End Property
        Dim fUSERLANG As Short
        Public Property USERLANG() As Short
            Get
                Return fUSERLANG
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("USERLANG", fUSERLANG, value)
            End Set
        End Property
        Dim fWithholdingType As Short
        Public Property WithholdingType() As Short
            Get
                Return fWithholdingType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WithholdingType", fWithholdingType, value)
            End Set
        End Property
        Dim fWithholdingFormType As Short
        Public Property WithholdingFormType() As Short
            Get
                Return fWithholdingFormType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WithholdingFormType", fWithholdingFormType, value)
            End Set
        End Property
        Dim fWithholdingEntityType As Short
        Public Property WithholdingEntityType() As Short
            Get
                Return fWithholdingEntityType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WithholdingEntityType", fWithholdingEntityType, value)
            End Set
        End Property
        Dim fTaxFileNumMode As Short
        Public Property TaxFileNumMode() As Short
            Get
                Return fTaxFileNumMode
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TaxFileNumMode", fTaxFileNumMode, value)
            End Set
        End Property
        Dim fBRTHDATE As DateTime
        Public Property BRTHDATE() As DateTime
            Get
                Return fBRTHDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("BRTHDATE", fBRTHDATE, value)
            End Set
        End Property
        Dim fLaborPmtType As Short
        Public Property LaborPmtType() As Short
            Get
                Return fLaborPmtType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LaborPmtType", fLaborPmtType, value)
            End Set
        End Property
        Dim fCCode As String
        <Size(7)> _
        Public Property CCode() As String
            Get
                Return fCCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CCode", fCCode, value)
            End Set
        End Property
        Dim fDECLID As String
        <Size(15)> _
        Public Property DECLID() As String
            Get
                Return fDECLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DECLID", fDECLID, value)
            End Set
        End Property
        Dim fCBVAT As Byte
        Public Property CBVAT() As Byte
            Get
                Return fCBVAT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CBVAT", fCBVAT, value)
            End Set
        End Property
        Dim fWorkflow_Approval_Status As Short
        Public Property Workflow_Approval_Status() As Short
            Get
                Return fWorkflow_Approval_Status
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Workflow_Approval_Status", fWorkflow_Approval_Status, value)
            End Set
        End Property
        Dim fWorkflow_Priority As Short
        Public Property Workflow_Priority() As Short
            Get
                Return fWorkflow_Priority
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Workflow_Priority", fWorkflow_Priority, value)
            End Set
        End Property

        Dim fDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID() As Integer
            Get
                Return fDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
            End Set
        End Property

#End Region
    End Class

End Namespace
