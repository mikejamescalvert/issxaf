Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP

Namespace UPR
    Public Class UPRFactory
        Private _mMSGPConnectionString As String
        Private _mExceptionMessages As New System.Collections.Specialized.StringCollection

#Region "Properties"
        Public Property MSGPConnectionString() As String
            Get
                Return _mMSGPConnectionString
            End Get
            Set(ByVal value As String)
                _mMSGPConnectionString = value
            End Set
        End Property
        Public Property ExceptionMessages() As System.Collections.Specialized.StringCollection
            Get
                Return _mExceptionMessages
            End Get
            Set(ByVal value As System.Collections.Specialized.StringCollection)
                _mExceptionMessages = value
            End Set
        End Property
#End Region
#Region "Operations"
        Public Function CreateUpdateEmployee(ByVal Employee As UPREmployee) As Boolean
            Dim uprEmployee As New eConnect.Serialization.UPRCreateEmployeeType
            Dim taEmployeeCreate As New eConnect.Serialization.taCreateEmployee
            Dim strCurrentRequest As String = ""
            Dim uprEmployeeTax As eConnect.Serialization.UPRCreateEmployeeTaxType
            Dim taEmployeeTax As eConnect.Serialization.taCreateEmployeeTax
            Dim blnProceed As Boolean = False
            'todo: create local taxes
            Dim uprLocalTax As eConnect.Serialization.UPRCreateEmployeeLocalTaxType
            Dim taEmployeeLocalTax As eConnect.Serialization.taCreateEmployeeLocalTax


            Dim uprEmployeeStateTax As eConnect.Serialization.UPRCreateEmployeeStateTaxType
            Dim taEmployeeStateTax As eConnect.Serialization.taCreateEmployeeStateTax

            Try
                Me.ExceptionMessages.Clear()
                'validate

                With taEmployeeCreate
                    If Employee.EmployeeClassCode > String.Empty Then
                        .EMPLCLAS = Employee.EmployeeClassCode
                        .DefaultFromClass = 1
                    Else
                        .DefaultFromClass = 0
                    End If
                    .USERDEF1 = Employee.UserDefined1
                    .USERDEF2 = Employee.UserDefined2
                    .FRSTNAME = Employee.FirstName
                    .LASTNAME = Employee.LastName
                    .MIDLNAME = Employee.MiddleName
                    .SOCSCNUM = Employee.SocialSecurityNumber
                    .EMPLOYID = Employee.EmployeeID
                    .ADDRESS1 = Employee.Address1
                    .ADDRESS2 = Employee.Address2
                    .ADDRESS3 = Employee.Address3
                    .CITY = Employee.City
                    .STATE = Employee.State
                    .ZIPCODE = Employee.ZipCode
                    .DIVISIONCODE_I = Employee.Division
                    .COUNTRY = Employee.Country
                    .PHONE1 = Employee.Phone1
                    .PHONE2 = Employee.Phone2
                    .SUTASTAT = Employee.SutaState
                    .NICKNAME = Employee.NickName
                    .ADRSCODE = Employee.AddressCode
                    .LOCATNID = Employee.LocationCode
                    If Employee.EmployeeType.HasValue = True Then
                        .EMPLOYMENTTYPE = Employee.EmployeeType
                        .EMPLOYMENTTYPESpecified = True
                    End If
                    .DEPRTMNT = Employee.Department
                    .JOBTITLE = Employee.JobTitle
                    .SUPERVISORCODE_I = Employee.SupervisorCode
                    If Employee.BirthDate <> Nothing Then
                        .BRTHDATE = Employee.BirthDate.ToString("MM/dd/yyyy")
                    End If
                    If Employee.HireDate <> Nothing Then
                        .STRTDATE = Employee.HireDate.ToString("MM/dd/yyyy")
                    End If
                    .GENDER = Employee.Gender
                    .ETHNORGN = Employee.EthnicOrigin
                    .MARITALSTATUS = Employee.MaritalStatus
                    .WRKRCOMP = Employee.WorkmansCompCode


                    .UpdateIfExists = 1


                End With

                With uprEmployee
                    .taCreateEmployee = taEmployeeCreate
                    If Employee.EmailAddress > String.Empty Then
                        ReDim .taCreateInternetAddresses_Items(0)
                        .taCreateInternetAddresses_Items(0) = New eConnect.Serialization.taCreateInternetAddresses_ItemsTaCreateInternetAddresses
                        .taCreateInternetAddresses_Items(0).EmailToAddress = Employee.EmailAddress
                        .taCreateInternetAddresses_Items(0).ADRSCODE = Employee.AddressCode
                        .taCreateInternetAddresses_Items(0).INET1 = Employee.EmailAddress
                        .taCreateInternetAddresses_Items(0).Master_Type = "EMP"
                        .taCreateInternetAddresses_Items(0).Master_ID = Employee.EmployeeID

                    End If

                End With


                If CommonLogic.eConnectCreate(Me.MSGPConnectionString, uprEmployee, strCurrentRequest) = True Then
                    blnProceed = False
                    If String.IsNullOrEmpty(Employee.LocalTaxCode) = False Then
                        taEmployeeLocalTax = New eConnect.Serialization.taCreateEmployeeLocalTax
                        With taEmployeeLocalTax
                            .EMPLOYID = Employee.EmployeeID
                            .LOCALTAX = Employee.LocalTaxCode
                            .AULCLTAX = 1
                            .INACTIVE = 0
                        End With

                        uprLocalTax = New eConnect.Serialization.UPRCreateEmployeeLocalTaxType
                        With uprLocalTax
                            .taCreateEmployeeLocalTax = taEmployeeLocalTax
                        End With
                        blnProceed = CommonLogic.eConnectCreate(Me.MSGPConnectionString, uprLocalTax, strCurrentRequest)
                    Else
                        blnProceed = True
                    End If


                    If blnProceed = True Then

                        taEmployeeTax = New eConnect.Serialization.taCreateEmployeeTax
                        With taEmployeeTax
                            '.EICFLGST = Employee.EICFlag
                            .FDFLGSTS = Employee.FederalFilingStatus
                            .FEDEXMPT = Employee.FederalExemptions
                            .ADFDWHDG = Employee.AdditionalFederalWithholding
                            .ESTFEDWH = Employee.EstimatedWithholding
                            .EMPLOYID = Employee.EmployeeID
                            .LOCALTAX = Employee.LocalTaxCode
                            .STATECD = Employee.WithholdingState
                            .UpdateIfExists = 1
                        End With

                        uprEmployeeTax = New eConnect.Serialization.UPRCreateEmployeeTaxType
                        With uprEmployeeTax
                            .taCreateEmployeeTax = taEmployeeTax

                        End With

                        If CommonLogic.eConnectCreate(Me.MSGPConnectionString, uprEmployeeTax, strCurrentRequest) = True Then

                            taEmployeeStateTax = New eConnect.Serialization.taCreateEmployeeStateTax
                            With taEmployeeStateTax
                                .EMPLOYID = Employee.EmployeeID
                                .STATECD = Employee.WithholdingState
                                .TXFLGSTS = Employee.StateFilingCode
                                .EXMFRSPS = Employee.StateSpouseExempt
                                .DEPNDNTS = Employee.StateExemption
                                '.EXMTAMNT = Employee.StateExemption
                                .ADSTWHDG = Employee.StateAdditionalWithholding
                                .EXMFRSLF = IIf(Employee.StateExempt = True, 1, 0)
                                .UpdateIfExists = 1

                            End With

                            uprEmployeeStateTax = New eConnect.Serialization.UPRCreateEmployeeStateTaxType
                            With uprEmployeeStateTax
                                .taCreateEmployeeStateTax = taEmployeeStateTax

                            End With
                            If CommonLogic.eConnectCreate(Me.MSGPConnectionString, uprEmployeeStateTax, strCurrentRequest) = True Then
                                Return True
                            Else
                                Me.ExceptionMessages.Add("Source, State Tax Create")
                                Me.ExceptionMessages.Add(strCurrentRequest)
                                Return False
                            End If


                        Else
                            Me.ExceptionMessages.Add("Source, Employee Tax Create")
                            Me.ExceptionMessages.Add(strCurrentRequest)
                            Return False
                        End If
                    Else
                        Me.ExceptionMessages.Add("Source, Local Tax Create")
                        Me.ExceptionMessages.Add(strCurrentRequest)
                        Return False
                    End If


                Else
                    Me.ExceptionMessages.Add("Source, Employee Create")
                    Me.ExceptionMessages.Add(strCurrentRequest)
                    Return False
                End If


            Catch ex As Exception
                Me.ExceptionMessages.Add("Source, General")
                Me.ExceptionMessages.Add(ex.Message)
                Me.ExceptionMessages.Add(strCurrentRequest)
                Return False
            End Try

        End Function
#End Region
    End Class
End Namespace
