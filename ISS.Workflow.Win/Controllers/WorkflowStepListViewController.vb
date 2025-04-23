Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports System.Runtime.Serialization
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Editors

Public Class WorkflowStepListViewController
    Inherits DevExpress.ExpressApp.ViewController

    Private _mLastWorkflowStep As ISSBaseWorkflowStep

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetObjectType = GetType(ISSBaseWorkflowStep)
        Me.TargetViewType = ViewType.ListView
    End Sub

    Private _mWorkflowObject As Interfaces.IWorkflow
    Private _mParentView As View
    Private _mGridControl As DevExpress.XtraGrid.GridControl
    Private _mGridView As DevExpress.XtraGrid.Views.Grid.GridView


    'Public ReadOnly Property WorkflowLocked As Boolean
    '    Get
    '        CType(CType(View,ListView).CollectionSource,PropertyCollectionSource).
    '    End Get
    'End Property

    Public ReadOnly Property ListView As View
        Get
            Return View
        End Get
    End Property

    'Public ReadOnly Property ParentView As View
    '    Get

    '    End Get
    'End Property

    Private Sub SetupWorkflowValue(ByVal sender As Object, ByVal e As EventArgs)
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim wfoWorkflow As Interfaces.IWorkflow
        If _mParentView.CurrentObject Is Nothing Then
            Return
        End If

        If Not (TypeOf _mParentView.CurrentObject Is Interfaces.IWorkflow) Then
            Return
        End If

        _mWorkflowObject = _mParentView.CurrentObject
        wfoWorkflow = obsObjectSpace.GetObject(_mWorkflowObject)
        If wfoWorkflow IsNot Nothing Then
            _mLastWorkflowStep = If(wfoWorkflow.WorkflowStatus IsNot Nothing, Me.View.ObjectSpace.GetObject(wfoWorkflow.WorkflowStatus), Nothing)
            'Else
            '    wfoWorkflow = _mParentView.CurrentObject
            '    _mLastWorkflowStep = wfoWorkflow.WorkflowStatus
        End If
    End Sub
    Private Function GetAvailableStepsFilter(ByVal WorkflowStep As ISSBaseWorkflowStep) As DevExpress.Data.Filtering.CriteriaOperator
        Dim objGroupFilter As New DevExpress.Data.Filtering.GroupOperator
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim oObjectCustomization As ISSBaseBusinessRules
        SetupWorkflowValue(Nothing, Nothing)

        If WorkflowObjectViewController.WorkflowLocked = False Then
            oObjectCustomization = obsObjectSpace.FindObject(Of ISSBaseBusinessRules)(New DevExpress.Data.Filtering.BinaryOperator("ObjectType", _mParentView.CurrentObject.GetType, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            'If oObjectCustomization IsNot Nothing Then
            '    Return New DevExpress.Data.Filtering.ContainsOperator("WorkflowStepGroups", New BinaryOperator("Oid", oObjectCustomization.DefaultWorkflowStepGroup.Oid))
            'Else
            If oObjectCustomization IsNot Nothing Then
                Return New DevExpress.Data.Filtering.BinaryOperator("ObjectCustomization.SavedType", oObjectCustomization.SavedType, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
            Else
                Return Nothing
            End If
            'End If
            'If WorkflowStep IsNot Nothing Then

            'Else
            '    oObjectCustomization = obsObjectSpace.FindObject(Of ISSBaseBusinessRules)(New DevExpress.Data.Filtering.BinaryOperator("ObjectType", _mParentView.CurrentObject.GetType, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            'End If
        End If

        If _mLastWorkflowStep Is Nothing Then
            If WorkflowStep IsNot Nothing Then
                If WorkflowStep.ShowNextStepsBeforeSave = True Then
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("PreviousSteps", New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal)))
                    For Each wsgGroup As ISSBaseWorkflowStepGroup In WorkflowStep.NextGroups
                        objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("WorkflowStepGroups", New BinaryOperator("This", wsgGroup)))
                    Next
                    objGroupFilter.OperatorType = DevExpress.Data.Filtering.GroupOperatorType.Or
                    Return objGroupFilter
                Else
                    'objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", _mLastWorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    'objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    'objGroupFilter.OperatorType = DevExpress.Data.Filtering.GroupOperatorType.Or
                    If _mParentView.CurrentObject IsNot Nothing Then
                        oObjectCustomization = obsObjectSpace.FindObject(Of ISSBaseBusinessRules)(New DevExpress.Data.Filtering.BinaryOperator("ObjectType", _mParentView.CurrentObject.GetType, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                        If oObjectCustomization IsNot Nothing Then
                            If oObjectCustomization.DefaultWorkflowStepGroup IsNot Nothing Then
                                objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("WorkflowStepGroups", New BinaryOperator("Oid", oObjectCustomization.DefaultWorkflowStepGroup.Oid)))
                                objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                                objGroupFilter.OperatorType = DevExpress.Data.Filtering.GroupOperatorType.Or
                                Return objGroupFilter
                            Else
                                Return New DevExpress.Data.Filtering.BinaryOperator("ObjectCustomization.SavedType", oObjectCustomization.SavedType, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
                            End If
                        End If
                    End If
                    'Return New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
                End If
            Else
                If _mParentView.CurrentObject IsNot Nothing Then
                    oObjectCustomization = obsObjectSpace.FindObject(Of ISSBaseBusinessRules)(New DevExpress.Data.Filtering.BinaryOperator("ObjectType", _mParentView.CurrentObject.GetType, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    If oObjectCustomization IsNot Nothing Then
                        If oObjectCustomization.DefaultWorkflowStepGroup IsNot Nothing Then
                            Return New DevExpress.Data.Filtering.ContainsOperator("WorkflowStepGroups", New BinaryOperator("Oid", oObjectCustomization.DefaultWorkflowStepGroup.Oid))
                        Else
                            Return New DevExpress.Data.Filtering.BinaryOperator("ObjectCustomization.SavedType", oObjectCustomization.SavedType, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
                        End If
                    End If
                End If
            End If
        Else
            If _mLastWorkflowStep IsNot WorkflowStep Then
                If WorkflowStep IsNot Nothing AndAlso WorkflowStep.ShowNextStepsBeforeSave = True Then
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", _mLastWorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("PreviousSteps", New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal)))
                    For Each wsgGroup As ISSBaseWorkflowStepGroup In WorkflowStep.NextGroups
                        objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("WorkflowStepGroups", New BinaryOperator("This", wsgGroup)))
                    Next

                    objGroupFilter.OperatorType = DevExpress.Data.Filtering.GroupOperatorType.Or
                    Return objGroupFilter
                Else
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", _mLastWorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("PreviousSteps", New DevExpress.Data.Filtering.BinaryOperator("Oid", _mLastWorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal)))
                    For Each wsgGroup As ISSBaseWorkflowStepGroup In WorkflowStep.NextGroups
                        objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("WorkflowStepGroups", New BinaryOperator("This", wsgGroup)))
                    Next
                    objGroupFilter.OperatorType = DevExpress.Data.Filtering.GroupOperatorType.Or
                    Return objGroupFilter
                End If
            Else
                objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("PreviousSteps", New DevExpress.Data.Filtering.BinaryOperator("Oid", WorkflowStep.Oid, DevExpress.Data.Filtering.BinaryOperatorType.Equal)))
                For Each wsgGroup As ISSBaseWorkflowStepGroup In WorkflowStep.NextGroups
                    objGroupFilter.Operands.Add(New DevExpress.Data.Filtering.ContainsOperator("WorkflowStepGroups", New BinaryOperator("This", wsgGroup)))
                Next
                objGroupFilter.OperatorType = DevExpress.Data.Filtering.GroupOperatorType.Or
                Return objGroupFilter
            End If
        End If

Return Nothing
    End Function
    Private Sub SetupWorkflowObjectsFromPopupForm(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lstListView As ListView = Me.View
        Dim dvtTemplate As DevExpress.ExpressApp.Win.Templates.LookupControlTemplate
        Dim dpcPopupContainer As DevExpress.XtraEditors.PopupContainerControl
        If _mWorkflowObject Is Nothing AndAlso Me.Frame IsNot Nothing AndAlso Me.Frame.Template IsNot Nothing Then
            dvtTemplate = Me.Frame.Template
            If dvtTemplate.Parent IsNot Nothing Then
                dpcPopupContainer = dvtTemplate.Parent
                AddHandler dpcPopupContainer.ParentChanged, AddressOf PopupContainerParentAssigned

                AddHandler dpcPopupContainer.VisibleChanged, AddressOf PopupContainerParentAssigned
            End If
        End If
    End Sub
    Private Sub PopupContainerParentAssigned(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim ddfDetailForm As DevExpress.ExpressApp.Win.Templates.XtraFormTemplateBase
        Dim dleLookupEditor As DevExpress.ExpressApp.Win.Editors.LookupEdit
        Dim dpcPopupContainer As DevExpress.XtraEditors.PopupContainerControl = sender
        Dim strParse As String = String.Empty
        Dim nsfFrame As NestedFrame
        If Me.View IsNot Nothing Then
            If Me.View.ObjectTypeInfo.Type IsNot Nothing Then
                If Me.View.ObjectTypeInfo.Type Is GetType(ISSBaseWorkflowStep) Then
                    If dpcPopupContainer.PopupContainerProperties IsNot Nothing AndAlso dpcPopupContainer.PopupContainerProperties.OwnerEdit IsNot Nothing Then
                        dleLookupEditor = dpcPopupContainer.PopupContainerProperties.OwnerEdit
                        nsfFrame = TryCast(dleLookupEditor.Frame, NestedFrame)
                        If nsfFrame IsNot Nothing Then
                            'If TypeOf dleLookupEditor.Parent.Parent.Parent Is DevExpress.ExpressApp.Win.Templates.XtraFormTemplateBase Then
                            'ddfDetailForm = dleLookupEditor.Parent.Parent.Parent

                            _mParentView = nsfFrame.ViewItem.View
                            If _mParentView IsNot Nothing AndAlso _mParentView.ObjectTypeInfo.Implements(Of Interfaces.IWorkflow)() Then
                                _mWorkflowObject = _mParentView.CurrentObject
                                If _mWorkflowObject IsNot Nothing Then
                                    If Not CType(Me.View, ListView).CollectionSource.Criteria("WorkflowFilter") Is GetAvailableStepsFilter(_mWorkflowObject.WorkflowStatus) Then
                                        strParse = GetAvailableStepsFilter(_mWorkflowObject.WorkflowStatus).ToString
                                        CType(Me.View, ListView).CollectionSource.Criteria("WorkflowFilter") = GetAvailableStepsFilter(_mWorkflowObject.WorkflowStatus)
                                        Me.View.Refresh()
                                    End If
                                End If
                                RemoveHandler _mParentView.CurrentObjectChanged, AddressOf SetupWorkflowObjectsFromPopupForm
                                RemoveHandler _mParentView.ObjectSpace.Committed, AddressOf SetupWorkflowObjectsFromPopupForm
                                RemoveHandler _mParentView.ObjectSpace.ObjectChanged, AddressOf SetupWorkflowObjectsFromPopupForm
                                AddHandler _mParentView.CurrentObjectChanged, AddressOf SetupWorkflowObjectsFromPopupForm
                                AddHandler _mParentView.ObjectSpace.Committed, AddressOf SetupWorkflowObjectsFromPopupForm
                                AddHandler _mParentView.ObjectSpace.ObjectChanged, AddressOf SetupWorkflowObjectsFromPopupForm
                            End If
                            'End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub WorkflowStepListViewController_FrameAssigned(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FrameAssigned
        RemoveHandler Me.Frame.TemplateChanged, AddressOf AssignTemplateInfo
        AddHandler Me.Frame.TemplateChanged, AddressOf AssignTemplateInfo
    End Sub
    Private Sub AssignTemplateInfo(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf Me.Frame.Template Is DevExpress.ExpressApp.Win.Templates.LookupControlTemplate Then
            RemoveHandler CType(Me.Frame.Template, DevExpress.ExpressApp.Win.Templates.LookupControlTemplate).ParentChanged, AddressOf SetupWorkflowObjectsFromPopupForm
            AddHandler CType(Me.Frame.Template, DevExpress.ExpressApp.Win.Templates.LookupControlTemplate).ParentChanged, AddressOf SetupWorkflowObjectsFromPopupForm
        End If
    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        Dim lpeListPropertyEditor As ListEditor = CType(View,ListView).Editor
        
    End Sub

    Private Sub Workflow_Unlock_Execute(sender As Object, e As SimpleActionExecuteEventArgs)

    End Sub

End Class
