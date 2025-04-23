<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentManagerControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DocumentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.WidgetView1 = New DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(Me.components)
        CType(Me.DocumentManager1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.WidgetView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DocumentManager1
        '
        Me.DocumentManager1.ContainerControl = Me
        Me.DocumentManager1.View = Me.WidgetView1
        Me.DocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.WidgetView1})
        '
        'DocumentManagerControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DocumentManagerControl"
        Me.Size = New System.Drawing.Size(889, 506)
        CType(Me.DocumentManager1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.WidgetView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents DocumentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents WidgetView1 As DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView

End Class
