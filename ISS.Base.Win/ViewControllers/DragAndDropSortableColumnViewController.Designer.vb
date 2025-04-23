Partial Class DragAndDropSortableColumnViewController

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DragAndDropSort_MoveRecordDown = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.DragAndDropSort_MoveRecordUp = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.DragAndDropSort_EnableResequencing = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'DragAndDropSort_MoveRecordDown
        '
        Me.DragAndDropSort_MoveRecordDown.Caption = "Move Record Down"
        Me.DragAndDropSort_MoveRecordDown.Category = "Sequencing"
        Me.DragAndDropSort_MoveRecordDown.ConfirmationMessage = Nothing
        Me.DragAndDropSort_MoveRecordDown.Id = "DragAndDropSort_MoveRecordDown"
        Me.DragAndDropSort_MoveRecordDown.ToolTip = Nothing
        '
        'DragAndDropSort_MoveRecordUp
        '
        Me.DragAndDropSort_MoveRecordUp.Caption = "Move Record Up"
        Me.DragAndDropSort_MoveRecordUp.Category = "Sequencing"
        Me.DragAndDropSort_MoveRecordUp.ConfirmationMessage = Nothing
        Me.DragAndDropSort_MoveRecordUp.Id = "DragAndDropSort_MoveRecordUp"
        Me.DragAndDropSort_MoveRecordUp.ToolTip = Nothing
        '
        'DragAndDropSort_EnableResequencing
        '
        Me.DragAndDropSort_EnableResequencing.Caption = "Enable ReSequencing"
        Me.DragAndDropSort_EnableResequencing.Category = "Sequencing"
        Me.DragAndDropSort_EnableResequencing.ConfirmationMessage = Nothing
        Me.DragAndDropSort_EnableResequencing.Id = "DragAndDropSort_EnableResequencing"
        Me.DragAndDropSort_EnableResequencing.ToolTip = Nothing
        '
        'DragAndDropSortableColumnViewController
        '
        Me.Actions.Add(Me.DragAndDropSort_MoveRecordDown)
        Me.Actions.Add(Me.DragAndDropSort_MoveRecordUp)
        Me.Actions.Add(Me.DragAndDropSort_EnableResequencing)

    End Sub

    Friend WithEvents DragAndDropSort_MoveRecordDown As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents DragAndDropSort_MoveRecordUp As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents DragAndDropSort_EnableResequencing As DevExpress.ExpressApp.Actions.SimpleAction
End Class
