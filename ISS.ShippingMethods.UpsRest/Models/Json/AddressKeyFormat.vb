Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Models.Json

    Public Class AddressKeyFormat
        <JsonIgnore>
        Public Property AddressLine As List(Of String)
        <JsonProperty(PropertyName:="AddressLine")>
        Public Property AddressLineRaw As JRaw
            Get
                Return New JRaw(JsonConvert.SerializeObject(AddressLine))
            End Get
            Set(value As JRaw)
                Dim raw = value.ToString(Formatting.None)
                If raw > String.Empty AndAlso raw.StartsWith("[") Then
                    AddressLine = JsonConvert.DeserializeObject(Of List(Of String))(raw)
                Else
                    AddressLine = New List(Of String)({JsonConvert.DeserializeObject(Of String)(raw)})
                End If

            End Set
        End Property
        Public Property PoliticalDivision2 As String
        Public Property PoliticalDivision1 As String
        Public Property PostcodePrimaryLow As String
        Public Property PostcodeExtendedLow As String
        Public Property CountryCode As String
    End Class


End Namespace