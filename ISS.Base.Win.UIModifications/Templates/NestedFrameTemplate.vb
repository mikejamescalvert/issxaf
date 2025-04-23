Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Win.Controls
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.Utils.Controls
Imports DevExpress.XtraBars

Imports DevExpress.ExpressApp.Win.Templates
<ToolboxItem(False)> _
Partial Public Class NestedFrameTemplate
    Inherits UserControl
    Implements IFrameTemplate, ISupportActionsToolbarVisibility, IViewSiteTemplate, ISupportUpdate, IBarManagerHolder, ISupportStoreSettings, ISupportViewChanged, IXtraResizableControl

    Private Const FrameTemplatesNestedFrameTemplate As String = "FrameTemplates\NestedFrameTemplate"
    Public Const ListViewStateNodeName As String = "ListViewState"
    Public Const MenuBarsCustomizationNodeName As String = "XtraBarsCustomization"
    Private view As DevExpress.ExpressApp.View
    Private modelTemplate As IModelTemplateWin
    Private prevMinSize As Size = Size.Empty
    Private minSize_Renamed As Size
    Private actionsToolbarVisibility_Renamed = ActionsToolbarVisibility.Default
    Private localizationHelper As TemplatesHelper
    Private Sub view_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
        RemoveHandler (CType(sender, DevExpress.ExpressApp.View)).ControlsCreated, AddressOf view_ControlsCreated
        Me.BeginInvoke(New MethodInvoker(AddressOf RaiseXtraResizableControlChanged))
    End Sub
    Private Sub ApplyActionsToolbarVisibility()
        'If actionsToolbarVisibility_Renamed <> ActionsToolbarVisibility.Default Then
        Dim isVisible As Boolean
        If actionsToolbarVisibility_Renamed = ActionsToolbarVisibility.Hide Then
            isVisible = False
        Else : isVisible = True
        End If
        For Each bar As Bar In BarManager.Bars
            bar.Visible = isVisible
        Next bar
        'End If

    End Sub
    Private Sub UpdateActionsToolbarVisibilityValue()
        Dim visibleBarsCount As Integer
        For Each bar As Bar In BarManager.Bars
            If bar.Visible Then
                visibleBarsCount = visibleBarsCount + 1
            End If
        Next bar
        If visibleBarsCount = BarManager.Bars.Count Then
            actionsToolbarVisibility_Renamed = ActionsToolbarVisibility.Show
        Else
            If visibleBarsCount = 0 Then
                actionsToolbarVisibility_Renamed = ActionsToolbarVisibility.Hide
            Else
                actionsToolbarVisibility_Renamed = ActionsToolbarVisibility.Default
            End If
        End If
    End Sub
    Protected Sub RaiseXtraResizableControlChanged()
        RaiseEvent Changed(Me, EventArgs.Empty)
    End Sub
    Protected Overridable Sub OnBarMangerChanged()
        RaiseEvent BarManagerChanged(Me, EventArgs.Empty)
    End Sub
    Public Sub New()
        InitializeComponent()
        barManager_Renamed.ProcessShortcutsWhenInvisible = False 'B190422
        ' B35864, B36128
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        ' B37974
        'SetStyle(ControlStyles.SupportsTransparentBackColor, false);
    End Sub
    Public ReadOnly Property ToolBar() As Bar
        Get
            Return standardToolBar
        End Get
    End Property
#Region "IFrameTemplate Members"
    Public Function GetContainers() As ICollection(Of IActionContainer) Implements IFrameTemplate.GetContainers
        Return ActionContainersManager.GetContainers()
    End Function
    Public Sub SetView(ByVal view As DevExpress.ExpressApp.View) Implements IFrameTemplate.SetView
        viewSiteManager.SetView(view)
        Me.view = view
        If view IsNot Nothing Then
            If view.IsControlCreated Then
                Me.BeginInvoke(New MethodInvoker(AddressOf RaiseXtraResizableControlChanged))
            Else
                AddHandler view.ControlsCreated, AddressOf view_ControlsCreated
            End If
            Tag = view.Caption
        End If
        RaiseEvent ViewChanged(Me, New TemplateViewChangedEventArgs(view))
    End Sub
    Public ReadOnly Property DefaultContainer() As IActionContainer Implements IFrameTemplate.DefaultContainer
        Get
            Return ActionContainersManager.DefaultContainer
        End Get
    End Property
    Public Overridable Sub SetStatus(ByVal messages() As String)
    End Sub
#End Region
#Region "ISupportStoreSettings"
    Public Overridable Sub SetSettings(ByVal modelTemplate As IModelTemplate) Implements ISupportStoreSettings.SetSettings
        Me.modelTemplate = CType(modelTemplate, IModelTemplateWin)
        localizationHelper = New TemplatesHelper(Me.modelTemplate)
        barManager_Renamed.Model = localizationHelper.GetBarsCustomizationNode(If(view Is Nothing, "", view.Id))
    End Sub
    Public Overridable Sub ReloadSettings() Implements ISupportStoreSettings.ReloadSettings
        modelSynchronizationManager.ApplyModel()
        If barManager_Renamed IsNot Nothing Then
            ApplyActionsToolbarVisibility()
        End If
    End Sub
    Public Overridable Sub SaveSettings() Implements ISupportStoreSettings.SaveSettings
        modelSynchronizationManager.SynchronizeModel()
        UpdateActionsToolbarVisibilityValue()
    End Sub
