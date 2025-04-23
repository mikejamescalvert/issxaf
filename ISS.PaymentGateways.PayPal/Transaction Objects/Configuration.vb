Public Class Configuration
    
    
    Private _mTestMode As Boolean
    Public Property TestMode As Boolean
        Get
            Return _mTestMode
        End Get
        Set(ByVal Value As Boolean)
            _mTestMode = Value
        End Set
    End Property

    Public ReadOnly Property URL As String
        Get
            If TestMode = True
                Return "pilot-payflowpro.paypal.com"
            Else
                Return "payflowpro.paypal.com"
            End If
        End Get
    End Property
    
    
    Private _mPayPalUser As String
    Public Property PayPalUser As String
        Get
            Return _mPayPalUser
        End Get
        Set(ByVal Value As String)
      _mPayPalUser = Value
        End Set
    End Property
    Private _mPayPalPassword As String
    Public Property PayPalPassword As String
        Get
            Return _mPayPalPassword
        End Get
        Set(ByVal Value As String)
      _mPayPalPassword = Value
        End Set
    End Property
    Private _mPayPalVendor As String
    Public Property PayPalVendor As String
        Get
            Return _mPayPalVendor
        End Get
        Set(ByVal Value As String)
      _mPayPalVendor = Value
        End Set
    End Property
    Private _mPayPalPartner As String
    Public Property PayPalPartner As String
        Get
            Return _mPayPalPartner
        End Get
        Set(ByVal Value As String)
      _mPayPalPartner = Value
        End Set
    End Property
    
End Class
