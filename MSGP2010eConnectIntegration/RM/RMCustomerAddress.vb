Imports MSGP2010eConnectIntegration.CMP

Namespace RM


    Public Class RMCustomerAddress

        Private _mInternetAddress As cmpinternetaddress
        Public Property InternetAddress As cmpinternetaddress
            Get
                Return _mInternetAddress
            End Get
            Set(ByVal Value As cmpinternetaddress)
                _mInternetAddress = Value
            End Set
        End Property


        Private _mCustomerNumber As String
        ''' <summary>
        ''' If this address record is attached to an RMCustomer Object
        ''' the customer number of the RM Customer object will be used
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MSGPRequiredField()> _
        Public Property CustomerNumber() As String
            Get
                Return _mCustomerNumber
            End Get
            Set(ByVal Value As String)
                _mCustomerNumber = Value
            End Set
        End Property

        Private _mAddressCode As String
        <MSGPRequiredField()> _
        Public Property AddressCode() As String
            Get
                Return _mAddressCode
            End Get
            Set(ByVal Value As String)
                _mAddressCode = Value
            End Set
        End Property
        Private _mAddressLine1 As String
        Public Property AddressLine1() As String
            Get
                Return _mAddressLine1
            End Get
            Set(ByVal Value As String)
                _mAddressLine1 = Value
            End Set
        End Property
        Private _mAddressLine2 As String
        Public Property AddressLine2() As String
            Get
                Return _mAddressLine2
            End Get
            Set(ByVal Value As String)
                _mAddressLine2 = Value
            End Set
        End Property
        Private _mAddressLine3 As String
        Public Property AddressLine3() As String
            Get
                Return _mAddressLine3
            End Get
            Set(ByVal Value As String)
                _mAddressLine3 = Value
            End Set
        End Property
        Private _mCity As String
        Public Property City() As String
            Get
                Return _mCity
            End Get
            Set(ByVal Value As String)
                _mCity = Value
            End Set
        End Property
        Private _mState As String
        Public Property State() As String
            Get
                Return _mState
            End Get
            Set(ByVal Value As String)
                _mState = Value
            End Set
        End Property
        Private _mZipCode As String
        Public Property ZipCode() As String
            Get
                Return _mZipCode
            End Get
            Set(ByVal Value As String)
                _mZipCode = Value
            End Set
        End Property
        Private _mPhoneNumber1 As String
        Public Property PhoneNumber1() As String
            Get
                Return _mPhoneNumber1
            End Get
            Set(ByVal Value As String)
                _mPhoneNumber1 = Value
            End Set
        End Property
        Private _mPhoneNumber2 As String
        Public Property PhoneNumber2() As String
            Get
                Return _mPhoneNumber2
            End Get
            Set(ByVal Value As String)
                _mPhoneNumber2 = Value
            End Set
        End Property
        Private _mPhoneNumber3 As String
        Public Property PhoneNumber3() As String
            Get
                Return _mPhoneNumber3
            End Get
            Set(ByVal Value As String)
                _mPhoneNumber3 = Value
            End Set
        End Property
        Private _mFaxNumber As String
        Public Property FaxNumber() As String
            Get
                Return _mFaxNumber
            End Get
            Set(ByVal Value As String)
                _mFaxNumber = Value
            End Set
        End Property
        Private _mSalesPersonId As String
        Public Property SalesPersonId() As String
            Get
                Return _mSalesPersonId
            End Get
            Set(ByVal Value As String)
                _mSalesPersonId = Value
            End Set
        End Property
        Private _mTerritoryId As String
        Public Property TerritoryId() As String
            Get
                Return _mTerritoryId
            End Get
            Set(ByVal Value As String)
                _mTerritoryId = Value
            End Set
        End Property
        Private _mContactPerson As String
        Public Property ContactPerson() As String
            Get
                Return _mContactPerson
            End Get
            Set(ByVal Value As String)
                _mContactPerson = Value
            End Set
        End Property
        Private _mCountry As String
        Public Property Country() As String
            Get
                Return _mCountry
            End Get
            Set(ByVal Value As String)
                _mCountry = Value
            End Set
        End Property
        Private _mInventorySiteId As String
        Public Property InventorySiteId() As String
            Get
                Return _mInventorySiteId
            End Get
            Set(ByVal Value As String)
                _mInventorySiteId = Value
            End Set
        End Property
        Private _mTaxScheduleId As String
        Public Property TaxScheduleId() As String
            Get
                Return _mTaxScheduleId
            End Get
            Set(ByVal Value As String)
                _mTaxScheduleId = Value
            End Set
        End Property
        Private _mShippingMethod As String
        Public Property ShippingMethod As String
            Get
                Return _mShippingMethod
            End Get
            Set(ByVal Value As String)
                _mShippingMethod = Value
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

    End Class

End Namespace
