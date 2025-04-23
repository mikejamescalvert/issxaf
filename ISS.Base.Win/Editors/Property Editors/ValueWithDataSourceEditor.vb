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
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.SystemModule
Imports ISS.Base.Helpers
Imports DevExpress.XtraEditors
Imports Alias1 = System.Collections.Generic
Imports ISS.Base.Interfaces
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win.Core.ModelEditor
Imports ISS.Base.Attributes.Editors.TextEditor
Imports System.Windows.Forms

''' <summary>
''' Creates an editor which has a drop down with a data source for the string value properties
''' </summary>
<PropertyEditor(GetType(String), False)>
Public Class ValueWithDataSourceEditor
    Inherits StringPropertyEditor

    Private WithEvents _mRepository As RepositoryItemComboBox


    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


#Region "Properties"
    Public ReadOnly Property IsSimpleString() As Boolean
        Get
            Return MemberInfo.MemberType IsNot GetType(String) OrElse Model.RowCount = 0
        End Get
    End Property
    'Public ReadOnly Property IsPropertyNameInsertEditor As Boolean
    '    Get
    '        Return (MemberInfo.FindAttribute(Of AllowPropertyOfTypeInsertAttribute)() IsNot Nothing)
    '    End Get
    'End Property
#End Region

#Region "Behaviors"
    Private Sub TextEditor_ValueRead(ByVal sender As Object, ByVal e As EventArgs) Handles Me.ValueRead
        If MemberInfo Is Nothing Then
            Return
        End If
    End Sub
    Public Overrides Sub BreakLinksToControl(ByVal unwireEventsOnly As Boolean)
        MyBase.BreakLinksToControl(unwireEventsOnly)
        If MemberInfo Is Nothing Then
            Return
        End If
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If MemberInfo Is Nothing Then
            Return
        End If
    End Sub

    Protected Overrides Function CreateControlCore() As Object
        Return New ComboBoxEdit
    End Function


    Protected Overrides Function CreateRepositoryItem() As RepositoryItem
        '_mRepository = New RepositoryItemComboBox
        Return New RepositoryItemComboBox
    End Function

    'Private _mAttribute As ValueWithDataSourceEditorAttribute
    'Private _mDisplayMember As IMemberInfo
    Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        _mRepository = item

        'Me.MemberInfo

        '_mAttribute = MemberInfo.FindAttribute(Of ValueWithDataSourceEditorAttribute)

        'If _mAttribute Is Nothing Then
        '    Return
        'End If

    End Sub

    Public Shared Sub LoadDataSourceFromObject(ByVal MemberInfo As IMemberInfo, ByVal ObjectSpace As IObjectSpace, ByVal CurrentObject As Object, ByVal RepositoryItem As RepositoryItemComboBox)
        'RepositoryItem.Items.Clear()
        If RepositoryItem.Items.Count > 0 Then
            Return
        End If
        If CurrentObject Is Nothing Then
            Return
        End If
        Dim dtiTypeInfo As TypeInfo = XafTypesInfo.Instance.FindTypeInfo(CurrentObject.GetType())
        Dim atr As ValueWithDataSourceEditorAttribute = MemberInfo.FindAttribute(Of ValueWithDataSourceEditorAttribute)
        Dim dtiValueTypeInfo As TypeInfo = Nothing
        For Each obj In dtiTypeInfo.FindMember(atr.SourceCollectionPropertyName).GetValue(CurrentObject)
            If dtiValueTypeInfo Is Nothing Then
                dtiValueTypeInfo = XafTypesInfo.Instance.FindTypeInfo(obj.GetType)
            End If

            If dtiValueTypeInfo Is Nothing OrElse dtiValueTypeInfo.FindMember(atr.ValuePropertyName) Is Nothing Then
                Throw New Exception("Type error!")
            End If

            RepositoryItem.Items.Add(dtiValueTypeInfo.FindMember(atr.ValuePropertyName).GetValue(obj))
        Next

    End Sub


    Private Sub LookupStringEditor_ControlCreated(sender As Object, e As EventArgs) Handles Me.ControlCreated

        If Me.View Is Nothing OrElse Me.View.ObjectSpace Is Nothing Then
            Return
        End If
        If View.CurrentObject Is Nothing Then
            Return
        End If
        LoadDataSourceFromObject(MemberInfo, View.ObjectSpace, View.CurrentObject, _mRepository)
        'Dim dtiTypeInfo As TypeInfo = XafTypesInfo.Instance.FindTypeInfo(View.CurrentObject.GetType())
        'Dim dtiValueTypeInfo As TypeInfo = Nothing
        'For Each obj In dtiTypeInfo.FindMember(_mAttribute.SourceCollectionPropertyName).GetValue(View.CurrentObject)
        '    If dtiValueTypeInfo Is Nothing Then
        '        dtiValueTypeInfo = XafTypesInfo.Instance.FindTypeInfo(obj.GetType)
        '    End If

        '    If dtiValueTypeInfo Is Nothing OrElse dtiValueTypeInfo.FindMember(_mAttribute.ValuePropertyName) Is Nothing Then
        '        Throw New Exception("Type error!")
        '    End If

        '    _mRepository.Items.Add(dtiValueTypeInfo.FindMember(_mAttribute.ValuePropertyName).GetValue(obj))
        'Next

        'For Each xpoObj In Me.View.ObjectSpace.CreateCollection(_mTypeInfo.Type)
        '    If _mDisplayMember.SerializeValue(xpoObj) = String.Empty Then
        '        Continue For
        '    End If
        '    _mRepository.Tokens.Add(New TokenEditToken(_mDisplayMember.SerializeValue(xpoObj), _mDisplayMember.SerializeValue(xpoObj)))
        'Next
    End Sub



#End Region


End Class
