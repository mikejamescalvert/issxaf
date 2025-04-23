Imports Microsoft.VisualBasic
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports System.Collections
Imports System.Collections.Generic
Imports MasterProvider.Module.Permissions
Imports DevExpress.ExpressApp.Security.ClientServer
Imports DevExpress.ExpressApp.Security.ClientServer.Wcf
Imports System.ServiceModel

Public Class CustomProviderContainer




    Private _mAutoCreate As AutoCreateOption
    Property AutoCreate As AutoCreateOption
        Get
            Return _mAutoCreate
        End Get
        Set(ByVal Value As AutoCreateOption)
            _mAutoCreate = Value
            If _mDataStore IsNot Nothing Then
                _mDataStore = Nothing
            End If
        End Set
    End Property
    Public Enum ProviderConnectionTypes
        SQLServer
        WebService
        InMemoryDataStore
        WcfService
    End Enum

    Private Shared MemoryDataStore As New InMemoryDataStore(AutoCreateOption.DatabaseAndSchema)

#Region "Properties"
    Public Property AssemblyName() As String
    Public Property DisplayName() As String
    Public Property ConnectionStringName() As String
    Public ReadOnly Property ConnectionType As ProviderConnectionTypes
        Get
            If ConnectionString = String.Empty Then
                Return ProviderConnectionTypes.SQLServer
            End If
            If ConnectionString.StartsWith("http://") Then
                Return ProviderConnectionTypes.WebService
            End If
            If ConnectionString = "Memory" Then
                Return ProviderConnectionTypes.InMemoryDataStore
            End If
            If ConnectionString.StartsWith("net.tcp://") Then
                Return ProviderConnectionTypes.WcfService
            End If
            Return ProviderConnectionTypes.SQLServer
        End Get
    End Property

    Private _mMemoryUpdated As Boolean
    Property MemoryUpdated As Boolean
        Get
            Return _mMemoryUpdated
        End Get
        Set(ByVal Value As Boolean)
            _mMemoryUpdated = Value
        End Set
    End Property

    Public Property IgnoreSchemaConstraints() As Boolean
    Private _mEffectedTableNames As New List(Of String)
    Public Property EffectedTableNames() As List(Of String)
        Get
            Return _mEffectedTableNames
        End Get
        Set(ByVal value As List(Of String))
            If _mEffectedTableNames Is value Then
                Return
            End If
            _mEffectedTableNames = value
        End Set
    End Property
    Private _mReflectionDictionary As New ReflectionDictionary
    Public Property ReflectionDictionary() As ReflectionDictionary
        Get
            Return _mReflectionDictionary
        End Get
        Set(ByVal value As ReflectionDictionary)
            If _mReflectionDictionary Is value Then
                Return
            End If
            _mReflectionDictionary = value
        End Set
    End Property
    Public ReadOnly Property RegistryLocation As String
        Get
            If System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName) Is Nothing Then
                Return String.Empty
            End If
            If System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString.StartsWith("HKEY") Then
                Return System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString
            End If
            Return String.Empty
        End Get
    End Property
    Private _mRegistryLoaded As Boolean
    Private _mRegistryNeedsUpdate As Boolean
    Public ReadOnly Property RegistryNeedsUpdate As Boolean
        Get
            If _mRegistryLoaded = False AndAlso IsRegistryEntry = True Then
                FetchFromRegistry()
            End If
            Return _mRegistryNeedsUpdate
        End Get
    End Property
    Public ReadOnly Property IsRegistryEntry As Boolean
        Get
            If System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName) Is Nothing Then
                Return False
            End If
            If System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString.StartsWith("HKEY") Then
                Return True
            End If
            Return False
        End Get
    End Property
    Public Property ErrorDuringConnectionLoad() As Boolean
    Private _mConnectionString As String
    Public Shared Event OnDataStoreLoading(ByVal Args As ConnectionLoadingArgs)
    Public Shared Event OnConnectionStringLoading(ByVal Args As ConnectionStringLoadingArgs)
    Public Class ConnectionLoadingArgs
        Inherits EventArgs
        ' Fields...
        Private _mConnectionStringName As String
        Public Property ConnectionStringName As String
            Get
                Return _mConnectionStringName
            End Get
            Set(ByVal Value As String)
                _mConnectionStringName = Value
            End Set
        End Property

        Private _mProvider As Object
        Public Property Provider As Object
            Get
                Return _mProvider
            End Get
            Set(ByVal Value As Object)
                _mProvider = Value
            End Set
        End Property
        Private _mCustomDataStore As IDataStore



        Property CustomDataStore As IDataStore
            Get
                Return _mCustomDataStore
            End Get
            Set(ByVal Value As IDataStore)
                _mCustomDataStore = Value
            End Set
        End Property



    End Class
    Public Class ConnectionStringLoadingArgs
        Inherits EventArgs
        ' Fields...
        Private _mConnectionStringName As String
        Public Property ConnectionStringName As String
            Get
                Return _mConnectionStringName
            End Get
            Set(ByVal Value As String)
                _mConnectionStringName = Value
            End Set
        End Property
        Private _mResultingConnectionString As String
        Public Property ResultingConnectionString As String
            Get
                Return _mResultingConnectionString
            End Get
            Set(ByVal Value As String)
                _mResultingConnectionString = Value
            End Set
        End Property

    End Class
    Public Property ConnectionString As String
        Get
            If _mConnectionString = String.Empty Then
                If System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName) Is Nothing Then
                    _mConnectionString = String.Empty
                End If
                If System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString.StartsWith("HKEY") Then
                    FetchFromRegistry()
                Else
                    Dim ConnectionStringLoadingArgs As New ConnectionStringLoadingArgs
                    With ConnectionStringLoadingArgs
                        .ConnectionStringName = ConnectionStringName
                        .ResultingConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString
                    End With
                    RaiseEvent OnConnectionStringLoading(ConnectionStringLoadingArgs)
                    _mConnectionString = ConnectionStringLoadingArgs.ResultingConnectionString
                End If
            End If
            Return _mConnectionString
        End Get
        Set(ByVal Value As String)
            _mConnectionString = Value
        End Set
    End Property
    Private _mDataLayer As SimpleDataLayer
    Private _mDataStore As IDataStore
    Private _mWebStore As WebServiceDataStore
    Private _mConnectionAttempt As Integer = 0
    Public ReadOnly Property DataStore() As IDataStore
        Get
            _mConnectionAttempt = 0
            While _mConnectionAttempt < 3
                If _mWebStore IsNot Nothing Then
                    Return _mWebStore
                End If
                If _mDataStore IsNot Nothing Then
                    Return _mDataStore
                End If
                SetupDataStore()
                _mConnectionAttempt += 1
            End While

            Throw New Exception("Cannot load data store from settings!")
        End Get
    End Property
    Private _mTables As New List(Of DBTable)
    Public Property Tables() As List(Of DBTable)
        Get
            Return _mTables
        End Get
        Set(ByVal value As List(Of DBTable))
            If _mTables Is value Then
                Return
            End If
            _mTables = value
        End Set
    End Property
