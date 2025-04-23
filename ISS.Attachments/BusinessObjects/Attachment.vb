Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Public Interface IAttachment
    Sub SetFileName(ByVal Value As String)
    Sub SetRecordDate(ByVal Value As Date)
    Property Description As String
    Property FileData As Byte()
    ReadOnly Property FileName As String
    ReadOnly Property RecordDate As Date
End Interface
<MasterProvider.Module.AllowDatabaseUpdateInMasterProvider()>
<MasterProvider.Module.AllowDataModificationsInMasterProvider()>
Public Class Attachment
    Inherits BaseObject
    Implements IAttachment

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub


    Private _mDescription As String
    <Size(255)>
    Public Property Description As String Implements IAttachment.Description
        Get
            Return _mDescription
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Description", _mDescription, Value)
        End Set
    End Property

    <Persistent("RecordDate")> _
    Private _mRecordDate As Date
    Public Overridable Sub SetRecordDate(ByVal Value As Date) Implements IAttachment.SetRecordDate
        SetPropertyValue("RecordDate", _mRecordDate, Value)
    End Sub
    <PersistentAlias("_mRecordDate")> _
    Public ReadOnly Property RecordDate As Date Implements IAttachment.RecordDate
        Get
            Return _mRecordDate
        End Get
    End Property

    <Persistent("FileName")> _
    <Size(255)>
    Private _mFileName As String
    Public Overridable Sub SetFileName(ByVal Value As String) Implements IAttachment.SetFileName
        SetPropertyValue("FileName", _mFileName, Value)
    End Sub
    <PersistentAlias("_mFileName")> _
    <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Public ReadOnly Property FileName As String Implements IAttachment.FileName
        Get
            Return _mFileName
        End Get
    End Property
    

    ' Fields...
    Private _mFileData As Byte()
    <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Public Property FileData As Byte() Implements IAttachment.FileData
        Get
            Return _mFileData
        End Get
        Set(ByVal Value As Byte())
            SetPropertyValue("FileData", _mFileData, Value)
        End Set
    End Property




End Class
