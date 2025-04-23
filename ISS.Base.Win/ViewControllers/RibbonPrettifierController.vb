Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp.Win.Templates.ActionContainers
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.Win

Public Class RibbonPrettifierController
    Inherits DevExpress.ExpressApp.WindowController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)


    End Sub


    Protected Overrides Sub OnFrameAssigned()
        MyBase.OnFrameAssigned()
        AddHandler Frame.TemplateChanged, AddressOf UpdateTransformer
    End Sub
    Public Sub UpdateTransformer()
        If TypeOf Frame.Template Is XtraFormTemplateBase AndAlso TypeOf Frame.Template Is ISupportClassicToRibbonTransform Then
            CType(Frame.Template, XtraFormTemplateBase).RibbonTransformer = New CustomRibbonTransformer(Frame.Template, Application)

        End If
    End Sub

    Public Sub MergeRibbon(ByVal theRibbon As RibbonControl)
        If TypeOf CType(Frame.Template, XtraFormTemplateBase).RibbonTransformer Is CustomRibbonTransformer Then
            CType(CType(Frame.Template, XtraFormTemplateBase).RibbonTransformer, CustomRibbonTransformer).MergeRibbon(theRibbon)
        End If
    End Sub

    Public Class CustomRibbonTransformer
        Inherits ClassicToRibbonTransformer

        'Post setup, iterate through actions and assign appropriate page/indexes

        Protected Overrides Sub TransformMainMenu(mainMenuBar As DevExpress.XtraBars.Bar)
            MyBase.TransformMainMenu(mainMenuBar)
            Dim objCat As Object
            Dim factory As BarActionItemsFactory = BarActionItemsFactoryProvider.GetBarActionItemsFactory(Ribbon.Manager)
            If factory IsNot Nothing Then
                For Each actionItem In factory.ActionItems
                    objCat = actionItem.Action.Model.GetNode(actionItem.Action.Category)
                    'hit um

                Next
            End If

        End Sub

        Public XafApplication As XafApplication

        Public Sub New(ByVal form As DevExpress.XtraEditors.XtraForm, ByVal App As XafApplication)
            MyBase.New(form)
            XafApplication = App
        End Sub

        Protected Overrides Sub AddToContainer(ribbon As RibbonControl, component As IComponent)
            MyBase.AddToContainer(ribbon, component)
        End Sub


        Protected Overrides Sub AddBarLinkContainerToPageAsPageGroup(targetPage As DevExpress.XtraBars.Ribbon.RibbonPage, barLinkContainer As DevExpress.ExpressApp.Win.Templates.ActionContainers.XafBarLinkContainerItem)
            'Stop

            'todo: set page caption for containers


            Dim abiBarItem As ActionContainerBarItem

            If TypeOf barLinkContainer Is DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem Then
                abiBarItem = barLinkContainer


                'If abiBarItem.ApplicationMenuIndex = 0 Then
                If barLinkContainer.Caption = "View" Or barLinkContainer.Caption = "Edit" Then
                    If barLinkContainer.Caption = "Edit" Then
                        abiBarItem.ApplicationMenuIndex = 999
                    Else
                        abiBarItem.ApplicationMenuIndex = 0
                    End If
                    barLinkContainer.TargetPageGroupCaption = "Actions"
                    'End If

                End If
            End If

            MyBase.AddBarLinkContainerToPageAsPageGroup(targetPage, barLinkContainer)

        End Sub



        Public Sub MergeRibbon(ByVal theRibbon As RibbonControl)
            If Ribbon IsNot Nothing Then
                Me.Ribbon.MergeRibbon(theRibbon)
            End If

        End Sub

    End Class

End Class
