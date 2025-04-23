Public Class SuggestedAddress
    Implements ISuggestedAddress

    Public Property Address1 As String Implements IAddressPoint.Address1


    Public Property Address2 As String Implements IAddressPoint.Address2


    Public Property Address3 As String Implements IAddressPoint.Address3


    Public Property City As String Implements IAddressPoint.City


    Public Property State As String Implements IAddressPoint.State

    Public Property ZipCode As String Implements IAddressPoint.ZipCode


    Public Property CountryCode As String Implements IAddressPoint.CountryCode

    Private _mLatitude As Double
    Public ReadOnly Property Latitude As Double Implements IAddressPoint.Latitude
        Get
            Return _mLatitude
        End Get
    End Property

    Private _mLongitude As Double
    Public ReadOnly Property Longitude As Double Implements IAddressPoint.Longitude
        Get
            Return _mLongitude
        End Get
    End Property

    Public Sub SetLatLong(ByVal NewLat As Double, ByVal NewLong As Double) Implements IAddressPoint.SetLatLong
        _mLatitude = NewLat
        _mLongitude = NewLong
    End Sub
End Class
