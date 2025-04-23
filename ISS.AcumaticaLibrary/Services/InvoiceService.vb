Imports ISS.AcumaticaLibrary.Models
Imports RestSharp

Namespace Services
    Public Class InvoiceService
        Private _mAuthenticationService As AuthenticationService
        Private _mAcumaticaConfig As AcumaticaConfiguration
        Public Sub New(ByVal AcumaticaConfig As AcumaticaConfiguration)
            _mAcumaticaConfig = AcumaticaConfig
            _mAuthenticationService = New AuthenticationService(_mAcumaticaConfig)

        End Sub

        ''' <summary>
        ''' Gets all invoices with a 1 based page size (1 = first page)
        ''' </summary>
        ''' <param name="PageNumber">first page = 1</param>
        ''' <returns></returns>
        Public Function GetAllInvoicesWithPaging(ByVal PageNumber As Integer, Optional ByVal InvoiceFilter As String = "") As InvoiceResults



            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim invResult As InvoiceResults
            Dim strUrl As String


            strUrl = String.Format("{0}Invoice?$top={1}&$skip={2}&$filter=Type eq 'Invoice'", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1))
            If InvoiceFilter > String.Empty Then
                strUrl = String.Format("{0}Invoice?$top={1}&$skip={2}&{3}", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1), InvoiceFilter)
                strUrl = strUrl + "&" + InvoiceFilter
            Else
                strUrl = String.Format("{0}Invoice?$top={1}&$skip={2}&$filter=Type eq 'Invoice'", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1))

            End If

            rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving invoices [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If
            invResult = New InvoiceResults(_mAcumaticaConfig)
            With invResult
                .PageNumber = PageNumber
                .Invoices = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSON.Invoice))(rspResponse.Content)
            End With

            Return invResult

        End Function

    End Class
End Namespace

