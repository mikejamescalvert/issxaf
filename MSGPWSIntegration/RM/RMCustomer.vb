Namespace RM

    Public Class RMCustomer
        Private _mCustomerKey As String = String.Empty
        Private _mCustomerName As String = String.Empty
        Private _mClassKey As String = String.Empty
        Private _mComment1 As String = String.Empty
        Private _mComment2 As String = String.Empty
        Private _mCreatedDate As Date = "1/1/1900"
        Private _mIsOnHold As Boolean = False
        Private _mIsActive As Boolean = True
        Private _mName As String = String.Empty
        Private _mNotes As String = String.Empty
        Private _mShortname As String = String.Empty
        Private _mPriority As Integer = 0
        Private _mPaymentTermsKey As String = String.Empty
        Private _mShipCompleteOnly As Boolean = False
        Private _mUserDefined1 As String = String.Empty
        Private _mUserDefined2 As String = String.Empty
        Private _mTaxRegistrationNumber As String = String.Empty
        Private _mStatementName As String = String.Empty
        Private _mDiscountGracePeriod As Integer = 0
        Private _mDueDateGracePeriod As Integer = 0
        Private _mPriceLevelKey As String = String.Empty
        Private _mTradeDiscountPercent As Decimal = 0
        Private _mBillToAddressKey As String = String.Empty
        Private _mShipToAddressKey As String = String.Empty
        Private _mDefaultAddressKey As String = String.Empty
        Private _mStatementToAddressKey As String = String.Empty
        Private _mCustomerAddresses As RMCustomerAddresses = New RMCustomerAddresses
        Private _mTaxExemptNumber1 As String
        Private _mTaxExemptNumber2 As String
        Public Property CustomerKey() As String
            Get
                Return _mCustomerKey
            End Get
            Set(ByVal value As String)
                _mCustomerKey = value
            End Set
        End Property
        Public Property CustomerName() As String
            Get
                Return _mCustomerName
            End Get
            Set(ByVal value As String)
                _mCustomerName = value
            End Set
        End Property
        Public Property ClassKey() As String
            Get
                Return _mClassKey
            End Get
            Set(ByVal value As String)
                _mClassKey = value
            End Set
        End Property
        Public Property Comment1() As String
            Get
                Return _mComment1
            End Get
            Set(ByVal value As String)
                _mComment1 = value
            End Set
        End Property
        Public Property Comment2() As String
            Get
                Return _mComment2
            End Get
            Set(ByVal value As String)
                _mComment2 = value
            End Set
        End Property
        Public Property CreatedDate() As Date
            Get
                Return _mCreatedDate
            End Get
            Set(ByVal value As Date)
                _mCreatedDate = value
            End Set
        End Property
        Public Property IsOnHold() As Boolean
            Get
                Return _mIsOnHold
            End Get
            Set(ByVal value As Boolean)
                _mIsOnHold = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                Return _mIsActive
            End Get
            Set(ByVal value As Boolean)
                _mIsActive = value
            End Set
        End Property
        Public Property Notes() As String
            Get
                Return _mNotes
            End Get
            Set(ByVal value As String)
                _mNotes = value
            End Set
        End Property
        Public Property Shortname() As String
            Get
                Return _mShortname
            End Get
            Set(ByVal value As String)
                _mShortname = value
            End Set
        End Property
        Public Property Priority() As Integer
            Get
                Return _mPriority
            End Get
            Set(ByVal value As Integer)
                _mPriority = value
            End Set
        End Property
        Public Property PaymentTermsKey() As String
            Get
                Return _mPaymentTermsKey
            End Get
            Set(ByVal value As String)
                _mPaymentTermsKey = value
            End Set
        End Property
        Public Property ShipCompleteOnly() As Boolean
            Get
                Return _mShipCompleteOnly
            End Get
            Set(ByVal value As Boolean)
                _mShipCompleteOnly = value
            End Set
        End Property
        Public Property UserDefined1() As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal value As String)
                _mUserDefined1 = value
            End Set
        End Property
        Public Property UserDefined2() As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal value As String)
                _mUserDefined2 = value
            End Set
        End Property
        Public Property TaxRegistrationNumber() As String
            Get
                Return _mTaxRegistrationNumber
            End Get
            Set(ByVal value As String)
                _mTaxRegistrationNumber = value
            End Set
        End Property
        Public Property StatementName() As String
            Get
                Return _mStatementName
            End Get
            Set(ByVal value As String)
                _mStatementName = value
            End Set
        End Property
        Public Property DiscountGracePeriod() As Integer
            Get
                Return _mDiscountGracePeriod
            End Get
            Set(ByVal value As Integer)
                _mDiscountGracePeriod = value
            End Set
        End Property
        Public Property DueDateGracePeriod() As Integer
            Get
                Return _mDueDateGracePeriod
            End Get
            Set(ByVal value As Integer)
                _mDueDateGracePeriod = value
            End Set
        End Property
        Public Property PriceLevelKey() As String
            Get
                Return _mPriceLevelKey
            End Get
            Set(ByVal value As String)
                _mPriceLevelKey = value
            End Set
        End Property
        Public Property TradeDiscountPercent() As Decimal
            Get
                Return _mTradeDiscountPercent
            End Get
            Set(ByVal value As Decimal)
                _mTradeDiscountPercent = value
            End Set
        End Property
        Public Property BillToAddressKey() As String
            Get
                Return _mBillToAddressKey
            End Get
            Set(ByVal value As String)
                _mBillToAddressKey = value
            End Set
        End Property
        Public Property ShipToAddressKey() As String
            Get
                Return _mShipToAddressKey
            End Get
            Set(ByVal value As String)
                _mShipToAddressKey = value
            End Set
        End Property
        Public Property DefaultAddressKey() As String
            Get
                Return _mDefaultAddressKey
            End Get
            Set(ByVal value As String)
                _mDefaultAddressKey = value
            End Set
        End Property
        Public Property StatementToAddressKey() As String
            Get
                Return _mStatementToAddressKey
            End Get
            Set(ByVal value As String)
                _mStatementToAddressKey = value
            End Set
        End Property
        Public Property CustomerAddresses() As RMCustomerAddresses
            Get
                Return _mCustomerAddresses
            End Get
            Set(ByVal value As RMCustomerAddresses)
                _mCustomerAddresses = value
            End Set
        End Property
        Public Property TaxExemptNumber1() As String
            Get
                Return _mTaxExemptNumber1
            End Get
            Set(ByVal value As String)
                If _mTaxExemptNumber1 = Value Then
                    Return
                End If
                _mTaxExemptNumber1 = Value
            End Set
        End Property
        Public Property TaxExemptNumber2() As String
            Get
                Return _mTaxExemptNumber2
            End Get
            Set(ByVal value As String)
                If _mTaxExemptNumber2 = Value Then
                    Return
                End If
                _mTaxExemptNumber2 = Value
            End Set
        End Property

    End Class
End Namespace