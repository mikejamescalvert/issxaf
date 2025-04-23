Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Model
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraPdfViewer
Imports DevExpress.XtraBars
Imports DevExpress.XtraPdfViewer.Bars

<PropertyEditor(GetType(String), False)>
Public Class PdfViewOnlyEditor
    Inherits WinPropertyEditor

    Public Sub New(ByVal objectType As Type, ByVal model As IModelMemberViewItem)
        MyBase.New(objectType, model)
    End Sub
    Private _mPdfBarController As PdfBarController
    Private _mBarManager As BarManager
    Private _mPdfControl As PdfViewer
    Public ReadOnly Property PdfControl As PdfViewer
        Get
            Return _mPdfControl
        End Get
    End Property

    Protected Overrides Function CreateControlCore() As Object
        Dim pnl As New Panel
        _mPdfControl = New PdfViewer()
        _mPdfControl.DetachStreamAfterLoadComplete = True

        _mPdfControl.Dock = DockStyle.Fill
        pnl.Controls.Add(_mPdfControl)
        _mPdfBarController = New PdfBarController
        _mPdfBarController.Control = _mPdfControl
        _mBarManager = New BarManager
        _mBarManager.Form = pnl
        AddHandler _mPdfControl.Load, AddressOf PdfControl_Load
        Return pnl
    End Function

    Private Sub PdfControl_Load(sender As Object, e As EventArgs)
        If _mPdfControl Is Nothing Then
            Return
        End If
        _mPdfControl.CreateBars()
        If _mBarManager Is Nothing OrElse _mBarManager.Bars Is Nothing OrElse _mBarManager.Bars.Count < 1 Then
            Return
        End If
        _mBarManager.Bars(0).ItemLinks(0).Visible = False
        _mBarManager.Bars(0).ItemLinks(11).Visible = False
        If _mBarManager.Bars.Count < 2 Then
            Return
        End If
        _mBarManager.Bars(1).Visible = False
    End Sub
    Public Overrides Sub BreakLinksToControl(unwireEventsOnly As Boolean)
        If _mPdfControl IsNot Nothing Then
            RemoveHandler _mPdfControl.Load, AddressOf PdfControl_Load
        End If
        MyBase.BreakLinksToControl(unwireEventsOnly)

    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing Then
                If _mPdfBarController IsNot Nothing Then
                    _mPdfBarController.Dispose()
                End If
                If _mBarManager IsNot Nothing Then
                    _mBarManager.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub PdfControl_DocumentChanged(sender As Object, e As PdfDocumentChangedEventArgs)
        _mPdfControl.CreateBars()
    End Sub

    Protected Overrides Sub OnAllowEditChanged()
        MyBase.OnAllowEditChanged()
    End Sub

    Protected Overrides Sub ReadValueCore()
        MyBase.ReadValueCore()
        If _mPdfControl IsNot Nothing AndAlso String.IsNullOrEmpty(PropertyValue) = False Then
            If IO.File.Exists(PropertyValue) Then
                _mPdfControl.LoadDocument(PropertyValue)
            Else
                _mPdfControl.CloseDocument()
            End If

        Else
            If _mPdfControl IsNot Nothing Then
                _mPdfControl.CloseDocument()
            End If
        End If
    End Sub


#Region "IInplaceEditSupport Members"


#End Region


End Class
