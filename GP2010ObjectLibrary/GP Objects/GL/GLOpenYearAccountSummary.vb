Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.GL
    ''' <summary>
    ''' GP Tabel GL10110
    ''' </summary>
    ''' 
    <Persistent("GL10110")>
    Partial Public Class GLOpenYearAccountSummary
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()

        End Sub

        <PersistentAlias("[<GLAccountIndexMaster>][ACTINDX=^.Oid.ACTINDX].Single()")>
        ReadOnly Property AccountMaster As GLAccountIndexMaster
            Get
                Return EvaluateAlias("AccountMaster")
            End Get
        End Property

    End Class

End Namespace
