Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Reports
Imports DevExpress.XtraReports.UI
Imports DevExpress.Persistent.Base.General

Public Class InplaceReportViewController
    Inherits DevExpress.ExpressApp.Reports.PrintSelectionBaseController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub


    Protected Overrides Sub ShowInReport(e As DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs, reportData As IReportData)
        Dim rpdReportData As ISSReportData = TryCast(reportData,ISSReportData)
        Dim rptReport As ISSXafReport
        If View.ObjectTypeInfo.IsPersistent = True OrElse rpdReportData Is Nothing Then
            MyBase.ShowInReport(e, reportData)
        Else
            rpdReportData = ObjectSpace.GetObject(reportData)
            rpdReportData.SetNonpersistentRuntimeObject(View.CurrentObject)
            rptReport = rpdReportData.LoadReport(ObjectSpace)
            rptReport.SetNonpersistentRuntimeObject(View.CurrentObject)
            rptReport.ShowPreview()
        End If


    End Sub

End Class
