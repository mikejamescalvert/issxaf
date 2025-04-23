Imports Microsoft.VisualBasic
Imports System

Partial Public Class ISSWindowsFormsApplication
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing


#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
        Me.module3 = New ISS.[Module].ISSModule()
        Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
        Me.module7 = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
        Me.module8 = New ISS.Base.ISSBaseModule()
        Me.module13 = New ISS.Base.Win.UIModifications.UIModificationsModule()
        Me.module14 = New ISS.DiskFileAttachments.DiskFileAttachmentsModule()
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.FileAttachmentsWindowsFormsModule1 = New DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule()
        Me.ReportsWindowsFormsModule1 = New DevExpress.ExpressApp.Reports.Win.ReportsWindowsFormsModule()
        Me.PivotChartWindowsFormsModule1 = New DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule()
        Me.PivotChartModuleBase1 = New DevExpress.ExpressApp.PivotChart.PivotChartModuleBase()
        Me.SchedulerModuleBase1 = New DevExpress.ExpressApp.Scheduler.SchedulerModuleBase()
        Me.MasterProviderModule1 = New MasterProvider.[Module].MasterProviderModule()
        Me.HtmlPropertyEditorWindowsFormsModule1 = New DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule()
        Me.ConditionalAppearanceModule1 = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.module9 = New ISS.Base.Win.ISSBaseWinModule()
        Me.module4 = New ISS.[Module].Win.ISSWindowsFormsModule()
        Me.module10 = New ISS.UserFilters.UserFiltersModule()
        Me.module11 = New ISS.UserFilters.Win.UserFiltersWinModule()
        Me.module15 = New ISS.DiskFileAttachments.Win.WinModule()
        Me.module17 = New ISS.Notifications.ISSNotificationsModule()
        Me.module19 = New ISS.Notifications.Win.ISSNotificationsWinModule()
        Me.module18 = New ISS.PostedAlias.PostedAliasModule()
        Me.spellCheck = New ISS.SpellChecker.V2.SpellCheckerV2Module()
        Me.spellCheckWin = New ISS.SpellChecker.V2.Win.SpellCheckerV2WinModule()
        Me.issAttachments = New ISS.Attachments.AttachmentsModule()
        Me.issCustomizations = New ISS.BusinessObjectCustomizations.[Module].BusinessObjectCustomizationsModule()
        Me.MemoryModule = New ISS.[Module].Memory.MemoryModule()
        Me.AuthenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
        Me.UserFiltersModule1 = New ISS.UserFilters.UserFiltersModule()
        Me.SecurityStrategyComplex1 = New DevExpress.ExpressApp.Security.SecurityStrategyComplex()
        Me.ViewVariantsModule1 = New DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule()
        Me.IssBaseModule1 = New ISS.Base.ISSBaseModule()
        Me.MasterProviderModule2 = New MasterProvider.[Module].MasterProviderModule()
        Me.SchedulerWindowsFormsModule1 = New DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule()
        Me.WorkflowModule1 = New ISS.Workflow.WorkflowModule()
        Me.ReportsModule2 = New DevExpress.ExpressApp.Reports.ReportsModule()
        Me.RecurrenceModule1 = New ISS.Recurrence.RecurrenceModule()
        Me.masterProviderCompanySelectorModule = New MasterProvider.CompanySelector.[Module].CompanySelectorModule()
        Me.gpObjectLibrary = New GPObjectLibrary.[Module].GPObjectLibraryModule()
        Me.MasterProviderWindowsFormsModule1 = New MasterProvider.[Module].Win.MasterProviderWindowsFormsModule()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'module5
        '
        Me.module5.AllowValidationDetailsAccess = True
        Me.module5.IgnoreWarningAndInformationRules = False
        '
        'sqlConnection1
        '
        Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=ISS;Integrated Security=SSPI;Pooling=false"
        Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'PivotChartModuleBase1
        '
        Me.PivotChartModuleBase1.DataAccessMode = DevExpress.ExpressApp.CollectionSourceDataAccessMode.Client
        Me.PivotChartModuleBase1.ShowAdditionalNavigation = False
        '
        'AuthenticationStandard1
        '
        Me.AuthenticationStandard1.LogonParametersType = GetType(MasterProvider.CompanySelector.[Module].companySelectorLogonParameters)
        Me.AuthenticationStandard1.UserLoginInfoType = Nothing
        '
        'SecurityStrategyComplex1
        '
        Me.SecurityStrategyComplex1.AllowAnonymousAccess = False
        Me.SecurityStrategyComplex1.Authentication = Me.AuthenticationStandard1
        Me.SecurityStrategyComplex1.NewUserRoleName = Nothing
        Me.SecurityStrategyComplex1.PermissionsReloadMode = DevExpress.ExpressApp.Security.PermissionsReloadMode.NoCache
        Me.SecurityStrategyComplex1.RoleType = GetType(DevExpress.ExpressApp.Security.Strategy.SecuritySystemRole)
        Me.SecurityStrategyComplex1.UseOptimizedPermissionRequestProcessor = False
        Me.SecurityStrategyComplex1.UserType = GetType(DevExpress.ExpressApp.Security.Strategy.SecuritySystemUser)
        '
        'ReportsModule2
        '
        Me.ReportsModule2.EnableInplaceReports = True
        Me.ReportsModule2.ReportDataType = GetType(DevExpress.Persistent.BaseImpl.ReportData)
        '
        'ISSWindowsFormsApplication
        '
        Me.ApplicationName = "ISS"
        Me.Connection = Me.sqlConnection1
        Me.DatabaseUpdateMode = DevExpress.ExpressApp.DatabaseUpdateMode.UpdateDatabaseAlways
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.module6)
        Me.Modules.Add(Me.module8)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.FileAttachmentsWindowsFormsModule1)
        Me.Modules.Add(Me.securityModule1)
        Me.Modules.Add(Me.MemoryModule)
        Me.Modules.Add(Me.module9)
        Me.Modules.Add(Me.module5)
        Me.Modules.Add(Me.MasterProviderModule1)
        Me.Modules.Add(Me.ConditionalAppearanceModule1)
        Me.Modules.Add(Me.WorkflowModule1)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.module7)
        Me.Modules.Add(Me.module10)
        Me.Modules.Add(Me.ViewVariantsModule1)
        Me.Modules.Add(Me.module11)
        Me.Modules.Add(Me.ReportsModule2)
        Me.Modules.Add(Me.ReportsWindowsFormsModule1)
        Me.Modules.Add(Me.module13)
        Me.Modules.Add(Me.module14)
        Me.Modules.Add(Me.module15)
        Me.Modules.Add(Me.spellCheck)
        Me.Modules.Add(Me.spellCheckWin)
        Me.Modules.Add(Me.issAttachments)
        Me.Modules.Add(Me.RecurrenceModule1)
        Me.Modules.Add(Me.module17)
        Me.Modules.Add(Me.module18)
        Me.Modules.Add(Me.HtmlPropertyEditorWindowsFormsModule1)
        Me.Modules.Add(Me.SchedulerModuleBase1)
        Me.Modules.Add(Me.SchedulerWindowsFormsModule1)
        Me.Modules.Add(Me.module19)
        Me.Modules.Add(Me.PivotChartModuleBase1)
        Me.Modules.Add(Me.PivotChartWindowsFormsModule1)
        Me.Modules.Add(Me.masterProviderCompanySelectorModule)
        Me.Modules.Add(Me.MasterProviderWindowsFormsModule1)
        Me.Modules.Add(Me.gpObjectLibrary)
        Me.Security = Me.SecurityStrategyComplex1
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
	Private module3 As Global.ISS.Module.ISSModule
	Private module4 As Global.ISS.Module.Win.ISSWindowsFormsModule
	Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
    Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
    Private module7 As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
    Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Private module8 As ISS.Base.ISSBaseModule
    Private module9 As ISS.Base.Win.ISSBaseWinModule
    Private module10 As ISS.UserFilters.UserFiltersModule
    Private module11 As ISS.UserFilters.Win.UserFiltersWinModule
    Private module13 As ISS.Base.Win.UIModifications.UIModificationsModule
    Private module14 As ISS.DiskFileAttachments.DiskFileAttachmentsModule
    Private module15 As ISS.DiskFileAttachments.Win.WinModule

    Private spellCheck As ISS.SpellChecker.V2.SpellCheckerV2Module
    Private spellCheckWin As ISS.SpellChecker.V2.Win.SpellCheckerV2WinModule

    'Private module16 As ISS.SpellChecker.Win.SpellCheckerModule
    Private module17 As ISS.Notifications.ISSNotificationsModule
    Private module18 As ISS.PostedAlias.PostedAliasModule
    Private module19 As ISS.Notifications.Win.ISSNotificationsWinModule
    Private issAttachments As ISS.Attachments.AttachmentsModule
    'Private issOutlookAttachments As ISS.Attachments.OutlookSupport.OutlookSupportModule
    'Private issWorkflow As ISS.Workflow.WorkflowModule
    'Private issHyperLinkModule As ISS.HyperLinkHandler.HyperLinkHandlerModule
    Private issCustomizations As ISS.BusinessObjectCustomizations.Module.BusinessObjectCustomizationsModule

    Private sqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents FileAttachmentsWindowsFormsModule1 As DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule
    Friend WithEvents ReportsWindowsFormsModule1 As DevExpress.ExpressApp.Reports.Win.ReportsWindowsFormsModule
    Friend WithEvents PivotChartWindowsFormsModule1 As DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule
    Friend WithEvents PivotChartModuleBase1 As DevExpress.ExpressApp.PivotChart.PivotChartModuleBase
    Friend WithEvents SchedulerModuleBase1 As DevExpress.ExpressApp.Scheduler.SchedulerModuleBase
    Friend WithEvents ReportsModule1 As DevExpress.ExpressApp.Reports.ReportsModule
    Friend WithEvents MasterProviderModule1 As MasterProvider.Module.MasterProviderModule
    Friend WithEvents MemoryModule As ISS.Module.Memory.MemoryModule
    Friend WithEvents HtmlPropertyEditorWindowsFormsModule1 As DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule
    Friend WithEvents ConditionalAppearanceModule1 As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Friend WithEvents AuthenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    Friend WithEvents UserFiltersModule1 As ISS.UserFilters.UserFiltersModule
    Friend WithEvents SecurityStrategyComplex1 As DevExpress.ExpressApp.Security.SecurityStrategyComplex
    Friend WithEvents ViewVariantsModule1 As DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule
    'Friend WithEvents ReportsModuleV21 As DevExpress.ExpressApp.ReportsV2.ReportsModuleV2
    'Friend WithEvents NotificationsWinModule1 As ISS.Notifications.Win.ISSNotificationsWinModule
    Friend WithEvents IssBaseModule1 As ISS.Base.ISSBaseModule
    Friend WithEvents MasterProviderModule2 As MasterProvider.Module.MasterProviderModule
    Friend WithEvents SchedulerWindowsFormsModule1 As DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule
    Friend WithEvents WorkflowModule1 As Workflow.WorkflowModule
    Friend WithEvents ReportsModule2 As DevExpress.ExpressApp.Reports.ReportsModule
    Friend WithEvents RecurrenceModule1 As Recurrence.RecurrenceModule
    Private masterProviderCompanySelectorModule As MasterProvider.CompanySelector.Module.CompanySelectorModule
    Private gpObjectLibrary As GPObjectLibrary.Module.GPObjectLibraryModule
    Friend WithEvents MasterProviderWindowsFormsModule1 As MasterProvider.Module.Win.MasterProviderWindowsFormsModule
End Class
