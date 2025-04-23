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
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.ViewInfo
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.ExpressApp.ConditionalAppearance
Imports DevExpress
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.ExpressApp.StateMachine

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class EditorOptionsListViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.ListView
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub

    Public ReadOnly Property ListView As ListView
        Get
            Return TryCast(View, ListView)
        End Get
    End Property

    Public ReadOnly Property GridListEditor As GridListEditor
        Get

            Return TryCast(ListView.Editor, GridListEditor)
        End Get
    End Property

    Public ReadOnly Property EditorOptions As IModelExtension
        Get
            Return TryCast(Application.Model, IModelExtension)
        End Get
    End Property

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        ' Perform various tasks depending on the target View.
    End Sub


    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()


        If GridListEditor IsNot Nothing AndAlso GridListEditor.GridView IsNot Nothing Then
            With GridListEditor.GridView
                .Appearance.EvenRow.BackColor = System.Drawing.Color.Ivory
                .Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGoldenrodYellow
                .Appearance.FocusedCell.Font = New System.Drawing.Font(GridListEditor.GridView.Appearance.FocusedCell.Font, System.Drawing.FontStyle.Bold)
                If .FocusedColumn IsNot Nothing Then
                    .FocusedColumn.AppearanceHeader.Font = New System.Drawing.Font(GridListEditor.GridView.FocusedColumn.AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
                End If
                AddHandler GridListEditor.GridView.FocusedColumnChanged, AddressOf HandleFocusedColumnChanged
            End With
        End If

        If EditorOptions.ISSEditorOptions.GridClickMode = IModelISSEditorOptions.AcceleratedMode.SingleClick AndAlso ListView.AllowEdit = True Then

            If GridListEditor IsNot Nothing AndAlso GridListEditor.GridView IsNot Nothing Then

                AddHandler GridListEditor.GridView.MouseDown, AddressOf GridView_MouseDown
                AddHandler GridListEditor.GridView.MouseUp, AddressOf GridView_MouseUp

                GridListEditor.GridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
                GridListEditor.GridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown

                AddHandler GridListEditor.GridView.ShownEditor, AddressOf Grid_ShowEditor
                AddHandler GridListEditor.GridView.FocusedRowChanged, AddressOf HandleFocusedRowChanged
                AddHandler GridListEditor.GridView.CellValueChanged, AddressOf HandleCellValueChanged
                For Each oColumn In GridListEditor.GridView.Columns
                    If TypeOf oColumn Is DevExpress.XtraGrid.Columns.GridColumn Then
                        ProcessGridColumn(oColumn)
                    End If
                Next
                'With GridListEditor.GridView
                '    .Appearance.EvenRow.BackColor = System.Drawing.Color.Ivory
                '    .Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGoldenrodYellow
                '    .Appearance.FocusedCell.Font = New System.Drawing.Font(GridListEditor.GridView.Appearance.FocusedCell.Font, System.Drawing.FontStyle.Bold)
                '    If .FocusedColumn IsNot Nothing Then
                '        .FocusedColumn.AppearanceHeader.Font = New System.Drawing.Font(GridListEditor.GridView.FocusedColumn.AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
                '    End If

                'End With

            End If
        End If

        LayoutGridColumns()
        ' Access and customize the target View control.
    End Sub

    Private _mMouseDown As Boolean
    Private _mEditorLoaded As Boolean

    Private Sub GridView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        _mMouseDown = False
        _mEditorLoaded = False

        Dim blnProcessEditorClick As Boolean = False
        'HWR 08/05/2024 added check for null focused column
        If GridListEditor.GridView.FocusedColumn Is Nothing Then
            Return
        End If

        If TypeOf GridListEditor.GridView.FocusedColumn.ColumnEdit Is Repository.RepositoryItemPopupBase Then
            Dim edit As PopupBaseEdit = TryCast(GridListEditor.GridView.ActiveEditor, PopupBaseEdit)
            If edit Is Nothing Then
                Return
            End If
            Dim ViewInfo As ButtonEditViewInfo = edit.GetViewInfo()
            Dim hi As EditHitInfo = ViewInfo.CalcHitInfo(edit.PointToClient(System.Windows.Forms.Cursor.Position))
            If hi.HitTest = EditHitTest.Button Then
                blnProcessEditorClick = True
            End If
        ElseIf TypeOf GridListEditor.GridView.FocusedColumn.ColumnEdit Is Repository.RepositoryItemCheckEdit Then
            Dim edit As BaseCheckEdit = TryCast(GridListEditor.GridView.ActiveEditor, BaseCheckEdit)
            If edit Is Nothing Then
                Return
            End If
            Dim ViewInfo As CheckEditViewInfo = edit.GetViewInfo()
            Dim hi As EditHitInfo = ViewInfo.CalcHitInfo(edit.PointToClient(System.Windows.Forms.Cursor.Position))


            If hi.IsInEdit = True Then
                blnProcessEditorClick = True
            End If
        End If

        If blnProcessEditorClick = False Then
            Return
        End If

        If _mEditorPopupToOpen IsNot Nothing Then

            If GridListEditor.GridView.IsNewItemRow(GridListEditor.GridView.FocusedRowHandle) Then
                GridListEditor.GridView.EnsureRowLoaded(GridListEditor.GridView.FocusedRowHandle, New DevExpress.Data.OperationCompleted(Sub(m)

                                                                                                                                             _mEditorPopupToOpen.ShowPopup()
                                                                                                                                         End Sub))
            Else
                _mEditorPopupToOpen.ShowPopup()
            End If
            _mEditorPopupToOpen = Nothing
        End If

        If _mEditorCheckboxToCheck IsNot Nothing Then

            If GridListEditor.GridView.IsNewItemRow(GridListEditor.GridView.FocusedRowHandle) Then

                GridListEditor.GridView.EnsureRowLoaded(GridListEditor.GridView.FocusedRowHandle, New DevExpress.Data.OperationCompleted(Sub(m)
                                                                                                                                             _mEditorCheckboxToCheck.EditValue = True
                                                                                                                                         End Sub))
            Else
                _mEditorCheckboxToCheck.EditValue = Not _mEditorCheckboxToCheck.EditValue
            End If
            _mEditorCheckboxToCheck = Nothing
        End If


    End Sub

    Private Sub GridView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        _mMouseDown = True


    End Sub

    Private Sub HandleCellValueChanged(sender As Object, e As CellValueChangedEventArgs)
        LayoutGridColumns()
    End Sub


    Protected Overrides Sub OnDeactivated()

        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
        If GridListEditor IsNot Nothing AndAlso GridListEditor.GridView IsNot Nothing Then
            RemoveHandler GridListEditor.GridView.ShownEditor, AddressOf Grid_ShowEditor
            RemoveHandler GridListEditor.GridView.FocusedColumnChanged, AddressOf HandleFocusedColumnChanged
            RemoveHandler GridListEditor.GridView.FocusedRowChanged, AddressOf HandleFocusedRowChanged

        End If

    End Sub

    Public Sub ProcessGridColumn(ByRef Column As DevExpress.XtraGrid.Columns.GridColumn)
        Dim blnDisableSpins As Boolean = EditorOptions.ISSEditorOptions.DisableSpinButtons
        Dim blnEnableNegativeNumber As Boolean = EditorOptions.ISSEditorOptions.DisableNegativeNumberEntry
        Dim strPropertyName As String = GridListEditor.FindColumnPropertyName(Column)
        Dim clmSpinEdit As RepositoryItemSpinEdit
        Dim rsiButtonEditor As RepositoryItemButtonEdit
        Dim mdl As IModelColumnExtension = ListView.Model.Columns.FirstOrDefault(Function(m) m.PropertyName = strPropertyName)
        If mdl Is Nothing Then
            Return
        End If

        If mdl.AllowEdit = False Then
            'hide column buttons for editors that are disabled
            rsiButtonEditor = TryCast(Column.ColumnEdit, RepositoryItemButtonEdit)
            If rsiButtonEditor IsNot Nothing Then

                For intLoop As Integer = rsiButtonEditor.Buttons.Count - 1 To 0 Step -1
                    rsiButtonEditor.Buttons(intLoop).Visible = False
                Next
            End If
        End If



        If mdl.DisableSpinButton.HasValue = True AndAlso mdl.DisableSpinButton = False Then
            blnDisableSpins = False
        End If
        If mdl.DisableNegativeNumberEntry.HasValue = True AndAlso mdl.DisableNegativeNumberEntry = False Then
            blnEnableNegativeNumber = False
        End If
        clmSpinEdit = TryCast(Column.ColumnEdit, RepositoryItemSpinEdit)
        If clmSpinEdit IsNot Nothing Then
            If blnDisableSpins = True Then
                DisableSpinButtonInButtonCollection(clmSpinEdit.Buttons)
            End If
            If blnEnableNegativeNumber = True Then
                clmSpinEdit.MinValue = 0
                clmSpinEdit.MaxValue = Int32.MaxValue
            End If
        End If

    End Sub

    Public Sub DisableSpinButtonInButtonCollection(ByRef ButtonCollection As DevExpress.XtraEditors.Controls.EditorButtonCollection)
        For intLoop As Integer = ButtonCollection.Count - 1 To 0 Step -1
            If ButtonCollection(intLoop).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Combo Then
                ButtonCollection(intLoop).Visible = False
            End If
        Next
    End Sub

    Private _mEditorPopupToOpen As PopupBaseEdit = Nothing
    Private _mEditorCheckboxToCheck As BaseCheckEdit = Nothing

    Private Sub Grid_ShowEditor(sender As Object, e As EventArgs)
        If EditorOptions.ISSEditorOptions.GridClickMode = IModelISSEditorOptions.AcceleratedMode.DoubleClick Then
            Return
        End If
        If _mEditorLoaded = False Then
            _mEditorLoaded = True
        Else
            Return
        End If


        If TypeOf GridListEditor.GridView.FocusedColumn Is DevExpress.XtraGrid.Columns.GridColumn Then
            ProcessGridColumn(GridListEditor.GridView.FocusedColumn)
        End If

        'todo: if editor is readonly, hide buttons

        If TypeOf GridListEditor.GridView.FocusedColumn.ColumnEdit Is Repository.RepositoryItemPopupBase Then

            'GridListEditor.GridView.RefreshEditor(True)
            Dim edit As PopupBaseEdit = TryCast(GridListEditor.GridView.ActiveEditor, PopupBaseEdit)
            If edit Is Nothing Then
                Return
            End If
            Dim button As EditorButton
            Dim ViewInfo As ButtonEditViewInfo = edit.GetViewInfo()
            Dim hi As EditHitInfo = ViewInfo.CalcHitInfo(edit.PointToClient(System.Windows.Forms.Cursor.Position))
            If hi.HitTest = EditHitTest.Button Then
                button = CType(hi.HitObject, DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs).Button
                Select Case button.Kind
                    Case ButtonPredefines.Combo, ButtonPredefines.Ellipsis, ButtonPredefines.DropDown
                        If edit.IsPopupOpen = False Then

                            _mEditorPopupToOpen = edit
                            'If GridListEditor.GridView.IsNewItemRow(GridListEditor.GridView.FocusedRowHandle) Then
                            '    GridListEditor.GridView.EnsureRowLoaded(GridListEditor.GridView.FocusedRowHandle, New DevExpress.Data.OperationCompleted(Sub(m)

                            '                                                                                                                                 edit.ShowPopup()
                            '                                                                                                                             End Sub))
                            'Else
                            '    edit.ShowPopup()
                            'End If

                            'If _mRowChanging = False Then
                            '    edit.ShowPopup()
                            'End If


                            'edit.ShowPopup()
                        End If


                    Case ButtonPredefines.Delete
                        edit.EditValue = Nothing
                End Select
            End If
        ElseIf TypeOf GridListEditor.GridView.FocusedColumn.ColumnEdit Is Repository.RepositoryItemCheckEdit Then
            Dim edit As BaseCheckEdit = TryCast(GridListEditor.GridView.ActiveEditor, BaseCheckEdit)
            If edit Is Nothing Then
                Return
            End If
            Dim ViewInfo As CheckEditViewInfo = edit.GetViewInfo()
            Dim hi As EditHitInfo = ViewInfo.CalcHitInfo(edit.PointToClient(System.Windows.Forms.Cursor.Position))


            If hi.IsInEdit = True Then
                _mEditorCheckboxToCheck = edit

                'If GridListEditor.GridView.IsNewItemRow(GridListEditor.GridView.FocusedRowHandle) Then

                '    GridListEditor.GridView.EnsureRowLoaded(GridListEditor.GridView.FocusedRowHandle, New DevExpress.Data.OperationCompleted(Sub(m)
                '                                                                                                                                 edit.EditValue = True
                '                                                                                                                             End Sub))
                'Else
                '    edit.EditValue = Not edit.EditValue
                'End If


            End If

        End If

    End Sub

    Private Sub LayoutGridColumns()
        Dim blnResult As Boolean?
        Dim typListViewType As Type = Nothing
        If GridListEditor Is Nothing OrElse GridListEditor.GridView Is Nothing Then
            Return
        End If
        'todo: for each cell in grid, check if disabled and change color
        For Each objColumn As GridColumn In GridListEditor.GridView.Columns
            If IsColumnDisabled(View.CurrentObject, objColumn.FieldName) = False Then
                objColumn.OptionsColumn.AllowFocus = True
                objColumn.AppearanceHeader.ForeColor = Nothing
            Else
                objColumn.OptionsColumn.AllowFocus = False
                objColumn.AppearanceHeader.ForeColor = Drawing.Color.Gray
            End If
            If View IsNot Nothing AndAlso View.ObjectTypeInfo IsNot Nothing AndAlso View.ObjectTypeInfo.Type IsNot Nothing Then
                typListViewType = View.ObjectTypeInfo.Type
            End If
            blnResult = IsColumnHidden(View.CurrentObject, typListViewType, objColumn.FieldName)
            If blnResult.HasValue = True Then
                objColumn.Visible = Not blnResult.Value

            End If

        Next
    End Sub

    Private _mRowChanging As Boolean
    Private Sub HandleFocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs)
        _mRowChanging = False
        _mEditorLoaded = False
        LayoutGridColumns()
        If GridListEditor.GridView.FocusedColumn IsNot Nothing AndAlso IsColumnDisabled(View.CurrentObject, GridListEditor.GridView.FocusedColumn.FieldName) = False Then
            GridListEditor.GridView.ShowEditor()
        End If
        'for each cell in grid, check if disabled and change color
        _mRowChanging = True
    End Sub

    Private _mColumnChanging As Boolean
    Private Sub HandleFocusedColumnChanged(sender As Object, e As FocusedColumnChangedEventArgs)
        _mColumnChanging = True

        _mEditorLoaded = False
        If e.PrevFocusedColumn IsNot Nothing Then
            e.PrevFocusedColumn.AppearanceHeader.Font = New System.Drawing.Font(e.PrevFocusedColumn.AppearanceHeader.Font, System.Drawing.FontStyle.Regular)
        End If
        If e.FocusedColumn IsNot Nothing Then
            e.FocusedColumn.AppearanceHeader.Font = New System.Drawing.Font(e.FocusedColumn.AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        End If



        If GridListEditor IsNot Nothing Then
            Dim strPropertyName As String = GridListEditor.FindColumnPropertyName(e.FocusedColumn)
            Dim mdl As IModelColumnExtension
            If strPropertyName > String.Empty Then
                mdl = ListView.Model.Columns.FirstOrDefault(Function(m) m.PropertyName = strPropertyName)
                If mdl IsNot Nothing Then
                    'If GridListEditor.GridView.ActiveEditor IsNot Nothing
                    If EditorOptions.ISSEditorOptions.GridClickMode = IModelISSEditorOptions.AcceleratedMode.SingleClick AndAlso ListView.AllowEdit = True AndAlso GridListEditor.AllowEdit = True AndAlso mdl.AllowEdit = True Then
                        GridListEditor.GridView.ShowEditor()
                    End If

                End If
            End If



        End If


        'End If

        'for each cell in grid, check if disabled and change color
        LayoutGridColumns()
        _mColumnChanging = False
    End Sub

    Public Overridable Function IsColumnDisabled(ByVal TargetObject As Object, ByVal ColumnName As String) As Boolean
        Return False
    End Function

    Public Overridable Function IsColumnHidden(ByVal TargetObject As Object, ByVal ListViewType As Type, ByVal ColumnName As String) As Boolean?
        Return Nothing
    End Function

End Class
