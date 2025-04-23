Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports ISS.Base.Attributes
Imports ISS.Workflow
Imports ISS.Workflow.Interfaces
Imports System
Imports System.Linq

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
<DefaultClassOptions()>
<DragAndDropSortableColumn("OrderId")>
Public Class Order ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Implements IWorkflow

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _mWorkflowStatus As ISSBaseWorkflowStep
    Private _mOrderId As Integer
    Property OrderId As Integer
        Get
            Return _mOrderId
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(OrderId), _mOrderId, Value)
        End Set
    End Property


    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        OrderId = Session.Evaluate(GetType(Order), CriteriaOperator.Parse("Max(OrderId)"), Nothing) + 1
    End Sub
    <Association("Order-OrderLines")>
    Public ReadOnly Property OrderLines() As XPCollection(Of OrderLine)
        Get
            Return GetCollection(Of OrderLine)(NameOf(OrderLines))
        End Get
    End Property

    <PersistentAlias("OrderLines.Sum(OrderedAmount)")>
    Public ReadOnly Property OrderedTotal As Decimal
        Get
            Return EvaluateAlias("OrderedTotal")
        End Get
    End Property

    <Association("Order-OrderAttachments")>
    Public ReadOnly Property OrderAttachments() As XPCollection(Of OrderAttachment)
        Get
            Return GetCollection(Of OrderAttachment)(NameOf(OrderAttachments))
        End Get
    End Property

    Private _mCustomer As Customer
    '<DataSourceProperty("AvailableCustomer")>
    Property Customer As Customer
        Get
            Return _mCustomer
        End Get
        Set(ByVal Value As Customer)
            SetPropertyValue(NameOf(Customer), _mCustomer, Value)
        End Set
    End Property

    Public ReadOnly Property AvailableCustomer As XPCollection(Of Customer)

        Get
            Dim xpcCustomer As New XPCollection(Of Customer)(Session, False)
            Return xpcCustomer
        End Get
    End Property

    Public Property WorkflowStatus As ISSBaseWorkflowStep Implements IWorkflow.WorkflowStatus
        Get
            Return _mWorkflowStatus
        End Get
        Set(value As ISSBaseWorkflowStep)
            SetPropertyValue(NameOf(WorkflowStatus), _mWorkflowStatus, value)
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
