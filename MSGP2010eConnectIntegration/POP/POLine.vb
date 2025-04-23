Namespace POP
    Public Class POLine

#Region "Properties"

        Private _mPoNumber As String
        Public Property PoNumber() As String
            Get
                Return _mPoNumber
            End Get
            Set(ByVal Value As String)
                _mPoNumber = Value
            End Set
        End Property

        Private _mPoType As POHeader.POTypes
        Public Property PoType() As POHeader.POTypes
            Get
                Return _mPoType
            End Get
            Set(ByVal Value As POHeader.POTypes)
                _mPoType = Value
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

        Private _mLocationId As String
        Public Property LocationId() As String
            Get
                Return _mLocationId
            End Get
            Set(ByVal Value As String)
                _mLocationId = Value
            End Set
        End Property

        Private _mVendorItemNumber As String
        Public Property VendorItemNumber() As String
            Get
                Return _mVendorItemNumber
            End Get
            Set(ByVal Value As String)
                _mVendorItemNumber = Value
            End Set
        End Property

        Private _mVendorItemDescription As String
        Public Property VendorItemDescription() As String
            Get
                Return _mVendorItemDescription
            End Get
            Set(ByVal Value As String)
                _mVendorItemDescription = Value
            End Set
        End Property

        Private _mItemNumber As String
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal Value As String)
                _mItemNumber = Value
            End Set
        End Property

        Private _mQuantity As Decimal
        Public Property Quantity As Decimal
            Get
                Return _mQuantity
            End Get
            Set(value As Decimal)
                _mQuantity = value
            End Set
        End Property

        Private _mNonInventory As Short
        Public Property NonInventory As Short
            Get
                Return _mNonInventory
            End Get
            Set(value As Short)
                _mNonInventory = value
            End Set
        End Property

        Private _mInventoryAccountIndex As Integer
        Public Property InventoryAccountIndex() As Integer
            Get
                Return _mInventoryAccountIndex
            End Get
            Set(ByVal Value As Integer)
                _mInventoryAccountIndex = Value
            End Set
        End Property

        Private _mInventoryAccount As String
        Public Property InventoryAccount() As String
            Get
                Return _mInventoryAccount
            End Get
            Set(ByVal Value As String)
                _mInventoryAccount = Value
            End Set
        End Property

        Private _mItemDescription As String
        Public Property ItemDescription() As String
            Get
                Return _mItemDescription
            End Get
            Set(ByVal Value As String)
                _mItemDescription = Value
            End Set
        End Property

        Private _mUnitCost As Decimal
        Public Property UnitCost As Decimal
            Get
                Return _mUnitCost
            End Get
            Set(value As Decimal)
                _mUnitCost = value
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

        Private _mShippingMethod As String
        Public Property ShippingMethod() As String
            Get
                Return _mShippingMethod
            End Get
            Set(ByVal Value As String)
                _mShippingMethod = Value
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

        Private _mLineNumber As Integer
        Property LineNumber As Integer
            Get
                Return _mLineNumber
            End Get
            Set(ByVal Value As Integer)
                _mLineNumber = Value
            End Set
        End Property

        Private _mPoLineStatus As POHeader.POStatuses
        Public Property PoLineStatus As POHeader.POStatuses
            Get
                Return _mPoLineStatus
            End Get
            Set(value As POHeader.POStatuses)
                _mPoLineStatus = value
            End Set
        End Property

#End Region
    End Class
End Namespace

