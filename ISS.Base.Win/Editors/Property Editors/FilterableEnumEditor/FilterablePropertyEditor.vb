Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Filtering.Helpers
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports System.ComponentModel
Imports System.Text
Imports System.Windows.Forms

<PropertyEditor(GetType([Enum]), EditorAliases.EnumPropertyEditor, True)>
Public Class FilterableEnumPropertyEditor
    Inherits DXPropertyEditor
    Implements IComplexViewItem

    Private Sub UpdateControlWithCurrentObject()
        Dim control = TryCast(Me.Control, IGridInplaceEdit)
        If control IsNot Nothing Then control.GridEditingObject = CurrentObject
    End Sub

    Protected Overrides Function CreateControlCore() As Object
        Return New XafEnumEdit()
    End Function

    Protected Overrides Function CreateRepositoryItem() As RepositoryItem
        Return New RepositoryItemXafEnumEdit()
    End Function

    Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        Dim enumEditRepositoryItem = TryCast(item, RepositoryItemXafEnumEdit)
        enumEditRepositoryItem.Setup(Application, ObjectSpace, Model)
        UpdateControlWithCurrentObject()
    End Sub

    Protected Overrides Sub OnCurrentObjectChanged()
        MyBase.OnCurrentObjectChanged()
        UpdateControlWithCurrentObject()
    End Sub

    Public Sub New(ByVal objectType As Type, ByVal model As IModelMemberViewItem)
        MyBase.New(objectType, model)
        ImmediatePostData = model.ImmediatePostData
    End Sub

    Public Overloads ReadOnly Property Control As ComboBoxEdit
        Get
            Return CType(MyBase.Control, ComboBoxEdit)
        End Get
    End Property

    Public Sub Setup(ByVal objectSpace As IObjectSpace, ByVal application As XafApplication) Implements IComplexViewItem.Setup
        application = application
        objectSpace = objectSpace
    End Sub


    Public Property Application As XafApplication
    Public Property ObjectSpace As IObjectSpace
End Class

<System.ComponentModel.DesignerCategory("")>
<System.ComponentModel.ToolboxItem(False)>
Public Class RepositoryItemXafEnumEdit
    Inherits RepositoryItemImageComboBox

    Private _application As XafApplication
    Private _objectSpace As IObjectSpace
    Private _model As IModelMemberViewItem
    Private _propertyMemberInfo As IMemberInfo
    Private _dataSourceMemberInfo As IMemberInfo

    Private Function GetObjectTypeInfo(ByVal model As IModelMemberViewItem) As ITypeInfo
        Dim objectView = TryCast(model.ParentView, IModelObjectView)
        Dim newPath = model?.ModelMember?.ModelClass?.TypeInfo
        Dim originalObject = If(objectView IsNot Nothing, objectView?.ModelClass?.TypeInfo, Nothing)
        If originalObject Is Nothing Then
            Return newPath
        Else
            Return originalObject
        End If
    End Function

    Friend Const EditorName As String = "XafEnumEdit"

    Friend Shared Sub Register()
        If Not EditorRegistrationInfo.[Default].Editors.Contains(EditorName) Then
            EditorRegistrationInfo.[Default].Editors.Add(New EditorClassInfo(EditorName, GetType(XafEnumEdit), GetType(RepositoryItemXafEnumEdit), GetType(ImageComboBoxEditViewInfo), New ImageComboBoxEditPainter(), True, EditImageIndexes.ImageComboBoxEdit, GetType(DevExpress.Accessibility.PopupEditAccessible)))
        End If
    End Sub

    Protected Overrides Function CreateRepositoryItem() As RepositoryItem
        Return New RepositoryItemXafEnumEdit()
    End Function

    Shared Sub New()
        RepositoryItemXafEnumEdit.Register()
    End Sub

    Public Sub New()
        [ReadOnly] = True
        TextEditStyle = TextEditStyles.Standard
        ShowDropDown = ShowDropDown.SingleClick
    End Sub

    Public Overrides Sub Assign(ByVal item As RepositoryItem)
        If TypeOf item Is RepositoryItemXafEnumEdit Then
            Dim source = TryCast(item, RepositoryItemXafEnumEdit)

            If source IsNot Nothing Then
                _application = source._application
                _objectSpace = source._objectSpace
                _model = source._model
                _propertyMemberInfo = source._propertyMemberInfo
                _dataSourceMemberInfo = source._dataSourceMemberInfo
            End If
        End If

        MyBase.Assign(item)
    End Sub

    Public Overrides Function CreateEditor() As BaseEdit
        Return TryCast(MyBase.CreateEditor(), XafEnumEdit)
    End Function

    Public Sub Init(ByVal type As Type)
        Dim loader As EnumImagesLoader = New EnumImagesLoader(type)
        Items.AddRange(loader.GetImageComboBoxItems())

        If loader?.Images?.Images?.Count > 0 Then
            SmallImages = loader.Images
        End If
    End Sub

    Public Sub Setup(ByVal application As XafApplication, ByVal objectSpace As IObjectSpace, ByVal model As IModelMemberViewItem)
        Me._application = application
        Me._objectSpace = objectSpace
        Me._model = model
        _propertyMemberInfo = Nothing
        _dataSourceMemberInfo = Nothing
        Dim typeInfo = GetObjectTypeInfo(model)
        If typeInfo Is Nothing Then Return
        _propertyMemberInfo = typeInfo.FindMember(model.PropertyName)

        If Not String.IsNullOrEmpty(model.DataSourceProperty) Then
            'Dim builder As StringBuilder = New StringBuilder(model.DataSourceProperty)
            'Dim path = _propertyMemberInfo.GetPath()

            'For index As Integer = path.Count - 2 To 0 Step -1
            '    builder.Insert(0, ".").Insert(0, path(index).Name)
            'Next

            _dataSourceMemberInfo = typeInfo.FindMember(model.DataSourceProperty)
        End If

        Init(_propertyMemberInfo.MemberType)
    End Sub

    Public Overrides ReadOnly Property EditorTypeName As String
        Get
            Return EditorName
        End Get
    End Property

    Public ReadOnly Property Application As XafApplication
        Get
            Return _application
        End Get
    End Property

    Public ReadOnly Property ObjectSpace As IObjectSpace
        Get
            Return _objectSpace
        End Get
    End Property

    Public ReadOnly Property Model As IModelMemberViewItem
        Get
            Return _model
        End Get
    End Property

    Public ReadOnly Property PropertyMemberInfo As IMemberInfo
        Get
            Return _propertyMemberInfo
        End Get
    End Property

    Public ReadOnly Property DataSourceMemberInfo As IMemberInfo
        Get
            Return _dataSourceMemberInfo
        End Get
    End Property
