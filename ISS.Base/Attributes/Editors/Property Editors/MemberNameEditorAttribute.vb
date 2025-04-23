Namespace Attributes.Editors.PropertyEditors
    Public Class MemberNameEditorAttribute
        Inherits Attribute

        Private _mObjectType As Type
        Public Property ObjectType As Type
            Get
                Return _mObjectType
            End Get
            Set(ByVal Value As Type)
                _mObjectType = Value
            End Set
        End Property
        Public Sub New(ByVal ObjectType As Type)
            Me.ObjectType = ObjectType
        End Sub
    End Class
End Namespace

