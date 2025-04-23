
Imports System.Data
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class SimpleAES
    Private Shared key As Byte() = {123, 217, 19, 11, 24, 26, _
        85, 45, 114, 184, 27, 162, _
        37, 112, 222, 209, 241, 24, _
        175, 144, 173, 53, 196, 29, _
        24, 26, 17, 218, 131, 236, _
        53, 209}
    Private Shared vector As Byte() = {146, 64, 191, 111, 23, 3, _
        113, 119, 231, 121, 221, 112, _
        79, 32, 114, 156}
    Private encryptor As ICryptoTransform, decryptor As ICryptoTransform
    Private encoder As UTF8Encoding

    Public Sub New()
        Dim rm As New RijndaelManaged()
        encryptor = rm.CreateEncryptor(key, vector)
        decryptor = rm.CreateDecryptor(key, vector)
        encoder = New UTF8Encoding()
    End Sub

    Public Function Encrypt(unencrypted As String) As String
        Return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)))
    End Function

    Public Function Decrypt(encrypted As String) As String
        Return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)))
    End Function

    Public Function Encrypt(buffer As Byte()) As Byte()
        Return Transform(buffer, encryptor)
    End Function

    Public Function Decrypt(buffer As Byte()) As Byte()
        Return Transform(buffer, decryptor)
    End Function

    Protected Function Transform(buffer As Byte(), transform__1 As ICryptoTransform) As Byte()
        Dim stream As New MemoryStream()
        Using cs As New CryptoStream(stream, transform__1, CryptoStreamMode.Write)
            cs.Write(buffer, 0, buffer.Length)
        End Using
        Return stream.ToArray()
    End Function
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
