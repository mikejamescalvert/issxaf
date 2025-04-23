Namespace IV
    Public Class IVSerialLotLine

        Private _mItemCode As String
        Private _mTrxNumber As String
        Private _mTrxQty As Decimal
        Private _mSerialLotNumber As String
        ''' <summary>
        ''' Serial or lot number involved in the transaction
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SerialLotNumber() As String
            Get
                Return _mSerialLotNumber
            End Get
            Set(ByVal value As String)
                _mSerialLotNumber = value

            End Set
        End Property
        Public Property TrxQty() As Decimal
            Get
                Return _mTrxQty
            End Get
            Set(ByVal value As Decimal)
                _mTrxQty = value

            End Set
        End Property


    End Class
End Namespace
