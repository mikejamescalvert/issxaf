Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports System
Imports System.Linq

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
<DefaultClassOptions()>
Public Class Product ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _mCustomer As Customer
    Property Customer As Customer
        Get
            Return _mCustomer
        End Get
        Set(ByVal Value As Customer)
            SetPropertyValue(NameOf(Customer), _mCustomer, Value)
        End Set
    End Property
    Private _mSKU As String
    Property SKU As String
        Get
            Return _mSKU
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(SKU), _mSKU, Value)
        End Set
    End Property

    Public ReadOnly Property AvailableProducts As XPCollection(Of Product)
        Get
            Return New XPCollection(Of Product)(Session, New BinaryOperator("Active", True))
        End Get
    End Property

    Private _mActiveDate As Date
    Property ActiveDate As Date
        Get
            Return _mActiveDate
        End Get
        Set(ByVal Value As Date)
            SetPropertyValue(NameOf(ActiveDate), _mActiveDate, Value)
        End Set
    End Property
    Private _mListPrice As Decimal
    Property ListPrice As Decimal
        Get
            Return _mListPrice
        End Get
        Set(ByVal Value As Decimal)
            SetPropertyValue(NameOf(ListPrice), _mListPrice, Value)
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
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
