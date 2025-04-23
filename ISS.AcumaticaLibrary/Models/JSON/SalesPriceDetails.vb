Namespace Models.JSON


    Public Class SalesPriceDetails
        Public Property id As String
        Public Property rowNumber As Integer
        Public Property BreakQty As JsonDoubleValue
        Public Property CreatedDateTime As JsonDateTimeValue

        Public Property Description As JsonStringValue
        Public Property EffectiveDate As JsonDateTimeValue
        Public Property ExpirationDate As JsonDateTimeValue
        Public Property InventoryID As JsonStringValue

        Public Property LastModifiedDateTime As JsonDateTimeValue
        Public Property NoteID As JsonStringValue
        Public Property Price As JsonDoubleValue
        Public Property PriceCode As JsonStringValue
        Public Property PriceType As JsonStringValue
        Public Property UOM As JsonStringValue
        Public Property Warehouse As JsonStringValue

    End Class


End Namespace