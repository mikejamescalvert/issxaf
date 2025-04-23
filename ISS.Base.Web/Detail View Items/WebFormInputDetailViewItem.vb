Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports DevExpress.ExpressApp
Imports System.Web.UI.WebControls

Public Class WebFormInputDetailViewItem
    Inherits ViewItem

    Private _mCaption As String

    Private _mControl As DevExpress.Web.ASPxTextBox

    Private _mVisible As Boolean = True
    Public Sub New(ByVal objectType As System.Type, ByVal id As String)
        MyBase.New(objectType, id)
        
    End Sub


    Public Property Visible() As Boolean
        Get
            Return _mVisible
        End Get
        Set(ByVal value As Boolean)
            _mVisible = value
            If _mControl IsNot Nothing Then
                _mControl.Visible = _mVisible
            End If
        End Set
    End Property

    Protected Overrides Function CreateControlCore() As Object
        _mControl = New DevExpress.Web.ASPxTextBox
        _mControl.EnableClientSideAPI = True
        _mControl.Visible = _mVisible
        _mControl.Width = New Unit(100, UnitType.Percentage)
        Return _mControl
    End Function
    Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Perform the required actions on the server side.
        RaiseEvent ActionExecuted(sender, e)
    End Sub

    Public Event ActionExecuted As EventHandler

End Class
