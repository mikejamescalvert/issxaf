Imports System
Imports DevExpress.Xpo
Namespace Objects.MS
    ''' <summary>
    ''' GP Table MS273527
    ''' </summary>
    <Persistent("MS273527")>
    Public Class MSNodusCreditCardMaster
        Inherits XPLiteObject

        Public Structure NodusCreditCardMasterKey

            Public Sub New(ByVal CustomerNumber As String, ByVal MSOCardNumber As String, ByVal CardExpDate As String)
                CUSTNMBR = CustomerNumber
                MSO_CardNumberPABP = MSOCardNumber
                MSO_CardExpDate = CardExpDate
            End Sub

            Private fCUSTNMBR As String
            <Size(15)>
            <Persistent("CUSTNMBR")>
            Public Property CUSTNMBR() As String
                Get
                    Return fCUSTNMBR
                End Get
                Set(ByVal value As String)
                    fCUSTNMBR = value
                End Set
            End Property
            Private fMSO_CardNumberPABP As String
            <Size(165)>
            <Persistent("MSO_CardNumberPABP")>
            Public Property MSO_CardNumberPABP() As String
                Get
                    Return fMSO_CardNumberPABP
                End Get
                Set(ByVal value As String)
                    fMSO_CardNumberPABP = value
                End Set
            End Property
            Private fMSO_CardExpDate As String
            <Size(5)>
            <Persistent("MSO_CardExpDate")>
            Public Property MSO_CardExpDate() As String
                Get
                    Return fMSO_CardExpDate
                End Get
                Set(ByVal value As String)
                    fMSO_CardExpDate = value
                End Set
            End Property
        End Structure

        Dim fOid As NodusCreditCardMasterKey
        <Key()>
        <Persistent()>
        Public Property Oid() As NodusCreditCardMasterKey
            Get
                Return fOid
            End Get
            Set(ByVal value As NodusCreditCardMasterKey)
                SetPropertyValue(Of NodusCreditCardMasterKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fMSO_CardName As String
        <Size(31)>
        Public Property MSO_CardName() As String
            Get
                Return fMSO_CardName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_CardName", fMSO_CardName, value)
            End Set
        End Property

        Dim fMSO_CardType As Char
        Public Property MSO_CardType() As Char
            Get
                Return fMSO_CardType
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("MSO_CardType", fMSO_CardType, value)
            End Set
        End Property
        Dim fMSO_Issue_Number As String
        <Size(101)>
        Public Property MSO_Issue_Number() As String
            Get
                Return fMSO_Issue_Number
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_Issue_Number", fMSO_Issue_Number, value)
            End Set
        End Property
        Dim fMSO_Start_Date As String
        <Size(5)>
        Public Property MSO_Start_Date() As String
            Get
                Return fMSO_Start_Date
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_Start_Date", fMSO_Start_Date, value)
            End Set
        End Property
        Dim fADRSCODE As String
        <Size(15)>
        Public Property ADRSCODE() As String
            Get
                Return fADRSCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADRSCODE", fADRSCODE, value)
            End Set
        End Property
        Dim fFRSTNAME As String
        <Size(15)>
        Public Property FRSTNAME() As String
            Get
                Return fFRSTNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FRSTNAME", fFRSTNAME, value)
            End Set
        End Property
        Dim fMIDLNAME As String
        <Size(15)>
        Public Property MIDLNAME() As String
            Get
                Return fMIDLNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MIDLNAME", fMIDLNAME, value)
            End Set
        End Property
        Dim fLASTNAME As String
        <Size(21)>
        Public Property LASTNAME() As String
            Get
                Return fLASTNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LASTNAME", fLASTNAME, value)
            End Set
        End Property
        Dim fADDRESS1 As String
        <Size(61)>
        Public Property ADDRESS1() As String
            Get
                Return fADDRESS1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS1", fADDRESS1, value)
            End Set
        End Property
        Dim fADDRESS2 As String
        <Size(61)>
        Public Property ADDRESS2() As String
            Get
                Return fADDRESS2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS2", fADDRESS2, value)
            End Set
        End Property
        Dim fADDRESS3 As String
        <Size(61)>
        Public Property ADDRESS3() As String
            Get
                Return fADDRESS3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS3", fADDRESS3, value)
            End Set
        End Property
        Dim fCITY As String
        <Size(35)>
        Public Property CITY() As String
            Get
                Return fCITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CITY", fCITY, value)
            End Set
        End Property
        Dim fSTATE As String
        <Size(29)>
        Public Property STATE() As String
            Get
                Return fSTATE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STATE", fSTATE, value)
            End Set
        End Property
        Dim fCOUNTRY As String
        <Size(61)>
        Public Property COUNTRY() As String
            Get
                Return fCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
            End Set
        End Property
        Dim fZIPCODE As String
        <Size(11)>
        Public Property ZIPCODE() As String
            Get
                Return fZIPCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIPCODE", fZIPCODE, value)
            End Set
        End Property
        Dim fEMail As String
        <Size(255)>
        Public Property EMail() As String
            Get
                Return fEMail
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EMail", fEMail, value)
            End Set
        End Property
        Dim fPHONNAME As String
        <Size(21)>
        Public Property PHONNAME() As String
            Get
                Return fPHONNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONNAME", fPHONNAME, value)
            End Set
        End Property
        Dim fMSO_DESC_PABP As String
        <Size(165)>
        Public Property MSO_DESC_PABP() As String
            Get
                Return fMSO_DESC_PABP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_DESC_PABP", fMSO_DESC_PABP, value)
            End Set
        End Property
        Dim fMSO_DESC1_PABP As String
        <Size(165)>
        Public Property MSO_DESC1_PABP() As String
            Get
                Return fMSO_DESC1_PABP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_DESC1_PABP", fMSO_DESC1_PABP, value)
            End Set
        End Property
        Dim fMSO_DESC2_PABP As String
        <Size(165)>
        Public Property MSO_DESC2_PABP() As String
            Get
                Return fMSO_DESC2_PABP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_DESC2_PABP", fMSO_DESC2_PABP, value)
            End Set
        End Property
        Dim fMSO_DESC3_PABP As String
        <Size(165)>
        Public Property MSO_DESC3_PABP() As String
            Get
                Return fMSO_DESC3_PABP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_DESC3_PABP", fMSO_DESC3_PABP, value)
            End Set
        End Property
        Dim fMSO_DESC4_PABP As String
        <Size(165)>
        Public Property MSO_DESC4_PABP() As String
            Get
                Return fMSO_DESC4_PABP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_DESC4_PABP", fMSO_DESC4_PABP, value)
            End Set
        End Property
        Dim fMSO_COMMENT1 As String
        <Size(51)>
        Public Property MSO_COMMENT1() As String
            Get
                Return fMSO_COMMENT1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_COMMENT1", fMSO_COMMENT1, value)
            End Set
        End Property
        Dim fMSO_COMMENT2 As String
        <Size(51)>
        Public Property MSO_COMMENT2() As String
            Get
                Return fMSO_COMMENT2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_COMMENT2", fMSO_COMMENT2, value)
            End Set
        End Property
        Dim fMSO_COMMENT3 As String
        <Size(51)>
        Public Property MSO_COMMENT3() As String
            Get
                Return fMSO_COMMENT3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_COMMENT3", fMSO_COMMENT3, value)
            End Set
        End Property
        Dim fMSO_COMMENT4 As String
        <Size(51)>
        Public Property MSO_COMMENT4() As String
            Get
                Return fMSO_COMMENT4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_COMMENT4", fMSO_COMMENT4, value)
            End Set
        End Property
        Dim fMSO_COMMENT5 As String
        <Size(51)>
        Public Property MSO_COMMENT5() As String
            Get
                Return fMSO_COMMENT5
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_COMMENT5", fMSO_COMMENT5, value)
            End Set
        End Property
        Dim fMSO_Check_Number As String
        <Size(15)>
        Public Property MSO_Check_Number() As String
            Get
                Return fMSO_Check_Number
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_Check_Number", fMSO_Check_Number, value)
            End Set
        End Property
        Dim fMSO_ABA As String
        <Size(31)>
        Public Property MSO_ABA() As String
            Get
                Return fMSO_ABA
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_ABA", fMSO_ABA, value)
            End Set
        End Property
        Dim fMSO_AcctType As String
        <Size(11)>
        Public Property MSO_AcctType() As String
            Get
                Return fMSO_AcctType
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_AcctType", fMSO_AcctType, value)
            End Set
        End Property
        Dim fMSO_Default_ACH As Byte
        Public Property MSO_Default_ACH() As Byte
            Get
                Return fMSO_Default_ACH
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MSO_Default_ACH", fMSO_Default_ACH, value)
            End Set
        End Property
        Dim fMSO_DLicense As String
        <Size(31)>
        Public Property MSO_DLicense() As String
            Get
                Return fMSO_DLicense
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_DLicense", fMSO_DLicense, value)
            End Set
        End Property
        Dim fMSO_ACCT As String
        <Size(19)>
        Public Property MSO_ACCT() As String
            Get
                Return fMSO_ACCT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_ACCT", fMSO_ACCT, value)
            End Set
        End Property
        Dim fMSO_BankName As String
        <Size(51)>
        Public Property MSO_BankName() As String
            Get
                Return fMSO_BankName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_BankName", fMSO_BankName, value)
            End Set
        End Property
        Dim fMSO_DateOfBirth As DateTime
        Public Property MSO_DateOfBirth() As DateTime
            Get
                Return fMSO_DateOfBirth
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MSO_DateOfBirth", fMSO_DateOfBirth, value)
            End Set
        End Property
        Dim fMSO_SSN As String
        <Size(21)>
        Public Property MSO_SSN() As String
            Get
                Return fMSO_SSN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSO_SSN", fMSO_SSN, value)
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
