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
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Xpo

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class ObjectViewController
    Inherits ViewController


    Private lPropertyChangedQueueItems As List(Of NotificationPropertyChangedQueueItem)

    Public Sub New()
        InitializeComponent()

    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        'RegisterPropertyChangedNotificationEvents()
        ' Perform various tasks depending on the target View.
    End Sub


    'Private Sub RegisterPropertyChangedNotificationEvents()
    '    ' Setup event handlers and list for property changed notification evaluation
    '    Dim gpoGroupOperator As New GroupOperator
    '    Dim obs As Xpo.XPObjectSpace = TryCast(ObjectSpace, Xpo.XPObjectSpace)

    '    If View Is Nothing OrElse View.ObjectTypeInfo Is Nothing OrElse obs Is Nothing Then
    '        Return
    '    End If

    '    With gpoGroupOperator
    '        .Operands.Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.OnChange))
    '        .Operands.Add(New BinaryOperator("IsActive", True))
    '        .Operands.Add(New BinaryOperator("TargetObjectType", View.ObjectTypeInfo.FullName))
    '    End With

    '    If New XPCollection(Of NotificationRule)(obs.Session, gpoGroupOperator).Count > 0 Then
    '        lPropertyChangedQueueItems = New List(Of NotificationPropertyChangedQueueItem)()

    '        AddHandler ObjectSpace.ObjectChanged, AddressOf ObjectSpace_NotificationObjectChanged
    '        AddHandler ObjectSpace.Committing, AddressOf ObjectSpace_NotificationObjectChangedCommitting
    '        AddHandler ObjectSpace.Refreshing, AddressOf ObjectSpace_NotificationObjectChangedRefreshing
    '    End If
    'End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
        'If lPropertyChangedQueueItems IsNot Nothing Then
        '    RemoveHandler ObjectSpace.ObjectChanged, AddressOf ObjectSpace_NotificationObjectChanged
        '    RemoveHandler ObjectSpace.Committing, AddressOf ObjectSpace_NotificationObjectChangedCommitting
        '    RemoveHandler ObjectSpace.Refreshing, AddressOf ObjectSpace_NotificationObjectChangedRefreshing
        'End If
    End Sub


    'Private Sub ObjectSpace_NotificationObjectChanged(sender As Object, e As ObjectChangedEventArgs)
    '    ' Check for source property value as property name of changed property in each rule; if found create notification property changed queue item
    '    Dim gpoGroupOperator As New GroupOperator
    '    Dim obs As Xpo.XPObjectSpace = ObjectSpace

    '    With gpoGroupOperator
    '        .Operands.Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.OnChange))
    '        .Operands.Add(New BinaryOperator("IsActive", True))
    '        .Operands.Add(New BinaryOperator("TargetObjectType", View.ObjectTypeInfo.FullName))
    '    End With

    '    For Each xpoPropertyChangedRule In New XPCollection(Of NotificationRule)(obs.Session, gpoGroupOperator)
    '        If xpoPropertyChangedRule.SourceProperty = e.PropertyName Then
    '            If MailSettings.GetInstance(obs.Session).DefaultFromAddress = String.Empty Then
    '                Throw New UserFriendlyException("Please setup your mail settings before sending notifications.")
    '            End If
    '            ' Check for existing nonpersistent queue item (property name and target object)
    '            Dim xpoNotificationQueueItem As NotificationPropertyChangedQueueItem = lPropertyChangedQueueItems.Where(Function(i) i.PropertyName = e.PropertyName AndAlso i.TargetObject IsNot Nothing AndAlso i.TargetObject Is e.Object).FirstOrDefault()
    '            If xpoNotificationQueueItem Is Nothing Then
    '                ' Get original value and add nonpersistent queue item
    '                xpoNotificationQueueItem = New NotificationPropertyChangedQueueItem
    '                With xpoNotificationQueueItem
    '                    .TargetObject = e.Object
    '                    .PropertyName = e.PropertyName
    '                    .OldValue = e.OldValue
    '                    .SourceRule = xpoPropertyChangedRule
    '                End With
    '                lPropertyChangedQueueItems.Add(xpoNotificationQueueItem)
    '            End If
    '            ' Set new value
    '            xpoNotificationQueueItem.NewValue = e.NewValue
    '        End If
    '    Next
    'End Sub

    'Private Sub ObjectSpace_NotificationObjectChangedCommitting(sender As Object, e As CancelEventArgs)
    '    Dim obs As XPObjectSpace = ObjectSpace
    '    Dim xpoNotificationQueueItem As NotificationQueueItem

    '    For Each xpoPropertyChangedQueueItem In lPropertyChangedQueueItems.ToArray()
    '        If xpoPropertyChangedQueueItem.NewValue <> xpoPropertyChangedQueueItem.OldValue Then
    '            ' Create base queue item for committed changes when the change is actually committed
    '            xpoNotificationQueueItem = xpoPropertyChangedQueueItem.SourceRule.GenerateNotification(xpoPropertyChangedQueueItem.TargetObject)
    '        End If
    '        ' Remove from change list either way
    '        lPropertyChangedQueueItems.Remove(xpoPropertyChangedQueueItem)
    '    Next
    'End Sub

    'Private Sub ObjectSpace_NotificationObjectChangedRefreshing(sender As Object, e As CancelEventArgs)
    '    lPropertyChangedQueueItems = New List(Of NotificationPropertyChangedQueueItem)()
    'End Sub
End Class
