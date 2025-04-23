Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.Xpo.Metadata
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.Xpo.DB

Public Class MasterDataStoreProvider
    Implements IXpoDataStoreProvider

    Private proxy As MasterDataStore
    Public Sub New()
        proxy = New MasterDataStore()
    End Sub
    Public ReadOnly Property ConnectionString() As String Implements IXpoDataStoreProvider.ConnectionString
        Get
            Return ""
        End Get
    End Property
    Public Function CreateWorkingStore(<System.Runtime.InteropServices.Out()> ByRef disposableObjects() As IDisposable) As DevExpress.Xpo.DB.IDataStore Implements IXpoDataStoreProvider.CreateWorkingStore
        disposableObjects = Nothing
        Return proxy
    End Function
    'Public ReadOnly Property XPDictionary() As XPDictionary Implements IXpoDataStoreProvider.XPDictionary
    '    Get
    '        Return _mDictionary
    '    End Get
    'End Property
    Private isInitialized_Renamed As Boolean
    Public ReadOnly Property IsInitialized() As Boolean
        Get
            Return isInitialized_Renamed
        End Get
    End Property
    Private _mDictionary As XPDictionary
    Public Sub Initialize(ByVal dictionary As XPDictionary, ByVal UpdateMode As DatabaseUpdateMode)
        _mDictionary = dictionary
        If UpdateMode = DatabaseUpdateMode.Never Then
            proxy.Initialize(dictionary, DevExpress.Xpo.DB.AutoCreateOption.None)
        Else
            proxy.Initialize(dictionary, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
        End If

        Helpers.SessionHelper.MasterDataStore = proxy

        isInitialized_Renamed = True
    End Sub

    Public Function CreateUpdatingStore(allowUpdateSchema As Boolean, ByRef disposableObjects() As IDisposable) As IDataStore Implements IXpoDataStoreProvider.CreateUpdatingStore
        disposableObjects = Nothing
        Return proxy
    End Function

    Public Function CreateSchemaCheckingStore(ByRef disposableObjects() As IDisposable) As IDataStore Implements IXpoDataStoreProvider.CreateSchemaCheckingStore
        disposableObjects = Nothing
        Return proxy
    End Function
End Class
