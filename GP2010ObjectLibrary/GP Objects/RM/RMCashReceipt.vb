Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM10201
    ''' </summary>
    <Persistent("RM10201")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class RMCashReceipt
        Inherits XPLiteObject

        Public Structure RMCashReceiptKey
            Private fDOCNUMBR As String
            <Size(21)> _
            <Persistent("DOCNUMBR")>
            Public Property DOCNUMBR() As String
                Get
                    Return fDOCNUMBR
                End Get
                Set(ByVal value As String)
                    fDOCNUMBR = value
                End Set
            End Property
            Private fRMDTYPAL As Short
            <Persistent("RMDTYPAL")>
            Public Property RMDTYPAL() As Short
                Get
                    Return fRMDTYPAL
                End Get
                Set(ByVal value As Short)
                    fRMDTYPAL = value
                End Set
            End Property
        End Structure

        Dim fOid As RMCashReceiptKey
        <Key()> _
        <Persistent()>
        Public Property Oid() As RMCashReceiptKey
            Get
                Return fOid
            End Get
            Set(ByVal value As RMCashReceiptKey)
                SetPropertyValue(Of RMCashReceiptKey)("Oid", fOid, value)
            End Set
        End Property
        Dim fBACHNUMB As String
        <Size(15)> _
        Public Property BACHNUMB() As String
            Get
                Return fBACHNUMB
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BACHNUMB", fBACHNUMB, value)
            End Set
        End Property
        Dim fBCHSOURC As String
        <Size(15)> _
        Public Property BCHSOURC() As String
            Get
                Return fBCHSOURC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BCHSOURC", fBCHSOURC, value)
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

        Dim fDOCDATE As DateTime
        Public Property DOCDATE() As DateTime
            Get
                Return fDOCDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DOCDATE", fDOCDATE, value)
            End Set
        End Property
        Dim fCSHRCTYP As Short
        Public Property CSHRCTYP() As Short
            Get
                Return fCSHRCTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CSHRCTYP", fCSHRCTYP, value)
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
        Dim fDISAMCHK As Decimal
        Public Property DISAMCHK() As Decimal
            Get
                Return fDISAMCHK
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISAMCHK", fDISAMCHK, value)
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
        Dim fNDSTAMNT As Decimal
        Public Property NDSTAMNT() As Decimal
            Get
                Return fNDSTAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NDSTAMNT", fNDSTAMNT, value)
            End Set
        End Property
        Dim fTRXDSCRN As String
        <Size(31)> _
        Public Property TRXDSCRN() As String
            Get
                Return fTRXDSCRN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXDSCRN", fTRXDSCRN, value)
            End Set
        End Property
        Dim fONHOLD As Short
        Public Property ONHOLD() As Short
            Get
                Return fONHOLD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ONHOLD", fONHOLD, value)
            End Set
        End Property
        Dim fPOSTED As Byte
        Public Property POSTED() As Byte
            Get
                Return fPOSTED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("POSTED", fPOSTED, value)
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
        Dim fLSTEDTDT As DateTime
        Public Property LSTEDTDT() As DateTime
            Get
                Return fLSTEDTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTEDTDT", fLSTEDTDT, value)
            End Set
        End Property
        Dim fLSTUSRED As String
        <Size(15)> _
        Public Property LSTUSRED() As String
            Get
                Return fLSTUSRED
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LSTUSRED", fLSTUSRED, value)
            End Set
        End Property
        Dim fORTRXAMT As Decimal
        Public Property ORTRXAMT() As Decimal
            Get
                Return fORTRXAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORTRXAMT", fORTRXAMT, value)
            End Set
        End Property
        Dim fCURTRXAM As Decimal
        Public Property CURTRXAM() As Decimal
            Get
                Return fCURTRXAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CURTRXAM", fCURTRXAM, value)
            End Set
        End Property
        Dim fWROFAMNT As Decimal
        Public Property WROFAMNT() As Decimal
            Get
                Return fWROFAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WROFAMNT", fWROFAMNT, value)
            End Set
        End Property
        Dim fDISTKNAM As Decimal
        Public Property DISTKNAM() As Decimal
            Get
                Return fDISTKNAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISTKNAM", fDISTKNAM, value)
            End Set
        End Property
        Dim fDISAVTKN As Decimal
        Public Property DISAVTKN() As Decimal
            Get
                Return fDISAVTKN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISAVTKN", fDISAVTKN, value)
            End Set
        End Property
        Dim fPPSAMDED As Decimal
        Public Property PPSAMDED() As Decimal
            Get
                Return fPPSAMDED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PPSAMDED", fPPSAMDED, value)
            End Set
        End Property
        Dim fGSTDSAMT As Decimal
        Public Property GSTDSAMT() As Decimal
            Get
                Return fGSTDSAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("GSTDSAMT", fGSTDSAMT, value)
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
        Dim fPSTGSTUS As Short
        Public Property PSTGSTUS() As Short
            Get
                Return fPSTGSTUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PSTGSTUS", fPSTGSTUS, value)
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
