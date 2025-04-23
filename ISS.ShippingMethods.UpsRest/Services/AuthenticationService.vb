Imports System.Text
Imports ISS.ShippingMethods.UpsRest.Models
Imports ISS.ShippingMethods.UpsRest.Models.Json
Imports Newtonsoft.Json
Imports RestSharp

Public Class AuthenticationService

    Private _mUpsConfiguration As UPSConfiguration
    Private _mAccessToken As String
    Private _mExpires As DateTime
    Public Sub New(ByVal Config As UPSConfiguration)
        _mUpsConfiguration = Config
    End Sub

    Public Function GetAccessToken() As String
        If String.IsNullOrEmpty(_mAccessToken) = False AndAlso (_mExpires = Nothing OrElse _mExpires > Now) Then
            Return _mAccessToken
        End If


        Dim client = New RestClient(_mUpsConfiguration.UpsAuthUrl)
        Dim request = New RestRequest("/security/v1/oauth/token", Method.POST)
        Dim response As RestResponse
        Dim uprResult As UpsAuthResult
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded")
        request.AddHeader("Authorization", GetBasicAuthHeader(_mUpsConfiguration.ClientID, _mUpsConfiguration.ClientSecret))
        request.AddParameter("grant_type", "client_credentials")



        response = client.Execute(request)
        If response.StatusCode <> Net.HttpStatusCode.OK Then
            Throw New Exception("Error fetching UPS Authentication: " + response.StatusDescription)
        End If
        uprResult = JsonConvert.DeserializeObject(Of UpsAuthResult)(response.Content)
        _mAccessToken = uprResult.access_token
        _mExpires = Now.AddSeconds(uprResult.expires_in)
        Return _mAccessToken
    End Function

    Private Function GetBasicAuthHeader(ByVal user As String, ByVal password As String) As String
        Dim cred = $"{user}:{password}"
        Dim encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(cred))
        Return $"Basic {encoded}"
    End Function
End Class
