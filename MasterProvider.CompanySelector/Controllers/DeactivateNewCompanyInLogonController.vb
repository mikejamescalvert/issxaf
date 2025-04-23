Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports Microsoft.VisualBasic

' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
Partial Public Class DeactivateNewCompanyInLogonController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        ' Target required Views (via the TargetXXX properties) and create their Actions.
        TargetViewType = ViewType.ListView
        TargetObjectType = GetType(CompanyDefinition)
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
        If View.Id = "CompanyDefinition_LookupListView_Logon" Then
            Dim controller As NewObjectViewController = Frame.GetController(Of NewObjectViewController)
            If controller IsNot Nothing Then
                controller.NewObjectAction.Active.SetItemValue("LookupListViewDeactivate", False)
            End If
        End If
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub
End Class
