Namespace Models.Json



    Public Class EmsResponse
        Public Property shipDate As String
        Public Property shipTime As String
        Public Property serviceLevel As String
        Public Property billType As String
        Public Property dutyType As String
        Public Property residentialIndicator As String
        Public Property destinationCountryName As String
        Public Property destinationCountryCode As String
        Public Property destinationPostalCode As String
        Public Property destinationPostalCodeLow As String
        Public Property destinationPostalCodeHigh As String
        Public Property destinationStateProvince As String
        Public Property destinationCityName As String
        Public Property originCountryName As String
        Public Property originCountryCode As String
        Public Property originPostalCode As String
        Public Property originPostalCodeLow As String
        Public Property originPostalCodeHigh As String
        Public Property originStateProvince As String
        Public Property originCityName As String
        Public Property weight As String
        Public Property weightUnitOfMeasure As String
        Public Property shipmentContentsValue As String
        Public Property shipmentContentsCurrencyCode As String
        Public Property guaranteeSuspended As Boolean
        Public Property numberOfServices As Integer
        Public Property services As EmsService()
    End Class


End Namespace