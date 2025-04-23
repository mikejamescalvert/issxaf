Imports ISS.AcumaticaLibrary.Models
Imports RestSharp

Namespace Services
    Public Class CustomerService
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
        Public Function GetAllCustomersWithPaging(ByVal PageNumber As Integer, Optional ByVal CustomerFilter As String = "") As CustomerResults



            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim csrResult As CustomerResults
            Dim strUrl As String


            strUrl = String.Format("{0}Customer?$top={1}&$skip={2}&$expand=Salespersons", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1))
            If CustomerFilter > String.Empty Then
                strUrl = strUrl + "&" + CustomerFilter
            End If

            rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving customers [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If
            csrResult = New CustomerResults(_mAcumaticaConfig)
            With csrResult
                .PageNumber = PageNumber
                .Customers = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSON.Customer))(rspResponse.Content)
            End With

            Return csrResult

        End Function

        Public Function GetCustomerLocationsForCustomerWithPaging(ByVal CustomerId As String, ByVal PageNumber As Integer) As CustomerLocationResults



            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim csrResult As CustomerLocationResults
            Dim strUrl As String


            strUrl = String.Format("{0}CustomerLocation?$top={1}&$expand=LocationContact/Address&$skip={2}&$filter=Customer eq '{3}'", _mAcumaticaConfig.EndpointUrl, _mAcumaticaConfig.RestPageSize, _mAcumaticaConfig.RestPageSize * (PageNumber - 1), CustomerId)

            rscClient = New RestClient()
            rsrRequest = New RestRequest(strUrl, Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving customer locations [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If
            csrResult = New CustomerLocationResults(_mAcumaticaConfig)
            With csrResult
                .PageNumber = PageNumber
                .CustomerLocations = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSON.CustomerLocation))(rspResponse.Content)
            End With

            Return csrResult
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
            rsrRequest = New RestRequest(String.Format("{0}Customer/", _mAcumaticaConfig.EndpointUrl, CustomerGuid), Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error retrieving customer [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.Customer)(rspResponse.Content)
        End Function

        ''' <summary>
        ''' Gets a customer by the customer GUID in Acumatica
        ''' </summary>
        ''' <param name="CustomerGuid">Customer GUID in Acumatica</param>
        ''' <returns></returns>
        Public Function GetCustomerByCustomerId(ByVal CustomerID As String) As JSON.Customer
            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse


            rscClient = New RestClient()
            rsrRequest = New RestRequest(String.Format("{0}Customer/{1}?$expand=PrimaryContact,BillingContact,ShippingContact,Salespersons,PrimaryContact/Address,BillingContact/Address,ShippingContact/Address,MainContact/Address,Contacts,Contacts/Contact,Contacts/Contact/Address", _mAcumaticaConfig.EndpointUrl, CustomerID), Method.GET)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                If rspResponse.Content.Contains("No entity satisfies") Then
                    Return Nothing
                End If
                Throw New Exception(String.Format("Error retrieving customer [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.Customer)(rspResponse.Content)
        End Function

        Public Function CreateUpdateCustomer(ByVal Customer As JSON.Customer) As JSON.Customer
            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse
            Dim cstTempCustomer As JSON.Customer

            If Customer.CustomerID IsNot Nothing Then
                cstTempCustomer = GetCustomerByCustomerId(Customer.CustomerID.value)
                If cstTempCustomer IsNot Nothing Then
                    If cstTempCustomer.MainContact IsNot Nothing Then
                        Customer.MainContact.ContactID = cstTempCustomer.MainContact.ContactID
                    End If
                    If cstTempCustomer.PrimaryContact IsNot Nothing Then
                        Customer.PrimaryContact.ContactID = cstTempCustomer.PrimaryContact.ContactID
                    End If
                    If cstTempCustomer.BillingContact IsNot Nothing Then
                        Customer.BillingContact.ContactID = cstTempCustomer.BillingContact.ContactID
                    End If

                    If cstTempCustomer.ShippingContact IsNot Nothing Then
                        Customer.ShippingContact.ContactID = cstTempCustomer.ShippingContact.ContactID
                    End If

                End If
            End If

            rscClient = New RestClient()

            If Customer.PrimaryContact IsNot Nothing Then
                Customer.PrimaryContact = CreateUpdateContact(Customer.PrimaryContact)
            End If
            If Customer.MainContact IsNot Nothing Then
                Customer.MainContact = CreateUpdateContact(Customer.MainContact)
            End If
            If Customer.ShippingContact IsNot Nothing Then
                Customer.ShippingContact = CreateUpdateContact(Customer.ShippingContact)
            End If
            If Customer.BillingContact IsNot Nothing Then
                Customer.BillingContact = CreateUpdateContact(Customer.BillingContact)
            End If
            rsrRequest = New RestRequest(String.Format("{0}Customer?$expand=PrimaryContact,BillingContact,ShippingContact,PrimaryContact/Address,BillingContact/Address,ShippingContact/Address,MainContact/Address,Salespersons,Contacts,Contacts/Contact,Contacts/Contact/Address", _mAcumaticaConfig.EndpointUrl), Method.PUT)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")
            rsrRequest.AddJsonBody(Customer)


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error creating customer [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.Customer)(rspResponse.Content)

        End Function

        Public Function CreateUpdateContact(ByVal Contact As JSON.Contact) As JSON.Contact
            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse


            rscClient = New RestClient()

            rsrRequest = New RestRequest(String.Format("{0}Contact?$expand=Address", _mAcumaticaConfig.EndpointUrl), Method.PUT)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")
            rsrRequest.AddJsonBody(Contact)


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error creating contact [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.Contact)(rspResponse.Content)

        End Function

        Public Function CreateUpdateCustomerLocation(ByVal CustomerLocation As JSON.CustomerLocation) As JSON.CustomerLocation
            Dim rsrRequest As RestRequest
            Dim rscClient As RestClient
            Dim rspResponse As RestResponse


            rscClient = New RestClient()

            rsrRequest = New RestRequest(String.Format("{0}CustomerLocation?$expand=LocationContact/Address", _mAcumaticaConfig.EndpointUrl), Method.PUT)
            _mAuthenticationService.AddAuthenticationToRequest(rsrRequest)
            rsrRequest.AddHeader("Content-Type", "application/json")
            rsrRequest.AddJsonBody(CustomerLocation)


            rspResponse = rscClient.Execute(rsrRequest)

            If rspResponse.IsSuccessful = False Then
                Throw New Exception(String.Format("Error creating customer location [{0}]: {1}", rspResponse.StatusCode, rspResponse.Content))
            End If

            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of JSON.CustomerLocation)(rspResponse.Content)

        End Function

    End Class

End Namespace

