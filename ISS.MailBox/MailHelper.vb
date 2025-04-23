Imports Microsoft.Exchange.WebServices.Data
Imports Microsoft.Exchange.WebServices.Data.SearchFilter
Imports Microsoft.Identity.Client

Public Class MailHelper
    Public Shared Function GetUnreadEmails(ByVal MailboxConfiguration As MailboxConfiguration) As MailboxResponse
        Dim ewsService As New ExchangeService(MailboxConfiguration.ExchangeVersion)
        Dim firFindItem As FindItemsResults(Of Item)
        Dim mbrResponse As New MailboxResponse
        Dim rstRestriction As New IsEqualTo(EmailMessageSchema.IsRead, False)
        If MailboxConfiguration.Domain > String.Empty Then
            ewsService.Credentials = New Net.NetworkCredential(MailboxConfiguration.Username, MailboxConfiguration.Password, MailboxConfiguration.Domain)
        Else
            ewsService.Credentials = New Net.NetworkCredential(MailboxConfiguration.Username, MailboxConfiguration.Password)
        End If

        ewsService.AutodiscoverUrl(MailboxConfiguration.MailboxEmailAddress, New Microsoft.Exchange.WebServices.Autodiscover.AutodiscoverRedirectionUrlValidationCallback(AddressOf Validate_Url))
        firFindItem = ewsService.FindItems(
            WellKnownFolderName.Inbox,
            rstRestriction,
            New ItemView(10))
        If firFindItem.Items.Count > 0 Then
            FetchMessagesFromFind(firFindItem, mbrResponse)
        End If

        While firFindItem.MoreAvailable
            firFindItem = ewsService.FindItems(
                WellKnownFolderName.Inbox,
                rstRestriction,
                New ItemView(10, firFindItem.NextPageOffset.Value))
            FetchMessagesFromFind(firFindItem, mbrResponse)
        End While

        Return mbrResponse
    End Function

    Public Shared Function GetUnreadEmailsUsingOAuth(ByVal MailboxConfiguration As OAuthMailboxConfiguration) As MailboxResponse

        Dim cca = ConfidentialClientApplicationBuilder.Create(MailboxConfiguration.AppID).WithClientSecret(MailboxConfiguration.ClientSecret).WithTenantId(MailboxConfiguration.TenantID).Build()
        Dim ewsScopes = New String() {"https://outlook.office365.com/.default"}
        Dim authResult = cca.AcquireTokenForClient(ewsScopes).ExecuteAsync().Result

        Dim ewsService As New ExchangeService
        Dim firFindItem As FindItemsResults(Of Item)
        Dim mbrResponse As New MailboxResponse
        Dim rstRestriction As New IsEqualTo(EmailMessageSchema.IsRead, False)

        ewsService.Url = New Uri("https://outlook.office365.com/EWS/Exchange.asmx")
        ewsService.Credentials = New OAuthCredentials(authResult.AccessToken)

        ewsService.ImpersonatedUserId = New ImpersonatedUserId(ConnectingIdType.SmtpAddress, MailboxConfiguration.Mailbox)
        firFindItem = ewsService.FindItems(
            WellKnownFolderName.Inbox,
            rstRestriction,
            New ItemView(10))
        If firFindItem.Items.Count > 0 Then
            FetchMessagesFromFind(firFindItem, mbrResponse)
        End If

        While firFindItem.MoreAvailable
            firFindItem = ewsService.FindItems(
                WellKnownFolderName.Inbox,
                rstRestriction,
                New ItemView(10, firFindItem.NextPageOffset.Value))
            FetchMessagesFromFind(firFindItem, mbrResponse)
        End While

        Return mbrResponse
    End Function

    Private Shared Function Validate_Url(redirectionUrl As String) As Boolean
        Return True
    End Function

    Public Shared Sub FetchMessagesFromFind(ByRef Find As FindItemsResults(Of Item), ByRef Response As MailboxResponse)
        Dim mmsMessage As MailMessage
        Dim emmMessage As EmailMessage
        Dim flaAttachment As FileAttachment
        Dim iosStream As IO.MemoryStream
        Dim madAddress As MailMessageAddress
        Dim msaAttachment As MailMessageAttachment
        For Each ewiItem In Find
            emmMessage = TryCast(ewiItem, EmailMessage)
            If emmMessage IsNot Nothing Then
                mmsMessage = New MailMessage

                'todo: read attachment
                With mmsMessage
                    emmMessage.Load()
                    .ItemID = emmMessage.Id.UniqueId
                    .Body = emmMessage.Body
                    .ReceivedDate = emmMessage.DateTimeReceived
                    .Subject = emmMessage.Subject
                    For Each ewaAttachment As Attachment In emmMessage.Attachments
                        flaAttachment = TryCast(ewaAttachment, FileAttachment)
                        If flaAttachment IsNot Nothing Then
                            iosStream = New IO.MemoryStream

                            flaAttachment.Load(iosStream)
                            msaAttachment = New MailMessageAttachment
                            With msaAttachment
                                .FileContents = iosStream.ToArray()
                                .FileName = flaAttachment.Name
                                .AttachmentID = flaAttachment.ContentId
                            End With
                            mmsMessage.Attachments.Add(msaAttachment)
                        End If
                    Next
                    mmsMessage.FromAddress.EmailAddress = emmMessage.From.Address
                    mmsMessage.FromAddress.Name = emmMessage.From.Name
                    For Each tmrReceipient In emmMessage.ToRecipients
                        madAddress = New MailMessageAddress
                        With madAddress
                            .EmailAddress = tmrReceipient.Address
                            .Name = tmrReceipient.Name
                        End With
                        mmsMessage.ToAddresses.Add(madAddress)
                    Next
                    For Each tmrReceipient In emmMessage.CcRecipients
                        madAddress = New MailMessageAddress
                        With madAddress
                            .EmailAddress = tmrReceipient.Address
                            .Name = tmrReceipient.Name
                        End With
                        mmsMessage.CCAddresses.Add(madAddress)
                    Next
                    For Each tmrReceipient In emmMessage.BccRecipients
                        madAddress = New MailMessageAddress
                        With madAddress
                            .EmailAddress = tmrReceipient.Address
                            .Name = tmrReceipient.Name
                        End With
                        mmsMessage.BCCAddresses.Add(madAddress)
                    Next
                End With
                Response.EmailItems.Add(mmsMessage)
            End If

        Next
    End Sub

    Public Shared Sub MarkEmailAsReadOAuth(ByVal MailboxConfiguration As OAuthMailboxConfiguration, ByVal ItemID As String)
        Dim itiId As ItemId
        Dim tmpMsg As EmailMessage

        Dim cca = ConfidentialClientApplicationBuilder.Create(MailboxConfiguration.AppID).WithClientSecret(MailboxConfiguration.ClientSecret).WithTenantId(MailboxConfiguration.TenantID).Build()
        Dim ewsScopes = New String() {"https://outlook.office365.com/.default"}
        Dim authResult = cca.AcquireTokenForClient(ewsScopes).ExecuteAsync().Result

        Dim ewsService As New ExchangeService
        Dim mbrResponse As New MailboxResponse
        Dim rstRestriction As New IsEqualTo(EmailMessageSchema.IsRead, False)

        ewsService.Url = New Uri("https://outlook.office365.com/EWS/Exchange.asmx")
        ewsService.Credentials = New OAuthCredentials(authResult.AccessToken)

        ewsService.ImpersonatedUserId = New ImpersonatedUserId(ConnectingIdType.SmtpAddress, MailboxConfiguration.Mailbox)
        itiId = New ItemId(ItemID)
        tmpMsg = EmailMessage.Bind(ewsService, itiId)
        tmpMsg.IsRead = True
        tmpMsg.Update(ConflictResolutionMode.AutoResolve)
    End Sub
    Public Shared Sub MarkEmailAsRead(ByVal MailboxConfiguration As MailboxConfiguration, ByVal ItemID As String)
        Dim ewsService As New ExchangeService(MailboxConfiguration.ExchangeVersion)
        Dim itiId As ItemId
        Dim tmpMsg As EmailMessage
        If MailboxConfiguration.Domain > String.Empty Then
            ewsService.Credentials = New Net.NetworkCredential(MailboxConfiguration.Username, MailboxConfiguration.Password, MailboxConfiguration.Domain)
        Else
            ewsService.Credentials = New Net.NetworkCredential(MailboxConfiguration.Username, MailboxConfiguration.Password)
        End If
        ewsService.AutodiscoverUrl(MailboxConfiguration.MailboxEmailAddress, New Microsoft.Exchange.WebServices.Autodiscover.AutodiscoverRedirectionUrlValidationCallback(AddressOf Validate_Url))
        itiId = New ItemId(ItemID)
        tmpMsg = EmailMessage.Bind(ewsService, itiId)
        tmpMsg.IsRead = True
        tmpMsg.Update(ConflictResolutionMode.AutoResolve)
    End Sub
End Class
