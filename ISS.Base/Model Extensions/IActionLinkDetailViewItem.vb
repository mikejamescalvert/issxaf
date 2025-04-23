Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Public Interface IActionLinkDetailViewItem
    Inherits DevExpress.ExpressApp.Model.IModelViewItem

    <DataSourceProperty("Application.ActionDesign.Actions")> _
    Property ActionID As DevExpress.ExpressApp.Model.IModelAction

End Interface
