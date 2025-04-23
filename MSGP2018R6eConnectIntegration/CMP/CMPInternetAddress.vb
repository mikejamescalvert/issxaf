Namespace CMP

    Public Class CMPInternetAddress
        Public Enum CMPMasterType
            CustomerRecord = 0
            ItemRecord
            VendorRecord
            CompanyRecord
            SalespersonRecord
            EmployeeRecord
        End Enum
        Private _mMasterType As CMPMasterType
        <MSGPRequiredField()>
        Public Property MasterType As CMPMasterType
            Get
                Return _mMasterType
            End Get
            Set(ByVal Value As CMPMasterType)
                _mMasterType = Value
            End Set
        End Property

        Private _mMasterID As String
        <MSGPRequiredField()>
        Public Property MasterID As String
            Get
                Return _mMasterID
            End Get
            Set(ByVal Value As String)
                _mMasterID = Value
            End Set
        End Property

        Private _mInternet1 As String
        ''' <summary>
        ''' email address 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Internet1 As String
            Get
                Return _mInternet1
            End Get
            Set(ByVal Value As String)
                _mInternet1 = Value
            End Set
        End Property

        Private _mAddressCode As String
        Public Property AddressCode As String
            Get
                Return _mAddressCode
            End Get
            Set(ByVal Value As String)
                _mAddressCode = Value
            End Set
        End Property

    End Class

End Namespace