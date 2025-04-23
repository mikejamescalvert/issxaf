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

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class ValueWithDataSourceListViewController
    Inherits ViewController(Of ListView)



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
            AddHandler GridListEditor.GridView.CellValueChanged, AddressOf HandleCellValueChanged
            LayoutGridColumns()

            'With GridListEditor.GridView
            '    .Appearance.EvenRow.BackColor = System.Drawing.Color.Ivory
            '    .Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGoldenrodYellow
            '    .Appearance.FocusedCell.Font = New System.Drawing.Font(GridListEditor.GridView.Appearance.FocusedCell.Font, System.Drawing.FontStyle.Bold)
            '    If .FocusedColumn IsNot Nothing Then
            '        .FocusedColumn.AppearanceHeader.Font = New System.Drawing.Font(GridListEditor.GridView.FocusedColumn.AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
            '    End If

            'End With

        End If

        ' Access and customize the target View control.
    End Sub

    Private Sub HandleCellValueChanged(sender As Object, e As CellValueChangedEventArgs)
        LayoutGridColumns()
    End Sub

    Private Sub LayoutGridColumns()

        For Each oColumn In GridListEditor.GridView.Columns
            If TypeOf oColumn Is DevExpress.XtraGrid.Columns.GridColumn Then

                ProcessGridColumn(oColumn)
            End If
        Next
    End Sub


    Public Sub ProcessGridColumn(ByRef Column As DevExpress.XtraGrid.Columns.GridColumn)
        Dim strPropertyName As String = GridListEditor.FindColumnPropertyName(Column)
        Dim clmRepositoryItem As RepositoryItemComboBox
        Dim mdl As IModelColumnExtension = ListView.Model.Columns.FirstOrDefault(Function(m) m.PropertyName = strPropertyName)
        If mdl Is Nothing Then
            Return
        End If



        clmRepositoryItem = TryCast(Column.ColumnEdit, RepositoryItemComboBox)
        If clmRepositoryItem IsNot Nothing AndAlso mdl.PropertyEditorType Is GetType(ValueWithDataSourceEditor) Then
            ValueWithDataSourceEditor.LoadDataSourceFromObject(mdl.ModelMember.MemberInfo, ObjectSpace, View.CurrentObject, clmRepositoryItem)
            'todo: is the column editor type a value with data source? load values
        End If

    End Sub

    Private Sub HandleFocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs)
        LayoutGridColumns()
    End Sub

    Private Sub Grid_ShowEditor(sender As Object, e As EventArgs)
        LayoutGridColumns()
    End Sub

    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub
End Class
