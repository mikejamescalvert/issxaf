Public Class DhlLabel
    Public Property LabelId As String
    Public ReadOnly Property FileName As String
        Get
            Return String.Format("{0}.pdf", LabelId)
        End Get
    End Property
    Public Property LabelData As Byte()
    Public Property TrackingCode As String
End Class
