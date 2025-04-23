Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Rules

    Public Class CriteriaRule
        Inherits RuleBase

        Private _mObjectId As Guid
        Property ObjectId As Guid
            Get
                Return _mObjectId
            End Get
            Set(ByVal Value As Guid)
                _mObjectId = Value
            End Set
        End Property
        

        Private _mTemplateName As String
        Public Property TemplateName() As String
            Get
                Return _mTemplateName
            End Get
            Set(ByVal Value As String)
                _mTemplateName = Value
            End Set
        End Property


        Private _mTargetType As Type
        Public Property TargetType() As Type
            Get
                Return _mTargetType
            End Get
            Set(ByVal value As Type)
                If _mTargetType Is value Then
                    Return
                End If
                _mTargetType = value
            End Set
        End Property

        Private _mBaseEvaluator As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator
        Public Property BaseEvaluator() As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator
            Get
                Return _mBaseEvaluator
            End Get
            Set(ByVal value As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator)
                If _mBaseEvaluator Is value Then
                    Return
                End If
                _mBaseEvaluator = value
            End Set
        End Property


        Private _mFullExceptionMessage As String
        Public Property FullExceptionMessage() As String
            Get
                Return _mFullExceptionMessage
            End Get
            Set(ByVal Value As String)
                _mFullExceptionMessage = Value
            End Set
        End Property


        Private _mWorkflowStepEvaluators As New List(Of WorkflowStepEvaluator)
        Public Property WorkflowStepEvaluators() As List(Of WorkflowStepEvaluator)
            Get
                Return _mWorkflowStepEvaluators
            End Get
            Set(ByVal value As List(Of WorkflowStepEvaluator))
                If _mWorkflowStepEvaluators Is value Then
                    Return
                End If
                _mWorkflowStepEvaluators = value
            End Set
        End Property

        Private _mIsObjectRule As Boolean
        Public Property IsObjectRule() As Boolean
            Get
                Return _mIsObjectRule
            End Get
            Set(ByVal value As Boolean)
                If _mIsObjectRule = value Then
                    Return
                End If
                _mIsObjectRule = value
            End Set
        End Property

        Protected Overloads Overrides Function IsValidInternal(ByVal target As Object, <System.Runtime.InteropServices.Out()> ByRef errorMessageTemplate As String) As Boolean
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.TypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(target.GetType)
            Dim wfoWorkflowObject As Interfaces.IWorkflow = Nothing

            If dtiTypeInfo Is Nothing Then
                Throw New Exception("Rule Executed For Object Type That Does Not Exist.")
            End If

            If target Is Nothing Then
                Throw New Exception("Rule Executed For Object That Does Not Exist.")
            End If

            If target.GetType IsNot TargetType Then
                Return True
            End If

            If IsObjectRule = False And dtiTypeInfo.Implements(Of Workflow.Interfaces.IWorkflow)() = False Then
                Return True
            End If

            If IsObjectRule = True Then
                If BaseEvaluator.Fit(target) = False Then
                    errorMessageTemplate = FullExceptionMessage
                    Return False
                End If
            End If

            If WorkflowStepEvaluators.Count = 0 Then
                Return True
            End If

            If dtiTypeInfo.Implements(Of Workflow.Interfaces.IWorkflow)() = False Then
                Return True
            End If

            wfoWorkflowObject = target
            If wfoWorkflowObject.WorkflowStatus Is Nothing Then
                Return True
            End If

            For Each wksWorkflowStep In WorkflowStepEvaluators
                If wfoWorkflowObject.WorkflowStatus.Oid <> wksWorkflowStep.Oid Then
                    Continue For
                End If

                If BaseEvaluator.Fit(target) = False Then
                    errorMessageTemplate = FullExceptionMessage
                    Return False
                End If
            Next
            Return True
        End Function

        Public Sub New()
            MyBase.New("", "Save", GetType(Object))
        End Sub
        Public Sub New(ByVal properties As IRuleBaseProperties)
            MyBase.New(properties)
        End Sub

        Public Class WorkflowStepEvaluator
            Private _mOid As System.Guid
            Public Property Oid() As System.Guid
                Get
                    Return _mOid
                End Get
                Set(ByVal Value As System.Guid)
                    _mOid = Value
                End Set
            End Property

        End Class

    End Class

End Namespace