Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.GL
    ''' <summary>
    ''' GP Table GL10111
    ''' </summary>
    ''' 
    <Persistent("GL10111")>
    Partial Public Class GLHistoricalYearAccountSummary
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
