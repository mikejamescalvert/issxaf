Namespace RM

    Public Class RMCashReceiptApply
        Public Enum ApplyToDocumentTypes
            SalesOrInvoice = 1
            DebitMemo = 3
            FinanceCharge = 4
            ServiceOrRepair = 5
            Warranty = 6
        End Enum
        Private _mApplyToDocumentNumber As String
        Public Property ApplyToDocumentNumber() As String
            Get
                Return _mApplyToDocumentNumber
            End Get
            Set(ByVal Value As String)
                _mApplyToDocumentNumber = Value
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

        Private _mApplyAmount As Decimal
        Public Property ApplyAmount() As Decimal
            Get
                Return _mApplyAmount
            End Get
            Set(ByVal Value As Decimal)
                _mApplyAmount = Value
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
        Private _mApplyPostingDate As Nullable(Of Date)
        ''' <summary>
        ''' If not provided will use the apply Date as the posting date
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ApplyPostingDate() As Nullable(Of Date)
            Get
                Return _mApplyPostingDate
            End Get
            Set(ByVal Value As Nullable(Of Date))
                _mApplyPostingDate = Value
            End Set
        End Property


    End Class


End Namespace