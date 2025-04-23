Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.XtraSpellChecker
Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Linq
Imports System.Reflection

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
Partial Public MustInherit Class SpellCheckerWindowController
    Inherits WindowController
    Private Shared lockObject As Object = New Object()
    Private Const ActiveKeyCanCheckSpelling As String = "CanCheckSpelling"

    Public Sub New()
        CheckSpellingAction = New SimpleAction(Me, "CheckSpelling", PredefinedCategory.RecordEdit)
        CheckSpellingAction.Caption = "Check Spelling"
        CheckSpellingAction.ToolTip = "Check the spelling and grammar of text in the form."
        CheckSpellingAction.Category = PredefinedCategory.RecordEdit.ToString()
        CheckSpellingAction.ImageName = "Action_SpellChecker"
        CheckSpellingAction.TargetViewType = ViewType.DetailView
    End Sub


    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        AddHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
    End Sub



    Protected Overrides Sub OnDeactivated()
        RemoveHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
        ReleaseSpellChecker()
        MyBase.OnDeactivated()
    End Sub

    Private Sub ReleaseSpellChecker()
        'If TypeOf SpellCheckerComponent Is IDisposable Then
        '    CType(SpellCheckerComponent, IDisposable).Dispose()
        '    SpellCheckerComponent = Nothing
        'End If
    End Sub

    Private Sub Window_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim window As Window = CType(sender, Window)

        If window.Template Is Nothing Then
            ReleaseSpellChecker()
        End If

        UpdateCheckSpellingAction(window)
    End Sub

    Protected Overridable Sub UpdateCheckSpellingAction(ByVal window As Window)
        Dim isInitialized As Boolean = InitializeSpellChecker(window)
        'mjc disable action
        CheckSpellingAction.Active(ActiveKeyCanCheckSpelling) = False
    End Sub

    Public Function InitializeSpellChecker(ByVal window As Window) As Boolean
        Dim success As Boolean = False

        If (SpellCheckerComponent Is Nothing) AndAlso CanCheckSpelling(window.Context, window.Template) Then
            SpellCheckerComponent = CreateSpellCheckerComponent(window.Template)


        End If
        If SpellCheckerComponent IsNot Nothing Then
            EnsureDictionaries()
            ActivateDictionaries()
            OnSpellCheckerCreated(New SpellCheckerCreatedEventArgs(SpellCheckerComponent))
            success = True
        End If
        Return success
    End Function

    Public Overridable Function CanCheckSpelling(ByVal context As TemplateContext, ByVal template As Object) As Boolean
        Dim args As QueryCanCheckSpellingEventArgs = New QueryCanCheckSpellingEventArgs(context, template)
        Dim isTargetTemplate As Boolean = (template IsNot Nothing) AndAlso (context = TemplateContext.ApplicationWindow OrElse context = TemplateContext.PopupWindow OrElse context = TemplateContext.View)
        args.Cancel = Not (SpellCheckerOptions.Enabled AndAlso isTargetTemplate)
        OnQueryCanCheckSpelling(args)
        Return Not args.Cancel
    End Function

    Protected MustOverride Function CreateDefaultDictionaryCore() As SpellCheckerISpellDictionary
    Protected MustOverride Function CreateCustomDictionaryCore() As SpellCheckerCustomDictionary
    Public MustOverride Sub CheckSpelling()
    Protected MustOverride Sub ActivateDictionaries()
    Protected MustOverride Function CreateSpellCheckerComponent(ByVal template As Object) As Object

    Private Sub EnsureDictionaries()
        If DefaultDictionary Is Nothing Then

            'SyncLock lockObject

            If DefaultDictionary Is Nothing Then
                Dim result As SpellCheckerISpellDictionary = CreateDefaultDictionaryCore()
                SetupDefaultDictionary(result)
                Dim args As DictionaryCreatedEventArgs = New DictionaryCreatedEventArgs(result, False)
                OnDictionaryCreated(args)
                DefaultDictionary = If(TryCast(args.Dictionary, SpellCheckerISpellDictionary), result)
            End If
            'End SyncLock
        End If

        If CustomDictionary Is Nothing Then

            'SyncLock lockObject

            If CustomDictionary Is Nothing Then
                Dim result As SpellCheckerCustomDictionary = CreateCustomDictionaryCore()
                SetupCustomDictionary(result)
                Dim args As DictionaryCreatedEventArgs = New DictionaryCreatedEventArgs(result, True)
                OnDictionaryCreated(args)
                CustomDictionary = If(TryCast(args.Dictionary, SpellCheckerCustomDictionary), result)
            End If
            'End SyncLock
        End If
    End Sub

    Private Shared _mWorkAssembly As Assembly
    Private Shared _mGrammarStream As Stream
    Private Shared _mDictionaryStream As Stream
    Private Shared _mAlphabetStream As Stream
    Private Shared _mCustomStream As Stream
    Public Sub SetupStreams()

        'If _mWorkAssembly Is Nothing Then
        _mWorkAssembly = GetType(SpellCheckerWindowController).Assembly
        'End If
        'If _mGrammarStream Is Nothing Then
        _mGrammarStream = _mWorkAssembly.GetManifestResourceStream("ISS.SpellChecker.V2.english.aff")
        'End If
        'If _mDictionaryStream Is Nothing Then
        _mDictionaryStream = _mWorkAssembly.GetManifestResourceStream("ISS.SpellChecker.V2.american.xlg")
        'End If
        'If _mAlphabetStream Is Nothing Then
        _mAlphabetStream = _mWorkAssembly.GetManifestResourceStream("ISS.SpellChecker.V2.EnglishAlphabet.txt")
        'End If
        ''If _mCustomStream Is Nothing Then
        _mCustomStream = _mWorkAssembly.GetManifestResourceStream("ISS.SpellChecker.V2.Custom.txt")
        'End If
    End Sub

    Protected Overridable Sub SetupDefaultDictionary(ByRef dictionary As SpellCheckerISpellDictionary)
        SetupStreams()
        dictionary.CaseSensitive = False
        dictionary.Culture = SpellChecker.Culture
        dictionary.Encoding = System.Text.Encoding.UTF8
        dictionary.LoadFromStream(_mDictionaryStream, _mGrammarStream, _mAlphabetStream)

    End Sub

    Protected Overridable Sub SetupCustomDictionary(ByRef dictionary As SpellCheckerCustomDictionary)
        SetupStreams()


        dictionary.CaseSensitive = False
        dictionary.Culture = SpellChecker.Culture
        dictionary.FillAlphabetFromStream(_mAlphabetStream)
        dictionary.LoadFromStream(_mCustomStream)

    End Sub

    Protected Overridable Sub OnDictionaryCreated(ByVal args As DictionaryCreatedEventArgs)
        RaiseEvent DictionaryCreated(Me, args)
    End Sub

    Protected Overridable Sub OnQueryCanCheckSpelling(ByVal args As QueryCanCheckSpellingEventArgs)
        RaiseEvent QueryCanCheckSpelling(Me, args)
    End Sub

    Protected Overridable Sub OnSpellCheckerCreated(ByVal args As SpellCheckerCreatedEventArgs)
        RaiseEvent SpellCheckerCreated(Me, args)
    End Sub

    Protected Overridable Function GetDictionaryFileInfo(ByVal isCustom As Boolean) As SpellCheckerDictionaryFileInfo
        Dim filePathPrefix As String = String.Empty

        If SpellCheckerOptions.PathResolutionMode = FilePathResolutionMode.RelativeToApplicationFolder Then
            filePathPrefix = PathHelper.GetApplicationFolder()
        End If

        Return New SpellCheckerDictionaryFileInfo(filePathPrefix & SpellCheckerOptions.AlphabetPath, filePathPrefix & (If(isCustom, SpellCheckerOptions.CustomDictionaryPath, SpellCheckerOptions.DefaultDictionaryPath)), If(isCustom, String.Empty, (filePathPrefix & SpellCheckerOptions.GrammarPath)))
    End Function

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Protected Overridable Function GetDictionaryStreamInfo(ByVal isCustom As Boolean) As SpellCheckerDictionaryStreamInfo
        Dim resourceAssembly As Assembly = GetType(SpellCheckerBase).Assembly
        Dim resourcePrefix As String = resourceAssembly.GetName().Name

        Try
            Dim alphabeth As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim alphabethStream As Stream = New MemoryStream(System.Text.Encoding.Unicode.GetBytes(alphabeth))

            Dim workAssembly As System.Reflection.Assembly = GetType(SpellCheckerWindowController).Assembly
            Dim affStream As Stream = workAssembly.GetManifestResourceStream("ISS.SpellChecker.V2.english.aff")
            Dim dicStream As Stream = workAssembly.GetManifestResourceStream("ISS.SpellChecker.V2.american.xlg")
            Dim alphStream As Stream = workAssembly.GetManifestResourceStream("ISS.SpellChecker.V2.EnglishAlphabet.txt")
            'dictionary_Renamed.LoadFromStream(dicStream, affStream, alphStream)
            'dictionary_Renamed.CaseSensitive = False
            'dictionary_Renamed.Culture = New CultureInfo("en-US")
            'customDictionary_Renamed = New SpellCheckerCustomDictionary()
            ''customDictionary.AlphabetPath = dictionary.AlphabetPath;
            'customDictionary_Renamed.FillAlphabetFromStream(workAssembly.GetManifestResourceStream("ISS.SpellChecker.Win.English.aff"))
            ''customDictionary.DictionaryPath = "Dictionaries\\Custom.txt";
            'customDictionary_Renamed.LoadFromStream(workAssembly.GetManifestResourceStream("ISS.SpellChecker.Win.Custom.txt"))
            'customDictionary_Renamed.CaseSensitive = False
            'customDictionary_Renamed.Culture = dictionary_Renamed.Culture

            'Dim dictionaryStream As Stream = resourceAssembly.GetManifestResourceStream("DevExpress.XtraSpellChecker.Core.Dictionary.american.xlg")
            'Dim grammarStream As Stream = resourceAssembly.GetManifestResourceStream("DevExpress.XtraSpellChecker.Core.Dictionary.english.aff")
            Return New SpellCheckerDictionaryStreamInfo(alphStream, dicStream, affStream)
        Catch ex As Exception
            Throw New ArgumentException(String.Format("Cannot load a dictionary from the {0} assembly by the specified name. Make sure that the dictionary file's BuildAction is set to EmbeddedResource and its name includes the file extension.", resourceAssembly.GetName().Name), ex)
        End Try
    End Function

    Private Sub CheckSpellingAction_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles CheckSpellingAction.Execute
        CheckSpelling()
    End Sub

    Public Shared Property DefaultDictionary As SpellCheckerISpellDictionary
    Public Shared Property CustomDictionary As SpellCheckerCustomDictionary
    Public Shared Property SpellCheckerComponent As Object
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Protected MustOverride ReadOnly Property SpellChecker As SpellCheckerBase

    Public ReadOnly Property SpellCheckerOptions As IModelSpellChecker
        Get
            Return (CType(Application.Model.Options, IModelOptionsSpellChecker)).SpellChecker
        End Get
    End Property

    Public Event QueryCanCheckSpelling As EventHandler(Of QueryCanCheckSpellingEventArgs)
    Public Event SpellCheckerCreated As EventHandler(Of SpellCheckerCreatedEventArgs)
    Public Event DictionaryCreated As EventHandler(Of DictionaryCreatedEventArgs)


    Public Structure SpellCheckerDictionaryFileInfo
        Public Sub New(ByVal alphabetPath As String, ByVal dictionaryPath As String, ByVal grammarPath As String)
            alphabetPath = alphabetPath
            dictionaryPath = dictionaryPath
            grammarPath = grammarPath
        End Sub

        Public AlphabetPath As String
        Public DictionaryPath As String
        Public GrammarPath As String
    End Structure

    Public Structure SpellCheckerDictionaryStreamInfo
        Public Sub New(ByVal alphabetStream As Stream, ByVal dictionaryStream As Stream, ByVal grammarStream As Stream)
            alphabetStream = alphabetStream
            dictionaryStream = dictionaryStream
            grammarStream = grammarStream
        End Sub

        Public AlphabetStream As Stream
        Public DictionaryStream As Stream
        Public GrammarStream As Stream
    End Structure
End Class
