Imports DevExpress.Xpo
Public Class MailboxConfiguration
    Public Enum SupportedServerTypes
        Exchange
    End Enum

    ' Fields...
    Private _mServerType As SupportedServerTypes
    Public Property ServerType As SupportedServerTypes
        Get
            Return _mServerType
        End Get
        Set(ByVal Value As SupportedServerTypes)
            _mServerType = Value
        End Set
    End Property
    
    Private _mMailboxEmailAddress As String
    Public Property MailboxEmailAddress As String
        Get
            Return _mMailboxEmailAddress
        End Get
        Set(ByVal Value As String)
            _mMailboxEmailAddress = Value
        End Set
    End Property
    Private _mDomain As String
    Public Property Domain As String
        Get
            Return _mDomain
        End Get
        Set(ByVal Value As String)
            _mDomain = Value
        End Set
    End Property
    Private _mUsername As String
    Public Property Username As String
        Get
            Return _mUsername
        End Get
        Set(ByVal Value As String)
            _mUsername = Value
        End Set
    End Property
    Private _mPassword As String
    Public Property Password As String
        Get
            Return _mPassword
        End Get
        Set(ByVal Value As String)
            _mPassword = Value
        End Set
    End Property

    Private _mExchangeVersion As Microsoft.Exchange.WebServices.Data.ExchangeVersion = Microsoft.Exchange.WebServices.Data.ExchangeVersion.Exchange2013_SP1
    Public Property ExchangeVersion As Microsoft.Exchange.WebServices.Data.ExchangeVersion 
        Get
            Return _mExchangeVersion
        End Get
        Set(ByVal Value As Microsoft.Exchange.WebServices.Data.ExchangeVersion )
  _mExchangeVersion = Value
        End Set
    End Property



End Class
