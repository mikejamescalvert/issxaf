Namespace IV
    ''' <summary>
    ''' Represent a fully encapsulated inventroy transfer transaction
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IVTransfer
        Private _mTrxBatchNo As String
        Private _mTrxNumber As String
        Private _mTrxDate As Date
        Private _mTrxLines As New IVTransferLines
        Public Sub New()

        End Sub


#Region "Properties"
        Public Property TrxDate() As Date
            Get
                Return _mTrxDate
            End Get
            Set(ByVal value As Date)
                _mTrxDate = value
            End Set
        End Property
        Public Property TrxBatchNo() As String
            Get
                Return _mTrxBatchNo
            End Get
            Set(ByVal value As String)
                _mTrxBatchNo = value
            End Set
        End Property
        ''' <summary>
        ''' The transaction number for the document
        ''' If none is assign then next available will 
        ''' be used from Dynamics GP
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
        Public Property TrxLines() As IVTransferLines
            Get
                Return _mTrxLines
            End Get
            Set(ByVal value As IVTransferLines)
                _mTrxLines = value
            End Set
        End Property
#End Region



    End Class
End Namespace

