Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Rules
    <CodeRule()> _
    Public Class WorkflowRule
        Inherits RuleBase(Of Interfaces.IWorkflow)

        Protected Overloads Overrides Function IsValidInternal(ByVal target As Interfaces.IWorkflow, ByRef errorMessageTemplate As String) As Boolean
            Dim strErrorMessage As String = String.Empty
            'Dim strViewId As String = ISS.Base.Helpers.ApplicationHelper.XAFApplication.FindDetailViewId(target.GetType)
            'Dim ddiDictionaryInfo As DevExpress.ExpressApp.DictionaryNode = ISS.Base.Helpers.ApplicationHelper.XAFApplication.FindViewInfo(strViewId)
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.TypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(target.GetType)
            Dim wfoWorkflowObject As Interfaces.IWorkflow = Nothing

            If dtiTypeInfo Is Nothing Then
                Return False
            End If

            'If ddiDictionaryInfo Is Nothing Then
            '    Return True
            'End If

            If target Is Nothing Then
                Return False
            End If

            If dtiTypeInfo IsNot Nothing Then
                If dtiTypeInfo.Implements(Of Interfaces.IWorkflow)() = True Then
                    wfoWorkflowObject = target
                    If wfoWorkflowObject.WorkflowStatus IsNot Nothing AndAlso wfoWorkflowObject.WorkflowStatus.DoNotAllowSaveInStep = True Then
                        strErrorMessage = String.Format("You cannot save in this workflow step: {0}", wfoWorkflowObject.WorkflowStatus.StatusName)
                    End If
                End If
            End If

            If strErrorMessage > String.Empty Then
                errorMessageTemplate = strErrorMessage
                Return False
            Else
                Return True
            End If
        End Function

        Public Sub New()
            MyBase.New("", "Save")
        End Sub
        Public Sub New(ByVal properties As IRuleBaseProperties)
            MyBase.New(properties)
        End Sub
        Protected Sub New(ByVal id As String, ByVal targetContextIDs As ContextIdentifiers)
            MyBase.New(id, targetContextIDs)
            
        End Sub
        Protected Sub New(ByVal id As String, ByVal targetContextIDs As ContextIdentifiers, ByVal targetType As Type)
            MyBase.New(id, targetContextIDs, targetType)
            
        End Sub


    End Class
End Namespace

