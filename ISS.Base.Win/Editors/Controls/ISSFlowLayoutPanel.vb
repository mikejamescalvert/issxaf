Imports System.Windows.Forms

Public Class ISSFlowLayoutPanel
    Inherits FlowLayoutPanel

    Public Sub New()
        MyBase.New()
        AutoSize = True
        AutoScroll = True
        'AutoScrollMinSize = New Drawing.Size(50, 50)

        WrapContents = True


    End Sub

    Public Function GetControlForDataItem(ByVal Item As Object) As Control
        For Each ctrControl As Control In Controls
            If ctrControl.Tag.Equals(Item) Then
                Return ctrControl
            End If
        Next
        Return Nothing
    End Function

    Private _mMouseDown As Boolean
    Private _mDownTime As DateTime

    Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        _mMouseDown = True
        _mDownTime = Now
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If _mMouseDown = False Then
            Return
        End If
        If Now.Subtract(_mDownTime).TotalMilliseconds < 200 Then
            Return
        End If
        Stop
    End Sub

    Protected Overrides Sub OnMouseUp(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        _mMouseDown = False
    End Sub

    Public ReadOnly Property PageSize As Integer
        Get
            Return Height
        End Get
    End Property

End Class
