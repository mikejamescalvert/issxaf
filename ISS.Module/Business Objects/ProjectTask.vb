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
'<DefaultClassOptions()>
<ISS.Base.Attributes.DragAndDropSortableColumn("ProjectTaskId")>
Public Class ProjectTask ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private Sub ProjectTask_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed
        If e.PropertyName = "Project" Then
            If Project.ProjectTasks.Count > 0 Then
                ProjectTaskId = Project.ProjectTasks.Max(Function(m) m.ProjectTaskId) + 1
            Else
                ProjectTaskId = 1
            End If

        End If
    End Sub

    Private _mProjectTaskId As Integer
    Property ProjectTaskId As Integer
        Get
            Return _mProjectTaskId
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue(Nameof(ProjectTaskId), _mProjectTaskId, Value)
        End Set
    End Property

    Private _mProject As Project
    <Association("Project-ProjectTasks")> _
    Property Project() As Project
        Get
            Return _mProject
        End Get
        Set(ByVal Value As Project)
            SetPropertyValue(Nameof(Project), _mProject, Value)
        End Set
    End Property
    

    Private _mName As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    Property Name As String
        Get
            Return _mName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Nameof(Name), _mName, Value)
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
    '        SetPropertyValue(nameof(PersistentProperty), _PersistentProperty, value)
    '    End Set
    'End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
