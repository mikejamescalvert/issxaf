Namespace IV


	Public Class IVVendorItem
		Private _mItemNumber As String
		Public Property ItemNumber As String
			Get
				Return _mItemNumber
			End Get
			Set(ByVal Value As String)
				_mItemNumber = Value
			End Set
		End Property
		Private _mVendorItemNumber As String
		Public Property VendorItemNumber As String
			Get
				Return _mVendorItemNumber
			End Get
			Set(ByVal Value As String)
				_mVendorItemNumber = Value
			End Set
		End Property
		Private _mVendorId As String
		Public Property VendorId As String
			Get
				Return _mVendorId
			End Get
			Set(ByVal Value As String)
				_mVendorId = Value
			End Set
		End Property

		Private _mUpdateIfExists As Boolean
		Public Property UpdateIfExists As Boolean
			Get
				Return _mUpdateIfExists
			End Get
			Set(ByVal Value As Boolean)
				_mUpdateIfExists = Value
			End Set
		End Property
		
		
	End Class
End Namespace

