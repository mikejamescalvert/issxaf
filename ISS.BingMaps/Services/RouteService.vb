Public Class RouteService
    Private _mConfiguration As IBingConfiguration
    Private _mAddressService As AddressService
    Public Sub New(ByVal Configuration As IBingConfiguration)
        _mConfiguration = Configuration
        _mAddressService = New AddressService(_mConfiguration)
    End Sub



    Public Function GetOptimizedRoute(ByVal RouteRequest As IRouteRequest, ByVal OptimizationType As OptimizationTypes) As IRouteResponse
        Dim gvcRoute As New BingMapsRESTToolkit.RouteRequest
        Dim bngRoute As BingMapsRESTToolkit.Route
        Dim spwWaypoint As BingMapsRESTToolkit.SimpleWaypoint
        Dim rsp As BingMapsRESTToolkit.Response
        Dim irrResponse As New RouteResponse
        Dim rspAddress As ResponseAddressPoint
        Dim intPoint As Integer = 0
        Dim kvpValue As KeyValuePair(Of IAddressPoint, BingMapsRESTToolkit.SimpleWaypoint)?
        Dim dctWaypoints As New Dictionary(Of IAddressPoint, BingMapsRESTToolkit.SimpleWaypoint)
        gvcRoute.WaypointOptimization = BingMapsRESTToolkit.Extensions.TspOptimizationType.TravelTime
        gvcRoute.RouteOptions = New BingMapsRESTToolkit.RouteOptions
        gvcRoute.Waypoints = New List(Of BingMapsRESTToolkit.SimpleWaypoint)


        gvcRoute.BingMapsKey = _mConfiguration.BingKey
        Select Case OptimizationType
            Case OptimizationTypes.TimeWithTraffic
                gvcRoute.RouteOptions.Optimize = BingMapsRESTToolkit.RouteOptimizationType.TimeWithTraffic
            Case OptimizationTypes.Distance
                gvcRoute.RouteOptions.Optimize = BingMapsRESTToolkit.RouteOptimizationType.Distance
            Case OptimizationTypes.Time
                gvcRoute.RouteOptions.Optimize = BingMapsRESTToolkit.RouteOptimizationType.Time

        End Select


        For Each objAddress In RouteRequest.WaypointList
            _mAddressService.LoadLatLongForAddress(objAddress)
            spwWaypoint = New BingMapsRESTToolkit.SimpleWaypoint
            With spwWaypoint

                .Coordinate = New BingMapsRESTToolkit.Coordinate
                .Coordinate.Latitude = objAddress.Latitude
                .Coordinate.Longitude = objAddress.Longitude

            End With
            gvcRoute.Waypoints.Add(spwWaypoint)

            dctWaypoints.Add(objAddress, spwWaypoint)
        Next


        gvcRoute.Execute()

        rsp = gvcRoute.Execute.Result
        If rsp Is Nothing OrElse rsp.ResourceSets Is Nothing OrElse rsp.ResourceSets.Length = 0 OrElse rsp.ResourceSets(0).Resources Is Nothing OrElse rsp.ResourceSets(0).Resources.Length = 0 Then
            Throw New Exception("No address results found")
        End If

        bngRoute = rsp.ResourceSets(0).Resources(0)


        For intLoop As Integer = 0 To gvcRoute.Waypoints.Count - 1
            spwWaypoint = gvcRoute.Waypoints(intLoop)
            kvpValue = dctWaypoints.FirstOrDefault(Function(m) m.Value Is spwWaypoint)
            If kvpValue IsNot Nothing Then
                rspAddress = New ResponseAddressPoint
                rspAddress.ResponseWaypoint = intLoop
                rspAddress.SourcePoint = kvpValue.Value.Key
                irrResponse.OptimizedRouteWaypointList.Add(rspAddress)
            End If
        Next

        irrResponse.InitialRequest = RouteRequest

        Return irrResponse
    End Function



    Public Function GetRouteImage(ByVal RouteImageRequiest As IRouteImageRequest) As String
        Throw New NotImplementedException
    End Function

    Public Enum OptimizationTypes
        Distance
        Time
        TimeWithTraffic
    End Enum

End Class
