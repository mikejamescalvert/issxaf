Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Columns

Public Class RegistryEditForm

    Private _mTempSession As New Session
    Private _mObjectList As New List(Of MPConnectionInformationInCode)
    Private _mActiveConnection As MPConnectionInformationInCode

    Private Sub RegistryEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each oCustomProviderContainer As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
            If oCustomProviderContainer.IsRegistryEntry = True Then
                AddRegistryEntryInformation(oCustomProviderContainer.RegistryLocation, DevExpress.ExpressApp.Utils.CaptionHelper.ConvertCompoundName(oCustomProviderContainer.ConnectionStringName), oCustomProviderContainer.DisplayName)
            End If
        Next
        If Helpers.DataStoreHelper.ApplicationContainer.IsRegistryEntry = True Then
            AddRegistryEntryInformation(Helpers.DataStoreHelper.ApplicationContainer.RegistryLocation, "Application Connection", "Application Connection")
        End If

        grcConnectionGridControl.DataSource = _mObjectList
        grcConnectionGridControl.RefreshDataSource()
        UpdateGridColumnSettings()
        UpdateContinueStatus()
    End Sub

    Public Function HasConnectionString(ByVal ConnectionStringName As String)
        For Each mpcConnection As MPConnectionInformationInCode In _mObjectList
            If mpcConnection.ConnectionStringName = ConnectionStringName Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub AddRegistryEntryInformation(ByVal RegistryPath As String, ByVal ConnectionStringName As String, ByVal DisplayName As String)
        If HasConnectionString(ConnectionStringName) = True Then
            Return
        End If
        Dim mpcConnection As New MPConnectionInformationInCode
        mpcConnection.Accepted = False
        mpcConnection.RegistryPath = RegistryPath
        mpcConnection.ConnectionStringName = ConnectionStringName
        mpcConnection.DisplayName = DisplayName
        mpcConnection.ReadConnectionFromRegistry()
        _mObjectList.Add(mpcConnection)
    End Sub
    Public Sub UpdateGridColumnSettings()
        For Each clmColumn As GridColumn In grvConnectionGridView.Columns
            If clmColumn.FieldName <> "DisplayName" Then
                clmColumn.Visible = False
            End If
        Next
    End Sub
    Public Sub UpdateContinueStatus()
        btnContinueToApplication.Enabled = Not NeedsRegistryUpdate()
    End Sub
    Public Function NeedsRegistryUpdate() As Boolean
        For Each oCustomProviderContainer As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
            If oCustomProviderContainer.RegistryNeedsUpdate = True Then
                Return True
            End If
        Next
        Return Helpers.DataStoreHelper.ApplicationContainer.RegistryNeedsUpdate
    End Function

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        If cbeConnectionType.EditValue = "SQL" Then
            _mActiveConnection.ConnectionType = MPConnectionInformation.ConnectionTypes.SQL
        ElseIf cbeConnectionType.EditValue = "Webservice" Then
            _mActiveConnection.ConnectionType = MPConnectionInformation.ConnectionTypes.WebService
        Else
            _mActiveConnection.ConnectionType = MPConnectionInformation.ConnectionTypes.Access
        End If

        _mActiveConnection.DatabaseLocation = Me.txtAccessDBLocation.Text
        _mActiveConnection.DatabaseName = Me.txtDB.Text
        _mActiveConnection.Password = Me.txtPassword.Text
        _mActiveConnection.ServerName = Me.txtServer.Text
        _mActiveConnection.URL = Me.txtURL.Text
        _mActiveConnection.UserName = Me.txtUsername.Text
        _mActiveConnection.TrustedConnection = Me.chkTrusted.Checked
        Try
            _mActiveConnection.ValidateConnection()
            MsgBox("Test Successful", MsgBoxStyle.Exclamation, "Connection Test")
            Me.btnSaveConnection.Enabled = True
        Catch ex As Exception
            Me.btnSaveConnection.Enabled = False
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error During Connection")
        End Try


    End Sub

    Private Sub btnSaveConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveConnection.Click

        _mActiveConnection.Accepted = True
        _mActiveConnection.WriteConnectionToRegistry()
        MsgBox("Save Successful", MsgBoxStyle.OkOnly, "Connection Save")
        _mActiveConnection.ReadConnectionFromRegistry()
        btnContinueToApplication.Enabled = True
        For Each cntConnection As MPConnectionInformationInCode In _mObjectList
            If cntConnection.Accepted = False Then
                btnContinueToApplication.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnCancelChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelChanges.Click
        Environment.Exit(1)
    End Sub

    Private Sub btnContinueToApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinueToApplication.Click
        MasterProvider.Module.Helpers.DataStoreHelper.LoadProviderInformation(DB.AutoCreateOption.None)
        For Each objProvider In MasterProvider.Module.Helpers.DataStoreHelper.CustomProviderContainerList
            If objProvider.IsRegistryEntry = True Then
                objProvider.FetchFromRegistry()
            End If
        Next
        If MasterProvider.Module.Helpers.DataStoreHelper.ApplicationContainer IsNot Nothing AndAlso MasterProvider.Module.Helpers.DataStoreHelper.ApplicationContainer.IsRegistryEntry Then
            MasterProvider.Module.Helpers.DataStoreHelper.ApplicationContainer.FetchFromRegistry()
        End If
        MasterProvider.Module.Helpers.SessionHelper.MasterDataStore.Initialize(Nothing, DB.AutoCreateOption.None)
        Me.Close()
    End Sub

    Private Sub cbeConnectionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbeConnectionType.SelectedIndexChanged
        If cbeConnectionType.EditValue = "SQL" Then
            SetupConnectionType(MPConnectionInformation.ConnectionTypes.SQL)
        ElseIf cbeConnectionType.EditValue = "Webservice" Then
            SetupConnectionType(MPConnectionInformation.ConnectionTypes.WebService)
        Else
            SetupConnectionType(MPConnectionInformation.ConnectionTypes.Access)
        End If
    End Sub

    Private Sub chkTrusted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrusted.CheckedChanged
        Me.txtUsername.Enabled = Not chkTrusted.Checked
        Me.txtPassword.Enabled = Not chkTrusted.Checked
        Me.btnSaveConnection.Enabled = False
    End Sub

    Private Sub grvConnectionGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvConnectionGridView.FocusedRowChanged
        _mActiveConnection = grvConnectionGridView.GetFocusedRow()
        SetupConnectionType(_mActiveConnection.ConnectionType)
        Me.txtAccessDBLocation.Text = _mActiveConnection.DatabaseLocation
        Me.txtDB.Text = _mActiveConnection.DatabaseName
        Me.txtPassword.Text = _mActiveConnection.Password
        Me.txtServer.Text = _mActiveConnection.ServerName
        Me.txtURL.Text = _mActiveConnection.URL
        Me.txtUsername.Text = _mActiveConnection.UserName
        Me.chkTrusted.Checked = _mActiveConnection.TrustedConnection
    End Sub

    Public Sub SetupConnectionType(ByVal ConnectionType As MPConnectionInformation.ConnectionTypes)
        Select Case ConnectionType
            Case MPConnectionInformation.ConnectionTypes.Access
                cbeConnectionType.EditValue = "Access DB"
                Me.lciDatabase.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciDBLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.lciServer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciTrusted.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciURL.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciUsername.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.esiTrusted.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case MPConnectionInformation.ConnectionTypes.SQL
                cbeConnectionType.EditValue = "SQL"
                Me.lciDatabase.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.lciDBLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.lciServer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.lciTrusted.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.lciURL.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciUsername.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.esiTrusted.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case MPConnectionInformation.ConnectionTypes.WebService
                cbeConnectionType.EditValue = "Webservice"
                Me.lciDatabase.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciDBLocation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciServer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciTrusted.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.lciURL.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.lciUsername.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.esiTrusted.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Select
        Me.txtAccessDBLocation.Text = String.Empty
        Me.txtDB.Text = String.Empty
        Me.txtPassword.Text = String.Empty
        Me.txtServer.Text = String.Empty
        Me.txtURL.Text = String.Empty
        Me.txtUsername.Text = String.Empty
        Me.chkTrusted.Checked = False
        Me.btnSaveConnection.Enabled = False
    End Sub

    Private Sub txtURL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtURL.EditValueChanged
        Me.btnSaveConnection.Enabled = False
    End Sub

    Private Sub txtAccessDBLocation_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccessDBLocation.EditValueChanged
        Me.btnSaveConnection.Enabled = False
    End Sub

    Private Sub txtServer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServer.EditValueChanged
        Me.btnSaveConnection.Enabled = False
    End Sub

    Private Sub txtDB_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDB.EditValueChanged
        Me.btnSaveConnection.Enabled = False
    End Sub

    Private Sub txtUsername_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.EditValueChanged
        Me.btnSaveConnection.Enabled = False
    End Sub

    Private Sub txtPassword_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.EditValueChanged
        Me.btnSaveConnection.Enabled = False
    End Sub


End Class