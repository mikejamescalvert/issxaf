Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("NotificationPropertyEmailTemplate")> _
<Serializable()> _
Public Class ISSBaseNotificationPropertyEmailTemplate
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub

#Region "Behaviors"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
#End Region

#Region "Persistent Properties"

    Private _mInclude As Boolean

    Private _mNotificationTemplate As ISSBaseNotificationTemplate
    Private _mPropertyName As String
    Public Property Include() As Boolean
        Get
            Return _mInclude
        End Get
        Set(ByVal value As Boolean)
            If _mInclude = value Then
                Return
            End If
            _mInclude = value
        End Set
    End Property
    <Association("NotificationTemplate-NotificationPropertyEmailTemplate")> _
    <Xml.Serialization.XmlIgnore()> _
    Public Property NotificationTemplate() As ISSBaseNotificationTemplate
        Get
            Return _mNotificationTemplate
        End Get
        Set(ByVal value As ISSBaseNotificationTemplate)
            If _mNotificationTemplate Is value Then
                Return
            End If
            _mNotificationTemplate = value
        End Set
    End Property

    <Browsable(False)> _
    Public Property PropertyName() As String
        Get
            Return _mPropertyName
        End Get
        Set(ByVal value As String)
            If String.Compare(_mPropertyName, value, False) = 0 Then
                Return
            End If
            _mPropertyName = value
        End Set
    End Property
#End Region

#Region "Non Persistent Properties"
    <RuleRequiredField("NotificationTemplate.PropertyRequired", DefaultContexts.Save, "Property Is Required")> _
    Public Property PropertyValue() As System.Reflection.PropertyInfo
        Get
            If PropertyName Is Nothing Then
                Return Nothing
            End If
            If NotificationTemplate IsNot Nothing AndAlso NotificationTemplate.ObjectCustomization IsNot Nothing Then
                Return NotificationTemplate.ObjectCustomization.ObjectType.GetProperty(Me.PropertyName)
            End If
            Return Nothing
        End Get
        Set(ByVal value As System.Reflection.PropertyInfo)
            Me.PropertyName = value.Name
        End Set
    End Property
#End Region

End Class
