Imports ISS.Base.Interfaces
Imports ISS.Base.Helpers
Imports DevExpress.ExpressApp.DC
Imports System.Net.Mail
Imports DevExpress.ExpressApp
Imports DevExpress.Xpo
Imports ISS.Attachments

Namespace Helpers
    Public Class EmailHelper

        Public Enum EmailImplementationType
            Implementor = 0
            Attribute = 1
            None = 2
        End Enum

        Public Shared Function GetEmailImplementationType(ByVal MemberInfo As IMemberInfo) As EmailImplementationType
            If MemberInfo Is Nothing OrElse MemberInfo.LastMember Is Nothing Then
                Return EmailImplementationType.None
            End If

            If MemberInfo.LastMember.FindAttribute(Of ISS.Base.Attributes.EmailAddressAttribute)() IsNot Nothing Then
                If MemberInfo.LastMember.Owner.Implements(Of IEmail)() Then
                    Return EmailImplementationType.Attribute
                End If
            Else
                If MemberInfo.LastMember.MemberTypeInfo.Implements(Of IEmail)() Then
                    Return EmailImplementationType.Implementor
                End If
            End If

            Return EmailImplementationType.None

        End Function

        Private Shared Sub OpenEmailWindow(ByVal Email As ISSBaseEmailMessage)
            Using prcProcess As New Process()
                Dim strMailTo As String = ""
                Dim strBCCAddress As String = ""
                Dim strCCAddress As String = ""
                Dim strTemp As String
                If Email Is Nothing Then
                    Throw New Exception("Error: No Email Prepared")
                End If
                For Each strTemp In Email.ToAddresses
                    If strMailTo > String.Empty Then
                        strMailTo &= ","
                    End If
                    strMailTo = strMailTo + strTemp
                Next
                For Each strTemp In Email.CCAddresses
                    If strCCAddress > String.Empty Then
                        strCCAddress &= ","
                    End If
                    strCCAddress = strCCAddress + strTemp
                Next
                For Each strTemp In Email.BCCAddresses
                    If strBCCAddress > String.Empty Then
                        strBCCAddress &= ","
                    End If
                    strBCCAddress = strBCCAddress + strTemp
                Next

                'If strMailTo > String.Empty Then
                prcProcess.StartInfo.FileName = String.Format("mailto:{0}", strMailTo)

                'End If
                If Email.Subject > String.Empty Then
                    If prcProcess.StartInfo.FileName > String.Empty Then
                        prcProcess.StartInfo.FileName &= "&"
                    End If
                    prcProcess.StartInfo.FileName &= String.Format("subject={0}", Email.Subject)
                End If
                If strCCAddress > String.Empty Then
                    If prcProcess.StartInfo.FileName > String.Empty Then
                        prcProcess.StartInfo.FileName &= "&"
                    End If
                    prcProcess.StartInfo.FileName &= String.Format("cc={0}", strCCAddress)
                End If
                If strBCCAddress > String.Empty Then
                    If prcProcess.StartInfo.FileName > String.Empty Then
                        prcProcess.StartInfo.FileName &= "&"
                    End If
                    prcProcess.StartInfo.FileName &= String.Format("bcc={0}", strBCCAddress)
                End If
                If Email.Message > String.Empty Then
                    If prcProcess.StartInfo.FileName > String.Empty Then
                        prcProcess.StartInfo.FileName &= "&"
                    End If
                    prcProcess.StartInfo.FileName &= String.Format("body={0}", Email.Message)
                End If
                If prcProcess.StartInfo.FileName > String.Empty Then
                    prcProcess.Start()
                End If
            End Using
        End Sub

        Public Shared Sub ShowEmail(ByVal MemberInfo As IMemberInfo, ByVal CurrentObject As Object)
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
                OpenEmailWindow(eioEmailInterface.GetEmail(CurrentObject, MemberInfo))
            End If
        End Sub

        ''' <summary>
        ''' Sends a standard email through the System.Net.Mail system.  Mail settings should be set in the app config.
        ''' </summary>
        ''' <param name="EmailMessage"></param>
        ''' <param name="IsHTML"></param>
        ''' <remarks></remarks>
        Public Shared Sub SendStandardEmail(ByVal EmailMessage As ISSBaseEmailMessage, ByVal IsHTML As Boolean)
            Dim smcSmtpClient As SmtpClient
            Try
                smcSmtpClient = New SmtpClient
                Using mmgMailMessage As New MailMessage() With {.Body = EmailMessage.Message, .Subject = EmailMessage.Subject, .IsBodyHtml = IsHTML}
                    For Each oString As String In EmailMessage.BCCAddresses
                        mmgMailMessage.Bcc.Add(oString)
                    Next
                    For Each oString As String In EmailMessage.CCAddresses
                        mmgMailMessage.CC.Add(oString)
                    Next
                    For Each oString As String In EmailMessage.ToAddresses
                        mmgMailMessage.To.Add(oString)
                    Next
                    smcSmtpClient.Send(mmgMailMessage)
                End Using
            Catch ex As Exception
                Throw New UserFriendlyException(ex)
            End Try
        End Sub

    End Class

End Namespace

