Imports System.Net
Imports System.Text
Imports System.Security.Cryptography
Imports PayPal.Payments
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Common

Public Class PaymentHelper

    Public Shared Function ChargeCard(ByVal Configuration As Configuration, ByVal PaymentRequest As PaymentRequest) As PaymentResponse
        Dim pmrResponse As New PaymentResponse
        Dim intMethod As Integer
        Dim intYear As Integer
        Dim intInd As Integer



        Try

            If PaymentRequest.ExpirationYear > 2000 Then
                intYear = PaymentRequest.ExpirationYear - 2000
            Else
                intYear = PaymentRequest.ExpirationYear
            End If


            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo(Configuration.PayPalUser, Configuration.PayPalVendor, Configuration.PayPalPartner, Configuration.PayPalPassword)

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData(Configuration.URL)
            '/////////////////////////////////////////////////////////////////


            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(PaymentRequest.OrderTotal))
            Inv.Amt = Amt
            Inv.PoNum = PaymentRequest.OrderNumber
            Inv.InvNum = PaymentRequest.OrderNumber

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            Bill.Zip = PaymentRequest.ZipCode
            Inv.BillTo = Bill

            ' Create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard(PaymentRequest.CardNumberDigitsOnly, PaymentRequest.ExpirationMonth.ToString().PadLeft(2, "0") + intYear.ToString.PadLeft(2,"0"))
            If PaymentRequest.CardCodeDigitsOnly > String.Empty
                CC.Cvv2 = PaymentRequest.CardCodeDigitsOnly
            End If
            

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)
            '/////////////////////////////////////////////////////////////////

            ' Create a new Auth Transaction.
            Dim Trans As Transactions.AuthorizationTransaction = New Transactions.AuthorizationTransaction(User, Connection, Inv, Card, Common.Utility.PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                pmrResponse.ResponseMessage = TrxnResponse.RespMsg
                ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                Dim TransCtx As Context = Resp.TransactionContext
                If TransCtx IsNot Nothing AndAlso TransCtx.getErrorCount() > 0 OrElse TrxnResponse.AuthCode = String.Empty Then
                    pmrResponse.ResponseType = PaymentResponse.ResponseTypes.AuthorizationError
                    
                Else
                    ' try to capture the funds
                    pmrResponse.PNRef = TrxnResponse.Pnref
                    ' If you want to change the amount being captured, you'll need to set the Amount object.
                    ' Dim Inv As Invoice = New Invoice
                    ' Set the amount object if you want to change the amount from the original authorization.
                    ' Currency Code USD is US ISO currency code.  If no code passed, USD is default.
                    ' See the Developer's Guide for the list of three-character currency codes available.
                    ' Dim Amt As New Currency(New Decimal(15.0), "USD")
                    ' Inv.Amt = Amt
                    ' Dim Trans As CaptureTransaction = New CaptureTransaction("<ORIGINAL_PNREF>", User, Connection, Inv, PayflowUtility.RequestId)

                    ' Create a new Capture Transaction for the original amount of the authorization.  See above if you
                    ' need to change the amount.
                    Dim CapTrans As Transactions.CaptureTransaction = New Transactions.CaptureTransaction(TrxnResponse.Pnref, User, Connection, Utility.PayflowUtility.RequestId)

                    ' Indicates if this Delayed Capture transaction is the last capture you intend to make.
                    ' The values are: Y (default) / N
                    ' NOTE: If CAPTURECOMPLETE is Y, any remaining amount of the original reauthorized transaction
                    ' is automatically voided.  Also, this is only used for UK and US accounts where PayPal is acting
                    ' as your bank.
                    ' Trans.CaptureComplete = "Y"

                    ' Submit the transaction.
                    Dim CapResp As Response = Trans.SubmitTransaction()
                    If Not CapResp Is Nothing Then
                        ' Get the Transaction Response parameters.
                        TrxnResponse = CapResp.TransactionResponse
                        ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                        TransCtx = CapResp.TransactionContext
                        
                        If TransCtx Is Nothing OrElse (TransCtx.getErrorCount() > 0) OrElse TrxnResponse.RespMsg <> "Approved" Then
                            pmrResponse.ResponseType = PaymentResponse.ResponseTypes.CaptureError
                            pmrResponse.ResponseMessage = TrxnResponse.RespMsg
                            
                        Else
                            pmrResponse.ResponseType = PaymentResponse.ResponseTypes.Success
                            pmrResponse.AuthorizationNumber =  TrxnResponse.AuthCode
                        End If
                    End If



                End If

            End If

        Catch ex As Exception
            pmrResponse.ResponseType = PaymentResponse.ResponseTypes.OtherError
            pmrResponse.ResponseMessage = ex.Message
        End Try

        Return pmrResponse
    End Function
  

End Class
