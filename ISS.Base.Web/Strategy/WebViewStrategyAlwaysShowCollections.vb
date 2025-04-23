Imports DevExpress.ExpressApp
Public Class WebViewStrategyAlwaysShowCollections
    Inherits DevExpress.ExpressApp.Web.ShowViewStrategy
    Public Sub New(ByVal application As DevExpress.ExpressApp.XafApplication)
        MyBase.New(application)

    End Sub

    Protected Overrides Sub ShowViewCore(ByVal parameters As DevExpress.ExpressApp.ShowViewParameters, ByVal showViewSource As DevExpress.ExpressApp.ShowViewSource)
        MyBase.ShowViewCore(parameters, showViewSource)
        If parameters.CreatedView IsNot Nothing Then
            If TypeOf parameters.CreatedView Is DetailView Then
                CollectionsEditMode = CType(parameters.CreatedView, DetailView).ViewEditMode
            End If
        End If

    End Sub


End Class
