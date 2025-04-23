Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.PK.Helpers
    Public Class PKHelper
        Public Shared Function GetPickListItems(ByVal ManufactureNumber As String, ByVal CurrentSession As Session) As XPCollection(Of PKPickListItem)
            Return New XPCollection(Of PKPickListItem)(CurrentSession, New BinaryOperator("Oid.MANUFACTUREORDER_I", ManufactureNumber))
        End Function
        Public Shared Function GetPickListSequence(ByVal ManufactureNumber As String, ByVal CurrentSession As Session) As PKPickListSequence
            Return CurrentSession.GetObjectByKey(Of PKPickListSequence)(ManufactureNumber)
        End Function
        Public Shared Sub UpdatePicklistSequence(ByVal ManufacturerNumber As String, ByVal NewSequence As Integer, ByVal CurrentSession As Session)
            Dim pksSequence As PKPickListSequence = CurrentSession.GetObjectByKey(Of PKPickListSequence)(ManufacturerNumber)
            If pksSequence IsNot Nothing Then
                pksSequence.PICKLISTSEQ = NewSequence
            End If
        End Sub
    End Class
End Namespace

