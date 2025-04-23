Public Class NotificationTemplateArgument

#Region "Non Persistent Properties"
    Private _mNotificationTemplate As ISSBaseNotificationTemplate
    Public Property NotificationTemplate() As ISSBaseNotificationTemplate
        Get
            Return _mNotificationTemplate
        End Get
        Set(ByVal value As ISSBaseNotificationTemplate)
            If _mNotificationTemplate Is value Then
                Return
            End If
            _mNotificationTemplate = value
        End Set
    End Property
#End Region

End Class
