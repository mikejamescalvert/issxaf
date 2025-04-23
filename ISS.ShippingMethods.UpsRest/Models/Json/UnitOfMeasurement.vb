Namespace Models.Json



    Public Class UnitOfMeasurement


        Private _mCode As String
        Property Code As String
            Get
                Return _mCode
            End Get
            Set(ByVal Value As String)
                _mCode = Value
                If Description = String.Empty Then
                    Description = Value
                End If

            End Set
        End Property
        

        Public Property Description As String
    End Class


End Namespace