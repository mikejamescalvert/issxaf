Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP
Namespace RM

    Public Class RMFactory


#Region "Properties"
        Private _mMSGPConnectionString As String
        Public Property MSGPConnectionString() As String
            Get
                Return _mMSGPConnectionString
            End Get
            Set(ByVal value As String)
                _mMSGPConnectionString = value
            End Set
        End Property

        Private _mExceptionMessages As New System.Collections.Specialized.StringCollection
        Public Property ExceptionMessages() As System.Collections.Specialized.StringCollection
            Get
                Return _mExceptionMessages
            End Get
            Set(ByVal value As System.Collections.Specialized.StringCollection)
                _mExceptionMessages = value
            End Set
        End Property
#End Region


#Region "Methods"
        Public Function CreateNationalAccountRelationship(ParentCustomerID As String, ChildCustomerID As String) As Boolean

            Dim taRM As New eConnect.Serialization.RMParentIDChildType
            Dim taRMChildren(0) As eConnect.Serialization.taParentIDChild_ItemsTaParentIDChild
            Try
                Me.ExceptionMessages.Clear()
                taRMChildren(0) = New eConnect.Serialization.taParentIDChild_ItemsTaParentIDChild
                With taRMChildren(0)
                    .CPRCSTNM = ParentCustomerID
                    .CUSTNMBR = ChildCustomerID
                    .CreateRemove = 0
                End With
                taRM.taParentIDChild_Items = taRMChildren
                CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)
                Return True

            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try

        End Function

        Public Function RemoveNationalAccountRelationship(ParentCustomerID As String, ChildCustomerID As String) As Boolean
            Dim taRM As New eConnect.Serialization.RMParentIDChildType
            Dim taRMChildren(0) As eConnect.Serialization.taParentIDChild_ItemsTaParentIDChild
            Try
                Me.ExceptionMessages.Clear()
                taRMChildren(0) = New eConnect.Serialization.taParentIDChild_ItemsTaParentIDChild
                With taRMChildren(0)
                    .CPRCSTNM = ParentCustomerID
                    .CUSTNMBR = ChildCustomerID
                    .CreateRemove = 1
                End With
                CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)
                Return True

            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function

        Public Function CreateNationalAccountMaster(NationalAccountMaster As RMNationalAccount, Optional ChildCustomerID As String = Nothing) As Boolean
            Dim taRM As New eConnect.Serialization.RMCreateParentIDType
            Dim taRMParent As New eConnect.Serialization.taCreateParentID
            Try
                Me.ExceptionMessages.Clear()
                With taRMParent
                    .CPRCSTNM = NationalAccountMaster.ParentCustomerId
                    .NAALLOWRECEIPTS = Math.Abs(NationalAccountMaster.AllowCashReceiptsEntryForChildren)
                    .NACREDITCHECK = NationalAccountMaster.BaseCreditCheckOnConsolidatedNationalAccount
                    .NADEFPARENTVEN = NationalAccountMaster.DefaultParentVendorForChildRefundChecks
                    .NAFINANCECHARGE = NationalAccountMaster.BaseFinanceChargeOnConsolidatedNationalAccount
                    .NAHOLDINACTIVE = NationalAccountMaster.ApplyHoldAcrossNationalAccount
                    .UpdateIfExists = NationalAccountMaster.UpdateIfExists

                End With
                taRM.taCreateParentID = taRMParent
                CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)
                If Not String.IsNullOrEmpty(ChildCustomerID) Then
                    CreateNationalAccountRelationship(NationalAccountMaster.ParentCustomerId, ChildCustomerID)
                End If
                Return True

            Catch ex As Exception
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            End Try
        End Function


        ''' <summary>
        ''' Creates a new RM territory record
        ''' </summary>
        ''' <param name="Territory"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateTerritory(ByVal Territory As RMTerritory) As Boolean
			Dim taRM As New eConnect.Serialization.RMTerritoryMasterType
			Dim taTERR As New eConnect.Serialization.taCreateTerritory

			Try
				Me.ExceptionMessages.Clear()
				Helper.ValidateMSGPRequiredFieldsComplete(Territory)
				With taTERR
					.SALSTERR = Territory.TerritoryKey
					.SLPRSNID = Territory.SalesPersonId
					.SLTERDSC = Territory.TerritoryName
					.STMGRFNM = Territory.SalesManagerFirstName
					.STMGRLNM = Territory.SalesManagerLastName
				End With
				taRM.taCreateTerritory = taTERR
				CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)

				Return True

			Catch ex As Exception
				Me.ExceptionMessages.Add(ex.Message)
				Return False
			End Try
		End Function



		''' <summary>
		''' Updates a customer address
		''' </summary>
		''' <param name="CustomerAddress"></param>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Function CreateUpdateCustomerAddress(ByVal CustomerAddress As RMCustomerAddress, Optional ByVal UpdateIfExists As Boolean = True) As Boolean
			Dim taRM As New eConnect.Serialization.RMCustomerAddressType
			Dim taCM As New eConnect.Serialization.taUpdateCreateCustomerRcd
			Dim taADDRESSES(0) As eConnect.Serialization.taCreateCustomerAddress_ItemsTaCreateCustomerAddress
			Try
				Me.ExceptionMessages.Clear()
				Helper.ValidateMSGPRequiredFieldsComplete(CustomerAddress)
				taADDRESSES(0) = New eConnect.Serialization.taCreateCustomerAddress_ItemsTaCreateCustomerAddress
				With taADDRESSES(0)

					If UpdateIfExists = True Then
						.UpdateIfExists = 1
					Else
						.UpdateIfExists = 0
					End If
					.ADDRESS1 = CustomerAddress.AddressLine1
					.ADDRESS2 = CustomerAddress.AddressLine2
					.ADDRESS3 = CustomerAddress.AddressLine3
					.ADRSCODE = CustomerAddress.AddressCode
					.CITY = CustomerAddress.City
					.CNTCPRSN = CustomerAddress.ContactPerson
					.CUSTNMBR = CustomerAddress.CustomerNumber
					.COUNTRY = CustomerAddress.Country
					.LOCNCODE = CustomerAddress.InventorySiteId
					.PHNUMBR1 = CustomerAddress.PhoneNumber1
					.PHNUMBR2 = CustomerAddress.PhoneNumber2
					.PHNUMBR3 = CustomerAddress.PhoneNumber3
					.SALSTERR = CustomerAddress.TerritoryId
					.SLPRSNID = CustomerAddress.SalesPersonId
					.STATE = CustomerAddress.State
					.ZIPCODE = CustomerAddress.ZipCode
					.TAXSCHID = CustomerAddress.TaxScheduleId
					.SHIPMTHD = CustomerAddress.ShippingMethod
					.USERDEF1 = CustomerAddress.UserDefined1
					.USERDEF2 = CustomerAddress.UserDefined2
				End With

				taRM.taCreateCustomerAddress_Items = taADDRESSES
				CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)

				'create Address first before creating email address
				Dim objCMPFactory As New CMP.CMPFactory
				objCMPFactory.MSGPConnectionString = Me.MSGPConnectionString
				objCMPFactory.CreateInternetAddress(CustomerAddress.InternetAddress)
				For Each strMessage As String In objCMPFactory.ExceptionMessages
					Me.ExceptionMessages.Add(strMessage)
				Next

				Return True

			Catch ex As Exception
				Me.ExceptionMessages.Add(ex.Message)
				Return False
			End Try
		End Function

		''' <summary>
		''' Creates or updates a customer master record
		''' creates or Updates Customer address if included
		''' Updates only occur if UpdateExisting ir true
		''' </summary>
		''' <param name="Customer"></param>
		''' <param name="UpdateExisting"></param>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Function CreateUpdateCustomer(ByVal Customer As RMCustomer, Optional ByVal UpdateExisting As Boolean = True) As Boolean
			Dim taRM As New eConnect.Serialization.RMCustomerMasterType
			Dim taCustomer As New eConnect.Serialization.taUpdateCreateCustomerRcd
			Dim taADDRESSES() As eConnect.Serialization.taCreateCustomerAddress_ItemsTaCreateCustomerAddress

			Try
				Me.ExceptionMessages.Clear()
				With taCustomer
					If UpdateExisting = True Then
						.UpdateIfExists = 1
					Else
						.UpdateIfExists = 2
					End If
					If Not String.IsNullOrEmpty(Customer.CustomerClassCode) Then
						.CUSTCLAS = Customer.CustomerClassCode
						.UseCustomerClass = 1
					End If
					.CUSTNMBR = Customer.CustomerNumber
					.CUSTNAME = Customer.CustomerName
					If Not String.IsNullOrEmpty(Customer.AddressCode) Then
						.ADRSCODE = Customer.AddressCode
					End If
					If Not String.IsNullOrEmpty(Customer.PrimaryBillToAddressCode) Then
						.PRBTADCD = Customer.PrimaryBillToAddressCode
					End If
					If Not String.IsNullOrEmpty(Customer.PrimaryShipToAddressCode) Then
						.PRSTADCD = Customer.PrimaryShipToAddressCode
					End If
					If Not String.IsNullOrEmpty(Customer.SalesPersonID) Then
						.SLPRSNID = Customer.SalesPersonID
					End If
					If Not String.IsNullOrEmpty(Customer.SalesTerritory) Then
						.SALSTERR = Customer.SalesTerritory
					End If
					If Not String.IsNullOrEmpty(Customer.UserDefined1) Then
						.USERDEF1 = Customer.UserDefined1
					End If
					If Not String.IsNullOrEmpty(Customer.UserDefined2) Then
						.USERDEF2 = Customer.UserDefined2
					End If
					If Not String.IsNullOrEmpty(Customer.Comment1) Then
						.COMMENT1 = Customer.Comment1
					End If
					If Not String.IsNullOrEmpty(Customer.PaymentTermID) Then
						.PYMTRMID = Customer.PaymentTermID
					End If
                    If Customer.Addresses.Count > 0 Then
                        ReDim taADDRESSES(Customer.Addresses.Count - 1)
                        For j As Integer = 0 To Customer.Addresses.Count - 1
                            'populate customer number from customer
                            Customer.Addresses(j).CustomerNumber = Customer.CustomerNumber

                            Try
                                'validate address objects
                                Helper.ValidateMSGPRequiredFieldsComplete(Customer.Addresses(j))

                                taADDRESSES(taADDRESSES.Length - 1) = New eConnect.Serialization.taCreateCustomerAddress_ItemsTaCreateCustomerAddress
                                With taADDRESSES(taADDRESSES.Length - 1)
                                    If UpdateExisting = True Then
                                        .UpdateIfExists = 1
                                    Else
                                        .UpdateIfExists = 0
                                    End If

                                    .ADDRESS1 = Customer.Addresses(j).AddressLine1
                                    .ADDRESS2 = Customer.Addresses(j).AddressLine2
                                    .ADDRESS3 = Customer.Addresses(j).AddressLine3
                                    .ADRSCODE = Customer.Addresses(j).AddressCode
                                    .CITY = Customer.Addresses(j).City
                                    .CNTCPRSN = Customer.Addresses(j).ContactPerson
                                    .CUSTNMBR = Customer.Addresses(j).CustomerNumber
                                    .COUNTRY = Customer.Addresses(j).Country
                                    .LOCNCODE = Customer.Addresses(j).InventorySiteId
                                    .PHNUMBR1 = Customer.Addresses(j).PhoneNumber1
                                    .PHNUMBR2 = Customer.Addresses(j).PhoneNumber2
                                    .PHNUMBR3 = Customer.Addresses(j).PhoneNumber3
                                    .SALSTERR = Customer.Addresses(j).TerritoryId
                                    .SLPRSNID = Customer.Addresses(j).SalesPersonId
                                    .STATE = Customer.Addresses(j).State
                                    .ZIPCODE = Customer.Addresses(j).ZipCode
                                    .TAXSCHID = Customer.Addresses(j).TaxScheduleId
                                    .SHIPMTHD = Customer.Addresses(j).ShippingMethod
                                    .USERDEF1 = Customer.Addresses(j).UserDefined1
                                    .USERDEF2 = Customer.Addresses(j).UserDefined2
                                End With

                            Catch ex As MSGPRequiredFieldValidationException
                                Me.ExceptionMessages.Add(String.Format("Customer address vaildation problem: {0}", Customer.Addresses(j).AddressCode))
                                Me.ExceptionMessages.Add(ex.Message)

                            Catch ex As Exception
                                Throw ex
                            End Try
                        Next
                    End If
                    taRM.taUpdateCreateCustomerRcd = taCustomer
					taRM.taCreateCustomerAddress_Items = taADDRESSES
					CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)

					'create email address after all addresses have been created
					If Customer.Addresses.Count > 0 Then
						For j As Integer = 0 To Customer.Addresses.Count - 1
							'populate customer number from customer
							Customer.Addresses(j).CustomerNumber = Customer.CustomerNumber

							Try
								'call CMPFactory and pass along customer.Addresses(j).InternetAddress
								If Customer.Addresses(j).InternetAddress IsNot Nothing Then
									Dim objCMPFactory As New CMP.CMPFactory
									objCMPFactory.MSGPConnectionString = Me.MSGPConnectionString
									objCMPFactory.CreateInternetAddress(Customer.Addresses(j).InternetAddress)
									For Each strMessage As String In objCMPFactory.ExceptionMessages
										Me.ExceptionMessages.Add(strMessage)
									Next
								End If


							Catch ex As MSGPRequiredFieldValidationException
								Me.ExceptionMessages.Add(ex.Message)
							Catch ex As Exception
								Throw ex
							End Try
						Next
					End If

					Return True

				End With
			Catch ex As Exception
				Me.ExceptionMessages.Add(ex.Message)
				Return False

			End Try
		End Function




		Public Function CreateCashReceipt(ByVal CashReceipt As RMCashReceipt) As Boolean
			Dim taRM As New eConnect.Serialization.RMCashReceiptsType
			Dim taCR As New eConnect.Serialization.taRMCashReceiptInsert
			Dim RMA As RMApply
			'Dim txCRD As New eConnect.Serialization.taRMDistribution_ItemsTaRMDistribution
			Try
				Me.ExceptionMessages.Clear()
				With taCR
					.CUSTNMBR = CashReceipt.CustomerNumber
					.DOCNUMBR = CashReceipt.DocumentNumber
					.DOCDATE = CashReceipt.DocumentDate
					.ORTRXAMT = CashReceipt.Amount
					.BACHNUMB = CashReceipt.BatchNumber
					.CHEKNMBR = CashReceipt.CreditCardNumberOrCheckNumber
					.CRCARDID = CashReceipt.CreditCardID
					.TRXDSCRN = CashReceipt.TransactionDescription
                    .CSHRCTYP = CashReceipt.ReceiptType
                    .BatchCHEKBKID = CashReceipt.BatchCheckbookId

                    If CashReceipt.GLPostingDate.HasValue = False Then
						.GLPOSTDT = CashReceipt.DocumentDate
					Else
						.GLPOSTDT = CashReceipt.GLPostingDate.Value.Date
					End If

				End With
				taRM.taRMCashReceiptInsert = taCR
				CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)

				For Each CRApply As RMCashReceiptApply In CashReceipt.ApplyTos
					RMA = New RMApply
					With RMA
						.ApplyAmount = CRApply.ApplyAmount
						.ApplyDate = CRApply.ApplyDate
						.ApplyFromDocumentNumber = CashReceipt.DocumentNumber
						.ApplyFromDocumentType = RMApply.ApplyFromDocumentTypes.CashReceipt
						.ApplyToDocumentNumber = CRApply.ApplyToDocumentNumber
						.ApplyToDocumentType = CRApply.ApplyToDocumentType
						.PostingDate = CRApply.ApplyPostingDate
					End With
					Me.ApplyCashReceipt(RMA)
				Next

				Return True

			Catch ex As Exception
				Me.ExceptionMessages.Add(ex.Message)
				Return False
			End Try

		End Function

		Public Function ApplyCashReceipt(ByVal ApplyTo As RMApply) As Boolean
			Dim taRM As New eConnect.Serialization.RMApplyType
			Dim taApply As New eConnect.Serialization.taRMApply
			Try
				Me.ExceptionMessages.Clear()
				With taApply
					.APTODCNM = ApplyTo.ApplyToDocumentNumber
					.APFRDCNM = ApplyTo.ApplyFromDocumentNumber
					.APPTOAMT = ApplyTo.ApplyAmount
					.APFRDCTY = ApplyTo.ApplyFromDocumentType
					.APTODCTY = ApplyTo.ApplyToDocumentType
					.APPLYDATE = ApplyTo.ApplyDate
					If ApplyTo.PostingDate.HasValue Then
						.GLPOSTDT = ApplyTo.PostingDate.Value.Date
					Else
						.GLPOSTDT = ApplyTo.ApplyDate
					End If
				End With

				taRM.taRMApply = taApply
				CommonLogic.eConnectCreate(Me.MSGPConnectionString, taRM)
				Return True

			Catch ex As Exception
				Me.ExceptionMessages.Add(ex.Message)
				Return False

			End Try


		End Function






#End Region


	End Class
End Namespace

