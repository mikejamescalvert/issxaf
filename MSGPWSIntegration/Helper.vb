Imports GP2010Service = MSGPWSIntegration.DynamicsWCFService

Public Class Helper
    'Friend Shared wsDynamicsGP2010 As MSGPWSIntegration.DynamicsWCFService.DynamicsGPClient

    'Friend Shared wsDynamicsGP10 As GP10Service.DynamicsGP

    Public Shared Sub SetupWSWithConfiguration(ByVal Configuration As GPSystemConfiguration)
        'THIS IS IN HERE TO SUPPORT CALLS TO THIS HELPER METHOD 
        'AND SHOULD BE REMOVED AFTER IF CALLER IS UPDATED TO USE THE CONFIGURATION OBJECT 
        'DIRECTLY
        Configuration.UpdateWebServiceConnectionFromConfiguration()


        'Select Case Configuration.GPVersion
        '    Case GPSystemConfiguration.AvailableGPVersions.GP10
        '        If wsDynamicsGP10 Is Nothing Then
        '            wsDynamicsGP10 = New GP10Service.DynamicsGP()
        '            wsDynamicsGP10.Url = Configuration.GPWSUrl
        '            wsDynamicsGP10.Credentials = New System.Net.NetworkCredential(Configuration.GPWSUserName, Configuration.GPWSPassword, Configuration.GPWSDomain)
        '        End If


        '    Case GPSystemConfiguration.AvailableGPVersions.GP2010


        ''HWR 06/25/12
        ''Build out binding context so that the app.config of the application consuming this assembly 
        'Dim binding As New System.ServiceModel.BasicHttpBinding
        'With binding
        '    .Name = "LegacyDynamicsGP"
        '    .CloseTimeout = New TimeSpan(0, 1, 0)
        '    .OpenTimeout = New TimeSpan(0, 1, 0)
        '    .ReceiveTimeout = New TimeSpan(0, 10, 0)
        '    .SendTimeout = New TimeSpan(0, 1, 0)
        '    .AllowCookies = False
        '    .BypassProxyOnLocal = False
        '    .HostNameComparisonMode = ServiceModel.HostNameComparisonMode.StrongWildcard
        '    .MaxBufferSize = 65536000
        '    .MaxBufferPoolSize = 65536000
        '    .MaxReceivedMessageSize = 65536000
        '    .MessageEncoding = ServiceModel.WSMessageEncoding.Text
        '    .TextEncoding = New System.Text.UTF8Encoding
        '    .TransferMode = ServiceModel.TransferMode.Buffered
        '    .UseDefaultWebProxy = True
        '    With .ReaderQuotas
        '        .MaxDepth = 32
        '        .MaxStringContentLength = 65536000
        '        .MaxArrayLength = 65536000
        '        .MaxBytesPerRead = 4096
        '        .MaxNameTableCharCount = 65536000
        '    End With
        '    With .Security
        '        .Mode = ServiceModel.BasicHttpSecurityMode.TransportCredentialOnly
        '        With .Transport
        '            .ClientCredentialType = ServiceModel.HttpClientCredentialType.Ntlm
        '            .ProxyCredentialType = ServiceModel.HttpProxyCredentialType.None
        '            .Realm = ""
        '        End With
        '        With .Message
        '            .ClientCredentialType = ServiceModel.BasicHttpMessageCredentialType.UserName
        '            .AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default
        '        End With
        '    End With
        'End With
        'Dim endpoint As New System.ServiceModel.EndpointAddress(Configuration.GPWSUrl)

        'If wsDynamicsGP2010 Is Nothing Then
        '    'wsDynamicsGP2010 = New GP2010Service.DynamicsGPClient("LegacyDynamicsGP", Configuration.GPWSUrl)
        '    wsDynamicsGP2010 = New GP2010Service.DynamicsGPClient(binding, endpoint)
        '    wsDynamicsGP2010.ClientCredentials.Windows.ClientCredential = New System.Net.NetworkCredential(Configuration.GPWSUserName, Configuration.GPWSPassword, Configuration.GPWSDomain)
        'End If
        'End Select

    End Sub

  

End Class
