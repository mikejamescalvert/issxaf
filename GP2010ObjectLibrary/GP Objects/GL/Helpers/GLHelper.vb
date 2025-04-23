Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Net
Namespace Objects.GL.Helpers
    Public Class GLHelper
        Public Shared Function GetGLAccountIndexMasterByAccountIndex(session As Session, AccountIndex As Integer) As GL.GLAccountIndexMaster
            Return session.FindObject(Of GL.GLAccountIndexMaster)(New BinaryOperator("ACTINDX", AccountIndex, BinaryOperatorType.Equal))
        End Function
    End Class
End Namespace

