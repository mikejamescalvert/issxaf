Imports Newtonsoft.Json

Namespace Models.Json



    Public Class Package
        Public Property PackagingType As PackagingType
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property Dimensions As Dimensions
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property PackageWeight As PackageWeight
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property PackageServiceOptions As PackageServiceOptions
    End Class


End Namespace