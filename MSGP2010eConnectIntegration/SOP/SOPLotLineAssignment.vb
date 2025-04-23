Imports MSGP2010eConnectIntegration.SOP
Namespace SOP
    Public Class SOPLotLineAssignment

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
    Private _mLineNumber As String
            <MSGPRequiredField()>
    Public Property LineNumber As String
        Get
            Return _mLineNumber
        End Get
        Set(ByVal Value As String)
            _mLineNumber = Value
        End Set
    End Property
    Private _mItemNumber As String
    Public Property ItemNumber As String
        Get
            Return _mItemNumber
        End Get
        Set(ByVal Value As String)
            _mItemNumber = Value
        End Set
    End Property
    Private _mLineLocationCode As String
    Public Property LineLocationCode As String
        Get
            Return _mLineLocationCode
        End Get
        Set(ByVal Value As String)
            _mLineLocationCode = Value
        End Set
    End Property
    Private _mUOM As String
    Public Property UOM As String
        Get
            Return _mUOM
        End Get
        Set(ByVal Value As String)
            _mUOM = Value
        End Set
    End Property
    
    Private _mLotNumber As String
            <MSGPRequiredField()>
    Public Property LotNumber As String
        Get
            Return _mLotNumber
        End Get
        Set(ByVal Value As String)
            _mLotNumber = Value
        End Set
    End Property
    


End Class

End Namespace
