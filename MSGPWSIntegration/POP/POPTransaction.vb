Namespace POP
    Public Class POPTransaction
        'Private _mPOPConfiguration As POPConfiguration
        Private _mPOPHeader As POPHeader
        Private _mPOPDetails As POPDetails


        Public Sub New()
            _mPOPHeader = New POPHeader
            _mPOPDetails = New POPDetails
        End Sub
        'Public Sub New(ByVal POPConfiguration As POPConfiguration, ByVal POPHeader As POPHeader, ByVal POPDetails As POPDetails)
        '    _mPOPConfiguration = POPConfiguration
        '    _mPOPHeader = POPHeader
        '    _mPOPDetails = POPDetails
        'End Sub

        Public Sub New(ByVal POPHeader As POPHeader, ByVal POPDetails As POPDetails)
            '_mPOPConfiguration = POPConfiguration
            _mPOPHeader = POPHeader
            _mPOPDetails = POPDetails
        End Sub


        'Public Property POPConfiguration() As POPConfiguration
        '    Get
        '        Return _mPOPConfiguration
        '    End Get
        '    Set(ByVal value As POPConfiguration)
        '        _mPOPConfiguration = value
        '    End Set
        'End Property
        Public Property POPHeader() As POPHeader
            Get
                Return _mPOPHeader
            End Get
            Set(ByVal value As POPHeader)
                _mPOPHeader = value
            End Set
        End Property
        Public Property POPDetails() As POPDetails
            Get
                Return _mPOPDetails
            End Get
            Set(ByVal value As POPDetails)
                _mPOPDetails = value
            End Set
        End Property
    End Class
End Namespace

