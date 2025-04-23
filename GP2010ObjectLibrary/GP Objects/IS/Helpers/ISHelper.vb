Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.IS.Helpers
    Public Class ISHelper
        Public Shared Function GetSalesOrderLink(ByVal SopNumber As String, ByVal LineItemSequence As Integer, ByVal CurrentSession As Session) As ISSalesOrderManufacturingOrderLink
            Dim gpoGroupOperator As New GroupOperator
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LNITMSEQ", LineItemSequence))
            Return CurrentSession.FindObject(Of ISSalesOrderManufacturingOrderLink)(gpoGroupOperator)
        End Function
    End Class
End Namespace

