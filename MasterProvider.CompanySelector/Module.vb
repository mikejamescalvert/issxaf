Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Linq
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Model.DomainLogics
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security
Imports MasterProvider.Module.Helpers
Imports System.Configuration

' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
Public NotInheritable Class CompanySelectorModule
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
        Dim updater As ModuleUpdater = New Updater(objectSpace, versionFromDB)
        Return New ModuleUpdater() {updater}
    End Function

    Public Overrides Sub Setup(application As XafApplication)
        MyBase.Setup(application)
        ' Manage various aspects of the application UI and behavior at the module level.
        If application IsNot Nothing Then
            AddHandler application.LoggedOn, AddressOf Application_LoggedOn
            AddHandler application.CreateCustomLogonWindowObjectSpace, AddressOf application_CreateCustomLogonWindowObjectSpace
        End If
    End Sub
    Public Overrides Sub CustomizeTypesInfo(ByVal typesInfo As ITypesInfo)
        MyBase.CustomizeTypesInfo(typesInfo)
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo)
        If Application IsNot Nothing AndAlso CType(Application?.Security, SecurityStrategy).AnonymousAllowedTypes IsNot Nothing Then
            CType(Application.Security, SecurityStrategy).AnonymousAllowedTypes.Add(GetType(CompanyDefinition))
        End If
    End Sub

    Private Sub application_CreateCustomLogonWindowObjectSpace(sender As Object, e As CreateCustomLogonWindowObjectSpaceEventArgs)
        e.ObjectSpace = DirectCast(sender, XafApplication).CreateObjectSpace(GetType(companySelectorLogonParameters))
        Dim nonPersistentObjectSpace As NonPersistentObjectSpace = TryCast(e.ObjectSpace, NonPersistentObjectSpace)
        If nonPersistentObjectSpace IsNot Nothing Then
            If Not nonPersistentObjectSpace.IsKnownType(GetType(CompanyDefinition), True) Then
                Dim additionalObjectSpace As IObjectSpace = DirectCast(sender, XafApplication).CreateObjectSpace(GetType(CompanyDefinition))
                nonPersistentObjectSpace.AdditionalObjectSpaces.Add(additionalObjectSpace)
                AddHandler nonPersistentObjectSpace.Disposed, Sub(s2, e2)
                                                                  additionalObjectSpace.Dispose()
                                                              End Sub
            End If
        End If
        DirectCast(e.LogonParameters, companySelectorLogonParameters).RefreshPersistentObjects(e.ObjectSpace)
    End Sub

    Private Sub Application_LoggedOn(sender As Object, e As LogonEventArgs)
        Dim xafLogonParams As companySelectorLogonParameters = e.LogonParameters

        If xafLogonParams?.Company IsNot Nothing AndAlso Not String.IsNullOrEmpty(xafLogonParams.Company.ERPCompanyId) Then
            MasterProviderSetup(xafLogonParams.Company.CompanyId, xafLogonParams.Company.ERPCompanyId)
            Application.Model.Title = String.Format("{0} ({1}/{2})", Application.ApplicationName, xafLogonParams.Company.Name, xafLogonParams.Company.CompanyId)
        End If
    End Sub

    Private Sub MasterProviderSetup(CompanyID As String, ERPCompanyID As String)
        Dim erpCompanyProvider As MasterProvider.Module.CustomProviderContainer
        Dim mpCompanyProvider As MasterProvider.Module.CustomProviderContainer
        Dim sql As SqlClient.SqlConnectionStringBuilder

        'get multi company connection string names and create connections
        Dim mcSettings As CompanySelectorSettings = CompanySelectorSettings.GetInstance()
        If mcSettings IsNot Nothing Then
            For Each multiCompanyInfo As CompanySelectorInformation In mcSettings.CompanySelectorInformation
                'set erp company connection
                sql = New SqlClient.SqlConnectionStringBuilder
                erpCompanyProvider = DataStoreHelper.GetCustomProviderByConnectionStringName(multiCompanyInfo.ERPConnectionStringName)
                If erpCompanyProvider Is Nothing Then
                    ' TODO: REVIEW KSC 6/21/2021 - ERP database custom provider container "Auto Create Option"
                    erpCompanyProvider = New MasterProvider.Module.CustomProviderContainer(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
                End If
                sql.ConnectionString = ConfigurationManager.ConnectionStrings(multiCompanyInfo.ERPConnectionStringName).ConnectionString
                sql.InitialCatalog = ERPCompanyID
                With erpCompanyProvider
                    .ConnectionString = sql.ToString
                    .SetupDataStore()
                    .UpdateSchema()
                End With

                'set up company xaf application database
                sql = New SqlClient.SqlConnectionStringBuilder
                mpCompanyProvider = DataStoreHelper.GetCustomProviderByConnectionStringName(multiCompanyInfo.CompanyConnectionStringName)
                If mpCompanyProvider Is Nothing Then
                    mpCompanyProvider = New MasterProvider.Module.CustomProviderContainer(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
                End If
                sql.ConnectionString = ConfigurationManager.ConnectionStrings(multiCompanyInfo.CompanyConnectionStringName).ConnectionString
                sql.InitialCatalog = String.Format("{0}{1}", sql.InitialCatalog, CompanyID)
                With mpCompanyProvider
                    .ConnectionString = sql.ToString
                    .SetupDataStore()
                    .UpdateSchema()
                End With
            Next
        End If
    End Sub
End Class