End Class

<System.ComponentModel.DesignerCategory("")>
<System.ComponentModel.ToolboxItem(False)>
Partial Public Class XafEnumEdit
    Inherits ImageComboBoxEdit
    Implements IGridInplaceEdit

    Private Shared _imageComboBoxItemProperties As PropertyDescriptorCollection
    Private _gridEditingObject As Object
    Private _objectSpace As IObjectSpace

    Friend Function GetDataSource(ByVal forObject As Object) As IList
        Dim criteria As CriteriaOperator = Nothing
        If Properties Is Nothing Then Return Nothing
        Dim propertyDataSource As IList = If((Properties.DataSourceMemberInfo IsNot Nothing), TryCast(Properties.DataSourceMemberInfo.GetValue(forObject), IList), Nothing)
        Dim dataSource As IList = New List(Of ImageComboBoxItem)()

        If propertyDataSource Is Nothing Then

            For i As Integer = 0 To Properties.Items.Count - 1
                dataSource.Add(CType(Properties.Items(i), ImageComboBoxItem))
            Next
        Else

            For i As Integer = 0 To Properties.Items.Count - 1
                Dim item = CType(Properties.Items(i), ImageComboBoxItem)
                If propertyDataSource.Contains(item.Value) Then dataSource.Add(item)
            Next
        End If

        Dim criteriaString As String = Properties.Model.DataSourceCriteria
        If Not String.IsNullOrEmpty(criteriaString) Then criteria = CriteriaOperator.Parse(criteriaString)

        If Not ReferenceEquals(criteria, Nothing) Then
            criteria.Accept(New EnumCriteriaParser(Properties.PropertyMemberInfo.Name, Properties.PropertyMemberInfo.MemberType))
            Dim filteredDataSource = New ExpressionEvaluator(ImageComboBoxItemProperties, criteria, True).Filter(dataSource)
            dataSource.Clear()

            For Each item As ImageComboBoxItem In filteredDataSource
                dataSource.Add(item)
            Next
        End If

        Return dataSource
    End Function

    Private Sub ObjectSpaceObjectChanged(ByVal sender As Object, ByVal e As ObjectChangedEventArgs)
        If e.Object = GridEditingObject AndAlso (String.IsNullOrEmpty(e.PropertyName) OrElse (Properties.DataSourceMemberInfo IsNot Nothing AndAlso Properties.DataSourceMemberInfo.Name.Equals(e.PropertyName))) Then
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ClosePopup()
        End If

        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnPropertiesChanged()
        MyBase.OnPropertiesChanged()
        If Properties IsNot Nothing Then ObjectSpace = Properties.ObjectSpace
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            ObjectSpace = Nothing
        End If

        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Function CreatePopupForm() As PopupBaseForm
        Return New XafEnumEditPopupForm(Me)
    End Function

    Protected Shared ReadOnly Property ImageComboBoxItemProperties As PropertyDescriptorCollection
        Get
            If _imageComboBoxItemProperties Is Nothing Then _imageComboBoxItemProperties = TypeDescriptor.GetProperties(GetType(ImageComboBoxItem))
            Return _imageComboBoxItemProperties
        End Get
    End Property

    Shared Sub New()
        RepositoryItemXafEnumEdit.Register()
    End Sub

    Public Sub New()
        Properties.TextEditStyle = TextEditStyles.Standard
        Properties.[ReadOnly] = True
        Height = WinPropertyEditor.TextControlHeight
    End Sub

    Public Overrides ReadOnly Property EditorTypeName As String
        Get
            Return RepositoryItemXafEnumEdit.EditorName
        End Get
    End Property

    Public ReadOnly Property EditingObject As Object
        Get
            Try
                Return BindingHelper.GetEditingObject(Me)
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property

    Public Overloads ReadOnly Property Properties As RepositoryItemXafEnumEdit
        Get
            Return CType(MyBase.Properties, RepositoryItemXafEnumEdit)
        End Get
    End Property

    Public Property GridEditingObject As Object Implements IGridInplaceEdit.GridEditingObject
        Get
            Return _gridEditingObject
        End Get
        Set(ByVal value As Object)
            'If _gridEditingObject Is value Then Return
            _gridEditingObject = value
        End Set
    End Property

    Public Property ObjectSpace As IObjectSpace
        Get
            Return _objectSpace
        End Get
        Set(ByVal value As IObjectSpace)
            If _objectSpace IsNot Nothing Then RemoveHandler _objectSpace.ObjectChanged, AddressOf ObjectSpaceObjectChanged
            _objectSpace = value
            If _objectSpace IsNot Nothing Then AddHandler _objectSpace.ObjectChanged, AddressOf ObjectSpaceObjectChanged
        End Set
    End Property

    Public Overloads ReadOnly Property PopupForm As XafEnumEditPopupForm
        Get
            Return CType(MyBase.PopupForm, XafEnumEditPopupForm)
        End Get
    End Property

    Private _mDataBindings As ControlBindingsCollection
    Private ReadOnly Property IGridInplaceEdit_DataBindings As ControlBindingsCollection Implements IGridInplaceEdit.DataBindings
        Get

            Return Me.DataBindings

        End Get
    End Property
