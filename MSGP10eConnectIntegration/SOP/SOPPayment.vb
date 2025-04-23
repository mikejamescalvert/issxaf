Namespace SOP
    Public Class SOPPayment

        Public Enum SOPDocTypes
            Quote = 1
            Order = 2
            Invoice = 3
            OrderReturn = 4
            BackOrder = 5
            FullfillmentOrder = 6
        End Enum

        Public Enum SOPPaymentTypes
            CashDeposit = 1
            CheckDeposit = 2
            CreditCardDeposit = 3
            CashPayment = 4
            CheckPayment = 5
            CreditCardPayment = 6
        End Enum

        Private _mSopType As SOPDocTypes
        <MSGPRequiredField()>
        Public Property SopType As SOPDocTypes
            Get
                Return _mSopType
            End Get
            Set(ByVal Value As SOPDocTypes)
                If _mSopType = Value Then
                    Return
                End If
                _mSopType = Value
            End Set
        End Property
        Private Shared _mSopNumber As String
        <MSGPRequiredField()>
        Public Shared Property SopNumber As String
            Get
                Return _mSopNumber
            End Get
            Set(ByVal Value As String)
                _mSopNumber = Value
            End Set
        End Property
        
        Private _mPaymentType As SOPPaymentTypes
        Public Property PaymentType As SOPPaymentTypes
            Get
                Return _mPaymentType
            End Get
            Set(ByVal Value As SOPPaymentTypes)
                _mPaymentType = Value
            End Set
        End Property

        Private _mCardName As String
        Public Property CardName As String
            Get
                Return _mCardName
            End Get
            Set(ByVal Value As String)
                _mCardName = Value
            End Set
        End Property

        Private _mDocumentAmount As Decimal
        Public Property DocumentAmount As Decimal
            Get
                Return _mDocumentAmount
            End Get
            Set(ByVal Value As Decimal)
                _mDocumentAmount = Value
            End Set
        End Property

        Private _mAuthorizationCode As String
        Public Property AuthorizationCode As String
            Get
                Return _mAuthorizationCode
            End Get
            Set(ByVal Value As String)
                _mAuthorizationCode = Value
            End Set
        End Property

        Private _mExpirationDate As DateTime
        Public Property ExpirationDate As DateTime
            Get
                Return _mExpirationDate
            End Get
            Set(ByVal Value As DateTime)
                _mExpirationDate = Value
            End Set
        End Property

        Private _mCardNumber As String
        Public Property CardNumber As String
            Get
                Return _mCardNumber
            End Get
            Set(ByVal Value As String)
                _mCardNumber = Value
            End Set
        End Property

    End Class
End Namespace