Imports System
Imports System.Data.OleDb

Namespace Helpers
    Public Class ExcelHelper
        Public Shared Function GetDataSetFromExcelFileName(ByVal FileName As String)
            Dim dstReturn As New DataSet
            Dim strExcelConnection As String
            Dim odbConnection As OleDbConnection
            Dim odaAdapter As OleDbDataAdapter
            Try
                strExcelConnection = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;""", FileName)
                odbConnection = New OleDbConnection(strExcelConnection)
                odaAdapter = New OleDbDataAdapter("Select * from [Sheet1$]", odbConnection)
                odaAdapter.Fill(dstReturn)
            Catch ex As Exception
                Throw ex
            End Try
            Return dstReturn
        End Function
    End Class
End Namespace