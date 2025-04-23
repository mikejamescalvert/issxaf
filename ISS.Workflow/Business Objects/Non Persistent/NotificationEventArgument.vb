Public Class NotificationEventArgument

#Region "Non Persistent Properties"

    Private _mIsHandled As Boolean
    Private _mNotificationStage As ISSBaseNotificationTemplate.NotificationStages
    Private _mNotificationTemplate As ISSBaseNotificationTemplate
    Public Property IsHandled() As Boolean
        Get
            Return _mIsHandled
        End Get
        Set(ByVal value As Boolean)
            If _mIsHandled = value Then
                Return
            End If
            _mIsHandled = value
        End Set
    End Property
    Public Property NotificationStage() As ISSBaseNotificationTemplate.NotificationStages
        Get
            Return _mNotificationStage
        End Get
        Set(ByVal value As ISSBaseNotificationTemplate.NotificationStages)
            If _mNotificationStage = value Then
                Return
            End If
            _mNotificationStage = value
        End Set
    End Property
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
