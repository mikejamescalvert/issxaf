Imports DevExpress.Persistent.Base
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Model

Public Interface IModelExtension
    Inherits IApplicationExtension

    ReadOnly Property ISSEditorOptions As IModelISSEditorOptions
    ReadOnly Property ISSApplicationOptions As IModelISSApplicationOptions
End Interface
