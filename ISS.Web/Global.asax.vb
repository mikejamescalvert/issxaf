﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Web
Imports System.Web.Routing

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Web
Imports DevExpress.Web

Public Class [Global]
    Inherits System.Web.HttpApplication
    Public Sub New()
        InitializeComponent()
    End Sub
    Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.Latest
        RouteTable.Routes.RegisterXafRoutes()
        AddHandler ASPxWebControl.CallbackError, AddressOf Application_Error
#If EASYTEST Then
        DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = True
#End If

    End Sub
    Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        Tracing.Initialize()
        WebApplication.SetInstance(Session, New ISSAspNetApplication())
        Dim security As SecurityStrategy = WebApplication.Instance.GetSecurityStrategy()
        security.RegisterXPOAdapterProviders()
        DevExpress.ExpressApp.Web.Templates.DefaultVerticalTemplateContentNew.ClearSizeLimit()
        WebApplication.Instance.SwitchToNewStyle()
        If (Not ConfigurationManager.ConnectionStrings.Item("ConnectionString") Is Nothing) Then
            WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings.Item("ConnectionString").ConnectionString
        End If
#If EASYTEST Then
        If (Not ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString") Is Nothing) Then
            WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString").ConnectionString
        End If
#End If
#If DEBUG Then
        If System.Diagnostics.Debugger.IsAttached AndAlso WebApplication.Instance.CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema Then
            WebApplication.Instance.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        End If
#End If
        WebApplication.Instance.Setup()
        WebApplication.Instance.Start()
    End Sub

    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ErrorHandling.Instance.ProcessApplicationError()
    End Sub
    Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        WebApplication.LogOff(Session)
        WebApplication.DisposeInstance(Session)
    End Sub
    Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
#Region "Web Form Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
    End Sub
#End Region
End Class
