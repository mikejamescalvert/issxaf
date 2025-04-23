Partial Class ToolViewController

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
        Me.Tools_RecalculateTotals = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'Tools_RecalculateTotals
        '
        Me.Tools_RecalculateTotals.Caption = "Recalculate Totals"
        Me.Tools_RecalculateTotals.Category = "Tools"
        Me.Tools_RecalculateTotals.ConfirmationMessage = Nothing
        Me.Tools_RecalculateTotals.Id = "Tools_RecalculateTotals"
        Me.Tools_RecalculateTotals.ImageName = Nothing
        Me.Tools_RecalculateTotals.Shortcut = Nothing
        Me.Tools_RecalculateTotals.Tag = Nothing
        Me.Tools_RecalculateTotals.TargetObjectsCriteria = Nothing
        Me.Tools_RecalculateTotals.TargetViewId = Nothing
        Me.Tools_RecalculateTotals.ToolTip = Nothing
        Me.Tools_RecalculateTotals.TypeOfView = Nothing

End Sub
 Friend WithEvents Tools_RecalculateTotals As DevExpress.ExpressApp.Actions.SimpleAction

End Class
