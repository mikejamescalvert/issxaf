Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Model

<PropertyEditor(GetType(Object), False)> _
Public Class RadioButtonEditor
    Inherits DXPropertyEditor

    Private _mEditorControlInstance As RadioGroupControl
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub



    Protected Overrides Function CreateControlCore() As Object
        _mEditorControlInstance = New RadioGroupControl
        Return _mEditorControlInstance

    End Function

    Protected Overrides Sub SetupRepositoryItem(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        Dim oRepositoryRadioControlGroup As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup = item
        Dim atrColumnOverride As ISS.Base.Attributes.RadioEditor.ColumnOverrideAttribute = Me.MemberInfo.FindAttribute(Of ISS.Base.Attributes.RadioEditor.ColumnOverrideAttribute)()
        CreateRepositoryItemDisplayCollection(oRepositoryRadioControlGroup)
        If atrColumnOverride IsNot Nothing Then
            oRepositoryRadioControlGroup.Columns = atrColumnOverride.NumberOfColumns
        Else
            oRepositoryRadioControlGroup.Columns = 1
        End If
    End Sub

    Public Sub CreateRepositoryItemDisplayCollection(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup)
        Dim iList As IList
        Dim strDisplayValue As String = String.Empty
        Dim oDisplayObject As Object
        Dim atrDataSourceProperty As DevExpress.Persistent.Base.DataSourcePropertyAttribute = Me.MemberInfo.FindAttribute(Of DevExpress.Persistent.Base.DataSourcePropertyAttribute)()
        item.Items.Clear()

        If atrDataSourceProperty IsNot Nothing Then
            iList = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(atrDataSourceProperty.DataSourceProperty, Me.CurrentObject)
        Else
            If Me.MemberInfo.MemberType.BaseType Is GetType([Enum]) Then
                For Each oValue As Object In [Enum].GetValues(Me.MemberInfo.MemberType)
                    item.Items.Add(New DevExpress.XtraEditors.Controls.RadioGroupItem(oValue, [Enum].GetName(Me.MemberInfo.MemberType, oValue)))
                Next
            Else
                iList = Me.View.ObjectSpace.CreateCollection(Me.MemberInfo.MemberType)
                For Each oItem As Object In iList
                    strDisplayValue = String.Empty
                    If Me.MemberInfo.MemberTypeInfo.DefaultMember IsNot Nothing Then
                        oDisplayObject = Me.MemberInfo.MemberTypeInfo.DefaultMember.GetValue(oItem)
                        If oDisplayObject IsNot Nothing Then
                            strDisplayValue = oDisplayObject.ToString
                        End If
                    End If
                    If strDisplayValue = String.Empty Then
                        strDisplayValue = oItem.ToString
                    End If
                    item.Items.Add(New DevExpress.XtraEditors.Controls.RadioGroupItem(oItem, strDisplayValue))
                Next
            End If
        End If



    End Sub

    Protected Overrides Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem
        Return New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    End Function

End Class

Public Class RadioGroupControl
    Inherits DevExpress.XtraEditors.RadioGroup

End Class