Partial Class OnDemandNotificationViewController

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
        Me.Notifications_SendNotification = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
        Me.Notifications_SendNotificationBatchSelectedRows = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
        '
        'Notifications_SendNotification
        '
        Me.Notifications_SendNotification.Caption = "Generate Notification"
        Me.Notifications_SendNotification.Category = "View"
        Me.Notifications_SendNotification.ConfirmationMessage = Nothing
        Me.Notifications_SendNotification.Id = "Notifications_SendNotification"
        Me.Notifications_SendNotification.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
        Me.Notifications_SendNotification.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.Notifications_SendNotification.ShowItemsOnClick = True
        Me.Notifications_SendNotification.ToolTip = "Generate Notification for the current object and show window to allow for changes" &
    " to notification details"
        '
        'Notifications_SendNotificationBatchSelectedRows
        '
        Me.Notifications_SendNotificationBatchSelectedRows.Caption = "Generate Notification Batch For Qualifying Selected Rows"
        Me.Notifications_SendNotificationBatchSelectedRows.Category = "View"
        Me.Notifications_SendNotificationBatchSelectedRows.ConfirmationMessage = Nothing
        Me.Notifications_SendNotificationBatchSelectedRows.Id = "Notifications_SendNotificationBatchNotifications_SendNotificationBatchSelectedRow" &
    "s"
        Me.Notifications_SendNotificationBatchSelectedRows.ImageName = "ArrangeInRows"
        Me.Notifications_SendNotificationBatchSelectedRows.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
        Me.Notifications_SendNotificationBatchSelectedRows.ShowItemsOnClick = True
        Me.Notifications_SendNotificationBatchSelectedRows.ToolTip = "Generate Notification Batch for Selected Rows that meet the notification rule cri" &
    "teria"
        '
        'Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects
        '
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.Caption = "Generate Notification Batch For All Qualifying Objects"
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.Category = "View"
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.ConfirmationMessage = Nothing
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.Id = "Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects"
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.ImageName = "SelectAll"
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.ShowItemsOnClick = True
        Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects.ToolTip = "Generate Notification Batch for all objects that meet notification rule criteria"
        '
        'OnDemandNotificationViewController
        '
        Me.Actions.Add(Me.Notifications_SendNotification)
        Me.Actions.Add(Me.Notifications_SendNotificationBatchSelectedRows)
        Me.Actions.Add(Me.Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects)

    End Sub

    Friend WithEvents Notifications_SendNotification As DevExpress.ExpressApp.Actions.SingleChoiceAction
    Friend WithEvents Notifications_SendNotificationBatchSelectedRows As DevExpress.ExpressApp.Actions.SingleChoiceAction
    Friend WithEvents Notifications_SendNotificationBatchNotifications_SendNotificationBatchAllObjects As DevExpress.ExpressApp.Actions.SingleChoiceAction
End Class
