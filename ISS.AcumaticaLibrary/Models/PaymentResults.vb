Namespace Models
    Public Class PaymentResults

        Public Sub New(ByVal Configuration As AcumaticaConfiguration)
            PageSize = Configuration.RestPageSize

        End Sub

        Private _mPageNumber As Integer
        Property PageNumber As Integer
            Get
                Return _mPageNumber
            End Get
            Set(ByVal Value As Integer)
                _mPageNumber = Value
            End Set
        End Property
        Private _mPageSize As Integer
        Property PageSize As Integer
            Get
                Return _mPageSize
            End Get
            Set(ByVal Value As Integer)
                _mPageSize = Value
            End Set
        End Property

        Private _mPayments As List(Of JSON.Payment)
        Public Property Payments As List(Of JSON.Payment)
            Get
                Return _mPayments
            End Get
            Set(value As List(Of JSON.Payment))
                _mPayments = value
            End Set
        End Property

    End Class

End Namespace
