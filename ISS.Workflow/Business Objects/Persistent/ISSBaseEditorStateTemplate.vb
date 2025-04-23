Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<RuleCombinationOfPropertiesIsUnique("EditorStateUnique", DefaultContexts.Save, "ObjectTemplate,ObjectTypeName,PropertyName")> _
<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("EditorStateTemplate")> _
<Serializable()> _
Public Class ISSBaseEditorStateTemplate
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub


#Region "Behaviors"

    Public Function GetCriteriaValue(ByVal DataObject As Object) As Boolean
        Dim ctoCriteriaOperator As DevExpress.Data.Filtering.CriteriaOperator
        Dim dxeExpressionEvaluator As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator
        Dim dcdDescriptorDefault As DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault
        Try
            If Me.CriteriaTemplate Is Nothing Then
                Return True
            End If
            If DataObject Is Nothing Then
                Return False
            End If
            ctoCriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse(Me.CriteriaTemplate.Criteria)
            dcdDescriptorDefault = New DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault(DataObject.GetType)
            dxeExpressionEvaluator = New DevExpress.Data.Filtering.Helpers.ExpressionEvaluator(dcdDescriptorDefault, ctoCriteriaOperator)
            Return dxeExpressionEvaluator.Fit(DataObject)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    
    Public Function DoesPropertyMatch(ByVal SourceType As Type, ByVal MemberName As String) As Boolean
        Dim dtiTypeInfo As DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ObjectTypeName)
        Dim dmiMemberInfo As DC.IMemberInfo
        Dim dtiCompareTypeInfo As DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(SourceType)
        Dim dmiCompareMemberInfo As DC.IMemberInfo

        If dtiTypeInfo Is Nothing OrElse dtiCompareTypeInfo Is Nothing
            Return False
        End If

        dmiCompareMemberInfo = dtiCompareTypeInfo.FindMember(MemberName)
        dmiMemberInfo = dtiTypeInfo.FindMember(PropertyName)

        If dmiCompareMemberInfo Is Nothing OrElse dmiMemberInfo Is Nothing
            Return False
        End If

         If dmiCompareMemberInfo.Name = dmiMemberInfo.Name And dtiCompareTypeInfo.Name = dtiTypeInfo.Name Then
            Return True
         End If
        Return False
    End Function

