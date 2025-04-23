Option Strict Off

Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports Microsoft.Office.Interop


Public Class DragAndDropListViewController
    Inherits DevExpress.ExpressApp.ViewController

    Private _Outlook As Object = Nothing
    Private Shared _ErrorReceived As Boolean = False

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.ListView
        Me.TargetObjectType = GetType(IAttachment)
        Try

            If _ErrorReceived = False Then
                _Outlook = CreateObject("Outlook.Application")
            End If
        Catch ex As Exception
            _ErrorReceived = True
        End Try
    End Sub

    Public ReadOnly Property ListView As ListView
        Get
            Return View
        End Get
    End Property

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()

        Dim lpeListPropertyEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor = ListView.Editor
        AddHandler lpeListPropertyEditor.Grid.DragEnter, AddressOf GridControl_DragEnter
        AddHandler lpeListPropertyEditor.Grid.DragDrop, AddressOf GridControl_DragDrop
    End Sub

    Public ReadOnly Property OutlookDataTypes As String()
        Get
            Return {"RenPrivateSourceFolder", _
                        "RenPrivateMessages", _
                        "RenPrivateItem", _
                        "FileGroupDescriptor", _
                        "FileGroupDescriptorW", _
                        "FileContents", _
                        "Object Descriptor"}
        End Get
    End Property

    Public ReadOnly Property FileDataTypes As String()
        Get
            Return {System.Windows.Forms.DataFormats.FileDrop}
        End Get
    End Property

    Private Sub GridControl_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs)

        If ListView.CollectionSource.AllowAdd = False Then
            e.Effect = System.Windows.Forms.DragDropEffects.None
            Return
        End If

        If OutlookDataTypes.All(Function(requiredFormat) e.Data.GetDataPresent(requiredFormat)) Then
            e.Effect = System.Windows.Forms.DragDropEffects.Copy
        End If
    End Sub


    Public Function IsFileLocked(ByVal FileName As String)
        Dim flsFileStream As IO.FileStream
        Try
            flsFileStream = IO.File.Open(FileName, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite, IO.FileShare.None)
        Catch ex As IO.IOException
            Return True
        Finally
            If flsFileStream IsNot Nothing Then
                flsFileStream.Close()
            End If
        End Try
        Return False
    End Function

    Private Sub GridControl_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)
        Dim oExplorer As Object
        Dim oSelection As Object
        Dim atcAttachment As IAttachment
        Dim strFiles() As String
        Dim ifiFileInfo As IO.FileInfo
        Dim strBaseFile As String = "temp.msg"
        Dim intAttempts As Integer = 0
        Dim strFileName As String = String.Empty
        Dim strFullPath As String = String.Empty

        If _Outlook IsNot Nothing AndAlso OutlookDataTypes.All(Function(requiredFormat) e.Data.GetDataPresent(requiredFormat)) Then
            oExplorer = _Outlook.ActiveExplorer
            oSelection = oExplorer.Selection
            For Each item In oSelection

                strFileName = strBaseFile
                strFullPath = String.Format("{0}\{1}", System.Windows.Forms.Application.LocalUserAppDataPath, strFileName)
                While IsFileLocked(strFullPath) = True
                    intAttempts += 1
                    ifiFileInfo = New IO.FileInfo(strBaseFile)
                    strFileName = strBaseFile.Substring(0, Len(strBaseFile) - Len(ifiFileInfo.Extension)) + intAttempts.ToString + ifiFileInfo.Extension
                    strFullPath = String.Format("{0}\{1}", System.Windows.Forms.Application.LocalUserAppDataPath, strFileName)
                End While

                item.SaveAs(strFullPath)
                atcAttachment = ListView.CollectionSource.ObjectSpace.CreateObject(ListView.ObjectTypeInfo.Type)
                atcAttachment.FileData = IO.File.ReadAllBytes(strFullPath)
                If item.Sent = True Then
                    atcAttachment.SetRecordDate(item.SentOn)
                Else
                    atcAttachment.SetRecordDate(item.ReceivedTime)
                End If
                atcAttachment.Description = item.Subject
                atcAttachment.SetFileName("temp.msg")
                IO.File.Delete(strFullPath)
                ListView.CollectionSource.Add(atcAttachment)
            Next
        End If

        'ListView.CollectionSource.ObjectSpace.CommitChanges()

    End Sub

End Class

