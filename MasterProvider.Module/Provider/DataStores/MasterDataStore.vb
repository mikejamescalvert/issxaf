

Imports Microsoft.VisualBasic
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports System.Collections
Imports System.Collections.Generic
Imports DevExpress.Xpo.Helpers
Imports System.Reflection
Imports MasterProvider.Module.Permissions
Imports DevExpress.ExpressApp.DC
Imports System.IO

Public Class MasterDataStore
    Implements IDataStore, ICommandChannel

    'Private _StandardDataStore As IDataStore
    'Private _StandardDataLayer As SimpleDataLayer

    Private _mIsInitialized As Boolean
    Public Property IsInitialized() As Boolean
        Get
            Return _mIsInitialized
        End Get
        Set(ByVal value As Boolean)
            If _mIsInitialized = value Then
                Return
            End If
            _mIsInitialized = value
        End Set
    End Property

    Private Shared _mDictionary As DevExpress.Xpo.Metadata.ReflectionDictionary
    Public Shared Function GetFullXPDictionaries() As DevExpress.Xpo.Metadata.ReflectionDictionary
        'MJC: 081516, reduce overhead by only fetching assemblies once
        If _mDictionary Is Nothing
            _mDictionary = New ReflectionDictionary
            _mDictionary.GetDataStoreSchema(GetAllAssemblies)
        End If
        Return _mDictionary
        'Dim xpdDictionary As DevExpress.Xpo.Metadata.ReflectionDictionary = New DevExpress.Xpo.Metadata.ReflectionDictionary
        ''Retrieves all assemblies and registers their persistent classes with the dictionary

        ''BuildManager.GetReferencedAssemblies()
        'xpdDictionary.GetDataStoreSchema(GetAllAssemblies())
        'Return xpdDictionary
    End Function

    ''' <summary>
    ''' Pulls a list of all assemblies from the application domain.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetAllAssemblies() As System.Reflection.Assembly()
        'Fetches all assemblies from the current domain.
        Dim lstAssemblies As New List(Of System.Reflection.Assembly)
        'Try
        For Each cpoCustomProvider As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
            Try
                AppDomain.CurrentDomain.Load(cpoCustomProvider.AssemblyName)
            Catch ex As Exception
            End Try
        Next
        'Catch ex As Exception

        'End Try


        For Each oAssembly As Assembly In AppDomain.CurrentDomain.GetAssemblies
            If oAssembly.FullName.StartsWith("DevExpress.Persistent") Then
                Continue For
            End If
            lstAssemblies.Add(oAssembly)
        Next
        Return lstAssemblies.ToArray
    End Function

    Public Sub SetAutoCreateOption(ByVal AutoCreateOption As AutoCreateOption)
        _mAutoCreateOption = AutoCreateOption
    End Sub

    Public Sub Initialize(ByVal dictionary As XPDictionary, ByVal AutoCreateOption As AutoCreateOption)
        'Dim lstReflectionDictionary As New List(Of ReflectionDictionary)
        Dim applicationDictionary As New ReflectionDictionary
        Dim mpiMasterProviderInfo As MasterProviderSettings = MasterProviderSettings.GetInstance
        SetAutoCreateOption(AutoCreateOption)
        Helpers.DataStoreHelper.LoadProviderInformation(AutoCreateOption)

        If dictionary Is Nothing Then
            'load all objects
            dictionary = GetFullXPDictionaries()
        End If

        Helpers.DataStoreHelper.LoadProviderTableNames(dictionary)

        For Each ci As XPClassInfo In dictionary.Classes
            If (Not String.IsNullOrEmpty(ci.TableName)) Then
                If Helpers.DataStoreHelper.IsCustomDataStoreTable(ci.TableName) Then
                    Helpers.DataStoreHelper.AddClassToReflectionDictionary(ci.TableName, ci.ClassType)
                Else
                    Helpers.DataStoreHelper.ApplicationContainer.ReflectionDictionary.QueryClassInfo(ci.ClassType)
                End If
            End If
        Next ci





        LoadDefaultPermissions(dictionary)
        Helpers.DataStoreHelper.SetupDataStores()
        IsInitialized = True
    End Sub

    Private Shared _mPermissionSet As New List(Of ObjectPermission)
    Public Shared Sub LoadDefaultPermissions(ByVal dictionary As XPDictionary)
        Dim blnModifyData As Boolean
        Dim blnModifySchema As Boolean
        Dim obaObjectAccess As ObjectPermission

        _mPermissionSet.Clear()

        'todo: read through master provider and set permission
        For Each ci As XPClassInfo In dictionary.Classes
            If ci.ClassType Is Nothing Then
                Continue For
            End If
            blnModifySchema = ci.FindAttributeInfo(GetType(MasterProvider.Module.AllowDatabaseUpdateInMasterProviderAttribute)) IsNot Nothing
            blnModifyData = ci.FindAttributeInfo(GetType(MasterProvider.Module.AllowDataModificationsInMasterProviderAttribute)) IsNot Nothing

            If blnModifySchema = True And blnModifyData = True Then
                obaObjectAccess = New ObjectPermission(ci.ClassType, ObjectPermissionType.FullAccess)
            ElseIf blnModifySchema = True Then
                obaObjectAccess = New ObjectPermission(ci.ClassType, ObjectPermissionType.OnlyAllowSchemaModification)
            ElseIf blnModifyData = True Then
                obaObjectAccess = New ObjectPermission(ci.ClassType, ObjectPermissionType.OnlyAllowDataModification)
            Else
                If Helpers.DataStoreHelper.IsCustomDataStoreTable(ci.TableName) = True Then
                    obaObjectAccess = New ObjectPermission(ci.ClassType, ObjectPermissionType.NoAccess)
                Else
                    obaObjectAccess = New ObjectPermission(ci.ClassType, ObjectPermissionType.FullAccess)
                End If
            End If
            _mPermissionSet.Add(obaObjectAccess)
        Next ci
    End Sub

    Private Shared _mOverridePermissionSet As New List(Of ObjectPermission)
    Public Shared Sub ClearPermissionOverrides()
        _mOverridePermissionSet.Clear()
    End Sub
    Public Shared Sub ClearPermissionOverrides(ByVal ObjectType As Type)
        For intLoop As Integer = _mOverridePermissionSet.Count - 1 To 0 Step -1
            If _mOverridePermissionSet(intLoop).ObjectType Is ObjectType Then
                _mOverridePermissionSet.RemoveAt(intLoop)
            End If
        Next
    End Sub

    Public Shared Sub AddPermissionOverride(ByVal ObjectType As Type, ByVal Permission As ObjectPermissionType)
        _mOverridePermissionSet.Add(New ObjectPermission(ObjectType, Permission))
    End Sub

    Public Shared Function GetObjectPermission(ByVal ObjectType As Type) As System.Nullable(Of ObjectPermissionType)
        For Each obpPermission As ObjectPermission In _mOverridePermissionSet
            If obpPermission.ObjectType Is ObjectType Then
                Return obpPermission.PermissionType
            End If
        Next
        For Each obpPermission As ObjectPermission In _mPermissionSet
            If obpPermission.ObjectType Is ObjectType Then
                Return obpPermission.PermissionType
            End If
        Next
        Return Nothing
    End Function

    Private _mAutoCreateOption As AutoCreateOption = DB.AutoCreateOption.SchemaAlreadyExists
    Public ReadOnly Property AutoCreateOption() As AutoCreateOption Implements IDataStore.AutoCreateOption
        Get
            Return _mAutoCreateOption
        End Get
    End Property

    Public Function ModifyData(ByVal ParamArray dmlStatements() As ModificationStatement) As ModificationResult Implements IDataStore.ModifyData
        Dim kalKeyedArrayList As New Collections.Generic.Dictionary(Of CustomProviderContainer, List(Of ModificationStatement))
        Dim applicationStatements As New List(Of ModificationStatement)()
        Dim lstModificatonStation As List(Of ModificationStatement)
        Dim oModificationResult As ModificationResult
        Dim oClassInfo As XPClassInfo
        Dim oapPermission As System.Nullable(Of ObjectPermissionType)
        For Each oStatement As ModificationStatement In dmlStatements
            oClassInfo = Helpers.DataStoreHelper.GetClassInfoFromTableName(oStatement.Table.Name)
            If oClassInfo IsNot Nothing Then
                oapPermission = GetObjectPermission(oClassInfo.ClassType)
                If Helpers.DataStoreHelper.IsCustomDataStoreTable(oStatement.Table.Name) = True Then
                    If oapPermission.HasValue = False OrElse (oapPermission.Value = ObjectPermissionType.OnlyAllowSchemaModification Or oapPermission.Value = ObjectPermissionType.NoAccess) Then
                        Throw New Exception(String.Format("Application Error: Data changes not allowed on table: {0}", oStatement.Table.Name))
                    End If
                Else
                    If oapPermission.HasValue = True AndAlso (oapPermission.Value = ObjectPermissionType.OnlyAllowSchemaModification Or oapPermission.Value = ObjectPermissionType.NoAccess) Then
                        Throw New Exception(String.Format("Application Error: Data changes not allowed on table: {0}", oStatement.Table.Name))
                    End If
                End If
            End If


            If Helpers.DataStoreHelper.IsCustomDataStoreTable(oStatement.Table.Name) = True Then
                If kalKeyedArrayList.ContainsKey(Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(oStatement.Table.Name)) Then
                    kalKeyedArrayList(Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(oStatement.Table.Name)).Add(oStatement)
                Else
                    lstModificatonStation = New List(Of ModificationStatement)
                    lstModificatonStation.Add(oStatement)
                    kalKeyedArrayList.Add(Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(oStatement.Table.Name), lstModificatonStation)
                End If
            Else
                applicationStatements.Add(oStatement)
            End If
        Next

        Dim modificationResultIdentities As List(Of ParameterValue) = New List(Of ParameterValue)()

        For Each oCustomProviderContainer As CustomProviderContainer In kalKeyedArrayList.Keys
            oModificationResult = oCustomProviderContainer.DataStore.ModifyData(kalKeyedArrayList(oCustomProviderContainer).ToArray)
            If oModificationResult IsNot Nothing Then
                modificationResultIdentities.AddRange(oModificationResult.Identities)
            End If
        Next

        If applicationStatements.Count > 0 Then
            oModificationResult = Helpers.DataStoreHelper.ApplicationContainer.DataStore.ModifyData(applicationStatements.ToArray)
            If oModificationResult IsNot Nothing Then
                modificationResultIdentities.AddRange(oModificationResult.Identities)
            End If
        End If

        Return New ModificationResult(modificationResultIdentities)
    End Function

    Public Function SelectData(ByVal ParamArray selects() As SelectStatement) As SelectedData Implements IDataStore.SelectData
        Dim resultSet As New List(Of SelectStatementResult)
        Dim kalKeyedArrayList As New Collections.Generic.Dictionary(Of CustomProviderContainer, List(Of SelectStatement))
        Dim applicationStatements As New List(Of SelectStatement)()
        Dim sdrSelectResult As SelectedData
        Dim cptTable As CustomProviderContainer

        For Each oStatement As SelectStatement In selects
            If Helpers.DataStoreHelper.IsCustomDataStoreTable(oStatement.Table.Name) = True Then
                cptTable = Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(oStatement.Table.Name)
                sdrSelectResult = cptTable.DataStore.SelectData(oStatement)
                If sdrSelectResult IsNot Nothing Then
                    resultSet.AddRange(sdrSelectResult.ResultSet)
                End If
                'If kalKeyedArrayList.ContainsKey(Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(oStatement.TableName)) Then
                '    kalKeyedArrayList(Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(oStatement.TableName)).Add(oStatement)
                'Else
                '    lstSelectStation = New List(Of SelectStatement)
                '    lstSelectStation.Add(oStatement)
                '    kalKeyedArrayList.Add(Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(oStatement.TableName), lstSelectStation)
                'End If
            Else
                sdrSelectResult = Helpers.DataStoreHelper.ApplicationContainer.DataStore.SelectData(oStatement)
                If sdrSelectResult IsNot Nothing Then
                    resultSet.AddRange(sdrSelectResult.ResultSet)
                End If
            End If
        Next
        'For Each oCustomProviderContainer As CustomProviderContainer In kalKeyedArrayList.Keys
        '    sdrSelectResult = oCustomProviderContainer.DataStore.SelectData(kalKeyedArrayList(oCustomProviderContainer).ToArray)
        '    If sdrSelectResult IsNot Nothing Then
        '        resultSet.AddRange(sdrSelectResult.ResultSet)
        '    End If
        'Next

        'sdrSelectResult = Helpers.DataStoreHelper.ApplicationContainer.DataStore.SelectData(applicationStatements.ToArray)
        'If sdrSelectResult IsNot Nothing Then
        '    resultSet.AddRange(sdrSelectResult.ResultSet)
        'End If

        '03-07-2012: MJC - Trim text values to return unpadded results from DB
        For Each rstResult As SelectStatementResult In resultSet
            For Each rwoRowObject As SelectStatementResultRow In rstResult.Rows
                For intLoop As Integer = 0 To rwoRowObject.Values.Length - 1
                    If TypeOf rwoRowObject.Values(intLoop) Is String Then
                        rwoRowObject.Values(intLoop) = Trim(rwoRowObject.Values(intLoop))
                    End If
                Next
            Next
        Next

        Return New SelectedData(CType(resultSet.ToArray(), SelectStatementResult()))
    End Function

    Public Function UpdateSchema(ByVal dontCreateIfFirstTableNotExist As Boolean, ByVal ParamArray tables() As DBTable) As UpdateSchemaResult Implements IDataStore.UpdateSchema
        Dim gpTables As List(Of DBTable) = New List(Of DBTable)()
        Dim storefrontTables As List(Of DBTable) = New List(Of DBTable)()
        Dim applicationTables As New List(Of DBTable)()
        Dim usrResult As UpdateSchemaResult
        'DataStoreHelper.ClearTables()

        If IsInitialized = False Then
            Initialize(GetFullXPDictionaries, DB.AutoCreateOption.DatabaseAndSchema)
        End If

        For Each table As DBTable In tables
            If String.IsNullOrEmpty(table.Name) Then
                Continue For
            End If
            If Helpers.DataStoreHelper.IsCustomDataStoreTable(table.Name) Then
                Helpers.DataStoreHelper.AddTableToCustomProviderContainer(table)
            Else
                If Helpers.DataStoreHelper.ApplicationContainer.IsTableInList(table.Name) = False Then
                    Helpers.DataStoreHelper.ApplicationContainer.Tables.Add(table)
                End If
            End If
        Next
        Helpers.DataStoreHelper.SetupDataStores()
        usrResult = Helpers.DataStoreHelper.UpdateTableSchemas(Me)

        'If AutoCreateOption = DB.AutoCreateOption.DatabaseAndSchema Or AutoCreateOption = DB.AutoCreateOption.SchemaOnly Then

        'End If
        Return UpdateSchemaResult.SchemaExists
    End Function

    Private Function PrepareArguments(ByVal args As Object) As Object
        Dim arguments() As Object = TryCast(args, Object())
        If arguments Is Nothing Then
            Return args
        End If
        Return New StoredProcedureArgument(arguments(0), arguments(1))
    End Function

    Public Function [Do](ByVal command As String, ByVal args As Object) As Object Implements DevExpress.Xpo.Helpers.ICommandChannel.Do
        Return CType(Helpers.DataStoreHelper.ApplicationContainer.DataStore, ICommandChannel).Do(command, args)
    End Function


End Class