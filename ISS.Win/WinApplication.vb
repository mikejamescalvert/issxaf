Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Win
Imports ISS.Module
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security.Strategy
Imports DevExpress.ExpressApp.Security
Imports DevExpress.Data.Filtering

Partial Public Class ISSWindowsFormsApplication
    Inherits WinApplication
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ISSWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
        'If System.Diagnostics.Debugger.IsAttached Then
        e.Updater.Update()
        e.Handled = True
        'Else
        '    Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & Constants.vbCrLf & _
        '        "The automatical update is disabled, because the application was started without debugging." & Constants.vbCrLf & _
        '        "You should start the application under Visual Studio, or modify the source code of the " & _
        '        "'DatabaseVersionMismatch' event handler to enable automatic database update, " & _
        '        "or manually create a database with the help of the 'DBUpdater' tool.")
        'End If
    End Sub



    Protected Overrides Sub OnDetailViewCreated(view As DevExpress.ExpressApp.DetailView)
        MyBase.OnDetailViewCreated(view)

    End Sub

    Private Sub ISSWindowsFormsApplication_LoggingOn(sender As Object, e As LogonEventArgs) Handles Me.LoggingOn
        If CType(e.LogonParameters, AuthenticationStandardLogonParameters).UserName = "updatedb" Then
            Me.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        Else
            Me.DatabaseUpdateMode = DatabaseUpdateMode.Never
        End If
    End Sub
End Class
