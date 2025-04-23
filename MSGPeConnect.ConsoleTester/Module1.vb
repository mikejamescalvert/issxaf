Imports MSGP2013eConnectIntegration.SOP.SOPFactory

Module Module1

    Sub Main()
        TestGP2013()

    End Sub

    Sub TestGP2013()
        Dim strOrderNumber As String
        Dim strBatchNumber As String
        Dim spfFactory As New MSGP2013eConnectIntegration.SOP.SOPFactory()
        Console.Write("Please input order number to test: ")
        strOrderNumber = Console.ReadLine()
        Console.Write("Please input new batch: ")
        strBatchNumber = Console.ReadLine()

        spfFactory.MSGPConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("eConnectConnectionString").ConnectionString
        If spfFactory.UpdateSOPOrderBatchId(strOrderNumber, SOPTYPES.Order, strBatchNumber) = False Then
            For Each strValue In spfFactory.ExceptionMessages
                Console.WriteLine(strValue)
            Next

        End If
    End Sub

End Module
