Public Class MailMessageAddress
    ' Fields...
    Private _mName As String
    Public Property Name As String
        Get
            Return _mName
        End Get
        Set(ByVal Value As String)
            _mName = Value
        End Set
    End Property
    Private _mEmailAddress As String
    Public Property EmailAddress As String
        Get
            Return _mEmailAddress
        End Get
        Set(ByVal Value As String)
            _mEmailAddress = Value
        End Set
    End Property
    
End Class
