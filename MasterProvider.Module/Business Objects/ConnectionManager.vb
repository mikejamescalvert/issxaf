Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.Collections.ObjectModel

Public Class ConnectionManager
    Inherits BaseObject

#Region "Behaviors"
    Protected Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Shared Function GetInstance(ByVal Session As Session) As ConnectionManager
        Dim cnmManager As ConnectionManager = Session.FindObject(Of ConnectionManager)(Nothing)
        If cnmManager Is Nothing Then
            cnmManager = New ConnectionManager(Session)
            cnmManager.Save()
        End If
        Return cnmManager
    End Function
    Public Sub AddRegistryEntryInformation(ByVal RegistryPath As String, ByVal ConnectionStringName As String, ByVal DisplayName As String)

        For Each cntConnection As MPConnectionInformation In _mConnections
            If cntConnection.ConnectionStringName = ConnectionStringName Then
                Return
            End If
        Next
        Dim mpcConnection As New MPConnectionInformation(Me.Session)
        mpcConnection.Accepted = False
        mpcConnection.RegistryPath = RegistryPath
        mpcConnection.ConnectionStringName = ConnectionStringName
        mpcConnection.DisplayName = DisplayName
        mpcConnection.ReadConnectionFromRegistry()
        _mConnections.Add(mpcConnection)
    End Sub
    Public Sub SetupConnections()
        _mConnections = New List(Of MPConnectionInformation)
        For Each oCustomProviderContainer As CustomProviderContainer In Helpers.DataStoreHelper.CustomProviderContainerList
            If oCustomProviderContainer.IsRegistryEntry = True Then
                AddRegistryEntryInformation(oCustomProviderContainer.RegistryLocation, DevExpress.ExpressApp.Utils.CaptionHelper.ConvertCompoundName(oCustomProviderContainer.ConnectionStringName), oCustomProviderContainer.DisplayName)
            End If
        Next
        If Helpers.DataStoreHelper.ApplicationContainer.IsRegistryEntry = True Then
            AddRegistryEntryInformation(Helpers.DataStoreHelper.ApplicationContainer.RegistryLocation, "Application Connection", "Application Connection")
        End If
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub
#End Region

#Region "Properties"
    Private _mConnections As List(Of MPConnectionInformation)
    Public ReadOnly Property Connections As ReadOnlyCollection(Of MPConnectionInformation)
        Get
            If _mConnections Is Nothing Then
                SetupConnections()
            End If
            Return _mConnections.AsReadOnly
        End Get
    End Property
#End Region

End Class
