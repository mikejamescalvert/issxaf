Namespace IV

    Public Class IVPriceListLine

        Private _mToQuantity As Decimal
        Public Property ToQuantity() As Decimal
            Get
                Return _mToQuantity
            End Get
            Set(ByVal value As Decimal)
                _mToQuantity = value
            End Set
        End Property

        Private _mUnitPrice As Decimal
        Public Property UnitPrice() As Decimal
            Get
                Return _mUnitPrice
            End Get
            Set(value As Decimal)
                _mUnitPrice = value
            End Set
        End Property
    End Class
End Namespace

