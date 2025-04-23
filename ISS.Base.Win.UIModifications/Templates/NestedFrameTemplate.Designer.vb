Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Win.Templates
Partial Public Class NestedFrameTemplate
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            Try
                modelSynchronizationManager.Dispose()
                ActionContainersManager.Dispose()
                If barManager_Renamed IsNot Nothing Then
                    cObjectsCreation = Nothing
                    cRecordEdit = Nothing
                    cView = Nothing
                    cEdit = Nothing
                    cLink = Nothing
                    cReports = Nothing
                    cSave = Nothing
                    cOpenObject = Nothing
                    cPrint = Nothing

                    viewSitePanel.Dispose()
                    standardToolBar.Dispose()
                    standardToolBar = Nothing

                    barManager_Renamed.Form = Nothing
                    barManager_Renamed.Dispose()
                    barManager_Renamed = Nothing
                End If
                'components.Dispose();
            Catch ex As Exception

            End Try

        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New XafComponentResourceManager(GetType(NestedFrameTemplate))
        Me.viewSitePanel = New DevExpress.XtraEditors.PanelControl()
        Me.cObjectsCreation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cRecordEdit = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cEdit = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cLink = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cReports = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cSave = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cOpenObject = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cView = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cDefault = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cFilters = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cExport = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cDiagnostic = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cMenu = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cRecordsNavigation = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.cPrint = New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem()
        Me.standardToolBar = New DevExpress.XtraBars.Bar()
        Me.barManager_Renamed = New DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.actionContainersManager = New DevExpress.ExpressApp.Win.Templates.ActionContainersManager(Me.components)
        Me.modelSynchronizationManager = New DevExpress.ExpressApp.Win.Templates.ModelSynchronizationManager(Me.components)
        Me.viewSiteManager = New DevExpress.ExpressApp.Win.Templates.ViewSiteManager(Me.components)
        CType(Me.viewSitePanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barManager_Renamed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' viewSitePanel
        ' 
        resources.ApplyResources(Me.viewSitePanel, "viewSitePanel")
        Me.viewSitePanel.Name = "viewSitePanel"
        ' 
        ' cObjectsCreation
        ' 
        resources.ApplyResources(Me.cObjectsCreation, "cObjectsCreation")
        Me.cObjectsCreation.ContainerId = "ObjectsCreation"
        Me.cObjectsCreation.Id = 0
        Me.cObjectsCreation.Name = "cObjectsCreation"
        Me.cObjectsCreation.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cObjectsCreation.TargetPageGroupCaption = Nothing
        ' 
        ' cRecordEdit
        ' 
        resources.ApplyResources(Me.cRecordEdit, "cRecordEdit")
        Me.cRecordEdit.ContainerId = "RecordEdit"
        Me.cRecordEdit.Id = 1
        Me.cRecordEdit.Name = "cRecordEdit"
        Me.cRecordEdit.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cRecordEdit.TargetPageGroupCaption = Nothing
        ' 
        ' cEdit
        ' 
        resources.ApplyResources(Me.cEdit, "cEdit")
        Me.cEdit.ContainerId = "Edit"
        Me.cEdit.Id = 1
        Me.cEdit.Name = "cEdit"
        Me.cEdit.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cEdit.TargetPageGroupCaption = Nothing
        ' 
        ' cLink
        ' 
        resources.ApplyResources(Me.cLink, "cLink")
        Me.cLink.ContainerId = "Link"
        Me.cLink.Id = 1
        Me.cLink.Name = "cLink"
        Me.cLink.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cLink.TargetPageGroupCaption = Nothing
        ' 
        ' cReports
        ' 
        resources.ApplyResources(Me.cReports, "cReports")
        Me.cReports.ContainerId = "Reports"
        Me.cReports.Id = 1
        Me.cReports.Name = "cReports"
        Me.cReports.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cReports.TargetPageGroupCaption = Nothing
        ' 
        ' cSave
        ' 
        resources.ApplyResources(Me.cSave, "cSave")
        Me.cSave.ContainerId = "Save"
        Me.cSave.Id = 1
        Me.cSave.Name = "cSave"
        Me.cSave.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cSave.TargetPageGroupCaption = Nothing
        ' 
        ' cOpenObject
        ' 
        resources.ApplyResources(Me.cOpenObject, "cOpenObject")
        Me.cOpenObject.ContainerId = "OpenObject"
        Me.cOpenObject.Id = 8
        Me.cOpenObject.Name = "cOpenObject"
        Me.cOpenObject.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cOpenObject.TargetPageGroupCaption = Nothing
        ' 
        ' cView
        ' 
        resources.ApplyResources(Me.cView, "cView")
        Me.cView.ContainerId = "View"
        Me.cView.Id = 2
        Me.cView.Name = "cView"
        Me.cView.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cView.TargetPageGroupCaption = Nothing
        ' 
        ' cDefault
        ' 
        resources.ApplyResources(Me.cDefault, "cDefault")
        Me.cDefault.ContainerId = "Unspecified"
        Me.cDefault.Id = 3
        Me.cDefault.Name = "cDefault"
        Me.cDefault.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cDefault.TargetPageGroupCaption = Nothing
        ' 
        ' cFilters
        ' 
        resources.ApplyResources(Me.cFilters, "cFilters")
        Me.cFilters.ContainerId = "Filters"
        Me.cFilters.Id = 4
        Me.cFilters.Name = "cFilters"
        Me.cFilters.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cFilters.TargetPageGroupCaption = Nothing
        ' 
        ' cExport
        ' 
        resources.ApplyResources(Me.cExport, "cExport")
        Me.cExport.ContainerId = "Export"
        Me.cExport.Id = 5
        Me.cExport.Name = "cExport"
        Me.cExport.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cExport.TargetPageGroupCaption = Nothing
        ' 
        ' cDiagnostic
        ' 
        resources.ApplyResources(Me.cDiagnostic, "cDiagnostic")
        Me.cDiagnostic.ContainerId = "Diagnostic"
        Me.cDiagnostic.Id = 6
        Me.cDiagnostic.Name = "cDiagnostic"
        Me.cDiagnostic.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cDiagnostic.TargetPageGroupCaption = Nothing
        ' 
        ' cMenu
        ' 
        resources.ApplyResources(Me.cMenu, "cMenu")
        Me.cMenu.ContainerId = "Menu"
        Me.cMenu.Id = 7
        Me.cMenu.Name = "cMenu"
        Me.cMenu.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cMenu.TargetPageGroupCaption = Nothing
        ' 
        ' cRecordsNavigation
        ' 
        resources.ApplyResources(Me.cRecordsNavigation, "cRecordsNavigation")
        Me.cRecordsNavigation.ContainerId = "RecordsNavigation"
        Me.cRecordsNavigation.Id = 10
        Me.cRecordsNavigation.Name = "cRecordsNavigation"
        Me.cRecordsNavigation.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cRecordsNavigation.TargetPageGroupCaption = Nothing
        ' 
        ' cPrint
        ' 
        resources.ApplyResources(Me.cPrint, "cPrint")
        Me.cPrint.ContainerId = "Print"
        Me.cPrint.Id = 7
        Me.cPrint.Name = "cPrint"
        Me.cPrint.TargetPageCategoryColor = System.Drawing.Color.Empty
        Me.cPrint.TargetPageGroupCaption = Nothing
        ' 
        ' standardToolBar
        ' 
        Me.standardToolBar.BarName = "ListView Toolbar"
        Me.standardToolBar.DockCol = 0
        Me.standardToolBar.DockRow = 0
        Me.standardToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.standardToolBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cObjectsCreation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cSave, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cLink, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordEdit, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cOpenObject, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cView, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cReports, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cDiagnostic, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cRecordsNavigation, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cDefault, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cFilters, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.cPrint, True)})
        resources.ApplyResources(Me.standardToolBar, "standardToolBar")
        ' 
        ' barManager
        ' 
        Me.barManager_Renamed.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.standardToolBar})
        Me.barManager_Renamed.DockControls.Add(Me.barDockControlTop)
        Me.barManager_Renamed.DockControls.Add(Me.barDockControlBottom)
        Me.barManager_Renamed.DockControls.Add(Me.barDockControlLeft)
        Me.barManager_Renamed.DockControls.Add(Me.barDockControlRight)
        Me.barManager_Renamed.Form = Me
        Me.barManager_Renamed.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.cObjectsCreation, Me.cEdit, Me.cLink, Me.cReports, Me.cSave, Me.cOpenObject, Me.cRecordEdit, Me.cView, Me.cDefault, Me.cFilters, Me.cExport, Me.cMenu, Me.cRecordsNavigation, Me.cPrint, Me.cDiagnostic})
        Me.barManager_Renamed.MaxItemId = 7
        ' 
        ' barDockControlTop
        ' 
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        ' 
        ' barDockControlBottom
        ' 
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        ' 
        ' barDockControlLeft
        ' 
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        ' 
        ' barDockControlRight
        ' 
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        ' 
        ' actionContainersManager
        ' 
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cObjectsCreation)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cRecordEdit)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cEdit)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cLink)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cReports)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cSave)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cOpenObject)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cView)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cDefault)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cFilters)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cExport)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cDiagnostic)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cMenu)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cRecordsNavigation)
        Me.actionContainersManager.ActionContainerComponents.Add(Me.cPrint)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cObjectsCreation)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cRecordEdit)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cEdit)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cLink)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cReports)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cSave)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cOpenObject)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cView)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cFilters)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cExport)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cPrint)
        Me.actionContainersManager.ContextMenuContainers.Add(Me.cMenu)
        Me.actionContainersManager.DefaultContainer = Me.cDefault
        Me.actionContainersManager.Template = Me
        ' 
        ' modelSynchronizationManager
        ' 
        Me.modelSynchronizationManager.ModelSynchronizableComponents.Add(Me.barManager_Renamed)
        ' 
        ' viewSiteManager
        ' 
        Me.viewSiteManager.UseDefferedLoading = True
        Me.viewSiteManager.ViewSiteControl = Me.viewSitePanel
        ' 
        ' NestedFrameTemplate
        ' 
        Me.Controls.Add(Me.viewSitePanel)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "NestedFrameTemplate"
        resources.ApplyResources(Me, "$this")
        CType(Me.viewSitePanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barManager_Renamed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private standardToolBar As DevExpress.XtraBars.Bar
    Private cObjectsCreation As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cRecordEdit As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cEdit As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cLink As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cReports As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cSave As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cOpenObject As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cView As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cDefault As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cFilters As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cExport As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cDiagnostic As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cMenu As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cRecordsNavigation As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private cPrint As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    Private barDockControlTop As DevExpress.XtraBars.BarDockControl
    Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Private barDockControlRight As DevExpress.XtraBars.BarDockControl
    Private modelSynchronizationManager As DevExpress.ExpressApp.Win.Templates.ModelSynchronizationManager
#End Region
    Protected viewSitePanel As DevExpress.XtraEditors.PanelControl
    Protected barManager_Renamed As DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager
    Public ActionContainersManager As DevExpress.ExpressApp.Win.Templates.ActionContainersManager
    Private viewSiteManager As DevExpress.ExpressApp.Win.Templates.ViewSiteManager
End Class

