Namespace Interfaces
    Public Interface IMessageProvider
        Event SendMessageCollection(ByVal MessageHeader As String, ByVal Message As List(Of String), ByVal MessageType As ISSBaseEndUserMessage.MessageTypes)
        Event SendMessage(ByVal MessageHeader As String, ByVal Messages As String, ByVal MessageType As ISSBaseEndUserMessage.MessageTypes)
    End Interface
End Namespace
