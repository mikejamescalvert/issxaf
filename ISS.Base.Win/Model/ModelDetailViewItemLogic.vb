Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Model

<DomainLogic(GetType(IModelDetailViewItem))>
Public Class ModelDetailViewItemLogic

    Public Shared Function Get_ViewItems(ByVal elementModel As IModelDetailViewItem) As IModelList(Of IModelViewItem)
        Dim compositeView as IModelCompositeView = FindCompositeView(elementModel)
        Dim rsl As New LazyCalculatedModelNodeList(Of IModelViewItem)(compositeView.Items,compositeView.Items)
        Return rsl
			'LazyCalculatedModelNodeList<IModelViewItem> result = null;
			'if(view != null) {
			'	result = new LazyCalculatedModelNodeList<IModelViewItem>(GetFilteredItems(GetAllUsedViewItems(view.Layout), view.Items), view.Items);
			'}
			'return result;
    End Function

    Public Shared Function FindCompositeView(ByVal elementModel As IModelDetailViewItem) As IModelCompositeView
        Dim mdlParent As IModelNode = elementModel.Parent
        While mdlParent IsNot Nothing
            If TypeOf mdlParent is IModelCompositeView Then
                Return mdlParent
            End If
            mdlParent = mdlParent.Parent
        End While
        Return Nothing
    End Function

End Class
