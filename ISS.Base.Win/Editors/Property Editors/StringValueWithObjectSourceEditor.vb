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
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Filtering
Imports DevExpress.Persistent.Base

''' <summary>
''' Creates an editor which has a drop down with a data source for the string value properties
''' </summary>
<PropertyEditor(GetType(String), False)>
Public Class StringValueWithObjectSourceEditor
    Inherits StringPropertyEditor

    Private WithEvents _mRepository As Repository.RepositoryItemLookUpEdit

    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

        'todo: how to create 

    End Sub

#Region "Properties"
    Public ReadOnly Property IsSimpleString() As Boolean
        Get
            Return MemberInfo.MemberType IsNot GetType(String) OrElse Model.RowCount = 0
        End Get
    End Property

#End Region

#Region "Behaviors"

    Private Sub TextEditor_ValueRead(ByVal sender As Object, ByVal e As EventArgs) Handles Me.ValueRead
        If MemberInfo Is Nothing Then
            Return
        End If
        SetupEditor()
    End Sub

    Public Overrides Sub BreakLinksToControl(ByVal unwireEventsOnly As Boolean)
        MyBase.BreakLinksToControl(unwireEventsOnly)
        If MemberInfo Is Nothing Then
            Return
        End If
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If MemberInfo Is Nothing Then
            Return
        End If
    End Sub

    Protected Overrides Function CreateControlCore() As Object
        Dim lueLookupEdit As DevExpress.XtraEditors.LookUpEdit = New DevExpress.XtraEditors.LookUpEdit
        SetupDefaultRepository(lueLookupEdit.Properties)
        Return New DevExpress.XtraEditors.LookUpEdit
    End Function

    Protected Overrides Function CreateRepositoryItem() As RepositoryItem
        Dim rpiRepositoryItem As New Repository.RepositoryItemLookUpEdit
        SetupDefaultRepository(rpiRepositoryItem)
        Return rpiRepositoryItem
    End Function

    Public Sub SetupDefaultRepository(ByVal RepositoryItem As Repository.RepositoryItemLookUpEdit)
        RepositoryItem.NullText = String.Empty
    End Sub

    Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        _mRepository = item
    End Sub

    Public Shared Sub LoadAllDataFromPropertySource(ByVal MemberInfo As IMemberInfo, ByVal ObjectSpace As IObjectSpace, ByVal RepositoryItem As Repository.RepositoryItemLookUpEdit)

        ' Check for attribute
        Dim atrMemberAttribute As StringValueWithPropertySourceEditorAttribute = MemberInfo.FindAttribute(Of StringValueWithPropertySourceEditorAttribute)
        If atrMemberAttribute IsNot Nothing Then
            ' Get targeted property type from alternate member property using property name or use source object type
            Dim tPropertyType As Type = Nothing
            Dim typ As ITypeInfo = MemberInfo.Owner
            Dim smiMemberInfo As IMemberInfo
            If typ IsNot Nothing AndAlso atrMemberAttribute.SourceCollectionPropertyName IsNot Nothing Then
                ' Using type object
                smiMemberInfo = typ.FindMember(atrMemberAttribute.SourceCollectionPropertyName)
                If smiMemberInfo IsNot Nothing AndAlso smiMemberInfo.ListElementType IsNot Nothing Then
                    tPropertyType = smiMemberInfo.ListElementType
                End If



            End If

            If tPropertyType Is Nothing Then
                Throw New UserFriendlyException("Property attribute type argument invalid.")
            End If


            Dim coCriteria As CriteriaOperator = CriteriaOperator.Parse("1=1")



            RepositoryItem.NullText = String.Empty
            RepositoryItem.ImmediatePopup = atrMemberAttribute.ShowPopupOnEdit

            RepositoryItem.DataSource = ObjectSpace.CreateCollection(tPropertyType, coCriteria)
            RepositoryItem.DisplayMember = atrMemberAttribute.ValuePropertyName
            RepositoryItem.ValueMember = atrMemberAttribute.ValuePropertyName
            RepositoryItem.Columns.Clear()
            RepositoryItem.PopupFormMinSize = New Size(atrMemberAttribute.MinimumWindowWidth, atrMemberAttribute.MinimumWindowHeight)

            If atrMemberAttribute.AllowManualEntry = True Then
                RepositoryItem.TextEditStyle = TextEditStyles.Standard
            End If

            Dim lciLookupColumnInfo As LookUpColumnInfo

            'Apply sort to main column
            If atrMemberAttribute.ColumnstoDisplay > String.Empty Then
                For index = 0 To atrMemberAttribute.ColumnstoDisplay.Split(";").Length - 1
                    lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ColumnstoDisplay.Split(";")(index), atrMemberAttribute.CaptionsOfColumnsToDisplay.Split(";")(index))
                    If atrMemberAttribute.SortColumnIndex = index Then
                        lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                        If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                            lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                        Else
                            lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                        End If
                    End If

                    If atrMemberAttribute.ColumnSizes > String.Empty Then
                        lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes.Split(";")(index)
                    End If

                    RepositoryItem.Columns.Add(lciLookupColumnInfo)
                Next
            Else

                lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ValuePropertyName, atrMemberAttribute.ValuePropertyName)
                lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                    lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                Else
                    lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                End If


                If atrMemberAttribute.CaptionsOfColumnsToDisplay > String.Empty Then
                    lciLookupColumnInfo.Caption = atrMemberAttribute.CaptionsOfColumnsToDisplay
                End If
                If atrMemberAttribute.ColumnSizes > String.Empty Then
                    lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes
                End If
                RepositoryItem.Columns.Add(lciLookupColumnInfo)
            End If
        End If

    End Sub

    Public Shared Sub LoadAllData(ByVal MemberInfo As IMemberInfo, ByVal ObjectSpace As IObjectSpace, ByVal RepositoryItem As Repository.RepositoryItemLookUpEdit)

        Dim apmPropertyMember As StringValueWithPropertySourceEditorAttribute = MemberInfo.FindAttribute(Of StringValueWithPropertySourceEditorAttribute)
        If apmPropertyMember IsNot nothing Then
            LoadAllDataFromPropertySource(MemberInfo, ObjectSpace, RepositoryItem)
            Return
        End If

            ' Check for attribute
            Dim atrMemberAttribute As StringValueWithObjectSourceEditorAttribute = MemberInfo.FindAttribute(Of StringValueWithObjectSourceEditorAttribute)
        If atrMemberAttribute IsNot Nothing Then
            ' Get targeted property type from alternate member property using property name or use source object type
            Dim tPropertyType As Type = Nothing
            If atrMemberAttribute.SourceObjectType IsNot Nothing Then
                ' Using type object
                tPropertyType = atrMemberAttribute.SourceObjectType

            End If

            If tPropertyType Is Nothing Then
                Throw New UserFriendlyException("Property attribute type argument invalid.")
            End If


            Dim coCriteria As CriteriaOperator = CriteriaOperator.Parse("1=1")



            RepositoryItem.NullText = String.Empty
            RepositoryItem.ImmediatePopup = atrMemberAttribute.ShowPopupOnEdit

            RepositoryItem.DataSource = ObjectSpace.CreateCollection(tPropertyType, coCriteria)
            RepositoryItem.DisplayMember = atrMemberAttribute.ValuePropertyName
            RepositoryItem.ValueMember = atrMemberAttribute.ValuePropertyName
            RepositoryItem.Columns.Clear()
            RepositoryItem.PopupFormMinSize = New Size(atrMemberAttribute.MinimumWindowWidth, atrMemberAttribute.MinimumWindowHeight)

            If atrMemberAttribute.AllowManualEntry = True Then
                RepositoryItem.TextEditStyle = TextEditStyles.Standard
            End If

            Dim lciLookupColumnInfo As LookUpColumnInfo

            'Apply sort to main column
            If atrMemberAttribute.ColumnstoDisplay > String.Empty Then
                For index = 0 To atrMemberAttribute.ColumnstoDisplay.Split(";").Length - 1
                    lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ColumnstoDisplay.Split(";")(index), atrMemberAttribute.CaptionsOfColumnsToDisplay.Split(";")(index))
                    If atrMemberAttribute.SortColumnIndex = index Then
                        lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                        If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                            lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                        Else
                            lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                        End If
                    End If

                    If atrMemberAttribute.ColumnSizes > String.Empty Then
                        lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes.Split(";")(index)
                    End If

                    RepositoryItem.Columns.Add(lciLookupColumnInfo)
                Next
            Else

                lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ValuePropertyName, atrMemberAttribute.ValuePropertyName)
                lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                    lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                Else
                    lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                End If


                If atrMemberAttribute.CaptionsOfColumnsToDisplay > String.Empty Then
                    lciLookupColumnInfo.Caption = atrMemberAttribute.CaptionsOfColumnsToDisplay
                End If
                If atrMemberAttribute.ColumnSizes > String.Empty Then
                    lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes
                End If

                RepositoryItem.Columns.Add(lciLookupColumnInfo)
            End If
        End If
    End Sub

    Public Shared Sub LoadDataSourceFromObjectPropertySource(ByVal CurrentObject As Object, ByVal MemberInfo As IMemberInfo, ByVal ObjectSpace As IObjectSpace, ByVal RepositoryItem As Repository.RepositoryItemLookUpEdit, Optional ByVal Reload As Boolean = False)

        ' Check for attribute
        Dim atrMemberAttribute As StringValueWithPropertySourceEditorAttribute = MemberInfo.FindAttribute(Of StringValueWithPropertySourceEditorAttribute)
        If atrMemberAttribute IsNot Nothing Then
            If CurrentObject Is Nothing Then
                Return
            End If
            ' Get targeted property type from alternate member property using property name or use source object type
            Dim tPropertyType As Type = Nothing
            Dim typ As ITypeInfo = MemberInfo.Owner
            Dim smiMemberInfo As IMemberInfo

            If typ IsNot Nothing AndAlso atrMemberAttribute.SourceCollectionPropertyName IsNot Nothing Then
                ' Using type object
                smiMemberInfo = typ.FindMember(atrMemberAttribute.SourceCollectionPropertyName)
                If smiMemberInfo Is Nothing Then
                    Throw New UserFriendlyException("Member info not found on parent")
                End If



                RepositoryItem.NullText = String.Empty
                RepositoryItem.ImmediatePopup = atrMemberAttribute.ShowPopupOnEdit

                RepositoryItem.DataSource = smiMemberInfo.GetValue(CurrentObject)
                RepositoryItem.DisplayMember = atrMemberAttribute.ValuePropertyName
                RepositoryItem.ValueMember = atrMemberAttribute.ValuePropertyName
                RepositoryItem.Columns.Clear()
                RepositoryItem.PopupFormMinSize = New Size(atrMemberAttribute.MinimumWindowWidth, atrMemberAttribute.MinimumWindowHeight)

                Dim lciLookupColumnInfo As LookUpColumnInfo
                If atrMemberAttribute.AllowManualEntry = True Then
                    RepositoryItem.TextEditStyle = TextEditStyles.Standard
                End If

                'Apply sort to main column
                If atrMemberAttribute.ColumnstoDisplay > String.Empty Then
                    For index = 0 To atrMemberAttribute.ColumnstoDisplay.Split(";").Length - 1
                        lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ColumnstoDisplay.Split(";")(index), atrMemberAttribute.CaptionsOfColumnsToDisplay.Split(";")(index))
                        If atrMemberAttribute.SortColumnIndex = index Then
                            lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                            If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                                lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                            Else
                                lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                            End If
                        End If

                        If atrMemberAttribute.ColumnSizes > String.Empty Then
                            lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes.Split(";")(index)
                        End If

                        RepositoryItem.Columns.Add(lciLookupColumnInfo)
                    Next
                Else

                    lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ValuePropertyName, atrMemberAttribute.ValuePropertyName)
                    lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                    If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                        lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    Else
                        lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    End If


                    If atrMemberAttribute.CaptionsOfColumnsToDisplay > String.Empty Then
                        lciLookupColumnInfo.Caption = atrMemberAttribute.CaptionsOfColumnsToDisplay
                    End If
                    If atrMemberAttribute.ColumnSizes > String.Empty Then
                        lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes
                    End If

                    RepositoryItem.Columns.Add(lciLookupColumnInfo)
                End If
            Else

                Throw New UserFriendlyException("Member info missing")
            End If

        End If
    End Sub

    Public Shared Sub LoadDataSourceFromObject(ByVal CurrentObject As Object, ByVal MemberInfo As IMemberInfo, ByVal ObjectSpace As IObjectSpace, ByVal RepositoryItem As Repository.RepositoryItemLookUpEdit, Optional ByVal Reload As Boolean = False)
        If RepositoryItem Is Nothing Then
            Return
        End If
        If MemberInfo Is Nothing Then
            Return
        End If

        If CurrentObject Is Nothing Then
            LoadAllData(MemberInfo, ObjectSpace, RepositoryItem)
            Return
        End If

        Dim atrPropertyMemberAttribute As StringValueWithPropertySourceEditorAttribute = MemberInfo.FindAttribute(Of StringValueWithPropertySourceEditorAttribute)
        If atrPropertyMemberAttribute IsNot Nothing Then
            LoadDataSourceFromObjectPropertySource(CurrentObject, MemberInfo, ObjectSpace, RepositoryItem, Reload)
            Return
        End If


        'If RepositoryItem.DataSource IsNot Nothing Then
        '    Return
        'End If



        ' Check for attribute
        Dim atrMemberAttribute As StringValueWithObjectSourceEditorAttribute = MemberInfo.FindAttribute(Of StringValueWithObjectSourceEditorAttribute)
        If atrMemberAttribute IsNot Nothing Then
            If CurrentObject Is Nothing Then
                Return
            End If
            ' Get targeted property type from alternate member property using property name or use source object type
            Dim tPropertyType As Type = Nothing
            If atrMemberAttribute.SourceObjectType IsNot Nothing Then
                ' Using type object
                tPropertyType = atrMemberAttribute.SourceObjectType
            ElseIf Not String.IsNullOrEmpty(atrMemberAttribute.TypePropertyName) Then
                If CurrentObject Is Nothing Then
                    Return
                End If
                If CurrentObject.GetType() Is Nothing Then
                    Return
                End If
                ' Property value is Type object
                tPropertyType = CurrentObject.GetType().GetProperty(atrMemberAttribute.TypePropertyName).GetValue(CurrentObject)
                '' Using string value
                'If atrMemberAttribute.UsePropertyValue Then
                '    ' Property value is Type object
                '    tPropertyType = CurrentObject.GetType().GetProperty(atrMemberAttribute.TypePropertyName).GetValue(CurrentObject)
                'Else
                '    ' Property is of Type to be used
                '    tPropertyType = MemberInfo.Owner.FindMember(atrMemberAttribute.TypePropertyName).MemberType
                'End If
            End If

            If tPropertyType Is Nothing Then
                Throw New UserFriendlyException("Property attribute type argument invalid.")
            End If

            Dim ctrWrapper As CriteriaWrapper
            Dim coCriteria As CriteriaOperator = Nothing
            If Not String.IsNullOrEmpty(atrMemberAttribute.CriteriaString) Then
                ctrWrapper = New CriteriaWrapper(atrMemberAttribute.CriteriaString, CurrentObject)
                coCriteria = ctrWrapper.CriteriaOperator
            End If


            RepositoryItem.NullText = String.Empty
            RepositoryItem.ImmediatePopup = atrMemberAttribute.ShowPopupOnEdit

            RepositoryItem.DataSource = ObjectSpace.CreateCollection(tPropertyType, coCriteria)
            RepositoryItem.DisplayMember = atrMemberAttribute.ValuePropertyName
            RepositoryItem.ValueMember = atrMemberAttribute.ValuePropertyName
            RepositoryItem.Columns.Clear()
            RepositoryItem.PopupFormMinSize = New Size(atrMemberAttribute.MinimumWindowWidth, atrMemberAttribute.MinimumWindowHeight)

            Dim lciLookupColumnInfo As LookUpColumnInfo
            If atrMemberAttribute.AllowManualEntry = True Then
                RepositoryItem.TextEditStyle = TextEditStyles.Standard
            End If
            'Apply sort to main column
            If atrMemberAttribute.ColumnstoDisplay > String.Empty Then
                For index = 0 To atrMemberAttribute.ColumnstoDisplay.Split(";").Length - 1
                    lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ColumnstoDisplay.Split(";")(index), atrMemberAttribute.CaptionsOfColumnsToDisplay.Split(";")(index))
                    If atrMemberAttribute.SortColumnIndex = index Then
                        lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                        If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                            lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                        Else
                            lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                        End If
                    End If

                    If atrMemberAttribute.ColumnSizes > String.Empty Then
                        lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes.Split(";")(index)
                    End If

                    RepositoryItem.Columns.Add(lciLookupColumnInfo)
                Next
            Else

                lciLookupColumnInfo = New LookUpColumnInfo(atrMemberAttribute.ValuePropertyName, atrMemberAttribute.ValuePropertyName)
                lciLookupColumnInfo.AllowSort = DefaultBoolean.True
                If atrMemberAttribute.SortDirection = SortDirection.Descending Then
                    lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                Else
                    lciLookupColumnInfo.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                End If


                If atrMemberAttribute.CaptionsOfColumnsToDisplay > String.Empty Then
                    lciLookupColumnInfo.Caption = atrMemberAttribute.CaptionsOfColumnsToDisplay
                End If
                If atrMemberAttribute.ColumnSizes > String.Empty Then
                    lciLookupColumnInfo.Width = atrMemberAttribute.ColumnSizes
                End If

                RepositoryItem.Columns.Add(lciLookupColumnInfo)
            End If
        End If
    End Sub

    Private Sub LookupStringEditor_ControlCreated(sender As Object, e As EventArgs) Handles Me.ControlCreated
        SetupEditor()
    End Sub

    Public Sub SetupEditor()
        If Me.View Is Nothing OrElse Me.View.ObjectSpace Is Nothing Then
            Return
        End If

        LoadDataSourceFromObject(View.CurrentObject, MemberInfo, View.ObjectSpace, _mRepository)
    End Sub

    Private Sub StringValueWithObjectSourceEditor_CustomSetupRepositoryItem(sender As Object, e As CustomSetupRepositoryItemEventArgs) Handles Me.CustomSetupRepositoryItem
        SetupEditor()
    End Sub

    Private Sub StringValueWithObjectSourceEditor_CurrentObjectChanged(sender As Object, e As EventArgs) Handles Me.CurrentObjectChanged
        SetupEditor()
    End Sub

#End Region

End Class
