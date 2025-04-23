Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.ClientServer

' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Web.WebApplication
Partial Public Class ISSAspNetApplication
    Inherits WebApplication
    Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
    Private module3 As ISS.Module.ISSModule
    Private module4 As ISS.Module.Web.ISSAspNetModule

    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Private securityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private conditionalAppearanceModule As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Private validationModule As DevExpress.ExpressApp.Validation.ValidationModule
    Friend WithEvents IssBaseModule1 As ISS.Base.ISSBaseModule
    Friend WithEvents MicrosoftModule1 As ISS.MultiFactor.Microsoft.Module.MicrosoftModule
    Private validationAspNetModule As DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Function CreateViewUrlManager() As IViewUrlManager
        Return New ViewUrlManager()
    End Function

    Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
        args.ObjectSpaceProvider = New SecuredObjectSpaceProvider(DirectCast(Me.Security, ISelectDataSecurityProvider), GetDataStoreProvider(args.ConnectionString, args.Connection), True)
        args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
    End Sub
    Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
        Dim application As System.Web.HttpApplicationState = If((System.Web.HttpContext.Current IsNot Nothing), System.Web.HttpContext.Current.Application, Nothing)
        Dim dataStoreProvider As IXpoDataStoreProvider = Nothing
        If Not application Is Nothing AndAlso application("DataStoreProvider") IsNot Nothing Then
            dataStoreProvider = TryCast(application("DataStoreProvider"), IXpoDataStoreProvider)
        Else
		    dataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(connectionString, connection, True)
            If Not application Is Nothing Then
                application("DataStoreProvider") = dataStoreProvider
            End If
        End If
        Return dataStoreProvider
    End Function
    Private Sub ISSAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
        '
        '#If EASYTEST Then
        e.Updater.Update()
        e.Handled = True
'#Else
'        If System.Diagnostics.Debugger.IsAttached Then
'            e.Updater.Update()
'            e.Handled = True
'        Else
'            Dim message As String = "The application cannot connect to the specified database, " & _
'				"because the database doesn't exist, its version is older " & _
'				"than that of the application or its schema does not match " & _
'				"the ORM data model structure. To avoid this error, use one " & _
'				"of the solutions from the https://www.devexpress.com/kb=T367835 KB Article."

'            If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
'                message &= Constants.vbCrLf & Constants.vbCrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
'            End If
'            Throw New InvalidOperationException(message)
'        End If
'#End If
    End Sub
    Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
        Me.module3 = New ISS.[Module].ISSModule()
        Me.module4 = New ISS.[Module].Web.ISSAspNetModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
        Me.authenticationStandard1 = New ISS.MultiFactor.Microsoft.Module.MultifactorAuthenticationStandard
        Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.conditionalAppearanceModule = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.validationModule = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.validationAspNetModule = New DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule()
        Me.IssBaseModule1 = New ISS.Base.ISSBaseModule()
        Me.MicrosoftModule1 = New ISS.MultiFactor.Microsoft.[Module].MicrosoftModule()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'securityStrategyComplex1
        '
        Me.securityStrategyComplex1.AllowAnonymousAccess = False
        Me.securityStrategyComplex1.Authentication = Me.authenticationStandard1
        Me.securityStrategyComplex1.NewUserRoleName = Nothing
        Me.securityStrategyComplex1.PermissionsReloadMode = DevExpress.ExpressApp.Security.PermissionsReloadMode.NoCache
        Me.securityStrategyComplex1.RoleType = GetType(DevExpress.ExpressApp.Security.Strategy.SecuritySystemRole)
        Me.securityStrategyComplex1.SupportNavigationPermissionsForTypes = False
        Me.securityStrategyComplex1.UseOptimizedPermissionRequestProcessor = False
        Me.securityStrategyComplex1.UserType = GetType(ISS.[Module].CustomSecurityUser)
        '
        'authenticationStandard1
        '
        Me.authenticationStandard1.LogonParametersType = GetType(ISS.MultiFactor.Microsoft.Module.MultifactorAuthenticationStandardParameters)
        Me.authenticationStandard1.UserLoginInfoType = Nothing
        '
        'validationModule
        '
        Me.validationModule.AllowValidationDetailsAccess = False
        Me.validationModule.IgnoreWarningAndInformationRules = False
        '
        'ISSAspNetApplication
        '
        Me.ApplicationName = "ISS"
        Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.objectsModule)
        Me.Modules.Add(Me.IssBaseModule1)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.validationModule)
        Me.Modules.Add(Me.validationAspNetModule)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.securityModule1)
        Me.Modules.Add(Me.conditionalAppearanceModule)
        Me.Modules.Add(Me.MicrosoftModule1)
        Me.Security = Me.securityStrategyComplex1
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
End Class

