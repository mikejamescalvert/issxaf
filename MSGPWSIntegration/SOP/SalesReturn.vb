Imports MSGPWSIntegration.SOP
Namespace SOP
    Public Class SalesReturn
        Inherits SalesDocument

        Private _mReturnDate As Date
        Public Property ReturnDate As Date
            Get
                Return _mReturnDate
            End Get
            Set(ByVal Value As Date)
                _mReturnDate = Value
            End Set
        End Property
        
        
    End Class
End Namespace

