Imports Microsoft.VisualBasic
Imports System

Partial Public Class ISSNotificationsWinModule
    ''' <summary> 
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary> 
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Component Designer generated code"

    ''' <summary> 
    ''' Required method for Designer support - do not modify 
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        '
        'ISSNotificationsWinModule
        '
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.SystemModule.SystemModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(ISS.Notifications.ISSNotificationsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(ISS.Base.Win.ISSBaseWinModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule))
        Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Office.Win.OfficeWindowsFormsModule))
    End Sub

#End Region
End Class
