Imports DevExpress.Xpo

Namespace RM
    Public Class RMTransactionDistribution
        Public Enum DistTypeForTransaction
            Cash = 1
            Taken = 1
            Recv = 3
            Write = 4
            Avail = 5
            Gst = 6
            Wh = 7
            Other = 8
            Sales = 9
            Trade = 10
            Freight = 11
            Misc = 12
            Taxes = 13
            Cogs = 14
            Inv = 15
            Fnchg = 16
            Returns = 17
            DrMemo = 18
            CrMemo = 19
            Service = 20
            Warrexp = 21
            Warrsls = 22
            Commexp = 23
            Cpmmpay = 24
        End Enum
        Private _mDistType As DistTypeForTransaction
        Public Property DistType As DistTypeForTransaction
            Get
                Return _mDistType
            End Get
            Set(ByVal Value As DistTypeForTransaction)
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
        Private _mReference As String
        Property Reference As String
            Get
                Return _mReference
            End Get
            Set(ByVal Value As String)
                _mReference = Value
            End Set
        End Property
        

    End Class
End Namespace

