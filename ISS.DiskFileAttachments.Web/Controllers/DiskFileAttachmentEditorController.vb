Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class DiskFileAttachmentEditorController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 
        Me.TargetViewType = ViewType.DetailView
    End Sub

    Private Sub DiskFileAttachmentEditorController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        Dim ufsFileUploadStringEditor As FileUploadEditor
        Dim ufsFileUploadControl As FileUploadStringControl
        Dim ufsFileUploadEditor As FileUploadEditor
        If TypeOf View Is DetailView Then
            For Each ufsFileUploadStringEditor In CType(View, DetailView).GetItems(Of FileUploadEditor)()
                ufsFileUploadControl = ufsFileUploadStringEditor.Control
                If ufsFileUploadControl IsNot Nothing Then
                    RemoveHandler ufsFileUploadControl.FileUploadComplete, AddressOf _mFileUploadControl_FileUploadComplete
                    AddHandler ufsFileUploadControl.FileUploadComplete, AddressOf _mFileUploadControl_FileUploadComplete
                End If
            Next
        End If
    End Sub

    Private Sub _mFileUploadControl_FileUploadComplete(ByVal sender As Object, ByVal e As DevExpress.Web.FileUploadCompleteEventArgs)
        Dim ufsFileUploadControl As FileUploadStringControl = sender
        Dim ufsFileUploadEditor As FileUploadEditor
        Dim oFileData As ISSBaseDiskFileAttachment
        If ufsFileUploadControl.OwnerEditor IsNot Nothing Then
            ufsFileUploadEditor = ufsFileUploadControl.OwnerEditor
            oFileData = ufsFileUploadEditor.PropertyValue
            oFileData.UploadFile(e.UploadedFile.FileBytes, e.UploadedFile.FileName, True)
            e.ErrorText = "Success"
            e.IsValid = False

        Else
            Throw New Exception("Missing Editor Link In Child Control!")
        End If
    End Sub


End Class
