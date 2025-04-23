Namespace Models.JSON


    Public Class StockItem
        Public Property id As String
        Public Property note As JsonStringValue
        Public Property ABCCode As JsonStringValue

        Public Property Availability As JsonStringValue
        Public Property AverageCost As JsonDoubleValue
        Public Property BaseUOM As JsonStringValue
        Public Property COGSAccount As JsonStringValue

        Public Property CurrentStdCost As JsonDoubleValue
        Public Property CurySpecificMSRP As JsonDoubleValue
        Public Property CurySpecificPrice As JsonDoubleValue
        Public Property DefaultIssueLocationID As JsonStringValue
        Public Property DefaultPrice As JsonDoubleValue
        Public Property DefaultReceiptLocationID As JsonStringValue
        Public Property DefaultWarehouseID As JsonStringValue
        Public Property Description As JsonStringValue
        Public Property DimensionVolume As JsonDoubleValue
        Public Property DimensionWeight As JsonDoubleValue
        Public Property DiscountAccount As JsonStringValue
        Public Property DiscountSubaccount As JsonStringValue
        Public Property InventoryAccount As JsonStringValue
        Public Property InventoryID As JsonStringValue
        Public Property ItemClass As JsonStringValue
        Public Property ItemStatus As JsonStringValue
        Public Property ItemType As JsonStringValue
        Public Property LandedCostVarianceAccount As JsonStringValue
        Public Property LastCost As JsonDoubleValue
        Public Property LastModified As JsonDateTimeValue
        Public Property LastStdCost As JsonDoubleValue
        Public Property LotSerialClass As JsonStringValue
        Public Property Markup As JsonDoubleValue
        Public Property MaxCost As JsonDoubleValue
        Public Property MinCost As JsonDoubleValue
        Public Property MinMarkup As JsonDoubleValue
        Public Property MSRP As JsonDoubleValue
        Public Property NotAvailable As JsonStringValue
        Public Property NoteID As JsonStringValue
        Public Property PendingStdCost As JsonDoubleValue
        Public Property POAccrualAccount As JsonStringValue
        Public Property PostingClass As JsonStringValue
        Public Property PriceClass As JsonStringValue
        Public Property PriceManager As JsonStringValue
        Public Property PriceWorkgroup As JsonStringValue
        Public Property ProductManager As JsonStringValue
        Public Property ProductWorkgroup As JsonStringValue
        Public Property PurchasePriceVarianceAccount As JsonStringValue
        Public Property PurchaseUOM As JsonStringValue
        Public Property SalesAccount As JsonStringValue
        Public Property SalesUOM As JsonStringValue
        Public Property StandardCostRevaluationAccount As JsonStringValue
        Public Property StandardCostVarianceAccount As JsonStringValue
        Public Property SubjectToCommission As JsonBooleanValue
        Public Property TaxCategory As JsonStringValue
        Public Property ValuationMethod As JsonStringValue
        Public Property Visibility As JsonStringValue
        Public Property VolumeUOM As JsonStringValue
        Public Property WeightUOM As JsonStringValue
        Public Property custom As Custom

        Public Property CrossReferences As List(Of ItemCrossReference)
        Public Property WarehouseDetails As List(Of ItemWarehouseDetails)
        Public Property Attributes As List(Of ItemAttribute)
    End Class


End Namespace