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
''' Creates an editor which allows tokened comma delimited object selection and returns comma delimited list
''' </summary>
<PropertyEditor(GetType(String), False)>
Public Class StringTokenizedLookupEditor
    Inherits StringPropertyEditor

    Private WithEvents _mRepository As RepositoryItemTokenEdit

    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


#Region "Properties"
    Public ReadOnly Property IsSimpleString() As Boolean
        Get
            Return MemberInfo.MemberType IsNot GetType(String) OrElse Model.RowCount = 0
        End Get
    End Property
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
        Dim ctrControl As New TokenEdit

        Return ctrControl
    End Function


    Protected Overrides Function CreateRepositoryItem() As RepositoryItem
        _mRepository = New RepositoryItemTokenEdit
        Return _mRepository
    End Function

    Private _mAttribute As StringTokenizedLookupEditorAttribute
    Private _mTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo
    Private _mDisplayMember As IMemberInfo
    Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        _mRepository = item

        'Me.MemberInfo

        _mAttribute = MemberInfo.FindAttribute(Of StringTokenizedLookupEditorAttribute)

        If _mAttribute Is Nothing Then
            Return
        End If
        _mTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(_mAttribute.SourceObjectType)
        If _mTypeInfo Is Nothing Then
            Return
        End If
        _mDisplayMember = _mTypeInfo.FindMember(_mAttribute.PropertyName)
        If _mDisplayMember Is Nothing Then
            Return
        End If



        _mRepository.MaxTokenCount = 1
        _mRepository.DropDownShowMode = TokenEditDropDownShowMode.Outlook

        _mRepository.EditMode = TokenEditMode.Manual
        _mRepository.Separators.Add(",")
    End Sub

    Private Sub LookupStringEditor_ControlCreated(sender As Object, e As EventArgs) Handles Me.ControlCreated
        _mRepository.Tokens.Clear()

        If Me.View Is Nothing OrElse Me.View.ObjectSpace Is Nothing Then
            Return
        End If
        For Each xpoObj In Me.View.ObjectSpace.CreateCollection(_mTypeInfo.Type)
            If _mDisplayMember.SerializeValue(xpoObj) = String.Empty Then
                Continue For
            End If
            _mRepository.Tokens.Add(New TokenEditToken(_mDisplayMember.SerializeValue(xpoObj), _mDisplayMember.SerializeValue(xpoObj)))
        Next
    End Sub

    Private Sub _mRepository_ValidateToken(sender As Object, e As TokenEditValidateTokenEventArgs) Handles _mRepository.ValidateToken
        e.IsValid = True
    End Sub

#End Region


End Class
