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
Public Class NotificationException ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        EntryDate = Now
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub

    Private _mEntryDate As Date
    Public Property EntryDate As Date
        Get
            Return _mEntryDate
        End Get
        Set(ByVal Value As Date)
            SetPropertyValue("EntryDate", _mEntryDate, Value)
        End Set
    End Property

    Private _mSourceNotificationRule As NotificationRule
    Public Property SourceNotificationRule As NotificationRule
        Get
            Return _mSourceNotificationRule
        End Get
        Set(ByVal Value As NotificationRule)
            SetPropertyValue("SourceNotificationRule", _mSourceNotificationRule, Value)
        End Set
    End Property
    Private _mSerializedTargetObjectKey As String
    <Size(-1)>
    Public Property SerializedTargetObjectKey As String
        Get
            Return _mSerializedTargetObjectKey
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SerializedTargetObjectKey", _mSerializedTargetObjectKey, Value)
        End Set
    End Property
    Private _mExceptionMessage As String
    <Size(-1)>
    Public Property ExceptionMessage As String
        Get
            Return _mExceptionMessage
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ExceptionMessage", _mExceptionMessage, Value)
        End Set
    End Property

End Class
