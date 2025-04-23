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

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(ISSBaseDiskFileAttachment), True)> _
Public Class FileUploadEditor
    Inherits ASPxStringPropertyEditor

    Private _mFileUploadControl As FileUploadStringControl
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)
        
    End Sub

    Public Property FileUploadControl() As FileUploadStringControl
        Get
            Return _mFileUploadControl
        End Get
        Set(ByVal value As FileUploadStringControl)
            If _mFileUploadControl Is value Then
                Return
            End If
            _mFileUploadControl = value
        End Set
    End Property


    Protected Overrides Function CreateViewModeControlCore() As System.Web.UI.WebControls.WebControl
        Dim dhpHyperLink As ASPxHyperLink = RenderHelper.CreateASPxHyperLink
        Return dhpHyperLink
    End Function

    Protected Overrides Function CreateControlCore() As Object
        _mFileUploadControl = New FileUploadStringControl(Me)
        _mFileUploadControl.ShowUploadButton = True
        _mFileUploadControl.ShowProgressPanel = True
        '_mFileUploadControl.ButtonStyle.Border.BorderWidth = 1
        '_mFileUploadControl.ButtonStyle.Border.BorderColor = Drawing.Color.Black
        _mFileUploadControl.ButtonStyle.CssClass = "dxpUploadButton_xaf"
        '_mFileUploadControl.ButtonStyle.BackColor = Drawing.Color.Gray
        Return _mFileUploadControl
    End Function



End Class

Public Class FileUploadStringControl
    Inherits DevExpress.Web.ASPxUploadControl

    Public Sub New()

    End Sub
    Public Sub New(ByVal ownerControl As DevExpress.Web.ASPxWebControl)
        MyBase.New(ownerControl)

    End Sub

    Private _mOwnerEditor As Object
    Public Property OwnerEditor() As Object
        Get
            Return _mOwnerEditor
        End Get
        Set(ByVal value As Object)
            If _mOwnerEditor Is value Then
                Return
            End If
            _mOwnerEditor = Value
        End Set
    End Property

    Public Sub New(ByVal ownerEditor As Object)
        Me.OwnerEditor = ownerEditor
    End Sub

End Class