#End Region

#Region "Behaviors"
    Public Sub New(ByVal AutoCreate As AutoCreateOption)
        Me.AutoCreate = AutoCreate
    End Sub
    Public Sub New(ByVal AssemblyName As String, ByVal ConnectionStringName As String, ByVal IgnoreSchemaConstraints As Boolean, ByVal DisplayName As String, ByVal AutoCreate As AutoCreateOption)
        Me.AssemblyName = AssemblyName
        Me.ConnectionStringName = ConnectionStringName
        Me.IgnoreSchemaConstraints = IgnoreSchemaConstraints
        Me.DisplayName = DisplayName
        Me.AutoCreate = AutoCreate
    End Sub
    Public Sub New(ByVal AssemblyName As String, ByVal ConnectionStringName As String, ByVal IgnoreSchemaConstraints As Boolean, ByVal DisplayName As String, ByVal ConnectionString As String, ByVal AutoCreate As AutoCreateOption)
        Me.AssemblyName = AssemblyName
        Me.ConnectionStringName = ConnectionStringName
        Me.IgnoreSchemaConstraints = IgnoreSchemaConstraints
        Me.DisplayName = DisplayName
        Me.ConnectionString = ConnectionString
        Me.AutoCreate = AutoCreate
    End Sub
    Public Sub New(ByVal AssemblyName As String, ByVal ConnectionStringName As String, ByVal IgnoreSchemaConstraints As Boolean, ByVal AutoCreate As AutoCreateOption)
        Me.AssemblyName = AssemblyName
        Me.ConnectionStringName = ConnectionStringName
        Me.IgnoreSchemaConstraints = IgnoreSchemaConstraints
        Me.AutoCreate = AutoCreate
    End Sub
    Public Sub LoadTableLists(ByVal dictionary As XPDictionary)
        Dim imfFieldInfo As DevExpress.Xpo.Metadata.Helpers.IntermediateObjectFieldInfo
        Dim rpiPropertyInfo As DevExpress.Xpo.Metadata.ReflectionPropertyInfo

        Tables.Clear()
        _mEffectedTableNames.Clear()

        For Each ci As XPClassInfo In dictionary.Classes

            If ci.IsPersistent = False Then
                Continue For
            End If
            If ci.ClassType Is Nothing Then
                For Each objProperty As Object In ci.PersistentProperties
                    If TypeOf objProperty Is DevExpress.Xpo.Metadata.Helpers.IntermediateObjectFieldInfo Then
                        imfFieldInfo = objProperty
                        If imfFieldInfo.MemberType IsNot Nothing AndAlso (imfFieldInfo.MemberType.Assembly.GetName.Name = AssemblyName Or AssemblyName = String.Empty) Then
                            _mEffectedTableNames.Add(ci.TableName)
                            If ConnectionType = ProviderConnectionTypes.InMemoryDataStore Then
                                Tables.Add(ci.Table)
                            End If
                            Exit For
                        End If
                    End If
                Next
            Else
                If ci.AssemblyName = AssemblyName Or AssemblyName = String.Empty Then
                    If ConnectionType = ProviderConnectionTypes.InMemoryDataStore Then
                        Tables.Add(ci.Table)
                    End If
                    _mEffectedTableNames.Add(ci.TableName)
                    For Each objAssocationProperty As Object In ci.AssociationListProperties
                        If TypeOf objAssocationProperty Is DevExpress.Xpo.Metadata.ReflectionPropertyInfo Then
                            rpiPropertyInfo = objAssocationProperty
                            If rpiPropertyInfo.IsAssociationList = True AndAlso rpiPropertyInfo.IntermediateClass IsNot Nothing Then
                                _mEffectedTableNames.Add(rpiPropertyInfo.IntermediateClass.TableName)
                                If ConnectionType = ProviderConnectionTypes.InMemoryDataStore Then
                                    Tables.Add(rpiPropertyInfo.IntermediateClass.Table)
                                End If
                            End If


                        End If
                    Next
                    For Each objProperty As Object In ci.PersistentProperties
                        If TypeOf objProperty Is DevExpress.Xpo.Metadata.Helpers.IntermediateObjectFieldInfo Then
                            imfFieldInfo = objProperty
                            If imfFieldInfo.MemberType IsNot Nothing AndAlso (imfFieldInfo.MemberType.Assembly.GetName.Name = AssemblyName Or AssemblyName = String.Empty) Then
                                If ConnectionType = ProviderConnectionTypes.InMemoryDataStore Then
                                    Tables.Add(ci.Table)
                                End If
                                _mEffectedTableNames.Add(ci.TableName)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
        Next
    End Sub
    Public Sub FetchFromRegistry()
        Dim mppConnection As MPConnectionInformationInCode
        'sshSession.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=temp.mdb;User Id=admin;Password=;"
        mppConnection = New MPConnectionInformationInCode With {.RegistryPath = RegistryLocation}
        mppConnection.ReadConnectionFromRegistry()
        _mConnectionString = mppConnection.GetConnectionStringFromInformation
        If _mConnectionString = String.Empty Then
            _mRegistryNeedsUpdate = True
        Else
            Try
                SetupDataStore()
                _mRegistryNeedsUpdate = False
                _mRegistryLoaded = True
            Catch ex As Exception
                ErrorDuringConnectionLoad = True
                _mRegistryNeedsUpdate = True
            End Try
        End If
        mppConnection = Nothing
    End Sub
    'Private _mContainer As Object
    Public Property CustomProvider As Object
    Public Sub SetupDataStore(Optional ByVal Connection As SqlClient.SqlConnection = Nothing)

        Dim ConnectionLoadingArgs As New ConnectionLoadingArgs
        With ConnectionLoadingArgs
            .ConnectionStringName = ConnectionString

        End With
        RaiseEvent OnDataStoreLoading(ConnectionLoadingArgs)

        If ConnectionLoadingArgs.CustomDataStore IsNot Nothing Then

            _mDataStore = ConnectionLoadingArgs.CustomDataStore
            _mDataLayer = New SimpleDataLayer(ReflectionDictionary, ConnectionLoadingArgs.CustomDataStore)
        Else

            Select Case ConnectionType
                Case ProviderConnectionTypes.WebService
                    If _mWebStore IsNot Nothing Then
                        _mWebStore.Dispose()
                        _mWebStore = Nothing
                    End If

                    _mWebStore = New WebServiceDataStore(ConnectionString)
                Case ProviderConnectionTypes.WcfService
                    Dim wcfSecuredClient As New WcfSecuredClient(WcfDataServerHelper.CreateNetTcpBinding(), New EndpointAddress(ConnectionString))

                    Dim securedObjectLayerClient As New MiddleTierSerializableObjectLayerClient(wcfSecuredClient)

                    _mDataStore = securedObjectLayerClient
                    '_mDataStore = XpoDefault.GetConnectionProvider(ConnectionString, AutoCreate)
                    'Throw New Exception("not implemented yet")
                Case ProviderConnectionTypes.SQLServer

                    If _mDataLayer IsNot Nothing Then
                        _mDataLayer.Dispose()
                        _mDataLayer = Nothing
                    End If
                    If _mDataStore IsNot Nothing Then
                        _mDataStore = Nothing
                    End If
                    '_mDataStore = New CustomSQLProvider(New System.Data.SqlClient.SqlConnection(ConnectionString), AutoCreateOption.DatabaseAndSchema)

                    If ConnectionLoadingArgs.Provider Is Nothing Then
                        _mDataStore = XpoDefault.GetConnectionProvider(ConnectionString, AutoCreate)
                        If TypeOf _mDataStore Is MSSqlConnectionProvider Then
                            _mDataStore = New CustomSQLProvider(New System.Data.SqlClient.SqlConnection(ConnectionString), AutoCreate)

                        End If
                    Else
                        'If ConnectionLoadingArgs.Provider IsNot Nothing Then
                        '    _mContainer = ConnectionLoadingArgs.Provider
                        'End If
                        CustomProvider = ConnectionLoadingArgs.Provider
                        If TypeOf ConnectionLoadingArgs.Provider Is Odbc.OdbcConnection Then
                            _mDataStore = XpoDefault.GetConnectionProvider(CType(ConnectionLoadingArgs.Provider, Odbc.OdbcConnection).ConnectionString, AutoCreate)
                        Else
                            _mDataStore = XpoDefault.GetConnectionProvider(ConnectionLoadingArgs.Provider, AutoCreate)
                            If TypeOf _mDataStore Is MSSqlConnectionProvider Then
                                _mDataStore = New CustomSQLProvider(New System.Data.SqlClient.SqlConnection(ConnectionString), AutoCreate)
                            End If
                        End If

                    End If
                    _mDataLayer = New SimpleDataLayer(ReflectionDictionary, _mDataStore)
                Case ProviderConnectionTypes.InMemoryDataStore
                    _mDataStore = MemoryDataStore
                    _mDataLayer = New SimpleDataLayer(ReflectionDictionary, _mDataStore)
                Case Else
                    If _mDataLayer IsNot Nothing Then
                        _mDataLayer.Dispose()
                        _mDataLayer = Nothing
                    End If
                    If _mDataStore IsNot Nothing Then
                        _mDataStore = Nothing
                    End If

                    _mDataStore = XpoDefault.GetConnectionProvider(ConnectionString, AutoCreate)
                    _mDataLayer = New SimpleDataLayer(ReflectionDictionary, _mDataStore)
            End Select
        End If

    End Sub
    Public Function IsTableInList(ByVal TableName As String)
        For Each oTable In Tables
            If oTable.Name = TableName Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function UpdateSchema() As UpdateSchemaResult
        Dim NonReadonlyTables As New List(Of DBTable)
        Dim oClassInfo As XPClassInfo
        Dim oapPermission As System.Nullable(Of ObjectPermissionType)

        For Each oTable In Tables.ToArray
            If IgnoreSchemaConstraints = True Or ConnectionType = ProviderConnectionTypes.InMemoryDataStore Then
                NonReadonlyTables.Add(oTable)
            Else
                oClassInfo = Helpers.DataStoreHelper.GetClassInfoFromTableName(oTable.Name)
                If oClassInfo IsNot Nothing Then
                    oapPermission = MasterDataStore.GetObjectPermission(oClassInfo.ClassType)
                    If Helpers.DataStoreHelper.IsCustomDataStoreTable(oTable.Name) = True Then
                        If oapPermission.HasValue = False OrElse (oapPermission.Value = ObjectPermissionType.OnlyAllowDataModification Or oapPermission.Value = ObjectPermissionType.NoAccess) Then
                            Continue For
                        End If
                    Else
                        If oapPermission.HasValue = True AndAlso (oapPermission.Value = ObjectPermissionType.OnlyAllowDataModification Or oapPermission.Value = ObjectPermissionType.NoAccess) Then
                            Continue For
                        End If
                    End If
                End If


                NonReadonlyTables.Add(oTable)
            End If
        Next
        Return DataStore.UpdateSchema(False, NonReadonlyTables.ToArray)
    End Function
#End Region


End Class
