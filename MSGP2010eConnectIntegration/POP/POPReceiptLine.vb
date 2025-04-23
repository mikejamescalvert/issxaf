Imports DevExpress.Xpo
Namespace POP
    Public Class POPReceiptLine
#Region "Properties"

        Private _mPONumber As String
        Public Property PONumber() As String
            Get
                Return _mPONumber
            End Get
            Set(ByVal Value As String)
                _mPONumber = Value
            End Set
        End Property
        Private _mItemNumber As String
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal Value As String)
                _mItemNumber = Value
            End Set
        End Property
        Private _mQuantityShipped As Decimal
        Public Property QuantityShipped() As Decimal
            Get
                Return _mQuantityShipped
            End Get
            Set(ByVal Value As Decimal)
                _mQuantityShipped = Value
            End Set
        End Property
        ''' <summary>
        ''' only required if PO receipt type is Shipment Invoice
        ''' </summary>
        ''' <remarks></remarks>
        Private _mQuantityInvoiced As Decimal
        Public Property QuantityInvoiced() As Decimal
            Get
                Return _mQuantityInvoiced
            End Get
            Set(ByVal Value As Decimal)
                _mQuantityInvoiced = Value
            End Set
        End Property
        Private _mReceiptDate As Date
        Public Property ReceiptDate() As Date
            Get
                Return _mReceiptDate
            End Get
            Set(ByVal Value As Date)
                _mReceiptDate = Value
            End Set
        End Property
        Private _mUnitOfMeasure As String
        Public Property UnitOfMeasure() As String
            Get
                Return _mUnitOfMeasure
            End Get
            Set(ByVal Value As String)
                _mUnitOfMeasure = Value
            End Set
        End Property
        Private _mUnitCost As Decimal?
        Public Property UnitCost As Decimal?
            Get
                Return _mUnitCost
            End Get
            Set(ByVal Value As Decimal?)
                _mUnitCost = Value
            End Set
        End Property
        Private _mExtendedCost As Decimal?
        Public Property ExtendedCost As Decimal?
            Get
                If _mExtendedCost.HasValue = True Then
                    Return _mExtendedCost
                ElseIf UnitCost.HasValue Then
                    Return UnitCost * QuantityShipped
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal Value As Decimal?)
                _mExtendedCost = Value
            End Set
        End Property

        


        Private _mAutoCost As Boolean
        ''' <summary>
        ''' If set to true the uits cost will be computed form teh extended cost and units
        ''' You do not need to provide unit cost if this is set to true
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AutoCost As Boolean

            Get
                Return _mAutoCost
            End Get
            Set(ByVal Value As Boolean)
                _mAutoCost = Value
            End Set
        End Property
        
        
        Private _mSiteId As String
        Public Property SiteId() As String
            Get
                Return _mSiteId
            End Get
            Set(ByVal Value As String)
                _mSiteId = Value
            End Set
        End Property
        Private _mSerialLotLines As New POPSerialLotLines
        Public Property SerialLotLines() As POPSerialLotLines
            Get
                Return _mSerialLotLines
            End Get
            Set(ByVal Value As POPSerialLotLines)
                _mSerialLotLines = Value
            End Set
        End Property








#End Region
    End Class
End Namespace

