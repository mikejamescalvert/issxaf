Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.SY
    ''' <summary>
    ''' GP Table SY06000
    ''' </summary>
    <Persistent("SY06000")>
    Public Class SYCustomerEFTInformation
        Inherits XPLiteObject

        Public Structure SYCustomerEFTInformationKey
            Private fSERIES As Short
            <Persistent("SERIES")>
            Public Property SERIES() As Short
                Get
                    Return fSERIES
                End Get
                Set(ByVal value As Short)
                    fSERIES = value
                End Set
            End Property
            Private fCustomerVendor_ID As String
            <Size(15)> _
            <Persistent("CustomerVendor_ID")>
            Public Property CustomerVendor_ID() As String
                Get
                    Return fCustomerVendor_ID
                End Get
                Set(ByVal value As String)
                    fCustomerVendor_ID = value
                End Set
            End Property
            Private fADRSCODE As String
            <Size(15)> _
            <Persistent("ADRSCODE")>
            Public Property ADRSCODE() As String
                Get
                    Return fADRSCODE
                End Get
                Set(ByVal value As String)
                    fADRSCODE = value
                End Set
            End Property
        End Structure

        Dim fOid As SYCustomerEFTInformationKey
        <Key()>
        <Persistent()>
        Public Property Oid() As SYCustomerEFTInformationKey
            Get
                Return fOid
            End Get
            Set(ByVal value As SYCustomerEFTInformationKey)
                SetPropertyValue(Of SYCustomerEFTInformationKey)("Oid", fOid, value)
            End Set
        End Property
        
        Dim fVENDORID As String
        <Size(15)> _
        Public Property VENDORID() As String
            Get
                Return fVENDORID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDORID", fVENDORID, value)
            End Set
        End Property
        Dim fCUSTNMBR As String
        <Size(15)> _
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property
        Dim fEFTUseMasterID As Short
        Public Property EFTUseMasterID() As Short
            Get
                Return fEFTUseMasterID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("EFTUseMasterID", fEFTUseMasterID, value)
            End Set
        End Property
        Dim fEFTBankType As Short
        Public Property EFTBankType() As Short
            Get
                Return fEFTBankType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("EFTBankType", fEFTBankType, value)
            End Set
        End Property
        Dim fFRGNBANK As Byte
        Public Property FRGNBANK() As Byte
            Get
                Return fFRGNBANK
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("FRGNBANK", fFRGNBANK, value)
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
        Dim fEFTBankAcct As String
        <Size(35)> _
        Public Property EFTBankAcct() As String
            Get
                Return fEFTBankAcct
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EFTBankAcct", fEFTBankAcct, value)
            End Set
        End Property
        Dim fEFTBankBranch As String
        <Size(15)> _
        Public Property EFTBankBranch() As String
            Get
                Return fEFTBankBranch
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EFTBankBranch", fEFTBankBranch, value)
            End Set
        End Property
        Dim fGIROPostType As Short
        Public Property GIROPostType() As Short
            Get
                Return fGIROPostType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("GIROPostType", fGIROPostType, value)
            End Set
        End Property
        Dim fEFTBankCode As String
        <Size(15)> _
        Public Property EFTBankCode() As String
            Get
                Return fEFTBankCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EFTBankCode", fEFTBankCode, value)
            End Set
        End Property
        Dim fEFTBankBranchCode As String
        <Size(5)> _
        Public Property EFTBankBranchCode() As String
            Get
                Return fEFTBankBranchCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EFTBankBranchCode", fEFTBankBranchCode, value)
            End Set
        End Property
        Dim fEFTBankCheckDigit As String
        <Size(3)> _
        Public Property EFTBankCheckDigit() As String
            Get
                Return fEFTBankCheckDigit
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EFTBankCheckDigit", fEFTBankCheckDigit, value)
            End Set
        End Property
        Dim fBSROLLNO As String
        <Size(31)> _
        Public Property BSROLLNO() As String
            Get
                Return fBSROLLNO
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BSROLLNO", fBSROLLNO, value)
            End Set
        End Property
        Dim fIntlBankAcctNum As String
        <Size(35)> _
        Public Property IntlBankAcctNum() As String
            Get
                Return fIntlBankAcctNum
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("IntlBankAcctNum", fIntlBankAcctNum, value)
            End Set
        End Property
        Dim fSWIFTADDR As String
        <Size(11)> _
        Public Property SWIFTADDR() As String
            Get
                Return fSWIFTADDR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SWIFTADDR", fSWIFTADDR, value)
            End Set
        End Property
        Dim fCustVendCountryCode As String
        <Size(3)> _
        Public Property CustVendCountryCode() As String
            Get
                Return fCustVendCountryCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CustVendCountryCode", fCustVendCountryCode, value)
            End Set
        End Property
        Dim fDeliveryCountryCode As String
        <Size(3)> _
        Public Property DeliveryCountryCode() As String
            Get
                Return fDeliveryCountryCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DeliveryCountryCode", fDeliveryCountryCode, value)
            End Set
        End Property
        Dim fBNKCTRCD As String
        <Size(3)> _
        Public Property BNKCTRCD() As String
            Get
                Return fBNKCTRCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BNKCTRCD", fBNKCTRCD, value)
            End Set
        End Property
        Dim fCBANKCD As String
        <Size(9)> _
        Public Property CBANKCD() As String
            Get
                Return fCBANKCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CBANKCD", fCBANKCD, value)
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
        Dim fADDRESS4 As String
        <Size(61)> _
        Public Property ADDRESS4() As String
            Get
                Return fADDRESS4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS4", fADDRESS4, value)
            End Set
        End Property
        Dim fRegCode1 As String
        <Size(31)> _
        Public Property RegCode1() As String
            Get
                Return fRegCode1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RegCode1", fRegCode1, value)
            End Set
        End Property
        Dim fRegCode2 As String
        <Size(31)> _
        Public Property RegCode2() As String
            Get
                Return fRegCode2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RegCode2", fRegCode2, value)
            End Set
        End Property
        Dim fBankInfo7 As Short
        Public Property BankInfo7() As Short
            Get
                Return fBankInfo7
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BankInfo7", fBankInfo7, value)
            End Set
        End Property
        Dim fEFTTransitRoutingNo As String
        <Size(11)> _
        Public Property EFTTransitRoutingNo() As String
            Get
                Return fEFTTransitRoutingNo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EFTTransitRoutingNo", fEFTTransitRoutingNo, value)
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
        Dim fEFTTransferMethod As Short
        Public Property EFTTransferMethod() As Short
            Get
                Return fEFTTransferMethod
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("EFTTransferMethod", fEFTTransferMethod, value)
            End Set
        End Property
        Dim fEFTAccountType As Short
        Public Property EFTAccountType() As Short
            Get
                Return fEFTAccountType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("EFTAccountType", fEFTAccountType, value)
            End Set
        End Property
        Dim fEFTPrenoteDate As DateTime
        Public Property EFTPrenoteDate() As DateTime
            Get
                Return fEFTPrenoteDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EFTPrenoteDate", fEFTPrenoteDate, value)
            End Set
        End Property
        Dim fEFTTerminationDate As DateTime
        Public Property EFTTerminationDate() As DateTime
            Get
                Return fEFTTerminationDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EFTTerminationDate", fEFTTerminationDate, value)
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
