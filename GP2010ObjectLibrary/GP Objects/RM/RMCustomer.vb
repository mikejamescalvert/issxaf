Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00101
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("RM00101")> _
    <DefaultProperty("npSummaryInfo")> _
    <OptimisticLocking(False)> _
    Public Class RMCustomer
        Inherits XPLiteObject

#Region "Behaviors"
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

#End Region


#Region "Non-Persistent Properties"
        <VisibleInLookupListView(False)>
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Summary Info")>
        <PersistentAlias("concat(CUSTNMBR,' - ',CUSTNAME)")>
        Public ReadOnly Property npSummaryInfo As String
            Get
                Return EvaluateAlias("npSummaryInfo")
            End Get
        End Property
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Shipping Method")>
        <PersistentAlias("[<SYShippingMethod>][SHIPMTHD = ^.SHIPMTHD].Single()")>
        Public ReadOnly Property ShippingMethod As SY.SYShippingMethod
            Get
                Return TryCast(EvaluateAlias("ShippingMethod"), SY.SYShippingMethod)
            End Get
        End Property
        '        Private _mShippingMethod As SY.SYShippingMethod
        '        <VisibleInDetailView(False)>
        '        <VisibleInListView(False)>
        '        <System.ComponentModel.DisplayName("Shipping Method")>
        'Public ReadOnly Property npShippingMethod As SY.SYShippingMethod
        '            Get

        '                If Not String.IsNullOrEmpty(Me.SHIPMTHD) Then
        '                    Return Session.FindObject(Of SY.SYShippingMethod)(New BinaryOperator("SHIPMTHD", Me.SHIPMTHD))
        '                Else
        '                    Return Nothing
        '                End If

        '            End Get
        '        End Property
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Payment Terms")>
        <PersistentAlias("[<SYPaymentTerms>][PYMTRMID = ^.PYMTRMID].Single()")>
        Public ReadOnly Property PaymentTerms As SY.SYPaymentTerms
            Get
                Return TryCast(EvaluateAlias("PaymentTerms"), SY.SYPaymentTerms)
            End Get
        End Property
        'Private _mPaymentTerms As SY.SYPaymentTerms
        '<VisibleInDetailView(False)>
        '<VisibleInListView(False)>
        '<System.ComponentModel.DisplayName("Payment Terms")>
        'Public ReadOnly Property npPaymentTerms As SY.SYPaymentTerms
        '    Get
        '        If Not String.IsNullOrEmpty(Me.PYMTRMID) Then
        '            Return Session.FindObject(Of SY.SYPaymentTerms)(New BinaryOperator("PYMTRMID", Me.PYMTRMID))
        '        Else
        '            Return Nothing
        '        End If
        '    End Get
        'End Property

        <PersistentAlias("[<TXTaxScheduleKey>][TAXSCHID = ^.TAXSCHID].Single()")>
        Public ReadOnly Property TaxSchedule As TX.TXTaxScheduleKey
            Get
                'If Not String.IsNullOrEmpty(Me.TAXSCHID) Then
                '    Return Session.FindObject(Of TX.TXTaxScheduleKey)(New BinaryOperator("TAXSCHID", Me.TAXSCHID))
                'Else
                '    Return Nothing
                'End If
                Return TryCast(EvaluateAlias("TaxSchedule"), TX.TXTaxScheduleKey)

            End Get
        End Property

        Private _mAddresses As XPCollection(Of RM.RMCustomerAddress)
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Addresses")>
        Public ReadOnly Property npAddresses As XPCollection(Of RM.RMCustomerAddress)
            Get
                If _mAddresses Is Nothing Then
                    _mAddresses = New XPCollection(Of RM.RMCustomerAddress)(Session, New BinaryOperator("Oid.CUSTNMBR", Me.CUSTNMBR))

                End If
                Return _mAddresses
            End Get
        End Property

        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Primary Bill To Address")>
        <PersistentAlias("[<RMCustomerAddress>][Oid.CUSTNMBR = ^.CUSTNMBR AND Oid.ADRSCODE = ^.PRBTADCD].Single()")>
        Public ReadOnly Property PrimaryBillToAddress As RM.RMCustomerAddress
            Get
                Return TryCast(EvaluateAlias("PrimaryBillToAddress"), RM.RMCustomerAddress)
            End Get
        End Property
        'Private _mPrimaryBillToAddress As RM.RMCustomerAddress
        '<VisibleInDetailView(False)>
        '<VisibleInListView(False)>
        '<System.ComponentModel.DisplayName("Primary Bill To Address")>
        'Public ReadOnly Property npPrimaryBillToAddress As RM.RMCustomerAddress
        '    Get
        '        If _mPrimaryBillToAddress Is Nothing AndAlso Me.PRBTADCD IsNot Nothing Then
        '            Dim xpoGO As New GroupOperator
        '            With xpoGO.Operands
        '                .Add(New BinaryOperator("Oid.CUSTNMBR", Me.CUSTNMBR))
        '                .Add(New BinaryOperator("Oid.ADRSCODE", Me.PRBTADCD))
        '            End With
        '            Return Session.FindObject(Of RM.RMCustomerAddress)(xpoGO)
        '        Else
        '            Return Nothing

        '        End If
        '    End Get
        'End Property

		<VisibleInDetailView(False)>
		<VisibleInListView(False)>
		<System.ComponentModel.DisplayName("Email Address")>
		<PersistentAlias("INetInfo.INET1")>
  Public ReadOnly Property EmailAddress As String
			Get
				Return EvaluateAlias("EmailAddress")
			End Get
		End Property


        ' Private _mINetInfo As Object
		<VisibleInDetailView(False)>
		<VisibleInListView(False)>
		<PersistentAlias("[<SYInternetAddressDetail>][Oid.Master_Type = 'CUS' AND Oid.Master_ID = ^.CUSTNMBR].Single()")>
		Public ReadOnly Property INetInfo As SY.SYInternetAddressDetail
			Get
				'If _mINetInfo Is Nothing Then
				'    Dim xpoGO As New GroupOperator
				'    With xpoGO.Operands
				'        .Add(New BinaryOperator("Master_Type", "CUS"))
				'        .Add(New BinaryOperator("Master_ID", Me.CUSTNMBR))
				'    End With
				'    _mINetInfo = Session.FindObject(Of SY.SYInternetAddressDetail)(xpoGO)
				'End If
				'Return _mINetInfo
				Return TryCast(EvaluateAlias("INetInfo"), SY.SYInternetAddressDetail)
			End Get
		End Property

        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <PersistentAlias("[<RMCustomerAddress>][Oid.CUSTNMBR = ^.CUSTNMBR AND Oid.ADRSCODE = ^.STADDRCD].Single()")>
        Public ReadOnly Property PrimaryShipToAddress As RM.RMCustomerAddress
            Get
                Return TryCast(EvaluateAlias("PrimaryShipToAddress"), RM.RMCustomerAddress)
            End Get
        End Property
        'Private _mPrimaryShipToAddress As RM.RMCustomerAddress
        '<VisibleInDetailView(False)>
        '<VisibleInListView(False)>
        '<System.ComponentModel.DisplayName("Primary Ship To Address")>
        'Public ReadOnly Property npPrimaryShipToAddress As RM.RMCustomerAddress
        '    Get
        '        If _mPrimaryShipToAddress Is Nothing AndAlso Me.PRBTADCD IsNot Nothing Then
        '            Dim xpoGO As New GroupOperator
        '            With xpoGO.Operands
        '                .Add(New BinaryOperator("Oid.CUSTNMBR", Me.CUSTNMBR))
        '                .Add(New BinaryOperator("Oid.ADRSCODE", Me.STADDRCD))
        '            End With
        '            Return Session.FindObject(Of RM.RMCustomerAddress)(xpoGO)
        '        Else
        '            Return Nothing

        '        End If
        '    End Get
        'End Property

        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <PersistentAlias("[<RMSalesperson>][SLPRSNID = ^.SLPRSNID].Single()")>
        Public ReadOnly Property Salesperson As RM.RMSalesperson
            Get
                Return TryCast(EvaluateAlias("Salesperson"), RM.RMSalesperson)
            End Get
        End Property
        'Private _mSalesPerson As RM.RMSalesperson
        '<VisibleInDetailView(False)>
        '<VisibleInListView(False)>
        '<System.ComponentModel.DisplayName("Salesperson")>
        'Public ReadOnly Property npSalesperson As RM.RMSalesperson
        '    Get
        '        If _mSalesPerson Is Nothing Then
        '            _mSalesPerson = Session.FindObject(Of RM.RMSalesperson)(New BinaryOperator("SLPRSNID", Me.SLPRSNID))
        '        End If
        '        Return _mSalesPerson
        '    End Get
        'End Property
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <PersistentAlias("[<RMReceivableDocument>][Oid.CUSTNMBR = ^.CUSTNMBR And Oid.RMDTYPAL In (1,3) And CURTRXAM > 0].Sum(CURTRXAM)")>
        Public ReadOnly Property OpenBalance As Decimal
            Get
                Return EvaluateAlias("OpenBalance")
            End Get
        End Property


        Private _mOpenInvoices As XPCollection(Of RM.RMReceivableDocument)
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Open Invoices")>
        Public ReadOnly Property npOpenInvoices As XPCollection(Of RM.RMReceivableDocument)
            Get

                If _mOpenInvoices Is Nothing Then
                    Dim gpoOpenInvoices As New DevExpress.Data.Filtering.GroupOperator
                    gpoOpenInvoices.Operands.Add(New BinaryOperator("Oid.CUSTNMBR", Me.CUSTNMBR))
                    gpoOpenInvoices.Operands.Add(New BinaryOperator("CURTRXAM", 0, BinaryOperatorType.Greater))
                    gpoOpenInvoices.Operands.Add(New InOperator("Oid.RMDTYPAL", New List(Of Integer)({1, 3})))
                    'gpoOpenInvoices.Operands.Add(New NotOperator(New NullOperator("AssociatedHistoricalInvoice")))
                    'gpoOpenInvoices.Operands.Add(New BinaryOperator("AssociatedHistoricalInvoice.Oid.SOPTYPE", "3"))
                    _mOpenInvoices = New XPCollection(Of RM.RMReceivableDocument)(Session, gpoOpenInvoices)

                End If
                Return _mOpenInvoices
            End Get
        End Property



        'Private _mCreditMemos As XPCollection(Of RM.RMReceivableDocument)
        '<VisibleInDetailView(False)>
        '<VisibleInListView(False)>
        '<System.ComponentModel.DisplayName("Credit Memos")>
        'Public ReadOnly Property npCreditMemos As XPCollection(Of RM.RMReceivableDocument)
        '    Get

        '        If _mCreditMemos Is Nothing Then
        '            Dim gpoCreditMemos As New DevExpress.Data.Filtering.GroupOperator
        '            gpoCreditMemos.Operands.Add(New BinaryOperator("Oid.CUSTNMBR", Me.CUSTNMBR))
        '            gpoCreditMemos.Operands.Add(New BinaryOperator("Oid.RMDTYPAL", 8))
        '            'gpoOpenInvoices.Operands.Add(New NotOperator(New NullOperator("AssociatedHistoricalInvoice")))
        '            'gpoOpenInvoices.Operands.Add(New BinaryOperator("AssociatedHistoricalInvoice.Oid.SOPTYPE", "3"))
        '            _mCreditMemos = New XPCollection(Of RM.RMReceivableDocument)(Session, gpoCreditMemos)

        '        End If
        '        Return _mCreditMemos
        '    End Get
        'End Property

