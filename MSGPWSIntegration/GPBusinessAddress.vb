Public Class GPBusinessAddress
    Private _mName As String = String.Empty
    Private _mAddress1 As String = String.Empty
    Private _mAddress2 As String = String.Empty
    Private _mAddress3 As String = String.Empty
    Private _mCity As String = String.Empty
    Private _mState As String = String.Empty
    Private _mZip As String = String.Empty
    Private _mCountry As String = String.Empty
    Private _mCountryCode As String = String.Empty
    Private _mContactPerson As String = String.Empty
    Private _mPhoneNumber As String = String.Empty

    Public Sub New()
    End Sub

    Public Sub New(ByVal _Name As String, ByVal _Address1 As String, ByVal _Address2 As String, ByVal _Address3 As String, ByVal _City As String, ByVal _State As String, ByVal _Zip As String, ByVal _Country As String, ByVal _ContactPerson As String, ByVal _PhoneNumber As String, ByVal _CountryCode As String)
        _mName = _Name
        _mAddress1 = _Address1
        _mAddress2 = _Address2
        _mAddress3 = _Address3
        _mCity = _City
        _mState = _State
        _mZip = _Zip
        _mCountry = _Country
        _mCountryCode = _CountryCode
        _mContactPerson = _ContactPerson
        _mPhoneNumber = _PhoneNumber
    End Sub

    Public Property Name() As String
        Get
            Return _mName
        End Get
        Set(ByVal value As String)
            _mName = value
        End Set
    End Property
    Public Property Address1() As String
        Get
            Return _mAddress1
        End Get
        Set(ByVal value As String)
            _mAddress1 = value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return _mAddress2
        End Get
        Set(ByVal value As String)
            _mAddress2 = value
        End Set
    End Property
    Public Property Address3() As String
        Get
            Return _mAddress3
        End Get
        Set(ByVal value As String)
            _mAddress3 = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return _mCity
        End Get
        Set(ByVal value As String)
            _mCity = value
        End Set
    End Property
    Public Property State() As String
        Get
            Return _mState
        End Get
        Set(ByVal value As String)
            _mState = value
        End Set
    End Property
    Public Property Zip() As String
        Get
            Return _mZip
        End Get
        Set(ByVal value As String)
            _mZip = value
        End Set
    End Property
    Public Property Country() As String
        Get
            Return _mCountry
        End Get
        Set(ByVal value As String)
            _mCountry = value
        End Set
    End Property
    Public Property CountryCode As String
        Get
            Return _mCountryCode
        End Get
        Set(value As String)
            _mCountryCode = value
        End Set
    End Property
    Public Property ContactPerson() As String
        Get
            Return _mContactPerson
        End Get
        Set(ByVal value As String)
            _mContactPerson = value
        End Set
    End Property
    Public Property PhoneNumber() As String
        Get
            Return _mPhoneNumber
        End Get
        Set(ByVal value As String)
            _mPhoneNumber = value
        End Set
    End Property
End Class


