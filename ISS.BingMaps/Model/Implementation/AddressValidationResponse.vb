Public Class AddressValidationResponse
    Implements IAddressValidationResponse

    Public Sub New()
        AddressResults = New List(Of ISuggestedAddress)
    End Sub

    Public Property AddressMatched As Boolean Implements IAddressValidationResponse.AddressMatched


    Public Property AddressResults As List(Of ISuggestedAddress) Implements IAddressValidationResponse.AddressResults

End Class
