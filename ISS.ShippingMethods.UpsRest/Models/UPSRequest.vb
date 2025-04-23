Namespace Models


    Public Class UPSRequest

        Public ReadOnly Property TotalWeight() As Decimal
            Get
                Dim decWeight As Decimal = 0
                For Each oPackage As UPSPackage In Packages
                    decWeight += oPackage.Weight
                Next
                Return decWeight
            End Get
        End Property

        Private _mDestinationAddress As New UPSAddress
        Public Property DestinationAddress() As UPSAddress
            Get
                Return _mDestinationAddress
            End Get
            Set(ByVal Value As UPSAddress)
                _mDestinationAddress = Value
            End Set
        End Property

        Private _mPackages As New List(Of UPSPackage)
        Public Property Packages() As List(Of UPSPackage)
            Get
                Return _mPackages
            End Get
            Set(ByVal Value As List(Of UPSPackage))
                _mPackages = Value
            End Set
        End Property



        Public Property RequestedShipDate As DateTime

    End Class
End Namespace