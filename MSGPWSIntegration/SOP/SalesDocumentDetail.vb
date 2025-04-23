Namespace SOP
    Public Class SalesDocumentDetail
        Private _mItemNumber As String = String.Empty
        Private _mQuantity As Decimal = -1
        Private _mQuantityToBackOrder As Decimal = -1
        Private _mQuantityToInvoice As Decimal = -1
        Private _mQuantityCanceled As Decimal = -1
        Private _mQuantityFullFilled As Decimal = -1
        Private _mSellPrice As Decimal = 0
        Private _mDiscountAmount As Decimal = 0
        Private _mRequestedShipDate As Date
        Private _mFulfillDate As Date
        Private _mLineSequenceNumber As Integer
        Private _mItemDescription As String
        Private _mShippingMethodKey As String
        Private _mShipToAddressKey As String
        Private _mTaxScheduleKey As String
        Private _mItemTaxScheduleKey As String
        Private _mDeleteLine As Boolean

        Public Property ShippingMethodKey() As String
            Get
                Return _mShippingMethodKey
            End Get
            Set(ByVal value As String)
                If _mShippingMethodKey = value Then
                    Return
                End If
                _mShippingMethodKey = value
            End Set
        End Property
        Public Property ShipToAddressKey() As String
            Get
                Return _mShipToAddressKey
            End Get
            Set(ByVal value As String)
                If _mShipToAddressKey = value Then
                    Return
                End If
                _mShipToAddressKey = value
            End Set
        End Property
        Public Property TaxScheduleKey() As String
            Get
                Return _mTaxScheduleKey
            End Get
            Set(ByVal value As String)
                If _mTaxScheduleKey = value Then
                    Return
                End If
                _mTaxScheduleKey = value
            End Set
        End Property
        Public Property ItemTaxScheduleKey() As String
            Get
                Return _mItemTaxScheduleKey
            End Get
            Set(ByVal value As String)
                If _mItemTaxScheduleKey = value Then
                    Return
                End If
                _mItemTaxScheduleKey = value
            End Set
        End Property
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal value As String)
                _mItemNumber = value
            End Set
        End Property

        Public Property Quantity() As Decimal
            Get
                Return _mQuantity
            End Get
            Set(ByVal value As Decimal)
                _mQuantity = value
            End Set
        End Property
        Public Property QuantityToBackOrder() As Decimal
            Get
                Return _mQuantityToBackOrder
            End Get
            Set(ByVal value As Decimal)
                _mQuantityToBackOrder = value
            End Set
        End Property
        Public Property QuantityToInvoice() As Decimal
            Get
                Return _mQuantityToInvoice
            End Get
            Set(ByVal value As Decimal)
                _mQuantityToInvoice = value
            End Set
        End Property
        Public Property QuantityCanceled() As Decimal
            Get
                Return Me._mQuantityCanceled
            End Get
            Set(ByVal value As Decimal)
                _mQuantityCanceled = value
            End Set
        End Property
        Public Property QuantityFullFilled() As Decimal
            Get
                Return Me._mQuantityFullFilled
            End Get
            Set(ByVal value As Decimal)
                _mQuantityFullFilled = value
            End Set
        End Property
        Public Property DiscountAmount As Decimal
            Get
                Return _mDiscountAmount
            End Get
            Set(value As Decimal)
                _mDiscountAmount = value
            End Set
        End Property

        Private _mTaxAmount As Decimal?
        Public Property TaxAmount As Decimal?
            Get
                Return _mTaxAmount
            End Get
            Set(ByVal Value As Decimal?)
                _mTaxAmount = Value
            End Set
        End Property
        Private _mNonTaxable As Boolean
        Public Property NonTaxable As Boolean
            Get
                Return _mNonTaxable
            End Get
            Set(ByVal Value As Boolean)
                _mNonTaxable = Value
            End Set
        End Property
        

        Public Property SellPrice() As Decimal
            Get
                Return _mSellPrice
            End Get
            Set(ByVal value As Decimal)
                _mSellPrice = value
            End Set
        End Property
        Public Property RequestedShipDate() As Date
            Get
                Return _mRequestedShipDate
            End Get
            Set(ByVal value As Date)
                _mRequestedShipDate = value
            End Set
        End Property
        Public Property FulfillDate() As Date
            Get
                Return _mFulfillDate
            End Get
            Set(ByVal value As Date)
                _mFulfillDate = value
            End Set
        End Property
        Public Property LineSequenceNumber() As Integer
            Get
                Return _mLineSequenceNumber
            End Get
            Set(ByVal value As Integer)
                _mLineSequenceNumber = value
            End Set
        End Property
        Public Property ItemDescription() As String
            Get
                Return _mItemDescription
            End Get
            Set(ByVal value As String)
                If _mItemDescription = value Then
                    Return
                End If
                _mItemDescription = value
            End Set
        End Property
        Public Property DeleteLine() As Boolean
            Get
                Return _mDeleteLine
            End Get
            Set(ByVal value As Boolean)
                If _mDeleteLine = value Then
                    Return
                End If
                _mDeleteLine = value
            End Set
        End Property
        Private _mActualShipDate As Date
        Public Property ActualShipDate() As Date
            Get
                Return _mActualShipDate
            End Get
            Set(ByVal Value As Date)
                _mActualShipDate = Value
            End Set
        End Property

        Private _mDropShip As Boolean
        Public Property DropShip As Boolean
            Get
                Return _mDropShip
            End Get
            Set(ByVal Value As Boolean)
                _mDropShip = Value
            End Set
        End Property
        Private _mNote As String
        Public Property Note As String
            Get
                Return _mNote
            End Get
            Set(ByVal Value As String)
                _mNote = Value
            End Set
        End Property
        Private _mBillingQuantity As Decimal
        Public Property BillingQuantity As Decimal
            Get
                Return _mBillingQuantity
            End Get
            Set(ByVal Value As Decimal)
                _mBillingQuantity = Value
            End Set
        End Property
        Private _mUOM As String
        Public Property UOM As String
            Get
                Return _mUOM
            End Get
            Set(ByVal Value As String)
                _mUOM = Value
            End Set
        End Property
        Private _mSiteID As String
        Public Property SiteID As String
            Get
                Return _mSiteID
            End Get
            Set(ByVal Value As String)
                _mSiteID = Value
            End Set
        End Property
        Private _mCommentKey As String
        Public Property CommentKey As String
            Get
                Return _mCommentKey
            End Get
            Set(ByVal Value As String)
                _mCommentKey = Value
            End Set
        End Property
        Private _mCommentText As String
        Public Property CommentText As String
            Get
                Return _mCommentText
            End Get
            Set(ByVal Value As String)
                _mCommentText = Value
            End Set
        End Property
        Private _mSalesTerritoryKey As String
        Public Property SalesTerritoryKey As String
            Get
                Return _mSalesTerritoryKey
            End Get
            Set(ByVal Value As String)
                _mSalesTerritoryKey = Value
            End Set
        End Property
        Private _mLotNumber As String
        Public Property LotNumber As String
            Get
                Return _mLotNumber
            End Get
            Set(ByVal Value As String)
                _mLotNumber = Value
            End Set
        End Property
        Private _mUnitCost As Decimal?
        Property UnitCost As Decimal?
            Get
                Return _mUnitCost
            End Get
            Set(ByVal Value As Decimal?)
                _mUnitCost = Value
            End Set
        End Property
        Private _mNonInventory As Boolean
        Property NonInventory As Boolean
            Get
                Return _mNonInventory
            End Get
            Set(ByVal Value As Boolean)
                _mNonInventory = Value
            End Set
        End Property

    End Class
End Namespace

