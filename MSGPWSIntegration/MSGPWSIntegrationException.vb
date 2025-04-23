
Public Class MSGPWSIntegrationException
    Inherits ApplicationException
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal Message As String)
        MyBase.New(Message)

    End Sub
    Public Sub New(ByVal Message As String, ByVal Source As String)
        MyBase.New(Message)
        MyBase.Source = Source
    End Sub
    Public Sub New(ByVal Message As String, ByVal Exception As Exception)
        MyBase.New(Message, Exception)
    End Sub


End Class


