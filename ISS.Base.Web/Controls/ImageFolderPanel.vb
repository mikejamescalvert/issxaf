Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Web.UI

Public Class ImageFolderPanel
    Inherits Panel


    Private _mFolderName As String
    Public Property FolderName() As String
        Get
            Return _mFolderName
        End Get
        Set(ByVal Value As String)
            _mFolderName = Value
        End Set
    End Property
    Private _mImageURL As String
    Public Property ImageURL() As String
        Get
            Return _mImageURL
        End Get
        Set(ByVal Value As String)
            _mImageURL = Value
        End Set
    End Property

    Public Sub New(ByVal theImageURL As String)
        If theImageURL(theImageURL.Length - 1) <> "/" Then
            ImageURL = theImageURL + "/"
        Else
            ImageURL = theImageURL
        End If
        FolderName = System.Web.HttpContext.Current.Server.MapPath(ImageURL)
    End Sub
    Private _mPreviewWidth As Integer = 100
    Public Property PreviewWidth() As Integer
        Get
            Return _mPreviewWidth
        End Get
        Set(ByVal Value As Integer)
            _mPreviewWidth = Value
        End Set
    End Property
    Private _mPreviewHeight As Integer = 100
    Public Property PreviewHeight() As Integer
        Get
            Return _mPreviewHeight
        End Get
        Set(ByVal Value As Integer)
            _mPreviewHeight = Value
        End Set
    End Property
    Private _mNumberOfImagesPerRow As Integer = 3
    Public Property NumberOfImagesPerRow() As Integer
        Get
            Return _mNumberOfImagesPerRow
        End Get
        Set(ByVal Value As Integer)
            _mNumberOfImagesPerRow = Value
        End Set
    End Property

    Private _mDisplayTable As Table
    Public Property DisplayTable() As Table
        Get
            Return _mDisplayTable
        End Get
        Set(ByVal value As Table)
            If _mDisplayTable Is value Then
                Return
            End If
            _mDisplayTable = value
        End Set
    End Property

    Public Sub CreatePanel()
        Me.Controls.Clear()
        Dim lnkLink As HyperLink
        Dim imgImage As Image
        Dim fioFileInfo As FileInfo
        Dim intCurrentColumn As Integer = 1
        Dim intCurrentRow As Integer = 0
        Dim ltlLiteral As New Literal
        If DisplayTable Is Nothing Then
            DisplayTable = New Table
        Else
            DisplayTable.Rows.Clear()
        End If
        DisplayTable.Rows.Add(New TableRow)
        For Each oFile In Directory.GetFiles(FolderName)
            fioFileInfo = New FileInfo(oFile)
            ltlLiteral = New Literal
            ltlLiteral.Text = String.Format("<br/><span align=""center"">{0}</span>", fioFileInfo.Name)
            imgImage = New Image
            imgImage.ImageUrl = ImageURL + fioFileInfo.Name
            imgImage.AlternateText = fioFileInfo.Name
            imgImage.Width = PreviewWidth
            imgImage.Height = PreviewHeight

            lnkLink = New HyperLink
            lnkLink.NavigateUrl = ImageURL + fioFileInfo.Name
            lnkLink.Controls.Add(imgImage)
            lnkLink.Controls.Add(ltlLiteral)

            DisplayTable.Rows(intCurrentRow).Cells.Add(New TableCell)
            DisplayTable.Rows(intCurrentRow).Cells(DisplayTable.Rows(intCurrentRow).Cells.Count - 1).Controls.Add(lnkLink)

            If intCurrentColumn = NumberOfImagesPerRow Then
                DisplayTable.Rows.Add(New TableRow)
                intCurrentRow += 1
                intCurrentColumn = 1
            Else
                intCurrentColumn += 1
            End If
        Next
        Me.Controls.Add(DisplayTable)
    End Sub

End Class
