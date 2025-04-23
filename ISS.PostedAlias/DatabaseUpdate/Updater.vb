Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
'Imports DevExpress.ExpressApp.Reports
'Imports DevExpress.ExpressApp.PivotChart
'Imports DevExpress.ExpressApp.Security.Strategy
'Imports ISS.PostedAlias.Module.BusinessObjects

' Allows you to handle a database update when the application version changes (http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppUpdatingModuleUpdatertopic help article for more details).
Public Class Updater
    Inherits ModuleUpdater
    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
    End Sub

    ' Override to specify the database update code which should be performed after the database schema is updated (http://documentation.devexpress.com/#Xaf/DevExpressExpressAppUpdatingModuleUpdater_UpdateDatabaseAfterUpdateSchematopic).
    Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        MyBase.UpdateDatabaseAfterUpdateSchema()
        'Example:
        'Dim name As String = "MyName"
        'Dim theObject As DomainObject1 = ObjectSpace.FindObject(Of DomainObject1)(CriteriaOperator.Parse("Name=?", name))
        'If (theObject Is Nothing) Then
        '    theObject = ObjectSpace.CreateObject(Of DomainObject1)()
        '    theObject.Name = name
        'End If
    End Sub
    ' Override to perform the required changes with the database structure before the database schema is updated (http://documentation.devexpress.com/#Xaf/DevExpressExpressAppUpdatingModuleUpdater_UpdateDatabaseBeforeUpdateSchematopic).
    Public Overrides Sub UpdateDatabaseBeforeUpdateSchema()
        MyBase.UpdateDatabaseBeforeUpdateSchema()
        ' Example:
        'If (CurrentDBVersion < New Version("1.1.0.0") AndAlso CurrentDBVersion > New Version("0.0.0.0")) Then
        '    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName")
        'End If
    End Sub
End Class
