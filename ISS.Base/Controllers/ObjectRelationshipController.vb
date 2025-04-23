Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.DC
Imports ISS.Base.Interfaces
Imports ISS.Base.Helpers
Imports DevExpress.Xpo

Public Class ObjectRelationshipController
    Inherits ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        If ISS.Base.ISSBaseModule.DisableObjectRelationshipController = False Then
            'MJC 092311: Checking Performance Implications
            RemoveHandler ObjectSpace.ObjectChanged, AddressOf ObjectChanged
            AddHandler ObjectSpace.ObjectChanged, AddressOf ObjectChanged
        End If

        
        'RemoveHandler ObjectSpace.Committed, AddressOf CommitDatabaseObjectSpace
        'AddHandler ObjectSpace.Committed, AddressOf CommitDatabaseObjectSpace
    End Sub

    'Private Shared Function DoesTypeHaveChildInterface(ByVal TypeInfo As TypeInfo) As Boolean
    '    For Each oMemberInfo As IMemberInfo In TypeInfo.Members
    '        If oMemberInfo.MemberTypeInfo.Implements(Of IObjectRelationship)() Then
    '            Return True
    '        End If
    '    Next
    '    Return False
    'End Function

    'Private Sub CommitDatabaseObjectSpace(ByVal sender As Object, ByVal e As EventArgs)
    '    DatabaseLevelObjectSpace.CommitTransaction()
    'End Sub

    Private _mObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace
    Public ReadOnly Property DatabaseLevelObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace
        Get
            If _mObjectSpace Is Nothing Then
                _mObjectSpace = Application.CreateObjectSpace
            End If
            Return _mObjectSpace
        End Get
    End Property

    'Private _mDatabaseUnitOfWork As UnitOfWork
    'Public ReadOnly Property DatabaseUnitOfWork As Session
    '    Get
    '        If _mDatabaseUnitOfWork Is Nothing Then
    '            _mDatabaseUnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
    '        End If
    '        Return _mDatabaseUnitOfWork
    '    End Get
    'End Property

    'Private _mDatabaseObjectSpace As ObjectSpace
    'Public ReadOnly Property DatabaseObjectSpace As ObjectSpace
    '    Get
    '        If _mDatabaseObjectSpace Is Nothing OrElse _mDatabaseObjectSpace.IsDisposed = True Then
    '            _mDatabaseObjectSpace = Application.CreateObjectSpace
    '        End If
    '        Return _mDatabaseObjectSpace
    '    End Get
    'End Property

    Public Sub ObjectChanged(ByVal sender As Object, ByVal e As ObjectChangedEventArgs)
        Dim ifcOneToOneChild As IObjectRelationship
        'Dim obsSpace As ObjectSpace
        Dim objOldObject As Object = Nothing
        Dim dtiTypeInfo As ITypeInfo
        Dim dmiMemberInfo As IMemberInfo

        If Application Is Nothing Then
            Return
        End If

        'obsSpace = Application.CreateObjectSpace
        If String.Compare(e.PropertyName, String.Empty, False) = 0 Then
            Return
        End If

        dtiTypeInfo = XafTypesInfo.Instance.FindTypeInfo(e.Object.GetType)
        If dtiTypeInfo Is Nothing Then
            Return
        End If

        dmiMemberInfo = dtiTypeInfo.FindMember(e.PropertyName)
        If dmiMemberInfo Is Nothing Then
            Return
        End If

        If dmiMemberInfo.MemberTypeInfo.Implements(Of IObjectRelationship)() = False Then
            Return
        End If

        ifcOneToOneChild = dmiMemberInfo.GetValue(e.Object)
        If ifcOneToOneChild IsNot Nothing Then
            ifcOneToOneChild.ParentReferenceSet(e.Object, dmiMemberInfo.IsAggregated)
        End If

        objOldObject = DatabaseLevelObjectSpace.GetObjectByKey(e.Object.GetType, dtiTypeInfo.KeyMember.GetValue(e.Object))
        If objOldObject Is Nothing Then
            Return
        End If

        ifcOneToOneChild = dmiMemberInfo.GetValue(objOldObject)
        If ifcOneToOneChild IsNot Nothing Then
            ifcOneToOneChild.ParentReferenceCleared(e.Object, dmiMemberInfo.IsAggregated)
        End If

    End Sub

End Class
