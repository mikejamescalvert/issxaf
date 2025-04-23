Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00201
    ''' </summary>
    <System.ComponentModel.DefaultProperty("CLASSID")>
    <Persistent("RM00201")>
    Public Class RMCustomerClass
        Inherits XPLiteObject
        Dim fCLASSID As String
        <Key()>
        <Size(15)>
        Public Property CLASSID() As String
            Get
                Return fCLASSID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CLASSID", fCLASSID, value)
            End Set
        End Property
        Dim fCLASDSCR As String
        <Size(31)>
        Public Property CLASDSCR() As String
            Get
                Return fCLASDSCR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CLASDSCR", fCLASDSCR, value)
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
        Dim fDEFLTCLS As Byte
        Public Property DEFLTCLS() As Byte
            Get
                Return fDEFLTCLS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DEFLTCLS", fDEFLTCLS, value)
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
        Dim fCHEKBKID As String
        <Size(15)>
        Public Property CHEKBKID() As String
            Get
                Return fCHEKBKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHEKBKID", fCHEKBKID, value)
            End Set
        End Property
        Dim fBANKNAME As String
        <Size(31)>
        Public Property BANKNAME() As String
            Get
                Return fBANKNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BANKNAME", fBANKNAME, value)
            End Set
        End Property
        Dim fTAXSCHID As String
        <Size(15)>
        Public Property TAXSCHID() As String
            Get
                Return fTAXSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXSCHID", fTAXSCHID, value)
            End Set
        End Property
        Dim fSHIPMTHD As String
        <Size(15)>
        Public Property SHIPMTHD() As String
            Get
                Return fSHIPMTHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHIPMTHD", fSHIPMTHD, value)
            End Set
        End Property
        Dim fPYMTRMID As String
        <Size(21)>
        Public Property PYMTRMID() As String
            Get
                Return fPYMTRMID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PYMTRMID", fPYMTRMID, value)
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
        Dim fCSTPRLVL As String
        <Size(11)>
        Public Property CSTPRLVL() As String
            Get
                Return fCSTPRLVL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CSTPRLVL", fCSTPRLVL, value)
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
        Dim fFINCHARG As Byte
        Public Property FINCHARG() As Byte
            Get
                Return fFINCHARG
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("FINCHARG", fFINCHARG, value)
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
        Dim fFINCHDLR As Decimal
        Public Property FINCHDLR() As Decimal
            Get
                Return fFINCHDLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FINCHDLR", fFINCHDLR, value)
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
        Dim fPRCLEVEL As String
        <Size(11)>
        Public Property PRCLEVEL() As String
            Get
                Return fPRCLEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCLEVEL", fPRCLEVEL, value)
            End Set
        End Property
        Dim fCURNCYID As String
        <Size(15)>
        Public Property CURNCYID() As String
            Get
                Return fCURNCYID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CURNCYID", fCURNCYID, value)
            End Set
        End Property
        Dim fRATETPID As String
        <Size(15)>
        Public Property RATETPID() As String
            Get
                Return fRATETPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RATETPID", fRATETPID, value)
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
        Dim fRMCOSACC As Integer
        Public Property RMCOSACC() As Integer
            Get
                Return fRMCOSACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMCOSACC", fRMCOSACC, value)
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
        Dim fRMSLSACC As Integer
        Public Property RMSLSACC() As Integer
            Get
                Return fRMSLSACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMSLSACC", fRMSLSACC, value)
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
        Dim fRMTAKACC As Integer
        Public Property RMTAKACC() As Integer
            Get
                Return fRMTAKACC
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMTAKACC", fRMTAKACC, value)
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
        Dim fSALSTERR As String
        <Size(15)>
        Public Property SALSTERR() As String
            Get
                Return fSALSTERR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SALSTERR", fSALSTERR, value)
            End Set
        End Property
        Dim fSLPRSNID As String
        <Size(15)>
        Public Property SLPRSNID() As String
            Get
                Return fSLPRSNID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SLPRSNID", fSLPRSNID, value)
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
        Dim fSNDSTMNT As Byte
        Public Property SNDSTMNT() As Byte
            Get
                Return fSNDSTMNT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SNDSTMNT", fSNDSTMNT, value)
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
        Dim fKPCALHST As Byte
        Public Property KPCALHST() As Byte
            Get
                Return fKPCALHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPCALHST", fKPCALHST, value)
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
        Dim fRMOvrpymtWrtoffAcctIdx As Integer
        Public Property RMOvrpymtWrtoffAcctIdx() As Integer
            Get
                Return fRMOvrpymtWrtoffAcctIdx
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RMOvrpymtWrtoffAcctIdx", fRMOvrpymtWrtoffAcctIdx, value)
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
        Dim fDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID() As Integer
            Get
                Return fDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
            End Set
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
