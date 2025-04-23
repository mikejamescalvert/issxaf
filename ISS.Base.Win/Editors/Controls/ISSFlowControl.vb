Imports System.Windows.Forms
Imports DevExpress.XtraLayout

Public Class ISSFlowControl
    Inherits LayoutControl

    Private WithEvents _mUpButton As New Button
    Private WithEvents _mDownButton As New Button

    Private _mFlowPanel As New ISSFlowLayoutPanel
    Public ReadOnly Property Panel As ISSFlowLayoutPanel
        Get
            Return _mFlowPanel
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        _mUpButton.Text = "↑"
        _mUpButton.MinimumSize = New Drawing.Size(0, 50)
        _mUpButton.MaximumSize = New Drawing.Size(1600, 50)
        _mUpButton.Font = New Drawing.Font(_mDownButton.Font, Drawing.FontStyle.Bold)
        _mDownButton.Text = "↓"
        _mDownButton.MinimumSize = New Drawing.Size(0, 50)
        _mDownButton.MaximumSize = New Drawing.Size(1600, 50)
        _mDownButton.Font = New Drawing.Font(_mDownButton.Font, Drawing.FontStyle.Bold)

        Dim lgiParentGroup As New LayoutControlGroup
        Dim lgiGroup As LayoutControlGroup
        Dim lciControlItem As LayoutControlItem
        Dim esiEmptySpaceItem As EmptySpaceItem

        lgiParentGroup.DefaultLayoutType = Utils.LayoutType.Vertical
        lgiParentGroup.TextVisible = False
        lgiParentGroup.GroupBordersVisible = False

        'lgiGroup = New LayoutControlGroup
        'lgiGroup.TextVisible = False
        'lgiGroup.GroupBordersVisible = False

        lciControlItem = New LayoutControlItem
        lciControlItem.Control = _mUpButton
        lciControlItem.TextVisible = False

        lgiParentGroup.AddItem(lciControlItem)

        lciControlItem = New LayoutControlItem
        lciControlItem.Control = _mFlowPanel
        lciControlItem.TextVisible = False

        'lgiGroup.AddItem(lciControlItem)
        lgiParentGroup.AddItem(lciControlItem)



        'lgiGroup = New LayoutControlGroup
        'lgiGroup.GroupBordersVisible = False
        'lgiGroup.TextVisible = False
        'lgiGroup.AddItem(lciControlItem)

        lciControlItem = New LayoutControlItem
        lciControlItem.Control = _mDownButton
        lciControlItem.TextVisible = False

        lgiParentGroup.AddItem(lciControlItem)

        'esiEmptySpaceItem = New EmptySpaceItem
        'esiEmptySpaceItem.FillControlToClientArea = True
        ''lgiGroup.AddItem(esiEmptySpaceItem)
        ''lgiGroup.AddItem(lciControlItem)

        'lgiGroup.Items(0).TextVisible = False
        'lgiGroup.Items(1).TextVisible = False

        'lgiGroup.Items(2).TextVisible = False
        'lgiParentGroup.AddGroup(lgiGroup)

        AddGroup(lgiParentGroup)

    End Sub

    Public Function IsAtBottomScroll() As Boolean

        If _mFlowPanel.AutoScrollPosition.Y = (_mFlowPanel.DisplayRectangle.Height - _mFlowPanel.Height) * -1 Then
            Return True
        ElseIf _mFlowPanel.AutoScrollPosition.Y - ScrollHeight <= (_mFlowPanel.DisplayRectangle.Height - _mFlowPanel.Height) * -1 Then
            Return True
        End If
        Return False
    End Function

    Public Function IsAtTopScroll() As Boolean
        If _mFlowPanel.AutoScrollPosition.Y = 0 Then
            Return True
        ElseIf _mFlowPanel.AutoScrollPosition.Y + ScrollHeight >= 0 Then
            Return True
        End If
        Return False
    End Function

    Private Sub _mDownButton_Click(sender As Object, e As System.EventArgs) Handles _mDownButton.Click
        Dim aspPosition As Drawing.Point = _mFlowPanel.AutoScrollPosition
        If IsAtBottomScroll() = True Then
            aspPosition.Y = (_mFlowPanel.DisplayRectangle.Height - _mFlowPanel.Height) * -1
        Else
            aspPosition.Y = _mFlowPanel.AutoScrollPosition.Y - ScrollHeight
        End If
        _mFlowPanel.AutoScrollPosition = New Drawing.Point(aspPosition.X, aspPosition.Y * -1)
    End Sub

    Public ReadOnly Property ScrollHeight As Integer
        Get
            Return _mFlowPanel.PageSize
        End Get
    End Property

    Private Sub _mUpButton_Click(sender As Object, e As System.EventArgs) Handles _mUpButton.Click
        Dim aspPosition As Drawing.Point = _mFlowPanel.AutoScrollPosition
        If IsAtTopScroll() = True Then
            aspPosition.Y = 0
        Else
            aspPosition.Y = _mFlowPanel.AutoScrollPosition.Y + ScrollHeight
        End If
        _mFlowPanel.AutoScrollPosition = New Drawing.Point(aspPosition.X, aspPosition.Y * -1)
    End Sub
End Class

