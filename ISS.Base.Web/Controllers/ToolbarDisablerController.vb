Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class ToolbarDisablerController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()
        'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub

    Private Sub ToolbarDisablerController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        HideDefaultToolbars()
    End Sub

    Public Sub SetToolbarVisible(ByVal Visible As Boolean)
        Dim frmFrame As DevExpress.ExpressApp.Templates.IFrameTemplate = Me.Frame.Template
        Dim cntControl As System.Web.UI.Control
        Dim tlbMainToolbar As System.Web.UI.Control
        If frmFrame IsNot Nothing Then
            cntControl = frmFrame
            tlbMainToolbar = cntControl.FindControl("TB")
            If tlbMainToolbar IsNot Nothing Then
                tlbMainToolbar.Visible = Visible
            Else
                tlbMainToolbar = cntControl.FindControl("ToolBar")
                If tlbMainToolbar IsNot Nothing Then
                    tlbMainToolbar.Visible = Visible
                End If
            End If
        End If
    End Sub

    Private Sub HideDefaultToolbars()
        Dim sabShowActionBar As ISS.Base.Attributes.View.ShowActionBarAttribute = Nothing
        Dim lstView As ListView
        Dim pcsPropertyCollectionSource As PropertyCollectionSource
        If TypeOf View Is ListView Then
            lstView = View
            If TypeOf lstView.CollectionSource Is PropertyCollectionSource Then
                pcsPropertyCollectionSource = lstView.CollectionSource
                sabShowActionBar = pcsPropertyCollectionSource.MemberInfo.FindAttribute(Of ISS.Base.Attributes.View.ShowActionBarAttribute)()
            End If
        End If
        If sabShowActionBar Is Nothing AndAlso Me.View.ObjectTypeInfo IsNot Nothing Then
            sabShowActionBar = Me.View.ObjectTypeInfo.FindAttribute(Of ISS.Base.Attributes.View.ShowActionBarAttribute)()
        End If
        If sabShowActionBar IsNot Nothing Then
            If sabShowActionBar.IsVisible = False Then
                SetToolbarVisible(False)
            End If
        End If


    End Sub

End Class
