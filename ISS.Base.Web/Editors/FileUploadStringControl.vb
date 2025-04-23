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

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(IO.FileInfo), True)> _
Public Class FileUploadStringEditor
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
            _mFileUploadControl = Value
        End Set
    End Property


    Protected Overrides Function CreateViewModeControlCore() As System.Web.UI.WebControls.WebControl
        Dim dhpHyperLink As ASPxHyperLink = RenderHelper.CreateASPxHyperLink
        Return dhpHyperLink
    End Function

    Protected Overrides Function CreateControlCore() As Object
        _mFileUploadControl = New FileUploadStringControl
        _mFileUploadControl.Native = True
        _mFileUploadControl.ShowUploadButton = True
        _mFileUploadControl.ShowProgressPanel = True
        Return _mFileUploadControl
    End Function



End Class

Public Class FileUploadStringControl
    Inherits DevExpress.Web.ASPxUploadControl

End Class
