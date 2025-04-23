Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Win.Templates.Ribbon
Imports System.Windows.Forms
Imports DevExpress.ExpressApp.Win.Templates.Navigation
Imports DevExpress.XtraNavBar.ViewInfo
Imports System.Reflection
Imports DevExpress.XtraNavBar

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
Partial Public Class NavigationModificationsController
    Inherits WindowController
    Public Sub New()
        InitializeComponent()
        ' Target required Windows (via the TargetXXX properties) and create their Actions.
        TargetWindowType = WindowType.Main
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target Window.

    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub
    Protected Overrides Sub SubscribeToViewEvents(view As DevExpress.ExpressApp.View)
        MyBase.SubscribeToViewEvents(view)
        SetupFrame()
        AddHandler view.ControlsCreated, AddressOf SetupFrame
    End Sub
    Private Sub NavigationModificationsController_FrameAssigned(sender As Object, e As EventArgs) Handles Me.FrameAssigned

        If Frame IsNot Nothing Then
            AddHandler Frame.TemplateChanged, AddressOf Frame_TemplateChanged
        End If
    End Sub
    Public ReadOnly Property ApplicationModelExtension As IModelExtension
        Get
            If Application IsNot Nothing Then
                Return TryCast(Application.Model, IModelExtension)
            End If
            Return Nothing
        End Get
    End Property
    Public Sub SetupFrame()

        If Frame Is Nothing Then
            Return
        End If
        If ApplicationModelExtension Is Nothing OrElse ApplicationModelExtension.ISSApplicationOptions.HideNavBarGroupSelections = False Then
            Return
        End If
        Dim ftfForm As Form = TryCast(Frame.Template, LightStyleMainRibbonForm)
        Dim spcSidePanel As Control
        Dim xnbNavBarControl As XafNavBarControl
        If ftfForm IsNot Nothing Then
            spcSidePanel = ftfForm.Controls.Item("sidePanel")
            If spcSidePanel IsNot Nothing Then
                xnbNavBarControl = spcSidePanel.Controls(0)
                If xnbNavBarControl IsNot Nothing Then

                    xnbNavBarControl.HideGroupCaptions = True
                    xnbNavBarControl.ExplorerBarShowGroupButtons = False
                    xnbNavBarControl.NavigationPaneMaxVisibleGroups = 0
                    'grpPainter = GetGroupPainter(xnbNavBarControl)
                    xnbNavBarControl.OptionsNavPane.ShowOverflowPanel = False

                End If
            End If
        End If
    End Sub
    'Private Function GetGroupPainter(ByVal navBar As NavBarControl) As ExplorerBarNavGroupPainter

    '    Dim fi As FieldInfo = GetType(NavBarControl).GetField("groupPainter", BindingFlags.NonPublic Or BindingFlags.Instance)

    '    Return fi.GetValue(navBar)

    'End Function 'GetGroupPainter
    Private Sub Frame_TemplateChanged(sender As Object, e As EventArgs)
        SetupFrame()
    End Sub
End Class
