Partial Class EditorOptionsDetailViewController

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
        Me.Help_NeedHelp = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'Help_NeedHelp
        '
        Me.Help_NeedHelp.Caption = "Need Help?"
        Me.Help_NeedHelp.Category = "Tools"
        Me.Help_NeedHelp.ConfirmationMessage = Nothing
        Me.Help_NeedHelp.Id = "Help_NeedHelp"
        Me.Help_NeedHelp.ImageName = "Action_AboutInfo"
        Me.Help_NeedHelp.ToolTip = Nothing
        '
        'EditorOptionsDetailViewController
        '
        Me.Actions.Add(Me.Help_NeedHelp)

End Sub

    Friend WithEvents Help_NeedHelp As DevExpress.ExpressApp.Actions.SimpleAction
End Class
