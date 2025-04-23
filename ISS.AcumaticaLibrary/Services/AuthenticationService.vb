Imports ISS.AcumaticaLibrary.Models
Imports RestSharp

Namespace Services
    Public Class AuthenticationService
        Private _mAcumaticaConfig As AcumaticaConfiguration
        Private _mRestClient As RestClient
        'Private _mCookieResults As IList(Of RestResponseCookie)
        Public Sub New(ByVal AcumaticaConfig As AcumaticaConfiguration)
            _mAcumaticaConfig = AcumaticaConfig
        End Sub

        Public Sub FetchLoginCookies()
            Dim rsrRequest As RestRequest
            Dim rspResponse As RestResponse
            If Now.Subtract(_mAcumaticaConfig.LastApiLogin).TotalMinutes < 30 AndAlso _mAcumaticaConfig.LastApiBranchLogin = _mAcumaticaConfig.Branch Then
                Return
            End If

            _mRestClient = New RestClient()
            rsrRequest = New RestRequest(_mAcumaticaConfig.LoginUrl, Method.POST)
            rsrRequest.AddHeader("Content-Type", "application/json")

            rsrRequest.AddJsonBody(New Models.JSON.Login(_mAcumaticaConfig), "application/json")


            rspResponse = _mRestClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                _mRestClient = Nothing
                Throw New Exception("Error logging in [" + rspResponse.StatusCode.ToString + "]: " + rspResponse.Content)
            End If

            _mAcumaticaConfig.AuthenticationCookieResults = rspResponse.Cookies
            _mAcumaticaConfig.LastApiBranchLogin = _mAcumaticaConfig.Branch
            _mAcumaticaConfig.LastApiLogin = Now

        End Sub

        Public Sub AddAuthenticationToRequest(ByVal Request As RestRequest)
            FetchLoginCookies()

            For Each objCookie In _mAcumaticaConfig.AuthenticationCookieResults
                Request.AddCookie(objCookie.Name, objCookie.Value)
            Next

        End Sub

    End Class

End Namespace
