Public Class UPSPackage
    Private _mWeight As Decimal
    Public Property Weight() As Decimal
        Get
            Return _mWeight
        End Get
        Set(ByVal Value As Decimal)
            _mWeight = Value
        End Set
    End Property
    Private _mWidth As Decimal
    Public Property Width() As Decimal
        Get
            Return _mWidth
        End Get
        Set(ByVal Value As Decimal)
            _mWidth = Value
        End Set
    End Property
    Private _mHeight As Decimal
    Public Property Height() As Decimal
        Get
            Return _mHeight
        End Get
        Set(ByVal Value As Decimal)
            _mHeight = Value
        End Set
    End Property
    Private _mLength As Decimal
    Public Property Length() As Decimal
        Get
            Return _mLength
        End Get
        Set(ByVal Value As Decimal)
            _mLength = Value
        End Set
    End Property
    Private _mDescription As String
    Public Property Description() As String
        Get
            Return _mDescription
        End Get
        Set(ByVal Value As String)
            _mDescription = Value
        End Set
    End Property
    Private _mInsure As Boolean
    Public Property Insure() As Boolean
        Get
            Return _mInsure
        End Get
        Set(ByVal Value As Boolean)
            _mInsure = Value
        End Set
    End Property
    Private _mValue As Decimal
    Public Property Value() As Decimal
        Get
            Return _mValue
        End Get
        Set(ByVal Value As Decimal)
            _mValue = Value
        End Set
    End Property


End Class
