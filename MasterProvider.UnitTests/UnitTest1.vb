Imports System.Text
Imports DevExpress.Xpo
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMultipleConnections()
        'Dim uow As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
        'Dim xpoCustomer As GPObjectLibrary.Module.Objects.RM.RMCustomer = uow.FindObject(Of GPObjectLibrary.Module.Objects.RM.RMCustomer)(Nothing)
        'Dim xpoObject As ISS.Module.Customer = uow.FindObject(Of ISS.Module.Customer)(Nothing)
        'Dim xpoMemoryMAnager As ISS.Module.Memory.MemoryManager = ISS.Module.Memory.MemoryManager.GetInstance(uow)
        'Assert.IsNotNull(xpoCustomer)
        'Assert.IsNotNull(xpoObject)
        'Assert.IsNotNull(xpoMemoryMAnager)

    End Sub

    '<TestMethod()> Public Sub TestKeyFetch()
    '    Dim uow As UnitOfWork = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork()
    '    Dim xpoObject As New ISS.Module.Customer(uow)
    '    xpoObject.CustomerName = "Test 1"
    '    uow.CommitChanges()
    '    uow = MasterProvider.Module.Helpers.SessionHelper.GetMasterProviderUnitOfWork
    '    xpoObject = uow.GetObjectByKey(Of ISS.Module.Customer)(xpoObject.Oid)
    '    Assert.IsNotNull(xpoObject)
    '    Assert.IsTrue(xpoObject.CustomerName = "Test 1")


    'End Sub

End Class