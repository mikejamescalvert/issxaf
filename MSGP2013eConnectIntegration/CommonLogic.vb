Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP
Imports Microsoft.Dynamics.GP.eConnect.Serialization
Imports System.Data.SqlClient

Public Class CommonLogic

    Public Enum DocNumberTypes
        IVTransfer
        IVAdjustment
        GLJournalEntry
        POPReceipt
        SOPDocument
        ARInvoice
        PMVoucherNumber
    End Enum
    Private Enum eConnectMethodTypes
        None = 0
        CreateTransaction = 1
        CreateEntity = 2

    End Enum
    <Obsolete("Next Doc Number methods have been implemented as individual calls - USE THOSE IMPLEMENTATIONS INSTEAD")>
    Public Shared Function GetDocNumber(ByVal MSGPConnectionString As String, ByVal NumberType As DocNumberTypes, Optional ByVal SopDocumentType As SOP.SOPOrder.SopTypes = SOP.SOPOrder.SopTypes.Order, Optional ByVal SopDocumentTypeId As String = "") As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        Select Case NumberType
            Case DocNumberTypes.IVTransfer
                ReturnDocNo = NextDocNumber.GetNextIVNumber(eConnect.IncrementDecrement.Increment, eConnect.IVDocType.IVTransfer, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.IVAdjustment
                ReturnDocNo = NextDocNumber.GetNextIVNumber(eConnect.IncrementDecrement.Increment, eConnect.IVDocType.IVAdjustment, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.GLJournalEntry
                ReturnDocNo = NextDocNumber.GetNextGLJournalEntryNumber(eConnect.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.POPReceipt
                ReturnDocNo = NextDocNumber.GetNextPOPReceiptNumber(eConnect.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.SOPDocument
                ReturnDocNo = NextDocNumber.GetNextSOPNumber(eConnect.IncrementDecrement.Increment, SopDocumentTypeId, SopDocumentType, GetSSPIConnectionString(MSGPConnectionString))
            Case DocNumberTypes.PMVoucherNumber
                ReturnDocNo = NextDocNumber.GetPMNextVoucherNumber(eConnect.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
        End Select
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function

    Public Shared Function GetNextPMVoucherNumber(ByVal MSGPConnectionString As String) As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        ReturnDocNo = NextDocNumber.GetPMNextVoucherNumber(eConnect.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function

    Public Shared Function GetNextGLJournalEntryNumber(ByVal MSGPConnectionString As String) As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        ReturnDocNo = NextDocNumber.GetNextGLJournalEntryNumber(eConnect.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function



    Public Shared Function GetNextIVAdjustmentDocNumber(ByVal MSGPConnectionString As String) As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        ReturnDocNo = NextDocNumber.GetNextIVNumber(eConnect.IncrementDecrement.Increment, eConnect.IVDocType.IVAdjustment, GetSSPIConnectionString(MSGPConnectionString))
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function

    Public Shared Function GetNextIVTransferDocNumber(ByVal MSGPConnectionString As String) As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        ReturnDocNo = NextDocNumber.GetNextIVNumber(eConnect.IncrementDecrement.Increment, eConnect.IVDocType.IVTransfer, GetSSPIConnectionString(MSGPConnectionString))
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function

    Public Shared Function GetNextPOPReceiptDocNumber(ByVal MSGPConnectionString As String) As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        ReturnDocNo = NextDocNumber.GetNextPOPReceiptNumber(eConnect.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function

    Public Shared Function GetNextPOPPurchaseOrderDocNumber(ByVal MSGPConnectionString As String) As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        ReturnDocNo = NextDocNumber.GetNextPONumber(eConnect.IncrementDecrement.Increment, GetSSPIConnectionString(MSGPConnectionString))
        'kill the next doc number object due to connection problems per MSGP Support
        Return ReturnDocNo
        NextDocNumber.Dispose()
        NextDocNumber = Nothing
    End Function

    Public Shared Function GetNextSOPDocNumber(ByVal MSGPConnectionString As String, ByVal SopDocumentType As SOP.SOPDocTypes, Optional ByVal SopDocumentTypeId As String = "") As String
        Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.GetNextDocNumbers
        Dim ReturnDocNo As String = String.Empty
        ReturnDocNo = NextDocNumber.GetNextSOPNumber(eConnect.IncrementDecrement.Increment, SopDocumentTypeId, SopDocumentType, GetSSPIConnectionString(MSGPConnectionString))
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
        Dim eConnectMethodType As eConnectMethodTypes = eConnectMethodTypes.None
        Dim eConnect As New eConnect.Serialization.eConnectType
        Dim eConCall As New eConnect.eConnectMethods
        'Dim XMLStream As New FileStream("Temp.xml", FileMode.Create)
        'Dim XMLStream As New System.IO.MemoryStream
        'Dim Writer As New XmlTextWriter(XMLStream, New UTF8Encoding)
        'Dim NextDocNumber As New Microsoft.Dynamics.GP.eConnect.MiscRoutines.GetNextDocNumbers
        Dim streConnectResult As String
        Dim blneConnectResult As Boolean

        Dim Serializer As New XmlSerializer(GetType(eConnect.Serialization.eConnectType))
        'Dim XmlDoc As New Xml.XmlDocument
        Dim msmMemoryStream As New MemoryStream
        Dim xmtXmlTextWriter As XmlTextWriter = New XmlTextWriter(msmMemoryStream, New UTF8Encoding)
        Dim strXmlAsString As String
        Try
            eConnect = New eConnect.Serialization.eConnectType

            Select Case eConnectSerializationObject.GetType.FullName
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMTerritoryMasterType"
                    ReDim eConnect.RMTerritoryMasterType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateEntity
                    eConnect.RMTerritoryMasterType(0) = eConnectSerializationObject
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.BRBankDepositsType"
                    ReDim eConnect.BRBankDepositsType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.BRBankDepositsType(0) = eConnectSerializationObject
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.BRBankTransactionType"
                    ReDim eConnect.BRBankTransactionType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.BRBankTransactionType(0) = eConnectSerializationObject
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.GLTransactionType"
                    ReDim eConnect.GLTransactionType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    Dim GLTrx As eConnect.Serialization.GLTransactionType = eConnectSerializationObject
                    Dim GLTrxHdr As eConnect.Serialization.taGLTransactionHeaderInsert = GLTrx.taGLTransactionHeaderInsert
                    Dim GLTrxLines() As eConnect.Serialization.taGLTransactionLineInsert_ItemsTaGLTransactionLineInsert = GLTrx.taGLTransactionLineInsert_Items

                    For Each GLTrxLine As eConnect.Serialization.taGLTransactionLineInsert_ItemsTaGLTransactionLineInsert In GLTrxLines
                        GLTrxLine.JRNENTRY = GLTrxHdr.JRNENTRY
                    Next
                    eConnect.GLTransactionType(0) = GLTrx
                Case "Microsoft.Dynamics.GP.eConnect.Serialization.IVInventoryTransferType"
                    ReDim eConnect.IVInventoryTransferType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.IVInventoryTransferType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.IVInventoryTransactionType"
                    ReDim eConnect.IVInventoryTransactionType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.IVInventoryTransactionType(0) = eConnectSerializationObject


                Case "Microsoft.Dynamics.GP.eConnect.Serialization.IVVendorItemType"
                    ReDim eConnect.IVVendorItemType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.IVVendorItemType(0) = eConnectSerializationObject


                Case "Microsoft.Dynamics.GP.eConnect.Serialization.POPReceivingsType"
                    ReDim eConnect.POPReceivingsType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.POPReceivingsType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.PMTransactionType"
                    ReDim eConnect.PMTransactionType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.PMTransactionType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.PMVendorMasterType"
                    ReDim eConnect.PMVendorMasterType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.PMVendorMasterType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.SOPTransactionType"
                    ReDim eConnect.SOPTransactionType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.SOPTransactionType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMCashReceiptsType"
                    ReDim eConnect.RMCashReceiptsType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.RMCashReceiptsType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMApplyType"
                    ReDim eConnect.RMApplyType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateTransaction
                    eConnect.RMApplyType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.CMPInternetAddressType"
                    ReDim eConnect.CMPInternetAddressType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateEntity
                    eConnect.CMPInternetAddressType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMCustomerMasterType"
                    ReDim eConnect.RMCustomerMasterType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateEntity
                    eConnect.RMCustomerMasterType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMCustomerAddressType"
                    ReDim eConnect.RMCustomerAddressType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateEntity
                    eConnect.RMCustomerAddressType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMCreateParentIDType"
                    ReDim eConnect.RMCreateParentIDType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateEntity
                    eConnect.RMCreateParentIDType(0) = eConnectSerializationObject

                Case "Microsoft.Dynamics.GP.eConnect.Serialization.RMParentIDChildType"
                    ReDim eConnect.RMParentIDChildType(0)
                    eConnectMethodType = eConnectMethodTypes.CreateEntity
                    eConnect.RMParentIDChildType(0) = eConnectSerializationObject

                Case Else

                    Throw New Exception("Object type not an accepted eConnect object")
            End Select

            xmtXmlTextWriter.Formatting = Formatting.Indented
            xmtXmlTextWriter.IndentChar = " "
            xmtXmlTextWriter.Indentation = 5

            Serializer.Serialize(xmtXmlTextWriter, eConnect)
            strXmlAsString = ASCIIEncoding.UTF8.GetString(msmMemoryStream.ToArray())
            xmtXmlTextWriter.Close()
            If eConnectMethodType = eConnectMethodTypes.CreateTransaction Then
                streConnectResult = eConCall.CreateTransactionEntity(GetSSPIConnectionString(MSGPConnectionString), strXmlAsString)
            ElseIf eConnectMethodType = eConnectMethodTypes.CreateEntity Then
                streConnectResult = eConCall.CreateEntity(GetSSPIConnectionString(MSGPConnectionString), strXmlAsString)
            End If
            Return True

        Catch ex As Exception
            Throw ex
        Finally
            xmtXmlTextWriter.Close()
        End Try

    End Function

    ''' <summary>
    ''' Retrieves the GP object defined in the request (thisRequest As eConnectOut)
    ''' See eConnectOut XML Node Reference
    ''' </summary>
    ''' <param name="MSGPConnectionString"></param>
    ''' <param name="thisRequest">See eConnectOut XML Node Reference</param>
    ''' <returns>serialized object(s) from GP</returns>
    ''' <remarks></remarks>
    Public Shared Function eConnect_GetEntity(ByVal MSGPConnectionString As String, ByVal thisRequest As eConnectOut) As Xml.XmlDocument
        Dim eGetEntityResult As New Xml.XmlDocument
        Dim eConCall As New eConnect.eConnectMethods

        Dim eConnectOutType() As RQeConnectOutType
        ReDim eConnectOutType(0)
        eConnectOutType(0) = New RQeConnectOutType
        eConnectOutType(0).eConnectOut = thisRequest

        Dim eConnectDoc As New eConnectType
        eConnectDoc.RQeConnectOutType = eConnectOutType

        Dim mem As New MemoryStream
        Dim ser As New XmlSerializer(GetType(eConnectType))
        ser.Serialize(mem, eConnectDoc)
        mem.Position = 0
        Dim requestDoc As New XmlDocument
        requestDoc.Load(mem)

        ser = Nothing
        mem = Nothing

        eGetEntityResult.LoadXml(eConCall.GetEntity(GetSSPIConnectionString(MSGPConnectionString), requestDoc.OuterXml))

        eConCall = Nothing
        eConnectDoc = Nothing

        Return eGetEntityResult
    End Function

    ''' <summary>
    ''' Update the GP Entity
    ''' </summary>
    ''' <param name="MSGPConnectionString"></param>
    ''' <param name="thisEntity">Serialized GP Object retrieved via GetEntity</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function eConnect_UpdateTransactionEntity(ByVal MSGPConnectionString As String, ByVal thisEntity As XmlDocument) As Boolean
        Dim bolReturn As Boolean = False
        Dim eConCall As New eConnect.eConnectMethods
        bolReturn = eConCall.UpdateTransactionEntity(MSGPConnectionString, thisEntity.OuterXml)
        eConCall = Nothing
        Return bolReturn
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
