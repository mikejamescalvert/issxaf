Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports Microsoft.VisualBasic

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class OnDemandNotificationConfirmationViewController
    Inherits ViewController
    ' Use CodeRush to create Controllers And Actions with a few keystrokes.
    ' https://docs.devexpress.com/CodeRushForRoslyn/403133/
    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
        Dim ctrl As OnDemandNotificationViewController = Frame.GetController(Of OnDemandNotificationViewController)
        If ctrl IsNot Nothing Then
            AddHandler ctrl.BatchProcessExecuting, AddressOf HandleBatchProcessExecuting

        End If

    End Sub

    Private Sub HandleBatchProcessExecuting(ByRef e As OnDemandNotificationViewController.BatchProcessingExecutingEventArgs)
        Dim strMessage As String

        If e.QualifyingObjectsCount IsNot Nothing Then
            strMessage = String.Format("Confirm batch notification process for {0}. Qualifying items to be processed: {1}", e.RuleName, e.QualifyingObjectsCount)
        Else
            strMessage = String.Format("Confirm batch notification process for {0}", e.RuleName)
        End If
        If Messaging.GetMessaging(Application).Show(strMessage, "Confirm Batch Process", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.

    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
        Dim ctrl As OnDemandNotificationViewController = Frame.GetController(Of OnDemandNotificationViewController)
        If ctrl IsNot Nothing Then
            AddHandler ctrl.BatchProcessExecuting, AddressOf HandleBatchProcessExecuting


        End If
    End Sub
End Class
