Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class WebDiskFileAttachmentController
    Inherits DiskFileAttachmentController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.HideUploadAction("CannotUploadFromWebAction")
        Me.HideUploadAction("CannotOpenFromWeb")
    End Sub

    Public Overrides Sub DeleteFileFromDisk()
        Dim oFileAttachment As ISS.DiskFileAttachments.ISSBaseDiskFileAttachment
        Dim lstAttachmentsToDelete As New List(Of ISS.DiskFileAttachments.ISSBaseDiskFileAttachment)
        Dim dltDeleteController As DevExpress.ExpressApp.SystemModule.DeleteObjectsViewController = Frame.GetController(Of DevExpress.ExpressApp.SystemModule.DeleteObjectsViewController)()
        If TypeOf View Is DetailView Then
            If dltDeleteController IsNot Nothing Then
                oFileAttachment = Me.View.CurrentObject
                oFileAttachment.DeleteFile()
                dltDeleteController.DeleteAction.DoExecute()
            End If
        Else
            For Each oFileAttachment In Me.EffectedAttachments
                lstAttachmentsToDelete.Add(oFileAttachment)
            Next
            For intLoop As Integer = lstAttachmentsToDelete.Count - 1 To 0 Step -1
                oFileAttachment = lstAttachmentsToDelete(intLoop)
                oFileAttachment.DeleteFile()
                oFileAttachment.Delete()
            Next
            Me.ObjectSpace.CommitChanges()
        End If
    End Sub

    Public Overrides Sub DownloadFileToDisk()
        Dim oFileAttachment As ISS.DiskFileAttachments.ISSBaseDiskFileAttachment
        Dim resResponse As System.Web.HttpResponse = System.Web.HttpContext.Current.Response


        If EffectedAttachments.Count > 0 Then
            oFileAttachment = EffectedAttachments(0)
            If oFileAttachment.FileInfo IsNot Nothing Then
                resResponse.AppendHeader("Content-Disposition", "attachment; filename=" + oFileAttachment.FileInfo.Name)
                resResponse.TransmitFile(oFileAttachment.FileName)
                resResponse.End()
            End If
        End If

    End Sub

    Public Function GetFileDataFromCollection(ByVal FileName As String) As Object
        For Each oFileAttachment As ISSBaseDiskFileAttachment In CType(Me.View, ListView).CollectionSource.Collection
            If oFileAttachment.FileName = oFileAttachment.GetPathFromPartialFilename(FileName) Then
                Return oFileAttachment
            End If
        Next
        Return Nothing
    End Function
    Public Overrides Sub OpenFile()

    End Sub

    Public Overrides Sub UploadFileToDisk()

        'Dim fsdFileSaveDialog As New Windows.Forms.SaveFileDialog
        'Dim folFolderSelectDialog As New Windows.Forms.FolderBrowserDialog
        'Dim oFileAttachment As ISS.Base.DiskFileAttachment
        'Dim ddiDirectoryInfo As IO.DirectoryInfo
        'Dim oFileInfo As IO.FileInfo
        'Dim ofdOpenFileDialog As New Windows.Forms.OpenFileDialog
        'Dim strFileName As String
        'If TypeOf View Is ListView Then
        '    Try
        '        ofdOpenFileDialog.Multiselect = True
        '        ofdOpenFileDialog.ShowDialog()
        '        If ofdOpenFileDialog.FileNames.Length > 0 Then
        '            For Each strFileName In ofdOpenFileDialog.FileNames
        '                oFileInfo = New IO.FileInfo(strFileName)
        '                oFileAttachment = GetFileDataFromCollection(oFileInfo.Name)
        '                If oFileAttachment Is Nothing Then
        '                    oFileAttachment = Me.View.ObjectTypeInfo.CreateInstance(ObjectSpace.Session)
        '                End If
        '                oFileAttachment.ValidateFile(oFileInfo)
        '                oFileAttachment.UploadFile(strFileName, oFileInfo.Name, True)
        '                oFileAttachment.Save()
        '                CType(Me.View, ListView).CollectionSource.Add(oFileAttachment)
        '            Next
        '        End If
        '        Me.ObjectSpace.CommitChanges()
        '    Catch ex As Exception
        '        Me.ObjectSpace.Rollback()
        '        Throw New UserFriendlyException(ex)
        '    End Try
        'Else
        '    Try
        '        ofdOpenFileDialog.Multiselect = False
        '        ofdOpenFileDialog.ShowDialog()
        '        If ofdOpenFileDialog.FileName > String.Empty Then
        '            oFileInfo = New IO.FileInfo(ofdOpenFileDialog.FileName)
        '            oFileAttachment = Me.View.CurrentObject
        '            oFileAttachment.ValidateFile(oFileInfo)
        '            oFileAttachment.UploadFile(ofdOpenFileDialog.FileName, oFileInfo.Name, True)
        '        End If
        '    Catch ex As Exception
        '        Me.ObjectSpace.Rollback()
        '        Throw New UserFriendlyException(ex)
        '    End Try

        'End If
    End Sub


    Private Sub WebDiskFileAttachmentController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        Dim ufsFileUploadEditor As FileUploadStringEditor
        Dim ufsFileUploadControl As FileUploadStringControl
        If TypeOf View Is DetailView Then
            For Each ufsFileUploadEditor In CType(View, DetailView).GetItems(Of FileUploadStringEditor)()

                ufsFileUploadControl = ufsFileUploadEditor.Control
                If ufsFileUploadControl IsNot Nothing Then
                    AddHandler ufsFileUploadControl.FileUploadComplete, AddressOf _mFileUploadControl_FileUploadComplete
                End If

            Next
        End If

    End Sub

    Private Sub _mFileUploadControl_FileUploadComplete(ByVal sender As Object, ByVal e As DevExpress.Web.FileUploadCompleteEventArgs)
        Dim ufsFileUploadControl As FileUploadStringControl = sender
        Dim oFileData As ISSBaseDiskFileAttachment = Me.View.CurrentObject
        Dim ufsFileUploadEditor As FileUploadStringEditor = ufsFileUploadControl.OwnerEditor
        oFileData.ValidateFile(e.UploadedFile.FileName, e.UploadedFile.FileBytes)
        oFileData.UploadFile(e.UploadedFile.FileBytes, e.UploadedFile.FileName, True)
        e.ErrorText = "Success"
        e.IsValid = False
    End Sub

End Class
