Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub GetOptimizedRoute()
        Dim cnf As New BingConfiguration
        Dim irtRoute As New RouteService(cnf)
        Dim adr As AddressPoint
        Dim rrqRouteRequest As New RouteRequest
        Dim rtrResponse As RouteResponse

        adr = New AddressPoint()
        With adr
            .Address1 = "12320 NE 109th Way"
            .City = "Vancouver"
            .State = "WA"
            .ZipCode = "98682"
        End With
        rrqRouteRequest.WaypointList.Add(adr)


        adr = New AddressPoint
        With adr
            .Address1 = "3105 NE Andresen Rd"
            .City = "Vancouver"
            .State = "WA"
            .ZipCode = "98661"
        End With

        rrqRouteRequest.WaypointList.Add(adr)


        adr = New AddressPoint
        With adr
            .Address1 = "3309 NE 78th St"
            .City = "Vancouver"
            .State = "WA"
            .ZipCode = "98665"
        End With

        rrqRouteRequest.WaypointList.Add(adr)


        adr = New AddressPoint
        With adr
            .Address1 = "1309 NE 134th St"
            .City = "Vancouver"
            .State = "WA"
            .ZipCode = "98685"
        End With

        rrqRouteRequest.WaypointList.Add(adr)


        adr = New AddressPoint()
        With adr
            .Address1 = "12320 NE 109th Way"
            .City = "Vancouver"
            .State = "WA"
            .ZipCode = "98682"
        End With
        rrqRouteRequest.WaypointList.Add(adr)

        rtrResponse = irtRoute.GetOptimizedRoute(rrqRouteRequest, RouteService.OptimizationTypes.TimeWithTraffic)
        Assert.IsNotNull(rtrResponse)

    End Sub

    <TestMethod()> Public Sub GetAddressLatLong()
        Dim cnf As New BingConfiguration
        Dim svc As New AddressService(cnf)
        Dim adr As New AddressPoint
        With adr
            .Address1 = "12320 NE 109th Way"
            .City = "Vancouver"
            .State = "WA"
            .ZipCode = "98682"
        End With
        svc.LoadLatLongForAddress(adr)
    End Sub


    <TestMethod()> Public Sub GetRouteImage()

    End Sub

End Class