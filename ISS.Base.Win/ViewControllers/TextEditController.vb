Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.Core.ModelEditor
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraBars
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraCharts.Design
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Menu
Imports DevExpress.XtraRichEdit.Services

Public Class TextEditController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.DetailView
    End Sub

    Public ReadOnly Property DetailView As DetailView
        Get
            Return View
        End Get
    End Property


    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        For Each dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor In DetailView.GetItems(Of DevExpress.ExpressApp.Editors.PropertyEditor)()
            If dveEditor.MemberInfo.FindAttribute(Of ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsertAttribute)() Is Nothing Then
                Continue For
            End If
            If dveEditor.Control Is Nothing Then
                AddHandler dveEditor.ControlCreated, AddressOf Control_Created
                Continue For
            End If


            ProcessControlForPropertyInsert(dveEditor.Control)

        Next
    End Sub

    Public Function GetPickerControl(ByVal TargetType As Type) As FieldPicker
        Dim pckPicker As New FieldPicker
        pckPicker.Properties.ClassType = TargetType
        pckPicker.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
        Return pckPicker
    End Function

    Public Function GetPropertyStringValueFromPropertyTargetType(ByVal MemberInfo As DC.IMemberInfo) As String
        'TODO: Get Parent Object Of Property Editor
        Dim aptAllowPropertyTypeAttribute As ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsertAttribute = MemberInfo.FindAttribute(Of ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsertAttribute)()
        Dim objOwner As Object = MemberInfo.GetOwnerInstance(View.CurrentObject)
        Dim frmWindowsForm As New frmPicker(aptAllowPropertyTypeAttribute.GetTargetPropertyType(objOwner))
        frmWindowsForm.ShowDialog()
        Return frmWindowsForm.SelectedProperty
    End Function

    Public Sub HtmlDesignerEditor_ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim bmgBarManager As DevExpress.XtraBars.BarManager = sender
        Dim dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor = GetEditorForBarItem(bmgBarManager)
        Dim hpePropertyEditor As DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlEditor = dveEditor.Control
        Dim strPropertyValue As String = GetPropertyStringValueFromPropertyTargetType(dveEditor.MemberInfo)
        Dim wbcWebBrowser As System.Windows.Forms.WebBrowser = hpePropertyEditor.BrowserControl
        'hpePropertyEditor.DoDragDrop(strPropertyValue, System.Windows.Forms.DragDropEffects.Copy)
        Dim txt As mshtml.IHTMLTxtRange = CType(wbcWebBrowser.Document.DomDocument.selection.createRange, mshtml.IHTMLTxtRange)
        txt.pasteHTML(strPropertyValue)
        'wbcWebBrowser.Document.ExecCommand("Paste", False, strPropertyValue)

        'Dim textBox As System.Windows.Forms.TextBox = mmeMemoEditor.MaskBox
        'textBox.Paste(strPropertyValue)
    End Sub

    Public Sub RawHtmlEditor_ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim mmeMemoEditor As DevExpress.XtraEditors.MemoEdit = CType(sender, System.Windows.Forms.MenuItem).Tag
        Dim dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor = GetEditorForControl(mmeMemoEditor)
        Dim strPropertyValue As String = GetPropertyStringValueFromPropertyTargetType(dveEditor.MemberInfo)
        Dim textBox As System.Windows.Forms.TextBox = mmeMemoEditor.MaskBox
        textBox.Paste(strPropertyValue)
    End Sub

    Public Sub RichTextEditor_ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim ctrRichText As DevExpress.ExpressApp.Office.Win.RichEditorContainer = CType(sender, System.Windows.Forms.MenuItem).Tag
        Dim dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor = GetEditorForControl(ctrRichText)
        Dim strPropertyValue As String = GetPropertyStringValueFromPropertyTargetType(dveEditor.MemberInfo)

        If String.IsNullOrWhiteSpace(strPropertyValue) = False Then
            Windows.Forms.Clipboard.SetText(strPropertyValue)
            ctrRichText.RichEditControl.Paste()
        End If
    End Sub
    Public Sub MemoEditor_ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim mmeMemoEditor As DevExpress.XtraEditors.MemoEdit = CType(sender, System.Windows.Forms.MenuItem).Tag
        Dim dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor = GetEditorForControl(mmeMemoEditor)
        Dim strPropertyValue As String = GetPropertyStringValueFromPropertyTargetType(dveEditor.MemberInfo)
        Dim textBox As System.Windows.Forms.TextBox = mmeMemoEditor.MaskBox
        textBox.Paste(strPropertyValue)
    End Sub
    Public Sub RichEditUserControl_ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim myItem As RichEditMenuItem = sender
        Dim recControl As RichEditControl = myItem.Tag
        'Dim reuUserControl As RichEditUserControl = recControl.Tag
        Dim dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor = GetEditorForControl(recControl.Parent)
        Dim strPropertyValue As String = GetPropertyStringValueFromPropertyTargetType(dveEditor.MemberInfo)

        If String.IsNullOrWhiteSpace(strPropertyValue) = False Then
            Windows.Forms.Clipboard.SetText(strPropertyValue)
            recControl.Paste()
        End If




    End Sub
    Public Sub MemoExEditor_ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim mmeMemoExEditor As DevExpress.XtraEditors.MemoExEdit = CType(sender, System.Windows.Forms.MenuItem).Tag
        Dim dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor = GetEditorForControl(mmeMemoExEditor)
        Dim strPropertyValue As String = GetPropertyStringValueFromPropertyTargetType(dveEditor.MemberInfo)
        Dim textBox As System.Windows.Forms.TextBox = mmeMemoExEditor.MaskBox
        textBox.Paste(strPropertyValue)
    End Sub


    Public Function GetEditorForBarItem(ByVal BarManagerToFind As DevExpress.XtraBars.BarManager) As DevExpress.ExpressApp.Editors.PropertyEditor
        Dim hpePropertyEditor As DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlEditor
        For Each dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor In DetailView.GetItems(Of DevExpress.ExpressApp.Editors.PropertyEditor)()
            If TypeOf dveEditor.Control Is DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlEditor Then
                hpePropertyEditor = dveEditor.Control
                If hpePropertyEditor.BarManager Is BarManagerToFind Then
                    Return dveEditor
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Function GetEditorForControl(ByVal ControlToFind As System.Windows.Forms.Control) As DevExpress.ExpressApp.Editors.PropertyEditor
        For Each dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor In DetailView.GetItems(Of DevExpress.ExpressApp.Editors.PropertyEditor)()
            If dveEditor.Control Is ControlToFind Then
                Return dveEditor
            End If
        Next
        Return Nothing
    End Function

    Public Sub TextEditor_ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim txeTextEditor As DevExpress.XtraEditors.TextEdit
        Dim dveEditor As DevExpress.ExpressApp.Editors.PropertyEditor
        Dim strPropertyValue As String

        txeTextEditor = TryCast(sender, System.Windows.Forms.MenuItem)?.Tag

        If txeTextEditor IsNot Nothing Then
            'AndAlso txeTextEditor.MaskBox IsNot Nothing Then

            dveEditor = GetEditorForControl(txeTextEditor)
            If dveEditor IsNot Nothing Then
                strPropertyValue = GetPropertyStringValueFromPropertyTargetType(dveEditor.MemberInfo)
                If String.IsNullOrEmpty(strPropertyValue) = False Then
                    txeTextEditor.SelectedText = strPropertyValue
                    'textBox = txeTextEditor.MaskBox

                    'textBox.Paste(strPropertyValue)


                End If
            End If
        End If

    End Sub
    Public Sub ProcessControlForPropertyInsert(ByRef ctr As System.Windows.Forms.Control)
        If ctr Is Nothing Then
            Return
        End If
        Dim txeTextEditor As DevExpress.XtraEditors.TextEdit
        Dim mmeMemoExEditor As DevExpress.XtraEditors.MemoExEdit
        Dim mmeMemoEditor As DevExpress.XtraEditors.MemoEdit
        Dim reuRichEditControl As RichEditUserControl
        Dim hpePropertyEditor As DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlEditor
        Dim briBarItem As DevExpress.XtraBars.BarItem
        Dim ctrRichEdit As DevExpress.ExpressApp.Office.Win.RichEditorContainer
        Dim lpiLinkPersist As DevExpress.XtraBars.LinkPersistInfo
        Dim mniItem As System.Windows.Forms.MenuItem

        If TypeOf ctr Is DevExpress.XtraEditors.TextEdit Then
            txeTextEditor = ctr
            If txeTextEditor.ContextMenu Is Nothing Then
                txeTextEditor.ContextMenu = New System.Windows.Forms.ContextMenu
            End If
            mniItem = New System.Windows.Forms.MenuItem("Insert Property Name", New System.EventHandler(AddressOf TextEditor_ContextMenuClicked))
            mniItem.Tag = txeTextEditor
            txeTextEditor.ContextMenu.MenuItems.Add(mniItem)
        ElseIf TypeOf ctr Is DevExpress.XtraEditors.MemoExEdit Then
            mmeMemoExEditor = ctr
            If mmeMemoExEditor.ContextMenu Is Nothing Then
                mmeMemoExEditor.ContextMenu = New System.Windows.Forms.ContextMenu
            End If
            mniItem = New System.Windows.Forms.MenuItem("Insert Property Name", New System.EventHandler(AddressOf MemoExEditor_ContextMenuClicked))
            mniItem.Tag = mmeMemoExEditor
            mmeMemoExEditor.ContextMenu.MenuItems.Add(mniItem)

        ElseIf TypeOf ctr Is DevExpress.XtraEditors.MemoEdit Then
            mmeMemoEditor = ctr
            If mmeMemoEditor.ContextMenu Is Nothing Then
                mmeMemoEditor.ContextMenu = New System.Windows.Forms.ContextMenu
            End If
            mniItem = New System.Windows.Forms.MenuItem("Insert Property Name", New System.EventHandler(AddressOf MemoEditor_ContextMenuClicked))
            mniItem.Tag = mmeMemoEditor
            mmeMemoEditor.ContextMenu.MenuItems.Add(mniItem)
        ElseIf TypeOf ctr Is DevExpress.ExpressApp.Office.Win.RichEditorContainer Then
            ctrRichEdit = ctr
            AddHandler ctrRichEdit.RichEditControl.PopupMenuShowing, AddressOf RichEdit_PopupMenuShowing

        ElseIf TypeOf ctr Is RichEditUserControl Then
            reuRichEditControl = ctr
            AddHandler reuRichEditControl.RichEditControl.PopupMenuShowing, AddressOf RichEdit_PopupMenuShowing

        ElseIf TypeOf ctr Is DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlEditor Then
            hpePropertyEditor = ctr
            If hpePropertyEditor.Memo.ContextMenu Is Nothing Then
                hpePropertyEditor.Memo.ContextMenu = New System.Windows.Forms.ContextMenu
            End If
            mniItem = New System.Windows.Forms.MenuItem("Insert Property Name", New System.EventHandler(AddressOf RawHtmlEditor_ContextMenuClicked))
            mniItem.Tag = hpePropertyEditor

            hpePropertyEditor.Memo.ContextMenu.MenuItems.Add(mniItem)

            briBarItem = New DevExpress.XtraBars.BarButtonItem(hpePropertyEditor.BarManager, "Insert Property Name")
            briBarItem.Id = 999
            briBarItem.Name = "InsertPropertyName"
            briBarItem.Tag = "InsertPropertyName"
            lpiLinkPersist = New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, briBarItem, DevExpress.XtraBars.BarItemPaintStyle.Caption)
            AddHandler briBarItem.ItemClick, AddressOf HtmlDesignerEditor_ContextMenuClicked
            hpePropertyEditor.BarManager.Bars(1).LinksPersistInfo.Add(lpiLinkPersist)
        End If
    End Sub

    Private Sub RichEdit_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs)
        If (e.MenuType And RichEditMenuType.Text) <> 0 Then
            ' Insert a new item into the Richedit popup menu and handle its click event:
            Dim myItem As New RichEditMenuItem("Insert Property Name", New EventHandler(AddressOf RichEditUserControl_ContextMenuClicked))
            myItem.Tag = sender
            e.Menu.Items.Add(myItem)

        End If
    End Sub

    Private Sub Control_Created(sender As Object, e As EventArgs)

        ProcessControlForPropertyInsert(sender.Control)

    End Sub

    Private _mDocumentManagers As New Dictionary(Of System.Windows.Forms.HtmlDocument, HtmlPropertyEditor.Win.HtmlEditor)

    Private Function CreatePopupMenu(ByVal manager As BarManager) As PopupMenu
        Dim popupMenu As New PopupMenu(manager)
        popupMenu.ItemLinks.Add(New BarButtonItem(manager, "Insert Property Name"))
        AddHandler popupMenu.ItemLinks.Item(popupMenu.ItemLinks.Count - 1).Item.ItemClick, AddressOf HtmlDesignerEditor_ContextMenuClicked
        Return popupMenu
    End Function
    Private Sub Document_ContextMenuShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs)

        Dim popupMenu As PopupMenu = CreatePopupMenu(_mDocumentManagers(sender).BarManager)
        popupMenu.ShowPopup(_mDocumentManagers(sender).BrowserControl.PointToScreen(e.ClientMousePosition))
    End Sub

End Class
