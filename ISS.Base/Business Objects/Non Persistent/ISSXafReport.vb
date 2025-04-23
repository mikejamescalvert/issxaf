Imports DevExpress.ExpressApp.Reports

Public Class ISSXafReport
    Inherits XafReport

    ' Fields...
    Private _mRuntimeObject As Object
    Public ReadOnly Property RuntimeObject As Object
        Get
            Return _mRuntimeObject
        End Get
    End Property
    Public Sub SetNonpersistentRuntimeObject(ByVal NonpersistentObject As Object)
        DataSource = {NonpersistentObject}
        _mRuntimeObject = NonpersistentObject
    End Sub

    Protected Overrides Sub InitializeDataSource()
        If RuntimeObject IsNot Nothing Then
            DataSource = {RuntimeObject}
        Else
            MyBase.InitializeDataSource()
        End If
    End Sub

    Protected Overrides Sub AdjustDataSource()
        'MyBase.AdjustDataSource()

    End Sub

    Protected Overrides Sub RefreshDataSourceForPrint()
        'MyBase.RefreshDataSourceForPrint()
    End Sub

End Class
