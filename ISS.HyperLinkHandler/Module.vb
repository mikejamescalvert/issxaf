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
Imports ISS.Base.Win
Imports System.Security

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
Public NotInheritable Class HyperLinkHandlerModule
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
        BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction
    End Sub

    Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
        Dim updater As ModuleUpdater = New Updater(objectSpace, versionFromDB)
        Return New ModuleUpdater() {updater}
    End Function

    Public Overrides Sub Setup(application As XafApplication)
        MyBase.Setup(application)
        AddHandler application.LoggedOn, AddressOf Application_LoggedOn

        ' Manage various aspects of the application UI and behavior at the module level.
        ' Todo, check/register registry settings

    End Sub

    Private Sub Application_LoggedOn(sender As Object, e As LogonEventArgs)
        RegisterRegistryForHandler()
    End Sub

    Public Sub RegisterRegistryForHandler()
        'todo: review adding to installation process
        'Dim mdl As IModelExtension = Application.Model
        'Dim kyeEntry As Microsoft.Win32.RegistryKey
        'Dim keyShellEntry As Microsoft.Win32.RegistryKey
        'Dim keyDefaultIconEntry As Microsoft.Win32.RegistryKey
        'Dim keyOpenEntry As Microsoft.Win32.RegistryKey
        'Dim keyCommandEntry As Microsoft.Win32.RegistryKey
        'Dim strApplicationPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        'If mdl IsNot Nothing AndAlso mdl.ISSApplicationOptions IsNot Nothing AndAlso String.IsNullOrEmpty(mdl.ISSApplicationOptions.HyperlinkHandlerPrefix) = False Then
        '    Try
        '        If Microsoft.Win32.Registry.ClassesRoot.GetSubKeyNames.Contains(mdl.ISSApplicationOptions.HyperlinkHandlerPrefix) = False Then
        '            kyeEntry = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(mdl.ISSApplicationOptions.HyperlinkHandlerPrefix)
        '            kyeEntry.SetValue(Nothing, "URL:" + mdl.ISSApplicationOptions.HyperlinkHandlerPrefix)
        '            kyeEntry.SetValue("URL Protocol", "")
        '            keyDefaultIconEntry = kyeEntry.CreateSubKey("DefaultIcon")
        '            keyDefaultIconEntry.SetValue(Nothing, AppDomain.CurrentDomain.FriendlyName + ",1")
        '            keyShellEntry = kyeEntry.CreateSubKey("shell")
        '            keyOpenEntry = keyShellEntry.CreateSubKey("open")
        '            keyCommandEntry = keyOpenEntry.CreateSubKey("command")


        '            strApplicationPath = """" + AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName + """ ""%1"""
        '            keyCommandEntry.SetValue(Nothing, strApplicationPath)
        '            keyDefaultIconEntry.Close()

        '            keyCommandEntry.Close()
        '            keyOpenEntry.Close()
        '            keyShellEntry.Close()
        '            kyeEntry.Close()



        '        End If


        '    Catch ex As SecurityException

        '        'todo: handle key not found exception
        '        'todo: handle security exception
        '        'Throw
        '    End Try

        'End If

    End Sub

    Public Overrides Sub CustomizeTypesInfo(ByVal typesInfo As ITypesInfo)
        MyBase.CustomizeTypesInfo(typesInfo)
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo)
    End Sub
End Class
