Public Class VoidResponse
    Public Enum ResponseTypes
        Success
        [Error]
    End Enum
    ' Fields...
    Private _mResponseType As ResponseTypes
    Public Property ResponseType As ResponseTypes
        Get
            Return _mResponseType
        End Get
        Set(ByVal Value As ResponseTypes)
            _mResponseType = Value
        End Set
    End Property
    Private _mResponseMessage As String
    Public Property ResponseMessage As String
        Get
            Return _mResponseMessage
        End Get
        Set(ByVal Value As String)
            _mResponseMessage = Value
        End Set
    End Property
    Private _mRequest As VoidRequest
    Public Property Request As VoidRequest
        Get
            Return _mRequest
        End Get
        Set(ByVal Value As VoidRequest)
            _mRequest = Value
        End Set
    End Property
    
End Class
