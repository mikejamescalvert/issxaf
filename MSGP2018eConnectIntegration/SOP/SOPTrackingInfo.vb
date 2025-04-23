Namespace SOP
    Public Class SOPTrackingInfo
        
        Private _mSOPNumber As String
        <MSGPRequiredField()>
        Public Property SOPNumber As String
            Get
                Return _mSOPNumber
            End Get
            Set(ByVal Value As String)
                _mSOPNumber = Value
            End Set
        End Property
        Private _mSOPType As SOPDocTypes
        <MSGPRequiredField()>
        Public Property SOPType As SOPDocTypes
            Get
                Return _mSOPType
            End Get
            Set(ByVal Value As SOPDocTypes)
                _mSOPType = Value
            End Set
        End Property

        Private _mTrackingNumber As String
        <MSGPRequiredField()>
        Public Property TrackingNumber As String
            Get
                Return _mTrackingNumber
            End Get
            Set(ByVal Value As String)
                _mTrackingNumber = Value
            End Set
        End Property

        Private _mRequesterTransaction As Short
        Public Property RequesterTransaction As Short
            Get
                Return _mRequesterTransaction
            End Get
            Set(ByVal Value As Short)
                _mRequesterTransaction = Value
            End Set
        End Property

        Private _mUserDefined1 As String
        Public Property UserDefined1 As String
            Get
                Return _mUserDefined1
            End Get
            Set(ByVal Value As String)
                _mUserDefined1 = Value
            End Set
        End Property
        Private _mUserDefined2 As String
        Public Property UserDefined2 As String
            Get
                Return _mUserDefined2
            End Get
            Set(ByVal Value As String)
                _mUserDefined2 = Value
            End Set
        End Property
        Private _mUserDefined3 As String
        Public Property UserDefined3 As String
            Get
                Return _mUserDefined3
            End Get
            Set(ByVal Value As String)
                _mUserDefined3 = Value
            End Set
        End Property
        Private _mUserDefined4 As String
        Public Property UserDefined4 As String
            Get
                Return _mUserDefined4
            End Get
            Set(ByVal Value As String)
                _mUserDefined4 = Value
            End Set
        End Property
        Private _mUserDefined5 As String
        Public Property UserDefined5 As String
            Get
                Return _mUserDefined5
            End Get
            Set(ByVal Value As String)
                _mUserDefined5 = Value
            End Set
        End Property
        
    End Class
End Namespace
