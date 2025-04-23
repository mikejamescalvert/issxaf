Imports System.Runtime.InteropServices
Imports ISS.AcumaticaLibrary.Models
Imports RestSharp

Namespace Services
    Public Class SalesOrderService
        Private _mAuthenticationService As AuthenticationService
        Private _mAcumaticaConfig As AcumaticaConfiguration
        Public Sub New(ByVal AcumaticaConfig As AcumaticaConfiguration)
            _mAcumaticaConfig = AcumaticaConfig
            _mAuthenticationService = New AuthenticationService(_mAcumaticaConfig)

        End Sub

        ''' <summary>
        ''' Gets all customers with a 1 based page size (1 = first page)
        ''' </summary>
        ''' <param name="PageNumber">first page = 1</param>
        ''' <returns></returns>
        Public Function GetAllSalesOrdersWithPaging(ByVal PageNumber As Integer, Optional ByVal OrderFilter As String = "", Optional ByVal ExtraCallFields As String = "") As SalesOrderResults



            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim sorResult As SalesOrderResults
            Dim strUrl As String


            strUrl = String.Format("{0}SalesOrder?$top={1}&$skip={2}&$expand=Details{3}", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1), ExtraCallFields)
            If OrderFilter > String.Empty Then
                strUrl = strUrl + "&" + OrderFilter
            End If


            rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving sales orders [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If
            sorResult = New SalesOrderResults(_mAcumaticaConfig)
            With sorResult
                .PageNumber = PageNumber
                .SalesOrders = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSON.SalesOrder))(rspResponse.Content)
            End With

            Return sorResult

        End Function

        Public Function CreateSalesOrder(ByVal Order As JSON.SalesOrder, ByVal customSuffix As String) As JSON.SalesOrder


            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse

            Dim strUrl As String


            strUrl = String.Format("{0}SalesOrder", _mAcumaticaConfig.EndpointUrl)


            strUrl = strUrl + customSuffix


                rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.PUT)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")
            rsrRequest.AddJsonBody(Order)

            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error creating sales orders [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If


            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.SalesOrder)(rspResponse.Content)
        End Function

    End Class
End Namespace

