Namespace RM
    Public Class RMCashReceipt

        Public Enum CashReceiptTypes
            Check = 0
            Cash = 1
            CreditCard = 2
        End Enum
#Region "Properties"


        Private _mCustomerNumber As String
        Public Property CustomerNumber() As String
            Get
                Return _mCustomerNumber
            End Get
            Set(ByVal Value As String)
                _mCustomerNumber = Value
            End Set
        End Property
        Private _mDocumentNumber As String
        Public Property DocumentNumber() As String
            Get
                Return _mDocumentNumber
            End Get
            Set(ByVal Value As String)
                _mDocumentNumber = Value
            End Set
        End Property
        Private _mDocumentDate As Date
        Public Property DocumentDate() As Date
            Get
                Return _mDocumentDate
            End Get
            Set(ByVal Value As Date)
                _mDocumentDate = Value
            End Set
        End Property
        Private _mAmount As Decimal
        Public Property Amount() As Decimal
            Get
                Return _mAmount
            End Get
            Set(ByVal Value As Decimal)
                _mAmount = Value
            End Set
        End Property
        Private _mGLPostingDate As Nullable(Of Date)
        ''' <summary>
        ''' GL Posting date if different from the Document Date
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GLPostingDate() As Nullable(Of Date)
            Get
                Return _mGLPostingDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _mGLPostingDate = Value
            End Set
        End Property
        Private _mBatchNumber As String
        Public Property BatchNumber As String
            Get
                Return _mBatchNumber
            End Get
            Set(ByVal Value As String)
                _mBatchNumber = Value
            End Set
        End Property
        Private _mCreditCardNumber As String
        Public Property CreditCardNumberOrCheckNumber As String
            Get
                Return _mCreditCardNumber
            End Get
            Set(ByVal Value As String)
                _mCreditCardNumber = Value
            End Set
        End Property
        Private _mCreditCardID As String
        Public Property CreditCardID As String
            Get
                Return _mCreditCardID
            End Get
            Set(ByVal Value As String)
                _mCreditCardID = Value
            End Set
        End Property
        Private _mTransactionDescription As String
        Public Property TransactionDescription As String
            Get
                Return _mTransactionDescription
            End Get
            Set(ByVal Value As String)
                _mTransactionDescription = Value
            End Set
        End Property
        Private _mReceiptType As CashReceiptTypes
        Public Property ReceiptType() As CashReceiptTypes
            Get
                Return _mReceiptType
            End Get
            Set(ByVal Value As CashReceiptTypes)
                _mReceiptType = Value
            End Set
        End Property

        Private _mApplyTos As RMCashReceiptsApplies
        Public Property ApplyTos() As RMCashReceiptsApplies
            Get
                Return _mApplyTos
            End Get
            Set(ByVal Value As RMCashReceiptsApplies)
                _mApplyTos = Value
            End Set
        End Property

#End Region

    End Class
End Namespace

