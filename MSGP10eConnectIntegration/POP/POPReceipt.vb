Namespace POP
    Public Class POPReceipt
        'Public Enum ReceiptTypes
        '    Shipment = 1
        '    ShipmentInvoice = 3
        'End Enum

#Region "Properties"
        Private _mReceiptNumber As String
        ''' <summary>
        ''' Typically assigned by GP.  If not provided will be assigned by GP
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReceiptNumber() As String
            Get
                Return _mReceiptNumber
            End Get
            Set(ByVal Value As String)
                _mReceiptNumber = Value
            End Set
        End Property
        
        Private _mVendorDocumentReference As String
        Public Property VendorDocumentReference() As String
            Get
                Return _mVendorDocumentReference
            End Get
            Set(ByVal Value As String)
                _mVendorDocumentReference = Value
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
        Private _mActualShipDate As String
        Public Property ActualShipDate() As String
            Get
                Return _mActualShipDate
            End Get
            Set(ByVal Value As String)
                _mActualShipDate = Value
            End Set
        End Property
        Private _mBatchId As String
        Public Property BatchId() As String
            Get
                Return _mBatchId
            End Get
            Set(ByVal Value As String)
                _mBatchId = Value
            End Set
        End Property

        Private _mVendorId As String
        Public Property VendorId() As String
            Get
                Return _mVendorId
            End Get
            Set(ByVal Value As String)
                _mVendorId = Value
            End Set
        End Property
        Private _mReference As String
        Public Property Reference() As String
            Get
                Return _mReference
            End Get
            Set(ByVal Value As String)
                _mReference = Value
            End Set
        End Property
        Private _mNoteText As String
        Public Property NoteText() As String
            Get
                Return _mNoteText
            End Get
            Set(ByVal Value As String)
                _mNoteText = Value
            End Set
        End Property

        Private _mPOLines As New POPReceiptLines
        Public Property POLines() As POPReceiptLines
            Get
                Return _mPOLines
            End Get
            Set(ByVal Value As POPReceiptLines)
                _mPOLines = Value
            End Set
        End Property




#End Region
    End Class
End Namespace

