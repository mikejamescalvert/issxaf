Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraRichEdit

Public Class RichEditUserControl
    Public ReadOnly Property RichEditControl() As RichEditControl
        Get
            If Me.RichEditControl1 IsNot Nothing Then
                Me.RichEditControl1.Tag = Me
            End If
            Return Me.RichEditControl1
        End Get
    End Property
    Private _mTempValue As String
    Public ReadOnly Property BarManager() As BarManager
        Get
            Return Me.BarManager1
        End Get
    End Property
    Public Property RtfText() As String
        Get
            If RichEditControl1 IsNot Nothing Then
                If (RichEditControl.ReadOnly = True Or RichEditControl.Enabled = False) AndAlso _mTempValue = String.Empty Then
                    Return Nothing
                End If
                Return RichEditControl1.RtfText
            End If
            Return String.Empty
        End Get
        Set(ByVal value As String)
            _mTempValue = value
            If RichEditControl1 IsNot Nothing Then
                RichEditControl1.RtfText = value
            End If
        End Set
    End Property
End Class
