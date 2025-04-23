Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports OtpNet

Public Class MultifactorAuthenticationStandard
    Inherits AuthenticationStandard

    Public Overrides Function Authenticate(objectSpace As IObjectSpace) As Object
        Dim obj As Object = MyBase.Authenticate(objectSpace)
        Dim mspLoginParameters As MultifactorAuthenticationStandardParameters = TryCast(Me.LogonParameters, MultifactorAuthenticationStandardParameters)
        Dim xpoUser As Object

        If mspLoginParameters IsNot Nothing Then
            Dim xpoUserSettings As MultifactorAuthenticationUserSettings = objectSpace.FindObject(Of MultifactorAuthenticationUserSettings)(New BinaryOperator("UserName", mspLoginParameters.UserName))
            If obj IsNot Nothing AndAlso xpoUserSettings IsNot Nothing Then
                If mspLoginParameters.AuthenticationCode = String.Empty Then
                    Throw New Exception("Authentication code is required!")
                End If
                Dim base32Bytes = Base32Encoding.ToBytes(xpoUserSettings.SecretKey)
                    Dim totp = New Totp(base32Bytes)
                    If totp.VerifyTotp(mspLoginParameters.AuthenticationCode, 0, VerificationWindow.RfcSpecifiedNetworkDelay) = False Then

                        Throw New Exception("Authentication code mismatch, please try again.")
                    End If

                End If
            End If
        Return obj
    End Function
End Class
