Partial Class AutoRefreshListViewController

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
        Me.AutoRefreshRateInSeconds = New DevExpress.ExpressApp.Actions.ParametrizedAction(Me.components)
        '
        'AutoRefreshRateInSeconds
        '
        Me.AutoRefreshRateInSeconds.Caption = "Update Refresh Rate"
        Me.AutoRefreshRateInSeconds.Category = "View"
        Me.AutoRefreshRateInSeconds.ConfirmationMessage = Nothing
        Me.AutoRefreshRateInSeconds.Id = "AutoRefreshRateInSeconds"
        Me.AutoRefreshRateInSeconds.NullValuePrompt = Nothing
        Me.AutoRefreshRateInSeconds.ShortCaption = Nothing
        Me.AutoRefreshRateInSeconds.ToolTip = Nothing
        '
        'AutoRefreshListViewController
        '
        Me.Actions.Add(Me.AutoRefreshRateInSeconds)
        Me.TargetViewType = DevExpress.ExpressApp.ViewType.ListView
        Me.TypeOfView = GetType(DevExpress.ExpressApp.ListView)

    End Sub
    Friend WithEvents AutoRefreshRateInSeconds As DevExpress.ExpressApp.Actions.ParametrizedAction

End Class
