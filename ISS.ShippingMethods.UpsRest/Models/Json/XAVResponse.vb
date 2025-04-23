Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Models.Json


    Public Class XAVResponse
        Public Property Response As AddressValidationResponse
        Public Property ValidAddressIndicator As String
        Public Property AmbiguousAddressIndicator As String
        Public Property NoCandidatesIndicator As String
        Public Property AddressClassification As CodeDescription
        <JsonIgnore>
        Public Property Candidate As List(Of Candidate)
        <JsonProperty(PropertyName:="Candidate")>
        Public Property CandidateRaw As JRaw
            Get
                Return New JRaw(JsonConvert.SerializeObject(Candidate))
            End Get
            Set(value As JRaw)
                Dim raw = value.ToString(Formatting.None)
                If raw > String.Empty AndAlso raw.StartsWith("[") Then
                    Candidate = JsonConvert.DeserializeObject(Of List(Of Candidate))(raw)
                Else
                    Candidate = New List(Of Candidate)({JsonConvert.DeserializeObject(Of Candidate)(raw)})
                End If

            End Set
        End Property
    End Class

End Namespace
