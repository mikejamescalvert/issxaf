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
Imports DevExpress.Data.Filtering
Imports OtpNet
Imports DevExpress.ExpressApp.Security

' For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
Public NotInheritable Class MicrosoftModule
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
        Dim sscSecurityStrategyComplex As SecurityStrategyComplex = TryCast(application.Security, SecurityStrategyComplex)
        If sscSecurityStrategyComplex IsNot Nothing Then
            sscSecurityStrategyComplex.AllowAnonymousAccess = True
            sscSecurityStrategyComplex.AnonymousAllowedTypes.Add(DevExpress.ExpressApp.SecuritySystem.UserType)
        End If

        ApplicationName = application.ApplicationName
        AddHandler application.LoggingOn, AddressOf Application_LoggingOn

        ' Manage various aspects of the application UI and behavior at the module level.
    End Sub

    Private Sub Application_LoggingOn(sender As Object, e As LogonEventArgs)


    End Sub

    Public Overrides Sub CustomizeTypesInfo(ByVal typesInfo As ITypesInfo)
        MyBase.CustomizeTypesInfo(typesInfo)
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo)
    End Sub

    Public Shared Property ApplicationName As String

End Class
