Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.XtraSpellChecker
Imports System.Globalization
Imports System.Windows.Forms

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
Partial Public Class WinSpellCheckerWindowController
    Inherits SpellCheckerWindowController
    Public Sub New()
        InitializeComponent()
        ' Target required Windows (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target Window.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Protected Shared dictionariesStorage As SharedDictionaryStorage

    Protected Overrides Function CreateSpellCheckerComponent(ByVal parentContainer As Object) As Object
        Dim result = New DevExpress.XtraSpellChecker.SpellChecker()
        result.ParentContainer = CType(parentContainer, Form)
        result.SpellCheckMode = SpellCheckMode.AsYouType
        result.CheckAsYouTypeOptions.ShowSpellCheckForm = True
        result.CheckAsYouTypeOptions.CheckControlsInParentContainer = True
        result.Culture = CultureInfo.CurrentUICulture
        result.UseSharedDictionaries = True
        Return result
    End Function

    Public Overloads Property SpellCheckerComponent As DevExpress.XtraSpellChecker.SpellChecker
        Get
            Return TryCast(MyBase.SpellCheckerComponent, DevExpress.XtraSpellChecker.SpellChecker)
        End Get
        Private Set(ByVal value As DevExpress.XtraSpellChecker.SpellChecker)
            MyBase.SpellCheckerComponent = value
        End Set
    End Property

    Protected Overrides ReadOnly Property SpellChecker As SpellCheckerBase
        Get
            Return SpellCheckerComponent
        End Get
    End Property


    Public Overrides Sub CheckSpelling()
        If SpellCheckerComponent IsNot Nothing Then
            SpellCheckerComponent.CheckContainer()

        End If
    End Sub

    Protected Overrides Sub UpdateCheckSpellingAction(ByVal window As Window)
        MyBase.UpdateCheckSpellingAction(window)
        CheckSpellingAction.Active("IsMain") = Not window.IsMain
    End Sub

    Protected Overrides Sub ActivateDictionaries()
        If dictionariesStorage Is Nothing Then
            dictionariesStorage = New SharedDictionaryStorage()
            dictionariesStorage.Dictionaries.Add(DefaultDictionary)
            dictionariesStorage.Dictionaries.Add(CustomDictionary)
        End If

        SpellCheckerComponent.Dictionaries.AddRange(dictionariesStorage.Dictionaries)
    End Sub
    Protected Overrides Function CreateDefaultDictionaryCore() As SpellCheckerISpellDictionary
        Return New SpellCheckerISpellDictionary()
    End Function

    Protected Overrides Function CreateCustomDictionaryCore() As SpellCheckerCustomDictionary
        Return New SpellCheckerCustomDictionary()
    End Function

End Class
