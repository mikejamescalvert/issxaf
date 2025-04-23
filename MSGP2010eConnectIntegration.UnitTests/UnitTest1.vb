Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MSGPeConnect.Core

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub UpdateSopBatchOnGP2010V()
        Dim strOrderNumber As String
        Dim strBatchNumber As String
        Dim shtOrderType As Short
        Dim spfFactory As MSGP2010eConnectIntegration.SOP.SOPFactory

        spfFactory = New MSGP2010eConnectIntegration.SOP.SOPFactory

        strOrderNumber = "ORDST2225"
        strBatchNumber = "NEWBATCH"
        shtOrderType = 2
        spfFactory.MSGPConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("eConnectConnectionString").ConnectionString
        Assert.IsTrue(spfFactory.UpdateSopDocumentBatchId(strOrderNumber, shtOrderType, strBatchNumber))


    End Sub

End Class