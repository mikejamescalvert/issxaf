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
<DefaultClassOptions()> _
Public Class Customer ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

        'CustomerId = Session.Evaluate(GetType(Customer), CriteriaOperator.Parse("Max(CustomerId)"), Nothing) + 1
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub


    Private _mCustomerNote As String
    Private _mCustomerId As Integer
    Property CustomerId As Integer
        Get
            Return _mCustomerId
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Nameof(CustomerId), _mCustomerId, Value)
        End Set
    End Property

    Private _mCustomerName As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    Property CustomerName As String
        Get
            Return _mCustomerName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(CustomerName), _mCustomerName, Value)
        End Set
    End Property

    <Association("Customer-Projects")>
    Public ReadOnly Property Projects() As XPCollection(Of Project)
        Get
            Return GetCollection(Of Project)(NameOf(Projects))
        End Get
    End Property

    Public ReadOnly Property PdfFilePath As String
        Get
            Return "C:\Users\mikej\Documents\Mike's ID.pdf"
        End Get
    End Property

    <Size(-1)>
    Property CustomerNote As String
        Get
            Return _mCustomerNote
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Nameof(CustomerNote), _mCustomerNote, Value)
        End Set
    End Property

    Private _mCustomerImage As System.Drawing.Image
    <ValueConverter(GetType(DevExpress.Xpo.Metadata.ImageValueConverter))>
    Property CustomerImage As System.Drawing.Image
        Get
            Return _mCustomerImage
        End Get
        Set(ByVal Value As System.Drawing.Image)
            SetPropertyValue(NameOf(CustomerImage), _mCustomerImage, Value)
            OnChanged("SavedCustomerImage")
        End Set
    End Property

    Private _mActiveDate As Date
    <ImmediatePostData()>
    Property ActiveDate As Date
        Get
            Return _mActiveDate
        End Get
        Set(ByVal Value As Date)
            SetPropertyValue(Nameof(ActiveDate), _mActiveDate, Value)
        End Set
    End Property


    'Public ReadOnly Property SavedCustomerImage As System.Drawing.Image
    '    Get
    '        Return CustomerImage
    '    End Get
    'End Property


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

    Public Enum CustomerTypes
        Normal
        Business
        Advanced
        Internal
        Other
    End Enum

    Private _mCustomerType As CustomerTypes?
    <DataSourceProperty("AvailableCustomerTypes")>
    Property CustomerType As CustomerTypes?
        Get
            Return _mCustomerType
        End Get
        Set(ByVal Value As CustomerTypes?)
            If (_mCustomerType = Value) Then Return
            _mCustomerType = Value
            RaisePropertyChangedEvent(NameOf(CustomerType))
        End Set
    End Property

    Public ReadOnly Property AvailableCustomerTypes As List(Of CustomerTypes?)
        Get
            Dim lstTypes As New List(Of CustomerTypes?)
            If Me.ActiveDate > "3/1/2024" Then
                lstTypes.Add(CustomerTypes.Advanced)
            End If
            lstTypes.Add(CustomerTypes.Normal)
            lstTypes.Add(CustomerTypes.Business)
            lstTypes.Add(CustomerTypes.Internal)
            lstTypes.Add(Nothing)
            Return lstTypes
        End Get
    End Property

End Class
