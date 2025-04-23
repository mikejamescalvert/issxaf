Imports System
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Security
Imports DevExpress.Xpo
Imports ISS.Base.Helpers
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win.Templates
Imports ISS.Base.Attributes.Editors.PropertyEditors
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports ISS.Base.Attributes.ObjectEditor

Public Class ISSBaseEditor
    Inherits LookupPropertyEditor

    Private _mMemberInfoFix As DevExpress.ExpressApp.DC.IMemberInfo

    Public ReadOnly Property MemberInfoFix() As DevExpress.ExpressApp.DC.IMemberInfo
        Get

            If Me.MemberInfo IsNot Nothing Then
                Return Me.MemberInfo
            End If
            If _mMemberInfoFix Is Nothing Then
                _mMemberInfoFix = Me.ObjectTypeInfo.FindMember(Me.PropertyName)
            End If
            Return _mMemberInfoFix
        End Get
    End Property

    Private _mEllipsisButton As New EditorButton("EditObject", ButtonPredefines.Glyph)
    Private _mDeleteButton As New EditorButton("DeleteObject", ButtonPredefines.Delete)
    Private _mNewButton As New EditorButton("NewObject", ButtonPredefines.Plus)
    Private _mEmailButton As New EditorButton("EmailObject", ButtonPredefines.Glyph)

    Private _mMyAllowOpenObjectAttribute As AllowOpenObjectAttribute
    Public Property MyAllowOpenObjectAttribute As AllowOpenObjectAttribute
        Get
            Return _mMyAllowOpenObjectAttribute
        End Get
        Set(ByVal Value As AllowOpenObjectAttribute)
            _mMyAllowOpenObjectAttribute = Value
        End Set
    End Property


    Private _mMyObjectEditorButtonsAttribute As ISS.Base.Attributes.ObjectEditor.ObjectEditorButtonsAttribute
    Public Property MyObjectEditorButtonsAttribute() As ISS.Base.Attributes.ObjectEditor.ObjectEditorButtonsAttribute
        Get
            Return _mMyObjectEditorButtonsAttribute
        End Get
        Set(ByVal value As ISS.Base.Attributes.ObjectEditor.ObjectEditorButtonsAttribute)
            _mMyObjectEditorButtonsAttribute = value
        End Set
    End Property

    Private _mCustomFrame As Frame
    Public Property CustomFrame() As Frame
        Get
            Return _mCustomFrame
        End Get
        Set(ByVal value As Frame)
            If _mCustomFrame Is value Then
                Return
            End If
            _mCustomFrame = value
        End Set
    End Property

    Private _mRepositoryItem As DevExpress.ExpressApp.Win.Editors.RepositoryItemLookupEdit

    Private _mIsChildEmailFunction As Boolean = False
    Private _mIsParentEmailFunction As Boolean = False

    Private _mChildViewController As ISS.Base.ISSBaseViewController
    Private WithEvents _mChildObject As XPBaseObject
    Private _mIsDropDownVisible As Boolean = True

    Private _mLookupEdit As LookupEdit

    Private _mEmailImplementationType As EmailHelper.EmailImplementationType

    Private _mCustomDisplayText As String
    Public Property CustomDisplayText() As String
        Get
            Return _mCustomDisplayText
        End Get
        Set(ByVal value As String)
            If _mCustomDisplayText = value Then
                Return
            End If
            _mCustomDisplayText = value
        End Set
    End Property

    Public Property ChildViewController() As ISS.Base.ISSBaseViewController
        Get
            Return _mChildViewController
        End Get
        Set(ByVal value As ISS.Base.ISSBaseViewController)
            If _mChildViewController Is value Then
                Return
            End If
            _mChildViewController = value
        End Set
    End Property
    Public ReadOnly Property ChildWindowController() As DevExpress.ExpressApp.WindowController
        Get
            If ChildViewController.Frame Is Nothing Then
                Return Nothing
            End If
            Return ChildViewController.Frame.GetController(Of WindowController)()
        End Get
    End Property
    Public ReadOnly Property ChildWindow() As DevExpress.ExpressApp.Win.WinWindow
        Get
            If ChildViewController.Frame Is Nothing Then
                Return Nothing
            End If
            Return ChildWindowController.Window
        End Get
    End Property
    Public Property ChildObject() As XPBaseObject
        Get
            Return _mChildObject
        End Get
        Set(ByVal value As XPBaseObject)
            If _mChildObject Is value Then
                Return
            End If
            _mChildObject = value
        End Set
    End Property

    Protected Overrides Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem
        Dim esaAttribute As EditorSearchModeAttribute = MemberInfoFix.FindAttribute(Of EditorSearchModeAttribute)()
        If esaAttribute IsNot Nothing AndAlso esaAttribute.SearchMode <> EditorSearchModeAttribute.SupportedModes.Standard Then
            Return New CustomRepositoryItemLookupEdit
        Else
            Return MyBase.CreateRepositoryItem()
        End If
    End Function
    Protected Overrides Function CreateControlCore() As Object
        Dim esaAttribute As EditorSearchModeAttribute = MemberInfoFix.FindAttribute(Of EditorSearchModeAttribute)()
        If esaAttribute IsNot Nothing AndAlso esaAttribute.SearchMode <> EditorSearchModeAttribute.SupportedModes.Standard Then
            _mLookupEdit = New CustomLookupEdit
        Else
            _mLookupEdit = MyBase.CreateControlCore
        End If
        Return _mLookupEdit
    End Function

    Protected Overrides Sub OnControlCreated()
        MyBase.OnControlCreated()
        MyBase.Control.Properties.ShowDropDown = ShowDropDown.Never

    End Sub

    Public ReadOnly Property EditorSettings As IModelExtension
        Get
            Return Model.Application
        End Get
    End Property


    Protected Overrides Sub SetupRepositoryItem(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        Dim objExpandObjectEditorAttribute As Attributes.ObjectEditor.ExpandObjectEditorAttribute
        Dim objButtonAlignmentAttribute As Attributes.ObjectEditor.ButtonAlignmentAttribute
        Dim objObjectEditorDisplayValueAttribute As Attributes.ObjectEditor.ObjectEditorDisplayValueAttribute
        Dim imiImageInfo As DevExpress.ExpressApp.Utils.ImageInfo
        Dim objButton As EditorButton
        Dim objCustomPropertyButtons As System.Collections.Generic.IEnumerable(Of ISS.Base.Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute)
        Dim objCustomButtons As System.Collections.Generic.IEnumerable(Of ISS.Base.Attributes.ObjectEditor.CustomEditorButtonAttribute)
        Dim atrTooltipProperty As ISS.Base.Attributes.ObjectEditor.ToolTipDisplayPropertyAttribute
        Dim atrTooltipText As ISS.Base.Attributes.ObjectEditor.ToolTipTextAttribute
        Try

            _mRepositoryItem = item
            _mLookupEdit = _mRepositoryItem.OwnerEdit
            _mRepositoryItem.ShowActionContainersPanel = False
            _mEllipsisButton.IsDefaultButton = False
            _mNewButton.Appearance.ForeColor = Color.MediumSeaGreen
            _mDeleteButton.Appearance.ForeColor = Color.MediumVioletRed
            _mEmailButton.Image = My.Resources.mail_send
            _mEmailButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
            imiImageInfo = DevExpress.ExpressApp.Utils.ImageLoader.Instance.GetImageInfo("MenuBar_OpenObject")
            If imiImageInfo <> Nothing Then
                _mEllipsisButton.Image = imiImageInfo.Image
                _mEllipsisButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
            End If
            MyAllowOpenObjectAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.Editors.PropertyEditors.AllowOpenObjectAttribute)()
            MyObjectEditorButtonsAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.ObjectEditor.ObjectEditorButtonsAttribute)()
            objExpandObjectEditorAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.ObjectEditor.ExpandObjectEditorAttribute)()
            objButtonAlignmentAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.ObjectEditor.ButtonAlignmentAttribute)()
            objObjectEditorDisplayValueAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.ObjectEditor.ObjectEditorDisplayValueAttribute)()
            objCustomButtons = Me.MemberInfoFix.FindAttributes(Of ISS.Base.Attributes.ObjectEditor.CustomEditorButtonAttribute)()
            objCustomPropertyButtons = Me.MemberInfoFix.FindAttributes(Of ISS.Base.Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute)()
            atrTooltipProperty = Me.MemberInfoFix.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipDisplayPropertyAttribute)()
            If atrTooltipProperty Is Nothing Then
                atrTooltipProperty = Me.MemberInfoFix.MemberTypeInfo.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipDisplayPropertyAttribute)()
            End If
            atrTooltipText = Me.MemberInfoFix.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipTextAttribute)()
            If atrTooltipText Is Nothing Then
                atrTooltipText = Me.MemberInfoFix.MemberTypeInfo.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipTextAttribute)()
            End If
            'If Me.View IsNot Nothing Then
            '    AddHandler Me.View.ObjectSpace.ObjectChanged, AddressOf RefreshObject
            'End If
            If objObjectEditorDisplayValueAttribute IsNot Nothing Then
                Me.CustomDisplayText = objObjectEditorDisplayValueAttribute.DisplayMessage
                _mRepositoryItem.DisplayFormat.FormatType = FormatType.Custom
                _mRepositoryItem.DisplayFormat.FormatString = objObjectEditorDisplayValueAttribute.DisplayMessage
                _mRepositoryItem.NullText = objObjectEditorDisplayValueAttribute.DisplayMessage
                AddHandler _mRepositoryItem.CustomDisplayText, AddressOf RepositoryItem_CustomDisplayText
            Else
                If Me.Helper.DisplayMember IsNot Nothing Then
                    If Me.Helper.DisplayMember.MemberTypeInfo.Type Is GetType(Decimal) Then
                        _mRepositoryItem.DisplayFormat.FormatType = FormatType.Numeric
                        _mRepositoryItem.DisplayFormat.FormatString = "{0:c2}"
                        _mRepositoryItem.EditFormat.FormatType = FormatType.Numeric
                        _mRepositoryItem.EditFormat.FormatString = "{0:c2}"
                    End If
                End If
            End If
            If Me.CurrentObject IsNot Nothing Then
                If TypeOf Me.CurrentObject Is XPBaseObject Then
                    AddHandler CType(Me.CurrentObject, XPBaseObject).Session.ObjectSaved, AddressOf LookupEditTextChanged
                End If
            End If

            If EditorSettings.ISSEditorOptions.ShowEllipsis = True OrElse (objExpandObjectEditorAttribute IsNot Nothing AndAlso objExpandObjectEditorAttribute.EditMode = Attributes.ObjectEditor.ExpandObjectEditorAttribute.ExpandObjectEditMode.EditInNew) Then
                If (MyAllowOpenObjectAttribute Is Nothing OrElse MyAllowOpenObjectAttribute.Allow = True) And (MyObjectEditorButtonsAttribute Is Nothing OrElse (MyObjectEditorButtonsAttribute.IsEllipsisVisible = True AndAlso MyObjectEditorButtonsAttribute.IsDepreciatedVersion = True) OrElse MyObjectEditorButtonsAttribute.IsDepreciatedVersion = False) Then
                    If DevExpress.ExpressApp.SecuritySystem.IsGranted(New ObjectAccessPermission(Me.MemberInfoFix.MemberType, ObjectAccess.Read, ObjectAccessModifier.Allow)) = True Then
                        _mEllipsisButton.Enabled = True
                        _mRepositoryItem.Buttons.Add(_mEllipsisButton)
                    End If
                End If
            End If
            If EditorSettings.ISSEditorOptions.ShowNewButton = True AndAlso (MyObjectEditorButtonsAttribute Is Nothing OrElse MyObjectEditorButtonsAttribute.IsNewVisible = True) Then
                If _mRepositoryItem.ReadOnly = False Then
                    If DevExpress.ExpressApp.SecuritySystem.IsGranted(New ObjectAccessPermission(Me.MemberInfoFix.MemberType, ObjectAccess.Create, ObjectAccessModifier.Allow)) = True Then
                        _mNewButton.Enabled = True
                        _mRepositoryItem.Buttons.Add(_mNewButton)
                    End If
                End If
            End If
            If EditorSettings.ISSEditorOptions.ShowClearButton = True AndAlso (MyObjectEditorButtonsAttribute Is Nothing OrElse MyObjectEditorButtonsAttribute.IsClearVisible = True) Then
                If _mRepositoryItem.ReadOnly = False Then
                    _mDeleteButton.Enabled = True
                    _mRepositoryItem.Buttons.Add(_mDeleteButton)
                End If
            End If

            _mEmailImplementationType = EmailHelper.GetEmailImplementationType(Me.MemberInfoFix)
            If _mEmailImplementationType <> EmailHelper.EmailImplementationType.None Then
                _mRepositoryItem.Buttons.Add(_mEmailButton)
                SetupEmailButton(Nothing, Nothing)
                AddHandler _mRepositoryItem.Enter, AddressOf SetupEmailButton
                BindEmailHandlerToObject()
            End If

            For Each objCustomButton As Base.Attributes.ObjectEditor.CustomEditorButtonAttribute In objCustomButtons
                If objCustomButton.ButtonImageName = String.Empty Then
                    objButton = New EditorButton(ButtonPredefines.Ellipsis)
                Else
                    objButton = New EditorButton(ButtonPredefines.Glyph)
                    objButton.Image = DevExpress.ExpressApp.Utils.ImageLoader.Instance.GetImageInfo(objCustomButton.ButtonImageName).Image
                End If
                If objCustomButton.ToolTipText > String.Empty Then
                    objButton.ToolTip = objCustomButton.ToolTipText
                End If
                objButton.Tag = objCustomButton
                _mRepositoryItem.Buttons.Add(objButton)
            Next
            For Each objCustomPropertyButton As Base.Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute In objCustomPropertyButtons
                If objCustomPropertyButton.ButtonImageName = String.Empty Then
                    objButton = New EditorButton(ButtonPredefines.Ellipsis)
                Else
                    objButton = New EditorButton(ButtonPredefines.Glyph)
                    objButton.Image = DevExpress.ExpressApp.Utils.ImageLoader.Instance.GetImageInfo(objCustomPropertyButton.ButtonImageName).Image
                End If
                objButton.Tag = objCustomPropertyButton
                If objCustomPropertyButton.ToolTipText > String.Empty Then
                    objButton.ToolTip = objCustomPropertyButton.ToolTipText
                End If
                _mRepositoryItem.Buttons.Add(objButton)
            Next
            If MyObjectEditorButtonsAttribute IsNot Nothing Then
                _mIsDropDownVisible = MyObjectEditorButtonsAttribute.IsDropDownVisible
                For intLoop As Integer = _mRepositoryItem.Buttons.Count - 1 To 0 Step -1
                    If _mRepositoryItem.Buttons(intLoop).IsDefaultButton = True Then
                        _mRepositoryItem.Buttons(intLoop).Enabled = MyObjectEditorButtonsAttribute.IsDropDownVisible
                        _mRepositoryItem.Buttons(intLoop).Visible = MyObjectEditorButtonsAttribute.IsDropDownVisible
                    End If
                Next
            End If

            If objButtonAlignmentAttribute IsNot Nothing AndAlso objButtonAlignmentAttribute.ButtonAlignment = Attributes.ObjectEditor.ButtonAlignmentAttribute.ButtonAlignments.Left Then
                For intLoop As Integer = _mRepositoryItem.Buttons.Count - 1 To 0 Step -1
                    If _mRepositoryItem.Buttons(intLoop).Visible = True Then
                        _mRepositoryItem.Buttons(intLoop).IsLeft = True
                    End If
                Next
            End If

            _mRepositoryItem.ShowDropDown = ShowDropDown.Never
            AddHandler _mRepositoryItem.ButtonClick, AddressOf MyLookupPropertyEditor_ButtonClick
            AddHandler _mRepositoryItem.KeyDown, AddressOf MyLookupPropertyEditor_KeyPressed
            AddHandler _mRepositoryItem.KeyUp, AddressOf MyLookupPropertyEditor_KeyReleased
            AddHandler _mRepositoryItem.QueryPopUp, AddressOf BeforeMenuShow
            AddHandler _mRepositoryItem.QueryResultValue, AddressOf LookupEditTextChanged
            '_mLookupEdit = Me.Control
            If _mLookupEdit IsNot Nothing Then
                If _mLookupEdit.EditValue IsNot Nothing Then
                    SetEditButtonEnabled(True)
                Else
                    SetEditButtonEnabled(False)
                End If
                AddHandler _mLookupEdit.TextChanged, AddressOf LookupEditTextChanged
                If atrTooltipText IsNot Nothing Then
                    _mLookupEdit.ToolTip = atrTooltipText.ToolTipText
                Else
                    If atrTooltipProperty IsNot Nothing Then
                        If Helpers.ReflectionHelper.GetObjectFromPropertyName(atrTooltipProperty.PropertyName, Me.CurrentObject) IsNot Nothing Then
                            _mLookupEdit.ToolTip = Helpers.ReflectionHelper.GetObjectFromPropertyName(atrTooltipProperty.PropertyName, Me.CurrentObject).ToString
                        End If
                    Else
                        'If Me.PropertyValue IsNot Nothing Then
                        '    If Helpers.ReflectionHelper.GetObjectFromPropertyName("ToolTip", Me.PropertyValue) IsNot Nothing Then
                        '        _mLookupEdit.ToolTip = Helpers.ReflectionHelper.GetObjectFromPropertyName("ToolTip", Me.PropertyValue).ToString
                        '    Else
                        _mLookupEdit.ToolTip = _mLookupEdit.Text
                    End If
                    'End If
                End If
                'End If
            End If
            SetupEllipsisVisibility()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RepositoryItem_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs)
        e.DisplayText = Me.CustomDisplayText
    End Sub

    Private Sub SetEditButtonEnabled(ByVal IsEnabled As Boolean)
        If MyObjectEditorButtonsAttribute IsNot Nothing AndAlso MyObjectEditorButtonsAttribute.IsEllipsisVisible = False AndAlso MyObjectEditorButtonsAttribute.IsDepreciatedVersion = True Then
            Return
        End If
        If MyAllowOpenObjectAttribute IsNot Nothing AndAlso MyAllowOpenObjectAttribute.Allow = False Then
            Return
        End If

        If MyObjectEditorButtonsAttribute Is Nothing AndAlso EditorSettings.ISSEditorOptions.ShowEllipsis = False Then
            Return    
        End If

        If DevExpress.ExpressApp.SecuritySystem.IsGranted(New ObjectAccessPermission(Me.MemberInfoFix.MemberType, ObjectAccess.Create, ObjectAccessModifier.Allow)) = True Then
            _mEllipsisButton.Enabled = True
            _mRepositoryItem.Buttons.Add(_mEllipsisButton)
        Else
            If SecuritySystem.IsGranted(New ObjectAccessPermission(Me.MemberInfoFix.MemberType, ObjectAccess.Read, ObjectAccessModifier.Allow)) = True Then
                _mEllipsisButton.Enabled = IsEnabled
                _mRepositoryItem.Buttons.Add(_mEllipsisButton)
            End If
        End If
    End Sub

    Public Sub LookupEditTextChanged()
        Dim atrTooltipProperty As ISS.Base.Attributes.ObjectEditor.ToolTipDisplayPropertyAttribute
        Dim atrTooltipText As ISS.Base.Attributes.ObjectEditor.ToolTipTextAttribute
        atrTooltipProperty = Me.MemberInfoFix.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipDisplayPropertyAttribute)()
        atrTooltipText = Me.MemberInfoFix.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipTextAttribute)()
        If atrTooltipProperty Is Nothing Then
            atrTooltipProperty = Me.MemberInfoFix.MemberTypeInfo.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipDisplayPropertyAttribute)()
        End If
        If atrTooltipText Is Nothing Then
            atrTooltipText = Me.MemberInfoFix.MemberTypeInfo.FindAttribute(Of ISS.Base.Attributes.ObjectEditor.ToolTipTextAttribute)()
        End If
        If _mLookupEdit IsNot Nothing Then
            If _mLookupEdit.EditValue IsNot Nothing Then
                'RefreshObject()
                SetEditButtonEnabled(True)
            Else
                SetEditButtonEnabled(False)
            End If
            If atrTooltipText IsNot Nothing Then
                _mLookupEdit.ToolTip = atrTooltipText.ToolTipText
            Else
                If Me.CurrentObject Is Nothing Then
                    _mLookupEdit.ToolTip = _mLookupEdit.Text
                    Return
                End If
                If atrTooltipProperty IsNot Nothing Then
                    If Helpers.ReflectionHelper.GetObjectFromPropertyName(atrTooltipProperty.PropertyName, Me.CurrentObject) IsNot Nothing Then
                        _mLookupEdit.ToolTip = Helpers.ReflectionHelper.GetObjectFromPropertyName(atrTooltipProperty.PropertyName, Me.CurrentObject).ToString
                    End If
                End If
            End If
        End If

        If atrTooltipText IsNot Nothing Then
            _mLookupEdit.ToolTip = atrTooltipText.ToolTipText
        Else
            If Me.CurrentObject Is Nothing Then
                _mLookupEdit.ToolTip = _mLookupEdit.Text
                Return
            End If

            If atrTooltipProperty IsNot Nothing Then

                If Helpers.ReflectionHelper.GetObjectFromPropertyName(atrTooltipProperty.PropertyName, Me.CurrentObject) IsNot Nothing Then
                    _mLookupEdit.ToolTip = Helpers.ReflectionHelper.GetObjectFromPropertyName(atrTooltipProperty.PropertyName, Me.CurrentObject).ToString
                End If

            Else
                If Helpers.ReflectionHelper.GetObjectFromPropertyName("ToolTip", Me.CurrentObject) IsNot Nothing Then
                    _mLookupEdit.ToolTip = Helpers.ReflectionHelper.GetObjectFromPropertyName("ToolTip", Me.CurrentObject).ToString
                Else
                    _mLookupEdit.ToolTip = _mLookupEdit.Text
                End If

            End If
        End If

    End Sub
    Private Sub BeforeMenuShow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim objRepositoryItemLookupEdit As LookupEdit
        If _mControlCClicked = True Then
            e.Cancel = True
            Return
        End If
        Try
            objRepositoryItemLookupEdit = sender
            If objRepositoryItemLookupEdit.Properties.Buttons.Contains(_mEllipsisButton) = True AndAlso objRepositoryItemLookupEdit.Properties.Buttons.VisibleCount = 1 Then
                e.Cancel = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private _mControlCClicked As Boolean = False
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)
        CustomRepositoryItemLookupEdit.RegisterEditor()
    End Sub


    Private Sub MyLookupPropertyEditor_KeyReleased(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        _mControlCClicked = False
    End Sub
    Private Sub MyLookupPropertyEditor_KeyPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim objLookupEdit As LookupEdit = sender
        Select Case e.KeyCode()
            Case Windows.Forms.Keys.F2
                ObjectEditButtonPressed(True)
            Case Windows.Forms.Keys.F3
                ObjectEditButtonPressed(False, objLookupEdit.EditValue)
            Case Windows.Forms.Keys.F4
                If _mIsDropDownVisible = False Then
                    e.Handled = True
                End If
            Case Windows.Forms.Keys.C
                If e.Modifiers = Windows.Forms.Keys.Control Then
                    _mControlCClicked = True
                    If objLookupEdit Is Nothing OrElse objLookupEdit.EditValue Is Nothing OrElse Helper.DisplayMember.GetValue(objLookupEdit.EditValue) Is Nothing Then
                        Windows.Forms.Clipboard.SetData(Windows.Forms.DataFormats.UnicodeText, String.Empty)
                    Else
                        Windows.Forms.Clipboard.SetData(Windows.Forms.DataFormats.UnicodeText, Helper.DisplayMember.GetValue(objLookupEdit.EditValue).ToString)
                    End If
                    e.Handled = True

                End If
        End Select
    End Sub



    Private Sub MyLookupPropertyEditor_ButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
        Dim dxgGridControl As DevExpress.XtraGrid.GridControl
        Dim dxvGridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim objCurrent As Object
        Dim objPropertyButton As ISS.Base.Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute
        Dim objButton As ISS.Base.Attributes.ObjectEditor.CustomEditorButtonAttribute
        _mLookupEdit = sender

        If TypeOf e.Button.Tag Is String Then
            Select Case e.Button.Tag
                Case _mEmailButton.Tag
                    If _mLookupEdit.InplaceType = InplaceType.Grid Then
                        dxgGridControl = _mLookupEdit.Parent
                        dxvGridView = dxgGridControl.Views(0)
                        If dxvGridView.GetFocusedRow Is Nothing Then
                            dxvGridView.AddNewRow()
                        End If
                        'create editing object if not exists
                        objCurrent = dxvGridView.GetFocusedRow
                    Else
                        objCurrent = Me.CurrentObject
                    End If
                    EmailHelper.ShowEmail(Me.MemberInfoFix, objCurrent)
                Case _mNewButton.Tag
                    ObjectEditButtonPressed(True)
                Case _mDeleteButton.Tag
                    Try
                        DeleteObject()
                    Catch ex As Exception
                        Throw ex
                    End Try
                Case _mEllipsisButton.Tag
                    If _mLookupEdit.EditValue Is Nothing Then
                        If DevExpress.ExpressApp.SecuritySystem.IsGranted(New ObjectAccessPermission(Me.MemberInfoFix.MemberType, ObjectAccess.Create, ObjectAccessModifier.Allow)) = True Then
                            ObjectEditButtonPressed(True)
                        End If
                    Else
                        ObjectEditButtonPressed(False, _mLookupEdit.EditValue)
                    End If
            End Select
        Else
            If e.Button.Tag IsNot Nothing Then
                If e.Button.Tag.GetType Is GetType(Base.Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute) Then
                    objPropertyButton = e.Button.Tag
                    ExecuteCustomPropertyButtonAction(objPropertyButton)
                ElseIf e.Button.Tag.GetType Is GetType(Base.Attributes.ObjectEditor.CustomEditorButtonAttribute) Then
                    objButton = e.Button.Tag
                    ExecuteCustomButtonAction(objButton)
                End If
            End If
        End If

    End Sub

    Private Sub ExecuteCustomPropertyButtonAction(ByVal PropertyButtonAttribute As ISS.Base.Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute)
        Dim objViewCollection As Object
        Dim objMasterObject As Object
        Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo
        Dim strMasterProperty As String
        Dim vsaViewSettingsAttribute As Attributes.View.ViewSettingsAttribute
        Dim objISSBaseView As New ISS.Base.ISSBaseViewController
        Dim lstController As New List(Of Controller)
        Dim pmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo
        Dim svpParameter As ShowViewParameters
        Dim svsSource As ShowViewSource
        Dim obs As IObjectSpace
        Dim pcsPropertyCollectionSource As PropertyCollectionSource
        Dim objMasterTranslated As Object
        objViewCollection = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(PropertyButtonAttribute.PropertyName, Me.View.CurrentObject)
        If objViewCollection IsNot Nothing Then
            objMasterObject = Me.View.CurrentObject
            If PropertyButtonAttribute.PropertyName.Contains(".") Then
                objMasterObject = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(ISS.Base.Helpers.ReflectionHelper.GetParentProperty(PropertyButtonAttribute.PropertyName), Me.View.CurrentObject)
            End If
            dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(objViewCollection.GetType)
            If dtiTypeInfo.IsListType = True Then
                strMasterProperty = ISS.Base.Helpers.ReflectionHelper.GetLastPropertyName(PropertyButtonAttribute.PropertyName)
                svpParameter = New ShowViewParameters
                svsSource = New ShowViewSource(Frame, Nothing)

                obs = Frame.Application.CreateObjectSpace()
                objMasterTranslated = obs.GetObject(objMasterObject)
                pmiMemberInfo = ISS.Base.Helpers.ReflectionHelper.GetMemberInfoForProperty(PropertyButtonAttribute.PropertyName, Me.View.CurrentObject)
                pcsPropertyCollectionSource = New PropertyCollectionSource(obs, objMasterTranslated.GetType, objMasterTranslated, pmiMemberInfo)

                svpParameter.Context = TemplateContext.View
                svpParameter.TargetWindow = TargetWindow.NewModalWindow

                svpParameter.CreatedView = Frame.Application.CreateListView(Frame.Application.FindListViewId(pmiMemberInfo.ListElementTypeInfo.Type), pcsPropertyCollectionSource, True)
                Me.Frame.Application.ShowViewStrategy.ShowView(svpParameter, svsSource)

            Else
                vsaViewSettingsAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.ObjectEditor.CustomPropertyLinkButtonViewSettingsAttribute)()
                If vsaViewSettingsAttribute Is Nothing Then
                    pmiMemberInfo = ISS.Base.Helpers.ReflectionHelper.GetMemberInfoForProperty(PropertyButtonAttribute.PropertyName, Me.View.CurrentObject)
                    If pmiMemberInfo IsNot Nothing Then
                        vsaViewSettingsAttribute = pmiMemberInfo.FindAttribute(Of Attributes.View.ViewSettingsAttribute)()
                    Else
                        vsaViewSettingsAttribute = Nothing
                    End If
                End If

                If vsaViewSettingsAttribute IsNot Nothing Then
                    objISSBaseView.ISSViewParameters.IsNewVisible = vsaViewSettingsAttribute.AllowNewInView
                    objISSBaseView.ISSViewParameters.IsDeleteVisible = vsaViewSettingsAttribute.AllowDeleteInView
                    lstController.Add(objISSBaseView)
                    Helpers.ViewHelper.CreateDetailViewThroughStrategy(CustomFrame, String.Empty, False, Me.Helper.ObjectSpace, dtiTypeInfo, lstController, False, Nothing, objViewCollection, Nothing, vsaViewSettingsAttribute.ViewInModalWindow, vsaViewSettingsAttribute.AllowEditInView)
                Else
                    vsaViewSettingsAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.View.ViewSettingsAttribute)()
                    If vsaViewSettingsAttribute IsNot Nothing Then
                        objISSBaseView.ISSViewParameters.IsNewVisible = vsaViewSettingsAttribute.AllowNewInView
                        objISSBaseView.ISSViewParameters.IsDeleteVisible = vsaViewSettingsAttribute.AllowDeleteInView
                        lstController.Add(objISSBaseView)
                        Helpers.ViewHelper.CreateDetailViewThroughStrategy(CustomFrame, String.Empty, False, Me.Helper.ObjectSpace, dtiTypeInfo, lstController, False, Nothing, objViewCollection, Nothing, vsaViewSettingsAttribute.ViewInModalWindow, vsaViewSettingsAttribute.AllowEditInView)
                    Else
                        Helpers.ViewHelper.CreateDetailViewThroughStrategy(CustomFrame, String.Empty, False, Me.Helper.ObjectSpace, dtiTypeInfo, Nothing, False, Nothing, objViewCollection, Nothing, Nothing, Nothing)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ExecuteCustomButtonAction(ByVal ButtonAttribute As ISS.Base.Attributes.ObjectEditor.CustomEditorButtonAttribute)

        Dim objISSBaseView As New ISS.Base.ISSBaseViewController
        Dim lstController As New List(Of Controller)

        For Each objControllerTest As Object In Me.CustomFrame.Controllers
            If objControllerTest.GetType.FullName = ButtonAttribute.ControllerFullTypeName Then
                Dim objMethodInfo As System.Reflection.MethodInfo = objControllerTest.GetType.GetMethod(ButtonAttribute.ButtonExecuteMethod)
                objMethodInfo.Invoke(objControllerTest, Nothing)
            End If
        Next

    End Sub

    Private Sub DeleteObject()
        Dim dxgGridControl As DevExpress.XtraGrid.GridControl
        Dim dxvGridView As DevExpress.XtraGrid.Views.Grid.GridView
        If _mLookupEdit.EditValue IsNot Nothing Then
            If MsgBox("Are you sure you want to clear this entry?", MsgBoxStyle.YesNoCancel, "Confirm Remove") = MsgBoxResult.Yes Then
                _mLookupEdit.EditValue = Nothing

                If _mLookupEdit.InplaceType = InplaceType.Grid Then
                    dxgGridControl = _mLookupEdit.Parent
                    dxvGridView = dxgGridControl.Views(0)
                    dxvGridView.PostEditor()
                    'create editing object if not exists
                    For Each objColumn As DevExpress.XtraGrid.Columns.GridColumn In dxvGridView.Columns
                        If objColumn.FieldName = Me.MemberInfoFix.BindingName Then
                            dxvGridView.SetFocusedRowCellValue(objColumn, Nothing)
                        End If
                    Next
                End If

            End If
        End If
    End Sub

    Private Sub CreateChildObject()

    End Sub

    Private Sub ObjectEditButtonPressed(ByVal IsNew As Boolean, Optional ByVal ChildObject As Object = Nothing, Optional ByVal ApplyChildObject As Boolean = True, Optional ByVal ViewSettingsAttribute As Attributes.View.ViewSettingsAttribute = Nothing)
        Dim objISSBaseView As New ISSBaseViewController
        Dim objControllers As New System.Collections.Generic.List(Of DevExpress.ExpressApp.Controller)
        Dim objView As View
        Dim objExpandObjectEditorAttribute As Attributes.ObjectEditor.ExpandObjectEditorAttribute
        Dim blnIsRoot As Boolean = False
        Dim objShowNewInDetailView As Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute
        Dim objViewSettingsAttribute As Attributes.View.ViewSettingsAttribute = ViewSettingsAttribute
        Dim dtiTypeInfo As DevExpress.ExpressApp.DC.TypeInfo
        Dim strViewID As String = String.Empty
        Dim mmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo
        Try
            If Me.Model.View IsNot Nothing Then
                strViewID = Me.Model.View.Id
            End If
            If ChildViewController IsNot Nothing AndAlso ChildWindowController IsNot Nothing AndAlso ChildWindow IsNot Nothing Then
                ChildWindow.Form.Activate()
                Return
            End If

            objExpandObjectEditorAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.ObjectEditor.ExpandObjectEditorAttribute)()
            objShowNewInDetailView = Me.MemberInfoFix.FindAttribute(Of Attributes.ObjectEditor.CustomPropertyLinkButtonAttribute)()
            If objExpandObjectEditorAttribute IsNot Nothing AndAlso objExpandObjectEditorAttribute.EditMode = Attributes.ObjectEditor.ExpandObjectEditorAttribute.ExpandObjectEditMode.EditOnForm AndAlso IsNew = True Then
                ChildObject = Helper.ObjectSpace.CreateObject(Me.Helper.LookupObjectTypeInfo.Type)
                CType(ChildObject, XPBaseObject).Save()
                _mLookupEdit.EditValue = ChildObject
                SaveParentProperty()
                If Me.MemberInfoFix IsNot Nothing Then
                    Dim dsaAttribute As DevExpress.Persistent.Base.DataSourcePropertyAttribute
                    dsaAttribute = Me.MemberInfoFix.FindAttribute(Of DevExpress.Persistent.Base.DataSourcePropertyAttribute)()
                    If dsaAttribute IsNot Nothing Then

                        Helpers.ReflectionHelper.AddObjectToPropertyCollection(ChildObject, BindingHelper.DataSource, dsaAttribute.DataSourceProperty)
                    End If
                End If
                Helper.ObjectSpace.CommitChanges()
                Helper.ObjectSpace.Refresh()
                Return
            End If

            objISSBaseView.ParentView = Me.View
            _mChildViewController = objISSBaseView


            objControllers.Add(objISSBaseView)

            If objViewSettingsAttribute Is Nothing Then
                objViewSettingsAttribute = Me.MemberInfoFix.FindAttribute(Of Attributes.View.ViewSettingsAttribute)()
            End If

            If objViewSettingsAttribute IsNot Nothing Then
                If objViewSettingsAttribute.AllowNewInView = False Then
                    objISSBaseView.ISSViewParameters.IsNewVisible = objViewSettingsAttribute.AllowNewInView
                End If
                If objViewSettingsAttribute.AllowDeleteInView = False Then
                    objISSBaseView.ISSViewParameters.IsDeleteVisible = objViewSettingsAttribute.AllowDeleteInView
                End If
                If objViewSettingsAttribute.ViewInModalWindow = True Then
                    _mChildObject = Helpers.ViewHelper.CreateDetailViewThroughStrategy(CustomFrame, strViewID, blnIsRoot, Helper.ObjectSpace, Helper.LookupObjectTypeInfo, objControllers, IsNew, Me.CurrentObject, ChildObject, Helper.LookupObjectTypeInfo.ReferenceToOwner, objViewSettingsAttribute.ViewInModalWindow, objViewSettingsAttribute.AllowEditInView)
                    'Try
                    If _mChildObject IsNot Nothing Then
                        If ApplyChildObject = True Then
                            ApplyObject(_mChildObject)
                        End If
                    End If
                    'Catch ex As Exception
                    'End Try
                Else
                    objView = Helpers.ViewHelper.CreateDetailViewThroughStrategy(CustomFrame, strViewID, blnIsRoot, Helper.ObjectSpace, Helper.LookupObjectTypeInfo, objControllers, IsNew, Me.CurrentObject, ChildObject, Helper.LookupObjectTypeInfo.ReferenceToOwner, objViewSettingsAttribute.ViewInModalWindow, objViewSettingsAttribute.AllowEditInView)
                    If ApplyChildObject = True Then
                        _mChildObject = objView.CurrentObject
                        If objView.ObjectSpace IsNot Nothing Then
                            AddHandler objView.ObjectSpace.Committed, AddressOf ViewCommitted
                        Else
                            ApplyObject(_mChildObject)
                        End If
                    End If
                End If
            Else

                objView = Helpers.ViewHelper.CreateDetailViewThroughStrategy(CustomFrame, strViewID, blnIsRoot, Helper.ObjectSpace, Helper.LookupObjectTypeInfo, objControllers, IsNew, Me.CurrentObject, ChildObject, Helper.LookupObjectTypeInfo.ReferenceToOwner, False, Not _mRepositoryItem.ReadOnly, PropertyName, MemberInfo)
                If ApplyChildObject = True Then
                    _mChildObject = objView.CurrentObject
                    If objView.ObjectSpace IsNot Nothing Then
                        AddHandler objView.ObjectSpace.Committed, AddressOf ViewCommitted
                    Else
                        If objView.Tag IsNot Nothing AndAlso objView.Tag.ToString = "Saved" Then
                            ApplyObject(_mChildObject)
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ViewCommitted(ByVal sender As Object, ByVal e As EventArgs)
        ApplyObject(_mChildObject)
    End Sub

    Private Sub SetupEllipsisVisibility()
        Dim strParentProperty As String = String.Empty
        Dim dxgGridControl As DevExpress.XtraGrid.GridControl
        Dim dxvGridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim objCurrent As Object = Nothing
        Dim objOpenObjectattribute As Attributes.ObjectEditor.OpenObjectAction.DisableObjectCreationIfNothingAttribute
        Me.ImmediatePostData = True
        If _mLookupEdit IsNot Nothing Then
            If _mLookupEdit.InplaceType = InplaceType.Grid Then
                dxgGridControl = _mLookupEdit.Parent
                dxvGridView = dxgGridControl.Views(0)
                dxvGridView.PostEditor()
                If dxvGridView.GetFocusedRow Is Nothing Then
                    dxvGridView.AddNewRow()
                End If
                'create editing object if not exists
                objCurrent = dxvGridView.GetFocusedRow
            Else
                objCurrent = Me.CurrentObject
            End If
            objOpenObjectattribute = Me.MemberInfo.FindAttribute(Of Attributes.ObjectEditor.OpenObjectAction.DisableObjectCreationIfNothingAttribute)()
            If MemberInfoFix.IsAggregated = False Or (objOpenObjectattribute IsNot Nothing AndAlso IsEllipsisAvailable() = True) Then
                If objCurrent Is Nothing Then
                    _mEllipsisButton.Enabled = False
                Else
                    'check if property is aggregate and if it has a property value
                    If Me.MemberInfo.SerializeValue(objCurrent) = String.Empty Then
                        _mEllipsisButton.Enabled = False
                    Else
                        _mEllipsisButton.Enabled = True
                    End If

                End If
            End If
        End If

    End Sub

    'TODO: Check If Elipsis is available
    Public Function IsEllipsisAvailable() As Boolean
        Dim objExpandObjectEditorAttribute As Attributes.ObjectEditor.ExpandObjectEditorAttribute = Me.MemberInfo.FindAttribute(Of Attributes.ObjectEditor.ExpandObjectEditorAttribute)()
        If objExpandObjectEditorAttribute Is Nothing OrElse objExpandObjectEditorAttribute.EditMode = Attributes.ObjectEditor.ExpandObjectEditorAttribute.ExpandObjectEditMode.EditInNew Then
            If MyObjectEditorButtonsAttribute Is Nothing OrElse MyObjectEditorButtonsAttribute.IsEllipsisVisible = True Then
                If DevExpress.ExpressApp.SecuritySystem.IsGranted(New ObjectAccessPermission(Me.MemberInfoFix.MemberType, ObjectAccess.Read, ObjectAccessModifier.Allow)) = True Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Protected Overrides Sub WriteValueCore()
        MyBase.WriteValueCore()
        SetupEmailButton(Nothing, Nothing)
        SetupEllipsisVisibility()
    End Sub

    'Public Sub RefreshObject()
    '    If _mLookupEdit IsNot Nothing AndAlso _mLookupEdit.EditValue IsNot Nothing Then
    '        _mLookupEdit.Properties.BeginUpdate()
    '        _mLookupEdit.Properties.EndUpdate()
    '    End If


    'End Sub

    Private Sub SaveParentProperty()
        Dim objBaseObject As Object = Helpers.ReflectionHelper.GetObjectFromPropertyName(Me.PropertyName, Me.CurrentObject)
        Try
            CType(objBaseObject, XPBaseObject).Save()
            CType(Me.CurrentObject, XPBaseObject).Save()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ApplyObject(ByVal ChildObject As Object)
        Dim dsaAttribute As DevExpress.Persistent.Base.DataSourcePropertyAttribute
        Dim strParentProperty As String = String.Empty
        Dim dxgGridControl As DevExpress.XtraGrid.GridControl
        Dim dxvGridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim objCurrent As Object

        Me.ImmediatePostData = True
        If ChildObject Is Nothing Then
            If _mLookupEdit IsNot Nothing Then
                _mLookupEdit.EditValue = Nothing
            End If
            Return
        Else
            ChildObject = Me.Helper.ObjectSpace.GetObject(ChildObject)
            If Me.Helper.ObjectSpace.IsDeletedObject(ChildObject) = True Then
                If _mLookupEdit IsNot Nothing Then
                    _mLookupEdit.EditValue = Nothing
                End If
                Return
            End If
        End If
        Try
            CType(ChildObject, XPBaseObject).Save()
        Catch ex As Exception
            Throw ex
        End Try

        If _mLookupEdit.InplaceType = InplaceType.Grid Then
            dxgGridControl = _mLookupEdit.Parent
            dxvGridView = dxgGridControl.Views(0)
            dxvGridView.PostEditor()
            If dxvGridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                Return
            End If
            If dxvGridView.GetFocusedRow Is Nothing Then
                dxvGridView.AddNewRow()
            End If
            'create editing object if not exists
            objCurrent = dxvGridView.GetFocusedRow
            ISS.Base.Helpers.ReflectionHelper.SetObjectPropertyName(Me.MemberInfoFix.Name, objCurrent, ChildObject)
            For Each objColumn As DevExpress.XtraGrid.Columns.GridColumn In dxvGridView.Columns
                If objColumn.FieldName = Me.MemberInfoFix.BindingName Then
                    dxvGridView.SetFocusedRowCellValue(objColumn, _mLookupEdit.Properties.Helper.ObjectSpace.GetObject(ChildObject))
                End If
            Next
        Else
            objCurrent = Me.CurrentObject
            If objCurrent IsNot Nothing Then
                ISS.Base.Helpers.ReflectionHelper.SetObjectPropertyName(Me.PropertyName, objCurrent, Helper.ObjectSpace.GetObject(ChildObject))
                _mLookupEdit.EditValue = Helper.ObjectSpace.GetObject(ChildObject)
                _mLookupEdit.IsModified = True
            End If
            If Me.MemberInfo IsNot Nothing Then
                dsaAttribute = Me.MemberInfo.FindAttribute(Of DevExpress.Persistent.Base.DataSourcePropertyAttribute)()
                If dsaAttribute IsNot Nothing Then
                    strParentProperty = Helpers.ReflectionHelper.GetParentProperty(Me.PropertyName)
                    If strParentProperty > String.Empty Then
                        Helpers.ReflectionHelper.SetObjectPropertyName(strParentProperty + "." + dsaAttribute.DataSourceProperty, BindingHelper.DataSource, Helper.ObjectSpace.GetObject(ChildObject))
                        Helpers.ReflectionHelper.AddObjectToPropertyCollection(ChildObject, BindingHelper.DataSource, strParentProperty + "." + dsaAttribute.DataSourceProperty)
                    Else
                        Helpers.ReflectionHelper.SetObjectPropertyName(dsaAttribute.DataSourceProperty, BindingHelper.DataSource, Helper.ObjectSpace.GetObject(ChildObject))
                        Helpers.ReflectionHelper.AddObjectToPropertyCollection(ChildObject, BindingHelper.DataSource, dsaAttribute.DataSourceProperty)
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub BindEmailHandlerToObject()
        Dim objChildToBind As Object

        If Me.CurrentObject IsNot Nothing Then
            If Me.MemberInfo.Name.Contains(".") Then
                objChildToBind = Helpers.ReflectionHelper.GetObjectFromPropertyName(Helpers.ReflectionHelper.GetParentProperty(Me.MemberInfo.Name), Me.CurrentObject)
            Else
                objChildToBind = Me.CurrentObject
            End If
            If objChildToBind IsNot Nothing Then
                AddHandler CType(objChildToBind, XPBaseObject).Changed, AddressOf SetupEmailButton
            End If
        End If
    End Sub

    Private Sub ObjectLookupEditor_CurrentObjectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CurrentObjectChanged
        _mEmailImplementationType = EmailHelper.GetEmailImplementationType(Me.MemberInfo)
        If _mEmailImplementationType <> EmailHelper.EmailImplementationType.None Then
            SetupEmailButton(Nothing, Nothing)
            BindEmailHandlerToObject()
        End If
        SetupEllipsisVisibility()
    End Sub

    Private Sub ObjectLookupEditor_ValueStored(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ValueStored
        Dim objExpandObjectEditorAttribute As Attributes.ObjectEditor.ExpandObjectEditorAttribute
        objExpandObjectEditorAttribute = Me.MemberInfo.FindAttribute(Of Attributes.ObjectEditor.ExpandObjectEditorAttribute)()
        If objExpandObjectEditorAttribute IsNot Nothing AndAlso objExpandObjectEditorAttribute.EditMode = Attributes.ObjectEditor.ExpandObjectEditorAttribute.ExpandObjectEditMode.EditOnForm Then
            CType(Me.CurrentObject, XPBaseObject).Save()
            Helper.ObjectSpace.CommitChanges()
            Return
        End If
        SetupEllipsisVisibility
    End Sub

    Private Sub SetupEmailButton(ByVal sender As Object, ByVal e As EventArgs)
        Dim objEmailer As ISS.Base.Interfaces.IEmail = Nothing
        Dim strToAddresses As String = String.Empty
        Dim objEmail As ISSBaseEmailMessage
        Dim dxgGridControl As DevExpress.XtraGrid.GridControl
        Dim dxvGridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim objCurrent As Object = Nothing

        _mEmailImplementationType = EmailHelper.GetEmailImplementationType(Me.MemberInfo)
        If _mEmailImplementationType <> EmailHelper.EmailImplementationType.None Then
            If sender IsNot Nothing AndAlso TypeOf sender Is LookupEdit Then
                _mLookupEdit = sender
                If _mLookupEdit.InplaceType = InplaceType.Grid Then
                    dxgGridControl = _mLookupEdit.Parent
                    dxvGridView = dxgGridControl.Views(0)
                    If dxvGridView.IsFilterRow(dxvGridView.FocusedRowHandle) = False Then
                        If dxvGridView.GetFocusedRow Is Nothing Then
                            dxvGridView.AddNewRow()
                        End If
                        'create editing object if not exists
                        objCurrent = dxvGridView.GetFocusedRow
                    End If
                Else
                    objCurrent = Me.CurrentObject
                End If
            Else
                objCurrent = Me.CurrentObject
            End If

            If objCurrent IsNot Nothing Then
                If _mEmailImplementationType = EmailHelper.EmailImplementationType.Implementor Then
                    objEmailer = Helpers.ReflectionHelper.GetObjectFromPropertyName(Me.PropertyName, objCurrent)
                Else
                    If Me.MemberInfo.Name.Contains(".") Then
                        objEmailer = Helpers.ReflectionHelper.GetObjectFromPropertyName(Helpers.ReflectionHelper.GetParentProperty(Me.MemberInfo.Name), Me.CurrentObject)
                    Else
                        objEmailer = Me.CurrentObject
                    End If
                End If
                If objEmailer IsNot Nothing Then
                    objEmail = objEmailer.GetEmail(Me.CurrentObject, Me.MemberInfo)
                    For intLoop As Integer = 0 To objEmail.ToAddresses.Count - 1
                        strToAddresses = strToAddresses + objEmail.ToAddresses(intLoop)
                    Next
                    If strToAddresses = String.Empty Then
                        _mEmailButton.Enabled = False
                    Else
                        _mEmailButton.Enabled = True
                    End If
                Else
                    _mEmailButton.Enabled = False
                End If
            Else
                _mEmailButton.Enabled = False
            End If
        End If
    End Sub

End Class

Public Class CustomRepositoryItemLookupEdit
    Inherits RepositoryItemLookupEdit

    Private Shared _mEditorClassInfo As EditorClassInfo
    Public Shared EditorName As String = "CustomLookupSearchEditor"
    Public Shared Sub RegisterEditor()
        Dim strEditorName As String = "CustomLookupEdit"
        If EditorRegistrationInfo.Default.Editors.Contains(EditorName) = False Then
            _mEditorClassInfo = New EditorClassInfo(EditorName, GetType(CustomLookupEdit), GetType(CustomRepositoryItemLookupEdit),
                                                    GetType(PopupBaseEditViewInfo), New ButtonEditPainter, True, EditImageIndexes.LookUpEdit,
                                                    GetType(DevExpress.Accessibility.PopupEditAccessible))
            EditorRegistrationInfo.Default.Editors.Add(_mEditorClassInfo)
        Else
            _mEditorClassInfo = EditorRegistrationInfo.Default.Editors(EditorName)
        End If
    End Sub

    Public Sub New()
        MyBase.New()

        TextEditStyle = TextEditStyles.Standard
    End Sub

    Protected Overrides ReadOnly Property EditorClassInfo As DevExpress.XtraEditors.Registrator.EditorClassInfo
        Get
            Return _mEditorClassInfo
        End Get
    End Property

    Public Overrides ReadOnly Property EditorTypeName As String
        Get
            Return EditorName
        End Get
    End Property

End Class

Public Class CustomLookupEdit
    Inherits LookupEdit
    

    Public Overloads ReadOnly Property Properties As CustomRepositoryItemLookupEdit
        Get
            Return MyBase.Properties
        End Get
    End Property

    Public Overrides ReadOnly Property EditorTypeName As String
        Get
            Return CustomRepositoryItemLookupEdit.EditorName
        End Get
    End Property

    Public Overrides Property Text As String
        Get
            If _mTempText > String.Empty Then
                Return _mTempText
            End If
            Return MyBase.Text
        End Get
        Set
            MyBase.Text = value
        End Set
    End Property

    Private _mTempText As String
    Public Overrides Property EditValue As Object
        Get
            If TypeOf MyBase.EditValue Is String Then
                Return Nothing
            Else
                Return MyBase.EditValue
            End If
        End Get
        Set(value As Object)
            If TypeOf value Is String Then

                If Properties.Helper.Model.ImmediatePostData = True AndAlso Properties.Helper.Model.ModelMember.MemberInfo.MemberTypeInfo.DefaultMember.SerializeValue(MyBase.EditValue) <> Text Then
                    Dim obj As Object = Nothing
                    Dim obsObjectSpace As IObjectSpace = Properties.Helper.ObjectSpace
                    Dim strProperty As String = Properties.Helper.Model.ModelMember.MemberInfo.FindAttribute(Of EditorSearchModeAttribute).SearchProperty
                    If strProperty = String.Empty Then
                        strProperty = Properties.Helper.DisplayMember.Name
                    End If
                    If Properties.Helper.Model.ModelMember.MemberInfo.FindAttribute(Of EditorSearchModeAttribute).SearchMode = EditorSearchModeAttribute.SupportedModes.ExactSearchWithText Then
                        obj = obsObjectSpace.FindObject(Properties.Helper.Model.ModelMember.MemberInfo.MemberType,
                                              New BinaryOperator(strProperty, value))
                    Else
                        obj = obsObjectSpace.FindObject(Properties.Helper.Model.ModelMember.MemberInfo.MemberType,
                                              New BinaryOperator(strProperty, "%" + value + "%", BinaryOperatorType.Like))
                    End If

                    If obj Is Nothing And value > String.Empty Then
                        ShowPopupWithSearchText()
                        Return
                    End If
                    MyBase.EditValue = obj
                    _mTempText = String.Empty
                Else
                    MyBase.EditValue = Nothing
                    _mTempText = value
                    IsModified = True
                End If
                'todo: look against default property and set appropriately
            Else
                MyBase.EditValue = value    
                If value IsNot Nothing Then
                    _mTempText = String.Empty    
                End If
            End If
        End Set
    End Property
    Private _mPopupOpen As Boolean = False
    Protected Overrides Sub OnPopupClosing(e As CloseUpEventArgs)
        MyBase.OnPopupClosing(e)
        _mPopupOpen = False
    End Sub
    Protected Overrides Sub OnPopupClosed(closeMode As DevExpress.XtraEditors.PopupCloseMode)
        MyBase.OnPopupClosed(closeMode)
        _mTempText = String.Empty
    End Sub

    Public Sub ShowPopupWithSearchText()
        'If PopupForm Is Nothing Then
         ShowPopup

        'PopupForm.Template.SetStartSearchString(Text)
        For intLoop As Integer = 1 To Text.Length
            PopupForm.Template.SetStartSearchString(Text.Substring(0,intLoop))
        Next
        'if grid mode, set edit value
        If InplaceType <> DevExpress.XtraEditors.Controls.InplaceType.Standalone Then
            MyBase.EditValue = PopupForm.SelectedObject
        End If
        
        'PopupForm.ShowPopupForm
        'End If

        'Dim objForm As DevExpress.ExpressApp.Win.Templates.LookupControlTemplate = PopupForm.Template
        'objForm.FocusFindEditor
        
    End Sub
    

    Protected Overrides Sub OnEditorKeyPress(e As Windows.Forms.KeyPressEventArgs)
        'Prevent popup
        
        'Stop
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub OnValidated(e As EventArgs)
        MyBase.OnValidated(e)
    End Sub

    Protected Overrides Sub OnValidating(e As ComponentModel.CancelEventArgs)
        'MyBase.OnValidating(e)
        If Properties.Helper.Model.ImmediatePostData = False Then
            If Text = String.Empty Then
                EditValue = Nothing
                e.Cancel = False
                Return
            End If
            If Properties.Helper.Model.ModelMember.MemberInfo.MemberTypeInfo.DefaultMember.SerializeValue(MyBase.EditValue) = Text Then
                EditValue = MyBase.EditValue
                e.Cancel = False
                Return
            End If
            Dim obj As Object = Nothing
            Dim obsObjectSpace As IObjectSpace = Properties.Helper.ObjectSpace
            Dim strProperty As String = Properties.Helper.Model.ModelMember.MemberInfo.FindAttribute(Of EditorSearchModeAttribute).SearchProperty
            If strProperty = String.Empty Then
                strProperty = Properties.Helper.DisplayMember.Name
            End If
            If Properties.Helper.Model.ModelMember.MemberInfo.FindAttribute(Of EditorSearchModeAttribute).SearchMode = EditorSearchModeAttribute.SupportedModes.ExactSearchWithText Then
                obj = obsObjectSpace.FindObject(Properties.Helper.Model.ModelMember.MemberInfo.MemberType,
                                        New BinaryOperator(strProperty, Text))
            Else
                obj = obsObjectSpace.FindObject(Properties.Helper.Model.ModelMember.MemberInfo.MemberType,
                                        New BinaryOperator(strProperty, "%" + Text + "%", BinaryOperatorType.Like))
            End If
            If obj Is Nothing And Properties.Helper.Model.ImmediatePostData = False Then
                ShowPopupWithSearchText()
                e.Cancel = True 
            Elseif obj IsNot Nothing And Properties.Helper.Model.ImmediatePostData = False Then
                MyBase.EditValue = obj
                _mTempText = String.Empty
            End If
        End If
    End Sub


    Private Sub CustomLookupEdit_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Validating
        
    End Sub
End Class