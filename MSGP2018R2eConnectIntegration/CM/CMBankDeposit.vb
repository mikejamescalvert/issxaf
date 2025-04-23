Namespace CM
    Public Class CMBankDeposit
        Public CheckbookId As String
        Public DepositDate As DateTime
        Public DepositNumber As String
        Public Post As Boolean
        Public Enum DepositTypes
            [DepositWithReceipt] = 1
            [DepositWihtoutReceipt] = 2
            [ClearUnusedReceipts] = 3
        End Enum
        Public DepositType As DepositTypes
        Public DepositItems As New List(Of CMBankDepositItem)
    End Class
End Namespace
