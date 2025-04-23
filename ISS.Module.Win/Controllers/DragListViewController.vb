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
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class DragListViewController
    Inherits ViewController(Of DevExpress.ExpressApp.ListView)
    Public Sub New()
        InitializeComponent()
        TargetViewType = ViewType.ListView
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Private WithEvents gridView1 As GridView
    Private WithEvents gridControl1 As GridControl
    Private WithEvents timer1 As New System.Windows.Forms.Timer
    Private groupRowHandle As Integer = GridControl.InvalidRowHandle
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        Dim lpe As GridListEditor = View.Editor
        gridView1 = lpe.GridView
        gridControl1 = lpe.Grid
        gridControl1.AllowDrop = True
        gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        gridView1.OptionsSelection.MultiSelect = True

        ' Access and customize the target View control.
    End Sub
    Private dragRectangle As New Rectangle(Point.Empty, SystemInformation.DragSize)
    Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridView1.MouseDown
        Dim view As GridView = CType(sender, GridView)
        If view.GroupCount = 0 Then
            Return
        End If
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(e.Location)
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRowCell Then
            dragRectangle.Location = e.Location
        Else
            dragRectangle.Location = Point.Empty
        End If
    End Sub

    Private Sub gridView1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridView1.MouseMove
        Dim view As GridView = CType(sender, GridView)
        If e.Button = MouseButtons.Left AndAlso dragRectangle.Location <> Point.Empty AndAlso (Not dragRectangle.Contains(e.Location)) Then
            Dim data() As Integer = view.GetSelectedRows()
            For i As Integer = 0 To data.Length - 1
                data(i) = view.GetDataSourceRowIndex(data(i))
            Next i
            view.GridControl.DoDragDrop(data, DragDropEffects.Move)
        End If
    End Sub

    Private Sub gridControl1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles gridControl1.DragOver
        Dim control As GridControl = CType(sender, GridControl)
        Dim view As GridView = CType(control.DefaultView, GridView)
        Dim info As GridHitInfo = view.CalcHitInfo(control.PointToClient(New Point(e.X, e.Y)))
        If info.InRowCell Then
            e.Effect = DragDropEffects.Move
        Else
            If info.InRow AndAlso view.IsGroupRow(info.RowHandle) Then
                groupRowHandle = info.RowHandle
                timer1.Start()
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Sub gridControl1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles gridControl1.DragDrop
        If e.Data IsNot Nothing AndAlso e.Effect = DragDropEffects.Move Then
            Dim control As GridControl = CType(sender, GridControl)
            Dim view As GridView = CType(control.DefaultView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(control.PointToClient(New Point(e.X, e.Y)))
            MoveRows(info.RowHandle, view, CType(e.Data.GetData(GetType(Integer())), Integer()), view.GetRowLevel(info.RowHandle))
            ObjectSpace.CommitChanges()
            view.RefreshData()
        End If
    End Sub

    Private Sub MoveRows(ByVal target As Integer, ByVal gridView As GridView, ByVal rows() As Integer, ByVal level As Integer)
        Dim col As GridColumn = gridView.GroupedColumns(level - 1)
        Dim val As Object = Nothing

        If gridView.IsDataRow(target) Then
            'grab value from target's group by data row
            val = gridView.GetRowCellValue(target, col)
        ElseIf gridView.IsGroupRow(target) Then
            'grab group's value
            val = gridView.GetGroupRowValue(target)
        End If


        For Each row As Integer In rows
            Dim rowHandle As Integer = gridView.GetRowHandle(row)
            gridView.SetRowCellValue(rowHandle, col, val)
        Next row
        If level > 0 Then
            level -= 1
            MoveRows(target, gridView, rows, level)
        End If
    End Sub
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        CType(sender, Timer).Stop()
        'If groupRowHandle <> GridControl.InvalidRowHandle Then
        '    gridView1.CollapseAllGroups()
        '    gridView1.ExpandGroupRow(groupRowHandle)
        '    groupRowHandle = GridControl.InvalidRowHandle
        'End If
    End Sub

    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub
End Class
