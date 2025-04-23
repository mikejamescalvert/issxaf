Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV40202
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("IV40202")> _
    <OptimisticLocking(False)> _
    <System.ComponentModel.DefaultProperty("UOFM")> _
    Public Class IVUOMScheduleDetail

        Inherits XPLiteObject
        ''' <summary>
        ''' Key Structure
        ''' </summary>
        ''' <remarks></remarks>
        Public Structure UOMScheduleDetailKeyType
            <Persistent("UOMSCHDL")> _
            <Size(11)> _
            <System.ComponentModel.Browsable(False)> _
            Public UOMSCHDL As String
            <Persistent("SEQNUMBR")> _
            <System.ComponentModel.Browsable(False)> _
            Public SEQNUMBR As Integer
        End Structure

        Private _mOid As UOMScheduleDetailKeyType
        <Key()> _
        <Persistent()> _
        Public Property Oid() As UOMScheduleDetailKeyType
            Get
                Return _mOid
            End Get
            Set(ByVal Value As UOMScheduleDetailKeyType)
                _mOid = Value
            End Set
        End Property

        <PersistentAlias("Oid.UOMSCHDL")> _
        Public Property UOMSCHDL() As String
            Get
                Return CType(EvaluateAlias("UOMSCHDL"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("UOMSCHDL", _mOid.UOMSCHDL, Value)
            End Set
        End Property
        <PersistentAlias("Oid.SEQNUMBR")> _
        Public Property SEQNUMBR() As Integer
            Get
                Return EvaluateAlias("SEQNUMBR")
            End Get
            Set(ByVal Value As Integer)
                SetPropertyValue("SEQNUMBR", _mOid.SEQNUMBR, Value)
            End Set
        End Property

        Dim fUOFM As String
        <VisibleInListView(False)> _
        <Size(9)> _
        Public Property UOFM() As String
            Get
                Return fUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOFM", fUOFM, value)
            End Set
        End Property
        Dim fEQUIVUOM As String
        <VisibleInListView(False)> _
        <Size(9)> _
        Public Property EQUIVUOM() As String
            Get
                Return fEQUIVUOM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EQUIVUOM", fEQUIVUOM, value)
            End Set
        End Property
        Dim fEQUOMQTY As Decimal
        <VisibleInListView(False)> _
        Public Property EQUOMQTY() As Decimal
            Get
                Return fEQUOMQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("EQUOMQTY", fEQUOMQTY, value)
            End Set
        End Property
        Dim fQTYBSUOM As Decimal
        <VisibleInListView(False)> _
        Public Property QTYBSUOM() As Decimal
            Get
                Return fQTYBSUOM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYBSUOM", fQTYBSUOM, value)
            End Set
        End Property
        Dim fUOFMLONGDESC As String
        <VisibleInListView(False)> _
        <Size(255)> _
        Public Property UOFMLONGDESC() As String
            Get
                Return fUOFMLONGDESC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOFMLONGDESC", fUOFMLONGDESC, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        <VisibleInListView(False)> _
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