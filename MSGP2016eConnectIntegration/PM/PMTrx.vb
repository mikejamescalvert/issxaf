Imports System
Imports DevExpress.Xpo

Namespace PM

    Public Class PMTrx
        Private _mVendorID As String
        Private _mPMDescription As String
        Private _mPMPaymentTerms As String
        Private _mPMDocDate As DateTime
        Private _mPMDocumentNumber As String
        Private _mDocumentType As PMTransactionDocumentTypes
        Private _mDueDate As DateTime
        Private _mTermsDiscDate As DateTime
        Private _mHold As Boolean
        Private _mBatchID As String
        Private _mTaxScheduleID As String
        Private _mTaxAmount As Decimal
        Private _mFreight As Decimal
        Private _mTradeDiscount As Decimal
        Private _mPMTrxDistributionLines As New PMTrxDistributionLines
        Private _mPurchaseAmount As Decimal
        Private _mVoucherNumber As String
        Private _mPONumber As String

		Private _mPostingDate As Date?
		''' <summary>
		''' GL Posting Date
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks>If provided will be used as the posting date otherwise Doc Date will be used</remarks>
		Public Property PostingDate As Date?
			Get
				Return _mPostingDate
			End Get
			Set(ByVal Value As Date?)
				_mPostingDate = Value
			End Set
		End Property
		

        Public Property VendorID() As String
            Get
                Return _mVendorID
            End Get
            Set(ByVal value As String)
                If _mVendorID = Value Then
                    Return
                End If
                _mVendorID = Value
            End Set
        End Property
        Public Property PMDescription() As String
            Get
                Return _mPMDescription
            End Get
            Set(ByVal value As String)
                If _mPMDescription = Value Then
                    Return
                End If
                _mPMDescription = Value
            End Set
        End Property
        Public Property PMPaymentTerms() As String
            Get
                Return _mPMPaymentTerms
            End Get
            Set(ByVal value As String)
                If _mPMPaymentTerms = Value Then
                    Return
                End If
                _mPMPaymentTerms = Value
            End Set
        End Property
        Public Property PMDocDate() As DateTime
            Get
                Return _mPMDocDate
            End Get
            Set(ByVal value As DateTime)
                If _mPMDocDate = Value Then
                    Return
                End If
                _mPMDocDate = Value
            End Set
        End Property
        Public Property PMDocumentNumber() As String
            Get
                Return _mPMDocumentNumber
            End Get
            Set(ByVal value As String)
                If _mPMDocumentNumber = Value Then
                    Return
                End If
                _mPMDocumentNumber = Value
            End Set
        End Property
        Public Property DocumentType() As PMTransactionDocumentTypes
            Get
                Return _mDocumentType
            End Get
            Set(ByVal value As PMTransactionDocumentTypes)
                If _mDocumentType = Value Then
                    Return
                End If
                _mDocumentType = Value
            End Set
        End Property
        Public Property DueDate() As DateTime
            Get
                Return _mDueDate
            End Get
            Set(ByVal value As DateTime)
                If _mDueDate = Value Then
                    Return
                End If
                _mDueDate = Value
            End Set
        End Property
        Public Property TermsDiscDate() As DateTime
            Get
                Return _mTermsDiscDate
            End Get
            Set(ByVal value As DateTime)
                If _mTermsDiscDate = Value Then
                    Return
                End If
                _mTermsDiscDate = Value
            End Set
        End Property
        Public Property Hold() As Boolean
            Get
                Return _mHold
            End Get
            Set(ByVal value As Boolean)
                If _mHold = Value Then
                    Return
                End If
                _mHold = Value
            End Set
        End Property
        Public Property BatchID() As String
            Get
                Return _mBatchID
            End Get
            Set(ByVal value As String)
                If _mBatchID = Value Then
                    Return
                End If
                _mBatchID = Value
            End Set
        End Property
        Public Property TaxScheduleID() As String
            Get
                Return _mTaxScheduleID
            End Get
            Set(ByVal value As String)
                If _mTaxScheduleID = Value Then
                    Return
                End If
                _mTaxScheduleID = Value
            End Set
        End Property
        Public Property TaxAmount() As Decimal
            Get
                Return _mTaxAmount
            End Get
            Set(ByVal value As Decimal)
                If _mTaxAmount = Value Then
                    Return
                End If
                _mTaxAmount = Value
            End Set
        End Property
        Public Property Freight() As Decimal
            Get
                Return _mFreight
            End Get
            Set(ByVal value As Decimal)
                If _mFreight = Value Then
                    Return
                End If
                _mFreight = Value
            End Set
        End Property
        Public Property TradeDiscount() As Decimal
            Get
                Return _mTradeDiscount
            End Get
            Set(ByVal value As Decimal)
                If _mTradeDiscount = Value Then
                    Return
                End If
                _mTradeDiscount = Value
            End Set
        End Property
        Private _mPMCheckbookId As String
        Public Property PMCheckbookId As String
            Get
                Return _mPMCheckbookId
            End Get
            Set(ByVal Value As String)
                _mPMCheckbookId = Value
            End Set
        End Property
        Private _mCreditCardAmount As Decimal
        Public Property CreditCardAmount As Decimal
            Get
                Return _mCreditCardAmount
            End Get
            Set(ByVal Value As Decimal)
                _mCreditCardAmount = Value
            End Set
        End Property
        Private _mCreditCardPaymentNumber As String
        Public Property CreditCardPaymentNumber As String
            Get
                Return _mCreditCardPaymentNumber
            End Get
            Set(ByVal Value As String)
                _mCreditCardPaymentNumber = Value
            End Set
        End Property
        Private _mCreditCardName As String
        Public Property CreditCardName As String
            Get
                Return _mCreditCardName
            End Get
            Set(ByVal Value As String)
                _mCreditCardName = Value
            End Set
        End Property
        Private _mCreditCardReceiptNumber As String
        Public Property CreditCardReceiptNumber As String
            Get
                Return _mCreditCardReceiptNumber
            End Get
            Set(ByVal Value As String)
                _mCreditCardReceiptNumber = Value
            End Set
        End Property
        Private _mCreditCardAmountDate As Date
        Public Property CreditCardAmountDate As Date
            Get
                Return _mCreditCardAmountDate
            End Get
            Set(ByVal Value As Date)
                _mCreditCardAmountDate = Value
            End Set
        End Property
        
        Private _mPMBatchCheckBookId As String
        Public Property PMBatchCheckBookId As String
            Get
                Return _mPMBatchCheckBookId
            End Get
            Set(ByVal Value As String)
                _mPMBatchCheckBookId = Value
            End Set
        End Property
        
        Private _mUserDefined1 As String
        Public Property UserDefined1 As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal Value As String)
                _mUserDefined1 = Value
            End Set
        End Property
        Private _mUserDefined2 As String
        Public Property UserDefined2 As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal Value As String)
                _mUserDefined2 = Value
            End Set
        End Property
        Private _mUserDefined3 As String
        Public Property UserDefined3 As String
            Get
                Return _mUserDefined3
            End Get
            Set(ByVal Value As String)
                _mUserDefined3 = Value
            End Set
        End Property
        Private _mUserDefined4 As String
        Public Property UserDefined4 As String
            Get
                Return _mUserDefined4
            End Get
            Set(ByVal Value As String)
                _mUserDefined4 = Value
            End Set
        End Property
        Private _mUserDefined5 As String
        Public Property UserDefined5 As String
            Get
                Return _mUserDefined5
            End Get
            Set(ByVal Value As String)
                _mUserDefined5 = Value
            End Set
        End Property
        
        
        Public Property PMTrxDistributionLines() As PMTrxDistributionLines
            Get
                Return _mPMTrxDistributionLines
            End Get
            Set(ByVal value As PMTrxDistributionLines)
                If _mPMTrxDistributionLines Is value Then
                    Return
                End If
                _mPMTrxDistributionLines = Value
            End Set
        End Property
        Public Property PurchaseAmount() As Decimal
            Get
                Return _mPurchaseAmount
            End Get
            Set(ByVal value As Decimal)
                _mPurchaseAmount = value
            End Set
        End Property
        Public ReadOnly Property VoucherNumber() As String
            Get
                Return _mVoucherNumber
            End Get
        End Property
        Public Property PONumber() As String
            Get
                Return _mPONumber
            End Get
            Set(ByVal value As String)
                If _mPONumber = Value Then
                    Return
                End If
                _mPONumber = Value
            End Set
        End Property
        Public Sub SetVoucherNumber(ByVal VoucherNumber As String)
            _mVoucherNumber = VoucherNumber
        End Sub

        Public ReadOnly Property DocumentAmount() As Decimal
            Get
                Dim decMSCChargeAmount As Decimal
                Dim decPurchaseAmount As Decimal
                Dim dectaXamount As Decimal
                Dim decFreightAmount As Decimal
                Dim decTrddiscount As Decimal
                Dim PMTrxDistributionLine As PMTrxDistributionLine

                If PMTrxDistributionLines.Count > 0 Then
                    For intLoop As Integer = 0 To PMTrxDistributionLines.Count - 1
                        PMTrxDistributionLine = PMTrxDistributionLines(intLoop)
                        Select Case PMTrxDistributionLine.DistributionType
                            Case MSGP2016eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Freight
                                decFreightAmount += -PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                            Case MSGP2016eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Misc
                                decMSCChargeAmount += -PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                            Case MSGP2016eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Purch
                                decPurchaseAmount += -PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                            Case MSGP2016eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Taxes
                                dectaXamount += -PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                            Case MSGP2016eConnectIntegration.PM.PMTrxDistributionLine.DistributionTypes.Trade
                                decTrddiscount += PMTrxDistributionLine.CreditAmount + PMTrxDistributionLine.DebitAmount
                        End Select
                    Next

                    Return decMSCChargeAmount + decPurchaseAmount + dectaXamount + decFreightAmount - decTrddiscount
                Else
                    Return PurchaseAmount
                End If

            End Get
		End Property
		Private _mTen99Amount As Decimal
		Public Property Ten99Amount As Decimal
			Get
				Return _mTen99Amount
			End Get
			Set(ByVal Value As Decimal)
				If _mTen99Amount = Value Then
					Return
				End If
				_mTen99Amount = Value
			End Set
		End Property

        Public ReadOnly Property ChargeAmount() As Decimal
            Get
                Return DocumentAmount
            End Get
        End Property

        Public Enum PMTransactionDocumentTypes
            Invoice = 1
            [Return] = 4
            CreditMemo = 5
        End Enum

    End Class

End Namespace

