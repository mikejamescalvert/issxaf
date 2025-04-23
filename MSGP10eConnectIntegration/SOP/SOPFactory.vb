Imports Microsoft.Dynamics.GP

Namespace SOP

    Public Class SOPFactory
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

        Public Function GetNextSopNumber(ByVal DocType As SOPPayment.SOPDocTypes, ByVal DocIdKey As String) As String
            Dim sop As New eConnect.MiscRoutines.GetSopNumber
            With sop
                Return .GetNextSopNumber(DocType, DocIdKey, MSGPConnectionString)
            End With
        End Function

        Public Function CreateSopDocument(ByRef SopOrder As SOPOrder) As String
            Me._mExceptionMessages.Clear()

            Try
                'set SOP doc number
                If SopOrder.SopNumber = String.Empty Then
                    SopOrder.SopNumber = CommonLogic.GetDocNumber(MSGPConnectionString, CommonLogic.DocNumberTypes.SOPDocument, SopOrder.SopType, SopOrder.DocumentID)
                End If
                SopOrder.DocumentDate = SopOrder.DocumentDate.Subtract(SopOrder.DocumentDate.TimeOfDay)

                Helper.ValidateMSGPRequiredFieldsComplete(SopOrder)

                Dim SOP As New Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType
                Dim taSopHdrIvcInsert As New eConnect.Serialization.taSopHdrIvcInsert
                Dim taSopLineIvcInserts() As eConnect.Serialization.taSopLineIvcInsert_ItemsTaSopLineIvcInsert
                Dim taSopPaymentInserts() As eConnect.Serialization.taCreateSopPaymentInsertRecord_ItemsTaCreateSopPaymentInsertRecord
                Dim SopPayment As SOP.SOPPayment
                Dim SopLine As SOP.SOPOrderLine
                With taSopHdrIvcInsert
                    .SLPRSNID = SopOrder.SalesPersonKey
                    .ADDRESS1 = SopOrder.Address1
                    .ADDRESS2 = SopOrder.Address2
                    .ADDRESS3 = SopOrder.Address3
                    .BACHNUMB = SopOrder.BatchNumber
                    .CITY = SopOrder.City
                    .CNTCPRSN = SopOrder.ContactName
                    .COUNTRY = SopOrder.Country
                    .CUSTNAME = SopOrder.CustomerName
                    .CUSTNMBR = SopOrder.CustomerNumber
                    .DOCDATE = SopOrder.DocumentDate
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
                    .USRDEFND1 = SopOrder.FacilityID
                    .STATE = SopOrder.State
                    .TAXSCHID = SopOrder.TaxScheduleID
                    .TAXAMNT = SopOrder.TaxAmount
                    .ZIPCODE = SopOrder.Zip
                    .DEFPRICING = 1
                    .COMMENT_1 = SopOrder.Comment1
                    .COMMENT_2 = SopOrder.Comment2
                    .COMMENT_3 = SopOrder.Comment3
                    .CMMTTEXT = SopOrder.CommentText
                    .UPSZONE = SopOrder.UPSZone
                    .PYMTRMID = SopOrder.PaymentTermsID
                    .SALSTERR = SopOrder.SalesTerritory
                    .USRDEFND1 = SopOrder.UserDefined1
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
                        .DOCDATE = Today
                        .UOFM = SopLine.UnitOfMeasure
                        .ITEMNMBR = SopLine.ItemNumber
                        .COMMENT_1 = SopLine.Comments
                        .QUANTITY = SopLine.Quantity
						.UNITPRCE = SopLine.UnitPrice
                        .ReqShipDate = Today.ToShortDateString
                        .SHIPMTHD = SopLine.ShippingMethodKey
						.DEFEXTPRICE = 1
						If SopLine.PriceLevel IsNot Nothing Then
							.PRCLEVEL = SopLine.PriceLevel
						End If
						.CURNCYID = "Z-US$"
						.LOCNCODE = SopOrder.LocationCode
                        If SopLine.ItemDescription > String.Empty Then
                            .ITEMDESC = SopLine.ItemDescription
                        End If
                        If SopOrder.SopType = SOPOrder.SopTypes.Return Then
                            .QTYRTRND = SopLine.Quantity
                        End If
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
                        End With

                    Catch ex As MSGPRequiredFieldValidationException
                        Me._mExceptionMessages.Add(String.Format("---SOPPayment object failed validation due to incomplete data: to get to the record, use SOPPayment.CardName={0}", SopPayment.CardName))
                        Me.HandleException(ex)
                    Catch ex As Exception
                        Throw ex
                    End Try

                Next

                With SOP
                    .taSopHdrIvcInsert = taSopHdrIvcInsert
                    .taSopLineIvcInsert_Items = taSopLineIvcInserts
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

    End Class
End Namespace
