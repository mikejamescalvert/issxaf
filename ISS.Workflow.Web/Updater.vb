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

	Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
		MyBase.New(session, currentDBVersion)
	End Sub

	Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
		MyBase.UpdateDatabaseAfterUpdateSchema()
	End Sub
End Class
