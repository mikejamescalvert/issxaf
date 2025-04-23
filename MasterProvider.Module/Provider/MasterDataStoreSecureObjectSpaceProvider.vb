Imports DevExpress.ExpressApp
Imports MasterProvider.Module.Permissions
Imports DevExpress.Xpo.Metadata
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security.ClientServer
Imports DevExpress.ExpressApp.Security

Public Class MasterDataStoreSecureObjectSpaceProvider
    Inherits SecuredObjectSpaceProvider
    Public Sub New(ByVal SecuritySystem As ISelectDataSecurityProvider, ByVal dataStoreProvider As IXpoDataStoreProvider)
        MyBase.New(SecuritySystem, dataStoreProvider)
        Me.AllowICommandChannelDoWithSecurityContext = True
    End Sub

    Protected Overrides Function CreateDataLayer(dataStore As DevExpress.Xpo.DB.IDataStore) As DevExpress.Xpo.IDataLayer
        Return MyBase.CreateDataLayer(dataStore)
    End Function


End Class
