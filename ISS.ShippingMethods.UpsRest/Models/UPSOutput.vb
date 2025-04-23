Namespace Models
    Public Class UPSOutput

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

        Private _mRates As New List(Of UPSShippingRate)
        Public Property Rates() As List(Of UPSShippingRate)
            Get
                Return _mRates
            End Get
            Set(ByVal Value As List(Of UPSShippingRate))
                _mRates = Value
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
        Private _mUPSResponse As String
        Property UPSResponse As String
            Get
                Return _mUPSResponse
            End Get
            Set(ByVal Value As String)
                _mUPSResponse = Value
            End Set
        End Property
        

    End Class
End Namespace