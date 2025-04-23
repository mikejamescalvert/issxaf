Public Class AddressService
    Private _mConfiguration As IBingConfiguration
    Public Sub New(ByVal Configuration As IBingConfiguration)
        _mConfiguration = Configuration
    End Sub


    Public Sub LoadLatLongForAddress(ByVal Address As IAddressPoint)

        Dim gcrRequest As New BingMapsRESTToolkit.GeocodeRequest
        Dim rsp As BingMapsRESTToolkit.Response
        Dim lct As BingMapsRESTToolkit.Location
        With gcrRequest
            .Address = New BingMapsRESTToolkit.SimpleAddress
            .Address.AddressLine = Address.Address1
            .Address.CountryRegion = Address.CountryCode
            .Address.AdminDistrict = Address.State
            .Address.Locality = Address.City
            .Address.PostalCode = Address.ZipCode
            .BingMapsKey = _mConfiguration.BingKey

        End With

        rsp = gcrRequest.Execute.Result
        If rsp Is Nothing OrElse rsp.ResourceSets Is Nothing OrElse rsp.ResourceSets.Length = 0 OrElse rsp.ResourceSets(0).Resources Is Nothing OrElse rsp.ResourceSets(0).Resources.Length = 0 Then
            Throw New Exception("No address results found")
        End If

        lct = rsp.ResourceSets(0).Resources(0)
        Address.SetLatLong(lct.GeocodePoints(0).Coordinates(0), lct.GeocodePoints(0).Coordinates(1))

    End Sub

End Class
