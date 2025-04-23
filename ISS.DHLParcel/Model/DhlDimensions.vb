Namespace Model

    Public Class DhlDimensions
        Public Sub New()

        End Sub

        Public Sub New(length As Decimal, width As Decimal, height As Decimal)
            Me.length = length
            Me.width = width
            Me.height = height
        End Sub

        Public Property length As Decimal
        Public Property width As Decimal
        Public Property height As Decimal
    End Class

End Namespace
