Namespace RM
    Public Class RMCustomer
        Private _mCustomerNumber As String
        <MSGPRequiredField()> _
        Public Property CustomerNumber() As String
            Get
                Return _mCustomerNumber
            End Get
            Set(ByVal Value As String)
                _mCustomerNumber = Value
            End Set
        End Property
        Private _mCustomerName As String
        Public Property CustomerName() As String
            Get
                Return _mCustomerName
            End Get
            Set(ByVal Value As String)
                _mCustomerName = Value
            End Set
        End Property
        Private _mCustomerClassCode As String
        ''' <summary>
        ''' Will use default from GP setup is not provided
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CustomerClassCode() As String
            Get
                Return _mCustomerClassCode
            End Get
            Set(ByVal Value As String)
                _mCustomerClassCode = Value
            End Set
        End Property
        Private _mAddressCode As String
        ''' <summary>
        ''' Required on new customers
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AddressCode() As String
            Get
                Return _mAddressCode
            End Get
            Set(ByVal Value As String)
                _mAddressCode = Value
            End Set
        End Property

        Private _mPrimaryBillToAddressCode As String
        Public Property PrimaryBillToAddressCode() As String
            Get
                Return _mPrimaryBillToAddressCode
            End Get
            Set(ByVal Value As String)
                _mPrimaryBillToAddressCode = Value
            End Set
        End Property
        Private _mPrimaryShipToAddressCode As String
        Public Property PrimaryShipToAddressCode() As String
            Get
                Return _mPrimaryShipToAddressCode
            End Get
            Set(ByVal Value As String)
                _mPrimaryShipToAddressCode = Value
            End Set
        End Property
        Private _mAddresses As RMCustomerAddresses
        Public Property Addresses() As RMCustomerAddresses
            Get
                Return _mAddresses
            End Get
            Set(ByVal Value As RMCustomerAddresses)
                _mAddresses = Value
            End Set
        End Property
        Private _mSalesPersonID As String
        Public Property SalesPersonID As String
            Get
                Return _mSalesPersonID
            End Get
            Set(ByVal Value As String)
                _mSalesPersonID = Value
            End Set
        End Property

        Private _mSalesTerritory As String
        Public Property SalesTerritory As String
            Get
                Return _mSalesTerritory
            End Get
            Set(ByVal Value As String)
                _mSalesTerritory = Value
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

        Private _mComment1 As String
        Public Property Comment1 As String
            Get
                Return _mComment1
            End Get
            Set(ByVal Value As String)
                _mComment1 = Value
            End Set
        End Property

        Private _mPaymentTermID As String
        Public Property PaymentTermID As String
            Get
                Return _mPaymentTermID
            End Get
            Set(ByVal Value As String)
                _mPaymentTermID = Value
            End Set
        End Property

    End Class
End Namespace