Imports System.IO
Imports DevExpress.Persistent.Base

Public Class TraceDescendant
    Inherits Tracing

    Public Const LogFileMaximumSizeInMegabytes As Integer = 10
    Public Sub New(ByVal FileName As String)
        MyBase.New(FileName)

    End Sub
    Public Sub New()
        MyBase.New

    End Sub
    Protected Overrides Function GetDateTimeStamp() As String
        CheckFileStatus()
        Return MyBase.GetDateTimeStamp()

    End Function

    Public Sub CheckFileStatus()

        Dim intMaxSizeInBytes = LogFileMaximumSizeInMegabytes * (1024 * 1024)
        Dim flcLocation As FileLocation = GetFileLocationFromSettings()
        Dim iofFileInfo As IO.FileInfo
        Dim strLocation As String = String.Empty
        Select Case flcLocation
            Case FileLocation.ApplicationFolder
                strLocation = Path.Combine(PathHelper.GetApplicationFolder, LogName + ".log")
            Case FileLocation.CurrentUserApplicationDataFolder
                strLocation = Path.Combine(LocalUserAppDataPath, LogName + ".log")
            Case Else
                Return
        End Select

        If IO.File.Exists(strLocation) = False Then
            Return
        End If

        iofFileInfo = New IO.FileInfo(strLocation)

        If iofFileInfo.Length > intMaxSizeInBytes Then
            If IO.File.Exists(strLocation + "-2") Then
                IO.File.Delete(strLocation + "-2")
            End If
            'IO.File.Copy(strLocation, strLocation + "-2")

            IO.File.Copy(strLocation, strLocation + "-2")
            IO.File.WriteAllText(strLocation, "")


        End If


    End Sub


End Class
