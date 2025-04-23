Imports Newtonsoft.Json

Namespace Models.Json



    Public Class RateRequest
        Public Property Request As Request
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property PickupType As PickupType
        Public Property Shipment As Shipment
    End Class


End Namespace