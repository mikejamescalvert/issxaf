Imports DevExpress.Xpo
Namespace Objects.WO
    Public Class ManufactureOrderCreateArguement

        Public Property OrderNumber() As String
        Public Property LineID() As Integer
        Public Property ItemNumber() As String
        Public Property InitialStatus() As InitialStatuses = InitialStatuses.Open
        Public Property Quantity As Decimal
        Public Property DrawFromSite As String
        Public Property PostToSite As String
        Public Property SchedulingPreferenceKey As String = "Default"
        Public Property SopType As SopTypes
        Public Property ItemDueDate As Date

        Public Enum InitialStatuses
            Open = 2
            Release = 3
            Complete = 6
        End Enum

        Public Enum SopTypes
            Quote = 1
            Order = 2
            Invoice = 3
        End Enum

    End Class
End Namespace

