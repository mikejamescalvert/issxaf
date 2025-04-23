
Public Class SpellCheckerCreatedEventArgs
    Inherits EventArgs

    Public Sub New(ByVal spellChecker As Object)
        Me.SpellChecker = spellChecker
    End Sub

    Public Property SpellChecker As Object
End Class
