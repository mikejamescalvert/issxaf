Namespace GL
    Public Class GLTrx
        Private _mBatchId As String
        Private _mTrxReference As String
        Private _mTrxDate As Date
        Private _mTrxNote As String
        Private _mTrxNumber As Integer
        Private _mTrxLines As New GLTrxLines


#Region "Properties"
        Public Property BatchId() As String
            Get
                Return _mBatchId
            End Get
            Set(ByVal value As String)
                If _mBatchId = value Then
                    Return
                End If
                _mBatchId = value
            End Set
        End Property
        Public Property TrxReference() As String
            Get
                Return _mTrxReference
            End Get
            Set(ByVal value As String)
                If _mTrxReference = value Then
                    Return
                End If
                _mTrxReference = value
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
        Public Property TrxNote() As String
            Get
                Return _mTrxNote
            End Get
            Set(ByVal value As String)
                If _mTrxNote = value Then
                    Return
                End If
                _mTrxNote = value
            End Set
        End Property
        ''' <summary>
        ''' The GL Journal Transaction number.
        ''' If this is not set the next number will be autmatically assigned
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TrxNumber() As Integer
            Get
                Return _mTrxNumber
            End Get
            Set(ByVal value As Integer)
                _mTrxNumber = value
            End Set
        End Property

        Public ReadOnly Property TotalDebit() As Decimal
            Get
                Dim decTotal As Decimal
                For Each Line As GlTrxLine In Me.TrxLines
                    If Line.TrxType = GlTrxLine.TrxTypes.Debit Then
                        decTotal += Line.TrxAmount
                    End If
                Next
                Return decTotal
            End Get
        End Property
        Public ReadOnly Property TotalCredit() As Decimal
            Get
                Dim decTotal As Decimal
                For Each Line As GlTrxLine In Me.TrxLines
                    If Line.TrxType = GlTrxLine.TrxTypes.Credit Then
                        decTotal += Line.TrxAmount
                    End If
                Next
                Return decTotal
            End Get
        End Property


        Public Property TrxLines() As GLTrxLines
            Get
                Return _mTrxLines
            End Get
            Set(ByVal value As GLTrxLines)
                _mTrxLines = value
            End Set
        End Property
#End Region



    End Class
End Namespace


