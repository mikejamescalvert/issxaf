Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Reports

Public Class ISSReportData
    Inherits ReportData
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

    Private _mRuntimeObject As Object
    <VisibleInListView(False)>
    <VisibleInDetailView(False)>
    Public ReadOnly Property RuntimeObject As Object
        Get
            Return _mRuntimeObject
        End Get
    End Property
    Public Sub SetNonpersistentRuntimeObject(ByVal NonpersistentObject As Object)
        _mRuntimeObject = NonpersistentObject
    End Sub

    Protected Overrides Function CreateReport() As DevExpress.ExpressApp.Reports.XafReport
        Dim ixrXafReport As New ISSXafReport()
        ixrXafReport.SetNonpersistentRuntimeObject(RuntimeObject)
        Return ixrXafReport
    End Function

End Class
