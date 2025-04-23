Public Class MailboxResponse
    ' Fields...
    Private _mEmailItems As New List(Of MailMessage)
    Public Property EmailItems As List(Of MailMessage)
        Get
            Return _mEmailItems
        End Get
        Set(ByVal Value As List(Of MailMessage))
            _mEmailItems = Value
        End Set
    End Property
    
End Class
