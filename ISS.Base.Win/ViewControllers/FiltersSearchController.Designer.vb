Partial Class FiltersSearchController

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
        Me.btnClearFilter = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Caption = "Clear Filter"
        Me.btnClearFilter.Category = "View"
        Me.btnClearFilter.ConfirmationMessage = Nothing
        Me.btnClearFilter.Id = "1dde362a-8b64-4f57-9aa4-1ad0373c381a"
        Me.btnClearFilter.ToolTip = Nothing
        '
        'FiltersSearchController
        '
        Me.TargetViewType = DevExpress.ExpressApp.ViewType.ListView
        Me.TypeOfView = GetType(DevExpress.ExpressApp.ListView)

    End Sub
    Friend WithEvents btnClearFilter As DevExpress.ExpressApp.Actions.SimpleAction

End Class
