
Namespace POP
    Public Class POPHeader
        Private _mVendorID As String = String.Empty
        Private _mVendorName As String = String.Empty
        Private _mPOType As POTypes = POTypes.Standard
        Private _mBuyerID As String = String.Empty
        Private _mOrderDate As Date?
        Private _mRequestedShipDate As Date?
        Private _mShipMethod As String = String.Empty
        Private _mPaymentTerms As String = String.Empty
        Private _mCommentID As String = String.Empty
        Private _mComment As String = String.Empty
        Private _mPurchaseAddress As MSGPWSIntegration.GPBusinessAddress
        Private _mShipToAddress As MSGPWSIntegration.GPBusinessAddress
        Private _mDoesAllowSalesOrderCommitments As Boolean = False

        Public Sub New()
            _mPurchaseAddress = New MSGPWSIntegration.GPBusinessAddress
            _mShipToAddress = New MSGPWSIntegration.GPBusinessAddress
        End Sub
        Public Sub New(ByVal VendorID As String, ByVal VendorName As String, ByVal POType As POtypes, ByVal OrderDate As Date, ByVal RequestedShipDate As Date, ByVal ShipMethod As String, ByVal PaymentTerms As String, ByVal CommentID As String, ByVal Comment As String, ByVal PurchaseAddress As MSGPWSIntegration.GPBusinessAddress, ByVal ShipToAddress As MSGPWSIntegration.GPBusinessAddress)
            _mVendorID = VendorID
            _mVendorName = VendorName
            _mPOType = POType
            _mOrderDate = OrderDate
            _mRequestedShipDate = RequestedShipDate
            _mShipMethod = ShipMethod
            _mPaymentTerms = PaymentTerms
            _mCommentID = CommentID
            _mComment = Comment
            _mPurchaseAddress = PurchaseAddress
            _mShipToAddress = ShipToAddress
        End Sub
        Private _mPONumber As String
        Public Property PONumber As String
            Get
                Return _mPONumber
            End Get
            Set(ByVal Value As String)
                _mPONumber = Value
            End Set
        End Property


        Public Property VendorID() As String
            Get
                Return _mVendorID
            End Get
            Set(ByVal value As String)
                _mVendorID = value
            End Set
        End Property

        Public Property VendorName() As String
            Get
                Return _mVendorName
            End Get
            Set(ByVal value As String)
                _mVendorName = value
            End Set
        End Property

        Public Property POType() As POtypes
            Get
                Return _mPOType
            End Get
            Set(ByVal value As POtypes)
                _mPOType = value
            End Set
        End Property

        Public Property BuyerID() As String
            Get
                Return _mBuyerID
            End Get
            Set(ByVal value As String)
                _mBuyerID = value
            End Set
        End Property
        Public Property OrderDate() As Date?
            Get
                Return _mOrderDate
            End Get
            Set(ByVal value As Date?)
                _mOrderDate = value
            End Set
        End Property
        Public Property RequestedShipDate() As Date?
            Get
                Return _mRequestedShipDate
            End Get
            Set(ByVal value As Date?)
                _mRequestedShipDate = value
            End Set
        End Property
        Public Property ShipMethod() As String
            Get
                Return _mShipMethod
            End Get
            Set(ByVal value As String)
                _mShipMethod = value
            End Set
        End Property
        Public Property PaymentTerms() As String
            Get
                Return _mPaymentTerms
            End Get
            Set(ByVal value As String)
                _mPaymentTerms = value
            End Set
        End Property
        Public Property CommentID() As String
            Get
                Return _mCommentID
            End Get
            Set(ByVal value As String)
                _mCommentID = value
            End Set
        End Property
        Public Property Comment() As String
            Get
                Return _mComment
            End Get
            Set(ByVal value As String)
                _mComment = value
            End Set
        End Property
        Public Property PurchaseAddress() As MSGPWSIntegration.GPBusinessAddress
            Get
                Return _mPurchaseAddress
            End Get
            Set(ByVal value As MSGPWSIntegration.GPBusinessAddress)
                _mPurchaseAddress = value
            End Set
        End Property
        Public Property ShipToAddress() As MSGPWSIntegration.GPBusinessAddress
            Get
                Return _mShipToAddress
            End Get
            Set(ByVal value As MSGPWSIntegration.GPBusinessAddress)
                _mShipToAddress = value
            End Set
        End Property

        Public Property DoesAllowSalesOrderCommitments() As Boolean
            Get
                Return _mDoesAllowSalesOrderCommitments
            End Get
            Set(ByVal value As Boolean)
                _mDoesAllowSalesOrderCommitments = value
            End Set
        End Property


    End Class
End Namespace

