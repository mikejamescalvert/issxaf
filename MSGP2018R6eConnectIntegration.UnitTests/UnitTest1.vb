Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub CreatePMTrx()
        Dim pmv As New MSGP2018R6eConnectIntegration.PM.PMFactory
        Dim pmt As New MSGP2018R6eConnectIntegration.PM.PMTrx
        With pmv
            .MSGPConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("GPConnectionString").ConnectionString

        End With
        With pmt
            .BatchID = "123"
            .DocumentType = PM.PMTrx.PMTransactionDocumentTypes.Invoice
            .VendorID = "VEND1"
        End With
        Dim strResult As String = pmv.CreatePMTransaction(pmt)
        Assert.IsTrue(String.IsNullOrEmpty(strResult) = False)
    End Sub

End Class