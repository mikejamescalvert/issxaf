Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports ISS.Attachments

'<ImageName("BO_Contact")> _
Public MustInherit Class NotificationAttachment
    Inherits NotificationModuleBaseObject
    Implements IAttachment

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub


    Private _mNotificationQueueItem As NotificationQueueItem
    <Association("NotificationQueueItem-NotificationAttachments")>
    Public Property NotificationQueueItem As NotificationQueueItem
        Get
            Return _mNotificationQueueItem
        End Get
        Set(ByVal Value As NotificationQueueItem)
            SetPropertyValue("NotificationQueueItem", _mNotificationQueueItem, Value)
        End Set
    End Property

    Private _mName As String
    <Size(255)>
    Public Property Name As String Implements IAttachment.Description, IAttachment.FileName
        Get
            Return _mName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Name", _mName, Value)
        End Set
    End Property


    Public Sub SetFileName(ByVal Value As String) Implements IAttachment.SetFileName
        Dim iofFile As New IO.FileInfo(Value)

        SetPropertyValue("Name", _mName, iofFile.Name)
    End Sub

    Public Sub SetRecordDate(ByVal Value As Date) Implements IAttachment.SetRecordDate
        SetPropertyValue("RecordDate", _mRecordDate, Value)
    End Sub
    <Persistent("RecordDate")> _
    Private _mRecordDate As Date
    <PersistentAlias("_mRecordDate")>
    ReadOnly Property RecordDate As Date Implements IAttachment.RecordDate
        Get
            Return _mRecordDate
        End Get
    End Property



    Public MustOverride Property Content As Byte() Implements IAttachment.FileData

    'Private _mFileName As String
    '<Size(255)>
    'Public Property FileName As String
    '	Get
    '		Return _mFileName
    '	End Get
    '	Set(ByVal Value As String)
    '		SetPropertyValue("FileName", _mFileName, Value)
    '	End Set
    'End Property



    Overridable Function GetContent() As Byte()
        Return Content
    End Function


End Class
