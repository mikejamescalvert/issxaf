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
Imports System.ComponentModel

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class MutexViewHandlerController
    Inherits WindowController
    Public Sub New()
        TargetWindowType = WindowType.Main
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub

    Private _mTimers As Timers.Timer

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        If _mBackgroundWorker Is Nothing Then
            _mBackgroundWorker = New BackgroundWorker()
            _mBackgroundWorker.WorkerReportsProgress = True
            _mBackgroundWorker.WorkerSupportsCancellation = True
            _mBackgroundWorker.RunWorkerAsync()
        End If

        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
        _mCancelWorker = True
    End Sub

    Private Shared _mViewShortcuts As New List(Of ViewShortcut)

    Private _mThreadLocked As Boolean = False
    Private _mThreadComplete As Boolean = False


    Public Sub ProcessViewShortcuts()
        If _mThreadLocked = True OrElse Frame Is Nothing Then
            Return
        End If
        _mThreadLocked = True
        Try

            Dim sctShortcut As ViewShortcut
            Dim svpParamters As New ShowViewParameters
            Dim svsShowViewSource As ShowViewSource


            For index = _mViewShortcuts.Count - 1 To 0 Step -1
                sctShortcut = New ViewShortcut(_mViewShortcuts(index).ViewId, _mViewShortcuts(index).ObjectKey)
                sctShortcut = Application.GetCompletedViewShortcut(sctShortcut)
                svpParamters.CreatedView = Application.ProcessShortcut(sctShortcut)
                svsShowViewSource = New ShowViewSource(Frame, Nothing)

                Application.ShowViewStrategy.ShowView(svpParamters, svsShowViewSource)

                'CType(Frame.Template, System.Windows.Forms.Form).Invoke(
                '    Sub()
                '        Application.ShowViewStrategy.ShowView(svpParamters, svsShowViewSource)
                '    End Sub)

                _mViewShortcuts.RemoveAt(index)
            Next
        Catch ex As Exception
            Throw
        Finally
            _mThreadLocked = False
        End Try





    End Sub

    Public Shared Sub AddShortcutToQueue(ByVal ViewShortcutToAdd As ViewShortcut)
        _mViewShortcuts.Add(ViewShortcutToAdd)
    End Sub

    Private WithEvents _mBackgroundWorker As BackgroundWorker
    Private _mCancelWorker As Boolean = False

    Private Sub MutexViewHandlerController_FrameAssigned(sender As Object, e As EventArgs) Handles Me.FrameAssigned


    End Sub

    Private Sub _mBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _mBackgroundWorker.DoWork
        While _mThreadLocked = True
            Threading.Thread.Sleep(100)
        End While
        Threading.Thread.Sleep(1000)
    End Sub


    Private Sub _mBackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _mBackgroundWorker.RunWorkerCompleted
        ProcessViewShortcuts()
        _mBackgroundWorker.RunWorkerAsync()
    End Sub
End Class
