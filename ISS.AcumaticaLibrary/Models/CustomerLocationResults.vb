Namespace Models
    Public Class CustomerLocationResults

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

        Private _mCustomerLocations As List(Of JSON.CustomerLocation)
        Public Property CustomerLocations As List(Of JSON.CustomerLocation)
            Get
                Return _mCustomerLocations
            End Get
            Set(value As List(Of JSON.CustomerLocation))
                _mCustomerLocations = value
            End Set
        End Property

    End Class

End Namespace
