Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.Net

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
<DefaultClassOptions()> _
Public Class MailSettings ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    Protected Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Shared Function GetInstance(ByVal session As Session)
        Dim xpoMailSettings As MailSettings = session.FindObject(Of MailSettings)(Nothing)
        If xpoMailSettings Is Nothing Then
            xpoMailSettings = New MailSettings(session)
        End If
        Return xpoMailSettings
    End Function
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        SmtpPort = 25
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub

    Public Enum ServerTypes
        Smtp = 0
    End Enum

    ' Fields...
    Private _mServerType As ServerTypes
    Public Property ServerType As ServerTypes
        Get
            Return _mServerType
        End Get
        Set(ByVal Value As ServerTypes)
            SetPropertyValue("ServerType", _mServerType, Value)
        End Set
    End Property

    Private _mSmtpServer As String
    <Size(255)>
    Public Property SmtpServer As String
        Get
            Return _mSmtpServer
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SmtpServer", _mSmtpServer, Value)
        End Set
    End Property
    Private _mSmtpPort As Integer
    Public Property SmtpPort As Integer
        Get
            Return _mSmtpPort
        End Get
        Set(ByVal Value As Integer)
            SetPropertyValue("SmtpPort", _mSmtpPort, Value)
        End Set
    End Property
    Private _mSmtpDomainName As String
    <Size(255)>
    Public Property SmtpDomainName As String
        Get
            Return _mSmtpDomainName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SmtpDomainName", _mSmtpDomainName, Value)
        End Set
    End Property
    
    Private _mSmtpUserName As String
    <Size(255)>
    Public Property SmtpUserName As String
        Get
            Return _mSmtpUserName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SmtpUserName", _mSmtpUserName, Value)
        End Set
    End Property
    Private _mSmtpPassword As String
    <Size(255)>
    <PasswordPropertyText(True)>
    Public Property SmtpPassword As String
        Get
            Return _mSmtpPassword
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("SmtpPassword", _mSmtpPassword, Value)
        End Set
    End Property
    Private _mDefaultFromAddress As String
    <Size(255)>
    Public Property DefaultFromAddress As String
        Get
            Return _mDefaultFromAddress
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("DefaultFromAddress", _mDefaultFromAddress, Value)
        End Set
    End Property
    
    Private _mUseSSL As Boolean
    Public Property UseSSL As Boolean
        Get
            Return _mUseSSL
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("UseSSL", _mUseSSL, Value)
        End Set
    End Property
    
    Protected Overrides Sub OnChanged(propertyName As String, oldValue As Object, newValue As Object)
        MyBase.OnChanged(propertyName, oldValue, newValue)
        If propertyName = "UseSSL" Then
            If UseSSL = True Then
                SmtpPort = 587
            Else
                SmtpPort = 25
            End If
        End If
    End Sub

    Public Function GetMailClient() As System.Net.Mail.SmtpClient
        Dim smcClient As New System.Net.Mail.SmtpClient
        With smcClient
            .Host = SmtpServer
            .Port = SmtpPort
            If SmtpUserName > String.Empty Then
                .Credentials = New NetworkCredential(SmtpUserName,SmtpPassword)
            End If
        End With
        Return smcClient
    End Function

End Class
