Namespace Model

    Public Class DhlCustomsGood
        Public Sub New()

        End Sub

        Public Sub New(code As String, description As String, origin As String, quantity As Double, value As Double, weight As Double)
            Me.code = code
            Me.description = description
            Me.origin = origin
            Me.quantity = quantity
            Me.value = value
            Me.weight = weight
        End Sub

        Public Property code As String
        Public Property description As String
        Public Property origin As String
        Public Property quantity As Double
        Public Property value As Double
        Public Property weight As Double
    End Class

End Namespace
