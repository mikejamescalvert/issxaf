Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
Partial Public Class ToolsWindowController
    Inherits WindowController
    Public Sub New()
        InitializeComponent()
        TargetWindowType = WindowType.Main

        ' Target required Windows (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target Window.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub Notifications_ProcessQueue_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles Notifications_ProcessQueue.Execute
        Dim obs As Xpo.XPObjectSpace = Application.CreateObjectSpace
        NotificationHelper.DistributeNotifications(obs)
        obs.CommitChanges
        MsgBox("Processing Complete!")
    End Sub

    Private Sub Notifications_GenerateNotifications_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles Notifications_GenerateNotifications.Execute
         Dim obs As Xpo.XPObjectSpace = Application.CreateObjectSpace
        NotificationHelper.ProcessScheduledNotificationRules(obs)
        NotificationHelper.ProcessTimeElapseNotificationRules(obs)
        MsgBox("Processing Complete!")
    End Sub
End Class
