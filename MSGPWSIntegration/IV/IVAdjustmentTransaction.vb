Namespace IV
    Public Class IVAdjustmentTransaction
        Private _mItemKey As String
        Private _mWarehouseKey As String
        Private _mAdjustmentQty As Decimal
        Public Property ItemKey() As String
            Get
                Return Me._mItemKey
            End Get
            Set(ByVal value As String)
                Me._mItemKey = value
            End Set
        End Property
        Public Property WarehouseKey() As String
            Get
                Return Me._mWarehouseKey
            End Get
            Set(ByVal value As String)
                Me._mWarehouseKey = value
            End Set
        End Property
        ''' <summary>
        ''' Positive or negative number of the adjsutment quantity
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AdjustmentQty() As Decimal
            Get
                Return Me._mAdjustmentQty
            End Get
            Set(ByVal value As Decimal)
                Me._mAdjustmentQty = value
            End Set
        End Property

    End Class
End Namespace

