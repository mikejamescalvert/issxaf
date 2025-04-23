Public Class StringHelper


    Public Shared Function Truncate(ByVal value As String, length As Integer) As String
        If String.IsNullOrEmpty(value) Then
            Return value
        End If
        If value.Length < length Then
            Return value
        Else
            Return Left(value, length)
        End If

    End Function

    Public Shared Function SubstituteTokens(ByVal value As String, SourceObject As Object, TokenEncapsulator As TokenEncapsulatorTypes) As String
        Dim colTokens As New System.Collections.Specialized.StringCollection
        Dim strtoken As String
        Dim intStartPosition As Integer?
        Dim PI As System.Reflection.PropertyInfo
        Dim strNewValue As String = value
        Dim strStartDelimiter As String
        Dim strEndDelimiter As String
        Dim strOriginalValue As String = value
        Select Case TokenEncapsulator
            Case TokenEncapsulatorTypes.Braces
                strStartDelimiter = "{"
                strEndDelimiter = "}"

            Case TokenEncapsulatorTypes.Brackets
                strStartDelimiter = "["
                strEndDelimiter = "]"


        End Select

        Try


            For j = 0 To value.Length - 1
                If value.Substring(j, 1) = strStartDelimiter AndAlso intStartPosition Is Nothing Then
                    intStartPosition = j
                End If
                If value.Substring(j, 1) = strEndDelimiter AndAlso intStartPosition.HasValue Then
                    If Not colTokens.Contains(value.Substring(intStartPosition, j - intStartPosition + 1)) Then
                        colTokens.Add(value.Substring(intStartPosition, j - intStartPosition + 1))
                    End If
                    intStartPosition = Nothing
                End If
            Next

            If colTokens.Count > 0 Then
                For Each strtoken In colTokens

                    'PI = SourceObject.GetType.GetProperty(strtoken.Replace(strStartDelimiter, "").Replace(strEndDelimiter, ""))
                    'If PI IsNot Nothing Then
                    '	value = value.Replace(strtoken, PI.GetValue(SourceObject, Nothing).ToString)
                    'Else
                    '	value = value.Replace(strtoken, "")
                    'End If
                    value = value.Replace(strtoken, GetPropertyValue(SourceObject, strtoken.Replace(strStartDelimiter, "").Replace(strEndDelimiter, "")))
                Next
            End If

            Return value
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Shared Function GetPropertyValue(SourceObject As Object, TargetProperty As String) As Object
        Dim intPropertyDelimiter As Integer = TargetProperty.IndexOf(".")
        Dim ChildProperty As System.Reflection.PropertyInfo
        If intPropertyDelimiter >= 0 Then
            ChildProperty = SourceObject.GetType.GetProperty(TargetProperty.Substring(0, intPropertyDelimiter))
            Return GetPropertyValue(ChildProperty.GetValue(SourceObject, Nothing), TargetProperty.Substring(intPropertyDelimiter + 1, TargetProperty.Length - (intPropertyDelimiter + 1)))
        Else
            ChildProperty = SourceObject.GetType.GetProperty(TargetProperty)
            Return ChildProperty.GetValue(SourceObject, Nothing)
        End If


    End Function
End Class
