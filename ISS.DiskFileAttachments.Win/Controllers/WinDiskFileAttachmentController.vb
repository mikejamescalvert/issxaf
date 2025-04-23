Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class WinDiskFileAttachmentController
    Inherits DiskFileAttachmentController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub
    Public Overrides Sub OpenFile()
        Dim oFileAttachment As ISS.DiskFileAttachments.ISSBaseDiskFileAttachment

        If Me.EffectedAttachments.Count = 1 Then
            oFileAttachment = Me.View.CurrentObject
            Process.Start(oFileAttachment.FileName)
        ElseIf Me.EffectedAttachments.Count > 1 Then
            For Each oFileAttachment In EffectedAttachments
                Process.Start(oFileAttachment.FileName)
            Next
        End If

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
                If View.ObjectTypeInfo.IsPersistent = True Then
                    oFileAttachment.Delete()
                Else
                    CType(Me.View, ListView).CollectionSource.Remove(oFileAttachment)
                End If
            Next
            'Me.ObjectSpace.CommitChanges()
        End If
    End Sub

    Public Overrides Sub DownloadFileToDisk()
        Dim fsdFileSaveDialog As New System.Windows.Forms.SaveFileDialog
        Dim folFolderSelectDialog As New System.Windows.Forms.FolderBrowserDialog
        Dim oFileAttachment As ISS.DiskFileAttachments.ISSBaseDiskFileAttachment
        Dim ddiDirectoryInfo As IO.DirectoryInfo

        If Me.EffectedAttachments.Count = 1 Then
            fsdFileSaveDialog.ShowDialog()
            If fsdFileSaveDialog.FileName > String.Empty Then
                oFileAttachment = EffectedAttachments(0)
                IO.File.Copy(oFileAttachment.FileName, fsdFileSaveDialog.FileName)
            End If
        ElseIf EffectedAttachments.Count > 1 Then
            folFolderSelectDialog.Description = "Select A Folder To Upload Files To"
            folFolderSelectDialog.ShowDialog()
            If folFolderSelectDialog.SelectedPath > String.Empty Then
                ddiDirectoryInfo = New IO.DirectoryInfo(folFolderSelectDialog.SelectedPath)
                For Each oFileAttachment In EffectedAttachments
                    IO.File.Copy(oFileAttachment.FileName, String.Format("{0}\{1}", ddiDirectoryInfo.FullName, oFileAttachment.FileInfo.Name), True)
                Next
            End If
        Else
            MsgBox("No Files Found!", MsgBoxStyle.OkOnly, "Download Files")
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

    Public Overrides Sub UploadFileToDisk()
        Dim oFileAttachment As ISS.DiskFileAttachments.ISSBaseDiskFileAttachment
        Dim oFileInfo As IO.FileInfo
        Dim ofdOpenFileDialog As New System.Windows.Forms.OpenFileDialog
        Dim strFileName As String
        If TypeOf View Is ListView Then
            Try
                ofdOpenFileDialog.Multiselect = True
                ofdOpenFileDialog.ShowDialog()
                If ofdOpenFileDialog.FileNames.Length > 0 Then
                    For Each strFileName In ofdOpenFileDialog.FileNames
                        oFileInfo = New IO.FileInfo(strFileName)
                        oFileAttachment = GetFileDataFromCollection(oFileInfo.Name)
                        If oFileAttachment Is Nothing Then
                            oFileAttachment = Me.View.ObjectTypeInfo.CreateInstance(CType(ObjectSpace, Xpo.XPObjectSpace).Session)
                            CType(Me.View, ListView).CollectionSource.Add(oFileAttachment)
                        End If
                        oFileAttachment.ValidateFile(oFileInfo)
                        oFileAttachment.UploadFile(strFileName, oFileInfo.Name, ISSBaseDiskFileAttachment.FileExistsOptions.Overwrite)
                        'oFileAttachment.Save()
                    Next
                End If
                'Me.ObjectSpace.CommitChanges()
            Catch ex As Exception
                Throw New UserFriendlyException(ex)
                'Me.ObjectSpace.Rollback()
            End Try
        Else
            Try
                ofdOpenFileDialog.Multiselect = False
                ofdOpenFileDialog.ShowDialog()
                If ofdOpenFileDialog.FileName > String.Empty Then
                    oFileInfo = New IO.FileInfo(ofdOpenFileDialog.FileName)
                    oFileAttachment = Me.View.CurrentObject
                    oFileAttachment.ValidateFile(oFileInfo)
                    oFileAttachment.UploadFile(ofdOpenFileDialog.FileName, oFileInfo.Name, ISSBaseDiskFileAttachment.FileExistsOptions.Overwrite)
                End If
            Catch ex As Exception
                Throw New UserFriendlyException(ex)
                'Me.ObjectSpace.Rollback()

            End Try

        End If
    End Sub

End Class
