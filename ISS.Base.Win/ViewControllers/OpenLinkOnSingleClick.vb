Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports DevExpress.XtraEditors

Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class OpenLinkOnSingleClick
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub

    Private Sub OpenLinkOnSingleClick_mViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        If Not (TypeOf View Is ListView) Then
            Return
        End If

        Dim lstView As ListView = View

        Dim editor As DevExpress.ExpressApp.Win.Editors.GridListEditor = TryCast(lstView.Editor, DevExpress.ExpressApp.Win.Editors.GridListEditor)
        If editor Is Nothing Then
            Return
        End If

        RemoveHandler editor.GridView.MouseDown, AddressOf GridView_MouseDown
        AddHandler editor.GridView.MouseDown, AddressOf GridView_MouseDown
    End Sub

    Private Sub GridView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim view As GridView = sender
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New System.Drawing.Point(e.X, e.Y))
        Dim repositoryItem As RepositoryItemHyperLinkEdit
        Dim editor As HyperLinkEdit
        Try
            If hitInfo.Column Is Nothing Then
                Return
            End If
            If hitInfo.Column.ColumnEdit Is Nothing Then
                Return
            End If
            If Not (hitInfo.InRowCell AndAlso GetType(RepositoryItemHyperLinkEdit).IsAssignableFrom(hitInfo.Column.ColumnEdit.GetType())) Then
                Return
            End If

            If view.GetRow(hitInfo.RowHandle) Is Nothing OrElse TryCast(view.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column), String) Is Nothing Then
                Return
            End If

            repositoryItem = hitInfo.Column.ColumnEdit
            editor = repositoryItem.CreateEditor
            editor.ShowBrowser(view.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column))
        Catch ex As Exception
            Return
        End Try
    End Sub

End Class
