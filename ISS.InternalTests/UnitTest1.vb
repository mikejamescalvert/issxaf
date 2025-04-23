Imports System.Net
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestEmail()

        Dim snpClient As New System.Net.Mail.SmtpClient("mail.authsmtp.com", 587)
        snpClient.EnableSsl = True
        snpClient.Credentials = New NetworkCredential("ac40917", "xjpq6wuydr")
        Dim smmMailMessage As New System.Net.Mail.MailMessage("cs@lapolicegear.com", "mike.calvert@issusa.com")
        smmMailMessage.Subject = "test"
        smmMailMessage.Body = "123"
        snpClient.Send(smmMailMessage)

    End Sub

    <TestMethod()> Public Sub TestOAuthMailbox()

        'Dim mbcConfiguration As New ISS.MailBox.MailboxConfiguration
        'mbcConfiguration.Domain = String.Empty
        'mbcConfiguration.MailboxEmailAddress = "support@issusa.com"
        'mbcConfiguration.Password = "Yup97425"
        'mbcConfiguration.MailboxEmailAddress = "mike.calvert@issusa.com"
        'mbcConfiguration.Password = "aBafa7ak"
        'mbcConfiguration.MailboxEmailAddress = "supporttest1@issusa.com"
        'mbcConfiguration.Password = "wcfftpnkllsjpvtv"

        Dim mbcConfiguration As New ISS.MailBox.OAuthMailboxConfiguration
        With mbcConfiguration
            .AppID = "d19a9c35-0a06-4b8f-a989-4c8a7974cf1f"
            .ClientSecret = "X8V8Q~w5XCND~fIbAQS-gYE-iPhRFA_S4BDQqa2u"
            .TenantID = "f0ad1916-283a-4459-a209-a427a0bdf247"
            .Mailbox = "support@issusa.com"
        End With

        For Each meiEmailItem In ISS.MailBox.MailHelper.GetUnreadEmailsUsingOAuth(mbcConfiguration).EmailItems
            Stop
        Next
    End Sub

End Class