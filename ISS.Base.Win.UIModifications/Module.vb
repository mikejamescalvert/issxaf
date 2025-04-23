Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win.Templates.Ribbon
Imports DevExpress.ExpressApp.Win.Templates.Bars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Ribbon

Public NotInheritable Class [UIModificationsModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub Setup(ByVal application As DevExpress.ExpressApp.XafApplication)
        MyBase.Setup(application)
        AddHandler application.CreateCustomTemplate, AddressOf Application_CreateCustomTemplate
        AddHandler application.CustomizeTemplate, AddressOf Application_CustomizeTemplate
    End Sub

    Public Sub Application_CreateCustomTemplate(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.CreateCustomTemplateEventArgs)
        If e.Context = DevExpress.ExpressApp.TemplateContext.NestedFrame Then
            e.Template = New ISS.Base.Win.UIModifications.NestedFrameTemplate
        End If
    End Sub

    Public Sub Application_CustomizeTemplate(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.CustomizeTemplateEventArgs)
        Dim lstBlockedContexts As New List(Of DevExpress.ExpressApp.TemplateContext)
        Dim frm As XtraForm = TryCast(e.Template, XtraForm)
        Dim rbf As RibbonForm = TryCast(e.Template, RibbonForm)
        lstBlockedContexts.Add(DevExpress.ExpressApp.TemplateContext.LookupWindow)
        lstBlockedContexts.Add(DevExpress.ExpressApp.TemplateContext.LookupControl)
        If lstBlockedContexts.Contains(e.Context) Then
            Return
        End If

        'If frm IsNot Nothing Then
        '    UIHelper.CustomizeTemplateForm(Application, frm)
        'Else
        If rbf IsNot Nothing Then
            UIHelper.CustomizeRibbonTemplateForm(Application, rbf)

        ElseIf TypeOf e.Template Is ISS.Base.Win.UIModifications.NestedFrameTemplate Then
            UIHelper.CustomizeNestedTemplate(Application, e.Template)
        ElseIf frm IsNot Nothing Then
            UIHelper.CustomizeTemplateForm(Application, frm)
        End If
        'End If

    End Sub


End Class
