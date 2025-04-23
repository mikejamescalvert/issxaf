Imports DevExpress.ExpressApp

Public Class ExceptionHelper
    Public Shared Function GetStandardExceptionMessage(ByVal ExceptionToTranslate As Exception) As String
        Dim strMessage As String = ExceptionToTranslate.Message & Constants.vbNewLine & ExceptionToTranslate.StackTrace
        Dim ineException As Exception = ExceptionToTranslate.InnerException
        While ineException IsNot Nothing
            strMessage &= Constants.vbNewLine & ineException.Message & Constants.vbNewLine & ineException.StackTrace
            ineException = ineException.InnerException
        End While
        Return strMessage
    End Function

End Class
