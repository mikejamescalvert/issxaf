Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Helpers
    Public Class MessageHelper
        Public Shared Function ShowMessage(ByVal Session As Session, ByVal HeaderMessage As String, ByVal MessageCollection As List(Of String), ByVal MessageType As ISSBaseEndUserMessage.MessageTypes) As ISSBaseEndUserMessage.MessageReturnValues
            Dim svpShowView As New ShowViewParameters
            Dim svsViewSource As New ShowViewSource(Nothing, Nothing)
            Dim obsSpace As Xpo.XPObjectSpace = Helpers.ApplicationHelper.XAFApplication.CreateObjectSpace
            Dim oEndUserMessage As New ISSBaseEndUserMessage(obsSpace.Session)
            Dim dlgController As New DevExpress.ExpressApp.SystemModule.DialogController
            oEndUserMessage.Setup(HeaderMessage, MessageCollection)
            If MessageType = ISSBaseEndUserMessage.MessageTypes.Informative Then
                dlgController.CancelAction.Active.SetItemValue("", False)
            Else
                dlgController.AcceptAction.Caption = "Yes"
                dlgController.CancelAction.Caption = "No"
            End If
            svpShowView.Context = DevExpress.ExpressApp.TemplateContext.PopupWindow
            svpShowView.CreateAllControllers = True
            svpShowView.Controllers.Add(dlgController)
            svpShowView.CreatedView = Helpers.ApplicationHelper.XAFApplication.CreateDetailView(obsSpace, oEndUserMessage, True)
            CType(svpShowView.CreatedView, DetailView).ViewEditMode = Editors.ViewEditMode.View
            svpShowView.TargetWindow = TargetWindow.NewModalWindow
            AddHandler dlgController.Accepting, AddressOf MarkAccepted
            Helpers.ApplicationHelper.XAFApplication.ShowViewStrategy.ShowView(svpShowView, svsViewSource)

            If MessageType = ISSBaseEndUserMessage.MessageTypes.Informative Then
                Return ISSBaseEndUserMessage.MessageReturnValues.InformativeOk
            Else
                If oEndUserMessage.Accepted = True Then
                    Return ISSBaseEndUserMessage.MessageReturnValues.Yes
                Else
                    Return ISSBaseEndUserMessage.MessageReturnValues.No
                End If
            End If
        End Function

        Private Shared Sub MarkAccepted(ByVal sender As Object, ByVal e As EventArgs)
            Dim dlgController As DevExpress.ExpressApp.SystemModule.DialogController = sender
            Dim oEndUserMessage As ISSBaseEndUserMessage = dlgController.Window.View.CurrentObject
            oEndUserMessage.Accepted = True
        End Sub

        Public Shared Function ShowMessage(ByVal Session As Session, ByVal HeaderMessage As String, ByVal Message As String, ByVal MessageType As ISSBaseEndUserMessage.MessageTypes) As ISSBaseEndUserMessage.MessageReturnValues
            Dim lstMessages As New List(Of String)
            lstMessages.Add(Message)
            Return ShowMessage(Session, HeaderMessage, lstMessages, MessageType)
        End Function
        Public Shared Function ShowSimpleMessage(ByVal Session As Session, ByVal Message As String) As ISSBaseEndUserMessage.MessageReturnValues
            Dim svpShowView As New ShowViewParameters
            Dim svsViewSource As New ShowViewSource(Nothing, Nothing)
            Dim obsSpace As Xpo.XPObjectSpace = Helpers.ApplicationHelper.XAFApplication.CreateObjectSpace
            Dim oEndUserMessage As New ISSBaseEndUserMessageDetail(obsSpace.Session)
            oEndUserMessage.Message = Message
            Dim dlgController As New DevExpress.ExpressApp.SystemModule.DialogController
            dlgController.CancelAction.Active.SetItemValue("", False)
            'If MessageType = ISSBaseEndUserMessage.MessageTypes.Informative Then
            '    dlgController.CancelAction.Active.SetItemValue("", False)
            'Else
            '    dlgController.AcceptAction.Caption = "Yes"
            '    dlgController.CancelAction.Caption = "No"
            'End If
            svpShowView.Context = DevExpress.ExpressApp.TemplateContext.PopupWindow
            svpShowView.CreateAllControllers = True
            svpShowView.Controllers.Add(dlgController)
            svpShowView.CreatedView = Helpers.ApplicationHelper.XAFApplication.CreateDetailView(obsSpace, oEndUserMessage, True)
            CType(svpShowView.CreatedView, DetailView).ViewEditMode = Editors.ViewEditMode.View
            svpShowView.TargetWindow = TargetWindow.NewModalWindow
            'AddHandler dlgController.Accepting, AddressOf MarkAccepted
            Helpers.ApplicationHelper.XAFApplication.ShowViewStrategy.ShowView(svpShowView, svsViewSource)

            'If MessageType = ISSBaseEndUserMessage.MessageTypes.Informative Then
            '    Return ISSBaseEndUserMessage.MessageReturnValues.InformativeOk
            'Else
            '    If oEndUserMessage.Accepted = True Then
            '        Return ISSBaseEndUserMessage.MessageReturnValues.Yes
            '    Else
            '        Return ISSBaseEndUserMessage.MessageReturnValues.No
            '    End If
            'End If
        End Function
    End Class
End Namespace