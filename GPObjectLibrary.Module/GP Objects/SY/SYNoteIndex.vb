Imports System
Imports DevExpress.Xpo
Namespace Objects.SY
    ''' <summary>
    ''' GP Table SY03900
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("SY03900")> _
    <OptimisticLocking(False)> _
    Public Class SYNoteIndex
        Inherits XPLiteObject
        Dim fNOTEINDX As Decimal
        <Key()> _
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fDATE1 As DateTime
        Public Property DATE1() As DateTime
            Get
                Return fDATE1
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DATE1", fDATE1, value)
            End Set
        End Property
        Dim fTIME1 As DateTime
        Public Property TIME1() As DateTime
            Get
                Return fTIME1
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("TIME1", fTIME1, value)
            End Set
        End Property

        Dim fTXTFIELD As String
        <Size(2147483647)> _
        Public Property TXTFIELD() As String
            Get
                Return fTXTFIELD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXTFIELD", fTXTFIELD, value)
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
