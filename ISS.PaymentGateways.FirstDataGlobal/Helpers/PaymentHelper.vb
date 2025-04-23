Imports System.Net
Imports System.Text
Imports System.Security.Cryptography

Public Class PaymentHelper

    Private Const PaymentURL As String = "https://api.globalgatewaye4.firstdata.com/transaction"
    Private Const TestPaymentURL As String = "https://api.demo.globalgatewaye4.firstdata.com/transaction"

    Public Shared Function ChargeCard(ByVal Configuration As Configuration, ByVal PaymentRequest As PaymentRequest) As PaymentResponse
        Dim fdsService As New FirstDataService.Service
        Dim trnTransaction As New FirstDataService.Transaction
        Dim trrResult As FirstDataService.TransactionResult
        Dim pmrResponse As New PaymentResponse
        Dim intMethod As Integer
        Dim intYear As Integer
        Dim intInd As Integer
        Try

            intMethod = Configuration.PurchaseType
            If PaymentRequest.ExpirationYear > 2000 Then
                intYear = PaymentRequest.ExpirationYear - 2000
            Else
                intYear = PaymentRequest.ExpirationYear
            End If
            If PaymentRequest.CardCodeDigitsOnly > 0 Then
                intInd = 1
            Else
                intInd = 9
            End If


             If Configuration.TestMode = True Then
                fdsService.Url = TestPaymentURL
            Else
                fdsService.Url = PaymentURL
            End If
    

            With trnTransaction
                .Transaction_Type = intMethod.ToString.PadLeft(2, "0")
                .ExactID = Configuration.GatewayID
                .Password = Configuration.Password
                .Card_Number = PaymentRequest.CardNumberDigitsOnly
                .VerificationStr2 = PaymentRequest.CardCodeDigitsOnly
                .Expiry_Date = PaymentRequest.ExpirationMonth.ToString.PadLeft(2, "0") + intYear.ToString.PadLeft(2, "0")
                .CardHoldersName = String.Format("{0} {1}", PaymentRequest.FirstName, PaymentRequest.LastName)
                .CVD_Presence_Ind = intInd.ToString
                .DollarAmount = PaymentRequest.OrderTotal.ToString
                .Reference_No = PaymentRequest.OrderNumber
                .ZipCode = PaymentRequest.ZipCode
                .Tax1Amount = "0"
                .Customer_Ref = PaymentRequest.CustomerID
                .Client_IP = PaymentRequest.CustomerIP
                .Client_Email = PaymentRequest.CustomerEmail
                .Currency = "USD"
            End With

            trrResult = fdsService.SendAndCommit(trnTransaction)

            If trrResult.Transaction_Approved = True Then
                pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Success
                pmrResponse.AuthorizationNumber = trrResult.Authorization_Num
            Else
                pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
                pmrResponse.ResponseMessage = trrResult.Error_Number + ":" + trrResult.Error_Description
            End If


        Catch ex As Exception
            pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
            pmrResponse.ResponseMessage = ex.Message
        End Try

        Return pmrResponse
    End Function

    Public Shared Function VoidCard(ByVal Configuration As Configuration, ByVal VoidRequest As VoidRequest) As VoidResponse
        Dim fdsService As New FirstDataService.Service
        Dim trnTransaction As New FirstDataService.Transaction
        Dim trrResult As FirstDataService.TransactionResult
        Dim vdrResponse As New VoidResponse
        Dim intMethod As Integer
        Dim intYear As Integer
        Dim intInd As Integer
        Try
            vdrResponse.Request = VoidRequest
            If VoidRequest.ExpirationYear > 2000 Then
                intYear = VoidRequest.ExpirationYear - 2000
            Else
                intYear = VoidRequest.ExpirationYear
            End If
            If VoidRequest.CardCodeDigitsOnly > 0 Then
                intInd = 1
            Else
                intInd = 9
            End If


             If Configuration.TestMode = True Then
                fdsService.Url = TestPaymentURL
            Else
                fdsService.Url = PaymentURL
            End If
    

            With trnTransaction
                .Transaction_Type = "13"
                .ExactID = Configuration.GatewayID
                .Password = Configuration.Password
                .Card_Number = VoidRequest.CardNumberDigitsOnly
                .VerificationStr2 = VoidRequest.CardCodeDigitsOnly
                .Expiry_Date = VoidRequest.ExpirationMonth.ToString.PadLeft(2, "0") + intYear.ToString.PadLeft(2, "0")
                .CardHoldersName = String.Format("{0} {1}", VoidRequest.FirstName, VoidRequest.LastName)
                .CVD_Presence_Ind = intInd.ToString
                .DollarAmount = VoidRequest.OrderTotal.ToString
                .Reference_No = VoidRequest.OrderNumber
                .ZipCode = VoidRequest.ZipCode
                .Tax1Amount = "0"
                .Customer_Ref = VoidRequest.CustomerID
                .Client_IP = VoidRequest.CustomerIP
                .Client_Email = VoidRequest.CustomerEmail
                .Currency = "USD"
                'Unique to void
                .Authorization_Num = VoidRequest.AuthorizationNumber
                
            End With

            trrResult = fdsService.SendAndCommit(trnTransaction)

            If trrResult.Transaction_Approved = True Then
                vdrResponse.ResponseType = PaymentResponse.ResponseTypes.Success
            Else
                vdrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
                vdrResponse.ResponseMessage = trrResult.Error_Number + ":" + trrResult.Error_Description
            End If


        Catch ex As Exception
            vdrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
            vdrResponse.ResponseMessage = ex.Message
        End Try

        Return vdrResponse




        ''todo: change method and response types/add auth number
        'Dim pmrResponse As New PaymentResponse
        'Dim intMethod As Integer
        'Dim intYear As Integer
        'Dim intInd As Integer
        'Dim htrRequest As Net.HttpWebRequest
        'Dim bytBuffer As Byte()
        'Dim iosStream As IO.Stream
        'Dim srmStreamReader As IO.StreamReader
        'Dim htrResponse As Net.HttpWebResponse
        'Dim encEncoding As Encoding = System.Text.Encoding.GetEncoding(1252)
        'Dim strResponse As String
        'Dim xmdDocument As XDocument
        'Dim strResponseCode As String
        'Dim strErrorMessage As String
        'Try
        '    If Configuration.TestMode = True Then
        '        htrRequest = WebRequest.Create(TestPaymentURL)
        '    Else
        '        htrRequest = WebRequest.Create(PaymentURL)
        '    End If
        '    intMethod = 13
        '    If VoidRequest.ExpirationYear > 2000 Then
        '        intYear = VoidRequest.ExpirationYear - 2000
        '    Else
        '        intYear = VoidRequest.ExpirationYear
        '    End If
        '    If VoidRequest.CardCodeDigitsOnly > 0 Then
        '        intInd = 1
        '    Else
        '        intInd = 9
        '    End If
        '    Dim xml As System.Xml.Linq.XElement = New XElement("Transaction",
        '                                            New XElement("Transaction_Type", intMethod.ToString.PadLeft(2, "0")),
        '                                            New XElement("ExactID", Configuration.GatewayID),
        '                                            New XElement("Password", Configuration.Password),
        '                                            New XElement("Card_Number", VoidRequest.CardNumberDigitsOnly.ToString),
        '                                            New XElement("VerificationStr2", VoidRequest.CardCodeDigitsOnly.ToString),
        '                                            New XElement("Expiry_Date", VoidRequest.ExpirationMonth.ToString.PadLeft(2, "0") + intYear.ToString.PadLeft(2, "0")),
        '                                            New XElement("CardHoldersName", String.Format("{0} {1}", VoidRequest.FirstName, VoidRequest.LastName)),
        '                                            New XElement("CVD_Presence_Ind", intInd.ToString),
        '                                            New XElement("Authorization_Num ", VoidRequest.AuthorizationNumber),
        '                                            New XElement("DollarAmount", VoidRequest.OrderTotal.ToString),
        '                                            New XElement("Reference_No", VoidRequest.OrderNumber),
        '                                            New XElement("ZipCode", VoidRequest.ZipCode),
        '                                            New XElement("Tax1Amount", "0"),
        '                                            New XElement("Customer_Ref", VoidRequest.CustomerID),
        '                                            New XElement("Client_IP", VoidRequest.CustomerIP),
        '                                            New XElement("Client_Email", VoidRequest.CustomerEmail),
        '                                            New XElement("Currency", "USD"),
        '                                            New XElement("Currency", "USD"))

        '    htrRequest.KeepAlive = False
        '    htrRequest.Method = "POST"
        '    bytBuffer = Encoding.ASCII.GetBytes(xml.ToString)
        '    htrRequest.ContentLength = bytBuffer.Length
        '    htrRequest.ContentType = "text/xml"
        '    iosStream = htrRequest.GetRequestStream
        '    iosStream.Write(bytBuffer, 0, bytBuffer.Length)
        '    iosStream.Close()
        '    htrResponse = htrRequest.GetResponse
        '    srmStreamReader = New IO.StreamReader(htrResponse.GetResponseStream, encEncoding)
        '    strResponse = srmStreamReader.ReadToEnd
        '    srmStreamReader.Close()
        '    htrResponse.Close()

        '    'todo: parse response

        '    xmdDocument = XDocument.Parse(strResponse)


        '    If xmdDocument.Element("Transaction_Approved").Value = "true" Then
        '        pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Success
        '    Else
        '        pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
        '        pmrResponse.ResponseType = xmdDocument.Element("Error_Description").Value
        '    End If

        'Catch ex As Exception
        '    pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
        '    pmrResponse.ResponseMessage = ex.Message
        'End Try

        'Return pmrResponse
    End Function

    Public Shared Function RefundCard(ByVal Configuration As Configuration, ByVal RefundRequest As RefundRequest) As RefundResponse
        Dim fdsService As New FirstDataService.Service
        Dim trnTransaction As New FirstDataService.Transaction
        Dim trrResult As FirstDataService.TransactionResult
        Dim rfdResponse As New RefundResponse
        Dim intMethod As Integer
        Dim intYear As Integer
        Dim intInd As Integer
        Try
            rfdResponse.Request = RefundRequest
            If RefundRequest.ExpirationYear > 2000 Then
                intYear = RefundRequest.ExpirationYear - 2000
            Else
                intYear = RefundRequest.ExpirationYear
            End If
            If RefundRequest.CardCodeDigitsOnly > 0 Then
                intInd = 1
            Else
                intInd = 9
            End If


             If Configuration.TestMode = True Then
                fdsService.Url = TestPaymentURL
            Else
                fdsService.Url = PaymentURL
            End If
    

            With trnTransaction
                .Transaction_Type = "04"
                .ExactID = Configuration.GatewayID
                .Password = Configuration.Password
                .Card_Number = RefundRequest.CardNumberDigitsOnly
                .VerificationStr2 = RefundRequest.CardCodeDigitsOnly
                .Expiry_Date = RefundRequest.ExpirationMonth.ToString.PadLeft(2, "0") + intYear.ToString.PadLeft(2, "0")
                .CardHoldersName = String.Format("{0} {1}", RefundRequest.FirstName, RefundRequest.LastName)
                .CVD_Presence_Ind = intInd.ToString
                .DollarAmount = RefundRequest.OrderTotal.ToString
                .Reference_No = RefundRequest.OrderNumber
                .ZipCode = RefundRequest.ZipCode
                .Tax1Amount = "0"
                .Customer_Ref = RefundRequest.CustomerID
                .Client_IP = RefundRequest.CustomerIP
                .Client_Email = RefundRequest.CustomerEmail
                .Currency = "USD"
                
            End With

            trrResult = fdsService.SendAndCommit(trnTransaction)

            If trrResult.Transaction_Approved = True Then
                rfdResponse.ResponseType = PaymentResponse.ResponseTypes.Success
            Else
                rfdResponse.ResponseType = PaymentResponse.ResponseTypes.Error
                rfdResponse.ResponseMessage = trrResult.Error_Number + ":" + trrResult.Error_Description
            End If


        Catch ex As Exception
            rfdResponse.ResponseType = PaymentResponse.ResponseTypes.Error
            rfdResponse.ResponseMessage = ex.Message
        End Try

        Return rfdResponse

        ''todo: change method and response types
        'Dim pmrResponse As New PaymentResponse
        'Dim intMethod As Integer
        'Dim intYear As Integer
        'Dim intInd As Integer
        'Dim htrRequest As Net.HttpWebRequest
        'Dim bytBuffer As Byte()
        'Dim iosStream As IO.Stream
        'Dim srmStreamReader As IO.StreamReader
        'Dim htrResponse As Net.HttpWebResponse
        'Dim encEncoding As Encoding = System.Text.Encoding.GetEncoding(1252)
        'Dim strResponse As String
        'Dim xmdDocument As XDocument
        'Dim strResponseCode As String
        'Dim strErrorMessage As String
        'Try
        '    If Configuration.TestMode = True Then
        '        htrRequest = WebRequest.Create(TestPaymentURL)
        '    Else
        '        htrRequest = WebRequest.Create(PaymentURL)
        '    End If
        '    intMethod = 4
        '    If RefundRequest.ExpirationYear > 2000 Then
        '        intYear = RefundRequest.ExpirationYear - 2000
        '    Else
        '        intYear = RefundRequest.ExpirationYear
        '    End If
        '    If RefundRequest.CardCodeDigitsOnly > 0 Then
        '        intInd = 1
        '    Else
        '        intInd = 9
        '    End If
        '    Dim xml As System.Xml.Linq.XElement = New XElement("Transaction",
        '                                            New XElement("Transaction_Type", intMethod.ToString.PadLeft(2, "0")),
        '                                            New XElement("ExactID", Configuration.GatewayID),
        '                                            New XElement("Password", Configuration.Password),
        '                                            New XElement("Card_Number", RefundRequest.CardNumberDigitsOnly.ToString),
        '                                            New XElement("VerificationStr2", RefundRequest.CardCodeDigitsOnly.ToString),
        '                                            New XElement("Expiry_Date", RefundRequest.ExpirationMonth.ToString.PadLeft(2, "0") + intYear.ToString.PadLeft(2, "0")),
        '                                            New XElement("CardHoldersName", String.Format("{0} {1}", RefundRequest.FirstName, RefundRequest.LastName)),
        '                                            New XElement("CVD_Presence_Ind", intInd.ToString),
        '                                            New XElement("DollarAmount", RefundRequest.OrderTotal.ToString),
        '                                            New XElement("Reference_No", RefundRequest.OrderNumber),
        '                                            New XElement("ZipCode", RefundRequest.ZipCode),
        '                                            New XElement("Tax1Amount", "0"),
        '                                            New XElement("Customer_Ref", RefundRequest.CustomerID),
        '                                            New XElement("Client_IP", RefundRequest.CustomerIP),
        '                                            New XElement("Client_Email", RefundRequest.CustomerEmail),
        '                                            New XElement("Currency", "USD"),
        '                                            New XElement("Currency", "USD"))

        '    htrRequest.KeepAlive = False
        '    htrRequest.Method = "POST"
        '    bytBuffer = Encoding.ASCII.GetBytes(xml.ToString)
        '    htrRequest.ContentLength = bytBuffer.Length
        '    htrRequest.ContentType = "text/xml"
        '    iosStream = htrRequest.GetRequestStream
        '    iosStream.Write(bytBuffer, 0, bytBuffer.Length)
        '    iosStream.Close()
        '    htrResponse = htrRequest.GetResponse
        '    srmStreamReader = New IO.StreamReader(htrResponse.GetResponseStream, encEncoding)
        '    strResponse = srmStreamReader.ReadToEnd
        '    srmStreamReader.Close()
        '    htrResponse.Close()

        '    'todo: parse response

        '    xmdDocument = XDocument.Parse(strResponse)


        '    If xmdDocument.Element("Transaction_Approved").Value = "true" Then
        '        pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Success
        '        pmrResponse.AuthorizationNumber = xmdDocument.Element("Authorization_Num").Value
        '    Else
        '        pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
        '        pmrResponse.ResponseType = xmdDocument.Element("Error_Description").Value
        '    End If

        'Catch ex As Exception
        '    pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Error
        '    pmrResponse.ResponseMessage = ex.Message
        'End Try

        'Return pmrResponse
    End Function

End Class
