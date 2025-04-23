Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class ActionButtonDetailViewItemController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 
        Me.TargetViewType = ViewType.DetailView
    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        If View Is Nothing Then
            Return
        End If
        If TypeOf View Is ListView Then
            Return
        End If
        For Each actionButtonDetailItem As ActionLinkDetailViewItem In CType(View, DetailView).GetItems(Of ActionLinkDetailViewItem)()
            RemoveHandler actionButtonDetailItem.Executed, AddressOf ActionButtonDetailItemOnExecuted
            AddHandler actionButtonDetailItem.Executed, AddressOf ActionButtonDetailItemOnExecuted
        Next actionButtonDetailItem
    End Sub

    Private Sub ActionButtonDetailItemOnExecuted(ByVal sender As Object, ByVal eventArgs As EventArgs)
        Dim actionButtonDetailItem As ActionLinkDetailViewItem
        Try
            actionButtonDetailItem = sender
            For Each oController As Controller In Frame.Controllers
                For Each oAction As ActionBase In oController.Actions
                    If Not TypeOf oAction Is SimpleAction AndAlso Not TypeOf oAction Is SingleChoiceAction Then
                        Continue For
                    End If
                    If oAction.Id = actionButtonDetailItem.Id Then
                        If TypeOf oAction Is SimpleAction Then
                            CType(oAction, SimpleAction).DoExecute()
                        ElseIf TypeOf oAction Is SingleChoiceAction Then
                            CType(oAction, SingleChoiceAction).DoExecute(CType(oAction, SingleChoiceAction).SelectedItem)
                        End If

                    End If
                Next
            Next
        Catch ex As Exception
            'Do Nothing, Not Worth An Error Page
            'Task#828: Handle 1007 Error
            'MJC: 08-27-10
        End Try

    End Sub

    Private Sub ActionButtonDetailViewItemController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        Dim actionButtonDetailItem As ActionLinkDetailViewItem
        If View Is Nothing Then
            Return
        End If
        If TypeOf View Is ListView Then
            Return
        End If
        For Each actionButtonDetailItem In CType(View, DetailView).GetItems(Of ActionLinkDetailViewItem)()
            For Each oController As Controller In Frame.Controllers
                For Each oAction As ActionBase In oController.Actions
                    If Not TypeOf oAction Is SimpleAction AndAlso Not TypeOf oAction Is SingleChoiceAction Then
                        Continue For
                    End If
                    If oAction.Id = actionButtonDetailItem.ActionID Then
                        RemoveHandler oAction.Changed, AddressOf UpdateAction
                        AddHandler oAction.Changed, AddressOf UpdateAction
                        actionButtonDetailItem.SetControlVisibility(oAction.Active.ResultValue)
                    End If
                Next
            Next
        Next actionButtonDetailItem
    End Sub

    Private Sub UpdateAction(ByVal sender As Object, ByVal e As EventArgs)
        Dim oAction As ActionBase = sender
        Dim actionButtonDetailItem As ActionLinkDetailViewItem
        If View Is Nothing Then
            Return
        End If
        If TypeOf View Is ListView Then
            Return
        End If
        For Each actionButtonDetailItem In CType(View, DetailView).GetItems(Of ActionLinkDetailViewItem)()
            If oAction.Id = actionButtonDetailItem.ActionID Then
                actionButtonDetailItem.SetControlVisibility(oAction.Active.ResultValue)
            End If
        Next
    End Sub

End Class
