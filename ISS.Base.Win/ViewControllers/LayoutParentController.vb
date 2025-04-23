Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports System.Drawing
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Core
Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Utils

Imports Microsoft.VisualBasic

Public Class LayoutParentController
	Inherits DevExpress.ExpressApp.ViewController

    Public ReadOnly Property IsMasterListViewControlVisible() As Boolean
        Get
            Return VisibleMasterListViewLayoutItem IsNot Nothing
        End Get
    End Property

    Private _mVisibleMasterListViewLayoutItem As DevExpress.XtraLayout.BaseLayoutItem
    Public Property VisibleMasterListViewLayoutItem() As DevExpress.XtraLayout.BaseLayoutItem
        Get
            Return _mVisibleMasterListViewLayoutItem
        End Get
        Set(ByVal value As DevExpress.XtraLayout.BaseLayoutItem)
            If _mVisibleMasterListViewLayoutItem Is value Then
                Return
            End If
            _mVisibleMasterListViewLayoutItem = value
        End Set
    End Property

    Private _mParentGroup As DevExpress.XtraLayout.LayoutGroup
    Public Property ParentGroup() As DevExpress.XtraLayout.LayoutGroup
        Get
            Return _mParentGroup
        End Get
        Set(ByVal value As DevExpress.XtraLayout.LayoutGroup)
            If _mParentGroup Is value Then
                Return
            End If
            _mParentGroup = Value
        End Set
    End Property

    Private _mParentPanelControlItem As DevExpress.XtraLayout.LayoutControlItem
    Public Property ParentPanelControlItem() As DevExpress.XtraLayout.LayoutControlItem
        Get
            Return _mParentPanelControlItem
        End Get
        Set(ByVal value As DevExpress.XtraLayout.LayoutControlItem)
            If _mParentPanelControlItem Is value Then
                Return
            End If
            _mParentPanelControlItem = Value
        End Set
    End Property

    Private _mParentPanel As System.Windows.Forms.TableLayoutPanel
    Public Property ParentPanel() As System.Windows.Forms.TableLayoutPanel
        Get
            Return _mParentPanel
        End Get
        Set(ByVal value As System.Windows.Forms.TableLayoutPanel)
            If _mParentPanel Is value Then
                Return
            End If
            _mParentPanel = Value
        End Set
    End Property

    Private _mLastItemAdded As DevExpress.XtraLayout.LayoutItem
    Public Property LastItemAdded() As DevExpress.XtraLayout.LayoutItem
        Get
            Return _mLastItemAdded
        End Get
        Set(ByVal value As DevExpress.XtraLayout.LayoutItem)
            If _mLastItemAdded Is value Then
                Return
            End If
            _mLastItemAdded = value
        End Set
    End Property

    Private _mButtonCount As Integer
    Public Property ButtonCount() As Integer
        Get
            Return _mButtonCount
        End Get
        Set(ByVal value As Integer)
            If _mButtonCount = Value Then
                Return
            End If
            _mButtonCount = Value
        End Set
    End Property

    Private _mButtonWidth As Integer
    Public Property ButtonWidth() As Integer
        Get
            Return _mButtonWidth
        End Get
        Set(ByVal value As Integer)
            If _mButtonWidth = Value Then
                Return
            End If
            _mButtonWidth = Value
        End Set
    End Property

    Public Const ButtonPerLine As Integer = 15
    Public Const ButtonPadding As Integer = 5

    Private _mLastLineRowWidth As Integer
    Public Property LastLineRowWidth() As Integer
        Get
            Return _mLastLineRowWidth
        End Get
        Set(ByVal value As Integer)
            If _mLastLineRowWidth = Value Then
                Return
            End If
            _mLastLineRowWidth = Value
        End Set
    End Property

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

        Me.TargetViewType = ViewType.DetailView

    End Sub

    Public Sub SetupControls(ByVal ParentLayoutGroup As DevExpress.XtraLayout.LayoutGroup)
        Me.ParentGroup = ParentLayoutGroup
        Me.LastItemAdded = Nothing
        Me.LastLineRowWidth = 0
        Me.ParentPanel = New System.Windows.Forms.TableLayoutPanel
        Me.ParentPanelControlItem = Me.ParentGroup.AddItem
        Me.ParentPanelControlItem.TextVisible = False
        Me.ParentPanelControlItem.Control = Me.ParentPanel
        Me.ButtonCount = 0
        Me.ButtonWidth = 0
    End Sub

    Private _mEditorList As New List(Of NestedIconListPropertyEditor)
    Public Property EditorList() As List(Of NestedIconListPropertyEditor)
        Get
            Return _mEditorList
        End Get
        Set(ByVal value As List(Of NestedIconListPropertyEditor))
            If _mEditorList Is value Then
                Return
            End If
            _mEditorList = Value
        End Set
    End Property

    Private Sub LayoutParentController_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        For Each oEditor As NestedIconListPropertyEditor In EditorList
            If oEditor.CurrentListView Is Me.VisibleMasterListViewLayoutItem Then
                oEditor.CurrentListView.Visibility = LayoutVisibility.Always
            Else
                oEditor.CurrentListView.Visibility = LayoutVisibility.Never
            End If
        Next
    End Sub

    Public Sub ViewRefreshed()
        For Each oEditor As NestedIconListPropertyEditor In EditorList
            If oEditor.CurrentListView Is Me.VisibleMasterListViewLayoutItem Then
                oEditor.CurrentListView.Visibility = LayoutVisibility.Always
            Else
                oEditor.CurrentListView.Visibility = LayoutVisibility.Never
            End If
        Next
    End Sub

    Private Sub LayoutParentController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        Dim objDetailView As DetailView = Me.View
        Dim objNestedIconListPropertyEditor As NestedIconListPropertyEditor
        Dim oTest As Object
        AddHandler Me.ObjectSpace.Committed, AddressOf ObjectSpace_Committed
        AddHandler Me.ObjectSpace.ObjectChanged, AddressOf ObjectSpace_ObjectChanged
        AddHandler Me.ObjectSpace.Refreshing, AddressOf ObjectSpace_Refreshing
        AddHandler Me.ObjectSpace.Reloaded, AddressOf ObjectSpace_Reloaded

        For Each objDetailViewItem As DevExpress.ExpressApp.Editors.ViewItem In objDetailView.Items
            If objDetailViewItem.GetType Is GetType(NestedIconListPropertyEditor) Then
                objNestedIconListPropertyEditor = objDetailViewItem
                oTest = objNestedIconListPropertyEditor.ListView.LayoutManager.Container
                EditorList.Add(objNestedIconListPropertyEditor)
                objNestedIconListPropertyEditor.LayoutParentController = Me
            End If
        Next
    End Sub
    Private Sub ObjectSpace_Committed()
        ViewStateChange()
    End Sub
    Private Sub ObjectSpace_ObjectChanged()
        ViewStateChange()
    End Sub
    Private Sub ObjectSpace_Refreshing()
        ViewStateChange()
    End Sub
    Private Sub ObjectSpace_Reloaded()
        ViewStateChange()
    End Sub

    Protected Overrides Sub OnViewChanging(ByVal view As DevExpress.ExpressApp.View)
        MyBase.OnViewChanging(view)
        ViewStateChange()
    End Sub

    Private Sub ViewStateChange()
        For Each oEditor As NestedIconListPropertyEditor In EditorList
            If oEditor.CurrentListView Is Me.VisibleMasterListViewLayoutItem Then
                If oEditor.CurrentListView.Visibility <> LayoutVisibility.Always Then
                    oEditor.CurrentListView.Visibility = LayoutVisibility.Always
                End If
            Else
                If oEditor.CurrentListView.Visibility <> LayoutVisibility.Never Then
                    oEditor.CurrentListView.Visibility = LayoutVisibility.Never
                End If
            End If
        Next
    End Sub



End Class

