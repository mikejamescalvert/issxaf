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
Imports DevExpress.ExpressApp.Security

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class DevExRichTextEditorController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        TargetViewType = ViewType.DetailView
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub

    Public ReadOnly Property ThisDetailView As DetailView
        Get
            Return View
        End Get
    End Property

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        AddHandler View.SelectionChanged, AddressOf View_SelectionChanged
        UpdateSetTaskActionState()
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub View_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        UpdateSetTaskActionState()
    End Sub
    Private Sub UpdateSetTaskActionState()
        Dim isGranted As Boolean
        Dim security As SecurityStrategy = Application.GetSecurityStrategy()

        For Each selectedObject As Object In View.SelectedObjects

            For Each objEditor In ThisDetailView.GetItems(Of DevExRichTextEditor)
                isGranted = True
                Dim isPriorityGranted As Boolean = security.CanWrite(selectedObject, objEditor.PropertyName)
                Dim isStatusGranted As Boolean = security.CanWrite(selectedObject, objEditor.PropertyName)
                If Not isPriorityGranted OrElse Not isStatusGranted Then
                    isGranted = False
                End If
                objEditor.SecurityDisable = Not isGranted
            Next

        Next selectedObject


    End Sub

End Class