#End Region
#Region "ISupportUpdate Members"
    Private Sub BeginUpdate() Implements ISupportUpdate.BeginUpdate
        barManager_Renamed.BeginUpdate()
    End Sub
    Private Sub EndUpdate() Implements ISupportUpdate.EndUpdate
        barManager_Renamed.EndUpdate()
    End Sub
#End Region
#Region "IBarManagerHolder Members"
    Public ReadOnly Property BarManager() As BarManager Implements IBarManagerHolder.BarManager
        Get
            Return barManager_Renamed
        End Get
    End Property
#End Region
#Region "IXtraResizableControl"
    Public ReadOnly Property IsCaptionVisible() As Boolean Implements IXtraResizableControl.IsCaptionVisible
        Get
            Return False
        End Get
    End Property
    Public ReadOnly Property MinSize() As Size Implements IXtraResizableControl.MinSize
        Get
            If (view IsNot Nothing) AndAlso view.IsControlCreated Then
                Dim viewControlMinimumSize As Size = (CType(view.Control, Control)).MinimumSize
                Dim xafLayoutControl As DevExpress.ExpressApp.Win.Layout.XafLayoutControl = TryCast(view.Control, DevExpress.ExpressApp.Win.Layout.XafLayoutControl)
                If xafLayoutControl IsNot Nothing Then
                    viewControlMinimumSize = xafLayoutControl.MinSize
                End If
                Dim borderSize As New Size(viewSitePanel.Bounds.Width - viewSitePanel.DisplayRectangle.Width, viewSitePanel.Bounds.Height - viewSitePanel.DisplayRectangle.Height)
                Dim newMinSize As New Size(barDockControlLeft.Width + viewControlMinimumSize.Width + barDockControlRight.Width + borderSize.Width, barDockControlTop.Height + viewControlMinimumSize.Height + barDockControlBottom.Height + borderSize.Height)
                If newMinSize <> prevMinSize Then
                    prevMinSize = newMinSize
                    ' Q254008
                    RaiseXtraResizableControlChanged()
                End If
                Return newMinSize
            End If
            Return minSize_Renamed
        End Get
    End Property
    Public ReadOnly Property MaxSize() As Size Implements IXtraResizableControl.MaxSize
        Get
            Return New Size(0, 0)
        End Get
    End Property
    Public Event Changed As EventHandler Implements IXtraResizableControl.Changed
    Public Event BarManagerChanged As EventHandler Implements IBarManagerHolder.BarManagerChanged
#End Region
#Region "IViewSiteTemplate Members"

    Public ReadOnly Property ViewSiteControl() As Object Implements IViewSiteTemplate.ViewSiteControl
        Get
            Return viewSitePanel
        End Get
    End Property

#End Region

#Region "ISupportViewChanged Members"

    Public Event ViewChanged As EventHandler(Of TemplateViewChangedEventArgs) Implements ISupportViewChanged.ViewChanged

#End Region


#Region "IActionBarVisibilityManager Members"
    'Public Property ActionsToolbarVisibility() As ActionsToolbarVisibility Implements ISupportActionsToolbarVisibility.ActionsToolbarVisibility
    '    Get
    '        Return actionsToolbarVisibility_Renamed
    '    End Get
    '    Set(ByVal value As ActionsToolbarVisibility)
    '        actionsToolbarVisibility_Renamed = value
    '    End Set
    'End Property
#End Region
    Private _mIsVisible As Boolean = True
    Public Sub SetVisible(isVisible As Boolean) Implements ISupportActionsToolbarVisibility.SetVisible
        'If isVisible = True Then
        '    barManager_Renamed.Form = Me
        'Else
        '    barManager_Renamed.Form = Nothing
        'End If
        _mIsVisible= isVisible
        standardToolBar.Visible = isVisible
        AddHandler standardToolBar.VisibleChanged, AddressOf Toolbar_VisibleChanged

        'For Each itm In barManager_Renamed.Items
        '    If TypeOf itm is BarItem Then
        '        If isVisible = True Then
        '            CType(itm,BarItem).Visibility = BarItemVisibility.Always
        '        Else
        '            CType(itm,BarItem).Visibility = BarItemVisibility.Never    
        '        End If
        '    End If
        'Next
        'If isVisible = True Then
        '    barDockControlTop.Parent = Me
        'Else
        '    barDockControlTop.Parent = Nothing
        'End If
        

        'barDockControlTop.Visible = isVisible
        'barManager_Renamed.Bars(0).Visible = False

    End Sub

    Public Event SettingsReloaded(sender As Object, e As EventArgs) Implements ISupportStoreSettings.SettingsReloaded

Private Sub Toolbar_VisibleChanged(sender As Object, e As EventArgs)
        If standardToolBar.Visible <> _mIsVisible Then
            standardToolBar.Visible = _mIsVisible
        End If
 End Sub 

End Class

