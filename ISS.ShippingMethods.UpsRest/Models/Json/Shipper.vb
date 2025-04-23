Imports Newtonsoft.Json

Namespace Models.Json



    Public Class Shipper
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Name As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ShipperNumber As String
        Public Property Address As Address
    End Class


End Namespace