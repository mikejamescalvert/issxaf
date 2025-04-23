Imports DevExpress.ExpressApp.Security
Imports DevExpress.Persistent.Base

Public Class MultifactorAuthenticationStandardParameters
    Inherits AuthenticationStandardLogonParameters

    Private _mAuthenticationCode As String

    ''' <summary>
    ''' The authentication code sent to 2FA for validating the login.
    ''' </summary>
    ''' <returns></returns>
    <Index(99)>
    Property AuthenticationCode As String
        Get
            Return _mAuthenticationCode
        End Get
        Set(ByVal Value As String)
            If (_mAuthenticationCode = Value) Then Return
            _mAuthenticationCode = Value
            RaisePropertyChanged(NameOf(AuthenticationCode))
        End Set
    End Property


End Class
