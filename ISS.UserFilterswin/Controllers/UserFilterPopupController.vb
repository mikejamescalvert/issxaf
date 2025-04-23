Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.Data.Filtering

''' <summary>
''' used exclusively as the controller for the UserFilter_DetailView displayed as a Popup
''' </summary>
''' <remarks></remarks>
Public Class UserFilterPopupController
    Inherits SystemModule.DialogController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub

    Protected Overrides Sub Accept(ByVal args As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs)
        MyBase.Accept(args)

        Dim xpoUserFilter As UserFilter = Me.Frame.View.CurrentObject
        Dim uciNewColumnInfo As UserFilterColumnInfo
        Dim xpoExistingUserFilter As UserFilter = CType(Me.Frame.View.ObjectSpace, DevExpress.ExpressApp.Xpo.XPObjectSpace).Session.FindObject(GetType(UserFilter), New GroupOperator(GroupOperatorType.And, New CriteriaOperator() {New BinaryOperator("Name", xpoUserFilter.Name, BinaryOperatorType.Equal), New BinaryOperator("CreatedByUser", xpoUserFilter.CreatedByUser, BinaryOperatorType.Equal)}))

        If String.IsNullOrEmpty(xpoUserFilter.Name) Then
            Throw New UserFriendlyException("Could not save filter. A name is requried to save the filter. Please enter a name and try again.")
        End If

        If xpoExistingUserFilter IsNot Nothing Then 'if there is already an existing UserFilter in database then modify existing filter and delete new UserFilter
            xpoExistingUserFilter.Description = xpoUserFilter.Description
            xpoExistingUserFilter.Criterion = xpoUserFilter.Criterion
            xpoExistingUserFilter.IsPublic = xpoUserFilter.IsPublic
            xpoExistingUserFilter.ShowMasterDetailView = xpoUserFilter.ShowMasterDetailView
            xpoExistingUserFilter.ShowGroupPanel = xpoUserFilter.ShowGroupPanel
            xpoExistingUserFilter.SpecificToView = xpoUserFilter.SpecificToView
            xpoExistingUserFilter.ViewID = xpoUserFilter.ViewID
            While xpoExistingUserFilter.UserFilterColumnInfos.Count > 0
                xpoExistingUserFilter.UserFilterColumnInfos(0).Delete()

            End While
            For Each oOldColumnInfo As UserFilterColumnInfo In xpoUserFilter.UserFilterColumnInfos
                uciNewColumnInfo = New UserFilterColumnInfo(xpoExistingUserFilter.Session)
                uciNewColumnInfo.Caption = oOldColumnInfo.Caption
                uciNewColumnInfo.FieldName = oOldColumnInfo.FieldName
                uciNewColumnInfo.GroupIndex = oOldColumnInfo.GroupIndex
                uciNewColumnInfo.Name = oOldColumnInfo.Name
                uciNewColumnInfo.OptionsColumnAllowEdit = oOldColumnInfo.OptionsColumnAllowEdit
                uciNewColumnInfo.SortIndex = oOldColumnInfo.SortIndex
                uciNewColumnInfo.SortOrder = oOldColumnInfo.SortOrder
                uciNewColumnInfo.ToolTip = oOldColumnInfo.ToolTip
                uciNewColumnInfo.VisibleIndex = oOldColumnInfo.VisibleIndex
                uciNewColumnInfo.Width = oOldColumnInfo.Width
                xpoExistingUserFilter.UserFilterColumnInfos.Add(uciNewColumnInfo)
            Next

            Me.Frame.View.CurrentObject = xpoExistingUserFilter 'this indicates xpoExistingUserFilter as ListViewController_Filters.SelectedItem

            xpoUserFilter.Delete()
            xpoExistingUserFilter.Save()

        End If

        Me.Frame.View.ObjectSpace.CommitChanges()

    End Sub

End Class
