Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Linq
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Model.DomainLogics
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.XtraSpellChecker.Native
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports System.Windows.Forms
Imports ISS.SpellChecker.Win
Imports ISS.Base.Win

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
Public NotInheritable Class SpellCheckerV2WinModule
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
        BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction
        RegisterSpellCheckerControlFinders()
    End Sub

    Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
        Dim updater As ModuleUpdater = New Updater(objectSpace, versionFromDB)
        Return New ModuleUpdater() {updater}
    End Function

    Public Overrides Sub Setup(application As XafApplication)
        MyBase.Setup(application)
        ' Manage various aspects of the application UI and behavior at the module level.
    End Sub
    Public Overrides Sub CustomizeTypesInfo(ByVal typesInfo As ITypesInfo)
        MyBase.CustomizeTypesInfo(typesInfo)
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo)
    End Sub

    Private Shared Sub RegisterSpellCheckerControlFinders()
        SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(StringEdit), GetType(StringEditTextBoxFinder))

        SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(LargeStringEdit), GetType(LargeStringEditTextBoxFinder))

        SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(MemoEdit), GetType(SimpleTextEditTextController))

        SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(ButtonEdit), GetType(TextEditTextBoxFinder))


        SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(HtmlPropertyEditor.Win.HtmlPropertyEditor), GetType(HtmlStringEditTextBoxFinder))

        'SpellCheckTextBoxBaseFinderManager.Default.RegisterClass(GetType(DevExRichTextEditor), GetType(RtfStringEditTextBoxFinder))



        SpellCheckTextControllersManager.Default.RegisterClass(GetType(StringEdit), GetType(SimpleTextEditTextController))

        SpellCheckTextControllersManager.Default.RegisterClass(GetType(LargeStringEdit), GetType(SimpleTextEditTextController))

        SpellCheckTextControllersManager.Default.RegisterClass(GetType(MemoEdit), GetType(SimpleTextEditTextController))

        SpellCheckTextControllersManager.Default.RegisterClass(GetType(ButtonEdit), GetType(SimpleTextEditTextController))




    End Sub
End Class

Public Class LargeStringEditTextBoxFinder
    Inherits MemoEditTextBoxFinder

    Public Overrides Function GetTextBoxInstance(ByVal editControl As Control) As TextBoxBase
        If TypeOf editControl Is LargeStringEdit Then Return MyBase.GetTextBoxInstance(CType(editControl, MemoEdit))
        Return Nothing
    End Function
End Class

Public Class StringEditTextBoxFinder
    Inherits TextEditTextBoxFinder



    Public Overrides Function GetTextBoxInstance(ByVal editControl As Control) As TextBoxBase
        If TypeOf editControl Is StringEdit Then Return MyBase.GetTextBoxInstance(CType(editControl, TextEdit))
        Return Nothing
    End Function
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

