Namespace Objects.IV.Helpers
    Public Class ItemStockCountSerialLotNumber
        Public Enum SerialLotTypes
            LotNumber
            SerialNumber
        End Enum

        Private _mSeriaLotType As SerialLotTypes
        Public Property SeriaLotType() As SerialLotTypes

            Get
                Return _mSeriaLotType
            End Get
            Set(ByVal Value As SerialLotTypes)
                _mSeriaLotType = Value
            End Set
        End Property
        Private _mSerialLotNumber As String
        Public Property SerialLotNumber() As String
            Get
                Return _mSerialLotNumber
            End Get
            Set(ByVal Value As String)
                _mSerialLotNumber = Value
            End Set
        End Property
        Private _mLotQty As Decimal
        ''' <summary>
        ''' Only valid for lot number tracking type
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LotQty() As Decimal
            Get
                Return _mLotQty
            End Get
            Set(ByVal Value As Decimal)
                _mLotQty = Value
            End Set
        End Property
    End Class
End Namespace