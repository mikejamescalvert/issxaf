Namespace Models
    Public Class SalesOrderResults

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

        Private _mSalesOrders As List(Of JSON.SalesOrder)
        Public Property SalesOrders As List(Of JSON.SalesOrder)
            Get
                Return _mSalesOrders
            End Get
            Set(value As List(Of JSON.SalesOrder))
                _mSalesOrders = value
            End Set
        End Property

    End Class

End Namespace
