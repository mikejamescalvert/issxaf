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

<PropertyEditor(GetType(Object), EditorAliases.LookupPropertyEditor, False)>
Public Class LookupLabelEditor
    Inherits PropertyEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub



    Protected Overrides Function CreateControlCore() As Object
        Dim xlbLabelEditor As New DevExpress.XtraEditors.LabelControl
        xlbLabelEditor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        xlbLabelEditor.Text = Me.CurrentObject
        WinLayoutHelper.SetupDevExpressControlWithDetailViewItem(xlbLabelEditor, Me.Model)
        Return xlbLabelEditor
    End Function


    Protected Overrides Function GetControlValueCore() As Object
        Return CType(Control, DevExpress.XtraEditors.LabelControl).Text
    End Function

    Protected Overrides Sub ReadValueCore()
        CType(Control, DevExpress.XtraEditors.LabelControl).Text = Me.PropertyValue
    End Sub

End Class
