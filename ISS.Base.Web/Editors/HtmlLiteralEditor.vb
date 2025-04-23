Imports DevExpress.ExpressApp
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports DevExpress.ExpressApp.Model

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(String), False)> _
Public Class HtmlLiteralEditor
    Inherits DevExpress.ExpressApp.Web.Editors.WebPropertyEditor

    Protected Overrides Function GetControlValueCore() As Object
        Return _mLiteral.Text
    End Function

    Protected Overrides Sub ReadEditModeValueCore()
        _mLiteral.Text = Me.PropertyValue
    End Sub

    Protected Overrides Sub ReadValueCore()
        MyBase.ReadValueCore()
        _mLiteral.Text = Me.PropertyValue
    End Sub

    Protected Overrides Sub WriteValueCore()
        MyBase.WriteValueCore()
        PropertyValue = _mLiteral.Text

    End Sub

    Private _mPanel As Panel
    Private _mLiteral As Literal
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


    Protected Overrides Function CreateEditModeControlCore() As System.Web.UI.WebControls.WebControl
        If _mLiteral Is Nothing Then
            _mLiteral = New Literal
        End If
        If _mPanel Is Nothing Then
            _mPanel = New Panel
            _mPanel.CssClass = "HtmlLiteralPanel"
            _mPanel.Controls.Add(_mLiteral)
        End If
        Return _mPanel
    End Function
    Protected Overrides Function CreateViewModeControlCore() As System.Web.UI.WebControls.WebControl
        If _mLiteral Is Nothing Then
            _mLiteral = New Literal
        End If
        If _mPanel Is Nothing Then
            _mPanel = New Panel
            _mPanel.CssClass = "HtmlLiteralPanel"
            _mPanel.Controls.Add(_mLiteral)
        End If
        Return _mPanel
    End Function

End Class
