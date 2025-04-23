Namespace RM
    Public Class RMCustomerAddress
        Private _mCustomerAddressKey As String = String.Empty
        Private _mCustomerKey As String = String.Empty
        Private _mLine1 As String = String.Empty
        Private _mLine2 As String = String.Empty
        Private _mLine3 As String = String.Empty
        Private _mCity As String = String.Empty
        Private _mState As String = String.Empty
        Private _mPostalCode As String = String.Empty
        Private _mCountryRegion As String = String.Empty
        Private _mCountryRegionCodeKey As String = String.Empty
        Private _mCreatedDate As Date = "1/1/1900"
        Private _mDeleteOnUpdate As Boolean = False
        Private _mContactPerson As String = String.Empty
        Private _mFax As String = String.Empty
        Private _mFaxExtension As String = String.Empty
        Private _mPhone1 As String = String.Empty
        Private _mPhone1Extension As String = String.Empty
        Private _mPhone2 As String = String.Empty
        Private _mPhone2Extension As String = String.Empty
        Private _mPhone3 As String = String.Empty
        Private _mPhone3Extension As String = String.Empty
        Private _mModifiedDate As String = "1/1/1900"
        Private _mName As String = String.Empty
        Private _mSalespersonKey As String = String.Empty
        Private _mSalesTerritoryKey As String = String.Empty
        Private _mShippingMethodKey As String = String.Empty
        Private _mTaxScheduleKey As String = String.Empty
        Private _mUPSZone As String = String.Empty
        Private _mUserDefined1 As String = String.Empty
        Private _mUserDefined2 As String = String.Empty
        Private _mWarehouseKey As String = String.Empty
        Private _mInternetAddresses As InternetAddresses = New RM.InternetAddresses

        Public Property CustomerAddressKey() As String
            Get
                Return _mCustomerAddressKey
            End Get
            Set(ByVal value As String)
                _mCustomerAddressKey = value
            End Set
        End Property

        Public Property CustomerKey() As String
            Get
                Return _mCustomerKey
            End Get
            Set(ByVal value As String)
                _mCustomerKey = value
            End Set
        End Property
        Public Property Line1() As String
            Get
                Return _mLine1
            End Get
            Set(ByVal value As String)
                _mLine1 = value
            End Set
        End Property
        Public Property Line2() As String
            Get
                Return _mLine2
            End Get
            Set(ByVal value As String)
                _mLine2 = value
            End Set
        End Property
        Public Property Line3() As String
            Get
                Return _mLine3
            End Get
            Set(ByVal value As String)
                _mLine3 = value
            End Set
        End Property
        Public Property City() As String
            Get
                Return _mCity
            End Get
            Set(ByVal value As String)
                _mCity = value
            End Set
        End Property
        Public Property State() As String
            Get
                Return _mState
            End Get
            Set(ByVal value As String)
                _mState = value
            End Set
        End Property
        Public Property PostalCode() As String
            Get
                Return _mPostalCode
            End Get
            Set(ByVal value As String)
                _mPostalCode = value
            End Set
        End Property
        Public Property CountryRegion() As String
            Get
                Return _mCountryRegion
            End Get
            Set(ByVal value As String)
                _mCountryRegion = value
            End Set
        End Property
        Public Property CountryRegionCodeKey() As String
            Get
                Return _mCountryRegionCodeKey
            End Get
            Set(ByVal value As String)
                _mCountryRegionCodeKey = value
            End Set
        End Property
        Public Property CreatedDate() As Date
            Get
                Return _mCreatedDate
            End Get
            Set(ByVal value As Date)
                _mCreatedDate = value
            End Set
        End Property
        Public Property DeleteOnUpdate() As Boolean
            Get
                Return _mDeleteOnUpdate
            End Get
            Set(ByVal value As Boolean)
                _mDeleteOnUpdate = value
            End Set
        End Property
        Public Property ContactPerson() As String
            Get
                Return _mContactPerson
            End Get
            Set(ByVal value As String)
                _mContactPerson = value
            End Set
        End Property
        Public Property Fax() As String
            Get
                Return _mFax
            End Get
            Set(ByVal value As String)
                _mFax = value
            End Set
        End Property
        Public Property FaxExtension() As String
            Get
                Return _mFaxExtension
            End Get
            Set(ByVal value As String)
                _mFaxExtension = value
            End Set
        End Property
        Public Property Phone1() As String
            Get
                Return _mPhone1
            End Get
            Set(ByVal value As String)
                _mPhone1 = value
            End Set
        End Property
        Public Property Phone1Extension() As String
            Get
                Return _mPhone1Extension
            End Get
            Set(ByVal value As String)
                _mPhone1Extension = value
            End Set
        End Property
        Public Property Phone2() As String
            Get
                Return _mPhone2
            End Get
            Set(ByVal value As String)
                _mPhone2 = value
            End Set
        End Property
        Public Property Phone2Extension() As String
            Get
                Return _mPhone2Extension
            End Get
            Set(ByVal value As String)
                _mPhone2Extension = value
            End Set
        End Property
        Public Property Phone3() As String
            Get
                Return _mPhone3
            End Get
            Set(ByVal value As String)
                _mPhone3 = value
            End Set
        End Property
        Public Property Phone3Extension() As String
            Get
                Return _mPhone3Extension
            End Get
            Set(ByVal value As String)
                _mPhone3Extension = value
            End Set
        End Property
        Public Property ModifiedDate() As Date
            Get
                Return _mModifiedDate
            End Get
            Set(ByVal value As Date)
                _mModifiedDate = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return _mName
            End Get
            Set(ByVal value As String)
                _mName = value
            End Set
        End Property
        Public Property SalespersonKey() As String
            Get
                Return _mSalespersonKey
            End Get
            Set(ByVal value As String)
                _mSalespersonKey = value
            End Set
        End Property
        Public Property SalesTerritoryKey() As String
            Get
                Return _mSalesTerritoryKey
            End Get
            Set(ByVal value As String)
                _mSalesTerritoryKey = value
            End Set
        End Property
        Public Property ShippingMethodKey() As String
            Get
                Return _mShippingMethodKey
            End Get
            Set(ByVal value As String)
                _mShippingMethodKey = value
            End Set
        End Property
        Public Property TaxScheduleKey() As String
            Get
                Return _mTaxScheduleKey
            End Get
            Set(ByVal value As String)
                _mTaxScheduleKey = value
            End Set
        End Property
        Public Property UPSZone() As String
            Get
                Return _mUPSZone
            End Get
            Set(ByVal value As String)
                _mUPSZone = value
            End Set
        End Property
        Public Property UserDefined1() As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal value As String)
                _mUserDefined1 = value
            End Set
        End Property
        Public Property UserDefined2() As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal value As String)
                _mUserDefined2 = value
            End Set
        End Property
        Public Property WarehouseKey() As String
            Get
                Return _mWarehouseKey
            End Get
            Set(ByVal value As String)
                _mWarehouseKey = value
            End Set
        End Property
        Public Property InternetAddresses() As RM.InternetAddresses
            Get
                Return _mInternetAddresses
            End Get
            Set(ByVal value As InternetAddresses)
                value = _mInternetAddresses
            End Set
        End Property
    End Class
End Namespace
