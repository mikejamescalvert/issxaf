Public Interface IAddressValidationResponse
    Property AddressMatched As Boolean
    Property AddressResults As List(Of ISuggestedAddress)
End Interface
