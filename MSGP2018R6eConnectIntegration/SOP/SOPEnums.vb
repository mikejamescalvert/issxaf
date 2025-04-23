Namespace SOP
    Public Enum SerialLotTypes
        None = -1
        SerialNumber = 0
        LotNumber = 1
    End Enum
    Public Enum SOPDocTypes
        Quote = 1
        Order = 2
        Invoice = 3
        OrderReturn = 4
        BackOrder = 5
        FullfillmentOrder = 6
    End Enum
    Public Enum SOPPaymentTypes
        CashDeposit = 1
        CheckDeposit = 2
        CreditCardDeposit = 3
        CashPayment = 4
        CheckPayment = 5
        CreditCardPayment = 6
    End Enum

End Namespace