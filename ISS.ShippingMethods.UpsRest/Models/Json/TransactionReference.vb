Imports Newtonsoft.Json

Namespace Models.Json


    Public Class TransactionReference
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property CustomerContext As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property TransactionIdentifier As String
    End Class


End Namespace