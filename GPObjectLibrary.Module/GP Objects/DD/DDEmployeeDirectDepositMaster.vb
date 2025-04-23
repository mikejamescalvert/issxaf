Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Reflection
Namespace Objects.DD

    <Persistent("DD00200")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider>
    Partial Public Class DDEmployeeDirectDepositMaster
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub

    End Class

End Namespace
