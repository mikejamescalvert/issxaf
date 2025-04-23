Namespace Models
    Public Class UPSConfiguration
        Private _mClientID As String
        Property ClientID As String
            Get
                Return _mClientID
            End Get
            Set(ByVal Value As String)
                _mClientID = Value
            End Set
        End Property
        Private _mClientSecret As String
        Property ClientSecret As String
            Get
                Return _mClientSecret
            End Get
            Set(ByVal Value As String)
                _mClientSecret = Value
            End Set
        End Property
        Private _mSandbox As Boolean
        Property Sandbox As Boolean
            Get
                Return _mSandbox
            End Get
            Set(ByVal Value As Boolean)
                _mSandbox = Value
            End Set
        End Property

        Public ReadOnly Property UpsAuthUrl As String
            Get
                If Sandbox = True Then
                    Return "https://wwwcie.ups.com/"
                Else
                    Return "https://onlinetools.ups.com/"
                End If

            End Get
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
            Set(ByVal Value As String)
                _mWeightUnits = Value
            End Set
        End Property
        Private _mMinimumPackageWeight As Decimal = 0.5
        Public Property MinimumPackageWeight() As Decimal
            Get
                Return _mMinimumPackageWeight
            End Get
            Set(ByVal Value As Decimal)
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
        Private _mMaxWeight As Decimal
        Property MaxWeight As Decimal
            Get
                Return _mMaxWeight
            End Get
            Set(ByVal Value As Decimal)
                _mMaxWeight = Value
            End Set
        End Property

        Private _mAccountNumber As String
        Property AccountNumber As String
            Get
                Return _mAccountNumber
            End Get
            Set(ByVal Value As String)
                _mAccountNumber = Value
            End Set
        End Property
        Private _mPickupCodeOverride As String
        Property PickupCodeOverride As String
            Get
                Return _mPickupCodeOverride
            End Get
            Set(ByVal Value As String)
                _mPickupCodeOverride = Value
            End Set
        End Property
        Public Property ShipperName As String

    End Class
End Namespace