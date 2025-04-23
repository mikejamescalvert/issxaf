Namespace IV
    Public Class IVItemVendor
        Private _mItemNumber As String = String.Empty
        Private _mVendorKey As String = String.Empty
        Private _mVendorItemNumber As String = String.Empty
        Private _mVendorItemDescription As String = String.Empty

        Public Sub New()
        End Sub

        Public Property ItemNumber() As String
            Get
                Return _mItemNumber
            End Get
            Set(ByVal value As String)
                _mItemNumber = value
            End Set
        End Property

        Public Property VendorKey() As String
            Get
                Return _mVendorKey
            End Get
            Set(ByVal value As String)
                _mVendorKey = value
            End Set
        End Property

        Public Property VendorItemNumber() As String
            Get
                Return _mVendorItemNumber
            End Get
            Set(ByVal value As String)
                _mVendorItemNumber = value
            End Set
        End Property
        Public Property VendorItemDescription() As String
            Get
                Return _mVendorItemDescription
            End Get
            Set(ByVal value As String)
                _mVendorItemDescription = value
            End Set
        End Property
    End Class
End Namespace
