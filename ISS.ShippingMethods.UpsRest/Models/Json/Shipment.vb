Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Models.Json



    Public Class Shipment
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property DeliveryTimeInformation As DeliveryTimeInformation
        Public Property Shipper As Shipper
        Public Property ShipTo As ShipTo
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ShipFrom As ShipFrom
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property PaymentDetails As PaymentDetails
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ShipmentRatingOptions As ShipmentRatingOptions


        Public Property ShipmentTotalWeight As ShipmentTotalWeight
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Service As ShipmentService
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property NumOfPieces As String
        Public Property Package As New List(Of Package)
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property InvoiceLineTotal As MonetaryValue

    End Class



End Namespace