Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.Strategy
Imports DevExpress.ExpressApp.Security.ClientServer
Imports DevExpress.ExpressApp
Imports System.Collections
Imports DevExpress.Persistent.BaseImpl.PermissionPolicy
Imports System.ServiceModel
Imports DevExpress.ExpressApp.Security.ClientServer.Wcf
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.MiddleTier

Namespace ISS.MiddleTier.ServiceHost
    Friend Class Program
        Shared Sub New()
            DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = True
            DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = False
        End Sub
        Private Shared Sub serverApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DatabaseVersionMismatchEventArgs)
            e.Updater.Update()
            e.Handled = True
        End Sub
        Shared Sub Main(ByVal args() As String)
                        DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_1
Try
                Dim connectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

                ValueManager.ValueManagerType = GetType(MultiThreadValueManager(Of )).GetGenericTypeDefinition()
                SecurityAdapterHelper.Enable()
                Console.WriteLine("Starting...")

                Dim serverApplication As New ServerApplication()
                serverApplication.ApplicationName = "ISS"
                serverApplication.CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema
                '#If DEBUG Then
                '                If System.Diagnostics.Debugger.IsAttached AndAlso serverApplication.CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema Then
                '                    serverApplication.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
                '                End If
                '#End If
                serverApplication.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
                serverApplication.Modules.BeginInit()
                serverApplication.Modules.Add(New DevExpress.ExpressApp.Security.SecurityModule())
                serverApplication.Modules.Add(New Global.ISS.Module.ISSModule)
                serverApplication.Modules.EndInit()

                AddHandler serverApplication.DatabaseVersionMismatch, AddressOf serverApplication_DatabaseVersionMismatch
                AddHandler serverApplication.CreateCustomObjectSpaceProvider, Sub(sender As Object, e As CreateCustomObjectSpaceProviderEventArgs)
                                                                                  e.ObjectSpaceProviders.Add(New XPObjectSpaceProvider(e.ConnectionString, e.Connection))
                                                                                  e.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(serverApplication.TypesInfo, Nothing))
                                                                              End Sub

                serverApplication.ConnectionString = connectionString

                Console.WriteLine("Setup...")
                serverApplication.Setup()
                Console.WriteLine("CheckCompatibility...")
                serverApplication.CheckCompatibility()
                serverApplication.Dispose()

                Console.WriteLine("Starting server...")
                Dim dataServerSecurityProvider As Func(Of IDataServerSecurity) = Function()
                                                                                     Dim securityStrategyComplex As DevExpress.ExpressApp.Security.SecurityStrategyComplex = New SecurityStrategyComplex(GetType(PermissionPolicyUser), GetType(PermissionPolicyRole), New AuthenticationStandard())
                                                                                     securityStrategyComplex.SupportNavigationPermissionsForTypes = False
                                                                                     Return securityStrategyComplex
                                                                                 End Function
                Dim serviceHost As WcfXafServiceHost = New WcfXafServiceHost(connectionString, dataServerSecurityProvider)
                'Dim serviceHost As WcfXafServiceHost = New WcfXafServiceHost(connectionString, dataServerSecurityProvider)
                serviceHost.AddServiceEndpoint(GetType(IWcfXafDataServer), WcfDataServerHelper.CreateNetTcpBinding(), "net.tcp://127.0.0.1:1451/DataServer")
                serviceHost.Open()
                Console.WriteLine("Server is started. Press Enter to stop.")
                Console.ReadLine()
                Console.WriteLine("Stopping...")
                serviceHost.Close()
                Console.WriteLine("Server is stopped.")
            Catch e As Exception
                Console.WriteLine("Exception occurs: " & e.Message)
                Console.WriteLine("Press Enter to close.")
                Console.ReadLine()
            End Try
        End Sub
    End Class
End Namespace
