Imports System
Imports System.Security.Principal

Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Objects
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo


Public Class Updater
	Inherits ModuleUpdater
    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
        
    End Sub


	Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        MyBase.UpdateDatabaseAfterUpdateSchema()
        'ISSBaseMailServerSettings.GetInstance(Session)

    End Sub

End Class
