Imports Newtonsoft.Json

Namespace Models.Json



    Public Class ShipFrom
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Name As String
        Public Property Address As Address
    End Class


End Namespace