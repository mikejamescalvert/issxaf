Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Base.General
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Xpo
Imports Microsoft.VisualBasic

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
<DefaultClassOptions()>
Public Class ScheduledEvent ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    ' Use CodeRush To create XPO classes And properties With a few keystrokes.
    Implements IEvent
    ' https://docs.devexpress.com/CodeRushForRoslyn/118557
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _mSubject As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    Property Subject As String Implements IEvent.Subject
        Get
            Return _mSubject
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Subject), _mSubject, Value)
        End Set
    End Property

    Private _mDescription As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    Property Description As String Implements IEvent.Description
        Get
            Return _mDescription
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Description), _mDescription, Value)
        End Set
    End Property

    Private _mStartOn As Date
    Property StartOn As Date Implements IEvent.StartOn
        Get
            Return _mStartOn
        End Get
        Set(ByVal Value As Date)
            SetPropertyValue(NameOf(StartOn), _mStartOn, Value)
        End Set
    End Property

    Private _mEndOn As Date
    Property EndOn As Date Implements IEvent.EndOn
        Get
            Return _mEndOn
        End Get
        Set(ByVal Value As Date)
            SetPropertyValue(NameOf(EndOn), _mEndOn, Value)
        End Set
    End Property

    Private _mAllDay As Boolean
    Property AllDay As Boolean Implements IEvent.AllDay
        Get
            Return _mAllDay
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue(NameOf(AllDay), _mAllDay, Value)
        End Set
    End Property

    Private _mLocation As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    Property Location As String Implements IEvent.Location
        Get
            Return _mLocation
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Location), _mLocation, Value)
        End Set
    End Property

    Private _mLabel As Integer
    Property Label As Integer Implements IEvent.Label
        Get
            Return _mLabel
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(Label), _mLabel, Value)
        End Set
    End Property
    Private _mStatus As Integer
    Property Status As Integer Implements IEvent.Status
        Get
            Return _mStatus
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(Status), _mStatus, Value)
        End Set
    End Property

    Private _mType As Integer
    Property Type As Integer Implements IEvent.Type
        Get
            Return _mType
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(Type), _mType, Value)
        End Set
    End Property

    Private _mResourceId As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    Property ResourceId As String Implements IEvent.ResourceId
        Get
            Return _mResourceId
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(ResourceId), _mResourceId, Value)
        End Set
    End Property


    Public ReadOnly Property AppointmentId As Object Implements IEvent.AppointmentId
        Get
            Return Oid
        End Get
    End Property

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
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
    '        SetPropertyValue(nameof(PersistentProperty), _PersistentProperty, value)
    '    End Set
    'End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
