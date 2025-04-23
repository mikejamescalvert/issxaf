Namespace PM

    Public Class PMCheck
        Private _batchNumber As String
        Property BatchNumber As String
            Get
                Return _batchNumber
            End Get
            Set(ByVal Value As String)
                _batchNumber = Value
            End Set
        End Property
        Private _mVoucherNumber As String
        Property VoucherNumber As String
            Get
                Return _mVoucherNumber
            End Get
            Set(ByVal Value As String)
                _mVoucherNumber = Value
            End Set
        End Property
        Private _mVendorId As String
        Property VendorId As String
            Get
                Return _mVendorId
            End Get
            Set(ByVal Value As String)
                _mVendorId = Value
            End Set
        End Property
        Private _mDocumentNumber As String
        Property DocumentNumber As String
            Get
                Return _mDocumentNumber
            End Get
            Set(ByVal Value As String)
                _mDocumentNumber = Value
            End Set
        End Property
        Private _mDocumentAmount As Decimal
        Property DocumentAmount As Decimal
            Get
                Return _mDocumentAmount
            End Get
            Set(ByVal Value As Decimal)
                _mDocumentAmount = Value
            End Set
        End Property
        Private _mDocumentDate As Date
        Property DocumentDate As Date
            Get
                Return _mDocumentDate
            End Get
            Set(ByVal Value As Date)
                _mDocumentDate = Value
            End Set
        End Property
        Private _mPaymentType As PaymentTypes
        Property PaymentType As PaymentTypes
            Get
                Return _mPaymentType
            End Get
            Set(ByVal Value As PaymentTypes)
                _mPaymentType = Value
            End Set
        End Property
        Private _mCardName As String
        Property CardName As String
            Get
                Return _mCardName
            End Get
            Set(ByVal Value As String)
                _mCardName = Value
            End Set
        End Property
        Private _mCheckbookId As String
        Property CheckbookId As String
            Get
                Return _mCheckbookId
            End Get
            Set(ByVal Value As String)
                _mCheckbookId = Value
            End Set
        End Property
        Private _mDescription As String
        Property Description As String
            Get
                Return _mDescription
            End Get
            Set(ByVal Value As String)
                _mDescription = Value
            End Set
        End Property
        Private _mUserDefined1 As String
        Property UserDefined1 As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal Value As String)
                _mUserDefined1 = Value
            End Set
        End Property
        Private _mUserDefined2 As String
        Property UserDefined2 As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal Value As String)
                _mUserDefined2 = Value
            End Set
        End Property
        Private _mUserDefined3 As String
        Property UserDefined3 As String
            Get
                Return _mUserDefined3
            End Get
            Set(ByVal Value As String)
                _mUserDefined3 = Value
            End Set
        End Property
        Private _mUserDefined4 As String
        Property UserDefined4 As String
            Get
                Return _mUserDefined4
            End Get
            Set(ByVal Value As String)
                _mUserDefined4 = Value
            End Set
        End Property
        Private _mUserDefined5 As String
        Property UserDefined5 As String
            Get
                Return _mUserDefined5
            End Get
            Set(ByVal Value As String)
                _mUserDefined5 = Value
            End Set
        End Property
        Private _mBatchCheckbookId As String
        Property BatchCheckbookId As String
            Get
                Return _mBatchCheckbookId
            End Get
            Set(ByVal Value As String)
                _mBatchCheckbookId = Value
            End Set
        End Property
        

        Public Enum PaymentTypes
            Check = 0
            Cash = 1
            CreditCard = 2
        End Enum

    End Class

End Namespace
