Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent
Imports ISS.Base.Helpers
Imports ISS.Workflow.Interfaces
Imports DevExpress.Data.Filtering.Helpers
Imports DevExpress.Data.Filtering
Imports System.Linq

Namespace Helpers
    Public Class WorkflowHelper

        ''' <summary>
        ''' Each aspect is an attribute of a control which can be adjusted based on the object's workflow.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum ControlAttributeTypes
            Enabled = 0
            Visible = 1
            Required = 2
            EnabledIfExists = 3
            [ReadOnly] = 4
            ReadonlyIfExists = 5
        End Enum

        ''' <summary>
        ''' Determines if an object's property should be required based on the current workflow.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="PropertyName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsPropertyRequired(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication) As System.Nullable(Of Boolean)
            Return GetWorkflowControlAttributeTypeValue(WorkflowObject, PropertyName, ControlAttributeTypes.Required, ObjectType, Application)
        End Function
        ''' <summary>
        ''' Determines if an object's property should be visible based on the current workflow.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="PropertyName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsPropertyVisible(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication) As System.Nullable(Of Boolean)
            Return GetWorkflowControlAttributeTypeValue(WorkflowObject, PropertyName, ControlAttributeTypes.Visible, ObjectType, Application)
        End Function
        ''' <summary>
        ''' Determines if an object's property should be enabled based on the current workflow.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="PropertyName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsPropertyEnabled(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal application As XafApplication) As System.Nullable(Of Boolean)
            Return GetWorkflowControlAttributeTypeValue(WorkflowObject, PropertyName, ControlAttributeTypes.Enabled, ObjectType, application)
        End Function


        Public Shared Function GetEditorTemplate(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication)
            Dim lstTemplateSource As IEnumerable(Of ISSBaseEditorStateTemplate) = Nothing
            Dim dtiMasterType As DevExpress.ExpressApp.DC.TypeInfo
            Dim wfiInterface As IWorkflow
            Dim objWorkflowDefinition As ISSBaseBusinessRules
            Dim xpoMatchedPropertyTemplate As ISSBaseEditorStateTemplate = Nothing
            If WorkflowObject Is Nothing Then
                Return Nothing
            End If

            dtiMasterType = XafTypesInfo.Instance.FindTypeInfo(WorkflowObject.GetType)
            If dtiMasterType Is Nothing Then
                Return Nothing
            End If

            wfiInterface = If(dtiMasterType.Implements(Of IWorkflow)(), WorkflowObject, Nothing)

            objWorkflowDefinition = If(wfiInterface IsNot Nothing, GetObjectCustomizationFromWorkflowObject(wfiInterface, dtiMasterType), Nothing)

            If objWorkflowDefinition Is Nothing Then
                objWorkflowDefinition = GetObjectCustomizationFromCollection(WorkflowObject.GetType, Application)
            End If

            If wfiInterface Is Nothing And objWorkflowDefinition Is Nothing Then
                Return Nothing
            End If

            If wfiInterface IsNot Nothing AndAlso wfiInterface.WorkflowStatus IsNot Nothing AndAlso wfiInterface.WorkflowStatus.StepObjectTemplate IsNot Nothing Then
                lstTemplateSource = wfiInterface.WorkflowStatus.StepObjectTemplate.PropertyTemplates
                
            End If

            If lstTemplateSource Is Nothing AndAlso objWorkflowDefinition IsNot Nothing AndAlso objWorkflowDefinition.DefaultObjectTemplate IsNot Nothing Then
                lstTemplateSource = objWorkflowDefinition.DefaultObjectTemplate.PropertyTemplates
            End If

            If lstTemplateSource IsNot Nothing
                Return lstTemplateSource.FirstOrDefault(Function (m) m.DoesPropertyMatch(ObjectType,PropertyName) = True)
            End If
            Return Nothing
        End Function

        Public Shared Function GetEditorColor(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication) As System.Drawing.Color
            Dim objPropertyTemplate As ISSBaseEditorStateTemplate = GetEditorTemplate(WorkflowObject,PropertyName,ObjectType,Application)

            If objPropertyTemplate IsNot Nothing Then
                If objPropertyTemplate.GetCriteriaValue(GetParentObject(WorkflowObject, PropertyName)) = True Then
                    Return objPropertyTemplate.TrueEditorStateColor
                Else
                    Return objPropertyTemplate.FalseEditorStateColor
                End If
            End If

            Return Nothing
            
        End Function

        ''' <summary>
        ''' Determines if an object's property should be readonly based on the current workflow.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="PropertyName"></param>
        ''' <returns></returns>
        ''' <remarks>The property must have a value in the current context to be readonly, otherwise it will not be.</remarks>
        Public Shared Function IsDisabledIfExists(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication) As System.Nullable(Of Boolean)
            Return GetWorkflowControlAttributeTypeValue(WorkflowObject, PropertyName, ControlAttributeTypes.EnabledIfExists, ObjectType, Application)
        End Function
        ''' <summary>
        ''' Determines if an object's property should be readonly based on the current workflow.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="PropertyName"></param>
        ''' <returns></returns>
        ''' <remarks>The property must have a value in the current context to be readonly, otherwise it will not be.</remarks>
        Public Shared Function IsReadOnly(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal Application As XafApplication) As System.Nullable(Of Boolean)
            Return GetWorkflowControlAttributeTypeValue(WorkflowObject, PropertyName, ControlAttributeTypes.ReadOnly, ObjectType, Application)
        End Function
        ''' <summary>
        ''' Determines if an object's property should be readonly based on the current workflow.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="PropertyName"></param>
        ''' <returns></returns>
        ''' <remarks>The property must have a value in the current context to be readonly, otherwise it will not be.</remarks>
        Public Shared Function IsReadOnlyIfExists(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ObjectType As Type, ByVal application As XafApplication) As System.Nullable(Of Boolean)
            Return GetWorkflowControlAttributeTypeValue(WorkflowObject, PropertyName, ControlAttributeTypes.ReadonlyIfExists, ObjectType, application)
        End Function
        ''' <summary>
        ''' Determines if the passed in property is a workflow step.
        ''' </summary>
        ''' <param name="ObjectType"></param>
        ''' <param name="PropertyName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsPropertyNameWorkflowStep(ByVal ObjectType As System.Type, ByVal PropertyName As String) As Boolean
            Return (ObjectType.GetProperty(PropertyName).PropertyType Is GetType(ISSBaseWorkflowStep))
        End Function

        Public Shared Function IsPropertyInWorkflowCriteria(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal Application As XafApplication) As Boolean
            Dim wfoWorkflow As IWorkflow
            Dim lstCriteraTemplates As New List(Of ISSBaseCriteriaTemplate)
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.TypeInfo
            Dim obcCustomization As ISSBaseBusinessRules
            Dim criCriteria As DevExpress.Data.Filtering.CriteriaOperator
            Dim intIndex As Integer = 0
            Dim strIsNullStatement As String
            If WorkflowObject Is Nothing Then
                Return False
            End If

            dtiTypeInfo = XafTypesInfo.Instance.FindTypeInfo(WorkflowObject.GetType)

            If dtiTypeInfo Is Nothing Then
                Return False
            End If

            If dtiTypeInfo.Implements(Of IWorkflow)() Then
                wfoWorkflow = WorkflowObject
                If wfoWorkflow.WorkflowStatus IsNot Nothing Then
                    lstCriteraTemplates.AddRange(wfoWorkflow.WorkflowStatus.CriteriaTemplates)
                Else
                    obcCustomization = GetObjectCustomizationFromCollection(WorkflowObject.GetType, Application)
                    If obcCustomization IsNot Nothing Then
                        lstCriteraTemplates.AddRange(obcCustomization.SaveValidationCriteriaTemplates)
                    End If
                End If
            End If

            If lstCriteraTemplates.Count = 0 Then
                Return False
            End If

            For Each crtCriteriaTemplate As ISSBaseCriteriaTemplate In lstCriteraTemplates
                If crtCriteriaTemplate.Criteria > String.Empty Then
                    If crtCriteriaTemplate.Criteria.Contains(String.Format("[{0}]", PropertyName)) Then
                        intIndex = crtCriteriaTemplate.Criteria.IndexOf(String.Format("[{0}]", PropertyName))
                        intIndex += PropertyName.Length + 2
                        If crtCriteriaTemplate.Criteria.Length >= intIndex + 9 Then
                            strIsNullStatement = crtCriteriaTemplate.Criteria.Substring(intIndex, 8)
                            If strIsNullStatement <> " Is Null" Then
                                Return True
                            End If
                        Else
                            Return True
                        End If
                    End If
                End If
            Next

        End Function

        Private Shared _mObjectCustomizationCollection As XPCollection(Of ISSBaseBusinessRules)

        Private Shared _mKeyedList As New Dictionary(Of String, BusinessRuleCache)

        Public Shared Sub ClearWorkflowDefinitionCache()
            _mKeyedList = New Dictionary(Of String, BusinessRuleCache)
        End Sub

        Public Class BusinessRuleCache
            Private _mBusinessRule As ISSBaseBusinessRules
            Public Property BusinessRule() As ISSBaseBusinessRules
                Get
                    Return _mBusinessRule
                End Get
                Set(ByVal Value As ISSBaseBusinessRules)
                    _mBusinessRule = Value
                End Set
            End Property
            Public Sub New(ByVal BRule As ISSBaseBusinessRules)
                Me.BusinessRule = BRule
            End Sub
        End Class

        ''' <summary>
        ''' Loads all object customization definitions and returns back the object customization for the passed in type.
        ''' </summary>
        ''' <param name="ObjectType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetObjectCustomizationFromCollection(ByVal ObjectType As Type, ByVal Application As XafApplication) As ISSBaseBusinessRules
            Dim obsSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace
            Dim objISSBaseBusinessRules As ISSBaseBusinessRules
            Dim brcCache As BusinessRuleCache
            'If _mObjectCustomizationCollection Is Nothing Then
            '    objSpace = ApplicationHelper.XAFApplication.CreateObjectSpace
            '    _mObjectCustomizationCollection = New XPCollection(Of ISSBaseBusinessRules)(objSpace.Session)
            'Else
            '    _mObjectCustomizationCollection.Reload()
            'End If
            If _mKeyedList.ContainsKey(ObjectType.FullName) Then
                If _mKeyedList(ObjectType.FullName) Is Nothing Then
                    obsSpace = Application.CreateObjectSpace
                    _mKeyedList(ObjectType.FullName) = New BusinessRuleCache(obsSpace.Session.FindObject(Of ISSBaseBusinessRules)(New BinaryOperator("SavedType", ObjectType.FullName)))
                End If
                Return _mKeyedList(ObjectType.FullName).BusinessRule
            Else
                obsSpace = Application.CreateObjectSpace
                objISSBaseBusinessRules = obsSpace.Session.FindObject(Of ISSBaseBusinessRules)(New BinaryOperator("SavedType", ObjectType.FullName))
                _mKeyedList.Add(ObjectType.FullName, New BusinessRuleCache(objISSBaseBusinessRules))
                Return objISSBaseBusinessRules
            End If


            'For intLoop As Integer = 0 To _mObjectCustomizationCollection.Count - 1
            '    If _mObjectCustomizationCollection(intLoop).ObjectType Is Nothing OrElse String.Compare(_mObjectCustomizationCollection(intLoop).ObjectType.FullName, ObjectType.FullName, False) <> 0 Then
            '        Continue For
            '    End If

            '    _mObjectCustomizationCollection(intLoop).Reload()
            '    Return _mObjectCustomizationCollection(intLoop)
            'Next
            'Return Nothing
        End Function
        ''' <summary>
        ''' Returns the object customization definition for the passed in object if it implements iworkflow and has a workflow status.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="TypeInfo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetObjectCustomizationFromWorkflowObject(ByVal WorkflowObject As Object, ByVal TypeInfo As DevExpress.ExpressApp.DC.TypeInfo) As ISSBaseBusinessRules
            Dim wfiInterface As IWorkflow = WorkflowObject
            If Not TypeInfo.Implements(Of IWorkflow)() Then
                Return Nothing
            End If
            If wfiInterface.WorkflowStatus Is Nothing OrElse wfiInterface.WorkflowStatus.ObjectCustomization Is Nothing Then
                Return Nothing
            End If

            'wfiInterface.WorkflowStatus.ObjectCustomization.Reload()
            Return wfiInterface.WorkflowStatus.ObjectCustomization
        End Function

        ''' <summary>
        ''' Checks the current workflow information for an object's property and returns back the passed in control attribute type value.
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <param name="PropertyName"></param>
        ''' <param name="ValueType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetWorkflowControlAttributeTypeValue(ByVal WorkflowObject As Object, ByVal PropertyName As String, ByVal ValueType As ControlAttributeTypes, ByVal ObjectType As Type, ByVal Application As XafApplication) As System.Nullable(Of Boolean)

            Dim objPropertyTemplate As ISSBaseEditorStateTemplate = GetEditorTemplate(WorkflowObject,PropertyName,ObjectType,Application)
            Dim estEditorStateType As ISSBaseEditorStateTemplate.EditorStateTypes
            If objPropertyTemplate IsNot Nothing Then
                If objPropertyTemplate.GetCriteriaValue(GetParentObject(WorkflowObject, PropertyName)) = True Then
                        estEditorStateType = objPropertyTemplate.TrueEditorStateType
                    Else
                        estEditorStateType = objPropertyTemplate.FalseEditorStateType
                    End If
                    If estEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Default Then
                        Return Nothing
                    End If
                    Select Case ValueType
                        Case ControlAttributeTypes.Enabled
                            If estEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Disabled Then
                                Return False
                            End If
                        Case ControlAttributeTypes.Visible
                            If estEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Hidden Then
                                Return False
                            End If
                        Case ControlAttributeTypes.Required
                            If estEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Bold Then
                                Return True
                            End If
                        Case ControlAttributeTypes.EnabledIfExists
                            If estEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.DisabledIfExists Then
                                Return True
                            End If
                        Case ControlAttributeTypes.ReadOnly
                            If estEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.ReadOnly Then
                                Return True
                            End If
                        Case ControlAttributeTypes.ReadonlyIfExists
                            If estEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.ReadOnlyIfExists Then
                                Return True
                            End If
                    End Select
            End If

            Return Nothing
            
        End Function

        Private Shared Function GetParentObject(ByVal DataObject As Object, ByVal PropertyName As String)
            If String.IsNullOrEmpty(PropertyName) Then
                Return DataObject
            End If
            If PropertyName.Contains(".") = False Then
                Return DataObject
            End If
            Return ReflectionHelper.GetObjectFromPropertyName(ReflectionHelper.GetParentProperty(PropertyName), DataObject)
        End Function
        

        ''' <summary>
        ''' Sets the default workflow step for the passed in object, if applicable
        ''' </summary>
        ''' <param name="WorkflowObject"></param>
        ''' <remarks></remarks>
        Public Shared Sub SetWorkflowStep(ByVal WorkflowObject As IWorkflow)
            If WorkflowObject.WorkflowStatus IsNot Nothing Then
                Return
            End If

            Dim objWorkflowDefinition As ISSBaseBusinessRules = CType(WorkflowObject, XPCustomObject).Session.FindObject(GetType(ISSBaseBusinessRules), New DevExpress.Data.Filtering.BinaryOperator("ObjectType", WorkflowObject.GetType, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            If objWorkflowDefinition Is Nothing OrElse objWorkflowDefinition.DefaultWorkflowStep Is Nothing Then
                Return
            End If

            WorkflowObject.WorkflowStatus = objWorkflowDefinition.DefaultWorkflowStep
        End Sub

        Public Shared Function GetCriteriaErrors(ByVal BaseTarget As Object, ByVal Application As XafApplication) As String
            Dim crtCriteriaTemplate As ISSBaseCriteriaTemplate = Nothing
            Dim ctoCriteriaOperator As DevExpress.Data.Filtering.CriteriaOperator
            Dim dxeExpressionEvaluator As ExpressionEvaluator
            Dim dcdDescriptorDefault As EvaluatorContextDescriptorDefault
            Dim strReturn As String = String.Empty
            Dim obcCustomization As ISSBaseBusinessRules = Nothing
            Dim dtiMasterType As DevExpress.ExpressApp.DC.TypeInfo = Nothing
            Dim lstRulesToApply As New List(Of ISSBaseCriteriaTemplate)
            Dim WorkflowObject As IWorkflow = Nothing
            If BaseTarget Is Nothing Then
                Return String.Empty
            End If

            dtiMasterType = XafTypesInfo.Instance.FindTypeInfo(BaseTarget.GetType)
            If dtiMasterType Is Nothing Then
                Return strReturn
            End If

            If GetType(IWorkflow).IsAssignableFrom(BaseTarget.GetType) = True Then
                WorkflowObject = BaseTarget
                If WorkflowObject IsNot Nothing AndAlso WorkflowObject.WorkflowStatus IsNot Nothing Then
                    WorkflowObject.WorkflowStatus.CriteriaTemplates.Reload()
                    lstRulesToApply.AddRange(WorkflowObject.WorkflowStatus.CriteriaTemplates)
                    obcCustomization = GetObjectCustomizationFromWorkflowObject(WorkflowObject, dtiMasterType)
                End If
            End If
            If BaseTarget IsNot Nothing Then
                If obcCustomization Is Nothing Then
                    obcCustomization = GetObjectCustomizationFromCollection(BaseTarget.GetType, Application)
                End If
                If obcCustomization Is Nothing Then
                    Return strReturn
                End If
                obcCustomization.SaveValidationCriteriaTemplates.Reload()
                lstRulesToApply.AddRange(obcCustomization.SaveValidationCriteriaTemplates)
            End If


            If lstRulesToApply.Count = 0 Then
                Return strReturn
            End If

            For Each crtCriteriaTemplate In lstRulesToApply
                ctoCriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse(crtCriteriaTemplate.Criteria)
                dcdDescriptorDefault = New EvaluatorContextDescriptorDefault(BaseTarget.GetType)
                dxeExpressionEvaluator = New ExpressionEvaluator(dcdDescriptorDefault, ctoCriteriaOperator)
                If dxeExpressionEvaluator.Fit(BaseTarget) <> False Then
                    Continue For
                End If

                If strReturn > String.Empty Then
                    strReturn = String.Format("{0}, ", strReturn)
                End If
                strReturn = If(crtCriteriaTemplate.ShowFilterInExceptionMessage = True, String.Format("{0}({1}): {2}", strReturn, crtCriteriaTemplate.Criteria, crtCriteriaTemplate.ExceptionMessage), String.Format("{0}{1}", strReturn, crtCriteriaTemplate.ExceptionMessage))
            Next

            Return strReturn
        End Function

        Public Shared Function GetWorkflowStepsForType(Byval ObjectType As Type, ByVal TargetSession As Session) As XpCollection(OF ISS.Workflow.ISSBaseWorkflowStep)
            Return New XPCollection(Of ISS.Workflow.ISSBaseWorkflowStep)(TargetSession, CriteriaOperator.Parse(String.Format("ObjectCustomization.SavedType = '{0}'", ObjectType.FullName)))
        End Function

    End Class
End Namespace
