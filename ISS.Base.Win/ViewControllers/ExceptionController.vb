Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports System.Net.Mail

Public Class ExceptionController
    Inherits ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
    End Sub


    Private Sub ExceptionClearLog_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles ExceptionClearLog.Execute
        ClearLog()
    End Sub

    Private Sub ExceptionSendToSupport_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles ExceptionSendToSupport.Execute
        SendToSupport()
    End Sub

    Public Overridable Sub SendToSupport()
        Tracing.Close(False)
        'Dim smpClient As New SmtpClient
        'Dim smmMailMessage As New MailMessage("applicationemail@issusa.com", IIf(System.Configuration.ConfigurationManager.AppSettings("AdminEmail") > String.Empty, System.Configuration.ConfigurationManager.AppSettings("AdminEmail"), "support@issusa.com"))
        'smmMailMessage.Subject = String.Format("Application Log [{0}]: {1}", Today.ToString("MM-dd-yyyy"), Application.ApplicationName)
        'smmMailMessage.Attachments.Add(New Attachment("expressappframework.log"))
        'smpClient.Send(smmMailMessage)
        Dim mapi As New MAPI

        mapi.AddAttachment(AppDomain.CurrentDomain.BaseDirectory + "\expressappframework.log")
        mapi.AddRecipientTo("support@issusa.com")
        mapi.SendMailPopup(String.Format("Application Log [{0}]: {1}", Today.ToString("MM-dd-yyyy"), Application.ApplicationName), "Help! I've encountered an exception in my application")

        Tracing.Initialize(PathHelper.GetApplicationFolder)
    End Sub


    Public Overridable Sub ClearLog()
        Tracing.Close(True)
        Tracing.Initialize(PathHelper.GetApplicationFolder)
    End Sub

    Private Sub ExceptionViewLog_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles ExceptionViewLog.Execute
        Tracing.Close(False)
        'Dim smpClient As New SmtpClient
        'Dim smmMailMessage As New MailMessage("applicationemail@issusa.com", IIf(System.Configuration.ConfigurationManager.AppSettings("AdminEmail") > String.Empty, System.Configuration.ConfigurationManager.AppSettings("AdminEmail"), "support@issusa.com"))
        'smmMailMessage.Subject = String.Format("Application Log [{0}]: {1}", Today.ToString("MM-dd-yyyy"), Application.ApplicationName)
        'smmMailMessage.Attachments.Add(New Attachment("expressappframework.log"))
        'smpClient.Send(smmMailMessage)

        Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\expressappframework.log")

        Tracing.Initialize(PathHelper.GetApplicationFolder)
    End Sub
End Class
