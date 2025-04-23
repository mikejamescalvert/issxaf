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
<NonPersistent()>
Public Class NotificationModuleBaseObject ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        SetPropertyValue("CreatedDate", _mCreatedDate, Now)
        SetPropertyValue("CreatedByUsername", _mCreatedByUsername, DevExpress.ExpressApp.SecuritySystem.CurrentUserName)

        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub
    Protected Overrides Sub OnSaving()
        MyBase.OnSaving()
        SetPropertyValue("LastModifiedDate", _mLastModifiedDate, Now)
        SetPropertyValue("LastModifiedByUsername", _mLastModifiedByUsername, DevExpress.ExpressApp.SecuritySystem.CurrentUserName)
    End Sub
    <Persistent("CreatedDate")> _
    Private _mCreatedDate As Date
    <PersistentAlias("_mCreatedDate")> _
    Public ReadOnly Property CreatedDate As Date
        Get
            Return _mCreatedDate
        End Get
    End Property
    <Persistent("CreatedByUsername")> _
    Private _mCreatedByUsername As String
    <PersistentAlias("_mCreatedByUsername")> _
    Public ReadOnly Property CreatedByUsername As String
        Get
            Return _mCreatedByUsername
        End Get
    End Property

    <Persistent("LastModifiedDate")> _
    Private _mLastModifiedDate As Date
    <PersistentAlias("_mLastModifiedDate")> _
    Public ReadOnly Property LastModifiedDate As Date
        Get
            Return _mLastModifiedDate
        End Get
    End Property
    <Persistent("LastModifiedByUsername")> _
    Private _mLastModifiedByUsername As String
    <PersistentAlias("_mLastModifiedByUsername")> _
    Public ReadOnly Property LastModifiedByUsername As String
        Get
            Return _mLastModifiedByUsername
        End Get
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
