Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.XtraSpellChecker

Public Class DictionaryCreatedEventArgs
    Inherits EventArgs

    Public Sub New(ByVal dictionary As ISpellCheckerDictionary, ByVal isCustom As Boolean)
        Me.Dictionary = dictionary
        Me.IsCustom = isCustom
    End Sub

    Public Property Dictionary As ISpellCheckerDictionary
    Public Property IsCustom As Boolean
End Class