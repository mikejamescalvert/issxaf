Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.HtmlPropertyEditor.Win

Public Class HTMLEditorViewController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.DetailView
    End Sub

    Public ReadOnly Property DetailView As DetailView
        Get
            Return View
        End Get
    End Property



    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        
        For Each hteEditor As HtmlPropertyEditor In DetailView.GetItems(Of HtmlPropertyEditor)
            If hteEditor.Control Is Nothing
                AddHandler hteEditor.ControlCreated, AddressOf HtmlEditor_ControlCreated
            Else
                FixEditor(hteEditor)
            End If

        Next
    End Sub

    Public Sub FixEditor(ByVal Editor As HtmlPropertyEditor)
        Dim objControl As HtmlEditor = Editor.Control
        
    End Sub

    Private Sub HtmlEditor_ControlCreated(sender As Object, e As EventArgs)
        FixEditor(sender)
    End Sub
End Class
