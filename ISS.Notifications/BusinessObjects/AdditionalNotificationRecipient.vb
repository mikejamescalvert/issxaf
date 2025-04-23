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

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
'<DefaultClassOptions()> _
Public Class AdditionalNotificationRecipient ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits NotificationModuleBaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub

    ' Fields...
    Private _mToName As String
    <Size(255)>
    Public Property ToName As String
        Get
            Return _mToName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ToName", _mToName, Value)
        End Set
    End Property
    Private _mToAddress As String
    <Size(255)>
    Public Property ToAddress As String
        Get
            Return _mToAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ToAddress", _mToAddress, Value)
        End Set
    End Property

    Private _mAdditionalToNotificationQueueItem As NotificationQueueItem
    <Association("NotificationQueueItem-AdditionalToNotificationRecipients")>
    Public Property AdditionalToNotificationQueueItem As NotificationQueueItem
        Get
            Return _mAdditionalToNotificationQueueItem
        End Get
        Set(ByVal Value As NotificationQueueItem)
            SetPropertyValue("AdditionalToNotificationQueueItem", _mAdditionalToNotificationQueueItem, Value)
        End Set
    End Property
    Private _mAdditionalCCNotificationQueueItem As NotificationQueueItem
    <Association("NotificationQueueItem-AdditionalCCNotificationRecipients")>
    Public Property AdditionalCCNotificationQueueItem As NotificationQueueItem
        Get
            Return _mAdditionalCCNotificationQueueItem
        End Get
        Set(ByVal Value As NotificationQueueItem)
            SetPropertyValue("AdditionalCCNotificationQueueItem", _mAdditionalCCNotificationQueueItem, Value)
        End Set
    End Property
    Private _mAdditionalBCCNotificationQueueItem As NotificationQueueItem
    <Association("NotificationQueueItem-AdditionalBCCNotificationRecipients")>
    Public Property AdditionalBCCNotificationQueueItem As NotificationQueueItem
        Get
            Return _mAdditionalBCCNotificationQueueItem
        End Get
        Set(ByVal Value As NotificationQueueItem)
            SetPropertyValue("AdditionalBCCNotificationQueueItem", _mAdditionalBCCNotificationQueueItem, Value)
        End Set
    End Property

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
    '    ' Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
