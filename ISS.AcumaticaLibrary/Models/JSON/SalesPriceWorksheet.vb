Namespace Models.JSON


    Public Class SalesPriceWorksheet
        Public Sub New()
            SalesPrices = New List(Of SalesPriceWorksheetDetail)
        End Sub
        Public Property id As String
        Public Property CreatedDateTime As JsonDateTimeValue

        Public Property Description As JsonStringValue
        Public Property EffectiveDate As JsonDateTimeValue
        Public Property ExpirationDate As JsonDateTimeValue
        Public Property Hold As JsonBooleanValue

        Public Property LastModifiedDateTime As JsonDateTimeValue
        Public Property OverwriteOverlappingPrices As JsonBooleanValue
        Public Property ReferenceNbr As JsonStringValue
        Public Property Status As JsonStringValue


        Public Property SalesPrices As List(Of SalesPriceWorksheetDetail)

    End Class


End Namespace