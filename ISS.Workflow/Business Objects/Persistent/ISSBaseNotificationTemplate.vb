Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("Notification Template")> _
<Serializable()> _
Public Class ISSBaseNotificationTemplate
    Inherits BaseObject


    Public Sub New()
        MyBase.New()
    End Sub

#Region "Behaviors"

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        BuildDefaultProperties()
    End Sub

    Public Sub BuildDefaultProperties()
        Dim rpiPropertyInfo As System.Reflection.PropertyInfo
        Dim objPropertyTemplate As ISSBaseNotificationPropertyEmailTemplate
        Dim gfcGroupCriteria As New DevExpress.Data.Filtering.GroupOperator
        Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo
        For intLoop As Integer = SendToProperties.Count - 1 To 0 Step -1
            SendToProperties(intLoop).Delete()
        Next
        If Me.ObjectCustomization IsNot Nothing Then
            dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ObjectCustomization.ObjectType)
            For Each rpiPropertyInfo In Me.ObjectCustomization.ObjectType.GetProperties
                
                If rpiPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.XPCustomObject) AndAlso _
                        rpiPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.XPBaseObject) AndAlso _
                        rpiPropertyInfo.PropertyType IsNot GetType(ISSBaseWorkflowStep) AndAlso _
                        rpiPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.PersistentBase) Then
                    If dtiTypeInfo.FindMember(rpiPropertyInfo.Name) is Nothing OrElse dtiTypeInfo.FindMember(rpiPropertyInfo.Name).FindAttribute(Of WorkflowNotificationSendToPropertyAttribute) is Nothing then
                        Continue For
                    End If

                    gfcGroupCriteria.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("PropertyName", rpiPropertyInfo.Name))
                    gfcGroupCriteria.Operands.Add(SendToProperties.Criteria)
                    gfcGroupCriteria.OperatorType = DevExpress.Data.Filtering.GroupOperatorType.And
                    objPropertyTemplate = Me.Session.FindObject(GetType(ISSBaseNotificationPropertyEmailTemplate), gfcGroupCriteria)
                    If objPropertyTemplate Is Nothing Then
                        objPropertyTemplate = New ISSBaseNotificationPropertyEmailTemplate(Me.Session)
                        objPropertyTemplate.PropertyValue = rpiPropertyInfo
                        objPropertyTemplate.Save()
                        Me.SendToProperties.Add(objPropertyTemplate)
                    End If
                End If
            Next
        End If
    End Sub


    Public Shared Function GetReplacementTokens(ByVal Value As String, ByVal ReplacementObject As Object, Optional ByVal ChangedProperty As String = "") As String
        Dim strReplacedValue As String = Value
        Dim intPosition As Integer = 0
        Dim intEndCharacter As Integer = 0
        Dim strProperty As String
        Dim strReplaceValue As String
        While intPosition < Value.Length AndAlso intPosition <> -1
            intPosition = Value.IndexOf("[", intPosition)
            intEndCharacter = Value.IndexOf("]", intPosition + 1)
            If intPosition <> -1 AndAlso intEndCharacter <> -1 Then
                strProperty = Value.Substring(intPosition + 1, intEndCharacter - intPosition - 1)
                strReplaceValue = Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(strProperty, ReplacementObject).ToString
                strReplacedValue = strReplacedValue.Replace("[" + strProperty + "]", strReplaceValue)
            End If
            If intEndCharacter <> -1 Then
                intPosition = intEndCharacter + 1
            Else
                intPosition = -1
            End If
        End While
        Return strReplacedValue
    End Function
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Public Sub OnNotification(ByVal EffectedObject As Object, ByVal NotificationStage As NotificationStages, ByVal ChangedProperty As String)
        Dim objMailSettings As Base.ISSBaseMailServerSettings = Base.ISSBaseMailServerSettings.GetInstance(Session)
        Dim smpClient As System.Net.Mail.SmtpClient
        Dim smmMailMessage As System.Net.Mail.MailMessage
        Dim smaToAddress As System.Net.Mail.MailAddress
        Dim smaFromAddress As System.Net.Mail.MailAddress
        Dim objNotificationEventArgument As New NotificationEventArgument
        Dim objNotificationTemplateArgument As New NotificationTemplateArgument
        If Me.SendTo IsNot Nothing Then
            If objMailSettings.ServerAddress IsNot Nothing Then
                objNotificationTemplateArgument.NotificationTemplate = Me
                objNotificationEventArgument.NotificationStage = NotificationStage
                objNotificationEventArgument.NotificationTemplate = Me
                objNotificationEventArgument.IsHandled = False
                RaiseEvent CustomNotificationTemplate(objNotificationTemplateArgument)
                RaiseEvent HandleNotification(objNotificationEventArgument)
                If objNotificationEventArgument.IsHandled = False Then
                    smpClient = New System.Net.Mail.SmtpClient(objMailSettings.ServerAddress)
                    If objMailSettings.MailServerUsername > String.Empty Then
                        smpClient.Credentials = New System.Net.NetworkCredential(objMailSettings.MailServerUsername, objMailSettings.MailServerPassword)
                    End If
                    smaToAddress = New System.Net.Mail.MailAddress(GetReplacementTokens(Me.SendTo, EffectedObject, ChangedProperty))
                    smaFromAddress = New System.Net.Mail.MailAddress(GetReplacementTokens(objMailSettings.EmailFromAddress, EffectedObject, ChangedProperty), GetReplacementTokens(objMailSettings.EmailFromName, EffectedObject, ChangedProperty))
                    smmMailMessage = New System.Net.Mail.MailMessage(smaFromAddress, smaToAddress)
                    For Each objToAddressProperty As ISSBaseNotificationPropertyEmailTemplate In Me.SendToProperties
                        If objToAddressProperty.Include = True Then
                            If objToAddressProperty.PropertyValue.GetValue(EffectedObject, Nothing) IsNot Nothing AndAlso objToAddressProperty.PropertyValue.GetValue(EffectedObject, Nothing).ToString > String.Empty Then
                                smmMailMessage.To.Add(New System.Net.Mail.MailAddress(objToAddressProperty.PropertyValue.GetValue(EffectedObject, Nothing).ToString))
                            End If
                        End If
                    Next
                    smmMailMessage.Body = GetReplacementTokens(Me.NotificatonTemplate, EffectedObject, ChangedProperty)
                    
                    smmMailMessage.Subject = GetReplacementTokens(Me.NotificationSubject, EffectedObject, ChangedProperty)
                    smpClient.Send(smmMailMessage)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Persistent Properties"


    Private _mNotificationName As String
    Private _mNotificationSubject As String


    Private _mNotificationType As NotificationTypes
    Private _mNotificatonTemplate As String

    Private _mObjectCustomization As ISSBaseBusinessRules
    Private _mSendTo As String
    <Size(255)> _
    Public Property NotificationName() As String
        Get
            Return _mNotificationName
        End Get
        Set(ByVal value As String)
            If _mNotificationName = value Then
                Return
            End If
            _mNotificationName = value
        End Set
    End Property
    <Size(255)> _
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("ObjectCustomization.ObjectType")>
    Public Property NotificationSubject() As String
        Get
            Return _mNotificationSubject
        End Get
        Set(ByVal value As String)
            If _mNotificationSubject = value Then
                Return
            End If
            _mNotificationSubject = value
        End Set
    End Property
    <RuleRequiredField("NotificationTemplate.NotificationType", DefaultContexts.Save, CustomMessageTemplate:="Notification Type is required.")> _
    Public Property NotificationType() As NotificationTypes
        Get
            Return _mNotificationType
        End Get
        Set(ByVal value As NotificationTypes)
            If _mNotificationType = value Then
                Return
            End If
            _mNotificationType = value
        End Set
    End Property
    <Size(SizeAttribute.Unlimited)> _
    <ISS.Base.Attributes.Editors.TextEditor.AllowPropertyOfTypeInsert("ObjectCustomization.ObjectType")>
    Public Property NotificatonTemplate() As String
        Get
            Return _mNotificatonTemplate
        End Get
        Set(ByVal value As String)
            If _mNotificatonTemplate = value Then
                Return
            End If
            _mNotificatonTemplate = value
        End Set
    End Property
    <Association("ObjectCustomization-NotificationTemplates")> _
    <Xml.Serialization.XmlIgnore()> _
    Public Property ObjectCustomization() As ISSBaseBusinessRules
        Get
            Return _mObjectCustomization
        End Get
        Set(ByVal value As ISSBaseBusinessRules)
            If _mObjectCustomization Is value Then
                Return
            End If
            _mObjectCustomization = value
            If Me.IsLoading = False Then
                BuildDefaultProperties()
            End If
        End Set
    End Property
    <Size(255)> _
    Public Property SendTo() As String
        Get
            Return _mSendTo
        End Get
        Set(ByVal value As String)
            If _mSendTo = value Then
                Return
            End If
            _mSendTo = value
        End Set
    End Property
#End Region

#Region "Enumerations"

    Public Enum NotificationStages
        ObjectChange = 0
        ObjectDelete = 1
        WorkflowEnter = 2
        WorkflowLeave = 3
    End Enum
    Public Enum NotificationTypes
        Email = 0
    End Enum
#End Region

#Region "Associations"
    <Association("NotificationTemplate-NotificationPropertyEmailTemplate")> _
    <Aggregated()> _
    Public ReadOnly Property SendToProperties() As XPCollection(Of ISSBaseNotificationPropertyEmailTemplate)
        Get
            Return GetCollection(Of ISSBaseNotificationPropertyEmailTemplate)("SendToProperties")
        End Get
    End Property
#End Region

#Region "Events"
    Public Event CustomNotificationTemplate(ByRef NotificatonTemplateArgument As NotificationTemplateArgument)
    Public Event HandleNotification(ByRef NotificatonEventArgument As NotificationEventArgument)
#End Region

End Class
