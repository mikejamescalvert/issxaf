
Namespace Attributes.Editors.PropertyEditors
    Public Class AllowOpenObjectAttribute
        Inherits Attribute
        Private _mAllow As Boolean
        Public Property Allow As Boolean
            Get
                Return _mAllow
            End Get
            Set(ByVal Value As Boolean)
                _mAllow = Value
            End Set
        End Property
        Public Sub New(ByVal AllowOpenObject As Boolean)
            Allow = AllowOpenObject
        End Sub
    End Class
End Namespace

