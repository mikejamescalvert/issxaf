Public Class BackgroundProcessForm


    Private Delegate Sub Increment()
    Private IncrementApp As Increment = AddressOf CrossThreadIncrementControl

    Private _mMethodDelegate As [Delegate]
    Public Property MethodDelegate() As [Delegate]
        Get
            Return _mMethodDelegate
        End Get
        Set(ByVal value As [Delegate])
            If _mMethodDelegate = Value Then
                Return
            End If
            _mMethodDelegate = Value
        End Set
    End Property

    Private _mExecutingObject As Object
    Public Property ExecutingObject() As Object
        Get
            Return _mExecutingObject
        End Get
        Set(ByVal value As Object)
            If _mExecutingObject = Value Then
                Return
            End If
            _mExecutingObject = Value
        End Set
    End Property

    Private Sub Execute()
        Me.bgwMethodExecuter.RunWorkerAsync()
    End Sub

    Public Sub IncrementControl()
        Me.Invoke(IncrementApp)
    End Sub

    Private Sub CrossThreadIncrementControl()
        ProgressBarControl.Increment(1)
        ProgressBarControl.Update()
    End Sub

    Public Event BeginProcessing(ByVal sender As Object)

    Public Sub New(ByVal MaxRecords As Integer, ByVal MethodDelegate As [Delegate], ByVal ExecutingObject As Object, Optional ByVal DisplayMessage As String = Nothing)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        If DisplayMessage > String.Empty Then
            Me.ProgressLabel.Text = DisplayMessage
        End If

        ' Add any initialization after the InitializeComponent() call.
        Me.ProgressBarControl.Properties.Step = 1
        Me.ProgressBarControl.Properties.PercentView = True
        Me.ProgressBarControl.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Broken
        Me.ProgressBarControl.Properties.Maximum = MaxRecords
        Me.ProgressBarControl.Properties.Minimum = 0

        Me.MethodDelegate = MethodDelegate

    End Sub

    Private Sub bgwMethodExecuter_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwMethodExecuter.DoWork
        Me.MethodDelegate.Method.Invoke(ExecutingObject, Reflection.BindingFlags.InvokeMethod, Nothing, Nothing, Nothing)
    End Sub

    Private Sub bgwMethodExecuter_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwMethodExecuter.RunWorkerCompleted
        Me.Close()
    End Sub

    Private Sub BackgroundProcessForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Execute()
    End Sub
End Class