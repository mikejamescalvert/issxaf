Public Class RouteRequest
    Implements IRouteRequest
    Public Sub New()
        WaypointList = New List(Of IAddressPoint)
    End Sub



    Public Property WaypointList As List(Of IAddressPoint) Implements IRouteRequest.WaypointList



End Class
