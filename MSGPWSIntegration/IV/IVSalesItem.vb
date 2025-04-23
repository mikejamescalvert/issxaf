Imports DevExpress.Xpo

Namespace IV
    Public Class IVSalesItem
        Private _mSalesItemKey As String = String.Empty
        Private _mSalesItemDescription As String = String.Empty
        Private _mUnitOfMeasure As String = String.Empty
        Private _mItemClassKey As String = String.Empty
        Public Sub New()
        End Sub

        Private _mItemSites As New System.Collections.Specialized.StringCollection
        ''' <summary>
        ''' if provided will create Item Site relationship for the Site Ids Specified
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemSites As System.Collections.Specialized.StringCollection
            Get
                Return _mItemSites
            End Get
            Set(ByVal Value As System.Collections.Specialized.StringCollection)
                _mItemSites = Value
            End Set
        End Property

        Private _mDefaultSite As String
        Public Property DefaultSite() As String
            Get
                Return _mDefaultSite
            End Get
            Set(ByVal Value As String)
                _mDefaultSite = Value
            End Set
        End Property
        Private _mPrices As New IVItemPrices
        Public Property Prices As IVItemPrices
            Get
                Return _mPrices
            End Get
            Set(ByVal Value As IVItemPrices)
                _mPrices = Value
            End Set
        End Property

        Private _mDefaultPricingLevelKey As String
        Public Property DefaultPricingLevelKey() As String
            Get
                Return _mDefaultPricingLevelKey
            End Get
            Set(ByVal Value As String)
                _mDefaultPricingLevelKey = Value
            End Set
        End Property

        Private _mCurrencyKey As String
        Public Property CurrencyKey() As String
            Get
                Return _mCurrencyKey
            End Get
            Set(ByVal Value As String)
                _mCurrencyKey = Value
            End Set
        End Property

        Private _mCurrencyISOCode As String
        Public Property CurrencyISOCode() As String
            Get
                Return _mCurrencyISOCode
            End Get
            Set(ByVal Value As String)
                _mCurrencyISOCode = Value
            End Set
        End Property


        Private _mPrice As Decimal?
        Public Property Price() As Decimal?
            Get
                Return _mPrice
            End Get
            Set(ByVal Value As Decimal?)
                _mPrice = Value
            End Set
        End Property


        Public Property SalesItemKey() As String
            Get
                Return _mSalesItemKey
            End Get
            Set(ByVal value As String)
                _mSalesItemKey = value
            End Set
        End Property

        Public Property SalesItemDescription() As String
            Get
                Return _mSalesItemDescription
            End Get
            Set(ByVal value As String)
                _mSalesItemDescription = value
            End Set
        End Property
        Private _mSalesItemShortDescription As String
        Public Property SalesItemShortDescription As String
            Get
                Return _mSalesItemShortDescription
            End Get
            Set(ByVal Value As String)
                _mSalesItemShortDescription = Value
            End Set
        End Property


        Private _mSellingUnitOfMeasure As String
        Public Property SellingUnitOfMeasure As String
            Get
                Return _mSellingUnitOfMeasure
            End Get
            Set(ByVal Value As String)
                _mSellingUnitOfMeasure = Value
            End Set
        End Property
        

        Private _mPurchaseUnitOfMeasure As String

        Public Property PurchaseUnitOfMeasure As String
            Get
                Return _mPurchaseUnitOfMeasure
            End Get
            Set(ByVal Value As String)
                _mPurchaseUnitOfMeasure = Value
            End Set
        End Property

        Private _mUnitOfMeasureSchedule As String
        Public Property UnitOfMeasureSchedule As String
            Get
                Return _mUnitOfMeasureSchedule
            End Get
            Set(ByVal Value As String)
                _mUnitOfMeasureSchedule = Value
            End Set
        End Property
        


        Public Property ItemClassKey() As String
            Get
                Return _mItemClassKey
            End Get
            Set(ByVal value As String)
                _mItemClassKey = value
            End Set
        End Property
    End Class
End Namespace

