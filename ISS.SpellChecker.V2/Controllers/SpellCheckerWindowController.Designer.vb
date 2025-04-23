Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base

Partial Public Class SpellCheckerWindowController
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
        Me.CheckSpellingAction = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'CheckSpellingAction
        '
        Me.CheckSpellingAction.Caption = "Check Spelling"
        Me.CheckSpellingAction.Category = "RecordEdit"
        Me.CheckSpellingAction.ConfirmationMessage = Nothing
        Me.CheckSpellingAction.Id = "e3d61ff7-bbea-4741-b083-6bbfe0e38749"
        Me.CheckSpellingAction.ImageName = "SpellCheck"
        Me.CheckSpellingAction.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView
        Me.CheckSpellingAction.ToolTip = "Check the spelling and grammar of text in the form."
        Me.CheckSpellingAction.TypeOfView = GetType(DevExpress.ExpressApp.DetailView)
        '
        'SpellCheckerWindowController
        '
        Me.Actions.Add(Me.CheckSpellingAction)

    End Sub

    Public WithEvents CheckSpellingAction As DevExpress.ExpressApp.Actions.SimpleAction
End Class
