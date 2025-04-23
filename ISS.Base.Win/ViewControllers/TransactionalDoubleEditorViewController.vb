Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class TransactionalDoubleEditorViewController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        If TypeOf View Is DetailView Then
            For Each tdeTransactionalEditor As TransactionalDoubleEditor In CType(View, DetailView).GetItems(Of TransactionalDoubleEditor)()
                AddHandler tdeTransactionalEditor.TransactionalDoubleHistoryClicked, AddressOf Editor_TransactionalDoubleHistoryClicked
            Next
        End If
    End Sub

    Protected Overrides Sub OnDeactivated()
        MyBase.OnDeactivated()
        If TypeOf View Is DetailView Then
            For Each tdeTransactionalEditor As TransactionalDoubleEditor In CType(View, DetailView).GetItems(Of TransactionalDoubleEditor)()
                RemoveHandler tdeTransactionalEditor.TransactionalDoubleHistoryClicked, AddressOf Editor_TransactionalDoubleHistoryClicked
            Next
        End If
    End Sub

    Private Sub Editor_TransactionalDoubleHistoryClicked(ByVal sender As Object, ByVal e As TransactionalDoubleEditor.TransactionalDoubleClickedEventArgs)
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace
        Dim svsShowViewSource As New ShowViewSource(Frame, Nothing)
        Dim tdeEditor As TransactionalDoubleEditor = sender
        Dim svpParameter As New ShowViewParameters
        If tdeEditor.MemberInfo.IsAggregated = True Then
            obsObjectSpace = ObjectSpace.CreateNestedObjectSpace
        Else
            obsObjectSpace = Application.CreateObjectSpace
        End If
        svpParameter.CreatedView = Application.CreateDetailView(obsObjectSpace, obsObjectSpace.GetObject(e.TransactionalDouble))
        svpParameter.NewWindowTarget = NewWindowTarget.Separate
        svpParameter.TargetWindow = TargetWindow.NewModalWindow
        Application.ShowViewStrategy.ShowView(svpParameter, svsShowViewSource)
        If tdeEditor.MemberInfo.IsAggregated = False Then
            CType(tdeEditor.PropertyValue, TransactionalDouble).Reload()
        End If
        tdeEditor.ReadValue()
    End Sub

End Class
