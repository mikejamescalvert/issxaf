Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule
Imports System.Reflection

Public Class AboutInfoController
    Inherits DevExpress.ExpressApp.WindowController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
    End Sub


    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()

        Dim xafAI As AboutInfo = AboutInfo.Instance
        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then

            xafAI.Version = String.Format("{0}.{1}.{2}.{3}", System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Major, System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor, System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Build, System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision)

        Else
            xafAI.Version = String.Format("{0}.{1}.{2}.{3}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision)
        End If
        xafAI.AboutInfoString = String.Format("{0}<br>{1}<br><br>{2}<br><br>{3}<br><br>{4}", xafAI.ProductName, "Version: " + xafAI.Version, xafAI.Copyright, AboutInfo.Instance.Company, xafAI.Description)
        

        'Dim asmAssembly As Assembly = Assembly.GetEntryAssembly
        'Dim fviFileVersion As FileVersionInfo = FileVersionInfo.GetVersionInfo(asmAssembly.Location)
        'DevExpress.ExpressApp.SystemModule.AboutInfo.Instance.AboutInfoString = String.Format("{0}<br>{1}<br><br>{2}<br><br>{3}<br><br>{4}", AboutInfo.Instance.ProductName, "Version: " + fviFileVersion.FileVersion, AboutInfo.Instance.Copyright, AboutInfo.Instance.Company, AboutInfo.Instance.Description)
    End Sub


End Class
