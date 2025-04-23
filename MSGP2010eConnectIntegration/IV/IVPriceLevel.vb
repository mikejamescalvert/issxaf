Namespace IV

    Public Class IVPriceLevel

        Private _mPriceLevel As String
        <MSGPRequiredField>
        Public Property PriceLevel() As String
            Get
                Return _mPriceLevel
            End Get
            Set(ByVal value As String)
                _mPriceLevel = value
            End Set
        End Property

        Private _mDescription As String
        Public Property Description() As String
            Get
                Return _mDescription
            End Get
            Set(ByVal value As String)
                _mDescription = value
            End Set
        End Property

    End Class
End Namespace

