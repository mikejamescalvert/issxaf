Partial Class IReportDataViewController

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
        Me.ReportData_ImportReports = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.ReportData_ExportReports = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'ReportData_ImportReports
        '
        Me.ReportData_ImportReports.Caption = "Import Reports"
        Me.ReportData_ImportReports.Category = "Reports"
        Me.ReportData_ImportReports.ConfirmationMessage = Nothing
        Me.ReportData_ImportReports.Id = "ReportData_ImportReports"
        Me.ReportData_ImportReports.ImageName = "Action_Chart_Printing_Preview"
        Me.ReportData_ImportReports.IsExecuting = false
        Me.ReportData_ImportReports.ToolTip = Nothing
        '
        'ReportData_ExportReports
        '
        Me.ReportData_ExportReports.Caption = "Export Reports"
        Me.ReportData_ExportReports.Category = "Reports"
        Me.ReportData_ExportReports.ConfirmationMessage = Nothing
        Me.ReportData_ExportReports.Id = "ReportData_ExportReports"
        Me.ReportData_ExportReports.ImageName = "Action_Export"
        Me.ReportData_ExportReports.IsExecuting = false
        Me.ReportData_ExportReports.ToolTip = Nothing

End Sub
 Friend WithEvents ReportData_ImportReports As DevExpress.ExpressApp.Actions.SimpleAction
 Friend WithEvents ReportData_ExportReports As DevExpress.ExpressApp.Actions.SimpleAction

End Class
