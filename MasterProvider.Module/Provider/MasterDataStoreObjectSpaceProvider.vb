Imports DevExpress.ExpressApp
Imports MasterProvider.Module.Permissions
Imports DevExpress.Xpo.Metadata
Imports DevExpress.ExpressApp.Xpo

Public Class MasterDataStoreObjectSpaceProvider
    Inherits Xpo.XPObjectSpaceProvider
    Public Sub New(ByVal dataStoreProvider As IXpoDataStoreProvider)
        MyBase.New(dataStoreProvider)
    End Sub

    Protected Overrides Function CreateDataLayer(dataStore As DevExpress.Xpo.DB.IDataStore) As DevExpress.Xpo.IDataLayer
        Return MyBase.CreateDataLayer(dataStore)
    End Function


End Class
