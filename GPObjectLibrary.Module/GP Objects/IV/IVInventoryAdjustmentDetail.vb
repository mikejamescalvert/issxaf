Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.ComponentModel
Imports DevExpress.Persistent.Base

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10001
    ''' </summary>
    <Persistent("IV10001")>
    Public Class IVInventoryAdjustmentDetail
        Inherits XPLiteObject

        <VisibleInListView(False)>
        <VisibleInDetailView(False)>
        <PersistentAlias("concat(Oid.IVDOCNBR,' ',Oid.ITEMNMBR)")>
        Public ReadOnly Property SummaryInformation As String
            Get
                Return EvaluateAlias("SummaryInformation") ' String.Format("{0} - {1}", Oid.IVDOCNBR, Oid.ITEMNMBR)
            End Get
        End Property

        Public Structure IVInventoryAdjustmentDetailKey
            Private fIVDOCNBR As String
            <Size(17)> _
            <Persistent("IVDOCNBR")>
            Public Property IVDOCNBR() As String
                Get
                    Return fIVDOCNBR
                End Get
                Set(ByVal value As String)
                    fIVDOCNBR = value
                End Set
            End Property
            Private fIVDOCTYP As Short
            <Persistent("IVDOCTYP")>
            Public Property IVDOCTYP() As Short
                Get
                    Return fIVDOCTYP
                End Get
                Set(ByVal value As Short)
                    fIVDOCTYP = value
                End Set
            End Property

            Private fITEMNMBR As String
            <Size(31)> _
            <Persistent("ITEMNMBR")>
            Public Property ITEMNMBR() As String
                Get
                    Return fITEMNMBR
                End Get
                Set(ByVal value As String)
                    fITEMNMBR = value
                End Set
            End Property
        End Structure

        Dim fOid As IVInventoryAdjustmentDetailKey
        <Key()> _
        <Persistent()>
        Public Property Oid() As IVInventoryAdjustmentDetailKey
            Get
                Return fOid
            End Get
            Set(ByVal value As IVInventoryAdjustmentDetailKey)
                SetPropertyValue(Of IVInventoryAdjustmentDetailKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fLNSEQNBR As Decimal
        Public Property LNSEQNBR() As Decimal
            Get
                Return fLNSEQNBR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LNSEQNBR", fLNSEQNBR, value)
            End Set
        End Property
        Dim fUOFM As String
        <Size(9)> _
        Public Property UOFM() As String
            Get
                Return fUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOFM", fUOFM, value)
            End Set
        End Property
        Dim fQTYBSUOM As Decimal
        Public Property QTYBSUOM() As Decimal
            Get
                Return fQTYBSUOM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYBSUOM", fQTYBSUOM, value)
            End Set
        End Property
        Dim fTRXQTY As Decimal
        Public Property TRXQTY() As Decimal
            Get
                Return fTRXQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TRXQTY", fTRXQTY, value)
            End Set
        End Property
        Dim fUNITCOST As Decimal
        Public Property UNITCOST() As Decimal
            Get
                Return fUNITCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UNITCOST", fUNITCOST, value)
            End Set
        End Property
        Dim fEXTDCOST As Decimal
        Public Property EXTDCOST() As Decimal
            Get
                Return fEXTDCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("EXTDCOST", fEXTDCOST, value)
            End Set
        End Property
        Dim fTRXLOCTN As String
        <Size(11)> _
        Public Property TRXLOCTN() As String
            Get
                Return fTRXLOCTN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXLOCTN", fTRXLOCTN, value)
            End Set
        End Property
        Dim fTRNSTLOC As String
        <Size(11)> _
        Public Property TRNSTLOC() As String
            Get
                Return fTRNSTLOC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRNSTLOC", fTRNSTLOC, value)
            End Set
        End Property
        Dim fTRFQTYTY As Short
        Public Property TRFQTYTY() As Short
            Get
                Return fTRFQTYTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TRFQTYTY", fTRFQTYTY, value)
            End Set
        End Property
        Dim fTRTQTYTY As Short
        Public Property TRTQTYTY() As Short
            Get
                Return fTRTQTYTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TRTQTYTY", fTRTQTYTY, value)
            End Set
        End Property
        Dim fIVIVINDX As Integer
        Public Property IVIVINDX() As Integer
            Get
                Return fIVIVINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVINDX", fIVIVINDX, value)
            End Set
        End Property

        <PersistentAlias("[<IVItem>][ITEMNMBR = ^.Oid.ITEMNMBR].Single(ITEMDESC)")>
        Public ReadOnly Property ItemDescription As String
            Get
                Return EvaluateAlias("ItemDescription")
            End Get
        End Property
        'Private _mItemDescription As String
        'Public ReadOnly Property ItemDescriptionO As String
        '    Get
        '        If _mItemDescription = String.Empty Then
        '            Dim ivoObject As IV.IVItem = Session.FindObject(Of IV.IVItem)(New BinaryOperator("ITEMNMBR", Oid.ITEMNMBR))
        '            If ivoObject IsNot Nothing Then
        '                _mItemDescription = ivoObject.ITEMDESC
        '            End If
        '        End If
        '        Return _mItemDescription
        '    End Get
        'End Property

        Dim fIVIVOFIX As Integer
        Public Property IVIVOFIX() As Integer
            Get
                Return fIVIVOFIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVOFIX", fIVIVOFIX, value)
            End Set
        End Property
        Dim fDECPLCUR As Short
        Public Property DECPLCUR() As Short
            Get
                Return fDECPLCUR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLCUR", fDECPLCUR, value)
            End Set
        End Property
        Dim fDECPLQTY As Short
        Public Property DECPLQTY() As Short
            Get
                Return fDECPLQTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLQTY", fDECPLQTY, value)
            End Set
        End Property
        Dim fUSAGETYPE As Short
        Public Property USAGETYPE() As Short
            Get
                Return fUSAGETYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("USAGETYPE", fUSAGETYPE, value)
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

        Private _mAdjustmentDetailSerialLots As XPCollection(Of IVInventoryAdjustmentDetailLotAssignment)
        Public ReadOnly Property AdjustmentDetailSerialLots As XPCollection(Of IVInventoryAdjustmentDetailLotAssignment)
            Get
                ReloadAdjustmentDetailSerialLots()
                Return _mAdjustmentDetailSerialLots

            End Get
        End Property

        Public Sub ReloadAdjustmentDetailSerialLots()
            Dim gpoGroupOperator As GroupOperator
            If _mAdjustmentDetailSerialLots Is Nothing Then
                gpoGroupOperator = New GroupOperator
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.IVDOCNBR", Me.Oid.IVDOCNBR))
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LNSEQNBR", Me.LNSEQNBR))
                _mAdjustmentDetailSerialLots = New XPCollection(Of IVInventoryAdjustmentDetailLotAssignment)(Session, gpoGroupOperator)
            End If

        End Sub


    End Class

End Namespace
