Imports System.Collections.Specialized
Imports DevExpress.ExpressApp.DC
Imports ISS.Base.Helpers
Imports ISS.Base.Interfaces

Public Class WinEmailHelper
    Inherits EmailHelper
    ''' <summary>
    ''' Uses MAPI to show local email client with attachments.
    ''' </summary>
    ''' <param name="strSubject"></param>
    ''' <param name="strBody"></param>
    ''' <param name="stcRecipientsTo"></param>
    ''' <param name="stcRecipientsCC"></param>
    ''' <param name="stcRecipientsBCC"></param>
    ''' <param name="AttachmentPaths"></param>
    Public Overloads Shared Sub ShowEmail(strSubject As String, strBody As String, stcRecipientsTo As StringCollection, stcRecipientsCC As StringCollection, stcRecipientsBCC As StringCollection, Optional AttachmentPaths As StringCollection = Nothing)
        Dim iboEmail As ISSBaseEmailMessage = New ISSBaseEmailMessage()
        With iboEmail
            If Not String.IsNullOrEmpty(strSubject) Then
                .Subject = strSubject
            End If
            If Not String.IsNullOrEmpty(strBody) Then
                .Message = strBody
            End If
            For Each recipient In stcRecipientsTo
                If Not String.IsNullOrEmpty(recipient) Then
                    .ToAddresses.Add(recipient)
                End If
            Next
            For Each recipient In stcRecipientsCC
                If Not String.IsNullOrEmpty(recipient) Then
                    .CCAddresses.Add(recipient)
                End If
            Next
            For Each recipient In stcRecipientsBCC
                If Not String.IsNullOrEmpty(recipient) Then
                    .BCCAddresses.Add(recipient)
                End If
            Next
        End With
        OpenEmailWindow(iboEmail, AttachmentPaths)
    End Sub

    ''' <summary>
    ''' Uses MAPI to show local email client with attachments.
    ''' </summary>
    ''' <param name="MemberInfo"></param>
    ''' <param name="CurrentObject"></param>
    ''' <param name="AttachmentPaths"></param>
    Public Overloads Shared Sub ShowEmail(MemberInfo As IMemberInfo, CurrentObject As Object, Optional AttachmentPaths As StringCollection = Nothing)
        Dim objEmailType As EmailImplementationType = GetEmailImplementationType(MemberInfo)
        Dim eioEmailInterface As IEmail = Nothing
        If objEmailType = EmailImplementationType.Implementor Then
            eioEmailInterface = ReflectionHelper.GetObjectFromPropertyName(MemberInfo.Name, CurrentObject)
        Else
            If MemberInfo.Name.Contains(".") Then
                eioEmailInterface = ReflectionHelper.GetObjectFromPropertyName(ReflectionHelper.GetParentProperty(MemberInfo.Name), CurrentObject)
            Else
                eioEmailInterface = CurrentObject
            End If
        End If
        If eioEmailInterface IsNot Nothing Then
            OpenEmailWindow(eioEmailInterface.GetEmail(CurrentObject, MemberInfo), AttachmentPaths)
        End If
    End Sub

    Private Overloads Shared Sub OpenEmailWindow(Email As ISSBaseEmailMessage, Optional AttachmentPaths As StringCollection = Nothing)
        Dim mapi As New MAPI()
        For Each strTemp As String In Email.ToAddresses
            If Not String.IsNullOrEmpty(strTemp) Then
                mapi.AddRecipientTo(strTemp)
            End If
        Next strTemp
        For Each strTemp As String In Email.CCAddresses
            If Not String.IsNullOrEmpty(strTemp) Then
                mapi.AddRecipientCC(strTemp)
            End If
        Next strTemp
        For Each strTemp As String In Email.BCCAddresses
            If Not String.IsNullOrEmpty(strTemp) Then
                mapi.AddRecipientBCC(strTemp)
            End If
        Next strTemp
        For Each strAttachmentPath As String In AttachmentPaths
            If Not String.IsNullOrEmpty(strAttachmentPath) Then
                mapi.AddAttachment(strAttachmentPath)
            End If
        Next strAttachmentPath
        mapi.SendMailPopup(Email.Subject, Email.Message)
    End Sub
End Class
