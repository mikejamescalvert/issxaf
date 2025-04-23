Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Model
Imports ISS.Base.Attributes.Editors.PropertyEditors
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Security

Public Class OpenObjectController
    Inherits DevExpress.ExpressApp.Win.SystemModule.OpenObjectController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Private ReadOnly _mControlToEditorMap As New Dictionary(Of System.Windows.Forms.Control, DevExpress.ExpressApp.Win.Editors.WinPropertyEditor)()

    Public Sub SubscribeToGrid()
        If CType(CType(View, ListView).Editor, GridListEditor).Grid IsNot Nothing Then
            AddHandler CType(CType(View, ListView).Editor, GridListEditor).GridView.FocusedColumnChanged, AddressOf GridView_FocusedColumnChanged
        End If
    End Sub

    Public Sub UnSubscribeFromGrid()
        If CType(CType(View, ListView).Editor, GridListEditor).Grid IsNot Nothing Then
            RemoveHandler CType(CType(View, ListView).Editor, GridListEditor).GridView.FocusedColumnChanged, AddressOf GridView_FocusedColumnChanged
        End If
    End Sub

    Public Sub SubscribeToEditor(ByVal WinPropertyEditor As DevExpress.ExpressApp.Win.Editors.WinPropertyEditor)
        If WinPropertyEditor.Control IsNot Nothing Then
            AddHandler WinPropertyEditor.Control.GotFocus, AddressOf Control_Focused
        End If
    End Sub

    Public Sub UnSubscribeFromEditor(ByVal WinPropertyEditor As DevExpress.ExpressApp.Win.Editors.WinPropertyEditor)
        If WinPropertyEditor.Control IsNot Nothing Then
            RemoveHandler WinPropertyEditor.Control.GotFocus, AddressOf Control_Focused
        End If
    End Sub
    Private Sub GridView_FocusedColumnChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim strPropertyName As String = GetFocusedPropertyNameForListView()
        Dim mmiModelInfo As IModelMember = Nothing
        If strPropertyName > String.Empty Then
            UpdateActionStateForFocusedProperty(View.ObjectTypeInfo.FindMember(strPropertyName))
        Else
            OpenObjectAction.Enabled.SetItemValue("AllowPropertyEditor", True)
        End If

    End Sub

    Public Function GetFocusedPropertyNameForListView() As String
        Dim strFieldName As String = String.Empty
        Dim lstListView As ListView = View
        If lstListView Is Nothing OrElse lstListView.Editor Is Nothing OrElse CType(CType(View, ListView).Editor, GridListEditor).GridView Is Nothing OrElse CType(CType(View, ListView).Editor, GridListEditor).GridView.FocusedColumn Is Nothing Then
            Return String.Empty
        End If
        Dim obj As XafGridColumnWrapper

        For Each obj In CType(CType(View, ListView).Editor, GridListEditor).Columns
            If obj.Column Is CType(CType(View, ListView).Editor, GridListEditor).GridView.FocusedColumn Then
                Return obj.PropertyName
            End If
            
        Next

        Return String.Empty
    End Function
    Private Sub Control_Focused(ByVal sender As Object, ByVal e As EventArgs)
        Dim wpeEditor As WinPropertyEditor = Nothing
        _mControlToEditorMap.TryGetValue(sender, wpeEditor)
        If wpeEditor IsNot Nothing Then
            If wpeEditor.Model IsNot Nothing AndAlso wpeEditor.Model.ModelMember IsNot Nothing Then
                UpdateActionStateForFocusedProperty(wpeEditor.Model.ModelMember)
            Else
                OpenObjectAction.Enabled.SetItemValue("AllowPropertyEditor", True)
            End If
        End If
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        _mControlToEditorMap.Clear()
        If TypeOf View Is DetailView Then
            For Each wpeWinPropertyEditor As DevExpress.ExpressApp.Win.Editors.WinPropertyEditor In CType(View, DetailView).GetItems(Of DevExpress.ExpressApp.Win.Editors.WinPropertyEditor)()
                If wpeWinPropertyEditor.Control IsNot Nothing Then
                    _mControlToEditorMap.Add(wpeWinPropertyEditor.Control, wpeWinPropertyEditor)
                    UnSubscribeFromEditor(wpeWinPropertyEditor)
                    SubscribeToEditor(wpeWinPropertyEditor)
                End If
            Next
        Else
            If TypeOf CType(View, ListView).Editor Is GridListEditor Then
                UnSubscribeFromGrid()
                SubscribeToGrid()
            End If
        End If
    End Sub

    Protected Overrides Sub OnDeactivated()
        MyBase.OnDeactivated()
        If TypeOf View Is DetailView Then
            For Each wpeWinPropertyEditor As DevExpress.ExpressApp.Win.Editors.WinPropertyEditor In CType(View, DetailView).GetItems(Of DevExpress.ExpressApp.Win.Editors.WinPropertyEditor)()
                If wpeWinPropertyEditor.Control IsNot Nothing Then
                    UnSubscribeFromEditor(wpeWinPropertyEditor)
                End If
            Next
        Else
            If TypeOf CType(View, ListView).Editor Is GridListEditor Then
                UnSubscribeFromGrid()
            End If
        End If
    End Sub

    Public Sub UpdateActionStateForFocusedProperty(ByVal ModelInfo As IModelMember)
        If ModelInfo Is Nothing Then
            OpenObjectAction.Enabled.SetItemValue("AllowPropertyEditor", True)
            Return
        End If
        UpdateActionStateForFocusedProperty(ModelInfo.MemberInfo)
    End Sub


    Public Sub UpdateActionStateForFocusedProperty(ByVal MemberInfo As IMemberInfo)
        If MemberInfo Is Nothing Then
            OpenObjectAction.Enabled.SetItemValue("AllowPropertyEditor", True)
            Return
        End If
        Dim aoeAllowOpenObjectAttribute As AllowOpenObjectAttribute = MemberInfo.FindAttribute(Of AllowOpenObjectAttribute)()
        If aoeAllowOpenObjectAttribute IsNot Nothing Then
            OpenObjectAction.Enabled.SetItemValue("AllowPropertyEditor", aoeAllowOpenObjectAttribute.Allow)
        Else
            OpenObjectAction.Enabled.SetItemValue("AllowPropertyEditor", True)
        End If

        'does have navigate access to object type
        Dim oapPermission As New ObjectAccessPermission(MemberInfo.MemberType,ObjectAccess.Navigate)
        OpenObjectAction.Enabled.SetItemValue("CanNavigate", SecuritySystem.IsGranted(oapPermission))

    End Sub

End Class
