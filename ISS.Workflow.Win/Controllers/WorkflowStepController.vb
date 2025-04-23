Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Data
Imports DevExpress.Xpo.DB
Imports DevExpress.ExpressApp.Win.Editors

Public Class WorkflowStepController
    Inherits DevExpress.ExpressApp.ViewController


    Private _mParentObject As Object
    Public Property ParentObject() As Object
        Get
            Return _mParentObject
        End Get
        Set(ByVal value As Object)
            If _mParentObject = value Then
                Return
            End If
            _mParentObject = value
        End Set
    End Property

    Public ReadOnly Property ListView As ListView
        Get
            Return View
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetObjectType = GetType(ISSBaseWorkflowStep)
        Me.TargetViewType = ViewType.ListView
    End Sub
    
End Class
