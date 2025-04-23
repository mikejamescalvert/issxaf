Imports System.ComponentModel
Imports DevExpress.ExpressApp.Model

Public Interface IUserFilterApplicationModel
    Inherits IModelNode
    ReadOnly Property UserFilterOptions As IUserFilterModel
End Interface
