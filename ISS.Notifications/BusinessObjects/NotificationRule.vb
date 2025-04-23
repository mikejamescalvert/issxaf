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
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.XtraReports.UI
Imports ISS.ExtensionMethods
Imports DevExpress.Persistent.Base.General
Imports DevExpress.XtraPrinting
Imports System.Drawing.Printing
Imports System.Net
Imports ISS.Recurrence
Imports ISS.Base.ReportService
Imports ISS.Base.Services.ReportService
Imports ISS.Base.Attributes.Editors.TextEditor
Imports DevExpress.Persistent.BaseImpl.EF
Imports ReportData = DevExpress.Persistent.BaseImpl.ReportData

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _


'todo: Add elapsed time options (Pivot Date Property, Adjustment Type [Seconds,Hours,Days.Month,Year], Adjustment Value)
'todo: check subject max settings for emails
'todo: set body as html editor
'todo: add in test process (show popup of objects that fit criteria.  allow entry of test email and selection of emails to test)
'<DefaultClassOptions()>
Public Class NotificationRule ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    'Implements IRecurrentEvent
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        Me.Recurrence = New RecurrenceDefinition(Session)
        With Me.Recurrence
            .HourlyRecurrence = 1
            .TimeToExecute = Now
        End With
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub

#Region "Properties"

    Private _mChangeToValue As String
    Private _mToValue As String
    Private _mChangeFromValue As String
    Private _mName As String
    <Size(255)>
    Public Property Name As String
        Get
            Return _mName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Name", _mName, Value)
        End Set
    End Property

    Public Enum EmailStyles
        AsEmbeddedReport
        AsAttachedReport
    End Enum
    Public Enum EvaluationTypes
        UponSave = 0
        ElapsedTime = 1
        Scheduled = 2
        OnDemand = 3
        Internal = 4
        OnDemandSelectedQualifying = 10
        OnDemandAllQualifying = 11

    End Enum
    Public Enum ReportTypes
        ReportV1
        ReportV2
    End Enum
    Public Enum NotificationFrequencyType
        FirstOccuranceOnly = 0
        EachOccurance = 1
        'OnceDaily = 2
    End Enum

    Private _mCombineAllOccurencesIntoSingleEmail As Boolean
    <ToolTip("Determines whether or not the notification rule will generate an email for each object that matches the filter, or a single email.")>
    Public Property CombineAllOccurencesIntoSingleEmail As Boolean
        Get
            Return _mCombineAllOccurencesIntoSingleEmail
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("CombineAllOccurencesIntoSingleEmail", _mCombineAllOccurencesIntoSingleEmail, Value)
        End Set
    End Property

    Private _mSplitAttachmentReport As ReportData
    <DataSourceCriteria("DataTypeName = '@This.TargetObjectTypeName'")>
    <ToolTip("When enabled, this feature will generate a separate PDF report for each applicable object upon execution of the notification rule. Each report will be attached to an email, ensuring that recipients receive detailed, individual documentation relevant to their specific notifications.")>
    Property SplitAttachmentReport As ReportData
        Get
            Return _mSplitAttachmentReport
        End Get
        Set(ByVal Value As ReportData)
            SetPropertyValue(NameOf(SplitAttachmentReport), _mSplitAttachmentReport, Value)
        End Set
    End Property

    Private _mReportType As ReportTypes
    <ImmediatePostData>
    Property ReportType As ReportTypes
        Get
            Return _mReportType
        End Get
        Set(ByVal Value As ReportTypes)
            SetPropertyValue(NameOf(ReportType), _mReportType, Value)
        End Set
    End Property

    Private _mBodyReport As ReportData
    <DataSourceCriteria("DataTypeName = '@This.TargetObjectTypeName'")>
    Public Property BodyReport As ReportData
        Get
            Return _mBodyReport
        End Get
        Set(ByVal Value As ReportData)
            SetPropertyValue("BodyReport", _mBodyReport, Value)
        End Set
    End Property
    Private _mBodyReportV2 As ReportDataV2
    <DataSourceCriteria("DataTypeName = '@This.TargetObjectTypeName'")>
    Public Property BodyReportV2 As ReportDataV2
        Get
            Return _mBodyReportV2
        End Get
        Set(ByVal Value As ReportDataV2)
            SetPropertyValue("BodyReportV2", _mBodyReportV2, Value)
        End Set
    End Property


    Private _mFromAddressOverride As String
    <Size(255)>
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("TargetObjectType")>
    Public Property FromAddressOverride As String
        Get
            Return _mFromAddressOverride
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("FromAddressOverride", _mFromAddressOverride, Value)
        End Set
    End Property


    Private _mBodyContent As String
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("TargetObjectType")>
    <ToolTip("Additional body content to be placed before the report content in the case of embedded reports")>
    <Size(-1)>
    Public Property BodyContent As String
        Get
            Return _mBodyContent
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("BodyContent", _mBodyContent, Value)
        End Set
    End Property

    Private _mEmailStyle As EmailStyles
    Public Property EmailStyle As EmailStyles
        Get
            Return _mEmailStyle
        End Get
        Set(ByVal Value As EmailStyles)
            SetPropertyValue("EmailStyle", _mEmailStyle, Value)
        End Set
    End Property



    Private _mAttachmentFormat As SupportedExportFormats
    Property AttachmentFormat As SupportedExportFormats
        Get
            Return _mAttachmentFormat
        End Get
        Set(ByVal Value As SupportedExportFormats)
            SetPropertyValue(NameOf(AttachmentFormat), _mAttachmentFormat, Value)
        End Set
    End Property

    Private _mRecurrence As RecurrenceDefinition
    <Aggregated()>
    <ExpandObjectMembers(ExpandObjectMembers.Never)>
    Public Property Recurrence As RecurrenceDefinition
        Get
            Return _mRecurrence
        End Get
        Set(ByVal Value As RecurrenceDefinition)
            SetPropertyValue("Recurrence", _mRecurrence, Value)
        End Set
    End Property




    Private _mTestCountLimit As Integer?

    <ToolTip("Generate test notifications for the count specified with their Executed date set to 01-01-1900")>
    Public Property TestCountLimit As Integer?
        Get
            Return _mTestCountLimit
        End Get
        Set(ByVal Value As Integer?)
            SetPropertyValue("TestCountLimit", _mTestCountLimit, Value)
        End Set
    End Property

    <Persistent("TargetObjectTypeName")>
    <Size(255)>
    Private _mTargetObjectTypeName As String
    Public Sub SetTargetObjectTypeName(ByVal TargetObjectTypeName As String)
        SetPropertyValue(Of String)("_mTargetObjectTypeName", _mTargetObjectTypeName, TargetObjectTypeName)
    End Sub
    <PersistentAlias("_mTargetObjectTypeName")>
    Public ReadOnly Property TargetObjectTypeName As String
        Get
            Return _mTargetObjectTypeName
        End Get
    End Property


    Private _mTargetObjectType As Type
    <NonPersistent()>
    Public Property TargetObjectType As Type
        Get
            If TargetObjectTypeName = String.Empty OrElse DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObjectTypeName) Is Nothing Then
                Return Nothing
            Else
                Return DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObjectTypeName).Type
            End If
        End Get
        Set(ByVal Value As Type)
            If Value Is Nothing Then
                SetTargetObjectTypeName(String.Empty)
            Else
                SetTargetObjectTypeName(Value.FullName)
            End If
        End Set
    End Property

    Private _mEvaluationType As EvaluationTypes
    <ImmediatePostData>
    Public Property EvaluationType As EvaluationTypes
        Get
            Return _mEvaluationType
        End Get
        Set(ByVal Value As EvaluationTypes)
            SetPropertyValue("EvaluationType", _mEvaluationType, Value)
        End Set
    End Property

    Private _mNotificationSubject As String
    <Size(-1)>
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("TargetObjectType")>
    Public Property NotificationSubject As String
        Get
            Return _mNotificationSubject
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("NotificationSubject", _mNotificationSubject, Value)
        End Set
    End Property

    Private _mIsActive As Boolean
    <ImmediatePostData>
    Public Property IsActive As Boolean
        Get
            Return _mIsActive
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("IsActive", _mIsActive, Value)
        End Set
    End Property
    Private _mEmailAddressesToBCC As String
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("TargetObjectType")>
    <ToolTip("Enter the bcc email addresses to send notification in semi-colon delimited format", "BCC Emails")>
    <Size(-1)>
    Public Property EmailAddressesToBCC As String
        Get
            Return _mEmailAddressesToBCC
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("EmailAddressesToBCC", _mEmailAddressesToBCC, Value)
        End Set
    End Property

    Private _mRecipientEmailAddresses As String
    <Size(-1)>
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("TargetObjectType")>
    <ToolTip("Enter the email addresses to send notification in semi-colon delimited format", "To Emails")>
    Public Property RecipientEmailAddresses As String
        Get
            Return _mRecipientEmailAddresses
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("RecipientEmailAddresses", _mRecipientEmailAddresses, Value)
        End Set
    End Property


    Private _mEmailAddressesToCC As String
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("TargetObjectType")>
    <System.ComponentModel.DisplayName("Email Addresses to CC")>
    <ToolTip("Enter the additional email addresses to CC in semi-colon delimited format", "CC Emails")>
    <Size(-1)>
    Public Property EmailAddressesToCC As String
        Get
            Return _mEmailAddressesToCC
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("EmailAddressesToCC", _mEmailAddressesToCC, Value)
        End Set
    End Property

    Private _mUseAngledBracketsForTokens As Boolean
    Public Property UseAngledBracketsForTokens As Boolean
        Get
            Return _mUseAngledBracketsForTokens
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("UseAngledBracketsForTokens", _mUseAngledBracketsForTokens, Value)
        End Set
    End Property


    Private _mRuleCriteria As String
    <Size(-1)>
    <CriteriaOptions("TargetObjectType")>
    Public Property RuleCriteria As String
        Get
            Return _mRuleCriteria
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("RuleCriteria", _mRuleCriteria, Value)
        End Set
    End Property

    

    'todo: provide value picker for objects
    <Size(255)>
    Property ChangeFromValue As String
        Get
            Return _mChangeFromValue
        End Get
        Set(ByVal Value As String)
            If (_mChangeFromValue = Value) Then Return
            _mChangeFromValue = Value
            OnChanged(NameOf(ChangeFromValue), Me, Me)
        End Set
    End Property

    'todo: provide value picker for objects
    <Size(255)>
    Property ChangeToValue As String
        Get
            Return _mChangeToValue
        End Get
        Set(ByVal Value As String)
            If (_mChangeToValue = Value) Then Return
            _mChangeToValue = Value
            OnChanged(NameOf(ChangeToValue), Me, Me)
        End Set
    End Property

    <ToolTip("List of additional email address information to use as choices for On Demand notifications")>
    <Association("NotificationRule-NotificationOnDemandFromOptions")>
    <Aggregated()>
    Public ReadOnly Property NotificationOnDemandFromOptions() As XPCollection(Of NotificationOnDemandFromOption)
        Get
            Return GetCollection(Of NotificationOnDemandFromOption)("NotificationOnDemandFromOptions")
        End Get
    End Property
    <ToolTip("List of additional email address information to use as choices for On Demand notifications")>
    <Association("NotificationRule-NotificationOnDemandToOptions")>
    <Aggregated()>
    Public ReadOnly Property NotificationOnDemandToOptions() As XPCollection(Of NotificationOnDemandToOption)
        Get
            Return GetCollection(Of NotificationOnDemandToOption)("NotificationOnDemandToOptions")
        End Get
    End Property


    Private _mFrequency As NotificationFrequencyType
    Public Property Frequency As NotificationFrequencyType
        Get
            Return _mFrequency
        End Get
        Set(ByVal Value As NotificationFrequencyType)
            SetPropertyValue("Frequency", _mFrequency, Value)
        End Set
    End Property

