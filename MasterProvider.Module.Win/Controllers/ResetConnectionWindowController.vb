Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win

Public Class ResetConnectionWindowController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetObjectType = GetType(ConnectionManager)
    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        Dim blnFoundRegistry As Boolean = False
        For Each oCustomProviderContainer As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
            If oCustomProviderContainer.IsRegistryEntry = True Then
                blnFoundRegistry = True
            End If
        Next
        If Helpers.DataStoreHelper.ApplicationContainer.IsRegistryEntry Then
            blnFoundRegistry = True
        End If
        MasterProvider_ResetConnections.Active.SetItemValue("HasConnections", blnFoundRegistry)
    End Sub

    Private Sub MasterProvider_ResetConnections_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles MasterProvider_ResetConnections.Execute
        Dim mpcConnection As MPConnectionInformation
        For Each oCustomProviderContainer As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
            If oCustomProviderContainer.IsRegistryEntry = True Then
                mpcConnection = New MPConnectionInformation(CType(ObjectSpace, Xpo.XPObjectSpace).Session)
                mpcConnection.Accepted = False
                mpcConnection.RegistryPath = oCustomProviderContainer.RegistryLocation
                mpcConnection.ResetConnection()
            End If
        Next
        If Helpers.DataStoreHelper.ApplicationContainer.IsRegistryEntry = True Then
            mpcConnection = New MPConnectionInformation(CType(ObjectSpace, Xpo.XPObjectSpace).Session)
            mpcConnection.Accepted = False
            mpcConnection.RegistryPath = Helpers.DataStoreHelper.ApplicationContainer.RegistryLocation
            mpcConnection.ResetConnection()

        End If
        'If Application.Security.IsLogoffEnabled = False Then
        '    For Each strReason As String In Me.Frame.GetController(Of DevExpress.ExpressApp.SystemModule.LogoffController)().LogoffAction.Active.GetKeys
        '        Me.Frame.GetController(Of DevExpress.ExpressApp.SystemModule.LogoffController)().LogoffAction.Active(strReason) = True
        '    Next
        '    Me.Frame.GetController(Of DevExpress.ExpressApp.SystemModule.LogoffController)().LogoffAction.DoExecute()
        '    Me.Application.Exit()
        'Else
        '    For Each strReason As String In Me.Frame.GetController(Of DevExpress.ExpressApp.SystemModule.LogoffController)().LogoffAction.Active.GetKeys
        '        Me.Frame.GetController(Of DevExpress.ExpressApp.SystemModule.LogoffController)().LogoffAction.Active(strReason) = True
        '    Next
        '    Me.Frame.GetController(Of DevExpress.ExpressApp.SystemModule.LogoffController)().LogoffAction.DoExecute()

        'End If
        CType(Application, WinApplication).Exit()
    End Sub

End Class
