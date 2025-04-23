Namespace PM
    Public Class PMTrxDistributionLine

        Private _mVendorID As String
        Private _mDistributionType As DistributionTypes
        Private _mAccountNumber As String
        Private _mDebitAmount As Decimal
        Private _mCreditAmount As Decimal
        Private _mDistributionReference As String
        Private _mDocType As DistributionDocTypes

        Public Property VendorID() As String
            Get
                Return _mVendorID
            End Get
            Set(ByVal value As String)
                If _mVendorID = value Then
                    Return
                End If
                _mVendorID = value
            End Set
        End Property
        Public Property DistributionType() As DistributionTypes
            Get
                Return _mDistributionType
            End Get
            Set(ByVal value As DistributionTypes)
                If _mDistributionType = value Then
                    Return
                End If
                _mDistributionType = value
            End Set
        End Property
        Public Property AccountNumber() As String
            Get
                Return _mAccountNumber
            End Get
            Set(ByVal value As String)
                If _mAccountNumber = value Then
                    Return
                End If
                _mAccountNumber = value
            End Set
        End Property
        Public Property DebitAmount() As Decimal
            Get
                Return _mDebitAmount
            End Get
            Set(ByVal value As Decimal)
                If _mDebitAmount = value Then
                    Return
                End If
                _mDebitAmount = value
            End Set
        End Property
        Public Property CreditAmount() As Decimal
            Get
                Return _mCreditAmount
            End Get
            Set(ByVal value As Decimal)
                If _mCreditAmount = value Then
                    Return
                End If
                _mCreditAmount = value
            End Set
        End Property
        Public Property DistributionReference() As String
            Get
                Return _mDistributionReference
            End Get
            Set(ByVal value As String)
                If _mDistributionReference = value Then
                    Return
                End If
                _mDistributionReference = value
            End Set
        End Property
        Public Property DocType() As DistributionDocTypes
            Get
                Return _mDocType
            End Get
            Set(ByVal value As DistributionDocTypes)
                If _mDocType = value Then
                    Return
                End If
                _mDocType = value
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
        Private _mLineSeq As Integer?
        ''' <summary>
        ''' If provided this value will be used for the distribution line seq.  If not it will be auto assigned by GP.  Use multiple of 16384 if being set
        ''' </summary>
        ''' <returns></returns>
        Property LineSeq As Integer?
            Get
                Return _mLineSeq
            End Get
            Set(ByVal Value As Integer?)
                _mLineSeq = Value
            End Set
        End Property


        Public Enum DistributionTypes
            Cash = 1
            Pay = 2
            Avail = 3
            Taken = 4
            Fnchg = 5
            Purch = 6
            Trade = 7
            Misc = 8
            Freight = 9
            Taxes = 10
            Write = 11
            Other = 12
            Gst = 13
            Wh = 14
            Unit = 15
            Round = 16
        End Enum
        Public Enum DistributionDocTypes
            Invoice = 1
            FinanceCharge = 2
            MiscellaneousCharge = 3
            [Return] = 4
            CreditMemo = 5
            ManualChecks = 6
        End Enum
    End Class
End Namespace
