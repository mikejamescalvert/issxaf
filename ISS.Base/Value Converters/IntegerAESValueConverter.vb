Imports DevExpress.Xpo.Metadata

Namespace ValueConverters
    Public Class IntegerAESValueConverter
        Inherits ValueConverter

        'TODO: modify the code to allow other object types

        Private _mAES As New SimpleAES

        Public Overrides Function ConvertFromStorageType(ByVal value As Object) As Object
            If TypeOf value Is String AndAlso String.IsNullOrEmpty(value) = False Then
                Try

                    Return Integer.Parse(_mAES.Decrypt(value))
                Catch ex As Exception
                    Return Integer.Parse(value)
                End Try

            Else
                Return 0
            End If
        End Function
        Public Overrides Function ConvertToStorageType(ByVal value As Object) As Object
            If value IsNot Nothing Then
                Try
                    Return _mAES.Encrypt(value.ToString())
                Catch ex As Exception
                    Return value.ToString()
                End Try
            Else
                Return String.Empty
            End If
        End Function
        Public Overrides ReadOnly Property StorageType() As System.Type
            Get
                Return GetType(String)
            End Get
        End Property

    End Class
End Namespace

