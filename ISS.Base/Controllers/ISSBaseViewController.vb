Imports System
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.SystemModule
Imports ISS.Base.Attributes.View.ListView
Imports ISS.Base.Attributes.View
Imports DevExpress.ExpressApp.Security
Imports DevExpress.Xpo

Partial Public Class ISSBaseViewController
    Inherits ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

#Region "Properties"
    Private _mISSViewParameters As New ISSBaseViewParameters
    Public Property ISSViewParameters() As ISSBaseViewParameters
        Get
            Return _mISSViewParameters
        End Get
        Set(ByVal value As ISSBaseViewParameters)
            If _mISSViewParameters Is value Then
                Return
            End If
            _mISSViewParameters = value
        End Set
    End Property
    'Private _mListProcessHandledByPlatform As Boolean
    'Property ListProcessHandledByPlatform As Boolean
    '    Get
    '        Return _mListProcessHandledByPlatform
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        _mListProcessHandledByPlatform = Value
    '    End Set
    'End Property
    


    Private _mParentObjectSpace As Xpo.XPObjectSpace
    Public Property ParentObjectSpace() As Xpo.XPObjectSpace
        Get
            Return _mParentObjectSpace
        End Get
        Set(ByVal value As Xpo.XPObjectSpace)
            If _mParentObjectSpace Is value Then
                Return
            End If
            _mParentObjectSpace = value
        End Set
    End Property

    Private _mViewSettings As Attributes.View.ViewSettingsAttribute
    Public ReadOnly Property ViewSettings() As Attributes.View.ViewSettingsAttribute
        Get
            If _mViewSettings Is Nothing Then
                SetupViewSettings()
            End If
            Return _mViewSettings
        End Get
    End Property

    Private WithEvents _mParentView As View
    Public Property ParentView() As View
        Get
            Return _mParentView
        End Get
        Set(ByVal value As View)
            If _mParentView Is value Then
                Return
            End If
            _mParentView = value
        End Set
    End Property

    Public ReadOnly Property IsListView() As Boolean
        Get
            Return TryCast(View, ListView) IsNot Nothing
        End Get
    End Property
#End Region

