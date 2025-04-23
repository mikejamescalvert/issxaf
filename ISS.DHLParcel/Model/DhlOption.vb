Namespace Model

    Public Class DhlOption
        Public Sub New()

        End Sub

        Public Sub New(key As String, input As String)
            Me.key = key
            Me.input = input
        End Sub

        Public Property key As String
        Public Property input As String
    End Class

End Namespace
