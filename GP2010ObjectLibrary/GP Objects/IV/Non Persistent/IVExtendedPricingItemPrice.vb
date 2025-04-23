Imports DevExpress.Xpo
Namespace Objects.IV.NonPersistent
    Public Class IVExtendedPricingItemPrice
        Private _mItemNumber As String
        Public Property ItemNumber As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal Value As String)
                _mItemNumber = Value
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

        Private _mPrice As Decimal
        Public Property Price As Decimal
            Get
                Return _mPrice
            End Get
            Set(ByVal Value As Decimal)
                _mPrice = Value
            End Set
        End Property
        Private _mUpdatedFromGroupAssignment As Boolean
        Public Property UpdatedFromGroupAssignment As Boolean
            Get
                Return _mUpdatedFromGroupAssignment
            End Get
            Set(ByVal Value As Boolean)
                _mUpdatedFromGroupAssignment = Value
            End Set
        End Property



    End Class
End Namespace

