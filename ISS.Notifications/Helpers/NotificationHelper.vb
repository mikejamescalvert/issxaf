Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Net.Mail
Imports System.Text
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp

Public Class NotificationHelper


    ''' <summary>
    ''' Processes the notification rules using the session fo the target object
    ''' </summary>
    ''' <param name="TargetObject"></param>
    ''' <remarks></remarks>
    Public Shared Sub ProcessSaveNotificationRules(TargetObject As XPBaseObject)
        Dim xpoUOW As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        Dim xpoGO As New GroupOperator
        Dim session As Session = TargetObject.Session
        With xpoGO.Operands
            .Add(New BinaryOperator("TargetObjectType", TargetObject.GetType))
            .Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.UponSave))
            .Add(New BinaryOperator("IsActive", True))
        End With
        Dim xclNR As New XPCollection(Of NotificationRule)(session, xpoGO)
        For Each xpoNR As NotificationRule In xclNR
            xpoNR.ProcessNotificationRule(TargetObject)
        Next
    End Sub
    Public Shared Sub LogNotificationException(ByVal SourceRule As NotificationRule, ByVal SerializedTargetKey As String, ByVal Exception As Exception, ByVal ProcessingUnitOfWork As UnitOfWork)
        'Dim xpoUOW As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        Dim xpoSN As NotificationException
        Dim stbBuilder As New StringBuilder
        Dim ineException As Exception = Exception.InnerException
        xpoSN = New NotificationException(ProcessingUnitOfWork)

        stbBuilder.AppendLine(Exception.Message)
        stbBuilder.AppendLine(Exception.StackTrace)

        While ineException IsNot Nothing
            stbBuilder.AppendLine(ineException.Message)
            stbBuilder.AppendLine(ineException.StackTrace)
            ineException = ineException.InnerException
        End While

        With xpoSN
            .ExceptionMessage = stbBuilder.ToString
            If SourceRule IsNot Nothing Then
                .SourceNotificationRule = ProcessingUnitOfWork.GetObjectByKey(Of NotificationRule)(SourceRule.Oid)
            End If
            .SerializedTargetObjectKey = SerializedTargetKey
        End With
        ProcessingUnitOfWork.CommitChanges()
    End Sub
    Public Shared Sub LogNotificationException(ByVal SourceRule As NotificationRule, ByVal SerializedTargetKey As String, ByVal Exception As Exception, ByVal ObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace)
        LogNotificationException(SourceRule, SerializedTargetKey, Exception, ObjectSpace.Session)
        ''Dim xpoUOW As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        'Dim xpoSN As NotificationException
        'Dim stbBuilder As New StringBuilder
        'Dim ineException As Exception = Exception.InnerException
        'xpoSN = New NotificationException(ObjectSpace.Session)

        'stbBuilder.AppendLine(Exception.Message)
        'stbBuilder.AppendLine(Exception.StackTrace)

        'While ineException IsNot Nothing
        '    stbBuilder.AppendLine(ineException.Message)
        '    stbBuilder.AppendLine(ineException.StackTrace)
        '    ineException = ineException.InnerException
        'End While

        'With xpoSN
        '    .ExceptionMessage = stbBuilder.ToString
        '    If SourceRule IsNot Nothing Then
        '        .SourceNotificationRule = ObjectSpace.GetObjectByKey(Of NotificationRule)(SourceRule.Oid)
        '    End If
        '    .SerializedTargetObjectKey = SerializedTargetKey
        'End With
        'ObjectSpace.CommitChanges()
    End Sub
    Public Shared Sub ProcessScheduledNotificationRules(ByVal ProcessingUnitOfWork As UnitOfWork)
        'Dim UOW As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        'Try

        Dim xpoGO As New GroupOperator
        With xpoGO.Operands
            .Add(New BinaryOperator("IsActive", True))
            .Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.Scheduled))
        End With
        Dim xclNR As New XPCollection(Of NotificationRule)(ProcessingUnitOfWork, xpoGO)
        For Each xpoNR As NotificationRule In xclNR
            xpoNR.ProcessNotificationRule()
        Next
        ProcessingUnitOfWork.CommitChanges()
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    ObjectSpace.CommitChanges()
        'End Try
    End Sub
    Public Shared Sub ProcessScheduledNotificationRules(ByVal ObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace)
        ProcessScheduledNotificationRules(ObjectSpace.Session)
        'Dim UOW

    End Sub

    Public Shared Sub ProcessTimeElapseNotificationRules(ByVal ProcessingUnitOfWork As UnitOfWork)
        'Dim UOW As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        Dim xpoGO As New GroupOperator
        With xpoGO.Operands
            .Add(New BinaryOperator("IsActive", True))
            .Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.ElapsedTime))
        End With
        Dim xclNR As New XPCollection(Of NotificationRule)(ProcessingUnitOfWork, xpoGO)
        For Each xpoNR As NotificationRule In xclNR
            xpoNR.ProcessNotificationRule()
            ProcessingUnitOfWork.CommitChanges()
        Next
    End Sub
    Public Shared Sub ProcessTimeElapseNotificationRules(ByVal ObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace)
        ProcessTimeElapseNotificationRules(ObjectSpace.Session)
        ''Dim UOW As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        'Dim xpoGO As New GroupOperator
        'With xpoGO.Operands
        '    .Add(New BinaryOperator("IsActive", True))
        '    .Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.ElapsedTime))
        'End With
        'Dim xclNR As New XPCollection(Of NotificationRule)(ObjectSpace.Session, xpoGO)
        'For Each xpoNR As NotificationRule In xclNR
        '    xpoNR.ProcessNotificationRule~()~
        '    ObjectSpace.CommitChanges()
        'Next

    End Sub
    Public Shared Sub DistributeNotifications(ByVal ProcessingUnitOfWork As UnitOfWork, Optional ByVal MaxAttemptCount As Integer = 10)
        Dim objMailClient As System.Net.Mail.SmtpClient = Nothing
        Dim xpoGO As New GroupOperator
        Dim gpoGroupOperator As New GroupOperator
        Dim xpoMailSettings As MailSettings = MailSettings.GetInstance(ProcessingUnitOfWork)

        gpoGroupOperator.Operands.Add(New BinaryOperator("Status", NotificationQueueItem.Statuses.New))
        gpoGroupOperator.Operands.Add(New BinaryOperator("AttemptCount", MaxAttemptCount, BinaryOperatorType.LessOrEqual))
        Dim xclNotificationsToProcess As New XPCursor(ProcessingUnitOfWork, GetType(NotificationQueueItem), gpoGroupOperator)
        For Each xpoNB As NotificationQueueItem In xclNotificationsToProcess
            Try
                If xpoMailSettings.ServerType = MailSettings.ServerTypes.Smtp Then

                    If objMailClient Is Nothing Then
                        objMailClient = New SmtpClient
                        With objMailClient
                            If xpoMailSettings.SmtpDomainName > String.Empty Then
                                .UseDefaultCredentials = False
                                .Credentials = New Net.NetworkCredential(xpoMailSettings.SmtpUserName, xpoMailSettings.SmtpPassword, xpoMailSettings.SmtpDomainName)
                            ElseIf xpoMailSettings.SmtpUserName > String.Empty Then
                                .UseDefaultCredentials = False
                                .Credentials = New Net.NetworkCredential(xpoMailSettings.SmtpUserName, xpoMailSettings.SmtpPassword)
                            End If

                            If xpoMailSettings.SmtpPort > 0 Then
                                .Port = xpoMailSettings.SmtpPort
                            End If
                            If xpoMailSettings.UseSSL = True Then
                                .EnableSsl = True
                            End If

                            .Host = xpoMailSettings.SmtpServer
                            .DeliveryMethod = SmtpDeliveryMethod.Network
                            If .Host = "smtp.office365.com" Then
                                ' Office 365 Hack
                                '.TargetName = "STARTTLS/smtp.office365.com"
                            End If

                        End With
                    End If

                    objMailClient.Send(xpoNB.GetMailItem())
                    xpoNB.Status = NotificationQueueItem.Statuses.Sent
                    ProcessingUnitOfWork.CommitChanges()
                End If
            Catch ex As Exception
                xpoNB.AttemptCount += 1
                LogNotificationException(xpoNB.RelatedNotificationRule, xpoNB.SerializedObjectKey, ex, ProcessingUnitOfWork)
            Finally
                ProcessingUnitOfWork.CommitChanges()
            End Try
        Next

    End Sub
    Public Shared Sub DistributeNotifications(ByVal ObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace, Optional ByVal MaxAttemptCount As Integer = 10)
        DistributeNotifications(ObjectSpace.Session, MaxAttemptCount)

    End Sub

    Public Shared Sub DeleteNotificationsOlderThanDate(ByVal CurrentUnitOfWork As UnitOfWork, ByVal ReferenceDate As DateTime)
        Dim xpcObjects As New XPCursor(CurrentUnitOfWork, GetType(NotificationQueueItem), CriteriaOperator.Parse("CreatedDate < ?", ReferenceDate))

        xpcObjects.PageSize = 100
        'xpcObjects.TopReturnedObjects = 100

        Dim intCommitCount As Integer = 0


        For Each obj As NotificationQueueItem In xpcObjects
            For Each objChild In obj.AdditionalBCCNotificationRecipients
                objChild.Delete()
            Next
            For Each objChild In obj.AdditionalCCNotificationRecipients
                objChild.Delete()
            Next
            For Each objChild In obj.AdditionalToNotificationRecipients
                objChild.Delete()
            Next
            For Each objChild In obj.NotificationAttachments
                objChild.Delete()
            Next

            obj.Delete()
            intCommitCount += 1
            If intCommitCount > 100 Then
                CurrentUnitOfWork.CommitChanges()
                intCommitCount = 0
            End If
        Next

        CurrentUnitOfWork.CommitChanges()
    End Sub

    Public Shared Sub DeleteNotificationExceptionsOlderThanDate(ByVal CurrentUnitOfWork As UnitOfWork, ByVal ReferenceDate As DateTime)
        Dim xpcObjects As New XPCursor(CurrentUnitOfWork, GetType(NotificationException), CriteriaOperator.Parse("EntryDate < ?", ReferenceDate))

        xpcObjects.PageSize = 100
        'xpcObjects.TopReturnedObjects = 100

        Dim intCommitCount As Integer = 0


        For Each obj As NotificationException In xpcObjects

            obj.Delete()
            intCommitCount += 1
            If intCommitCount > 100 Then
                CurrentUnitOfWork.CommitChanges()
                intCommitCount = 0
            End If
        Next

        CurrentUnitOfWork.CommitChanges()

    End Sub

    Public Shared Function GetQueueItemsAssociatedToRecord(ByVal Record As Object, ByVal Session As Session) As XPCollection(Of NotificationQueueItem)
        If Record Is Nothing
            Return Nothing
        End If
        Dim gpoGroupOperator As GroupOperator
        Dim typType As ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.CastTypeToTypeInfo(Record.GetType)
        If typType Is Nothing
            Return Nothing
        End If
        If typType.KeyMember Is Nothing
            Return Nothing
        End If

        gpoGroupOperator = New GroupOperator

        With gpoGroupOperator
            .Operands.Add(New BinaryOperator("SerializedObjectKey", typType.KeyMember.SerializeValue(Record)))
            .Operands.Add(New BinaryOperator("RelatedNotificationRule.TargetObjectTypeName", typType.FullName))
        End With
        Return New XPCollection(Of NotificationQueueItem)(Session, gpoGroupOperator)
    End Function

    Public Shared Event NotificationQueueItemGenerated(ByVal QueueItem As NotificationQueueItem, ByVal SourceRule As NotificationRule, ByVal SourceObject As Object, ByVal SourceFilter As GroupOperator)
    Public Shared Sub OnNotificationQueueItemGenerated(ByVal QueueItem As NotificationQueueItem, ByVal SourceRule As NotificationRule, ByVal SourceObject As Object, ByVal SourceFilter As GroupOperator)
        RaiseEvent NotificationQueueItemGenerated(QueueItem, SourceRule, SourceObject, SourceFilter)
    End Sub

End Class
