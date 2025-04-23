Namespace RM
    Public Class RMCashReceiptsApplies
        Inherits System.Collections.ObjectModel.KeyedCollection(Of String, RMCashReceiptApply)

        Protected Overrides Function GetKeyForItem(ByVal item As RMCashReceiptApply) As String
            Return item.ApplyToDocumentNumber
        End Function
    End Class
End Namespace

