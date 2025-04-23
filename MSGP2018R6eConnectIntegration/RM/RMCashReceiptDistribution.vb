Namespace RM
    Public Class RMCashReceiptDistribution
        Public Enum DistTypeForCashReceipts
            Cash = 1
            Recv = 3
        End Enum
        Private _mDistType As DistTypeForCashReceipts
        Public Property DistType As DistTypeForCashReceipts
            Get
                Return _mDistType
            End Get
            Set(ByVal Value As DistTypeForCashReceipts)
                _mDistType = Value
            End Set
        End Property
        Private _mAccountNumber As String
        Public Property AccountNumber As String
            Get
                Return _mAccountNumber
            End Get
            Set(ByVal Value As String)
                _mAccountNumber = Value
            End Set
        End Property
        Private _mDebitAmount As Decimal
        Public Property DebitAmount As Decimal
            Get
                Return _mDebitAmount
            End Get
            Set(ByVal Value As Decimal)
                _mDebitAmount = Value
            End Set
        End Property
        Private _mCreditAmount As Decimal
        Public Property CreditAmount As Decimal
            Get
                Return _mCreditAmount
            End Get
            Set(ByVal Value As Decimal)
                _mCreditAmount = Value
            End Set
        End Property

    End Class
End Namespace

