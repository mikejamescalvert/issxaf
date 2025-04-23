Namespace Model

    Public Class DhlShipment
        Public Property shipmentId As String
        Public Property orderReference As String
        Public Property receiver As DhlReceiver
        Public Property shipper As DhlShipper
        Public Property accountId As String
        Public Property options As New List(Of DhlOption)
        Public Property onBehalfOf As DhlOnBehalfOf
        Public Property product As String
        Public Property customsDeclaration As DhlCustomsDeclaration
        Public Property returnLabel As Boolean
        Public Property pieces As New List(Of DhlPiece)
    End Class

End Namespace
