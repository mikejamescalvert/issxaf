Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports ISS.Base.Win
Imports DevExpress.Xpo

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class CameraViewController
    Inherits ViewController(Of DetailView)
    Public Sub New()
        InitializeComponent()

        TargetObjectType = GetType(Customer)
        _mTakeSnapshot = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'Attachments_PasteInformation
        '
        _mTakeSnapshot.Caption = "Take Snapshot"
        _mTakeSnapshot.Category = "View"
        _mTakeSnapshot.ConfirmationMessage = Nothing
        _mTakeSnapshot.Id = "Camera_TakeSnapshot"
        _mTakeSnapshot.ImageName = "Action_FileAttachment_Attach"
        _mTakeSnapshot.IsExecuting = False
        _mTakeSnapshot.ToolTip = Nothing

        Actions.Add(_mTakeSnapshot)
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Private WithEvents _mTakeSnapshot As SimpleAction

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()



        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub
    Public ReadOnly Property ThisDetailView As DetailView
        Get
            Return View
        End Get
    End Property
    Private Sub _mTakeSnapshot_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles _mTakeSnapshot.Execute
        Dim dveEditor As CameraEditor
        For Each dveEditor In ThisDetailView.GetItems(Of CameraEditor)
            dveEditor.TakePicture()
        Next
        Dim uow As New UnitOfWork
        uow.AutoCreateOption = DB.AutoCreateOption.SchemaAlreadyExists
        uow.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

        ISS.Notifications.NotificationHelper.DeleteNotificationsOlderThanDate(uow, Today.AddDays(-10))
    End Sub
End Class
