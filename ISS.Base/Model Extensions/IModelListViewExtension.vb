Imports System.ComponentModel

Public Interface IModelListViewExtension
    Inherits DevExpress.ExpressApp.Model.IModelListView
    Property HideLinkUnlink As Nullable(Of Boolean)
    <Browsable(False)>
    Property CurrentUserFilterGuid As String
End Interface
