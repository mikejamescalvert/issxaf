Namespace SOP
    Public Class SalesPayment
        Enum PaymentType
            Cash_Deposit = 0
            Check_Deposit = 1
            Payment_Card_Deposit = 2
            Cash_Payment = 3
            Check_Payment = 4
            Payment_Card_Payment = 5
        End Enum
        Private _mPaymentCardTypeKey As String = String.Empty
        Private _mSalesPaymentType As PaymentType = PaymentType.Payment_Card_Payment
        Private _mPaymentAmount As Decimal = "0"
        Private _mAuthorizationCode As String = String.Empty
        Private _mBankAccountKey As String = String.Empty
        Private _mPaymentCardNumber As String = String.Empty
        Private _mCheckNumber As String = String.Empty
        Private _mNumber As String = String.Empty
        Private _mExpirationDate As Date = "1/1/1900"
        Private _mAuditTrailCode As String = String.Empty
        Private _mDeleteOnUpdate As Boolean = False
        Private _mPaymentDate As Date

        Public Property SalesPaymentType() As PaymentType
            Get
                Return _mSalesPaymentType
            End Get
            Set(ByVal value As PaymentType)
                _mSalesPaymentType = value
            End Set
        End Property
        Public Property PaymentCardTypeKey() As String
            Get
                Return _mPaymentCardTypeKey
            End Get
            Set(ByVal value As String)
                _mPaymentCardTypeKey = value
            End Set
        End Property
        Public Property PaymentAmount() As Decimal
            Get
                Return _mPaymentAmount
            End Get
            Set(ByVal value As Decimal)
                _mPaymentAmount = value
            End Set
        End Property
        Public Property AuthorizationCode() As String
            Get
                Return _mAuthorizationCode
            End Get
            Set(ByVal value As String)
                _mAuthorizationCode = value
            End Set
        End Property
        Public Property BankAccountKey() As String
            Get
                Return _mBankAccountKey
            End Get
            Set(ByVal value As String)
                _mBankAccountKey = value
            End Set
        End Property
        Public Property PaymentCardNumber() As String
            Get
                Return _mPaymentCardNumber
            End Get
            Set(ByVal value As String)
                _mPaymentCardNumber = value
            End Set
        End Property
        Public Property CheckNumber() As String
            Get
                Return _mCheckNumber
            End Get
            Set(ByVal value As String)
                _mCheckNumber = value
            End Set
        End Property
        Public Property Number() As String
            Get
                Return _mNumber
            End Get
            Set(ByVal value As String)
                _mNumber = value
            End Set
        End Property
        Public Property ExpirationDate() As Date
            Get
                Return _mExpirationDate
            End Get
            Set(ByVal value As Date)
                _mExpirationDate = value
            End Set
        End Property
        Public Property AuditTrailCode() As String
            Get
                Return _mAuditTrailCode
            End Get
            Set(ByVal value As String)
                _mAuditTrailCode = value
            End Set
        End Property
        Public Property DeleteOnUpdate() As Boolean
            Get
                Return _mDeleteOnUpdate
            End Get
            Set(ByVal value As Boolean)
                _mDeleteOnUpdate = value
            End Set
        End Property
        Public Property PaymentDate() As Date
            Get
                Return Me._mPaymentDate
            End Get
            Set(ByVal value As Date)
                _mPaymentDate = value
            End Set
        End Property
    End Class
End Namespace

