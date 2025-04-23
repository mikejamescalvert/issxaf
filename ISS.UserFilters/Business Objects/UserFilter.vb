Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.Reflection
Imports DevExpress.ExpressApp.Editors

<NavigationItem("Administration")> _
<System.ComponentModel.DefaultProperty("SummaryInfo")> _
Public Class UserFilter
    Inherits BaseObject

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    <VisibleInListView(False)> _
    <VisibleInDetailView(False)> _
    Public ReadOnly Property SummaryInfo() As String
        Get
            Return String.Format("{0} ({1})", Me.Name, IIf(IsPublic, "Public", "Private"))
        End Get
    End Property

    Private _mShowGroupPanel As Boolean
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    Public Property ShowGroupPanel() As Boolean
        Get
            Return _mShowGroupPanel
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("ShowGroupPanel", _mShowGroupPanel, Value)
        End Set
    End Property
    Private _mShowMasterDetailView As Boolean
    Public Property ShowMasterDetailView As Boolean
        Get
            Return _mShowMasterDetailView
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("ShowMasterDetailView", _mShowMasterDetailView, Value)
        End Set
    End Property
    

    Private _mCreatedByUserID As Guid
    <Browsable(False)> _
    Public Property CreatedByUserID() As Guid
        Get
            Return _mCreatedByUserID
        End Get
        Set(ByVal Value As Guid)
            SetPropertyValue("CreatedByUserID", _mCreatedByUserID, Value)
        End Set
    End Property


    Public ReadOnly Property CreatedByUser() As Object
        Get
            If CreatedByUserID <> Nothing Then
                Return Session.GetObjectByKey(DevExpress.ExpressApp.SecuritySystem.UserType, CreatedByUserID)
            End If
            Return Nothing
        End Get
    End Property

    Private _mName As String
    Public Property Name() As String
        Get
            Return _mName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Name", _mName, Value)
        End Set
    End Property

    Private _mDescription As String
    <Size(-1)> _
    Public Property Description() As String
        Get
            Return _mDescription
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Description", _mDescription, Value)
        End Set
    End Property

    Private _mIsPublic As Boolean
    Public Property IsPublic() As Boolean
        Get
            Return _mIsPublic
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("IsPublic", _mIsPublic, Value)
        End Set
    End Property

    Private _mLayout As String
    <Size(SizeAttribute.Unlimited)> _
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    Public Property Layout() As String
        Get
            Return _mLayout
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Layout", _mLayout, Value)
        End Set
    End Property

    <Persistent("SavedObjectTypeName")> _
    Private _mSavedObjectTypeName As String
    Public Overridable Sub SetSavedObjectTypeName(ByVal Value As String)
        SetPropertyValue("SavedObjectTypeName", _mSavedObjectTypeName, Value)
    End Sub
    <PersistentAlias("_mSavedObjectTypeName")> _
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    Public ReadOnly Property SavedObjectTypeName() As String
        Get
            Return _mSavedObjectTypeName
        End Get
    End Property


    <PersistentAlias("_mSavedObjectTypeName")> _
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    Public Property ObjectType() As Type
        Get
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.TypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(Me.SavedObjectTypeName)
            If dtiTypeInfo Is Nothing Then
                Return Nothing
            End If
            Return dtiTypeInfo.Type
        End Get
        Set(ByVal Value As Type)
            If Value Is Nothing Then
                SetSavedObjectTypeName(String.Empty)
            Else
                SetSavedObjectTypeName(Value.FullName)
            End If
        End Set
    End Property

    <Association("UserFilter-UserFilterColumnInfos")> _
    <Aggregated()> _
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    Public ReadOnly Property UserFilterColumnInfos() As XPCollection(Of UserFilterColumnInfo)
        Get
            Return GetCollection(Of UserFilterColumnInfo)("UserFilterColumnInfos")
        End Get
    End Property

    Private _mCriterion As String
    '<CriteriaObjectTypeMember("ObjectType")> _
    <Size(-1)> _
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    Public Property Criterion() As String
        Get
            Return _mCriterion
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Criterion", _mCriterion, Value)
        End Set
    End Property

    Private _mViewID As String
    <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    <VisibleInLookupListView(False)>
    Public Property ViewID As String
        Get
            Return _mViewID
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ViewID", _mViewID, Value)
        End Set
    End Property

    
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        Me.CreatedByUserID = DevExpress.ExpressApp.SecuritySystem.CurrentUserId

    End Sub

        Private _mSpecificToView As Boolean
    Public Property SpecificToView As Boolean
        Get
            Return _mSpecificToView
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("SpecificToView", _mSpecificToView, Value)
        End Set
    End Property



End Class
