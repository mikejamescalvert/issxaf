Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.SY.Helpers
    Public Class SYHelper
        Public Shared Function GetInternetDetailsForSalesPerson(ByVal SalesPersonID As String, ByVal MasterType As String, ByVal CurrentSession As Session) As SYInternetAddressDetail
            Dim gpoGroupOperator As New GroupOperator
            gpoGroupOperator.OperatorType = GroupOperatorType.And
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.Master_ID", SalesPersonID))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.Master_Type", MasterType))
            Return CurrentSession.FindObject(Of SYInternetAddressDetail)(gpoGroupOperator)
        End Function
        Public Shared Function GetInternetDetailsForCustomerAddress(ByVal CustomerKey As String, ByVal AddressKey As String, ByVal CurrentSession As Session) As SY.SYInternetAddressDetail
            Dim gpoGroupOperator As New GroupOperator
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.Master_Type", "CUS"))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.Master_ID", CustomerKey))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.ADRSCODE", AddressKey))
            Return CurrentSession.FindObject(Of SY.SYInternetAddressDetail)(gpoGroupOperator)
        End Function

        Public Shared Function GetInternetDetailsForVendorAddress(ByVal VendorKey As String, ByVal AddressKey As String, ByVal CurrentSession As Session) As SY.SYInternetAddressDetail
            Dim gpoGroupOperator As New GroupOperator
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.Master_Type", "VEN"))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.Master_ID", VendorKey))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.ADRSCODE", AddressKey))
            Return CurrentSession.FindObject(Of SY.SYInternetAddressDetail)(gpoGroupOperator)
        End Function

        Public Shared Function GetNoteText(NoteIndex As Double, ByVal CurrentSession As Session) As String
            Dim xpoNote As SY.SYNoteIndex
            xpoNote = CurrentSession.FindObject(Of SY.SYNoteIndex)(New BinaryOperator("NOTEINDX", NoteIndex))
            If xpoNote IsNot Nothing Then
                Return xpoNote.TXTFIELD
            Else
                Return Nothing
            End If
        End Function



    End Class
End Namespace

