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
<ISS.Base.Attributes.DragAndDropSortableColumn("ProjectId")>
Public Class Project ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private Sub Project_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed
        If e.PropertyName = "Customer" Then
            If Customer.Projects.Count > 0 Then
                ProjectId = Customer.Projects.Max(Function(m) m.ProjectId) + 1
            Else
                ProjectId = 1
            End If

        End If
    End Sub



    Private _mProjectId As Integer
    Property ProjectId As Integer
        Get
            Return _mProjectId
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(ProjectId), _mProjectId, Value)
        End Set
    End Property


    Private _mCustomer As Customer
    <Association("Customer-Projects")>
    Property Customer As Customer
        Get
            Return _mCustomer
        End Get
        Set(ByVal Value As Customer)
            SetPropertyValue(NameOf(Customer), _mCustomer, Value)
        End Set
    End Property

    <Association("Project-ProjectTasks")>
    <Aggregated()>
    Public ReadOnly Property ProjectTasks() As XPCollection(Of ProjectTask)
        Get
            Return GetCollection(Of ProjectTask)(NameOf(ProjectTasks))
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
    '        SetPropertyValue(nameof(PersistentProperty), _PersistentProperty, value)
    '    End Set
    'End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
