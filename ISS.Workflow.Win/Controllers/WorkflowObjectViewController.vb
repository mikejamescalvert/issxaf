Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors

Public Class WorkflowObjectViewController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        TargetObjectType = GetType(Workflow.Interfaces.IWorkflow)
        Me.TargetViewType = ViewType.DetailView
    End Sub

    Public Shared WorkflowLocked As Boolean = True

    Public ReadOnly Property DetailView As DetailView
        Get
            Return View
        End Get
    End Property

    Private Sub Workflow_Unlock_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles Workflow_Unlock.Execute
        If WorkflowLocked = True Then
            Workflow_Unlock.Caption = "Lock Workflow"
            WorkflowLocked = False
        Else
            Workflow_Unlock.Caption = "Unlock Workflow"
            WorkflowLocked = True
        End If
        
    End Sub

    Protected Overrides Sub OnDeactivated()
        MyBase.OnDeactivated()
    End Sub

End Class
