Imports DevExpress.ExpressApp.Win
'... 
Public Class CustomSplashScreen
    Implements ISplash, ISupportUpdateSplash

    Private Shared form As SplashScreenForm
    Private _isStarted As Boolean
    Public Sub Start() Implements ISplash.Start
        _isStarted = True
        If form Is Nothing Then
            form = New SplashScreenForm()

        End If
        
        form.Properties.UseFadeInEffect = False
        form.Properties.UseFadeOutEffect = False
        form.Show()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub [Stop]() Implements ISplash.Stop
        If form IsNot Nothing Then
            form.Hide()
        End If
        _isStarted = False
    End Sub
    Public Sub SetDisplayText(ByVal displayText As String) Implements ISplash.SetDisplayText
        form.UpdateDescription(displayText)
        form.BringToFront()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public ReadOnly Property IsStarted() As Boolean Implements ISplash.IsStarted
        Get
            Return _isStarted
        End Get
    End Property

    Public Sub UpdateSplash(caption As String, description As String, ParamArray additionalParams() As Object) Implements ISupportUpdateSplash.UpdateSplash
        If form IsNot Nothing Then
            form.Text = caption
            form.UpdateDescription(description)
            If additionalParams IsNot Nothing AndAlso additionalParams.Length > 0 AndAlso TypeOf additionalParams(0) Is Decimal Then
                form.UpdateProgress(additionalParams(0))
            End If
            form.BringToFront()
            System.Windows.Forms.Application.DoEvents()
        End If

    End Sub
End Class