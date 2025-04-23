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
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports Microsoft.VisualBasic
Imports ISS.ExtensionMethods
Imports DevExpress.Xpo
Imports System.ComponentModel

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class OnDemandNotificationViewController
    Inherits ViewController
    ' Use CodeRush to create Controllers And Actions with a few keystrokes.
    ' https://docs.devexpress.com/CodeRushForRoslyn/403133/
    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub

    ReadOnly Property ThisListView As ListView
        Get
            Return TryCast(View, ListView)
        End Get
    End Property

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        GenerateNotificationActionItems()
        If ThisListView IsNot Nothing Then
            GenerateNotificationActionItemsAllObjectBatchProcessing()
            GenerateNotificationActionItemsSelectedRowsBatchProcessing()
        End If
        AddHandler View.CurrentObjectChanged, AddressOf HandleCurrentObjectChanged
    End Sub

    Private Sub HandleCurrentObjectChanged(sender As Object, e As EventArgs)
        GenerateNotificationActionItems()
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
        RemoveHandler View.CurrentObjectChanged, AddressOf HandleCurrentObjectChanged
    End Sub


    Private Sub Notifications_SendNotification_Execute(sender As Object, e As SingleChoiceActionExecuteEventArgs) Handles Notifications_SendNotification.Execute
        If e.SelectedChoiceActionItem Is Nothing OrElse View.CurrentObject Is Nothing Then
            Return
        End If
        Dim obs As Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim xpoRule As NotificationRule = obs.FindObject(Of NotificationRule)(New BinaryOperator("Oid", New System.Guid(e.SelectedChoiceActionItem.Id)))
        If xpoRule Is Nothing Then
            Return
        End If

        'todo: generate notification from default
        Dim xpoAttachment As NotificationDatabaseAttachment
        Dim dlgController As New DialogController
        Dim objParameters As New OnDemandNotificationParameters(obs.Session)
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
            .CCEmailAddress = xpoRule.GetCCEmailAddress(View.CurrentObject)
            .BCCEmailAddress = xpoRule.GetBCCEmailAddress(View.CurrentObject)
            .Subject = xpoQueueItem.Subject
            .FromAddress = xpoQueueItem.FromAddress
            .SerializedObjectKEy = xpoQueueItem.SerializedObjectKey
            .RelatedRule = obs.GetObject(xpoQueueItem.RelatedNotificationRule)

            For Each objAttach In xpoQueueItem.NotificationAttachments
                xpoAttachment = obs.CreateObject(Of NotificationDatabaseAttachment)
                With xpoAttachment
                    .Content = objAttach.Content
                    .Name = objAttach.Name
                    .SetFileName(objAttach.Name)
                    .SetRecordDate(objAttach.RecordDate)
                End With
                .NotificationAttachments.Add(xpoAttachment)
            Next

            'For Each objAttach In xpoQueueItem.NotificationAttachments
            '    .NotificationAttachments.Add(obs.GetObject(objAttach))
            'Next
        End With
        objParameters.OnDemandNotificationFromOptions.Clear()

        For Each xpoItem In xpoRule.NotificationOnDemandFromOptions
            strFromOption = String.Empty
            If String.IsNullOrEmpty(xpoItem.FromAddress) = False Then
                If xpoRule.UseAngledBracketsForTokens = True Then
                    strFromOption = xpoItem.FromAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Braces)
                Else
                    strFromOption = xpoItem.FromAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Brackets)
                End If
            End If

            If strFromOption = String.Empty Then
                Continue For
            End If

            xpoFromOption = New OnDemandNotificationFromOption(obs.Session)
            With xpoFromOption
                .Name = String.Format("{0} ({1})", xpoItem.Name, strFromOption)
                .FromAddress = strFromOption
            End With
            objParameters.OnDemandNotificationFromOptions.Add(xpoFromOption)
            If xpoItem.DefaultOption = True Then
                objParameters.OnDemandNotificationFromOption = xpoFromOption
            End If
        Next

        For Each xpoItem In xpoRule.NotificationOnDemandToOptions
            strToOption = String.Empty
            If String.IsNullOrEmpty(xpoItem.ToAddress) = False Then
                If xpoRule.UseAngledBracketsForTokens = True Then
                    strToOption = xpoItem.ToAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Braces)
                Else
                    strToOption = xpoItem.ToAddress.issSubstituteTokens(obs.GetObject(View.CurrentObject), TokenEncapsulatorTypes.Brackets)
                End If
            End If

            If strToOption = String.Empty Then
                Continue For
            End If

            xpoToOption = New OnDemandNotificationToOption(obs.Session)
            With xpoToOption
                .Name = String.Format("{0} ({1})", xpoItem.Name, strToOption)
                .ToAddress = strToOption
            End With
            objParameters.OnDemandNotificationToOptions.Add(xpoToOption)
            If xpoItem.DefaultOption = True Then
                objParameters.OnDemandNotificationToOption = xpoToOption
            End If
        Next

        xpoQueueItem.Delete()
        obs.CommitChanges()

        AddHandler dlgController.Cancelling, AddressOf Dialog_Cancelling
        AddHandler dlgController.Accepting, AddressOf Dialog_Accepting
        e.ShowViewParameters.Controllers.Add(dlgController)
        e.ShowViewParameters.CreatedView = Application.CreateDetailView(obs, objParameters)
        e.ShowViewParameters.NewWindowTarget = NewWindowTarget.Separate
        e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow
        e.ShowViewParameters.Context = TemplateContext.PopupWindow
    End Sub

    Private Sub Dialog_Cancelling(sender As Object, e As EventArgs)
        Dim xpoOnDemandNotificationParams As OnDemandNotificationParameters
        xpoOnDemandNotificationParams = CType(sender, DialogController).Frame?.View?.CurrentObject
        If xpoOnDemandNotificationParams IsNot Nothing Then
            xpoOnDemandNotificationParams.Delete()
            CType(sender, DialogController).Frame.View.ObjectSpace.CommitChanges()
        End If

    End Sub

    Private Sub Dialog_Accepting(sender As Object, e As DialogControllerAcceptingEventArgs)
        'generate queue item and pass to dialog based on selected choice item

        Dim xpoOnDemandNotificationParameters As OnDemandNotificationParameters
        Dim obs As Xpo.XPObjectSpace
        Dim xpoNotificationQueueItem As NotificationQueueItem
        Dim xpoAttachment As NotificationDatabaseAttachment
        Dim xpoMailSettings As MailSettings



        obs = Application.CreateObjectSpace
        xpoOnDemandNotificationParameters = e.AcceptActionArgs.CurrentObject
        xpoMailSettings = MailSettings.GetInstance(obs.Session)

        If xpoOnDemandNotificationParameters.Body = String.Empty Then
            Throw New UserFriendlyException("Please enter an email body for the notification item.")
        End If
        If xpoOnDemandNotificationParameters.EmailAddress = String.Empty Then
            Throw New UserFriendlyException("Please enter an email address for the notification item.")
        End If
        If xpoOnDemandNotificationParameters.Subject = String.Empty Then
            Throw New UserFriendlyException("Please enter an email subjet for the notification item.")
        End If
        If xpoMailSettings.DefaultFromAddress = String.Empty Then
            Throw New UserFriendlyException("Please setup your mail settings before sending notifications.")
        End If

        xpoNotificationQueueItem = New NotificationQueueItem(obs.Session)
        With xpoNotificationQueueItem
            .Body = xpoOnDemandNotificationParameters.Body
            .PrimaryToAddress = xpoOnDemandNotificationParameters.EmailAddress
            .Subject = xpoOnDemandNotificationParameters.Subject
            If xpoOnDemandNotificationParameters.OnDemandNotificationFromOption IsNot Nothing Then
                .FromAddress = xpoOnDemandNotificationParameters.OnDemandNotificationFromOption.FromAddress
            Else
                .FromAddress = xpoOnDemandNotificationParameters.FromAddress
            End If

            If xpoOnDemandNotificationParameters.OnDemandNotificationToOption IsNot Nothing Then
                .PrimaryToAddress = xpoOnDemandNotificationParameters.OnDemandNotificationToOption.ToAddress
            Else
                .PrimaryToAddress = xpoOnDemandNotificationParameters.EmailAddress
            End If

            .SerializedObjectKey = xpoOnDemandNotificationParameters.SerializedObjectKEy
            .RelatedNotificationRule = obs.GetObject(xpoOnDemandNotificationParameters.RelatedRule)
            For Each objAttach In xpoOnDemandNotificationParameters.NotificationAttachments
                xpoAttachment = obs.CreateObject(Of NotificationDatabaseAttachment)
                With xpoAttachment
                    .Content = objAttach.Content
                    .Name = objAttach.Name
                    .SetFileName(objAttach.Name)
                    .SetRecordDate(objAttach.RecordDate)
                End With
                .NotificationAttachments.Add(xpoAttachment)
            Next

            xpoOnDemandNotificationParameters.RelatedRule.AppendCCAndBCCToNotificationQueueItem(xpoNotificationQueueItem, xpoOnDemandNotificationParameters.CCEmailAddress, xpoOnDemandNotificationParameters.BCCEmailAddress)
        End With
        xpoOnDemandNotificationParameters.Delete()
        obs.CommitChanges()
    End Sub
    Private Sub Notifications_SendNotificationBatchSelectedRows_Execute(sender As Object, e As SingleChoiceActionExecuteEventArgs) Handles Notifications_SendNotificationBatchSelectedRows.Execute
        If e.SelectedChoiceActionItem Is Nothing OrElse View.CurrentObject Is Nothing Then
            Return
        End If
        Dim obs As Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim xpoRule As NotificationRule = obs.FindObject(Of NotificationRule)(New BinaryOperator("Oid", New System.Guid(e.SelectedChoiceActionItem.Id)))
        If xpoRule Is Nothing Then
            Return
        End If
        Dim eBatchprocessingEventArgs As BatchProcessingExecutingEventArgs
        Dim intQualifyingSelectedObjects As Integer
        If String.IsNullOrEmpty(xpoRule.RuleCriteria) Then
            intQualifyingSelectedObjects = ThisListView.SelectedObjects.Count
        Else
            For Each xpoObject As XPBaseObject In ThisListView.SelectedObjects
                If xpoObject.Fit(CriteriaOperator.Parse(xpoRule.RuleCriteria)) Then
                    intQualifyingSelectedObjects += 1
                End If
            Next
        End If
        'raise event to allow for cancellation
        eBatchprocessingEventArgs = New BatchProcessingExecutingEventArgs(xpoRule.Name, intQualifyingSelectedObjects)
        RaiseEvent BatchProcessExecuting(eBatchprocessingEventArgs)
        If eBatchprocessingEventArgs.Cancel = True Then
            Return
        End If
        For Each xpoObject In ThisListView.SelectedObjects
            xpoRule.ProcessNotificationRule(obs.GetObject(xpoObject))
        Next
        obs.CommitChanges()

    End Sub

    Public Sub GenerateNotificationActionItems()
        Dim gpoGroupOperator As New GroupOperator
        Dim caiChoiceActionItem As ChoiceActionItem
        Dim obs As Xpo.XPObjectSpace = TryCast(ObjectSpace, Xpo.XPObjectSpace)
        If obs Is Nothing Then
            Return
        End If

        If View Is Nothing OrElse View.ObjectTypeInfo Is Nothing Then
            Return
        End If
        With gpoGroupOperator
            .Operands.Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.OnDemand))
            .Operands.Add(New BinaryOperator("IsActive", True))
            .Operands.Add(New BinaryOperator("TargetObjectType", View.ObjectTypeInfo.FullName))
        End With
        Notifications_SendNotification.Items.Clear()


        Dim xpcOnDemandRules As New XPCollection(Of NotificationRule)(obs.Session, gpoGroupOperator)
        For Each xpoItem In xpcOnDemandRules
            If View.CurrentObject IsNot Nothing AndAlso TypeOf (View.CurrentObject) Is XPBaseObject AndAlso CType(View.CurrentObject, XPBaseObject).Fit(xpoItem.RuleCriteria) Then
                caiChoiceActionItem = New ChoiceActionItem
                With caiChoiceActionItem
                    .Caption = xpoItem.Name
                    .Data = xpoItem.Oid
                    .Id = xpoItem.Oid.ToString
                    .ImageName = "BO_Note"

                End With
                Notifications_SendNotification.Items.Add(caiChoiceActionItem)
            End If
        Next
    End Sub
    Public Sub GenerateNotificationActionItemsSelectedRowsBatchProcessing()
        Dim gpoGroupOperator As New GroupOperator
        Dim caiChoiceActionItem As ChoiceActionItem
        Dim obs As Xpo.XPObjectSpace = TryCast(ObjectSpace, Xpo.XPObjectSpace)
        If obs Is Nothing Then
            Return
        End If

        If View Is Nothing OrElse View.ObjectTypeInfo Is Nothing Then
            Return
        End If
        Notifications_SendNotificationBatchSelectedRows.Items.Clear()
        With gpoGroupOperator
            .Operands.Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.OnDemandSelectedQualifying))
            .Operands.Add(New BinaryOperator("IsActive", True))
            .Operands.Add(New BinaryOperator("TargetObjectType", View.ObjectTypeInfo.FullName))
        End With
        Dim xpcOnDemandRulesSelected As New XPCollection(Of NotificationRule)(obs.Session, gpoGroupOperator)
        If xpcOnDemandRulesSelected.Count > 0 Then
            For Each xpoItem In xpcOnDemandRulesSelected
                caiChoiceActionItem = New ChoiceActionItem
                With caiChoiceActionItem
                    .Caption = String.Format("{0}", xpoItem.Name)
                    .Data = xpoItem.Oid
                    .Id = xpoItem.Oid.ToString
                    .ImageName = "ArrangeInRows"
                End With
                Notifications_SendNotificationBatchSelectedRows.Items.Add(caiChoiceActionItem)
            Next
        End If
    End Sub
    Private Sub GenerateNotificationActionItemsAllObjectBatchProcessing()
        Dim gpoGroupOperator As New GroupOperator
        Dim caiChoiceActionItem As ChoiceActionItem
        Dim obs As Xpo.XPObjectSpace = TryCast(ObjectSpace, Xpo.XPObjectSpace)
        If obs Is Nothing Then
            Return
        End If

        If View Is Nothing OrElse View.ObjectTypeInfo Is Nothing Then
            Return
        End If
        Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.Items.Clear()


        gpoGroupOperator.Operands.Clear()
        With gpoGroupOperator
            .Operands.Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.OnDemandAllQualifying))
            .Operands.Add(New BinaryOperator("IsActive", True))
            .Operands.Add(New BinaryOperator("TargetObjectType", View.ObjectTypeInfo.FullName))
        End With
        Dim xpcOnDemandRulesAll As New XPCollection(Of NotificationRule)(obs.Session, gpoGroupOperator)
        If xpcOnDemandRulesAll.Count > 0 Then
            For Each xpoItem In xpcOnDemandRulesAll
                caiChoiceActionItem = New ChoiceActionItem
                With caiChoiceActionItem
                    .Caption = String.Format("{0}", xpoItem.Name)
                    .Data = xpoItem.Oid
                    .Id = xpoItem.Oid.ToString
                    .ImageName = "SelectAll"

                End With
                Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.Items.Add(caiChoiceActionItem)
            Next
        End If

    End Sub
