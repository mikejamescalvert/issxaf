Imports DevExpress.XtraSpellChecker
Imports System.Reflection
Imports System.Globalization
Imports System.IO
Imports DevExpress.XtraSpellChecker.Native
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors
Imports System.Windows.Forms
Imports ISS.Base.Win

Public NotInheritable Class SpellCheckerInitializer
    Private Shared dictionary_Renamed As SpellCheckerISpellDictionary
    Private Shared customDictionary_Renamed As SpellCheckerCustomDictionary
    Private Sub New()
    End Sub
    Public Shared Sub Initialize(ByVal spellCheckerCore As DevExpress.XtraSpellChecker.SpellChecker)
        If dictionary_Renamed Is Nothing Then
            dictionary_Renamed = New SpellCheckerISpellDictionary()
            Dim workAssembly As System.Reflection.Assembly = GetType(SpellCheckerInitializer).Assembly
            Dim affStream As Stream = workAssembly.GetManifestResourceStream("ISS.SpellChecker.Win.English.aff")
            Dim dicStream As Stream = workAssembly.GetManifestResourceStream("ISS.SpellChecker.Win.American.xlg")
            Dim alphStream As Stream = workAssembly.GetManifestResourceStream("ISS.SpellChecker.Win.EnglishAlphabet.txt")
            dictionary_Renamed.LoadFromStream(dicStream, affStream, alphStream)
            dictionary_Renamed.CaseSensitive = False
            dictionary_Renamed.Culture = New CultureInfo("en-US")
            customDictionary_Renamed = New SpellCheckerCustomDictionary()
            'customDictionary.AlphabetPath = dictionary.AlphabetPath;
            customDictionary_Renamed.FillAlphabetFromStream(workAssembly.GetManifestResourceStream("ISS.SpellChecker.Win.English.aff"))
            'customDictionary.DictionaryPath = "Dictionaries\\Custom.txt";
            customDictionary_Renamed.LoadFromStream(workAssembly.GetManifestResourceStream("ISS.SpellChecker.Win.Custom.txt"))
            customDictionary_Renamed.CaseSensitive = False
            customDictionary_Renamed.Culture = dictionary_Renamed.Culture
            SpellCheckTextControllersManager.Default.RegisterClass(GetType(StringEdit), GetType(SimpleTextEditTextController))
            SpellCheckTextControllersManager.Default.RegisterClass(GetType(LargeStringEdit), GetType(SimpleTextEditTextController))
            SpellCheckTextControllersManager.Default.RegisterClass(GetType(MemoEdit), GetType(SimpleTextEditTextController))
            SpellCheckTextControllersManager.Default.RegisterClass(GetType(ButtonEdit), GetType(SimpleTextEditTextController))

            SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(StringEdit), GetType(StringEditTextBoxFinder))
            SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(ButtonEdit), GetType(StringEditTextBoxFinder))
            SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(LargeStringEdit), GetType(LargeStringEditTextBoxFinder))
            SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditor), GetType(HtmlStringEditTextBoxFinder))
            SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(DevExRichTextEditor), GetType(RtfStringEditTextBoxFinder))
        End If

        spellCheckerCore.SpellCheckMode = SpellCheckMode.AsYouType
        spellCheckerCore.CheckAsYouTypeOptions.ShowSpellCheckForm = True
        spellCheckerCore.CheckAsYouTypeOptions.CheckControlsInParentContainer = True
        spellCheckerCore.Culture = New CultureInfo("en-US")
        spellCheckerCore.Dictionaries.Add(SpellCheckerInitializer.Dictionary)
        spellCheckerCore.Dictionaries.Add(SpellCheckerInitializer.CustomDictionary)
        'dictionary.AlphabetPath = "Dictionaries\\EnglishAlphabet.txt";
        'dictionary.DictionaryPath = "Dictionaries\\American.xlg";
        'dictionary.GrammarPath = "Dictionaries\\English.aff";

        'dictionary.Encoding = Encoding.GetEncoding(1252);
        'dictionary.Load();


        'customDictionary.Encoding = dictionary.Encoding;
        'customDictionary.Load();


    End Sub
    Public Shared ReadOnly Property Dictionary() As SpellCheckerISpellDictionary
        Get
            Return dictionary_Renamed
        End Get
    End Property
    Public Shared ReadOnly Property CustomDictionary() As SpellCheckerCustomDictionary
        Get
            Return customDictionary_Renamed
        End Get
    End Property
End Class
Public Class HtmlStringEditTextBoxFinder
    Inherits MemoEditTextBoxFinder
    Public Overrides Function GetTextBoxInstance(ByVal editControl As Control) As TextBoxBase
        If TypeOf editControl Is DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlEditor Then
            Return MyBase.GetTextBoxInstance(editControl)
        End If
        Return Nothing
    End Function
End Class
Public Class RtfStringEditTextBoxFinder
    Inherits MemoEditTextBoxFinder
    Public Overrides Function GetTextBoxInstance(ByVal editControl As Control) As TextBoxBase
        If TypeOf editControl Is RichTextUserControl Then
            Return MyBase.GetTextBoxInstance(CType(editControl, RichTextUserControl))
        End If
        Return Nothing
    End Function
End Class
Public Class LargeStringEditTextBoxFinder
    Inherits MemoEditTextBoxFinder
    Public Overrides Function GetTextBoxInstance(ByVal editControl As Control) As TextBoxBase
        If TypeOf editControl Is LargeStringEdit Then
            Return MyBase.GetTextBoxInstance(CType(editControl, MemoEdit))
        End If
        Return Nothing
    End Function
End Class
Public Class StringEditTextBoxFinder
    Inherits TextEditTextBoxFinder
    Public Overrides Function GetTextBoxInstance(ByVal editControl As Control) As TextBoxBase
        If TypeOf editControl Is StringEdit OrElse TypeOf editControl Is ButtonEdit Then
            Return MyBase.GetTextBoxInstance(CType(editControl, TextEdit))
        End If
        Return Nothing
    End Function
End Class
