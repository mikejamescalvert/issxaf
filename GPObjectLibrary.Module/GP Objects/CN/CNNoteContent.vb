Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.CN
    ''' <summary>
    ''' GP Table CN00300
    ''' </summary>
    ''' 
    <Persistent("CN00300")>
    Partial Public Class NoteContent
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
