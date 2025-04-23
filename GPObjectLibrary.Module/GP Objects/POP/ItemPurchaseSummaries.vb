Namespace Objects.POP
    Public Class ItemPurchaseSummaries
        Inherits Collections.ObjectModel.KeyedCollection(Of String, ItemPurchaseSummary)

        Protected Overrides Function GetKeyForItem(ByVal item As ItemPurchaseSummary) As String
            Return item.ItemKey

        End Function
    End Class
End Namespace

