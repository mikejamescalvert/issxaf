Namespace IV
    ''' <summary>
    ''' Represents a fully encapsulated inventory transfer line
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IVTransferLine
        ''' <summary>
        ''' Item quantity types to affect in a transfer
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum TrxTypes
            OnHand = 1
            Returned = 2
            InUse = 3
            InService = 4
            Damaged = 5
        End Enum
        Private _mToSiteType As TrxTypes
        Private _mFromSiteType As TrxTypes
        Private _mFromSite As String
        Private _mToSite As String
        Private _mItemCode As String
        Private _mTrxQty As Decimal
        'Private _mLineSequence As Integer
        Private _mSerialLotLines As IVSerialLotLines


#Region "Properties"
        ''' <summary>
        ''' Contains the line sequence for the item used by GP as a row pointer.  This is assigned during processing.
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
        ''' Defines the type of transfer to record at the destination site
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ToSiteType() As TrxTypes
            Get
                Return _mToSiteType
            End Get
            Set(ByVal value As TrxTypes)
                _mToSiteType = value
            End Set
        End Property
        ''' <summary>
        ''' Defines the type of transfer to record from the source site
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FromSiteType() As TrxTypes
            Get
                Return _mFromSiteType
            End Get
            Set(ByVal value As TrxTypes)
                _mFromSiteType = value
            End Set
        End Property
        ''' <summary>
        ''' The location from which the transfer will be recorded
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FromSite() As String
            Get
                Return _mFromSite
            End Get
            Set(ByVal value As String)
                _mFromSite = value
            End Set
        End Property
        ''' <summary>
        ''' The location to which the transfer will be recorded
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ToSite() As String
            Get
                Return _mToSite
            End Get
            Set(ByVal value As String)
                _mToSite = value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                Return _mItemCode
            End Get
            Set(ByVal value As String)
                _mItemCode = value
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

        Public Property SerialLotLines() As IVSerialLotLines
            Get
                Return _mSerialLotLines
            End Get
            Set(ByVal value As IVSerialLotLines)
                _mSerialLotLines = value
            End Set
        End Property

#End Region

    End Class
End Namespace
