Namespace Models.JSON


    Public Class Customer
        Public Sub New()
            Me.Salespersons = New List(Of Salesperson)
        End Sub
        Public Property id As String
        Public Property note As JsonStringValue
        Public Property AccountRef As JsonStringValue
        Public Property ApplyOverdueCharges As JsonBooleanValue
        Public Property AutoApplyPayments As JsonBooleanValue
        Public Property BillingAddressOverride As JsonBooleanValue
        Public Property BillingContactOverride As JsonBooleanValue
        Public Property BillingContact As Contact
        Public Property PrimaryContact As Contact
        Public Property MainContact As Contact
        Public Property CreatedDateTime As JsonDateTimeValue
        Public Property CreditLimit As JsonDoubleValue
        Public Property CurrencyID As JsonStringValue
        Public Property CurrencyRateType As JsonStringValue
        Public Property CustomerClass As JsonStringValue
        Public Property CustomerID As JsonStringValue
        Public Property CustomerName As JsonStringValue
        Public Property Email As JsonStringValue
        Public Property EnableCurrencyOverride As JsonBooleanValue
        Public Property EnableRateOverride As JsonBooleanValue
        Public Property EnableWriteOffs As JsonBooleanValue
        Public Property FOBPoint As JsonStringValue
        Public Property LastModifiedDateTime As JsonDateTimeValue
        Public Property LeadTimedays As JsonIntegerValue
        Public Property LocationName As JsonStringValue
        Public Property MultiCurrencyStatements As JsonBooleanValue
        Public Property NoteID As JsonStringValue
        Public Property OrderPriority As JsonIntegerValue
        Public Property PriceClassID As JsonStringValue
        Public Property PrintInvoices As JsonBooleanValue
        Public Property PrintStatements As JsonBooleanValue
        Public Property ResidentialDelivery As JsonBooleanValue
        Public Property RestrictVisibilityTo As JsonStringValue
        Public Property SaturdayDelivery As JsonBooleanValue
        Public Property SendInvoicesbyEmail As JsonBooleanValue
        Public Property SendStatementsbyEmail As JsonBooleanValue
        Public Property ShippingAddressOverride As JsonBooleanValue
        Public Property ShippingBranch As JsonStringValue
        Public Property ShippingContactOverride As JsonBooleanValue
        Public Property ShippingContact As Contact
        Public Property ShippingRule As JsonStringValue
        Public Property ShippingTerms As JsonStringValue
        Public Property ShippingZoneID As JsonStringValue
        Public Property ShipVia As JsonStringValue
        Public Property StatementCycleID As JsonStringValue
        Public Property StatementType As JsonStringValue
        Public Property Status As JsonStringValue
        Public Property TaxRegistrationID As JsonStringValue
        Public Property TaxZone As JsonStringValue
        Public Property Terms As JsonStringValue
        Public Property WarehouseID As JsonStringValue
        Public Property WriteOffLimit As JsonDoubleValue
        Public Property custom As Object

        Public Property Salespersons As List(Of Salesperson)
        Public Property Contacts As List(Of CustomerContact)

    End Class


End Namespace