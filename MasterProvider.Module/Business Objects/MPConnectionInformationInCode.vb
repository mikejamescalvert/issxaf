Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

''' <summary>
''' A base connection information class used to fetch information when a registry entry is specified as the connection string
''' </summary>
''' <remarks>A non persistent object, only used by controllers.  Requires Conditional Editor States.</remarks>
Public Class MPConnectionInformationInCode

    ''' <summary>
    ''' Defines the supported connection types within XAF
    ''' </summary>
    ''' <remarks>Primarily used in setting the type property</remarks>
    Public Enum ConnectionTypes
        SQL
        Access
        WebService
    End Enum

#Region "Behaviors"
    Public Sub New()
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Function GetConnectionStringFromInformation() As String
        Dim strConnection As String = String.Empty
        Select Case ConnectionType
            Case ConnectionTypes.Access
                If Password > String.Empty Then
                    strConnection = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", DatabaseLocation, Password)
                Else
                    strConnection = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User Id=admin;Password=;", DatabaseLocation)
                End If
            Case ConnectionTypes.SQL
                If Me.TrustedConnection = False Then
                    strConnection = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};Pooling=False;", ServerName, DatabaseName, UserName, Password)
                Else
                    strConnection = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;Pooling=False;", ServerName, DatabaseName)
                End If
            Case ConnectionTypes.WebService
                Return URL
        End Select
        Return strConnection
    End Function
    Public Sub WriteConnectionToRegistry()
        'RegistryHelper.WriteConnectionStringToRegistryPath(RegistryPath, GetConnectionStringFromInformation)
        Dim intValue As Integer = ConnectionType
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, intValue.ToString, "ConnectionType")
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, DatabaseLocation, "DBLocation")
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, DatabaseName, "DB")
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, Password, "Password")
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, ServerName, "ServerName")
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, TrustedConnection.ToString, "TrustedConnection")
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, URL, "URL")
        Helpers.RegistryHelper.WriteValueToRegistryPath(RegistryPath, UserName, "UserName")
    End Sub
    Public Sub ResetConnection()
        ConnectionType = ConnectionTypes.SQL
        Me.DatabaseLocation = String.Empty
        Me.DatabaseName = String.Empty
        Me.Password = String.Empty
        Me.ServerName = String.Empty
        Me.TrustedConnection = False
        Me.URL = String.Empty
        Me.UserName = String.Empty
        WriteConnectionToRegistry()

    End Sub
    Public Sub ReadConnectionFromRegistry()
        Integer.TryParse(Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "ConnectionType"), ConnectionType)
        DatabaseLocation = Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "DBLocation")
        DatabaseName = Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "DB")
        Password = Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "Password")
        ServerName = Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "ServerName")
        Boolean.TryParse(Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "TrustedConnection"), TrustedConnection)
        URL = Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "URL")
        UserName = Helpers.RegistryHelper.ReadValueFromRegistryPath(RegistryPath, "UserName")
    End Sub
    Public Sub ValidateConnection()
        Dim sshSession As Session
        Try
            If ConnectionType = ConnectionTypes.SQL Or ConnectionType = ConnectionTypes.Access Then
                sshSession = New Session
                sshSession.ConnectionString = GetConnectionStringFromInformation()
                sshSession.Connect()

            Else
                sshSession = New Session(New SimpleDataLayer(New WebServiceDataStore(GetConnectionStringFromInformation())))
                sshSession.Connect()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region "Properties"
    Private _mConnectionStringName As String
    Public Property ConnectionStringName As String
        Get
            Return _mConnectionStringName
        End Get
        Set(ByVal Value As String)
            _mConnectionStringName = Value
        End Set
    End Property
    Private _mAccepted As Boolean
    <VisibleInDetailView(False)> _
<VisibleInListView(False)> _
    Public Property Accepted As Boolean
        Get
            Return _mAccepted
        End Get
        Set(ByVal Value As Boolean)
            _mAccepted = Value
        End Set
    End Property
    Private _mRegistryPath As String
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    Public Property RegistryPath As String
        Get
            Return _mRegistryPath
        End Get
        Set(ByVal Value As String)
            _mRegistryPath = Value
        End Set
    End Property
    Private _mConnectionType As ConnectionTypes
    <ImmediatePostData()> _
        <VisibleInListView(False)> _
    Public Property ConnectionType As ConnectionTypes
        Get
            Return _mConnectionType
        End Get
        Set(ByVal Value As ConnectionTypes)
            _mConnectionType = Value
        End Set
    End Property
    Private _mServerName As String
    <VisibleInListView(False)> _
    Public Property ServerName As String
        Get
            Return _mServerName
        End Get
        Set(ByVal Value As String)
            _mServerName = Value
        End Set
    End Property
    Private _mDatabaseName As String
    <VisibleInListView(False)> _
    Public Property DatabaseName As String
        Get
            Return _mDatabaseName
        End Get
        Set(ByVal Value As String)
            _mDatabaseName = Value
        End Set
    End Property
    Private _mUserName As String
    <VisibleInListView(False)> _
    Public Property UserName As String
        Get
            Return _mUserName
        End Get
        Set(ByVal Value As String)
            _mUserName = Value
        End Set
    End Property
    Private _mPassword As String
    <PasswordPropertyText(True)> _
        <VisibleInListView(False)> _
    Public Property Password As String
        Get
            Return _mPassword
        End Get
        Set(ByVal Value As String)
            _mPassword = Value
        End Set
    End Property
    Private _mTrustedConnection As Boolean
    <ImmediatePostData()> _
        <VisibleInListView(False)> _
    Public Property TrustedConnection As Boolean
        Get
            Return _mTrustedConnection
        End Get
        Set(ByVal Value As Boolean)
            _mTrustedConnection = Value
        End Set
    End Property
    Private _mDatabaseLocation As String
    <VisibleInListView(False)> _
    Public Property DatabaseLocation As String
        Get
            Return _mDatabaseLocation
        End Get
        Set(ByVal Value As String)
            _mDatabaseLocation = Value
        End Set
    End Property
    Private _mURL As String
    <VisibleInListView(False)> _
    Public Property URL As String
        Get
            Return _mURL
        End Get
        Set(ByVal Value As String)
            _mURL = Value
        End Set
    End Property
    Private _mDisplayName As String
    Public Property DisplayName As String
        Get
            Return _mDisplayName
        End Get
        Set(ByVal Value As String)
            _mDisplayName = Value
        End Set
    End Property

#End Region

End Class
