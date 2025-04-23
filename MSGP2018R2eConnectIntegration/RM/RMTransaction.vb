Namespace RM
    ''' <summary>
    ''' RM20101 - Open Transactions
    ''' </summary>
    Public Class RMTransaction

        Public Enum RMDocTypes
            ReservedForBalanceCarriedForwardRecords = 0
            SaleOrInvoice = 1
            ReservedForScheduledPayments = 2
            DebitMemo = 3
            FinanceCharge = 4
            ServiceOrRepair = 5
            Warranty = 6
            CreditMemo = 7
            [Return] = 8
            Payment = 9
        End Enum

#Region "Properties"
        Private _mNoteIndex As Double
        Property NoteIndex As Double
            Get
                Return _mNoteIndex
            End Get
            Set(ByVal Value As Double)
                _mNoteIndex = Value
            End Set
        End Property
        
        Private _mDocumentType As RMDocTypes
        Public Property DocumentType() As RMDocTypes
            Get
                Return _mDocumentType
            End Get
            Set(ByVal Value As RMDocTypes)
                _mDocumentType = Value
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

        Private _mDocumentDescription As String
        Public Property DocumentDescription() As String
            Get
                Return _mDocumentDescription
            End Get
            Set(ByVal Value As String)
                _mDocumentDescription = Value
            End Set
        End Property

        Private _mDocumentDate
        Public Property DocumentDate() As Date
            Get
                Return _mDocumentDate
            End Get
            Set(ByVal Value As Date)
                _mDocumentDate = Value
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

        Private _mCustomerNumber As String
        Public Property CustomerNumber() As String
            Get
                Return _mCustomerNumber
            End Get
            Set(ByVal Value As String)
                _mCustomerNumber = Value
            End Set
        End Property

        Private _mDocumentAmount As Decimal
        Public Property DocumentAmount() As Decimal
            Get
                Return _mDocumentAmount
            End Get
            Set(ByVal Value As Decimal)
                _mDocumentAmount = Value
            End Set
        End Property

        Private _mSalesAmount As Decimal
        Public Property SalesAmount() As Decimal
            Get
                Return _mSalesAmount
            End Get
            Set(ByVal Value As Decimal)
                _mSalesAmount = Value
            End Set
        End Property

        Private _mCreateDistributions As Boolean
        Public Property CreateDistributions() As Boolean
            Get
                Return _mCreateDistributions
            End Get
            Set(ByVal Value As Boolean)
                _mCreateDistributions = Value
            End Set
        End Property

        Private _mUserDefined1 As String
        Public Property UserDefined1() As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal Value As String)
                _mUserDefined1 = Value
            End Set
        End Property

        Private _mUserDefined2 As String
        Public Property UserDefined2() As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal Value As String)
                _mUserDefined2 = Value
            End Set
        End Property

        Private _mUserDefined3 As String
        Public Property UserDefined3() As String
            Get
                Return _mUserDefined3
            End Get
            Set(ByVal Value As String)
                _mUserDefined3 = Value
            End Set
        End Property

        Private _mUserDefined4 As String
        Public Property UserDefined4() As String
            Get
                Return _mUserDefined4
            End Get
            Set(ByVal Value As String)
                _mUserDefined4 = Value
            End Set
        End Property

        Private _mUserDefined5 As String
        Public Property UserDefined5() As String
            Get
                Return _mUserDefined5
            End Get
            Set(ByVal Value As String)
                _mUserDefined5 = Value
            End Set
        End Property
        Private _mBatchCheckBookId As String
        Property BatchCheckBookId As String
            Get
                Return _mBatchCheckBookId
            End Get
            Set(ByVal Value As String)
                _mBatchCheckBookId = Value
            End Set
        End Property
        Private _mDistributionRef As String
        Property DistributionRef As String
            Get
                Return _mDistributionRef
            End Get
            Set(ByVal Value As String)
                _mDistributionRef = Value
            End Set
        End Property
        

        Private _mDistributions As New List(Of RMTransactionDistribution)
        Public Property Distributions() As List(Of RMTransactionDistribution)
            Get
                Return _mDistributions
            End Get
            Set(ByVal Value As List(Of RMTransactionDistribution))
                _mDistributions = Value
            End Set
        End Property

        'Private _mApplyTos As New List(Of RMCashReceiptsApplies)
        'Public Property ApplyTos() As List(Of RMCashReceiptsApplies)
        '    Get
        '        Return _mApplyTos
        '    End Get
        '    Set(ByVal Value As List(Of RMCashReceiptsApplies))
        '        _mApplyTos = Value
        '    End Set
        'End Property

#End Region

    End Class
End Namespace

