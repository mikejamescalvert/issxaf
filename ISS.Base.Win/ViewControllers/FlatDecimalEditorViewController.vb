Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors.Mask
Imports DevExpress.ExpressApp.PivotGrid.Win
Imports DevExpress.XtraPivotGrid
Imports System.Windows.Forms
Imports DevExpress.ExpressApp.Model
Imports System.ComponentModel

' TODO: KSC - To implement, add this view controller and remove the repository setup method from the editor.
Partial Public Class FlatDecimalEditorViewController
    Inherits ViewController

    Private ri As RepositoryItemMyDecimalEdit
    Private editorShown As Boolean = False

    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
        If View IsNot Nothing AndAlso TypeOf View Is DevExpress.ExpressApp.ListView Then
            Dim lv As DevExpress.ExpressApp.ListView = CType(View, DevExpress.ExpressApp.ListView)
            If lv.Editor IsNot Nothing AndAlso TypeOf lv.Editor Is GridListEditor Then
                Dim editor As GridListEditor = lv.Editor
                If editor IsNot Nothing Then
                    Dim gv As GridView = editor.GridView
                    If gv IsNot Nothing Then
                        AddHandler gv.CustomRowCellEditForEditing, AddressOf GridView_CustomRowCellEditForEditing
                        AddHandler gv.ShownEditor, AddressOf GridView_ShownEditor
                        AddHandler gv.ShowingEditor, AddressOf GridView_ShowingEditor

                        ri = New RepositoryItemMyDecimalEdit()
                        ri.Mask.MaskType = MaskType.Custom
                        ri.Mask.EditMask = "#################0\.00"
                    End If
                End If
            ElseIf lv.Editor IsNot Nothing AndAlso TypeOf lv.Editor Is PivotGridListEditor Then
                Dim editor As PivotGridListEditor = lv.Editor
                If editor IsNot Nothing AndAlso editor.PivotGridControl IsNot Nothing Then
                    AddHandler editor.PivotGridControl.CustomCellEditForEditing, AddressOf PivotGridControl_CustomCellEditForEditing
                    AddHandler editor.PivotGridControl.ShownEditor, AddressOf PivotGridControl_ShownEditor

                    ri = New RepositoryItemMyDecimalEdit()
                    ri.Mask.MaskType = MaskType.Custom
                    ri.Mask.EditMask = "#################0\.00"
                End If
            End If
        ElseIf View IsNot Nothing AndAlso TypeOf View Is DevExpress.ExpressApp.DetailView Then
            Dim dv As DetailView = View
            For Each decEdit In dv.GetItems(Of FlatDecimalPropertyEditor)()
                If decEdit.Control IsNot Nothing Then
                    AddHandler decEdit.Control.MouseUp, AddressOf DecimalEdit_MouseUp
                    AddHandler decEdit.Control.Leave, AddressOf DecimalEdit_LeaveFocus
                    AddHandler decEdit.Control.Enter, AddressOf DecimalEdit_Enter
                End If
            Next
        End If
    End Sub

    Private Sub GridView_ShowingEditor(sender As Object, e As CancelEventArgs)
        Dim gv As GridView = sender
        If gv IsNot Nothing AndAlso gv.FocusedColumn IsNot Nothing AndAlso gv.FocusedColumn.ColumnEdit IsNot Nothing AndAlso TypeOf gv.FocusedColumn.ColumnEdit Is RepositoryItemMyDecimalEdit Then
            Dim lv As DevExpress.ExpressApp.ListView = View
            Dim col As IModelColumn
            If lv IsNot Nothing AndAlso lv.Model IsNot Nothing AndAlso lv.Model.Columns IsNot Nothing Then
                col = lv.Model.Columns.Item(gv.FocusedColumn.FieldName)
                If col IsNot Nothing Then
                    e.Cancel = Not col.AllowEdit
                End If

            End If

        End If
    End Sub

    Private Sub PivotGridControl_CustomCellEditForEditing(sender As Object, e As PivotCustomCellEditEventArgs)
        If e.ColumnField IsNot Nothing AndAlso
            e.ColumnField.DataType Is GetType(Decimal) AndAlso
            e.ColumnField.FieldEdit IsNot Nothing AndAlso
             e.ColumnField.FieldEdit.EditorTypeName = "MyDecimalEdit" Then

            e.RepositoryItem = ri
        End If

    End Sub

    Private Sub GridView_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs)
        If e.Column IsNot Nothing AndAlso
            e.Column.ColumnType Is GetType(Decimal) AndAlso
             e.Column.ColumnEdit IsNot Nothing AndAlso
             e.Column.ColumnEdit.EditorTypeName = "MyDecimalEdit" Then


            e.RepositoryItem = ri

        End If
    End Sub

    ''' <summary>
    ''' Set cursor position to far right when flat decimal editor is shown. Setup for cursor positioning on key down and on click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GridView_ShownEditor(sender As Object, e As EventArgs)
        Dim gv As GridView = sender
        If gv.ActiveEditor IsNot Nothing AndAlso gv.ActiveEditor.EditorTypeName = "MyDecimalEdit" Then
            If TypeOf gv.ActiveEditor Is MyDecimalEdit Then
                Dim editor As MyDecimalEdit = gv.ActiveEditor
                AddHandler editor.MouseUp, AddressOf DecimalEdit_MouseUp
                AddHandler editor.Leave, AddressOf DecimalEdit_LeaveFocus
                editor.SelectAll()
                'SetCursorToRight(editor)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Set cursor position to far right when flat decimal editor is shown. Setup for cursor positioning on key down and on click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PivotGridControl_ShownEditor(sender As Object, e As EventArgs)
        Dim gv As GridView = sender
        If gv.ActiveEditor IsNot Nothing AndAlso gv.ActiveEditor.EditorTypeName = "MyDecimalEdit" Then
            If TypeOf gv.ActiveEditor Is MyDecimalEdit Then
                Dim editor As MyDecimalEdit = gv.ActiveEditor
                AddHandler editor.MouseUp, AddressOf DecimalEdit_MouseUp
                AddHandler editor.Leave, AddressOf DecimalEdit_LeaveFocus
                editor.SelectAll()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Select all on enter, mouse click moves cursor to right after method completes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DecimalEdit_Enter(sender As Object, e As EventArgs)
        If Not editorShown Then
            Dim editor As MyDecimalEdit = sender
            editor.SelectAll()
            AddHandler editor.Leave, AddressOf DecimalEdit_LeaveFocus
        End If
    End Sub

    ''' <summary>
    ''' Set editor shown to false. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DecimalEdit_LeaveFocus(sender As Object, e As EventArgs)
        editorShown = False
    End Sub

    ''' <summary>
    ''' Set cursor position to far right when flat decimal editor is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DecimalEdit_MouseUp(sender As Object, e As MouseEventArgs)
        If Not editorShown Then
            SetCursorToRight(sender)
            editorShown = True
        End If
    End Sub

    ''' <summary>
    ''' Set the editor's cursor position to far right.
    ''' </summary>
    ''' <param name="editor">Editor in which to apply</param>
    Private Sub SetCursorToRight(editor As MyDecimalEdit)
        editor.SelectionStart = editor.Text.Length
        editor.SelectionLength = 0
    End Sub

    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
        If TypeOf View Is DevExpress.ExpressApp.ListView Then
            Dim lv As DevExpress.ExpressApp.ListView = View
            If lv.Editor IsNot Nothing AndAlso TypeOf lv.Editor Is GridListEditor Then
                Dim gv As GridView = CType(lv.Editor, GridListEditor).GridView
                If gv IsNot Nothing Then
                    RemoveHandler gv.CustomRowCellEditForEditing, AddressOf GridView_CustomRowCellEditForEditing
                    RemoveHandler gv.MouseDown, AddressOf GridView_ShownEditor
                End If
            ElseIf TypeOf lv.Editor Is PivotGridListEditor Then
                Dim editor As PivotGridListEditor = lv.Editor
                If editor IsNot Nothing AndAlso editor.PivotGridControl IsNot Nothing Then
                    RemoveHandler editor.PivotGridControl.CustomCellEditForEditing, AddressOf PivotGridControl_CustomCellEditForEditing
                    RemoveHandler editor.PivotGridControl.ShownEditor, AddressOf PivotGridControl_ShownEditor
                End If
            End If
        ElseIf TypeOf View Is DevExpress.ExpressApp.DetailView Then
            Dim dv As DetailView = View
            For Each decEdit In dv.GetItems(Of FlatDecimalPropertyEditor)()
                If decEdit.Control IsNot Nothing Then
                    RemoveHandler decEdit.Control.MouseUp, AddressOf DecimalEdit_MouseUp
                    RemoveHandler decEdit.Control.Leave, AddressOf DecimalEdit_LeaveFocus
                End If
            Next
        End If
    End Sub
End Class
