Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports ISS.Base.Attributes
Imports ISS.Base.Attributes.View.ListView
Imports System
Imports System.Linq

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
'<DefaultClassOptions()>
<ObjectClickActionAttribute(ObjectClickActionAttribute.ObjectClickActions.NoAction, False)>
<DragAndDropSortableColumn("OrderLineId")>
Public Class OrderLine ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private Sub OrderLine_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed
        If e.PropertyName = "Order" AndAlso Order IsNot Nothing Then
            If Order.OrderLines.Count > 0 Then
                OrderLineId = Order.OrderLines.Max(Function(m) m.OrderLineId) + 1
            Else
                OrderLineId = 1
            End If

        End If
    End Sub

    Private _mOrderLineId As Integer
    Property OrderLineId As Integer
        Get
            Return _mOrderLineId
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(OrderLineId), _mOrderLineId, Value)
        End Set
    End Property


    Private _mOrder As Order
    <Association("Order-OrderLines")>
    Property Order() As Order
        Get
            Return _mOrder
        End Get
        Set(ByVal Value As Order)
            SetPropertyValue(NameOf(Order), _mOrder, Value)
        End Set
    End Property

    Private _mProductCode As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <Editors.TextEditor.StringValueWithObjectSourceEditor(GetType(Product), "SKU", 0, SortDirection.Ascending, "Customer = '@This.Order.Customer'", True, "SKU", "SKU", "250", 100, 100, True)>
    Property ProductCode As String
        Get
            Return _mProductCode
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(ProductCode), _mProductCode, Value)
        End Set
    End Property

    Private _mProduct As Product
    <DataSourceProperty("AvailableProducts")>
    Property Product As Product
        Get
            Return _mProduct
        End Get
        Set(ByVal Value As Product)
            SetPropertyValue(NameOf(Product), _mProduct, Value)
        End Set
    End Property

    Public ReadOnly Property AvailableProducts As XPCollection(Of Product)
        Get
            If Order Is Nothing OrElse Order.Customer Is Nothing Then
                Return Nothing
            End If

            Return New XPCollection(Of Product)(Session, New BinaryOperator("Customer", Order.Customer))
        End Get
    End Property



    Private _mReplacementProduct As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <Editors.TextEditor.StringValueWithPropertySourceEditor("ReplacementProducts", "SKU", 0, SortDirection.Ascending, "Customer = '@This.Order.Customer'", True, "SKU", "SKU", "250", 100, 100, True)>
    Property ReplacementProduct As String
        Get
            Return _mReplacementProduct
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(ReplacementProduct), _mReplacementProduct, Value)
        End Set
    End Property

    Private _mReplacementProducts As XPCollection(Of Product)
    Public ReadOnly Property ReplacementProducts As XPCollection(Of Product)
        Get
            If _mReplacementProducts Is Nothing Then
                _mReplacementProducts = New XPCollection(Of Product)(Session, CriteriaOperator.Parse("StartsWith([SKU],'REP')"))
            End If
            Return _mReplacementProducts
        End Get
    End Property

    Private _mOrderedAmount As Decimal
    Property OrderedAmount As Decimal
        Get
            Return _mOrderedAmount
        End Get
        Set(ByVal Value As Decimal)
            SetPropertyValue(NameOf(OrderedAmount), _mOrderedAmount, Value)
        End Set
    End Property

    ReadOnly Property ProductType As Type
        Get
            Return GetType(Product)
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
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
