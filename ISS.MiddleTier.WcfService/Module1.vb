Imports System.ServiceModel.Description
Imports DevExpress.ExpressApp.MiddleTier
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.ClientServer
Imports DevExpress.ExpressApp.Security.ClientServer.Wcf
Imports DevExpress.Persistent.BaseImpl.PermissionPolicy

Module Module1

    Sub Main()
        Try
            ' ... 
            Dim serverApplication As New ServerApplication()
            serverApplication.ApplicationName = "ISS"
            serverApplication.DatabaseUpdateMode = DevExpress.ExpressApp.DatabaseUpdateMode.UpdateDatabaseAlways
            serverApplication.Modules.BeginInit()
            serverApplication.Modules.Add(New GPObjectLibrary.Module.GPObjectLibraryModule)
            serverApplication.Modules.EndInit()

            ' ... 
            Dim dataServerSecurityProvider = Function()
                                                 Dim security As New SecurityStrategyComplex(
                                                     GetType(PermissionPolicyUser), GetType(PermissionPolicyRole), New AuthenticationStandard())
                                                 security.SupportNavigationPermissionsForTypes = False
                                                 Return security
                                             End Function
            Dim serviceHost As New WcfXafServiceHost(System.Configuration.ConfigurationManager.ConnectionStrings("GPConnectionString").ConnectionString, dataServerSecurityProvider)
            serviceHost.AddServiceEndpoint(GetType(IWcfXafDataServer),
                WcfDataServerHelper.CreateNetTcpBinding(), "net.tcp://localhost:1451/DataServer")

            Dim debug As ServiceDebugBehavior = serviceHost.Description.Behaviors.Find(Of ServiceDebugBehavior)()
            If debug Is Nothing Then
                serviceHost.Description.Behaviors.Add(New ServiceDebugBehavior() With {.IncludeExceptionDetailInFaults = True})
            Else
                If Not debug.IncludeExceptionDetailInFaults Then
                    debug.IncludeExceptionDetailInFaults = True
                End If
            End If

            serviceHost.Open()
        Catch e As Exception
            Console.WriteLine("Exception occurs: " & e.Message)
            Console.WriteLine("Press Enter to close.")
            Console.ReadLine()
        End Try
    End Sub

End Module
