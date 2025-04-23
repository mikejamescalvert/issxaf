Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports System.Reflection
Imports DevExpress.Persistent.BaseImpl
Imports System.Configuration
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Xpo.DB

Partial Public NotInheritable Class [MasterProviderModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()

    End Sub

    Public Shared Property SchemaNamingEngines As New List(Of ISchemaNamingEngine)
    'Public Shared Property SecuredObjectSpaceSecurity As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Public Sub SetupMasterProvider()
        If DesignMode = False Then
            If Application.DatabaseUpdateMode = DatabaseUpdateMode.Never Then
                Helpers.DataStoreHelper.LoadProviderInformation(AutoCreateOption.None)
            Else
                Helpers.DataStoreHelper.LoadProviderInformation(AutoCreateOption.DatabaseAndSchema)
            End If

        End If
    End Sub

    Public Overrides Sub Setup(ByVal application As DevExpress.ExpressApp.XafApplication)
        MyBase.Setup(application)
        SetupMasterProvider()
        'application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        AddHandler application.CreateCustomObjectSpaceProvider, AddressOf OnCreateCustomObjectSpaceProvider
        AddHandler application.CustomCheckCompatibility, AddressOf OnCustomCheckCompatibility
        DevExpress.Xpo.Session.GlobalSuppressExceptionOnReferredObjectAbsentInDataStore = True
    End Sub


    Private Shared provider As MasterDataStoreProvider
    Protected Sub OnCreateCustomObjectSpaceProvider(ByVal sender As Object, ByVal e As CreateCustomObjectSpaceProviderEventArgs)
        provider = New MasterDataStoreProvider

        If TypeOf Application.Security Is DevExpress.ExpressApp.Security.SecurityStrategyComplex Then
            e.ObjectSpaceProvider = New MasterDataStoreSecureObjectSpaceProvider(Application.Security, provider)
        Else
            e.ObjectSpaceProvider = New MasterDataStoreObjectSpaceProvider(provider)
        End If

    End Sub
    Protected Sub OnCustomCheckCompatibility(ByVal sender As Object, ByVal e As CustomCheckCompatibilityEventArgs)
        Dim oapplication As XafApplication = sender
        If (Not provider.IsInitialized) Then
            If oapplication.ObjectSpaceProvider IsNot Nothing Then
                provider.Initialize(CType(oapplication.ObjectSpaceProvider, Xpo.XPObjectSpaceProvider).XPDictionary, oapplication.DatabaseUpdateMode)
            End If
        End If
    End Sub



End Class
