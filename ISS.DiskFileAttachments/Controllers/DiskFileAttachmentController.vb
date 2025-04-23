Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public MustInherit Class DiskFileAttachmentController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetObjectType = GetType(ISSBaseDiskFileAttachment)
    End Sub

    Public Sub HideUploadAction(ByVal Reason As String)
        Me.btnUploadDiskFile.Active.SetItemValue(Reason, False)
    End Sub
    Public Sub HideOpenAction(ByVal reason As String)
        Me.btnOpen.Active.SetItemValue(reason, False)
    End Sub

    Private Sub btnUploadDiskFile_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles btnUploadDiskFile.Execute
        UploadFileToDisk()
    End Sub

    Private Sub btnDownloadDiskFile_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles btnDownloadDiskFile.Execute
        DownloadFileToDisk()
    End Sub

    Private Sub btnDeleteDiskFile_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles btnDeleteDiskFile.Execute
        DeleteFileFromDisk()
    End Sub

    Private _mEffectedAttachments As New List(Of ISSBaseDiskFileAttachment)
    Public ReadOnly Property EffectedAttachments() As List(Of ISSBaseDiskFileAttachment)
        Get
            _mEffectedAttachments.Clear()
            If Me.View.SelectedObjects.Count > 0 Then
                For Each oFileAttachment As ISSBaseDiskFileAttachment In Me.View.SelectedObjects
                    _mEffectedAttachments.Add(oFileAttachment)
                Next
            End If
            Return _mEffectedAttachments
        End Get
    End Property

    Public MustOverride Sub UploadFileToDisk()
    Public MustOverride Sub DownloadFileToDisk()
    Public MustOverride Sub DeleteFileFromDisk()
    Public MustOverride Sub OpenFile()


    Private Sub DiskFileAttachmentController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf View Is ListView Then
            Me.btnDeleteDiskFile.Caption = "Delete Files"
            Me.btnDownloadDiskFile.Caption = "Download Files"
            Me.btnUploadDiskFile.Caption = "Upload Files"
            Me.btnOpen.Caption = "Open Files"
        Else
            Me.btnDeleteDiskFile.Caption = "Delete File"
            Me.btnDownloadDiskFile.Caption = "Download File"
            Me.btnUploadDiskFile.Caption = "Upload File"
            Me.btnOpen.Caption = "Open Files"
        End If
    End Sub

    Private Sub btnOpen_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles btnOpen.Execute
        OpenFile()
    End Sub
End Class
