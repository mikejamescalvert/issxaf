Namespace Model


    Public Class DhlCreateShipmentResponse

        Public Property shipmentId As String
        Public Property product As String
        Public Property shipmentTrackerCode As String
        Public Property pieces As List(Of DhlPiece)
        Public Property returnShipment As DhlReturnShipment
        Public Property customsDeclarationId As String
        Public Property orderReference As String
        Public Property deliveryArea As DhlDeliveryArea

    End Class


    Public Class DhlReturnShipment
        Public Property shipmentId As String
        Public Property receiver As DhlReceiver
        Public Property shipper As DhlShipper
        Public Property product As String
        Public Property shipmentTrackerCode As String
        Public Property options As List(Of DhlOption)
        Public Property returnUrl As String
        Public Property pieces As List(Of DhlPiece)
    End Class

    Public Class DhlDeliveryArea
        Public Property remote As Boolean
        Public Property type As String
    End Class

End Namespace


