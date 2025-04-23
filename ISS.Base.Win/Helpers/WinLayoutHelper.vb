Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports System.Windows.Forms
Imports System.Drawing

Public Class WinLayoutHelper


    Public Shared Sub SetupDevExpressNormalControlWithDetailViewItem(ByVal Control As DevExpress.XtraEditors.BaseControl, ByVal Model As IDetailViewItem)
        Dim fntFont As Font
        Dim ftsFontStyle As FontStyle
        Dim szeSize As Single
        If Model.BackgroundColor <> Nothing Then
            Control.LookAndFeel.UseDefaultLookAndFeel = False
            Control.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        End If

        If Model.Bold = True Then
            ftsFontStyle = FontStyle.Bold
        Else
            ftsFontStyle = FontStyle.Regular
        End If

        'For Each btn As CheckButton In _mStateButtonList
        If Model.MinimumHeight > 0 OrElse Model.MinimumWidth > 0 Then
            Control.MinimumSize = New System.Drawing.Size(Model.MinimumWidth, Model.MinimumHeight)
        End If
        If Model.ForegroundColor <> Nothing Then
            If TypeOf Control Is DevExpress.XtraEditors.CheckButton AndAlso Model.CheckedForegroundColor <> Nothing AndAlso CType(Control, DevExpress.XtraEditors.CheckButton).Checked = True Then
                Control.BackColor = Model.CheckedForegroundColor
            Else
                Control.BackColor = Model.ForegroundColor
            End If

            Control.ForeColor = Model.ForegroundColor
        End If
        If Model.BackgroundColor <> Nothing Then
            If TypeOf Control Is DevExpress.XtraEditors.CheckButton AndAlso Model.CheckedBackgroundColor <> Nothing AndAlso CType(Control, DevExpress.XtraEditors.CheckButton).Checked = True Then
                Control.BackColor = Model.CheckedBackgroundColor
            Else
                Control.BackColor = Model.BackgroundColor
            End If

        End If
        fntFont = Control.Font
        If Model.FontSize > 0 Then
            szeSize = Model.FontSize
        Else
            szeSize = Control.Font.Size
        End If
        fntFont = New Font(Control.Font.FontFamily, szeSize, ftsFontStyle)
        Control.Font = fntFont



    End Sub

    Public Shared Sub SetupDevExpressControlWithDetailViewItem(ByVal Control As DevExpress.XtraEditors.BaseStyleControl, ByVal Model As IDetailViewItem)
        Dim fntFont As Font
        Dim ftsFontStyle As FontStyle
        Dim szeSize As Single
        If Model.BackgroundColor <> Nothing Then
            Control.LookAndFeel.UseDefaultLookAndFeel = False
            Control.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        End If

        If Model.Bold = True Then
            ftsFontStyle = FontStyle.Bold
        Else
            ftsFontStyle = FontStyle.Regular
        End If

        'For Each btn As CheckButton In _mStateButtonList
        If Model.MinimumHeight > 0 OrElse Model.MinimumWidth > 0 Then
            Control.MinimumSize = New System.Drawing.Size(Model.MinimumWidth, Model.MinimumHeight)
        End If
        If Model.ForegroundColor <> Nothing Then

            If TypeOf Control Is DevExpress.XtraEditors.CheckButton AndAlso Model.CheckedForegroundColor <> Nothing AndAlso CType(Control, DevExpress.XtraEditors.CheckButton).Checked = True Then
                Control.Appearance.BackColor = Model.CheckedForegroundColor
            Else
                Control.Appearance.BackColor = Model.ForegroundColor
            End If

            Control.ForeColor = Model.ForegroundColor
        End If
        If Model.BackgroundColor <> Nothing Then
            If TypeOf Control Is DevExpress.XtraEditors.CheckButton AndAlso Model.CheckedBackgroundColor <> Nothing AndAlso CType(Control, DevExpress.XtraEditors.CheckButton).Checked = True Then
                Control.Appearance.BackColor = Model.CheckedBackgroundColor
            Else
                Control.Appearance.BackColor = Model.BackgroundColor
            End If

        End If
        fntFont = Control.Font
        If Model.FontSize > 0 Then
            szeSize = Model.FontSize
        Else
            szeSize = Control.Font.Size
        End If
        fntFont = New Font(Control.Font.FontFamily, szeSize, ftsFontStyle)
        Control.Font = fntFont



    End Sub

    Public Shared Sub SetupPropertyEditor(ByVal PropertyControlObject As System.Windows.Forms.Control, ByVal IsEnabled As System.Nullable(Of Boolean), ByVal IsVisible As System.Nullable(Of Boolean), ByVal IsRequired As System.Nullable(Of Boolean), ByVal IsReadonly As System.Nullable(Of Boolean), ByVal EditorColor As System.Drawing.Color)
        If PropertyControlObject Is Nothing Then
            Return
        End If
        If PropertyControlObject.Parent Is Nothing Then
            Return
        End If
        Dim dlcLayoutControl As DevExpress.XtraLayout.LayoutControl = PropertyControlObject.Parent
        Dim dlcLayoutControlItem As DevExpress.XtraLayout.LayoutControlItem = ISS.Base.Win.LayoutHelper.GetLayoutControlItemFromParentLayout(PropertyControlObject, dlcLayoutControl)
        SetPropertyEditorVisible(PropertyControlObject, IsVisible)
        SetPropertyEditorReadonly(PropertyControlObject, IsReadonly)
        SetPropertyEditorEnabled(PropertyControlObject, IsEnabled)
        If IsRequired.HasValue = True Then
            If dlcLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
                If IsRequired = True Then
                    If dlcLayoutControlItem.AppearanceItemCaption.Font.Bold = False Then
                        dlcLayoutControlItem.AppearanceItemCaption.Font = New System.Drawing.Font(dlcLayoutControlItem.AppearanceItemCaption.Font, Drawing.FontStyle.Bold)
                    End If
                Else
                    If dlcLayoutControlItem.AppearanceItemCaption.Font.Bold = True Then
                        dlcLayoutControlItem.AppearanceItemCaption.Font = New System.Drawing.Font(dlcLayoutControlItem.AppearanceItemCaption.Font, Drawing.FontStyle.Regular)
                    End If
                End If

            End If
        End If
        If EditorColor <> Nothing Then
            dlcLayoutControlItem.AppearanceItemCaption.ForeColor = EditorColor
        End If
    End Sub
    Public Shared Sub SetPropertyEditorReadonly(ByVal PropertyControlObject As Control, ByVal IsReadonly As System.Nullable(Of Boolean))
        If IsReadonly.HasValue = False Then
            Return
        End If
        If TypeOf PropertyControlObject Is DevExpress.XtraEditors.BaseEdit Then
            If CType(PropertyControlObject, DevExpress.XtraEditors.BaseEdit).Properties.ReadOnly <> IsReadonly Then
                CType(PropertyControlObject, DevExpress.XtraEditors.BaseEdit).Properties.ReadOnly = IsReadonly
            End If
        End If

    End Sub
    Public Shared Sub SetPropertyEditorEnabled(ByVal PropertyControlObject As System.Windows.Forms.Control, ByVal IsEnabled As System.Nullable(Of Boolean))
        If IsEnabled.HasValue = False Then
            Return
        End If
        If PropertyControlObject.Enabled <> IsEnabled Then
            PropertyControlObject.Enabled = Not PropertyControlObject.Enabled
        End If
    End Sub
    Public Shared Sub SetPropertyEditorVisible(ByVal PropertyControlObject As System.Windows.Forms.Control, ByVal IsVisible As System.Nullable(Of Boolean))
        If IsVisible.HasValue = False Then
            Return
        End If
        Dim dlcLayoutControl As DevExpress.XtraLayout.LayoutControl = PropertyControlObject.Parent
        Dim dlcLayoutControlItem As DevExpress.XtraLayout.LayoutControlItem = ISS.Base.Win.LayoutHelper.GetLayoutControlItemFromParentLayout(PropertyControlObject, dlcLayoutControl)
        If IsVisible = True Then
            If dlcLayoutControlItem.Visibility <> DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
                dlcLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If
        Else
            If dlcLayoutControlItem.Visibility <> DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
                dlcLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        End If
    End Sub
    Public Shared Sub SetPropertyEditorRequired(ByVal PropertyControlObject As System.Windows.Forms.Control, ByVal IsRequired As System.Nullable(Of Boolean))
        If IsRequired.HasValue = False Then
            Return
        End If
        If PropertyControlObject Is Nothing Then
            Return
        End If
        If PropertyControlObject.Parent Is Nothing Then
            Return
        End If
        Dim dlcLayoutControl As DevExpress.XtraLayout.LayoutControl = PropertyControlObject.Parent
        Dim dlcLayoutControlItem As DevExpress.XtraLayout.LayoutControlItem = ISS.Base.Win.LayoutHelper.GetLayoutControlItemFromParentLayout(PropertyControlObject, dlcLayoutControl)
        If IsRequired = True Then
            If dlcLayoutControlItem.AppearanceItemCaption.Font.Bold = False Then
                dlcLayoutControlItem.AppearanceItemCaption.Font = New System.Drawing.Font(dlcLayoutControlItem.AppearanceItemCaption.Font, Drawing.FontStyle.Bold)
            End If
        Else
            If dlcLayoutControlItem.AppearanceItemCaption.Font.Bold = True Then
                dlcLayoutControlItem.AppearanceItemCaption.Font = New System.Drawing.Font(dlcLayoutControlItem.AppearanceItemCaption.Font, Drawing.FontStyle.Regular)
            End If
        End If
    End Sub
    Public Shared Sub SetListViewControllersEnabled(ByVal ListView As Editors.ListPropertyEditor, ByVal IsEnabled As System.Nullable(Of Boolean))
        If ListView.Frame Is Nothing Then
            Return
        End If
        For Each objController As Controller In ListView.Frame.Controllers
            Try
                If IsEnabled.HasValue = True Then
                    objController.Active.SetItemValue("WorkflowDisable", IsEnabled)
                Else
                    objController.Active.SetItemValue("WorkflowDisable", True)
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub
    Public Shared Sub SetupListView(ByVal ListView As Editors.ListPropertyEditor, ByVal IsEnabled As System.Nullable(Of Boolean), ByVal IsVisible As System.Nullable(Of Boolean))
        'TODO: Add logic to disallow hiding if conflicting with another editor type.
        'SetPropertyEditorVisible(ListView.Control, IsVisible)
        SetListViewControllersEnabled(ListView, IsEnabled)
    End Sub


End Class
