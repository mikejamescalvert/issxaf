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
Public Class BulkChangeOperation ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub

    Private _mStringChange As String
    <Size(255)>
    Public Property StringChange As String
        Get
            Return _mStringChange
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("StringChange", _mStringChange, Value)
        End Set
    End Property
    Private _mIntegerChange As Integer
    Public Property IntegerChange As Integer
        Get
            Return _mIntegerChange
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("IntegerChange", _mIntegerChange, Value)
        End Set
    End Property
    Private _mDecimalChange As Decimal
    Public Property DecimalChange As Decimal
        Get
            Return _mDecimalChange
        End Get
        Set(ByVal Value As Decimal)
            SetPropertyValue("DecimalChange", _mDecimalChange, Value)
        End Set
    End Property

    Private _mPersistentObjectChange As Object
    <DataSourceProperty("ObjectsAvailableForChange")>
    Public Property PersistentObjectChange As Object
        Get
            Return _mPersistentObjectChange
        End Get
        Set(ByVal Value As Object)
            SetPropertyValue("PersistentObjectChange", _mPersistentObjectChange, Value)
        End Set
    End Property

    Public ReadOnly Property ObjectsAvailableForChange As xpcollection
        Get
            Return Nothing
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
