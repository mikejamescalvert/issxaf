Imports ISS.AcumaticaLibrary.Models.JSON

Namespace Models
    Public Class SalesPriceResults

        Public Sub New(ByVal Configuration As AcumaticaConfiguration)

        End Sub

        Private _mSalesPriceDetails As List(Of SalesPriceDetails)
        Property SalesPriceDetails As List(Of SalesPriceDetails)
            Get
                Return _mSalesPriceDetails
            End Get
            Set(ByVal Value As List(Of SalesPriceDetails))
                _mSalesPriceDetails = Value
            End Set
        End Property


    End Class

End Namespace
