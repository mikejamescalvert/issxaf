Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports ISS.Base
Imports ISS.Base.Attributes.View
Imports DevExpress.ExpressApp.Win.Templates
Imports DevExpress.ExpressApp.Win.Controls
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.SystemModule

Public Class NestedActionBarController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        'AddHandler Frame.TemplateChanged, AddressOf ActionBarController_ViewControlsCreated
        'ActionBarController_ViewControlsCreated(Me,New EventArgs)
    End Sub

     '
    Private Sub ActionBarController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        Dim atrShowActionBar As ShowActionBarAttribute = Nothing
        Dim lstListView As ListView = Nothing
        Dim pcsPropertyCollectionSource As PropertyCollectionSource = Nothing
        Dim imiMemberInfo As DC.IMemberInfo
        If TypeOf View Is ListView Then
            lstListView = View
            If TypeOf lstListView.CollectionSource Is PropertyCollectionSource Then
                pcsPropertyCollectionSource = lstListView.CollectionSource
                atrShowActionBar = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of ShowActionBarAttribute)()
                If pcsPropertyCollectionSource.MemberInfo IsNot Nothing Then
                    If atrShowActionBar Is Nothing Then
                        atrShowActionBar = lstListView.ObjectTypeInfo.FindAttribute(Of ShowActionBarAttribute)()
                    End If
                End If
            Else
                atrShowActionBar = lstListView.ObjectTypeInfo.FindAttribute(Of ShowActionBarAttribute)()
            End If
        ElseIf TypeOf View Is DetailView Then


            For Each dpeDetailEditor As DetailPropertyEditor In CType(View, DetailView).GetItems(Of DetailPropertyEditor)()
                imiMemberInfo = View.ObjectTypeInfo.FindMember(dpeDetailEditor.PropertyName)
                If imiMemberInfo IsNot Nothing Then
                    atrShowActionBar = imiMemberInfo.FindAttribute(Of ShowActionBarAttribute)()
                    If atrShowActionBar IsNot Nothing Then
                        If dpeDetailEditor.Frame Is Nothing Then
                            RemoveHandler dpeDetailEditor.ControlCreated, AddressOf DetailEditor_ControlCreated
                            AddHandler dpeDetailEditor.ControlCreated, AddressOf DetailEditor_ControlCreated
                        Else
                            SetToolBarVisibility(atrShowActionBar.IsVisible, dpeDetailEditor.Frame)
                        End If

                    End If
                End If
            Next
            atrShowActionBar = View.ObjectTypeInfo.FindAttribute(Of ShowActionBarAttribute)()
            'todo; search for parent view
        End If
        If atrShowActionBar IsNot Nothing Then
            SetToolBarVisibility(atrShowActionBar.IsVisible)
        End If
    End Sub

    Public Sub DetailEditor_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
        Dim dpeDetailEditor As DetailPropertyEditor = sender
        Dim atrShowActionBar As ShowActionBarAttribute = Nothing
        Dim imiMemberInfo As DC.IMemberInfo
        imiMemberInfo = View.ObjectTypeInfo.FindMember(dpeDetailEditor.PropertyName)
        If imiMemberInfo IsNot Nothing Then
            atrShowActionBar = imiMemberInfo.FindAttribute(Of ShowActionBarAttribute)()
            If atrShowActionBar IsNot Nothing Then
                SetToolBarVisibility(atrShowActionBar.IsVisible, dpeDetailEditor.Frame)
            End If
        End If
    End Sub

    Private Sub SetControllersActive(ByVal Reason As String, ByVal IsEnabled As Boolean)
        For Each oController As Controller In Me.Frame.Controllers
            oController.Active.SetItemValue(Reason, IsEnabled)
        Next
    End Sub

    Public Shared Sub SetToolBarVisibility(ByVal IsVisible As Boolean, ByVal ViewFrame As Frame)
        If ViewFrame Is Nothing Then
            Return
        End If

        Dim isaActions As ISupportActionsToolbarVisibility


        If ViewFrame.Template IsNot Nothing Then
            isaActions = TryCast(ViewFrame.Template,ISupportActionsToolbarVisibility)
            If isaActions IsNot Nothing Then
                isaActions.SetVisible(IsVisible)    
            End If
            
        End If

        
        'If ViewFrame.Template Is Nothing Then
        '    Return
        'End If
        'For Each actContainer As DevExpress.ExpressApp.Win.Templates.ActionContainers.XafBarLinkContainerItem In ViewFrame.Template.GetContainers
        '    CType(actContainer,DevExpress.ExpressApp.Win.Templates.ActionContainers.XafBarLinkContainerItem).Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        'Next
        
        
        '  ActionContainerHolder containerHolder = ((Control) Frame.Template).FindNestedControls<ActionContainerHolder>("ToolBar").SingleOrDefault();
        '        if (containerHolder != null)
        '            containerHolder.Visible = !((IModelViewHideViewToolBar) View.Model).HideToolBar.Value;

        'Dim tvcVisibilityController As ToolbarVisibilityController = ViewFrame.GetController(Of ToolbarVisibilityController)

        'If tvcVisibilityController isnot Nothing Then
        '    tvcVisibilityController.ShowToolbarAction.DoExecute()
        '    'tvcVisibilityController.SetToolbarVisibility(IsVisible)
        'End If
        ''    ctrl.SetToolbarVisibility(true);
        'If typeof ViewFrame.Template is ISupportActionsToolbarVisibility Then
        '    CType(ViewFrame.Template,ISupportActionsToolbarVisibility).SetVisible    
        'End If
        'If IsVisible = True Then
        '    CType(ViewFrame.Template, ISupportActionsToolbarVisibility).SetVisible(True)
        'Else
        '    CType(ViewFrame.Template, ISupportActionsToolbarVisibility).SetVisible(False)
        'End If
    End Sub

    Public Sub SetToolBarVisibility(ByVal IsVisible As Boolean)
        SetToolBarVisibility(IsVisible, Frame)
        'If Frame Is Nothing Then
        '    Return
        'End If

        'If Frame.Template Is Nothing Then
        '    Return
        'End If
        'If IsVisible = True Then
        '    CType(Me.Frame.Template, ISupportActionsToolbarVisibility).ActionsToolbarVisibility = ActionsToolbarVisibility.Show
        'Else
        '    CType(Me.Frame.Template, ISupportActionsToolbarVisibility).ActionsToolbarVisibility = ActionsToolbarVisibility.Hide
        'End If



        'Dim nftNestedTemplate As IBarManagerHolder = TryCast(Frame.Template, IBarManagerHolder)
        'If nftNestedTemplate IsNot Nothing Then
        '    For Each oBar In nftNestedTemplate.BarManager.Bars
        '        If oBar.BarName.Contains("Toolbar") = True Then
        '            oBar.Visible = IsVisible
        '        End If
        '    Next
        'End If

    End Sub

End Class
