Imports System.Runtime.CompilerServices
Imports DevExpress.ExpressApp.DC

Public Module CompilerExtensions




    ''' <summary>
    ''' Truncates a string based on the passed in length
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="Length"></param>
    ''' <returns></returns>
    ''' <remarks>Located in the ISS.ExtensionMethods assembly</remarks>
    <Extension()>
    Function issTruncate(ByVal value As String,
                  ByVal Length As Integer)
        If String.IsNullOrEmpty(value) Then
            Return value
        End If
        If value.Length < Length Then
            Return value
        Else
            Return Left(value, Length)
        End If
    End Function

    <Extension()>
    Function issSubstituteTokens(ByVal value As String,
                  SourceObject As Object,
                  TokenEncapsulator As TokenEncapsulatorTypes)
        If value Is Nothing Then
            Return value
        End If
        Dim colTokens As New System.Collections.Specialized.StringCollection
        Dim strtoken As String
        Dim strFormatString As String
        Dim intStartPosition As Integer?
        Dim PI As System.Reflection.PropertyInfo
        Dim strNewValue As String = value
        Dim strStartDelimiter As String
        Dim strEndDelimiter As String
        Dim strOriginalToken As String
        Dim strOriginalValue As String = value
        Dim dtiTypeInfo As ITypeInfo = Nothing
        Dim dmiMemberInfo As IMemberInfo

        Select Case TokenEncapsulator
            Case TokenEncapsulatorTypes.Braces
                strStartDelimiter = "{"
                strEndDelimiter = "}"

            Case TokenEncapsulatorTypes.Brackets
                strStartDelimiter = "["
                strEndDelimiter = "]"
            Case Else
                Throw New Exception("Invalid delimited type passed in!")

        End Select

        Try


            For j = 0 To value.Length - 1
                If value.Substring(j, 1) = strStartDelimiter AndAlso intStartPosition Is Nothing Then
                    intStartPosition = j
                End If
                If value.Substring(j, 1) = strEndDelimiter AndAlso intStartPosition.HasValue Then
                    If Not colTokens.Contains(value.Substring(intStartPosition, j - intStartPosition+1)) Then
                        colTokens.Add(value.Substring(intStartPosition, j - intStartPosition+1))
                    End If
                    intStartPosition = Nothing
                End If
            Next
            If SourceObject IsNot Nothing
                dtiTypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(SourceObject.GetType)
            

            End If
            If dtiTypeInfo IsNot Nothing Then
                For Each strtoken In colTokens
                    strFormatString = String.Empty
                    If strtoken.Contains("|") Then
                        strOriginalToken = strtoken
                        strFormatString = strtoken.Substring(strtoken.IndexOf("|") + 1)
                        strFormatString = strFormatString.Replace("]", "")
                        strtoken = strtoken.Substring(0, strtoken.IndexOf("|"))
                        strtoken = strtoken + "]"
                    End If
                    dmiMemberInfo = dtiTypeInfo.FindMember(strtoken.Replace(strStartDelimiter, "").Replace(strEndDelimiter, ""))
                    If dmiMemberInfo IsNot Nothing Then

                        If dmiMemberInfo.MemberType IsNot Nothing AndAlso dmiMemberInfo.MemberType.IsEnum = True Then
                            'todo: generate enum

                            value = value.Replace(strtoken, System.Enum.GetName(dmiMemberInfo.MemberType, dmiMemberInfo.GetValue(SourceObject)))
                        Else
                            If strFormatString > String.Empty Then

                                value = value.Replace(strOriginalToken, String.Format("{0:" + strFormatString + "}", dmiMemberInfo.GetValue(SourceObject)))
                            Else
                                value = value.Replace(strtoken, dmiMemberInfo.SerializeValue(SourceObject))
                            End If

                        End If

                    End If
                Next
            Else
                For Each strtoken In colTokens

                    value = value.Replace(strtoken, GetPropertyValue(SourceObject, strtoken.Replace(strStartDelimiter, "").Replace(strEndDelimiter, "")))
                Next
            End If

            Return value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetPropertyValue(SourceObject As Object, TargetProperty As String) As Object
        Dim intPropertyDelimiter As Integer = TargetProperty.IndexOf(".")
        Dim ChildProperty As System.Reflection.PropertyInfo
        If intPropertyDelimiter >= 0 Then
            ChildProperty = SourceObject.GetType.GetProperty(TargetProperty.Substring(0, intPropertyDelimiter))
            Return GetPropertyValue(ChildProperty.GetValue(SourceObject, Nothing), TargetProperty.Substring(intPropertyDelimiter + 1, TargetProperty.Length - (intPropertyDelimiter + 1)))
        Else
            ChildProperty = SourceObject.GetType.GetProperty(TargetProperty)
            If ChildProperty.PropertyType.IsEnum Then
                System.Enum.GetName(ChildProperty.PropertyType, ChildProperty.GetValue(SourceObject, Nothing))
            Else
                Return ChildProperty.GetValue(SourceObject, Nothing)
            End If


        End If


    End Function

End Module

Public Enum TokenEncapsulatorTypes
    Braces
    Brackets
End Enum