Public Class UPSShippingRate

    Private _mRateName As String
    Public Property RateName() As String
        Get
            Return _mRateName
        End Get
        Set(ByVal Value As String)
            _mRateName = Value
        End Set
    End Property

    Private _mRate As Decimal
    Public Property Rate() As Decimal
        Get
            Return _mRate
        End Get
        Set(ByVal Value As Decimal)
            _mRate = Value
        End Set
    End Property

End Class
