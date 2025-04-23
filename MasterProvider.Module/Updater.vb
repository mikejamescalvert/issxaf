Imports System
Imports System.Security.Principal

Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base.Security
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class Updater
	Inherits DevExpress.ExpressApp.Updating.ModuleUpdater
    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
        
    End Sub
    

	Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        MyBase.UpdateDatabaseAfterUpdateSchema()
        ConnectionManager.GetInstance(CType(ObjectSpace, Xpo.XPObjectSpace).Session)
        ObjectSpace.CommitChanges()
	End Sub

End Class
