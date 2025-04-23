Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Model
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraPdfViewer
Imports DevExpress.XtraBars
Imports DevExpress.XtraPdfViewer.Bars
Imports DevExpress.XtraEditors.Camera
Imports DevExpress.XtraLayout

<PropertyEditor(GetType(System.Drawing.Image), False)>
Public Class CameraEditor
    Inherits WinPropertyEditor

    Public Sub New(ByVal objectType As Type, ByVal model As IModelMemberViewItem)
        MyBase.New(objectType, model)
    End Sub
    Private _mCamera As CameraControl
    Private _mImage As DevExpress.XtraEditors.PictureEdit
    Private WithEvents _mSnapshotButton As DevExpress.XtraEditors.SimpleButton
    Private _mCameraPanel As DevExpress.XtraLayout.LayoutControl

    Protected Overrides Function CreateControlCore() As Object
        Dim litCameraLayoutItem As LayoutControlItem
        Dim litButtonLayoutItem As LayoutControlItem
        Dim litImageLayoutItem As LayoutControlItem

        Dim col1Root As ColumnDefinition = New ColumnDefinition() With {.SizeType = SizeType.Percent, .Width = 45.0R}
        Dim col2Root As ColumnDefinition = New ColumnDefinition() With {.SizeType = SizeType.Percent, .Width = 10.0R}
        Dim col3Root As ColumnDefinition = New ColumnDefinition() With {.SizeType = SizeType.Percent, .Width = 45.0R}
        Dim row1Root As RowDefinition = New RowDefinition() With {.SizeType = SizeType.Percent, .Height = 100}

        _mCameraPanel = New DevExpress.XtraLayout.LayoutControl
        _mCameraPanel.MinimumSize = New Drawing.Size(100, 100)
        _mCameraPanel.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table


        _mCameraPanel.Root.OptionsTableLayoutGroup.ColumnDefinitions.Clear()
        _mCameraPanel.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(New ColumnDefinition() {col1Root, col2Root, col3Root})
        _mCameraPanel.Root.OptionsTableLayoutGroup.RowDefinitions.Clear()
        _mCameraPanel.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(New RowDefinition() {row1Root})


        _mCamera = New CameraControl
        ControlBindingProperty = "Tag"

        '_mCamera.Dock = DockStyle.Fill
        _mImage = New DevExpress.XtraEditors.PictureEdit
        _mImage.MinimumSize = New Drawing.Size(100, 300)
        _mCamera.MinimumSize = New Drawing.Size(100, 300)
        _mSnapshotButton = New DevExpress.XtraEditors.SimpleButton
        _mSnapshotButton.Text = ">>"
        _mSnapshotButton.Name = "simplebutton"
        _mCameraPanel.Dock = DockStyle.Fill
        _mCameraPanel.Name = "camerapanel"
        _mCamera.Name = "maincamera"
        _mCamera.Dock = DockStyle.Fill
        _mImage.Dock = DockStyle.Fill
        _mImage.Text = String.Empty
        _mImage.Name = "imagedisplay"
        _mImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom

        litCameraLayoutItem = _mCameraPanel.Root.AddItem()
        litCameraLayoutItem.OptionsTableLayoutItem.ColumnIndex = 0
        litCameraLayoutItem.OptionsTableLayoutItem.RowIndex = 0
        litCameraLayoutItem.Name = "liCamera"
        litCameraLayoutItem.Control = _mCamera
        litCameraLayoutItem.TextVisible = False

        litButtonLayoutItem = _mCameraPanel.Root.AddItem()
        litButtonLayoutItem.Name = "liButton"
        litButtonLayoutItem.OptionsTableLayoutItem.ColumnIndex = 1
        litButtonLayoutItem.OptionsTableLayoutItem.RowIndex = 0
        litButtonLayoutItem.TextVisible = False
        litButtonLayoutItem.Control = _mSnapshotButton
        litButtonLayoutItem.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center
        litButtonLayoutItem.Width = 10

        litImageLayoutItem = _mCameraPanel.Root.AddItem()
        litImageLayoutItem.Name = "liImage"
        litImageLayoutItem.OptionsTableLayoutItem.ColumnIndex = 2
        litImageLayoutItem.OptionsTableLayoutItem.RowIndex = 0
        litImageLayoutItem.Control = _mImage
        'litImageLayoutItem.Width = 47
        litImageLayoutItem.TextVisible = False
        _mCameraPanel.BestFit()
        Return _mCameraPanel
    End Function

    Public Sub TakePicture()
        If _mCameraPanel IsNot Nothing AndAlso _mCamera IsNot Nothing AndAlso _mImage IsNot Nothing Then
            _mCameraPanel.Tag = _mCamera.TakeSnapshot()
            WriteValue()
            OnValueRead()

        End If

    End Sub

    Public Overrides Sub BreakLinksToControl(unwireEventsOnly As Boolean)

        MyBase.BreakLinksToControl(unwireEventsOnly)

    End Sub
    Protected Overrides Sub OnValueRead()
        MyBase.OnValueRead()
        If _mImage IsNot Nothing Then
            _mImage.Image = PropertyValue
        End If
    End Sub
    Protected Overrides Function GetControlValueCore() As Object
        _mCameraPanel.Tag = _mCamera.TakeSnapshot()
        'Return _mCamera.TakeSnapshot()
        Return MyBase.GetControlValueCore()

    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing Then
                If _mCamera IsNot Nothing Then
                    _mCamera.Dispose()
                End If

            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Protected Overrides Sub OnAllowEditChanged()
        MyBase.OnAllowEditChanged()
    End Sub

    Protected Overrides Sub ReadValueCore()
        MyBase.ReadValueCore()

    End Sub

    Private Sub _mSnapshotButton_Click(sender As Object, e As EventArgs) Handles _mSnapshotButton.Click
        TakePicture()
    End Sub


#Region "IInplaceEditSupport Members"


#End Region


End Class
