Partial Class CopyAttachmentListViewController

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
        Me.Attachments_CopyInformation = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'Attachments_CopyInformation
        '
        Me.Attachments_CopyInformation.Caption = "Copy To Clipboard"
        Me.Attachments_CopyInformation.Category = "View"
        Me.Attachments_CopyInformation.ConfirmationMessage = Nothing
        Me.Attachments_CopyInformation.Id = "Attachments_CopyInformation"
        Me.Attachments_CopyInformation.ToolTip = Nothing
        '
        'CopyAttachmentController
        '
        Me.Actions.Add(Me.Attachments_CopyInformation)

    End Sub

    Friend WithEvents Attachments_CopyInformation As DevExpress.ExpressApp.Actions.SimpleAction
    Public ReadOnly Property Attachments_CopyInformation_Action As DevExpress.ExpressApp.Actions.SimpleAction
        Get
            Return Attachments_CopyInformation
        End Get
    End Property
End Class
