Namespace Attributes.Editors.PropertyEditors
    Public Class ViewIdEditorAttribute
        Inherits Attribute

        Private _mObjectTypeMember As String
        Property ObjectTypeMember As String
            Get
                Return _mObjectTypeMember
            End Get
            Set(ByVal Value As String)
                _mObjectTypeMember = Value
            End Set
        End Property

        Public Sub New(ByVal ObjectTypeMember As String)
            Me.ObjectTypeMember = ObjectTypeMember
        End Sub
    End Class
End Namespace

