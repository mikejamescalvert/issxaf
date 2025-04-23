Namespace IV
    ''' <summary>
    ''' Represent a fully encapsulated inventory adjustment transaction
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IVAdjustment
        Private _mTrxBatchNo As String
        Private _mTrxNumber As String
        Private _mTrxDate As Date
        Private _mTrxLines As New IVAdjustmentLines

        ''' <summary>
        ''' Batch number to assign the transactions
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TrxBatchNo() As String
            Get
                Return _mTrxBatchNo
            End Get
            Set(ByVal value As String)
                _mTrxBatchNo = value
            End Set
        End Property
        ''' <summary>
        ''' Transaction number
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TrxNumber() As String
            Get
                Return _mTrxNumber
            End Get
            Set(ByVal value As String)
                _mTrxNumber = value
            End Set
        End Property
        ''' <summary>
        ''' Transaction Date
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TrxDate() As Date
            Get
                Return _mTrxDate
            End Get
            Set(ByVal value As Date)
                _mTrxDate = value
            End Set
        End Property
        ''' <summary>
        ''' A collection of adjustment line details to be transacted
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TrxLines() As IVAdjustmentLines
            Get
                Return _mTrxLines
            End Get
            Set(ByVal value As IVAdjustmentLines)
                _mTrxLines = value
            End Set
        End Property


    End Class
End Namespace

