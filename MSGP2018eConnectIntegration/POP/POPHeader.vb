Namespace POP
    Public Class POPHeader
        Public Sub New()

        End Sub
        ''' <summary>
        ''' Will get generated if not provided
        ''' </summary>
        ''' <returns></returns>
        Public Property PONumber As String
        Public Property VendorId As String
        Public Property CreatedByUsername As String
        Public Property Lines As New List(Of POPLine)
    End Class
End Namespace

