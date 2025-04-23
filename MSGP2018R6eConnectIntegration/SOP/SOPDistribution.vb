Imports DevExpress.Xpo

Namespace SOP
    Public Class SOPDistribution
        Public Enum DistributionTypes
            Sales = 1
            Receiving = 2
            Cash = 3
            Taken = 4
            Available = 5
            Trade = 6
            Freight = 7

        End Enum
        Private _mDistributionType As Object
        Public Property DistributionType As Object
            Get
                Return _mDistributionType
            End Get
            Set(ByVal Value As Object)
                _mDistributionType = Value
            End Set
        End Property

        Private _mDistributionReference As String
        Public Property DistributionReference As String
            Get
                Return _mDistributionReference
            End Get
            Set(ByVal Value As String)
                _mDistributionReference = Value
            End Set
        End Property
        Private _mAccountNumber As String
        Public Property AccountNumber As String
            Get
                Return _mAccountNumber
            End Get
            Set(ByVal Value As String)
                _mAccountNumber = Value
            End Set
        End Property
        Private _mDebitAmount As Double
        Public Property DebitAmount As Double
            Get
                Return _mDebitAmount
            End Get
            Set(ByVal Value As Double)
                _mDebitAmount = Value
            End Set
        End Property
        Private _mCreditAmount As Double
        Public Property CreditAmount As Double
            Get
                Return _mCreditAmount
            End Get
            Set(ByVal Value As Double)
                _mCreditAmount = Value
            End Set
        End Property
        
        
    End Class
End Namespace
