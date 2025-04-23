<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackgroundProcessForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ProgressBarControl = New DevExpress.XtraEditors.ProgressBarControl
        Me.ProgressLabel = New DevExpress.XtraEditors.LabelControl
        Me.bgwMethodExecuter = New System.ComponentModel.BackgroundWorker
        CType(Me.ProgressBarControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarControl
        '
        Me.ProgressBarControl.Location = New System.Drawing.Point(12, 29)
        Me.ProgressBarControl.Name = "ProgressBarControl"
        Me.ProgressBarControl.Size = New System.Drawing.Size(305, 18)
        Me.ProgressBarControl.TabIndex = 0
        '
        'ProgressLabel
        '
        Me.ProgressLabel.Appearance.Options.UseTextOptions = True
        Me.ProgressLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ProgressLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.ProgressLabel.Location = New System.Drawing.Point(12, 10)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(305, 13)
        Me.ProgressLabel.TabIndex = 1
        Me.ProgressLabel.Text = "Processing"
        '
        'bgwMethodExecuter
        '
        '
        'BackgroundProcessForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 59)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.ProgressBarControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "BackgroundProcessForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.ProgressBarControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBarControl As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents ProgressLabel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bgwMethodExecuter As System.ComponentModel.BackgroundWorker
End Class
