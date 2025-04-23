Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp

Public NotInheritable Class [LabelTooltipsModule]
    Inherits ModuleBase
    Public Sub New()
        ModelDifferenceResourceName = "ISS.LabelTooltips.Model.DesignedDiffs"
        InitializeComponent()
    End Sub
    Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
        MyBase.ExtendModelInterfaces(extenders)
        extenders.Add(Of DevExpress.ExpressApp.Model.IModelViewItem, IViewItemWithTooltip)()
    End Sub
End Class
