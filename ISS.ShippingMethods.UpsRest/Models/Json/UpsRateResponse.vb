Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Models.Json



    Public Class ElementLevelInformation
        Public Property Level As String
        Public Property ElementIdentifier As CodeValue()
    End Class


    Public Class AlertDetail
        Public Property Code As String
        Public Property Description As String
        Public Property ElementLevelInformation As ElementLevelInformation
    End Class


    Public Class Response
        Public Property ResponseStatus As CodeDescription
        <JsonIgnore>
        Public Property Alert As List(Of CodeDescription)
        <JsonProperty(PropertyName:="Alert")>
        Public Property AlertRaw As JRaw
            Get
                Return New JRaw(JsonConvert.SerializeObject(Alert))
            End Get
            Set(value As JRaw)
                Dim raw = value.ToString(Formatting.None)
                If raw > String.Empty AndAlso raw.StartsWith("[") Then
                    Alert = JsonConvert.DeserializeObject(Of List(Of CodeDescription))(raw)
                Else
                    Alert = New List(Of CodeDescription)({JsonConvert.DeserializeObject(Of CodeDescription)(raw)})
                End If

            End Set
        End Property
        <JsonIgnore>
        Public Property AlertDetail As List(Of AlertDetail)
        <JsonProperty(PropertyName:="AlertDetail")>
        Public Property AlertDetailRaw As JRaw
            Get
                Return New JRaw(JsonConvert.SerializeObject(AlertDetail))
            End Get
            Set(value As JRaw)
                Dim raw = value.ToString(Formatting.None)
                If raw > String.Empty AndAlso raw.StartsWith("[") Then
                    AlertDetail = JsonConvert.DeserializeObject(Of List(Of AlertDetail))(raw)
                Else
                    AlertDetail = New List(Of AlertDetail)({JsonConvert.DeserializeObject(Of AlertDetail)(raw)})
                End If

            End Set
        End Property


        Public Property TransactionReference As TransactionReference
    End Class




    Public Class BillingWeight
        Public Property UnitOfMeasurement As UnitOfMeasurement
        Public Property Weight As String
    End Class




    Public Class ItemizedCharge
        Public Property Code As String
        Public Property Description As String
        Public Property CurrencyCode As String
        Public Property MonetaryValue As String
        Public Property SubType As String
    End Class


    Public Class FreightDensityRate
        Public Property Density As String
        Public Property TotalCubicFeet As String
    End Class





    Public Class AdjustedHeight
        Public Property Value As Object
        Public Property UnitOfMeasurement As Object
    End Class


    Public Class HandlingUnit
        Public Property Quantity As String
        Public Property Type As Type
        Public Property Dimensions As Dimensions
        Public Property AdjustedHeight As AdjustedHeight
    End Class


    Public Class FRSShipmentData
        Public Property TransportationCharges As MonetaryValue
        Public Property FreightDensityRate As FreightDensityRate
        Public Property HandlingUnits As HandlingUnit()
    End Class






    Public Class TaxCharge
        Public Property Type As String
        Public Property MonetaryValue As String
    End Class


    Public Class NegotiatedRateCharges
        Public Property ItemizedCharges As ItemizedCharge()
        Public Property TaxCharges As TaxCharge()
        Public Property TotalCharge As MonetaryValue
        Public Property TotalChargesWithTaxes As MonetaryValue
    End Class





    Public Class NegotiatedCharges
        Public Property ItemizedCharges As Object()
    End Class


    Public Class SimpleRate
        Public Property Code As String
    End Class


    Public Class RateModifier
        Public Property ModifierType As Object
        Public Property ModifierDesc As Object
        Public Property Amount As Object
    End Class


    Public Class RatedPackage
        Public Property BaseServiceCharge As MonetaryValue
        Public Property TransportationCharges As MonetaryValue
        Public Property ServiceOptionsCharges As MonetaryValue
        Public Property TotalCharges As MonetaryValue
        Public Property Weight As String
        Public Property BillingWeight As BillingWeight
        <JsonIgnore>
        Public Property Accessorial As List(Of CodeDescription)
        <JsonProperty(PropertyName:="Accessorial")>
        Public Property AccessorialRaw As JRaw
            Get
                Return New JRaw(JsonConvert.SerializeObject(Accessorial))
            End Get
            Set(value As JRaw)
                Dim raw = value.ToString(Formatting.None)
                If raw > String.Empty AndAlso raw.StartsWith("[") Then
                    Accessorial = JsonConvert.DeserializeObject(Of List(Of CodeDescription))(raw)
                Else
                    Accessorial = New List(Of CodeDescription)({JsonConvert.DeserializeObject(Of CodeDescription)(raw)})
                End If

            End Set
        End Property


        Public Property ItemizedCharges As ItemizedCharge()
        Public Property NegotiatedCharges As NegotiatedCharges
        Public Property SimpleRate As SimpleRate
        Public Property RateModifier As RateModifier()
    End Class


    Public Class Arrival
        Public Property [Date] As String
        Public Property Time As Object
    End Class


    Public Class Pickup
        Public Property [Date] As String
        Public Property Time As Object
    End Class


    Public Class EstimatedArrival
        Public Property Arrival As Arrival
        Public Property BusinessDaysInTransit As String
        Public Property Pickup As Pickup
        Public Property DayOfWeek As String
        Public Property CustomerCenterCutoff As String
        Public Property DelayCount As String
        Public Property HolidayCount As String
        Public Property RestDays As String
        Public Property TotalTransitDays As String
    End Class


    Public Class ServiceSummary
        Public Property Service As ShipmentService
        Public Property GuaranteedIndicator As String
        Public Property Disclaimer As String
        Public Property EstimatedArrival As EstimatedArrival
        Public Property SaturdayDelivery As String
        Public Property SaturdayDeliveryDisclaimer As String
        Public Property SundayDelivery As String
        Public Property SundayDeliveryDisclaimer As String
    End Class


    Public Class TimeInTransit
        Public Property PickupDate As String
        Public Property DocumentsOnlyIndicator As String
        Public Property PackageBillType As String
        Public Property ServiceSummary As ServiceSummary
        Public Property AutoDutyCode As String
        Public Property Disclaimer As String

    End Class


    Public Class RatedShipment
        Public Property Service As ShipmentService
        Public Property RateChart As String
        Public Property BillableWeightCalculationMethod As String
        Public Property RatingMethod As String
        Public Property BillingWeight As BillingWeight
        Public Property TransportationCharges As MonetaryValue
        Public Property BaseServiceCharge As MonetaryValue
        Public Property ItemizedCharges As ItemizedCharge()
        Public Property FRSShipmentData As FRSShipmentData
        Public Property ServiceOptionsCharges As MonetaryValue
        Public Property TotalCharges As MonetaryValue
        Public Property TotalChargesWithTaxes As MonetaryValue
        Public Property NegotiatedRateCharges As NegotiatedRateCharges
        Public Property TimeInTransit As TimeInTransit
        Public Property ScheduledDeliveryDate As String
        Public Property RoarRatedIndicator As String

    End Class


    Public Class RateResponse
        Public Property Response As Response
        Public Property RatedShipment As RatedShipment()
    End Class
    Public Class UpsRateResponse
        Public Property RateResponse As RateResponse
    End Class


End Namespace