Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Model

<PropertyEditor(GetType(System.Reflection.PropertyInfo), True)> _
Public Class WorkflowMasterPropertyTypeEditor
    Inherits StringPropertyEditor

    Private _mObjectCustomization As ISSBaseBusinessRules

    Private _mParentObject As System.Type
    Public Property ParentObject() As System.Type
        Get
            Return _mParentObject
        End Get
        Set(ByVal value As System.Type)
            If _mParentObject Is value Then
                Return
            End If
            _mParentObject = value
        End Set
    End Property


    Protected Overrides Function CreateControlCore() As Object
        Dim objComboBox As New DevExpress.XtraEditors.ImageComboBoxEdit
        Return objComboBox
    End Function

    Protected Overrides Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem
        Dim objRepositoryItem As New WorkflowPropertyEditorRepositoryItem
        objRepositoryItem.Tag = Me
        Return objRepositoryItem
    End Function

    Protected Overrides Sub SetupRepositoryItem(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        Dim objRepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = item
        Dim objWorkflowPropertyTemplate As ISSBaseEditorStateTemplate
        'Dim objNotificationPropertyTemplate As ISSBaseNotificationPropertyEmailTemplate
        Dim objWorkflowStep As ISSBaseWorkflowStep
        Dim objISSBaseCustomCaption As ISSBaseCustomCaption

        If Me.CurrentObject IsNot Nothing Then
            If Me.CurrentObject.GetType Is GetType(ISSBaseEditorStateTemplate) Then
                objWorkflowPropertyTemplate = Me.CurrentObject
                _mObjectCustomization = objWorkflowPropertyTemplate.ObjectTemplate.ObjectCustomization
                SetupValues(objRepositoryItem)
            ElseIf Me.CurrentObject.GetType Is GetType(ISSBaseWorkflowStep) Then
                objWorkflowStep = Me.CurrentObject
                _mObjectCustomization = objWorkflowStep.ObjectCustomization
                SetupValues(objRepositoryItem)
            ElseIf Me.CurrentObject.GetType Is GetType(ISSBaseCustomCaption) Then
                objISSBaseCustomCaption = Me.CurrentObject
                _mObjectCustomization = objISSBaseCustomCaption.ObjectCustomization
                SetupValues(objRepositoryItem)
            'ElseIf Me.CurrentObject.GetType Is GetType(ISSBaseNotificationPropertyEmailTemplate) Then
            '    objNotificationPropertyTemplate = Me.CurrentObject
            '    _mObjectCustomization = objNotificationPropertyTemplate.NotificationTemplate.ObjectCustomization
            '    SetupValues(objRepositoryItem)
            End If
        End If
    End Sub

    'Public Shared Sub SetupValuesWithAttributeType(ByVal RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox, ByVal ParentType As System.Type, ByVal AttributeType As System.Type)
    '    Dim dmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo = Nothing
    '    Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = Nothing
    '    If ParentType IsNot Nothing Then
    '        For Each objPropertyInfo As System.Reflection.PropertyInfo In ParentType.GetProperties
    '            If objPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.XPCustomObject) AndAlso _
    '                    objPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.XPBaseObject) AndAlso _
    '                    objPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.PersistentBase) Then
    '                dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ParentType)
    '                If dtiTypeInfo IsNot Nothing Then
    '                    dmiMemberInfo = dtiTypeInfo.FindMember(objPropertyInfo.Name)
    '                End If
    '                If dmiMemberInfo IsNot Nothing Then
    '                    RepositoryItemComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(dmiMemberInfo.Name, objPropertyInfo))
    '                Else
    '                    RepositoryItemComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(objPropertyInfo.Name, objPropertyInfo))
    '                End If
    '                dtiTypeInfo = Nothing
    '                dmiMemberInfo = Nothing
    '            End If
    '        Next
    '    End If
    'End Sub
    'Public Shared Sub SetupValues(ByVal RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox, ByVal ParentType As System.Type)
    '    Dim dmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo = Nothing
    '    Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = Nothing
    '    If ParentType IsNot Nothing Then
    '        For Each objPropertyInfo As System.Reflection.PropertyInfo In ParentType.GetProperties
    '            If objPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.XPCustomObject) AndAlso _
    '                    objPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.XPBaseObject) AndAlso _
    '                    objPropertyInfo.DeclaringType IsNot GetType(DevExpress.Xpo.PersistentBase) Then
    '                dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ParentType)
    '                If dtiTypeInfo IsNot Nothing Then
    '                    dmiMemberInfo = dtiTypeInfo.FindMember(objPropertyInfo.Name)
    '                End If
    '                If dmiMemberInfo IsNot Nothing Then
    '                    RepositoryItemComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(dmiMemberInfo.Name, objPropertyInfo))
    '                Else
    '                    RepositoryItemComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(objPropertyInfo.Name, objPropertyInfo))
    '                End If
    '                dtiTypeInfo = Nothing
    '                dmiMemberInfo = Nothing
    '            End If
    '        Next
    '    End If
    'End Sub

    Private _mBuildProperties As New List(Of System.Type)
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)
        
    End Sub


    Public Sub SetObjectCustomization(ByVal ObjectCustomization As ISSBaseBusinessRules)
        _mObjectCustomization = ObjectCustomization
    End Sub

    Public Sub SetupValues(ByVal RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox)
        Dim rpiPropertyInfo As System.Reflection.PropertyInfo
        Dim cmiComboBoxItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem
        Try
            If _mObjectCustomization Is Nothing OrElse _mObjectCustomization.ObjectType Is Nothing Then
                Return
            End If
            _mBuildProperties.Clear()
            RepositoryItemComboBox.Items.Clear()
            RepositoryItemComboBox.Sorted = True
            'RepositoryItemComboBox.Sorted = True
            'RepositoryItemComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(objPropertyInfo.Name, objPropertyInfo))
            _mBuildProperties.Add(_mObjectCustomization.ObjectType)
            For Each rpiPropertyInfo In _mObjectCustomization.ObjectType.GetProperties
                If rpiPropertyInfo.DeclaringType Is GetType(DevExpress.Xpo.XPCustomObject) Then
                    Continue For
                End If

                If rpiPropertyInfo.DeclaringType Is GetType(XPBaseObject) Then
                    Continue For
                End If

                If rpiPropertyInfo.DeclaringType Is GetType(BaseObject) Then
                    Continue For
                End If

                If rpiPropertyInfo.DeclaringType Is GetType(DevExpress.Xpo.PersistentBase) Then
                    Continue For
                End If

                cmiComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(String.Format("{0}.{1}", rpiPropertyInfo.ReflectedType.Name, rpiPropertyInfo.Name), rpiPropertyInfo)
                RepositoryItemComboBox.Items.Add(cmiComboBoxItem)

                If _mBuildProperties.Contains(rpiPropertyInfo.PropertyType) = True Then
                    Continue For
                End If

                _mBuildProperties.Add(rpiPropertyInfo.PropertyType)
                If rpiPropertyInfo.PropertyType.IsSubclassOf(GetType(DevExpress.Xpo.PersistentBase)) Then
                    BuildChildProperties(RepositoryItemComboBox, rpiPropertyInfo.PropertyType)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub BuildChildProperties(ByVal RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox, ByVal ObjectType As System.Type)
        Dim rpiPropertyInfo As System.Reflection.PropertyInfo
        Dim cmiComboBoxItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem
        For Each rpiPropertyInfo In ObjectType.GetProperties
            If rpiPropertyInfo.DeclaringType Is GetType(DevExpress.Xpo.XPCustomObject) Then
                Continue For
            End If
            If rpiPropertyInfo.DeclaringType Is GetType(DevExpress.Xpo.XPBaseObject) Then
                Continue For
            End If
            If rpiPropertyInfo.DeclaringType Is GetType(BaseObject) Then
                Continue For
            End If

            If rpiPropertyInfo.DeclaringType Is GetType(DevExpress.Xpo.PersistentBase) Then
                Continue For
            End If

            cmiComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(String.Format("{0}.{1}", rpiPropertyInfo.ReflectedType.Name, rpiPropertyInfo.Name), rpiPropertyInfo)
            RepositoryItemComboBox.Items.Add(cmiComboBoxItem)

            If _mBuildProperties.Contains(rpiPropertyInfo.PropertyType) <> False Then
                Continue For
            End If

            _mBuildProperties.Add(rpiPropertyInfo.PropertyType)
            If rpiPropertyInfo.PropertyType.IsSubclassOf(GetType(DevExpress.Xpo.PersistentBase)) Then
                BuildChildProperties(RepositoryItemComboBox, rpiPropertyInfo.PropertyType)
            End If
        Next
    End Sub

End Class

Public Class WorkflowPropertyEditorRepositoryItem
    Inherits DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

End Class