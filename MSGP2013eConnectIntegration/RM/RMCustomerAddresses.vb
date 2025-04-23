Namespace RM
    Public Class RMCustomerAddresses
        Inherits System.Collections.ObjectModel.KeyedCollection(Of String, RMCustomerAddress)

        Protected Overrides Function GetKeyForItem(ByVal item As RMCustomerAddress) As String
            Return item.AddressCode
        End Function
    End Class
End Namespace

