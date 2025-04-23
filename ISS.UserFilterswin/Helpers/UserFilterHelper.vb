Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win.Editors

Namespace Helpers
    Public Class UserFilterHelper

        Public Shared Sub ExportToFile(ByRef UserFilter As UserFilter, ByRef FileName As String)
            Dim objXmlUserFilter As New XmlUserFilter
            Dim objXmlUserFilterColumnInfo As XmlUserFilterColumnInfo
            Dim xszSerializer As System.Xml.Serialization.XmlSerializer
            Dim ifsFileStream As New IO.FileStream(FileName, IO.FileMode.Create)
            With objXmlUserFilter
                .CreatedByUserID = UserFilter.CreatedByUserID
                .Criterion = UserFilter.Criterion
                .Description = UserFilter.Description
                .IsPublic = UserFilter.IsPublic
                .Layout = UserFilter.Layout
                .Name = UserFilter.Name
                .SavedObjectTypeName = UserFilter.SavedObjectTypeName
                .ShowGroupPanel = UserFilter.ShowGroupPanel
            End With

            For Each xpoColumn In UserFilter.UserFilterColumnInfos
                objXmlUserFilterColumnInfo = New XmlUserFilterColumnInfo
                With objXmlUserFilterColumnInfo
                    .Caption = xpoColumn.Caption
                    .DisplayFormat = xpoColumn.DisplayFormat
                    .FieldName = xpoColumn.FieldName
                    .GroupIndex = xpoColumn.GroupIndex
                    .Name = xpoColumn.Name
                    .OptionsColumnAllowEdit = xpoColumn.OptionsColumnAllowEdit
                    .SortIndex = xpoColumn.SortIndex
                    .SortOrder = xpoColumn.SortOrder
                    .ToolTip = xpoColumn.ToolTip
                    .VisibleIndex = xpoColumn.VisibleIndex
                    .Width = xpoColumn.Width
                End With
                objXmlUserFilter.ColumnInfos.Add(objXmlUserFilterColumnInfo)
            Next
            xszSerializer = New System.Xml.Serialization.XmlSerializer(GetType(XmlUserFilter))
            xszSerializer.Serialize(ifsFileStream, objXmlUserFilter)
            ifsFileStream.Flush()
            ifsFileStream.Dispose()
            ifsFileStream = Nothing
        End Sub

        Public Shared Sub ImportFromFile(ByRef FileName As String, ByRef ObjectSpace As Xpo.XPObjectSpace)
            Dim objXmlUserFilter As XmlUserFilter
            Dim ifsFileStream As New IO.FileStream(FileName, IO.FileMode.OpenOrCreate)
            Dim xszSerializer As System.Xml.Serialization.XmlSerializer
            Dim xpoUserFilter As UserFilter
            Dim xpoUserFilterColumnInfo As UserFilterColumnInfo
            xszSerializer = New System.Xml.Serialization.XmlSerializer(GetType(XmlUserFilter))
            objXmlUserFilter = xszSerializer.Deserialize(ifsFileStream)
            If objXmlUserFilter IsNot Nothing Then
                xpoUserFilter = ObjectSpace.CreateObject(Of UserFilter)()
                With xpoUserFilter
                    .CreatedByUserID = objXmlUserFilter.CreatedByUserID
                    .Criterion = objXmlUserFilter.Criterion
                    .Description = objXmlUserFilter.Description
                    .IsPublic = objXmlUserFilter.IsPublic
                    .Layout = objXmlUserFilter.Layout
                    .Name = objXmlUserFilter.Name
                    .SetSavedObjectTypeName(objXmlUserFilter.SavedObjectTypeName)
                    .ShowGroupPanel = objXmlUserFilter.ShowGroupPanel
                End With

                For Each objXmlUserFilterColumnInfo In objXmlUserFilter.ColumnInfos
                    xpoUserFilterColumnInfo = ObjectSpace.CreateObject(Of UserFilterColumnInfo)()
                    With xpoUserFilterColumnInfo
                        .Caption = objXmlUserFilterColumnInfo.Caption
                        .DisplayFormat = objXmlUserFilterColumnInfo.DisplayFormat
                        .FieldName = objXmlUserFilterColumnInfo.FieldName
                        .GroupIndex = objXmlUserFilterColumnInfo.GroupIndex
                        .Name = objXmlUserFilterColumnInfo.Name
                        .OptionsColumnAllowEdit = objXmlUserFilterColumnInfo.OptionsColumnAllowEdit
                        .SortIndex = objXmlUserFilterColumnInfo.SortIndex
                        .SortOrder = objXmlUserFilterColumnInfo.SortOrder
                        .ToolTip = objXmlUserFilterColumnInfo.ToolTip
                        .VisibleIndex = objXmlUserFilterColumnInfo.VisibleIndex
                        .Width = objXmlUserFilterColumnInfo.Width
                    End With
                    xpoUserFilter.UserFilterColumnInfos.Add(xpoUserFilterColumnInfo)
                Next
            End If
        End Sub

        Public Shared Sub UpdateUserFilterWithColumnInfo(ByRef XtraGridEditor As DevExpress.ExpressApp.Win.Editors.GridListEditor, ByRef UserFilterObject As UserFilter)
            Dim ufcColumnInfo As UserFilterColumnInfo
            While UserFilterObject.UserFilterColumnInfos.Count > 0
                UserFilterObject.UserFilterColumnInfos(0).Delete()
            End While
            UserFilterObject.ShowGroupPanel = XtraGridEditor.GridView.OptionsView.ShowGroupPanel
            For Each dxgDevExpressColumn In XtraGridEditor.Columns
                ufcColumnInfo = New UserFilterColumnInfo(UserFilterObject.Session)
                With ufcColumnInfo
                    .Caption = dxgDevExpressColumn.Caption
                    .DisplayFormat = dxgDevExpressColumn.DisplayFormat
                    .FieldName = dxgDevExpressColumn.PropertyName
                    .GroupIndex = dxgDevExpressColumn.GroupIndex
                    .Name = dxgDevExpressColumn.PropertyName
                    .SortIndex = dxgDevExpressColumn.SortIndex
                    .SortOrder = dxgDevExpressColumn.SortOrder
                    .ToolTip = dxgDevExpressColumn.ToolTip
                    .VisibleIndex = dxgDevExpressColumn.VisibleIndex
                    .Width = dxgDevExpressColumn.Width
                End With
                UserFilterObject.UserFilterColumnInfos.Add(ufcColumnInfo)
            Next

        End Sub

        Private Shared Sub ResetView(ByRef Frame As Frame, ByRef View As View, ByRef Application As XafApplication)
            Dim obsObjectSpace As Xpo.XPObjectSpace = Application.CreateObjectSpace
            Dim pcsPropertySource As PropertyCollectionSource
            If View.IsRoot = False Then
                pcsPropertySource = CType(View, ListView).CollectionSource
                Frame.SetView(Application.CreateListView(View.Id,
                    Application.CreatePropertyCollectionSource(
                        obsObjectSpace, pcsPropertySource.MasterObjectType,
                        obsObjectSpace.GetObject(pcsPropertySource.MasterObject),
                        pcsPropertySource.MemberInfo, View.Id, pcsPropertySource.IsServerMode,
                        pcsPropertySource.Mode), View.IsRoot), True, Frame)
            Else
                Frame.SetView(Application.ProcessShortcut(Frame.View.CreateShortcut()), True, Frame)
            End If
        End Sub

        Public Shared Sub UpdateGridFromUserFilter(ByRef Editor As GridListEditor, ByRef Frame As Frame, ByRef Application As XafApplication, ByVal ListView As ListView, ByRef UserFilterObject As UserFilter)
            Dim ufcColumnInfo As UserFilterColumnInfo
            Dim clmColumnWrapper As ColumnWrapper
            Dim mdcModelColumn As IModelColumn
            Dim blnFoundColumn As Boolean
            Dim strFieldName As String
            Editor.Grid.BeginUpdate()

            UserFilterObject.UserFilterColumnInfos.Sorting.Add(New DevExpress.Xpo.SortProperty("VisibleIndex", DevExpress.Xpo.DB.SortingDirection.Ascending))
            For Each ufcColumnInfo In UserFilterObject.UserFilterColumnInfos
                strFieldName = ufcColumnInfo.FieldName.Replace("!", "")
                blnFoundColumn = False
                For Each mdcModelColumn In ListView.Model.Columns
                    If mdcModelColumn.PropertyName = strFieldName Then
                        blnFoundColumn = True
                    End If
                Next
                If blnFoundColumn = False AndAlso ListView.Model.ModelClass.FindMember(strFieldName) IsNot Nothing Then

                    mdcModelColumn = ListView.Model.Columns.AddNode(Of IModelColumn)(strFieldName)
                    mdcModelColumn.AllowEdit = ufcColumnInfo.OptionsColumnAllowEdit
                    mdcModelColumn.Caption = ufcColumnInfo.Caption
                    mdcModelColumn.DisplayFormat = ufcColumnInfo.DisplayFormat
                    mdcModelColumn.Index = ufcColumnInfo.VisibleIndex
                    mdcModelColumn.PropertyName = strFieldName
                    mdcModelColumn.SortIndex = ufcColumnInfo.SortIndex
                    mdcModelColumn.SortOrder = ufcColumnInfo.SortOrder
                    mdcModelColumn.Width = ufcColumnInfo.Width
                    If ufcColumnInfo.VisibleIndex > -1 Then
                        If ufcColumnInfo.GroupIndex > -1 Then
                            mdcModelColumn.GroupIndex = ufcColumnInfo.GroupIndex
                        End If
                        If ufcColumnInfo.DisplayFormat > String.Empty Then
                            mdcModelColumn.DisplayFormat = ufcColumnInfo.DisplayFormat
                        End If
                    End If
                    Editor.AddColumn(mdcModelColumn)
                End If

            Next

            For Each clm In Editor.Columns
                blnFoundColumn = False

                For Each ufcColumnInfo In UserFilterObject.UserFilterColumnInfos
                    strFieldName = ufcColumnInfo.FieldName.Replace("!", "")
                    If clm.PropertyName = strFieldName Then
                        blnFoundColumn = True
                        clm.Width = ufcColumnInfo.Width
                        Exit For
                    End If
                Next
            Next

            For Each clm In Editor.Columns
                blnFoundColumn = False

                For Each ufcColumnInfo In UserFilterObject.UserFilterColumnInfos
                    strFieldName = ufcColumnInfo.FieldName.Replace("!", "")
                    If clm.PropertyName = strFieldName Then
                        blnFoundColumn = True

                        clm.Caption = ufcColumnInfo.Caption
                        clm.DisplayFormat = ufcColumnInfo.DisplayFormat
                        clm.VisibleIndex = ufcColumnInfo.VisibleIndex
                        clm.SortIndex = ufcColumnInfo.SortIndex
                        clm.SortOrder = ufcColumnInfo.SortOrder
                        clm.Width = ufcColumnInfo.Width
                        If ufcColumnInfo.VisibleIndex > -1 Then
                            If ufcColumnInfo.GroupIndex > -1 Then
                                clm.GroupIndex = ufcColumnInfo.GroupIndex
                            End If
                            If ufcColumnInfo.DisplayFormat > String.Empty Then
                                clm.DisplayFormat = ufcColumnInfo.DisplayFormat
                            End If
                        End If
                        Exit For
                    End If
                Next
                If blnFoundColumn = False Then
                    clm.VisibleIndex = -1
                End If
            Next

            Editor.Grid.EndUpdate()
        End Sub


    End Class
End Namespace




