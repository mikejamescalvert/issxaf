Imports DevExpress.Xpo

Namespace SOP
    Public Class SOPOrderLine
        Public Enum ItemTaxableTypes
            DefaultTax = 0
            Tax = 1
            NonTax = 2
            BasedOnCustomer = 3
        End Enum
        Private _mItemNumber As String
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal value As String)
                If _mItemNumber = value Then
                    Return
                End If
                _mItemNumber = value
            End Set
        End Property
        Private _mItemTaxType As ItemTaxableTypes
        Public Property ItemTaxType As ItemTaxableTypes
            Get
                Return _mItemTaxType
            End Get
            Set(ByVal Value As ItemTaxableTypes)
                _mItemTaxType = Value
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


        Private _mQuantity As Decimal
        Public Property Quantity() As Decimal
            Get
                Return _mQuantity
            End Get
            Set(ByVal value As Decimal)
                If _mQuantity = value Then
                    Return
                End If
                _mQuantity = value
            End Set
		End Property

		Private _mQuantityShipped As Decimal
		Public Property QuantityShipped As Decimal
			Get
				Return _mQuantityShipped
			End Get
			Set(ByVal Value As Decimal)
				_mQuantityShipped = Value
			End Set
		End Property

        Private _mBackorderQuantity As Decimal
        Public Property BackorderQuantity As Decimal
            Get
                Return _mBackorderQuantity
            End Get
            Set(ByVal Value As Decimal)
          _mBackorderQuantity = Value
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
        Private _mShipDate As Date?
        Public Property ShipDate As Date?
            Get
                Return _mShipDate
            End Get
            Set(ByVal Value As Date?)
                _mShipDate = Value
            End Set
        End Property
        Private _mRequestedShipDate As Date?
        Public Property RequestedShipDate As Date?
            Get
                Return _mRequestedShipDate
            End Get
            Set(ByVal Value As Date?)
                _mRequestedShipDate = Value
            End Set
        End Property

                

        Private _mItemDescription As String
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

        Private _mUnitOfMeasure As String
        Public Property UnitOfMeasure() As String
            Get
                Return _mUnitOfMeasure
            End Get
            Set(ByVal Value As String)
                _mUnitOfMeasure = Value
            End Set
        End Property
        Private _mLocationId As String
        Public Property LocationId As String
            Get
                Return _mLocationId
            End Get
            Set(ByVal Value As String)
                _mLocationId = Value
            End Set
        End Property
        Private _mSalesAccountNumber As String
        Public Property SalesAccountNumber As String
            Get
                Return _mSalesAccountNumber
            End Get
            Set(ByVal Value As String)
                _mSalesAccountNumber = Value
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

    End Class
End Namespace