#End Region

#Region "Behaviors"
    Protected Overrides Sub OnChanged(propertyName As String, oldValue As Object, newValue As Object)
        Dim xpoUOW As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        Dim xpoRD As RecurrenceDefinition
        MyBase.OnChanged(propertyName, oldValue, newValue)
        Select Case propertyName
            Case "IsActive"
                If IsActive = True Then
                    TestCountLimit = Nothing
                End If
            Case "EvaluationType"
                If EvaluationType = EvaluationTypes.Scheduled AndAlso Recurrence Is Nothing Then
                    xpoRD = New RecurrenceDefinition(xpoUOW)
                    xpoUOW.CommitChanges()
                    Me.Recurrence = Session.GetObjectByKey(Of RecurrenceDefinition)(xpoRD.Oid)


                End If
            Case NameOf(BodyReport)
                If BodyReport IsNot Nothing Then
                    BodyReportV2 = Nothing
                End If
            Case NameOf(BodyReportV2)
                If BodyReportV2 IsNot Nothing Then
                    BodyReport = Nothing
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Creates a notification for the target object based on the fit to the rule criteria and details
    ''' If no target opbjkect specified and the rule is elapsed time it will process against a collection of qualifying iobjects
    ''' </summary>
    ''' <param name="TargetObject"></param>
    ''' 
    ''' <remarks>
    ''' Expects a base object decendent if the same type as the TargetObjectType
    ''' </remarks>
    ''' 
    Public Sub ProcessNotificationRule(Optional TargetObject As XPBaseObject = Nothing)
        Dim intCounter As Integer
        Dim intItemCount As Integer

        Try
            Select Case EvaluationType
                Case EvaluationTypes.Scheduled
                    If Me.Recurrence IsNot Nothing AndAlso Me.Recurrence.Due = False Then
                        Exit Sub
                    End If
                    If TargetObject Is Nothing Then



                        If CombineAllOccurencesIntoSingleEmail = False Then

                            Dim xcl As XPCollection = GetQualifyingObjects()
                            For Each xpoTargetObject In xcl
                                intCounter += 1
                                ProcessNotificationRuleForTargetObject(xpoTargetObject)
                                If TestCountLimit IsNot Nothing AndAlso intCounter = TestCountLimit Then
                                    Exit For
                                End If
                            Next
                        Else
                            'are there any occurences?
                            intItemCount = Session.Evaluate(TargetObjectType, CriteriaOperator.Parse("Count()"), GetCriteria)
                            If intItemCount > 0 Then
                                ProcessNotificationRuleFromFilter(GetCriteria)
                            End If

                        End If

                    Else
                        ProcessNotificationRuleForTargetObject(TargetObject)
                    End If
                Case EvaluationTypes.ElapsedTime
                    If TargetObject Is Nothing Then

                        If CombineAllOccurencesIntoSingleEmail = False Then
                            Dim xcl As XPCollection = GetQualifyingObjects()


                            For Each xpoTargetObject In xcl
                                intCounter += 1
                                ProcessNotificationRuleForTargetObject(xpoTargetObject)
                                If TestCountLimit IsNot Nothing AndAlso intCounter = TestCountLimit Then
                                    Exit For
                                End If

                            Next
                        Else
                            'are there any occurences?
                            intItemCount = Session.Evaluate(TargetObjectType, CriteriaOperator.Parse("Count()"), GetCriteria)
                            If intItemCount > 0 Then
                                ProcessNotificationRuleFromFilter(GetCriteria)
                            End If
                        End If

                    Else
                        ProcessNotificationRuleForTargetObject(TargetObject)
                    End If
                Case EvaluationTypes.UponSave

                    If TargetObject Is Nothing Then
                        Throw New Exception("Could not process SAVE rule with no Target Object")
                    Else
                        'See if target object fits the rule
                        If TargetObject.Fit(Me.GetCriteria) OrElse Me.GetCriteria Is Nothing Then
                            ProcessNotificationRuleForTargetObject(TargetObject)
                        End If
                    End If
                Case EvaluationTypes.OnDemand, EvaluationTypes.Internal
                    If TargetObject Is Nothing Then
                        Throw New Exception("Could not process notification rule with no Target Object")
                    Else
                        'See if target object fits the rule
                        If TargetObject.Fit(Me.GetCriteria) OrElse Me.GetCriteria Is Nothing Then
                            ProcessNotificationRuleForTargetObject(TargetObject)
                        End If
                    End If

                Case EvaluationTypes.OnDemandSelectedQualifying
                    If TargetObject Is Nothing Then
                        Return
                    Else
                        'See if target object fits the rule
                        If TargetObject.Fit(Me.GetCriteria) OrElse Me.GetCriteria Is Nothing Then
                            ProcessNotificationRuleForTargetObject(TargetObject)
                        End If
                    End If

                Case EvaluationTypes.OnDemandAllQualifying
                    If CombineAllOccurencesIntoSingleEmail = False Then

                        Dim xcl As XPCollection = GetQualifyingObjects()
                        For Each xpoTargetObject In xcl
                            intCounter += 1
                            ProcessNotificationRuleForTargetObject(xpoTargetObject)
                            If TestCountLimit IsNot Nothing AndAlso intCounter = TestCountLimit Then
                                Exit For
                            End If
                        Next
                    Else
                        'are there any occurences?
                        intItemCount = Session.Evaluate(TargetObjectType, CriteriaOperator.Parse("Count()"), GetCriteria)
                        If intItemCount > 0 Then
                            ProcessNotificationRuleFromFilter(GetCriteria)
                        End If

                    End If

            End Select
        Catch ex As Exception
            Throw New Exception("Error processing rule: " + Oid.ToString, ex)
        End Try




    End Sub

    Public Function GetExistingNotifications(TargetObject As XPBaseObject) As XPCollection(Of NotificationQueueItem)
        If TargetObject Is Nothing Then
            Return New XPCollection(Of NotificationQueueItem)(Session, CriteriaOperator.Parse("1=0"))
        End If
        Dim tpiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObject.GetType)
        Dim gpoGroupOperator As New GroupOperator

        gpoGroupOperator.Operands.Add(New BinaryOperator("SerializedObjectKey", tpiTypeInfo.KeyMember.SerializeValue(TargetObject)))
        gpoGroupOperator.Operands.Add(New BinaryOperator("RelatedNotificationRule", Me))
        Return New XPCollection(Of NotificationQueueItem)(Session, gpoGroupOperator)
    End Function

    Private Sub ProcessNotificationRuleFromFilter(Filter As GroupOperator)
        Dim xpoNewNotification As NotificationQueueItem
        Try


            xpoNewNotification = GenerateNotificationFromFilter(Filter)

            If xpoNewNotification IsNot Nothing Then
                With xpoNewNotification
                    .RelatedNotificationRule = Me
                End With
            End If
            'update recurrance processing date and time
            If Recurrence IsNot Nothing Then
                Recurrence.Update()
            End If

        Catch ex As Exception
            Throw New Exception("Error processing rule: " + Oid.ToString, ex)
        End Try
        'get notification and save for processing


    End Sub

    Private Sub ProcessNotificationRuleForTargetObject(TargetObject As XPBaseObject)
        Try

            If TargetObject.GetType IsNot TargetObjectType Then
                Throw New Exception("Could not process rule - in valid object type for rule")
            End If
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObject.GetType)
            Dim lstExistingNotifications As IList = GetExistingNotifications(TargetObject)
            If Frequency = NotificationFrequencyType.FirstOccuranceOnly AndAlso lstExistingNotifications IsNot Nothing Then
                For Each xpoNotification As NotificationQueueItem In lstExistingNotifications
                    'test for notification exists for this rule 

                    If xpoNotification.RelatedNotificationRule IsNot Nothing AndAlso xpoNotification.RelatedNotificationRule.Oid = Me.Oid Then
                        Exit Sub
                    End If
                Next
            End If
            'If Frequency = NotificationFrequencyType.OnceDaily AndAlso lstExistingNotifications IsNot Nothing Then

            '    For Each xpoNotification As NotificationQueueItem In lstExistingNotifications
            '        'test for notification exists and within last day
            '        If xpoNotification.RelatedNotificationRule.Oid = Me.Oid Then
            '            If xpoNotification.CreatedDate.AddDays(1) > Now Then
            '                Exit Sub
            '            End If
            '        End If
            '    Next
            'End If

            'get notification and save for processing

            Dim xpoNewNotification As NotificationQueueItem = GenerateNotification(TargetObject)

            If xpoNewNotification IsNot Nothing Then
                With xpoNewNotification
                    .RelatedNotificationRule = Me
                    .SerializedObjectKey = dtiTypeInfo.KeyMember.SerializeValue(TargetObject)
                End With



            End If

            'update recurrance processing date and time
            If Recurrence IsNot Nothing Then
                Recurrence.Update()
            End If
        Catch ex As Exception
            Throw New Exception("Error processing rule: " + Oid.ToString, ex)
        End Try


    End Sub
    Public Function GenerateNotificationFromFilter(ByVal FilterGroupOperator As GroupOperator) As NotificationQueueItem
        Try

            'If NotificationReport Is Nothing Then
            '	Helpers.NotificationHelper.CreateSystemExceptionNotification(xpoSS.SystemNotificationEmailAddresses, String.Format("Notification Exception: {0}", Me.Name), "Notification Report not defined")
            '	Return Nothing
            'End If
            Dim xpoNotification As NotificationQueueItem
            Dim xpoDBAttachment As NotificationDatabaseAttachment
            Dim rpsReportService As New ISS.Base.Services.ReportService
            Dim xpoAdditionalNotificationRecipient As AdditionalNotificationRecipient
            'Dim xafRPT As XtraReport
            Dim xpcXpCollection As XPCollection
            'Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObject.GetType)
            Dim xpoMailSettings As MailSettings = MailSettings.GetInstance(Session)



            xpcXpCollection = New XPCollection(Session, Me.TargetObjectType, FilterGroupOperator)
            xpoNotification = New NotificationQueueItem(Session)
            With xpoNotification
                If String.IsNullOrEmpty(NotificationSubject) = False Then

                    If UseAngledBracketsForTokens = True Then
                        .Subject = NotificationSubject
                    Else
                        .Subject = NotificationSubject
                    End If
                End If




                .FromAddress = FromAddressOverride
                If .FromAddress = String.Empty Then
                    .FromAddress = xpoMailSettings.DefaultFromAddress
                End If

                If ReportType = ReportTypes.ReportV1 AndAlso BodyReport IsNot Nothing Then
                    Dim rptReportService As New ISS.Base.Services.ReportService

                    If EmailStyle = EmailStyles.AsAttachedReport Then
                        If Me.BodyContent IsNot Nothing Then
                            If UseAngledBracketsForTokens = True Then
                                .Body = BodyContent
                            Else
                                .Body = BodyContent
                            End If

                        End If

                        xpoDBAttachment = New NotificationDatabaseAttachment(Session)
                        With xpoDBAttachment
                            .Name = String.Format("{0}.{1}", Today.ToShortDateString, AttachmentFormat.ToString())
                            .Content = rpsReportService.ExportReportToByteArray(BodyReport, xpcXpCollection, AttachmentFormat)
                        End With
                        xpoNotification.NotificationAttachments.Add(xpoDBAttachment)
                    Else

                        .Body = System.Text.Encoding.Default.GetString(rpsReportService.ExportReportToByteArray(BodyReport, xpcXpCollection, SupportedExportFormats.Mail))
                    End If

                ElseIf ReportType = ReportTypes.ReportV2 AndAlso BodyReportV2 IsNot Nothing Then
                    Dim rptReportService As New ISS.Base.Services.ReportService

                    If EmailStyle = EmailStyles.AsAttachedReport Then
                        If Me.BodyContent IsNot Nothing Then
                            If UseAngledBracketsForTokens = True Then
                                .Body = BodyContent
                            Else
                                .Body = BodyContent
                            End If

                        End If

                        xpoDBAttachment = New NotificationDatabaseAttachment(Session)
                        With xpoDBAttachment
                            .Name = String.Format("{0}.{1}", Today.ToShortDateString, AttachmentFormat.ToString())
                            .Content = rpsReportService.ExportReportToByteArray(BodyReportV2, xpcXpCollection, AttachmentFormat)
                        End With
                        xpoNotification.NotificationAttachments.Add(xpoDBAttachment)
                    Else

                        .Body = System.Text.Encoding.Default.GetString(rpsReportService.ExportReportToByteArray(BodyReport, xpcXpCollection, SupportedExportFormats.Mail))
                    End If

                    'xafRPT.ExportToHtml(strExportStream)
                    'strExportStream.Position = 0
                    'srmReader = New IO.StreamReader(strExportStream)
                    '.Body = srmReader.ReadToEnd
                Else
                    If UseAngledBracketsForTokens = True Then
                        .Body = BodyContent
                    Else
                        .Body = BodyContent
                    End If

                End If

                If SplitAttachmentReport IsNot Nothing Then
                    For Each obj In xpcXpCollection
                        xpoDBAttachment = New NotificationDatabaseAttachment(Session)
                        With xpoDBAttachment
                            .Name = String.Format("{0}.{1}", obj.ToString, AttachmentFormat.ToString)
                            .Content = rpsReportService.ExportReportToByteArray(SplitAttachmentReport, {obj}, AttachmentFormat)
                        End With
                        xpoNotification.NotificationAttachments.Add(xpoDBAttachment)
                    Next


                End If

                Dim strReplacement As String

                If RecipientEmailAddresses > String.Empty Then
                    If UseAngledBracketsForTokens = True Then
                        strReplacement = RecipientEmailAddresses
                    Else
                        strReplacement = RecipientEmailAddresses
                    End If
                    For Each strToAddressSplit In strReplacement.Split(";")
                        For Each strToAddress In strToAddressSplit.Split(",")
                            If .PrimaryToAddress = String.Empty Then
                                If UseAngledBracketsForTokens = True Then
                                    .PrimaryToAddress = strToAddress
                                Else
                                    .PrimaryToAddress = strToAddress
                                End If

                            Else
                                xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(Session)
                                With xpoAdditionalNotificationRecipient
                                    If UseAngledBracketsForTokens = True Then
                                        .ToAddress = strToAddress
                                    Else
                                        .ToAddress = strToAddress
                                    End If

                                End With
                                .AdditionalToNotificationRecipients.Add(xpoAdditionalNotificationRecipient)

                            End If
                        Next

                    Next
                End If

                If EmailAddressesToCC > String.Empty Then
                    If UseAngledBracketsForTokens = True Then
                        strReplacement = EmailAddressesToCC
                    Else
                        strReplacement = EmailAddressesToCC
                    End If
                    For Each strToAddressSplit In strReplacement.Split(";")
                        For Each strToAddress In strToAddressSplit.Split(",")
                            xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(Session)
                            With xpoAdditionalNotificationRecipient
                                If UseAngledBracketsForTokens = True Then
                                    .ToAddress = strToAddress
                                Else
                                    .ToAddress = strToAddress
                                End If

                            End With
                            .AdditionalCCNotificationRecipients.Add(xpoAdditionalNotificationRecipient)
                        Next



                    Next
                End If

                If EmailAddressesToBCC > String.Empty Then
                    If UseAngledBracketsForTokens = True Then
                        strReplacement = EmailAddressesToBCC
                    Else
                        strReplacement = EmailAddressesToBCC
                    End If
                    For Each strToAddressSplit In strReplacement.Split(";")
                        For Each strToAddress In strToAddressSplit.Split(",")
                            xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(Session)
                            With xpoAdditionalNotificationRecipient
                                If UseAngledBracketsForTokens = True Then
                                    .ToAddress = strToAddress
                                Else
                                    .ToAddress = strToAddress
                                End If

                            End With
                            .AdditionalBCCNotificationRecipients.Add(xpoAdditionalNotificationRecipient)
                        Next



                    Next
                End If

                NotificationHelper.OnNotificationQueueItemGenerated(xpoNotification, Me, Nothing, FilterGroupOperator)
            End With
            Return xpoNotification
        Catch ex As Exception
            NotificationHelper.LogNotificationException(Me, String.Empty, ex, Session)

        End Try
        Return Nothing
    End Function
    Public Function GenerateNotification(ByVal TargetObject As Object) As NotificationQueueItem
        Try
            Dim xpoNotification As NotificationQueueItem
            Dim xpoDBAttachment As NotificationDatabaseAttachment
            Dim xpoAdditionalNotificationRecipient As AdditionalNotificationRecipient

            Dim rptService As New ISS.Base.Services.ReportService
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObject.GetType)
            Dim xpoMailSettings As MailSettings = MailSettings.GetInstance(Session)



            xpoNotification = New NotificationQueueItem(Session)
            With xpoNotification
                .SerializedObjectKey = dtiTypeInfo.KeyMember.SerializeValue(TargetObject)
                If String.IsNullOrEmpty(NotificationSubject) = False Then

                    If UseAngledBracketsForTokens = True Then
                        .Subject = NotificationSubject.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
                    Else
                        .Subject = NotificationSubject.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
                    End If
                End If




                .FromAddress = FromAddressOverride
                If .FromAddress = String.Empty Then
                    .FromAddress = xpoMailSettings.DefaultFromAddress
                End If

                If UseAngledBracketsForTokens = True Then
                    .FromAddress = .FromAddress.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
                Else
                    .FromAddress = .FromAddress.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
                End If

                If ReportType = ReportTypes.ReportV1 AndAlso BodyReport IsNot Nothing Then

                    If EmailStyle = EmailStyles.AsAttachedReport Then
                        If String.IsNullOrEmpty(BodyContent) = False Then

                            If UseAngledBracketsForTokens = True Then
                                .Body = BodyContent.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
                            Else
                                .Body = BodyContent.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
                            End If
                        End If
                        xpoDBAttachment = New NotificationDatabaseAttachment(Session)
                        With xpoDBAttachment
                            '.Name = String.Format("{0}.{1}", Today.ToShortDateString, AttachmentFormat.ToString)
                            .Name = String.Format("{0:MMddyyyy}.{1}", Today, AttachmentFormat.ToString)
                            .Content = rptService.ExportReportToByteArray(BodyReport, {TargetObject}, AttachmentFormat)
                        End With
                        xpoNotification.NotificationAttachments.Add(xpoDBAttachment)
                    Else
                        .Body = System.Text.Encoding.Default.GetString(rptService.ExportReportToByteArray(BodyReport, {TargetObject}, SupportedExportFormats.Mail))
                    End If

                ElseIf ReportType = ReportTypes.ReportV2 AndAlso BodyReportV2 IsNot Nothing Then
                    If EmailStyle = EmailStyles.AsAttachedReport Then
                        xpoDBAttachment = New NotificationDatabaseAttachment(Session)

                        With xpoDBAttachment
                            '.Name = String.Format("{0}.{1}", Today.ToShortDateString, AttachmentFormat.ToString)
                            .Name = String.Format("{0:MMddyyyy}.{1}", Today, AttachmentFormat.ToString)
                            .Content = rptService.ExportReportToByteArray(BodyReportV2, {TargetObject}, AttachmentFormat)
                        End With
                        xpoNotification.NotificationAttachments.Add(xpoDBAttachment)
                    Else
                        .Body = System.Text.Encoding.Default.GetString(rptService.ExportReportToByteArray(BodyReport, {TargetObject}, SupportedExportFormats.Mail))
                    End If
                Else
                    If String.IsNullOrEmpty(BodyContent) = False Then

                        If UseAngledBracketsForTokens = True Then
                            .Body = BodyContent.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
                        Else
                            .Body = BodyContent.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
                        End If
                    End If


                End If
                Dim strReplacement As String

                If RecipientEmailAddresses > String.Empty Then
                    If UseAngledBracketsForTokens = True Then
                        strReplacement = RecipientEmailAddresses.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
                    Else
                        strReplacement = RecipientEmailAddresses.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
                    End If
                    For Each strToAddressSplit In strReplacement.Split(";")
                        For Each strToAddress In strToAddressSplit.Split(",")
                            If .PrimaryToAddress = String.Empty Then
                                If UseAngledBracketsForTokens = True Then
                                    .PrimaryToAddress = strToAddress
                                Else
                                    .PrimaryToAddress = strToAddress
                                End If

                            Else
                                xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(Session)
                                With xpoAdditionalNotificationRecipient
                                    If UseAngledBracketsForTokens = True Then
                                        .ToAddress = strToAddress
                                    Else
                                        .ToAddress = strToAddress
                                    End If

                                End With
                                .AdditionalToNotificationRecipients.Add(xpoAdditionalNotificationRecipient)

                            End If
                        Next

                    Next
                End If
                AppendCCAndBCCToNotificationQueueItem(xpoNotification, TargetObject)

                .RelatedNotificationRule = Me
                NotificationHelper.OnNotificationQueueItemGenerated(xpoNotification, Me, TargetObject, Nothing)
            End With
            Return xpoNotification
        Catch ex As Exception
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo
            Dim strKey As String
            Try
                dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObject.GetType)
                strKey = dtiTypeInfo.KeyMember.SerializeValue(TargetObject)
            Catch ex2 As Exception
                strKey = String.Empty
            End Try
            NotificationHelper.LogNotificationException(Me, strKey, ex, Session)

        End Try
        Return Nothing
    End Function

    Private Sub label_HtmlItemCreated(sender As Object, e As HtmlEventArgs)
        Dim strNewHtml As String
        Try
            If e.Brick.TextValue.ToString.ToUpper.Contains("<HTML") Or e.Brick.TextValue.ToString.ToUpper.Contains("<SPAN") Or e.Brick.TextValue.ToString.ToUpper.Contains("<IMG") Or e.Brick.TextValue.ToString.ToUpper.Contains("</") Then
                strNewHtml = e.Brick.Text
                If strNewHtml > String.Empty Then
                    strNewHtml = strNewHtml.Replace("’", "'").Replace("…", "...").Replace("‘", "'")
                End If
                e.ContentCell.InnerHtml = strNewHtml

            End If

        Catch ex As Exception

        End Try



    End Sub

    ''' <summary>
    ''' Creates the CC and BCC Additional Email Address Entries using the values provided
    ''' </summary>
    ''' <param name="QueueItem"></param>
    ''' <param name="EmailAddressesToCCText"></param>
    ''' <param name="EmailAddressesToBCCText"></param>
    Public Sub AppendCCAndBCCToNotificationQueueItem(ByVal QueueItem As NotificationQueueItem, ByVal EmailAddressesToCCText As String, EmailAddressesToBCCText As String)

        Dim xpoAdditionalNotificationRecipient As AdditionalNotificationRecipient
        With QueueItem

            If EmailAddressesToCCText > String.Empty Then
                For Each strToAddressSplit In EmailAddressesToCCText.Split(";")
                    For Each strToAddress In strToAddressSplit.Split(",")
                        If strToAddress = String.Empty Then
                            Continue For
                        End If
                        xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(QueueItem.Session)
                        With xpoAdditionalNotificationRecipient
                            If UseAngledBracketsForTokens = True Then
                                .ToAddress = strToAddress
                            Else
                                .ToAddress = strToAddress
                            End If

                        End With
                        .AdditionalCCNotificationRecipients.Add(xpoAdditionalNotificationRecipient)
                    Next



                Next
            End If
            If EmailAddressesToBCCText > String.Empty Then
                For Each strToAddressSplit In EmailAddressesToBCCText.Split(";")
                    For Each strToAddress In strToAddressSplit.Split(",")
                        If strToAddress = String.Empty Then
                            Continue For
                        End If
                        xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(QueueItem.Session)
                        With xpoAdditionalNotificationRecipient
                            If UseAngledBracketsForTokens = True Then
                                .ToAddress = strToAddress
                            Else
                                .ToAddress = strToAddress
                            End If

                        End With
                        .AdditionalBCCNotificationRecipients.Add(xpoAdditionalNotificationRecipient)
                    Next



                Next
            End If
        End With
    End Sub
    ''' <summary>
    ''' Creates the CC and BCC Additional Email Address Entries using the rule definition and token substitution
    ''' </summary>
    ''' <param name="QueueItem"></param>
    ''' <param name="TargetObject"></param>
    Public Sub AppendCCAndBCCToNotificationQueueItem(ByVal QueueItem As NotificationQueueItem, ByVal TargetObject As Object)
        Dim strReplacement As String
        Dim xpoAdditionalNotificationRecipient As AdditionalNotificationRecipient
        With QueueItem

            If EmailAddressesToCC > String.Empty Then
                If UseAngledBracketsForTokens = True Then
                    strReplacement = EmailAddressesToCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
                Else
                    strReplacement = EmailAddressesToCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
                End If
                For Each strToAddressSplit In strReplacement.Split(";")
                    For Each strToAddress In strToAddressSplit.Split(",")
                        If strToAddress = String.Empty Then
                            Continue For
                        End If
                        xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(QueueItem.Session)
                        With xpoAdditionalNotificationRecipient
                            If UseAngledBracketsForTokens = True Then
                                .ToAddress = strToAddress
                            Else
                                .ToAddress = strToAddress
                            End If

                        End With
                        .AdditionalCCNotificationRecipients.Add(xpoAdditionalNotificationRecipient)
                    Next



                Next
            End If

            If EmailAddressesToBCC > String.Empty Then
                If UseAngledBracketsForTokens = True Then
                    strReplacement = EmailAddressesToBCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
                Else
                    strReplacement = EmailAddressesToBCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
                End If
                For Each strToAddressSplit In strReplacement.Split(";")
                    For Each strToAddress In strToAddressSplit.Split(",")
                        If strToAddress = String.Empty Then
                            Continue For
                        End If
                        xpoAdditionalNotificationRecipient = New AdditionalNotificationRecipient(QueueItem.Session)
                        With xpoAdditionalNotificationRecipient
                            If UseAngledBracketsForTokens = True Then
                                .ToAddress = strToAddress
                            Else
                                .ToAddress = strToAddress
                            End If

                        End With
                        .AdditionalBCCNotificationRecipients.Add(xpoAdditionalNotificationRecipient)
                    Next



                Next
            End If

        End With
    End Sub
    ''' <summary>
    ''' Returns the CC email address string substituting in any token values
    ''' </summary>
    ''' <param name="TargetObject"></param>
    ''' <returns></returns>
    Public Function GetCCEmailAddress(ByVal TargetObject As Object) As String
        Dim strReplacement As String

        If EmailAddressesToCC > String.Empty Then
            If UseAngledBracketsForTokens = True Then
                strReplacement = EmailAddressesToCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
            Else
                strReplacement = EmailAddressesToCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
            End If
        End If
        Return strReplacement
    End Function
    ''' <summary>
    ''' Returns the BCC email address string substituting in any token values
    ''' </summary>
    ''' <param name="TargetObject"></param>
    ''' <returns></returns>
    Public Function GetBCCEmailAddress(ByVal TargetObject As Object) As String
        Dim strReplacement As String

        If EmailAddressesToBCC > String.Empty Then
            If UseAngledBracketsForTokens = True Then
                strReplacement = EmailAddressesToBCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Braces)
            Else
                strReplacement = EmailAddressesToBCC.issSubstituteTokens(TargetObject, TokenEncapsulatorTypes.Brackets)
            End If
        End If
        Return strReplacement
    End Function

    Public Function GetQualifyingObjects() As XPCollection
        Return New XPCollection(Session, TargetObjectType, GetCriteria)
    End Function

    ''' <summary>
    ''' Returns a criteria object which will include any time lapse criteria operator
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCriteria() As CriteriaOperator
        Dim xpoGO As New GroupOperator

        With xpoGO.Operands
            If Not String.IsNullOrEmpty(RuleCriteria) Then
                .Add(Session.ParseCriteria(RuleCriteria))
            End If

        End With
        If xpoGO.Operands.Count = 0 Then
            Return Nothing
        Else
            Return xpoGO
        End If




    End Function

    'Public Function GetSourceCriteria() As CriteriaOperator
    '    Dim xpoGO As New GroupOperator

    '    With xpoGO.Operands
    '        If Not String.IsNullOrEmpty(SourceCriteria) Then
    '            .Add(Session.ParseCriteria(SourceCriteria))
    '        End If

    '    End With
    '    If xpoGO.Operands.Count = 0 Then
    '        Return Nothing
    '    Else
    '        Return xpoGO
    '    End If

    'End Function

#End Region


    '    #Region "ReccurrenceV2"

    '    Private _mAllDay As Boolean
    '        <Browsable(False)>
    '    Public Property AllDay As Boolean Implements IEvent.AllDay
    '        Get
    '            Return _mAllDay
    '        End Get
    '        Set(ByVal Value As Boolean)
    '            SetPropertyValue("AllDay", _mAllDay, Value)
    '        End Set
    '    End Property
    '        <Browsable(False)>
    '    Public ReadOnly Property AppointmentId As Object Implements IEvent.AppointmentId
    '        Get
    '            Return Oid
    '        End Get
    '    End Property


    '    Private _mDescription As String
    '    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    '        <Browsable(False)>
    '    Public Property Description As String Implements IEvent.Description
    '        Get
    '            Return _mDescription
    '        End Get
    '        Set(ByVal Value As String)
    '            SetPropertyValue("Description", _mDescription, Value)
    '        End Set
    '    End Property

    '    Private _mEndOn As Date
    '        <Browsable(False)>
    '    Public Property EndOn As Date Implements IEvent.EndOn
    '        Get
    '            Return _mEndOn
    '        End Get
    '        Set(ByVal Value As Date)
    '            SetPropertyValue("EndOn", _mEndOn, Value)
    '        End Set
    '    End Property

    '    Private _mLabel As Integer
    '    <Browsable(False)>
    '    Public Property Label As Integer Implements IEvent.Label
    '        Get
    '            Return _mLabel
    '        End Get
    '        Set(ByVal Value As Integer)
    '            SetPropertyValue("Label", _mLabel, Value)
    '        End Set
    '    End Property


    '    Private _mLocation As String
    '    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    '    <Browsable(False)>
    '    Public Property Location As String Implements IEvent.Location
    '        Get
    '            Return _mLocation
    '        End Get
    '        Set(ByVal Value As String)
    '            SetPropertyValue("Location", _mLocation, Value)
    '        End Set
    '    End Property

    '    Private _mRecurrenceInfoXml As String
    '    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    '    <DevExpress.Xpo.DisplayName("Recurrence Settings")>
    '    Public Property RecurrenceInfoXml As String Implements IRecurrentEvent.RecurrenceInfoXml
    '        Get
    '            Return _mRecurrenceInfoXml
    '        End Get
    '        Set(ByVal Value As String)
    '            SetPropertyValue("RecurrenceInfoXml", _mRecurrenceInfoXml, Value)
    '        End Set
    '    End Property

    '    Private _mRecurrencePattern As IRecurrentEvent
    '    <Browsable(False)>
    '    Public Property RecurrencePattern As IRecurrentEvent Implements IRecurrentEvent.RecurrencePattern
    '        Get
    '            Return _mRecurrencePattern
    '        End Get
    '        Set(ByVal Value As IRecurrentEvent)
    '            SetPropertyValue("RecurrencePattern", _mRecurrencePattern, Value)
    '        End Set
    '    End Property


    '    Private _mResourceId As String
    '    <Browsable(False)>
    '    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    '    Public Property ResourceId As String Implements IEvent.ResourceId
    '        Get
    '            Return _mResourceId
    '        End Get
    '        Set(ByVal Value As String)
    '            SetPropertyValue("ResourceId", _mResourceId, Value)
    '        End Set
    '    End Property

    '    Private _mStartOn As Date
    '    <Browsable(False)>
    '    Public Property StartOn As Date Implements IEvent.StartOn
    '        Get
    '            Return _mStartOn
    '        End Get
    '        Set(ByVal Value As Date)
    '            SetPropertyValue("StartOn", _mStartOn, Value)
    '        End Set
    '    End Property

    '    Private _mStatus As Integer
    '    <Browsable(False)>
    '    Public Property Status As Integer Implements IEvent.Status
    '        Get
    '            Return _mStatus
    '        End Get
    '        Set(ByVal Value As Integer)
    '            SetPropertyValue("Status", _mStatus, Value)
    '        End Set
    '    End Property

    '    Private _mSubject As String
    '    <Browsable(False)>
    '    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    '    Public Property Subject As String Implements IEvent.Subject
    '        Get
    '            Return _mSubject
    '        End Get
    '        Set(ByVal Value As String)
    '            SetPropertyValue("Subject", _mSubject, Value)
    '        End Set
    '    End Property

    '    Private _mType As Integer
    '    <Browsable(False)>
    '    Public Property Type As Integer Implements IEvent.Type
    '        Get
    '            Return _mType
    '        End Get
    '        Set(ByVal Value As Integer)
    '            SetPropertyValue("Type", _mType, Value)
    '        End Set
    '    End Property

    '    Public ReadOnly Property Due As Boolean
    '        Get
    '            'todo: parse definition and last run

    '        End Get
    '    End Property

    '    Private _mLastRunDate As DateTime
    '    Public Property LastRunDate As DateTime
    '        Get
    '            Return _mLastRunDate
    '        End Get
    '        Set(ByVal Value As DateTime)
    '            SetPropertyValue("LastRunDate", _mLastRunDate, Value)
    '        End Set
    '    End Property


    '#End Region

End Class
