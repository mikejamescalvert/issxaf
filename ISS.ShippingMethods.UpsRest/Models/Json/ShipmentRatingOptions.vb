Namespace Models.Json


    Public MustInherit Class ShipmentRatingOptions

    End Class
    Public Class NegotiatedShipmentRatingOptions
        Inherits ShipmentRatingOptions
        Public Property NegotiatedRatesIndicator As String = "Y"
    End Class
    Public Class RateChartShipmentRatingOptions
        Inherits ShipmentRatingOptions
        Public Property RateChartIndicator As String = "Y"
    End Class


End Namespace