Imports System
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web.UI.WebControls

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model

Public Class AlwaysEditInListView
    Inherits ListEditor


    Private _mGridControl As DevExpress.Web.ASPxGridView
    Public Property GridControl() As DevExpress.Web.ASPxGridView
        Get
            Return _mGridControl
        End Get
        Set(ByVal value As DevExpress.Web.ASPxGridView)
            If _mGridControl Is value Then
                Return
            End If
            _mGridControl = value
        End Set
    End Property

    Public Overrides ReadOnly Property RequiredProperties() As String()
        Get
            Return New String() {String.Empty}
        End Get
    End Property


    Protected Overrides Function CreateControlsCore() As Object
        GridControl = New DevExpress.Web.ASPxGridView
        GridControl.ID = "control"
        Return GridControl
    End Function

    Public Overrides Sub Refresh()
        'If Control IsNot Nothing Then
        '    Control.Refresh()
        'End If
    End Sub

    Protected Overloads Overrides Sub AssignDataSourceToControl(ByVal dataSource As Object)
        If Control IsNot Nothing Then
            Control.DataSource = dataSource
        End If
    End Sub

    Private _mFocusedObject As Object
    Public Sub New(ByVal model As DevExpress.ExpressApp.Model.IModelListView)
        MyBase.New(model)

    End Sub
    Public Sub New()

    End Sub

    Public Overrides Property FocusedObject() As Object
        Get
            If GridControl Is Nothing Then
                Return Nothing
            End If
            Return GridControl.GetRow(GridControl.FocusedRowIndex)
        End Get
        Set(ByVal value As Object)
            _mFocusedObject = value
        End Set
    End Property

    Public Overrides ReadOnly Property ContextMenuTemplate() As DevExpress.ExpressApp.Templates.IContextMenuTemplate
        Get
            Return Nothing
        End Get
    End Property




    Public Overrides Function GetSelectedObjects() As System.Collections.IList
        Dim lstRows As New List(Of Object)
        If GridControl Is Nothing Then
            Return New List(Of Object)
        End If
        For intLoop As Integer = 0 To GridControl.VisibleRowCount
            If GridControl.IsGroupRow(intLoop) = False Then
                If GridControl.Selection.IsRowSelected(intLoop) = True Then
                    lstRows.Add(GridControl.GetRow(intLoop))
                End If
            End If
        Next
        Return lstRows
    End Function

    Public Overrides ReadOnly Property SelectionType() As DevExpress.ExpressApp.SelectionType
        Get
            Return DevExpress.ExpressApp.SelectionType.MultipleSelection
        End Get
    End Property




End Class
