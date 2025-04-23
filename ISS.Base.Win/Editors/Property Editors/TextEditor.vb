Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.SystemModule
Imports ISS.Base.Helpers
Imports DevExpress.XtraEditors
Imports Alias1 = System.Collections.Generic
Imports ISS.Base.Interfaces
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win.Core.ModelEditor
Imports ISS.Base.Attributes.Editors.TextEditor
Imports System.Windows.Forms
Imports System.Linq

<PropertyEditor(GetType(String), True)> _
Public Class TextEditor
    Inherits StringPropertyEditor
    Implements IGridInplaceEdit

    Private _mEmailButton As New EditorButton(ButtonPredefines.Glyph)
    Private WithEvents _mRepositoryItem As RepositoryItemButtonEdit
    Private WithEvents _mControl As ButtonEdit

    'TODO: Find attribute pointing to type property
    'TODO: Allow right click and inserting of that property with popup that asks for property type

    Private _mEmailImplementationType As EmailHelper.EmailImplementationType
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


#Region "Properties"
    Public ReadOnly Property IsSimpleString() As Boolean
        Get
            Return MemberInfo.MemberType IsNot GetType(String) OrElse Model.RowCount = 0
        End Get
    End Property

    Private _mObject As Object
    Public Property GridEditingObject As Object Implements IGridInplaceEdit.GridEditingObject
        Get
            Return _mObject
        End Get
        Set(value As Object)
            _mObject = value
            RefreshEditor()
        End Set
    End Property

    Public ReadOnly Property DataBindings As ControlBindingsCollection Implements IGridInplaceEdit.DataBindings
        Get
            Return _mControl.DataBindings
        End Get
    End Property
    'Public ReadOnly Property IsPropertyNameInsertEditor As Boolean
    '    Get
    '        Return (MemberInfo.FindAttribute(Of AllowPropertyOfTypeInsertAttribute)() IsNot Nothing)
    '    End Get
    'End Property
#End Region

    Public ReadOnly Property RealCurrentObject As Object
        Get
            If _mRepositoryItem IsNot Nothing AndAlso TypeOf _mRepositoryItem Is RepositoryItemButtonEditEx AndAlso CType(_mRepositoryItem, RepositoryItemButtonEditEx).GridEditingObject IsNot Nothing Then
                Return CType(_mRepositoryItem, RepositoryItemButtonEditEx).GridEditingObject
            End If

            If View IsNot Nothing AndAlso View.CurrentObject IsNot Nothing Then
                Return View.CurrentObject
            End If

            If CurrentObject Is Nothing Then
                Return _mObject
            End If
            Return CurrentObject
        End Get
    End Property

