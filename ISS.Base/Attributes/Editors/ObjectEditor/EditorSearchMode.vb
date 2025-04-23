Namespace Attributes.ObjectEditor
    ''' <summary>
    ''' When an exact or fuzzy search mode is chosen, it will allow for free form text entry in the editor.  Once a value is set, if there is no matching value in the database the popup window will display for searching purposes.
    ''' </summary>
    ''' <remarks></remarks>
Public Class EditorSearchModeAttribute
    Inherits Attribute
    Public Enum SupportedModes
        Standard = 0
        ExactSearchWithText = 1
        FuzzySearchWithText = 1
    End Enum

    ' Fields...
    Private _mSearchMode As SupportedModes
    Public Property SearchMode As SupportedModes
        Get
            Return _mSearchMode
        End Get
        Set(ByVal Value As SupportedModes)
            _mSearchMode = Value
        End Set
    End Property
    Private _mSearchProperty As String
    Public Property SearchProperty As String
        Get
            Return _mSearchProperty
        End Get
        Set(ByVal Value As String)
            _mSearchProperty = Value
        End Set
    End Property
    Public Sub New(ByVal SearchMode As SupportedModes)
        Me.SearchMode = SearchMode
    End Sub

End Class

End Namespace
