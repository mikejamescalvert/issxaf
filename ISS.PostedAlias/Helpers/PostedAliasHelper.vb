Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class PostedAliasHelper
    Public Shared Sub UpdateObjectPostedAttributes(ByVal TargetObject As Object, ByVal TargetSession As Session)
        Dim lstPathing As List(Of PostedAliasPathingAttributeInfo) = PostedAliasModule.GetPostedAliasPathingInformationForParents(TargetObject.GetType)
        For Each paiInfo As PostedAliasPathingAttributeInfo In lstPathing
            paiInfo.TargetMethod.Invoke(TargetObject, {TargetSession.Evaluate(TargetObject.GetType, CriteriaOperator.Parse(paiInfo.Attribute.PersistentAlias), New BinaryOperator(paiInfo.SourceClass.KeyMember.Name, paiInfo.SourceClass.KeyMember.GetValue(TargetObject)))})
        Next
    End Sub

End Class
