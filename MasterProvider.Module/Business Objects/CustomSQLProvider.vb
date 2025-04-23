Imports DevExpress.Xpo.DB
Imports System.Data.SqlClient

Public Class CustomSQLProvider
    Inherits DevExpress.Xpo.DB.MSSqlConnectionProvider
    Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal autoCreateOption As DevExpress.Xpo.DB.AutoCreateOption)
        MyBase.New(connection, autoCreateOption)
        
    End Sub
    Private _mDisableServerInsert As Boolean = False

    Public Overrides Function UpdateSchema(dontCreateIfFirstTableNotExist As Boolean, ParamArray tables() As DevExpress.Xpo.DB.DBTable) As DevExpress.Xpo.DB.UpdateSchemaResult
        _mDisableServerInsert = True
        Dim obj As Object = MyBase.UpdateSchema(dontCreateIfFirstTableNotExist, tables)
        _mDisableServerInsert = False
        Return obj
    End Function

    Public Overrides Function ComposeSafeTableName(tableName As String) As String
        Dim strTableName As String = tableName
        Dim strResult As String
        If Helpers.DataStoreHelper.GetClassInfoFromTableName(tableName) IsNot Nothing Then
            For Each iteExtenders In MasterProviderModule.SchemaNamingEngines
                strResult = iteExtenders.GetTableName(strTableName, Helpers.DataStoreHelper.GetClassInfoFromTableName(tableName).ClassType)
                If strResult > String.Empty Then
                    strTableName = strResult
                End If
            Next
        End If

        Return strTableName

    End Function

    'Public Overrides Function ComposeSafeConstraintName(constraintName As String) As String
    '    'Return MyBase.ComposeSafeConstraintName(constraintName)
    '    Dim strResult As String
    '    For Each iteExtenders In MasterProviderModule.SchemaNamingEngines
    '        strResult = iteExtenders.GetConstraintName(constraintName)
    '        If strResult > String.Empty Then
    '            constraintName = strResult
    '        End If
    '    Next
    '    Return constraintName
    'End Function

    'Public Overrides Function ComposeSafeColumnName(columnName As String) As String
    '    'Return MyBase.ComposeSafeColumnName(columnName)
    '    Dim strResult As String
    '    For Each iteExtenders In MasterProviderModule.SchemaNamingEngines
    '        strResult = iteExtenders.GetColumnName(columnName)
    '        If strResult > String.Empty Then
    '            columnName = strResult
    '        End If
    '    Next
    '    Return columnName
    'End Function

    'Protected Overrides Function GetIndexName(cons As DBIndex, table As DBTable) As String
    '    Dim strIndex As String = MyBase.GetIndexName(cons, table)
    '    Dim strResult As String = strIndex
    '    For Each iteExtenders In MasterProviderModule.SchemaNamingEngines
    '        strResult = iteExtenders.GetIndexName(strIndex)
    '        If strResult > String.Empty Then
    '            strIndex = strResult
    '        End If
    '    Next
    '    Return strIndex
    'End Function

    'Protected Overrides Function GetPrimaryKeyName(cons As DBPrimaryKey, table As DBTable) As String
    '    Dim strIndex As String = MyBase.GetPrimaryKeyName(cons, table)
    '    Dim strResult As String = strIndex
    '    For Each iteExtenders In MasterProviderModule.SchemaNamingEngines
    '        strResult = iteExtenders.GetIndexName(strIndex)
    '        If strResult > String.Empty Then
    '            strIndex = strResult
    '        End If
    '    Next
    '    Return strIndex
    'End Function

    Public Overrides Function ComposeSafeSchemaName(tableName As String) As String
        
        

        If _mDisableServerInsert = True Then
            Return MyBase.ComposeSafeSchemaName(tableName)
        End If
        Dim cpcCustomContainer As CustomProviderContainer
        Dim scbConnectionBuilder As New SqlConnectionStringBuilder



        If Helpers.DataStoreHelper.IsCustomDataStoreTable(tableName) Then
            cpcCustomContainer = Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(tableName)
            If cpcCustomContainer.ConnectionType = CustomProviderContainer.ProviderConnectionTypes.SQLServer Then
                scbConnectionBuilder.ConnectionString = cpcCustomContainer.ConnectionString
                Return String.Format("{0}"".""{1}", scbConnectionBuilder("Database"), ObjectsOwner)
            End If

        Else
            If Helpers.DataStoreHelper.ApplicationContainer.ConnectionType = CustomProviderContainer.ProviderConnectionTypes.SQLServer Then
                scbConnectionBuilder.ConnectionString = Helpers.DataStoreHelper.ApplicationContainer.ConnectionString
                Return String.Format("{0}"".""{1}", scbConnectionBuilder("Database"), ObjectsOwner)
            End If
        End If
        Return MyBase.ComposeSafeSchemaName(tableName)
    End Function

    
    'Public Overrides Function ComposeSafeTableName(tableName As String) As String
    '    If _mDisableServerInsert = True Then
    '        Return MyBase.ComposeSafeTableName(tableName)
    '    End If
    '    Me.ObjectsOwner = String.Empty
    '    Dim cpcCustomContainer As CustomProviderContainer
    '    Dim scbConnectionBuilder As New SqlConnectionStringBuilder
    '    If Helpers.DataStoreHelper.IsCustomDataStoreTable(tableName) Then
    '        cpcCustomContainer = Helpers.DataStoreHelper.GetCustomProviderContainerStoreByTableName(tableName)
    '        If cpcCustomContainer.ConnectionType = CustomProviderContainer.ProviderConnectionTypes.SQLServer Then
    '            scbConnectionBuilder.ConnectionString = cpcCustomContainer.ConnectionString
    '            tableName = String.Format("{0}.{2}.{1}", scbConnectionBuilder("Database"), tableName,ObjectsOwner)
    '        End If

    '    Else
    '        If Helpers.DataStoreHelper.ApplicationContainer.ConnectionType = CustomProviderContainer.ProviderConnectionTypes.SQLServer Then
    '            scbConnectionBuilder.ConnectionString = Helpers.DataStoreHelper.ApplicationContainer.ConnectionString
    '            tableName = String.Format("{0}.{2}.{1}", scbConnectionBuilder("Database"), tableName,ObjectsOwner)
    '        End If
    '    End If
    '    Return tableName

    '    'If tableName.Contains("RM00101") Then
    '    '    Stop
    '    'End If
    '    'Return MyBase.ComposeSafeTableName(tableName)
    'End Function


End Class
