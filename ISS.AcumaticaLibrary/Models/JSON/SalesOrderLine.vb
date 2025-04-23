Namespace Models.JSON


    Public Class SalesOrderLine
        Public Property id As String
        Public Property note As JsonStringValue
        Public Property Account As JsonStringValue
        Public Property AlternateID As JsonStringValue
        Public Property Amount As JsonDoubleValue
        Public Property AutoCreateIssue As JsonBooleanValue
        Public Property AverageCost As JsonDoubleValue
        Public Property Branch As JsonStringValue
        Public Property CalculateDiscountsOnImport As JsonBooleanValue
        Public Property Commissionable As JsonBooleanValue
        Public Property Completed As JsonBooleanValue
        Public Property CustomerOrderNbr As JsonStringValue
        Public Property DiscountAmount As JsonDoubleValue
        Public Property DiscountCode As JsonStringValue
        Public Property DiscountedUnitPrice As JsonDoubleValue
        Public Property DiscountPercent As JsonDoubleValue
        Public Property ExtendedPrice As JsonDoubleValue
        Public Property FreeItem As JsonBooleanValue
        Public Property InventoryID As JsonStringValue
        Public Property LastModifiedDate As JsonDateTimeValue
        Public Property LineDescription As JsonStringValue
        Public Property LineNbr As JsonIntegerValue
        Public Property LineType As JsonStringValue
        Public Property Location As JsonStringValue
        Public Property LotSerialNbr As JsonStringValue
        Public Property ManualDiscount As JsonBooleanValue
        Public Property ManualPrice As JsonBooleanValue
        Public Property MarkForPO As JsonBooleanValue
        Public Property NoteID As JsonStringValue
        Public Property OpenQty As JsonDoubleValue
        Public Property Operation As JsonStringValue
        Public Property OrderQty As JsonDoubleValue
        Public Property OvershipThreshold As JsonDoubleValue
        Public Property POSource As JsonStringValue
        Public Property QtyOnShipments As JsonDoubleValue
        Public Property ReasonCode As JsonStringValue
        Public Property RequestedOn As JsonDateTimeValue
        Public Property SalespersonID As JsonStringValue
        Public Property SchedOrderDate As JsonDateTimeValue
        Public Property ShipOn As JsonDateTimeValue
        Public Property ShippingRule As JsonStringValue
        Public Property ShipToLocation As JsonStringValue
        Public Property TaxCategory As JsonStringValue
        Public Property TaxZone As JsonStringValue
        Public Property UnbilledAmount As JsonDoubleValue
        Public Property UndershipThreshold As JsonDoubleValue
        Public Property UnitCost As JsonDoubleValue
        Public Property UnitPrice As JsonDoubleValue
        Public Property UOM As JsonStringValue
        Public Property WarehouseID As JsonStringValue
        Public Property custom As Custom
    End Class


End Namespace