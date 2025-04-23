Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class PropertyTemplateController
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
        'Dim objDetailView As DetailView = Me.View
        If Me.View.ObjectTypeInfo.IsPersistent = False Then
            Return
        End If
        HandleObjectTypeEditors(Me, Nothing)
        RemoveHandler View.CurrentObjectChanged, AddressOf HandleObjectTypeEditors
        AddHandler View.CurrentObjectChanged, AddressOf HandleObjectTypeEditors
    End Sub

    Protected Overrides Sub OnDeactivated()
        MyBase.OnDeactivated()
        RemoveHandler View.CurrentObjectChanged, AddressOf HandleObjectTypeEditors
    End Sub

    Private Sub HandleObjectTypeEditors(ByVal sender As Object, ByVal e As EventArgs)
        Dim objDetailView As DetailView = Me.View
        If objDetailView IsNot Nothing Then
            If Me.View.CurrentObject IsNot Nothing AndAlso TypeOf Me.View.CurrentObject Is DevExpress.Xpo.XPCustomObject Then
                RemoveHandler CType(Me.View.CurrentObject, DevExpress.Xpo.XPCustomObject).Changed, AddressOf HandleObjectTypeEditors
                AddHandler CType(Me.View.CurrentObject, DevExpress.Xpo.XPCustomObject).Changed, AddressOf HandleObjectTypeEditors
            End If
            For Each objListPropertyEditor As Editors.ListPropertyEditor In objDetailView.GetItems(Of Editors.ListPropertyEditor)()
                If objListPropertyEditor.MemberInfo Is Nothing Then
                    Continue For
                End If
                If objListPropertyEditor.MemberInfo.ListElementType Is GetType(ISSBaseEditorStateTemplate) OrElse objListPropertyEditor.MemberInfo.ListElementType Is GetType(ISSBaseCustomCaption) Then
                    'If objListPropertyEditor.ListView.AllowEdit <> True Then
                    '    objListPropertyEditor.ListView.AllowEdit.SetItemValue("WorkflowAllowEdit", True)
                    'End If
                    'objListPropertyEditor.Frame.GetCotroller(Of ISS.Base.ISSBaseViewController).SetNewButtonVisibility(False)
                    'objListPropertyEditor.Frame.GetController(Of ISS.Base.ISSBaseViewController).SetDeleteButtonVisbility(False)
                    'objListPropertyEditor.Frame.GetController(Of ISS.Base.ISSBaseViewController).ISSViewParameters.ISSBaseListViewParameters.IsObjectAllowedToBeViewedInDetailView = False
                    If objListPropertyEditor.Control Is Nothing OrElse objListPropertyEditor.ListView.IsControlCreated = False Then
                        AddHandler objListPropertyEditor.ControlCreated, AddressOf CreateItemsForPropertyDropDown
                    Else
                        SetupGrid(CType(objListPropertyEditor.ListView.Control, DevExpress.XtraGrid.GridControl).Views(0))
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub CreateItemsForPropertyDropDown(ByVal sender As Object, ByVal e As EventArgs)
        Dim objListview As Editors.ListPropertyEditor
        Dim lstView As ListView

        If TypeOf sender Is ListView Then
            lstView = sender
            If lstView.IsControlCreated = False Then
                AddHandler lstView.ControlsCreated, AddressOf CreateItemsForPropertyDropDown
            Else
                SetupGrid(CType(lstView.Control, DevExpress.XtraGrid.GridControl).Views(0))
            End If
        Else
            objListview = sender
            If objListview.ListView IsNot Nothing AndAlso objListview.ListView.IsControlCreated = False Then
                AddHandler objListview.ListView.ControlsCreated, AddressOf CreateItemsForPropertyDropDown
            Else
                SetupGrid(CType(objListview.ListView.Control, DevExpress.XtraGrid.GridControl).Views(0))
            End If
        End If



    End Sub


    'Private Sub CreateItemsForPropertyDropDown(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim objListview As Editors.ListPropertyEditor = sender
    '    SetupGrid(CType(objListview.ListView.Control, DevExpress.XtraGrid.GridControl).Views(0))

    'End Sub

    Private Sub SetupGrid(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim oColumnEdit As WorkflowPropertyEditorRepositoryItem
        Dim drcCheckItem As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Dim sytType As System.Type = Nothing
        Dim oObjectTemplate As ISSBaseBusinessRules = Nothing
        If TypeOf Me.View.CurrentObject Is ISSBaseBusinessRules Then
            oObjectTemplate = Me.View.CurrentObject
            sytType = CType(Me.View.CurrentObject, ISSBaseBusinessRules).ObjectType
        ElseIf TypeOf Me.View.CurrentObject Is ISSBaseUserInterfaceTemplate Then
            If CType(Me.View.CurrentObject, ISSBaseUserInterfaceTemplate).ObjectCustomization IsNot Nothing Then
                oObjectTemplate = CType(Me.View.CurrentObject, ISSBaseUserInterfaceTemplate).ObjectCustomization
                sytType = CType(Me.View.CurrentObject, ISSBaseUserInterfaceTemplate).ObjectCustomization.ObjectType
            End If
        'ElseIf TypeOf Me.View.CurrentObject Is ISSBaseNotificationTemplate Then
        '    If CType(Me.View.CurrentObject, ISSBaseNotificationTemplate).ObjectCustomization IsNot Nothing Then
        '        oObjectTemplate = CType(Me.View.CurrentObject, ISSBaseNotificationTemplate).ObjectCustomization
        '        sytType = CType(Me.View.CurrentObject, ISSBaseNotificationTemplate).ObjectCustomization.ObjectType
        '    End If
        ElseIf TypeOf Me.View.CurrentObject Is ISSBaseWorkflowStep Then
            If CType(Me.View.CurrentObject, ISSBaseWorkflowStep).ObjectCustomization IsNot Nothing Then
                oObjectTemplate = CType(Me.View.CurrentObject, ISSBaseWorkflowStep).ObjectCustomization
                sytType = CType(Me.View.CurrentObject, ISSBaseWorkflowStep).ObjectCustomization.ObjectType
            End If
        ElseIf TypeOf Me.View.CurrentObject Is ISSBaseCustomCaption Then
            If CType(Me.View.CurrentObject, ISSBaseCustomCaption).ObjectCustomization IsNot Nothing Then
                oObjectTemplate = CType(Me.View.CurrentObject, ISSBaseCustomCaption).ObjectCustomization
                sytType = CType(Me.View.CurrentObject, ISSBaseCustomCaption).ObjectCustomization.ObjectType
            End If
        Else
            sytType = Me.View.CurrentObject.GetType
        End If
        If GridView Is Nothing Then
            Return
        End If

        'GridView.OptionsView.ShowIndicator = False
        'GridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown
        'GridView.OptionsCustomization.AllowColumnMoving = False
        'GridView.OptionsSelection.EnableAppearanceFocusedRow = False
        'GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        'GridView.OptionsSelection.EnableAppearanceHideSelection = False
        'GridView.OptionsSelection.MultiSelect = False
        For Each objColumn As DevExpress.XtraGrid.Columns.GridColumn In GridView.Columns
            If TypeOf objColumn.ColumnEdit Is WorkflowPropertyEditorRepositoryItem Then
                oColumnEdit = objColumn.ColumnEdit
                If oColumnEdit.Tag IsNot Nothing AndAlso oColumnEdit.Tag.GetType Is GetType(WorkflowMasterPropertyTypeEditor) Then
                    CType(oColumnEdit.Tag, WorkflowMasterPropertyTypeEditor).SetObjectCustomization(oObjectTemplate)
                    CType(oColumnEdit.Tag, WorkflowMasterPropertyTypeEditor).SetupValues(oColumnEdit)
                End If
                'oMasterWorkflowEditor = oColumnEdit.OwnerEdit
                'CType(objColumn.ColumnEdit.OwnerEdit, WorkflowMasterPropertyTypeEditor).SetupValues(objColumn.ColumnEdit)
                'objColumn.OptionsColumn.AllowEdit = False
                'objColumn.OptionsColumn.AllowFocus = False
                'If objColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False Then
                objColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True
                'End If
                'objColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Else
                If Not (TypeOf objColumn.ColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit) Then
                    Continue For
                End If

                drcCheckItem = objColumn.ColumnEdit
                drcCheckItem.AllowFocused = False
            End If
        Next
    End Sub
End Class
