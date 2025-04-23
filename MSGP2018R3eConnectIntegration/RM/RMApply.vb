Namespace RM
    Public Class RMApply
        Private _mApplytoDocumentNumber As String
        Public Enum ApplyToDocumentTypes
            SalesOrInvoice = 1
            DebitMemo = 3
            FinanceCharge = 4
            ServiceOrRepair = 5
            Warranty = 6
        End Enum
        Public Enum ApplyFromDocumentTypes
            CreditMemo = 7
            [Return] = 8
            CashReceipt = 9

        End Enum

        Public Property ApplyToDocumentNumber() As String
            Get
                Return _mApplytoDocumentNumber
            End Get
            Set(ByVal Value As String)
                _mApplytoDocumentNumber = Value
            End Set
        End Property
        Private _mApplyFromDocumentNumber As String
        Public Property ApplyFromDocumentNumber() As String
            Get
                Return _mApplyFromDocumentNumber
            End Get
            Set(ByVal Value As String)
                _mApplyFromDocumentNumber = Value
            End Set
        End Property
        Private _mApplyAmount As Decimal
        Public Property ApplyAmount() As Decimal
            Get
                Return _mApplyAmount
            End Get
            Set(ByVal Value As Decimal)
                _mApplyAmount = Value
            End Set
        End Property
        Private _mApplyToDocumentType As ApplyToDocumentTypes
        Public Property ApplyToDocumentType() As ApplyToDocumentTypes
            Get
                Return _mApplyToDocumentType
            End Get
            Set(ByVal Value As ApplyToDocumentTypes)
                _mApplyToDocumentType = Value
            End Set
        End Property
        Private _mApplyFromDocumentType As ApplyFromDocumentTypes
        Public Property ApplyFromDocumentType() As ApplyFromDocumentTypes
            Get
                Return _mApplyFromDocumentType
            End Get
            Set(ByVal Value As ApplyFromDocumentTypes)
                _mApplyFromDocumentType = Value
            End Set
        End Property



        Private _mApplyDate As Date
        Public Property ApplyDate() As Date
            Get
                Return _mApplyDate
            End Get
            Set(ByVal Value As Date)
                _mApplyDate = Value
            End Set
        End Property
        Private _mPostingDate As Nullable(Of Date)
        ''' <summary>
        ''' If empty will use the ApplyDate instead
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PostingDate() As Nullable(Of Date)
            Get
                Return _mPostingDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _mPostingDate = Value
            End Set
        End Property


    End Class
End Namespace
