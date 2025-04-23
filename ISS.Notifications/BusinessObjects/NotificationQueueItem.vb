Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
'<DefaultClassOptions()> _
Public Class NotificationQueueItem ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits NotificationModuleBaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub

    Public Enum Statuses
        [New] = 0
        [Sent] = 1
        [Error] = 2
    End Enum

    Private _mStatus As Statuses
    Public Property Status As Statuses
        Get
            Return _mStatus
        End Get
        Set(ByVal Value As Statuses)
            SetPropertyValue("Status", _mStatus, Value)
        End Set
    End Property
    
    

    ' Fields...
    Private _mFromAddress As String
    <Size(255)>
    Public Property FromAddress As String
        Get
            Return _mFromAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("FromAddress", _mFromAddress, Value)
        End Set
    End Property
    Private _mFromName As String
    <Size(255)>
    Public Property FromName As String
        Get
            Return _mFromName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("FromName", _mFromName, Value)
        End Set
    End Property
    Private _mPrimaryToAddress As String
    <Size(255)>
    Public Property PrimaryToAddress As String
        Get
            Return _mPrimaryToAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("PrimaryToAddress", _mPrimaryToAddress, Value)
        End Set
    End Property
    Private _mPrimaryToName As String
    <Size(255)>
    Public Property PrimaryToName As String
        Get
            Return _mPrimaryToName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("PrimaryToName", _mPrimaryToName, Value)
        End Set
    End Property
    Private _mSubject As String
    <Size(255)>
    Public Property Subject As String
        Get
            Return _mSubject
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Subject", _mSubject, Value)
        End Set
    End Property
    Private _mBody As String
    <Size(-1)>
    Public Property Body As String
        Get
            Return _mBody
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Body", _mBody, Value)
        End Set
    End Property

    <Aggregated()>
    <Association("NotificationQueueItem-NotificationAttachments")>
    Public ReadOnly Property NotificationAttachments As XPCollection(Of NotificationAttachment)
        Get
            Return GetCollection(Of NotificationAttachment)("NotificationAttachments")
        End Get
    End Property
    <Association("NotificationQueueItem-AdditionalToNotificationRecipients")>
    <Aggregated()>
    Public ReadOnly Property AdditionalToNotificationRecipients As XPCollection(Of AdditionalNotificationRecipient)
        Get
            Return GetCollection(Of AdditionalNotificationRecipient)("AdditionalToNotificationRecipients")
        End Get
    End Property
    <Association("NotificationQueueItem-AdditionalCCNotificationRecipients")>
    <Aggregated()>
    Public ReadOnly Property AdditionalCCNotificationRecipients As XPCollection(Of AdditionalNotificationRecipient)
        Get
            Return GetCollection(Of AdditionalNotificationRecipient)("AdditionalCCNotificationRecipients")
        End Get
    End Property
        <Association("NotificationQueueItem-AdditionalBCCNotificationRecipients")>
    <Aggregated()>
    Public ReadOnly Property AdditionalBCCNotificationRecipients As XPCollection(Of AdditionalNotificationRecipient)
        Get
            Return GetCollection(Of AdditionalNotificationRecipient)("AdditionalBCCNotificationRecipients")
        End Get
    End Property
    Public Function GetMailItem As System.Net.Mail.MailMessage
        Dim smmMailMessage As New System.Net.Mail.MailMessage
		With smmMailMessage
			For Each xpoAttachment In NotificationAttachments
				.Attachments.Add(New System.Net.Mail.Attachment(New IO.MemoryStream(xpoAttachment.GetContent), xpoAttachment.Name))
			Next
			.IsBodyHtml = True
			.From = New Net.Mail.MailAddress(FromAddress, FromName)
            
                If PrimaryToName > String.Empty
                    .To.Add(New Net.Mail.MailAddress(PrimaryToAddress, PrimaryToName))
                Else
                    For each strItem In PrimaryToAddress.Split(",")
                        .To.Add(New Net.Mail.MailAddress(strItem))
                    Next
                    
                End If
			
			.Subject = Subject
			.Body = Body


			For Each xpoTo In AdditionalToNotificationRecipients
                If xpoTo.ToAddress = String.Empty
                    Continue For
                End If
                If xpoTo.ToName> String.Empty
                    .To.Add(New Net.Mail.MailAddress(xpoTo.ToAddress, xpoTo.ToName))
                    Else
                    .To.Add(New Net.Mail.MailAddress(xpoTo.ToAddress))
                End If
				
			Next
			For Each xpoCc In AdditionalCCNotificationRecipients
                If xpoCc.ToAddress = String.Empty
                    Continue For
                End If
                If xpoCc.ToName > String.Empty
                    .CC.Add(New Net.Mail.MailAddress(xpoCc.ToAddress, xpoCc.ToName))
                    Else
                    .CC.Add(New Net.Mail.MailAddress(xpoCc.ToAddress))
                End If
				
			Next
			For Each xpoBCC In AdditionalBCCNotificationRecipients
                If xpoBCC.ToAddress = String.Empty OrElse xpoBCC.ToAddress = vbCrLf
                    Continue For
                End If
                If  xpoBCC.ToName > String.Empty
                    .Bcc.Add(New Net.Mail.MailAddress(xpoBCC.ToAddress, xpoBCC.ToName))
                    Else
                    .Bcc.Add(New Net.Mail.MailAddress(xpoBCC.ToAddress))
                End If
				
			Next

		End With
        Return smmMailMessage
    End Function


    'Private _mErrorMessage As String
    '<VisibleInListView(False)>
    '<Size(-1)>
    'Public Property ErrorMessage As String
    '    Get
    '        Return _mErrorMessage
    '    End Get
    '    Set(ByVal Value As String)
    '        SetPropertyValue("ErrorMessage", _mErrorMessage, Value)
    '    End Set
    'End Property


    Private _mRelatedNotificationRule As NotificationRule
    Public Property RelatedNotificationRule As NotificationRule
        Get
            Return _mRelatedNotificationRule
        End Get
        Set(ByVal Value As NotificationRule)
            SetPropertyValue("RelatedNotificationRule", _mRelatedNotificationRule, Value)
        End Set
    End Property
    Private _mSerializedObjectKey As String
    <Size(-1)>
    Public Property SerializedObjectKey As String
        Get
            Return _mSerializedObjectKey
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SerializedObjectKey", _mSerializedObjectKey, Value)
        End Set
    End Property
    'Private _mProcessed As Boolean
    'Public Property Processed As Boolean
    '    Get
    '        Return _mProcessed
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        SetPropertyValue("Processed", _mProcessed, Value)
    '    End Set
    'End Property

    Private _mAttemptCount As Integer
    Public Property AttemptCount As Integer
        Get
            Return _mAttemptCount
        End Get
        Set(value As Integer)
            SetPropertyValue(NameOf(AttemptCount), _mAttemptCount, value)
        End Set
    End Property

    'Private _PersistentProperty As String
    '<XafDisplayName("My display name"), ToolTip("My hint message")> _
    '<ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(False)> _
    '<Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)> _
    'Public Property PersistentProperty() As String
    '    Get
    '        Return _PersistentProperty
    '    End Get
    '    Set(ByVal value As String)
    '        SetPropertyValue("PersistentProperty", _PersistentProperty, value)
    '    End Set
    'End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (http://documentation.devexpress.com/#Xaf/CustomDocument2619).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
