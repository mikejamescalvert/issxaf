Public Class UPSTimeInTransitOutput

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

    Private _mTransitTimes As New List(Of UPSTimeInTransitEntry)
    Public Property TransitTimes() As List(of UPSTimeInTransitEntry)
        Get
            Return _mTransitTimes
        End Get
        Set(ByVal Value As List(of UPSTimeInTransitEntry))
            _mTransitTimes = Value
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


End Class
