Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Model.NodeGenerators

Public Class ModelDetailViewItemsNodesGeneratorUpdater
    Inherits ModelNodesGeneratorUpdater(Of ModelDetailViewItemsNodesGenerator)
    Public Overrides Sub UpdateNode(ByVal node As ModelNode)
        ' Cast the 'node' parameter to IModelViewItems 
        ' to access the Items node. 
        Dim imeEditor As IModelPropertyEditor
          Dim objNode As IModelViewItems = node
        For Each objChild In objNode
           If TypeOf objChild Is IModelPropertyEditor
                imeEditor = objChild
                If imeEditor.ModelMember IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo.FindAttribute(Of ISS.Base.Attributes.Editors.TextEditor.StringTokenizedLookupEditorAttribute) IsNot Nothing Then
                    imeEditor.PropertyEditorType = GetType(StringTokenizedLookupEditor)
                ElseIf imeEditor.ModelMember IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo.FindAttribute(Of ISS.Base.Attributes.Editors.TextEditor.ValueWithDataSourceEditorAttribute) IsNot Nothing Then
                    imeEditor.PropertyEditorType = GetType(ValueWithDataSourceEditor)
                ElseIf imeEditor.ModelMember IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo.FindAttribute(Of ISS.Base.Attributes.Editors.TextEditor.StringValueWithObjectSourceEditorAttribute) IsNot Nothing Then
                    imeEditor.PropertyEditorType = GetType(StringValueWithObjectSourceEditor)
                ElseIf imeEditor.ModelMember IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo IsNot Nothing AndAlso imeEditor.ModelMember.MemberInfo.FindAttribute(Of ISS.Base.Attributes.Editors.TextEditor.StringValueWithPropertySourceEditorAttribute) IsNot Nothing Then
                    imeEditor.PropertyEditorType = GetType(StringValueWithObjectSourceEditor)
                End If

            End If
        Next
    End Sub
End Class