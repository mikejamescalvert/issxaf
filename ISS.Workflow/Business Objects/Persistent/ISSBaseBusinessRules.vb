Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.BaseImpl

<DefaultProperty("ObjectType")> _
<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("BusinessRules")> _
<Serializable()> _
Public Class ISSBaseBusinessRules
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub

#Region "Behaviors"
    Public Function IsValidObject(ByVal Target As Object, ByVal Evaluator As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator) As Boolean
        If Target Is Nothing Then
            Return False
        End If

        If Target.GetType IsNot ObjectType Then
            Return False
        End If
        Return Evaluator.Fit(Target)
    End Function
    Private Sub ClearObjectDefinition()
        DefaultObjectTemplate = Nothing
        DefaultWorkflowStep = Nothing
        If WorkflowSteps IsNot Nothing Then
            For intLoop As Integer = WorkflowSteps.Count - 1 To 0 Step -1
                WorkflowSteps(intLoop).Delete()
            Next
        End If
        If ObjectTemplates IsNot Nothing Then
            For intLoop As Integer = ObjectTemplates.Count - 1 To 0 Step -1
                ObjectTemplates(intLoop).Delete()
            Next
        End If

    End Sub
   
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private Sub ISSBaseBusinessRules_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed
        Select e.PropertyName
            Case "SavedType"
                OnChanged("ImplementsWorkflow")
                OnChanged("DefaultViewIdOverride")
        End Select
    End Sub
#End Region

#Region "Persistent Properties"







    <VisibleInListView(False)>
    <VisibleInDetailView(False)>
    Public ReadOnly Property ImplementsWorkflow As Boolean
        Get
            Dim objTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ObjectType)
            If objTypeInfo Is Nothing Then
                Return False
            Else
                Return objTypeInfo.Implements(Of Interfaces.IWorkflow)
            End If
        End Get
    End Property

    Private _mDefaultObjectTemplate As ISSBaseUserInterfaceTemplate
    <DataSourceProperty("ObjectTemplates")> _
    <ISS.Base.Attributes.ObjectEditor.ObjectEditorButtons(True, True, True, False)> _
    Property DefaultObjectTemplate As ISSBaseUserInterfaceTemplate
        Get
            Return _mDefaultObjectTemplate
        End Get
        Set(ByVal Value As ISSBaseUserInterfaceTemplate)
            SetPropertyValue("DefaultObjectTemplate", _mDefaultObjectTemplate, Value)
        End Set
    End Property
    Private _mDefaultWorkflowStep As ISSBaseWorkflowStep
    <DataSourceProperty("WorkflowSteps")> _
    <ISS.Base.Attributes.ObjectEditor.ObjectEditorButtons(True, True, True, False)> _
    Public Property DefaultWorkflowStep() As ISSBaseWorkflowStep
        Get
            Return _mDefaultWorkflowStep
        End Get
        Set(ByVal value As ISSBaseWorkflowStep)
            SetPropertyValue("DefaultWorkflowStep", _mDefaultWorkflowStep, Value)
        End Set
    End Property
        Private _mDefaultWorkflowStepGroup As ISSBaseWorkflowStepGroup
    <DataSourceProperty("WorkflowStepGroups")> _
    <ISS.Base.Attributes.ObjectEditor.ObjectEditorButtons(True, True, True, False)> _
    Public Property DefaultWorkflowStepGroup() As ISSBaseWorkflowStepGroup
        Get
            Return _mDefaultWorkflowStepGroup
        End Get
        Set(ByVal value As ISSBaseWorkflowStepGroup)
            SetPropertyValue("DefaultWorkflowStepGroup", _mDefaultWorkflowStepGroup, Value)
        End Set
    End Property
    <RuleRequiredField("ObjectCustomization.ObjectTypeRequired", DefaultContexts.Save, "Object Type Is Required")> _
    <RuleUniqueValue("ObjectCustomization.ObjectTypeUnique", DefaultContexts.Save, "Object Type Already Has Workflow")> _
    <ImmediatePostData()>
    Public Property ObjectType() As Type
        Get
            Return DevExpress.Persistent.Base.ReflectionHelper.FindType(_mSavedType)
        End Get
        Set(ByVal value As Type)
            SavedType = value.FullName
            
            ClearObjectDefinition()
        End Set
    End Property

    Private _mSavedType As String
    <Size(255)>
    <Browsable(False)> _
    <ImmediatePostData()>
    Property SavedType As String
        Get
            Return _mSavedType
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SavedType", _mSavedType, Value)
        End Set
    End Property
    Private _mTrackChanges As Boolean
    Property TrackChanges As Boolean
        Get
            Return _mTrackChanges
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("TrackChanges", _mTrackChanges, Value)
        End Set
    End Property
    Private _mDefaultViewIdOverride As String
    <Size(255)>
    <ISS.Base.Attributes.Editors.PropertyEditors.ViewIdEditor("ObjectType")>
    Property DefaultViewIdOverride As String
        Get
            Return _mDefaultViewIdOverride
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("DefaultViewIdOverride", _mDefaultViewIdOverride, Value)
        End Set
    End Property
    

#End Region

#Region "Associations"
    <Association("ObjectCustomization-CriteriaTemplates")> _
    <Aggregated()> _
    Public ReadOnly Property CriteriaTemplates() As XPCollection(Of ISSBaseCriteriaTemplate)
        Get
            Return GetCollection(Of ISSBaseCriteriaTemplate)("CriteriaTemplates")
        End Get
    End Property
    <Association("ObjectCustomization-ObjectTemplates")> _
    <Aggregated()> _
    Public ReadOnly Property ObjectTemplates() As XPCollection(Of ISSBaseUserInterfaceTemplate)
        Get
            Return GetCollection(Of ISSBaseUserInterfaceTemplate)("ObjectTemplates")
        End Get
    End Property
    <Association("DefaultSaveValidationObjectCustomization-SaveValidationCriteriaTemplates")> _
    <Aggregated()>
    Public ReadOnly Property SaveValidationCriteriaTemplates() As XPCollection(Of ISSBaseCriteriaTemplate)
        Get
            Return GetCollection(Of ISSBaseCriteriaTemplate)("SaveValidationCriteriaTemplates")
        End Get
    End Property
    <Association("ObjectCustomization-WorkflowStepGroups")> _
    <Aggregated()> _
    Public ReadOnly Property WorkflowStepGroups() As XPCollection(Of ISSBaseWorkflowStepGroup)
        Get
            Return GetCollection(Of ISSBaseWorkflowStepGroup)("WorkflowStepGroups")
        End Get
    End Property
    <Association("ObjectCustomization-WorkflowSteps")> _
    <Aggregated()> _
    Public ReadOnly Property WorkflowSteps() As XPCollection(Of ISSBaseWorkflowStep)
        Get
            Return GetCollection(Of ISSBaseWorkflowStep)("WorkflowSteps")
        End Get
    End Property
    <Association("ObjectCustomization-CustomCaptions")> _
<Aggregated()> _
    Public ReadOnly Property CustomCaptions As XPCollection(Of ISSBaseCustomCaption)
        Get
            Return GetCollection(Of ISSBaseCustomCaption)("CustomCaptions")
        End Get
    End Property

    <Association("ISSBaseBusinessRules-ISSBaseConditionalViews")> _
    <Aggregated()> _
    Public ReadOnly Property ISSBaseConditionalViews() As XPCollection(Of ISSBaseConditionalView)
        Get
            Return GetCollection(Of ISSBaseConditionalView)("ISSBaseConditionalViews")
        End Get
    End Property

#End Region

End Class
