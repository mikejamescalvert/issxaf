Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class ObjectCustomizationController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetObjectType = GetType(ISSBaseBusinessRules)
        Me.TargetViewType = ViewType.DetailView

    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        'disable step and step list if selected object doesn't implement
        'definitin changed: reevalute
        SetupWorkflowStepAvailability(Me, Nothing)
        AddHandler Me.View.CurrentObjectChanged, AddressOf SetupWorkflowStepAvailability
        RemoveHandler CType(Me.View.CurrentObject, ISSBaseBusinessRules).Changed, AddressOf SetupWorkflowStepAvailability
        AddHandler CType(Me.View.CurrentObject, ISSBaseBusinessRules).Changed, AddressOf SetupWorkflowStepAvailability
    End Sub

    Private Sub ObjectChanged()
        SetupWorkflowStepAvailability(Me, Nothing)
        RemoveHandler CType(Me.View.CurrentObject, ISSBaseBusinessRules).Changed, AddressOf SetupWorkflowStepAvailability
        AddHandler CType(Me.View.CurrentObject, ISSBaseBusinessRules).Changed, AddressOf SetupWorkflowStepAvailability
    End Sub

    Private Sub SetupWorkflowStepAvailability(ByVal sender As Object, ByVal e As EventArgs)

        Dim objDetailView As DetailView = Me.View
        Dim objWorkflowDefintion As ISSBaseBusinessRules = objDetailView.CurrentObject
        Dim objTypeInfo As DevExpress.ExpressApp.DC.TypeInfo
        If objWorkflowDefintion Is Nothing Then
            SetPropertyEditorsReadonlyForWorkflowStep(True, True)
        Else
            objTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(objWorkflowDefintion.ObjectType)
            If objTypeInfo Is Nothing Then
                SetPropertyEditorsReadonlyForWorkflowStep(True, True)
            Else
                SetPropertyEditorsReadonlyForWorkflowStep(Not objTypeInfo.Implements(Of Interfaces.IWorkflow)(), False)
            End If
        End If
    End Sub

    Private Sub SetPropertyEditorsReadonlyForWorkflowStep(ByVal IsWorkflowReadonly As Boolean, ByVal IsEditorsReadonly As Boolean)
        Dim objDetailView As DetailView = Me.View
        For Each objListPropertyEditor As Editors.ListPropertyEditor In objDetailView.GetItems(Of Editors.ListPropertyEditor)()
            If objListPropertyEditor.ListView IsNot Nothing Then
                If objListPropertyEditor.ListView.ObjectTypeInfo.Type Is GetType(ISSBaseWorkflowStep) Then
                    objListPropertyEditor.ListView.AllowEdit.SetItemValue("", Not IsWorkflowReadonly)
                Else
                    objListPropertyEditor.ListView.AllowEdit.SetItemValue("", Not IsEditorsReadonly)
                End If
            End If

        Next
        For Each objPropertyEditor As DevExpress.ExpressApp.Win.Editors.LookupPropertyEditor In objDetailView.GetItems(Of DevExpress.ExpressApp.Win.Editors.LookupPropertyEditor)()
            If objPropertyEditor.MemberInfo.MemberTypeInfo.Type Is GetType(ISSBaseWorkflowStep) Then
                objPropertyEditor.AllowEdit.SetItemValue("", Not IsWorkflowReadonly)
            ElseIf objPropertyEditor.MemberInfo.MemberTypeInfo.Type IsNot GetType(System.Type) Then
                objPropertyEditor.AllowEdit.SetItemValue("", Not IsEditorsReadonly)
            End If
        Next
    End Sub

End Class
