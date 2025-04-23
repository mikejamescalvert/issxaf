Imports DevExpress.Xpo

Namespace UPR
    Public Class UPREmployee
        Private _mEmployeeID As String
        Property EmployeeID As String
            Get
                Return _mEmployeeID
            End Get
            Set(ByVal Value As String)
                _mEmployeeID = Value
            End Set
        End Property
        Private _mFirstName As String
        Property FirstName As String
            Get
                Return _mFirstName
            End Get
            Set(ByVal Value As String)
                _mFirstName = Value
            End Set
        End Property
        Private _mEmailAddress As String
        Property EmailAddress As String
            Get
                Return _mEmailAddress
            End Get
            Set(ByVal Value As String)
                _mEmailAddress = Value
            End Set
        End Property
        
        Private _mLocalTaxCode As String
        Property LocalTaxCode As String
            Get
                Return _mLocalTaxCode
            End Get
            Set(ByVal Value As String)
                _mLocalTaxCode = Value
            End Set
        End Property
        Private _mSutaState As String
        Property SutaState As String
            Get
                Return _mSutaState
            End Get
            Set(ByVal Value As String)
                _mSutaState = Value
            End Set
        End Property

        Private _mEmployeeClassCode As String
        Property EmployeeClassCode As String
            Get
                Return _mEmployeeClassCode
            End Get
            Set(ByVal Value As String)
                _mEmployeeClassCode = Value
            End Set
        End Property
        

        Private _mLastName As String
        Property LastName As String
            Get
                Return _mLastName
            End Get
            Set(ByVal Value As String)
                _mLastName = Value
            End Set
        End Property
        Private _mMiddleName As String
        Property MiddleName As String
            Get
                Return _mMiddleName
            End Get
            Set(ByVal Value As String)
                _mMiddleName = Value
            End Set
        End Property
        Private _mSocialSecurityNumber As String
        Property SocialSecurityNumber As String
            Get
                Return _mSocialSecurityNumber
            End Get
            Set(ByVal Value As String)
                _mSocialSecurityNumber = Value
            End Set
        End Property
        Private _mHireDate As Date
        Property HireDate As Date
            Get
                Return _mHireDate
            End Get
            Set(ByVal Value As Date)
                _mHireDate = Value
            End Set
        End Property

        Private _mNickName As String
        Property NickName As String
            Get
                Return _mNickName
            End Get
            Set(ByVal Value As String)
                _mNickName = Value
            End Set
        End Property
        

        Private _mAddressCode As String
        Property AddressCode As String
            Get
                Return _mAddressCode
            End Get
            Set(ByVal Value As String)
                _mAddressCode = Value
            End Set
        End Property
        Private _mLocationCode As String
        Property LocationCode As String
            Get
                Return _mLocationCode
            End Get
            Set(ByVal Value As String)
                _mLocationCode = Value
            End Set
        End Property
        Private _mEmployeeType As Short?
        Property EmployeeType As Short?
            Get
                Return _mEmployeeType
            End Get
            Set(ByVal Value As Short?)
                _mEmployeeType = Value
            End Set
        End Property
        Private _mDepartment As String
        Property Department As String
            Get
                Return _mDepartment
            End Get
            Set(ByVal Value As String)
                _mDepartment = Value
            End Set
        End Property
        Private _mJobTitle As String
        Property JobTitle As String
            Get
                Return _mJobTitle
            End Get
            Set(ByVal Value As String)
                _mJobTitle = Value
            End Set
        End Property
        Private _mSupervisorCode As String
        Property SupervisorCode As String
            Get
                Return _mSupervisorCode
            End Get
            Set(ByVal Value As String)
                _mSupervisorCode = Value
            End Set
        End Property
        Private _mBirthDate As Date
        Property BirthDate As Date
            Get
                Return _mBirthDate
            End Get
            Set(ByVal Value As Date)
                _mBirthDate = Value
            End Set
        End Property
        Private _mGender As Short
        Property Gender As Short
            Get
                Return _mGender
            End Get
            Set(ByVal Value As Short)
                _mGender = Value
            End Set
        End Property
        Private _mEthnicOrigin As Short
        Property EthnicOrigin As Short
            Get
                Return _mEthnicOrigin
            End Get
            Set(ByVal Value As Short)
                _mEthnicOrigin = Value
            End Set
        End Property
        Private _mMaritalStatus As Short
        Property MaritalStatus As Short
            Get
                Return _mMaritalStatus
            End Get
            Set(ByVal Value As Short)
                _mMaritalStatus = Value
            End Set
        End Property


        Private _mAddress1 As String
        Property Address1 As String
            Get
                Return _mAddress1
            End Get
            Set(ByVal Value As String)
                _mAddress1 = Value
            End Set
        End Property
        Private _mAddress2 As String
        Property Address2 As String
            Get
                Return _mAddress2
            End Get
            Set(ByVal Value As String)
                _mAddress2 = Value
            End Set
        End Property
        Private _mAddress3 As String
        Property Address3 As String
            Get
                Return _mAddress3
            End Get
            Set(ByVal Value As String)
                _mAddress3 = Value
            End Set
        End Property
        Private _mCity As String
        Property City As String
            Get
                Return _mCity
            End Get
            Set(ByVal Value As String)
                _mCity = Value
            End Set
        End Property
        Private _mState As String
        Property State As String
            Get
                Return _mState
            End Get
            Set(ByVal Value As String)
                _mState = Value
            End Set
        End Property
        Private _mZipCode As String
        Property ZipCode As String
            Get
                Return _mZipCode
            End Get
            Set(ByVal Value As String)
                _mZipCode = Value
            End Set
        End Property
        Private _mDivision As String
        Property Division As String
            Get
                Return _mDivision
            End Get
            Set(ByVal Value As String)
                _mDivision = Value
            End Set
        End Property
        
        Private _mCountry As String
        Property Country As String
            Get
                Return _mCountry
            End Get
            Set(ByVal Value As String)
                _mCountry = Value
            End Set
        End Property
        Private _mPhone1 As String
        Property Phone1 As String
            Get
                Return _mPhone1
            End Get
            Set(ByVal Value As String)
                _mPhone1 = Value
            End Set
        End Property

        Private _mPhone2 As String
        Property Phone2 As String
            Get
                Return _mPhone2
            End Get
            Set(ByVal Value As String)
                _mPhone2 = Value
            End Set
        End Property
        Private _mWorkmansCompCode As String
        Property WorkmansCompCode As String
            Get
                Return _mWorkmansCompCode
            End Get
            Set(ByVal Value As String)
                _mWorkmansCompCode = Value
            End Set
        End Property
        

        'Private _mEICFlag As Short
        'Property EICFlag As Short
        '    Get
        '        Return _mEICFlag
        '    End Get
        '    Set(ByVal Value As Short)
        '        _mEICFlag = Value
        '    End Set
        'End Property
        Private _mFederalFilingStatus As String
        Property FederalFilingStatus As String
            Get
                Return _mFederalFilingStatus
            End Get
            Set(ByVal Value As String)
                _mFederalFilingStatus = Value
            End Set
        End Property
        Private _mFederalExemptions As Short
        Property FederalExemptions As Short
            Get
                Return _mFederalExemptions
            End Get
            Set(ByVal Value As Short)
                _mFederalExemptions = Value
            End Set
        End Property
        Private _mAdditionalFederalWithholding As Decimal
        Property AdditionalFederalWithholding As Decimal
            Get
                Return _mAdditionalFederalWithholding
            End Get
            Set(ByVal Value As Decimal)
                _mAdditionalFederalWithholding = Value
            End Set
        End Property
        Private _mEstimatedWithholding As Decimal
        Property EstimatedWithholding As Decimal
            Get
                Return _mEstimatedWithholding
            End Get
            Set(ByVal Value As Decimal)
                _mEstimatedWithholding = Value
            End Set
        End Property
        Private _mWithholdingState As String
        Property WithholdingState As String
            Get
                Return _mWithholdingState
            End Get
            Set(ByVal Value As String)
                _mWithholdingState = Value
            End Set
        End Property

        Private _mStateSpouseExempt As Integer
        Property StateSpouseExempt As Integer
            Get
                Return _mStateSpouseExempt
            End Get
            Set(ByVal Value As Integer)
                _mStateSpouseExempt = Value
            End Set
        End Property
        Private _mStateFilingCode As String
        Property StateFilingCode As String
            Get
                Return _mStateFilingCode
            End Get
            Set(ByVal Value As String)
                _mStateFilingCode = Value
            End Set
        End Property
        

        'Private _mStateMarried As Boolean
        'Property StateMarried As Boolean
        '    Get
        '        Return _mStateMarried
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        _mStateMarried = Value
        '    End Set
        'End Property
        Private _mStateExemption As Decimal
        Property StateExemption As Decimal
            Get
                Return _mStateExemption
            End Get
            Set(ByVal Value As Decimal)
                _mStateExemption = Value
            End Set
        End Property
        Private _mStateAdditionalWithholding As Decimal
        Property StateAdditionalWithholding As Decimal
            Get
                Return _mStateAdditionalWithholding
            End Get
            Set(ByVal Value As Decimal)
                _mStateAdditionalWithholding = Value
            End Set
        End Property
        Private _mStateExempt As Boolean
        Property StateExempt As Boolean
            Get
                Return _mStateExempt
            End Get
            Set(ByVal Value As Boolean)
                _mStateExempt = Value
            End Set
        End Property
        Private _mUserDefined1 As String
        Property UserDefined1 As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal Value As String)
                _mUserDefined1 = Value
            End Set
        End Property
        Private _mUserDefined2 As String
        Property UserDefined2 As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal Value As String)
                _mUserDefined2 = Value
            End Set
        End Property
        

    End Class
End Namespace

