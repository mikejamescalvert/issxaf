Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10103
    ''' </summary>
    <Persistent("SOP10103")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class SOPSalesPayment
        Inherits XPLiteObject

        Public Structure SOPSalesPaymentKey
            Private fSOPTYPE As Short
            <Persistent("SOPTYPE")>
            Public Property SOPTYPE() As Short
                Get
                    Return fSOPTYPE
                End Get
                Set(ByVal value As Short)
                    fSOPTYPE = value
                End Set
            End Property
            Private fSOPNUMBE As String
            <Size(21)> _
            <Persistent("SOPNUMBE")>
            Public Property SOPNUMBE() As String
                Get
                    Return fSOPNUMBE
                End Get
                Set(ByVal value As String)
                    fSOPNUMBE = value
                End Set
            End Property
            Private fSEQNUMBR As Integer
            <Persistent("SEQNUMBR")>
            Public Property SEQNUMBR() As Integer
                Get
                    Return fSEQNUMBR
                End Get
                Set(ByVal value As Integer)
                    fSEQNUMBR = value
                End Set
            End Property
        End Structure

        Dim fOid As SOPSalesPaymentKey
        <Key()>
        <Persistent()>
        Public Property Oid() As SOPSalesPaymentKey
            Get
                Return fOid
            End Get
            Set(ByVal value As SOPSalesPaymentKey)
                SetPropertyValue(Of SOPSalesPaymentKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fPYMTTYPE As Short
        Public Property PYMTTYPE() As Short
            Get
                Return fPYMTTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PYMTTYPE", fPYMTTYPE, value)
            End Set
        End Property
        Dim fDOCNUMBR As String
        <Size(21)> _
        Public Property DOCNUMBR() As String
            Get
                Return fDOCNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DOCNUMBR", fDOCNUMBR, value)
            End Set
        End Property
        Dim fRMDTYPAL As Short
        Public Property RMDTYPAL() As Short
            Get
                Return fRMDTYPAL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RMDTYPAL", fRMDTYPAL, value)
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
        Dim fCHEKNMBR As String
        <Size(21)> _
        Public Property CHEKNMBR() As String
            Get
                Return fCHEKNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHEKNMBR", fCHEKNMBR, value)
            End Set
        End Property
        Dim fCARDNAME As String
        <Size(15)> _
        Public Property CARDNAME() As String
            Get
                Return fCARDNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CARDNAME", fCARDNAME, value)
            End Set
        End Property
        Dim fRCTNCCRD As String
        <Size(21)> _
        Public Property RCTNCCRD() As String
            Get
                Return fRCTNCCRD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RCTNCCRD", fRCTNCCRD, value)
            End Set
        End Property
        Dim fAUTHCODE As String
        <Size(15)> _
        Public Property AUTHCODE() As String
            Get
                Return fAUTHCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AUTHCODE", fAUTHCODE, value)
            End Set
        End Property
        Dim fAMNTPAID As Decimal
        Public Property AMNTPAID() As Decimal
            Get
                Return fAMNTPAID
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AMNTPAID", fAMNTPAID, value)
            End Set
        End Property
        Dim fOAMTPAID As Decimal
        Public Property OAMTPAID() As Decimal
            Get
                Return fOAMTPAID
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OAMTPAID", fOAMTPAID, value)
            End Set
        End Property
        Dim fAMNTREMA As Decimal
        Public Property AMNTREMA() As Decimal
            Get
                Return fAMNTREMA
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AMNTREMA", fAMNTREMA, value)
            End Set
        End Property
        Dim fOAMNTREM As Decimal
        Public Property OAMNTREM() As Decimal
            Get
                Return fOAMNTREM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OAMNTREM", fOAMNTREM, value)
            End Set
        End Property
        Dim fDOCDATE As DateTime
        Public Property DOCDATE() As DateTime
            Get
                Return fDOCDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DOCDATE", fDOCDATE, value)
            End Set
        End Property
        Dim fEXPNDATE As DateTime
        Public Property EXPNDATE() As DateTime
            Get
                Return fEXPNDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EXPNDATE", fEXPNDATE, value)
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
        Dim fCURRNIDX As Short
        Public Property CURRNIDX() As Short
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CURRNIDX", fCURRNIDX, value)
            End Set
        End Property
        Dim fTRXSORCE As String
        <Size(13)> _
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXSORCE", fTRXSORCE, value)
            End Set
        End Property
        Dim fDEPSTATS As Short
        Public Property DEPSTATS() As Short
            Get
                Return fDEPSTATS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DEPSTATS", fDEPSTATS, value)
            End Set
        End Property
        Dim fDELETE1 As Byte
        Public Property DELETE1() As Byte
            Get
                Return fDELETE1
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DELETE1", fDELETE1, value)
            End Set
        End Property
        Dim fGLPOSTDT As DateTime
        Public Property GLPOSTDT() As DateTime
            Get
                Return fGLPOSTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("GLPOSTDT", fGLPOSTDT, value)
            End Set
        End Property
        Dim fCASHINDEX As Integer
        Public Property CASHINDEX() As Integer
            Get
                Return fCASHINDEX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CASHINDEX", fCASHINDEX, value)
            End Set
        End Property
        Dim fDEPINDEX As Integer
        Public Property DEPINDEX() As Integer
            Get
                Return fDEPINDEX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEPINDEX", fDEPINDEX, value)
            End Set
        End Property
        Dim fEFTFLAG As Byte
        Public Property EFTFLAG() As Byte
            Get
                Return fEFTFLAG
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("EFTFLAG", fEFTFLAG, value)
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
