Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp

Public NotInheritable Class [SpellCheckerModule]
    Inherits ModuleBase
    Public Sub New()
        ModelDifferenceResourceName = "ISS.SpellChecker.Model.DesignedDiffs"
        InitializeComponent()
    End Sub
End Class
