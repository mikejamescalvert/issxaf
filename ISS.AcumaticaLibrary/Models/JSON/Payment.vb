Namespace Models.JSON
    Public Class Payment
        Public Property id As String
        Public Property note As JsonStringValue
        Public Property ReferenceNbr As JsonStringValue
        Public Property PaymentAmount As JsonDoubleValue
        Public Property CustomerID As JsonStringValue
        Public Property ApplicationDate As JsonDateTimeValue

        Public Property Status As JsonStringValue
        Public Property PaymentRef As JsonStringValue

    End Class
End Namespace

