Namespace Model

    Public Class DhlAddress
        Public Sub New()

        End Sub

        Public Sub New(countryCode As String, postalCode As String, city As String, street As String, additionalAddressLine As String, number As String, isBusiness As Boolean, addition As String)
            Me.countryCode = countryCode
            Me.postalCode = postalCode
            Me.city = city
            Me.street = street
            Me.additionalAddressLine = additionalAddressLine
            Me.number = number
            Me.isBusiness = isBusiness
            Me.addition = addition
        End Sub

        Public Property countryCode As String
        Public Property postalCode As String
        Public Property city As String
        Public Property street As String
        Public Property additionalAddressLine As String
        Public Property number As String
        Public Property isBusiness As Boolean
        Public Property addition As String
    End Class

End Namespace
