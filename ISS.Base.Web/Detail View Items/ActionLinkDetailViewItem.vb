'INSTANT VB NOTE: This code snippet uses implicit typing. You will need to set 'Option Infer On' in the VB file or set 'Option Infer' at the project level:

Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.Web
Imports DevExpress.ExpressApp.Model
Imports ISS.Base
Imports DevExpress.ExpressApp.Editors

<ViewItemAttribute(GetType(IActionLinkDetailViewItem))> _
Public Class ActionLinkDetailViewItem
    Inherits ISS.Base.ActionLinkDetailViewItem

    Private _mCaption As String

    Public Sub New(ByVal model As IModelViewItem, ByVal objectType As Type)
        MyBase.New(model, objectType)
        _mCaption = model.Caption
        CreateControl()
    End Sub
    Public Sub New(ByVal theModel As IActionLinkDetailViewItem, ByVal theType As Type)
        MyBase.New(theModel, theType)
        _mCaption = theModel.Caption
        CreateControl()
    End Sub
    Public Sub New(ByVal objectType As Type, ByVal id As String)
        MyBase.New(objectType, id)
        
    End Sub


    Protected Overrides Function CreateControlCore() As Object
        Dim button = New ASPxButton With {.Text = _mCaption}
        AddHandler button.Click, AddressOf InvokeExecuted
        button.Visible = ControlVisible
        Return button
    End Function
End Class
