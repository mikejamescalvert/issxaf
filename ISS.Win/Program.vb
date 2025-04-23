Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win

Imports ISS.Win

Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Activation
Imports DevExpress.ExpressApp.Win.Templates
Imports Microsoft.VisualBasic.ApplicationServices
Imports ISS.HyperLinkHandler
Imports DevExpress.XtraEditors
Imports ISS.Base

Public Class Program

    Private Shared WithEvents _Application As ISSWindowsFormsApplication
    Public Sub NewArgumentsReceived(args As String())
        ' e.g. add them to a list box
        If args.Length > 0 Then
            MessageBox.Show("new args received!")
        End If
    End Sub
    Private Shared Sub WinApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal args As DatabaseVersionMismatchEventArgs)
        args.Updater.Update()
        args.Handled = True
    End Sub
    Private Shared Sub CustomizeTemplte_Test(ByVal sender As Object, ByVal e As CustomizeTemplateEventArgs)
        If e.Context = TemplateContext.ApplicationWindow Then
            'Dim tmp As MainFormTemplateBase = e.Template
            'If tmp IsNot Nothing AndAlso tmp.DocumentManager IsNot Nothing AndAlso tmp.DocumentManager.View IsNot Nothing Then

            'End If
        End If

    End Sub


    '<STAThread()>
    'Public Shared Sub MainWithMuteEx(ByVal arguments() As String)
    '    'Example: issxaf://customer?123-123-123(guid)
    '    Dim strAssembly = GetType(Program).Assembly.GetName()
    '    Dim strMuteExName As String = strAssembly.Name + "_" + strAssembly.Version.ToString(3)
    '    Using mtxInstance As New ISS.HyperLinkHandler.MutexHandler(strMuteExName)
    '        If mtxInstance.IsFirstInstance = True Then

    '            AddHandler mtxInstance.ArgumentsReceived, AddressOf MuteEx_ArgumentsReceived
    '            mtxInstance.ListenForArgumentsFromSuccessiveInstances()
    '            Main(arguments)
    '        Else
    '            mtxInstance.PassArgumentsToFirstInstance()
    '        End If
    '    End Using

    'End Sub

    'Private Shared Sub MuteEx_ArgumentsReceived(sender As Object, e As ArgumentsReceivedEventArgs)
    '    Dim mtxInstance As MutexHandler = sender
    '    mtxInstance.HandleApplicationArguments(String.Join(";", e.args), _Application)
    'End Sub

    Public Shared Sub Main(ByVal arguments() As String)

                    DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_1
AddHandler Tracing.CreateCustomTracer, Sub(s As Object, args As CreateCustomTracerEventArgs)
                                                   args.Tracer = New ISS.Base.TraceDescendant()
                                               End Sub

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
        _Application = New ISSWindowsFormsApplication()
        If (Not ConfigurationManager.ConnectionStrings.Item("ConnectionString") Is Nothing) Then
            _Application.ConnectionString = ConfigurationManager.ConnectionStrings.Item("ConnectionString").ConnectionString
        End If
        _Application.DatabaseUpdateMode = DatabaseUpdateMode.Never
        _Application.UseLightStyle = True
        _Application.UseOldTemplates = False
        DevExpress.ExpressApp.Utils.ImageLoader.Instance.UseSvgImages = True

        _Application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        AddHandler _Application.CustomizeTemplate, AddressOf CustomizeTemplte_Test

        If arguments.Length > 0 Then
            For Each argument In arguments
                If argument.Length > 0 Then
                    Dim test = argument
                End If
            Next
        End If

        Try
            _Application.Setup()
            '_Application.ShowViewStrategy = New ISS.Base.Win.ISSMDIStrategy(_Application)
            'AddHandler _Application.CreateCustomTemplate, AddressOf _Application_CreateCustomTemplate
            _Application.Start()
        Catch e As Exception
            _Application.HandleException(e)
        End Try

    End Sub

    ' This is invoked when subsequent instances try to start.
    '    grab and process their command line 
    Private Sub StartupNextInstance(sender As Object,
                        e As StartupNextInstanceEventArgs)

        ' ToDo: Process the command line provided in e.CommandLine.


    End Sub

    Private Shared Sub _Application_LoggingOn(sender As Object, e As LogonEventArgs) Handles _Application.LoggingOn
        If CType(e.LogonParameters, AuthenticationStandardLogonParameters).UserName = "updatedb" Then
            _Application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        Else
            _Application.DatabaseUpdateMode = DatabaseUpdateMode.Never
        End If
    End Sub

    'Private Shared Sub _Application_CreateCustomTemplate(ByVal sender As Object, ByVal e As CreateCustomTemplateEventArgs) Handles _Application.CreateCustomTemplate
    '    If e.Context = TemplateContext.ApplicationWindow Then
    '        e.Template = New ISS.Base.Win.MDIMainForm
    '    ElseIf e.Context = TemplateContext.View Then
    '        e.Template = New ISS.Base.Win.MDIChildForm
    '    End If
    'End Sub

End Class