#Region "Behaviors"
    Public Sub Setup()
        If TypeOf View Is DashboardView Then
            Return
        End If
        Dim objListViewObjectHandler As ListViewProcessCurrentObjectController = Frame.GetController(Of ListViewProcessCurrentObjectController)()
        DisableReadonlyObjects()
        SetupViewSettings()
        SetupCollectionAttributes()
        ApplyDetailViewFix()

        If ISSViewParameters.IsNewVisible = False Then
            SetNewButtonVisibility(False)
        End If
        If ISSViewParameters.IsDeleteVisible = False Then
            SetDeleteButtonVisibility(False)
        End If
        If objListViewObjectHandler IsNot Nothing Then
            AddHandler objListViewObjectHandler.CustomProcessSelectedItem, AddressOf ListView_CustomProcessSelectedItem
        End If

        

    End Sub
    Public Sub ApplyDetailViewFix()
        If View.GetType IsNot GetType(DetailView) Then
            Return
        End If

        If TypeOf View.ObjectSpace Is Xpo.XPNestedObjectSpace Then
            SetNewButtonVisibility(False)
        End If

        'If View.ObjectTypeInfo.Type IsNot GetType(ISSBaseEndUserMessageDetail) Then
        '    Return
        'End If

        'View.AllowDelete.SetItemValue("MessageReadonly", False)
        'View.AllowEdit.SetItemValue("MessageReadonly", False)
        'View.AllowNew.SetItemValue("MessageReadonly", False)
        'CType(View, DetailView).ViewEditMode = ViewEditMode.View
    End Sub
    Public Sub CustomCalculateNewItemRowPosition(ByVal sender As Object, ByVal e As CustomCalculateNewItemRowPositionEventArgs)
        Dim atrEditableInListView As EditableInListViewAttribute = Nothing
        Dim pcsPropertyCollectionSource As PropertyCollectionSource
        Dim lstListView As ListView = View
        If TypeOf lstListView.CollectionSource Is PropertyCollectionSource Then
            pcsPropertyCollectionSource = lstListView.CollectionSource
            atrEditableInListView = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of EditableInListViewAttribute)()
        End If
        If atrEditableInListView Is Nothing Then
            atrEditableInListView = lstListView.ObjectTypeInfo.FindAttribute(Of EditableInListViewAttribute)()
        End If
        If SecuritySystem.IsGranted(New ObjectAccessPermission(View.ObjectTypeInfo.Type, ObjectAccess.Create, ObjectAccessModifier.Allow)) = True Then
            e.NewItemRowPosition = atrEditableInListView.NewItemRowPosition
        End If
    End Sub
    Public Sub DisableReadonlyObjects()
        If View Is Nothing Then
            Return
        End If
        Dim vwrReadonlyView As ReadOnlyAttribute = View.ObjectTypeInfo.FindAttribute(Of ReadOnlyAttribute)()
        If vwrReadonlyView Is Nothing OrElse vwrReadonlyView.IsReadOnly <> True Then
            Return
        End If

        If TypeOf View Is DetailView Then
            CType(View, DetailView).ViewEditMode = ViewEditMode.View
        End If
        View.AllowDelete.SetItemValue("MasterDelete", False)
        View.AllowEdit.SetItemValue("MasterDelete", False)
        View.AllowNew.SetItemValue("MasterDelete", False)
    End Sub
    Public Sub SetupCollectionAttributes()
        Dim lstListView As ListView = Nothing
        Dim pcsPropertyCollectionSource As PropertyCollectionSource = Nothing
        Dim dnrNewItemRowController As NewItemRowListViewController = Nothing
        Dim atrEditableInListView As EditableInListViewAttribute = Nothing
        Dim atrObjectClickAction As ObjectClickActionAttribute = Nothing
        'Dim atrObjectDoubleClickAction As ObjectDoubleClickActionAttribute = Nothing
        Dim atrShowLinkUnlinkAttribute As ShowLinkUnlinkAttribute = Nothing
        Dim idiModelItem As IModelBOModelItem = Nothing
        Dim ilvView As IModelListViewExtension = Nothing

        If TypeOf View Is ListView Then
            lstListView = View
            ilvView = TryCast(View.Model, IModelListViewExtension)
            If TypeOf lstListView.CollectionSource Is PropertyCollectionSource Then
                pcsPropertyCollectionSource = lstListView.CollectionSource
                If pcsPropertyCollectionSource.MemberInfo IsNot Nothing Then
                    atrEditableInListView = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of EditableInListViewAttribute)()
                    atrObjectClickAction = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of ObjectClickActionAttribute)()
                    atrShowLinkUnlinkAttribute = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of ShowLinkUnlinkAttribute)()
                    idiModelItem = TryCast(Application.Model.BOModel.Item(pcsPropertyCollectionSource.MasterObjectType.FullName).FindMember(pcsPropertyCollectionSource.MemberInfo.Name), IModelBOModelItem)
                End If
            End If
            If atrEditableInListView Is Nothing Then
                atrEditableInListView = lstListView.ObjectTypeInfo.FindAttribute(Of EditableInListViewAttribute)()
            End If
            If atrShowLinkUnlinkAttribute Is Nothing Then
                atrShowLinkUnlinkAttribute = lstListView.ObjectTypeInfo.FindAttribute(Of ShowLinkUnlinkAttribute)()
            End If
            If atrObjectClickAction Is Nothing Then
                atrObjectClickAction = lstListView.ObjectTypeInfo.FindAttribute(Of ObjectClickActionAttribute)()
            End If

            If atrObjectClickAction IsNot Nothing Then
                ISSViewParameters.ISSBaseListViewParameters.IsObjectAllowedToBeViewedInDetailView = (atrObjectClickAction.ClickAction = ObjectClickActionAttribute.ObjectClickActions.OpenDetailView)
                ISSViewParameters.ISSBaseListViewParameters.RequiresRowLabelClick = atrObjectClickAction.AllowRowLabelDoubleClick
            End If
            If atrEditableInListView IsNot Nothing AndAlso lstListView.Id.Contains("LookupListView") = False Then
                If SecuritySystem.IsGranted(New ObjectAccessPermission(View.ObjectTypeInfo.Type, ObjectAccess.Write, ObjectAccessModifier.Allow)) = True Then
                    lstListView.Editor.AllowEdit = True
                End If
                dnrNewItemRowController = Frame.GetController(Of NewItemRowListViewController)()
                If dnrNewItemRowController IsNot Nothing Then
                    AddHandler dnrNewItemRowController.CustomCalculateNewItemRowPosition, AddressOf CustomCalculateNewItemRowPosition
                    dnrNewItemRowController.UpdateNewItemRowPosition()
                End If
            End If
            If atrShowLinkUnlinkAttribute IsNot Nothing Then
                SetLinkUnlinkVisibility(atrShowLinkUnlinkAttribute.IsLinkUnlinkVisible)
            Else
                If ilvView IsNot Nothing AndAlso ilvView.HideLinkUnlink.HasValue = True Then
                    SetLinkUnlinkVisibility(Not ilvView.HideLinkUnlink.Value)
                ElseIf idiModelItem IsNot Nothing Then
                    SetLinkUnlinkVisibility(Not idiModelItem.HideLinkUnlink)
                End If
            End If
            
        End If
        
    End Sub
    Public Sub SetupViewSettingsAttribute()
        Dim lstView As ListView
        Dim pcsPropertyCollectionSource As PropertyCollectionSource = Nothing
        If IsListView Then
            lstView = View
            If TypeOf lstView.CollectionSource Is PropertyCollectionSource Then
                pcsPropertyCollectionSource = lstView.CollectionSource
                If pcsPropertyCollectionSource.MemberInfo IsNot Nothing Then
                    _mViewSettings = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of ViewSettingsAttribute)()
                End If
            End If
            If _mViewSettings Is Nothing Then
                _mViewSettings = lstView.ObjectTypeInfo.FindAttribute(Of ViewSettingsAttribute)()
            End If
        Else
            _mViewSettings = CType(View, DetailView).ObjectTypeInfo.FindAttribute(Of ViewSettingsAttribute)()
        End If

    End Sub
    Public Sub SetupViewSettings()
        SetupViewSettingsAttribute()
        If _mViewSettings Is Nothing Then
            SetNewButtonVisibility(True, "ViewSettings")
            SetDeleteButtonVisibility(True, "ViewSettings")
            SetViewEditable(True, "ViewSettings")
        Else
            SetNewButtonVisibility(_mViewSettings.AllowNewInView, "ViewSettings")
            SetDeleteButtonVisibility(_mViewSettings.AllowDeleteInView, "ViewSettings")
            SetViewEditable(_mViewSettings.AllowEditInView, "ViewSettings")
        End If
    End Sub
    'MJC 06-04-2015: Disable alias refreshing to determine performance issues
    Private _mRefreshing As Boolean = False
    Public Sub RefreshAliasesOnChanged(ByVal sender As Object, ByVal e As ObjectChangedEventArgs)
        If _mRefreshing = True Then
            Return
        End If
        _mRefreshing = True
        'For Each dmiMemberInfo As DC.IMemberInfo In View.ObjectTypeInfo.Members
        '    If dmiMemberInfo.FindAttribute(Of PersistentAliasAttribute)() IsNot Nothing Then
        '        View.ObjectSpace.SetModified(View.CurrentObject, dmiMemberInfo)
        '    End If
        'Next
        _mRefreshing = False
    End Sub
