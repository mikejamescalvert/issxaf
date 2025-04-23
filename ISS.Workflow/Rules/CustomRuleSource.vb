Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Imports System.Linq
Imports ISS.Workflow.Rules

Public Class CustomRuleSource
    Implements DevExpress.Persistent.Validation.IRuleSource

    Private Shared _mLastTemplateUpdate As DateTime
    Private Shared _mTemplates As New List(Of DevExpress.Persistent.Validation.IRule)
    Public Shared ReadOnly Property Templates() As List(Of DevExpress.Persistent.Validation.IRule)
        Get
            If _mTemplates Is Nothing OrElse _mLastTemplateUpdate < Now.AddMinutes(-5) Then
                BuildTemplates()
            End If
            Return _mTemplates
        End Get
    End Property

    Public Shared Sub BuildTemplates()
        Dim xpcObjectCollection As XPCollection(Of ISSBaseBusinessRules)
        Dim ctrCriteriaRule As Rules.CriteriaRule
        Dim sshSession As Session
        Dim wkeWorkflowEvaluator As Rules.CriteriaRule.WorkflowStepEvaluator

        _mTemplates.Clear()
        sshSession = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderSession
        xpcObjectCollection = New XPCollection(Of ISSBaseBusinessRules)(sshSession)
        For Each broBusinessRules As ISSBaseBusinessRules In xpcObjectCollection
            For Each oCriteria As ISSBaseCriteriaTemplate In broBusinessRules.SaveValidationCriteriaTemplates
                If _mTemplates.FirstOrDefault(Function(m) CType(m, CriteriaRule).ObjectId = oCriteria.Oid) IsNot Nothing
                    Continue For
                End If
                ctrCriteriaRule = New Rules.CriteriaRule
                ctrCriteriaRule.ObjectId = oCriteria.Oid
                ctrCriteriaRule.TemplateName = oCriteria.CriteriaName
                ctrCriteriaRule.BaseEvaluator = oCriteria.GetEvaluator
                ctrCriteriaRule.TargetType = broBusinessRules.ObjectType
                ctrCriteriaRule.FullExceptionMessage = oCriteria.FullExceptionMessage
                'If oCriteria.DefaultSaveValidationObjectCustomization IsNot Nothing Then
                ctrCriteriaRule.IsObjectRule = True
                'End If
                _mTemplates.Add(ctrCriteriaRule)
            Next
            For Each oCriteria As ISSBaseCriteriaTemplate In broBusinessRules.CriteriaTemplates
                If _mTemplates.FirstOrDefault(Function(m) CType(m, CriteriaRule).ObjectId = oCriteria.Oid) IsNot Nothing
                    Continue For
                End If
                If oCriteria.WorkflowSteps.Count = 0 Then
                    Continue For
                End If
                ctrCriteriaRule = New Rules.CriteriaRule
                ctrCriteriaRule.ObjectId = oCriteria.Oid
                ctrCriteriaRule.TemplateName = oCriteria.CriteriaName
                ctrCriteriaRule.BaseEvaluator = oCriteria.GetEvaluator
                ctrCriteriaRule.TargetType = broBusinessRules.ObjectType
                ctrCriteriaRule.FullExceptionMessage = oCriteria.FullExceptionMessage
                For Each oWorkflowStep As ISSBaseWorkflowStep In oCriteria.WorkflowSteps
                    wkeWorkflowEvaluator = New Rules.CriteriaRule.WorkflowStepEvaluator
                    wkeWorkflowEvaluator.Oid = oWorkflowStep.Oid
                    ctrCriteriaRule.WorkflowStepEvaluators.Add(wkeWorkflowEvaluator)
                Next
                _mTemplates.Add(ctrCriteriaRule)
            Next
        Next
        xpcObjectCollection.Dispose()
        xpcObjectCollection = Nothing
        sshSession.DropIdentityMap()
        sshSession.Dispose()
        sshSession = Nothing
        _mLastTemplateUpdate = Now
    End Sub

    Public Function CreateRules() As System.Collections.Generic.ICollection(Of DevExpress.Persistent.Validation.IRule) Implements DevExpress.Persistent.Validation.IRuleSource.CreateRules
        Return Templates
    End Function

    Public ReadOnly Property Name() As String Implements DevExpress.Persistent.Validation.IRuleSource.Name
        Get
            Return "Criteria Rule Source Provider"
        End Get
    End Property

End Class
