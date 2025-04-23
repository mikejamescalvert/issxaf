Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports System.Reflection
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo.Metadata
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo

Partial Public NotInheritable Class [ISSModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub CustomizeTypesInfo(typesInfo As ITypesInfo)
        MyBase.CustomizeTypesInfo(typesInfo)

    End Sub

    Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
        Dim updater As ModuleUpdater = New Updater(objectSpace, versionFromDB)
        Return New ModuleUpdater() {updater}
    End Function

    Public Overrides Sub Setup(application As XafApplication)
        MyBase.Setup(application)
        AddHandler application.LoggedOn, AddressOf Application_LoggedOn


    End Sub

    Private Sub Application_LoggedOn(sender As Object, e As LogonEventArgs)


    End Sub
End Class
