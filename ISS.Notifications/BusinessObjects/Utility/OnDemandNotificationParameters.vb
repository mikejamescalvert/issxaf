Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel

Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
'<DefaultClassOptions()> _
Public Class OnDemandNotificationParameters ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112701.aspx).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private Sub OnDemandNotificationParameters_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed
        If e.PropertyName = "OnDemandNotificationToOption"
            If OnDemandNotificationToOption IsNot Nothing
                EmailAddress = OnDemandNotificationToOption.ToAddress
            End If
        End If
    End Sub

    Private _mEmailAddress As String
    <Size(255)>
    Public Property EmailAddress As String
        Get
            Return _mEmailAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("EmailAddress", _mEmailAddress, Value)
        End Set
    End Property
    Private _mBCCEmailAddress As String
    <ToolTip("Enter the bcc email addresses to send notification in semi-colon delimited format", "BCC Emails")>
    <ComponentModel.DisplayName("BCC Email Addresses")>
    <Size(255)>
    Public Property BCCEmailAddress As String
        Get
            Return _mBCCEmailAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("CCEmailAddress", _mBCCEmailAddress, Value)
        End Set
    End Property
    Private _mCCEmailAddress As String
    <ToolTip("Enter the cc email addresses to send notification in semi-colon delimited format", "CC Emails")>
    <ComponentModel.DisplayName("CC Email Addresses")>
    <Size(255)>
    Public Property CCEmailAddress As String
        Get
            Return _mCCEmailAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("CCEmailAddress", _mCCEmailAddress, Value)
        End Set
    End Property
    Private _mSubject As String
    <Size(255)>
    Public Property Subject As String
        Get
            Return _mSubject
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Subject", _mSubject, Value)
        End Set
    End Property

    Private _mBody As String
    <Size(-1)>
    Public Property Body As String
        Get
            Return _mBody
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Body", _mBody, Value)
        End Set
    End Property

    Private _mFromAddress As String
    <Size(255)>
    <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Public Property FromAddress As String
        Get
            Return _mFromAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("FromAddress", _mFromAddress, Value)
        End Set
    End Property

    Private _mSerializedObjectKEy As String
    <Size(-1)>
        <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Public Property SerializedObjectKEy As String
        Get
            Return _mSerializedObjectKEy
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SerializedObjectKEy", _mSerializedObjectKEy, Value)
        End Set
    End Property

    Private _mRelatedRule As NotificationRule
            <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Public Property RelatedRule As NotificationRule
        Get
            Return _mRelatedRule
        End Get
        Set(ByVal Value As NotificationRule)
            SetPropertyValue("RelatedRule", _mRelatedRule, Value)
        End Set
    End Property

    Private _mOnDemandNotificationFromOption As OnDemandNotificationFromOption
    <DataSourceProperty("OnDemandNotificationFromOptions")>
    Public Property OnDemandNotificationFromOption As OnDemandNotificationFromOption
        Get
            Return _mOnDemandNotificationFromOption
        End Get
        Set(ByVal Value As OnDemandNotificationFromOption)
            SetPropertyValue("OnDemandNotificationFromOption", _mOnDemandNotificationFromOption, Value)
        End Set
    End Property
    
    Private _mOnDemandNotificationFromOptions As New List(Of OnDemandNotificationFromOption)
    <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Public ReadOnly Property OnDemandNotificationFromOptions As List(Of OnDemandNotificationFromOption)
        Get
            Return _mOnDemandNotificationFromOptions
        End Get
    End Property

    Private _mAttachments As New XPCollection(Of NotificationAttachment)(Session, False)
    <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    <DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property NotificationAttachments As XPCollection(Of NotificationAttachment)
        Get
            Return _mAttachments
        End Get
    End Property


    Private _mOnDemandNotificationToOption As OnDemandNotificationToOption
    <DataSourceProperty("OnDemandNotificationToOptions")>
    <ImmediatePostData()>
    Public Property OnDemandNotificationToOption As OnDemandNotificationToOption
        Get
            Return _mOnDemandNotificationToOption
        End Get
        Set(ByVal Value As OnDemandNotificationToOption)
            SetPropertyValue("OnDemandNotificationToOption", _mOnDemandNotificationToOption, Value)
        End Set
    End Property
    
    Private _mOnDemandNotificationToOptions As New List(Of OnDemandNotificationToOption)
            <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Public Readonly Property OnDemandNotificationToOptions As List(Of OnDemandNotificationToOption)
        Get
            Return _mOnDemandNotificationToOptions
        End Get
    End Property
    Protected Overrides Sub OnDeleting()
        MyBase.OnDeleting()
        For j = Me.NotificationAttachments.Count - 1 To 0 Step -1
            Me.NotificationAttachments(j).Delete()
        Next
    End Sub



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
