Public Class Helper
    ''' <summary>
    ''' Evaluates properties of the Target object to determine if the customer attribute MSGPRequireField
    ''' exists and if the field value is not nothing to satisfy the requirement.
    ''' Throws an MSGPRequiredFieldValidationException if a required field is not complete
    ''' 
    ''' </summary>
    ''' <param name="Target"></param>
    ''' <remarks></remarks>
    Public Shared Sub ValidateMSGPRequiredFieldsComplete(ByVal Target As Object)
        If Target Is Nothing Then Return

        Dim sb As New System.Text.StringBuilder
        For Each PI As System.Reflection.PropertyInfo In Target.GetType.GetProperties()
            If PI.GetCustomAttributes(GetType(MSGPRequiredFieldAttribute), False).Length > 0 AndAlso PI.GetValue(Target, Nothing) Is Nothing Then
                sb.AppendLine(Target.GetType.Name & "." & PI.Name)
            End If
        Next
        If sb.Length > 0 Then
            Throw New MSGPRequiredFieldValidationException(sb.ToString)
        End If

    End Sub
End Class
