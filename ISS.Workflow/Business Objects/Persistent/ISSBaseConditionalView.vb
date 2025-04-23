Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Editors

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
'<DefaultClassOptions()> _
Public Class ISSBaseConditionalView ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _mISSBaseBusinessRules As ISSBaseBusinessRules
    <Association("ISSBaseBusinessRules-ISSBaseConditionalViews")> _
    Property ISSBaseBusinessRules() As ISSBaseBusinessRules
        Get
            Return _mISSBaseBusinessRules
        End Get
        Set(ByVal Value As ISSBaseBusinessRules)
            SetPropertyValue("ISSBaseBusinessRules", _mISSBaseBusinessRules, Value)
        End Set
    End Property

    Private _mViewId As String
    <Size(255)>
    <ISS.Base.Attributes.Editors.PropertyEditors.ViewIdEditor("ISSBaseBusinessRules.ObjectType")>
    Property ViewId As String
        Get
            Return _mViewId
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ViewId", _mViewId, Value)
        End Set
    End Property
    Private _mCriteria As String
    <CriteriaOptions("ISSBaseBusinessRules.ObjectType")> _
    <Index(3)> _
    <Size(SizeAttribute.Unlimited)> _
    Property Criteria As String
        Get
            Return _mCriteria
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Criteria", _mCriteria, Value)
        End Set
    End Property

    Public Function IsValidObject(ByVal Target As Object) As Boolean
        If ISSBaseBusinessRules Is Nothing Then
            Return False
        End If

        If ISSBaseBusinessRules.ObjectType Is Nothing Then
            Return False
        End If

        Return ISSBaseBusinessRules.IsValidObject(Target, GetEvaluator())
    End Function
    Public Function GetEvaluator() As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator
        Dim ctoCriteriaOperator As CriteriaOperator = Session.ParseCriteria(Criteria)
        Dim dxeExpressionEvaluator As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator
        Dim dcdDescriptorDefault As DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault

        If ISSBaseBusinessRules Is Nothing Then
            Return Nothing
        End If

        If ISSBaseBusinessRules.ObjectType Is Nothing Then
            Return Nothing
        End If

        dcdDescriptorDefault = New DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault(ISSBaseBusinessRules.ObjectType)
        dxeExpressionEvaluator = New DevExpress.Data.Filtering.Helpers.ExpressionEvaluator(dcdDescriptorDefault, ctoCriteriaOperator)
        Return dxeExpressionEvaluator
    End Function

    'Private _PersistentProperty As String
    '<XafDisplayName("My display name"), ToolTip("My hint message")> _
    '<ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(False)> _
    '<Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)> _
    'Public Property PersistentProperty() As String
    '    Get
    '        Return _PersistentProperty
    '    End Get
    '    Set(ByVal value As String)
    '        SetPropertyValue("PersistentProperty", _PersistentProperty, value)
    '    End Set
    'End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
