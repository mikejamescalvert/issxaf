Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class PermissionsController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 
        AddHandler Permissions.PermissionsChanged, AddressOf UpdateViewStateFromPermission
    End Sub

    Public Sub UpdateViewStateFromPermission()
        Dim oapPermission As System.Nullable(Of Permissions.ObjectPermissionType)
        If View IsNot Nothing AndAlso View.ObjectTypeInfo IsNot Nothing AndAlso View.ObjectTypeInfo.Type IsNot Nothing Then
            oapPermission = Permissions.GetPermission(View.ObjectTypeInfo.Type)
            If oapPermission.HasValue = False Then
                Return
            End If
            If oapPermission = Permissions.ObjectPermissionType.OnlyAllowSchemaModification Or oapPermission = Permissions.ObjectPermissionType.NoAccess Then
                View.AllowDelete("MasterProviderPermission") = False
                View.AllowEdit("MasterProviderPermission") = False
                View.AllowNew("MasterProviderPermission") = False
            Else
                View.AllowDelete("MasterProviderPermission") = True
                View.AllowEdit("MasterProviderPermission") = True
                View.AllowNew("MasterProviderPermission") = True
            End If
        End If
    End Sub


    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        UpdateViewStateFromPermission()
        
    End Sub

End Class
