Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security.Strategy

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
Public Class Updater
    Inherits ModuleUpdater
    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
    End Sub

    Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        MyBase.UpdateDatabaseAfterUpdateSchema()
        Dim xpoUser As CustomSecurityUser = ObjectSpace.FindObject(Of CustomSecurityUser)(New BinaryOperator("UserName", "admin"))
        Dim xpoRole As SecuritySystemRole = ObjectSpace.FindObject(Of SecuritySystemRole)(New BinaryOperator("Name", "Administrators"))
        If xpoUser Is Nothing Then
            xpoUser = ObjectSpace.CreateObject(Of CustomSecurityUser)()
            xpoUser.UserName = "admin"
        End If
        If xpoRole Is Nothing Then
            xpoRole = ObjectSpace.CreateObject(Of SecuritySystemRole)
            xpoRole.IsAdministrative = True
            xpoRole.Name = "Administrators"
        End If
        xpoUser.Roles.Add(xpoRole)
        ObjectSpace.CommitChanges()
    End Sub

    Public Overrides Sub UpdateDatabaseBeforeUpdateSchema()
        MyBase.UpdateDatabaseBeforeUpdateSchema()

        'If (CurrentDBVersion < New Version("1.1.0.0") AndAlso CurrentDBVersion > New Version("0.0.0.0")) Then
        '    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName")
        'End If
    End Sub
End Class

