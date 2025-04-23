Imports Microsoft.Dynamics.GP
Imports Microsoft.Dynamics.GP.eConnect.Serialization
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace SOP
	Public Class SOPFactory
		Public Enum SOPQuantityShortageTypes
			SellBalance = 1
			OverrideShortage = 2
			BackOrderAll = 3
			BackOrderBalance = 4
			CancelAll = 5
			CancelBalance = 6

		End Enum

		Public Enum SOPTYPES
			Quote = 1
			Order = 2
			Invoice = 3
			[Return] = 4
			BackOrder = 5
			FulFillmentOrder = 6
		End Enum
		Private _mMSGPConnectionString As String
		Private _mExceptionMessages As New System.Collections.Specialized.StringCollection
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

		Public Function GetNextSopNumber(ByVal DocType As SOPDocTypes, ByVal DocIdKey As String) As String
			Dim sop As New eConnect.GetSopNumber
			With sop
				Return .GetNextSopNumber(DocType, DocIdKey, MSGPConnectionString)
			End With
		End Function
		Public Function UpdateSOPOrderBatchId(CUSTNMBR As String, SOPNUMBE As String, SOPTYPE As SOPTYPES, DOCID As String, DOCDATE As Date, TargetBatchId As String) As Boolean
			Me._mExceptionMessages.Clear()

			Try

				Dim SOP As New Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
				Dim taSopHdrIvcInsert As eConnect.Serialization.taSopHdrIvcInsert

				taSopHdrIvcInsert = New eConnect.Serialization.taSopHdrIvcInsert
				With taSopHdrIvcInsert
					.CUSTNMBR = CUSTNMBR
					.SOPTYPE = SOPTYPE.GetHashCode
					.SOPNUMBE = SOPNUMBE
					.DOCID = DOCID
					.DOCDATE = DOCDATE
					.BACHNUMB = TargetBatchId
					.UpdateExisting = 1
				End With


				With SOP
					.taSopHdrIvcInsert = taSopHdrIvcInsert
				End With
				If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, SOP) = True Then
					Return True
				Else
					Return False
				End If
			Catch ex As Exception
				Me.HandleException(ex)
				Return False
			End Try
		End Function

		Public Function UpdateSOPLineToInvoice(SOPNUMBE As String, SOPTYPE As SOPTYPES, CUSTNMBR As String, DOCDATE As Date, LNITMSEQ As Integer, ITEMNMBR As String, QuantityToInvoice As Decimal, BackOrderQty As Decimal, Shipdate As Date, QuantityShortageHandling As SOPQuantityShortageTypes) As Boolean
			Me._mExceptionMessages.Clear()

			Try

				Dim SOP As New Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
				Dim taSopLineIvcInserts(0) As eConnect.Serialization.taSopLineIvcInsert_ItemsTaSopLineIvcInsert

				taSopLineIvcInserts(0) = New eConnect.Serialization.taSopLineIvcInsert_ItemsTaSopLineIvcInsert
				With taSopLineIvcInserts(0)
					.SOPTYPE = SOPTYPE.GetHashCode
					.SOPNUMBE = SOPNUMBE
					.CUSTNMBR = CUSTNMBR
					.DOCDATE = DOCDATE
					.ITEMNMBR = ITEMNMBR
					.LNITMSEQ = LNITMSEQ
					.QtyShrtOpt = QuantityShortageHandling.GetHashCode
					If BackOrderQty > 0 Then
						.QTYTBAOR = BackOrderQty
					End If
					.QUANTITY = QuantityToInvoice
					.ACTLSHIP = Shipdate
					.UpdateIfExists = 1

				End With


				With SOP
					.taSopLineIvcInsert_Items = taSopLineIvcInserts
				End With
				If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, SOP) = True Then
					Return True
				Else
					Return False
				End If
			Catch ex As Exception
				Me.HandleException(ex)
				Return False
			End Try

		End Function

		'HWR 07/16/14
		'NOT TESTED 
		'Public Function CreateUpdateSopLine(SOPNUMBE As String, SOPTYPE As SOPTYPES, CUSTNMBR As String, DOCDATE As Date, LNITMSEQ As Integer, TAXSCHID As String, ByRef SOPLine As SOPOrderLine, UpdateExisting As Boolean) As Boolean

		'	Me._mExceptionMessages.Clear()

		'	Try
		'		Helper.ValidateMSGPRequiredFieldsComplete(SOPLine)
		'		Dim SOP As New Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
		'		Dim taSopLineIvcInserts(0) As eConnect.Serialization.taSopLineIvcInsert_ItemsTaSopLineIvcInsert


		'		taSopLineIvcInserts(0) = New eConnect.Serialization.taSopLineIvcInsert_ItemsTaSopLineIvcInsert
		'		With taSopLineIvcInserts(0)
		'			.SOPTYPE = SOPTYPE.GetHashCode
		'			.SOPNUMBE = SOPNUMBE
		'			.CUSTNMBR = CUSTNMBR
		'			.DOCDATE = DOCDATE
		'			.LNITMSEQ = LNITMSEQ
		'			.UOFM = SOPLine.UnitOfMeasure
		'			.ITEMNMBR = SOPLine.ItemNumber
		'			If Not String.IsNullOrEmpty(SOPLine.LocationId) Then
		'				.LOCNCODE = SOPLine.LocationId
		'			End If
		'			.TAXSCHID = TAXSCHID
		'			.IVITMTXB = SOPLine.ItemTaxType.GetHashCode
		'			.COMMENT_1 = SOPLine.Comments
		'			.QUANTITY = SOPLine.Quantity
		'			.UNITPRCE = SOPLine.UnitPrice
		'			.SLSINDX = SOPLine.SalesAccountNumber
		'			.USRDEFND1 = SOPLine.UserDefined1
		'			.USRDEFND2 = SOPLine.UserDefined2
		'			.USRDEFND3 = SOPLine.UserDefined3
		'			.Print_Phone_NumberGB = 1
		'			.Print_Phone_NumberGBSpecified = True
		'			If SOPLine.RequestedShipDate.HasValue Then
		'				.ReqShipDate = SOPLine.RequestedShipDate.Value
		'			End If
		'			If SOPLine.ShipDate.HasValue Then
		'				.ACTLSHIP = SOPLine.ShipDate.Value
		'			End If
		'			If Not String.IsNullOrEmpty(SOPLine.ShippingMethodKey) Then
		'				.SHIPMTHD = SOPLine.ShippingMethodKey
		'			End If
		'			.DEFEXTPRICE = 1

		'			If Not String.IsNullOrEmpty(SOPLine.ItemDescription) Then
		'				.ITEMDESC = SOPLine.ItemDescription
		'			End If
		'			If UpdateExisting Then
		'				.UpdateIfExists = 1
		'			End If
		'		End With

		'		With SOP
		'			.taSopLineIvcInsert_Items = taSopLineIvcInserts
		'		End With
		'		If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, SOP) = True Then
		'			Return True
		'		Else
		'			Return False
		'		End If
		'	Catch ex As Exception
		'		Me.HandleException(ex)
		'		Return False
		'	End Try

		'End Function
		Public Function CreateSopDocument(ByRef SopOrder As SOPOrder) As String
			Me._mExceptionMessages.Clear()

			Try
				'set SOP doc number
				If SopOrder.SopNumber = String.Empty Then
                    SopOrder.SopNumber = CommonLogic.GetNextSOPDocNumber(MSGPConnectionString, SopOrder.SopType, SopOrder.DocumentID)
				End If
				SopOrder.DocumentDate = SopOrder.DocumentDate.Subtract(SopOrder.DocumentDate.TimeOfDay)

				Helper.ValidateMSGPRequiredFieldsComplete(SopOrder)

				Dim SOP As New Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
				Dim taSopHdrIvcInsert As New eConnect.Serialization.taSopHdrIvcInsert
				Dim taSopLineIvcInserts() As eConnect.Serialization.taSopLineIvcInsert_ItemsTaSopLineIvcInsert
				Dim taSopPaymentInserts() As eConnect.Serialization.taCreateSopPaymentInsertRecord_ItemsTaCreateSopPaymentInsertRecord
				Dim taSopDistributionInserts() As eConnect.Serialization.taSopDistribution_ItemsTaSopDistribution
				Dim taSopUserDefined As New eConnect.Serialization.taSopUserDefined
				Dim SopPayment As SOP.SOPPayment
				Dim SopLine As SOP.SOPOrderLine
				Dim SopDistribution As SOP.SOPDistribution
				With taSopHdrIvcInsert
					.CREATETAXES = 1
					.PRBTADCD = SopOrder.BillToAddressCode
					.PRSTADCD = SopOrder.ShipToAddressCode
					.SLPRSNID = SopOrder.SalesPersonKey
					.ADDRESS1 = SopOrder.Address1
					.ADDRESS2 = SopOrder.Address2
					.ADDRESS3 = SopOrder.Address3
					.BACHNUMB = SopOrder.BatchNumber
					.REFRENCE = SopOrder.GLReference
					.CITY = SopOrder.City
					.CNTCPRSN = SopOrder.ContactName
					.COUNTRY = SopOrder.Country
					.CUSTNAME = SopOrder.CustomerName
					.CUSTNMBR = SopOrder.CustomerNumber
					.DOCDATE = SopOrder.DocumentDate

					If SopOrder.DueDate.HasValue Then
						.DUEDATE = SopOrder.DueDate.Value.ToString("MM/dd/yyyy")
					End If
					.DOCID = SopOrder.DocumentID
					.FAXNUMBR = SopOrder.FaxNumber
					.FREIGHT = SopOrder.FreightAmount
					.LOCNCODE = SopOrder.LocationCode
					.PYMTRCVD = SopOrder.PaymentAmount
					.PHNUMBR1 = SopOrder.PhoneNumber
					.CSTPONBR = SopOrder.PONumber
					.SHIPMTHD = SopOrder.ShippingMethodKey
					.ShipToName = SopOrder.ShipToName
					.SOPNUMBE = SopOrder.SopNumber
					.SOPTYPE = SopOrder.SopType
					.STATE = SopOrder.State
					.TAXSCHID = SopOrder.TaxScheduleID
					.TAXAMNT = SopOrder.TaxAmount
					.ZIPCODE = SopOrder.Zip
					.DEFPRICING = 1
					.COMMENT_1 = SopOrder.Comment1
					.COMMENT_2 = SopOrder.Comment2
					.COMMENT_3 = SopOrder.Comment3
					.COMMENT_4 = SopOrder.Comment4
					.USRDEFND1 = SopOrder.UserDefinedDevOnly1
					.USRDEFND2 = SopOrder.UserDefinedDevOnly2
					.USRDEFND3 = SopOrder.UserDefinedDevOnly3
					.USRDEFND4 = SopOrder.UserDefinedDevOnly4
					.USRDEFND5 = SopOrder.UserDefinedDevOnly5
					.CMMTTEXT = SopOrder.CommentText
					.UPSZONE = SopOrder.UPSZone
					.PYMTRMID = SopOrder.PaymentTermsID
					.SALSTERR = SopOrder.SalesTerritory
					.NOTETEXT = SopOrder.NoteText
					.Print_Phone_NumberGB = 1
                    .Print_Phone_NumberGBSpecified = True

                    

				End With

				With taSopUserDefined
					.SOPNUMBE = SopOrder.SopNumber
					.SOPTYPE = SopOrder.SopType
					.USERDEF1 = SopOrder.UserDefined1
					.USERDEF2 = SopOrder.UserDefined2
					.USRDEF03 = SopOrder.UserDefined3
					.USRDEF04 = SopOrder.UserDefined4
					.USRDEF05 = SopOrder.UserDefined5
				End With


				'dimension the line item details to hold the incoming details
				ReDim taSopLineIvcInserts(SopOrder.SOPOrderLines.Count - 1)

				For j As Integer = 0 To SopOrder.SOPOrderLines.Count - 1
					SopLine = SopOrder.SOPOrderLines(j)
					Helper.ValidateMSGPRequiredFieldsComplete(SopLine)
					taSopLineIvcInserts(j) = New eConnect.Serialization.taSopLineIvcInsert_ItemsTaSopLineIvcInsert
					With taSopLineIvcInserts(j)
						.SOPTYPE = SopOrder.SopType
						.SOPNUMBE = SopOrder.SopNumber
						.CUSTNMBR = SopOrder.CustomerNumber
						.DOCDATE = SopOrder.DocumentDate
						.UOFM = SopLine.UnitOfMeasure
						.ITEMNMBR = SopLine.ItemNumber
						If Not String.IsNullOrEmpty(SopLine.LocationId) Then
							.LOCNCODE = SopLine.LocationId
						End If
						.TAXSCHID = SopOrder.TaxScheduleID
						.IVITMTXB = SopLine.ItemTaxType.GetHashCode
						.COMMENT_1 = SopLine.Comments
						.QUANTITY = SopLine.Quantity
                        .QTYTBAOR = SopLine.BackorderQuantity
						.UNITPRCE = SopLine.UnitPrice
						.SLSINDX = SopLine.SalesAccountNumber
						.USRDEFND1 = SopLine.UserDefined1
						.USRDEFND2 = SopLine.UserDefined2
						.USRDEFND3 = SopLine.UserDefined3
						.Print_Phone_NumberGB = 1
						.Print_Phone_NumberGBSpecified = True
						If SopLine.RequestedShipDate.HasValue Then
							.ReqShipDate = SopLine.RequestedShipDate.Value
						End If
						If SopLine.ShipDate.HasValue Then
							.ACTLSHIP = SopLine.ShipDate.Value
						End If
						If Not String.IsNullOrEmpty(SopLine.ShippingMethodKey) Then
							.SHIPMTHD = SopLine.ShippingMethodKey
						End If
						.DEFEXTPRICE = 1

						If Not String.IsNullOrEmpty(SopLine.ItemDescription) Then
							.ITEMDESC = SopLine.ItemDescription
						End If
						If SopOrder.SopType = SOPOrder.SopTypes.Return Then
							.QTYRTRND = SopLine.Quantity
						End If
					End With
				Next

				ReDim taSopDistributionInserts(SopOrder.SOPDistributions.Count - 1)

				For j As Integer = 0 To SopOrder.SOPDistributions.Count - 1
					SopDistribution = SopOrder.SOPDistributions(j)
					taSopDistributionInserts(j) = New eConnect.Serialization.taSopDistribution_ItemsTaSopDistribution

					With taSopDistributionInserts(j)
						.ACTNUMST = SopDistribution.AccountNumber
						.CRDTAMNT = SopDistribution.CreditAmount
						.CUSTNMBR = SopOrder.CustomerNumber
						.DEBITAMT = SopDistribution.DebitAmount
						.DistRef = SopDistribution.DistributionReference
						.DISTTYPE = SopDistribution.DistributionType.GetHashCode
						.SOPNUMBE = SopOrder.SopNumber
						.SOPTYPE = SopOrder.SopType.GetHashCode
					End With

				Next

				'dimension the payments to hold incoming payment records
				ReDim taSopPaymentInserts(SopOrder.SOPPayments.Count - 1)
				For j As Integer = 0 To SopOrder.SOPPayments.Count - 1
					SopPayment = SopOrder.SOPPayments(j)
					Try
						'set required properties of SOPPayment using SOPOrder and then validate
						SopPayment.SopType = SopOrder.SopType
						SopPayment.SopNumber = SopOrder.SopNumber
						Helper.ValidateMSGPRequiredFieldsComplete(SopPayment)

						taSopPaymentInserts(j) = New eConnect.Serialization.taCreateSopPaymentInsertRecord_ItemsTaCreateSopPaymentInsertRecord
						With taSopPaymentInserts(j)
							.SOPTYPE = SopPayment.SopType
							.SOPNUMBE = SopPayment.SopNumber
							.CUSTNMBR = SopOrder.CustomerNumber
							.PYMTTYPE = SopPayment.PaymentType
							.DOCAMNT = SopPayment.DocumentAmount
							.CARDNAME = SopPayment.CardName
							.RCTNCCRD = SopPayment.CardNumber
							.EXPNDATE = SopPayment.ExpirationDate.ToString("MM/dd/yyyy")
							.AUTHCODE = SopPayment.AuthorizationCode
							If Not String.IsNullOrEmpty(SopPayment.DocNumber) Then
								.DOCNUMBR = SopPayment.DocNumber
							End If
						End With

					Catch ex As MSGPRequiredFieldValidationException
						Me._mExceptionMessages.Add(String.Format("---SOPPayment object failed validation due to incomplete data: to get to the record, use SOPPayment.CardName={0}", SopPayment.CardName))
						Me.HandleException(ex)
					Catch ex As Exception
						Throw ex
					End Try

				Next

				With SOP
					.taSopUserDefined = taSopUserDefined
					.taSopHdrIvcInsert = taSopHdrIvcInsert
					.taSopLineIvcInsert_Items = taSopLineIvcInserts
					.taSopDistribution_Items = taSopDistributionInserts
					.taCreateSopPaymentInsertRecord_Items = taSopPaymentInserts
				End With
				If CommonLogic.eConnectCreate(Me._mMSGPConnectionString, SOP) = True Then
					Return SopOrder.SopNumber
				Else
					Return String.Empty
				End If


			Catch ex As Exception

				Me.HandleException(ex)
				Return String.Empty
			End Try

		End Function

		Private Sub HandleException(ByVal ex As Exception)
			Me._mExceptionMessages.Add(ex.Message)
			If ex.InnerException IsNot Nothing Then
				Me.HandleException(ex.InnerException)
			End If
		End Sub

		Public Function GetSopHeaderForTransaction(ByVal SopNumber As String, ByVal SopType As Short) As eConnect.Serialization.taSopHdrIvcInsert
			Dim uowUnitOfWork As UnitOfWork
			Dim sooSalesOrder As GPObjectLibrary.Module.Objects.SOP.SOPSalesOrderHeader
			Dim gpoGroupOperator As GroupOperator
			Dim taSopHeader As eConnect.Serialization.taSopHdrIvcInsert
			Dim udfUserDefinedFields As GPObjectLibrary.Module.Objects.SOP.SOPSalesOrderHeaderUserDefinedField
			uowUnitOfWork = New UnitOfWork
			uowUnitOfWork.ConnectionString = MSGPConnectionString

			gpoGroupOperator = New GroupOperator
			With gpoGroupOperator
				.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
				.Operands.Add(New BinaryOperator("Oid.SOPTYPE", SopType))
			End With

			taSopHeader = New eConnect.Serialization.taSopHdrIvcInsert
			With taSopHeader
				.SOPNUMBE = SopNumber
				.SOPTYPE = SopType
			End With

			sooSalesOrder = uowUnitOfWork.FindObject(Of GPObjectLibrary.Module.Objects.SOP.SOPSalesOrderHeader)(gpoGroupOperator)
			If sooSalesOrder IsNot Nothing Then
				taSopHeader = New eConnect.Serialization.taSopHdrIvcInsert
				With taSopHeader
					'TODO: Fetch the target SOP
					.ADDRESS1 = sooSalesOrder.ADDRESS1
					.ADDRESS2 = sooSalesOrder.ADDRESS2
					.ADDRESS3 = sooSalesOrder.ADDRESS3
					.BACHNUMB = sooSalesOrder.BACHNUMB
					.BACKDATE = sooSalesOrder.BACKDATE

					.CITY = sooSalesOrder.CITY

					.CNTCPRSN = sooSalesOrder.CNTCPRSN
					.COMMAMNT = sooSalesOrder.COMMAMNT
					.COMMNTID = sooSalesOrder.COMMNTID
					.COUNTRY = sooSalesOrder.COUNTRY
					.CSTPONBR = sooSalesOrder.CSTPONBR
					.CURNCYID = sooSalesOrder.CURNCYID
					.CUSTNAME = sooSalesOrder.CUSTNAME
					.CUSTNMBR = sooSalesOrder.CUSTNMBR
					.DISAVAMT = sooSalesOrder.DISAVAMT
					.DISAVAMTSpecified = .DISAVAMT > 0
					.DISCDATE = sooSalesOrder.DISCDATE
					.DISTKNAM = sooSalesOrder.DISTKNAM
					.DOCAMNT = sooSalesOrder.DOCAMNT
					.DOCDATE = sooSalesOrder.DOCDATE
					.DOCID = sooSalesOrder.DOCID
					.DSCDLRAM = sooSalesOrder.DSCDLRAM
					.DSCDLRAMSpecified = .DSCDLRAM > 0
					.DSCPCTAM = sooSalesOrder.DSCPCTAM
					.DSCPCTAMSpecified = sooSalesOrder.DSCPCTAM > 0
					.DUEDATE = sooSalesOrder.DUEDATE
					.DYSTINCR = sooSalesOrder.DYSTINCR
					.EXCHDATE = sooSalesOrder.EXCHDATE

					.FAXNUMBR = sooSalesOrder.FAXNUMBR
					.FREIGHT = sooSalesOrder.FRTAMNT
					.FREIGTBLE = sooSalesOrder.FRGTTXBL
					.FRTSCHID = sooSalesOrder.FRTSCHID
					.FRTTXAMT = sooSalesOrder.FRTTXAMT
					.GPSFOINTEGRATIONID = sooSalesOrder.GPSFOINTEGRATIONID
					.INTEGRATIONID = sooSalesOrder.INTEGRATIONID
					.INTEGRATIONSOURCE = sooSalesOrder.INTEGRATIONSOURCE
					.INVODATE = sooSalesOrder.INVODATE
					.LOCNCODE = sooSalesOrder.LOCNCODE
					.MISCAMNT = sooSalesOrder.MISCAMNT
					.MISCTBLE = sooSalesOrder.MISCTXBL
					.MRKDNAMT = sooSalesOrder.MRKDNAMT
					.MSCSCHID = sooSalesOrder.MSCSCHID
					.MSCTXAMT = sooSalesOrder.MSCTXAMT
					.MSTRNUMB = sooSalesOrder.MSTRNUMB
					.ORDRDATE = sooSalesOrder.ORDRDATE
					.ORIGNUMB = sooSalesOrder.ORIGNUMB
					.ORIGTYPE = sooSalesOrder.ORIGTYPE
					.PHNUMBR1 = sooSalesOrder.PHNUMBR1
					.PHNUMBR2 = sooSalesOrder.PHNUMBR2
					.PHNUMBR3 = sooSalesOrder.PHONE3
					.PRBTADCD = sooSalesOrder.PRBTADCD
					.PRCLEVEL = sooSalesOrder.PRCLEVEL
					.PRSTADCD = sooSalesOrder.PRSTADCD
					.PYMTRCVD = sooSalesOrder.PYMTRCVD
					.PYMTRMID = sooSalesOrder.PYMTRMID
					.QUOEXPDA = sooSalesOrder.QUOEXPDA
					.QUOTEDAT = sooSalesOrder.QUOTEDAT
					.RATETPID = sooSalesOrder.RATETPID
					.REFRENCE = sooSalesOrder.REFRENCE
					.REPTING = sooSalesOrder.REPTING
					.ReqShipDate = sooSalesOrder.ReqShipDate
					.RETUDATE = sooSalesOrder.RETUDATE
					.RTCLCMTD = sooSalesOrder.RTCLCMTD
					.SALSTERR = sooSalesOrder.SALSTERR
					.SHIPMTHD = sooSalesOrder.SHIPMTHD
					.ShipToName = sooSalesOrder.ShipToName
					.SLPRSNID = sooSalesOrder.SLPRSNID
					.SOPNUMBE = sooSalesOrder.Oid.SOPNUMBE
					.SOPTYPE = sooSalesOrder.Oid.SOPTYPE
					.STATE = sooSalesOrder.STATE
					.SUBTOTAL = sooSalesOrder.SUBTOTAL
					.TAXAMNT = sooSalesOrder.TAXAMNT
					.TAXEXMT1 = sooSalesOrder.TAXEXMT1
					.TAXEXMT2 = sooSalesOrder.TAXEXMT2
					.TAXSCHID = sooSalesOrder.TAXSCHID
					.TIME1 = sooSalesOrder.TIME1
					.TIMETREP = sooSalesOrder.TIMETREP
					.TRADEPCT = sooSalesOrder.TRDISPCT
					.TRADEPCTSpecified = .TRADEPCT > 0
					.TRDISAMT = sooSalesOrder.TRDISAMT
					.TRDISAMTSpecified = .TRDISAMT > 0
					.TRXFREQU = sooSalesOrder.TRXFREQU
					.TXRGNNUM = sooSalesOrder.TXRGNNUM
					.UPSZONE = sooSalesOrder.UPSZONE
					.USER2ENT = sooSalesOrder.USER2ENT

					udfUserDefinedFields = sooSalesOrder.GetUserDefinedFields()
					If udfUserDefinedFields IsNot Nothing Then
						.USRDEFND1 = udfUserDefinedFields.USERDEF1
						.USRDEFND2 = udfUserDefinedFields.USERDEF2
						.USRDEFND3 = udfUserDefinedFields.USRDEF03
						.USRDEFND4 = udfUserDefinedFields.USRDEF04
						.USRDEFND5 = udfUserDefinedFields.USRDEF05
						.CMMTTEXT = udfUserDefinedFields.CMMTTEXT
						.COMMENT_1 = udfUserDefinedFields.COMMENT_1
						.COMMENT_2 = udfUserDefinedFields.COMMENT_2
						.COMMENT_3 = udfUserDefinedFields.COMMENT_3
						.COMMENT_4 = udfUserDefinedFields.COMMENT_4
					End If
					.XCHGRATE = sooSalesOrder.XCHGRATE
					.ZIPCODE = sooSalesOrder.ZIPCODE
					.UpdateExisting = 1
				End With
			End If
			Return taSopHeader
		End Function

		''' <summary>
		''' Appends a new tracking number to the sales order.
		''' </summary>
		''' <param name="TrackingInfo"></param>
		''' <returns>Returns back a boolean of whether or not the call was successful.</returns>
		''' <remarks>Uses the GP Object Library to fetch information from GP and populate the header of the eConnect call.</remarks>
		Public Function CreateSOPTrackingInfo(ByVal TrackingInfo As SOPTrackingInfo) As Boolean
			Me._mExceptionMessages.Clear()
			Dim SOP As Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
			Dim taSopTrackingUpdate1 As eConnect.Serialization.taSopTrackingNum_ItemsTaSopTrackingNum
			Try
				Helper.ValidateMSGPRequiredFieldsComplete(TrackingInfo)
				'TODO: Fetch the target SOP

				SOP = New Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType

				With SOP
					.taSopHdrIvcInsert = GetSopHeaderForTransaction(TrackingInfo.SOPNumber, TrackingInfo.SOPType)
				End With

				'Sample Tracking Update
				taSopTrackingUpdate1 = New eConnect.Serialization.taSopTrackingNum_ItemsTaSopTrackingNum
				With taSopTrackingUpdate1
					.SOPNUMBE = SOP.taSopHdrIvcInsert.SOPNUMBE
					.SOPTYPE = SOP.taSopHdrIvcInsert.SOPTYPE

					.RequesterTrx = TrackingInfo.RequesterTransaction
					.Tracking_Number = TrackingInfo.TrackingNumber
					.USRDEFND1 = TrackingInfo.UserDefined1
					.USRDEFND2 = TrackingInfo.UserDefined2
					.USRDEFND3 = TrackingInfo.UserDefined3
					.USRDEFND4 = TrackingInfo.UserDefined4
					.USRDEFND5 = TrackingInfo.UserDefined5
				End With

				With SOP
					.taSopTrackingNum_Items = {taSopTrackingUpdate1}
				End With

				Return CommonLogic.eConnectCreate(MSGPConnectionString, SOP)
			Catch ex As Exception
				Me.HandleException(ex)
				Return False
			End Try
		End Function

		Public Function CreateSOPPayment(ByVal Payment As SOPPayment) As Boolean
			Me._mExceptionMessages.Clear()
			Dim SOP As Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
			Dim taSopPayment As eConnect.Serialization.taCreateSopPaymentInsertRecord_ItemsTaCreateSopPaymentInsertRecord
			Try
				Helper.ValidateMSGPRequiredFieldsComplete(Payment)
				'TODO: Fetch the target SOP

				SOP = New Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
				With SOP
					.taSopHdrIvcInsert = GetSopHeaderForTransaction(Payment.SopNumber, Payment.SopType)
					.taSopHdrIvcInsert.PYMTRCVD += Payment.DocumentAmount
				End With

				'Sample Tracking Update
				taSopPayment = New eConnect.Serialization.taCreateSopPaymentInsertRecord_ItemsTaCreateSopPaymentInsertRecord
				With taSopPayment
					.SOPNUMBE = SOP.taSopHdrIvcInsert.SOPNUMBE
					.SOPTYPE = SOP.taSopHdrIvcInsert.SOPTYPE
					.AUTHCODE = Payment.AuthorizationCode
					.CARDNAME = Payment.CardName
					.CUSTNMBR = SOP.taSopHdrIvcInsert.CUSTNMBR
					.CUSTNAME = SOP.taSopHdrIvcInsert.CUSTNAME
					.DOCAMNT = Payment.DocumentAmount
					.DOCDATE = Today
					.EXPNDATE = Payment.ExpirationDate
					.PYMTTYPE = Payment.PaymentType
					.RCTNCCRD = Payment.CardNumber
					If Not String.IsNullOrEmpty(Payment.DocNumber) Then
						.DOCNUMBR = Payment.DocNumber
					End If
				End With

				With SOP
					.taCreateSopPaymentInsertRecord_Items = {taSopPayment}
				End With

				Return CommonLogic.eConnectCreate(MSGPConnectionString, SOP)
			Catch ex As Exception
				Me.HandleException(ex)
				Return False
			End Try
		End Function

	End Class
End Namespace
