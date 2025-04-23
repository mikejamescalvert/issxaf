Imports ISS.AcumaticaLibrary.Models
Imports ISS.AcumaticaLibrary.Models.JSON
Imports Newtonsoft.Json.Linq
Imports RestSharp

Namespace Services
    Public Class ItemService
        Private _mAuthenticationService As AuthenticationService
        Private _mAcumaticaConfig As AcumaticaConfiguration
        Public Sub New(ByVal AcumaticaConfig As AcumaticaConfiguration)
            _mAcumaticaConfig = AcumaticaConfig
            _mAuthenticationService = New AuthenticationService(_mAcumaticaConfig)

        End Sub

        ''' <summary>
        ''' Gets all stock items with a 1 based page size (1 = first page)
        ''' </summary>
        ''' <param name="PageNumber">first page = 1</param>
        ''' <returns></returns>
        Public Function GetAllStockItemsWithPaging(ByVal PageNumber As Integer, Optional ByVal StockItemFilter As String = "") As StockItemResults



            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim sirResult As StockItemResults
            Dim strUrl As String


            strUrl = String.Format("{0}StockItem?$top={1}&$skip={2}&$expand=CrossReferences,Attributes", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1))
            If StockItemFilter > String.Empty Then
                strUrl = strUrl + "&" + StockItemFilter
            End If

            rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving stock items [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If
            sirResult = New StockItemResults(_mAcumaticaConfig)
            With sirResult
                .PageNumber = PageNumber
                .StockItems = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSON.StockItem))(rspResponse.Content)
            End With

            Return sirResult

        End Function


        ''' <summary>
        ''' Gets all stock items with a 1 based page size (1 = first page)
        ''' </summary>
        ''' <param name="PageNumber">first page = 1</param>
        ''' <returns></returns>
        Public Function GetSalesPrices(ByVal Request As SalesPriceRequest) As SalesPriceResults



            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim sirResult As SalesPriceResults
            Dim strUrl As String
            Dim jobResultObject As JObject

            strUrl = String.Format("{0}SalesPricesInquiry?$expand=SalesPriceDetails", _mAcumaticaConfig.EndpointUrl)


            rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.PUT)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")
            rsrRequest.AddJsonBody(Request)

            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving item prices [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If
            jobResultObject = JObject.Parse(rspResponse.Content)

            sirResult = New SalesPriceResults(_mAcumaticaConfig)
            With sirResult
                .SalesPriceDetails = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSON.SalesPriceDetails))(jobResultObject("SalesPriceDetails").ToString())
            End With

            Return sirResult

        End Function

        ''' <summary>
        ''' Creates or updates a price worksheet.  If updating, line ID and refernce numbers must match existing data.
        ''' </summary>
        ''' <param name="Worksheet"></param>
        ''' <returns></returns>
        Public Function CreateUpdateSalesPriceWorksheet(ByVal Worksheet As JSON.SalesPriceWorksheet) As JSON.SalesPriceWorksheet
            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse


            rscClient = New RestClient()

            rsrRequest = New RestRequest(String.Format("{0}SalesPriceWorksheet?$expand=SalesPrices", _mAcumaticaConfig.EndpointUrl), Method.PUT)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")
            rsrRequest.AddJsonBody(Worksheet)


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error creating/updating price [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.SalesPriceWorksheet)(rspResponse.Content)

        End Function


        ''' <summary>
        ''' Gets a customer by the customer GUID in Acumatica
        ''' </summary>
        ''' <param name="CustomerGuid">Customer GUID in Acumatica</param>
        ''' <returns></returns>
        Public Function GetCustomerByGuid(ByVal CustomerGuid As String) As JSON.Customer
            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse


            rscClient = New RestClient()
            rsrRequest = New RestRequest(String.Format("{0}Customer/", _mAcumaticaConfig.SourceUrl, CustomerGuid), Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving customer [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.Customer)(rspResponse.Content)
        End Function

    End Class



End Namespace

