Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.Model

Public MustInherit Class ActionLinkDetailViewItem
    Inherits ViewItem
    Public Sub New(ByVal model As IModelViewItem, ByVal objectType As Type)
        MyBase.New(objectType, model.Id)
        CreateControl()
    End Sub

    Private _mModel As IActionLinkDetailViewItem
    Public ReadOnly Property ActionID As String
        Get
            If _mModel.ActionID Is Nothing Then
                Return String.Empty
            End If
            Return _mModel.ActionID.Id
        End Get
    End Property
    Public Sub New(ByVal theModel As IActionLinkDetailViewItem, ByVal theType As Type)
        MyBase.New(theType, theModel.Id)
        _mModel = theModel
    End Sub
    Public Sub New(ByVal objectType As Type, ByVal id As String)
        MyBase.New(objectType, id)

    End Sub


    Public Event Executed As EventHandler

    Protected Sub InvokeExecuted(ByVal sender As Object, ByVal e As EventArgs)
        Dim handler As EventHandler = ExecutedEvent
        If handler IsNot Nothing Then
            handler(Me, e)
        End If
    End Sub


    Public Property ControlVisible() As Boolean = True

    Public Overridable Sub SetControlVisibility(ByVal Visible As Boolean)
        ControlVisible = Visible
        If Me.Control IsNot Nothing Then
            Me.Control.Visible = Visible
        End If
    End Sub

    Protected Overrides Function CreateControlCore() As Object

    End Function

End Class
