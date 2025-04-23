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

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class AutoRefreshListViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        ' Perform various tasks depending on the target View.

        'todo: load last refresh rate from model settings

    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private WithEvents _mTimers As Timers.Timer


    Const RefreshRateInSecondsErrorMessage As String = "Please put the auto refresh rate in seconds"

    Private Sub AutoRefreshRateInSeconds_Changed(sender As Object, e As ActionChangedEventArgs) Handles AutoRefreshRateInSeconds.Changed
        SetupAutoRefresh()
    End Sub
    Private Sub AutoRefreshRateInSeconds_Execute(sender As Object, e As ParametrizedActionExecuteEventArgs) Handles AutoRefreshRateInSeconds.Execute
        SetupAutoRefresh()
    End Sub

    Public Sub SetupAutoRefresh()
        If String.IsNullOrEmpty(AutoRefreshRateInSeconds.Value) = True Then
            Return
            'Throw New UserFriendlyException(RefreshRateInSecondsErrorMessage)
        End If

        If IsNumeric(AutoRefreshRateInSeconds.Value) = False Then
            Return
            'Throw New UserFriendlyException(RefreshRateInSecondsErrorMessage)
        End If

        'todo: save seconds to database

        If _mTimers IsNot Nothing Then
            _mTimers.Stop()
            _mTimers = Nothing
        End If

        _mTimers = New Timers.Timer
        _mTimers.AutoReset = False
        _mTimers.Interval = Decimal.Parse(AutoRefreshRateInSeconds.Value) * 1000
        _mTimers.Start()
    End Sub

    Private Sub _mTimers_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles _mTimers.Elapsed
        Try
            ObjectSpace.Refresh()
            View.Refresh()
        Catch ex As Exception
            Throw
        Finally
            _mTimers.Start()
        End Try

    End Sub

    Private Sub AutoRefreshRateInSeconds_ValueChanged(sender As Object, e As EventArgs) Handles AutoRefreshRateInSeconds.ValueChanged
        SetupAutoRefresh()
    End Sub
End Class
