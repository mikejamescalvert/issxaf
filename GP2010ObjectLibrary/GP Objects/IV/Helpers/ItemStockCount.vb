Imports DevExpress.Xpo
Namespace Objects.IV.Helpers
    Public Class ItemStockCount
        Private _mItemKey As String
        Public Property ItemKey() As String
            Get
                Return _mItemKey
            End Get
            Set(ByVal Value As String)
                _mItemKey = Value
            End Set
        End Property
        Private _mItemDescription As String
        Public Property ItemDescription As String
            Get
                Return _mItemDescription
            End Get
            Set(ByVal Value As String)
                _mItemDescription = Value
            End Set
        End Property

        
        Private _mItemCount As Decimal
        Public Property ItemCount() As Decimal
            Get
                Return _mItemCount
            End Get
            Set(ByVal Value As Decimal)
                _mItemCount = Value
            End Set
        End Property

        Public ReadOnly Property ItemBaseUOMCount() As Decimal
            Get
                If ItemBaseUOMFactor > 0 Then
                    Return ItemCount * ItemBaseUOMFactor
                Else
                    Return ItemCount
                End If
            End Get
        End Property
        Private _mItemBaseUOMFactor As Decimal
        Public Property ItemBaseUOMFactor As Decimal
            Get
                Return _mItemBaseUOMFactor
            End Get
            Set(ByVal Value As Decimal)
                _mItemBaseUOMFactor = Value
            End Set
        End Property
        

        Private _mUOM As String
        Public Property UOM() As String
            Get
                Return _mUOM
            End Get
            Set(ByVal Value As String)
                _mUOM = Value
            End Set
        End Property
        Private _mLocation As String
        Public Property Location() As String
            Get
                Return _mLocation
            End Get
            Set(ByVal Value As String)
                _mLocation = Value
            End Set
        End Property
        Private _mReceiptQty As Double
        Public Property ReceiptQty As Double
            Get
                Return _mReceiptQty
            End Get
            Set(ByVal Value As Double)
                _mReceiptQty = Value
            End Set
        End Property
        

        Private _mCountDate As Date
        Public Property CountDate() As Date
            Get
                Return _mCountDate
            End Get
            Set(ByVal Value As Date)
                _mCountDate = Value
            End Set
        End Property
        Private _mSerialNumbers As System.Collections.ObjectModel.Collection(Of ItemStockCountSerialLotNumber)
        Public Property SerialNumbers() As System.Collections.ObjectModel.Collection(Of ItemStockCountSerialLotNumber)

            Get
                Return _mSerialNumbers
            End Get
            Set(ByVal Value As System.Collections.ObjectModel.Collection(Of ItemStockCountSerialLotNumber))
                _mSerialNumbers = Value
            End Set
        End Property
    End Class
End Namespace