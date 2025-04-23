Imports System.ComponentModel
Imports DevExpress.XtraEditors

Public Class RichTextUserControl
    Inherits XtraUserControl
    Implements INotifyPropertyChanged

    Private _mImmediatePost As Boolean

    Public Sub New(ByVal ImmediatePost As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RichEditControl.Options.Export.Rtf.Compatibility.DuplicateObjectAsMetafile = False
        RichEditControl.Options.DocumentCapabilities.InlinePictures = DevExpress.XtraRichEdit.DocumentCapability.Enabled
        RichEditControl.Options.DocumentCapabilities.FloatingObjects = DevExpress.XtraRichEdit.DocumentCapability.Disabled

        _mImmediatePost = ImmediatePost
    End Sub

    Public Property RtfText As String
        Get
            Return RichEditControl.RtfText
        End Get
        Set(value As String)
            If value IsNot Nothing AndAlso value.Contains("rtf") Then
                RichEditControl.RtfText = value
            Else
                RichEditControl.Text = value
            End If

        End Set
    End Property

    Private Sub RichTextUserControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If RichEditControl IsNot Nothing Then
            RichEditControl.Dispose()
            RichEditControl = Nothing
        End If
    End Sub

    Private Sub RichEditControl1_ContentChanged(sender As Object, e As EventArgs) Handles RichEditControl.ContentChanged

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("RtfText"))

    End Sub


    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

End Class
