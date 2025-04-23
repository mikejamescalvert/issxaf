Namespace Models.JSON
    Public Class Login

        Public Sub New(ByVal AcumaticaConfig As AcumaticaConfiguration)
            Me.locale = "en-US"
            Me.name = AcumaticaConfig.ApiUsername
            Me.password = AcumaticaConfig.ApiPassword
            Me.company = AcumaticaConfig.Company
            Me.branch = AcumaticaConfig.Branch
            Me.locale = AcumaticaConfig.Locale
        End Sub

        Private _mName As String
        Property name As String
            Get
                Return _mName
            End Get
            Set(ByVal Value As String)
                _mName = Value
            End Set
        End Property
        Private _mPassword As String
        Property password As String
            Get
                Return _mPassword
            End Get
            Set(ByVal Value As String)
                _mPassword = Value
            End Set
        End Property
        Private _mCompany As String
        Property company As String
            Get
                Return _mCompany
            End Get
            Set(ByVal Value As String)
                _mCompany = Value
            End Set
        End Property
        Private _mBranch As String
        Property branch As String
            Get
                Return _mBranch
            End Get
            Set(ByVal Value As String)
                _mBranch = Value
            End Set
        End Property
        Private _mLocale As String
        Property locale As String
            Get
                Return _mLocale
            End Get
            Set(ByVal Value As String)
                _mLocale = Value
            End Set
        End Property
        

    End Class

End Namespace
