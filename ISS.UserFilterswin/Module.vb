Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

Public NotInheritable Class [UserFiltersWinModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ExtendModelInterfaces(extenders As ModelInterfaceExtenders)
        MyBase.ExtendModelInterfaces(extenders)

    End Sub

End Class
