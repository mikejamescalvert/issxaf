
Imports DevExpress.Xpo

Namespace SOP
    Public Class SOPOrder
        Private _mSalesPersonKey As String
        Public Property SalesPersonKey() As String
            Get
                Return _mSalesPersonKey
            End Get
            Set(ByVal Value As String)
                _mSalesPersonKey = Value
            End Set
        End Property

       

        Private _mTaxScheduleID As String
        Public Property TaxScheduleID() As String
            Get
                Return _mTaxScheduleID
            End Get
            Set(ByVal Value As String)
                _mTaxScheduleID = Value
            End Set
        End Property


        Private _mShippingMethodKey As String
        Public Property ShippingMethodKey() As String
            Get
                Return _mShippingMethodKey
            End Get
            Set(ByVal value As String)
                If _mShippingMethodKey = Value Then
                    Return
                End If
                _mShippingMethodKey = Value
            End Set
        End Property

        Private _mTaxAmount As Decimal
        Public Property TaxAmount() As Decimal
            Get
                Return _mTaxAmount
            End Get
            Set(ByVal value As Decimal)
                If _mTaxAmount = Value Then
                    Return
                End If
                _mTaxAmount = Value
            End Set
        End Property

        Private _mLocationCode As String
        Public Property LocationCode() As String
            Get
                Return _mLocationCode
            End Get
            Set(ByVal value As String)
                If _mLocationCode = Value Then
                    Return
                End If
                _mLocationCode = Value
            End Set
        End Property

        Private _mDocumentDate As Date
        <MSGPRequiredField()> _
        Public Property DocumentDate() As Date
            Get
                Return _mDocumentDate
            End Get
            Set(ByVal value As Date)
                If _mDocumentDate = value Then
                    Return
                End If
                _mDocumentDate = value
            End Set
        End Property


        Private _mDueDate As Date?
        Public Property DueDate As Date?
            Get
                Return _mDueDate
            End Get
            Set(ByVal Value As Date?)
                If _mDueDate = Value Then
                    Return
                End If
                _mDueDate = Value
            End Set
        End Property
        

        Private _mFreightAmount As Decimal
        Public Property FreightAmount() As Decimal
            Get
                Return _mFreightAmount
            End Get
            Set(ByVal value As Decimal)
                If _mFreightAmount = Value Then
                    Return
                End If
                _mFreightAmount = Value
            End Set
        End Property

        Private _mPONumber As String
        Public Property PONumber() As String
            Get
                Return _mPONumber
            End Get
            Set(ByVal value As String)
                If _mPONumber = Value Then
                    Return
                End If
                _mPONumber = Value
            End Set
        End Property
        Private _mShipToAddressCode As String
        Public Property ShipToAddressCode As String
            Get
                Return _mShipToAddressCode
            End Get
            Set(ByVal Value As String)
                _mShipToAddressCode = Value
            End Set
        End Property
        Private _mBillToAddressCode As String
        Public Property BillToAddressCode As String
            Get
                Return _mBillToAddressCode
            End Get
            Set(ByVal Value As String)
                _mBillToAddressCode = Value
            End Set
        End Property
                
        Private _mCustomerNumber As String
        <MSGPRequiredField()> _
        Public Property CustomerNumber() As String
            Get
                Return _mCustomerNumber
            End Get
            Set(ByVal value As String)
                If _mCustomerNumber = value Then
                    Return
                End If
                _mCustomerNumber = value
            End Set
        End Property

        Private _mCustomerName As String
        Public Property CustomerName() As String
            Get
                Return _mCustomerName
            End Get
            Set(ByVal value As String)
                If _mCustomerName = Value Then
                    Return
                End If
                _mCustomerName = Value
            End Set
        End Property

        Private _mShipToName As String
        Public Property ShipToName() As String
            Get
                Return _mShipToName
            End Get
            Set(ByVal value As String)
                If _mShipToName = Value Then
                    Return
                End If
                _mShipToName = Value
            End Set
        End Property

        Private _mAddress1 As String
        Public Property Address1() As String
            Get
                Return _mAddress1
            End Get
            Set(ByVal value As String)
                If _mAddress1 = Value Then
                    Return
                End If
                _mAddress1 = Value
            End Set
        End Property

        Private _mAddress2 As String
        Public Property Address2() As String
            Get
                Return _mAddress2
            End Get
            Set(ByVal value As String)
                If _mAddress2 = Value Then
                    Return
                End If
                _mAddress2 = Value
            End Set
        End Property

        Private _mAddress3 As String
        Public Property Address3() As String
            Get
                Return _mAddress3
            End Get
            Set(ByVal value As String)
                If _mAddress3 = Value Then
                    Return
                End If
                _mAddress3 = Value
            End Set
        End Property

        Private _mContactName As String
        Public Property ContactName() As String
            Get
                Return _mContactName
            End Get
            Set(ByVal value As String)
                If _mContactName = Value Then
                    Return
                End If
                _mContactName = Value
            End Set
        End Property

        Private _mFaxNumber As String
        Public Property FaxNumber() As String
            Get
                Return _mFaxNumber
            End Get
            Set(ByVal value As String)
                If _mFaxNumber = Value Then
                    Return
                End If
                _mFaxNumber = Value
            End Set
        End Property

        Private _mCity As String
        Public Property City() As String
            Get
                Return _mCity
            End Get
            Set(ByVal value As String)
                If _mCity = Value Then
                    Return
                End If
                _mCity = Value
            End Set
        End Property

        Private _mState As String
        Public Property State() As String
            Get
                Return _mState
            End Get
            Set(ByVal value As String)
                If _mState = Value Then
                    Return
                End If
                _mState = Value
            End Set
        End Property

        Private _mZip As String
        Public Property Zip() As String
            Get
                Return _mZip
            End Get
            Set(ByVal value As String)
                If _mZip = Value Then
                    Return
                End If
                _mZip = Value
            End Set
        End Property

        Private _mCountry As String
        Public Property Country() As String
            Get
                Return _mCountry
            End Get
            Set(ByVal value As String)
                If _mCountry = Value Then
                    Return
                End If
                _mCountry = Value
            End Set
        End Property

        Private _mPhoneNumber As String
        Public Property PhoneNumber() As String
            Get
                Return _mPhoneNumber
            End Get
            Set(ByVal value As String)
                If _mPhoneNumber = Value Then
                    Return
                End If
                _mPhoneNumber = Value
            End Set
        End Property

        Private _mPaymentAmount As Decimal
        Public Property PaymentAmount() As Decimal
            Get
                Return _mPaymentAmount
            End Get
            Set(ByVal value As Decimal)
                If _mPaymentAmount = Value Then
                    Return
                End If
                _mPaymentAmount = Value
            End Set
        End Property

        Private _mBatchNumber As String
        <MSGPRequiredField()> _
        Public Property BatchNumber() As String
            Get
                Return _mBatchNumber
            End Get
            Set(ByVal value As String)
                If _mBatchNumber = value Then
                    Return
                End If
                _mBatchNumber = value
            End Set
        End Property

        Private _mGLReference As String
        Public Property GLReference As String
            Get
                Return _mGLReference
            End Get
            Set(ByVal Value As String)
                _mGLReference = Value
            End Set
        End Property
        
        Private _mSOPDistributions As New List(Of SOPDistribution)
        Public Property SOPDistributions As List(Of SOPDistribution)
            Get
                Return _mSOPDistributions
            End Get
            Set(ByVal Value As List(Of SOPDistribution))
                _mSOPDistributions = Value
            End Set
        End Property
        

        Private _mSOPOrderLines As New List(Of SOPOrderLine)
        Public Property SOPOrderLines() As List(Of SOPOrderLine)
            Get
                Return _mSOPOrderLines
            End Get
            Set(ByVal value As List(Of SOPOrderLine))
                If _mSOPOrderLines Is value Then
                    Return
                End If
                _mSOPOrderLines = value
            End Set
        End Property

        Private _mSOPPayments As New List(Of SOPPayment)
        Public Property SOPPayments As List(Of SOPPayment)
            Get
                Return _mSOPPayments
            End Get
            Set(ByVal Value As List(Of SOPPayment))
                If _mSOPPayments Is Value Then
                    Return
                End If
                _mSOPPayments = Value
            End Set
        End Property

        Private _mSopNumber As String
        <MSGPRequiredField()> _
        Public Property SopNumber() As String
            Get
                Return _mSopNumber
            End Get
            Set(ByVal value As String)
                If _mSopNumber = value Then
                    Return
                End If
                _mSopNumber = value
            End Set
        End Property

        Private _mDocumentID As String
        <MSGPRequiredField()> _
        Public Property DocumentID() As String
            Get
                Return _mDocumentID
            End Get
            Set(ByVal value As String)
                If _mDocumentID = value Then
                    Return
                End If
                _mDocumentID = value
            End Set
        End Property

        Private _mSopType As SopTypes
        <MSGPRequiredField()> _
        Public Property SopType() As SopTypes
            Get
                Return _mSopType
            End Get
            Set(ByVal value As SopTypes)
                If _mSopType = value Then
                    Return
                End If
                _mSopType = value
            End Set
        End Property

        Public Enum SopTypes
			Quote = 1
			Order = 2
			Invoice = 3
			[Return] = 4
        End Enum

        Private _mNoteText As String
        Public Property NoteText As String
            Get
                Return _mNoteText
            End Get
            Set(ByVal Value As String)
                _mNoteText = Value
            End Set
        End Property
        
        Private _comment1 As String
        Public Property Comment1() As String
            Get
                Return _comment1
            End Get
            Set(ByVal Value As String)
                _comment1 = Value
            End Set
        End Property

        Private _comment2 As String
        Public Property Comment2() As String
            Get
                Return _comment2
            End Get
            Set(ByVal Value As String)
                _comment2 = Value
            End Set
        End Property

        Private _comment3 As String
        Public Property Comment3() As String
            Get
                Return _comment3
            End Get
            Set(ByVal Value As String)
                _comment3 = Value
            End Set
        End Property

        Private _comment4 As String
        Public Property Comment4() As String
            Get
                Return _comment4
            End Get
            Set(ByVal Value As String)
                _comment4 = Value
            End Set
        End Property

        Private _commentText As String
        Public Property CommentText() As String
            Get
                Return _commentText
            End Get
            Set(ByVal Value As String)
                _commentText = Value
            End Set
        End Property

        Private _mUPSZone As String
        Public Property UPSZone As String
            Get
                Return _mUPSZone
            End Get
            Set(ByVal Value As String)
                _mUPSZone = Value
            End Set
        End Property

        Private _mPaymentTermsID As String
        Public Property PaymentTermsID As String
            Get
                Return _mPaymentTermsID
            End Get
            Set(ByVal Value As String)
                _mPaymentTermsID = Value
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

        Private _mUserDefined3 As String
        Public Property UserDefined3 As String
            Get
                Return _mUserDefined3
            End Get
            Set(ByVal Value As String)
                _mUserDefined3 = Value
            End Set
		End Property
		Private _mUserDefined4 As String
		Public Property UserDefined4 As String
			Get
				Return _mUserDefined4
			End Get
			Set(ByVal Value As String)
				_mUserDefined4 = Value
			End Set
		End Property
		Private _mUserDefined5 As String
		Public Property UserDefined5 As String
			Get
				Return _mUserDefined5
			End Get
			Set(ByVal Value As String)
				_mUserDefined5 = Value
			End Set
		End Property



		Private _mUserDefinedDevOnly1 As String
		Public Property UserDefinedDevOnly1 As String
			Get
				Return _mUserDefinedDevOnly1
			End Get
			Set(ByVal Value As String)
				_mUserDefinedDevOnly1 = Value
			End Set
		End Property

		Private _mUserDefinedDevOnly2 As String
		Public Property UserDefinedDevOnly2 As String
			Get
				Return _mUserDefinedDevOnly2
			End Get
			Set(ByVal Value As String)
				_mUserDefinedDevOnly2 = Value
			End Set
		End Property

		Private _mUserDefinedDevOnly3 As String
		Public Property UserDefinedDevOnly3 As String
			Get
				Return _mUserDefinedDevOnly3
			End Get
			Set(ByVal Value As String)
				_mUserDefinedDevOnly3 = Value
			End Set
		End Property
		Private _mUserDefinedDevOnly4 As String
		Public Property UserDefinedDevOnly4 As String
			Get
				Return _mUserDefinedDevOnly4
			End Get
			Set(ByVal Value As String)
				_mUserDefinedDevOnly4 = Value
			End Set
		End Property
		Private _mUserDefinedDevOnly5 As String
		Public Property UserDefinedDevOnly5 As String
			Get
				Return _mUserDefinedDevOnly5
			End Get
			Set(ByVal Value As String)
				_mUserDefinedDevOnly5 = Value
			End Set
		End Property
    End Class
End Namespace