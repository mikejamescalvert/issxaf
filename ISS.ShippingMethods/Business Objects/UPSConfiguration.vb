Public Class UPSConfiguration
    Private _mUsername As String
    Public Property Username() As String
        Get
            Return _mUsername
        End Get
        Set(ByVal Value As String)
            _mUsername = Value
        End Set
    End Property
    Private _mPassword As String
    Public Property Password() As String
        Get
            Return _mPassword
        End Get
        Set(ByVal Value As String)
            _mPassword = Value
        End Set
    End Property
    Private _mLicenseKey As String
    Public Property LicenseKey() As String
        Get
            Return _mLicenseKey
        End Get
        Set(ByVal Value As String)
            _mLicenseKey = Value
        End Set
    End Property
    Private _mTestMode As Boolean = False
    Public Property TestMode() As Boolean
        Get
            Return _mTestMode
        End Get
        Set(ByVal Value As Boolean)
            _mTestMode = Value
        End Set
    End Property
    Private _mTestServerAddress As String = "https://wwwcie.ups.com/ups.app/xml/Rate"
    Public Property TestServerAddress() As String
        Get
            Return _mTestServerAddress
        End Get
        Set(ByVal Value As String)
            _mTestServerAddress = Value
        End Set
    End Property
    Private _mLiveServerAddress As String = "https://onlinetools.ups.com/ups.app/xml/Rate"
    Public Property LiveServerAddress() As String
        Get
            Return _mLiveServerAddress
        End Get
        Set(ByVal Value As String)
            _mLiveServerAddress = Value
        End Set
    End Property
    Private _mMaxWeight As Decimal = 150
    Public Property MaxWeight() As Decimal 
        Get
            Return _mMaxWeight
        End Get
        Set(ByVal Value As Decimal )
            _mMaxWeight = Value
        End Set
    End Property
    Private _mOriginAddress As New UPSAddress
    Public Property OriginAddress() As UPSAddress
        Get
            Return _mOriginAddress
        End Get
        Set(ByVal Value As UPSAddress)
            _mOriginAddress = Value
        End Set
    End Property
    Private _mWeightUnits As String = "LBS"
    Public Property WeightUnits() As String 
        Get
            Return _mWeightUnits
        End Get
        Set(ByVal Value As String )
            _mWeightUnits = Value
        End Set
    End Property
    Private _mMinimumPackageWeight As Decimal = 0.5
    Public Property MinimumPackageWeight() As Decimal 
        Get
            Return _mMinimumPackageWeight
        End Get
        Set(ByVal Value As Decimal )
            _mMinimumPackageWeight = Value
        End Set
    End Property
    Private _mAllowInsurance As Boolean = False
    Public Property AllowInsurance() As Boolean
        Get
            Return _mAllowInsurance
        End Get
        Set(ByVal Value As Boolean)
            _mAllowInsurance = Value
        End Set
    End Property
    Private _mMarkupPercent As Decimal = 0
    Public Property MarkupPercent() As Decimal
        Get
            Return _mMarkupPercent
        End Get
        Set(ByVal Value As Decimal)
            _mMarkupPercent = Value
        End Set
    End Property
    Private _mMarkupFee As Decimal = 0
    Public Property MarkupFee() As Decimal
        Get
            Return _mMarkupFee
        End Get
        Set(ByVal Value As Decimal)
            _mMarkupFee = Value
        End Set
    End Property



End Class
