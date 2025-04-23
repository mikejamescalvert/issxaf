Namespace Model

    Public Class DhlShippingFee
        Public Sub New()

        End Sub

        Public Sub New(currency As String, value As Double)
            Me.currency = currency
            Me.value = value
        End Sub

        Public Property currency As String
        Public Property value As Double
    End Class

End Namespace
