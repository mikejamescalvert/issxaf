Partial Class OpenAttachmentController

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OpenAttachment = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.Attachments_UploadAttachment = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.Attachments_SaveAttachment = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'OpenAttachment
        '
        Me.OpenAttachment.Caption = "Open Attachment"
        Me.OpenAttachment.Category = "View"
        Me.OpenAttachment.ConfirmationMessage = Nothing
        Me.OpenAttachment.Id = "Attachments_OpenAttachment"
        Me.OpenAttachment.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.OpenAttachment.ToolTip = Nothing
        '
        'Attachments_UploadAttachment
        '
        Me.Attachments_UploadAttachment.Caption = "Upload Attachment"
        Me.Attachments_UploadAttachment.Category = "View"
        Me.Attachments_UploadAttachment.ConfirmationMessage = Nothing
        Me.Attachments_UploadAttachment.Id = "Attachments_UploadAttachment"
        Me.Attachments_UploadAttachment.ImageName = "BO_FileAttachment"
        Me.Attachments_UploadAttachment.TargetViewType = DevExpress.ExpressApp.ViewType.ListView
        Me.Attachments_UploadAttachment.ToolTip = Nothing
        Me.Attachments_UploadAttachment.TypeOfView = GetType(DevExpress.ExpressApp.ListView)
        '
        'Attachments_SaveAttachment
        '
        Me.Attachments_SaveAttachment.Caption = "Save Attachment"
        Me.Attachments_SaveAttachment.Category = "View"
        Me.Attachments_SaveAttachment.ConfirmationMessage = Nothing
        Me.Attachments_SaveAttachment.Id = "Attachments_SaveAttachment"
        Me.Attachments_SaveAttachment.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.Attachments_SaveAttachment.ToolTip = Nothing
        '
        'OpenAttachmentController
        '
        Me.Actions.Add(Me.OpenAttachment)
        Me.Actions.Add(Me.Attachments_UploadAttachment)
        Me.Actions.Add(Me.Attachments_SaveAttachment)

    End Sub

    Friend WithEvents OpenAttachment As DevExpress.ExpressApp.Actions.SimpleAction
    Public ReadOnly Property OpenAttachment_Action As DevExpress.ExpressApp.Actions.SimpleAction
        Get
            Return OpenAttachment
        End Get
    End Property
    Friend WithEvents Attachments_UploadAttachment As DevExpress.ExpressApp.Actions.SimpleAction
    Public ReadOnly Property Attachments_UploadAttachment_Action As DevExpress.ExpressApp.Actions.SimpleAction
        Get
            Return Attachments_UploadAttachment
        End Get
    End Property
    Friend WithEvents Attachments_SaveAttachment As DevExpress.ExpressApp.Actions.SimpleAction
    Public ReadOnly Property Attachments_SaveAttachment_Action As DevExpress.ExpressApp.Actions.SimpleAction
        Get
            Return Attachments_SaveAttachment
        End Get
    End Property
End Class
