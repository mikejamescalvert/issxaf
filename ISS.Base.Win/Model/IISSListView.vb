Public Interface IISSListView
    Inherits DevExpress.ExpressApp.Model.IModelListView
    Property ShowGridFooter As Nullable(Of GridFooterOptions)



End Interface
Public Enum GridFooterOptions
    [Default]
    Always
    RootListViewOnly
End Enum