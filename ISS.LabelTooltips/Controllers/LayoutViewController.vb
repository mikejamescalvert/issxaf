Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.Layout

Public Class LayoutViewController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.DetailView
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        Dim currentView As DetailView = CType(View, DetailView)
        ' Access the Detail View's Control as a Layout Control 
        Dim layoutControl As DevExpress.XtraLayout.LayoutControl = CType( _
           currentView.Control, DevExpress.XtraLayout.LayoutControl)
        'Customize the LayoutControl's settings as required 
        'Access the Layout Control's Layout Items 
        For Each tltToolTipItem As IViewItemWithTooltip In CType(View.Model, DevExpress.ExpressApp.Model.IModelDetailView).Items
            If tltToolTipItem.Tooltip > String.Empty Then
                For Each obj As Object In layoutControl.Items
                    If TypeOf obj Is DevExpress.XtraLayout.LayoutControlItem Then
                        Dim layoutControlItem As DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem = CType( _
                           obj, DevExpress.ExpressApp.Win.Layout.XafLayoutControlItem)
                        'Customize the current LayoutItem's settings 
                        If CType(currentView.LayoutManager, WinLayoutManager).FindViewItem(layoutControlItem).Id = tltToolTipItem.Id Then
                            layoutControlItem.OptionsToolTip.ToolTip = tltToolTipItem.Tooltip
                            layoutControlItem.OptionsToolTip.IconToolTip = tltToolTipItem.TooltipImage
                            layoutControlItem.OptionsToolTip.IconToolTipTitle = tltToolTipItem.TooltipTip
                        End If
                    End If
                Next obj
            End If
        Next

    End Sub
End Class
