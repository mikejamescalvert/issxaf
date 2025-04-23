Imports DevExpress.Xpo
Imports ISS.ShippingMethods.UpsRest.Models

Public Class UPSAddressValidationOutput

    Public Enum RequestStatuses
        Success
        Failure
    End Enum

    Private _mResult As RequestStatuses
    Public Property Result() As RequestStatuses
        Get
            Return _mResult
        End Get
        Set(ByVal Value As RequestStatuses)
            _mResult = Value
        End Set
    End Property

    Private _mErrorMessage As String
    Public Property ErrorMessage() As String
        Get
            Return _mErrorMessage
        End Get
        Set(ByVal Value As String)
            _mErrorMessage = Value
        End Set
    End Property

    Private _mUPSRequest As String
    Public Property UPSRequest() As String
        Get
            Return _mUPSRequest
        End Get
        Set(ByVal Value As String)
            _mUPSRequest = Value
        End Set
    End Property
    Private _mResidential As Boolean = True
    Public Property Residential As Boolean
        Get
            Return _mResidential
        End Get
        Set(ByVal Value As Boolean)
            _mResidential = Value
        End Set
    End Property
    Public Property UPSResult As String



    Private _mSuggestedAddresses As New List(Of UPSAddress)
    Public ReadOnly Property SuggestedAddresses As List(Of UPSAddress)
        Get
            Return _mSuggestedAddresses
        End Get
    End Property

End Class
