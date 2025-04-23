Namespace IV

    Public Class IVPriceListHeader

        Private _mItemNumber As String
        <MSGPRequiredField>
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal value As String)
                _mItemNumber = value
            End Set
        End Property

        Private _mCurrencyId As String
        Public Property CurrencyId() As String
            Get
                Return _mCurrencyId
            End Get
            Set(ByVal value As String)
                _mCurrencyId = value
            End Set
        End Property

        Private _mPriceLevel As String
        Public Property PriceLevel() As String
            Get
                Return _mPriceLevel
            End Get
            Set(ByVal value As String)
                _mPriceLevel = value
            End Set
        End Property

        Private _mUnitOfMeasure As String
        Public Property UnitOfMeasure() As String
            Get
                Return _mUnitOfMeasure
            End Get
            Set(ByVal value As String)
                _mUnitOfMeasure = value
            End Set
        End Property

        Private _mPriceListLines As IVPriceListLines
        <DevExpress.Persistent.Validation.RuleCriteria("PriceListLines[PriceListLine.ToQuantity = 999999999999].Count > 0", TargetContextIDs:="GPValidation")>
        Public Property PriceListLines() As IVPriceListLines
            Get
                Return _mPriceListLines
            End Get
            Set(ByVal value As IVPriceListLines)
                _mPriceListLines = value
            End Set
        End Property

    End Class
End Namespace

