Imports DevExpress.Data.Filtering

Public Class CollectionHelper

    Public Shared Function GetObjectInCollectionFromPropertyNameValue(ByVal PropertyName As String, ByRef Value As Object, ByRef BaseCollection As DevExpress.Xpo.XPBaseCollection) As Object
        Dim dcdDescriptorDefault As DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault = New DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault(BaseCollection.GetObjectClassInfo.ClassType)
        Dim crtOperator As New BinaryOperator(PropertyName, Value, BinaryOperatorType.Equal)
        Dim dxeExpressionEvaluator As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator = New DevExpress.Data.Filtering.Helpers.ExpressionEvaluator(dcdDescriptorDefault, crtOperator)

        For Each oObject As Object In BaseCollection
            If dxeExpressionEvaluator.Fit(oObject) = True Then
                Return oObject
            End If
        Next
        Return Nothing
    End Function




End Class
