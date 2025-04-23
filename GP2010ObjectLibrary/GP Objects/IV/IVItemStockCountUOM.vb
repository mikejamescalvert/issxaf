Imports System
Imports DevExpress.Xpo
Namespace Objects.IV

    ''' <summary>
    ''' GP Table IV10303
    ''' </summary>
    <Persistent("IV10303")>
    <OptimisticLocking(False)>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class IVItemStockCountUOM
        Inherits XPLiteObject

        Public Structure ItemStockCountUOMKey
            <Persistent("STCKCNTID")>
            <System.ComponentModel.Browsable(False)>
            Public STCKCNTID As String
            <Persistent("ITEMNMBR")>
            <System.ComponentModel.Browsable(False)>
            Public ITEMNMBR As String
            <Persistent("LOCNCODE")>
            <System.ComponentModel.Browsable(False)>
            Public LOCNCODE As String
            <Persistent("BINNMBR")>
            <System.ComponentModel.Browsable(False)>
            Public BINNMBR As String
            <Persistent("UOFM")>
            <System.ComponentModel.Browsable(False)>
            Public UOFM As String


            'Dim fSTCKCNTID As String
            '<Persistent("STCKCNTID")> _
            '<Size(15)> _
            'Public Property STCKCNTID() As String
            '    Get
            '        Return fSTCKCNTID
            '    End Get
            '    Set(ByVal value As String)
            '        fSTCKCNTID = value
            '    End Set
            'End Property
            'Dim fITEMNMBR As String
            '<Persistent("ITEMNMBR")> _
            '<Size(31)> _
            'Public Property ITEMNMBR() As String
            '    Get
            '        Return fITEMNMBR
            '    End Get
            '    Set(ByVal value As String)
            '        fITEMNMBR = value
            '    End Set
            'End Property
            'Dim fLOCNCODE As String
            '<Persistent("LOCNCODE")> _
            '<Size(11)> _
            'Public Property LOCNCODE() As String
            '    Get
            '        Return fLOCNCODE
            '    End Get
            '    Set(ByVal value As String)
            '        fLOCNCODE = value
            '    End Set
            'End Property
            'Dim fBINNMBR As String
            '<Persistent("BINNMBR")> _
            '<Size(21)> _
            'Public Property BINNMBR() As String
            '    Get
            '        Return fBINNMBR
            '    End Get
            '    Set(ByVal value As String)
            '        fBINNMBR = value
            '    End Set
            'End Property
            'Dim fUOFM As String
            '<Persistent("UOFM")> _
            '<Size(9)> _
            'Public Property UOFM() As String
            '    Get
            '        Return fUOFM
            '    End Get
            '    Set(ByVal value As String)
            '        fUOFM = value
            '    End Set
            'End Property
        End Structure

        Public _mOid As ItemStockCountUOMKey
        <Key()>
        <Persistent()>
        Public Property Oid() As ItemStockCountUOMKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As ItemStockCountUOMKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property
        <PersistentAlias("Oid.STCKCNTID")>
        Public Property STCKCNTID() As String
            Get
                Return CType(EvaluateAlias("STCKCNTID"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("STCKCNTID", _mOid.STCKCNTID, Value)
            End Set
        End Property
        <PersistentAlias("Oid.ITEMNMBR")>
        Public Property ITEMNMBR() As String
            Get
                Return CType(EvaluateAlias("ITEMNMBR"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("ITEMNMBR", _mOid.ITEMNMBR, Value)
            End Set
        End Property
        <PersistentAlias("Oid.LOCNCODE")>
        Public Property LOCNCODE() As String
            Get
                Return CType(EvaluateAlias("LOCNCODE"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("LOCNCODE", _mOid.LOCNCODE, Value)
            End Set
        End Property
        <PersistentAlias("Oid.BINNMBR")>
        Public Property BINNMBR() As String
            Get
                Return CType(EvaluateAlias("BINNMBR"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("BINNMBR", _mOid.BINNMBR, Value)
            End Set
        End Property
        <PersistentAlias("Oid.UOFM")>
        Public Property UOFM() As String
            Get
                Return CType(EvaluateAlias("UOFM"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("UOFM", _mOid.UOFM, Value)
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
        Dim fCOUNTEDQTY As Decimal
        Public Property COUNTEDQTY() As Decimal
            Get
                Return fCOUNTEDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("COUNTEDQTY", fCOUNTEDQTY, value)
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