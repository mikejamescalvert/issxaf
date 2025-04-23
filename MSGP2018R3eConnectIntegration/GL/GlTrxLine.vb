Namespace GL
    Public Class GlTrxLine
        Public Enum TrxTypes
            Debit
            Credit
        End Enum
        Private _mGlAcct As String
        Private _mTrxAmount As Decimal
        Private _mTrxType As TrxTypes
        Private _mDistDescription As String
        Public Sub New()

        End Sub
        Public Sub New(ByVal GLAcct As String, ByVal TrxAmount As Decimal, ByVal TrxType As TrxTypes)
            Me._mGlAcct = GLAcct
            Me._mTrxAmount = TrxAmount
            Me._mTrxType = TrxType
        End Sub


#Region "Properties"
        Public Property DistDescription() As String
            Get
                Return _mDistDescription
            End Get
            Set(ByVal value As String)
                If _mDistDescription = value Then
                    Return
                End If
                _mDistDescription = value
            End Set
        End Property
        Public Property GlAcct() As String
            Get
                Return _mGlAcct
            End Get
            Set(ByVal value As String)
                If _mGlAcct = value Then
                    Return
                End If
                _mGlAcct = value
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
        Public Property TrxType() As TrxTypes
            Get
                Return _mTrxType
            End Get
            Set(ByVal value As TrxTypes)
                If _mTrxType = value Then
                    Return
                End If
                _mTrxType = value
            End Set
        End Property
#End Region
    End Class
End Namespace
