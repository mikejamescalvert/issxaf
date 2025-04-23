Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation


<DefaultProperty("StatusName")> _
<System.ComponentModel.ReadOnly(False)> _
<Editor("ISS.Base.Win.WorkflowStepEditor", "ISS.Base.Win.WorkflowStepEditor")> _
<System.ComponentModel.DisplayName("WorkflowStep")> _
<Serializable()> _
Public Class ISSBaseWorkflowStep
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub

#Region "Behaviors"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
#End Region

#Region "Persistent Properties"

    Private _mDescription As String


    Private _mDisplayOrder As Integer
    Private _mDoNotAllowSaveInStep As Boolean

    Private _mObjectCustomization As ISSBaseBusinessRules


    Private _mShowNextStepsBeforeSave As Boolean
    Private _mStatusName As String

    Private _mStepObjectTemplate As ISSBaseUserInterfaceTemplate

    Private _mWorkflowStepGroup As ISSBaseWorkflowStepGroup

    <Size(255)> _
<RuleRequiredField("Workflow.StepName", DefaultContexts.Save, CustomMessageTemplate:="A status name is required.")> _
    Public Property StatusName() As String
        Get
            Return _mStatusName
        End Get
        Set(ByVal value As String)
            If _mStatusName = value Then
                Return
            End If
            _mStatusName = value
        End Set
    End Property

    <Association("WorkflowStepGroups-WorkflowSteps")> _
    <DataSourceProperty("ObjectCustomization.WorkflowStepGroups")> _
        <Xml.Serialization.XmlIgnore()> _
    Public ReadOnly Property WorkflowStepGroups As XPCollection(Of ISSBaseWorkflowStepGroup)
        Get
            Return GetCollection(Of ISSBaseWorkflowStepGroup)("WorkflowStepGroups")
        End Get
    End Property

    '    <Association("WorkflowStepGroup-WorkflowSteps")> _
    '<DataSourceProperty("ObjectCustomization.WorkflowStepGroups")> _
    '    <ISS.Base.Attributes.ObjectEditor.ObjectEditorButtons(False, True, True, False)> _
    '    <Xml.Serialization.XmlIgnore()> _
    '    Public Property WorkflowStepGroup() As ISSBaseWorkflowStepGroup
    '        Get
    '            Return _mWorkflowStepGroup
    '        End Get
    '        Set(ByVal value As ISSBaseWorkflowStepGroup)
    '            If _mWorkflowStepGroup Is value Then
    '                Return
    '            End If
    '            _mWorkflowStepGroup = value
    '        End Set
    '    End Property

    <Size(SizeAttribute.Unlimited)> _
    Public Property Description() As String
        Get
            Return _mDescription
        End Get
        Set(ByVal value As String)
            If _mDescription = value Then
                Return
            End If
            _mDescription = value
        End Set
    End Property
    Public Property DisplayOrder() As Integer
        Get
            Return _mDisplayOrder
        End Get
        Set(ByVal value As Integer)
            If _mDisplayOrder = value Then
                Return
            End If
            _mDisplayOrder = value
        End Set
    End Property
    Public Property DoNotAllowSaveInStep() As Boolean
        Get
            Return _mDoNotAllowSaveInStep
        End Get
        Set(ByVal value As Boolean)
            If _mDoNotAllowSaveInStep = value Then
                Return
            End If
            _mDoNotAllowSaveInStep = value
        End Set
    End Property
    <Association("ObjectCustomization-WorkflowSteps")> _
    <Browsable(False)> _
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

    <DataSourceProperty("ObjectCustomization.ObjectTemplates")> _
    <ISS.Base.Attributes.ObjectEditor.ObjectEditorButtons(False, True, True, False)> _
    Public Property StepObjectTemplate() As ISSBaseUserInterfaceTemplate
        Get
            Return _mStepObjectTemplate
        End Get
        Set(ByVal value As ISSBaseUserInterfaceTemplate)
            If _mStepObjectTemplate Is value Then
                Return
            End If
            _mStepObjectTemplate = value
        End Set
    End Property
    Public Property ShowNextStepsBeforeSave() As Boolean
        Get
            Return _mShowNextStepsBeforeSave
        End Get
        Set(ByVal value As Boolean)
            If _mShowNextStepsBeforeSave = value Then
                Return
            End If
            _mShowNextStepsBeforeSave = value
        End Set
    End Property


#End Region

#Region "Associations"


    <Association("CriteriaTemplates-WorkflowSteps")> _
    <DataSourceProperty("ObjectCustomization.CriteriaTemplates")> _
    Public ReadOnly Property CriteriaTemplates() As XPCollection(Of ISSBaseCriteriaTemplate)
        Get
            Return GetCollection(Of ISSBaseCriteriaTemplate)("CriteriaTemplates")
        End Get
    End Property
    <Association("PreviousSteps-NextGroups")> _
    <DataSourceProperty("ObjectCustomization.WorkflowStepGroups")> _
    Public ReadOnly Property NextGroups() As XPCollection(Of ISSBaseWorkflowStepGroup)
        Get
            Return GetCollection(Of ISSBaseWorkflowStepGroup)("NextGroups")
        End Get
    End Property
    <Association("PreviousSteps-NextSteps")> _
    <DataSourceProperty("ObjectCustomization.WorkflowSteps")> _
        Public ReadOnly Property NextSteps() As XPCollection(Of ISSBaseWorkflowStep)
        Get
            Return GetCollection(Of ISSBaseWorkflowStep)("NextSteps")
        End Get
    End Property

    <Association("PreviousSteps-NextSteps")> _
    <Browsable(False)> _
    <Xml.Serialization.XmlIgnore()> _
    Public ReadOnly Property PreviousSteps() As XPCollection(Of ISSBaseWorkflowStep)
        Get
            Return GetCollection(Of ISSBaseWorkflowStep)("PreviousSteps")
        End Get
    End Property
#End Region

End Class
