Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Win

Public Class ResetUserXAFMLController
    Inherits DevExpress.ExpressApp.WindowController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Private Sub btnResetXML_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles btnResetXML.Execute
        Dim strApplicationPath As String
        Dim appApplication As XafApplication
        If System.Configuration.ConfigurationManager.AppSettings("UserModelDiffsLocation") = "CurrentUserApplicationDataFolder" Then
            strApplicationPath = System.Windows.Forms.Application.LocalUserAppDataPath
        Else
            strApplicationPath = System.Windows.Forms.Application.StartupPath
        End If

        'Dim lastDiff As DevExpress.ExpressApp.DictionaryDifferenceStore = Application.Model.LastDiffS
        'Dim strApplicationName As String = Application.ApplicationName
        'Dim obProvider As DevExpress.ExpressApp.IObjectSpaceProvider = Application.ObjectSpaceProvider
        'CType(Application.ShowViewStrategy, DevExpress.ExpressApp.Win.WinShowViewStrategyBase).CloseAllWindows()
        'ISS.Base.Helpers.ApplicationHelper.XAFApplication.Setup(strApplicationName, obProvider)
        'ISS.Base.Helpers.ApplicationHelper.XAFApplication.Model.LastDiffStore = lastDiff
        'CType(ISS.Base.Helpers.ApplicationHelper.XAFApplication.ShowViewStrategy, DevExpress.ExpressApp.Win.WinShowViewStrategyBase).ShowStartupWindow()
        appApplication = Me.Application
        CType(appApplication, DevExpress.ExpressApp.Win.WinApplication).ShowViewStrategy.CloseAllWindows()
        CType(appApplication.Model.Root, ModelNode).Undo()

        'If System.IO.File.Exists(strApplicationPath + "\Model.user.xafml") = True Then
        '    System.IO.File.Delete(System.Windows.Forms.Application.ExecutablePath + "Model.user.xafml")
        'End If
        'appApplication.Setup()
        CType(appApplication, DevExpress.ExpressApp.Win.WinApplication).ShowViewStrategy.ShowStartupWindow()

    End Sub
End Class
