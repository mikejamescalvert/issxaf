Partial Class ResetUserXAFMLController

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
        Me.btnResetXML = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'btnResetXML
        '
        Me.btnResetXML.Caption = "Reset User Settings"
        Me.btnResetXML.Category = "Options"
        Me.btnResetXML.ConfirmationMessage = "Are you sure you want to reset your settings?  This will cause an application res" & _
            "tart."
        Me.btnResetXML.Id = "7a46b9ac-4592-4b0c-84dd-44570c918bfe"
        Me.btnResetXML.ImageName = "Action_Reload"
        Me.btnResetXML.Shortcut = Nothing
        Me.btnResetXML.Tag = Nothing
        Me.btnResetXML.TargetObjectsCriteria = Nothing
        Me.btnResetXML.TargetViewId = Nothing
        Me.btnResetXML.ToolTip = Nothing
        Me.btnResetXML.TypeOfView = Nothing
        '
        'ResetUserXAFMLController
        '
        Me.TargetWindowType = DevExpress.ExpressApp.WindowType.Main

    End Sub
    Friend WithEvents btnResetXML As DevExpress.ExpressApp.Actions.SimpleAction

End Class
