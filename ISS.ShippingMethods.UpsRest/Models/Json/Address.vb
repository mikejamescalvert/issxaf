Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Models.Json



    Public Class Address
        <JsonIgnore>
        Public Property AddressLine As New List(Of String)
        <JsonProperty(PropertyName:="AddressLine", NullValueHandling:=NullValueHandling.Ignore)>
        Public Property AddressLineRaw As JRaw
            Get
                If AddressLine Is Nothing Then
                    Return Nothing
                End If
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


        Public Property City As String
        Public Property StateProvinceCode As String
        Public Property PostalCode As String
        Public Property CountryCode As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property ResidentialAddressIndicator As String

    End Class


End Namespace