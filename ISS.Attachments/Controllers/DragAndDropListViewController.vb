Option Strict Off

Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

'********************Change log****************************
'HWR 04/24/17 - Change to open attachment through independent controller and action

Public Class DragAndDropListViewController
    Inherits DevExpress.ExpressApp.ViewController


    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.ListView
        Me.TargetObjectType = GetType(IAttachment)

    End Sub

    Public ReadOnly Property ListView As ListView
        Get
            Return View
        End Get
    End Property

    Public ReadOnly Property CurrentAttachment As IAttachment
        Get
            Return View.CurrentObject
        End Get
    End Property

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ListView.AllowNew("CreateAttachmentsNotAllowed") = False

        'HWR 04/24/17
        'If not TypeOf ListView.Editor Is DevExpress.ExpressApp.Win.Editors.GridListEditor
        '    Return   
        'End If

        'Dim cntProcessSelectedItemController As DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController = Frame.GetController(Of DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController)
        'ListView.AllowNew("CreateAttachmentsNotAllowed") = False

        'AddHandler cntProcessSelectedItemController.CustomProcessSelectedItem, AddressOf ListView_CustomProcessSelectedItem

    End Sub

    Public Sub ToolStripItem_PasteClicked()
        HandlePaste()
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        If not TypeOf ListView.Editor Is DevExpress.ExpressApp.Win.Editors.GridListEditor
            Return   
        End If
        Dim lpeListPropertyEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor = ListView.Editor
        AddHandler lpeListPropertyEditor.Grid.DragEnter, AddressOf GridControl_DragEnter
        AddHandler lpeListPropertyEditor.Grid.DragDrop, AddressOf GridControl_DragDrop
        AddHandler lpeListPropertyEditor.Grid.KeyDown, AddressOf GridControl_KeyDown
        AddHandler lpeListPropertyEditor.Grid.KeyPress, AddressOf GridControl_KeyPress
    End Sub


    Public ReadOnly Property FileDataTypes As String()
        Get
            Return {System.Windows.Forms.DataFormats.FileDrop}
        End Get
    End Property

    
    Public Sub HandlePaste()
        Dim atcAttachment As IAttachment
        Dim ifiFileInfo As IO.FileInfo
        Dim imgImage As System.Drawing.Image
        Dim strName As String
        Dim sgi As System.Guid
        If System.Windows.Forms.Clipboard.ContainsImage = True Then
            imgImage = System.Windows.Forms.Clipboard.GetImage
            sgi = System.Guid.NewGuid
            strName = sgi.ToString + ".png"
            imgImage.Save(strName, Drawing.Imaging.ImageFormat.Png)
            imgImage.Dispose()
            imgImage = Nothing
            ifiFileInfo = New IO.FileInfo(strName)
            atcAttachment = ListView.CollectionSource.ObjectSpace.CreateObject(ListView.ObjectTypeInfo.Type)
            atcAttachment.FileData = IO.File.ReadAllBytes(strName)
            atcAttachment.SetRecordDate(ifiFileInfo.LastWriteTime)

            'atcAttachment.Description = ifiFileInfo.Name
            atcAttachment.SetFileName(ifiFileInfo.Name)
            ListView.CollectionSource.Add(atcAttachment)
            IO.File.Delete(strName)
        ElseIf System.Windows.Forms.Clipboard.ContainsFileDropList Then
            For Each strName In System.Windows.Forms.Clipboard.GetFileDropList
                ifiFileInfo = New IO.FileInfo(strName)
                atcAttachment = ListView.CollectionSource.ObjectSpace.CreateObject(ListView.ObjectTypeInfo.Type)
                atcAttachment.FileData = IO.File.ReadAllBytes(strName)
                atcAttachment.SetRecordDate(ifiFileInfo.LastWriteTime)

                atcAttachment.Description = ifiFileInfo.Name
                atcAttachment.SetFileName(ifiFileInfo.Name)
                ListView.CollectionSource.Add(atcAttachment)
            Next
        ElseIf System.Windows.Forms.Clipboard.ContainsData("FileGroupDescriptor") Then
            'Stop
            'Get the Filename:

            Dim theStream As System.IO.Stream = DirectCast(System.Windows.Forms.Clipboard.GetData("FileGroupDescriptor"), System.IO.Stream)
            Dim fileGroupDescriptor As Byte() = New Byte(511) {}
            theStream.Read(fileGroupDescriptor, 0, 512)

            Dim fileName As New System.Text.StringBuilder("")
            Dim i As Integer
            i = 76
            While fileGroupDescriptor(i) <> 0
                fileName.Append(Convert.ToChar(fileGroupDescriptor(i)))
                i += 1
            End While
            theStream.Close()

            'Dim theFile As String = "C:\Temp\DragAndDrop\" + fileName.ToString()

            'Get the data and save it to a file:

            Dim ms As System.IO.MemoryStream = DirectCast(System.Windows.Forms.Clipboard.GetData("FileContents"), System.IO.MemoryStream)
            Dim fileBytes As Byte() = New Byte(ms.Length - 1) {}
            ms.Position = 0
            ms.Read(fileBytes, 0, CInt(ms.Length))

            'Dim fs As New System.IO.FileStream(theFile, System.IO.FileMode.Create)
            'fs.Write(fileBytes, 0, CInt(fileBytes.Length))
            'fs.Close()

            atcAttachment = ListView.CollectionSource.ObjectSpace.CreateObject(ListView.ObjectTypeInfo.Type)
            atcAttachment.FileData = fileBytes
            atcAttachment.SetRecordDate(Now)

            atcAttachment.Description = fileName.ToString
            atcAttachment.SetFileName(fileName.ToString)
            ListView.CollectionSource.Add(atcAttachment)

        End If
    End Sub

    Private _mPaste As Boolean = False
    Private _mCopy As Boolean = False

    Private Sub GridControl_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.Control = True AndAlso e.KeyCode = System.Windows.Forms.Keys.V Then
            _mPaste = True
        ElseIf e.Control = True AndAlso e.KeyCode = System.Windows.Forms.Keys.C Then
            _mCopy = True
        End If
    End Sub

    Private Sub GridControl_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If _mPaste Then
            'todo: handle paste
            HandlePaste()

            e.Handled = True
            _mPaste = False
        ElseIf _mCopy Then
            HandleCopy()

            e.Handled = True
            _mCopy = False
        End If
    End Sub

    Private Sub HandleCopy()
        Dim svcAttachmentService As New AttachmentService()
        svcAttachmentService.CopyAttachmentFileData(CType(View, ListView).SelectedObjects(0))
    End Sub

    Private Sub GridControl_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs)

        If ListView.CollectionSource.AllowAdd = False Then
            e.Effect = System.Windows.Forms.DragDropEffects.None
            Return
        End If

        If FileDataTypes.All(Function(requiredFormat) e.Data.GetDataPresent(requiredFormat)) Then
            e.Effect = System.Windows.Forms.DragDropEffects.Copy
        End If
    End Sub

    Private Sub GridControl_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)
        Dim atcAttachment As IAttachment
        Dim strFiles() As String
        Dim ifiFileInfo As IO.FileInfo
        Dim strFileTypes() As String
        Dim afaAttachmentFilter As AttachmentFilterAttribute = ListView.ObjectTypeInfo.FindAttribute(Of AttachmentFilterAttribute)

        If FileDataTypes.All(Function(requiredFormat) e.Data.GetDataPresent(requiredFormat)) Then
            strFiles = e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop)
            If afaAttachmentFilter IsNot Nothing AndAlso afaAttachmentFilter.AllowedTypes > String.Empty Then
                strFileTypes = afaAttachmentFilter.AllowedTypes.ToLower.Split(",")
                For Each strFile As String In strFiles
                    ifiFileInfo = New IO.FileInfo(strFile)
                    If ifiFileInfo.Extension = String.Empty Then
                        MsgBox("All attachments must have a file extension.")
                        Return
                    End If
                    If strFileTypes.Contains(Trim(ifiFileInfo.Extension.Replace(".", "").ToLower)) = False Then
                        MsgBox(ifiFileInfo.Extension + " is not a supported file type.")
                        Return
                    End If
                Next
            End If

            For Each strFile As String In strFiles
                ifiFileInfo = New IO.FileInfo(strFile)
                atcAttachment = ListView.CollectionSource.ObjectSpace.CreateObject(ListView.ObjectTypeInfo.Type)
                atcAttachment.FileData = IO.File.ReadAllBytes(strFile)
                atcAttachment.SetRecordDate(ifiFileInfo.LastWriteTime)

                atcAttachment.Description = ifiFileInfo.Name
                atcAttachment.SetFileName(ifiFileInfo.Name)
                ListView.CollectionSource.Add(atcAttachment)
            Next
        End If

        'ListView.CollectionSource.ObjectSpace.CommitChanges()

    End Sub
    'HWR 04/24/17
    'Private Sub ListView_CustomProcessSelectedItem(sender As Object, e As SystemModule.CustomProcessListViewSelectedItemEventArgs)
    '    If View.Id.Contains("Lookup") = False Then
    '        CurrentAttachment.OpenFile()
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub Attachments_PasteInformation_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles Attachments_PasteInformation.Execute
        HandlePaste()
    End Sub
End Class

