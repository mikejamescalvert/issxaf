Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class FiltersSearchController
    Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 
    End Sub

    Private Sub btnClearFilter_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles btnClearFilter.Execute
        Dim objFilterController As SystemModule.FilterController
        objFilterController = Me.Frame.GetController(Of SystemModule.FilterController)()
        objFilterController.FullTextFilterAction.DoExecute(String.Empty)
    End Sub

    Private Sub FiltersSearchController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        If Me.View Is Nothing OrElse Me.View.ObjectTypeInfo Is Nothing Then
            Me.btnClearFilter.Active.SetItemValue("HasViewInfo", False)
            Return
        Else
            Me.btnClearFilter.Active.SetItemValue("HasViewInfo", True)
        End If

        Me.btnClearFilter.Active.SetItemValue("PersistentObject", View.ObjectTypeInfo.IsPersistent)

    End Sub
End Class
