Namespace IV

	Public Class IVItemMaster

		Private _mItemNumber As String
		Public Property ItemNumber As String
			Get
				Return _mItemNumber
			End Get
			Set(ByVal Value As String)
				_mItemNumber = Value
			End Set
		End Property

		Private _mItemDescription As String
		Public Property ItemDescription As String
			Get
				Return _mItemDescription
			End Get
			Set(ByVal Value As String)
				_mItemDescription = Value
			End Set
		End Property

		Private _mItemClassId As String
		Public Property ItemClassId As String
			Get
				Return _mItemClassId
			End Get
			Set(ByVal Value As String)
				_mItemClassId = Value
			End Set
		End Property

		Private _mLocationId As String
		Public Property LocationId As String
			Get
				Return _mLocationId
			End Get
			Set(ByVal Value As String)
				_mLocationId = Value
			End Set
		End Property

		Private _mUOMSchedule As String
		Public Property UOMSchedule As String
			Get
				Return _mUOMSchedule
			End Get
			Set(ByVal Value As String)
				_mUOMSchedule = Value
			End Set
		End Property

		Private _mPriceList As IVPriceList
		Public Property PriceList As IVPriceList
			Get
				Return _mPriceList
			End Get
			Set(value As IVPriceList)
				If value.ItemNumber <> ItemNumber Then
					value.ItemNumber = ItemNumber
				End If
				_mPriceList = value
			End Set
		End Property

	End Class
End Namespace


