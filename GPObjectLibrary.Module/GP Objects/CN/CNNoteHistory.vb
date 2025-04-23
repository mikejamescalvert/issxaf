Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.CN
    ''' <summary>
    ''' GP Table CN30100
    ''' </summary>
    ''' 
    <Persistent("CN30100")>
    Partial Public Class NoteHistory
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
