Imports Newtonsoft.Json.Linq
Imports RestSharp

Public Class AuthenticationService
    Private _mDhlParcelConfiguration As DhlParcelConfiguration
    Private _mAccessToken As String
    Private _mAccessTokenExpiration As DateTime
    Public Sub New(ByVal Configuration As DhlParcelConfiguration)
        _mDhlParcelConfiguration = Configuration
    End Sub

    Public Function GetAccessToken() As String
        If String.IsNullOrEmpty(_mAccessToken) = False AndAlso Now < _mAccessTokenExpiration Then
            Return _mAccessToken
        End If

        Dim client As New RestClient("https://api-gw.dhlparcel.nl")
        Dim request As New RestRequest("/authenticate/api-key", Method.POST)
        Dim body = New With {.userId = _mDhlParcelConfiguration.UserId, .key = _mDhlParcelConfiguration.ApiKey}
        Dim response As RestResponse
        Dim jobResponse As JObject
        request.AddHeader("Content-Type", "application/json")
        request.AddJsonBody(body)
        response = client.Execute(request)
        If response.StatusCode <> Net.HttpStatusCode.OK Then
            Throw New Exception(String.Format("Error fetching authentication code: [{1}] {0}", response.Content, response.StatusCode))
        End If

        jobResponse = JObject.Parse(response.Content)
        _mAccessToken = jobResponse("accessToken").ToString()
        _mAccessTokenExpiration = UnixTimeStampToDateTime(jobResponse("accessTokenExpiration").ToString())
        Return _mAccessToken
    End Function

    Private Function UnixTimeStampToDateTime(ByVal unixTimeStamp As Double) As DateTime
        Dim dateTime As DateTime = New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime()
        Return dateTime
    End Function

End Class
