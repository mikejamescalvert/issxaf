Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model

<PropertyEditor(GetType(Decimal), False)> _
Public Class DecimalProgressPropertyEditor
    Inherits FloatPropertyEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)
        
    End Sub


    Protected Overrides Function CreateControlCore() As Object
        Return New DevExpress.XtraEditors.ProgressBarControl
    End Function

    Protected Overrides Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem
        Return New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    End Function

    'Protected Overrides Function GetControlValueCore() As Object
    '    Return MyBase.GetControlValueCore()
    'End Function

    'Protected Overrides Sub ReadValueCore()
    '    MyBase.ReadValueCore()
    'End Sub

    'Protected Overrides Sub WriteValueCore()

    '    MyBase.WriteValueCore()
    'End Sub

    Protected Overrides Sub SetupRepositoryItem(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
        'MyBase.SetupRepositoryItem(item)
        Dim dpaAttribute As ISS.Base.Attributes.Editors.DecimalProgressPropertyEditor.DecimalProgressPropertyEditorAttribute = MemberInfo.FindAttribute(Of ISS.Base.Attributes.Editors.DecimalProgressPropertyEditor.DecimalProgressPropertyEditorAttribute)()
        If dpaAttribute IsNot Nothing Then
            CType(item, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Maximum = dpaAttribute.MaximumValue
            CType(item, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Step = dpaAttribute.IntervalStep
        Else
            CType(item, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Maximum = 100
            CType(item, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Step = 1
        End If
        CType(item, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).PercentView = False
        CType(item, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        CType(item, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar).Minimum = 0
    End Sub

End Class
