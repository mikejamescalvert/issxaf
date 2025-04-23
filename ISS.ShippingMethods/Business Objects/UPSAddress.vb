Public Class UPSAddress

    Private _mAddress1 As String
    Public Property Address1() As String
        Get
            Return _mAddress1
        End Get
        Set(ByVal Value As String)
            _mAddress1 = Value
        End Set
    End Property
    Private _mAddress2 As String
    Public Property Address2() As String
        Get
            Return _mAddress2
        End Get
        Set(ByVal Value As String)
            _mAddress2 = Value
        End Set
    End Property
    Private _mCity As String
    Public Property City() As String
        Get
            Return _mCity
        End Get
        Set(ByVal Value As String)
            _mCity = Value
        End Set
    End Property
    Private _mStateCode As String
    Public Property StateCode() As String
        Get
            Return _mStateCode
        End Get
        Set(ByVal Value As String)
            _mStateCode = Value
        End Set
    End Property
    Private _mPostalCode As String
    Public Property PostalCode() As String
        Get
            Return _mPostalCode
        End Get
        Set(ByVal Value As String)
            _mPostalCode = Value
        End Set
    End Property
    Private _mCountryCode As String = "US"
    Public Property CountryCode() As String
        Get
            Return _mCountryCode
        End Get
        Set(ByVal Value As String)
            _mCountryCode = Value
        End Set
    End Property


End Class
