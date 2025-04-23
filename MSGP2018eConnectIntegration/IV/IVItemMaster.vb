
Namespace IV

    'TODO: HWR 03/17/2012 - Complete this and copy to GP2010 assembly
    ''' <summary>
    ''' Required Fields are indicated.
    ''' All others will default from setup or policy
    ''' REQUIRED - 
    ''' ItemNumber
    ''' </summary>
    ''' <remarks> 
    ''' </remarks>
    Public Class IVItemMaster
        Public Enum ItemTypes
            SalesInventory = 1
            Discontinued = 2
            Kit = 3
            MiscellaneousCharges = 4
            Services = 5
            FlatFee = 6
        End Enum
        Public Enum ItemTrackingTypes
            None = 1
            SerialNumbers = 2
            LotNumbers = 3

        End Enum

        Public Enum TaxableTypes
            Taxable = 1
            NonTaxable = 2
            BasedOnCustomers = 3

        End Enum

#Region "Properties"

        Private _mItemNumber As String
        ''' <summary>
        ''' REQUIRED
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <MSGPRequiredField()>
        Public Property ItemNumber As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal Value As String)
                _mItemNumber = Value
            End Set
        End Property
        Private _mItemDescription As String
        Public Property ItemDescription As String
            Get
                Return _mItemDescription
            End Get
            Set(ByVal Value As String)
                _mItemDescription = Value
            End Set
        End Property
        Private _mItemShortName As String
        Public Property ItemShortName As String
            Get
                Return _mItemShortName
            End Get
            Set(ByVal Value As String)
                _mItemShortName = Value
            End Set
        End Property
        Private _mItemGenericDescription As String
        Public Property ItemGenericDescription As String
            Get
                Return _mItemGenericDescription
            End Get
            Set(ByVal Value As String)
                _mItemGenericDescription = Value
            End Set
        End Property

        Private _mItemClassCode As String
        Public Property ItemClassCode As String
            Get
                Return _mItemClassCode
            End Get
            Set(ByVal Value As String)
                _mItemClassCode = Value
            End Set
        End Property
        Private _mItemType As ItemTypes
        Public Property ItemType As ItemTypes
            Get
                Return _mItemType
            End Get
            Set(ByVal Value As ItemTypes)
                _mItemType = Value
            End Set
        End Property

        Private _mItemTracking As ItemTrackingTypes
        Public Property ItemTracking As ItemTrackingTypes
            Get
                Return _mItemTracking
            End Get
            Set(ByVal Value As ItemTrackingTypes)
                _mItemTracking = Value
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
        
        Private _mTaxable As TaxableTypes

        Public Property Taxable As TaxableTypes
            Get
                Return _mTaxable
            End Get
            Set(ByVal Value As TaxableTypes)
                _mTaxable = Value
            End Set
        End Property
        Private _mUnitOfMeasureScheduleId As String
        Public Property UnitOfMeasureScheduleId As String
            Get
                Return _mUnitOfMeasureScheduleId
            End Get
            Set(ByVal Value As String)
                _mUnitOfMeasureScheduleId = Value
            End Set
        End Property
        Private _mShippingWeight As Double?
        Public Property ShippingWeight As Double?
            Get
                Return _mShippingWeight
            End Get
            Set(ByVal Value As Double?)
                _mShippingWeight = Value
            End Set
        End Property
        Private _mListPrice As Decimal?
        Public Property ListPrice As Decimal?
            Get
                Return _mListPrice
            End Get
            Set(ByVal Value As Decimal?)
                _mListPrice = Value
            End Set
        End Property
        Private _mNoteText As String
        Public Property NoteText As String
            Get
                Return _mNoteText
            End Get
            Set(ByVal Value As String)
                _mNoteText = Value
            End Set
        End Property
        Private _mAltItem1 As String
        Public Property AltItem1 As String
            Get
                Return _mAltItem1
            End Get
            Set(ByVal Value As String)
                _mAltItem1 = Value
            End Set
        End Property
        Private _mAltItem2 As String
        Public Property AltItem2 As String
            Get
                Return _mAltItem2
            End Get
            Set(ByVal Value As String)
                _mAltItem2 = Value
            End Set
        End Property




#End Region



#Region "Behaviors"
        Public Sub New()
            Me.ItemType = ItemTypes.SalesInventory
            Me.ItemTracking = ItemTrackingTypes.None
            Me.Taxable = TaxableTypes.Taxable

        End Sub
        ''' <summary>
        ''' Validates the items returning as string message of any exception
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Validate() As String
            Try
                Helper.ValidateMSGPRequiredFieldsComplete(Me)
                Return Nothing
            Catch ex As Exception
                Return ex.Message
            End Try

        End Function

#End Region

    End Class
End Namespace
