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
Imports DevExpress.Data.Filtering

Public NotInheritable Class [PostedAliasModule]
    ' You can override various virtual methods and handle corresponding events to manage various aspects of your XAF application UI and behavior.
    Inherits ModuleBase 'http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModuleBasetopic
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
        Dim updater As ModuleUpdater = New Updater(objectSpace, versionFromDB)
        Return New ModuleUpdater() {updater}
    End Function

    Public Overrides Sub Setup(application As XafApplication)
        MyBase.Setup(application)
        'todo: deprecate module after confirmation of not using
        'AddHandler application.ObjectSpaceCreated, AddressOf Application_ObjectSpaceCreated
        'AddHandler application.LoggingOn, AddressOf Application_LoggingOn


    End Sub

    Private Sub Application_LoggingOn(sender As Object, e As LogonEventArgs)
        Dim paiInfo As PostedAliasPathingAttributeInfo
        Dim pitInfo As InTransactionPersistentAliasPathingAttributeInfo
        PostedAliasPathingInfoObjects.Clear()
        InTransactionPersistentAliasPathingInfoObjects.Clear()

        For Each objType In DevExpress.ExpressApp.XafTypesInfo.Instance.PersistentTypes
            For Each mthMethodInfo In objType.Type.GetMethods
                If mthMethodInfo.GetCustomAttributes(GetType(PostedAliasAttribute), True).Length > 0 Then
                    paiInfo = New PostedAliasPathingAttributeInfo
                    With paiInfo
                        .Attribute = mthMethodInfo.GetCustomAttributes(GetType(PostedAliasAttribute), True)(0)
                        .SourceClass = objType
                        .TargetMethod = mthMethodInfo
                    End With
                    PostedAliasPathingInfoObjects.Add(paiInfo)
                End If
            Next
            For Each mmiMemberInfo In objType.Members
                If mmiMemberInfo.FindAttribute(Of InTransactionPersistentAliasAttribute)() IsNot Nothing Then
                    pitInfo = New InTransactionPersistentAliasPathingAttributeInfo
                    With pitInfo
                        .Attribute = mmiMemberInfo.FindAttribute(Of InTransactionPersistentAliasAttribute)()
                        .SourceClass = objType
                        .TargetProperty = mmiMemberInfo
                        .ParentCollectionProperty = objType.FindMember(.Attribute.PathToCollection)
                    End With
                    InTransactionPersistentAliasPathingInfoObjects.Add(pitInfo)
                End If
            Next
        Next
 End Sub 

    Public Shared PostedAliasPathingInfoObjects As New List(Of PostedAliasPathingAttributeInfo)
    Public Shared InTransactionPersistentAliasPathingInfoObjects As New List(Of InTransactionPersistentAliasPathingAttributeInfo)
    Public Shared Function GetPostedAliasPathingInformationForDependents(ByVal ObjectType As Type) As List(Of PostedAliasPathingAttributeInfo)
        Return New List(Of PostedAliasPathingAttributeInfo)(From paa In PostedAliasPathingInfoObjects
                                                           Select paa
                                                           Where paa.Attribute.DependentObjectType = ObjectType Or
                                                                paa.Attribute.DependentObjectType.IsAssignableFrom(ObjectType))
    End Function
    Public Shared Function GetPostedAliasPathingInformationForParents(ByVal ObjectType As Type) As List(Of PostedAliasPathingAttributeInfo)
        Return New List(Of PostedAliasPathingAttributeInfo)(From paa In PostedAliasPathingInfoObjects
                                                           Select paa
                                                           Where paa.SourceClass.Type = ObjectType Or
                                                                paa.Attribute.DependentObjectType.IsAssignableFrom(ObjectType))
    End Function

    Public Shared Function GetInTransactionPersistentAliasPathingInformationForDependents(ByVal ObjectType As Type) As List(Of InTransactionPersistentAliasPathingAttributeInfo)
        Return New List(Of InTransactionPersistentAliasPathingAttributeInfo)(From paa In InTransactionPersistentAliasPathingInfoObjects
                                                           Select paa
                                                           Where paa.Attribute.DependentObjectType = ObjectType Or
                                                                paa.Attribute.DependentObjectType.IsAssignableFrom(ObjectType))
    End Function
    Public Shared Function GetInTransactionPersistentAliasPathingInformationForParents(ByVal ObjectType As Type) As List(Of InTransactionPersistentAliasPathingAttributeInfo)
        Return New List(Of InTransactionPersistentAliasPathingAttributeInfo)(From paa In InTransactionPersistentAliasPathingInfoObjects
                                                           Select paa
                                                           Where paa.SourceClass.Type = ObjectType Or
                                                                paa.Attribute.DependentObjectType.IsAssignableFrom(ObjectType))
    End Function

    Private Sub Application_ObjectSpaceCreated(sender As Object, e As ObjectSpaceCreatedEventArgs)
        If TypeOf e.ObjectSpace Is DevExpress.ExpressApp.INestedObjectSpace Then
            AddHandler e.ObjectSpace.Committing, AddressOf NestedObjectSpace_Committing
            AddHandler e.ObjectSpace.Committed, AddressOf NestedObjectSpace_Committed
        Else
            AddHandler e.ObjectSpace.Committing, AddressOf ObjectSpace_Committing
            AddHandler e.ObjectSpace.Committed, AddressOf ObjectSpace_Committed
            AddHandler e.ObjectSpace.Disposed, AddressOf ObjectSpace_Disposed
            AddHandler e.ObjectSpace.ObjectDeleting, AddressOf ObjectSpace_ObjectDeleting
            AddHandler e.ObjectSpace.ObjectDeleted, AddressOf ObjectSpace_ObjectDeleted
            AddHandler e.ObjectSpace.ObjectChanged, AddressOf ObjectSpace_ObjectChanged
        End If


    End Sub

    Private _mObjectSpaceDictionary As New Dictionary(Of DevExpress.ExpressApp.Xpo.XPObjectSpace, List(Of PostedAliasValueHolder))
    Private _mObjectSpaceDeletingDictionary As New Dictionary(Of DevExpress.ExpressApp.Xpo.XPObjectSpace, List(Of PostedAliasDeletingValueHolder))
    Private _mObjectSpaceDeletingTransactionDictionary As New Dictionary(Of DevExpress.ExpressApp.Xpo.XPObjectSpace, List(Of InTransactionPersistentAliasDeletingValueHolder))


    Private _mNestedObjectSpaceTransactionDictionary As New Dictionary(Of DevExpress.ExpressApp.Xpo.XPObjectSpace, List(Of NestedInTransactionPersistentAliasDeletingValueHolder))

    Private Sub ObjectSpace_Committing(sender As Object, e As CancelEventArgs)
        Dim lstAttributes As List(Of PostedAliasPathingAttributeInfo)
        Dim vlhHolder As PostedAliasValueHolder
        Dim dtiTypeInfo As ITypeInfo
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = sender
        Dim objOldValue As Object
        Dim obsObjectSpaceParent As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
        If _mObjectSpaceDictionary.Keys.Contains(obsObjectSpace) = False Then
            _mObjectSpaceDictionary.Add(obsObjectSpace, New List(Of PostedAliasValueHolder))
        End If

        For Each obj In obsObjectSpace.ModifiedObjects
            lstAttributes = GetPostedAliasPathingInformationForDependents(obj.GetType)
            If lstAttributes.Count > 0 Then
                dtiTypeInfo = obsObjectSpace.TypesInfo.FindTypeInfo(obj.GetType)
                For Each objAttribute In lstAttributes
                    vlhHolder = New PostedAliasValueHolder
                    With vlhHolder
                        objOldValue = obsObjectSpaceParent.FindObject(dtiTypeInfo.Type, New BinaryOperator(dtiTypeInfo.KeyMember.Name,dtiTypeInfo.KeyMember.GetValue(obj)),False)
                        If objOldValue Is Nothing Then
                            .OldValue = String.Empty
                        Else
                            .OldValue = dtiTypeInfo.FindMember(objAttribute.Attribute.DependentMemberName).SerializeValue(objOldValue)
                        End If
                        .PersistentObject = obj
                        .PersistentType = dtiTypeInfo
                        .AttributeReference = objAttribute
                        .OldParent = dtiTypeInfo.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).GetValue(objOldValue)
                    End With
                    _mObjectSpaceDictionary(sender).Add(vlhHolder)
                Next
            End If

        Next

    End Sub

    Private Sub ObjectSpace_Committed(sender As Object, e As EventArgs)
        Dim lstValues As List(Of PostedAliasValueHolder) = _mObjectSpaceDictionary(sender)
        Dim strNewValue As String
        Dim objParent As Object
        Dim objCurrent As Object
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
        For Each vlhHolder As PostedAliasValueHolder In lstValues
            strNewValue = vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.DependentMemberName).SerializeValue(vlhHolder.PersistentObject)
            objParent = vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).GetValue(vlhHolder.PersistentObject)
            If strNewValue <> vlhHolder.OldValue OrElse vlhHolder.OldParent IsNot objParent Then
                If vlhHolder.OldParent IsNot Nothing AndAlso vlhHolder.OldParent IsNot objParent Then
                    objCurrent = obsObjectSpace.GetObject(vlhHolder.OldParent)
                    vlhHolder.AttributeReference.TargetMethod.Invoke(objCurrent, {obsObjectSpace.Session.Evaluate(objCurrent.GetType, CriteriaOperator.Parse(vlhHolder.AttributeReference.Attribute.PersistentAlias), New BinaryOperator(vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).MemberTypeInfo.KeyMember.Name, vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).MemberTypeInfo.KeyMember.GetValue(objCurrent)))})
                    If vlhHolder.AttributeReference.SourceClass.FindMember("OptimisticLockField") IsNot Nothing Then
                        vlhHolder.AttributeReference.SourceClass.FindMember("OptimisticLockField").SetValue(objCurrent, vlhHolder.AttributeReference.SourceClass.FindMember("OptimisticLockField").GetValue(vlhHolder.OldParent) - 1)
                    End If
                End If
                If objParent IsNot Nothing Then
                    objCurrent = obsObjectSpace.GetObject(objParent)

                    vlhHolder.AttributeReference.TargetMethod.Invoke(objCurrent, {obsObjectSpace.Session.Evaluate(objCurrent.GetType, CriteriaOperator.Parse(vlhHolder.AttributeReference.Attribute.PersistentAlias), New BinaryOperator(vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).MemberTypeInfo.KeyMember.Name, vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).MemberTypeInfo.KeyMember.GetValue(objCurrent)))})
                    If vlhHolder.AttributeReference.SourceClass.FindMember("OptimisticLockField") IsNot Nothing Then
                        vlhHolder.AttributeReference.SourceClass.FindMember("OptimisticLockField").SetValue(objCurrent, vlhHolder.AttributeReference.SourceClass.FindMember("OptimisticLockField").GetValue(objParent) - 1)
                    End If
                End If

            End If
        Next
        _mObjectSpaceDictionary(sender).Clear
        If obsObjectSpace.ModifiedObjects.Count > 0 Then

            obsObjectSpace.CommitChanges()
            CType(sender, DevExpress.ExpressApp.Xpo.XPObjectSpace).Refresh()
        End If
        
    End Sub

    Private Sub ObjectSpace_Disposed(sender As Object, e As EventArgs)
        Dim obs As IObjectSpace = sender
        If TypeOf obs Is INestedObjectSpace Then
            RemoveHandler obs.Committing, AddressOf NestedObjectSpace_Committing
            RemoveHandler obs.Committed, AddressOf NestedObjectSpace_Committed
        Else
            RemoveHandler obs.ObjectDeleting, AddressOf ObjectSpace_ObjectDeleting
            RemoveHandler obs.ObjectDeleted, AddressOf ObjectSpace_ObjectDeleted
            RemoveHandler obs.ObjectChanged, AddressOf ObjectSpace_ObjectChanged
            RemoveHandler obs.Committing, AddressOf ObjectSpace_Committing
            RemoveHandler obs.Committed, AddressOf ObjectSpace_Committed
            RemoveHandler obs.Disposed, AddressOf ObjectSpace_Disposed
        End If

    End Sub

    Private Sub ObjectSpace_ObjectChanged(sender As Object, e As ObjectChangedEventArgs)
        If e.Object Is Nothing Then
            Return
        End If
        Dim dtiTypeInfo As ITypeInfo
        Dim imiParentMemberInfo As IMemberInfo
        Dim objParent As Object
        Dim obs As IObjectSpace = sender
        Dim obsOldObject As Object
        Dim lstAttributes As List(Of InTransactionPersistentAliasPathingAttributeInfo) = GetInTransactionPersistentAliasPathingInformationForDependents(e.Object.GetType)
        Dim obsObjectSpaceParent As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace

        For Each objAttribute In lstAttributes
            dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(e.Object.GetType)
            imiParentMemberInfo = dtiTypeInfo.FindMember(objAttribute.Attribute.PathToProperty)
            objParent = imiParentMemberInfo.GetValue(e.Object)
            If objParent IsNot Nothing Then
                obs.SetModified(objParent, objAttribute.ParentCollectionProperty)
                obs.SetModified(objParent, objAttribute.TargetProperty)
            End If
            obsOldObject = obsObjectSpaceParent.FindObject(dtiTypeInfo.Type, New BinaryOperator(dtiTypeInfo.KeyMember.Name, dtiTypeInfo.KeyMember.GetValue(e.Object)), False)
            objParent = imiParentMemberInfo.GetValue(obsOldObject)
            If objParent IsNot Nothing Then
                obs.SetModified(obs.GetObject(objParent), objAttribute.ParentCollectionProperty)
                obs.SetModified(obs.GetObject(objParent), objAttribute.TargetProperty)

            End If
        Next

        'lstAttributes = GetInTransactionPersistentAliasPathingInformationForParents(e.Object.GetType)
        'For Each objAttribute In lstAttributes
        '    If e.PropertyName <> objAttribute.TargetProperty.Name Then
        '        obs.SetModified(e.Object, objAttribute.TargetProperty)
        '    End If
        'Next

    End Sub

    Private Sub ObjectSpace_ObjectDeleting(sender As Object, e As ObjectsManipulatingEventArgs)
        Dim lstPostedAttributes As List(Of PostedAliasPathingAttributeInfo)
        Dim lstInTransactionAttributes As List(Of InTransactionPersistentAliasPathingAttributeInfo)
        Dim vlhPostedHolder As PostedAliasDeletingValueHolder
        Dim vlhInTransactionHolder As InTransactionPersistentAliasDeletingValueHolder
        Dim dtiTypeInfo As ITypeInfo
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = sender
        Dim objOldValue As Object
        Dim obsObjectSpaceParent As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
        If _mObjectSpaceDeletingDictionary.Keys.Contains(obsObjectSpace) = False Then
            _mObjectSpaceDeletingDictionary.Add(obsObjectSpace, New List(Of PostedAliasDeletingValueHolder))
        End If

        If _mObjectSpaceDeletingTransactionDictionary.Keys.Contains(obsObjectSpace) = False Then
            _mObjectSpaceDeletingTransactionDictionary.Add(obsObjectSpace, New List(Of InTransactionPersistentAliasDeletingValueHolder))
        End If

        For Each obj In e.Objects
            dtiTypeInfo = obsObjectSpace.TypesInfo.FindTypeInfo(obj.GetType)

            lstPostedAttributes = GetPostedAliasPathingInformationForDependents(obj.GetType)
            If lstPostedAttributes.Count > 0 Then

                For Each objAttribute In lstPostedAttributes
                    vlhPostedHolder = New PostedAliasDeletingValueHolder
                    With vlhPostedHolder
                        .PersistentType = dtiTypeInfo
                        .AttributeReference = objAttribute
                        .OldParent = dtiTypeInfo.FindMember(vlhPostedHolder.AttributeReference.Attribute.PathToParentFromMember).GetValue(obsObjectSpaceParent.GetObject(obj))
                    End With
                    If vlhPostedHolder.OldParent IsNot Nothing Then
                        _mObjectSpaceDeletingDictionary(sender).Add(vlhPostedHolder)
                    End If

                Next
            End If
            lstInTransactionAttributes = GetInTransactionPersistentAliasPathingInformationForDependents(obj.GetType)
            If lstInTransactionAttributes.Count > 0 Then
                For Each objAttribute In lstInTransactionAttributes
                    vlhInTransactionHolder = New InTransactionPersistentAliasDeletingValueHolder
                    With vlhInTransactionHolder
                        .PersistentType = dtiTypeInfo
                        .AttributeReference = objAttribute
                        .OldParent = dtiTypeInfo.FindMember(vlhInTransactionHolder.AttributeReference.Attribute.PathToProperty).GetValue(obsObjectSpaceParent.GetObject(obj))
                    End With
                    If vlhInTransactionHolder.OldParent IsNot Nothing Then
                        _mObjectSpaceDeletingTransactionDictionary(sender).Add(vlhInTransactionHolder)
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub ObjectSpace_ObjectDeleted(sender As Object, e As ObjectsManipulatingEventArgs)
        Dim lstValues As List(Of PostedAliasDeletingValueHolder) = _mObjectSpaceDeletingDictionary(sender)
        Dim objCurrent As Object
        Dim obs As IObjectSpace = sender
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim lstInTransactionHolders As List(Of InTransactionPersistentAliasDeletingValueHolder) = _mObjectSpaceDeletingTransactionDictionary(sender)
        'process old parents posted method
        For Each vlhHolder As PostedAliasDeletingValueHolder In lstValues
            objCurrent = obsObjectSpace.GetObject(vlhHolder.OldParent)
            vlhHolder.AttributeReference.TargetMethod.Invoke(objCurrent, {obsObjectSpace.Session.Evaluate(objCurrent.GetType, CriteriaOperator.Parse(vlhHolder.AttributeReference.Attribute.PersistentAlias), New BinaryOperator(vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).MemberTypeInfo.KeyMember.Name, vlhHolder.PersistentType.FindMember(vlhHolder.AttributeReference.Attribute.PathToParentFromMember).MemberTypeInfo.KeyMember.GetValue(objCurrent)))})
        Next
        'process old parents transaction properties
        If lstInTransactionHolders.Count > 0 Then
            For Each vlhHolder In lstInTransactionHolders
                obs.SetModified(obs.GetObject(vlhHolder.OldParent), vlhHolder.AttributeReference.TargetProperty)
            Next
        End If

        _mObjectSpaceDeletingTransactionDictionary(sender).Clear()
        _mObjectSpaceDeletingDictionary(sender).Clear()
        If obsObjectSpace.ModifiedObjects.Count > 0 Then
            obsObjectSpace.CommitChanges()
            CType(sender, DevExpress.ExpressApp.Xpo.XPObjectSpace).Refresh()
        End If
    End Sub

    Private Sub NestedObjectSpace_Committing(sender As Object, e As CancelEventArgs)
        Dim lstInTransactionAttributes As List(Of InTransactionPersistentAliasPathingAttributeInfo)
        Dim vlhInTransactionHolder As NestedInTransactionPersistentAliasDeletingValueHolder
        Dim dtiTypeInfo As ITypeInfo
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = sender
        Dim objOldValue As Object
        Dim obsObjectSpaceParent As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace

        If _mNestedObjectSpaceTransactionDictionary.Keys.Contains(obsObjectSpace) = False Then
            _mNestedObjectSpaceTransactionDictionary.Add(obsObjectSpace, New List(Of NestedInTransactionPersistentAliasDeletingValueHolder))
        End If

        For Each obj In obsObjectSpace.ModifiedObjects
            dtiTypeInfo = obsObjectSpace.TypesInfo.FindTypeInfo(obj.GetType)
            lstInTransactionAttributes = GetInTransactionPersistentAliasPathingInformationForDependents(obj.GetType)
            If lstInTransactionAttributes.Count > 0 Then
                For Each objAttribute In lstInTransactionAttributes
                    vlhInTransactionHolder = New NestedInTransactionPersistentAliasDeletingValueHolder
                    With vlhInTransactionHolder
                        .PersistentType = dtiTypeInfo
                        .AttributeReference = objAttribute
                        .OldParent = dtiTypeInfo.FindMember(vlhInTransactionHolder.AttributeReference.Attribute.PathToProperty).GetValue(obsObjectSpaceParent.GetObject(obj))
                        .NewParent = dtiTypeInfo.FindMember(vlhInTransactionHolder.AttributeReference.Attribute.PathToProperty).GetValue(obsObjectSpace.GetObject(obj))
                    End With
                    If vlhInTransactionHolder.OldParent IsNot Nothing OrElse vlhInTransactionHolder.NewParent IsNot Nothing Then
                        _mNestedObjectSpaceTransactionDictionary(sender).Add(vlhInTransactionHolder)
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub NestedObjectSpace_Committed(sender As Object, e As EventArgs)
        Dim obs As IObjectSpace = sender
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace = Application.CreateObjectSpace
        Dim lstInTransactionHolders As List(Of NestedInTransactionPersistentAliasDeletingValueHolder) = _mNestedObjectSpaceTransactionDictionary(sender)
        'process old parents transaction properties
        If lstInTransactionHolders.Count > 0 Then
            For Each vlhHolder In lstInTransactionHolders
                If vlhHolder.OldParent IsNot Nothing Then
                    obs.SetModified(obs.GetObject(vlhHolder.OldParent), vlhHolder.AttributeReference.TargetProperty)
                End If
                If vlhHolder.NewParent IsNot Nothing Then
                    obs.SetModified(obs.GetObject(vlhHolder.NewParent), vlhHolder.AttributeReference.TargetProperty)
                End If

            Next
        End If

        _mNestedObjectSpaceTransactionDictionary(sender).Clear()
        If obsObjectSpace.ModifiedObjects.Count > 0 Then
            obsObjectSpace.CommitChanges()
            CType(sender, DevExpress.ExpressApp.Xpo.XPObjectSpace).Refresh()
        End If
    End Sub



