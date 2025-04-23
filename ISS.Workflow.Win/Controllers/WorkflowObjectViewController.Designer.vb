Partial Class WorkflowObjectViewController

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
        Me.Workflow_Unlock = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'Workflow_Unlock
        '
        Me.Workflow_Unlock.Caption = "Unlock Workflow"
        Me.Workflow_Unlock.Category = "View"
        Me.Workflow_Unlock.ConfirmationMessage = Nothing
        Me.Workflow_Unlock.Id = "Workflow_Unlock"
        Me.Workflow_Unlock.ImageName = Nothing
        Me.Workflow_Unlock.Shortcut = Nothing
        Me.Workflow_Unlock.Tag = Nothing
        Me.Workflow_Unlock.TargetObjectsCriteria = Nothing
        Me.Workflow_Unlock.TargetViewId = Nothing
        Me.Workflow_Unlock.ToolTip = Nothing
        Me.Workflow_Unlock.TypeOfView = Nothing

End Sub
 Friend WithEvents Workflow_Unlock As DevExpress.ExpressApp.Actions.SimpleAction

End Class
