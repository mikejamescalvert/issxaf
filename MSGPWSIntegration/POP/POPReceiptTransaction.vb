Namespace POP
    Public Class POPReceiptTransaction
        Public Sub New()
            Me.ReceiptHeader = New POPReceipt
            Me.ReceiptLines = New POPReceiptLines
        End Sub
        Private _mReceiptHeader As POPReceipt
        Public Property ReceiptHeader As POPReceipt
            Get
                Return _mReceiptHeader
            End Get
            Set(ByVal Value As POPReceipt)
                _mReceiptHeader = Value
            End Set
        End Property
        Private _mReceiptLines As POPReceiptLines
        Public Property ReceiptLines As POPReceiptLines
            Get
                Return _mReceiptLines
            End Get
            Set(ByVal Value As POPReceiptLines)
                _mReceiptLines = Value
            End Set
        End Property




    End Class
End Namespace

