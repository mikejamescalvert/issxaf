Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.CN
    ''' <summary>
    ''' GP Table CN00100
    ''' </summary>
    ''' 
    <Persistent("CN00100")>
    Partial Public Class NoteHeader
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