#Region "Behaviors"
    Private Sub BindEmailHandlerToObject()
        Dim objChildToBind As Object

        If RealCurrentObject Is Nothing Then
            Return
        End If
        If MemberInfo Is Nothing Then
            Return
        End If
        If MemberInfo.Name.Contains(".") Then
            objChildToBind = ReflectionHelper.GetObjectFromPropertyName(ReflectionHelper.GetParentProperty(Me.MemberInfo.Name), Me.RealCurrentObject)
        Else
            objChildToBind = RealCurrentObject
        End If
        If objChildToBind IsNot Nothing Then
            RemoveHandler CType(objChildToBind, XPCustomObject).Changed, AddressOf SetupEmailButton
            AddHandler CType(objChildToBind, XPCustomObject).Changed, AddressOf SetupEmailButton
        End If
    End Sub
    Private Sub RemoveHandlers()
        Dim objChildToBind As Object

        If RealCurrentObject Is Nothing Then
            Return
        End If
        If MemberInfo Is Nothing Then
            Return
        End If
        If MemberInfo.Name.Contains(".") Then
            objChildToBind = ReflectionHelper.GetObjectFromPropertyName(ReflectionHelper.GetParentProperty(Me.MemberInfo.Name), Me.RealCurrentObject)
        Else
            objChildToBind = RealCurrentObject
        End If
        If objChildToBind IsNot Nothing Then
            RemoveHandler CType(objChildToBind, XPCustomObject).Changed, AddressOf SetupEmailButton
        End If
        RemoveHandler CurrentObjectChanged, AddressOf SetupEmailButton
    End Sub
    Private Sub TextEditor_ValueRead(ByVal sender As Object, ByVal e As EventArgs) Handles Me.ValueRead
        If MemberInfo Is Nothing Then
            Return
        End If
        SetupEmailButton(Me, Nothing)

    End Sub
    Public Overrides Sub BreakLinksToControl(ByVal unwireEventsOnly As Boolean)
        MyBase.BreakLinksToControl(unwireEventsOnly)
        If MemberInfo Is Nothing Then
            Return
        End If
        RemoveHandlers()
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If MemberInfo Is Nothing Then
            Return
        End If
        RemoveHandlers()
    End Sub

    Protected Overrides Function CreateControlCore() As Object
        Dim ctrControl As System.Windows.Forms.Control = Nothing
        Dim menMemberEditorName As Attributes.Editors.PropertyEditors.MemberNameEditorAttribute
        Dim vieEditor As Attributes.Editors.PropertyEditors.ViewIdEditorAttribute
        Dim mnpPropertySource As Attributes.Editors.PropertyEditors.MemberNamePropertySourceAttribute
        If MemberInfo IsNot Nothing Then
            menMemberEditorName = MemberInfo.FindAttribute(Of Attributes.Editors.PropertyEditors.MemberNameEditorAttribute)()
            mnpPropertySource = MemberInfo.FindAttribute(Of Attributes.Editors.PropertyEditors.MemberNamePropertySourceAttribute)()
            vieEditor = MemberInfo.FindAttribute(Of Attributes.Editors.PropertyEditors.ViewIdEditorAttribute)()
            If menMemberEditorName IsNot Nothing Then
                ctrControl = GetPickerControl(menMemberEditorName.ObjectType, String.Empty)
            ElseIf mnpPropertySource IsNot Nothing Then
                ctrControl = GetPickerControl(GetTypeFromProperty(mnpPropertySource.ObjectTypeProperty), mnpPropertySource.PropertyTypeFilter)
            ElseIf vieEditor IsNot Nothing
                ctrControl = GetViewPickerControl()
            ElseIf IsSimpleString Then
                _mControl = New ButtonEdit
                _mControl.Properties.Buttons.Clear()
                ctrControl = _mControl
            End If
        End If
        If ctrControl Is Nothing Then
            ctrControl = MyBase.CreateControlCore
        End If

        Return ctrControl
    End Function

    Public Function GetTypeFromProperty(ByVal PropertyName As String) As Type
        Return Me.MemberInfo.Owner.FindMember(PropertyName).GetValue(RealCurrentObject)
    End Function
    Public Function GetViewPickerControl()
        Return New DevExpress.XtraEditors.ComboBox()
    End Function
    Public Sub SetupViewPickerRepositoryItem(ByVal item As RepositoryItem, TargetType As Type)
        If Not TypeOf item Is RepositoryItemComboBox
            Return
        End If
        
        CType(item, RepositoryItemComboBox).Items.Clear
        CType(item, RepositoryItemComboBox).TextEditStyle = TextEditStyles.DisableTextEditor
        If TargetType Is Nothing
            Return
        End If

        For Each x As IModelDetailView In Me.Model.Application.Views.GetNodes(Of IModelDetailView)
            If x.ModelClass.Name = TargetType.FullName Then
                CType(item, RepositoryItemComboBox).Items.Add(x.Id)
            End If
        Next
        
    End Sub
    Public Function GetPickerControl(ByVal TargetType As Type, ByVal PropertyFilter As String) As FieldPicker
        Dim pckPicker As New CustomFieldPicker
        pckPicker.Properties.ClassType = TargetType
        pckPicker.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
        pckPicker.PropertyFilter = PropertyFilter
        Return pckPicker
    End Function
    Public Function GetRepositoryItemForType(ByVal TargetType As Type) As RepositoryFieldPicker
        Dim pckPicker As New RepositoryFieldPicker
        pckPicker.ClassType = TargetType
        pckPicker.TextEditStyle = TextEditStyles.DisableTextEditor
        Return pckPicker
    End Function
    Protected Overrides Function CreateRepositoryItem() As RepositoryItem
        Dim vieEditor As Attributes.Editors.PropertyEditors.ViewIdEditorAttribute
        Dim menMemberEditorName As Attributes.Editors.PropertyEditors.MemberNameEditorAttribute


        If Model IsNot Nothing AndAlso Model.ModelMember IsNot Nothing Then
            menMemberEditorName = Model.ModelMember.MemberInfo.FindAttribute(Of Attributes.Editors.PropertyEditors.MemberNameEditorAttribute)()
            If menMemberEditorName IsNot Nothing Then
                Return GetRepositoryItemForType(menMemberEditorName.ObjectType)
            End If
        End If

        If MemberInfo IsNot Nothing AndAlso IsSimpleString Then
            _mRepositoryItem = New RepositoryItemButtonEditEx
            AddHandler CType(_mRepositoryItem, RepositoryItemButtonEditEx).EventObjectChanged, AddressOf RefreshEditor
            For Each objButton As EditorButton In _mRepositoryItem.Buttons
                objButton.Visible = False
            Next
            Return _mRepositoryItem
        Else
            Return MyBase.CreateRepositoryItem()
        End If
    End Function

    Private Sub View_CurrentObjectChanged(sender As Object, e As EventArgs)
        RefreshEditor()
    End Sub

    Public Class RepositoryItemButtonEditEx
        Inherits RepositoryItemButtonEdit
        Implements IGridInplaceEdit
        Public Event EventObjectChanged()
        Public Sub New()

        End Sub

        Public Sub UpdateObject()
            RaiseEvent EventObjectChanged()
        End Sub

        Private _mEditingObject As Object
        Public Property GridEditingObject As Object Implements IGridInplaceEdit.GridEditingObject
            Get
                Return _mEditingObject
            End Get
            Set(value As Object)
                _mEditingObject = value
                UpdateObject()
            End Set
        End Property

        Public ReadOnly Property DataBindings As ControlBindingsCollection Implements IGridInplaceEdit.DataBindings
            Get
                Return Nothing
            End Get
        End Property
    End Class

    Protected Overrides Sub OnValueRead()
        MyBase.OnValueRead()
        Dim vieEditor As Attributes.Editors.PropertyEditors.ViewIdEditorAttribute
        Dim cbeComboBoxEdit As ComboBoxEdit= TryCast(Control,ComboBoxEdit)
        Dim typViewType As Type
        If MemberInfo Is Nothing OrElse cbeComboBoxEdit Is Nothing Then
            Return
        End If
        vieEditor = MemberInfo.FindAttribute(Of Attributes.Editors.PropertyEditors.ViewIdEditorAttribute)()
        If vieEditor IsNot Nothing Then
            typViewType = MemberInfo.Owner.FindMember(vieEditor.ObjectTypeMember).GetValue(RealCurrentObject)
            SetupViewPickerRepositoryItem(cbeComboBoxEdit.Properties,typViewType)
        End If
    End Sub

    Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        If TypeOf item Is RepositoryFieldPicker Then
            Return
        End If
        If MemberInfo Is Nothing Then
            Return
        End If



        Dim objCustomAttributes As Alias1.IEnumerable(Of CustomAttribute)
        Dim objCustomAttribute As CustomAttribute
        Dim mmeMemoEdit As RepositoryItemLargeStringEdit
        Dim mmeMemoExEdit As RepositoryItemMemoExEdit
        Dim vieEditor As Attributes.Editors.PropertyEditors.ViewIdEditorAttribute
        Dim objButton As EditorButton
        Dim typViewType As Type
        Dim objCustomButtons As System.Collections.Generic.IEnumerable(Of ISS.Base.Attributes.ObjectEditor.CustomEditorButtonAttribute)

        vieEditor = MemberInfo.FindAttribute(Of Attributes.Editors.PropertyEditors.ViewIdEditorAttribute)()
        If vieEditor IsNot Nothing Then
            typViewType = MemberInfo.Owner.FindMember(vieEditor.ObjectTypeMember).GetValue(RealCurrentObject)
            SetupViewPickerRepositoryItem(item,typViewType)
            Return
        End If

        'TODO: find a way to add context menu option
        'TODO: insert property name

        If IsSimpleString = True Then
            _mRepositoryItem = item
            _mRepositoryItem.Buttons.Clear()

            'If IsPropertyNameInsertEditor = True Then
            '    If _mRepositoryItem.ContextMenu Is Nothing Then
            '        _mRepositoryItem.ContextMenu = New ContextMenu
            '    End If
            '    _mRepositoryItem.ContextMenu.MenuItems.Add("Insert Property", New EventHandler(AddressOf RepositoryItem_ContextMenuClicked))
            'End If
            If MemberInfo.Size > 0 AndAlso MemberInfo.Size < 256 Then
                _mRepositoryItem.MaxLength = MemberInfo.Size
            End If

            _mEmailButton.Image = My.Resources.mail_send
            _mEmailButton.ImageLocation = ImageLocation.MiddleCenter
            objCustomAttributes = MemberInfo.FindAttributes(Of CustomAttribute)()
            For Each objCustomAttribute In objCustomAttributes
                If objCustomAttribute.Name > String.Empty AndAlso String.Compare(objCustomAttribute.Name.ToUpper, "DISPLAYFORMAT", False) = 0 Then
                    _mRepositoryItem.DisplayFormat.FormatString = objCustomAttribute.Value
                    _mRepositoryItem.DisplayFormat.FormatType = FormatType.Custom
                End If
                If objCustomAttribute.Name <= String.Empty OrElse objCustomAttribute.Name.ToUpper <> "EDITMASK" Then
                    Continue For
                End If

                _mRepositoryItem.Mask.EditMask = objCustomAttribute.Value
                _mRepositoryItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
            Next
            objCustomButtons = Me.MemberInfo.FindAttributes(Of ISS.Base.Attributes.ObjectEditor.CustomEditorButtonAttribute)()
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

        Else

            'If IsPropertyNameInsertEditor = True Then
            '    If TypeOf item Is RepositoryItemLargeStringEdit Then
            '        mmeMemoEdit = item
            '        If mmeMemoEdit.ContextMenu Is Nothing Then
            '            mmeMemoEdit.ContextMenu = New ContextMenu
            '        End If
            '        mmeMemoEdit.ContextMenu.MenuItems.Add("Insert Property", New EventHandler(AddressOf RepositoryItem_ContextMenuClicked))
            '    ElseIf TypeOf item Is RepositoryItemMemoExEdit Then
            '        mmeMemoExEdit = item
            '        If mmeMemoExEdit.ContextMenu Is Nothing Then
            '            mmeMemoExEdit.ContextMenu = New ContextMenu
            '        End If
            '        mmeMemoExEdit.ContextMenu.MenuItems.Add("Insert Property", New EventHandler(AddressOf RepositoryItem_ContextMenuClicked))
            '    End If

            'End If
            'If Me.ObjectTypeInfo IsNot Nothing Then
            '    If Me.ObjectTypeInfo.Type Is GetType(ISSBaseEndUserMessage) Then
            '        mmeMemoEdit = item
            '        mmeMemoEdit.BorderStyle = BorderStyles.NoBorder
            '        mmeMemoEdit.AllowFocused = False
            '        mmeMemoEdit.AutoHeight = True
            '        mmeMemoEdit.ScrollBars = Windows.Forms.ScrollBars.None
            '    End If
            'End If
        End If
        If _mRepositoryItem IsNot Nothing Then
            If _mRepositoryItem.DisplayFormat.FormatString = _mRepositoryItem.Mask.EditMask Then
                _mRepositoryItem.Mask.UseMaskAsDisplayFormat = True
            End If
        End If





        RemoveHandler CurrentObjectChanged, AddressOf SetupEmailButton
        AddHandler CurrentObjectChanged, AddressOf SetupEmailButton

        SetupEmailButton(Me, Nothing)

    End Sub
    Private Function GetObjectFromPropertyName(ByVal PropertyName As String, ByVal SourceObject As Object) As Object
        For Each objPropertyInfo As System.Reflection.PropertyInfo In SourceObject.GetType.GetProperties
            If objPropertyInfo.CanRead AndAlso objPropertyInfo.Name = PropertyName Then
                Return objPropertyInfo.GetValue(SourceObject, Nothing)
            End If
        Next
        Return Nothing
    End Function
    Private Sub SetupEmailButton(ByVal sender As Object, ByVal e As EventArgs)
        Dim objEmailer As IEmail = Nothing
        Dim strToAddresses As String = String.Empty
        Dim objEmail As ISSBaseEmailMessage
        If _mRepositoryItem Is Nothing Then
            Return
        End If
        If _mRepositoryItem.Buttons.Count > 0 AndAlso (_mRepositoryItem.Buttons.Count > 1 OrElse _mRepositoryItem.Buttons(0) IsNot _mEmailButton) Then
            _mRepositoryItem.Buttons.Clear()
        End If

        _mEmailImplementationType = EmailHelper.GetEmailImplementationType(Model.ModelMember.MemberInfo)
        If _mEmailImplementationType = EmailHelper.EmailImplementationType.None Then
            Return
        End If

        _mEmailButton.Tag = "Email"
        _mRepositoryItem.Buttons.Add(_mEmailButton)
        BindEmailHandlerToObject()
        If RealCurrentObject IsNot Nothing Then
            _mEmailButton.Enabled = True
            If _mEmailImplementationType = EmailHelper.EmailImplementationType.Implementor Then
                objEmailer = ReflectionHelper.GetObjectFromPropertyName(Me.PropertyName, Me.RealCurrentObject)
            Else
                If Model.ModelMember.MemberInfo.Name.Contains(".") Then
                    objEmailer = ReflectionHelper.GetObjectFromPropertyName(ReflectionHelper.GetParentProperty(Model.ModelMember.MemberInfo.Name), Me.RealCurrentObject)
                Else
                    objEmailer = RealCurrentObject
                End If
            End If
            If objEmailer IsNot Nothing Then
                _mEmailButton.Enabled = objEmailer.ShowEmailButton
                'objEmail = objEmailer.GetEmail(CurrentObject, MemberInfo)
                'For intLoop As Integer = 0 To objEmail.ToAddresses.Count - 1
                '    strToAddresses = strToAddresses + objEmail.ToAddresses(intLoop)
                'Next
                'If String.Compare(strToAddresses, String.Empty, False) = 0 Then
                '    _mEmailButton.Enabled = False
                'End If
            Else
                _mEmailButton.Enabled = False
            End If
        Else
            _mEmailButton.Enabled = False
        End If

    End Sub
    Private Sub _mRepositoryItem_ButtonClick(ByVal sender As Object, ByVal e As ButtonPressedEventArgs) Handles _mRepositoryItem.ButtonClick
        If e.Button.Tag = "Email" AndAlso Model.ModelMember.MemberInfo IsNot Nothing Then
            EmailHelper.ShowEmail(Model.ModelMember.MemberInfo, Me.RealCurrentObject)
        End If

    End Sub
    Private Sub TextEditor_CurrentObjectChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.CurrentObjectChanged
        RefreshEditor()
    End Sub
    Private Sub RefreshEditor()
        'If MemberInfo Is Nothing Then
        '    Return
        'End If
        _mEmailImplementationType = EmailHelper.GetEmailImplementationType(Model.ModelMember.MemberInfo)
        If _mEmailImplementationType <> EmailHelper.EmailImplementationType.None Then
            SetupEmailButton(Me, Nothing)
            BindEmailHandlerToObject()
        End If
    End Sub
#End Region
    Protected Overrides Sub OnFormatValue(e As ConvertEventArgs)
        MyBase.OnFormatValue(e)

    End Sub
    Protected Overrides Sub WriteValueCore()
        MyBase.WriteValueCore()

    End Sub


End Class
