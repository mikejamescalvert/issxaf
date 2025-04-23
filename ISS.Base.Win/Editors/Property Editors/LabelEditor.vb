Imports System
Imports System.Drawing
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Core
Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Utils

Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Repository

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(String), False)> _
<PropertyEditor(GetType(Object), EditorAliases.LookupPropertyEditor, False)>
<PropertyEditor(GetType(Object), EditorAliases.DoublePropertyEditor, False)>
<PropertyEditor(GetType(Object), EditorAliases.FloatPropertyEditor, False)>
<PropertyEditor(GetType(Object), EditorAliases.IntegerPropertyEditor, False)>
<PropertyEditor(GetType(Object), EditorAliases.ObjectPropertyEditor, False)>
<PropertyEditor(GetType(Object), EditorAliases.StringPropertyEditor, False)>
Public Class LabelEditor
    Inherits PropertyEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

    Private _mLabel As DevExpress.XtraEditors.LabelControl
    Protected Overrides Function CreateControlCore() As Object
        _mLabel = New DevExpress.XtraEditors.LabelControl
        _mLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        _mLabel.Dock = DockStyle.Right
        _mLabel.MinimumSize = New System.Drawing.Size(1, 1)
        UpdateLabel
        Return _mLabel
    End Function

    Public Overrides Sub Refresh()
        MyBase.Refresh()
        UpdateLabel
    End Sub

    Protected Overrides Function GetControlValueCore() As Object
        Return PropertyValue
    End Function

    Public Sub UpdateLabel
        If _mLabel IsNot Nothing Then
            If Me.Model.LookupProperty = String.Empty Then
                _mLabel.Text = Me.MemberInfo.SerializeValue(Me.CurrentObject)
            Else
                _mLabel.Text = Me.MemberInfo.MemberTypeInfo.FindMember(Me.Model.LookupProperty).SerializeValue(Me.PropertyValue)
            End If
        End If
    End Sub

    Protected Overrides Sub ReadValueCore()
        UpdateLabel

    End Sub


End Class
