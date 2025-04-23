Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.IO

Namespace Helpers
    Public Class RegistryHelper

        Public Shared Function GetDecryptedRegistryValue(ByVal theValue As String) As String
            If theValue = String.Empty Then
                Return String.Empty
            End If
            Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
            Dim strDecrKey As String = "ISSEncryptString"
            Dim inputByteArray(theValue.Length) As Byte
            Try
                Dim byKey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(strDecrKey, 8))
                Dim des As New DESCryptoServiceProvider
                inputByteArray = Convert.FromBase64String(theValue)
                Dim ms As New MemoryStream
                Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
                cs.Write(inputByteArray, 0, inputByteArray.Length)
                cs.FlushFinalBlock()
                Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
                Return encoding.GetString(ms.ToArray())
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function
        Public Shared Function GetEncryptedRegistryValue(ByVal theValue As String) As String
            If theValue = String.Empty Then
                Return String.Empty
            End If
            Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
            Dim strEncrKey As String = "ISSEncryptString"
            Try
                Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))
                Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(theValue)
                Dim des As New DESCryptoServiceProvider
                Dim ms As New MemoryStream
                Dim cs As New CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write)
                cs.Write(InputByteArray, 0, InputByteArray.Length)
                cs.FlushFinalBlock()
                Return Convert.ToBase64String(ms.ToArray())
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        'Public Shared Function ReadConnectionStringFromRegistryPath(ByVal RegistryPath As String) As String
        '    Return GetDecryptedRegistryValue(CStr(Registry.GetValue(RegistryPath, "ConnectionString", String.Empty)))
        'End Function
        Public Shared Function ReadValueFromRegistryPath(ByVal RegistryPath As String, ByVal KeyName As String) As String
            Return GetDecryptedRegistryValue(CStr(Registry.GetValue(RegistryPath, KeyName, String.Empty)))
        End Function
        'Public Shared Sub WriteConnectionStringToRegistryPath(ByVal RegistryPath As String, ByVal ConnectionString As String)
        '    Registry.SetValue(RegistryPath, "ConnectionString", GetEncryptedRegistryValue(ConnectionString))
        'End Sub
        Public Shared Sub WriteValueToRegistryPath(ByVal RegistryPath As String, ByVal Value As String, ByVal KeyName As String)
            Registry.SetValue(RegistryPath, KeyName, GetEncryptedRegistryValue(Value))
        End Sub

    End Class
End Namespace


