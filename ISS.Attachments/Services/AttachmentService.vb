Imports System.IO

Public Class AttachmentService
    Public Sub DownloadFile(ByVal Attachment As IAttachment, ByVal FileName As String)
        Dim strBaseFile As String = Attachment.FileName
        IO.File.WriteAllBytes(FileName, Attachment.FileData)
    End Sub

    Public Sub OpenFile(ByVal Attachment As IAttachment)
        Process.Start(WriteAttachmentFileData(Attachment))
    End Sub

    Public Sub CopyAttachmentFileData(Attachment As IAttachment)
        System.Windows.Forms.Clipboard.SetFileDropList(New Specialized.StringCollection From {WriteAttachmentFileData(Attachment)})
    End Sub

    ''' <summary>
    ''' Writes attachment file data to the local user App Data path and returns the path.
    ''' </summary>
    ''' <param name="Attachment"></param>
    ''' <returns>Fully qualified path to the file with filename.</returns>
    Public Function WriteAttachmentFileData(Attachment As IAttachment) As String
        Dim strBaseFile As String = Attachment.FileName
        Dim intAttempts As Integer = 0
        Dim ifiFileInfo As FileInfo
        Dim strFileName As String = Attachment.FileName
        Dim strFullPath As String = String.Format("{0}\{1}", System.Windows.Forms.Application.LocalUserAppDataPath, strFileName)

        While IsFileLocked(strFullPath) = True
            intAttempts += 1
            ifiFileInfo = New IO.FileInfo(strBaseFile)
            strFileName = strBaseFile.Substring(0, Len(strBaseFile) - Len(ifiFileInfo.Extension)) + intAttempts.ToString + ifiFileInfo.Extension
            strFullPath = String.Format("{0}\{1}", System.Windows.Forms.Application.LocalUserAppDataPath, strFileName)
        End While

        File.WriteAllBytes(strFullPath, Attachment.FileData)

        Return strFullPath
    End Function

    Private Function IsFileLocked(ByVal FileName As String)
        Dim flsFileStream As IO.FileStream = Nothing
        Try
            flsFileStream = IO.File.Open(FileName, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite, IO.FileShare.None)
        Catch ex As IO.IOException
            Return True
        Finally
            If flsFileStream IsNot Nothing Then
                flsFileStream.Close()
            End If
        End Try
        Return False
    End Function
End Class
