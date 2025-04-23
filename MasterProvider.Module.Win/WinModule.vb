Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win

<ToolboxItemFilter("Xaf.Platform.Win")> _
Partial Public NotInheritable Class [MasterProviderWindowsFormsModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub SetupMasterProviderWin()
        If DesignMode = True Then
            Return
        End If
        Try
            If NeedsRegistryUpdate() = True Then
                SetupRegistry()
            End If
        Catch ex As Exception
            EventLog.WriteEntry("Atlas.MasterProvider", ex.Message)
            System.Windows.Forms.MessageBox.Show("Fatal error during application setup, Please contact your system administrator.")
        End Try

    End Sub

    Public Sub SetupRegistry()
        Dim frmRegistry As RegistryEditForm
        frmRegistry = New RegistryEditForm
        frmRegistry.ShowDialog()
    End Sub

    Public Function NeedsRegistryUpdate() As Boolean
        For Each oCustomProviderContainer As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
            If oCustomProviderContainer.RegistryNeedsUpdate = True Then
                Return True
            End If
        Next
        Return Helpers.DataStoreHelper.ApplicationContainer.RegistryNeedsUpdate
    End Function

    Public Overrides Sub Setup(ByVal application As DevExpress.ExpressApp.XafApplication)
        SetupMasterProviderWin()
        AddHandler application.LogonFailed, AddressOf Application_LogonFailed

        MyBase.Setup(application)
        'AddHandler application.CreateCustomLogonWindowControllers, AddressOf OnCreateCustomLogonControllers
    End Sub

    Protected Sub OnCreateCustomLogonControllers(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.CreateCustomLogonWindowControllersEventArgs)
        'If Application.Security.IsLogoffEnabled = True Then
        '    e.Controllers.Add(New LogonRequiredConnectionViewController)
        'Else

        'End If
    End Sub

    Private Sub Application_LogonFailed(sender As Object, e As LogonFailedEventArgs)
        'check exception, if connection issue popup connection setup
        Dim blnPopRegistry As Boolean = False

        If Not TypeOf e.Exception Is DevExpress.ExpressApp.Security.AuthenticationException Then
            If Helpers.DataStoreHelper.ApplicationContainer.IsRegistryEntry = True Then
                blnPopRegistry = True
            Else
                For Each oCustomProviderContainer As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
                    If oCustomProviderContainer.IsRegistryEntry = True Then
                        blnPopRegistry = True
                    End If
                Next
            End If
            e.Handled = True
            CType(Application, WinApplication).HandleException(e.Exception)
            If blnPopRegistry = True Then
                SetupRegistry()
            End If

        End If

    End Sub

End Class

