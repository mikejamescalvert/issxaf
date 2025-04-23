Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Rules
    <CodeRule()> _
    Public Class CustomWorkflowRule
        Inherits RuleBase

        Protected Overloads Overrides Function IsValidInternal(ByVal target As Object, ByRef errorMessageTemplate As String) As Boolean
            Dim strErrorMessage As String = String.Empty
            'Dim strViewId As String = ISS.Base.Helpers.ApplicationHelper.XAFApplication.FindDetailViewId(target.GetType)
            'Dim ddiDictionaryInfo As DevExpress.ExpressApp.DictionaryNode = ISS.Base.Helpers.ApplicationHelper.XAFApplication.FindViewInfo(strViewId)
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.TypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(target.GetType)
            Dim cwvWorkflowValidation As Interfaces.ICustomWorkflowValidation
            Dim wfoWorkflowObject As Interfaces.IWorkflow = Nothing

            If dtiTypeInfo Is Nothing Then
                Return False
            End If

            If target Is Nothing Then
                Return False
            End If

            If dtiTypeInfo.Implements(Of Interfaces.ICustomWorkflowValidation)() = True Then
                cwvWorkflowValidation = target
                If dtiTypeInfo.Implements(Of Interfaces.IWorkflow)() Then
                    wfoWorkflowObject = target
                    strErrorMessage = strErrorMessage + cwvWorkflowValidation.ValidateWorkflowStep(wfoWorkflowObject)
                End If
            End If
            'For Each objDictionaryInfoTemp As DevExpress.ExpressApp.DictionaryNode In ddiDictionaryInfo.ChildNodes
            '    If String.Compare(objDictionaryInfoTemp.DisplayName, "Items", False) = 0 Then
            '        For Each objItems As DevExpress.ExpressApp.DictionaryNode In objDictionaryInfoTemp.ChildNodes
            '            If objItems.DisplayName.Contains(".") <> False Then
            '                Continue For
            '            End If
            '            If Helpers.WorkflowHelper.IsPropertyRequired(target, objItems.DisplayName) <> True Then
            '                Continue For
            '            End If

            '            objPropertyValue = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(objItems.DisplayName, target)
            '            If objPropertyValue IsNot Nothing Then
            '                If TypeOf objPropertyValue Is System.DateTime Then
            '                    If objPropertyValue = Nothing Then
            '                        If strErrorMessage > String.Empty Then
            '                            strErrorMessage = String.Format("{0}, ", strErrorMessage)
            '                        End If
            '                        strErrorMessage = String.Format("{0} Field Required: {1}", strErrorMessage, objItems.FindAttribute("Caption").Value)
            '                    End If
            '                ElseIf TypeOf objPropertyValue Is String Then
            '                    If String.Compare(objPropertyValue, String.Empty, False) = 0 Then
            '                        If strErrorMessage > String.Empty Then
            '                            strErrorMessage = String.Format("{0}, ", strErrorMessage)
            '                        End If
            '                        strErrorMessage = String.Format("{0} Field Required: {1}", strErrorMessage, objItems.FindAttribute("Caption").Value)
            '                    End If
            '                End If
            '            Else
            '                If strErrorMessage > String.Empty Then
            '                    strErrorMessage = String.Format("{0}, ", strErrorMessage)
            '                End If
            '                strErrorMessage = String.Format("{0} Field Required: {1}", strErrorMessage, objItems.FindAttribute("Caption").Value)
            '            End If
            '        Next
            '    End If
            'Next



            If strErrorMessage > String.Empty Then
                errorMessageTemplate = strErrorMessage
                Return False
            Else
                Return True
            End If
        End Function




        Public Sub New()
            MyBase.New("", "Save", GetType(Object))
        End Sub
        Public Sub New(ByVal properties As IRuleBaseProperties)
            MyBase.New(properties)
        End Sub
        Protected Sub New(ByVal id As String, ByVal targetContextIDs As ContextIdentifiers, ByVal targetType As Type)
            MyBase.New(id, targetContextIDs, targetType)
            
        End Sub


    End Class
End Namespace

