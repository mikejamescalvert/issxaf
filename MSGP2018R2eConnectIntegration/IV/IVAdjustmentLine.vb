Namespace IV
    Public Class IVAdjustmentLine

        Private _mItemCode As String
        Private _mSiteId As String
        Private _mTrxQty As Decimal
        Private _mSerialLotLines As New IVSerialLotLines
        'Private _mLineSequence As Integer

        ''' <summary>
        ''' Line sequence to be assigned to the line item.  Auto assigned after processing
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Public Property LineSequence() As Integer
        '    Get
        '        Return _mLineSequence
        '    End Get
        '    Set(ByVal value As Integer)
        '        _mLineSequence = value
        '    End Set
        'End Property

        ''' <summary>
        ''' Inventory item code for the transaction
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemCode() As String
            Get
                Return _mItemCode
            End Get
            Set(ByVal value As String)
                _mItemCode = Value
            End Set
        End Property
        ''' <summary>
        ''' Location to be affected by the transaction
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SiteId() As String
            Get
                Return _mSiteId
            End Get
            Set(ByVal value As String)
                _mSiteId = Value
            End Set
        End Property
        ''' <summary>
        ''' Quantity of the adjustment
        ''' positive=increase, negative=decrease
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TrxQty() As Decimal
            Get
                Return _mTrxQty
            End Get
            Set(ByVal value As Decimal)
                _mTrxQty = Value
            End Set
        End Property
        ''' <summary>
        ''' Non-zero unit cost will be used to udpate the adjustment
        ''' </summary>
        ''' <remarks></remarks>
        Private _mUnitCost As Decimal
        Public Property UnitCost As Decimal
            Get
                Return _mUnitCost
            End Get
            Set(ByVal Value As Decimal)
                _mUnitCost = Value
            End Set
        End Property

        ''' <summary>
        ''' A collection of serial lot number values.  The Serial lot number type must be specified
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SerialLotLines() As IVSerialLotLines
            Get
                Return _mSerialLotLines
            End Get
            Set(ByVal value As IVSerialLotLines)
                _mSerialLotLines = value
            End Set
        End Property
    End Class
End Namespace

