Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.Editors
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.ExpressApp.Model
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.ExpressApp.DC
Imports ISS.Base.Attributes.View.ListView
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.ExpressApp.Win.Core
Imports ISS.Base.Win.TextEditor

Public Class WinListViewController
    Inherits ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

        Me.TargetViewType = ViewType.ListView
    End Sub

    Public ReadOnly Property ListView As ListView
        Get
            Return View
        End Get
    End Property


    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        'If ListView.IsRoot = False AndAlso ListView.Id.Contains("Lookup") Then
        '    ListView.AllowNew("DisableNewInNestedListView") = False
        'End If
        SetupDefaultGridOptions()
        'SetupGridDoubleClickAction
        'SetupGridImageStatusColumn()
        Dim objBaseController As ISSBaseViewController = Frame.GetController(Of ISSBaseViewController)
        AddHandler objBaseController.OnHandleRowClick, AddressOf Base_OnHandleRowClick
        Dim objListViewObjectHandler As ListViewProcessCurrentObjectController = Frame.GetController(Of ListViewProcessCurrentObjectController)()
        If objListViewObjectHandler IsNot Nothing Then
            AddHandler objListViewObjectHandler.CustomProcessSelectedItem, AddressOf ListView_CustomProcessSelectedItem
        End If


    End Sub



    Private Sub Base_OnHandleRowClick(sender As Object, e As CancelEventArgs)
        e.Cancel = True
    End Sub

    Private Sub ListView_CustomProcessSelectedItem(sender As Object, e As CustomProcessListViewSelectedItemEventArgs)
        Dim gleGridListEditor As GridListEditor
        Dim ghiHitInfo As GridHitInfo
        Dim bvcBaseViewController As ISSBaseViewController = Frame.GetController(Of ISSBaseViewController)
        Dim blnHandled As Boolean = False
        If bvcBaseViewController IsNot Nothing Then

            If bvcBaseViewController.ISSViewParameters.ISSBaseListViewParameters.IsObjectAllowedToBeViewedInDetailView = False Then
                blnHandled = True
                If bvcBaseViewController.ISSViewParameters.ISSBaseListViewParameters.RequiresRowLabelClick = True Then
                    gleGridListEditor = TryCast(Me.ListView.Editor, GridListEditor)
                    If gleGridListEditor IsNot Nothing Then
                        ghiHitInfo = gleGridListEditor.GridView.CalcHitInfo(gleGridListEditor.Grid.PointToClient(gleGridListEditor.Control.MousePosition))
                        If ghiHitInfo.InRow = True AndAlso ghiHitInfo.HitTest = GridHitTest.RowIndicator Then
                            blnHandled = False
                        End If
                    End If
                End If
            End If
        End If
        If blnHandled = True And e.Handled = False Then
            e.Handled = True
        End If
    End Sub

    'Private Sub SetupGridDoubleClickAction
    '    Dim atrObjectDoubleClickAction As ObjectDoubleClickActionAttribute = Nothing
    '    Dim mmiMemberInfo As IMemberInfo
    '    Dim gleGridListEditor As GridListEditor = TryCast(ListView.Editor,GridListEditor)
    '    If gleGridListEditor Is Nothing
    '        Return
    '    End If

    '    If TypeOf ListView.CollectionSource Is PropertyCollectionSource Then
    '        mmiMemberInfo = CType(ListView.CollectionSource, PropertyCollectionSource).MemberInfo
    '        If mmiMemberInfo IsNot Nothing
    '            atrObjectDoubleClickAction = mmiMemberInfo.FindAttribute(Of ObjectDoubleClickActionAttribute)()
    '        End If
    '    End If

    '    If atrObjectDoubleClickAction Is Nothing
    '        atrObjectDoubleClickAction = ListView.ObjectTypeInfo.FindAttribute(Of ObjectDoubleClickActionAttribute)()
    '    End If

    '    If atrObjectDoubleClickAction IsNot Nothing
    '        gleGridListEditor.ProcessSelectedItemBySingleClick = false
    '    End If

    'End Sub

    'Private Sub SetupGridImageStatusColumn()
    '    Dim gleListEditor As GridListEditor
    '    Dim xafMI As DevExpress.ExpressApp.DC.IMemberInfo
    '    'If TypeOf CType(View, ListView).Editor Is GridListEditor Then
    '    '    gleListEditor = CType(View, ListView).Editor
    '    '    RemoveHandler gleListEditor.GridView.CustomRowCellEdit, AddressOf Messages_CustomRowCellEdit
    '    '    AddHandler gleListEditor.GridView.CustomRowCellEdit, AddressOf Messages_CustomRowCellEdit
    '    '    For Each oColumn As Object In gleListEditor.GridView.Columns
    '    '        If TypeOf oColumn Is XafGridColumnWrapper Then
    '    '            xafMI = View.ObjectTypeInfo.FindMember(CType(oColumn, XafGridColumnWrapper).PropertyName)
    '    '            If xafMI IsNot Nothing AndAlso xafMI.MemberType Is GetType(ObjectState) Then
    '    '                CType(oColumn, XafGridColumnWrapper).G = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
    '    '            End If
    '    '        End If
    '    '    Next
    '    'End If
    'End Sub

    'Private Sub Messages_CustomRowCellEdit(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs)
    '    Dim gisGridImageStatus As ObjectState
    '    Dim xgcXafGridColumn As XafGridColumnWrapper
    '    Dim ppiPropertyInfo As DevExpress.ExpressApp.DC.IMemberInfo
    '    Dim gleGridListEditor As GridListEditor
    '    Dim objRowObject As Object
    '    Dim rioObjectEdit As RepositoryItemObjectEdit
    '    Dim rilLookupEdit As RepositoryItemLookupEdit

    '    If View Is Nothing Then
    '        Return
    '    End If
    '    If Not TypeOf e.Column Is XafGridColumn Then
    '        Return
    '    End If
    '    xgcXafGridColumn = e.Column
    '    ppiPropertyInfo = View.ObjectTypeInfo.FindMember(xgcXafGridColumn.PropertyName)
    '    gleGridListEditor = CType(View, ListView).Editor

    '    If ppiPropertyInfo IsNot Nothing AndAlso ppiPropertyInfo.MemberType Is GetType(ObjectState) Then
    '        CType(e.Column, XafGridColumn).ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
    '        objRowObject = gleGridListEditor.GridView.GetRow(e.RowHandle)
    '        If objRowObject IsNot Nothing Then
    '            gisGridImageStatus = View.ObjectTypeInfo.FindMember(CType(e.Column, XafGridColumn).PropertyName).GetValue(objRowObject)
    '            If TypeOf e.RepositoryItem Is RepositoryItemObjectEdit Then
    '                rioObjectEdit = e.RepositoryItem
    '                rioObjectEdit.Buttons.Clear()
    '                If gisGridImageStatus IsNot Nothing Then
    '                    For Each oInstance As ObjectStateInstance In gisGridImageStatus.ObjectStateInstances
    '                        AddImage(gisGridImageStatus, oInstance, e.RepositoryItem, CType(e.Column, XafGridColumn).PropertyName, objRowObject)
    '                    Next
    '                    RemoveHandler rioObjectEdit.ButtonPressed, AddressOf ButtonClicked
    '                    AddHandler rioObjectEdit.ButtonPressed, AddressOf ButtonClicked
    '                End If
    '            ElseIf TypeOf e.RepositoryItem Is RepositoryItemLookupEdit Then
    '                rilLookupEdit = e.RepositoryItem
    '                rilLookupEdit.Buttons.Clear()
    '                If gisGridImageStatus IsNot Nothing Then
    '                    For Each oInstance As ObjectStateInstance In gisGridImageStatus.ObjectStateInstances
    '                        AddImage(gisGridImageStatus, oInstance, e.RepositoryItem, CType(e.Column, XafGridColumn).PropertyName, objRowObject)
    '                    Next
    '                    RemoveHandler rilLookupEdit.ButtonPressed, AddressOf ButtonClicked
    '                    AddHandler rilLookupEdit.ButtonPressed, AddressOf ButtonClicked
    '                End If
    '            End If
    '        End If
    '    End If

    '    'Dim order As CommunicationEntry = TryCast(GridView.GetRow(e.RowHandle), CommunicationEntry)
    '    'If order IsNot Nothing Then
    '    '    Dim item As RepositoryItemButtonEdit = TryCast(defaultButtonColumnColumnProperties.Clone(), RepositoryItemButtonEdit)
    '    '    UpdateButtons(item, order.Status Is oSystemSettings.ReadStatus)
    '    '    e.RepositoryItem = item
    '    'End If
    '    'End If
    'End Sub

    Private Sub ButtonClicked(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        CType(e.Button.Tag, ObjectState.CellClickAction).GridImageStatus.OnActionExecuted(e.Button.Tag)
    End Sub


    Public Sub AddImage(ByVal GridImageStatus As ObjectState, ByVal GridImage As ObjectStateInstance, ByVal RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, ByVal PropertyName As String, ByVal TargetObject As Object)
        Dim dcbButton As New DevExpress.XtraEditors.Controls.EditorButton
        dcbButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        dcbButton.Appearance.BackColor = Color.Transparent
        dcbButton.Appearance.BackColor2 = Color.Transparent
        dcbButton.Appearance.BorderColor = Color.Transparent
        dcbButton.Appearance.Options.UseBackColor = True
        dcbButton.Appearance.Options.UseBorderColor = True
        dcbButton.Appearance.Options.UseImage = True
        dcbButton.Image = GridImage.StateImage
        dcbButton.ToolTip = GridImage.ToolTip
        dcbButton.Tag = New ObjectState.CellClickAction(GridImage, PropertyName, TargetObject, GridImageStatus)
        dcbButton.IsLeft = True


        RepositoryItem.Buttons.Add(dcbButton)
        '        Me.Properties.Buttons.Add()
    End Sub

    Public Function GetColumnByPropertyName(ByVal PropertyName As String) As GridColumn
        Dim gpeEditor As GridListEditor = ListView.Editor

        For Each clmn As XafGridColumnWrapper In gpeEditor.Columns
            If clmn.PropertyName = PropertyName Then
                Return clmn.Column
            End If
        Next
        Return Nothing
    End Function

    Private Sub SetupDefaultGridOptions()
        Dim objListView As ListView
        Dim gpeEditor As GridListEditor
        Dim dgcGridControl As DevExpress.XtraGrid.GridControl
        Dim dgvGridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim imeExtension As IModelColumnExtension
        Dim gdcColumn As GridColumn
        objListView = Me.View
        If TypeOf objListView.Control Is DevExpress.XtraGrid.GridControl Then
            gpeEditor = objListView.Editor
            dgcGridControl = objListView.Control
            dgvGridView = dgcGridControl.Views(0)
            dgvGridView.OptionsView.EnableAppearanceEvenRow = True
            AddHandler dgvGridView.InitNewRow, AddressOf GridView_InitNewRow
            AddHandler dgvGridView.ShownEditor, AddressOf GridView_ShowEditor
            For Each clmColumn In gpeEditor.Columns
                For Each imcColumn As IModelColumn In gpeEditor.Model.Columns
                    If imcColumn.PropertyName = clmColumn.PropertyName Then
                        imeExtension = TryCast(imcColumn, IModelColumnExtension)
                        If imeExtension IsNot Nothing Then
                            gdcColumn = GetColumnByPropertyName(imcColumn.PropertyName)
                            If gdcColumn IsNot Nothing Then
                                gdcColumn.OptionsColumn.TabStop = Not imeExtension.SkipTabStop
                            End If
                        End If
                    End If
                Next
            Next


            AddHandler dgvGridView.KeyDown, AddressOf GridView_Keydown
        End If
    End Sub

    Private Sub GridView_ShowEditor(sender As Object, e As EventArgs)
        Dim clmColumnView As ColumnView = sender
        Dim gpeEditor As GridListEditor = ListView.Editor
        Dim obj As Object = clmColumnView.GetFocusedRow

        For Each clmn As DevExpress.XtraGrid.Columns.GridColumn In clmColumnView.Columns
            If TryCast(clmn.RealColumnEdit, RepositoryItemButtonEditEx) IsNot Nothing Then
                TryCast(clmn.RealColumnEdit, RepositoryItemButtonEditEx).GridEditingObject = View.CurrentObject
            End If
        Next


    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As InitNewRowEventArgs)
        Dim clmColumnView As ColumnView = sender
        Dim obj As Object = clmColumnView.GetRow(e.RowHandle)
        If obj IsNot Nothing AndAlso clmColumnView.ActiveEditor IsNot Nothing AndAlso TryCast(clmColumnView.ActiveEditor.Properties, RepositoryItemButtonEditEx) IsNot Nothing Then
            TryCast(clmColumnView.ActiveEditor.Properties, RepositoryItemButtonEditEx).UpdateObject()
        End If



    End Sub

    Private Sub GridView_Keydown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim dgvGridView As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Dim objListView As ListView = Me.View
        Dim pcsPropertyCollectionSource As PropertyCollectionSource
        Dim dovDeleteViewController As DevExpress.ExpressApp.SystemModule.DeleteObjectsViewController = Me.Frame.GetController(Of DevExpress.ExpressApp.SystemModule.DeleteObjectsViewController)()
        Dim dkaDeleteKeyAction As ISS.Base.Attributes.View.ListView.DeleteKeyActionAttribute = Nothing
        If objListView.IsRoot = True Then
            dkaDeleteKeyAction = objListView.ObjectTypeInfo.FindAttribute(Of ISS.Base.Attributes.View.ListView.DeleteKeyActionAttribute)()
        Else
            If TypeOf objListView.CollectionSource Is PropertyCollectionSource Then
                pcsPropertyCollectionSource = objListView.CollectionSource
                dkaDeleteKeyAction = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of ISS.Base.Attributes.View.ListView.DeleteKeyActionAttribute)()
            End If
        End If
        If dkaDeleteKeyAction IsNot Nothing AndAlso dkaDeleteKeyAction.DeleteKeyAction = Attributes.View.ListView.DeleteKeyActionAttribute.DeleteKeyActions.DeleteObjects Then
            If e.KeyCode = System.Windows.Forms.Keys.Delete Then
                If dovDeleteViewController IsNot Nothing Then
                    If dovDeleteViewController.DeleteAction.Enabled.ResultValue = True Then
                        If objListView.CollectionSource.AllowRemove = True Then
                            If MsgBox("Are you sure you want to remove these items?", MsgBoxStyle.YesNoCancel, "Confirm Remove") = MsgBoxResult.Yes Then
                                Me.ObjectSpace.Delete(objListView.SelectedObjects)
                                If objListView.IsRoot = True Then
                                    Me.ObjectSpace.CommitChanges()
                                End If
                                objListView.Refresh()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ApplyCollectionAttributes()
        Dim lstListView As ListView
        Dim pcsPropertyCollectionSource As PropertyCollectionSource
        Dim atrVisibleActions As Attributes.View.ViewSettingsAttribute
        If TypeOf Me.View Is ListView Then
            lstListView = Me.View
            If TypeOf lstListView.CollectionSource Is PropertyCollectionSource Then

                pcsPropertyCollectionSource = lstListView.CollectionSource
                If pcsPropertyCollectionSource.MemberInfo IsNot Nothing Then
                    atrVisibleActions = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of Attributes.View.ViewSettingsAttribute)()
                    If atrVisibleActions IsNot Nothing Then
                        SetOpenObjectVisibility(atrVisibleActions.AllowOpenObjectInView)
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SetOpenObjectVisibility(ByVal IsVisible As Boolean)
        Dim objOpenObject As DevExpress.ExpressApp.Win.SystemModule.OpenObjectController
        Try
            objOpenObject = Me.Frame.GetController(Of DevExpress.ExpressApp.Win.SystemModule.OpenObjectController)()
            If objOpenObject IsNot Nothing Then
                objOpenObject.Active.SetItemValue("", IsVisible)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
