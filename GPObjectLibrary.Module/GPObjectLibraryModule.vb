Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports System.Reflection
Imports DevExpress.Persistent.BaseImpl
Imports System.Configuration

Partial Public NotInheritable Class [GPObjectLibraryModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    'Public Overrides Sub Setup(ByVal application As DevExpress.ExpressApp.XafApplication)
    '    MyBase.Setup(application)
    '    AddHandler application.CreateCustomObjectSpaceProvider, AddressOf OnCreateCustomObjectSpaceProvider
    '    AddHandler application.CustomCheckCompatibility, AddressOf OnCustomCheckCompatibility
    '    DevExpress.Xpo.Session.GlobalSuppressExceptionOnReferredObjectAbsentInDataStore = True
    'End Sub

    'Private Shared provider As MyXpoDataStoreProvider
    'Protected Sub OnCreateCustomObjectSpaceProvider(ByVal sender As Object, ByVal e As CreateCustomObjectSpaceProviderEventArgs)
    '    provider = New MyXpoDataStoreProvider
    '    e.ObjectSpaceProvider = New ObjectSpaceProvider(provider)
    'End Sub
    'Protected Sub OnCustomCheckCompatibility(ByVal sender As Object, ByVal e As CustomCheckCompatibilityEventArgs)
    '    Dim oapplication As XafApplication = sender
    '    If ConfigurationManager.ConnectionStrings("ConnectionString") Is Nothing Then
    '        Throw New Exception("Missing connection string value: ConnectionString")
    '    End If
    '    If ConfigurationManager.ConnectionStrings("GPConnectionString") Is Nothing Then
    '        Throw New Exception("Missing connection string value: GPConnectionString")
    '    End If
    '    If (Not provider.IsInitialized) Then
    '        provider.Initialize((oapplication.ObjectSpaceProvider).XPDictionary, ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, ConfigurationManager.ConnectionStrings("GPConnectionString").ConnectionString)
    '    End If
    'End Sub

End Class
