Public Class MailMessage
    Private _mItemID As String
    Public Property ItemID As String
        Get
            Return _mItemID
        End Get
        Set(ByVal Value As String)
            _mItemID = Value
        End Set
    End Property
    
    Private _mFromAddress As New MailMessageAddress
    Public Property FromAddress As MailMessageAddress
        Get
            Return _mFromAddress
        End Get
        Set(ByVal Value As MailMessageAddress)
            _mFromAddress = Value
        End Set
    End Property
    Private _mToAddresses As New List(Of MailMessageAddress)
    Public Property ToAddresses As List(Of MailMessageAddress)
        Get
            Return _mToAddresses
        End Get
        Set(ByVal Value As List(Of MailMessageAddress))
            _mToAddresses = Value
        End Set
    End Property
    Private _mCCAddresses As New List(Of MailMessageAddress)
    Public Property CCAddresses As List(Of MailMessageAddress)
        Get
            Return _mCCAddresses
        End Get
        Set(ByVal Value As List(Of MailMessageAddress))
            _mCCAddresses = Value
        End Set
    End Property
    Private _mBCCAddresses As New List(Of MailMessageAddress)
    Public Property BCCAddresses As List(Of MailMessageAddress)
        Get
            Return _mBCCAddresses
        End Get
        Set(ByVal Value As List(Of MailMessageAddress))
            _mBCCAddresses = Value
        End Set
    End Property
    
    ' Fields...
    Private _mSubject As String
    Public Property Subject As String
        Get
            Return _mSubject
        End Get
        Set(ByVal Value As String)
            _mSubject = Value
        End Set
    End Property

    Private _mBody As String
    Public Property Body As String
        Get
            Return _mBody
        End Get
        Set(ByVal Value As String)
            _mBody = Value
        End Set
    End Property
    
    Private _mAttachments As New List(Of MailMessageAttachment)
    Public Property Attachments As List(Of MailMessageAttachment)
        Get
            Return _mAttachments
        End Get
        Set(ByVal Value As List(Of MailMessageAttachment))
            _mAttachments = Value
        End Set
    End Property
    
    Private _mReceivedDate As DateTime
    Public Property ReceivedDate As DateTime
        Get
            Return _mReceivedDate
        End Get
        Set(ByVal Value As DateTime)
            _mReceivedDate = Value
        End Set
    End Property
    
    
End Class
