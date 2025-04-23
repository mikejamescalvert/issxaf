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
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSpellChecker
Imports DevExpress.Utils.Win

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class WinSpellCheckerGridListViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        TargetViewType = ViewType.ListView
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        SetupGridView()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub


    Protected Overridable Sub SetupGridView()
        If TypeOf View Is DevExpress.ExpressApp.ListView Then
            Dim lv As DevExpress.ExpressApp.ListView = CType(View, DevExpress.ExpressApp.ListView)
            Dim gridListEditor As GridListEditor = TryCast(lv.Editor, GridListEditor)
            If gridListEditor IsNot Nothing Then
                RemoveHandler gridListEditor.GridView.ShownEditor, AddressOf GridView_ShownEditor
                AddHandler gridListEditor.GridView.ShownEditor, AddressOf GridView_ShownEditor
            End If
        End If
    End Sub
    Private Sub GridView_ShownEditor(ByVal sender As Object, ByVal e As EventArgs)
        'If spellCheckerCore IsNot Nothing Then
        Return
        Dim gvwGridView As GridView = TryCast(sender, GridView)
        If gvwGridView Is Nothing Then
            Return
        End If
        Dim activeControl As Control = gvwGridView.ActiveEditor
        If activeControl Is Nothing Then
            Return
        End If
        Dim sccSpellCheckerController As WinSpellCheckerWindowController = Frame.GetController(Of WinSpellCheckerWindowController)
        If TypeOf activeControl Is MemoExEdit Then
            AddHandler CType(activeControl, MemoExEdit).Popup, AddressOf MemoExEdit_Popup
        End If
        If sccSpellCheckerController IsNot Nothing AndAlso sccSpellCheckerController.SpellCheckerComponent IsNot Nothing Then
            sccSpellCheckerController.SpellCheckerComponent.SetShowSpellCheckMenu(activeControl, True)
            sccSpellCheckerController.SpellCheckerComponent.CheckAsYouTypeOptions.ShowSpellCheckForm = False
            If sccSpellCheckerController.SpellCheckerComponent.SpellCheckMode = SpellCheckMode.AsYouType Then
                sccSpellCheckerController.SpellCheckerComponent.Check(activeControl)
            End If
        End If

        'End If
    End Sub
    Private Sub MemoExEdit_Popup(sender As Object, e As EventArgs)
        Dim ppcControl As IPopupControl = TryCast(sender, IPopupControl)
        Dim popupWindow As Control
        Dim sccSpellCheckerController As WinSpellCheckerWindowController = Frame.GetController(Of WinSpellCheckerWindowController)
        If sccSpellCheckerController Is Nothing OrElse sccSpellCheckerController.SpellCheckerComponent Is Nothing Then
            return
        End If
        If ppcControl Is Nothing Then
            Return
        End If
        popupWindow = ppcControl.PopupWindow
        If popupWindow Is Nothing Then
            Return
        End If
        If popupWindow.Controls Is Nothing Then
            Return
        End If
        If popupWindow.Controls.Count < 3 Then
            Return
        End If
        sccSpellCheckerController.SpellCheckerComponent.SetShowSpellCheckMenu(popupWindow.Controls(2), True)
        If sccSpellCheckerController.SpellCheckerComponent.SpellCheckMode = SpellCheckMode.AsYouType Then
            sccSpellCheckerController.SpellCheckerComponent.Check(popupWindow.Controls(2))
        End If
    End Sub

End Class
