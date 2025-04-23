Namespace POP
    Public Class POHeader

#Region "Properties"
        Private _mPoNumber As String
        <MSGPRequiredField()>
        Public Property PoNumber() As String
            Get
                Return _mPoNumber
            End Get
            Set(ByVal Value As String)
                _mPoNumber = Value
            End Set
        End Property

        Private _mPoType As POTypes
        Public Property PoType() As POTypes
            Get
                Return _mPoType
            End Get
            Set(ByVal Value As POTypes)
                _mPoType = Value
            End Set
        End Property

        Private _mVendorId As String
        <MSGPRequiredField()>
        Public Property VendorId() As String
            Get
                Return _mVendorId
            End Get
            Set(ByVal Value As String)
                _mVendorId = Value
            End Set
        End Property

        Private _mVendorName As String
        Public Property VendorName() As String
            Get
                Return _mVendorName
            End Get
            Set(ByVal Value As String)
                _mVendorName = Value
            End Set
        End Property

        Private _mDocumentDate As Date
        Public Property DocumentDate() As Date
            Get
                Return _mDocumentDate
            End Get
            Set(ByVal Value As Date)
                _mDocumentDate = Value
            End Set
        End Property

        Private _mTradeDiscountAmount As Decimal
        Public Property TradeDiscountAmount() As Decimal
            Get
                Return _mTradeDiscountAmount
            End Get
            Set(ByVal Value As Decimal)
                _mTradeDiscountAmount = Value
            End Set
        End Property

        Private _mFreightAmount As Decimal
        Public Property FreightAmount() As Decimal
            Get
                Return _mFreightAmount
            End Get
            Set(ByVal Value As Decimal)
                _mFreightAmount = Value
            End Set
        End Property

        Private _mMiscellaneousChargeAmount As Decimal
        Public Property MiscellaneousChargeAmount() As Decimal
            Get
                Return _mMiscellaneousChargeAmount
            End Get
            Set(ByVal Value As Decimal)
                _mMiscellaneousChargeAmount = Value
            End Set
        End Property

        Private _mTaxAmount As Decimal
        Public Property TaxAmount() As Decimal
            Get
                Return _mTaxAmount
            End Get
            Set(ByVal Value As Decimal)
                _mTaxAmount = Value
            End Set
        End Property

        Private _mSubtotal As Decimal
        <MSGPRequiredField()>
        Public Property Subtotal() As Decimal
            Get
                Return _mSubtotal
            End Get
            Set(ByVal Value As Decimal)
                _mSubtotal = Value
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

        Private _mShipToAddressCode As String
        Public Property ShipToAddressCode() As String
            Get
                Return _mShipToAddressCode
            End Get
            Set(ByVal Value As String)
                _mShipToAddressCode = Value
            End Set
        End Property

        Private _mCompanyName As String
        Public Property CompanyName() As String
            Get
                Return _mCompanyName
            End Get
            Set(ByVal Value As String)
                _mCompanyName = Value
            End Set
        End Property

        Private _mContact As String
        Public Property Contact() As String
            Get
                Return _mContact
            End Get
            Set(ByVal Value As String)
                _mContact = Value
            End Set
        End Property

        Private _mAddress1 As String
        Public Property Address1() As String
            Get
                Return _mAddress1
            End Get
            Set(ByVal value As String)
                _mAddress1 = value
            End Set
        End Property

        Private _mAddress2 As String
        Public Property Address2() As String
            Get
                Return _mAddress2
            End Get
            Set(ByVal value As String)
                _mAddress2 = value
            End Set
        End Property

        Private _mAddress3 As String
        Public Property Address3() As String
            Get
                Return _mAddress3
            End Get
            Set(ByVal value As String)
                _mAddress3 = value
            End Set
        End Property

        Private _mCity As String
        Public Property City() As String
            Get
                Return _mCity
            End Get
            Set(ByVal value As String)
                _mCity = value
            End Set
        End Property

        Private _mState As String
        Public Property State() As String
            Get
                Return _mState
            End Get
            Set(ByVal value As String)
                _mState = value
            End Set
        End Property

        Private _mZip As String
        Public Property Zip() As String
            Get
                Return _mZip
            End Get
            Set(ByVal value As String)
                _mZip = value
            End Set
        End Property

        Private _mVendorAddressCode As String
        Public Property VendorAddressCode() As String
            Get
                Return _mVendorAddressCode
            End Get
            Set(ByVal value As String)
                _mVendorAddressCode = value
            End Set
        End Property

        Private _mPurchaseCompanyName As String
        Public Property PurchaseCompanyName() As String
            Get
                Return _mPurchaseCompanyName
            End Get
            Set(ByVal Value As String)
                _mPurchaseCompanyName = Value
            End Set
        End Property

        Private _mPurchaseContact As String
        Public Property PurchaseContact() As String
            Get
                Return _mPurchaseContact
            End Get
            Set(ByVal Value As String)
                _mPurchaseContact = Value
            End Set
        End Property

        Private _mPurchaseAddress1 As String
        Public Property PurchaseAddress1() As String
            Get
                Return _mPurchaseAddress1
            End Get
            Set(ByVal value As String)
                _mPurchaseAddress1 = value
            End Set
        End Property

        Private _mPurchaseAddress2 As String
        Public Property PurchaseAddress2() As String
            Get
                Return _mPurchaseAddress2
            End Get
            Set(ByVal value As String)
                _mPurchaseAddress2 = value
            End Set
        End Property

        Private _mPurchaseAddress3 As String
        Public Property PurchaseAddress3() As String
            Get
                Return _mPurchaseAddress3
            End Get
            Set(ByVal value As String)
                _mPurchaseAddress3 = value
            End Set
        End Property

        Private _mPurchaseCity As String
        Public Property PurchaseCity() As String
            Get
                Return _mPurchaseCity
            End Get
            Set(ByVal value As String)
                _mPurchaseCity = value
            End Set
        End Property

        Private _mPurchaseState As String
        Public Property PurchaseState() As String
            Get
                Return _mPurchaseState
            End Get
            Set(ByVal value As String)
                _mPurchaseState = value
            End Set
        End Property

        Private _mPurchaseZip As String
        Public Property PurchaseZip() As String
            Get
                Return _mPurchaseZip
            End Get
            Set(ByVal value As String)
                _mPurchaseZip = value
            End Set
        End Property

        Private _mBillToAddressCode As String
        Public Property BillToAddressCode() As String
            Get
                Return _mBillToAddressCode
            End Get
            Set(ByVal value As String)
                _mBillToAddressCode = value
            End Set
        End Property

        Private _mShippingMethod As String
        Public Property ShippingMethod() As String
            Get
                Return _mShippingMethod
            End Get
            Set(ByVal Value As String)
                _mShippingMethod = Value
            End Set
        End Property

        Private _mPaymentTermsId As String
        Public Property PaymentTermsId() As String
            Get
                Return _mPaymentTermsId
            End Get
            Set(ByVal Value As String)
                _mPaymentTermsId = Value
            End Set
        End Property

        Private _mDueDate As Date?
        Public Property DueDate() As Date?
            Get
                Return _mDueDate
            End Get
            Set(ByVal Value As Date?)
                _mDueDate = Value
            End Set
        End Property

        Private _mTaxScheduleId As String
        Public Property TaxScheduleId() As String
            Get
                Return _mTaxScheduleId
            End Get
            Set(ByVal Value As String)
                _mTaxScheduleId = Value
            End Set
        End Property

        Private _mUserToEnter As String
        Public Property UserToEnter() As String
            Get
                Return _mUserToEnter
            End Get
            Set(ByVal Value As String)
                _mUserToEnter = Value
            End Set
        End Property

        Private _mPoStatus As POStatuses
        Public Property PoStatus As POStatuses
            Get
                Return _mPoStatus
            End Get
            Set(value As POStatuses)
                _mPoStatus = value
            End Set
        End Property

        Private _mNoteText As String
        Public Property NoteText() As String
            Get
                Return _mNoteText
            End Get
            Set(ByVal Value As String)
                _mNoteText = Value
            End Set
        End Property

        Private _mUserDefined1 As String
        Public Property UserDefined1 As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal Value As String)
                _mUserDefined1 = Value
            End Set
        End Property

        Private _mUserDefined2 As String
        Public Property UserDefined2 As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal Value As String)
                _mUserDefined2 = Value
            End Set
        End Property

        Private _mUserDefined3 As String
        Public Property UserDefined3 As String
            Get
                Return _mUserDefined3
            End Get
            Set(ByVal Value As String)
                _mUserDefined3 = Value
            End Set
        End Property

        Private _mUserDefined4 As String
        Public Property UserDefined4 As String
            Get
                Return _mUserDefined4
            End Get
            Set(ByVal Value As String)
                _mUserDefined4 = Value
            End Set
        End Property

        Private _mUserDefined5 As String
        Public Property UserDefined5 As String
            Get
                Return _mUserDefined5
            End Get
            Set(ByVal Value As String)
                _mUserDefined5 = Value
            End Set
        End Property

        Private _mPOLines As New POLines
        Public Property POLines() As POLines
            Get
                Return _mPOLines
            End Get
            Set(ByVal Value As POLines)
                _mPOLines = Value
            End Set
        End Property

        Public Enum POTypes
            Standard = 1
            DropShip = 2
            Blanket = 3
            BlanketDropShip = 4
        End Enum

        Public Enum POStatuses
            [New] = 1
            Released = 2
            ChangeOrder = 3
            Received = 4
            Closed = 5
            Cancelled = 6
        End Enum

#End Region
    End Class
End Namespace

