Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports DevExpress.Web
Imports DevExpress.ExpressApp.Web

Public Class LabelEditControl
    Inherits Table
    Implements INamingContainer

    Private _mLinkButton As ASPxHyperLink
    Private _mLabel As ASPxLabel

    Public Sub New()
        Dim tlrTableRow As New TableRow
        BorderWidth = 0
        CellPadding = 0
        CellSpacing = 0

        tlrTableRow.VerticalAlign = VerticalAlign.Top
        tlrTableRow.Cells.Add(GetLabelCell)
        tlrTableRow.Cells.Add(GetButtonCell)
        Rows.Add(tlrTableRow)
    End Sub

    Public Overrides Property Width() As System.Web.UI.WebControls.Unit
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value As System.Web.UI.WebControls.Unit)
            'MyBase.Width = value
        End Set
    End Property

    Public ReadOnly Property ASPxLabel() As ASPxLabel
        Get
            Return _mLabel
        End Get
    End Property

    Public ReadOnly Property ASPxHyperlink() As ASPxHyperLink
        Get
            Return _mLinkButton
        End Get
    End Property

    Public Property Text() As String
        Get
            Return _mLabel.Text
        End Get
        Set(ByVal value As String)
            _mLabel.Text = value
        End Set
    End Property

    Public Property NavigateURL() As String
        Get
            Return _mLinkButton.NavigateUrl
        End Get
        Set(ByVal value As String)
            _mLinkButton.NavigateUrl = value
        End Set
    End Property

    Private _mButtonImageName As String = "Editor_Edit"
    Public Property ButtonImageName() As String
        Get
            Return _mButtonImageName
        End Get
        Set(ByVal value As String)
            _mButtonImageName = value
            If _mLinkButton IsNot Nothing Then
                _mLinkButton.ImageUrl = DevExpress.ExpressApp.Utils.ImageLoader.Instance.GetImageInfo(value).ImageUrl
            End If
        End Set
    End Property

    Public Function GetLabelCell() As TableCell
        Dim tlcLabelCell As New TableCell
        tlcLabelCell.Attributes.Add("style", "padding-right:5px")
        _mLabel = New ASPxLabel
        tlcLabelCell.Controls.Add(_mLabel)
        Return tlcLabelCell
    End Function

    Public Function GetButtonCell()
        Dim tlcButtonCell As New TableCell
        _mLinkButton = New ASPxHyperLink()
        _mLinkButton.ImageUrl = DevExpress.ExpressApp.Utils.ImageLoader.Instance.GetImageInfo("Editor_Edit").ImageUrl
        tlcButtonCell.Controls.Add(_mLinkButton)
        Return tlcButtonCell
    End Function

End Class
