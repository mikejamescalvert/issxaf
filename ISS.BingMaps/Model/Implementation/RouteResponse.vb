Public Class RouteResponse
    Implements IRouteResponse
    Public Sub New()
        Me.OptimizedRouteWaypointList = New List(Of IResponseAddressPoint)
    End Sub

    Public Property OptimizedRouteWaypointList As List(Of IResponseAddressPoint) Implements IRouteResponse.OptimizedRouteWaypointList
    Public Property InitialRequest As IRouteRequest Implements IRouteResponse.InitialRequest

End Class
