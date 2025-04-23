Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Namespace Services
    Public Class ReportService

        Public Enum SupportedExportFormats
            Pdf = 0
            Xls = 1
            Xlsx = 2
            Html = 3
            Mail = 4
        End Enum

        Public Function ExportReportToByteArray(ByVal Report As ReportData, ByVal DataSource As Object, ByVal Format As SupportedExportFormats) As Byte()
            Dim strExportStream As New IO.MemoryStream
            Dim xafRPT As New XtraReport
            'Dim srmReader As IO.StreamReader
            Dim strMemoryStream As New System.IO.MemoryStream(Report.GetMemberValue("Content"), False)
            strMemoryStream.Position = 0
            xafRPT.LoadLayout(strMemoryStream)
            xafRPT.DataSource = DataSource

            Select Case Format
                Case SupportedExportFormats.Pdf
                    Dim xafPDFOption As New DevExpress.XtraPrinting.PdfExportOptions
                    With xafPDFOption
                        .DocumentOptions.Title = Report.ReportName
                        .PdfACompatibility = DevExpress.XtraPrinting.PdfACompatibility.PdfA1b
                    End With
                    xafRPT.ExportToPdf(strExportStream, xafPDFOption)

                Case SupportedExportFormats.Xls
                    xafRPT.ExportToXls(strExportStream)

                Case SupportedExportFormats.Xlsx
                    xafRPT.ExportToXlsx(strExportStream)

                Case SupportedExportFormats.Html
                    Dim heoExportOptions As New HtmlExportOptions
                    With heoExportOptions
                        .EmbedImagesInHTML = True
                    End With
                    For Each xloLabel As XRLabel In xafRPT.AllControls(Of XRLabel)
                        AddHandler xloLabel.HtmlItemCreated, AddressOf label_HtmlItemCreated
                    Next

                    xafRPT.ExportToHtml(strExportStream, heoExportOptions)

                Case SupportedExportFormats.Mail
                    Dim heoExportOptions As New HtmlExportOptions
                    With heoExportOptions
                        .EmbedImagesInHTML = True
                        .InlineCss = True
                    End With
                    For Each xloLabel As XRLabel In xafRPT.AllControls(Of XRLabel)
                        AddHandler xloLabel.HtmlItemCreated, AddressOf label_HtmlItemCreated
                    Next

                    xafRPT.ExportToHtml(strExportStream, heoExportOptions)

            End Select

            Return strExportStream.ToArray

        End Function
        Public Function ExportReportToByteArray(ByVal Report As ReportDataV2, ByVal DataSource As Object, ByVal Format As SupportedExportFormats) As Byte()
            Dim strExportStream As New IO.MemoryStream
            Dim xafRPT As New XtraReport
            'Dim srmReader As IO.StreamReader
            Dim strMemoryStream As New System.IO.MemoryStream(Report.GetMemberValue("Content"), False)
            strMemoryStream.Position = 0
            xafRPT.LoadLayout(strMemoryStream)
            xafRPT.DataSource = DataSource

            Select Case Format
                Case SupportedExportFormats.Pdf
                    Dim xafPDFOption As New DevExpress.XtraPrinting.PdfExportOptions
                    With xafPDFOption
                        .DocumentOptions.Title = Report.DisplayName
                        .PdfACompatibility = DevExpress.XtraPrinting.PdfACompatibility.PdfA1b
                    End With
                    xafRPT.ExportToPdf(strExportStream, xafPDFOption)

                Case SupportedExportFormats.Xls
                    xafRPT.ExportToXls(strExportStream)

                Case SupportedExportFormats.Xlsx
                    xafRPT.ExportToXlsx(strExportStream)

                Case SupportedExportFormats.Html
                    Dim heoExportOptions As New HtmlExportOptions
                    With heoExportOptions
                        .EmbedImagesInHTML = True
                    End With
                    For Each xloLabel As XRLabel In xafRPT.AllControls(Of XRLabel)
                        AddHandler xloLabel.HtmlItemCreated, AddressOf label_HtmlItemCreated

                    Next

                    xafRPT.ExportToHtml(strExportStream, heoExportOptions)

                Case SupportedExportFormats.Mail
                    Dim heoExportOptions As New HtmlExportOptions
                    With heoExportOptions
                        .EmbedImagesInHTML = True
                        .InlineCss = True
                    End With
                    For Each xloLabel As XRLabel In xafRPT.AllControls(Of XRLabel)
                        AddHandler xloLabel.HtmlItemCreated, AddressOf label_HtmlItemCreated
                    Next

                    xafRPT.ExportToHtml(strExportStream, heoExportOptions)

            End Select

            Return strExportStream.ToArray

        End Function

        Private Sub label_HtmlItemCreated(sender As Object, e As HtmlEventArgs)
            Dim strNewHtml As String
            Try
                If e.Brick.TextValue Is Nothing Then
                    Return
                End If
                If e.Brick.TextValue.ToString.ToUpper.Contains("<HTML") Or e.Brick.TextValue.ToString.ToUpper.Contains("<SPAN") Or e.Brick.TextValue.ToString.ToUpper.Contains("<IMG") Or e.Brick.TextValue.ToString.ToUpper.Contains("</") Then
                    strNewHtml = e.Brick.Text
                    If strNewHtml > String.Empty Then
                        strNewHtml = strNewHtml.Replace("’", "'").Replace("…", "...").Replace("‘", "'")
                    End If
                    e.ContentCell.InnerHtml = strNewHtml

                End If

            Catch ex As Exception

            End Try

        End Sub

        Public Function ExportToMailItem(ByVal Report As ReportData, ByVal DataSource As Object) As Net.Mail.AlternateView
            Dim strExportStream As New IO.MemoryStream
            Dim xafRPT As New XtraReport
            Dim strMemoryStream As New System.IO.MemoryStream(Report.GetMemberValue("Content"), False)
            strMemoryStream.Position = 0
            xafRPT.LoadLayout(strMemoryStream)
            xafRPT.DataSource = DataSource

            Dim meoExportOptions As New MailMessageExportOptions
            With meoExportOptions
                .EmbedImagesInHTML = True
            End With
            For Each xloLabel As XRLabel In xafRPT.AllControls(Of XRLabel)
                AddHandler xloLabel.HtmlItemCreated, AddressOf label_HtmlItemCreated
            Next

            Return xafRPT.ExportToMail(meoExportOptions)
        End Function

        Public Function ExportToMailItem(ByVal Report As ReportDataV2, ByVal DataSource As Object) As Net.Mail.AlternateView
            Dim strExportStream As New IO.MemoryStream
            Dim xafRPT As New XtraReport
            Dim strMemoryStream As New System.IO.MemoryStream(Report.GetMemberValue("Content"), False)
            strMemoryStream.Position = 0
            xafRPT.LoadLayout(strMemoryStream)
            xafRPT.DataSource = DataSource

            Dim meoExportOptions As New MailMessageExportOptions
            With meoExportOptions
                .EmbedImagesInHTML = True
            End With
            For Each xloLabel As XRLabel In xafRPT.AllControls(Of XRLabel)
                AddHandler xloLabel.HtmlItemCreated, AddressOf label_HtmlItemCreated
            Next

            Return xafRPT.ExportToMail(meoExportOptions)
        End Function


    End Class

End Namespace
