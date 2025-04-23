Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Reflection
Namespace Objects.EX
    <MasterProvider.Module.AllowDataModificationsInMasterProvider>
    Partial Public Class EXEmployeeExtraFields
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            DATE1_I = "1/1/1900"
            DATE2_I = "1/1/1900"
            DATE3_I = "1/1/1900"
            DATE4_I = "1/1/1900"
            DATE5_I = "1/1/1900"
            STRINGS_I_1 = " "
            STRINGS_I_2 = " "
            STRINGS_I_3 = " "
            STRINGS_I_4 = " "
            STRINGS_I_5 = " "
            NUMERICEXTRA_1 = 0
            NUMERICEXTRA_2 = 0
            NUMERICEXTRA_3 = 0
            NUMERICEXTRA_4 = 0
            NUMERICEXTRA_5 = 0
            DOLLARS_I_1 = 0
            DOLLARS_I_2 = 0
            DOLLARS_I_3 = 0
            DOLLARS_I_4 = 0
            DOLLARS_I_5 = 0
            CHECKBOXES_I_1 = 0
            CHECKBOXES_I_2 = 0
            CHECKBOXES_I_3 = 0
            CHECKBOXES_I_4 = 0
            CHECKBOXES_I_5 = 0
            NOTESINDEX_I = 0
            CHANGEBY_I = "sa"
            CHANGEDATE_I = "1/1/1900"
        End Sub

        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            CHANGEDATE_I = Today
        End Sub
    End Class

End Namespace
