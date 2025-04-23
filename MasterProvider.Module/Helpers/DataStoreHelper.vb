Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata
Imports System.Collections.Generic
Imports System.Resources
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports System.Linq

Namespace Helpers
    Public Class DataStoreHelper

        Private Shared _mApplicationContainer As CustomProviderContainer
        Public Shared ReadOnly Property ApplicationContainer As CustomProviderContainer
            Get
                Return _mApplicationContainer
            End Get
        End Property

        Public Shared ReadOnly Property ApplicationConnectionString() As String
            Get
                Return ApplicationContainer.ConnectionString
            End Get
        End Property

        Public Shared Event OnProviderSetup(ByVal ProviderSetupEventArgs As ProviderSetupEventArgs)

        Public Class ProviderSetupEventArgs
            Inherits EventArgs

            Public Property ApplicationConnectionStringName As String = "ConnectionString"
            Public Property ApplicationConnectionString As String = String.Empty
            Public Property CustomProviders As New List(Of CustomProvider)

            Public Class CustomProvider
                Public Property AssemblyName As String
                Public Property ConnectionStringName As String
                Public Property ConnectionString As String
                Public Property DisplayName As String
                Public Property IgnoreSchemaConstraints As Boolean
            End Class

        End Class

        Private Shared Sub RegisterProvider(ByVal AssemblyName As String, ByVal ConnectionStringName As String, ByVal DisplayName As String, ByVal IgnoreSchemaConstraints As Boolean, ByVal ConnectionString As String, ByVal AutoCreateOption As AutoCreateOption)
            Dim oCustomProviderContainer As CustomProviderContainer = Nothing
            If _mCustomProviderContainerList Is Nothing Then
                _mCustomProviderContainerList = New List(Of CustomProviderContainer)
            End If
            For Each mcpCustomProvider In _mCustomProviderContainerList
                If mcpCustomProvider.AssemblyName = AssemblyName And ConnectionStringName = ConnectionStringName Then
                    oCustomProviderContainer = mcpCustomProvider
                End If
            Next
            If oCustomProviderContainer Is Nothing Then
                oCustomProviderContainer = New CustomProviderContainer(AutoCreateOption)
                oCustomProviderContainer.AssemblyName = AssemblyName
                oCustomProviderContainer.ConnectionStringName = ConnectionStringName
                oCustomProviderContainer.DisplayName = DisplayName
                oCustomProviderContainer.IgnoreSchemaConstraints = IgnoreSchemaConstraints
                oCustomProviderContainer.ConnectionString = ConnectionString
                oCustomProviderContainer.AutoCreate = AutoCreateOption
                _mCustomProviderContainerList.Add(oCustomProviderContainer)
            End If


        End Sub

        Public Shared Sub LoadProviderInformation(ByVal AutoCreateOption As AutoCreateOption)
            Dim evaProviderSetupEventArgs As New ProviderSetupEventArgs
            RaiseEvent OnProviderSetup(evaProviderSetupEventArgs)
            'CustomProviderContainerList.Clear()

            If _mCustomProviderContainerList Is Nothing Then
                _mCustomProviderContainerList = New List(Of CustomProviderContainer)
            End If

            evaProviderSetupEventArgs.CustomProviders.ForEach(
                Sub(m) RegisterProvider(m.AssemblyName, m.ConnectionStringName, m.DisplayName, m.IgnoreSchemaConstraints, m.ConnectionString, AutoCreateOption)
                    )

            If _mApplicationContainer Is Nothing OrElse evaProviderSetupEventArgs.ApplicationConnectionString > String.Empty OrElse evaProviderSetupEventArgs.ApplicationConnectionStringName <> "ConnectionString" Then
                _mApplicationContainer = New CustomProviderContainer(String.Empty,
                                                                     evaProviderSetupEventArgs.ApplicationConnectionStringName,
                                                                     True,
                                                                     "Application Connection",
                                                                     AutoCreateOption)
                If evaProviderSetupEventArgs.ApplicationConnectionString > String.Empty Then
                    _mApplicationContainer.ConnectionString = evaProviderSetupEventArgs.ApplicationConnectionString
                End If
            End If

            Dim mpiMasterProviderInfo As MasterProviderSettings = MasterProviderSettings.GetInstance
            If mpiMasterProviderInfo IsNot Nothing Then
                For Each asiAssemblyInfo As AssemblyInformation In mpiMasterProviderInfo.Assemblies
                    'If evaProviderSetupEventArgs.CustomProviders.FirstOrDefault(Function (m) m.AssemblyName = asiAssemblyInfo.AssemblyName) Is Nothing
                    RegisterProvider(asiAssemblyInfo.AssemblyName,
                                         asiAssemblyInfo.ConnectionStringName,
                                         asiAssemblyInfo.GetDisplayName,
                                         IIf(asiAssemblyInfo.IgnoreSchemaContraints = Nothing OrElse asiAssemblyInfo.IgnoreSchemaContraints.ToLower <> "true", False, True),
                                         String.Empty,
                                     AutoCreateOption)
                    'End If
                Next
            End If

        End Sub

        Private Shared _mCustomProviderContainerList As List(Of CustomProviderContainer)
        Public Shared ReadOnly Property CustomProviderContainerList() As List(Of CustomProviderContainer)
            Get
                If _mCustomProviderContainerList Is Nothing Then
                    LoadProviderInformation(AutoCreateOption.None)
                End If
                Return _mCustomProviderContainerList
            End Get
        End Property
        Public Shared Sub LoadProviderTableNames(ByVal dictionary As XPDictionary)
            If CustomProviderContainerList Is Nothing Then
                _mCustomProviderContainerList = New List(Of CustomProviderContainer)()
            End If
            CustomProviderContainerList.ForEach(Sub(m) m.LoadTableLists(dictionary))
        End Sub
        Public Shared Function GetCustomProviderByConnectionStringName(ByVal ConnectionStringName As String) As CustomProviderContainer
            Return CustomProviderContainerList.FirstOrDefault(Function (m) m.ConnectionStringName = ConnectionStringName)
        End Function
        Public Shared Function GetCustomProviderByAssemblyName(ByVal AssemblyName As String) As CustomProviderContainer
            Return CustomProviderContainerList.FirstOrDefault(Function (m) m.AssemblyName = AssemblyName)
        End Function
        Public Shared Function GetCustomProviderConnectionStringByConnectionStringName(ByVal ConnectionStringName As String) As String
            Dim oContainer As CustomProviderContainer = GetCustomProviderByConnectionStringName(ConnectionStringName)
            Return IIf(oContainer IsNot Nothing, oContainer.ConnectionString,String.Empty)
        End Function
        Public Shared Function GetCustomProviderConnectionStringByAssemblyName(ByVal AssemblyName As String) As String
            Dim oContainer As CustomProviderContainer = GetCustomProviderByAssemblyName(AssemblyName)
            Return IIf(oContainer IsNot Nothing, oContainer.ConnectionString,String.Empty)
        End Function


        Public Shared Function IsCustomDataStoreTable(ByVal TableName As String) As Boolean
            Return CustomProviderContainerList.Any(Function (m) m.EffectedTableNames.Any(Function (m2) m2 = TableName))
        End Function


        Public Shared Sub AddTableToCustomProviderContainer(ByRef table As DBTable)
            For Each oCustomProviderContainer In CustomProviderContainerList
                For Each oTableName As String In oCustomProviderContainer.EffectedTableNames
                    If String.Compare(table.Name, oTableName, False) = 0 Then
                        If oCustomProviderContainer.IsTableInList(table.Name) = False Then
                            oCustomProviderContainer.Tables.Add(table)
                        End If

                    End If
                Next
            Next
        End Sub

        Public Shared Sub AddClassToReflectionDictionary(ByVal TableName As String, ByRef ClassType As Type)
            For Each oCustomProviderContainer In CustomProviderContainerList
                oCustomProviderContainer.ReflectionDictionary.QueryClassInfo(ClassType)
            Next
        End Sub

        Public Shared Function GetCustomProviderContainerStoreByTableName(ByVal TableName As String) As CustomProviderContainer
            Dim cpcContainer As CustomProviderContainer = CustomProviderContainerList.FirstOrDefault(Function(m) m.EffectedTableNames.Any(Function(m2) String.Compare(m2, TableName, False) = 0))
            If cpcContainer.ConnectionType = CustomProviderContainer.ProviderConnectionTypes.InMemoryDataStore And cpcContainer.MemoryUpdated = False Then
                'todo: 
                cpcContainer.UpdateSchema()
                cpcContainer.MemoryUpdated = True
            End If
            Return cpcContainer


            'For Each oCustomProviderContainer In CustomProviderContainerList
            '    For Each oTableName As String In oCustomProviderContainer.EffectedTableNames
            '        If String.Compare(TableName, oTableName, False) = 0 Then
            '            Return oCustomProviderContainer
            '        End If
            '    Next
            'Next
            'Return Nothing
        End Function

        Public Shared Function GetClassInfoFromTableName(ByVal TableName As String) As XPClassInfo
            For Each oCustomProviderContainer In CustomProviderContainerList
                For Each oClassInfo As XPClassInfo In oCustomProviderContainer.ReflectionDictionary.Classes
                    If String.Compare(oClassInfo.TableName, TableName, False) = 0 Then
                        Return oClassInfo
                    End If
                Next
            Next
            For Each oClassInfo As XPClassInfo In ApplicationContainer.ReflectionDictionary.Classes
                If String.Compare(oClassInfo.TableName, TableName, False) = 0 Then
                    Return oClassInfo
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function IsTableDataReadonly(ByVal TableName As String) As Boolean
            Dim oCustomProviderContainer As CustomProviderContainer = GetCustomProviderContainerStoreByTableName(TableName)
            Dim oClassInfo As XPClassInfo = GetClassInfoFromTableName(TableName)
            Dim roaReadOnlyAttribute As AllowDataModificationsInMasterProviderAttribute
            If oCustomProviderContainer Is Nothing Then
                Return False
            End If
            If oClassInfo Is Nothing Then
                Return False
            Else
                roaReadOnlyAttribute = oClassInfo.FindAttributeInfo(GetType(AllowDataModificationsInMasterProviderAttribute))
                If roaReadOnlyAttribute Is Nothing Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Public Shared Function IsTableStructureReadonly(ByVal TableName As String) As Boolean
            Dim oCustomProviderContainer As CustomProviderContainer = GetCustomProviderContainerStoreByTableName(TableName)
            Dim oClassInfo As XPClassInfo = GetClassInfoFromTableName(TableName)
            Dim roaReadOnlyAttribute As AllowDatabaseUpdateInMasterProviderAttribute
            If oCustomProviderContainer Is Nothing Then
                Return False
            End If
            If oClassInfo Is Nothing Then
                Return False
            Else
                roaReadOnlyAttribute = oClassInfo.FindAttributeInfo(GetType(AllowDatabaseUpdateInMasterProviderAttribute))
                If roaReadOnlyAttribute Is Nothing Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Public Shared Sub SetupDataStores()
            For Each oCustomProviderContainer In CustomProviderContainerList
                oCustomProviderContainer.SetupDataStore()
            Next
            ApplicationContainer.SetupDataStore()
        End Sub

        Public Shared Function UpdateTableSchemas(ByVal MasterDataStore As MasterDataStore) As UpdateSchemaResult

            Dim usrResult As UpdateSchemaResult = UpdateSchemaResult.SchemaExists
            For Each oCustomProviderContainer In CustomProviderContainerList
                If MasterDataStore.AutoCreateOption = AutoCreateOption.DatabaseAndSchema Or
                    MasterDataStore.AutoCreateOption = AutoCreateOption.SchemaOnly Or
                    oCustomProviderContainer.ConnectionType = CustomProviderContainer.ProviderConnectionTypes.InMemoryDataStore Then
                    If oCustomProviderContainer.UpdateSchema() = UpdateSchemaResult.FirstTableNotExists Then
                        usrResult = UpdateSchemaResult.FirstTableNotExists
                    End If
                End If

                'If oCustomProviderContainer.UpdateSchema(MasterDataStore) = UpdateSchemaResult.FirstTableNotExists Then
                '    usrResult = UpdateSchemaResult.FirstTableNotExists
                'End If
            Next
            If MasterDataStore.AutoCreateOption = AutoCreateOption.DatabaseAndSchema Or
                MasterDataStore.AutoCreateOption = AutoCreateOption.SchemaOnly Or
                ApplicationContainer.ConnectionType = CustomProviderContainer.ProviderConnectionTypes.InMemoryDataStore Then
                If ApplicationContainer.UpdateSchema() = UpdateSchemaResult.FirstTableNotExists Then
                    usrResult = UpdateSchemaResult.FirstTableNotExists
                End If
            End If

            Return usrResult
        End Function

        Public Shared Sub ClearTables()
            For Each oCustomProviderContainer In CustomProviderContainerList
                oCustomProviderContainer.Tables.Clear()
            Next
            ApplicationContainer.Tables.Clear()
        End Sub




    End Class
End Namespace


