Namespace Objects.IV.Helpers
    Public Class ItemStockCounts
        Inherits System.Collections.ObjectModel.KeyedCollection(Of ItemStockCountKey, ItemStockCount)
        Public Structure ItemStockCountKey
            Public ItemKey As String
            Public Location As String
        End Structure
        Public Overloads Function Contains(ByVal ItemKey As String, ByVal Location As String) As Boolean
            Dim key As ItemStockCountKey
            key.ItemKey = ItemKey
            key.Location = Location
            Return MyBase.Contains(key)
        End Function

        Public Overloads ReadOnly Property item(ByVal ItemKey As String, ByVal Location As String) As GPObjectLibrary.Module.Objects.IV.Helpers.ItemStockCount
            Get
                Dim key As ItemStockCountKey
                key.ItemKey = ItemKey
                key.Location = Location
                Return MyBase.Item(key)
            End Get
        End Property




        Protected Overrides Function GetKeyForItem(ByVal item As ItemStockCount) As ItemStockCountKey
            Dim Key As ItemStockCountKey
            Key.ItemKey = item.ItemKey
            Key.Location = item.Location
            Return Key
        End Function
    End Class
End Namespace

