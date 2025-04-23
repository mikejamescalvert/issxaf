Namespace Model

    Public Class DhlName
        Public Sub New()

        End Sub
        Public Sub New(FirstName As String, LastName As String, CompanyName As String, AdditionalName As String)
            Me.firstName = FirstName
            Me.lastName = LastName
            Me.companyName = CompanyName
            Me.additionalName = AdditionalName
        End Sub
        Public Property firstName As String
        Public Property lastName As String
        Public Property companyName As String
        Public Property additionalName As String
    End Class

End Namespace
