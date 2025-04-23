Imports DevExpress.Persistent.Base
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Model

Public Interface IModelDetailViewItem
    Inherits IDetailViewItem
    <DataSourceProperty("ViewItems")>
    <Category("Layout")>
    Property TabTargetViewItem As DevExpress.ExpressApp.Model.IModelViewItem
    Property SkipTabStop As Boolean
    Property ViewItems As IModelList(Of IModelViewItem)
    <Category("EditorSpecific")>
    Property DisableSpinButton As Nullable(Of Boolean)
    <Category("EditorSpecific")>
    Property DisableNegativeNumberEntry As Nullable(Of Boolean)
End Interface
