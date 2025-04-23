Namespace Interfaces
    Public Interface IEmail
        Function GetEmail(ByVal CurrentObject As Object, ByVal MemberInfo As DevExpress.ExpressApp.DC.IMemberInfo) As ISSBaseEmailMessage
        Function GetEmailAddress() As String
        Function ShowEmailButton() As Boolean

    End Interface

End Namespace
