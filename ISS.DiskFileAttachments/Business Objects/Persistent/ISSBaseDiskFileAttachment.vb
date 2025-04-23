Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.BaseImpl

<DefaultProperty("FileSummary")> _
<System.ComponentModel.DisplayName("DiskFileAttachment")> _
Public MustInherit Class ISSBaseDiskFileAttachment
    Inherits BaseObject
    Private _mCreateDirectory As Boolean
    Private _mFileExistsOption As FileExistsOptions
    Private _mSourceFileName As String
    Private _mSourceFileBytes() As Byte

    Public Enum FileExistsOptions
        ThrowException
        Overwrite
        CreateReferenceOnly
    End Enum


    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _mFileName As String
    <Size(255)> _
    <Browsable(False)> _
    Public Property FileName() As String
        Get
            Return _mFileName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("FileName", _mFileName, value)
            '_mFileName = value
            'If Me.IsLoading = False AndAlso Me.IsSaving = False Then
            '    OnChanged("FileName")
            'End If
        End Set
    End Property

    Public MustOverride Function GetBaseDirectory() As String

    Public Overridable Sub ValidateFile(ByVal FileInfo As IO.FileInfo)
        Return
    End Sub

    Public Overridable Sub ValidateFile(ByVal FileName As String, ByVal FileBytes() As Byte)
        Return
    End Sub


    Public Function GetPathFromPartialFilename(ByVal FileName As String)
        Return Me.GetBaseDirectory + FileName
    End Function

    Public Overridable Sub DeleteFile()
        If FileName > String.Empty Then
            If System.IO.File.Exists(FileName) Then
                System.IO.File.Delete(FileName)
            End If
        End If
    End Sub

    Public Overridable Sub UploadFile(ByVal FileBytes() As Byte, ByVal TargetFileName As String, Optional ByVal ExistsOption As FileExistsOptions = FileExistsOptions.ThrowException, Optional ByVal CreateDirectory As Boolean = True)
        Me.FileName = GetPathFromPartialFilename(TargetFileName)
        Me._mCreateDirectory = CreateDirectory
        Me._mFileExistsOption = ExistsOption
        Me._mSourceFileBytes = FileBytes
        OnChanged("FileName")
        OnChanged("FileInfo")


        'Dim strTargetFile As String = GetPathFromPartialFilename(TargetFileName)
        'If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strTargetFile)) Then
        '    If Not CreateDirectory Then
        '        Throw New Exception(String.Format("Directory path [ {0} ] does not exist", strTargetFile))
        '    Else
        '        Try
        '            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strTargetFile))
        '        Catch ex As Exception
        '            Throw New Exception(String.Format("Could not create directory [{0}]", strTargetFile), ex)
        '        End Try
        '    End If
        'End If

        'If System.IO.File.Exists(strTargetFile) Then
        '    Select Case ExistsOption
        '        Case FileExistsOptions.ThrowException
        '            Throw New Exception("File Already Exists!")
        '        Case FileExistsOptions.Overwrite
        '            System.IO.File.Delete(strTargetFile)
        '            System.IO.File.WriteAllBytes(strTargetFile, FileBytes)
        '        Case FileExistsOptions.CreateReferenceOnly

        '    End Select
        'Else
        '    System.IO.File.WriteAllBytes(strTargetFile, FileBytes)
        'End If
        'Me.FileName = strTargetFile
    End Sub
    Public Overridable Sub UploadFile(ByVal SourceFileName As String, ByVal TargetFileName As String, Optional ByVal ExistsOption As FileExistsOptions = FileExistsOptions.ThrowException, Optional ByVal CreateDirectory As Boolean = True)
        Me.FileName = GetPathFromPartialFilename(TargetFileName)
        Me._mCreateDirectory = CreateDirectory
        Me._mFileExistsOption = ExistsOption
        Me._mSourceFileName = SourceFileName
        OnChanged("FileName")
        OnChanged("FileInfo")

    End Sub

    Private _mFileInfo As IO.FileInfo
    Public Property FileInfo() As IO.FileInfo
        Get
            Try
                If String.IsNullOrEmpty(Me.FileName) Then
                    _mFileInfo = Nothing
                Else
                    If _mFileInfo Is Nothing Then
                        _mFileInfo = New IO.FileInfo(Me.FileName)
                    Else
                        If _mFileInfo.FullName <> Me.FileName Then
                            _mFileInfo = New IO.FileInfo(Me.FileName)
                        End If
                    End If
                End If
            Catch ex As Exception
                _mFileInfo = Nothing
            End Try
            Return _mFileInfo
        End Get
        Set(ByVal value As IO.FileInfo)
            If value Is Nothing Then
                Me.FileName = String.Empty
            Else
                If value.FullName = Me.FileName Then
                    Return
                Else
                    Me.FileName = value.FullName
                End If
            End If
        End Set
    End Property
    Public Sub SaveFileToDisk()
        If Me.IsDeleted Then
            Exit Sub
        End If
        If Me._mSourceFileBytes IsNot Nothing OrElse Me._mSourceFileName IsNot Nothing Then
            If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(Me.FileName)) Then
                If Not Me._mCreateDirectory Then
                    Throw New Exception(String.Format("Directory path [ {0} ] does not exist", Me.FileName))
                Else
                    Try
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Me.FileName))
                    Catch ex As Exception
                        Throw New Exception(String.Format("Could not create directory [{0}]", Me.FileName), ex)
                    End Try
                End If
            End If

            If System.IO.File.Exists(Me.FileName) Then
                Select Case Me._mFileExistsOption
                    Case FileExistsOptions.ThrowException
                        Throw New Exception("File Already Exists!")

                    Case FileExistsOptions.Overwrite
                        System.IO.File.Delete(Me.FileName)


                    Case FileExistsOptions.CreateReferenceOnly
                        Me._mSourceFileBytes = Nothing
                        Me._mSourceFileName = Nothing

                End Select

            End If
            If Me._mSourceFileBytes IsNot Nothing Then
                System.IO.File.WriteAllBytes(Me.FileName, Me._mSourceFileBytes)
                Me._mSourceFileBytes = Nothing
            End If
            If Me._mSourceFileName IsNot Nothing Then
                System.IO.File.Copy(Me._mSourceFileName, Me.FileName)
                Me._mSourceFileName = Nothing
            End If
        End If

    End Sub
    Public Overridable ReadOnly Property FileSummary() As String
        Get
            If FileInfo IsNot Nothing Then
                Return FileInfo.Name
            End If
            Return String.Empty
        End Get
    End Property
    Protected Overrides Sub OnSaving()
        MyBase.OnSaving()
        Me.SaveFileToDisk()
    End Sub

    'TODO: Add Event For OnUploading, Allow Cancel
    'TODO: Add Property File Exists On Disk

End Class
