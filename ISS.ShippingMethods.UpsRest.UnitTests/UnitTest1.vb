Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    Private Function GetApexConfiguration() As ISS.ShippingMethods.UpsRest.Models.UPSConfiguration
        Dim cfg As New Models.UPSConfiguration
        With cfg
            .AccountNumber = "8e9599"
            .ClientID = "POCN0dtYCek8siA99UoMJ8YJjEsNswQ66Ajv49hvkKAZ7v2Q"
            .ClientSecret = "mvg3jMLim3o3vONeEySluTA9yG5FujwGu2Zfog4F70AsxpxNrilhbX7qmiEHnO55"
            .OriginAddress = GetApexOriginAddress()

        End With
        Return cfg
    End Function

    Private Function GetConfiguration() As ISS.ShippingMethods.UpsRest.Models.UPSConfiguration
        Return GetApexConfiguration()
    End Function

    Private Function GetDevConfiguration() As ISS.ShippingMethods.UpsRest.Models.UPSConfiguration
        Dim cfg As New Models.UPSConfiguration
        With cfg
            .AccountNumber = "H09D03"
            .ClientID = "ZbXYAc1KvmHlWfJj0AoCYfPo7CBow0viRXjtEQBOEunteUOk"
            .ClientSecret = "8aVCCTMYhh4ODzAlK4eJFGMr3J3hhfP6vXwBvqZBVXnfYrQ63MAPIYEGA3o1xV8K"
            .OriginAddress = GetDevOriginAddress()
            .PickupCodeOverride = "03"
        End With
        Return cfg
    End Function
    Public Function GetDestinationAddress()
        Dim adr As New Models.UPSAddress
        With adr
            .Address1 = "12320 NE 109th Way"
            .City = "Vancouver"
            .StateCode = "WA"
            .PostalCode = "98682"
        End With
        Return adr
    End Function
    Public Function GetInvalidDestinationAddress()
        Dim adr As New Models.UPSAddress
        With adr
            .Address1 = "12323 NE 109th Way"
            .City = "Vancouver"
            .StateCode = "WA"
            .PostalCode = "9882"
        End With
        Return adr
    End Function
    Public Function GetDevOriginAddress() As Models.UPSAddress
        Dim adr As New Models.UPSAddress
        With adr
            .Address1 = "2932 Bogue Creek Dr"
            .City = "Howell"
            .StateCode = "MI"
            .PostalCode = "48855"
        End With
        Return adr
    End Function

    Public Function GetApexOriginAddress() As Models.UPSAddress
        Dim adr As New Models.UPSAddress
        With adr
            .Address1 = "16592 Hale Avenue"
            .City = "Irvine"
            .StateCode = "CA"
            .PostalCode = "92606"
            .CountryCode = "US"
        End With
        Return adr
    End Function
    <TestMethod()> Public Sub GetShippingMethods()

        Dim svcRating As New RatingService(GetConfiguration)
        Dim rtrRequest As New Models.UPSRequest

        With rtrRequest
            .DestinationAddress = GetDestinationAddress()
            .Packages = New List(Of Models.UPSPackage)
            .Packages.Add(New Models.UPSPackage())
            .Packages(0).Weight = 10
            .Packages.Add(New Models.UPSPackage())
            .Packages(1).Weight = 12
        End With
        Dim rst = svcRating.GetUPSShippingMethods(rtrRequest, False)
        Assert.IsNotNull(rst)
        Assert.IsTrue(rst.Rates.Count > 0)
    End Sub
    <TestMethod()> Public Sub GetShippingMethodsCostValue()

        Dim svcRating As New RatingService(GetConfiguration)
        Dim rtrRequest As New Models.UPSRequest

        With rtrRequest
            .DestinationAddress = GetDestinationAddress()
            .Packages = New List(Of Models.UPSPackage)
            .Packages.Add(New Models.UPSPackage())
            .Packages(0).Weight = 10
            .Packages.Add(New Models.UPSPackage())
            .Packages(1).Weight = 12
        End With
        Dim rst = svcRating.GetUPSShippingMethods(rtrRequest, True)
        Assert.IsNotNull(rst)
        Assert.IsTrue(rst.Rates.Count > 0)
    End Sub
    <TestMethod>
    Public Sub ValidateValidAddress()
        Dim svcRating As New RatingService(GetConfiguration)
        Dim rtrRequest As New Models.UPSRequest

        With rtrRequest
            .DestinationAddress = GetDestinationAddress()
            .Packages = New List(Of Models.UPSPackage)
            .Packages.Add(New Models.UPSPackage())
            .Packages(0).Weight = 10
            .Packages.Add(New Models.UPSPackage())
            .Packages(1).Weight = 12
        End With
        Dim rst = svcRating.GetUPSAddressValidationResults(rtrRequest)
        Assert.IsNotNull(rst)
        Assert.IsTrue(rst.SuggestedAddresses.Count > 0 Or rst.Result = UPSAddressValidationOutput.RequestStatuses.Success)
    End Sub

    <TestMethod>
    Public Sub ValidateInvalidAddress()
        Dim svcRating As New RatingService(GetConfiguration)
        Dim rtrRequest As New Models.UPSRequest

        With rtrRequest
            .DestinationAddress = GetInvalidDestinationAddress()
            .Packages = New List(Of Models.UPSPackage)
            .Packages.Add(New Models.UPSPackage())
            .Packages(0).Weight = 10
            .Packages.Add(New Models.UPSPackage())
            .Packages(1).Weight = 12
        End With
        Dim rst = svcRating.GetUPSAddressValidationResults(rtrRequest)
        Assert.IsNotNull(rst)
        Assert.IsTrue(rst.SuggestedAddresses.Count > 0 Or rst.Result = UPSAddressValidationOutput.RequestStatuses.Success)
    End Sub
    <TestMethod>
    Public Sub GetTimeInTransit()
        Dim svcRating As New RatingService(GetConfiguration)
        Dim rtrRequest As New Models.UPSRequest

        With rtrRequest
            .DestinationAddress = GetDestinationAddress()
            .Packages = New List(Of Models.UPSPackage)
            .Packages.Add(New Models.UPSPackage())
            .Packages(0).Weight = 10
            .Packages.Add(New Models.UPSPackage())
            .Packages(1).Weight = 12
        End With
        Dim rst = svcRating.GetUPSTimeInTransit(rtrRequest)
        Assert.IsNotNull(rst)
        Assert.IsTrue(rst.TransitTimes.Count > 0)
    End Sub

End Class