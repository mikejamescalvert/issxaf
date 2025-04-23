Namespace Models.JSON


    Public Class SalesOrder
        Public Sub New()
            Me.Details = New List(Of SalesOrderLine)
        End Sub
        Public Property id As String
        Public Property rowNumber As Integer
        Public Property note As JsonStringValue
        Public Property Approved As JsonBooleanValue
        Public Property BaseCurrencyID As JsonStringValue
        Public Property BillToAddress As Address
        Public Property BillToAddressOverride As JsonBooleanValue
        Public Property BillToContact As Contact
        Public Property BillToContactOverride As JsonBooleanValue
        Public Property CashAccount As JsonStringValue
        Public Property ContactID As JsonStringValue
        Public Property ControlTotal As JsonDoubleValue
        Public Property CreatedDate As JsonDateTimeValue
        Public Property CreditHold As JsonBooleanValue
        Public Property CurrencyID As JsonStringValue
        Public Property CurrencyRate As JsonDoubleValue
        Public Property CurrencyRateTypeID As JsonStringValue
        Public Property CustomerID As JsonStringValue
        Public Property CustomerOrder As JsonStringValue
        Public Property [Date] As JsonDateTimeValue
        Public Property Description As JsonStringValue
        Public Property DestinationWarehouseID As JsonStringValue
        Public Property Details As List(Of SalesOrderLine)
        Public Property DisableAutomaticDiscountUpdate As JsonBooleanValue
        Public Property EffectiveDate As JsonDateTimeValue
        Public Property ExternalRef As JsonStringValue
        Public Property Hold As JsonBooleanValue
        Public Property IsTaxValid As JsonBooleanValue
        Public Property LastModified As JsonDateTimeValue
        Public Property LocationID As JsonStringValue
        Public Property NoteID As JsonStringValue
        Public Property OrderedQty As JsonBooleanValue
        Public Property OrderNbr As JsonStringValue
        Public Property OrderTotal As JsonBooleanValue
        Public Property OrderType As JsonStringValue
        Public Property PaymentMethod As JsonStringValue
        Public Property PaymentRef As JsonStringValue
        Public Property PreferredWarehouseID As JsonStringValue
        Public Property ReciprocalRate As JsonDoubleValue
        Public Property RequestedOn As JsonDateTimeValue
        Public Property ShipToAddressOverride As JsonBooleanValue
        Public Property ShipToAddress As Address
        Public Property ShipToContactOverride As JsonBooleanValue
        Public Property ShipToContact As Contact
        Public Property ShipVia As JsonStringValue
        Public Property Status As JsonStringValue
        Public Property TaxTotal As JsonDoubleValue
        Public Property WillCall As JsonBooleanValue
        Public Property custom As Object



    End Class


End Namespace