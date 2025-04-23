Imports System.IO
Imports system.Xml
Imports system.Xml.Serialization
Imports system.Text
Imports microsoft.Dynamics.GP
Namespace GL
    Public Class GLFactory
        Private _mMSGPConnectionString As String
        Private _mExceptionMessages As New System.Collections.Specialized.StringCollection
#Region "Properties"
        Public Property MSGPConnectionString() As String
            Get
                Return _mMSGPConnectionString
            End Get
            Set(ByVal value As String)
                If _mMSGPConnectionString = value Then
                    Return
                End If
                _mMSGPConnectionString = value
            End Set
        End Property
        Public ReadOnly Property ExceptionMessages() As System.Collections.Specialized.StringCollection
            Get
                Return _mExceptionMessages
            End Get
        End Property
#End Region
#Region "Public Methods"
        ''' <summary>
        ''' Creates a GL Transaction
        ''' </summary>
        ''' <param name="GLTransaction">
        ''' This value will be used for the trx header reference and for each GlTrxLIne reference that is blank
        ''' </param>
        ''' <returns>GL Entry transaciton number is return if successful otherwise 0 </returns>
        ''' <remarks></remarks>
        Public Function CreateGLTransaction(ByVal GLTransaction As GLTrx) As Integer
            Me._mExceptionMessages.Clear()
            Try
                Dim GL As New eConnect.Serialization.GLTransactionType
                Dim taGLTrxHeader As New eConnect.Serialization.taGLTransactionHeaderInsert
                Dim taGLTrxLines() As eConnect.Serialization.taGLTransactionLineInsert_ItemsTaGLTransactionLineInsert
                Dim GLTrx As GlTrxLine
                'validate line item details
                If GlTrxLinesInBalance(GLTransaction.TrxLines) = False Then
                    Me.ExceptionMessages.Add("Could not create GL Transaction  - Gl Transaction Detail does not balance")
                    Return False
                End If

                'set journal entry number
                If GLTransaction.TrxNumber = 0 Then
                    GLTransaction.TrxNumber = CommonLogic.GetDocNumber(MSGPConnectionString, CommonLogic.DocNumberTypes.GLJournalEntry)
                End If
                With taGLTrxHeader
                    .BACHNUMB = GLTransaction.BatchId
                    .REFRENCE = GLTransaction.TrxReference
                    .TRXDATE = GLTransaction.TrxDate
                    .TRXTYPE = GLTransaction.TransactionType.GetHashCode
                    .SERIES = 2 'financial
                    If GLTransaction.TransactionType = MSGP2018R6eConnectIntegration.GL.GLTrx.TransactionTypes.Reversing Then
                        .RVRSNGDT = GLTransaction.ReversingDate.Date
                    End If
                    .JRNENTRY = GLTransaction.TrxNumber
                    If GLTransaction.TrxNote IsNot Nothing Then
                        .NOTETEXT = GLTransaction.TrxNote
                    End If
                End With
                'dimension the line item details to hold tte incoming details
                ReDim taGLTrxLines(GLTransaction.TrxLines.Count - 1)
                For j As Integer = 0 To GLTransaction.TrxLines.Count - 1
                    GLTrx = GLTransaction.TrxLines(j)
                    taGLTrxLines(j) = New eConnect.Serialization.taGLTransactionLineInsert_ItemsTaGLTransactionLineInsert
                    With taGLTrxLines(j)
                        .BACHNUMB = GLTransaction.BatchId
                        .ACTNUMST = GLTrx.GlAcct
                        If GLTrx.TrxType = GlTrxLine.TrxTypes.Credit Then
                            .CRDTAMNT = GLTrx.TrxAmount
                        Else
                            .DEBITAMT = GLTrx.TrxAmount
                        End If
                        If GLTrx.DistDescription <> String.Empty Then
                            .DSCRIPTN = GLTrx.DistDescription
                        Else
                            .DSCRIPTN = GLTransaction.TrxReference
                        End If
                    End With
                Next

                With GL
                    .taGLTransactionHeaderInsert = taGLTrxHeader
                    .taGLTransactionLineInsert_Items = taGLTrxLines
                End With
                If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, GL) = True Then
                    Return GLTransaction.TrxNumber
                Else
                    Return 0
                End If


            Catch ex As Exception

                Me.HandleException(ex)
                Return False
            End Try

        End Function
#End Region
#Region "Private Methods"
        Private Function GlTrxLinesInBalance(ByVal TrxLines As GLTrxLines) As Boolean
            'validate that the entry line items balance
            Dim TrxTotal As Decimal
            For Each GLTrxLine As GlTrxLine In TrxLines
                If GLTrxLine.TrxType = GlTrxLine.TrxTypes.Credit Then
                    TrxTotal -= GLTrxLine.TrxAmount
                Else
                    TrxTotal += GLTrxLine.TrxAmount
                End If
            Next
            If TrxTotal <> 0 Then
                Return False
            Else
                Return True
            End If
        End Function
#End Region
        Private Sub HandleException(ByVal ex As Exception)
            Me._mExceptionMessages.Add(ex.Message)
            If ex.InnerException IsNot Nothing Then
                Me.HandleException(ex.InnerException)
            End If
        End Sub
    End Class

End Namespace
