Public Class DhlParcelConfiguration

    Public Sub New()
        BaseUrl = "https://api-gw.dhlparcel.nl"
    End Sub

    Private _mBaseUrl As String
    Property BaseUrl As String
        Get
            Return _mBaseUrl
        End Get
        Set(ByVal Value As String)
            _mBaseUrl = Value
        End Set
    End Property


    Private _mUserId As String
    Property UserId As String
        Get
            Return _mUserId
        End Get
        Set(ByVal Value As String)
            _mUserId = Value
        End Set
    End Property

    Private _mApiKey As String
    Property ApiKey As String
        Get
            Return _mApiKey
        End Get
        Set(ByVal Value As String)
            _mApiKey = Value
        End Set
    End Property

End Class
