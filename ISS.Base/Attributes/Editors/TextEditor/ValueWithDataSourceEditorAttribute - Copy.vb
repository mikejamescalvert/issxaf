
Namespace Attributes.Editors.TextEditor
    Public Class ValueWithDataSourceEditorAttribute
        Inherits Attribute

        Private _mSourceCollectionPropertyName As String
        Property SourceCollectionPropertyName As String
            Get
                Return _mSourceCollectionPropertyName
            End Get
            Set(ByVal Value As String)
                _mSourceCollectionPropertyName = Value
            End Set
        End Property

        Private _mValuePropertyName As String
        Property ValuePropertyName As String
            Get
                Return _mValuePropertyName
            End Get
            Set(ByVal Value As String)
                _mValuePropertyName = Value
            End Set
        End Property


        Public Sub New(ByVal SourceCollectionPropertyName As String, ByVal ValuePropertyName As String)
            Me.SourceCollectionPropertyName = SourceCollectionPropertyName
            Me.ValuePropertyName = ValuePropertyName
        End Sub

    End Class
End Namespace
