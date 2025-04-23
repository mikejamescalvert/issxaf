Imports System
Imports DevExpress.Xpo

Namespace Objects.BM
    ''' <summary>
    ''' GP Table BM010415
    ''' </summary>
    <Persistent("BM010415")>
    Public Class BMBillOfMaterialHeader
        Inherits XPLiteObject

        Public Structure BillOfMaterialHeaderKey
            Private fITEMNMBR As String
            <Size(31)>
            <Persistent("ITEMNMBR")>
            Public Property ITEMNMBR() As String
                Get
                    Return fITEMNMBR
                End Get
                Set(ByVal value As String)
                    fITEMNMBR = value
                End Set
            End Property
            Private fBOMCAT_I As Short
            <Persistent("BOMCAT_I")>
            Public Property BOMCAT_I() As Short
                Get
                    Return fBOMCAT_I
                End Get
                Set(ByVal value As Short)
                    fBOMCAT_I = value
                End Set
            End Property
            Private fBOMNAME_I As String
            <Size(15)>
            <Persistent("BOMNAME_I")>
            Public Property BOMNAME_I() As String
                Get
                    Return fBOMNAME_I
                End Get
                Set(ByVal value As String)
                    fBOMNAME_I = value
                End Set
            End Property
        End Structure

        Dim fOid As BillOfMaterialHeaderKey
        <Key()>
        <Persistent()>
        Public Property Oid() As BillOfMaterialHeaderKey
            Get
                Return fOid
            End Get
            Set(ByVal value As BillOfMaterialHeaderKey)
                SetPropertyValue(Of BillOfMaterialHeaderKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fREVISIONLEVEL_I As String
        <Size(51)>
        Public Property REVISIONLEVEL_I() As String
            Get
                Return fREVISIONLEVEL_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REVISIONLEVEL_I", fREVISIONLEVEL_I, value)
            End Set
        End Property
        Dim fEFFECTIVEDATE_I As DateTime
        Public Property EFFECTIVEDATE_I() As DateTime
            Get
                Return fEFFECTIVEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EFFECTIVEDATE_I", fEFFECTIVEDATE_I, value)
            End Set
        End Property
        Dim fBACKFLUSHITEM_I As Byte
        Public Property BACKFLUSHITEM_I() As Byte
            Get
                Return fBACKFLUSHITEM_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BACKFLUSHITEM_I", fBACKFLUSHITEM_I, value)
            End Set
        End Property
        Dim fBOMTYPE_I As Short
        Public Property BOMTYPE_I() As Short
            Get
                Return fBOMTYPE_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BOMTYPE_I", fBOMTYPE_I, value)
            End Set
        End Property
        Dim fLOCNCODE As String
        <Size(11)>
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
            End Set
        End Property
        Dim fWCID_I As String
        <Size(11)>
        Public Property WCID_I() As String
            Get
                Return fWCID_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WCID_I", fWCID_I, value)
            End Set
        End Property
        Dim fNet_Phantom_Inventory As Byte
        Public Property Net_Phantom_Inventory() As Byte
            Get
                Return fNet_Phantom_Inventory
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Net_Phantom_Inventory", fNet_Phantom_Inventory, value)
            End Set
        End Property
        Dim fCHANGEDATE_I As DateTime
        Public Property CHANGEDATE_I() As DateTime
            Get
                Return fCHANGEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CHANGEDATE_I", fCHANGEDATE_I, value)
            End Set
        End Property
        Dim fCHANGEBY_I As String
        <Size(15)>
        Public Property CHANGEBY_I() As String
            Get
                Return fCHANGEBY_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHANGEBY_I", fCHANGEBY_I, value)
            End Set
        End Property
        Dim fMFGNOTEINDEX3_I As Decimal
        Public Property MFGNOTEINDEX3_I() As Decimal
            Get
                Return fMFGNOTEINDEX3_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MFGNOTEINDEX3_I", fMFGNOTEINDEX3_I, value)
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
