Namespace CM
    Public Class CMTrx
        Public Enum BankTransactionTypes
            'Check = 3
            'Withdrawl = 4
            IncreaseAdjustment = 5
            DecreaseAdjustment = 6
        End Enum
        Private _mCheckbookId As String
        Private _mTransType As BankTransactionTypes
        Private _mTrxDocNumber As String
        Private _mTrxDate As Date
        Private _mTrxDescription As String
        Private _mTrxAmount As Decimal
        Private _mTrxOffsetGLAccount As String
#Region "Properties"
        Public Property CheckbookId() As String
            Get
                Return _mCheckbookId
            End Get
            Set(ByVal value As String)
                If _mCheckbookId = value Then
                    Return
                End If
                _mCheckbookId = value
            End Set
        End Property
        Public Property TransType() As BankTransactionTypes
            Get
                Return _mTransType
            End Get
            Set(ByVal value As BankTransactionTypes)
                If _mTransType = value Then
                    Return
                End If
                _mTransType = value
            End Set
        End Property
        Public Property TrxDocNumber() As String
            Get
                Return _mTrxDocNumber
            End Get
            Set(ByVal value As String)
                If _mTrxDocNumber = value Then
                    Return
                End If
                _mTrxDocNumber = value
            End Set
        End Property
        Public Property TrxDate() As Date
            Get
                Return _mTrxDate
            End Get
            Set(ByVal value As Date)
                If _mTrxDate = value Then
                    Return
                End If
                _mTrxDate = value
            End Set
        End Property
        Public Property TrxDescription() As String
            Get
                Return _mTrxDescription
            End Get
            Set(ByVal value As String)
                If _mTrxDescription = value Then
                    Return
                End If
                _mTrxDescription = value
            End Set
        End Property
        Public Property TrxAmount() As Decimal
            Get
                Return _mTrxAmount
            End Get
            Set(ByVal value As Decimal)
                If _mTrxAmount = value Then
                    Return
                End If
                _mTrxAmount = value
            End Set
        End Property
        Public Property TrxOffsetGLAccount() As String
            Get
                Return _mTrxOffsetGLAccount
            End Get
            Set(ByVal value As String)
                If _mTrxOffsetGLAccount = value Then
                    Return
                End If
                _mTrxOffsetGLAccount = value
            End Set
        End Property
#End Region

    End Class
End Namespace
