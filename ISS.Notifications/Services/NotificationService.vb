Imports DevExpress.ExpressApp

Public Class NotificationService

    Private _mUponChangeCacheDuration As Decimal = 60

    'Private _mMemberInfoNotificationRuleDictionary As Dictionary(Of Reflection.MemberInfo, Oid)

    Public Sub New()

    End Sub

    Public Sub RefreshChangeCacheDictionary(ByVal ObjectSpace As IObjectSpace)
        'Throw New NotImplementedException
    End Sub
    Public Sub ProcessChangedObjectWithChangeNotificationRules(ByVal ObjectSpace As IObjectSpace, ByVal ChangedEvent As ObjectChangedEventArgs)
        RefreshChangeCacheDictionary(ObjectSpace)
        'Throw New NotImplementedException
    End Sub

End Class
