Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

Public NotInheritable Class [UserFiltersModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ExtendModelInterfaces(ByVal extenders As ModelInterfaceExtenders)
        MyBase.ExtendModelInterfaces(extenders)
        extenders.Add(Of IModelApplication, IUserFilterApplicationModel)()
    End Sub

End Class
