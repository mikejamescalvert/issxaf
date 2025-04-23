Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.Persistent.Base.General
Imports System.Windows.Forms
Imports DevExpress.ExpressApp.Reports

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class IReportDataViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.ListView
        Me.TargetObjectType = GetType(IReportData)
        ' Target required Views (via the TargetXXX properties) and create their Actions.
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub ReportData_ImportReports_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles ReportData_ImportReports.Execute
        Dim rptModule As DevExpress.ExpressApp.Reports.ReportsModule
        Dim ofdOpenFileDialog As New OpenFileDialog
        Dim irdReportData As IReportData
        Dim ifiFileInfo As IO.FileInfo
        Dim xtrReport As XafReport
        ofdOpenFileDialog.Filter = "repx files (*.repx)|*.repx|All files (*.*)|*.*"
        ofdOpenFileDialog.Multiselect = True
        If ofdOpenFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            rptModule = Me.Application.Modules.FindModule(Of DevExpress.ExpressApp.Reports.ReportsModule)()
            If rptModule IsNot Nothing Then
                For Each strFile In ofdOpenFileDialog.FileNames
                    ifiFileInfo = New IO.FileInfo(strFile)
                    xtrReport = New XafReport
                    xtrReport.LoadLayout(strFile)
                    irdReportData = ObjectSpace.FindObject(rptModule.ReportDataType, New BinaryOperator("ReportName", ifiFileInfo.Name.Replace(ifiFileInfo.Extension, "")))
                    If irdReportData Is Nothing Then
                        irdReportData = ObjectSpace.CreateObject(rptModule.ReportDataType)
                        irdReportData.ReportName = ifiFileInfo.Name.Replace(ifiFileInfo.Extension, "")
                    End If
                    irdReportData.SaveReport(xtrReport)
                Next
            End If
        End If
        ObjectSpace.CommitChanges()
    End Sub

    Private Sub ReportData_ExportReports_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles ReportData_ExportReports.Execute
        Dim fbdBrowserDialog As New FolderBrowserDialog
        Dim xtrReport As DevExpress.XtraReports.UI.XtraReport
        Dim strFileName As String
        fbdBrowserDialog.Description = "Choose an export directory"
        If fbdBrowserDialog.ShowDialog = DialogResult.OK Then
            For Each xpoReport As IReportData In View.SelectedObjects
                strFileName = String.Format("{0}\{1}.repx", fbdBrowserDialog.SelectedPath, xpoReport.ReportName)
                xtrReport = xpoReport.LoadReport(ObjectSpace)
                xtrReport.SaveLayout(strFileName)
            Next
        End If

        ObjectSpace.CommitChanges()
    End Sub
End Class
