Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports Microsoft.VisualBasic
Imports OtpNet

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class MultiFactorUserViewController
    Inherits ViewController
    ' Use CodeRush to create Controllers And Actions with a few keystrokes.
    ' https://docs.devexpress.com/CodeRushForRoslyn/403133/
    Public Sub New()
        InitializeComponent()
        TargetObjectType = DevExpress.ExpressApp.SecuritySystem.UserType
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub SetupMultifactor_Execute(sender As Object, e As PopupWindowShowActionExecuteEventArgs) Handles SetupMultifactor.Execute

    End Sub

    Private Sub SetupMultifactor_CustomizePopupWindowParams(sender As Object, e As CustomizePopupWindowParamsEventArgs) Handles SetupMultifactor.CustomizePopupWindowParams
        Dim obs As IObjectSpace = Application.CreateObjectSpace(GetType(MultiFactorAuthentication))
        Dim obj As MultiFactorAuthentication = obs.CreateObject(Of MultiFactorAuthentication)
        Dim dlg As New DialogController

        Dim imf As ISecurityUser = TryCast(View.CurrentObject, ISecurityUser)

        If imf Is Nothing Then
            Throw New Exception("Unable to find multifactor settings in user object.")
        End If

        AddHandler dlg.Accepting, AddressOf MultiFactor_AcceptingDialog
        obj.Username = imf.UserName
        obj.SetupSecretKeyAndQrCode()
        e.DialogController = dlg
        e.View = Application.CreateDetailView(obs, obj)
        CType(e.View, DetailView).ViewEditMode = ViewEditMode.Edit
    End Sub

    Private Sub MultiFactor_AcceptingDialog(sender As Object, e As DialogControllerAcceptingEventArgs)
        Dim obj As MultiFactorAuthentication = e.AcceptActionArgs.CurrentObject

        Dim base32Bytes = Base32Encoding.ToBytes(obj.UserSettings.SecretKey)
        Dim totp = New Totp(base32Bytes)

        If totp.VerifyTotp(obj.AuthenticationCode, 0, VerificationWindow.RfcSpecifiedNetworkDelay) = False Then

            Throw New Exception("Authentication code mismatch, please try again.")

            'ObjectSpace.CommitChanges()

            'e.ShowViewParameters.CreatedView.ObjectSpace.CommitChanges()
        End If
    End Sub

    Private Sub ClearMultifactorAuthentication_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles ClearMultifactorAuthentication.Execute
        Dim imf As ISecurityUser = TryCast(View.CurrentObject, ISecurityUser)
        If imf Is Nothing Then
            Dim xpoMultifactorSettings As MultifactorAuthenticationUserSettings = ObjectSpace.FindObject(Of MultifactorAuthenticationUserSettings)(New BinaryOperator("UserName", imf.UserName))
            If xpoMultifactorSettings IsNot Nothing Then
                xpoMultifactorSettings.Delete()
                ObjectSpace.CommitChanges()
            End If
        End If

    End Sub
End Class
