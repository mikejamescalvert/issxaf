Partial Class ResetConnectionWindowController
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
        Me.MasterProvider_ResetConnections = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'MasterProvider_ResetConnections
        '
        Me.MasterProvider_ResetConnections.Caption = "Reset Application Connections"
        Me.MasterProvider_ResetConnections.Category = "Tools"
        Me.MasterProvider_ResetConnections.ConfirmationMessage = "Are you sure you want to reset your connection information and close the applicat" & _
            "ion?"
        Me.MasterProvider_ResetConnections.Id = "MasterProvider_ResetConnections"
        Me.MasterProvider_ResetConnections.ImageName = "Action_Reload"
        Me.MasterProvider_ResetConnections.Shortcut = Nothing
        Me.MasterProvider_ResetConnections.Tag = Nothing
        Me.MasterProvider_ResetConnections.TargetObjectsCriteria = Nothing
        Me.MasterProvider_ResetConnections.TargetViewId = Nothing
        Me.MasterProvider_ResetConnections.ToolTip = Nothing
        Me.MasterProvider_ResetConnections.TypeOfView = Nothing

    End Sub
    Friend WithEvents MasterProvider_ResetConnections As DevExpress.ExpressApp.Actions.SimpleAction

End Class
