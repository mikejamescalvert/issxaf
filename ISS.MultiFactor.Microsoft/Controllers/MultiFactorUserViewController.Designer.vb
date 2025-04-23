Partial Class MultiFactorUserViewController

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SetupMultifactor = New DevExpress.ExpressApp.Actions.PopupWindowShowAction(Me.components)
        Me.ClearMultifactorAuthentication = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'SetupMultifactor
        '
        Me.SetupMultifactor.AcceptButtonCaption = Nothing
        Me.SetupMultifactor.CancelButtonCaption = Nothing
        Me.SetupMultifactor.Caption = "Setup Multifactor Authentication"
        Me.SetupMultifactor.Category = "View"
        Me.SetupMultifactor.ConfirmationMessage = Nothing
        Me.SetupMultifactor.Id = "SetupMultifactor"
        Me.SetupMultifactor.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.SetupMultifactor.ToolTip = Nothing
        '
        'ClearMultifactorAuthentication
        '
        Me.ClearMultifactorAuthentication.Caption = "Clear Multifactor Authentication"
        Me.ClearMultifactorAuthentication.ConfirmationMessage = Nothing
        Me.ClearMultifactorAuthentication.Id = "ClearMultifactorAuthentication"
        Me.ClearMultifactorAuthentication.ToolTip = Nothing
        '
        'MultiFactorUserViewController
        '
        Me.Actions.Add(Me.SetupMultifactor)
        Me.Actions.Add(Me.ClearMultifactorAuthentication)

    End Sub

    Friend WithEvents SetupMultifactor As DevExpress.ExpressApp.Actions.PopupWindowShowAction
    Friend WithEvents ClearMultifactorAuthentication As DevExpress.ExpressApp.Actions.SimpleAction
End Class
