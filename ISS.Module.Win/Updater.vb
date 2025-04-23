Imports System
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security.Strategy
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo

Public Class Updater
    Inherits ModuleUpdater



    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
    End Sub

    Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        MyBase.UpdateDatabaseAfterUpdateSchema()
        Dim xpoUser As SecuritySystemUser = ObjectSpace.FindObject(Of SecuritySystemUser)(New BinaryOperator("UserName", "admin"))
        Dim xpoRole As SecuritySystemRole = ObjectSpace.FindObject(Of SecuritySystemRole)(New BinaryOperator("Name", "Administrators"))
        If xpoUser Is Nothing Then
            xpoUser = ObjectSpace.CreateObject(Of SecuritySystemUser)()
            With xpoUser
                .UserName = "admin"
                .SetPassword("")
            End With
        End If
        If xpoRole Is Nothing Then
            xpoRole = ObjectSpace.CreateObject(Of SecuritySystemRole)
            With xpoRole
                .Name = "Administrators"
                .IsAdministrative = True
            End With
        End If
        xpoUser.Roles.Add(xpoRole)
        ObjectSpace.CommitChanges()
    End Sub

End Class
