Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Reports.Win
Imports DevExpress.ExpressApp.Reports
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Xpo

Public Class ReportWizardViewController
    Inherits Reports.Win.WinReportServiceController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub



    Private Sub ReportWizardViewController_NewXafReportWizardShowing(sender As Object, e As DevExpress.ExpressApp.Reports.Win.NewXafReportWizardShowingEventArgs) Handles Me.NewXafReportWizardShowing
        e.WizardParameters = New CustomWizardParameters(e.WizardParameters.Report)

    End Sub
End Class

<DomainComponent>
Public Class CustomWizardParameters
    Inherits NewXafReportWizardParameters
    Public Sub New(ByVal report As DevExpress.ExpressApp.Reports.XafReport)
        MyBase.New(report)

    End Sub
    <TypeConverter(GetType(MyReportDataTypeConverter))>
    Public Overloads Property DataType As Type
        Get
            Return MyBase.DataType
        End Get
        Set(ByVal Value As Type)
            MyBase.DataType = Value
        End Set
    End Property


End Class

Public Class MyReportDataTypeConverter
    Inherits LocalizedClassInfoTypeConverter


    Public Overrides Function GetStandardValues(context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Dim bmnBOModel As IModelBOModel = CaptionHelper.ApplicationModel.BOModel
        Dim lstResults As New List(Of Type)
        Dim itiTypeInfo As ITypeInfo
        Dim virVisibleInReports As VisibleInReportsAttribute
        For Each itmModelClass As IModelClass In bmnBOModel.GetNodes(Of IModelClass)()
            itiTypeInfo = XafTypesInfo.Instance.FindTypeInfo(itmModelClass.Name)
            If itiTypeInfo Is Nothing OrElse itiTypeInfo.IsAbstract = True Then
                Continue For
            End If
            virVisibleInReports = itiTypeInfo.FindAttribute(Of VisibleInReportsAttribute)()
            If TypeOf itmModelClass Is IModelClassReportsVisibility Then
                If CType(itmModelClass, IModelClassReportsVisibility).IsVisibleInReports = False AndAlso virVisibleInReports Is Nothing Then
                    Continue For
                ElseIf CType(itmModelClass, IModelClassReportsVisibility).IsVisibleInReports = True Then
                    lstResults.Add(itiTypeInfo.Type)
                End If
            End If
            'If virVisibleInReports IsNot Nothing AndAlso virVisibleInReports.IsVisible = True Then
            '    lstResults.Add(itiTypeInfo.Type)
            'End If
        Next
        Return New StandardValuesCollection(lstResults)
    End Function


End Class