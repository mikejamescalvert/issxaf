Public Class DocumentManagerControl


    Private Sub WidgetView1_QueryControl(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs) Handles WidgetView1.QueryControl

    End Sub

    Private Sub WidgetView1_ShowingDockGuides(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.ShowingDockGuidesEventArgs) Handles WidgetView1.ShowingDockGuides
        If e.Document.ImageIndex = -2 Then
            e.Configuration.DisableAllGuides    
        End If
        
    End Sub
End Class
