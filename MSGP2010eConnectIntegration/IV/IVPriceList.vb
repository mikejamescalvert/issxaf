Namespace IV
    ''' <summary>
    ''' A collection of inventory price list line headers
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IVPriceList
        Inherits System.Collections.ObjectModel.Collection(Of IVPriceListHeader)

        Private _mItemNumber As String
        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal value As String)
                If value <> _mItemNumber Then
                    For Each header In Items
                        If header.ItemNumber <> value Then
                            header.ItemNumber = value
                        End If
                    Next
                End If
                _mItemNumber = value
            End Set
        End Property

        Protected Overrides Sub InsertItem(index As Integer, item As IVPriceListHeader)
            MyBase.InsertItem(index, item)
            If item.ItemNumber <> ItemNumber Then
                item.ItemNumber = ItemNumber
            End If
        End Sub
    End Class
End Namespace

