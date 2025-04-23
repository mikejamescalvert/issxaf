Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports DevExpress.ExpressApp
Imports System.Web.UI.WebControls

Public Class WebLiteralDetailViewItem
    Inherits ViewItem

    Private _mCaption As String

    Private _mPanel As Panel

    Private _mLiteral As Literal
    Public Property Literal() As Literal
        Get
            Return _mLiteral
        End Get
        Set(ByVal value As Literal)
            If _mLiteral Is value Then
                Return
            End If
            _mLiteral = Value
        End Set
    End Property

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
            If Literal IsNot Nothing Then
                Literal.Visible = _mVisible
            End If
        End Set
    End Property
    Protected Overrides Function CreateControlCore() As Object
        Literal = New Literal
        Literal.Visible = _mVisible
        Literal.Text = _mCaption
        _mPanel = New Panel
        _mPanel.Controls.Add(Literal)
        Return _mPanel
    End Function
    Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Perform the required actions on the server side.
        RaiseEvent ActionExecuted(sender, e)
    End Sub

    Public Event ActionExecuted As EventHandler

End Class
