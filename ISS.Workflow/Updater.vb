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
        DestroyRedundantPropertyTemplates()
    End Sub


    Private Sub DestroyRedundantPropertyTemplates()
        Dim xpcPropertyTemplate As New XPCollection(Of ISSBaseEditorStateTemplate)(CType(ObjectSpace, Xpo.XPObjectSpace).Session)
        Dim oPropertyTemplate As ISSBaseEditorStateTemplate
        For intLoop As Integer = xpcPropertyTemplate.Count - 1 To 0 Step -1
            oPropertyTemplate = xpcPropertyTemplate(intLoop)
            If oPropertyTemplate.ObjectType Is Nothing OrElse oPropertyTemplate.PropertyValue Is Nothing Then
                oPropertyTemplate.Delete()
            End If
        Next
    End Sub


End Class
