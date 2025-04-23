Imports DevExpress.Xpo
Imports System.Reflection
Imports System.Web.Compilation

Namespace Helpers
    Public Class SessionHelper

        'Private Shared _mMasterDataStore As MasterDataStore
        'Public Shared ReadOnly Property MasterDataStore As MasterDataStore
        '    Get
        '        If _mMasterDataStore Is Nothing Then
        '            _mMasterDataStore = New MasterDataStore
        '            _mMasterDataStore.Initialize(MasterDataStore.GetFullXPDictionaries, _mMasterDataStore.AutoCreateOption)
        '        End If
        '        Return _mMasterDataStore
        '    End Get

        'End Property

        Private Shared _mMasterDataStore As MasterDataStore
        Public Shared Property MasterDataStore As MasterDataStore
            Get
                If _mMasterDataStore Is Nothing Then
                    SetupBaseMasterProvider()
                End If
                Return _mMasterDataStore
            End Get
            Set(ByVal Value As MasterDataStore)
                _mMasterDataStore = Value
            End Set
        End Property

        Private Shared Sub SetupBaseMasterProvider()
            If _mMasterDataStore Is Nothing Then
                _mMasterDataStore = New MasterDataStore
                _mMasterDataStore.Initialize(MasterDataStore.GetFullXPDictionaries, _mMasterDataStore.AutoCreateOption)
            End If

        End Sub

        ''' <summary>
        ''' Re-connects the passed in session to the master provider logic.
        ''' </summary>
        ''' <param name="SessionObject"></param>
        ''' <remarks></remarks>
        Public Shared Sub SetupSessionWithMasterProvider(ByRef SessionObject As Session)
            SessionObject.Connect(New SimpleDataLayer(MasterDataStore), Nothing)
        End Sub

        ''' <summary>
        ''' Creates an instance of a unit of work and sets it up for use with the master provider.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetMasterProviderUnitOfWork() As UnitOfWork
            'Dim solObjectLayer As SimpleObjectLayer
            'Dim sdlDataLayer As SimpleDataLayer
            'Dim uowUnitOfWork As UnitOfWork

            'sdlDataLayer = New SimpleDataLayer(MasterDataStore.GetFullXPDictionaries, MasterDataStore)
            'solObjectLayer = SimpleObjectLayer.FromDataLayer(sdlDataLayer)

            'uowUnitOfWork = New UnitOfWork(New SimpleDataLayer(MasterDataStore), Nothing)
            'AddHandler uowUnitOfWork.BeforeConnect, AddressOf Session_BeforeConnect
            'SetupSessionWithMasterProvider(uowUnitOfWork)
            Return New UnitOfWork(New SimpleDataLayer(MasterDataStore), Nothing)
        End Function

        ''' <summary>
        ''' Creates an instance of a session and sets it up for use with the master provider.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetMasterProviderSession() As Session
            'Dim sdlDataLayer As SimpleDataLayer
            'Dim solObjectLayer As SimpleObjectLayer
            'Dim sshSession As Session
            'sdlDataLayer = New SimpleDataLayer(MasterDataStore.GetFullXPDictionaries, MasterDataStore)
            'solObjectLayer = SimpleObjectLayer.FromDataLayer(sdlDataLayer)
            'sshSession = New Session(solObjectLayer, Nothing)
            'AddHandler sshSession.BeforeConnect, AddressOf Session_BeforeConnect
            'SetupSessionWithMasterProvider(sshSession)
            'Return sshSession
            Return New Session(New SimpleDataLayer(MasterDataStore), Nothing)
        End Function

        Private Shared Sub Session_BeforeConnect(sender As Object, e As SessionManipulationEventArgs)
            If MasterDataStore.AutoCreateOption <> e.Session.AutoCreateOption Then
                MasterDataStore.SetAutoCreateOption(e.Session.AutoCreateOption)
            End If

        End Sub

    End Class
End Namespace

