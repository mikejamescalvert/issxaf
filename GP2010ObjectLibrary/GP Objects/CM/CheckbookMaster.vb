Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.ComponentModel

Namespace Objects.CM
    ''' <summary>
    ''' GP Table CM00100
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("CM00100")>
    <DefaultProperty("CHEKBKID")>
    Public Class CheckBookMaster
        Inherits XPLiteObject
        Dim fCHEKBKID As String
        <Key()>
        <Size(15)>
        Public Property CHEKBKID() As String
            Get
                Return fCHEKBKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHEKBKID", fCHEKBKID, value)
            End Set
        End Property
        Dim fDSCRIPTN As String
        <Size(31)>
        Public Property DSCRIPTN() As String
            Get
                Return fDSCRIPTN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DSCRIPTN", fDSCRIPTN, value)
            End Set
        End Property
        Dim fBANKID As String
        <Size(15)>
        Public Property BANKID() As String
            Get
                Return fBANKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BANKID", fBANKID, value)
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
        Dim fACTINDX As Integer
        Public Property ACTINDX() As Integer
            Get
                Return fACTINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACTINDX", fACTINDX, value)
            End Set
        End Property
        Dim fBNKACTNM As String
        <Size(15)>
        Public Property BNKACTNM() As String
            Get
                Return fBNKACTNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BNKACTNM", fBNKACTNM, value)
            End Set
        End Property
        Dim fNXTCHNUM As String
        <Size(21)>
        Public Property NXTCHNUM() As String
            Get
                Return fNXTCHNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NXTCHNUM", fNXTCHNUM, value)
            End Set
        End Property
        Dim fNext_Deposit_Number As String
        <Size(21)>
        Public Property Next_Deposit_Number() As String
            Get
                Return fNext_Deposit_Number
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Next_Deposit_Number", fNext_Deposit_Number, value)
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
        Dim fDYDEPCLR As Short
        Public Property DYDEPCLR() As Short
            Get
                Return fDYDEPCLR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DYDEPCLR", fDYDEPCLR, value)
            End Set
        End Property
        Dim fXCDMCHPW As String
        <Size(11)>
        Public Property XCDMCHPW() As String
            Get
                Return fXCDMCHPW
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("XCDMCHPW", fXCDMCHPW, value)
            End Set
        End Property
        Dim fMXCHDLR As Decimal
        Public Property MXCHDLR() As Decimal
            Get
                Return fMXCHDLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MXCHDLR", fMXCHDLR, value)
            End Set
        End Property
        Dim fDUPCHNUM As Byte
        Public Property DUPCHNUM() As Byte
            Get
                Return fDUPCHNUM
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DUPCHNUM", fDUPCHNUM, value)
            End Set
        End Property
        Dim fOVCHNUM1 As Byte
        Public Property OVCHNUM1() As Byte
            Get
                Return fOVCHNUM1
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("OVCHNUM1", fOVCHNUM1, value)
            End Set
        End Property
        Dim fLOCATNID As String
        <Size(15)>
        Public Property LOCATNID() As String
            Get
                Return fLOCATNID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCATNID", fLOCATNID, value)
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
        Dim fCMUSRDF1 As String
        <Size(21)>
        Public Property CMUSRDF1() As String
            Get
                Return fCMUSRDF1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CMUSRDF1", fCMUSRDF1, value)
            End Set
        End Property
        Dim fCMUSRDF2 As String
        <Size(21)>
        Public Property CMUSRDF2() As String
            Get
                Return fCMUSRDF2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CMUSRDF2", fCMUSRDF2, value)
            End Set
        End Property
        Dim fLast_Reconciled_Date As DateTime
        Public Property Last_Reconciled_Date() As DateTime
            Get
                Return fLast_Reconciled_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Last_Reconciled_Date", fLast_Reconciled_Date, value)
            End Set
        End Property
        Dim fLast_Reconciled_Balance As Decimal
        Public Property Last_Reconciled_Balance() As Decimal
            Get
                Return fLast_Reconciled_Balance
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Last_Reconciled_Balance", fLast_Reconciled_Balance, value)
            End Set
        End Property
        Dim fCURRBLNC As Decimal
        Public Property CURRBLNC() As Decimal
            Get
                Return fCURRBLNC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CURRBLNC", fCURRBLNC, value)
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
        Dim fRecond As Byte
        Public Property Recond() As Byte
            Get
                Return fRecond
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Recond", fRecond, value)
            End Set
        End Property
        Dim fReconcile_In_Progress As Decimal
        Public Property Reconcile_In_Progress() As Decimal
            Get
                Return fReconcile_In_Progress
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Reconcile_In_Progress", fReconcile_In_Progress, value)
            End Set
        End Property
        Dim fDeposit_In_Progress As String
        <Size(21)>
        Public Property Deposit_In_Progress() As String
            Get
                Return fDeposit_In_Progress
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Deposit_In_Progress", fDeposit_In_Progress, value)
            End Set
        End Property
        Dim fCHBKPSWD As String
        <Size(15)>
        Public Property CHBKPSWD() As String
            Get
                Return fCHBKPSWD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHBKPSWD", fCHBKPSWD, value)
            End Set
        End Property
        Dim fCURNCYPD As String
        <Size(15)>
        Public Property CURNCYPD() As String
            Get
                Return fCURNCYPD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CURNCYPD", fCURNCYPD, value)
            End Set
        End Property
        Dim fCRNCYRCD As String
        <Size(15)>
        Public Property CRNCYRCD() As String
            Get
                Return fCRNCYRCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CRNCYRCD", fCRNCYRCD, value)
            End Set
        End Property
        Dim fADPVADLR As Decimal
        Public Property ADPVADLR() As Decimal
            Get
                Return fADPVADLR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ADPVADLR", fADPVADLR, value)
            End Set
        End Property
        Dim fADPVAPWD As String
        <Size(11)>
        Public Property ADPVAPWD() As String
            Get
                Return fADPVAPWD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADPVAPWD", fADPVAPWD, value)
            End Set
        End Property
        Dim fDYCHTCLR As Short
        Public Property DYCHTCLR() As Short
            Get
                Return fDYCHTCLR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DYCHTCLR", fDYCHTCLR, value)
            End Set
        End Property
        Dim fCMPANYID As Short
        Public Property CMPANYID() As Short
            Get
                Return fCMPANYID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CMPANYID", fCMPANYID, value)
            End Set
        End Property
        Dim fCHKBKTYP As Short
        Public Property CHKBKTYP() As Short
            Get
                Return fCHKBKTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CHKBKTYP", fCHKBKTYP, value)
            End Set
        End Property
        Dim fDDACTNUM As String
        <Size(17)>
        Public Property DDACTNUM() As String
            Get
                Return fDDACTNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DDACTNUM", fDDACTNUM, value)
            End Set
        End Property
        Dim fDDINDNAM As String
        <Size(23)>
        Public Property DDINDNAM() As String
            Get
                Return fDDINDNAM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DDINDNAM", fDDINDNAM, value)
            End Set
        End Property
        Dim fDDTRANS As String
        <Size(3)>
        Public Property DDTRANS() As String
            Get
                Return fDDTRANS
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DDTRANS", fDDTRANS, value)
            End Set
        End Property
        Dim fPaymentRateTypeID As String
        <Size(15)>
        Public Property PaymentRateTypeID() As String
            Get
                Return fPaymentRateTypeID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PaymentRateTypeID", fPaymentRateTypeID, value)
            End Set
        End Property
        Dim fDepositRateTypeID As String
        <Size(15)>
        Public Property DepositRateTypeID() As String
            Get
                Return fDepositRateTypeID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DepositRateTypeID", fDepositRateTypeID, value)
            End Set
        End Property
        Dim fCashInTransAcctIdx As Integer
        Public Property CashInTransAcctIdx() As Integer
            Get
                Return fCashInTransAcctIdx
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CashInTransAcctIdx", fCashInTransAcctIdx, value)
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
