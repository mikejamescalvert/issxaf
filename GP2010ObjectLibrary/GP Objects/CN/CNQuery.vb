Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.CN

    ''' <summary>
    ''' GP Table CN00600
    ''' </summary>
    <Persistent("CN00600")> _
    <OptimisticLocking(False)> _
    Partial Public Class CNQuery
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