End Class

Public Class PostedAliasValueHolder
    Public PersistentObject As Object
    Public PersistentType As ITypeInfo
    Public OldValue As String
    Public OldParent As Object
    Public AttributeReference As PostedAliasPathingAttributeInfo

End Class

Public Class PostedAliasDeletingValueHolder
    Public PersistentType As ITypeInfo
    Public OldParent As Object
    Public AttributeReference As PostedAliasPathingAttributeInfo

End Class

Public Class NestedInTransactionPersistentAliasDeletingValueHolder
    Public PersistentType As ITypeInfo
    Public OldParent As Object
    Public NewParent As Object
    Public AttributeReference As InTransactionPersistentAliasPathingAttributeInfo

End Class
Public Class InTransactionPersistentAliasDeletingValueHolder
    Public PersistentType As ITypeInfo
    Public OldParent As Object
    Public NewParent As Object
    Public AttributeReference As InTransactionPersistentAliasPathingAttributeInfo

End Class

Public Class PostedAliasPathingAttributeInfo
    Public SourceClass As ITypeInfo
    Public TargetMethod As Reflection.MethodInfo
    Public Attribute As PostedAliasAttribute
End Class

Public Class InTransactionPersistentAliasPathingAttributeInfo
    Public SourceClass As ITypeInfo
    Public Attribute As InTransactionPersistentAliasAttribute
    Public TargetProperty As IMemberInfo
    Public ParentCollectionProperty As IMemberInfo
End Class
