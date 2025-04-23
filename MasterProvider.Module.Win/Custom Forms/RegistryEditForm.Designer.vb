<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegistryEditForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grcConnectionGridControl = New DevExpress.XtraGrid.GridControl()
        Me.grvConnectionGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnContinueToApplication = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelChanges = New DevExpress.XtraEditors.SimpleButton()
        Me.grpConnectionGroup = New DevExpress.XtraEditors.GroupControl()
        Me.lctConnectionInfoLayout = New DevExpress.XtraLayout.LayoutControl()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.chkTrusted = New DevExpress.XtraEditors.CheckEdit()
        Me.txtDB = New DevExpress.XtraEditors.TextEdit()
        Me.txtServer = New DevExpress.XtraEditors.TextEdit()
        Me.txtAccessDBLocation = New DevExpress.XtraEditors.TextEdit()
        Me.txtURL = New DevExpress.XtraEditors.TextEdit()
        Me.cbeConnectionType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnTestConnection = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSaveConnection = New DevExpress.XtraEditors.SimpleButton()
        Me.lcgConnectionGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciConnectionType = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciTestButton = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciSaveButton = New DevExpress.XtraLayout.LayoutControlItem()
        Me.esiButtonAlign = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lciURL = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciDBLocation = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciServer = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciDatabase = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciTrusted = New DevExpress.XtraLayout.LayoutControlItem()
        Me.esiTrusted = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lciUsername = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPassword = New DevExpress.XtraLayout.LayoutControlItem()
        Me.esiButtonSpace = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.grcConnectionGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvConnectionGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpConnectionGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpConnectionGroup.SuspendLayout()
        CType(Me.lctConnectionInfoLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lctConnectionInfoLayout.SuspendLayout()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTrusted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccessDBLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtURL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbeConnectionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgConnectionGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciConnectionType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciTestButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciSaveButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.esiButtonAlign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciURL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDBLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciServer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciTrusted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.esiTrusted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciUsername, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.esiButtonSpace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grcConnectionGridControl
        '
        Me.grcConnectionGridControl.Location = New System.Drawing.Point(12, 12)
        Me.grcConnectionGridControl.MainView = Me.grvConnectionGridView
        Me.grcConnectionGridControl.Name = "grcConnectionGridControl"
        Me.grcConnectionGridControl.Size = New System.Drawing.Size(308, 275)
        Me.grcConnectionGridControl.TabIndex = 0
        Me.grcConnectionGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvConnectionGridView})
        '
        'grvConnectionGridView
        '
        Me.grvConnectionGridView.GridControl = Me.grcConnectionGridControl
        Me.grvConnectionGridView.Name = "grvConnectionGridView"
        Me.grvConnectionGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvConnectionGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grvConnectionGridView.OptionsBehavior.Editable = False
        '
        'btnContinueToApplication
        '
        Me.btnContinueToApplication.Enabled = False
        Me.btnContinueToApplication.Location = New System.Drawing.Point(624, 294)
        Me.btnContinueToApplication.Name = "btnContinueToApplication"
        Me.btnContinueToApplication.Size = New System.Drawing.Size(75, 23)
        Me.btnContinueToApplication.TabIndex = 10
        Me.btnContinueToApplication.Text = "Continue"
        '
        'btnCancelChanges
        '
        Me.btnCancelChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelChanges.Location = New System.Drawing.Point(543, 294)
        Me.btnCancelChanges.Name = "btnCancelChanges"
        Me.btnCancelChanges.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelChanges.TabIndex = 11
        Me.btnCancelChanges.Text = "Cancel"
        '
        'grpConnectionGroup
        '
        Me.grpConnectionGroup.Controls.Add(Me.lctConnectionInfoLayout)
        Me.grpConnectionGroup.Location = New System.Drawing.Point(326, 12)
        Me.grpConnectionGroup.Name = "grpConnectionGroup"
        Me.grpConnectionGroup.Size = New System.Drawing.Size(373, 276)
        Me.grpConnectionGroup.TabIndex = 3
        Me.grpConnectionGroup.Text = "Connection Information"
        '
        'lctConnectionInfoLayout
        '
        Me.lctConnectionInfoLayout.Controls.Add(Me.txtPassword)
        Me.lctConnectionInfoLayout.Controls.Add(Me.txtUsername)
        Me.lctConnectionInfoLayout.Controls.Add(Me.chkTrusted)
        Me.lctConnectionInfoLayout.Controls.Add(Me.txtDB)
        Me.lctConnectionInfoLayout.Controls.Add(Me.txtServer)
        Me.lctConnectionInfoLayout.Controls.Add(Me.txtAccessDBLocation)
        Me.lctConnectionInfoLayout.Controls.Add(Me.txtURL)
        Me.lctConnectionInfoLayout.Controls.Add(Me.cbeConnectionType)
        Me.lctConnectionInfoLayout.Controls.Add(Me.btnTestConnection)
        Me.lctConnectionInfoLayout.Controls.Add(Me.btnSaveConnection)
        Me.lctConnectionInfoLayout.Location = New System.Drawing.Point(5, 25)
        Me.lctConnectionInfoLayout.Name = "lctConnectionInfoLayout"
        Me.lctConnectionInfoLayout.Root = Me.lcgConnectionGroup
        Me.lctConnectionInfoLayout.Size = New System.Drawing.Size(359, 250)
        Me.lctConnectionInfoLayout.TabIndex = 0
        Me.lctConnectionInfoLayout.Text = "LayoutControl1"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(105, 180)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(242, 20)
        Me.txtPassword.StyleController = Me.lctConnectionInfoLayout
        Me.txtPassword.TabIndex = 7
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(105, 156)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(242, 20)
        Me.txtUsername.StyleController = Me.lctConnectionInfoLayout
        Me.txtUsername.TabIndex = 6
        '
        'chkTrusted
        '
        Me.chkTrusted.Location = New System.Drawing.Point(103, 132)
        Me.chkTrusted.Name = "chkTrusted"
        Me.chkTrusted.Properties.Caption = "Trusted Connection"
        Me.chkTrusted.Size = New System.Drawing.Size(244, 20)
        Me.chkTrusted.StyleController = Me.lctConnectionInfoLayout
        Me.chkTrusted.TabIndex = 5
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(105, 108)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(242, 20)
        Me.txtDB.StyleController = Me.lctConnectionInfoLayout
        Me.txtDB.TabIndex = 4
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(105, 84)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(242, 20)
        Me.txtServer.StyleController = Me.lctConnectionInfoLayout
        Me.txtServer.TabIndex = 3
        '
        'txtAccessDBLocation
        '
        Me.txtAccessDBLocation.Location = New System.Drawing.Point(105, 60)
        Me.txtAccessDBLocation.Name = "txtAccessDBLocation"
        Me.txtAccessDBLocation.Size = New System.Drawing.Size(242, 20)
        Me.txtAccessDBLocation.StyleController = Me.lctConnectionInfoLayout
        Me.txtAccessDBLocation.TabIndex = 2
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(105, 36)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(242, 20)
        Me.txtURL.StyleController = Me.lctConnectionInfoLayout
        Me.txtURL.TabIndex = 1
        '
        'cbeConnectionType
        '
        Me.cbeConnectionType.EditValue = "SQL"
        Me.cbeConnectionType.Location = New System.Drawing.Point(105, 12)
        Me.cbeConnectionType.Name = "cbeConnectionType"
        Me.cbeConnectionType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeConnectionType.Properties.Items.AddRange(New Object() {"SQL", "Webservice", "Access DB"})
        Me.cbeConnectionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeConnectionType.Size = New System.Drawing.Size(242, 20)
        Me.cbeConnectionType.StyleController = Me.lctConnectionInfoLayout
        Me.cbeConnectionType.TabIndex = 0
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(149, 216)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(96, 22)
        Me.btnTestConnection.StyleController = Me.lctConnectionInfoLayout
        Me.btnTestConnection.TabIndex = 8
        Me.btnTestConnection.Text = "Test"
        '
        'btnSaveConnection
        '
        Me.btnSaveConnection.Enabled = False
        Me.btnSaveConnection.Location = New System.Drawing.Point(249, 216)
        Me.btnSaveConnection.Name = "btnSaveConnection"
        Me.btnSaveConnection.Size = New System.Drawing.Size(98, 22)
        Me.btnSaveConnection.StyleController = Me.lctConnectionInfoLayout
        Me.btnSaveConnection.TabIndex = 9
        Me.btnSaveConnection.Text = "Save"
        '
        'lcgConnectionGroup
        '
        Me.lcgConnectionGroup.CustomizationFormText = "lcgConnectionGroup"
        Me.lcgConnectionGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.lcgConnectionGroup.GroupBordersVisible = False
        Me.lcgConnectionGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciConnectionType, Me.lciTestButton, Me.lciSaveButton, Me.esiButtonAlign, Me.lciURL, Me.lciDBLocation, Me.lciServer, Me.lciDatabase, Me.lciTrusted, Me.esiTrusted, Me.lciUsername, Me.lciPassword, Me.esiButtonSpace})
        Me.lcgConnectionGroup.Name = "lcgConnectionGroup"
        Me.lcgConnectionGroup.Size = New System.Drawing.Size(359, 250)
        Me.lcgConnectionGroup.TextVisible = False
        '
        'lciConnectionType
        '
        Me.lciConnectionType.Control = Me.cbeConnectionType
        Me.lciConnectionType.CustomizationFormText = "Connection Type"
        Me.lciConnectionType.Location = New System.Drawing.Point(0, 0)
        Me.lciConnectionType.Name = "lciConnectionType"
        Me.lciConnectionType.Size = New System.Drawing.Size(339, 24)
        Me.lciConnectionType.Text = "Connection Type"
        Me.lciConnectionType.TextSize = New System.Drawing.Size(81, 13)
        '
        'lciTestButton
        '
        Me.lciTestButton.Control = Me.btnTestConnection
        Me.lciTestButton.CustomizationFormText = "lciTestButton"
        Me.lciTestButton.Location = New System.Drawing.Point(137, 204)
        Me.lciTestButton.Name = "lciTestButton"
        Me.lciTestButton.Size = New System.Drawing.Size(100, 26)
        Me.lciTestButton.TextSize = New System.Drawing.Size(0, 0)
        Me.lciTestButton.TextVisible = False
        '
        'lciSaveButton
        '
        Me.lciSaveButton.Control = Me.btnSaveConnection
        Me.lciSaveButton.CustomizationFormText = "lciSaveButton"
        Me.lciSaveButton.Location = New System.Drawing.Point(237, 204)
        Me.lciSaveButton.Name = "lciSaveButton"
        Me.lciSaveButton.Size = New System.Drawing.Size(102, 26)
        Me.lciSaveButton.TextSize = New System.Drawing.Size(0, 0)
        Me.lciSaveButton.TextVisible = False
        '
        'esiButtonAlign
        '
        Me.esiButtonAlign.AllowHotTrack = False
        Me.esiButtonAlign.CustomizationFormText = "esiButtonAlign"
        Me.esiButtonAlign.Location = New System.Drawing.Point(0, 204)
        Me.esiButtonAlign.Name = "esiButtonAlign"
        Me.esiButtonAlign.Size = New System.Drawing.Size(137, 26)
        Me.esiButtonAlign.TextSize = New System.Drawing.Size(0, 0)
        '
        'lciURL
        '
        Me.lciURL.Control = Me.txtURL
        Me.lciURL.CustomizationFormText = "URL"
        Me.lciURL.Location = New System.Drawing.Point(0, 24)
        Me.lciURL.Name = "lciURL"
        Me.lciURL.Size = New System.Drawing.Size(339, 24)
        Me.lciURL.Text = "URL"
        Me.lciURL.TextSize = New System.Drawing.Size(81, 13)
        Me.lciURL.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'lciDBLocation
        '
        Me.lciDBLocation.Control = Me.txtAccessDBLocation
        Me.lciDBLocation.CustomizationFormText = "DB Location"
        Me.lciDBLocation.Location = New System.Drawing.Point(0, 48)
        Me.lciDBLocation.Name = "lciDBLocation"
        Me.lciDBLocation.Size = New System.Drawing.Size(339, 24)
        Me.lciDBLocation.Text = "DB Location"
        Me.lciDBLocation.TextSize = New System.Drawing.Size(81, 13)
        Me.lciDBLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'lciServer
        '
        Me.lciServer.Control = Me.txtServer
        Me.lciServer.CustomizationFormText = "Server"
        Me.lciServer.Location = New System.Drawing.Point(0, 72)
        Me.lciServer.Name = "lciServer"
        Me.lciServer.Size = New System.Drawing.Size(339, 24)
        Me.lciServer.Text = "Server"
        Me.lciServer.TextSize = New System.Drawing.Size(81, 13)
        '
        'lciDatabase
        '
        Me.lciDatabase.Control = Me.txtDB
        Me.lciDatabase.CustomizationFormText = "Database"
        Me.lciDatabase.Location = New System.Drawing.Point(0, 96)
        Me.lciDatabase.Name = "lciDatabase"
        Me.lciDatabase.Size = New System.Drawing.Size(339, 24)
        Me.lciDatabase.Text = "Database"
        Me.lciDatabase.TextSize = New System.Drawing.Size(81, 13)
        '
        'lciTrusted
        '
        Me.lciTrusted.Control = Me.chkTrusted
        Me.lciTrusted.CustomizationFormText = "lciTrusted"
        Me.lciTrusted.Location = New System.Drawing.Point(91, 120)
        Me.lciTrusted.Name = "lciTrusted"
        Me.lciTrusted.Size = New System.Drawing.Size(248, 24)
        Me.lciTrusted.TextSize = New System.Drawing.Size(0, 0)
        Me.lciTrusted.TextVisible = False
        '
        'esiTrusted
        '
        Me.esiTrusted.AllowHotTrack = False
        Me.esiTrusted.CustomizationFormText = "esiTrusted"
        Me.esiTrusted.Location = New System.Drawing.Point(0, 120)
        Me.esiTrusted.Name = "esiTrusted"
        Me.esiTrusted.Size = New System.Drawing.Size(91, 24)
        Me.esiTrusted.TextSize = New System.Drawing.Size(0, 0)
        '
        'lciUsername
        '
        Me.lciUsername.Control = Me.txtUsername
        Me.lciUsername.CustomizationFormText = "Username"
        Me.lciUsername.Location = New System.Drawing.Point(0, 144)
        Me.lciUsername.Name = "lciUsername"
        Me.lciUsername.Size = New System.Drawing.Size(339, 24)
        Me.lciUsername.Text = "Username"
        Me.lciUsername.TextSize = New System.Drawing.Size(81, 13)
        '
        'lciPassword
        '
        Me.lciPassword.Control = Me.txtPassword
        Me.lciPassword.CustomizationFormText = "Password"
        Me.lciPassword.Location = New System.Drawing.Point(0, 168)
        Me.lciPassword.Name = "lciPassword"
        Me.lciPassword.Size = New System.Drawing.Size(339, 24)
        Me.lciPassword.Text = "Password"
        Me.lciPassword.TextSize = New System.Drawing.Size(81, 13)
        '
        'esiButtonSpace
        '
        Me.esiButtonSpace.AllowHotTrack = False
        Me.esiButtonSpace.CustomizationFormText = "esiButtonSpace"
        Me.esiButtonSpace.Location = New System.Drawing.Point(0, 192)
        Me.esiButtonSpace.Name = "esiButtonSpace"
        Me.esiButtonSpace.Size = New System.Drawing.Size(339, 12)
        Me.esiButtonSpace.TextSize = New System.Drawing.Size(0, 0)
        '
        'RegistryEditForm
        '
        Me.AcceptButton = Me.btnContinueToApplication
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelChanges
        Me.ClientSize = New System.Drawing.Size(711, 330)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpConnectionGroup)
        Me.Controls.Add(Me.btnCancelChanges)
        Me.Controls.Add(Me.btnContinueToApplication)
        Me.Controls.Add(Me.grcConnectionGridControl)
        Me.Name = "RegistryEditForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection Setup"
        CType(Me.grcConnectionGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvConnectionGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpConnectionGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpConnectionGroup.ResumeLayout(False)
        CType(Me.lctConnectionInfoLayout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lctConnectionInfoLayout.ResumeLayout(False)
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTrusted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccessDBLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtURL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbeConnectionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgConnectionGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciConnectionType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciTestButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciSaveButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.esiButtonAlign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciURL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDBLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciServer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDatabase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciTrusted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.esiTrusted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciUsername, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.esiButtonSpace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grcConnectionGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvConnectionGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnContinueToApplication As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelChanges As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grpConnectionGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnTestConnection As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSaveConnection As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbeConnectionType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lctConnectionInfoLayout As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents lcgConnectionGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lciConnectionType As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciTestButton As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciSaveButton As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents esiButtonAlign As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtAccessDBLocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtURL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciURL As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciDBLocation As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkTrusted As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtDB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciServer As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciDatabase As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciTrusted As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents esiTrusted As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lciUsername As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciPassword As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents esiButtonSpace As DevExpress.XtraLayout.EmptySpaceItem
End Class
