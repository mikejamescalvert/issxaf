Public Class SOPShipmentLine
#Region "Properties"
    Private _mDocNumber As String
    Public Property DocNumber() As String
        Get
            Return _mDocNumber
        End Get
        Set(ByVal Value As String)
            _mDocNumber = Value
        End Set
    End Property


#End Region
End Class
