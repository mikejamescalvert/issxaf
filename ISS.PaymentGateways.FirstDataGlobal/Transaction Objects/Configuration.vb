Public Class Configuration
    ' Fields...
    Private _mGatewayID As String
    Public Property GatewayID As String
        Get
            Return _mGatewayID
        End Get
        Set(ByVal Value As String)
            _mGatewayID = Value
        End Set
    End Property
    Private _mPassword As String
    Public Property Password As String
        Get
            Return _mPassword
        End Get
        Set(ByVal Value As String)
            _mPassword = Value
        End Set
    End Property
    Private _mTerminalKeyID As String
    Public Property TerminalKeyID As String
        Get
            Return _mTerminalKeyID
        End Get
        Set(ByVal Value As String)
            _mTerminalKeyID = Value
        End Set
    End Property
    Private _mHMACKey As String
    Public Property HMACKey As String
        Get
            Return _mHMACKey
        End Get
        Set(ByVal Value As String)
            _mHMACKey = Value
        End Set
    End Property

    Public Enum PurchaseTypes
        AuthorizeAndCapture = 0
        AuthorizeOnly = 1
    End Enum
    
    Private _mPurchaseType As PurchaseTypes
    Public Property PurchaseType As PurchaseTypes
        Get
            Return _mPurchaseType
        End Get
        Set(ByVal Value As PurchaseTypes)
            _mPurchaseType = Value
        End Set
    End Property
    
    Private _mTestMode As Boolean
    Public Property TestMode As Boolean
        Get
            Return _mTestMode
        End Get
        Set(ByVal Value As Boolean)
            _mTestMode = Value
        End Set
    End Property
    
    
End Class
