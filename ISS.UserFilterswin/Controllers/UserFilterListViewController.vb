Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.ViewVariantsModule
Imports DevExpress.Xpo
Imports System
Imports ISS.Base
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Grid

Public Class UserFilterListViewController
    Inherits DevExpress.ExpressApp.ViewController

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

    Private _mActionSetup As Boolean = False

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        If ListView.Model.MasterDetailMode = MasterDetailMode.ListViewAndDetailView Then
            _mMasterDetailViewshown = True
        Else
            _mMasterDetailViewshown = False
        End If

        UpdateMasterDetailViewActionState()

        Dim iamApplicationModel As ISS.UserFilters.IUserFilterApplicationModel = TryCast(Application.Model, ISS.UserFilters.IUserFilterApplicationModel)
        If iamApplicationModel IsNot Nothing Then
            If Me.View.IsRoot = True Then
                Me.ListViewController_CreateFilter.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInRootListView
                Me.ListViewController_DeleteFilter.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInRootListView
                Me.ListViewController_Filters.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInRootListView
                Me.ListViewController_ShowHideMasterDetail.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInRootListView
            Else
                Me.ListViewController_CreateFilter.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInNestedListView
                Me.ListViewController_DeleteFilter.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInNestedListView
                Me.ListViewController_Filters.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInNestedListView
                Me.ListViewController_ShowHideMasterDetail.Active("ShowAction") = iamApplicationModel.UserFilterOptions.ShowUserFiltersInNestedListView
            End If
        End If

        If ListView.IsRoot = True Then
            If ListView.ObjectTypeInfo.FindAttribute(Of HideUserFilterAttribute)() IsNot Nothing Then
                Me.ListViewController_CreateFilter.Active("HideUserFilterAttribute") = False
                Me.ListViewController_DeleteFilter.Active("HideUserFilterAttribute") = False
                Me.ListViewController_Filters.Active("HideUserFilterAttribute") = False
                Me.ListViewController_ShowHideMasterDetail.Active("HideUserFilterAttribute") = False
            End If
        Else
            If TypeOf ListView.CollectionSource Is PropertyCollectionSource AndAlso CType(ListView.CollectionSource, PropertyCollectionSource).MemberInfo.FindAttribute(Of HideUserFilterAttribute)() IsNot Nothing Then
                Me.ListViewController_CreateFilter.Active("HideUserFilterAttribute") = False
                Me.ListViewController_DeleteFilter.Active("HideUserFilterAttribute") = False
                Me.ListViewController_Filters.Active("HideUserFilterAttribute") = False
                Me.ListViewController_ShowHideMasterDetail.Active("HideUserFilterAttribute") = False
            End If
        End If

    End Sub

    Public ReadOnly Property CurrentListView() As ListView
        Get
            If Me.View Is Nothing Then
                Return Nothing
            End If
            Return Me.View
        End Get
    End Property



    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        PopulateAction()

        Dim xafOS As Xpo.XPObjectSpace = Me.Application.CreateObjectSpace
        Dim xpoUserFilter As New UserFilter(xafOS.Session)
        xpoUserFilter.ObjectType = View.ObjectTypeInfo.Type

        Dim gleGridListEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor
        Dim gfpGridFilterprocessor As New Filtering.FilterWithObjectsProcessor(Me.View.ObjectSpace)

        If TypeOf CurrentListView.Editor Is DevExpress.ExpressApp.Win.Editors.GridListEditor Then
            gleGridListEditor = CurrentListView.Editor
            Helpers.UserFilterHelper.UpdateUserFilterWithColumnInfo(gleGridListEditor, xpoUserFilter)
            If gleGridListEditor.GridView IsNot Nothing Then
                Dim gridView As GridView = gleGridListEditor.GridView
                AddHandler gridView.ColumnFilterChanged, AddressOf GridView_ColumnFilterChanged
            End If
        End If
    End Sub

    Private Sub GridView_ColumnFilterChanged(sender As Object, e As EventArgs)
        If CType(sender, GridView).ActiveFilterString = "" Then
            ListViewController_Filters.SelectedIndex = 0
        End If
    End Sub

    Public Sub PopulateAction()
        Dim objModelExtension As IModelListViewExtension
        Dim gpoGroupOperator As GroupOperator
        Dim gpoMasterGroupOperator As GroupOperator
        Dim xpoObjectSpace As Xpo.XPObjectSpace
        Dim blnFoundEmpty As Boolean = False
        Dim blnFoundUserFilter As Boolean = False
        Dim vccCollection As IList
        Dim lFilterItemsToRemove As List(Of ChoiceActionItem)

        If TypeOf ObjectSpace Is NonPersistentObjectSpace OrElse ObjectSpace Is Nothing Then
            Return
        End If
        If Application Is Nothing Then
            Return
        End If
        If View Is Nothing OrElse View.ObjectTypeInfo Is Nothing OrElse View.ObjectTypeInfo.Type Is Nothing OrElse View.Model Is Nothing Then
            Return
        End If
        If ListViewController_Filters Is Nothing OrElse ListViewController_Filters.Items Is Nothing Then
            Return
        End If
        objModelExtension = TryCast(View.Model, IModelListViewExtension)
        If objModelExtension Is Nothing Then
            Return
        End If

        xpoObjectSpace = Application.CreateObjectSpace
        ListViewController_Filters.BeginUpdate()

        gpoMasterGroupOperator = New GroupOperator
        gpoMasterGroupOperator.OperatorType = GroupOperatorType.Or

        gpoGroupOperator = New GroupOperator
        gpoGroupOperator.Operands.Add(CriteriaOperator.Parse("SavedObjectTypeName = ?", View.ObjectTypeInfo.Type.FullName))
        gpoGroupOperator.Operands.Add(CriteriaOperator.Parse("SpecificToView = False Or SpecificToView Is Null"))
        gpoGroupOperator.Operands.Add(CriteriaOperator.Parse("CreatedByUserID = ? Or IsPublic = True", SecuritySystem.CurrentUserId))

        gpoMasterGroupOperator.Operands.Add(gpoGroupOperator)

        gpoGroupOperator = New GroupOperator
        gpoGroupOperator.Operands.Add(CriteriaOperator.Parse(String.Format("ViewID = '{0}'", View.Id)))
        gpoGroupOperator.Operands.Add(New BinaryOperator("SpecificToView", True))
        gpoGroupOperator.Operands.Add(CriteriaOperator.Parse("CreatedByUserID = ? Or IsPublic = True", SecuritySystem.CurrentUserId))

        gpoMasterGroupOperator.Operands.Add(gpoGroupOperator)

        vccCollection = xpoObjectSpace.CreateCollection(GetType(UserFilter), gpoMasterGroupOperator, {New SortProperty("IsPublic", DB.SortingDirection.Ascending), New SortProperty("SummaryInfo", DB.SortingDirection.Ascending)})

        For Each xpoUserFilter As UserFilter In vccCollection

            If ListViewController_Filters.Items.FirstOrDefault(Function(m) m.Id = xpoUserFilter.Oid.ToString) Is Nothing Then
                ListViewController_Filters.Items.Add(New ChoiceActionItem(xpoUserFilter.Oid.ToString, xpoUserFilter.SummaryInfo, xpoUserFilter))
            Else
                ListViewController_Filters.Items.FirstOrDefault(Function(m) m.Id = xpoUserFilter.Oid.ToString).Caption = xpoUserFilter.SummaryInfo
            End If
        Next

        lFilterItemsToRemove = New List(Of ChoiceActionItem)
        For Each item In ListViewController_Filters.Items
            If String.IsNullOrEmpty(item.Caption) Then
                blnFoundEmpty = True
                Continue For
            Else
                If objModelExtension IsNot Nothing AndAlso TypeOf item.Data Is UserFilter AndAlso CType(item.Data, UserFilter)?.Oid.ToString = objModelExtension.CurrentUserFilterGuid Then
                    ListViewController_Filters.SelectedItem = item
                Else
                    blnFoundUserFilter = False
                    For Each xpoUserFilter As UserFilter In vccCollection
                        If xpoUserFilter.Oid.ToString = item.Id Then
                            blnFoundUserFilter = True
                        End If
                    Next
                    If blnFoundUserFilter = False Then
                        lFilterItemsToRemove.Add(item)
                    End If
                End If
            End If
        Next
        For Each itemToRemove In lFilterItemsToRemove
            ListViewController_Filters.Items.Remove(itemToRemove)
        Next

        'For intLoop As Integer = ListViewController_Filters.Items.Count - 1 To 0 Step -1
        '    If ListViewController_Filters.Items(intLoop).Caption = String.Empty Then
        '        blnFoundEmpty = True
        '        Continue For
        '    Else
        '        If objModelExtension IsNot Nothing AndAlso CType(ListViewController_Filters.Items(intLoop).Data, UserFilter).Oid.ToString = objModelExtension.CurrentUserFilterGuid Then
        '            ListViewController_Filters.SelectedItem = ListViewController_Filters.Items(intLoop)
        '        Else
        '            blnFoundUserFilter = False
        '            For Each xpoUserFilter As UserFilter In vccCollection
        '                If xpoUserFilter.Oid.ToString = ListViewController_Filters.Items(intLoop).Id Then
        '                    blnFoundUserFilter = True
        '                End If
        '            Next
        '            If blnFoundUserFilter = False Then
        '                ListViewController_Filters.Items.RemoveAt(intLoop)
        '            End If
        '        End If
        '    End If

        'Next

        If blnFoundEmpty = False Then
            ListViewController_Filters.Items.Insert(0, New ChoiceActionItem(String.Empty, Nothing))
        End If

        'For Each xafChoiceActionItem As ChoiceActionItem In ListViewController_Filters.Items
        '    If xafChoiceActionItem.Data Is Nothing Then
        '        Continue For
        '    End If
        '    If objModelExtension IsNot Nothing AndAlso CType(xafChoiceActionItem.Data, UserFilter).Oid.ToString = objModelExtension.CurrentUserFilterGuid Then
        '        ListViewController_Filters.SelectedItem = xafChoiceActionItem
        '    End If
        'Next

        ListViewController_Filters.EndUpdate()

        xpoObjectSpace.Dispose()
        xpoObjectSpace = Nothing

    End Sub

    Private Sub ListViewController_CreateFilter_CustomizePopupWindowParams(ByVal sender As Object, ByVal e As CustomizePopupWindowParamsEventArgs) Handles ListViewController_CreateFilter.CustomizePopupWindowParams
        Dim xafOS As Xpo.XPObjectSpace = Me.Application.CreateObjectSpace
        Dim xpoUserFilter As New UserFilter(xafOS.Session)
        Dim gleGridListEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor
        Dim ctoCriteriaOperator As CriteriaOperator = Nothing
        Dim gfpGridFilterprocessor As New Filtering.FilterWithObjectsProcessor(Me.View.ObjectSpace)
        Dim strFilter As String = String.Empty

        xpoUserFilter.ObjectType = View.ObjectTypeInfo.Type

        If TypeOf CurrentListView.Editor Is DevExpress.ExpressApp.Win.Editors.GridListEditor Then
            gleGridListEditor = CurrentListView.Editor
            Helpers.UserFilterHelper.UpdateUserFilterWithColumnInfo(gleGridListEditor, xpoUserFilter)
            If gleGridListEditor.GridView IsNot Nothing AndAlso gleGridListEditor.GridView.ActiveFilter IsNot Nothing AndAlso gleGridListEditor.GridView.ActiveFilter.Criteria IsNot Nothing Then
                strFilter = gleGridListEditor.GridView.ActiveFilterString
                ctoCriteriaOperator = gleGridListEditor.GridView.ActiveFilterCriteria
                gfpGridFilterprocessor.Process(ctoCriteriaOperator, Filtering.FilterWithObjectsProcessorMode.ObjectToString)
                xpoUserFilter.Criterion = ctoCriteriaOperator.ToString
                xpoUserFilter.ShowGroupPanel = gleGridListEditor.GridView.OptionsView.ShowGroupPanel
                ctoCriteriaOperator = CriteriaEditorHelper.GetCriteriaOperator(xpoUserFilter.Criterion, View.ObjectTypeInfo.Type, View.ObjectSpace)
                gfpGridFilterprocessor.Process(ctoCriteriaOperator, Filtering.FilterWithObjectsProcessorMode.StringToObject)
                gleGridListEditor.GridView.ActiveFilterCriteria = ctoCriteriaOperator
            End If
            xpoUserFilter.ViewID = gleGridListEditor.Model.Id
        End If

        xpoUserFilter.CreatedByUserID = DevExpress.ExpressApp.SecuritySystem.CurrentUserId

        'set members of newly UserFilter to match the members of the already selected UserFilter
        If ListViewController_Filters.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrEmpty(ListViewController_Filters.SelectedItem.Caption) Then
            Dim xpoSelectedUserFilter As UserFilter = ListViewController_Filters.SelectedItem.Data
            xpoUserFilter.Name = xpoSelectedUserFilter.Name
            xpoUserFilter.Description = xpoSelectedUserFilter.Description
            xpoUserFilter.IsPublic = xpoSelectedUserFilter.IsPublic
            xpoUserFilter.ShowMasterDetailView = xpoSelectedUserFilter.ShowMasterDetailView
            xpoUserFilter.SpecificToView = xpoSelectedUserFilter.SpecificToView
        End If

        xpoUserFilter.ShowMasterDetailView = _mMasterDetailViewshown

        'If ListViewController_ShowHideMasterDetail.Caption = ShowMasterDetailCaption Then
        '    xpoUserFilter.ShowMasterDetailView = False
        'Else
        '    xpoUserFilter.ShowMasterDetailView = True
        'End If


        e.DialogController = New UserFilterPopupController
        e.View = e.Application.CreateDetailView(xafOS, "UserFilter_DetailView_ViewMode", False, xpoUserFilter)
        RemoveHandler e.DialogController.AcceptAction.Executed, AddressOf HandlePopupExecuted
        AddHandler e.DialogController.AcceptAction.Executed, AddressOf HandlePopupExecuted

    End Sub

    Private Sub HandlePopupExecuted(ByVal sender As Object, ByVal e As ActionBaseEventArgs)
        Dim createdFilter = CType(CType(e.Action.Controller, UserFilterPopupController).Frame.View.CurrentObject, UserFilter).Oid

        PopulateAction()

        Dim selectedItem As ChoiceActionItem = Nothing
        For Each filterItem In ListViewController_Filters.Items
            If filterItem.Data IsNot Nothing AndAlso filterItem.Data.Oid = createdFilter Then
                selectedItem = filterItem
            End If
        Next
        ListViewController_Filters.SelectedItem = selectedItem
    End Sub

    Private Sub ListViewController_Filters_Execute(ByVal sender As Object, ByVal e As SingleChoiceActionExecuteEventArgs) Handles ListViewController_Filters.Execute

        If _mSkipAction = True Then
            Return
        End If

        Dim objModelExtension As IModelListViewExtension = TryCast(View.Model, IModelListViewExtension)

        Dim gleGridListEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor
        Dim ctoCriteriaOperator As CriteriaOperator
        Dim xpoObjectSpace As Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim gfpGridFilterprocessor As New Filtering.FilterWithObjectsProcessor(xpoObjectSpace)
        Dim xpoUserFilter As UserFilter = xpoObjectSpace.GetObject(e.SelectedChoiceActionItem.Data)
        Dim uacAppearanceController As DevExpress.ExpressApp.ConditionalAppearance.AppearanceController = Frame.GetController(Of DevExpress.ExpressApp.ConditionalAppearance.AppearanceController)()
        Dim ctr As Utils.LightDictionary(Of String, CriteriaOperator)
        If TypeOf CurrentListView.Editor Is DevExpress.ExpressApp.Win.Editors.GridListEditor Then
            '_mCurrentFilterOid = Nothing
            gleGridListEditor = CurrentListView.Editor
            If gleGridListEditor.GridView Is Nothing Then
                Return
            End If
            gleGridListEditor.GridView.ActiveFilterCriteria = Nothing
            If xpoUserFilter IsNot Nothing Then
                If objModelExtension IsNot Nothing Then
                    objModelExtension.CurrentUserFilterGuid = xpoUserFilter.Oid.ToString
                    View.SaveModel()
                    Application.SaveModelChanges()

                End If

                If xpoUserFilter.ShowMasterDetailView = True Then
                    ListView.Model.MasterDetailMode = MasterDetailMode.ListViewAndDetailView
                Else
                    ListView.Model.MasterDetailMode = MasterDetailMode.ListViewOnly
                End If


                Dim vwsFactory As New XafApplicationViewsFactory(Application)
                _mSkipAction = True
                'todo: save criteria and re-add criteria
                'todo: roll back to 23.1.5
                ctr = Nothing
                If Me.ListView IsNot Nothing AndAlso Me.ListView.CollectionSource IsNot Nothing AndAlso Me.ListView.CollectionSource.Criteria IsNot Nothing Then
                    ctr = New Utils.LightDictionary(Of String, CriteriaOperator)
                    For Each strKey In ListView.CollectionSource.Criteria.Keys
                        ctr.Add(strKey, ListView.CollectionSource.Criteria(strKey))
                    Next
                End If



                FrameVariantsEngine.RecreateFrameView(vwsFactory, Me.Frame, Me.ListView.Id)
                    _mSkipAction = False
                    gleGridListEditor = CurrentListView.Editor
                    If gleGridListEditor.GridView Is Nothing Then
                        Return
                    End If

                If ctr IsNot Nothing Then

                    For Each strKey In ctr.Keys
                        If ListView.CollectionSource.Criteria.ContainsKey(strKey) = False Then
                            ListView.CollectionSource.Criteria.Add(strKey, ctr(strKey))
                        End If

                    Next
                End If


                '_mCurrentFilterOid = xpoUserFilter.Oid
                ctoCriteriaOperator = CriteriaEditorHelper.GetCriteriaOperator(xpoUserFilter.Criterion, View.ObjectTypeInfo.Type, View.ObjectSpace)
                    gfpGridFilterprocessor.Process(ctoCriteriaOperator, Filtering.FilterWithObjectsProcessorMode.StringToObject)
                    gleGridListEditor.GridView.ActiveFilterCriteria = ctoCriteriaOperator

                    'For Each itm In ListViewController_Filters.Items
                    '    If itm.Data IsNot Nothing AndAlso TypeOf itm.Data Is UserFilter AndAlso itm.Data.Oid = xpoUserFilter.Oid Then
                    '        ListViewController_Filters.SelectedItem = itm
                    '    End If
                    'Next

                    'View.LoadModel()
                    Helpers.UserFilterHelper.UpdateGridFromUserFilter(gleGridListEditor, Frame, Application, View, xpoUserFilter)
                    If uacAppearanceController IsNot Nothing Then
                        uacAppearanceController.Refresh()
                        For Each vwiItem As ViewItem In CType(View, ListView).Items
                            uacAppearanceController.RefreshItemAppearance(View, DevExpress.ExpressApp.ConditionalAppearance.AppearanceItemType.ViewItem.ToString, vwiItem.Id, vwiItem, View.CurrentObject)
                        Next


                    End If
                    gleGridListEditor = CurrentListView.Editor
                    gleGridListEditor.GridView.ActiveFilterCriteria = ctoCriteriaOperator
                    gleGridListEditor.GridView.OptionsView.ShowGroupPanel = xpoUserFilter.ShowGroupPanel
                    If gleGridListEditor.GridView.OptionsView.ShowGroupPanel = False Then
                        gleGridListEditor.GridView.ClearGrouping()
                    End If

                    'gleGridListEditor.ApplyModel
                Else
                    If objModelExtension IsNot Nothing Then
                    objModelExtension.CurrentUserFilterGuid = String.Empty
                    View.SaveModel()
                    Application.SaveModelChanges()

                End If

                'View.Model.SetValue("Userfilter", String.Empty)
            End If
        End If

        xpoObjectSpace.Dispose()
        xpoObjectSpace = Nothing

        PopulateAction()



    End Sub

    Private Sub ListViewController_DeleteFilter_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs) Handles ListViewController_DeleteFilter.Execute
        If ListViewController_Filters.SelectedItem IsNot Nothing AndAlso ListViewController_Filters.SelectedItem.Data IsNot Nothing Then
            Dim xpoObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
            xpoObjectSpace.GetObject(ListViewController_Filters.SelectedItem.Data).Delete()
            xpoObjectSpace.CommitChanges()
            Try
                ListViewController_Filters.Items.Clear()
                PopulateAction()
            Catch ex As Exception
                Throw New UserFriendlyException("Populate Actions Exception", ex)
            End Try

            xpoObjectSpace.Dispose()
            xpoObjectSpace = Nothing
        End If
    End Sub

    Private Sub ListViewController_ExportFilter_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles ListViewController_ExportFilter.Execute
        Dim sfdSaveFileDialog As New System.Windows.Forms.SaveFileDialog
        sfdSaveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        sfdSaveFileDialog.FilterIndex = 1
        sfdSaveFileDialog.RestoreDirectory = True
        For Each xpoUserFilter As UserFilter In View.SelectedObjects
            sfdSaveFileDialog.FileName = xpoUserFilter.Name + ".xml"
            If sfdSaveFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Helpers.UserFilterHelper.ExportToFile(xpoUserFilter, sfdSaveFileDialog.FileName)
            End If
        Next
    End Sub

    Private Sub ListViewController_ImportFilter_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles ListViewController_ImportFilter.Execute
        Dim ofdOpenFileDialog As New System.Windows.Forms.OpenFileDialog
        ofdOpenFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        ofdOpenFileDialog.FilterIndex = 1
        ofdOpenFileDialog.RestoreDirectory = True
        ofdOpenFileDialog.Multiselect = True
        If ofdOpenFileDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            For Each strFile In ofdOpenFileDialog.FileNames
                Helpers.UserFilterHelper.ImportFromFile(strFile, ObjectSpace)
            Next
            ObjectSpace.CommitChanges()
            ObjectSpace.Refresh()
            View.Refresh()
        End If
    End Sub

    Public ReadOnly Property GridListEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor
        Get
            If ListView Is Nothing Then
                Return Nothing
            End If
            Return TryCast(ListView.Editor, DevExpress.ExpressApp.Win.Editors.GridListEditor)
        End Get
    End Property

    Private Sub ListViewController_ShowHideMasterDetail_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles ListViewController_ShowHideMasterDetail.Execute
        Dim objModelExtension As IModelListViewExtension = TryCast(View.Model, IModelListViewExtension)


        Dim gleGridListEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor
        Dim ctoCriteriaOperator As CriteriaOperator
        Dim xpoObjectSpace As Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim gfpGridFilterprocessor As New Filtering.FilterWithObjectsProcessor(xpoObjectSpace)
        Dim blnShowGroup As Boolean
        Dim uacAppearanceController As DevExpress.ExpressApp.ConditionalAppearance.AppearanceController = Frame.GetController(Of DevExpress.ExpressApp.ConditionalAppearance.AppearanceController)()
        Dim xpoUserFilter As UserFilter = Nothing
        Dim gpoOldCriteria As CriteriaOperator

        If ListViewController_Filters.SelectedItem IsNot Nothing AndAlso ListViewController_Filters.SelectedItem.Data IsNot Nothing Then
            xpoUserFilter = ObjectSpace.GetObject(Of UserFilter)(ListViewController_Filters.SelectedItem.Data)
        End If


        If TypeOf CurrentListView.Editor Is DevExpress.ExpressApp.Win.Editors.GridListEditor Then
            gleGridListEditor = CurrentListView.Editor
            If gleGridListEditor.GridView Is Nothing Then
                Return
            End If
            blnShowGroup = gleGridListEditor.GridView.OptionsView.ShowGroupPanel
            gpoOldCriteria = gleGridListEditor.GridView.ActiveFilterCriteria
            gleGridListEditor.GridView.ActiveFilterCriteria = Nothing

            If _mMasterDetailViewshown = True Then
                ListView.Model.MasterDetailMode = MasterDetailMode.ListViewOnly
            Else
                ListView.Model.MasterDetailMode = MasterDetailMode.ListViewAndDetailView
            End If
            _mMasterDetailViewshown = Not _mMasterDetailViewshown


            Dim vwsFactory As New XafApplicationViewsFactory(Application)
            FrameVariantsEngine.RecreateFrameView(vwsFactory, Me.Frame, Me.ListView.Id)

            gleGridListEditor = CurrentListView.Editor
            If gleGridListEditor.GridView Is Nothing Then
                Return
            End If
            ctoCriteriaOperator = gleGridListEditor.GridView.ActiveFilterCriteria



            If xpoUserFilter IsNot Nothing Then

                For Each itm In ListViewController_Filters.Items
                    If itm.Data IsNot Nothing AndAlso TypeOf itm.Data Is UserFilter AndAlso itm.Data.Oid = xpoUserFilter.Oid Then
                        ListViewController_Filters.SelectedItem = itm
                    End If
                Next
                Helpers.UserFilterHelper.UpdateGridFromUserFilter(gleGridListEditor, Frame, Application, View, xpoUserFilter)
            End If
            If uacAppearanceController IsNot Nothing Then
                uacAppearanceController.Refresh()
                For Each vwiItem As ViewItem In CType(View, ListView).Items
                    uacAppearanceController.RefreshItemAppearance(View, DevExpress.ExpressApp.ConditionalAppearance.AppearanceItemType.ViewItem.ToString, vwiItem.Id, vwiItem, View.CurrentObject)
                Next


            End If



            gleGridListEditor = CurrentListView.Editor
            gleGridListEditor.GridView.ActiveFilterCriteria = ctoCriteriaOperator
            gleGridListEditor.GridView.OptionsView.ShowGroupPanel = blnShowGroup
            If gleGridListEditor.GridView.OptionsView.ShowGroupPanel = False Then
                gleGridListEditor.GridView.ClearGrouping()
            End If

            gleGridListEditor.GridView.ActiveFilterCriteria = gpoOldCriteria
            'End If
        End If


        UpdateMasterDetailViewActionState()

        If xpoUserFilter IsNot Nothing Then
            _mSkipAction = True
            If objModelExtension IsNot Nothing Then
                objModelExtension.CurrentUserFilterGuid = xpoUserFilter.Oid.ToString
                View.SaveModel()
                Application.SaveModelChanges()
            End If
            PopulateAction()
            _mSkipAction = False
        End If

    End Sub
    Private _mSkipAction As Boolean = False
    Private _mMasterDetailViewshown As Boolean = False
    Public Sub UpdateMasterDetailViewActionState()
        If _mMasterDetailViewshown = True Then
            ListViewController_ShowHideMasterDetail.Caption = "Hide Master Detail View"
            ListViewController_ShowHideMasterDetail.ImageName = "Action_HideItemFromDashboard"
        Else
            ListViewController_ShowHideMasterDetail.Caption = "Show Master Detail View"
            ListViewController_ShowHideMasterDetail.ImageName = "Action_ShowItemOnDashboard"
        End If
    End Sub

End Class
