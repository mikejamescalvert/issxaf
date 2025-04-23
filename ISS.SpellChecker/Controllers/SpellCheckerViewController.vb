Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports DevExpress.XtraSpellChecker
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Globalization
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Win
Imports DevExpress.ExpressApp.Editors

Public Class SpellCheckerViewController
    Inherits ViewController
    Private spellCheckerCore As DevExpress.XtraSpellChecker.SpellChecker
    Private checkActionCore As SimpleAction
    Private parentControlCore As Control
    Private Sub CheckContainer()
        If spellCheckerCore.ParentContainer Is Nothing Then
            spellCheckerCore.ParentContainer = parentControlCore
        End If
        spellCheckerCore.CheckContainer()
    End Sub
    Public Sub New()
        checkActionCore = New SimpleAction(Me, "Check", PredefinedCategory.RecordEdit)
        checkActionCore.ToolTip = "Check Spelling"
        checkActionCore.Caption = checkActionCore.ToolTip
        checkActionCore.Category = "View"
        checkActionCore.ImageName = "BO_Task"
        checkActionCore.TargetViewType = ViewType.DetailView
        checkActionCore.TargetViewNesting = Nesting.Root
        AddHandler checkActionCore.Execute, AddressOf checkActionCore_Execute
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        If View.IsRoot Or TypeOf View Is DetailView Then
            parentControlCore = CType(View.Control, Control)
        End If
        SetupSpellChecker()
        SetupGridView()
        CheckContainer()

    End Sub
    Protected Overridable Sub SetupSpellChecker()
        spellCheckerCore = New DevExpress.XtraSpellChecker.SpellChecker()
        SpellCheckerInitializer.Initialize(spellCheckerCore)
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
        If spellCheckerCore IsNot Nothing Then
            Dim activeControl As Control = (CType(sender, GridView)).ActiveEditor
            If TypeOf activeControl Is MemoExEdit Then
                AddHandler CType(activeControl, MemoExEdit).Popup, AddressOf MemoExEdit_Popup
            End If
            spellCheckerCore.SetShowSpellCheckMenu(activeControl, True)
            spellCheckerCore.CheckAsYouTypeOptions.ShowSpellCheckForm = false
            If spellCheckerCore.SpellCheckMode = SpellCheckMode.AsYouType Then
                spellCheckerCore.Check(activeControl)
            End If
        End If
    End Sub
    Private Sub checkActionCore_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
        CheckContainer()
        'Dim dtvRTFEditor As ISS.Base.Win.DevExRichTextEditor
        'For Each dtvTemRTFEditor As ISS.Base.Win.DevExRichTextEditor In CType(View, DetailView).GetItems(Of ISS.Base.Win.DevExRichTextEditor)()
        '    If dtvRTFEditor IsNot Nothing Then
        '        dtvTemRTFEditor.AppendRTFText(dtvRTFEditor.PropertyValue)
        '    Else
        '        dtvRTFEditor = dtvTemRTFEditor
        '    End If
        'Next
    End Sub
    Public ReadOnly Property SpellChecker() As DevExpress.XtraSpellChecker.SpellChecker
        Get
            Return spellCheckerCore
        End Get
    End Property
    Public ReadOnly Property CheckAction() As SimpleAction
        Get
            Return checkActionCore
        End Get
    End Property

    Private Sub MemoExEdit_Popup(sender As Object, e As EventArgs)
        Dim popupWindow As Control = (CType(sender, IPopupControl)).PopupWindow
        spellCheckerCore.SetShowSpellCheckMenu(popupWindow.Controls(2), True)
        If spellCheckerCore.SpellCheckMode = SpellCheckMode.AsYouType Then
            spellCheckerCore.Check(popupWindow.Controls(2))
        End If
    End Sub

End Class