Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Model

Namespace Helpers
    Public Class ModelHelper
        ' ''' <summary>
        ' ''' Iterates through the passed in parent node and returns the child node with the given display name
        ' ''' </summary>
        ' ''' <param name="NodeToSearch"></param>
        ' ''' <param name="DisplayName"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function GetDictionaryNodeFromDisplayName(ByVal NodeToSearch As DevExpress.ExpressApp.DictionaryNode, ByVal DisplayName As String) As DevExpress.ExpressApp.DictionaryNode
        '    Try
        '        For Each objSearchDictionary As DevExpress.ExpressApp.DictionaryNode In NodeToSearch.ChildNodes
        '            If objSearchDictionary.DisplayName = DisplayName Then
        '                Return objSearchDictionary
        '            End If
        '        Next
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '    Return Nothing
        'End Function
        'Public Shared Function GetDictionaryNodeFromMatchingAttribute(ByVal NodeToSearch As DevExpress.ExpressApp.DictionaryNode, ByVal Value As String, ByVal AttributeName As String) As DevExpress.ExpressApp.DictionaryNode
        '    Try
        '        For Each objSearchDictionary As DevExpress.ExpressApp.DictionaryNode In NodeToSearch.ChildNodes
        '            If GetAttributeValueFromAttributeName(objSearchDictionary.Attributes, AttributeName) = Value Then
        '                Return objSearchDictionary
        '            End If
        '        Next
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '    Return Nothing
        'End Function
        ' ''' <summary>
        ' ''' Iterates through the model dictionary and returns a child node based on the passed in path
        ' ''' </summary>
        ' ''' <param name="PathString"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function GetDictionaryPathByDisplayNames(ByVal PathString As String) As DevExpress.ExpressApp.DictionaryNode
        '    Try
        '        Dim strSplit() As String = PathString.Split("\")
        '        Dim strTemp As String = String.Empty
        '        Dim objCurrentNode As DevExpress.ExpressApp.DictionaryNode
        '        Dim objFoundNode As DevExpress.ExpressApp.DictionaryNode = Nothing
        '        Dim objCurrentDictionary As DevExpress.ExpressApp.ReadOnlyDictionaryNodeCollection = ApplicationHelper.XAFApplication.Model.RootNode.ChildNodes


        '        For Each strTemp In strSplit
        '            objFoundNode = Nothing
        '            For Each objCurrentNode In objCurrentDictionary
        '                If objCurrentNode.DisplayName = strTemp Then
        '                    objFoundNode = objCurrentNode
        '                End If
        '            Next
        '            If objFoundNode IsNot Nothing Then
        '                objCurrentDictionary = objFoundNode.ChildNodes
        '            Else
        '                Return Nothing
        '            End If
        '        Next
        '        Return objFoundNode

        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '    Return Nothing
        'End Function
        ' ''' <summary>
        ' ''' Iterates through an attribute collection and returns a value based on the attribute name
        ' ''' </summary>
        ' ''' <param name="AttributeCollection"></param>
        ' ''' <param name="AttributeName"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function GetAttributeValueFromAttributeName(ByVal AttributeCollection As DevExpress.ExpressApp.ReadOnlyAttributeCollection, ByVal AttributeName As String) As String
        '    Try
        '        For Each objSearchAttribute As DevExpress.ExpressApp.DictionaryAttribute In AttributeCollection
        '            If objSearchAttribute.Name = AttributeName Then
        '                Return objSearchAttribute.Value
        '            End If
        '        Next
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        '    Return Nothing
        'End Function
        'Public Shared Function GetBaseBOModel()
        '    Return GetDictionaryPathByDisplayNames("BOModel")
        'End Function
        ' ''' <summary>
        ' ''' Iterates through the BO Model and returns the child node based on the passed in Full Class Name
        ' ''' </summary>
        ' ''' <param name="FullClassName"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function GetBOModelItemFromBOModelClassName(ByVal FullClassName As String)
        '    Dim objNode As DevExpress.ExpressApp.DictionaryNode
        '    Dim objSearchNode As DevExpress.ExpressApp.DictionaryNode
        '    Try
        '        objNode = GetDictionaryPathByDisplayNames("BOModel")
        '        For Each objSearchNode In objNode.ChildNodes
        '            If GetAttributeValueFromAttributeName(objSearchNode.Attributes, "Name") = FullClassName Then
        '                Return objSearchNode
        '            End If
        '        Next
        '        Return Nothing
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        ''' <summary>
        ''' Iterates through the BO Model and returns a classes Image Name based on the passed in Full Class Name
        ''' </summary>
        ''' <param name="FullClassName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetBOModelImageNameFromClassName(ByVal FullClassName As String)
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(FullClassName)
            Dim mdlModelClass As DevExpress.ExpressApp.Model.IModelClass
            If dtiTypeInfo IsNot Nothing Then
                mdlModelClass = ApplicationHelper.XAFApplication.Model.BOModel.GetClass(dtiTypeInfo.Type)
                If mdlModelClass IsNot Nothing Then
                    Return mdlModelClass.ImageName
                End If
            End If
            Return String.Empty

            'Dim objChildNode As DevExpress.ExpressApp.DictionaryNode
            'Dim strImageName As String = String.Empty
            'Try
            '    objChildNode = GetBOModelItemFromBOModelClassName(FullClassName)
            '    If objChildNode IsNot Nothing Then
            '        strImageName = GetAttributeValueFromAttributeName(objChildNode.Attributes, "ImageName")
            '    End If
            '    If strImageName = String.Empty Then
            '        strImageName = "BO_Unknown"
            '    End If
            '    Return strImageName
            'Catch ex As Exception
            '    Return Nothing
            'End Try
        End Function
        ''' <summary>
        ''' Iterates through the BO Model and returns a classes Caption based on the passed in Full Class Name
        ''' </summary>
        ''' <param name="FullClassName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetBOModelCaptionFromClassName(ByVal FullClassName As String)
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(FullClassName)
            Dim mdlModelClass As DevExpress.ExpressApp.Model.IModelClass
            If dtiTypeInfo IsNot Nothing Then
                mdlModelClass = ApplicationHelper.XAFApplication.Model.BOModel.GetClass(dtiTypeInfo.Type)
                If mdlModelClass IsNot Nothing Then
                    Return mdlModelClass.Caption
                End If
            End If
            Return String.Empty
        End Function

        'Public Shared Function GetPropertyNodeFromBaseClass(ByVal FullClassName As String, ByVal PropertyName As String) As DevExpress.ExpressApp.DictionaryNode
        '    Dim objChildNode As DevExpress.ExpressApp.DictionaryNode
        '    Dim objPropertyNode As DevExpress.ExpressApp.DictionaryNode = Nothing
        '    Dim strCaption As String = String.Empty
        '    Dim strPropertySplit() As String
        '    Dim strNewClassName As String = String.Empty
        '    Try
        '        objChildNode = GetBOModelItemFromBOModelClassName(FullClassName)
        '        If objChildNode IsNot Nothing Then
        '            If PropertyName.Contains(".") Then
        '                strPropertySplit = PropertyName.Split(".")
        '                For intLoop As Integer = 0 To strPropertySplit.Length - 1
        '                    If intLoop = 0 Then
        '                        objPropertyNode = GetDictionaryNodeFromDisplayName(objChildNode, strPropertySplit(intLoop))
        '                        strNewClassName = GetAttributeValueFromAttributeName(objPropertyNode.Attributes, "Type")
        '                    Else
        '                        objChildNode = GetBOModelItemFromBOModelClassName(strNewClassName)
        '                        objPropertyNode = GetDictionaryNodeFromDisplayName(objChildNode, strPropertySplit(intLoop))
        '                        strNewClassName = GetAttributeValueFromAttributeName(objChildNode.Attributes, "Type")
        '                    End If
        '                Next
        '            Else
        '                objPropertyNode = GetDictionaryNodeFromDisplayName(objChildNode, PropertyName)
        '            End If
        '        End If
        '        Return objPropertyNode
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        'Public Shared Function GetBaseNodeFromBaseClassProperty(ByVal FullClassName As String, ByVal PropertyName As String) As DevExpress.ExpressApp.DictionaryNode
        '    Dim objChildNode As DevExpress.ExpressApp.DictionaryNode
        '    Dim objPropertyNode As DevExpress.ExpressApp.DictionaryNode = Nothing
        '    Dim strCaption As String = String.Empty
        '    Dim strNewClassName As String = String.Empty
        '    Dim strType As String = ""
        '    Try
        '        objChildNode = GetPropertyNodeFromBaseClass(FullClassName, PropertyName)
        '        If GetAttributeValueFromAttributeName(objChildNode.Attributes, "CollectionElementType") > String.Empty Then
        '            strType = GetAttributeValueFromAttributeName(objChildNode.Attributes, "CollectionElementType")
        '        Else
        '            strType = GetAttributeValueFromAttributeName(objChildNode.Attributes, "Type")
        '        End If
        '        objPropertyNode = GetDictionaryNodeFromMatchingAttribute(GetBaseBOModel, strType, "Name")
        '        Return objPropertyNode
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        'Public Shared Function GetImageNameFromBaseClassProperty(ByVal FullClassName As String, ByVal PropertyName As String) As String
        '    Dim objChildNode As DevExpress.ExpressApp.DictionaryNode
        '    Dim objPropertyNode As DevExpress.ExpressApp.DictionaryNode = Nothing
        '    Dim strCaption As String = String.Empty
        '    Dim strNewClassName As String = String.Empty
        '    Dim strType As String = ""
        '    Try
        '        objChildNode = GetBaseNodeFromBaseClassProperty(FullClassName, PropertyName)
        '        Return GetAttributeValueFromAttributeName(objChildNode.Attributes, "ImageName")
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        'Public Shared Function GetAttributeValueFromBaseClassProperty(ByVal FullClassName As String, ByVal PropertyName As String, ByVal AttributeName As String) As String
        '    Dim objChildNode As DevExpress.ExpressApp.DictionaryNode
        '    Dim objPropertyNode As DevExpress.ExpressApp.DictionaryNode = Nothing
        '    Dim strCaption As String = String.Empty
        '    Dim strNewClassName As String = String.Empty
        '    Dim strType As String = ""
        '    Try
        '        objChildNode = GetBaseNodeFromBaseClassProperty(FullClassName, PropertyName)
        '        Return GetAttributeValueFromAttributeName(objChildNode.Attributes, AttributeName)
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        ''' <summary>
        ''' Returns the current view collection
        ''' </summary>
        ''' <param name="ViewId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Public Shared Function GetViewItems(ByVal ViewId As String) As DevExpress.ExpressApp.DictionaryNode
        '    Try
        '        Return GetDictionaryPathByDisplayNames("Views\" + ViewId + "\Items")
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        ''' <summary>
        ''' Iterates through the view colleciton and returns back a value which matches the view id
        ''' </summary>
        ''' <param name="ItemID"></param>
        ''' <param name="ViewID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Public Shared Function GetViewItemFromViewID(ByVal ItemID As String, ByVal ViewID As String)
        '    Try
        '        Return GetDictionaryPathByDisplayNames("Views\" + ViewID + "\Items\" + ItemID)
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
        Public Shared Function GetCaptionFromView(ByVal ViewID As String)
            Dim imvIModelView As IModelView = ApplicationHelper.XAFApplication.Model.Views.GetNode(ViewID)
            If imvIModelView IsNot Nothing Then
                Return imvIModelView.Caption
            End If
            Return String.Empty
            'Dim objDictionary As DevExpress.ExpressApp.DictionaryNode
            'Try
            '    objDictionary = GetDictionaryPathByDisplayNames("Views\" + ViewID)
            '    Return GetAttributeValueFromAttributeName(objDictionary.Attributes, "Caption")
            'Catch ex As Exception
            '    Return Nothing
            'End Try
        End Function
        ' ''' <summary>
        ' ''' Returns a view node's view id
        ' ''' </summary>
        ' ''' <param name="ItemID"></param>
        ' ''' <param name="ParentViewID"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Shared Function GetViewIDFromViewItem(ByVal ItemID As String, ByVal ParentViewID As String)
        '    Dim imvIModelView As IModelView = ApplicationHelper.XAFApplication.Model.Views.GetNode(Of IModelView)(ParentViewID)
        '    Dim imnIModelNode As IModelNode
        '    If imvIModelView IsNot Nothing Then

        '        Return imvIModelView.Caption
        '        imnIModelNode = imvIModelView.GetNode(Of IModelNode)(ItemID)
        '        imnIModelNode()
        '    End If
        '    Return String.Empty
        'End Function
        ''' <summary>
        ''' Check's if a child view is set to be an icon
        ''' </summary>
        ''' <param name="ViewItemID"></param>
        ''' <param name="ItemCaption"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsViewItemAnIcon(ByVal ViewItemID As String, ByVal ItemCaption As String)
            Try
                If ItemCaption <> "Icon" Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Return Nothing
            End Try
            Return False
        End Function

    End Class
End Namespace


