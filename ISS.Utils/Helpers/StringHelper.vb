Public Class StringHelper

    Public Shared Function GetStringWithMaxLength(ByVal StringValue As String, ByVal Length As Integer) As String
        If String.IsNullOrEmpty(StringValue) = True Then
            Return String.Empty
        End If
        If StringValue.Length > Length Then
            Return StringValue.Substring(0, Length)
        Else
            Return StringValue
        End If
    End Function

End Class
