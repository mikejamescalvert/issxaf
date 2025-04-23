Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports ISS.Base.Win
Imports Microsoft.VisualBasic

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class WinSpellCheckDetailViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        TargetViewType = ViewType.DetailView
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        SetupRichEdit()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub SetupRichEdit()
        Dim ctrController As WinSpellCheckerWindowController = Frame.GetController(Of WinSpellCheckerWindowController)

        If ctrController.SpellCheckerComponent Is Nothing Then
            AddHandler ctrController.Frame.TemplateChanged, AddressOf SpellCheckController_SetupRtf
        Else
            For Each objEditor In CType(View, DetailView).GetItems(Of DevExRichTextEditor)
                If objEditor Is Nothing OrElse objEditor.RichEditUserControl Is Nothing Then
                    AddHandler objEditor.ControlCreated, AddressOf RichEditor_Created
                Else
                    objEditor.RichEditUserControl.RichEditControl.SpellChecker = ctrController.SpellCheckerComponent
                End If

            Next
        End If

    End Sub

    Private Function SpellCheckController_SetupRtf()
        Dim ctrController As WinSpellCheckerWindowController = Frame.GetController(Of WinSpellCheckerWindowController)
        For Each objEditor In CType(View, DetailView).GetItems(Of DevExRichTextEditor)
            If objEditor Is Nothing OrElse objEditor.RichEditUserControl Is Nothing Then
                AddHandler objEditor.ControlCreated, AddressOf RichEditor_Created
            Else
                objEditor.RichEditUserControl.RichEditControl.SpellChecker = ctrController.SpellCheckerComponent
            End If

        Next
    End Function

    Private Sub RichEditor_Created(sender As Object, e As EventArgs)
        Dim objEditor As DevExRichTextEditor = sender
        Dim ctrController As WinSpellCheckerWindowController = Frame.GetController(Of WinSpellCheckerWindowController)
        objEditor.RichEditUserControl.RichEditControl.SpellChecker = ctrController.SpellCheckerComponent
    End Sub
End Class
