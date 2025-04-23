
Namespace SOP
    Public Class SOPOrderLine
        Private _mItemNumber As String
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal value As String)
                If _mItemNumber = Value Then
                    Return
                End If
                _mItemNumber = Value
            End Set
        End Property

        Private _mShippingMethodKey As String
        Public Property ShippingMethodKey() As String
            Get
                Return _mShippingMethodKey
            End Get
            Set(ByVal Value As String)
                _mShippingMethodKey = Value
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
		

        Private _mQuantity As Decimal
        Public Property Quantity() As Decimal
            Get
                Return _mQuantity
            End Get
            Set(ByVal value As Decimal)
                If _mQuantity = Value Then
                    Return
                End If
                _mQuantity = Value
            End Set
        End Property

        Private _mComments As String
        Public Property Comments() As String
            Get
                Return _mComments
            End Get
            Set(ByVal value As String)
                If _mComments = value Then
                    Return
                End If
                _mComments = value
            End Set
        End Property

        Private _mUnitPrice As Decimal
        Public Property UnitPrice() As Decimal
            Get
                Return _mUnitPrice
            End Get
            Set(ByVal value As Decimal)
                If _mUnitPrice = value Then
                    Return
                End If
                _mUnitPrice = value
            End Set
        End Property

        Private _mItemDescription As String
        Public Property ItemDescription() As String
            Get
                Return _mItemDescription
            End Get
            Set(ByVal value As String)
                If _mItemDescription = Value Then
                    Return
                End If
                _mItemDescription = Value
            End Set
        End Property

        Private _mUnitOfMeasure As String
        Public Property UnitOfMeasure() As String
            Get
                Return _mUnitOfMeasure
            End Get
            Set(ByVal Value As String)
                _mUnitOfMeasure = Value
            End Set
        End Property


    End Class
End Namespace
