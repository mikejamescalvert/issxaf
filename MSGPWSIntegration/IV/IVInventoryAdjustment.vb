Public Class IVInventoryAdjustment

    Private _mGPSystemConfiguration As GPSystemConfiguration
    Public Property GPSystemConfiguration As GPSystemConfiguration
        Get
            Return _mGPSystemConfiguration
        End Get
        Set(ByVal Value As GPSystemConfiguration)
            _mGPSystemConfiguration = Value
        End Set
    End Property

    Private _mDocumentNumber As String
    Public Property DocumentNumber As String
        Get
            Return _mDocumentNumber
        End Get
        Set(ByVal Value As String)
            _mDocumentNumber = Value
        End Set
    End Property
    Private _mBatchID As String
    Public Property BatchID As String
        Get
            Return _mBatchID
        End Get
        Set(ByVal Value As String)
            _mBatchID = Value
        End Set
    End Property
    Private _mTransactionDate As Date
    Public Property TransactionDate As Date
        Get
            Return _mTransactionDate
        End Get
        Set(ByVal Value As Date)
            _mTransactionDate = Value
        End Set
    End Property
    

End Class
