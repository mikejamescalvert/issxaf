Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base

Namespace Objects.PM.Helpers
    Public Class CheckHelper
        Public Shared Function GetClosedChecks(ByVal Session As Session) As XPCollection(Of PM.PMClosedPMTransaction)
            Dim ddfDataFilter As New DevExpress.Data.Filtering.GroupOperator
            Dim xpcPostedTransactions As XPCollection(Of PM.PMClosedPMTransaction)
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.DOCTYPE", "6", DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            xpcPostedTransactions = New XPCollection(Of PM.PMClosedPMTransaction)(Session, ddfDataFilter)
            Return xpcPostedTransactions
        End Function
        Public Shared Function GetClosedChecksFromDate(ByVal Session As Session, ByVal LastDate As DateTime) As XPCollection(Of PM.PMClosedPMTransaction)
            Dim ddfDataFilter As New DevExpress.Data.Filtering.GroupOperator
            Dim xpcPostedTransactions As XPCollection(Of PM.PMClosedPMTransaction)
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.DOCTYPE", "6", DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("DOCDATE", LastDate, DevExpress.Data.Filtering.BinaryOperatorType.Greater))
            xpcPostedTransactions = New XPCollection(Of PM.PMClosedPMTransaction)(Session, ddfDataFilter)
            Return xpcPostedTransactions
        End Function
        Public Shared Function GetClosedChecksForDateRange(ByVal Session As Session, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As XPCollection(Of PM.PMClosedPMTransaction)
            Dim ddfDataFilter As New DevExpress.Data.Filtering.GroupOperator
            Dim xpcPostedTransactions As XPCollection(Of PM.PMClosedPMTransaction)
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.DOCTYPE", "6", DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("DOCDATE", StartDate, DevExpress.Data.Filtering.BinaryOperatorType.GreaterOrEqual))
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("DOCDATE", EndDate.AddDays(1), DevExpress.Data.Filtering.BinaryOperatorType.Less))
            xpcPostedTransactions = New XPCollection(Of PM.PMClosedPMTransaction)(Session, ddfDataFilter)

            Return xpcPostedTransactions
        End Function
        Public Shared Function GetWorkingChecksForDateRange(ByVal Session As Session, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As XPCollection(Of PM.PMWorkingPMTransaction)
            Dim ddfDataFilter As New DevExpress.Data.Filtering.GroupOperator
            Dim xpcWorkingTransactions As XPCollection(Of PM.PMWorkingPMTransaction)
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("DOCTYPE", "6", DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("DOCDATE", StartDate, DevExpress.Data.Filtering.BinaryOperatorType.GreaterOrEqual))
            ddfDataFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("DOCDATE", EndDate.AddDays(1), DevExpress.Data.Filtering.BinaryOperatorType.Less))
            xpcWorkingTransactions = New XPCollection(Of PM.PMWorkingPMTransaction)(Session, ddfDataFilter)

            Return xpcWorkingTransactions
        End Function
    End Class
End Namespace

