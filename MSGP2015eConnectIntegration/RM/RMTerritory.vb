Namespace RM
    Public Class RMTerritory
        Private _mTerritoryKey As String
        Public Property TerritoryKey As String
            Get
                Return _mTerritoryKey
            End Get
            Set(ByVal Value As String)
                _mTerritoryKey = Value
            End Set
        End Property
        Private _mTerritoryName As String
        Public Property TerritoryName As String
            Get
                Return _mTerritoryName
            End Get
            Set(ByVal Value As String)
                _mTerritoryName = Value
            End Set
        End Property
        Private _mSalesPersonId As String
        Public Property SalesPersonId As String
            Get
                Return _mSalesPersonId
            End Get
            Set(ByVal Value As String)
                _mSalesPersonId = Value
            End Set
        End Property
        Private _mSalesManagerFirstName As String
        Public Property SalesManagerFirstName As String
            Get
                Return _mSalesManagerFirstName
            End Get
            Set(ByVal Value As String)
                _mSalesManagerFirstName = Value
            End Set
        End Property
        Private _mSalesManagerLastName As String
        Public Property SalesManagerLastName As String
            Get
                Return _mSalesManagerLastName
            End Get
            Set(ByVal Value As String)
                _mSalesManagerLastName = Value
            End Set
        End Property
        
        
    End Class
End Namespace

