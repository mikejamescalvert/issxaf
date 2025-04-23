Imports DevExpress.ExpressApp.Model
Public Interface IModelISSEditorOptions
    Inherits IModelNode

    Property ShowNewButton As Boolean
    Property ShowEllipsis As Boolean
    Property ShowClearButton As Boolean
    Property DisableSpinButtons As Boolean
    Property DisableNegativeNumberEntry As Boolean

    Property GridClickMode As AcceleratedMode

    Enum AcceleratedMode
        DoubleClick
        SingleClick
    End Enum

End Interface
