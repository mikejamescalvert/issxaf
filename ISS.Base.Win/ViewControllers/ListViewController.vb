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

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class ListViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.ListView
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Public ReadOnly Property ListView As ListView
        Get
            Return TryCast(View,ListView)
        End Get
    End Property
    Public ReadOnly Property GridListEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor
        Get
            If ListView Is Nothing Then
                Return Nothing
            End If
            Return TryCast(ListView.Editor,DevExpress.ExpressApp.Win.Editors.GridListEditor)
        End Get
    End Property
    Public ReadOnly Property ApplicationModelExtension As IModelExtension
        Get
            If Application IsNot Nothing Then
                Return TryCast(Application.Model,IModelExtension)
            End If
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property ListViewModelExtension As IISSListView
        Get
            If ListView IsNot Nothing Then
                Return TryCast(ListView.Model,IISSListView)    
            End If
            Return Nothing
        End Get
    End Property
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        'If TypeOf ListView.Editor is DragAndDropBoardEditor Then
        '    CType(ListView.Editor,DragAndDropBoardEditor).XafApplication = Application
        'End If
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()


        If GridListEditor IsNot Nothing Then
            If ListViewModelExtension IsNot Nothing AndAlso ListViewModelExtension.ShowGridFooter.HasValue = True Then
                If (ListViewModelExtension.ShowGridFooter.Value = GridFooterOptions.RootListViewOnly And ListView.IsRoot = True) _
                 Or ListViewModelExtension.ShowGridFooter.Value = GridFooterOptions.Always Then
                    GridListEditor.GridView.OptionsView.ShowFooter = True
                End If
            ElseIf ApplicationModelExtension IsNot Nothing Then
                If (ApplicationModelExtension.ISSApplicationOptions.ShowGridFooter = GridFooterOptions.RootListViewOnly And ListView.IsRoot = True) _
                 Or ApplicationModelExtension.ISSApplicationOptions.ShowGridFooter = GridFooterOptions.Always Then
                    GridListEditor.GridView.OptionsView.ShowFooter = True
                End If
            End If
        End If

        For each strNew In View.AllowNew.GetKeys
            If View.AllowNew(strNew) = False
                'ono
            End If
        Next

        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub



End Class
