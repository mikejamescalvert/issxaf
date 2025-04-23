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
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model

'TODO: Post back image url to image.
<PropertyEditor(GetType(DiskImage), True)> _
Public Class ImagePreviewWithUploaderEditor
    Inherits DevExpress.ExpressApp.Web.Editors.WebPropertyEditor
    Public Sub New(ByVal objectType As Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


    Public ReadOnly Property CurrentDiskImage() As DiskImage
        Get
            Return Me.PropertyValue
        End Get
    End Property



    Protected Overrides Function CreateViewModeControlCore() As System.Web.UI.WebControls.WebControl
        Dim pnlPanel As New Panel
        Dim imgImage As Image
        Dim strBasePath As String
        If CurrentDiskImage IsNot Nothing Then
            imgImage = New Image
            strBasePath = System.Web.HttpContext.Current.Server.MapPath(CurrentDiskImage.GetFullURLPath)
            If IO.File.Exists(strBasePath) = True Then
                imgImage.ImageUrl = CurrentDiskImage.GetFullURLPath
            Else
                imgImage.ImageUrl = "missing.jpg"
            End If
            imgImage.ID = Me.ImageEditorID
            pnlPanel.Controls.Add(imgImage)
        End If
        Return pnlPanel
    End Function

    Public ReadOnly Property IncludeErrorScriptId() As String
        Get
            Return "errorscript"
        End Get
    End Property

    Public ReadOnly Property IncludeAfterSelectedScriptId() As String
        Get
            Return Me.PropertyName.Replace(".", "_") + "_selectedscript"
        End Get
    End Property

    Public ReadOnly Property IncludeAfterSelectedScriptFunctionId() As String
        Get
            Return Me.PropertyName.Replace(".", "_") + "_afterSelectedHandler"
        End Get
    End Property

    Public ReadOnly Property IncludeScriptId() As String
        Get
            Return Me.PropertyName.Replace(".", "_") + "_script"
        End Get
    End Property

    Public ReadOnly Property IncludeScriptFunctionId() As String
        Get
            Return Me.PropertyName.Replace(".", "_") + "_afterUploadHandler"
        End Get
    End Property

    Public ReadOnly Property ImageEditorID() As String
        Get
            Return Me.PropertyName.Replace(".", "_") + "_image"
        End Get
    End Property
    Public Sub AddJavascriptImageUploaded()
        Dim strScript As String = "<script type=""text/javascript"">" & _
                                    "function " + Me.IncludeScriptFunctionId + "(response) {" & _
                                    "document.getElementById('" + Me.ImageEditorID + "').src=response.substring(0,response.indexOf('<'));" & _
                                   "}" & _
                                "</script>"

        Dim wbpPage As System.Web.UI.Page = CType(System.Web.HttpContext.Current.Handler, DevExpress.ExpressApp.Web.WebWindowTemplateHttpHandler).ActualHandler

        wbpPage.ClientScript.RegisterClientScriptBlock(GetType(System.Web.UI.Page), IncludeScriptFunctionId, strScript, False)
    End Sub

    Private Sub SetupScript(ByVal sender As Object, ByVal e As EventArgs)
        Dim wbcWebControl As Control = sender
        AddJavascriptImageUploaded()

    End Sub

    Private _mCurrentUploader As Uploader

    Protected Overrides Sub SetupControl(ByVal control As System.Web.UI.WebControls.WebControl)
        MyBase.SetupControl(control)

        'control.ID
    End Sub

    Protected Overrides Function CreateEditModeControlCore() As System.Web.UI.WebControls.WebControl
        Dim pnlPanel As New Panel
        Dim imgImage As ImageReplacement
        Dim strBasePath As String
        Dim btnUpload As Button
        Dim strId As String
        If CurrentDiskImage IsNot Nothing Then
            imgImage = New ImageReplacement
            btnUpload = New Button
            _mCurrentUploader = GetUploadControl()

            strBasePath = System.Web.HttpContext.Current.Server.MapPath(CurrentDiskImage.GetFullURLPath)
            SetupScript(imgImage, Nothing)

            'AddHandler imgImage.Load, AddressOf SetupScript
            imgImage.PropertyName = Me.PropertyName
            If IO.File.Exists(strBasePath) = True Then
                imgImage.ImageUrl = CurrentDiskImage.GetFullURLPath
            Else
                imgImage.ImageUrl = "missing.jpg"
            End If
            'imgImage.ID = Me.ImageEditorID

            pnlPanel.Controls.Add(_mCurrentUploader)
            pnlPanel.Controls.Add(GetInstallationProgress)
            pnlPanel.Controls.Add(imgImage)
        End If
        Return pnlPanel
    End Function

    Public Function GetInstallationProgress() As InstallationProgress
        Dim itpProgress As New InstallationProgress
        itpProgress.TargetControlID = Me.PropertyName.Replace(".", "_")
        itpProgress.ProgressHtml = "&lt;p&gt;&lt;img src=\&quot;{0}\&quot; /&gt;&lt;br /&gt;Loading Aurigma Image Uploader...&lt;/p&gt;"
        itpProgress.ProgressImageUrl = "images\progress.gif"
        itpProgress.ProgressCssClass = "DownloadingScreenStyle"
        Return itpProgress
    End Function

    Public Function GetUploadControl() As Uploader
        Dim aiuImageUploader As New Uploader
        Dim cnvConverter As New Converter
        Dim strBasePath As String = CurrentDiskImage.GetImageRootURL
        Dim strClientScript As String
        Dim aceClientEvent As New Aurigma.ImageUploader.ClientEvent
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

        'aiuImageUploader.ID = "Uploader_" + Id
        'aiuImageUploader.UploadSettings.RedirectUrl = System.Web.HttpContext.Current.Request.RawUrl
        aiuImageUploader.LicenseKey = System.Configuration.ConfigurationManager.AppSettings("ImageUploadKey")
        aiuImageUploader.Converters.Clear()
        aiuImageUploader.Converters.Add(cnvConverter)
        aiuImageUploader.Restrictions.MaxFileSize = 52424880
        aiuImageUploader.EnableImageEditor = True
        aiuImageUploader.UploadPane.ViewMode = PaneViewMode.List
        aiuImageUploader.FolderPane.ViewMode = PaneViewMode.List
        aiuImageUploader.Width = New Unit(610)
        aiuImageUploader.ID = Me.PropertyName.Replace(".", "_")
        aiuImageUploader.ActiveXControl.CustomCodeBase = "http://www.mdwebbinc.com/Scripts/ImageUploader7.cab"
        aiuImageUploader.ActiveXControl.CustomCodeBase64 = "http://www.mdwebbinc.com/Scripts/ImageUploader7_x64.cab"
        aiuImageUploader.ActiveXControl.UseCustomCodeBase = True
        aiuImageUploader.JavaControl.CustomCodeBase = "http://www.mdwebbinc.com/Scripts/ImageUploader7.jar"
        aiuImageUploader.JavaControl.UseCustomCodeBase = True

        aceClientEvent = New ClientEvent(ClientEventNames.AfterUpload, Me.IncludeScriptFunctionId)
        aiuImageUploader.ClientEvents.Add(aceClientEvent)
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
            If CurrentDiskImage Is Nothing Then
                Return
            End If
            strBasePath = CurrentDiskImage.GetImageRootURL
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
            System.Web.HttpContext.Current.Response.Write(strBasePath + strFileName)
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
