Imports System.ComponentModel
Imports DevExpress.ExpressApp.Model

Public Interface IModelOptionsSpellChecker
    Inherits IModelNode

    <DXDescription("DevExpress.ExpressApp.SpellChecker.IModelOptionsSpellChecker,SpellChecker")>
    ReadOnly Property SpellChecker As IModelSpellChecker
End Interface

Public Interface IModelSpellChecker
    Inherits IModelNode

    <DXDescription("DevExpress.ExpressApp.SpellChecker.IModelSpellChecker,Enabled")>
    <Category("Behavior")>
    <DefaultValue(True)>
    Property Enabled As Boolean
    <DXDescription("DevExpress.ExpressApp.SpellChecker.IModelSpellChecker,AlphabetPath")>
    <Category("Data")>
    <Localizable(True)>
    <DefaultValue("Dictionaries\EnglishAlphabet.txt")>
    Property AlphabetPath As String
    <DXDescription("DevExpress.ExpressApp.SpellChecker.IModelSpellChecker,GrammarPath")>
    <Category("Data")>
    <DefaultValue("Dictionaries\English.aff")>
    <Localizable(True)>
    Property GrammarPath As String
    <DXDescription("DevExpress.ExpressApp.SpellChecker.IModelSpellChecker,DefaultDictionaryPath")>
    <Category("Data")>
    <DefaultValue("Dictionaries\American.xlg")>
    <Localizable(True)>
    Property DefaultDictionaryPath As String
    <DXDescription("DevExpress.ExpressApp.SpellChecker.IModelSpellChecker,CustomDictionaryPath")>
    <Category("Data")>
    <DefaultValue("Dictionaries\Custom.txt")>
    <Localizable(True)>
    Property CustomDictionaryPath As String
    <DXDescription("DevExpress.ExpressApp.SpellChecker.IModelSpellChecker,DefaultDictionaryPathResolution")>
    <Category("Behavior")>
    <DefaultValue(FilePathResolutionMode.RelativeToApplicationFolder)>
    Property PathResolutionMode As FilePathResolutionMode
End Interface

Public Enum FilePathResolutionMode
    '<Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    None
    Absolute
    RelativeToApplicationFolder
End Enum
