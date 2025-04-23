Imports RestSharp

Namespace Models
    Public Class AcumaticaConfiguration

        Public Sub New()
            Me.Locale = "en-US"
        End Sub

        Private _mAcumaticaUrl As String
        Property AcumaticaUrl As String
            Get
                Return _mAcumaticaUrl
            End Get
            Set(ByVal Value As String)
                _mAcumaticaUrl = Value
            End Set
        End Property
        Private _mApiUsername As String
        Property ApiUsername As String
            Get
                Return _mApiUsername
            End Get
            Set(ByVal Value As String)
                _mApiUsername = Value
            End Set
        End Property
        Private _mApiPassword As String
        Property ApiPassword As String
            Get
                Return _mApiPassword
            End Get
            Set(ByVal Value As String)
                _mApiPassword = Value
            End Set
        End Property
        Private _mCompany As String
        Property Company As String
            Get
                Return _mCompany
            End Get
            Set(ByVal Value As String)
                _mCompany = Value
            End Set
        End Property
        Private _mBranch As String
        Property Branch As String
            Get
                Return _mBranch
            End Get
            Set(ByVal Value As String)
                _mBranch = Value
            End Set
        End Property
        Private _mLocale As String
        Property Locale As String
            Get
                Return _mLocale
            End Get
            Set(ByVal Value As String)
                _mLocale = Value
            End Set
        End Property

        Private _mEndpointName As String
        Property EndpointName As String
            Get
                Return _mEndpointName
            End Get
            Set(ByVal Value As String)
                _mEndpointName = Value
            End Set
        End Property
        Private _mEndpointVersion As String
        Property EndpointVersion As String
            Get
                Return _mEndpointVersion
            End Get
            Set(ByVal Value As String)
                _mEndpointVersion = Value
            End Set
        End Property

        Public ReadOnly Property SourceUrl As String
            Get
                If AcumaticaUrl.EndsWith("/") = True Then
                    Return AcumaticaUrl
                Else
                    Return AcumaticaUrl + "/"
                End If
            End Get
        End Property
        Public ReadOnly Property LoginUrl As String
            Get
                Return SourceUrl + "entity/auth/login"
            End Get
        End Property

        Public ReadOnly Property EndpointUrl As String
            Get
                Return SourceUrl + "entity/" + EndpointName + "/" + EndpointVersion + "/"
            End Get
        End Property

        Public ReadOnly Property RestPageSize As Integer
            Get
                Return 20
            End Get
        End Property

        Public AuthenticationCookieResults As IList(Of RestResponseCookie)
        Public LastApiLogin As DateTime
        Public LastApiBranchLogin As String
    End Class

End Namespace
