Namespace Models.JSON
    Public Class Invoice
        Public Property id As String
        Public Property note As JsonStringValue
        Public Property Amount As JsonDoubleValue
        Public Property Balance As JsonDoubleValue
        Public Property Customer As JsonStringValue
        Public Property [Date] As JsonDateTimeValue
        Public Property DueDate As JsonDateTimeValue
        Public Property ReferenceNbr As JsonStringValue
        Public Property Type As JsonStringValue
    End Class
End Namespace

