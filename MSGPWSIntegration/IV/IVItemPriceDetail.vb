Namespace IV
    Public Class IVItemPriceDetail
        Private _mPrice As Double
        Public Property Price As Double
            Get
                Return _mPrice
            End Get
            Set(ByVal Value As Double)
                _mPrice = Value
            End Set
        End Property
        Private _mToQuantity As Double
        Public Property ToQuantity As Double
            Get
                Return _mToQuantity
            End Get
            Set(ByVal Value As Double)
                _mToQuantity = Value
            End Set
        End Property
        Private _mNumberOfDecimaDigits As Integer
        ''' <summary>
        ''' Numebr of significant digits must be between 0-5
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NumberOfDecimaDigits As Integer
            Get
                Return _mNumberOfDecimaDigits
            End Get
            Set(ByVal Value As Integer)
                _mNumberOfDecimaDigits = Value
            End Set
        End Property
        
        
    End Class
End Namespace