#Region "Events"
    Public Class BatchProcessingExecutingEventArgs
        Public Sub New(RuleName As String, Optional QualifyingObjectsCount As Integer? = Nothing)
            _mRuleName = RuleName
            _mQualifyingObjectsCount = QualifyingObjectsCount
        End Sub
        Private _mCancel As Boolean
        Public Property Cancel As Boolean
            Get
                Return _mCancel
            End Get
            Set(ByVal Value As Boolean)
                _mCancel = Value
            End Set
        End Property
        Private _mRuleName As String
        Public ReadOnly Property RuleName As String
            Get
                Return _mRuleName
            End Get

        End Property
        Private _mQualifyingObjectsCount As Integer?
        Public ReadOnly Property QualifyingObjectsCount As Integer?
            Get
                Return _mQualifyingObjectsCount
            End Get
        End Property


    End Class
    Public Event BatchProcessExecuting(ByRef e As BatchProcessingExecutingEventArgs)

    Private Sub Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects_Execute(sender As Object, e As SingleChoiceActionExecuteEventArgs) Handles Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.Execute
        If e.SelectedChoiceActionItem Is Nothing OrElse View.CurrentObject Is Nothing Then
            Return
        End If
        Dim obs As Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim xpoRule As NotificationRule = obs.FindObject(Of NotificationRule)(New BinaryOperator("Oid", New System.Guid(e.SelectedChoiceActionItem.Id)))
        If xpoRule Is Nothing Then
            Return
        End If
        Dim eBatchprocessingEventArgs As BatchProcessingExecutingEventArgs
        Dim intQualifyingSelectedObjects As Integer
        intQualifyingSelectedObjects = xpoRule.GetQualifyingObjects().Count
        'raise event to allow for cancellation
        eBatchprocessingEventArgs = New BatchProcessingExecutingEventArgs(xpoRule.Name, intQualifyingSelectedObjects)
        RaiseEvent BatchProcessExecuting(eBatchprocessingEventArgs)
        If eBatchprocessingEventArgs.Cancel = True Then
            Return
        End If
        xpoRule.ProcessNotificationRule()
        obs.CommitChanges()
    End Sub

#End Region



End Class
