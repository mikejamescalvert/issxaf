Imports System.Text
Imports DevExpress.Xpo
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    Private _mGPUnitOfWork As UnitOfWork
    Public Function GetGPUnitOfWork() As UnitOfWork
        If _mGPUnitOfWork Is Nothing Then
            _mGPUnitOfWork = New UnitOfWork
            _mGPUnitOfWork.AutoCreateOption = DB.AutoCreateOption.SchemaAlreadyExists
            _mGPUnitOfWork.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("GPConnectionString").ConnectionString

        End If
        Return _mGPUnitOfWork
    End Function
    <TestMethod()> Public Sub TestPOReceiptModule()
        Dim uow As UnitOfWork = GetGPUnitOfWork()
        Dim xpcReceipts As New XPCollection(Of GPObjectLibrary.Module.Objects.POP.POPReceiptHeaderWork)(uow)
        Assert.IsNotNull(xpcReceipts)
        Assert.IsTrue(xpcReceipts.Count > 0)
    End Sub

End Class