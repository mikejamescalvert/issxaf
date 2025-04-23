Partial Class DiskFileAttachmentController

	<System.Diagnostics.DebuggerNonUserCode()> _
	Public Sub New(ByVal Container As System.ComponentModel.IContainer)
		MyClass.New()

		'Required for Windows.Forms Class Composition Designer support
		Container.Add(Me)

	End Sub

	'Component overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso components IsNot Nothing Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Component Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Component Designer
	'It can be modified using the Component Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnUploadDiskFile = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.btnDownloadDiskFile = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.btnDeleteDiskFile = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.btnOpen = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'btnUploadDiskFile
        '
        Me.btnUploadDiskFile.Caption = "Upload File"
        Me.btnUploadDiskFile.Category = "RecordEdit"
        Me.btnUploadDiskFile.Id = "btnUploadDiskFile"
        Me.btnUploadDiskFile.ImageName = "upload"
        Me.btnUploadDiskFile.Tag = Nothing
        Me.btnUploadDiskFile.TypeOfView = Nothing
        '
        'btnDownloadDiskFile
        '
        Me.btnDownloadDiskFile.Caption = "Download File"
        Me.btnDownloadDiskFile.Category = "RecordEdit"
        Me.btnDownloadDiskFile.Id = "btnDownloadDiskFile"
        Me.btnDownloadDiskFile.ImageName = "download"
        Me.btnDownloadDiskFile.Tag = Nothing
        Me.btnDownloadDiskFile.TypeOfView = Nothing
        '
        'btnDeleteDiskFile
        '
        Me.btnDeleteDiskFile.Caption = "Delete File"
        Me.btnDeleteDiskFile.Category = "RecordEdit"
        Me.btnDeleteDiskFile.ConfirmationMessage = "Are you sure you want to delete the selected files?"
        Me.btnDeleteDiskFile.Id = "btnDeleteDiskFile"
        Me.btnDeleteDiskFile.ImageName = "burnfile"
        Me.btnDeleteDiskFile.Tag = Nothing
        Me.btnDeleteDiskFile.TypeOfView = Nothing
        '
        'btnOpen
        '
        Me.btnOpen.Caption = "Open File"
        Me.btnOpen.Category = "RecordEdit"
        Me.btnOpen.Id = "1e685660-dd44-4fba-b86d-61193517b0bf"
        Me.btnOpen.ImageName = "open"
        Me.btnOpen.Tag = Nothing
        Me.btnOpen.TypeOfView = Nothing

    End Sub
    Friend WithEvents btnUploadDiskFile As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents btnDownloadDiskFile As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents btnDeleteDiskFile As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents btnOpen As DevExpress.ExpressApp.Actions.SimpleAction

End Class
