Namespace IV
    ''' <summary>
    ''' Collection of inventory adjustment line serial otr lot number a specific inventory item entry
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IVSerialLotLines
        Inherits System.Collections.ObjectModel.Collection(Of IVSerialLotLine)

        Private _mSerialLotType As SerialLotTypes

#Region "Properties"
        Public Property SerialLotType() As SerialLotTypes
            Get
                Return _mSerialLotType
            End Get
            Set(ByVal value As SerialLotTypes)
                _mSerialLotType = value
            End Set
        End Property
#End Region
        Public Sub New()
            Me.SerialLotType = SerialLotTypes.None
        End Sub

    End Class
End Namespace
