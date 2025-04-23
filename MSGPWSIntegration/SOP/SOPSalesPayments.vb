Namespace SOP
    Public Class SalesPayments
        Inherits Collections.ObjectModel.KeyedCollection(Of String, SalesPayment)

        Protected Overrides Function GetKeyForItem(ByVal item As SalesPayment) As String
            Return item.PaymentCardTypeKey
        End Function
    End Class
End Namespace

