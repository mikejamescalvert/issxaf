Partial Class MPConnectionController

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
        Me.MPConnectionInformation_Test = New DevExpress.ExpressApp.Actions.SimpleAction(components)
        Me.MPConnectionInformation_Save = New DevExpress.ExpressApp.Actions.SimpleAction(components)
        '
        'MPConnectionInformation_Test
        '
        Me.MPConnectionInformation_Test.Caption = "Test Connection"
        Me.MPConnectionInformation_Test.Category = "MPConnectionInformationActions"
        Me.MPConnectionInformation_Test.ConfirmationMessage = Nothing
        Me.MPConnectionInformation_Test.Id = "MPConnectionInformation_Test"
        Me.MPConnectionInformation_Test.ImageName = Nothing
        Me.MPConnectionInformation_Test.Shortcut = Nothing
        Me.MPConnectionInformation_Test.Tag = Nothing
        Me.MPConnectionInformation_Test.TargetObjectsCriteria = Nothing
        Me.MPConnectionInformation_Test.TargetViewId = Nothing
        Me.MPConnectionInformation_Test.ToolTip = Nothing
        Me.MPConnectionInformation_Test.TypeOfView = Nothing
        '
        'MPConnectionInformation_Save
        '
        Me.MPConnectionInformation_Save.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept
        Me.MPConnectionInformation_Save.Caption = "Save Connection"
        Me.MPConnectionInformation_Save.Category = "MPConnectionInformationActions"
        Me.MPConnectionInformation_Save.ConfirmationMessage = "You will have to restart your application for the settings to take effect."
        Me.MPConnectionInformation_Save.Id = "MPConnectionInformation_Save"
        Me.MPConnectionInformation_Save.ImageName = Nothing
        Me.MPConnectionInformation_Save.Shortcut = Nothing
        Me.MPConnectionInformation_Save.Tag = Nothing
        Me.MPConnectionInformation_Save.TargetObjectsCriteria = Nothing
        Me.MPConnectionInformation_Save.TargetViewId = Nothing
        Me.MPConnectionInformation_Save.ToolTip = Nothing
        Me.MPConnectionInformation_Save.TypeOfView = Nothing

    End Sub
    Friend WithEvents MPConnectionInformation_Test As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents MPConnectionInformation_Save As DevExpress.ExpressApp.Actions.SimpleAction

End Class
