Namespace Helpers
    Public Class ReflectionHelper

        Public Shared Function ContainsProperty(ByRef PropertyName As String, ByRef ObjectType As Type) As Boolean
            Return GetMemberInfo(PropertyName, ObjectType) IsNot Nothing
        End Function

        Public Shared Function GetMemberInfo(ByVal PropertyName As String, ByVal ObjectType As Type) As DevExpress.ExpressApp.DC.IMemberInfo
            Dim xafTypeInfo As DevExpress.ExpressApp.DC.TypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ObjectType)
            If xafTypeInfo Is Nothing Then
                Return Nothing
            End If
            Return xafTypeInfo.FindMember(PropertyName)
        End Function

        Public Shared Function GetObjectFromPropertyName(ByRef PropertyName As String, ByRef SourceObject As Object) As Object
            Dim mmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo

            If SourceObject Is Nothing Then
                Return Nothing
            End If

            If PropertyName <= String.Empty Then
                Return Nothing
            End If

            mmiMemberInfo = GetMemberInfo(PropertyName, SourceObject.GetType)
            If mmiMemberInfo Is Nothing Then
                Return Nothing
            End If

            Return mmiMemberInfo.GetValue(SourceObject)
        End Function

        Public Shared Function SetObjectPropertyName(ByRef PropertyName As String, ByRef SourceObject As Object, ByRef SetObject As Object) As Boolean
            Dim mmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo

            If SourceObject Is Nothing Then
                Return False
            End If

            If PropertyName <= String.Empty Then
                Return False
            End If

            mmiMemberInfo = GetMemberInfo(PropertyName, SourceObject.GetType)
            If mmiMemberInfo Is Nothing Then
                Return False
            End If

            mmiMemberInfo.SetValue(SourceObject, SetObject)
        End Function

        Public Shared Sub AddObjectToPropertyCollection(ByRef ObjectToAdd As Object, ByRef SourceObject As Object, ByRef PropertyName As String)
            Dim objTemp As Object
            Dim sytType As System.Type

            objTemp = GetObjectFromPropertyName(PropertyName, SourceObject)
            sytType = objTemp.GetType.BaseType
            If objTemp IsNot Nothing AndAlso objTemp.GetType.BaseType Is GetType(DevExpress.Xpo.XPBaseCollection) Then
                objTemp.Add(ObjectToAdd)
            End If
        End Sub

        Public Shared Sub RemoveObjectFromPropertyCollection(ByRef ObjectToRemove As Object, ByRef SourceObject As Object, ByRef PropertyName As String)
            Dim objTemp As Object
            Dim sytType As System.Type

            objTemp = GetObjectFromPropertyName(PropertyName, SourceObject)
            sytType = objTemp.GetType.BaseType
            If objTemp IsNot Nothing AndAlso objTemp.GetType.BaseType Is GetType(DevExpress.Xpo.XPBaseCollection) Then
                objTemp.Remove(ObjectToRemove)
            End If
        End Sub

        Public Shared Function GetParentProperty(ByVal PropertyName As String) As String
            Dim strProperties() As String
            Dim strReturnProperty As String = String.Empty
            If PropertyName > String.Empty Then
                If PropertyName.Contains(".") Then
                    strProperties = PropertyName.Split(".")
                    For intLoop As Integer = 0 To strProperties.Length - 1
                        If intLoop = strProperties.Length - 1 Then
                            Return strReturnProperty
                        Else
                            If strReturnProperty > String.Empty Then
                                strReturnProperty = strReturnProperty + "."
                            End If
                            strReturnProperty = strReturnProperty + strProperties(intLoop)
                        End If
                    Next
                End If
            End If
            Return String.Empty
        End Function
        Public Shared Function GetLastPropertyName(ByVal PropertyName As String) As String
            Dim strProperties() As String
            Dim strReturnProperty As String = String.Empty
            If PropertyName > String.Empty Then
                If PropertyName.Contains(".") Then
                    strProperties = PropertyName.Split(".")
                    Return strProperties(strProperties.Length - 1)
                Else
                    Return PropertyName
                End If
            Else
                Return PropertyName
            End If
            Return String.Empty
        End Function
        Public Shared Function GetFirstPropertyName(ByVal PropertyName As String) As String
            Dim strProperties() As String
            Dim strReturnProperty As String = String.Empty
            If PropertyName > String.Empty Then
                If PropertyName.Contains(".") Then
                    strProperties = PropertyName.Split(".")
                    Return strProperties(0)
                Else
                    Return PropertyName
                End If
            Else
                Return PropertyName
            End If
            Return String.Empty
        End Function

    End Class

End Namespace
