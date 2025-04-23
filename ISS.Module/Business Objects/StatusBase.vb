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
Imports DevExpress.ExpressApp.Editors

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
<DefaultClassOptions()>
<RuleCombinationOfPropertiesIsUnique("Priority;ObjectType")>
Public Class StatusBase ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ObjectType = GetObjectType()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _mCriteria As String
    <Size(-1)>
    <CriteriaOptions("ObjectType")>
    Property Criteria As String
        Get
            Return _mCriteria
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Criteria), _mCriteria, Value)
        End Set
    End Property

    Private _mPriority As Integer

    Property Priority As Integer
        Get
            Return _mPriority
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(NameOf(Priority), _mPriority, Value)
        End Set
    End Property

    Private _mObjectType As Type
    Property ObjectType As Type
        Get
            Return _mObjectType
        End Get
        Set(ByVal Value As Type)
            SetPropertyValue(NameOf(ObjectType), _mObjectType, Value)
        End Set
    End Property

    Public Overridable Function GetObjectType() As Type
        Return Nothing
    End Function





    '<Browsable(False)>
    '<Persistent()>
    'Public MustOverride ReadOnly Property ObjectType As Type

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