#End Region
#Region "Persistent Properties"
    'Private _mCriteriaTemplate As ISSBaseCriteriaTemplate

    Private _mObjectTemplate As ISSBaseUserInterfaceTemplate
    Private _mObjectTypeName As String
    Private _mPropertyName As String

    'Public Property CriteriaTemplate() As ISSBaseCriteriaTemplate
    '    Get
    '        Return _mCriteriaTemplate
    '    End Get
    '    Set(ByVal value As ISSBaseCriteriaTemplate)
    '        If _mCriteriaTemplate Is value Then
    '            Return
    '        End If
    '        _mCriteriaTemplate = value
    '    End Set
    'End Property
    'Private _mCriteriaTemplate As ISSBaseCriteriaTemplate
    Private _mCriteriaTemplate As ISSBaseCriteriaTemplate
    <Index(2)> _
    <DataSourceProperty("ObjectTemplate.ObjectCustomization.CriteriaTemplates")> _
        Public Property CriteriaTemplate() As ISSBaseCriteriaTemplate
        Get
            Return _mCriteriaTemplate
        End Get
        Set(ByVal Value As ISSBaseCriteriaTemplate)
            SetPropertyValue("CriteriaTemplate", _mCriteriaTemplate, Value)
        End Set
    End Property



    Private _mFalseEditorStateType As EditorStateTypes
    <Index(4)> _
    Public Property FalseEditorStateType() As EditorStateTypes
        Get
            Return _mFalseEditorStateType
        End Get
        Set(ByVal value As EditorStateTypes)
            If _mFalseEditorStateType = value Then
                Return
            End If
            _mFalseEditorStateType = value
        End Set
    End Property
    <Persistent("FalseEditorStateColor")>
    Private _mFalseEditorStateColor As Integer
    Public Property FalseEditorStateColor As System.Drawing.Color
        Get
            Return System.Drawing.Color.FromArgb(_mFalseEditorStateColor)
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _mFalseEditorStateColor = Value.ToArgb
            OnChanged("FalseEditorStateColor")
        End Set
    End Property
       

    Private _mTrueEditorStateType As EditorStateTypes
    <Index(3)> _
    Public Property TrueEditorStateType() As EditorStateTypes
        Get
            Return _mTrueEditorStateType
        End Get
        Set(ByVal value As EditorStateTypes)
            If _mTrueEditorStateType = value Then
                Return
            End If
            _mTrueEditorStateType = value
        End Set
    End Property

    <Persistent("TrueEditorStateColor")>
    Private _mTrueEditorStateColor As Integer
    <NonPersistent()>
    Public Property TrueEditorStateColor As System.Drawing.Color
        Get
            Return System.Drawing.Color.FromArgb(_mTrueEditorStateColor)
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _mTrueEditorStateColor = Value.ToArgb
            OnChanged("TrueEditorStateColor")
        End Set
    End Property

    

    'Private _mEditorStateType As EditorStateTypes
    'Public Property EditorStateType() As EditorStateTypes
    '    Get
    '        Return _mEditorStateType
    '    End Get
    '    Set(ByVal value As EditorStateTypes)
    '        If _mEditorStateType = value Then
    '            Return
    '        End If
    '        _mEditorStateType = value
    '    End Set
    'End Property
    <Association("ObjectTemplate-PropertyTemplates")> _
    <Xml.Serialization.XmlIgnore()> _
    Public Property ObjectTemplate() As ISSBaseUserInterfaceTemplate
        Get
            Return _mObjectTemplate
        End Get
        Set(ByVal value As ISSBaseUserInterfaceTemplate)
            If _mObjectTemplate Is value Then
                Return
            End If
            _mObjectTemplate = value
        End Set
    End Property
    <Browsable(False)> _
    Public ReadOnly Property ObjectType() As System.Type
        Get
            If DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ObjectTypeName) IsNot Nothing Then
                Return DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ObjectTypeName).Type
            Else
                Return Nothing
            End If
        End Get
    End Property
    <Browsable(False)> _
    <[ReadOnly](True)> _
    <Size(SizeAttribute.Unlimited)> _
    Public Property ObjectTypeName() As String
        Get
            Return _mObjectTypeName
        End Get
        Set(ByVal value As String)
            If _mObjectTypeName = value Then
                Return
            End If
            _mObjectTypeName = value
        End Set
    End Property

    <[ReadOnly](True)> _
    <Browsable(False)> _
    Public Property PropertyName() As String
        Get
            Return _mPropertyName
        End Get
        Set(ByVal value As String)
            If _mPropertyName = value Then
                Return
            End If
            _mPropertyName = value
        End Set
    End Property
    <RuleRequiredField("PropertyTemplate.PropertyRequired", DefaultContexts.Save, "Property Is Required")> _
    <Index(1)> _
    Public Property PropertyValue() As System.Reflection.PropertyInfo
        Get
            If Me.PropertyName Is Nothing Then
                Return Nothing
            Else
                If ObjectType IsNot Nothing Then
                    Return ObjectType.GetProperty(Me.PropertyName)
                Else
                    Return Nothing
                End If
            End If
        End Get
        Set(ByVal value As System.Reflection.PropertyInfo)
            Me.PropertyName = value.Name
            Me.ObjectTypeName = value.ReflectedType.FullName
        End Set
    End Property
#End Region
#Region "Enumerations"

    Public Enum EditorStateTypes
        [Empty] = 0
        [Default] = 6
        Bold = 7
        Disabled = 8
        DisabledIfExists = 9
        Hidden = 10
        [ReadOnly] = 11
        ReadOnlyIfExists = 12
    End Enum

    'Public Enum EditorStateTypes
    '    Hidden = 0
    '    Disabled = 1
    '    Bold = 2
    '    DisabledIfExists = 3
    '    [Default] = 4
    'End Enum
#End Region

End Class
