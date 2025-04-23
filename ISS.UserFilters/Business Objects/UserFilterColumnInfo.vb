Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Public Class UserFilterColumnInfo
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _mUserFilter As UserFilter
    <Association("UserFilter-UserFilterColumnInfos")> _
    Public Property UserFilter() As UserFilter
        Get
            Return _mUserFilter
        End Get
        Set(ByVal Value As UserFilter)
            SetPropertyValue("UserFilter", _mUserFilter, Value)
        End Set
    End Property


    Private _mCaption As String
    <Size(SizeAttribute.Unlimited)> _
    Public Property Caption() As String
        Get
            Return _mCaption
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Caption", _mCaption, Value)
        End Set
    End Property

    Private _mDisplayFormat As String
    Public Property DisplayFormat() As String
        Get
            Return _mDisplayFormat
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("DisplayFormat", _mDisplayFormat, Value)
        End Set
    End Property


    Private _mFieldName As String
    Public Property FieldName() As String
        Get
            Return _mFieldName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("FieldName", _mFieldName, Value)
        End Set
    End Property

    Private _mGroupIndex As Integer
    Public Property GroupIndex() As Integer
        Get
            Return _mGroupIndex
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("GroupIndex", _mGroupIndex, Value)
        End Set
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

    Private _mOptionsColumnAllowEdit As Boolean
    Public Property OptionsColumnAllowEdit() As Boolean
        Get
            Return _mOptionsColumnAllowEdit
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("OptionsColumnAllowEdit", _mOptionsColumnAllowEdit, Value)
        End Set
    End Property

    Private _mSortIndex As Integer
    Public Property SortIndex() As Integer
        Get
            Return _mSortIndex
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("SortIndex", _mSortIndex, Value)
        End Set
    End Property

    Private _mSortOrder As Integer
    Public Property SortOrder() As Integer
        Get
            Return _mSortOrder
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("SortOrder", _mSortOrder, Value)
        End Set
    End Property

    Private _mToolTip As String
    <Size(-1)> _
    Public Property ToolTip() As String
        Get
            Return _mToolTip
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ToolTip", _mToolTip, Value)
        End Set
    End Property

    Private _mVisibleIndex As Integer
    Public Property VisibleIndex() As Integer
        Get
            Return _mVisibleIndex
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("VisibleIndex", _mVisibleIndex, Value)
        End Set
    End Property

    Private _mWidth As Integer
    Public Property Width() As Integer
        Get
            Return _mWidth
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("Width", _mWidth, Value)
        End Set
    End Property


End Class
