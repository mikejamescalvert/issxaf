Partial Class ToolsViewController
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
        Me.Notifications_ProcessQueue = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.Notifications_GenerateNotifications = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'Notifications_ProcessQueue
        '
        Me.Notifications_ProcessQueue.Caption = "Process Notification Queue"
        Me.Notifications_ProcessQueue.Category = "Tools"
        Me.Notifications_ProcessQueue.ConfirmationMessage = Nothing
        Me.Notifications_ProcessQueue.Id = "Notifications_ProcessQueue"
        Me.Notifications_ProcessQueue.ImageName = "Action_SimpleAction"
        Me.Notifications_ProcessQueue.ToolTip = Nothing
        '
        'Notifications_GenerateNotifications
        '
        Me.Notifications_GenerateNotifications.Caption = "Generate Notifications"
        Me.Notifications_GenerateNotifications.Category = "Tools"
        Me.Notifications_GenerateNotifications.ConfirmationMessage = Nothing
        Me.Notifications_GenerateNotifications.Id = "Notifications_GenerateNotifications"
        Me.Notifications_GenerateNotifications.ImageName = "Action_SimpleAction"
        Me.Notifications_GenerateNotifications.ToolTip = Nothing
        '
        'ToolsWindowController
        '
        Me.Actions.Add(Me.Notifications_ProcessQueue)
        Me.Actions.Add(Me.Notifications_GenerateNotifications)

End Sub

    Friend WithEvents Notifications_ProcessQueue As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents Notifications_GenerateNotifications As DevExpress.ExpressApp.Actions.SimpleAction
End Class
