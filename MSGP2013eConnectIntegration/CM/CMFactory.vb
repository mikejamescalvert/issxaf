Imports System.IO
Imports system.Xml
Imports system.Xml.Serialization
Imports system.Text
Imports microsoft.Dynamics.GP

Namespace CM

    Public Class CMFactory
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


        Public Function CreateBankTransaction(ByVal CMTransaction As CMTrx) As Boolean
            Me._mExceptionMessages.Clear()
            Try
                Dim BT As New eConnect.Serialization.BRBankTransactionType
                Dim BTHeader As New eConnect.Serialization.taBRBankTransactionHeader
                Dim BTDist As New eConnect.Serialization.taBRBankTransactionDist_ItemsTaBRBankTransactionDist
                Dim BTDistItems(0) As eConnect.Serialization.taBRBankTransactionDist_ItemsTaBRBankTransactionDist
                With BTHeader
                    .CHEKBKID = CMTransaction.CheckbookId
                    .Option = 1
                    .CMTrxType = CMTransaction.TransType
                    .TRXDATE = CMTransaction.TrxDate
                    .TRXAMNT = CMTransaction.TrxAmount
                    .DistRef = CMTransaction.TrxDescription
                    .CMTrxNum = CMTransaction.TrxDocNumber
                End With
                With BTDist
                    .Option = 1
                    .ACTNUMST = CMTransaction.TrxOffsetGLAccount
                    Select Case CMTransaction.TransType
                        Case CM.CMTrx.BankTransactionTypes.DecreaseAdjustment
                            .DEBITAMT = CMTransaction.TrxAmount
                            .DistRef = CMTransaction.TrxDescription
                        Case CM.CMTrx.BankTransactionTypes.IncreaseAdjustment
                            .CRDTAMNT = CMTransaction.TrxAmount
                            .DistRef = CMTransaction.TrxDescription
                    End Select
                End With
                BTDistItems(0) = BTDist

                With BT
                    .taBRBankTransactionHeader = BTHeader
                    .taBRBankTransactionDist_Items = BTDistItems
                End With
                Return CommonLogic.eConnectCreate(Me._mMSGPConnectionString, BT)

            Catch ex As Exception
                Me.HandleException(ex)
                Return False
            End Try

        End Function


        Public Function CreateBankDeposit(ByVal BankDeposit As CMBankDeposit) As Boolean
            Me._mExceptionMessages.Clear()
            Try
                Dim BD As New eConnect.Serialization.BRBankDepositsType
                Dim BDL As eConnect.Serialization.taBRBankDepositsLine_ItemsTaBRBankDepositsLine
                Dim lstLines As New List(Of eConnect.Serialization.taBRBankDepositsLine_ItemsTaBRBankDepositsLine)
                With BD
                    .taBRBankDepositsHeader = New eConnect.Serialization.taBRBankDepositsHeader
                    .taBRBankDepositsHeader.CHEKBKID = BankDeposit.CheckbookId
                    .taBRBankDepositsHeader.DEPDATE = BankDeposit.DepositDate

                    .taBRBankDepositsHeader.depositnumber = BankDeposit.DepositNumber


                    .taBRBankDepositsHeader.DEPTYPE = BankDeposit.DepositType
                    .taBRBankDepositsHeader.DSCRIPTN = BankDeposit.Description
                End With

                For Each BankLink In BankDeposit.DepositItems
                    BDL = New eConnect.Serialization.taBRBankDepositsLine_ItemsTaBRBankDepositsLine
                    With BDL
                        .CHEKBKID = BankDeposit.CheckbookId
                        .depositnumber = BankDeposit.DepositNumber
                        .RCPTNMBR = BankLink.ReceiptNumber
                        .RcpType = BankLink.ReceiptType
                        .RcpTypeSpecified = True

                    End With
                    lstLines.Add(BDL)
                Next
                BD.taBRBankDepositsLine_Items = lstLines.ToArray
                If BankDeposit.Post = True Then

                    BD.taBRPostBankDeposits = New eConnect.Serialization.taBRPostBankDeposits
                    With BD.taBRPostBankDeposits
                        .CHEKBKID = BankDeposit.CheckbookId
                        .depositnumber = BankDeposit.DepositNumber
                        .PTDUSRID = "sa"
                    End With
                End If
                Return CommonLogic.eConnectCreate(Me._mMSGPConnectionString, BD)
                    

            Catch ex As Exception
                Me.HandleException(ex)
                Return False
            End Try

        End Function


#End Region
#Region "Private Methods"
        Private Sub HandleException(ByVal ex As Exception)
            Me._mExceptionMessages.Add(ex.Message)
            If ex.InnerException IsNot Nothing Then
                Me.HandleException(ex.InnerException)
            End If
        End Sub
#End Region

    End Class
End Namespace
