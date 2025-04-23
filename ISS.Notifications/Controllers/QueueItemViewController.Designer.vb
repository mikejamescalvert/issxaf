Partial Class QueueItemViewController

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
        Me.QueueItem_ProcessNotifications = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'QueueItem_ProcessNotifications
        '
        Me.QueueItem_ProcessNotifications.Caption = "Process Notifications"
        Me.QueueItem_ProcessNotifications.Category = "View"
        Me.QueueItem_ProcessNotifications.ConfirmationMessage = Nothing
        Me.QueueItem_ProcessNotifications.Id = "QueueItem_ProcessNotifications"
        Me.QueueItem_ProcessNotifications.ToolTip = Nothing
        '
        'QueueItemViewController
        '
        Me.Actions.Add(Me.QueueItem_ProcessNotifications)

End Sub
    Friend WithEvents QueueItem_ProcessNotifications As DevExpress.ExpressApp.Actions.SimpleAction
End Class
