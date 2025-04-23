Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Models.Json







    Public Class AddressValidationResponse
        Public Property ResponseStatus As CodeDescription

        Public Property AddressClassification As CodeDescription
        <JsonIgnore>
        Public Property Alert As List(Of CodeDescription)
        <JsonProperty(PropertyName:="Alert")>
        Public Property AlertRaw As JRaw
            Get
                Return New JRaw(JsonConvert.SerializeObject(Alert))
            End Get
            Set(value As JRaw)
                Dim raw = value.ToString(Formatting.None)
                If raw > String.Empty AndAlso raw.StartsWith("[") Then
                    Alert = JsonConvert.DeserializeObject(Of List(Of CodeDescription))(raw)
                Else
                    Alert = New List(Of CodeDescription)({JsonConvert.DeserializeObject(Of CodeDescription)(raw)})
                End If

            End Set
        End Property

        Public Property TransactionReference As TransactionReference
    End Class

End Namespace
