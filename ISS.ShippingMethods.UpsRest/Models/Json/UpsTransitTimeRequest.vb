Namespace Models.Json

    Public Class UpsTransitTimeRequest
        Public Property originCountryCode As String
        Public Property originStateProvince As String
        Public Property originCityName As String
        Public Property originTownName As String
        Public Property originPostalCode As String
        Public Property destinationCountryCode As String
        Public Property destinationStateProvince As String
        Public Property destinationCityName As String
        Public Property destinationTownName As String
        Public Property destinationPostalCode As String
        Public Property weight As String
        Public Property weightUnitOfMeasure As String
        Public Property shipmentContentsValue As String
        Public Property shipmentContentsCurrencyCode As String
        Public Property billType As String
        Public Property shipDate As String
        Public Property shipTime As String
        Public Property residentialIndicator As String
        Public Property avvFlag As Boolean
        Public Property numberOfPackages As String
    End Class

End Namespace