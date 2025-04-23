Partial Class DragAndDropListViewController

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
        Me.components = New System.ComponentModel.Container()
		Me.Attachments_PasteInformation = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
		'
		'Attachments_PasteInformation
		'
		Me.Attachments_PasteInformation.Caption = "Paste From Clipboard"
		Me.Attachments_PasteInformation.Category = "View"
		Me.Attachments_PasteInformation.ConfirmationMessage = Nothing
		Me.Attachments_PasteInformation.Id = "Attachments_PasteInformation"
		Me.Attachments_PasteInformation.ImageName = "Action_FileAttachment_Attach"
		Me.Attachments_PasteInformation.IsExecuting = False
		Me.Attachments_PasteInformation.ToolTip = Nothing

	End Sub
	Friend WithEvents Attachments_PasteInformation As DevExpress.ExpressApp.Actions.SimpleAction
	ReadOnly Property Attachments_PasteInformation_Action As DevExpress.ExpressApp.Actions.SimpleAction
		Get
			Return Attachments_PasteInformation
		End Get
	End Property

End Class
