Partial Class UserFilterListViewController

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListViewController_CreateFilter = New DevExpress.ExpressApp.Actions.PopupWindowShowAction(Me.components)
        Me.ListViewController_Filters = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
        Me.ListViewController_DeleteFilter = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.ListViewController_ExportFilter = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.ListViewController_ImportFilter = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.ListViewController_ShowHideMasterDetail = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'ListViewController_CreateFilter
        '
        Me.ListViewController_CreateFilter.AcceptButtonCaption = Nothing
        Me.ListViewController_CreateFilter.CancelButtonCaption = Nothing
        Me.ListViewController_CreateFilter.Caption = "Save Filter"
        Me.ListViewController_CreateFilter.Category = "View"
        Me.ListViewController_CreateFilter.ConfirmationMessage = Nothing
        Me.ListViewController_CreateFilter.Id = "ListViewController_CreateFilter"
        Me.ListViewController_CreateFilter.ImageName = "Action_Filter"
        Me.ListViewController_CreateFilter.ToolTip = Nothing
        '
        'ListViewController_Filters
        '
        Me.ListViewController_Filters.Caption = "ListViewController_Filters"
        Me.ListViewController_Filters.Category = "View"
        Me.ListViewController_Filters.ConfirmationMessage = Nothing
        Me.ListViewController_Filters.Id = "ListViewController_Filters"
        Me.ListViewController_Filters.ToolTip = "saved filters"
        '
        'ListViewController_DeleteFilter
        '
        Me.ListViewController_DeleteFilter.Caption = "Delete Filter"
        Me.ListViewController_DeleteFilter.Category = "View"
        Me.ListViewController_DeleteFilter.ConfirmationMessage = Nothing
        Me.ListViewController_DeleteFilter.Id = "ListViewController_DeleteFilter"
        Me.ListViewController_DeleteFilter.ImageName = "Action_Clear"
        Me.ListViewController_DeleteFilter.ToolTip = Nothing
        '
        'ListViewController_ExportFilter
        '
        Me.ListViewController_ExportFilter.Caption = "Export Filter"
        Me.ListViewController_ExportFilter.Category = "View"
        Me.ListViewController_ExportFilter.ConfirmationMessage = Nothing
        Me.ListViewController_ExportFilter.Id = "ListViewController_ExportFilter"
        Me.ListViewController_ExportFilter.ImageName = "Action_Export_ToXML"
        Me.ListViewController_ExportFilter.TargetObjectType = GetType(ISS.UserFilters.UserFilter)
        Me.ListViewController_ExportFilter.ToolTip = Nothing
        '
        'ListViewController_ImportFilter
        '
        Me.ListViewController_ImportFilter.Caption = "Import Filter"
        Me.ListViewController_ImportFilter.Category = "View"
        Me.ListViewController_ImportFilter.ConfirmationMessage = Nothing
        Me.ListViewController_ImportFilter.Id = "ListViewController_ImportFilter"
        Me.ListViewController_ImportFilter.ImageName = "Action_Redo"
        Me.ListViewController_ImportFilter.TargetObjectType = GetType(ISS.UserFilters.UserFilter)
        Me.ListViewController_ImportFilter.ToolTip = Nothing
        '
        'ListViewController_ShowHideMasterDetail
        '
        Me.ListViewController_ShowHideMasterDetail.Caption = "Show Master Detail"
        Me.ListViewController_ShowHideMasterDetail.Category = "View"
        Me.ListViewController_ShowHideMasterDetail.ConfirmationMessage = Nothing
        Me.ListViewController_ShowHideMasterDetail.Id = "ListViewController_ShowHideMasterDetail"
        Me.ListViewController_ShowHideMasterDetail.ImageName = "Action_Show"
        Me.ListViewController_ShowHideMasterDetail.ToolTip = Nothing
        '
        'UserFilterListViewController
        '
        Me.Actions.Add(Me.ListViewController_CreateFilter)
        Me.Actions.Add(Me.ListViewController_Filters)
        Me.Actions.Add(Me.ListViewController_DeleteFilter)
        Me.Actions.Add(Me.ListViewController_ExportFilter)
        Me.Actions.Add(Me.ListViewController_ImportFilter)
        Me.Actions.Add(Me.ListViewController_ShowHideMasterDetail)

End Sub
    Public WithEvents ListViewController_CreateFilter As DevExpress.ExpressApp.Actions.PopupWindowShowAction
    Public WithEvents ListViewController_Filters As DevExpress.ExpressApp.Actions.SingleChoiceAction
    Public WithEvents ListViewController_DeleteFilter As DevExpress.ExpressApp.Actions.SimpleAction
    Public WithEvents ListViewController_ExportFilter As DevExpress.ExpressApp.Actions.SimpleAction
    Public WithEvents ListViewController_ImportFilter As DevExpress.ExpressApp.Actions.SimpleAction
    Public WithEvents ListViewController_ShowHideMasterDetail As DevExpress.ExpressApp.Actions.SimpleAction
End Class
