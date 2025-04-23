Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.Drawing

<DefaultProperty("FullImagePath")> _
Public Class DiskImage
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    <Browsable(False)> _
    Public ReadOnly Property FullImagePath() As String
        Get
            Return GetFullURLPath()
        End Get
    End Property

    Public Overridable Function GetImageScaledHeight() As Integer
        Return 150
        Dim ino As New InOperator("User",New List(Of String))
    End Function

    Public Overridable Function GetImageScaledWidth() As Integer
        Return 150
    End Function

    Public Overridable Function GetImageDirectory() As String
        Return Environment.CurrentDirectory + "\image\"
    End Function

    Public Overridable Function GetImageRootURL() As String
        Return "image/"
    End Function

    Public Function GetFullURLPath() As String
        Return GetImageRootURL() + ImageFileName()
    End Function
    Public Function GetFullDiskFileName() As String
        Return GetImageDirectory() + ImageFileName()
    End Function

    Public Function GetImageData() As Image
        Dim imgImage As Image
        If GetFullDiskFileName() > String.Empty Then
            imgImage = Image.FromFile(GetFullDiskFileName)
        Else
            imgImage = Nothing
        End If
        Return imgImage
    End Function

    Public Overridable Function GetNewImageName() As String
        Return System.Guid.NewGuid.ToString + ".jpg"
    End Function

    <Custom("PropertyEditorType", "ImageSolution.Module.Web.ImageUploaderEditor")> _
    <NonPersistent()> _
    <Index(0)> _
    Public Property FileUpload() As String
        Get
            Return GetImageRootURL()
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    Private _mImageFileName As String
    <VisibleInDetailView(False)> _
    <VisibleInListView(False)> _
    <Size(-1)>
    Public Property ImageFileName() As String
        Get
            Return _mImageFileName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ImageFileName", _mImageFileName, Value)
        End Set
    End Property

    <VisibleInListView(False)> _
    <Index(1)> _
    Public ReadOnly Property UploadedFile() As String
        Get
            Return ImageFileName
        End Get
    End Property


End Class
