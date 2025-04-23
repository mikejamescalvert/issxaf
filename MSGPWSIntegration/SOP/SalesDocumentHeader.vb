Imports MSGPWSIntegration.SOP
Imports System.Collections.Specialized

Namespace SOP
    Public Class SalesDocumentHeader



        Private _mSOPDocumentKey As String = String.Empty
        Private _mSalesDocumentTypeKey As String = String.Empty
        Private _mSOPBatchId As String = String.Empty
        Private _mCustomerId As String = String.Empty
        Private _mCustomerPO As String = String.Empty
        Private _mSalesPersonId As String = String.Empty
        Private _mRequestedShipDate As Date
        Private _mRequestedPaymentTerms As String = String.Empty
        Private _mCustomerNote As String = String.Empty
        Private _mShipToAddressKey As String = String.Empty
        Private _mShipToAddress As MSGPWSIntegration.GPBusinessAddress
        Private _mBillToAddressKey As String = String.Empty
        Private _mSalesPayments As SalesPayments = New SalesPayments
        Private _mSalesUserDefined As SOPSalesUserDefined = New SOPSalesUserDefined
        Private _mPaymentAmount As Decimal = 0
        Private _mFreightAmount As Decimal = 0
        Private _mTrackingNumbers As New StringCollection
        Private _mMiscAmount As Decimal
        Private _mShipmethodKey As String
        Private _mTaxScheduleKey As String

        Private _mFreightTaxKey As String
        Public Property FreightTaxKey As String
            Get
                Return _mFreightTaxKey
            End Get
            Set(ByVal Value As String)
                _mFreightTaxKey = Value
            End Set
        End Property
        Private _mCustomerName As String
        Public Property CustomerName As String
            Get
                Return _mCustomerName
            End Get
            Set(ByVal Value As String)
                _mCustomerName = Value
            End Set
        End Property
        Private _mOrderDate As Date?
        Public Property OrderDate As Date?
            Get
                Return _mOrderDate
            End Get
            Set(ByVal Value As Date?)
                _mOrderDate = Value
            End Set
        End Property

        Private _mDefaultSiteId As String
        Public Property DefaultSiteId As String
            Get
                Return _mDefaultSiteId
            End Get
            Set(ByVal Value As String)
                _mDefaultSiteId = Value
            End Set
        End Property
        Private _mSalesTaxAmount As Decimal
        Public Property SalesTaxAmount As Decimal
            Get
                Return _mSalesTaxAmount
            End Get
            Set(ByVal Value As Decimal)
                _mSalesTaxAmount = Value
            End Set
        End Property
        Protected _mTaxRegistrationNumber As String
        Public Property TaxRegistrationNumber As String
            Get
                Return _mTaxRegistrationNumber
            End Get
            Set(ByVal Value As String)
                _mTaxRegistrationNumber = Value
            End Set
        End Property
        Private _mTaxExempt1 As String
        Public Property TaxExempt1 As String
            Get
                Return _mTaxExempt1
            End Get
            Set(ByVal Value As String)
                _mTaxExempt1 = Value
            End Set
        End Property
        Private _mTaxExempt2 As String
        Public Property TaxExempt2 As String
            Get
                Return _mTaxExempt2
            End Get
            Set(ByVal Value As String)
                _mTaxExempt2 = Value
            End Set
        End Property

        Private _mTradeDiscountPercent As Decimal
        Public Property TradeDiscountPercent() As Decimal
            Get
                Return _mTradeDiscountPercent
            End Get
            Set(ByVal Value As Decimal)
                _mTradeDiscountPercent = Value
            End Set
        End Property

        Private _mTradeDiscountFlatAmount As Decimal
        Public Property TradeDiscountFlatAmount() As Decimal
            Get
                Return _mTradeDiscountFlatAmount
            End Get
            Set(ByVal Value As Decimal)
                _mTradeDiscountFlatAmount = Value
            End Set
        End Property


        Public Sub New()
            _mShipToAddress = New MSGPWSIntegration.GPBusinessAddress
        End Sub

        Public Property SOPDocumentKey() As String
            Get
                Return _mSOPDocumentKey
            End Get
            Set(ByVal value As String)
                _mSOPDocumentKey = value
            End Set
        End Property

        Public Property MiscAmount() As Decimal
            Get
                Return _mMiscAmount
            End Get
            Set(ByVal value As Decimal)
                If _mMiscAmount = value Then
                    Return
                End If
                _mMiscAmount = value
            End Set
        End Property

        Public Property SalesDocumentTypeKey() As String
            Get
                Return _mSalesDocumentTypeKey
            End Get
            Set(ByVal value As String)
                _mSalesDocumentTypeKey = value
            End Set
        End Property


        Public Property SOPBatchId() As String
            Get
                Return _mSOPBatchId
            End Get
            Set(ByVal value As String)
                _mSOPBatchId = value
            End Set
        End Property

        Public Property CustomerId() As String
            Get
                Return _mCustomerId
            End Get
            Set(ByVal value As String)
                _mCustomerId = value
            End Set
        End Property

        Public Property CustomerPO() As String
            Get
                Return _mCustomerPO
            End Get
            Set(ByVal value As String)
                _mCustomerPO = value
            End Set
        End Property

        Public Property SalesPersonId() As String
            Get
                Return _mSalesPersonId
            End Get
            Set(ByVal value As String)
                _mSalesPersonId = value
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
        Public Property ShipmethodKey() As String
            Get
                Return _mShipmethodKey
            End Get
            Set(ByVal value As String)
                If _mShipmethodKey = value Then
                    Return
                End If
                _mShipmethodKey = value
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
        Public Property RequestedPaymentTerms() As String
            Get
                Return _mRequestedPaymentTerms
            End Get
            Set(ByVal value As String)
                _mRequestedPaymentTerms = value
            End Set
        End Property
        Public Property CustomerNote() As String
            Get
                Return _mCustomerNote
            End Get
            Set(ByVal value As String)
                _mCustomerNote = value
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
        Public Property ShipToAddress() As MSGPWSIntegration.GPBusinessAddress
            Get
                Return _mShipToAddress
            End Get
            Set(ByVal value As MSGPWSIntegration.GPBusinessAddress)
                _mShipToAddress = value
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
        Public Property SalesPayments() As SalesPayments
            Get
                Return _mSalesPayments
            End Get
            Set(ByVal value As SalesPayments)
                _mSalesPayments = value
            End Set
        End Property
        Public Property SalesUserDefined() As SOPSalesUserDefined
            Get
                Return _mSalesUserDefined
            End Get
            Set(ByVal value As SOPSalesUserDefined)
                _mSalesUserDefined = value
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
        Public Property FreightAmount() As Decimal
            Get
                Return _mFreightAmount
            End Get
            Set(ByVal value As Decimal)
                _mFreightAmount = value
            End Set
        End Property
        Public Property TrackingNumbers() As StringCollection
            Get
                Return Me._mTrackingNumbers
            End Get
            Set(ByVal value As StringCollection)
                Me._mTrackingNumbers = value
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
        Private _mCommentKey As String
        Public Property CommentKey As String
            Get
                Return _mCommentKey
            End Get
            Set(ByVal Value As String)
                _mCommentKey = Value
            End Set
        End Property
        Private _mComment As String
        Public Property Comment As String
            Get
                Return _mComment
            End Get
            Set(ByVal Value As String)
                _mComment = Value
            End Set
        End Property
        Private _mSalespersonKey As String
        Public Property SalespersonKey As String
            Get
                Return _mSalespersonKey
            End Get
            Set(ByVal Value As String)
                _mSalespersonKey = Value
            End Set
        End Property
        Private _mPaymentTermsKey As String
        Public Property PaymentTermsKey As String
            Get
                Return _mPaymentTermsKey
            End Get
            Set(ByVal Value As String)
                _mPaymentTermsKey = Value
            End Set
        End Property
        Private _mPostedDate As Date
        Public Property PostedDate As Date
            Get
                Return _mPostedDate
            End Get
            Set(ByVal Value As Date)
                _mPostedDate = Value
            End Set
        End Property
        Private _mInvoiceDate As Date
        Public Property InvoiceDate As Date
            Get
                Return _mInvoiceDate
            End Get
            Set(ByVal Value As Date)
                _mInvoiceDate = Value
            End Set
        End Property

        Private _mFulfillDate As Date
        Public Property FulfillDate As Date
            Get
                Return _mFulfillDate
            End Get
            Set(ByVal Value As Date)
                _mFulfillDate = Value
            End Set
        End Property
        Private _mExpirationDate As Date
        Public Property ExpirationDate As Date
            Get
                Return _mExpirationDate
            End Get
            Set(ByVal Value As Date)
                _mExpirationDate = Value
            End Set
        End Property
        Private _mFreightAccount As String
        Public Property FreightAccount As String
            Get
                Return _mFreightAccount
            End Get
            Set(ByVal Value As String)
                _mFreightAccount = Value
            End Set
        End Property
        Private _mWarrantyDays As String
        Public Property WarrantyDays As String
            Get
                Return _mWarrantyDays
            End Get
            Set(ByVal Value As String)
                _mWarrantyDays = Value
            End Set
        End Property
        Private _mFOB As String
        Public Property FOB As String
            Get
                Return _mFOB
            End Get
            Set(ByVal Value As String)
                _mFOB = Value
            End Set
        End Property
        Private _mTestProtocol As String
        Public Property TestProtocol As String
            Get
                Return _mTestProtocol
            End Get
            Set(ByVal Value As String)
                _mTestProtocol = Value
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
        Private _mPriceLevel As String
        Public Property PriceLevel As String
            Get
                Return _mPriceLevel
            End Get
            Set(ByVal Value As String)
                _mPriceLevel = Value
            End Set
        End Property
        Private _mClearProcessHolds As Boolean
        Public Property ClearProcessHolds As Boolean
            Get
                Return _mClearProcessHolds
            End Get
            Set(ByVal Value As Boolean)
                _mClearProcessHolds = Value
            End Set
        End Property
        
    End Class
End Namespace

