Imports DevExpress.Xpo
Namespace Objects.IV.NonPersistent
    <NonPersistent()>
    Public Class IVExtendedPriceLevel
        Private _mIsBase As Boolean
        Public Property IsBase As Boolean
            Get
                Return _mIsBase
            End Get
            Set(ByVal Value As Boolean)
                _mIsBase = Value
            End Set
        End Property
        
        Private _mPriceLevelName As String
        Public Property PriceLevelName As String
            Get
                Return _mPriceLevelName
            End Get
            Set(ByVal Value As String)
                _mPriceLevelName = Value
            End Set
        End Property

        Private _mPriceLevelEntries As New List(Of IVExtendedPricingItemPrice)
        Public ReadOnly Property PriceLevelEntries As List(Of IVExtendedPricingItemPrice)
            Get
                Return _mPriceLevelEntries
            End Get
        End Property

    End Class
End Namespace

