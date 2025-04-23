Imports DevExpress.Xpo

Public Class Permissions

    Public Shared Event PermissionsChanged()


    Public Enum ObjectPermissionType
        OnlyAllowDataModification
        OnlyAllowSchemaModification
        FullAccess
        NoAccess
    End Enum


    Public Shared Function GetPermission(ByVal ObjectType As Type) As System.Nullable(Of ObjectPermissionType)
        Return MasterDataStore.GetObjectPermission(ObjectType)
    End Function


    Public Shared Sub SetPermission(ByVal ObjectType As Type, ByVal Type As ObjectPermissionType)
        MasterDataStore.AddPermissionOverride(ObjectType, Type)
        RaiseEvent PermissionsChanged()
    End Sub

    Public Shared Sub ResetPermissions(ByVal ObjectType As Type)
        MasterDataStore.ClearPermissionOverrides(ObjectType)
        RaiseEvent PermissionsChanged()
    End Sub

    Public Shared Sub ResetPermissions()
        MasterDataStore.ClearPermissionOverrides()
        RaiseEvent PermissionsChanged()
    End Sub

    Friend Class ObjectPermission
        Friend Sub New(ByVal ObjectType As Type, ByVal Permission As ObjectPermissionType)
            _mObjectType = ObjectType
            _mPermissionType = Permission
        End Sub
        Private _mObjectType As Type
        Public ReadOnly Property ObjectType As Type
            Get
                Return _mObjectType
            End Get
        End Property
        Private _mPermissionType As ObjectPermissionType
        Public ReadOnly Property PermissionType As ObjectPermissionType
            Get
                Return _mPermissionType
            End Get
        End Property
    End Class

End Class
