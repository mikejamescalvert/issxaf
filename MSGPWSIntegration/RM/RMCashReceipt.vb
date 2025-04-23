Imports DevExpress.Xpo
Namespace RM
    Public Class RMCashReceipt
        Private _mCreditCardNumber As String
        Public Property CreditCardNumber() As String
            Get
                Return _mCreditCardNumber
            End Get
            Set(ByVal Value As String)
                _mCreditCardNumber = Value
            End Set
        End Property
        Private _mCustomerNumber As String
        Public Property CustomerNumber() As String
            Get
                Return _mCustomerNumber
            End Get
            Set(ByVal Value As String)
                _mCustomerNumber = Value
            End Set
        End Property
        Private _mInvoiceNumber As String
        Public Property InvoiceNumber() As String
            Get
                Return _mInvoiceNumber
            End Get
            Set(ByVal Value As String)
                _mInvoiceNumber = Value
            End Set
        End Property
        Private _mAmount As Decimal
        Public Property Amount() As Decimal
            Get
                Return _mAmount
            End Get
            Set(ByVal Value As Decimal)
                _mAmount = Value
            End Set
        End Property
        Private _mPaymentTypeKey As String
        Public Property PaymentTypeKey As String
            Get
                Return _mPaymentTypeKey
            End Get
            Set(ByVal Value As String)
                _mPaymentTypeKey = Value
            End Set
        End Property
        Private _mDescription As String
        Public Property Description As String
            Get
                Return _mDescription
            End Get
            Set(ByVal Value As String)
                _mDescription = Value
            End Set
        End Property
        
    End Class

End Namespace
