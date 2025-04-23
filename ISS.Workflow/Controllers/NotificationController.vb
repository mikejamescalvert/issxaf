Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class NotificationController
    Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        'Me.ObjectCustomization = Me.ObjectSpace.FindObject(GetType(ISSBaseBusinessRules), New DevExpress.Data.Filtering.BinaryOperator("ObjectType", Me.View.ObjectTypeInfo.Type, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
        'If Me.ObjectCustomization IsNot Nothing Then
        '    If Me.ObjectCustomization.DeleteNotification IsNot Nothing Then
        If TypeOf Me.View Is DashboardView OrElse Me.View.ObjectTypeInfo.IsPersistent = False Then
            Return
        End If
        Dim oDeleteTemplate As ISSBaseBusinessRules = Me.ObjectSpace.FindObject(GetType(ISSBaseBusinessRules), New DevExpress.Data.Filtering.BinaryOperator("ObjectType", Me.View.ObjectTypeInfo.Type, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
        If oDeleteTemplate Is Nothing OrElse oDeleteTemplate.DeleteNotification Is Nothing Then
            Return
        End If


        RemoveHandler Me.ObjectSpace.ObjectDeleting, AddressOf ObjectsDeleted
        AddHandler Me.ObjectSpace.ObjectDeleting, AddressOf ObjectsDeleted
        RemoveHandler Me.ObjectSpace.ObjectChanged, AddressOf ObjectChanged
        AddHandler Me.ObjectSpace.ObjectChanged, AddressOf ObjectChanged
        '    End If
        'End If

    End Sub

    Protected Overrides Sub OnDeactivated()
        MyBase.OnDeactivated()
        RemoveHandler Me.ObjectSpace.ObjectDeleting, AddressOf ObjectsDeleted
        RemoveHandler Me.ObjectSpace.ObjectChanged, AddressOf ObjectChanged
    End Sub

    Private Sub ObjectsDeleted(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.ObjectsManipulatingEventArgs)
        
    End Sub
   

    Private _mISSBaseBusinessRules As ISSBaseBusinessRules
    Public Sub ObjectChanged(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.ObjectChangedEventArgs)
        Dim obsSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace
        Dim objCustomization As ISSBaseBusinessRules
        Dim objValueFromDB As Object
        Dim objWorkflowStep As ISSBaseWorkflowStep
        Dim oCurrentObject As Object
        If Application Is Nothing Then
            Return
        End If
        If Me.View Is Nothing Then
            Return
        End If
        If Me.View.CurrentObject Is Nothing Then
            Return
        End If
        oCurrentObject = Me.View.CurrentObject
        obsSpace = Application.CreateObjectSpace
        If _mISSBaseBusinessRules Is Nothing Then
            _mISSBaseBusinessRules = ObjectSpace.FindObject(GetType(ISSBaseBusinessRules), New DevExpress.Data.Filtering.BinaryOperator("ObjectType", oCurrentObject.GetType))
        End If
        If _mISSBaseBusinessRules IsNot Nothing Then
            If e.Object IsNot Nothing AndAlso e.Object IsNot Nothing Then
                If e.PropertyName > String.Empty AndAlso e.PropertyName <> "Oid" AndAlso e.PropertyName <> "GCRecord" Then
                    objValueFromDB = obsSpace.GetObject(e.Object)
                    If objValueFromDB Is Nothing Then
                        Return
                    End If
                    objCustomization = obsSpace.FindObject(GetType(ISSBaseBusinessRules), New DevExpress.Data.Filtering.BinaryOperator("ObjectType", e.Object.GetType))
                    If objCustomization IsNot Nothing AndAlso objCustomization.ChangeNotification IsNot Nothing Then
                        objCustomization.ChangeNotification.OnNotification(e.Object, ISSBaseNotificationTemplate.NotificationStages.ObjectChange, e.PropertyName)
                    End If
                    For Each rpiPropertyInfo As Reflection.PropertyInfo In e.Object.GetType.GetProperties
                        If rpiPropertyInfo.Name > String.Empty AndAlso _
                                                   rpiPropertyInfo.Name.ToUpper = e.PropertyName.ToUpper Then
                            If rpiPropertyInfo.PropertyType Is GetType(ISSBaseWorkflowStep) Then
                                If rpiPropertyInfo.GetValue(e.Object, Nothing) IsNot Nothing Then
                                    objWorkflowStep = rpiPropertyInfo.GetValue(e.Object, Nothing)
                                    If objWorkflowStep.EnterNotification IsNot Nothing Then
                                        objWorkflowStep.EnterNotification.OnNotification(e.Object, ISSBaseNotificationTemplate.NotificationStages.WorkflowEnter, e.PropertyName)
                                    End If
                                End If
                                If rpiPropertyInfo.GetValue(objValueFromDB, Nothing) IsNot Nothing Then
                                    objWorkflowStep = rpiPropertyInfo.GetValue(objValueFromDB, Nothing)
                                    If objWorkflowStep.LeaveNotification IsNot Nothing Then
                                        objWorkflowStep.LeaveNotification.OnNotification(e.Object, ISSBaseNotificationTemplate.NotificationStages.WorkflowLeave, e.PropertyName)
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        End If
        obsSpace.Session.DropIdentityMap()
        obsSpace.Dispose()

    End Sub

End Class
