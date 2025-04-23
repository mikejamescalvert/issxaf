Imports System.ComponentModel

Public Interface IModelColumnExtension
    Inherits DevExpress.ExpressApp.Model.IModelColumn

    Property SkipTabStop As Boolean

    <Category("EditorSpecific")>
    Property DisableSpinButton As Nullable(Of Boolean)

    <Category("EditorSpecific")>
    Property DisableNegativeNumberEntry As Nullable(Of Boolean)
End Interface
