Public Interface IAddressPoint
    Property Address1 As String
    Property Address2 As String
    Property Address3 As String
    Property City As String
    Property State As String
    Property ZipCode As String
    Property CountryCode As String

    ReadOnly Property Latitude As Double
    ReadOnly Property Longitude As Double

    Sub SetLatLong(ByVal NewLat As Double, ByVal NewLong As Double)

End Interface
