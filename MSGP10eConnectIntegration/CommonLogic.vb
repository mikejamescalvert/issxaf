Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP
Imports System.Data.SqlClient

Friend Class CommonLogic
    Public Enum DocNumberTypes
        IVTransfer
        IVAdjustment
        GLJournalEntry
        POPReceipt
        SOPDocument
        ARInvoice
        PMVoucherNumber
    End Enum
    Public Shared Function GetDocNumber(ByVal MSGPConnectionString As String, ByVal NumberType As DocNumberTypes, Optional ByVal SopDocumentType As SOP.SOPOrder.SopTypes = SOP.SOPOrder.SopTypes.Order, Optional ByVal SopDocumentTypeId As String = "") As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.MiscRoutines.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        Select Case NumberType
            Case DocNumberTypes.IVTransfer
                ReturnDocNo = NextDocNumber.GetNextIVNumber(eConnect.MiscRoutines.GetNextDocNumbers.IncrementDecrement.Increment, eConnect.MiscRoutines.GetNextDocNumbers.IVDocType.IVTransfer, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.IVAdjustment
                ReturnDocNo = NextDocNumber.GetNextIVNumber(eConnect.MiscRoutines.GetNextDocNumbers.IncrementDecrement.Increment, eConnect.MiscRoutines.GetNextDocNumbers.IVDocType.IVAdjustment, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.GLJournalEntry
                ReturnDocNo = NextDocNumber.GetNextGLJournalEntryNumber(Microsoft.Dynamics.GP.eConnect.MiscRoutines.GetNextDocNumbers.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.POPReceipt
                ReturnDocNo = NextDocNumber.GetNextPOPReceiptNumber(Microsoft.Dynamics.GP.eConnect.MiscRoutines.GetNextDocNumbers.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.SOPDocument
                ReturnDocNo = NextDocNumber.GetNextSOPNumber(Microsoft.Dynamics.GP.eConnect.MiscRoutines.GetNextDocNumbers.IncrementDecrement.Increment, SopDocumentTypeId, SopDocumentType, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.PMVoucherNumber
                ReturnDocNo = NextDocNumber.GetPMNextVoucherNumber(Microsoft.Dynamics.GP.eConnect.MiscRoutines.GetNextDocNumbers.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
        End Select
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function
    ''' <summary>
    ''' Processes eConnect Serialization objects and return success or failure
    ''' </summary>
    ''' <param name="MSGPConnectionString"></param>
    ''' <param name="eConnectSerializationObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function eConnectCreate(ByVal MSGPConnectionString As String, ByVal eConnectSerializationObject As Object) As Boolean
        Dim eConnect As New eConnect.Serialization.eConnectType
        Dim eConCall As New eConnect.eConnectMethods
        'Dim XMLStream As New FileStream("Temp.xml", FileMode.Create)
        'Dim XMLStream As New System.IO.MemoryStream
        'Dim Writer As New XmlTextWriter(XMLStream, New UTF8Encoding)
        'Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.MiscRoutines.GetNextDocNumbers
        Dim blneConnectResult As Boolean

        Dim Serializer As New XmlSerializer(GetType(eConnect.Serialization.eConnectType))
        'Dim XmlDoc As New Xml.XmlDocument
        Dim msmMemoryStream As New MemoryStream
        Dim xmtXmlTextWriter As XmlTextWriter = New XmlTextWriter(msmMemoryStream, New UTF8Encoding)
        Dim strXmlAsString As String
        Try
            eConnect = New eConnect.Serialization.eConnectType

            Select Case eConnectSerializationObject.GetType.FullName
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.BRBankTransactionType"
                    ReDim eConnect.BRBankTransactionType(0)
                    eConnect.BRBankTransactionType(0) = eConnectSerializationObject
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.GLTransactionType"
                    ReDim eConnect.GLTransactionType(0)
                    Dim GLTrx As eConnect.Serialization.GLTransactionType = eConnectSerializationObject
                    Dim GLTrxHdr As eConnect.Serialization.taGLTransactionHeaderInsert = GLTrx.taGLTransactionHeaderInsert
                    Dim GLTrxLines() As eConnect.Serialization.taGLTransactionLineInsert_ItemsTaGLTransactionLineInsert = GLTrx.taGLTransactionLineInsert_Items

                    For Each GLTrxLine As eConnect.Serialization.taGLTransactionLineInsert_ItemsTaGLTransactionLineInsert In GLTrxLines
                        GLTrxLine.JRNENTRY = GLTrxHdr.JRNENTRY
                    Next
                    eConnect.GLTransactionType(0) = GLTrx
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.IVInventoryTransferType"
                    ReDim eConnect.IVInventoryTransferType(0)
                    eConnect.IVInventoryTransferType(0) = eConnectSerializationObject
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.IVItemMasterType"
                    ReDim eConnect.IVItemMasterType(0)
                    eConnect.IVItemMasterType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.IVInventoryTransactionType"
                    ReDim eConnect.IVInventoryTransactionType(0)
                    eConnect.IVInventoryTransactionType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.POPReceivingsType"
                    ReDim eConnect.POPReceivingsType(0)
                    eConnect.POPReceivingsType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.PMTransactionType"
                    ReDim eConnect.PMTransactionType(0)
                    eConnect.PMTransactionType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType"
                    ReDim eConnect.SOPTransactionType(0)
                    eConnect.SOPTransactionType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMCashReceiptsType"
                    ReDim eConnect.RMCashReceiptsType(0)
                    eConnect.RMCashReceiptsType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMApplyType"
                    ReDim eConnect.RMApplyType(0)
                    eConnect.RMApplyType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.CMPInternetAddressType"
                    ReDim eConnect.CMPInternetAddressType(0)
                    eConnect.CMPInternetAddressType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMCustomerMasterType"
                    ReDim eConnect.RMCustomerMasterType(0)
                    eConnect.RMCustomerMasterType(0) = eConnectSerializationObject

                Case Else
                    Throw New Exception("Object type not an accepted eConnect object")
            End Select

            xmtXmlTextWriter.Formatting = Formatting.Indented
            xmtXmlTextWriter.IndentChar = " "
            xmtXmlTextWriter.Indentation = 5

            Serializer.Serialize(xmtXmlTextWriter, eConnect)
            strXmlAsString = ASCIIEncoding.UTF8.GetString(msmMemoryStream.ToArray())
            xmtXmlTextWriter.Close()
            blneConnectResult = eConCall.eConnect_EntryPoint(GetSSPIConnectionString(MSGPConnectionString), Microsoft.Dynamics.GP.eConnect.EnumTypes.ConnectionStringType.SqlClient, strXmlAsString, Microsoft.Dynamics.GP.eConnect.EnumTypes.SchemaValidationType.None)

            Return blneConnectResult
        Catch ex As Exception
            Throw ex
        Finally
            xmtXmlTextWriter.Close()
        End Try

    End Function

    Public Shared Function GetSSPIConnectionString(ConnectionString As String) As String
        Dim csb As SqlConnectionStringBuilder = New SqlConnectionStringBuilder()
        csb.ConnectionString = ConnectionString
        csb.IntegratedSecurity = True
        csb.Remove("User Id")
        csb.Remove("Password")
        Return csb.ConnectionString
    End Function

End Class
