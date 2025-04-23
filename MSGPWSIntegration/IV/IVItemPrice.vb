Namespace IV
    Public Class IVItemPrice
  
        Private _mPriceLevelKey As String
        Public Property PriceLevelKey As String
            Get
                Return _mPriceLevelKey
            End Get
            Set(ByVal Value As String)
                _mPriceLevelKey = Value
            End Set
        End Property
        Private _mCurrencyKey As String
        Public Property CurrencyKey As String
            Get
                Return _mCurrencyKey
            End Get
            Set(ByVal Value As String)
                _mCurrencyKey = Value
            End Set
        End Property
        Private _mUnitOfMeasure As String
        Public Property UnitOfMeasure As String
            Get
                Return _mUnitOfMeasure
            End Get
            Set(ByVal Value As String)
                _mUnitOfMeasure = Value
            End Set
        End Property

        Private _mItemPriceDetails As New IVItemPriceDetails
        Public Property ItemPriceDetails As IVItemPriceDetails
            Get
                Return _mItemPriceDetails
            End Get
            Set(ByVal Value As IVItemPriceDetails)
                _mItemPriceDetails = Value
            End Set
        End Property




    End Class
End Namespace

