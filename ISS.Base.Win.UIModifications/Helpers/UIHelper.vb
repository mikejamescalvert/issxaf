Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.XtraBars
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp.Win.Templates.ActionContainers
Imports DevExpress.ExpressApp.Win.Templates.Ribbon
Imports DevExpress.ExpressApp.Templates.ActionControls
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.ExpressApp.Win.Templates.Bars
Imports DevExpress.ExpressApp.Win.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.Win.Templates.Bars.ActionControls

Public Class UIHelper

    Public Shared Sub CustomizeRibbonTemplateForm(ByVal MainApplication As XafApplication, ByVal FormTemplate As RibbonForm)

        'Dim stbStandardToolBar As Bar = FormTemplate.Ribbon.pages.Bars("Main Toolbar")
        Dim acbBarItem As DevExpress.ExpressApp.Win.Templates.Ribbon.ActionControls.RibbonGroupActionControlContainer
        Dim rsc As System.ComponentModel.ComponentResourceManager = New XafComponentResourceManager(GetType(MainForm))
        Dim xfrRibbonControl As XafRibbonControlV2 = FormTemplate.Ribbon
        Dim lstBarsToShow As New List(Of String)
        xfrRibbonControl.BeginInit()
        For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
            'If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
            If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < 0 Then
                Continue For
            End If

            lstBarsToShow.Add(mcmMapping.Id)

        Next

        For Each cnt In xfrRibbonControl.ActionContainers
            If lstBarsToShow.Contains(cnt.ActionCategory) OrElse cnt.ActionCategory = "PopupActions" Then
                lstBarsToShow.Remove(cnt.ActionCategory)
            End If


        Next


        'For Each pst As LinkPersistInfo In FormTemplate.BarManager.Bars("Main Toolbar").LinksPersistInfo
        '    acbItemContainer = TryCast(pst.Item, ActionContainerBarItem)
        '    If acbItemContainer IsNot Nothing Then
        '        lstBarsToShow.Remove(acbItemContainer.ContainerId)
        '    End If

        'Next




        For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
            'If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
            If mcmMapping.Index.HasValue = False OrElse mcmMapping.Index.Value < 0 Then
                Continue For
            End If

            If mcmMapping.Id = "PopupActions" Then
                Continue For
            End If

            If lstBarsToShow.Contains(mcmMapping.Id) Then
                acbBarItem = GetRibbonActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
                '                xfrRibbonControl.ActionContainers.Add(acbBarItem)
                'FormTemplate.RegisterActionContainers({acbBarItem})
                'FormTemplate.ActionContainersManager.ActionContainerComponents.Add(acbBarItem)
                acbBarItem.RibbonGroup = New ActionContainersRibbonPageGroup(DevExpress.ExpressApp.Utils.CaptionHelper.ConvertCompoundName(mcmMapping.Id))
                'rbgGroup = New ActionContainersRibbonPageGroup(DevExpress.ExpressApp.Utils.CaptionHelper.ConvertCompoundName(mcmMapping.Id))
                If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < xfrRibbonControl.ActionContainers.Count - 1 Then
                    xfrRibbonControl.ActionContainers.Insert(mcmMapping.Index.Value, acbBarItem)
                    xfrRibbonControl.Pages(0).Groups.Insert(mcmMapping.Index.Value, acbBarItem.RibbonGroup)
                Else
                    xfrRibbonControl.ActionContainers.Add(acbBarItem)
                    xfrRibbonControl.Pages(0).Groups.Add(acbBarItem.RibbonGroup)
                End If





                acbBarItem.EndInit()
                'stbStandardToolBar.AddItem(acbBarItem)
                'stbStandardToolBar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))
                'rsc.ApplyResources(acbBarItem, acbBarItem.Name)


            End If

            'If IsActionContainerPresent(mcmMapping.Id, FormTemplate.BarManager) = False Then
            '    If mcmMapping.Index.HasValue = True Then
            '        acbBarItem = GetActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
            '    Else
            '        acbBarItem = GetActionContainerBarItem(mcmMapping.Id, 9999)
            '    End If

            '    FormTemplate.ActionContainersManager.ActionContainerComponents.Add(acbBarItem)
            '    If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < FormTemplate.BarManager.Items.Count - 1 Then
            '        FormTemplate.BarManager.Items.Insert(mcmMapping.Index.Value, acbBarItem)
            '    Else
            '        FormTemplate.BarManager.Items.Add(acbBarItem)
            '    End If

            '    stbStandardToolBar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))
            'Else
            '    If mcmMapping.Index.HasValue = True Then
            '        EnforceIndex(mcmMapping.Id, FormTemplate.BarManager, mcmMapping.Index)
            '    Else
            '        EnforceIndex(mcmMapping.Id, FormTemplate.BarManager, 0)
            '    End If

            'End If

            'End If
        Next
        xfrRibbonControl.EndInit()
    End Sub

    Public Shared Sub CustomizeTemplateForm(ByVal MainApplication As XafApplication, ByVal FormTemplate As DevExpress.ExpressApp.Win.Templates.XtraFormTemplateBase)
        Dim stbStandardToolBar As Bar = FormTemplate.BarManager.Bars("Main Toolbar")
        Dim acbBarItem As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Dim acbItemContainer As ActionContainerBarItem
        Dim rsc As System.ComponentModel.ComponentResourceManager = New XafComponentResourceManager(GetType(MainForm))

        Dim lstBarsToShow As New List(Of String)

        For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
            'If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
            If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < 0 Then
                Continue For
            End If

            lstBarsToShow.Add(mcmMapping.Id)

        Next

        For Each pst As LinkPersistInfo In FormTemplate.BarManager.Bars("Main Toolbar").LinksPersistInfo
            acbItemContainer = TryCast(pst.Item, ActionContainerBarItem)
            If acbItemContainer IsNot Nothing Then
                lstBarsToShow.Remove(acbItemContainer.ContainerId)
            End If

        Next




        'Dim bsivView As MainMenuItem = Nothing
        'For Each lpi As LinkPersistInfo In FormTemplate.BarManager.Bars("Main Menu").LinksPersistInfo
        '    If lpi.Link IsNot Nothing AndAlso lpi.Link.Item IsNot Nothing AndAlso lpi.Link.Item.Name = "barSubItemFile" Then
        '        bsivView = lpi.Link.Item
        '    End If

        'Next

        For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
            'If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
            If mcmMapping.Index.HasValue = False OrElse mcmMapping.Index.Value < 0 Then
                Continue For
            End If

            If lstBarsToShow.Contains(mcmMapping.Id) Then
                acbBarItem = GetActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
                FormTemplate.RegisterActionContainers({acbBarItem})
                FormTemplate.ActionContainersManager.ActionContainerComponents.Add(acbBarItem)

                If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < FormTemplate.BarManager.Items.Count - 1 Then
                    FormTemplate.BarManager.Items.Insert(mcmMapping.Index.Value, acbBarItem)
                Else
                    FormTemplate.BarManager.Items.Add(acbBarItem)
                End If

                stbStandardToolBar.AddItem(acbBarItem)
                stbStandardToolBar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))
                rsc.ApplyResources(acbBarItem, acbBarItem.Name)


            End If
        Next

    End Sub


    Public Shared Sub CustomizeTemplateForm(ByVal MainApplication As XafApplication, ByVal FormTemplate As XtraForm)
        Dim stbStandardToolBar As Bar = CType(FormTemplate, IBarManagerHolder).BarManager.Bars("Main Toolbar")
        Dim acbBarItem As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Dim rsc As System.ComponentModel.ComponentResourceManager = New XafComponentResourceManager(GetType(MainForm))

        Dim lstBarsToShow As New List(Of String)

        For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
            'If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
            If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < 0 Then
                Continue For
            End If

            lstBarsToShow.Add(mcmMapping.Id)

        Next

        Dim actionControlsSite As IActionControlsSite = TryCast(FormTemplate, IActionControlsSite)
        Dim barManagerHolder As IBarManagerHolder = TryCast(FormTemplate, IBarManagerHolder)

        If (FormTemplate IsNot Nothing) AndAlso (actionControlsSite IsNot Nothing) AndAlso (barManagerHolder IsNot Nothing) Then
            Dim barManager As XafBarManagerV2 = CType(barManagerHolder.BarManager, XafBarManagerV2)
            barManager.BeginInit()
            'Dim barContainerCustom As New BarLinkContainerExItem()
            'barContainerCustom.MergeType = BarMenuMerge.MergeItems






            For Each act In barManager.ActionContainers
                If lstBarsToShow.Contains(act.ActionCategory) Then
                    lstBarsToShow.Remove(act.ActionCategory)
                End If
            Next

            Dim actionContainerCustom As BarLinkActionControlContainer



            For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
                'If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
                If mcmMapping.Index.HasValue = False OrElse mcmMapping.Index.Value < 0 Then
                    Continue For
                End If

                If lstBarsToShow.Contains(mcmMapping.Id) Then

                    acbBarItem = GetActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
                    'barManager.Bars("Main Toolbar").AddItem(acbBarItem)

                    actionContainerCustom = New BarLinkActionControlContainer()
                    actionContainerCustom.BeginInit()

                    actionContainerCustom.BarContainerItem = acbBarItem
                    actionContainerCustom.ActionCategory = mcmMapping.Id

                    'barManager.ActionContainers.Add(actionContainerCustom)

                    If mcmMapping.Index.Value < barManager.Bars("Main Toolbar").ItemLinks.Count - 1 Then
                        barManager.Bars("Main Toolbar").InsertItem(barManager.Bars("Main Toolbar").ItemLinks(mcmMapping.Index.Value - 1), acbBarItem)
                    Else
                        barManager.Bars("Main Toolbar").AddItem(acbBarItem)
                    End If

                    If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < barManager.ActionContainers.Count - 1 Then
                        barManager.ActionContainers.Insert(mcmMapping.Index.Value, actionContainerCustom)
                    Else
                        barManager.ActionContainers.Add(actionContainerCustom)
                    End If

                    'barManager.Bars("Main Toolbar").LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))


                    actionContainerCustom.EndInit()

                End If
            Next

            barManager.EndInit()
        End If






        'Dim bsivView As MainMenuItem = Nothing
        'For Each lpi As LinkPersistInfo In CType(FormTemplate, IBarManagerHolder).BarManager.Bars("Main Menu").LinksPersistInfo
        '    If lpi.Link IsNot Nothing AndAlso lpi.Link.Item IsNot Nothing AndAlso lpi.Link.Item.Name = "barSubItemFile" Then
        '        bsivView = lpi.Link.Item
        '    End If

        ''Next

        'For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
        '    'If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
        '    If mcmMapping.Index.HasValue = False OrElse mcmMapping.Index.Value < 0 Then
        '        Continue For
        '    End If

        '    If lstBarsToShow.Contains(mcmMapping.Id) Then
        '        acbBarItem = GetActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
        '        CType(CType(FormTemplate, IBarManagerHolder).BarManager, XafBarManagerV2).ActionContainers.Add(GetActionControlContainer(mcmMapping.Id, mcmMapping.Index.Value))


        '        If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value < CType(FormTemplate, IBarManagerHolder).BarManager.Items.Count - 1 Then
        '            CType(FormTemplate, IBarManagerHolder).BarManager.Items.Insert(mcmMapping.Index.Value, acbBarItem)
        '        Else
        '            CType(FormTemplate, IBarManagerHolder).BarManager.Items.Add(acbBarItem)
        '        End If

        '        stbStandardToolBar.AddItem(acbBarItem)
        '        stbStandardToolBar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))
        '        rsc.ApplyResources(acbBarItem, acbBarItem.Name)


        '    End If
        'Next

    End Sub

    Public Shared Sub CustomizeNestedTemplate(ByVal MainApplication As XafApplication, ByVal NestedTemplate As ISS.Base.Win.UIModifications.NestedFrameTemplate)
        Dim stbStandardToolBar As Bar = NestedTemplate.BarManager.Bars("ListView Toolbar")
        Dim acbBarItem As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
            If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
                If IsActionContainerPresent(mcmMapping.Id, NestedTemplate.BarManager) = False Then
                    acbBarItem = GetActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
                    NestedTemplate.ActionContainersManager.ActionContainerComponents.Add(acbBarItem)
                    If mcmMapping.Index.Value < NestedTemplate.BarManager.Items.Count - 1 Then
                        NestedTemplate.BarManager.Items.Insert(mcmMapping.Index.Value, acbBarItem)
                    Else
                        NestedTemplate.BarManager.Items.Add(acbBarItem)
                    End If

                    stbStandardToolBar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))
                End If

            End If
        Next
    End Sub

    Public Shared Sub CustomizeMainFormTemplate(ByVal MainApplication As XafApplication, ByVal MainTemplate As DevExpress.ExpressApp.Win.Templates.MainForm)
        Dim stbStandardToolBar As Bar = MainTemplate.BarManager.Bars("Main Toolbar")
        Dim bsiBarSubItem As DevExpress.ExpressApp.Win.Templates.MainMenuItem
        Dim acbBarItem As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        For Each mcmMapping As IModelActionContainer In CType(MainApplication.Model.ActionDesign.GetNode("ActionToContainerMapping"), IModelActionToContainerMapping)
            If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
                If IsActionContainerPresent(mcmMapping.Id, MainTemplate.BarManager) = False Then
                    acbBarItem = GetActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
                    MainTemplate.ActionContainersManager.ActionContainerComponents.Add(acbBarItem)
                    MainTemplate.BarManager.Items.Insert(mcmMapping.Index.Value, acbBarItem)
                    stbStandardToolBar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))
                End If

            End If
        Next
    End Sub

    Public Shared Function EnforceIndex(ByVal ActionId As String, ByVal MainBarManager As BarManager, ByVal Index As Integer)
        Dim bbiBarItem As BarItem
        Dim iacActionContainer As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        For Each bbiBarItem In MainBarManager.Items
            If TypeOf bbiBarItem Is DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem Then
                iacActionContainer = bbiBarItem
                If iacActionContainer.ContainerId = ActionId Then
                    iacActionContainer.ApplicationMenuIndex = Index
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Public Shared Function IsActionContainerPresent(ByVal ActionId As String, ByVal MainBarManager As BarManager)
        Dim bbiBarItem As BarItem
        Dim iacActionContainer As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        For Each bbiBarItem In MainBarManager.Items
            If TypeOf bbiBarItem Is DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem Then
                iacActionContainer = bbiBarItem
                If iacActionContainer.ContainerId = ActionId Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    'Public Shared Sub CustomizeDetailFormTemplate(ByVal MainApplication As XafApplication, ByVal DetailTemplate As DevExpress.ExpressApp.Win.Templates.DetailViewForm)
    '    Dim stbStandardToolBar As Bar = DetailTemplate.BarManager.Bars("Main Toolbar")
    '    Dim acbBarItem As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
    '    For Each mcmMapping As IModelActionContainer In MainApplication.Model.ActionDesign.GetNode(Of IModelActionToContainerMapping)("ActionToContainerMapping")
    '        If mcmMapping.Index.HasValue = True AndAlso mcmMapping.Index.Value >= 0 Then
    '            If IsActionContainerPresent(mcmMapping.Id, DetailTemplate.BarManager) = False Then
    '                acbBarItem = GetActionContainerBarItem(mcmMapping.Id, mcmMapping.Index.Value)
    '                DetailTemplate.ActionContainersManager.ActionContainerComponents.Add(acbBarItem)
    '                DetailTemplate.BarManager.Items.Insert(mcmMapping.Index.Value, acbBarItem)
    '                stbStandardToolBar.LinksPersistInfo.Add(New DevExpress.XtraBars.LinkPersistInfo(acbBarItem, True))
    '            End If

    '        End If
    '    Next
    'End Sub

    Public Shared Function GetActionContainerBarItem(ByVal theCategory As String, ByVal theIndex As Integer) As DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        Dim abiActionItem As New DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionContainerBarItem
        With abiActionItem
            .ApplicationMenuItem = True
            .ApplicationMenuIndex = theIndex
            .ContainerId = theCategory
            .MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            .Name = "c" + theCategory
            .TargetPageCategoryColor = System.Drawing.Color.Empty
            .TargetPageGroupCaption = Nothing
            '.Description = theCategory
            .Caption = DevExpress.ExpressApp.Utils.CaptionHelper.ConvertCompoundName(theCategory)
        End With

        Return abiActionItem
    End Function


    Public Shared Function GetActionControlContainer(ByVal theCategory As String, ByVal theIndex As Integer) As DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
        Dim abiActionItem As New DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer
        abiActionItem.BeginInit()

        With abiActionItem
            .ActionCategory = theCategory
            .BarContainerItem = New BarLinkContainerItem()
            With .BarContainerItem
                .Id = theIndex
                .MergeOrder = 2
                .MergeType = BarMenuMerge.MergeItems
                .Name = theCategory
            End With

        End With
        abiActionItem.EndInit()
        Return abiActionItem
    End Function



    Public Shared Function GetRibbonActionContainerBarItem(ByVal theCategory As String, ByVal theIndex As Integer) As DevExpress.ExpressApp.Win.Templates.Ribbon.ActionControls.RibbonGroupActionControlContainer
        Dim abiActionItem As New DevExpress.ExpressApp.Win.Templates.Ribbon.ActionControls.RibbonGroupActionControlContainer
        With abiActionItem
            .BeginInit()
            .ActionCategory = theCategory
            .IsMenuMode = True
            '.ApplicationMenuItem = True
            '.ApplicationMenuIndex = theIndex
            '.ContainerId = theCategory
            '.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems
            '.Name = "c" + theCategory
            '.TargetPageCategoryColor = System.Drawing.Color.Empty
            '.TargetPageGroupCaption = Nothing
            '.Description = theCategory

            '.Caption = DevExpress.ExpressApp.Utils.CaptionHelper.ConvertCompoundName(theCategory)
        End With
        'abiActionItem.EndInit()
        Return abiActionItem
    End Function

End Class
