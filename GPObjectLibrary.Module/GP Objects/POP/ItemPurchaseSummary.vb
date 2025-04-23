Namespace Objects.POP
    Public Class ItemPurchaseSummary
        Private _mItemKey As String
        Public Property ItemKey As String
            Get
                Return _mItemKey
            End Get
            Set(ByVal Value As String)
                _mItemKey = Value
            End Set
        End Property
        Private _mItemDescription As String
        Public Property ItemDescription As String
            Get
                Return _mItemDescription
            End Get
            Set(ByVal Value As String)
                _mItemDescription = Value
            End Set
        End Property
        Private _mPurchaseQty As Decimal
        Public Property PurchaseQty As Decimal
            Get
                Return _mPurchaseQty
            End Get
            Set(ByVal Value As Decimal)
                _mPurchaseQty = Value
            End Set
        End Property

    End Class
End Namespace