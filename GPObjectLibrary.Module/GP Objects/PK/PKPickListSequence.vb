Imports System
Imports DevExpress.Xpo
Namespace Objects.PK
    ''' <summary>
    ''' GP Table PK01200
    ''' </summary>
    <Persistent("PK01200")>
    Public Class PKPickListSequence
        Inherits XPLiteObject
        Dim fMANUFACTUREORDER_I As String
        <Key()>
        <Size(31)>
        Public Property MANUFACTUREORDER_I() As String
            Get
                Return fMANUFACTUREORDER_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MANUFACTUREORDER_I", fMANUFACTUREORDER_I, value)
            End Set
        End Property
        Dim fPICKLISTSEQ As Integer
        Public Property PICKLISTSEQ() As Integer
            Get
                Return fPICKLISTSEQ
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PICKLISTSEQ", fPICKLISTSEQ, value)
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
