Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("MailSettings")> _
Public Class ISSBaseMailServerSettings
    Inherits BaseObject

    Public Sub New()
        MyBase.New()

    End Sub

#Region "Behaviors"

    Public Shared Function GetInstance(ByVal session As Session) As ISSBaseMailServerSettings
        Dim objMailServerSettings As ISSBaseMailServerSettings = session.FindObject(GetType(ISSBaseMailServerSettings), Nothing)
        If objMailServerSettings Is Nothing Then
            objMailServerSettings = New ISSBaseMailServerSettings(session)
            objMailServerSettings.Save()
        End If
        Return objMailServerSettings
    End Function
    Protected Sub New(ByVal session As Session)
        MyBase.New(session)
        
    End Sub
#End Region

#Region "Persistent Properties"
    Private _mEmailFromAddress As String
    Private _mEmailFromName As String
    Private _mMailServerPassword As String
    Private _mMailServerUsername As String
    Private _mServerAddress As String

    <Size(255)> _
    Public Property EmailFromAddress() As String
        Get
            Return _mEmailFromAddress
        End Get
        Set(ByVal value As String)
            If _mEmailFromAddress = value Then
                Return
            End If
            _mEmailFromAddress = value
        End Set
    End Property
    <Size(255)> _
    Public Property EmailFromName() As String
        Get
            Return _mEmailFromName
        End Get
        Set(ByVal value As String)
            If _mEmailFromName = value Then
                Return
            End If
            _mEmailFromName = value
        End Set
    End Property
    <Size(255)> _
    Public Property MailServerPassword() As String
        Get
            Return _mMailServerPassword
        End Get
        Set(ByVal value As String)
            If _mMailServerPassword = value Then
                Return
            End If
            _mMailServerPassword = value
        End Set
    End Property
    <Size(255)> _
    Public Property MailServerUsername() As String
        Get
            Return _mMailServerUsername
        End Get
        Set(ByVal value As String)
            If _mMailServerUsername = value Then
                Return
            End If
            _mMailServerUsername = value
        End Set
    End Property
    <Size(255)> _
    Public Property ServerAddress() As String
        Get
            Return _mServerAddress
        End Get
        Set(ByVal value As String)
            If _mServerAddress = value Then
                Return
            End If
            _mServerAddress = value
        End Set
    End Property
#End Region

End Class
