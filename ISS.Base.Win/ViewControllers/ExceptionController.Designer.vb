Partial Class ExceptionController

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
        Me.ExceptionClearLog = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.ExceptionSendToSupport = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.ExceptionViewLog = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'ExceptionClearLog
        '
        Me.ExceptionClearLog.Caption = "Clear Exception Log"
        Me.ExceptionClearLog.Category = "Tools"
        Me.ExceptionClearLog.ConfirmationMessage = "Are you sure you want to clear your exception log?"
        Me.ExceptionClearLog.Id = "ExceptionClearLog"
        Me.ExceptionClearLog.ImageName = "Action_Delete"
        Me.ExceptionClearLog.ToolTip = Nothing
        '
        'ExceptionSendToSupport
        '
        Me.ExceptionSendToSupport.Caption = "Send Exceptions To Support"
        Me.ExceptionSendToSupport.Category = "Tools"
        Me.ExceptionSendToSupport.Id = "ExceptionSendToSupport"
        Me.ExceptionSendToSupport.ImageName = "BO_Localization"
        Me.ExceptionSendToSupport.ToolTip = Nothing
        '
        'ExceptionViewLog
        '
        Me.ExceptionViewLog.Caption = "View Exception Log"
        Me.ExceptionViewLog.Category = "Tools"
        Me.ExceptionViewLog.Id = "ExceptionViewLog"
        Me.ExceptionViewLog.ImageName = "BO_List"
        Me.ExceptionViewLog.ToolTip = Nothing

    End Sub
    Friend WithEvents ExceptionClearLog As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents ExceptionSendToSupport As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents ExceptionViewLog As DevExpress.ExpressApp.Actions.SimpleAction

End Class
