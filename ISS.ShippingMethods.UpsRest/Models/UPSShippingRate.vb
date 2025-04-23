Imports DevExpress.Xpo

Namespace Models


    Public Class UPSShippingRate

        Private _mRateName As String
        Public Property RateName() As String
            Get
                Return _mRateName
            End Get
            Set(ByVal Value As String)
                _mRateName = Value
            End Set
        End Property

        Private _mRate As Decimal
        Public Property Rate() As Decimal
            Get
                Return _mRate
            End Get
            Set(ByVal Value As Decimal)
                _mRate = Value
            End Set
        End Property
        Private _mDisplayOrder As Integer
        Property DisplayOrder As Integer
            Get
                Return _mDisplayOrder
            End Get
            Set(ByVal Value As Integer)
                _mDisplayOrder = Value
            End Set
        End Property
        Public Property EstimatedDeliveryDate As Date

    End Class
End Namespace