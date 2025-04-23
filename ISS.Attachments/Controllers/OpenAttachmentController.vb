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
Imports System.Windows.Forms

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class OpenAttachmentController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        Me.TargetObjectType = GetType(IAttachment)
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        If ThisListView IsNot Nothing Then
            ThisListView.AllowNew("CreateAttachmentsNotAllowed") = False
        End If
        Dim lpoProcess As ListViewProcessCurrentObjectController = Frame.GetController(Of ListViewProcessCurrentObjectController)
        If lpoProcess IsNot Nothing Then
            AddHandler lpoProcess.CustomProcessSelectedItem, AddressOf LPO_CustomProcessSelectedItem

        End If
    End Sub
    Private _mAttachmentHandler As Boolean = False
    Private Sub LPO_CustomProcessSelectedItem(sender As Object, e As CustomProcessListViewSelectedItemEventArgs)
        If _mAttachmentHandler = True Then
            e.Handled = True
            AttachmentService.OpenFile(ThisCurrentObject)
        End If

    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Public Property AttachmentService As New AttachmentService

    ReadOnly Property ThisCurrentObject As IAttachment
        Get
            Return View.CurrentObject
        End Get
    End Property

    ReadOnly Property ThisListView As DevExpress.ExpressApp.ListView
        Get
            If TypeOf View Is DevExpress.ExpressApp.ListView Then
                Return View
            Else
                Return Nothing

            End If
        End Get
    End Property
    Private _mThisDetailView As Object
    ReadOnly Property ThisDetailView As DetailView
        Get
            If TypeOf View Is DetailView Then
                Return View
            Else
                Return Nothing
            End If
        End Get
    End Property



    Private Sub OpenAttachment_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles OpenAttachment.Execute
        'Dim lpoProcess As ListViewProcessCurrentObjectController = Frame.GetController(Of ListViewProcessCurrentObjectController)
        'If lpoProcess IsNot Nothing Then
        '    _mAttachmentHandler = True
        '    lpoProcess.ProcessCurrentObjectAction.DoExecute()
        '    _mAttachmentHandler = False
        'End If
        AttachmentService.OpenFile(ThisCurrentObject)
    End Sub

    Private Sub Attachments_UploadAttachment_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles Attachments_UploadAttachment.Execute
        Dim ofdOpenFileDialog As New OpenFileDialog
        Dim xpoAttachment As IAttachment
        Dim ifiFileInfo As IO.FileInfo
        ofdOpenFileDialog.Title = "Please select a file to upload"
        ofdOpenFileDialog.Multiselect = True
        If ofdOpenFileDialog.ShowDialog() = DialogResult.OK Then
            For Each strFile In ofdOpenFileDialog.FileNames
                ifiFileInfo = New IO.FileInfo(strFile)
                xpoAttachment = ObjectSpace.CreateObject(View.ObjectTypeInfo.Type)
                xpoAttachment = ThisListView.CollectionSource.ObjectSpace.CreateObject(ThisListView.ObjectTypeInfo.Type)
                xpoAttachment.FileData = IO.File.ReadAllBytes(strFile)
                xpoAttachment.SetRecordDate(ifiFileInfo.LastWriteTime)

                xpoAttachment.Description = ifiFileInfo.Name
                xpoAttachment.SetFileName(ifiFileInfo.Name)
                CType(View, DevExpress.ExpressApp.ListView).CollectionSource.Add(xpoAttachment)
            Next
        End If
    End Sub

    Private Sub Attachments_SaveAttachment_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles Attachments_SaveAttachment.Execute
        Dim sfdSaveFileDialog As New SaveFileDialog
        'Dim xpoAttachment As IAttachment
        'Dim ifiFileInfo As IO.FileInfo
        If ThisCurrentObject Is Nothing Then
            Throw New Exception("No attachment selected")
        End If
        sfdSaveFileDialog.Title = "Choose a save location"
        sfdSaveFileDialog.FileName = ThisCurrentObject.FileName
        If sfdSaveFileDialog.ShowDialog() = DialogResult.OK Then
            AttachmentService.DownloadFile(ThisCurrentObject, sfdSaveFileDialog.FileName)
            'For Each strFile In ofdOpenFileDialog.FileNames
            '    ifiFileInfo = New IO.FileInfo(strFile)
            '    xpoAttachment = ObjectSpace.CreateObject(View.ObjectTypeInfo.Type)
            '    xpoAttachment = ThisListView.CollectionSource.ObjectSpace.CreateObject(ThisListView.ObjectTypeInfo.Type)
            '    xpoAttachment.FileData = IO.File.ReadAllBytes(strFile)
            '    xpoAttachment.SetRecordDate(ifiFileInfo.LastWriteTime)

            '    xpoAttachment.Description = ifiFileInfo.Name
            '    xpoAttachment.SetFileName(ifiFileInfo.Name)
            '    CType(View, DevExpress.ExpressApp.ListView).CollectionSource.Add(xpoAttachment)
            'Next
        End If
    End Sub
End Class
