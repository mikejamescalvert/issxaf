Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.RM.Helpers
    Public Class CustomerHelper
        Public Shared Function GetEncryptedCard(ByVal RawCard As String, ByVal MasterDBConnectionString As String) As String
            Dim sqcConnection As New SqlClient.SqlConnection(MasterDBConnectionString)
            Dim scmCommand As New SqlClient.SqlCommand
            Dim sdrDataReader As SqlClient.SqlDataReader
            Dim strCard As String = String.Empty
            sqcConnection.Open()
            scmCommand.Connection = sqcConnection
            scmCommand.CommandText = "xp_NodusEncrypt"
            scmCommand.CommandType = CommandType.StoredProcedure
            RawCard = RawCard.Replace("-", "").Trim.Replace(" ", "")
            scmCommand.Parameters.AddWithValue("data", RawCard)
            scmCommand.Parameters.Add("encryptedData", SqlDbType.NVarChar, 4000)
            scmCommand.Parameters.Add("maskedData", SqlDbType.NVarChar, 4000)

            scmCommand.Parameters(1).Direction = ParameterDirection.Output
            scmCommand.Parameters(2).Direction = ParameterDirection.Output

            scmCommand.ExecuteNonQuery()


            strCard = scmCommand.Parameters(1).Value
            Return strCard
            'exec(xp_NodusEncrypt) '0000000000000000', @txtE OUTPUT, @txtO OUTPUT
        End Function
        Public Shared Sub UpdateCustomerCCInformation(ByVal CustomerID As String, ByVal CardID As String, ByVal CreditCardNumber As String, ByVal CreditCardExpirationDate As DateTime, ByVal UpdateNodusTables As Boolean, ByVal GPConnectionString As String, ByVal MasterDBConnectionString As String)
            Dim cstCustomer As RMCustomer
            Dim sshSession As New Session
            Dim ncmCreditCardMaster As MS.MSNodusCreditCardMaster
            Dim gpoGroupOperator As New GroupOperator
            Dim strEncryptedCard As String
            sshSession.ConnectionString = GPConnectionString
            If sshSession.IsConnected = False Then
                sshSession.Connect()
            End If
            cstCustomer = sshSession.GetObjectByKey(Of RMCustomer)(CustomerID)
            If cstCustomer IsNot Nothing Then
                cstCustomer.CRCARDID = CardID
                cstCustomer.CRCRDNUM = CreditCardNumber
                cstCustomer.CCRDXPDT = CreditCardExpirationDate
                cstCustomer.Save()
            Else
                Throw New Exception("Customer Does Not Exist")
            End If
            If UpdateNodusTables = True Then
                strEncryptedCard = GetEncryptedCard(CreditCardNumber, MasterDBConnectionString)
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.CUSTNMBR", CustomerID))
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.MSO_CardNumberPABP", strEncryptedCard))

                ncmCreditCardMaster = sshSession.FindObject(Of MS.MSNodusCreditCardMaster)(gpoGroupOperator)
                If ncmCreditCardMaster Is Nothing Then
                    ncmCreditCardMaster = New MS.MSNodusCreditCardMaster(sshSession)



                    ncmCreditCardMaster.ADDRESS1 = ""
                    ncmCreditCardMaster.ADDRESS2 = ""
                    ncmCreditCardMaster.ADDRESS3 = ""
                    ncmCreditCardMaster.ADRSCODE = ""
                    ncmCreditCardMaster.CITY = ""
                    ncmCreditCardMaster.COUNTRY = ""
                    ncmCreditCardMaster.EMail = ""
                    ncmCreditCardMaster.FRSTNAME = ""
                    ncmCreditCardMaster.LASTNAME = ""
                    ncmCreditCardMaster.MIDLNAME = ""
                    ncmCreditCardMaster.MSO_ABA = ""
                    ncmCreditCardMaster.MSO_ACCT = ""
                    ncmCreditCardMaster.MSO_AcctType = ""
                    ncmCreditCardMaster.MSO_BankName = ""
                    ncmCreditCardMaster.MSO_CardName = ""
                    ncmCreditCardMaster.MSO_CardType = ""
                    ncmCreditCardMaster.MSO_Check_Number = ""
                    ncmCreditCardMaster.MSO_COMMENT1 = ""
                    ncmCreditCardMaster.MSO_COMMENT2 = ""
                    ncmCreditCardMaster.MSO_COMMENT3 = ""
                    ncmCreditCardMaster.MSO_COMMENT4 = ""
                    ncmCreditCardMaster.MSO_COMMENT5 = ""
                    ncmCreditCardMaster.MSO_DateOfBirth = "1/1/1900"
                    ncmCreditCardMaster.MSO_DESC_PABP = ""
                    ncmCreditCardMaster.MSO_DESC1_PABP = ""
                    ncmCreditCardMaster.MSO_DESC2_PABP = ""
                    ncmCreditCardMaster.MSO_DESC3_PABP = ""
                    ncmCreditCardMaster.MSO_DESC4_PABP = ""
                    ncmCreditCardMaster.MSO_DLicense = ""
                    ncmCreditCardMaster.MSO_Issue_Number = ""
                    ncmCreditCardMaster.MSO_SSN = ""
                    ncmCreditCardMaster.MSO_Start_Date = ""
                    ncmCreditCardMaster.PHONNAME = ""
                    ncmCreditCardMaster.STATE = ""
                    ncmCreditCardMaster.ZIPCODE = ""

                    ncmCreditCardMaster.Oid = New MS.MSNodusCreditCardMaster.NodusCreditCardMasterKey(CustomerID, strEncryptedCard, String.Format("{0}{1}", CreditCardExpirationDate.Month.ToString.PadLeft(2, "0"), CreditCardExpirationDate.Year.ToString.Substring(2)))
                    ncmCreditCardMaster.MSO_Start_Date = Today.Month.ToString.PadLeft(2, "0") + Today.Year.ToString.Substring(2)
                    If CardID > String.Empty Then
                        ncmCreditCardMaster.MSO_CardName = CardID
                    End If
                    ncmCreditCardMaster.Save()
                End If
            End If
            
        End Sub
    End Class
End Namespace
