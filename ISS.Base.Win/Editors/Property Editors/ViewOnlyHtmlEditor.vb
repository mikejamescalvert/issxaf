Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports System.Windows.Forms
Imports ISS.Base.Attributes.Editors.ViewOnlyHtmlEditor
Imports mshtml

''' <summary>
''' Shows a web browser that renders the HTML of a string property.
''' </summary>
''' <remarks></remarks>
<PropertyEditor(GetType(String), False)> _
Public Class ViewOnlyHtmlEditor
    Inherits WinPropertyEditor
    Public Sub New(ByVal objectType As Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

    Private _mControl As WebBrowser

    Protected Overrides Function CreateControlCore() As Object
        _mControl = New WebBrowser
        Dim veaAttribute As ViewOnlyHtmlEditorAttribute = Me.MemberInfo.FindAttribute(Of ViewOnlyHtmlEditorAttribute)()
        If veaAttribute IsNot Nothing Then
            _mControl.MinimumSize = New System.Drawing.Size(veaAttribute.MinSize, veaAttribute.MinSize)
            _mControl.ScrollBarsEnabled = veaAttribute.EnableScroll
        End If
        'ControlBindingProperty = "DocumentText"
        Return _mControl
    End Function

    Protected Overrides Sub ReadValueCore()
        If _mControl Is Nothing Then
            Return
        End If

        If _mControl.Document Is Nothing Then
            _mControl.DocumentText = "<html></html>"
        Else
            CType(_mControl.Document.DomDocument, IHTMLDocument2).clear()
        End If


        CType(_mControl.Document.DomDocument, IHTMLDocument2).write(Me.PropertyValue)
        CType(_mControl.Document.DomDocument, IHTMLDocument2).close()
        '_mControl.Document.Body.InnerHtml = Me.PropertyValue
        'MyBase.ReadValueCore()

    End Sub

    'Protected Overrides Sub WriteValueCore()
    '    MyBase.WriteValueCore()
    'End Sub

End Class
