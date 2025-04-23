Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class SkinEditorController
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

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        Dim wdcWindowsControl As System.Windows.Forms.Control
        For Each dviViewItem As DevExpress.ExpressApp.Editors.DetailPropertyEditor In DetailView.GetItems(Of DevExpress.ExpressApp.Editors.DetailPropertyEditor)()
            If dviViewItem.Control IsNot Nothing Then
                wdcWindowsControl = dviViewItem.Control

            End If
        Next


    End Sub

End Class