End Class


Public Class XafEnumEditPopupForm
    Inherits PopupListBoxForm

    Protected Overrides Sub OnBeforeShowPopup()
        UpdateDataSource()
        MyBase.OnBeforeShowPopup()
    End Sub

    Protected Overrides Sub SetupListBoxOnShow()
        MyBase.SetupListBoxOnShow()
        Dim visibleItems = TryCast(ListBox.DataSource, IList)
        Dim currentItem = CType(OwnerEdit.SelectedItem, ImageComboBoxItem)
        Dim currentItemInVisibleItems = visibleItems Is Nothing OrElse visibleItems.Contains(currentItem)
        Dim selectedItem = CType(ListBox.SelectedItem, ImageComboBoxItem)
        If Not selectedItem Is currentItem OrElse Not currentItemInVisibleItems Then selectedItem = Nothing
        If selectedItem Is Nothing AndAlso currentItemInVisibleItems Then selectedItem = currentItem
        ListBox.SelectedIndex = -1
        ListBox.SelectedItem = selectedItem
    End Sub

    Public Sub New(ByVal ownerEdit As XafEnumEdit)
        MyBase.New(ownerEdit)
    End Sub

    Public Sub UpdateDataSource()
        If Properties Is Nothing Then Return
        Dim dataSource = TryCast(OwnerEdit.GetDataSource(OwnerEdit.EditingObject), IList)
        ListBox.DataSource = If(dataSource IsNot Nothing, CObj(dataSource), CObj(Properties.Items))
    End Sub

    Public Overloads ReadOnly Property OwnerEdit As XafEnumEdit
        Get
            Return CType(MyBase.OwnerEdit, XafEnumEdit)
        End Get
    End Property

    Public Overloads ReadOnly Property Properties As RepositoryItemXafEnumEdit
        Get
            Return CType(MyBase.Properties, RepositoryItemXafEnumEdit)
        End Get
    End Property
End Class