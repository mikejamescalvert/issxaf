Imports DevExpress.Xpo
Public Class OAuthMailboxConfiguration

    Private _mAppID As String
    Property AppID As String
        Get
            Return _mAppID
        End Get
        Set(ByVal Value As String)
            _mAppID = Value
        End Set
    End Property
    Private _mTenantID As String
    Property TenantID As String
        Get
            Return _mTenantID
        End Get
        Set(ByVal Value As String)
            _mTenantID = Value
        End Set
    End Property
    Private _mClientSecret As String
    Property ClientSecret As String
        Get
            Return _mClientSecret
        End Get
        Set(ByVal Value As String)
            _mClientSecret = Value
        End Set
    End Property
    Private _mMailbox As String
    Property Mailbox As String
        Get
            Return _mMailbox
        End Get
        Set(ByVal Value As String)
            _mMailbox = Value
        End Set
    End Property
    


End Class
