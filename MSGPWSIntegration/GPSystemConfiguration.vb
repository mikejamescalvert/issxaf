Imports GP2010Service = MSGPWSIntegration.DynamicsWCFService
Public Class GPSystemConfiguration
    Public Sub New()
    End Sub

    Public Enum AvailableGPVersions
        GP2010
        GP10
    End Enum

    Private _mGPVersion As AvailableGPVersions
    Public Property GPVersion As AvailableGPVersions
        Get
            Return _mGPVersion
        End Get
        Set(ByVal Value As AvailableGPVersions)
            _mGPVersion = Value
        End Set
    End Property


    'Public Sub New(ByVal _GPWSUserName As String, ByVal _GPWSPassword As String, ByVal _GPWSDomain As String, ByVal _GPWSUrl As String, ByVal _GPWSCompanyId As Integer, ByVal _CurrencyCode As String, , ByVal _GPVersion As AvailableGPVersions)
    '    _mGPWSUserName = _GPWSUserName
    '    _mGPWSPassword = _GPWSPassword
    '    _mGPWSDomain = _GPWSDomain
    '    _mGPWSUrl = _GPWSUrl
    '    _mGPWSCompanyId = _GPWSCompanyId
    '    _mCurrencyCode = _CurrencyCode
    '    _mGPVersion = _GPVersion
    'End Sub

    Private _mGPWSUserName As String = String.Empty
    Public Property GPWSUserName() As String
        Get
            Return _mGPWSUserName
        End Get
        Set(ByVal value As String)
            _mGPWSUserName = value
        End Set
    End Property

    Private _mGPWSPassword As String = String.Empty
    Public Property GPWSPassword() As String
        Get
            Return _mGPWSPassword
        End Get
        Set(ByVal value As String)
            _mGPWSPassword = value
        End Set
    End Property
    Private _mGPWSDomain As String = String.Empty
    Public Property GPWSDomain() As String
        Get
            Return _mGPWSDomain
        End Get
        Set(ByVal value As String)
            _mGPWSDomain = value
        End Set
    End Property
    Private _mGPWSUrl As String = String.Empty
    Public Property GPWSUrl() As String
        Get
            Return _mGPWSUrl
        End Get
        Set(ByVal value As String)
            _mGPWSUrl = value
        End Set
    End Property
    Private _mGPWSCompanyId As Integer = -2
    Public Property GPWSCompanyId() As Integer
        Get
            Return _mGPWSCompanyId
        End Get
        Set(ByVal value As Integer)
            _mGPWSCompanyId = value
        End Set
    End Property

    Private _mGPCompanyDatabaseName As String
    ''' <summary>
    ''' Used for eConnect Direct calls
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GPCompanyDatabaseName As String
        Get
            Return _mGPCompanyDatabaseName
        End Get
        Set(ByVal Value As String)
            _mGPCompanyDatabaseName = Value
        End Set
    End Property

    Private _mGPSQLServerInstanceName As String
    Public Property GPSQLServerInstanceName As String
        Get
            Return _mGPSQLServerInstanceName
        End Get
        Set(ByVal Value As String)
            _mGPSQLServerInstanceName = Value
        End Set
    End Property

    Private _mCurrencyCode As String = String.Empty
    Public Property CurrencyCode() As String
        Get
            Return _mCurrencyCode
        End Get
        Set(ByVal value As String)
            _mCurrencyCode = value
        End Set
    End Property

    Private _mGPIntegrationLibraryUserName As String
    ''' <summary>
    ''' User Name ot be used by the ISS GP Integration Library
    ''' if left blank integrated security (SSPI) will be assumed
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GPIntegrationLibraryUserName As String
        Get
            Return _mGPIntegrationLibraryUserName
        End Get
        Set(ByVal Value As String)
            _mGPIntegrationLibraryUserName = Value
        End Set
    End Property
    Private _mGPIntegrationLibraryUserPassword As String
    ''' <summary>
    ''' User password to be used by the ISS GP Integration Library Database access
    ''' if left blank integrated security (SSPI) will be assumed
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GPIntegrationLibraryUserPassword As String
        Get
            Return _mGPIntegrationLibraryUserPassword
        End Get
        Set(ByVal Value As String)
            _mGPIntegrationLibraryUserPassword = Value
        End Set
    End Property






    Private _mGPWS2010 As MSGPWSIntegration.DynamicsWCFService.DynamicsGPClient
    ''' <summary>
    ''' If nothing then will attempt to build from the UpdateWebServiceConnectionConfiguration
    ''' if you want to force the rebuild of this connection call to UpdateWebServiceConnectionConfiguration directly
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GPWS2010 As MSGPWSIntegration.DynamicsWCFService.DynamicsGPClient
        Get
            If _mGPWS2010 Is Nothing Then
                Me.UpdateWebServiceConnectionFromConfiguration()
            End If
            Return _mGPWS2010
        End Get

    End Property
    Private _mGPWS10 As GP10Service.DynamicsGP
    ''' <summary>
    ''' If nothing then will attempt to build from the UpdateWebServiceConnectionConfiguration
    ''' if you want to force the rebuild of this connection call to UpdateWebServiceConnectionConfiguration directly
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GPWS10 As GP10Service.DynamicsGP
        Get
            If _mGPWS10 Is Nothing Then
                Me.UpdateWebServiceConnectionFromConfiguration()
            End If
            Return _mGPWS10
        End Get
    End Property

    ReadOnly Property eConnectConnectionString As String
        Get
            Return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;Pooling=false;", GPSQLServerInstanceName, GPCompanyDatabaseName)
        End Get
    End Property

    Public ReadOnly Property GPIntegrationLibraryConnectionString As String
        Get
            If Not String.IsNullOrEmpty(GPIntegrationLibraryUserName) AndAlso Not String.IsNullOrEmpty(GPIntegrationLibraryUserPassword) Then
                Return String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};Pooling=false;", GPSQLServerInstanceName, GPCompanyDatabaseName, GPIntegrationLibraryUserName, GPIntegrationLibraryUserPassword)

            Else
                Return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;;Pooling=false;", GPSQLServerInstanceName, GPCompanyDatabaseName)

            End If
        End Get
    End Property


