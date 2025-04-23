Public Class MailMessageAttachment
    ' Fields...
    Private _mFileName As String
    Public Property FileName As String
        Get
            Return _mFileName
        End Get
        Set(ByVal Value As String)
            _mFileName = Value
        End Set
    End Property
    Private _mFileContents As Byte()
    Public Property FileContents As Byte()
        Get
            Return _mFileContents
        End Get
        Set(ByVal Value As Byte())
            _mFileContents = Value
        End Set
    End Property
    Private _mAttachmentID As String
    Public Property AttachmentID As String
        Get
            Return _mAttachmentID
        End Get
        Set(ByVal Value As String)
      _mAttachmentID = Value
        End Set
    End Property
    
End Class
