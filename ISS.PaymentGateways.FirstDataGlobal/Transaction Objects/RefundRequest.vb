Public Class RefundRequest
    ' Fields...' Fields...
    Private _mOrderNumber As String
    Public Property OrderNumber As String
        Get
            Return _mOrderNumber
        End Get
        Set(ByVal Value As String)
            _mOrderNumber = Value
        End Set
    End Property
    Private _mZipCode As String
    Public Property ZipCode As String
        Get
            Return _mZipCode
        End Get
        Set(ByVal Value As String)
            _mZipCode = Value
        End Set
    End Property
    Private _mCustomerID As String
    Public Property CustomerID As String
        Get
            Return _mCustomerID
        End Get
        Set(ByVal Value As String)
            _mCustomerID = Value
        End Set
    End Property
    Private _mCustomerIP As String = "127.0.0.1"
    Public Property CustomerIP As String 
        Get
            Return _mCustomerIP
        End Get
        Set(ByVal Value As String )
            _mCustomerIP = Value
        End Set
    End Property
    Private _mCustomerEmail As String
    Public Property CustomerEmail As String
        Get
            Return _mCustomerEmail
        End Get
        Set(ByVal Value As String)
            _mCustomerEmail = Value
        End Set
    End Property
    Private _mCurrencyCode As String = "USD"
    Public Property CurrencyCode As String 
        Get
            Return _mCurrencyCode
        End Get
        Set(ByVal Value As String )
            _mCurrencyCode = Value
        End Set
    End Property
    Private _mFirstName As String
    Public Property FirstName As String
        Get
            Return _mFirstName
        End Get
        Set(ByVal Value As String)
            _mFirstName = Value
        End Set
    End Property
    Private _mLastName As String
    Public Property LastName As String
        Get
            Return _mLastName
        End Get
        Set(ByVal Value As String)
            _mLastName = Value
        End Set
    End Property
    Private _mExpirationMonth As Integer
    Public Property ExpirationMonth As Integer
        Get
            Return _mExpirationMonth
        End Get
        Set(ByVal Value As Integer)
            _mExpirationMonth = Value
        End Set
    End Property
    Private _mExpirationYear As Integer
    Public Property ExpirationYear As Integer
        Get
            Return _mExpirationYear
        End Get
        Set(ByVal Value As Integer)
            _mExpirationYear = Value
        End Set
    End Property
    Private _mCardNumberDigitsOnly As String
    Public Property CardNumberDigitsOnly As String
        Get
            Return _mCardNumberDigitsOnly
        End Get
        Set(ByVal Value As String)
            _mCardNumberDigitsOnly = Value
        End Set
    End Property
    Private _mCardCodeDigitsOnly As String
    Public Property CardCodeDigitsOnly As String
        Get
            Return _mCardCodeDigitsOnly
        End Get
        Set(ByVal Value As String)
            _mCardCodeDigitsOnly = Value
        End Set
    End Property
    Private _mOrderTotal As Decimal
    Public Property OrderTotal As Decimal
        Get
            Return _mOrderTotal
        End Get
        Set(ByVal Value As Decimal)
            _mOrderTotal = Value
        End Set
    End Property
    
End Class
