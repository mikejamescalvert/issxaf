Public Class SplashScreenForm
    Sub New
        InitializeComponent()
        labelControl1.Text = String.Format("Copyright © {0}", DateTime.Today.Year)
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Public Sub UpdateDescription(ByVal description As String)
        labelControl2.Text = description
    End Sub

    Public Sub UpdateProgress(ByVal percentage As Decimal)

    End Sub

End Class
