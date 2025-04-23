Imports DevExpress.XtraEditors

Public Class CustomHotTrackButton
    Inherits SimpleButton

    Private _mHotTrackedImage As System.Drawing.Image
    Private _mDisabledImage As System.Drawing.Image
    Private _mNormalImage As System.Drawing.Image
    Private _mPressedImage As System.Drawing.Image
    Private _mSelectedImage As System.Drawing.Image
    Public Property HotTrackedImage() As System.Drawing.Image
        Get
            Return _mHotTrackedImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            If _mHotTrackedImage Is value Then
                Return
            End If
            _mHotTrackedImage = Value
        End Set
    End Property
    Public Property DisabledImage() As System.Drawing.Image
        Get
            Return _mDisabledImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            If _mDisabledImage Is value Then
                Return
            End If
            _mDisabledImage = Value
        End Set
    End Property
    Public Property NormalImage() As System.Drawing.Image
        Get
            Return _mNormalImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            If _mNormalImage Is value Then
                Return
            End If
            _mNormalImage = value
            If _mNormalImage IsNot Nothing Then
                Me.MaximumSize = New System.Drawing.Size(_mNormalImage.Width, _mNormalImage.Height + 20)
                Me.MinimumSize = New System.Drawing.Size(_mNormalImage.Width, _mNormalImage.Height + 20)
            Else
                Me.MaximumSize = Nothing
                Me.MinimumSize = Nothing
            End If
        End Set
    End Property
    Public Property PressedImage() As System.Drawing.Image
        Get
            Return _mPressedImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            If _mPressedImage Is value Then
                Return
            End If
            _mPressedImage = Value
        End Set
    End Property
    Public Property SelectedImage() As System.Drawing.Image
        Get
            Return _mSelectedImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            If _mSelectedImage Is value Then
                Return
            End If
            _mSelectedImage = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.AutoSizeInLayoutControl = False
    End Sub

    Protected Overrides Function CreateViewInfo() As DevExpress.XtraEditors.ViewInfo.BaseStyleControlViewInfo
        Return New MyViewInfo(Me)
    End Function

    Private Sub UpdateLook(ByVal IsDown As Boolean, ByVal IsHover As Boolean)
        If IsHover = True Then
            If IsDown = True Then
                If Me.PressedImage Is Nothing Then
                    Me.Image = Me.NormalImage
                Else
                    Me.Image = Me.PressedImage
                End If
            Else
                If Me.HotTrackedImage Is Nothing Then
                    Me.Image = Me.NormalImage
                Else
                    Me.Image = Me.HotTrackedImage
                End If
            End If
        Else
            Me.Image = Me.NormalImage
        End If
    End Sub

    Private Sub CustomHotTrackButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        UpdateLook(True, True)
    End Sub

    Private Sub CustomHotTrackButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        UpdateLook(False, True)
    End Sub

    Private Sub CustomHotTrackButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        UpdateLook(False, False)
    End Sub

    Private Sub CustomHotTrackButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        UpdateLook(True, False)
    End Sub

End Class

Class MyViewInfo
    Inherits DevExpress.XtraEditors.ViewInfo.SimpleButtonViewInfo

    Private _mButton As CustomHotTrackButton

    Public Sub New(ByVal owner As CustomHotTrackButton)
        MyBase.new(owner)
        _mButton = owner
    End Sub

    Protected Overrides Function CalcButtonState(ByVal buttonInfo As DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs, ByVal state As DevExpress.Utils.Drawing.ObjectState) As DevExpress.Utils.Drawing.ObjectState
        Dim objRes As DevExpress.Utils.Drawing.ObjectState = MyBase.CalcButtonState(buttonInfo, state)
        Return DevExpress.Utils.Drawing.ObjectState.Normal
    End Function

End Class