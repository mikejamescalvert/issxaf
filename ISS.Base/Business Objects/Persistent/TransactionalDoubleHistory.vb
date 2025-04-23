Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Public Class TransactionalDoubleHistory
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
        TransactionDate = Now
    End Sub

    Private _mTransactionalDouble As TransactionalDouble
    <Association("TransactionalDouble-HistoricalEntries")>
    Public Property TransactionalDouble As TransactionalDouble
        Get
            Return _mTransactionalDouble
        End Get
        Set(ByVal Value As TransactionalDouble)
            SetPropertyValue("TransactionalDouble", _mTransactionalDouble, Value)
        End Set
    End Property

    Private _mTransactionDate As DateTime
    Public Property TransactionDate As DateTime
        Get
            Return _mTransactionDate
        End Get
        Set(ByVal Value As DateTime)
            SetPropertyValue("TransactionDate", _mTransactionDate, Value)
        End Set
    End Property

    Private _mFromValue As Double
    Public Property FromValue As Double
        Get
            Return _mFromValue
        End Get
        Set(ByVal Value As Double)
            SetPropertyValue("FromValue", _mFromValue, Value)
        End Set
    End Property
    Private _mToValue As Double
    Public Property ToValue As Double
        Get
            Return _mToValue
        End Get
        Set(ByVal Value As Double)
            SetPropertyValue("ToValue", _mToValue, Value)
        End Set
    End Property

End Class