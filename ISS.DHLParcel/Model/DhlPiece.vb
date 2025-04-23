Namespace Model

    Public Class DhlPiece
        Public Sub New()

        End Sub

        Public Sub New(parcelType As String, quantity As Double, weight As Double, dimensions As DhlDimensions, labelId As String, trackerCode As String)
            Me.parcelType = parcelType
            Me.quantity = quantity
            Me.weight = weight
            Me.dimensions = dimensions
            Me.labelId = labelId
            Me.trackerCode = trackerCode
        End Sub

        Public Property parcelType As String
        Public Property quantity As Double
        Public Property weight As Double
        Public Property dimensions As DhlDimensions
        Public Property labelId As String
        Public Property trackerCode As String
    End Class

End Namespace
