Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Linq
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Model.DomainLogics
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering


' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModuleBasetopic.
Public NotInheritable Class ISSNotificationsModule
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
        Dim updater As ModuleUpdater = New Updater(objectSpace, versionFromDB)
        Return New ModuleUpdater() {updater}
    End Function

    Public Overrides Sub Setup(application As XafApplication)
        MyBase.Setup(application)
        AddHandler application.ObjectSpaceCreated, AddressOf Application_ObjectSpaceCreated

        ' Manage various aspects of the application UI and behavior at the module level.
    End Sub

    Private Sub Application_ObjectSpaceCreated(sender As Object, e As ObjectSpaceCreatedEventArgs)
        If Not TypeOf e.ObjectSpace Is INestedObjectSpace Then
            AddHandler e.ObjectSpace.Committing, AddressOf RootObjectSpace_Commiting
            AddHandler e.ObjectSpace.Committed, AddressOf RootObjectSpace_Commited
            AddHandler e.ObjectSpace.ObjectChanged, AddressOf RootObjectSpace_Changed
        End If

    End Sub

    Private Sub RootObjectSpace_Changed(sender As Object, e As ObjectChangedEventArgs)
        'Throw New NotImplementedException()
        '_mNotificationService.RefreshChangeCacheDictionary(sender)
        '_mNotificationService.ProcessChangedObjectWithChangeNotificationRules(sender, e.Object)


    End Sub


    'todo: load all notification rules with uponchange types
    'todo: reload with cache

    Private _mNotificationService As New NotificationService



    Private _mInstanceLevel As Integer = 0
    Private _mObjectSpaceCommitingDictionary As New Dictionary(Of IObjectSpace, List(Of Object))
    Private Sub RootObjectSpace_Commited(sender As Object, e As EventArgs)
        _mInstanceLevel += 1
        Dim obs As IObjectSpace = sender
        Dim gpoGroupOperator As GroupOperator
        Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo
        Dim obj As Object
        If _mObjectSpaceCommitingDictionary.ContainsKey(obs) = True Then
            Try

                While _mObjectSpaceCommitingDictionary(obs).Count > 0
                    obj = _mObjectSpaceCommitingDictionary(obs)(_mObjectSpaceCommitingDictionary(obs).Count - 1)
                    _mObjectSpaceCommitingDictionary(obs).RemoveAt(_mObjectSpaceCommitingDictionary(obs).Count - 1)
                    dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(obj.GetType)
                    If dtiTypeInfo IsNot Nothing Then
                        gpoGroupOperator = New GroupOperator
                        gpoGroupOperator.Operands.Add(New BinaryOperator("IsActive", True))
                        gpoGroupOperator.Operands.Add(New BinaryOperator("TargetObjectTypeName", dtiTypeInfo.FullName))
                        gpoGroupOperator.Operands.Add(New BinaryOperator("EvaluationType", NotificationRule.EvaluationTypes.UponSave))
                        'todo: find save rules and process against object
                        For Each xpoRule As NotificationRule In obs.CreateCollection(GetType(NotificationRule), gpoGroupOperator)
                            Try
                                ' todo: only commit if the rule has modified or created an object

                                xpoRule.ProcessNotificationRule(obj)

                                If (obs.ModifiedObjects IsNot Nothing AndAlso obs.ModifiedObjects.Count > 0) Then
                                    obs.CommitChanges()
                                End If


                            Catch ex As Exception
                                'obs.Rollback()
                                NotificationHelper.LogNotificationException(xpoRule, dtiTypeInfo.KeyMember.SerializeValue(obj), ex, CType(obs, Xpo.XPObjectSpace).Session)
                            End Try
                        Next
                    End If
                End While

            Catch ex As Exception
                'obs.Rollback()
                NotificationHelper.LogNotificationException(Nothing, String.Empty, ex, CType(obs, Xpo.XPObjectSpace).Session)
            End Try
            If _mInstanceLevel = 1 AndAlso _mObjectSpaceCommitingDictionary.ContainsKey(obs) AndAlso _mObjectSpaceCommitingDictionary(obs).Count = 0 Then
                _mObjectSpaceCommitingDictionary.Remove(obs)
            End If
            _mInstanceLevel -= 1
        End If

    End Sub

    Private Sub RootObjectSpace_Commiting(sender As Object, e As CancelEventArgs)
        Dim obs As IObjectSpace = sender
        If _mObjectSpaceCommitingDictionary.ContainsKey(obs) = False Then
            _mObjectSpaceCommitingDictionary.Add(obs, New List(Of Object))

        End If
        For Each obj In obs.GetObjectsToSave(True)
            If obs.IsDeletedObject(obj) = false Then
                _mObjectSpaceCommitingDictionary(obs).Add(obj)
            End If

        Next
        '_mObjectSpaceCommitingDictionary(obs).AddRange(obs.GetObjectsToSave(True))
    End Sub

End Class
