Imports System
Imports DevExpress.Xpo
Namespace Objects.GL

    ''' <summary>
    ''' GP Table GL00100
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.DefaultProperty("ACTDESCR")>
    <Persistent("GL00100")> _
    <OptimisticLocking(False)> _
    Public Class GLAccountMaster
        Inherits XPLiteObject
        Dim fACTINDX As Integer
        <Key()> _
        Public Property ACTINDX() As Integer
            Get
                Return fACTINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACTINDX", fACTINDX, value)
            End Set
        End Property

        Private _mACTDESCR As String
        Public Property ACTDESCR As String
            Get
                Return _mACTDESCR
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("ACTDESCR", _mACTDESCR, Value)
            End Set
        End Property
        Dim fACCATNUM As Short
        Public Property ACCATNUM() As Short
            Get
                Return fACCATNUM
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ACCATNUM", fACCATNUM, value)
            End Set
        End Property
        Private _mUSERDEF1 As String
        Property USERDEF1 As String
            Get
                Return _mUSERDEF1
            End Get
            Set(ByVal Value As String)
                If (_mUSERDEF1 = Value) Then Return
                _mUSERDEF1 = Value
                RaisePropertyChangedEvent(NameOf(USERDEF1))
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
