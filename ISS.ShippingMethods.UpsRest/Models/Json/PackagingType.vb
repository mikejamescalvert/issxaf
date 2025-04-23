Imports Newtonsoft.Json

Namespace Models.Json



    Public Class PackagingType
        Public Property Code As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Description As String
    End Class


End Namespace