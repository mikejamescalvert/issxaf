Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data.Filtering

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10000
    ''' </summary>
    <Persistent("IV10000")>
    <DefaultProperty("Oid.IVDOCNBR")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class IVInventoryAdjustmentHeader
        Inherits XPLiteObject

        'Public Structure IVInventoryAdjustmentHeaderKey
        Private fBACHNUMB As String
        <Size(15)>
        <Persistent("BACHNUMB")>
        Public Property BACHNUMB() As String
            Get
                Return fBACHNUMB
            End Get
            Set(ByVal value As String)
                SetPropertyValue("BACHNUMB", fBACHNUMB, value)
            End Set
        End Property
        Private fBCHSOURC As String
        <Size(15)>
        <Persistent("BCHSOURC")>
        Public Property BCHSOURC() As String
            Get
                Return fBCHSOURC
            End Get
            Set(ByVal value As String)
                SetPropertyValue("BCHSOURC", fBCHSOURC, value)

            End Set
        End Property
        Private fIVDOCNBR As String
        <Size(17)>
        <Persistent("IVDOCNBR")>
        Public Property IVDOCNBR() As String
            Get
                Return fIVDOCNBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue("IVDOCNBR", fIVDOCNBR, value)
            End Set
        End Property
        Private fIVDOCTYP As Short
        <Persistent("IVDOCTYP")>
        Public Property IVDOCTYP() As Short
            Get
                Return fIVDOCTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue("IVDOCTYP", fIVDOCTYP, value)
            End Set
        End Property
        'End Structure

        'Dim fOid As IVInventoryAdjustmentHeaderKey
        '<Key()> _
        '<Persistent()>
        'Public Property Oid() As IVInventoryAdjustmentHeaderKey
        '    Get
        '        Return fOid
        '    End Get
        '    Set(ByVal value As IVInventoryAdjustmentHeaderKey)
        '        SetPropertyValue(Of IVInventoryAdjustmentHeaderKey)("Oid", fOid, value)
        '    End Set
        'End Property

        Dim fRCDOCNUM As String
        <Size(21)>
        Public Property RCDOCNUM() As String
            Get
                Return fRCDOCNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RCDOCNUM", fRCDOCNUM, value)
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
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
            End Set
        End Property
        Dim fMDFUSRID As String
        <Size(15)>
        Public Property MDFUSRID() As String
            Get
                Return fMDFUSRID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MDFUSRID", fMDFUSRID, value)
            End Set
        End Property
        Dim fPOSTEDDT As DateTime
        Public Property POSTEDDT() As DateTime
            Get
                Return fPOSTEDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("POSTEDDT", fPOSTEDDT, value)
            End Set
        End Property
        Dim fPTDUSRID As String
        <Size(15)>
        Public Property PTDUSRID() As String
            Get
                Return fPTDUSRID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PTDUSRID", fPTDUSRID, value)
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
        Dim fTRXQTYTL As Decimal
        Public Property TRXQTYTL() As Decimal
            Get
                Return fTRXQTYTL
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TRXQTYTL", fTRXQTYTL, value)
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
        Dim fSRCRFRNCNMBR As String
        <Size(31)>
        Public Property SRCRFRNCNMBR() As String
            Get
                Return fSRCRFRNCNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SRCRFRNCNMBR", fSRCRFRNCNMBR, value)
            End Set
        End Property
        Dim fSOURCEINDICATOR As Short
        Public Property SOURCEINDICATOR() As Short
            Get
                Return fSOURCEINDICATOR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOURCEINDICATOR", fSOURCEINDICATOR, value)
            End Set
        End Property
        Private _mAdjustmentDetails As XPCollection(Of IVInventoryAdjustmentDetail)
        Public ReadOnly Property AdjustmentDetails As XPCollection(Of IVInventoryAdjustmentDetail)
            Get
                ReloadDetails()
                Return _mAdjustmentDetails

            End Get
        End Property

        Private _mDEX_ROW_ID As Integer
        <Key(True)>
        Public Property DEX_ROW_ID As Integer
            Get
                Return _mDEX_ROW_ID
            End Get
            Set(ByVal Value As Integer)
                SetPropertyValue("DEX_ROW_ID", _mDEX_ROW_ID, Value)
            End Set
        End Property


        Public Sub ReloadDetails()
            Dim gpoGroupOperator As GroupOperator
            If _mAdjustmentDetails Is Nothing Then
                gpoGroupOperator = New GroupOperator
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.IVDOCNBR", Me.IVDOCNBR))
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.IVDOCTYP", Me.IVDOCTYP))
                _mAdjustmentDetails = New XPCollection(Of IVInventoryAdjustmentDetail)(Session, gpoGroupOperator)
            End If
        End Sub


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
