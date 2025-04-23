Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Web.Editors.Standard
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.IO
Imports Aurigma.ImageUploader
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Model

Public Class ImageUploaderEditor
    Inherits DevExpress.ExpressApp.Web.Editors.WebPropertyEditor

    Public ReadOnly Property CurrentDiskImage() As DiskImage
        Get
            Return Me.CurrentObject
        End Get
    End Property

    Public Sub New(ByVal objectType As Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

    Protected Overrides Function CreateViewModeControlCore() As System.Web.UI.WebControls.WebControl
        Return GetViewOnlyPanel()
    End Function
    Protected Overrides Function CreateEditModeControlCore() As System.Web.UI.WebControls.WebControl
        Return GetEditorPanel()
    End Function
    Public Function GetViewOnlyPanel() As Panel
        Dim pnlPanel As New Panel
        Dim uplUploader As Uploader = GetUploadControl()
        RenderHelper.CreateASPxPageControl()
        pnlPanel.Controls.Add(uplUploader)
        Return pnlPanel
    End Function
    Public Function GetEditorPanel() As Panel
        Dim pnlPanel As New Panel
        Dim uplUploader As Uploader = GetUploadControl()
        pnlPanel.Controls.Add(uplUploader)
        pnlPanel.Controls.Add(GetInstallationProgress)
        Return pnlPanel
    End Function
    Public Function GetInstallationProgress() As InstallationProgress
        Dim itpProgress As New InstallationProgress
        itpProgress.TargetControlID = "Uploader_" + Id
        itpProgress.ProgressHtml = "&lt;p&gt;&lt;img src=\&quot;{0}\&quot; /&gt;&lt;br /&gt;Loading Aurigma Image Uploader...&lt;/p&gt;"
        itpProgress.ProgressImageUrl = "mywaitIndicator.gif"
        itpProgress.ProgressCssClass = "DownloadingScreenStyle"
        Return itpProgress
    End Function
    Public Function GetUploadControl() As Uploader
        Dim aiuImageUploader As New Uploader
        Dim cnvConverter As New Converter
        Dim strBasePath As String = CurrentDiskImage.GetImageRootURL
        If strBasePath(strBasePath.Length - 1) <> "/" Then
            strBasePath = strBasePath + "/"
        End If
        cnvConverter.Mode = "*.*=Thumbnail"
        cnvConverter.ThumbnailKeepColorSpace = False
        cnvConverter.ThumbnailHeight = CurrentDiskImage.GetImageScaledHeight
        cnvConverter.ThumbnailWidth = CurrentDiskImage.GetImageScaledWidth
        cnvConverter.ThumbnailFitMode = ThumbnailFitMode.Fit
        cnvConverter.ThumbnailResizeQuality = ResizeQuality.High
        cnvConverter.ThumbnailApplyCrop = True

        aiuImageUploader.ID = "Uploader_" + Id
        aiuImageUploader.UploadSettings.RedirectUrl = System.Web.HttpContext.Current.Request.RawUrl
        aiuImageUploader.LicenseKey = System.Configuration.ConfigurationManager.AppSettings("ImageUploadKey")
        aiuImageUploader.Converters.Clear()
        aiuImageUploader.Converters.Add(cnvConverter)
        aiuImageUploader.Restrictions.MaxFileSize = 52424880
        aiuImageUploader.EnableImageEditor = True
        aiuImageUploader.UploadPane.ViewMode = PaneViewMode.List
        aiuImageUploader.FolderPane.ViewMode = PaneViewMode.List
        aiuImageUploader.Width = New Unit(610)


        If IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strBasePath)) = False Then
            IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strBasePath))
        End If

        'aiuImageUploader.DestinationFolder = strBasePath

        AddHandler aiuImageUploader.FileUploaded, AddressOf FileUploaded
        aiuImageUploader.Restrictions.MaxFileCount = 1

        Return aiuImageUploader
    End Function

    Public Sub FileUploaded(ByVal sender As Object, ByVal e As FileUploadedEventArgs)
        Dim strNewName As String
        Dim strBasePath As String
        Dim strFileName As String = String.Empty
        Dim obsSpace As Xpo.XPObjectSpace
        Try
            If e.UploadedFile Is Nothing Then
                Return
            End If
            strBasePath = CurrentDiskImage.GetImageScaledHeight
            obsSpace = Xpo.XPObjectSpace.FindObjectSpaceByObject(CurrentDiskImage)
            If strBasePath(strBasePath.Length - 1) <> "/" Then
                strBasePath = strBasePath + "/"
            End If
            If strFileName = String.Empty Then
                strFileName = e.UploadedFile.SourceName
            End If
            strNewName = String.Format("{0}{1}", System.Web.HttpContext.Current.Server.MapPath(strBasePath), strFileName)
            While IO.File.Exists(strNewName) = True
                strFileName = strFileName.Substring(0, strFileName.Length - 4)
                strFileName = strFileName + "i.jpg"
                strNewName = String.Format("{0}{1}", System.Web.HttpContext.Current.Server.MapPath(strBasePath), strFileName)
            End While
            If IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strBasePath)) = False Then
                IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strBasePath))
            End If
            e.UploadedFile.ConvertedFiles(0).SaveAs(strNewName)
            CurrentDiskImage.ImageFileName = strFileName
            CurrentDiskImage.Save()
            obsSpace.CommitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Overrides Function GetControlValueCore() As Object
        Return Nothing
    End Function

    Protected Overrides Sub ReadEditModeValueCore()

    End Sub

End Class
