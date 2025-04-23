
Namespace POP
    Public Class POPDetail
        Private _mItemNumber As String = String.Empty
        Private _mSiteID As String = String.Empty
        Private _mQuantity As Double = 0
        Private _mUOM As String = String.Empty
        Private _mUnitCost As Decimal = 0
        Private _mExtendedCost As Decimal = 0
        Private _mRequestedDate As Date?
        Private _mCommentKey As String = String.Empty
        Private _mCommentText As String = String.Empty


        Public Sub New()
        End Sub
        Public Sub New(ByVal ItemNumber As String, ByVal SiteID As String, ByVal Quantity As Integer, ByVal UOM As String, ByVal UnitCost As Decimal, ByVal ExtendedCost As Decimal, ByVal RequestedDate As Date, ByVal CommentKey As String, ByVal CommentText As String)
            _mItemNumber = ItemNumber
            _mSiteID = SiteID
            _mQuantity = Quantity
            _mUOM = UOM
            _mUnitCost = UnitCost
            _mExtendedCost = ExtendedCost
            _mRequestedDate = RequestedDate
            _mCommentKey = CommentKey
            _mCommentText = CommentText
        End Sub
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal value As String)
                _mItemNumber = value
            End Set
        End Property
        Public Property SiteID() As String
            Get
                Return _mSiteID
            End Get
            Set(ByVal value As String)
                _mSiteID = value
            End Set
        End Property
        Public Property Quantity() As Double
            Get
                Return _mQuantity
            End Get
            Set(ByVal value As Double)
                _mQuantity = value
            End Set
        End Property
        Public Property UOM() As String
            Get
                Return _mUOM
            End Get
            Set(ByVal value As String)
                _mUOM = value
            End Set
        End Property
        Public Property UnitCost() As Decimal
            Get
                Return _mUnitCost
            End Get
            Set(ByVal value As Decimal)
                _mUnitCost = value
            End Set
        End Property
        Public Property ExtendedCost() As Decimal?
            Get
                Return _mExtendedCost
            End Get
            Set(ByVal value As Decimal?)
                _mExtendedCost = value
            End Set
        End Property
        Public Property RequestedDate() As Date?
            Get
                Return _mRequestedDate
            End Get
            Set(ByVal value As Date?)
                _mRequestedDate = value
            End Set
        End Property
        Public Property CommentKey() As String
            Get
                Return _mCommentKey
            End Get
            Set(ByVal value As String)
                _mCommentKey = value
            End Set
        End Property
        Public Property CommentText() As String
            Get
                Return _mCommentText
            End Get
            Set(ByVal value As String)
                _mCommentText = value
            End Set
        End Property

        Private _mInventoryGLAccount As String
        Public Property InventoryGLAccount As String
            Get
                Return _mInventoryGLAccount
            End Get
            Set(ByVal Value As String)
                _mInventoryGLAccount = Value
            End Set
        End Property

    End Class
End Namespace



