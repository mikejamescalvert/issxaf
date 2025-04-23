Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultProperty("Name")> _
<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("WorkflowStepGroup")> _
<Serializable()> _
 Public Class ISSBaseWorkflowStepGroup
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub

#Region "Behaviors"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Public Function IsWorkflowStepInGroup(ByVal WorkflowStep As ISSBaseWorkflowStep) As Boolean
        Dim xcl As New XPCollection(Of ISSBaseWorkflowStep)(Session, WorkflowSteps)
        xcl.Filter = New BinaryOperator("Oid", WorkflowStep.Oid)
        If xcl.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "Persistent Properties"
    Private _mName As String

    Private _mObjectCustomization As ISSBaseBusinessRules
    <Size(255)> _
    Public Property Name() As String
        Get
            Return _mName
        End Get
        Set(ByVal Value As String)
            _mName = Value
        End Set
    End Property
    <Association("ObjectCustomization-WorkflowStepGroups")> _
    <Xml.Serialization.XmlIgnore()> _
    Public Property ObjectCustomization() As ISSBaseBusinessRules
        Get
            Return _mObjectCustomization
        End Get
        Set(ByVal value As ISSBaseBusinessRules)
            If _mObjectCustomization Is value Then
                Return
            End If
            _mObjectCustomization = value
        End Set
    End Property
#End Region

#Region "Associations"
    <Association("PreviousSteps-NextGroups")> _
    <Browsable(False)> _
    Public ReadOnly Property PreviousSteps() As XPCollection(Of ISSBaseWorkflowStep)
        Get
            Return GetCollection(Of ISSBaseWorkflowStep)("PreviousSteps")
        End Get
    End Property

    <Association("WorkflowStepGroups-WorkflowSteps")> _
    <DataSourceProperty("ObjectCustomization.WorkflowSteps")> _
    Public ReadOnly Property WorkflowSteps() As XPCollection(Of ISSBaseWorkflowStep)
        Get
            Return GetCollection(Of ISSBaseWorkflowStep)("WorkflowSteps")
        End Get
    End Property
#End Region


End Class
