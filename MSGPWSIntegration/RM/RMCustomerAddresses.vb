Namespace RM
    Public Class RMCustomerAddresses
        Inherits Collections.ObjectModel.Collection(Of RMCustomerAddress)
        'Inherits Collections.ObjectModel.KeyedCollection(Of String, RMCustomerAddress)

        'Protected Overrides Function GetKeyForItem(ByVal item As RMCustomerAddress) As String
        '    Return item.CustomerAddressKey
        'End Function
    End Class
End Namespace

