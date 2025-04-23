Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Validation
Imports DevExpress.Persistent.Validation
Imports ISS.Workflow.Rules
Imports DevExpress.Data.Filtering

Public NotInheritable Class WorkflowModule
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub AddAdditionalRuleSources(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Validation.CustomizeApplicationRuntimeRulesEventArgs)
        If DesignMode = False Then
            e.ApplicationModelRuleSet.RegisteredSources.Add(New CustomRuleSource)
            e.RuleSources.Add(New CustomRuleSource)
        End If
    End Sub
    Private Sub InjectIntoValidation(ByVal sender As Object, ByVal e As EventArgs)
        Dim xafApplication As DevExpress.ExpressApp.XafApplication = sender
        Dim vldModule As DevExpress.ExpressApp.Validation.ValidationModule
        For Each oModule As ModuleBase In xafApplication.Modules
            If oModule.GetType Is GetType(DevExpress.ExpressApp.Validation.ValidationModule) Then
                vldModule = oModule
                AddHandler vldModule.CustomizeApplicationRuntimeRules, AddressOf AddAdditionalRuleSources
            End If
        Next
    End Sub
    Public Overrides Sub Setup(ByVal moduleManager As DevExpress.ExpressApp.ApplicationModulesManager)
        If DesignMode = False AndAlso Application IsNot Nothing Then
            AddHandler Application.SetupComplete, AddressOf InjectIntoValidation
            AddHandler Application.DetailViewCreating, AddressOf Application_ViewOverride

        End If
        MyBase.Setup(moduleManager)
        'If DesignMode = False Then
            DevExpress.ExpressApp.Validation.ValidationRulesRegistrator.RegisterRule(moduleManager, GetType(CriteriaRule), GetType(IRuleBaseProperties))
            DevExpress.ExpressApp.Validation.ValidationRulesRegistrator.RegisterRule(moduleManager, GetType(CustomWorkflowRule), GetType(IRuleBaseProperties))
            DevExpress.ExpressApp.Validation.ValidationRulesRegistrator.RegisterRule(moduleManager, GetType(WorkflowRule), GetType(IRuleBaseProperties))
        'End If

    End Sub

    Private Sub Application_ViewOverride(sender As Object, e As DetailViewCreatingEventArgs)
        Dim xpoRule As ISSBaseBusinessRules
        Dim typType As Type
        Dim lstFoundConditionlView As New List(Of ISSBaseConditionalView)
        If e.Obj Is Nothing
            Return
        End If
        typType = e.Obj.GetType
        If e.ObjectSpace Is Nothing OrElse TypeOf e.ObjectSpace Is NonPersistentObjectSpace Then
            Return
        End If
        xpoRule = e.ObjectSpace.FindObject(Of ISSBaseBusinessRules)(New BinaryOperator("SavedType", typType.FullName))
        If xpoRule IsNot Nothing
            For each xpoConditions In xpoRule.ISSBaseConditionalViews
                If xpoConditions.IsValidObject(e.Obj)
                    lstFoundConditionlView.Add(xpoConditions)
                End If
            Next
            If lstFoundConditionlView.Count > 1 Then
                Throw New Exception("Multiple conditional views found for single object!")
            ElseIf lstFoundConditionlView.Count = 1 AndAlso lstFoundConditionlView(0).ViewId > String.Empty
                e.ViewID = lstFoundConditionlView(0).ViewId
            ElseIf xpoRule.DefaultViewIdOverride > String.Empty
                e.ViewID = xpoRule.DefaultViewIdOverride
            End If
        End If
        
        
    End Sub
End Class
