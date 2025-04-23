Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.Linq

<DefaultProperty("CurrentValue")>
Public Class TransactionalDouble
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub


#Region "Properties"
    Private _mCurrentValue As Double
    Public Property CurrentValue As Double
        Get
            Return _mCurrentValue
        End Get
        Set(ByVal Value As Double)
            SetPropertyValue("CurrentValue", _mCurrentValue, Value)
        End Set
    End Property
#End Region

#Region "Collections"
    <Association("TransactionalDouble-HistoricalEntries")>
    <Aggregated()>
    Public ReadOnly Property HistoricalEntries As XPCollection(Of TransactionalDoubleHistory)
        Get
            Return GetCollection(Of TransactionalDoubleHistory)("HistoricalEntries")
        End Get
    End Property
#End Region

#Region "Behaviors"
    Private _mValueChanged As Boolean = False
    Private _mStartingValue As Double
    Protected Overrides Sub OnChanged(propertyName As String, oldValue As Object, newValue As Object)
        MyBase.OnChanged(propertyName, oldValue, newValue)
        If propertyName = "CurrentValue" Then
            If CurrentValue <> _mStartingValue Then
                _mValueChanged = True
            Else
                _mValueChanged = False
            End If
        End If
    End Sub
    Protected Overrides Sub OnLoaded()
        MyBase.OnLoaded()
        _mStartingValue = CurrentValue
    End Sub
    Protected Overrides Sub OnSaving()
        MyBase.OnSaving()
        Dim hveHistoricalEntry As TransactionalDoubleHistory
        If _mValueChanged = True Then
            hveHistoricalEntry = New TransactionalDoubleHistory(Session) With {.FromValue = _mStartingValue, .ToValue = CurrentValue}
            If HistoricalEntries.Count = 0 Then
                hveHistoricalEntry.FromValue = CurrentValue
            End If
            HistoricalEntries.Add(hveHistoricalEntry)
        End If
    End Sub
    Public Function GetRateAtDateTime(ByVal TransactionDateTime As DateTime) As Double
        
        Dim xpoHistory As TransactionalDoubleHistory = HistoricalEntries.Where(Function (xpoTempHistory) xpoTempHistory.TransactionDate > TransactionDateTime).OrderBy(Function (xpoTempHistory) xpoTempHistory.TransactionDate).FirstOrDefault()
        If xpoHistory Is Nothing Then
            Return CurrentValue
        End If
        Return xpoHistory.FromValue  


        'HistoricalEntries.Filter = New BinaryOperator("TransactionDate", TransactionDateTime, BinaryOperatorType.Greater)
        'HistoricalEntries.Sorting.Clear()
        'HistoricalEntries.Sorting.Add(New SortProperty("TransactionDate", DB.SortingDirection.Ascending))
        'If HistoricalEntries.Count = 0 Then
        '    decRate = CurrentValue
        'Else
        '    decRate = HistoricalEntries(0).FromValue
        'End If
        'HistoricalEntries.Filter = Nothing
        'Return decRate
    End Function
#End Region





End Class
