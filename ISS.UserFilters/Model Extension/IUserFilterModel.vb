Imports System.ComponentModel
Imports DevExpress.ExpressApp.Model

Public Interface IUserFilterModel
    Inherits IModelNode
    <DefaultValue(True)>
    Property ShowUserFiltersInRootListView As Boolean
    <DefaultValue(False)>
    Property ShowUserFiltersInNestedListView As Boolean

End Interface
