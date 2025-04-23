Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors
Imports System.Drawing
Imports DevExpress.ExpressApp.Model

<PropertyEditor(GetType(ObjectState), True)> _
Public Class WinGridImageStatusEditor
    Inherits ObjectPropertyEditor



    'Protected Overrides Function CreateControlCore() As Object
    '    Dim idcImageDisplayControl As New ImageDisplayControl
    '    Me.ControlBindingProperty = "ImageGridStatus"
    '    Return idcImageDisplayControl
    'End Function   

    Protected Overrides Sub SetRepositoryItemReadOnly(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem, ByVal [readOnly] As Boolean)
        MyBase.SetRepositoryItemReadOnly(item, [readOnly])
        _mLookupRepositoryItem = item
        SetupImages()

    End Sub
    Protected Overrides Sub SetupRepositoryItem(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        _mLookupRepositoryItem = item
        AddHandler _mLookupRepositoryItem.ButtonClick, AddressOf ButtonClicked
        SetupImages()

    End Sub

    Private Sub ButtonClicked(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        CType(e.Button.Tag, ObjectState.CellClickAction).GridImageStatus.OnActionExecuted(e.Button.Tag)
    End Sub

    Private _mLookupRepositoryItem As RepositoryItemObjectEdit
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


    Private Sub SetupImages()
        If _mLookupRepositoryItem Is Nothing Then
            Return
        End If
        _mLookupRepositoryItem.Buttons.Clear()
        If Me.PropertyValue IsNot Nothing Then
            For Each oState As ObjectStateInstance In CType(PropertyValue, ObjectState).ObjectStateInstances
                AddImage(PropertyValue, oState, _mLookupRepositoryItem)
            Next
        End If
    End Sub

    Protected Overrides Sub OnControlValueChanged()
        MyBase.OnControlValueChanged()
        SetupImages()
    End Sub

    Protected Overrides Sub ReadValueCore()
        MyBase.ReadValueCore()
        SetupImages()
    End Sub

    Protected Overrides Sub WriteValueCore()
        MyBase.WriteValueCore()
        SetupImages()
    End Sub



    Public Sub AddImage(ByVal CurrentObjectState As ObjectState, ByVal CurrentObjectStateInstance As ObjectStateInstance, ByVal RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit)
        Dim dcbButton As New DevExpress.XtraEditors.Controls.EditorButton
        dcbButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        dcbButton.Appearance.BackColor = Color.Transparent
        dcbButton.Appearance.BackColor2 = Color.Transparent
        dcbButton.Appearance.BorderColor = Color.Transparent
        dcbButton.Appearance.Options.UseBackColor = True
        dcbButton.Appearance.Options.UseBorderColor = True
        dcbButton.Appearance.Options.UseImage = True
        dcbButton.Image = CurrentObjectStateInstance.StateImage
        dcbButton.Tag = New ObjectState.CellClickAction(CurrentObjectStateInstance, Me.PropertyName, Me.CurrentObject, CurrentObjectState)
        dcbButton.ToolTip = CurrentObjectStateInstance.ToolTip
        dcbButton.IsLeft = True
        RepositoryItem.Buttons.Add(dcbButton)
        '        Me.Properties.Buttons.Add()
    End Sub



    'Protected Overrides Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem
    '    Dim lbeButtonEdit As New ImageDisplayRepositoryItem
    '    Return lbeButtonEdit
    'End Function

End Class
