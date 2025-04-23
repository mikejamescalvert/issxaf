Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.BM.Helpers
    Public Class BMHelper
        Public Shared Function GetBillOfMaterialDetails(ByVal PartNumber As String, ByVal CurrentSession As Session) As XPCollection(Of BMBillOfMaterialDetail)
            Return New XPCollection(Of BMBillOfMaterialDetail)(CurrentSession, New BinaryOperator("Oid.PPN_I", PartNumber))
        End Function
        Public Shared Function GetBillOfMaterialHeader(ByVal PartNumber As String, ByVal CurrentSession As Session) As BMBillOfMaterialHeader
            Return CurrentSession.FindObject(Of BMBillOfMaterialHeader)(New BinaryOperator("Oid.ITEMNMBR", PartNumber))
        End Function
    End Class
End Namespace

