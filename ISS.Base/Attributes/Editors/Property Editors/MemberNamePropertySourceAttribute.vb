Namespace Attributes.Editors.PropertyEditors
    Public Class MemberNamePropertySourceAttribute
        Inherits Attribute

        ' Fields...
        Private _mObjectTypeProperty As String
        Public Property ObjectTypeProperty As String
            Get
                Return _mObjectTypeProperty
            End Get
            Set(ByVal Value As String)
                _mObjectTypeProperty = Value
            End Set
        End Property
        
        Private _mPropertyTypeFilter As String
        Public Property PropertyTypeFilter As String
            Get
                Return _mPropertyTypeFilter
            End Get
            Set(ByVal Value As String)
                _mPropertyTypeFilter = Value
            End Set
        End Property
        
        Public Sub New(ByVal ObjectTypeProperty As String, ByVal PropertyTypeFilter as string)
            Me.ObjectTypeProperty = ObjectTypeProperty
            Me.PropertyTypeFilter = PropertyTypeFilter
        End Sub
    End Class
End Namespace

