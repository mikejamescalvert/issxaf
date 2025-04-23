Imports DevExpress.ExpressApp
Imports System.ComponentModel

Public Class QueryCanCheckSpellingEventArgs
    Inherits CancelEventArgs

    Public Sub New(ByVal context As TemplateContext, ByVal template As Object)
        Me.Context = context
        Me.Template = template
    End Sub

    Public Property Context As TemplateContext
    Public Property Template As Object
End Class