#Region "Behaviors"
    Public Sub UpdateWebServiceConnectionFromConfiguration()
        _mGPWS10 = Nothing
        _mGPWS2010 = Nothing

        Select Case GPVersion
            Case GPSystemConfiguration.AvailableGPVersions.GP10

                _mGPWS10 = New GP10Service.DynamicsGP
                GPWS10.Url = GPWSUrl
                GPWS10.Credentials = New System.Net.NetworkCredential(GPWSUserName, GPWSPassword, GPWSDomain)

            Case GPSystemConfiguration.AvailableGPVersions.GP2010
                'HWR 06/25/12
                Dim binding As New System.ServiceModel.BasicHttpBinding
                With binding
                    .Name = "LegacyDynamicsGP"
                    .CloseTimeout = New TimeSpan(0, 1, 0)
                    .OpenTimeout = New TimeSpan(0, 1, 0)
                    .ReceiveTimeout = New TimeSpan(0, 10, 0)
                    .SendTimeout = New TimeSpan(0, 1, 0)
                    .AllowCookies = False
                    .BypassProxyOnLocal = False
                    .HostNameComparisonMode = ServiceModel.HostNameComparisonMode.StrongWildcard
                    .MessageEncoding = ServiceModel.WSMessageEncoding.Text
                    .MaxReceivedMessageSize = 2147483647
                    .TextEncoding = New System.Text.UTF8Encoding
                    .TransferMode = ServiceModel.TransferMode.Buffered
                    .UseDefaultWebProxy = True
                    With .ReaderQuotas
                        .MaxDepth = 32
                        .MaxStringContentLength = 65536000
                        .MaxArrayLength = 65536000
                        .MaxBytesPerRead = 4096
                        .MaxNameTableCharCount = 65536000
                    End With
                    With .Security
                        .Mode = ServiceModel.BasicHttpSecurityMode.TransportCredentialOnly
                        With .Transport
                            .ClientCredentialType = ServiceModel.HttpClientCredentialType.Ntlm
                            .ProxyCredentialType = ServiceModel.HttpProxyCredentialType.None
                            .Realm = ""
                        End With
                        With .Message
                            .ClientCredentialType = ServiceModel.BasicHttpMessageCredentialType.UserName
                            .AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default
                        End With
                    End With
                End With
                Dim endpoint As New System.ServiceModel.EndpointAddress(GPWSUrl)
                With endpoint

                End With


                '_mGPWS2010 = New MSGPWSIntegration.DynamicsWCFService.DynamicsGPClient("LegacyDynamicsGP", Me.GPWSUrl)
                _mGPWS2010 = New MSGPWSIntegration.DynamicsWCFService.DynamicsGPClient(binding, endpoint)
                GPWS2010.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(GPWSUserName, GPWSPassword, GPWSDomain)

        End Select

    End Sub

    Public Function GP2010GetContext() As GP2010Service.Context
        Dim context As New GP2010Service.Context
        context.OrganizationKey = CType(gp2010GetCompanyKey(), GP2010Service.OrganizationKey)
        context.CultureName = "en-US"
        Return context

    End Function

    Public Function GP2010GetCompanyKey() As GP2010Service.CompanyKey
        Dim companyKey = New GP2010Service.CompanyKey
        companyKey.Id = Me.GPWSCompanyId
        Return companyKey
    End Function

    Public Function GP10GetContext() As GP10Service.Context
        Dim context As New GP10Service.Context
        context.OrganizationKey = CType(GP10GetCompanyKey(), GP10Service.OrganizationKey)
        context.CultureName = "en-US"
        Return context

    End Function

    Public Function GP10GetCompanyKey() As GP10Service.CompanyKey
        Dim companyKey = New GP10Service.CompanyKey
        companyKey.Id = Me.GPWSCompanyId
        Return companyKey
    End Function




#End Region





End Class