#End Region

#Region "Global View Controller Functionality"
    Public Sub SetDeleteButtonVisibility(ByVal IsVisible As Boolean)
        SetDeleteButtonVisibility(IsVisible, "Unknown")
    End Sub
    Public Sub SetDeleteButtonVisibility(ByVal IsActive As Boolean, ByVal Reason As String)
        Try
            If View IsNot Nothing Then
                View.AllowDelete.SetItemValue(Reason, IsActive)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetLinkUnlinkVisibility(ByVal IsVisible As Boolean)
        SetLinkUnlinkVisibility(IsVisible, "Unknown")
    End Sub
    Public Sub SetLinkUnlinkVisibility(ByVal IsVisible As Boolean, ByVal Reason As String)
        Dim objLinkUnlink As LinkUnlinkController
        Try
            objLinkUnlink = Frame.GetController(Of LinkUnlinkController)()
            If objLinkUnlink IsNot Nothing Then
                objLinkUnlink.Active.SetItemValue(Reason, IsVisible)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetNewButtonVisibility(ByVal IsVisible As Boolean)
        SetNewButtonVisibility(IsVisible, "Unknown")
    End Sub
    Public Sub SetNewButtonVisibility(ByVal IsActive As Boolean, ByVal Reason As String)
        Try
            If View IsNot Nothing Then
                View.AllowNew.SetItemValue(Reason, IsActive)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetViewEditable(ByVal IsEditable As Boolean)
        SetViewEditable(IsEditable, "Unknown")
    End Sub
    Public Sub SetViewEditable(ByVal IsEditable As Boolean, ByVal Reason As String)
        Try
            If View IsNot Nothing Then
                View.AllowEdit.SetItemValue(Reason, IsEditable)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "Event Handlers"

    Public Event OnHandleRowClick(ByVal sender As Object, ByVal e As CancelEventArgs)

    Public Sub ListView_CustomProcessSelectedItem(ByVal sender As Object, ByVal e As CustomProcessListViewSelectedItemEventArgs)
        Dim ceaEventArgs As New CancelEventArgs
        RaiseEvent OnHandleRowClick(Me,ceaEventArgs)
        If ceaEventArgs.Cancel = True
            Return
        End If

        If ISSViewParameters.ISSBaseListViewParameters.IsObjectAllowedToBeViewedInDetailView = False Then
            e.Handled = True
        End If
    End Sub
    Private Sub ParentView_Closing(ByVal sender As Object, ByVal e As EventArgs) Handles _mParentView.Disposing
        Dim objController As WindowController
        Dim objListView As ListView
        If ParentView.GetType Is GetType(ListView) Then
            objListView = ParentView
            If objListView.IsRoot = False Then
                If Frame IsNot Nothing Then
                    objController = Frame.GetController(Of WindowController)()
                    While objController.Window.Close(True) = False
                        Threading.Thread.Sleep(10)
                    End While
                End If
            End If
        Else
            If Frame Is Nothing Then
                Return
            End If

            objController = Frame.GetController(Of WindowController)()
            While objController.Window.Close(True) = False
                Threading.Thread.Sleep(10)
            End While
        End If
    End Sub

    Private Sub ISSBaseViewController_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If TypeOf View Is DetailView Then

            AddHandler ObjectSpace.ObjectChanged, AddressOf RefreshAliasesOnChanged
        End If

    End Sub
    Private Sub ISSBaseViewController_ViewControlsCreated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.ViewControlsCreated
        Try
            Setup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class

