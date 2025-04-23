Namespace RM
	Public Class RMNationalAccount
		Private _mParentCustomerId As String
		Public Property ParentCustomerId As String
			Get
				Return _mParentCustomerId
			End Get
			Set(ByVal Value As String)
				_mParentCustomerId = Value
			End Set
		End Property
        Private _mAllowCashReceiptsEntryForChildren As Short
        Public Property AllowCashReceiptsEntryForChildren As Short
            Get
                Return _mAllowCashReceiptsEntryForChildren
            End Get
            Set(ByVal Value As Short)
                _mAllowCashReceiptsEntryForChildren = Value
            End Set
        End Property
        Private _mBaseCreditCheckOnConsolidatedNationalAccount As Short
        Public Property BaseCreditCheckOnConsolidatedNationalAccount As Short
            Get
                Return _mBaseCreditCheckOnConsolidatedNationalAccount
            End Get
            Set(ByVal Value As Short)
                _mBaseCreditCheckOnConsolidatedNationalAccount = Value
            End Set
        End Property
        Private _mBaseFinanceChargeOnConsolidatedNationalAccount As Short
        Public Property BaseFinanceChargeOnConsolidatedNationalAccount As Short
            Get
                Return _mBaseFinanceChargeOnConsolidatedNationalAccount
            End Get
            Set(ByVal Value As Short)
                _mBaseFinanceChargeOnConsolidatedNationalAccount = Value
            End Set
        End Property

        Private _mApplyHoldAcrossNationalAccount As Short
        Public Property ApplyHoldAcrossNationalAccount As Short
            Get
                Return _mApplyHoldAcrossNationalAccount
            End Get
            Set(ByVal Value As Short)
                _mApplyHoldAcrossNationalAccount = Value
            End Set
        End Property
        Private _mDefaultParentVendorForChildRefundChecks As Short
        Public Property DefaultParentVendorForChildRefundChecks As Short
            Get
                Return _mDefaultParentVendorForChildRefundChecks
            End Get
            Set(ByVal Value As Short)
                _mDefaultParentVendorForChildRefundChecks = Value
            End Set
        End Property
        Private _mUpdateIfExists As Short
        Public Property UpdateIfExists As Short
            Get
                Return _mUpdateIfExists
            End Get
            Set(ByVal Value As Short)
                _mUpdateIfExists = Value
            End Set
        End Property
		
				


	End Class
End Namespace

