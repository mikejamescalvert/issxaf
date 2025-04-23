
Namespace Attributes.Editors.TextEditor
    Public Class StringTokenizedLookupEditorAttribute
        Inherits Attribute

        Private _mSourceObjectType As String
        Public Property SourceObjectType As String
            Get
                Return _mSourceObjectType
            End Get
            Set(ByVal Value As String)
                _mSourceObjectType = Value
            End Set
        End Property
        Private _mPropertyName As String
        Public Property PropertyName As String
            Get
                Return _mPropertyName
            End Get
            Set(ByVal Value As String)
                _mPropertyName = Value
            End Set
        End Property

        Public Sub New(ByVal SourceObjectType As String, ByVal PropertyName As String)
            Me.SourceObjectType = SourceObjectType
            Me.PropertyName = PropertyName
        End Sub

    End Class
End Namespace
