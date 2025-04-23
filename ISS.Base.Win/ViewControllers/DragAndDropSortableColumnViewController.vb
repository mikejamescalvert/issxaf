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
Imports ISS.Base.Attributes
Imports DevExpress.Utils.Behaviors
Imports DevExpress.Utils.DragDrop
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid
Imports DevExpress.Xpo

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class DragAndDropSortableColumnViewController
    Inherits ViewController

    Private _mBehaviorManager As BehaviorManager

    Public Sub New()
        InitializeComponent()
        TargetViewType = ViewType.ListView


        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub


    Public ReadOnly Property ListView As DevExpress.ExpressApp.ListView
        Get
            Return View
        End Get
    End Property

    Public ReadOnly Property GridListEditor As GridListEditor
        Get
            If ListView Is Nothing Then
                Return Nothing
            End If
            Return TryCast(ListView.Editor, GridListEditor)
        End Get
    End Property

    Private _mDragAndDropSortableColumnAttributeInstance As Attribute
    Public ReadOnly Property DragAndDropSortableColumnAttributeInstance As DragAndDropSortableColumnAttribute
        Get
            If _mDragAndDropSortableColumnAttributeInstance Is Nothing AndAlso ListView IsNot Nothing AndAlso ListView.ObjectTypeInfo IsNot Nothing Then
                _mDragAndDropSortableColumnAttributeInstance = ListView.ObjectTypeInfo.FindAttribute(Of DragAndDropSortableColumnAttribute)
            End If
            Return _mDragAndDropSortableColumnAttributeInstance
        End Get
    End Property


    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()



        ' Perform various tasks depending on the target View.
        DragAndDropSort_EnableResequencing.Active("Editable") = (View.AllowEdit = True)
        DragAndDropSort_EnableResequencing.Active("DragAndDropAllowed") = (DragAndDropSortableColumnAttributeInstance IsNot Nothing)
        DragAndDropSort_MoveRecordDown.Active("DragAndDropAllowed") = (DragAndDropSortableColumnAttributeInstance IsNot Nothing)
        DragAndDropSort_MoveRecordUp.Active("DragAndDropAllowed") = (DragAndDropSortableColumnAttributeInstance IsNot Nothing)
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        If DragAndDropSortableColumnAttributeInstance Is Nothing Then
            Return
        End If

        If GridListEditor IsNot Nothing AndAlso
            GridListEditor.GridView IsNot Nothing Then

            _mBehaviorManager = New BehaviorManager
            GridListEditor.GridView.GridControl.AllowDrop = False
            _mBehaviorManager.Attach(Of DragDropBehavior)(GridListEditor.GridView, Sub(behavior)
                                                                                       behavior.Properties.AllowDrop = True
                                                                                       behavior.Properties.InsertIndicatorVisible = True
                                                                                       behavior.Properties.PreviewVisible = True

                                                                                       AddHandler behavior.DragOver, AddressOf HandelDragOver
                                                                                       AddHandler behavior.DragDrop, AddressOf HandleDragDrop
                                                                                   End Sub)


            'AddHandler GridListEditor.GridView.EndSorting, AddressOf GridView_SortingChanged
            AddHandler GridListEditor.GridView.PopupMenuShowing, AddressOf GridView_PopupShowing
        End If
        'SetupGridForSorting()



        ' Access and customize the target View control.
    End Sub


    Private Sub HandelDragOver(sender As Object, e As DragOverEventArgs)
        Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
        e.InsertType = args.InsertType
        e.InsertIndicatorLocation = args.InsertIndicatorLocation
        e.Action = args.Action
        Cursor.Current = args.Cursor
        args.Handled = True
    End Sub

    Private Sub HandleDragDrop(sender As Object, e As DragDropEventArgs)
        Dim targetGrid As GridView = TryCast(e.Target, GridView)
        Dim sourceGrid As GridView = TryCast(e.Source, GridView)
        If e.Action = DragDropActions.None OrElse targetGrid IsNot sourceGrid Then
            Return
        End If

        DoDragDrop(sender, e)

        'Dim TargetProperty As String = ListView.Model.GetValue(Of String)("GridDragDropRowPositioningIndexProperty")
        'Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        'Dim hitInfo As GridHitInfo = targetGrid.CalcHitInfo(hitPoint)
        'Dim key As Object = targetGrid.GetRowCellValue(CType(e.Data, Integer())(0), "Oid")
        'If ListView.Model.ModelClass.FindMember(TargetProperty).MemberInfo.MemberTypeInfo.FullName = "System.Double" Then
        '    Dim targetIndex As Double = DirectCast(targetGrid.GetRowCellValue(hitInfo.RowHandle, TargetProperty), Double)
        '    UpdateIndexOrder(key, targetIndex, targetGrid)
        'Else
        '    Dim targetIndex As Integer = DirectCast(targetGrid.GetRowCellValue(hitInfo.RowHandle, TargetProperty), Integer)
        '    UpdateIndexOrder(key, targetIndex, targetGrid)
        'End If


    End Sub

    Private Sub GridView_PopupShowing(sender As Object, e As PopupMenuShowingEventArgs)
        Dim rowMenu As DevExpress.XtraGrid.Menu.GridViewMenu
        If e.MenuType = GridMenuType.Column Then
            rowMenu = TryCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewMenu)
            If rowMenu IsNot Nothing Then
                If DragAndDropSort_EnableResequencing.Active = True Then
                    rowMenu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem(DragAndDropSort_EnableResequencing.Caption, AddressOf MenuItem_HandleClick))
                    rowMenu.Items(rowMenu.Items.Count - 1).BeginGroup = True
                End If
                If DragAndDropSort_MoveRecordUp.Active = True Then
                    rowMenu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem(DragAndDropSort_MoveRecordUp.Caption, AddressOf MenuItem_HandleClick))
                End If
                If DragAndDropSort_MoveRecordDown.Active = True Then
                    rowMenu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem(DragAndDropSort_MoveRecordDown.Caption, AddressOf MenuItem_HandleClick))
                End If

            End If
        End If
    End Sub

    Private Sub MenuItem_HandleClick(sender As Object, e As EventArgs)
        Select Case CType(sender, DevExpress.Utils.Menu.DXMenuItem).Caption
            Case DragAndDropSort_EnableResequencing.Caption
                DragAndDropSort_EnableResequencing.DoExecute()
            Case DragAndDropSort_MoveRecordUp.Caption
                DragAndDropSort_MoveRecordUp.DoExecute()
            Case DragAndDropSort_MoveRecordDown.Caption
                DragAndDropSort_MoveRecordDown.DoExecute()
        End Select
    End Sub

    'Public Sub SetupGridForSorting()
    '    If GridListEditor Is Nothing OrElse GridListEditor.GridView Is Nothing OrElse ListView.AllowEdit = True Then
    '        Return
    '    End If

    '    If GridListEditor.GridView.SortedColumns.Count = 1 AndAlso
    '        DragAndDropSortableColumnAttributeInstance.SortedColumnName = GridListEditor.GridView.SortedColumns(0).FieldName Then


    '        AddHandler GridListEditor.Grid.DragEnter, AddressOf GridControl_DragEnter
    '        AddHandler GridListEditor.Grid.DragDrop, AddressOf GridControl_DragDrop

    '        AddHandler GridListEditor.Grid.MouseMove, AddressOf GridControl_MouseMove
    '        AddHandler GridListEditor.Grid.MouseDown, AddressOf GridControl_MouseDown


    '    Else
    '        If GridListEditor IsNot Nothing AndAlso GridListEditor.Grid IsNot Nothing Then
    '            RemoveHandler GridListEditor.Grid.DragEnter, AddressOf GridControl_DragEnter
    '            RemoveHandler GridListEditor.Grid.DragDrop, AddressOf GridControl_DragDrop


    '            AddHandler GridListEditor.Grid.MouseMove, AddressOf GridControl_MouseMove
    '            AddHandler GridListEditor.Grid.MouseDown, AddressOf GridControl_MouseDown

    '        End If



    '    End If

    'End Sub

    Private Sub GridControl_MouseMove(sender As Object, e As MouseEventArgs)
        Dim grid As GridControl = TryCast(sender, GridControl)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width \ 2, downHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)
            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                grid.DoDragDrop(CType(grid.FocusedView, GridView).GetSelectedRows, DragDropEffects.All)
                downHitInfo = Nothing
            End If
        End If
    End Sub

    Private downHitInfo As GridHitInfo
    Private Sub GridControl_MouseDown(sender As Object, e As MouseEventArgs)
        Dim grid As GridControl = TryCast(sender, GridControl)
        downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = CType(grid.FocusedView, GridView).CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    'Private Sub GridView_SortingChanged(sender As Object, e As EventArgs)
    '    'SetupGridForSorting()


    'End Sub

    'Private Sub GridControl_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs)

    '    If ListView.CollectionSource.AllowAdd = False Then
    '        e.Effect = System.Windows.Forms.DragDropEffects.None
    '        Return
    '    End If



    '    If e.Data.GetDataPresent("System.Int32[]") = True Then
    '        Dim hitPoint = GridListEditor.Grid.PointToClient(Cursor.Position)

    '        Dim hitInfo As GridHitInfo = GridListEditor.GridView.CalcHitInfo(hitPoint)
    '        If hitInfo.InDataRow = False Then
    '            e.Effect = System.Windows.Forms.DragDropEffects.None
    '            Return
    '        End If


    '        Dim objData As Integer() = e.Data.GetData("System.Int32[]")
    '        If objData.Length = 0 Then
    '            e.Effect = System.Windows.Forms.DragDropEffects.None
    '            Return
    '        End If

    '        e.Effect = System.Windows.Forms.DragDropEffects.Move
    '    End If


    'End Sub

    Public Sub DoDragDrop(sender As Object, e As DragDropEventArgs)
        Dim hitPoint = GridListEditor.Grid.PointToClient(Cursor.Position)
        Dim objSelectedRow As Object
        Dim hitInfo As GridHitInfo = GridListEditor.GridView.CalcHitInfo(hitPoint)
        Dim intStartRowIndex As Integer = GridListEditor.GridView.DataRowCount
        Dim lstObjects As New List(Of Object)
        Dim lstNewOrderedObjects As New List(Of Object)


        objSelectedRow = GridListEditor.GridView.GetRow(hitInfo.RowHandle)

        Dim objData As Integer() = e.Data


        For Each intData In objData
            lstObjects.Add(GridListEditor.GridView.GetRow(intData))
            If intData < intStartRowIndex Then
                intStartRowIndex = intData
            End If
        Next


        For intLoop As Integer = 0 To GridListEditor.GridView.RowCount - 1
            If GridListEditor.GridView.IsDataRow(intLoop) AndAlso
                objData.Contains(intLoop) = False AndAlso
                lstObjects.Contains(GridListEditor.GridView.GetRow(intLoop)) = False Then
                lstNewOrderedObjects.Add(GridListEditor.GridView.GetRow(intLoop))

            End If
        Next
        If hitInfo.RowHandle >= intStartRowIndex Then
            lstNewOrderedObjects.InsertRange(lstNewOrderedObjects.IndexOf(objSelectedRow) + 1, lstObjects)
        Else
            lstNewOrderedObjects.InsertRange(lstNewOrderedObjects.IndexOf(objSelectedRow), lstObjects)
        End If


        For intLoop As Integer = 1 To lstNewOrderedObjects.Count
            If ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).MemberType Is GetType(Double) Then
                ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(lstNewOrderedObjects(intLoop - 1), CType(intLoop, Double))
            Else
                ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(lstNewOrderedObjects(intLoop - 1), intLoop)
            End If

        Next

    End Sub

    'Private Sub GridControl_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)
    '    Dim hitPoint = GridListEditor.Grid.PointToClient(Cursor.Position)
    '    Dim objSelectedRow As Object
    '    Dim hitInfo As GridHitInfo = GridListEditor.GridView.CalcHitInfo(hitPoint)
    '    Dim intRowHandle As Integer
    '    Dim intStartRowIndex As Integer = GridListEditor.GridView.DataRowCount
    '    Dim lstObjects As New List(Of Object)
    '    Dim lstNewOrderedObjects As New List(Of Object)
    '    If hitInfo.InDataRow = False Then
    '        e.Effect = System.Windows.Forms.DragDropEffects.None
    '        Return
    '    End If


    '    objSelectedRow = GridListEditor.GridView.GetRow(hitInfo.RowHandle)


    '    Dim objData As Integer() = e.Data.GetData("System.Int32[]")

    '    For Each intData In objData
    '        lstObjects.Add(GridListEditor.GridView.GetRow(intData))
    '        If intData < intStartRowIndex Then
    '            intStartRowIndex = intData
    '        End If
    '    Next

    '    For intLoop As Integer = 0 To GridListEditor.GridView.RowCount - 1
    '        If GridListEditor.GridView.IsDataRow(intLoop) AndAlso
    '            objData.Contains(intLoop) = False AndAlso
    '            lstObjects.Contains(GridListEditor.GridView.GetRow(intLoop)) = False Then
    '            lstNewOrderedObjects.Add(GridListEditor.GridView.GetRow(intLoop))

    '        End If
    '    Next
    '    If hitInfo.RowHandle >= intStartRowIndex Then
    '        lstNewOrderedObjects.InsertRange(lstNewOrderedObjects.IndexOf(objSelectedRow) + 1, lstObjects)
    '    Else
    '        lstNewOrderedObjects.InsertRange(lstNewOrderedObjects.IndexOf(objSelectedRow), lstObjects)
    '    End If


    '    For intLoop As Integer = 1 To lstNewOrderedObjects.Count
    '        ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(lstNewOrderedObjects(intLoop - 1), intLoop)
    '    Next



    '    'For Each intData In objData
    '    '    lstSelectedObjects.Add(intData, GridListEditor.GridView.GetRow(intData))
    '    '    If intData < intStartRowIndex Then
    '    '        intStartRowIndex = intData
    '    '    End If
    '    'Next

    '    'Dim intStartingValue As Integer

    '    'If hitInfo.RowHandle < intStartRowIndex Then
    '    '    'moving cells up
    '    '    intStartingValue = hitInfo.RowHandle+1

    '    '    For intLoop As Integer = 0 To GridListEditor.GridView.DataRowCount - 1
    '    '        intRowHandle = GridListEditor.GridView.GetRowHandle(intLoop)
    '    '        If intRowHandle >= hitInfo.RowHandle AndAlso
    '    '            lstSelectedObjects.Keys.Contains(intRowHandle) = False Then
    '    '            lstAffectedObjects.Add(intRowHandle, GridListEditor.GridView.GetRow(intRowHandle))
    '    '        End If
    '    '    Next

    '    '    'renumber selected rows
    '    '    For Each obj In lstSelectedObjects.OrderBy(Function(m) m.Key)
    '    '        ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(obj.Value, intStartingValue)
    '    '        intStartingValue += 1
    '    '    Next
    '    '    'renumber rows after selected rows
    '    '    For Each obj In lstAffectedObjects.OrderBy(Function(m) m.Key)
    '    '        ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(obj.Value, intStartingValue)
    '    '        intStartingValue += 1
    '    '    Next

    '    'Else
    '    '    'moving cells down
    '    '    intStartingValue = intStartRowIndex + 1


    '    '    For intLoop As Integer = 0 To GridListEditor.GridView.DataRowCount - 1
    '    '        intRowHandle = GridListEditor.GridView.GetRowHandle(intLoop)
    '    '        If intRowHandle >= intStartingValue AndAlso
    '    '            lstSelectedObjects.Keys.Contains(intRowHandle) = False Then
    '    '            lstAffectedObjects.Add(intRowHandle, GridListEditor.GridView.GetRow(intRowHandle))
    '    '        End If
    '    '    Next

    '    '    'renumber rows after selected rows
    '    '    For Each obj In lstAffectedObjects.OrderBy(Function(m) m.Key)
    '    '        If (intStartingValue = hitInfo.RowHandle + 1) Or
    '    '            ((hitInfo.RowHandle = GridListEditor.GridView.DataRowCount) And (intStartingValue = hitInfo.RowHandle)) Then

    '    '            'renumber selected rows
    '    '            For Each objSelected In lstSelectedObjects.OrderBy(Function(m) m.Key)
    '    '                ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(objSelected.Value, intStartingValue)
    '    '                intStartingValue += 1
    '    '            Next
    '    '        End If
    '    '        ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(obj.Value, intStartingValue)
    '    '        intStartingValue += 1

    '    '    Next



    '    'End If




    '    'todo: read through all rows and change their positions as necessary
    '    ListView.CollectionSource.ObjectSpace.CommitChanges()

    'End Sub

    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub DragAndDropSort_MoveRecordDown_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles DragAndDropSort_MoveRecordDown.Execute
        Dim intStartingValue As Integer = GridListEditor.GridView.DataRowCount + 10
        Dim intRowHandle As Integer
        Dim lstSelectedObjects As New Dictionary(Of Integer, Object)
        Dim lstAffectedObjects As New Dictionary(Of Integer, Object)
        Dim lstObjects As New List(Of Integer)
        Dim intCurrentValue As Integer

        Dim xpoCurrentObject As Object = Nothing
        Dim xpoNextObject As Object = Nothing

        For intLoop As Integer = 0 To GridListEditor.GridView.DataRowCount - 1
            intRowHandle = GridListEditor.GridView.GetRowHandle(intLoop)
            If View.CurrentObject Is GridListEditor.GridView.GetRow(intRowHandle) AndAlso
                intLoop < GridListEditor.GridView.DataRowCount - 1 Then
                xpoNextObject = GridListEditor.GridView.GetRow(intRowHandle + 1)
            End If
        Next

        xpoCurrentObject = View.CurrentObject

        If xpoNextObject IsNot Nothing AndAlso xpoCurrentObject IsNot Nothing Then
            intCurrentValue = ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).GetValue(xpoCurrentObject)
            ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(xpoCurrentObject, intCurrentValue + 1)
            ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(xpoNextObject, intCurrentValue)
        End If
        ListView.CollectionSource.ObjectSpace.CommitChanges()

    End Sub

    Private Sub DragAndDropSort_MoveRecordUp_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles DragAndDropSort_MoveRecordUp.Execute
        Dim intStartingValue As Integer = GridListEditor.GridView.DataRowCount + 10
        Dim intRowHandle As Integer
        Dim lstSelectedObjects As New Dictionary(Of Integer, Object)
        Dim lstAffectedObjects As New Dictionary(Of Integer, Object)
        Dim lstObjects As New List(Of Integer)
        Dim intCurrentValue As Integer

        Dim xpoCurrentObject As Object = Nothing
        Dim xpoNextObject As Object = Nothing

        For intLoop As Integer = 0 To GridListEditor.GridView.DataRowCount - 1
            intRowHandle = GridListEditor.GridView.GetRowHandle(intLoop)
            If View.CurrentObject Is GridListEditor.GridView.GetRow(intRowHandle) AndAlso
                intLoop > 0 Then
                xpoNextObject = GridListEditor.GridView.GetRow(intRowHandle - 1)
            End If
        Next

        xpoCurrentObject = View.CurrentObject

        If xpoNextObject IsNot Nothing AndAlso xpoCurrentObject IsNot Nothing Then
            intCurrentValue = ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).GetValue(xpoCurrentObject)
            ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(xpoCurrentObject, intCurrentValue - 1)
            ListView.ObjectTypeInfo.FindMember(DragAndDropSortableColumnAttributeInstance.SortedColumnName).SetValue(xpoNextObject, intCurrentValue)
        End If

        ListView.CollectionSource.ObjectSpace.CommitChanges()
    End Sub

    Private Sub DragAndDropSort_EnableResequencing_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles DragAndDropSort_EnableResequencing.Execute
        If View.AllowEdit = True Then
            View.AllowEdit("Sequencing") = False
            DragAndDropSort_EnableResequencing.Caption = "Disable Resequencing"
        Else
            View.AllowEdit("Sequencing") = True
            DragAndDropSort_EnableResequencing.Caption = "Enable Resequencing"
        End If
    End Sub
End Class
