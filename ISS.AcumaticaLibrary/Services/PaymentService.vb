Imports ISS.AcumaticaLibrary.Models
Imports RestSharp

Namespace Services
    Public Class PaymentService
        Private _mAuthenticationService As AuthenticationService
        Private _mAcumaticaConfig As AcumaticaConfiguration
        Public Sub New(ByVal AcumaticaConfig As AcumaticaConfiguration)
            _mAcumaticaConfig = AcumaticaConfig
            _mAuthenticationService = New AuthenticationService(_mAcumaticaConfig)

        End Sub

        ''' <summary>
        ''' Gets all Payments with a 1 based page size (1 = first page)
        ''' </summary>
        ''' <param name="PageNumber">first page = 1</param>
        ''' <returns></returns>
        Public Function GetAllPaymentsWithPaging(ByVal PageNumber As Integer, Optional ByVal PaymentFilter As String = "") As PaymentResults



            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim invResult As PaymentResults
            Dim strUrl As String


            strUrl = String.Format("{0}Payment?$top={1}&$skip={2}&$filter=Type eq 'Payment'&$filter=Status Eq 'Closed'", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1))
            If PaymentFilter > String.Empty Then
                strUrl = strUrl + "&" + PaymentFilter
            End If

            rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving Payments [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If
            invResult = New PaymentResults(_mAcumaticaConfig)
            With invResult
                .PageNumber = PageNumber
                .Payments = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSON.Payment))(rspResponse.Content)
            End With

            Return invResult

        End Function

    End Class
End Namespace

