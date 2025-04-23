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
Imports DevExpress.Xpo
Imports ISS.ExtensionMethods

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class ObjectViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()

        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        GenerateNotificationActionItems()
        ' Perform various tasks depending on the target View.
    End Sub

    Public Sub GenerateNotificationActionItems()
        Dim gpoGroupOperator As New GroupOperator
        Dim xpcOnDemandRules As XPCollection(Of NotificationRule)
        Dim caiChoiceActionItem As ChoiceActionItem
        Dim obs As Xpo.XPObjectSpace = TryCast(ObjectSpace, Xpo.XPObjectSpace)
        If obs Is Nothing
            Return
        End If

        If View Is Nothing OrElse View.ObjectTypeInfo Is Nothing
            Return
        End If
        With gpoGroupOperator
            .Operands.Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.OnDemand))
            .Operands.Add(New BinaryOperator("IsActive", True))
            .Operands.Add(New BinaryOperator("TargetObjectType", View.ObjectTypeInfo.FullName))
        End With
        Notifications_SendNotification.Items.Clear()


        xpcOnDemandRules = New XPCollection(Of NotificationRule)(obs.Session, gpoGroupOperator)
        For Each xpoItem In xpcOnDemandRules
            caiChoiceActionItem = New ChoiceActionItem
            With caiChoiceActionItem
                .Caption = xpoItem.Name
                .Data = xpoItem.Oid
                .Id = xpoItem.Oid.ToString
                .ImageName = "BO_Attachment"
            End With
            Notifications_SendNotification.Items.Add(caiChoiceActionItem)
        Next
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub Dialog_Accepting(sender As Object, e As DialogControllerAcceptingEventArgs)
        'generate queue item and pass to dialog based on selected choice item

        Dim xpoOnDemandNotificationParameters As OnDemandNotificationParameters = e.AcceptActionArgs.CurrentObject
        Dim obs As Xpo.XPObjectSpace
        Dim xpoNotificationQueueItem As NotificationQueueItem
        Dim xpoMailSettings As MailSettings
        
        If xpoOnDemandNotificationParameters.Body = String.Empty Then
            Throw New UserFriendlyException("Please enter an email body for the notification item.")
        End If
        If xpoOnDemandNotificationParameters.EmailAddress = String.Empty Then
            Throw New UserFriendlyException("Please enter an email address for the notification item.")
        End If
        If xpoOnDemandNotificationParameters.Subject = String.Empty Then
            Throw New UserFriendlyException("Please enter an email subjet for the notification item.")
        End If

        obs = Application.CreateObjectSpace
        xpoMailSettings = MailSettings.GetInstance(obs.Session)

        If xpoMailSettings.DefaultFromAddress = String.Empty Then
            Throw New UserFriendlyException("Please setup your mail settings before sending notifications.")
        End If

        xpoNotificationQueueItem = New NotificationQueueItem(obs.Session)
        With xpoNotificationQueueItem
            .Body = xpoOnDemandNotificationParameters.Body
            .PrimaryToAddress = xpoOnDemandNotificationParameters.EmailAddress
            .Subject = xpoOnDemandNotificationParameters.Subject
            If xpoOnDemandNotificationParameters.OnDemandNotificationFromOption IsNot Nothing
                .FromAddress = xpoOnDemandNotificationParameters.OnDemandNotificationFromOption.FromAddress
                Else
                .FromAddress = xpoOnDemandNotificationParameters.FromAddress
            End If

            If xpoOnDemandNotificationParameters.OnDemandNotificationToOption IsNot Nothing
                .PrimaryToAddress = xpoOnDemandNotificationParameters.OnDemandNotificationToOption.ToAddress
                Else
                .PrimaryToAddress = xpoOnDemandNotificationParameters.EmailAddress
            End If
            
            .SerializedObjectKey = xpoOnDemandNotificationParameters.SerializedObjectKey
            .RelatedNotificationRule = obs.GetObject(xpoOnDemandNotificationParameters.RelatedRule)

            xpoOnDemandNotificationParameters.RelatedRule.AppendCCAndBCCToNotificationQueueItem(xpoNotificationQueueItem,View.CurrentObject)


        End With
        obs.CommitChanges()
    End Sub

    Private Sub Notifications_SendNotification_Execute(sender As Object, e As SingleChoiceActionExecuteEventArgs) Handles Notifications_SendNotification.Execute
        If e.SelectedChoiceActionItem Is Nothing OrElse View.CurrentObject is nothing Then
            Return
        End If
        'todo: generate notification from default
        Dim dlgController As New DialogController
        Dim obs As Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim objParameters As New OnDemandNotificationParameters(obs.Session)
        Dim xpoRule As NotificationRule = obs.FindObject(Of NotificationRule)(New BinaryOperator("Oid", New System.Guid(e.SelectedChoiceActionItem.Id)))
        Dim xpoQueueItem As NotificationQueueItem
        Dim xpoFromOption As OnDemandNotificationFromOption
        Dim strFromOption As String
                Dim xpoToOption As OnDemandNotificationToOption
        Dim strToOption As String
        If xpoRule Is Nothing Then
            Return
        End If

        xpoQueueItem = xpoRule.GenerateNotification(obs.GetObject(View.CurrentObject))
        With objParameters
            .Body = xpoQueueItem.Body
            .EmailAddress = xpoQueueItem.PrimaryToAddress
            .Subject = xpoQueueItem.Subject
            .FromAddress = xpoQueueItem.FromAddress
            .SerializedObjectKey = xpoQueueItem.SerializedObjectKey
            .RelatedRule = obs.GetObject(xpoQueueItem.RelatedNotificationRule)
        End With
        objParameters.OnDemandNotificationFromOptions.Clear
        For Each xpoItem In xpoRule.NotificationOnDemandFromOptions
            strFromOption = String.Empty
            If String.IsNullOrEmpty(xpoItem.FromAddress) = False
                If xpoRule.UseAngledBracketsForTokens = True
                    strFromOption = xpoItem.FromAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Braces)
                    Else
                    strFromOption = xpoItem.FromAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Brackets)
                End If
            End If

            If strFromOption = String.Empty
                Continue For
            End If

            xpoFromOption = New OnDemandNotificationFromOption(obs.Session)
            With xpoFromOption
                .Name = String.Format("{0} ({1})", xpoItem.Name, strFromOption)
                .FromAddress = strFromOption
            End With
            objParameters.OnDemandNotificationFromOptions.Add(xpoFromOption)
            If xpoItem.DefaultOption = True
                objParameters.OnDemandNotificationFromOption = xpoFromOption
            End If
        Next

                For Each xpoItem In xpoRule.NotificationOnDemandToOptions
            strToOption = String.Empty
            If String.IsNullOrEmpty(xpoItem.ToAddress) = False
                If xpoRule.UseAngledBracketsForTokens = True
                    strToOption = xpoItem.ToAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Braces)
                    Else
                    strToOption = xpoItem.ToAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Brackets)
                End If
            End If

            If strToOption = String.Empty
                Continue For
            End If

            xpoToOption = New OnDemandNotificationToOption(obs.Session)
            With xpoToOption
                .Name = String.Format("{0} ({1})", xpoItem.Name, strToOption)
                .ToAddress = strToOption
            End With
            objParameters.OnDemandNotificationToOptions.Add(xpoToOption)
            If xpoItem.DefaultOption = True
                objParameters.OnDemandNotificationToOption = xpoToOption
            End If
        Next

        xpoQueueItem.Delete()
        obs.CommitChanges()

        AddHandler dlgController.Accepting, AddressOf Dialog_Accepting
        e.ShowViewParameters.Controllers.Add(dlgController)
        e.ShowViewParameters.CreatedView = Application.CreateDetailView(obs, objParameters)
        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Separate
        e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow
        e.ShowViewParameters.Context = TemplateContext.PopupWindow
    End Sub
End Class
