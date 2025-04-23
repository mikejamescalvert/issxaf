Public Class SOPShipmentLines
    Inherits System.Collections.ObjectModel.KeyedCollection(Of String, SOPShipmentLine)

    Protected Overrides Function GetKeyForItem(ByVal item As SOPShipmentLine) As String
        Return item.DocNumber
    End Function
End Class
