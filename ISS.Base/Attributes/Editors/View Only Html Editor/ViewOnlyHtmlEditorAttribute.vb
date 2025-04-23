Namespace Attributes.Editors.ViewOnlyHtmlEditor
    ''' <summary>
    ''' Specifies the minimum size of the view only html editor and whether or not to enable the scroll bar.
    ''' </summary>
    ''' <remarks>Only applicable to the ViewOnlyHtmlEditor in the ISS.Base.Win</remarks>
    Public Class ViewOnlyHtmlEditorAttribute
        Inherits Attribute
        Private _mMinSize As Integer
        Public Property MinSize As Integer
            Get
                Return _mMinSize
            End Get
            Set(ByVal Value As Integer)
                _mMinSize = Value
            End Set
        End Property
        Private _mEnableScroll As String
        Public Property EnableScroll As String
            Get
                Return _mEnableScroll
            End Get
            Set(ByVal Value As String)
                _mEnableScroll = Value
            End Set
        End Property

        Public Sub New(ByVal MinSize As Integer, ByVal EnableScroll As Boolean)
            Me.MinSize = MinSize
            Me.EnableScroll = EnableScroll
        End Sub
    End Class
End Namespace

