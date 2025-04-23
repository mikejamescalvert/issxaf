
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.GL
    ''' <summary>
    ''' GP Table DTA00200
    ''' </summary>
    '<VisibleInReports()>
    <Persistent("DTA00200")>
    Public Class MDACode
        Inherits XPLiteObject
#Region "Properties"



        Dim fGROUPID As String
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Group Id")>
        <Size(15)>
        Public Property GROUPID() As String
            Get
                Return fGROUPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GROUPID", fGROUPID, value)
            End Set
        End Property
        Dim fCODEID As String
        <System.ComponentModel.DisplayName("Code Id")>
        <Size(15)>
        Public Property CODEID() As String
            Get
                Return fCODEID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CODEID", fCODEID, value)
            End Set
        End Property
        Dim fCODEDESC As String
        <System.ComponentModel.DisplayName("Description")>
        <Size(51)>
        Public Property CODEDESC() As String
            Get
                Return fCODEDESC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CODEDESC", fCODEDESC, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        <Browsable(False)>
        <Key(True)>
        Public Property DEX_ROW_ID() As Integer
            Get
                Return fDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
            End Set
        End Property

        <PersistentAlias("[<MDACodeTransaction>][GROUPID = ^.GROUPID AND CODEID = ^.CODEID].Sum(CODEAMT)")>
        Public ReadOnly Property TotalTransactionAmount As Decimal
            Get
                Return EvaluateAlias("TotalTransactionAmount")
            End Get
        End Property
        'Public ReadOnly Property TotalTransactionAmountO As Decimal
        '    Get
        '        Dim xpci As DevExpress.Xpo.Metadata.XPClassInfo = Session.Dictionary.GetClassInfo(GetType(MDACodeTransaction))
        '        Dim xpoGO As New GroupOperator
        '        With xpoGO.Operands
        '            .Add(New BinaryOperator("GROUPID", Me.GROUPID))
        '            .Add(New BinaryOperator("CODEID", Me.CODEID))
        '        End With
        '        Return Session.EvaluateInTransaction(xpci, CriteriaOperator.Parse("Sum(CODEAMT)"), xpoGO)
        '    End Get
        'End Property


#End Region


#Region "Collections"

        Private _mTransactions As XPCollection(Of MDACodeTransaction)
        Protected Overridable Sub SetTransactions(ByVal Value As XPCollection(Of MDACodeTransaction))
            SetPropertyValue("Transactions", _mTransactions, Value)
        End Sub
        Public ReadOnly Property Transactions As XPCollection(Of MDACodeTransaction)
            Get
                If _mTransactions Is Nothing Then
                    _mTransactions = Me.GetTransactions
                End If
                Return _mTransactions
            End Get
        End Property




#End Region

#Region "Behaviors"
        Public Function GetTransactions() As XPCollection(Of MDACodeTransaction)
            Dim xpoGO As New GroupOperator
            With xpoGO.Operands
                .Add(New BinaryOperator("CODEID", Me.CODEID))
                .Add(New BinaryOperator("GROUPID", Me.GROUPID))
            End With
            Return New XPCollection(Of MDACodeTransaction)(Session, xpoGO)

        End Function


#End Region


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