#End Region



#Region "Properties"

        Dim fCUSTNMBR As String
        <VisibleInLookupListView(True)>
        <VisibleInListView(True)>
        <Size(15)> _
        <Key()> _
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property
        Dim fCUSTNAME As String
        <VisibleInLookupListView(True)>
        <VisibleInListView(True)>
        <Size(65)> _
        Public Property CUSTNAME() As String
            Get
                Return fCUSTNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNAME", fCUSTNAME, value)
            End Set
        End Property
        Dim fCUSTCLAS As String
        <Size(15)> _
        Public Property CUSTCLAS() As String
            Get
                Return fCUSTCLAS
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTCLAS", fCUSTCLAS, value)
            End Set
        End Property
        Dim fCPRCSTNM As String
        <Size(15)> _
        Public Property CPRCSTNM() As String
            Get
                Return fCPRCSTNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CPRCSTNM", fCPRCSTNM, value)
            End Set
        End Property
        Dim fCNTCPRSN As String
        <Size(61)> _
        Public Property CNTCPRSN() As String
            Get
                Return fCNTCPRSN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CNTCPRSN", fCNTCPRSN, value)
            End Set
        End Property
        Dim fSTMTNAME As String
        <Size(65)> _
        Public Property STMTNAME() As String
            Get
                Return fSTMTNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STMTNAME", fSTMTNAME, value)
            End Set
        End Property
        Dim fSHRTNAME As String
        <Size(15)> _
        Public Property SHRTNAME() As String
            Get
                Return fSHRTNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHRTNAME", fSHRTNAME, value)
            End Set
        End Property
        Dim fADRSCODE As String
        <Size(15)> _
        Public Property ADRSCODE() As String
            Get
                Return fADRSCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADRSCODE", fADRSCODE, value)
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
        Dim fZIP As String
        <Size(11)> _
        Public Property ZIP() As String
            Get
                Return fZIP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIP", fZIP, value)
            End Set
        End Property
        Dim fPHONE1 As String
        <Size(21)> _
        Public Property PHONE1() As String
            Get
                Return fPHONE1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE1", fPHONE1, value)
            End Set
        End Property
        Dim fPHONE2 As String
        <Size(21)> _
        Public Property PHONE2() As String
            Get
                Return fPHONE2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE2", fPHONE2, value)
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
        Dim fFAX As String
        <Size(21)> _
        Public Property FAX() As String
            Get
                Return fFAX
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FAX", fFAX, value)
            End Set
        End Property
        Dim fPRBTADCD As String
        <Size(15)> _
        Public Property PRBTADCD() As String
            Get
                Return fPRBTADCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRBTADCD", fPRBTADCD, value)
            End Set
        End Property
        Dim fPRSTADCD As String
        <Size(15)> _
        Public Property PRSTADCD() As String
            Get
                Return fPRSTADCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRSTADCD", fPRSTADCD, value)
            End Set
        End Property
        Dim fSTADDRCD As String
        <Size(15)> _
        Public Property STADDRCD() As String
            Get
                Return fSTADDRCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STADDRCD", fSTADDRCD, value)
            End Set
        End Property
        Dim fSLPRSNID As String
        <Size(15)> _
        Public Property SLPRSNID() As String
            Get
                Return fSLPRSNID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SLPRSNID", fSLPRSNID, value)
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
        Dim fCRLMTTYP As Short
        Public Property CRLMTTYP() As Short
            Get
                Return fCRLMTTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CRLMTTYP", fCRLMTTYP, value)
            End Set
        End Property
        Dim fCRLMTAMT As Decimal
        Public Property CRLMTAMT() As Decimal
            Get
                Return fCRLMTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CRLMTAMT", fCRLMTAMT, value)
            End Set
        End Property
        Dim fCRLMTPER As Short
        Public Property CRLMTPER() As Short
            Get
                Return fCRLMTPER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CRLMTPER", fCRLMTPER, value)
            End Set
        End Property
        Dim fCRLMTPAM As Decimal
        Public Property CRLMTPAM() As Decimal
            Get
                Return fCRLMTPAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CRLMTPAM", fCRLMTPAM, value)
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
        Dim fCUSTDISC As Short
        Public Property CUSTDISC() As Short
            Get
                Return fCUSTDISC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CUSTDISC", fCUSTDISC, value)
            End Set
        End Property
        Dim fPRCLEVEL As String
        <Size(11)> _
        Public Property PRCLEVEL() As String
            Get
                Return fPRCLEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCLEVEL", fPRCLEVEL, value)
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
        Dim fMINPYDLR As Decimal
        Public Property MINPYDLR() As Decimal
            Get
                Return fMINPYDLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MINPYDLR", fMINPYDLR, value)
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
        Dim fFNCHATYP As Short
        Public Property FNCHATYP() As Short
            Get
                Return fFNCHATYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FNCHATYP", fFNCHATYP, value)
            End Set
        End Property
        Dim fFNCHPCNT As Short
        Public Property FNCHPCNT() As Short
            Get
                Return fFNCHPCNT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FNCHPCNT", fFNCHPCNT, value)
            End Set
        End Property
        Dim fFINCHDLR As Decimal
        Public Property FINCHDLR() As Decimal
            Get
                Return fFINCHDLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FINCHDLR", fFINCHDLR, value)
            End Set
        End Property
        Dim fMXWOFTYP As Short
        Public Property MXWOFTYP() As Short
            Get
                Return fMXWOFTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MXWOFTYP", fMXWOFTYP, value)
            End Set
        End Property
        Dim fMXWROFAM As Decimal
        Public Property MXWROFAM() As Decimal
            Get
                Return fMXWROFAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MXWROFAM", fMXWROFAM, value)
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
        Dim fTAXEXMT1 As String
        <Size(25)> _
        Public Property TAXEXMT1() As String
            Get
                Return fTAXEXMT1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXEXMT1", fTAXEXMT1, value)
            End Set
        End Property
        Dim fTAXEXMT2 As String
        <Size(25)> _
        Public Property TAXEXMT2() As String
            Get
                Return fTAXEXMT2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXEXMT2", fTAXEXMT2, value)
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
        Dim fBALNCTYP As Short
        Public Property BALNCTYP() As Short
            Get
                Return fBALNCTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BALNCTYP", fBALNCTYP, value)
            End Set
        End Property
        Dim fSTMTCYCL As Short
        Public Property STMTCYCL() As Short
            Get
                Return fSTMTCYCL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("STMTCYCL", fSTMTCYCL, value)
            End Set
        End Property
        Dim fBANKNAME As String
        <Size(31)> _
        Public Property BANKNAME() As String
            Get
                Return fBANKNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BANKNAME", fBANKNAME, value)
            End Set
        End Property
        Dim fBNKBRNCH As String
        <Size(21)> _
        Public Property BNKBRNCH() As String
            Get
                Return fBNKBRNCH
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BNKBRNCH", fBNKBRNCH, value)
            End Set
        End Property
        Dim fSALSTERR As String
        <Size(15)> _
        Public Property SALSTERR() As String
            Get
                Return fSALSTERR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SALSTERR", fSALSTERR, value)
            End Set
        End Property
        Dim fDEFCACTY As Short
        Public Property DEFCACTY() As Short
            Get
                Return fDEFCACTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DEFCACTY", fDEFCACTY, value)
            End Set
        End Property
        Dim fRMCSHACC As Integer
        Public Property RMCSHACC() As Integer
            Get
                Return fRMCSHACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMCSHACC", fRMCSHACC, value)
            End Set
        End Property
        Dim fRMARACC As Integer
        Public Property RMARACC() As Integer
            Get
                Return fRMARACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMARACC", fRMARACC, value)
            End Set
        End Property
        Dim fRMSLSACC As Integer
        Public Property RMSLSACC() As Integer
            Get
                Return fRMSLSACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMSLSACC", fRMSLSACC, value)
            End Set
        End Property
        Dim fRMIVACC As Integer
        Public Property RMIVACC() As Integer
            Get
                Return fRMIVACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMIVACC", fRMIVACC, value)
            End Set
        End Property
        Dim fRMCOSACC As Integer
        Public Property RMCOSACC() As Integer
            Get
                Return fRMCOSACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMCOSACC", fRMCOSACC, value)
            End Set
        End Property
        Dim fRMTAKACC As Integer
        Public Property RMTAKACC() As Integer
            Get
                Return fRMTAKACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMTAKACC", fRMTAKACC, value)
            End Set
        End Property
        Dim fRMAVACC As Integer
        Public Property RMAVACC() As Integer
            Get
                Return fRMAVACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMAVACC", fRMAVACC, value)
            End Set
        End Property
        Dim fRMFCGACC As Integer
        Public Property RMFCGACC() As Integer
            Get
                Return fRMFCGACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMFCGACC", fRMFCGACC, value)
            End Set
        End Property
        Dim fRMWRACC As Integer
        Public Property RMWRACC() As Integer
            Get
                Return fRMWRACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMWRACC", fRMWRACC, value)
            End Set
        End Property
        Dim fRMSORACC As Integer
        Public Property RMSORACC() As Integer
            Get
                Return fRMSORACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMSORACC", fRMSORACC, value)
            End Set
        End Property
        Dim fFRSTINDT As DateTime
        Public Property FRSTINDT() As DateTime
            Get
                Return fFRSTINDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FRSTINDT", fFRSTINDT, value)
            End Set
        End Property
        Dim fINACTIVE As Byte
        Public Property INACTIVE() As Byte
            Get
                Return fINACTIVE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INACTIVE", fINACTIVE, value)
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
        Dim fCRCARDID As String
        <Size(15)> _
        Public Property CRCARDID() As String
            Get
                Return fCRCARDID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CRCARDID", fCRCARDID, value)
            End Set
        End Property
        Dim fCRCRDNUM As String
        <Size(21)> _
        Public Property CRCRDNUM() As String
            Get
                Return fCRCRDNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CRCRDNUM", fCRCRDNUM, value)
            End Set
        End Property
        Dim fCCRDXPDT As DateTime
        Public Property CCRDXPDT() As DateTime
            Get
                Return fCCRDXPDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CCRDXPDT", fCCRDXPDT, value)
            End Set
        End Property
        Dim fKPDSTHST As Byte
        Public Property KPDSTHST() As Byte
            Get
                Return fKPDSTHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPDSTHST", fKPDSTHST, value)
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
        Dim fNOTEINDX As Decimal
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
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
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
            End Set
        End Property
        Dim fRevalue_Customer As Byte
        Public Property Revalue_Customer() As Byte
            Get
                Return fRevalue_Customer
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Revalue_Customer", fRevalue_Customer, value)
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
        Dim fFINCHID As String
        <Size(15)> _
        Public Property FINCHID() As String
            Get
                Return fFINCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FINCHID", fFINCHID, value)
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
        Dim fSend_Email_Statements As Byte
        Public Property Send_Email_Statements() As Byte
            Get
                Return fSend_Email_Statements
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Send_Email_Statements", fSend_Email_Statements, value)
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
        Dim fGPSFOINTEGRATIONID As String
        <Size(31)> _
        Public Property GPSFOINTEGRATIONID() As String
            Get
                Return fGPSFOINTEGRATIONID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GPSFOINTEGRATIONID", fGPSFOINTEGRATIONID, value)
            End Set
        End Property
        Dim fINTEGRATIONSOURCE As Short
        Public Property INTEGRATIONSOURCE() As Short
            Get
                Return fINTEGRATIONSOURCE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("INTEGRATIONSOURCE", fINTEGRATIONSOURCE, value)
            End Set
        End Property
        Dim fINTEGRATIONID As String
        <Size(31)> _
        Public Property INTEGRATIONID() As String
            Get
                Return fINTEGRATIONID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INTEGRATIONID", fINTEGRATIONID, value)
            End Set
        End Property
        Dim fORDERFULFILLDEFAULT As Short
        Public Property ORDERFULFILLDEFAULT() As Short
            Get
                Return fORDERFULFILLDEFAULT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORDERFULFILLDEFAULT", fORDERFULFILLDEFAULT, value)
            End Set
        End Property
        Dim fCUSTPRIORITY As Short
        Public Property CUSTPRIORITY() As Short
            Get
                Return fCUSTPRIORITY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CUSTPRIORITY", fCUSTPRIORITY, value)
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
        Dim fRMOvrpymtWrtoffAcctIdx As Integer
        Public Property RMOvrpymtWrtoffAcctIdx() As Integer
            Get
                Return fRMOvrpymtWrtoffAcctIdx
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMOvrpymtWrtoffAcctIdx", fRMOvrpymtWrtoffAcctIdx, value)
            End Set
        End Property
        Dim fSHIPCOMPLETE As Byte
        Public Property SHIPCOMPLETE() As Byte
            Get
                Return fSHIPCOMPLETE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SHIPCOMPLETE", fSHIPCOMPLETE, value)
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
        Dim fINCLUDEINDP As Byte
        Public Property INCLUDEINDP() As Byte
            Get
                Return fINCLUDEINDP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLUDEINDP", fINCLUDEINDP, value)
            End Set
        End Property


#End Region

    End Class

End Namespace