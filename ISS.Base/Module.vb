Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.Persistent.Base
Imports ISS.Base.Attributes

Public NotInheritable Class [ISSBaseModule]
    Inherits ModuleBase
    Implements IModelNodeUpdater(Of IModelBOModelClassMembers)

    Public Shared Property DisableObjectRelationshipController As Boolean

    Public Sub New()

        InitializeComponent()
        CustomTransactionalDoubleFunction.Register()

    End Sub

    Public Overrides Sub AddModelNodeUpdaters(updaterRegistrator As DevExpress.ExpressApp.Model.Core.IModelNodeUpdaterRegistrator)
        MyBase.AddModelNodeUpdaters(updaterRegistrator)
        updaterRegistrator.AddUpdater(Me)
    End Sub

    Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
        MyBase.ExtendModelInterfaces(extenders)
        extenders.Add(Of IModelViewItem, IDetailViewItem)()
        extenders.Add(Of IModelMember, IModelBOModelItem)()
        extenders.Add(Of IModelListView, IModelListViewExtension)()
        extenders.Add(Of IModelClass, IBOModel)()
        extenders.Add(Of IModelApplication, IApplicationExtension)()
    End Sub

    'Public Overrides Function GetSchema() As DevExpress.ExpressApp.Schema
    '    Dim schema As Schema
    '    Dim dictionary As DictionaryXmlReader = New DictionaryXmlReader
    '    Dim dictionaryNode As DictionaryNode
    '    Dim strXML As String = "<Element Name=""Application"">" & _
    '                                "<Element Name=""Views"">" & _
    '                                    "<Element Name=""DetailView"">" & _
    '                                        "<Element Name=""Items"">" & _
    '                                            "<Element Name=""ActionLinkDetailViewItem"" > " & _
    '                                                "<Attribute Name=""ActionId"" Required=""True"" RefNodeName=""/Application/ActionDesign/Actions/Action"" IsNewNode=""True""/>" & _
    '                                            "</Element>" & _
    '                                        "</Element>" & _
    '                                    "</Element>" & _
    '                                "</Element>" & _
    '                            "</Element>"


    '    dictionaryNode = dictionary.ReadFromString(strXML)
    '    schema = New Schema(dictionaryNode)
    '    Return schema
    'End Function

    'Public Overrides Sub UpdateModel(ByVal model As DevExpress.ExpressApp.Dictionary)
    '    MyBase.UpdateModel(model)

    '    For Each viewNode As DictionaryNode In model.RootNode.FindChildNode("Views").ChildNodes
    '        If String.Compare(viewNode.Name, "DetailView", False) = 0 Then
    '            If viewNode.FindChildNode("Layout") IsNot Nothing Then
    '                ScanGroup(viewNode.FindChildNode("Layout"))
    '            End If
    '        End If
    '    Next
    'End Sub

    'Private Sub ScanGroup(ByRef LayoutGroup As DictionaryNode)
    '    For Each viewLayoutNode As DictionaryNode In LayoutGroup.ChildNodes
    '        If String.Compare(viewLayoutNode.Name, "LayoutGroup", False) = 0 Then
    '            AddLayoutGroupAttributesToGroup(viewLayoutNode)
    '            ScanGroup(viewLayoutNode)
    '        ElseIf String.Compare(viewLayoutNode.Name, "TabbedGroup", False) = 0 Then
    '            ScanGroup(viewLayoutNode)
    '        End If
    '    Next
    'End Sub

    'Private Sub AddLayoutGroupAttributesToGroup(ByRef LayoutGroup As DictionaryNode)
    '    Dim objDictionaryAttribute As DictionaryAttribute
    '    objDictionaryAttribute = LayoutGroup.FindAttribut("TextSizingMode")
    '    If objDictionaryAttribute Is Nothing Then
    '        LayoutGroup.AddAttribute("TextSizingMode", "Align")
    '        Dim vwwView As View
    '    End If
    'End Sub

    Public Overrides Sub Setup(ByVal application As DevExpress.ExpressApp.XafApplication)

        MyBase.Setup(application)
    End Sub

    Public Overrides Sub CustomizeTypesInfo(typesInfo As DevExpress.ExpressApp.DC.ITypesInfo)
        MyBase.CustomizeTypesInfo(typesInfo)

        For Each typInfo As DevExpress.ExpressApp.DC.TypeInfo In typesInfo.PersistentTypes
            For Each mmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo In typInfo.Members
                If mmiMemberInfo.FindAttribute(Of VisibleInReportsOnlyAttribute)() IsNot Nothing Then
                    mmiMemberInfo.AddAttribute(New VisibleInDetailViewAttribute(False))
                    mmiMemberInfo.AddAttribute(New VisibleInListViewAttribute(False))
                End If
            Next
            
        Next

    End Sub

    Public Sub UpdateNode(node As DevExpress.ExpressApp.Model.IModelBOModelClassMembers, application As DevExpress.ExpressApp.Model.IModelApplication) Implements DevExpress.ExpressApp.Model.Core.IModelNodeUpdater(Of DevExpress.ExpressApp.Model.IModelBOModelClassMembers).UpdateNode

    End Sub
End Class
