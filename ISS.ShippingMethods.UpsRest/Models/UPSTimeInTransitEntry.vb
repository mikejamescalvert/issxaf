Imports DevExpress.Xpo
Public Class UPSTimeInTransitEntry

    Private _mMethodName As String
    Public Property MethodName As String
        Get
            Return _mMethodName
        End Get
        Set(ByVal Value As String)
            _mMethodName = Value
        End Set
    End Property
    
    Private _mTransitTime As String
    Public Property TransitTime As String
        Get
            Return _mTransitTime
        End Get
        Set(ByVal Value As String)
            _mTransitTime = Value
        End Set
    End Property


End Class
