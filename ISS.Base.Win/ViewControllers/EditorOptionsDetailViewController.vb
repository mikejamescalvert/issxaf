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
Imports DevExpress.ExpressApp.Win.Layout
Imports DevExpress.ExpressApp.Win.Editors
Imports System.Windows.Forms

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class EditorOptionsDetailViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.DetailView
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub

    Public ReadOnly Property ThisDetailView As DetailView
        Get
            Return TryCast(View, DetailView)
        End Get
    End Property


    Public ReadOnly Property ThisLayoutManager As WinLayoutManager
        Get
            Return TryCast(ThisDetailView.LayoutManager, WinLayoutManager)
        End Get
    End Property

    Public ReadOnly Property EditorOptions As IModelExtension
        Get
            Return TryCast(Application.Model, IModelExtension)
        End Get
    End Property


    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        If ThisDetailView Is Nothing Then
            Return
        End If

        If ThisLayoutManager IsNot Nothing Then
            AddHandler ThisLayoutManager.ItemCreated, AddressOf WinLayoutManager_ItemCreated

        End If
        'For Each propertyEditor As IntegerPropertyEditor In ThisDetailView.GetItems(Of IntegerPropertyEditor)()
        '    AddHandler propertyEditor.ControlCreated, AddressOf propertyEditor_ControlCreated
        'Next propertyEditor
        'For Each propertyEditor As BooleanPropertyEditor In ThisDetailView.GetItems(Of BooleanPropertyEditor)()
        '    AddHandler propertyEditor.ControlCreated, AddressOf propertyEditor_ControlCreated
        'Next propertyEditor

        Dim blnShowHelp As Boolean = False

        If ThisDetailView IsNot Nothing AndAlso ThisDetailView.Model IsNot Nothing AndAlso ThisDetailView.Model.ModelClass IsNot Nothing AndAlso TypeOf ThisDetailView.Model.ModelClass Is ISS.Base.IBOModel
            If CType(ThisDetailView.Model.ModelClass, IBOModel).HelpURL > String.Empty
                blnShowHelp = True
            End If
        End If
        If blnShowHelp = False AndAlso TypeOf Me.Application.Model Is IApplicationExtension AndAlso CType(Me.Application.Model,IApplicationExtension).HelpURL > String.Empty
            blnShowHelp = True
        End If

        Me.Help_NeedHelp.Active("HelpUrlAvailable") = blnShowHelp    

        For Each propertyEditor In ThisDetailView.GetItems(Of PropertyEditor)

            AddHandler propertyEditor.ControlCreated, AddressOf propertyEditor_ControlCreated
        Next

    End Sub

    Private Sub propertyEditor_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
        'Dim propertyEditor As IntegerPropertyEditor = CType(sender, IntegerPropertyEditor)
        'propertyEditor.Control.Properties.Buttons(propertyEditor.Control.Properties.SpinButtonIndex).Visible = False

        Dim PE As DXPropertyEditor = TryCast(sender, DXPropertyEditor)
        If PE Is Nothing
            Return
        End If
        If PE IsNot Nothing AndAlso PE.Control IsNot Nothing Then
            'PE.Control.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            AddHandler PE.Control.KeyDown, AddressOf Control_KeyDown
        End If

        

        If EditorOptions Is Nothing OrElse EditorOptions.ISSEditorOptions Is Nothing OrElse PE.Model Is Nothing Then
            Return
        End If

        If EditorOptions.ISSEditorOptions.DisableNegativeNumberEntry = True Then
            If CType(PE.Model, IModelDetailViewItem).DisableNegativeNumberEntry.HasValue = False OrElse CType(PE.Model, IModelDetailViewItem).DisableNegativeNumberEntry = True Then
                If TypeOf PE Is IntegerPropertyEditor Then
                    DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.IntegerEdit).Properties.MaxValue = Int32.MaxValue
                    DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.IntegerEdit).Properties.MinValue = 0
                ElseIf TypeOf PE Is DoublePropertyEditor Then
                    DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DoubleEdit).Properties.MaxValue = Int32.MaxValue
                    DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DoubleEdit).Properties.MinValue = 0
                ElseIf TypeOf PE Is DecimalPropertyEditor Then
                    DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DecimalEdit).Properties.MaxValue = Int32.MaxValue
                    DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DecimalEdit).Properties.MinValue = 0
                End If
            End If
        End If

        If EditorOptions.ISSEditorOptions.DisableSpinButtons = True Then
            If CType(PE.Model, IModelDetailViewItem).DisableSpinButton.HasValue = False OrElse CType(PE.Model, IModelDetailViewItem).DisableSpinButton = True Then
                If TypeOf PE Is IntegerPropertyEditor Then
                    For intLoop As Integer = DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.IntegerEdit).Properties.Buttons.Count - 1 To 0 Step -1
                        DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.IntegerEdit).Properties.AllowMouseWheel = False
                        If DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.IntegerEdit).Properties.Buttons(intLoop).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Combo Then
                            DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.IntegerEdit).Properties.Buttons(intLoop).Visible = False
                        End If
                    Next
                ElseIf TypeOf PE Is DoublePropertyEditor Then
                    For intLoop As Integer = DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DoubleEdit).Properties.Buttons.Count - 1 To 0 Step -1
                        DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DoubleEdit).Properties.AllowMouseWheel = False
                        If DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DoubleEdit).Properties.Buttons(intLoop).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Combo Then
                            DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DoubleEdit).Properties.Buttons(intLoop).Visible = False
                        End If
                    Next
                ElseIf TypeOf PE Is DecimalPropertyEditor Then
                    For intLoop As Integer = DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DecimalEdit).Properties.Buttons.Count - 1 To 0 Step -1
                        DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DecimalEdit).Properties.AllowMouseWheel = False
                        If DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DecimalEdit).Properties.Buttons(intLoop).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Combo Then
                            DirectCast(PE.Control, DevExpress.ExpressApp.Win.Editors.DecimalEdit).Properties.Buttons(intLoop).Visible = False
                        End If
                    Next
                End If
            End If
        End If

    End Sub

    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F1 AndAlso sender IsNot Nothing
            For Each propertyEditor In ThisDetailView.GetItems(Of PropertyEditor)
                If propertyEditor.Control IsNot Nothing AndAlso propertyEditor.Control Is sender
                    if TypeOf propertyEditor.Model Is IModelBOModelItem andalso CType(propertyEditor.Model,IModelBOModelItem).HelpURL > String.Empty
                        Process.Start(CType(propertyEditor.Model,IModelBOModelItem).HelpURL)
                        e.Handled = True
                    End If
                End If
            Next
            If e.Handled = False AndAlso TypeOf Me.Application.Model Is IApplicationExtension AndAlso CType(Me.Application.Model,IApplicationExtension).HelpURL > String.Empty
                Process.Start(CType(Me.Application.Model,IApplicationExtension).HelpURL)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub WinLayoutManager_ItemCreated(sender As Object, e As ItemCreatedEventArgs)
        Dim PE As DXPropertyEditor = TryCast(e.ViewItem, DXPropertyEditor)
        Dim xciControlItem As DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem = TryCast(e.Item, DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem)
        If PE IsNot Nothing AndAlso xciControlItem IsNot Nothing Then
            If TypeOf PE Is IntegerPropertyEditor Then
                'PE.Control.MaximumSize = New System.Drawing.Size(50, 25)
                'xciControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
                'xciControlItem.MaxSize = New System.Drawing.Size(0, 26)
            End If
            If TypeOf PE Is DoublePropertyEditor Then
                'PE.Control.MaximumSize = New System.Drawing.Size(100, 25)
                'xciControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
                'xciControlItem.MaxSize = New System.Drawing.Size(0, 26)
            End If
            If TypeOf PE Is DecimalPropertyEditor Then
                'PE.Control.MaximumSize = New System.Drawing.Size(100, 25)
                'xciControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
                'xciControlItem.MaxSize = New System.Drawing.Size(0, 26)
            End If
            If TypeOf PE Is BooleanPropertyEditor Then
                'DirectCast(xciControlItem, XafLayoutControlItem).TextVisible = True
            End If
        End If
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
        If ThisDetailView Is Nothing Then
            Return
        End If
        For Each propertyEditor As IntegerPropertyEditor In ThisDetailView.GetItems(Of IntegerPropertyEditor)()
            RemoveHandler propertyEditor.ControlCreated, AddressOf propertyEditor_ControlCreated
        Next propertyEditor
        For Each propertyEditor As BooleanPropertyEditor In ThisDetailView.GetItems(Of BooleanPropertyEditor)()
            RemoveHandler propertyEditor.ControlCreated, AddressOf propertyEditor_ControlCreated
        Next propertyEditor

    End Sub

    Private Sub Help_NeedHelp_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles Help_NeedHelp.Execute
        Dim strUrl As String = String.Empty
        If ThisDetailView IsNot Nothing AndAlso ThisDetailView.Model IsNot Nothing AndAlso ThisDetailView.Model.ModelClass IsNot Nothing AndAlso TypeOf ThisDetailView.Model.ModelClass Is ISS.Base.IBOModel
            If CType(ThisDetailView.Model.ModelClass, IBOModel).HelpURL > String.Empty
                strUrl = CType(ThisDetailView.Model.ModelClass, IBOModel).HelpURL
            End If
        End If
        If strUrl = String.Empty AndAlso TypeOf Me.Application.Model Is IApplicationExtension AndAlso CType(Me.Application.Model,IApplicationExtension).HelpURL > String.Empty
            strUrl = ctype(Me.Application.Model,IApplicationExtension).HelpURL
        End If
        If strUrl > String.Empty
            Process.Start(strUrl)
        End If
    End Sub
End Class
