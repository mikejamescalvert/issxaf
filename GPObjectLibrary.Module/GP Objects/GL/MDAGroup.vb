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
    ''' GP Table DTA00100
    ''' </summary>
    <Persistent("DTA00100")>
    <System.ComponentModel.DefaultProperty("DSCRIPTN")>
    Public Class MDAGroup
        Inherits XPLiteObject

#Region "Properties"
        Dim fGROUPID As String
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
        Dim fDSCRIPTN As String
        <System.ComponentModel.DisplayName("Description")>
        <Size(31)>
        Public Property DSCRIPTN() As String
            Get
                Return fDSCRIPTN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DSCRIPTN", fDSCRIPTN, value)
            End Set
        End Property
        Dim fNOTEINDX As Decimal
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
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

        <PersistentAlias("[<MDACodeTransaction>][GROUPID = ^.GROUPID].Sum(CODEAMT)")>
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

        '        End With
        '        Return Session.EvaluateInTransaction(xpci, CriteriaOperator.Parse("Sum(CODEAMT)"), xpoGO)
        '    End Get
        'End Property




#End Region






#Region "Collections"

        Private _mMDACodes As XPCollection(Of MDACode)
        Protected Overridable Sub SetMDACodes(ByVal Value As XPCollection(Of MDACode))
            SetPropertyValue("MDACodes", _mMDACodes, Value)
        End Sub

        Public ReadOnly Property MDACodes As XPCollection(Of MDACode)
            Get
                If _mMDACodes Is Nothing Then
                    _mMDACodes = Me.GetMDACodes
                End If
                Return _mMDACodes
            End Get
        End Property



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


        Public Function GetMDACodes() As XPCollection(Of MDACode)
            Dim xpoGO As New GroupOperator
            With xpoGO.Operands
                .Add(New BinaryOperator("GROUPID", Me.GROUPID))
            End With
            Return New XPCollection(Of MDACode)(Session, xpoGO)
        End Function

        ''' <summary>
        ''' fetches transaction for the related group restricted to the GL account and date range if provided
        ''' </summary>
        ''' <param name="glaccount"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGroupTransactions(Optional ByVal GLAccount As String = Nothing, Optional ByVal FromDate As Date? = Nothing, Optional ByVal ThruDate As Date? = Nothing) As XPCollection(Of MDAGroupTransaction)
            Dim xpoGO As New GroupOperator
            With xpoGO.Operands
                .Add(New BinaryOperator("GROUPID", Me.GROUPID, BinaryOperatorType.Equal))
                If GLAccount IsNot Nothing Then
                    Dim xpoGLM As GLAccountIndexMaster = Session.FindObject(Of GLAccountIndexMaster)(New BinaryOperator("ACTNUMST", GLAccount, BinaryOperatorType.Equal))
                    If xpoGLM Is Nothing Then
                        Return Nothing
                    End If
                    .Add(New BinaryOperator("ACTINDX", xpoGLM.ACTINDX, BinaryOperatorType.Equal))
                End If
                If FromDate.HasValue Then
                    .Add(New BinaryOperator("TRXDATE", FromDate.Value.Date, BinaryOperatorType.GreaterOrEqual))

                End If
                If ThruDate.HasValue Then
                    .Add(New BinaryOperator("TRXDATE", ThruDate.Value.Date, BinaryOperatorType.LessOrEqual))
                End If
            End With
            Return New XPCollection(Of MDAGroupTransaction)(Session, xpoGO)

        End Function
    End Class
End Namespace