Imports System
Imports System.ComponentModel
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Web.Editors
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports DevExpress.Web
Imports DevExpress.ExpressApp.Model

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(String), False)> _
Public Class HyperlinkEditor
    Inherits ASPxPropertyEditor


    Protected Overrides Function CreateViewModeControlCore() As System.Web.UI.WebControls.WebControl
        Me.HyperlinkControl = RenderHelper.CreateASPxHyperLink()
        Return Me.HyperlinkControl
    End Function

    Protected Overrides Function CreateEditModeControlCore() As System.Web.UI.WebControls.WebControl
        Me.HyperlinkControl = RenderHelper.CreateASPxHyperLink()
        Return Me.HyperlinkControl
    End Function

    Private _mHyperlinkControl As ASPxHyperLink
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

    Public Property HyperlinkControl() As ASPxHyperLink
        Get
            Return _mHyperlinkControl
        End Get
        Set(ByVal value As ASPxHyperLink)
            If _mHyperlinkControl Is value Then
                Return
            End If
            _mHyperlinkControl = value
        End Set
    End Property

    Protected Overrides Sub ReadEditModeValueCore()
        Dim oHyperlink As ASPxHyperLink = InplaceViewModeEditor
        Dim mmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo = ObjectTypeInfo.FindMember(Me.PropertyName)
        Dim strPropertyValue As String = mmiMemberInfo.SerializeValue(Me.CurrentObject)
        If strPropertyValue > String.Empty Then
            oHyperlink.Text = strPropertyValue
            oHyperlink.NavigateUrl = strPropertyValue
        End If
    End Sub

End Class
