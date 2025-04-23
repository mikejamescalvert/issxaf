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
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Printing
Imports DevExpress.XtraGrid
Imports System.ComponentModel

Partial Public Class StringValueWithObjectSpaceViewController
    Inherits ViewController(Of ListView)

    Public ReadOnly Property ThisListView As ListView
        Get
            Return TryCast(View, ListView)
        End Get
    End Property

    Public ReadOnly Property GridListEditor As GridListEditor
        Get
            Return TryCast(ThisListView.Editor, GridListEditor)
        End Get
    End Property

    Public ReadOnly Property ThisCurrentObject As Object
        Get
            If View.CurrentObject IsNot Nothing Then
                Return View.CurrentObject
            End If
            If ThisListView?.SelectedObjects.Count > 0 AndAlso ThisListView?.SelectedObjects(0) IsNot Nothing Then
                Return ThisListView.SelectedObjects(0)
            End If
            Return Nothing
        End Get
    End Property

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

        If GridListEditor IsNot Nothing AndAlso GridListEditor.GridView IsNot Nothing Then
            AddHandler GridListEditor.GridView.ShownEditor, AddressOf Grid_ShowEditor
            AddHandler GridListEditor.GridView.FocusedRowChanged, AddressOf HandleFocusedRowChanged
            AddHandler GridListEditor.GridView.SelectionChanged, AddressOf HandleSelectionChanged
            AddHandler GridListEditor.GridView.GotFocus, AddressOf Grid_GotFocus
        End If
        LayoutGridColumns()
    End Sub

    Private _mGridFocused As Boolean

    Private Sub Grid_GotFocus(sender As Object, e As EventArgs)
        If _mGridFocused = False Then
            LayoutGridColumns()
            _mGridFocused = True
        End If
    End Sub

    Private Sub HandleSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If ThisCurrentObject IsNot Nothing Then
            LayoutGridColumns()
        End If
    End Sub

    Private Sub HandleFocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs)
        If ThisCurrentObject IsNot Nothing Then
            LayoutGridColumns(True)
        End If
    End Sub

    Private Sub Grid_ShowEditor(sender As Object, e As EventArgs)
        Dim clmView As ColumnView = sender
        Dim rluLookup As DevExpress.XtraEditors.LookUpEdit
        If clmView.FocusedRowHandle = GridControl.NewItemRowHandle Then
            rluLookup = TryCast(clmView.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            If rluLookup IsNot Nothing Then
                AddHandler rluLookup.QueryPopUp, AddressOf Lookup_QueryPopup
            End If
        End If
        'If ThisCurrentObject Is Nothing Then
        '    GridListEditor.GridView.ActiveEditor.IsModified = True
        'End If
        'LayoutGridColumns()
    End Sub

    Private Sub Lookup_QueryPopup(sender As Object, e As CancelEventArgs)
        EnsureCurrentObject
    End Sub

    Public Sub EnsureCurrentObject()
        If View.CurrentObject Is Nothing Then
            Dim clmnView As ColumnView = CType(CType(View, ListView).Editor, WinColumnsListEditor).ColumnView
            Dim cluLookupEdit As DevExpress.XtraEditors.LookUpEdit = TryCast(clmnView.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            If cluLookupEdit IsNot Nothing Then
                Dim strPropertyName As String = GridListEditor.FindColumnPropertyName(clmnView.FocusedColumn)
                Dim clmRepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = cluLookupEdit.Properties
                Dim mdl As IModelColumnExtension = ThisListView.Model.Columns.FirstOrDefault(Function(m) m.PropertyName = strPropertyName)
                If mdl Is Nothing Then
                    Return
                End If

                clmnView.ActiveEditor.IsModified = True
                StringValueWithObjectSourceEditor.LoadDataSourceFromObject(View.CurrentObject, mdl.ModelMember.MemberInfo, ObjectSpace, clmRepositoryItem, False)
                clmnView.RefreshEditor(True)
            End If

        End If
    End Sub

    Private Sub LayoutGridColumns(Optional ByVal Reload As Boolean = False)
        If GridListEditor Is Nothing Then
            Return
        End If
        If GridListEditor.GridView Is Nothing Then
            Return
        End If
        For Each oColumn In GridListEditor.GridView.Columns
            If TypeOf oColumn Is DevExpress.XtraGrid.Columns.GridColumn Then
                ProcessGridColumn(oColumn)
            End If
        Next
    End Sub

    Public Sub ProcessGridColumn(ByRef Column As DevExpress.XtraGrid.Columns.GridColumn, Optional ByVal Reload As Boolean = False)
        Dim strPropertyName As String = GridListEditor.FindColumnPropertyName(Column)
        Dim clmRepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim mdl As IModelColumnExtension = ThisListView.Model.Columns.FirstOrDefault(Function(m) m.PropertyName = strPropertyName)
        If mdl Is Nothing Then
            Return
        End If

        clmRepositoryItem = TryCast(Column.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        If clmRepositoryItem IsNot Nothing AndAlso mdl.PropertyEditorType Is GetType(StringValueWithObjectSourceEditor) Then
            StringValueWithObjectSourceEditor.LoadDataSourceFromObject(ThisCurrentObject, mdl.ModelMember.MemberInfo, ObjectSpace, clmRepositoryItem, Reload)
        End If
    End Sub

    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub
End Class
