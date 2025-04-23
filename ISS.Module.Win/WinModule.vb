Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports ISS.Base.Win

<ToolboxItemFilter("Xaf.Platform.Win")>
Partial Public NotInheritable Class [ISSWindowsFormsModule]
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
        Dim updater As ModuleUpdater = New Updater(objectSpace, versionFromDB)
        Return New ModuleUpdater() {updater}
    End Function
End Class

