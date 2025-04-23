Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.ComponentModel

Namespace Objects.POP
    ''' <summary>
    ''' GP Table POP10110
    ''' </summary>
    <Persistent("POP10110")>
    <DefaultProperty("ITEMNMBR")>
    Public Class POPLine
        Inherits XPLiteObject

        Public Structure POLineKey
            Private fPONUMBER As String
            <Size(17)>
            <Persistent("PONUMBER")>
            Public Property PONUMBER() As String
                Get
                    Return fPONUMBER
                End Get
                Set(ByVal value As String)
                    fPONUMBER = value
                End Set
            End Property
            Private fORD As Integer
            <Persistent("ORD")>
            Public Property ORD() As Integer
                Get
                    Return fORD
                End Get
                Set(ByVal value As Integer)
                    fORD = value
                End Set
            End Property
            Private fBRKFLD1 As Short
            <Persistent("BRKFLD1")>
            Public Property BRKFLD1() As Short
                Get
                    Return fBRKFLD1
                End Get
                Set(ByVal value As Short)
                    fBRKFLD1 = value
                End Set
            End Property
        End Structure

        Dim fOid As POLineKey
        <Key()>
        <Persistent()>
        Public Property Oid() As POLineKey
            Get
                Return fOid
            End Get
            Set(ByVal value As POLineKey)
                SetPropertyValue(Of POLineKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fPOLNESTA As Short
        Public Property POLNESTA() As Short
            Get
                Return fPOLNESTA
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POLNESTA", fPOLNESTA, value)
            End Set
        End Property
        Dim fPOTYPE As Short
        Public Property POTYPE() As Short
            Get
                Return fPOTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POTYPE", fPOTYPE, value)
            End Set
        End Property
        Dim fITEMNMBR As String
        <Size(31)>
        Public Property ITEMNMBR() As String
            Get
                Return fITEMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
            End Set
        End Property
        Dim fITEMDESC As String
        <Size(101)>
        Public Property ITEMDESC() As String
            Get
                Return fITEMDESC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMDESC", fITEMDESC, value)
            End Set
        End Property
        Dim fVENDORID As String
        <Size(15)>
        Public Property VENDORID() As String
            Get
                Return fVENDORID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDORID", fVENDORID, value)
            End Set
        End Property
        Dim fVNDITNUM As String
        <Size(31)>
        Public Property VNDITNUM() As String
            Get
                Return fVNDITNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDITNUM", fVNDITNUM, value)
            End Set
        End Property
        Dim fVNDITDSC As String
        <Size(101)>
        Public Property VNDITDSC() As String
            Get
                Return fVNDITDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDITDSC", fVNDITDSC, value)
            End Set
        End Property
        Dim fNONINVEN As Short
        Public Property NONINVEN() As Short
            Get
                Return fNONINVEN
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("NONINVEN", fNONINVEN, value)
            End Set
        End Property
        Dim fLOCNCODE As String
        <Size(11)>
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
            End Set
        End Property
        Dim fUOFM As String
        <Size(9)>
        Public Property UOFM() As String
            Get
                Return fUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOFM", fUOFM, value)
            End Set
        End Property
        Dim fUMQTYINB As Decimal
        Public Property UMQTYINB() As Decimal
            Get
                Return fUMQTYINB
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UMQTYINB", fUMQTYINB, value)
            End Set
        End Property
        Dim fQTYORDER As Decimal
        Public Property QTYORDER() As Decimal
            Get
                Return fQTYORDER
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYORDER", fQTYORDER, value)
            End Set
        End Property
        Dim fQTYCANCE As Decimal
        Public Property QTYCANCE() As Decimal
            Get
                Return fQTYCANCE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYCANCE", fQTYCANCE, value)
            End Set
        End Property
        Dim fQTYCMTBASE As Decimal
        Public Property QTYCMTBASE() As Decimal
            Get
                Return fQTYCMTBASE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYCMTBASE", fQTYCMTBASE, value)
            End Set
        End Property
        Dim fQTYUNCMTBASE As Decimal
        Public Property QTYUNCMTBASE() As Decimal
            Get
                Return fQTYUNCMTBASE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYUNCMTBASE", fQTYUNCMTBASE, value)
            End Set
        End Property
        Dim fUNITCOST As Decimal
        Public Property UNITCOST() As Decimal
            Get
                Return fUNITCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UNITCOST", fUNITCOST, value)
            End Set
        End Property
        Dim fEXTDCOST As Decimal
        Public Property EXTDCOST() As Decimal
            Get
                Return fEXTDCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("EXTDCOST", fEXTDCOST, value)
            End Set
        End Property
        Dim fINVINDX As Integer
        Public Property INVINDX() As Integer
            Get
                Return fINVINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("INVINDX", fINVINDX, value)
            End Set
        End Property
        Dim fREQDATE As DateTime
        Public Property REQDATE() As DateTime
            Get
                Return fREQDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("REQDATE", fREQDATE, value)
            End Set
        End Property
        Dim fPRMDATE As DateTime
        Public Property PRMDATE() As DateTime
            Get
                Return fPRMDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("PRMDATE", fPRMDATE, value)
            End Set
        End Property
        Dim fPRMSHPDTE As DateTime
        Public Property PRMSHPDTE() As DateTime
            Get
                Return fPRMSHPDTE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("PRMSHPDTE", fPRMSHPDTE, value)
            End Set
        End Property
        Dim fREQSTDBY As String
        <Size(21)>
        Public Property REQSTDBY() As String
            Get
                Return fREQSTDBY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REQSTDBY", fREQSTDBY, value)
            End Set
        End Property
        Dim fCOMMNTID As String
        <Size(15)>
        Public Property COMMNTID() As String
            Get
                Return fCOMMNTID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMNTID", fCOMMNTID, value)
            End Set
        End Property
        Dim fDOCTYPE As Short
        Public Property DOCTYPE() As Short
            Get
                Return fDOCTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DOCTYPE", fDOCTYPE, value)
            End Set
        End Property
        Dim fPOLNEARY_1 As Decimal
        Public Property POLNEARY_1() As Decimal
            Get
                Return fPOLNEARY_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_1", fPOLNEARY_1, value)
            End Set
        End Property
        Dim fPOLNEARY_2 As Decimal
        Public Property POLNEARY_2() As Decimal
            Get
                Return fPOLNEARY_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_2", fPOLNEARY_2, value)
            End Set
        End Property
        Dim fPOLNEARY_3 As Decimal
        Public Property POLNEARY_3() As Decimal
            Get
                Return fPOLNEARY_3
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_3", fPOLNEARY_3, value)
            End Set
        End Property
        Dim fPOLNEARY_4 As Decimal
        Public Property POLNEARY_4() As Decimal
            Get
                Return fPOLNEARY_4
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_4", fPOLNEARY_4, value)
            End Set
        End Property
        Dim fPOLNEARY_5 As Decimal
        Public Property POLNEARY_5() As Decimal
            Get
                Return fPOLNEARY_5
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_5", fPOLNEARY_5, value)
            End Set
        End Property
        Dim fPOLNEARY_6 As Decimal
        Public Property POLNEARY_6() As Decimal
            Get
                Return fPOLNEARY_6
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_6", fPOLNEARY_6, value)
            End Set
        End Property
        Dim fPOLNEARY_7 As Decimal
        Public Property POLNEARY_7() As Decimal
            Get
                Return fPOLNEARY_7
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_7", fPOLNEARY_7, value)
            End Set
        End Property
        Dim fPOLNEARY_8 As Decimal
        Public Property POLNEARY_8() As Decimal
            Get
                Return fPOLNEARY_8
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_8", fPOLNEARY_8, value)
            End Set
        End Property
        Dim fPOLNEARY_9 As Decimal
        Public Property POLNEARY_9() As Decimal
            Get
                Return fPOLNEARY_9
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("POLNEARY_9", fPOLNEARY_9, value)
            End Set
        End Property
        Dim fDECPLCUR As Short
        Public Property DECPLCUR() As Short
            Get
                Return fDECPLCUR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLCUR", fDECPLCUR, value)
            End Set
        End Property
        Dim fDECPLQTY As Short
        Public Property DECPLQTY() As Short
            Get
                Return fDECPLQTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLQTY", fDECPLQTY, value)
            End Set
        End Property
        Dim fITMTRKOP As Short
        Public Property ITMTRKOP() As Short
            Get
                Return fITMTRKOP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ITMTRKOP", fITMTRKOP, value)
            End Set
        End Property
        Dim fVCTNMTHD As Short
        Public Property VCTNMTHD() As Short
            Get
                Return fVCTNMTHD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("VCTNMTHD", fVCTNMTHD, value)
            End Set
        End Property

        Dim fPO_Line_Status_Orig As Short
        Public Property PO_Line_Status_Orig() As Short
            Get
                Return fPO_Line_Status_Orig
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PO_Line_Status_Orig", fPO_Line_Status_Orig, value)
            End Set
        End Property
        Dim fQTY_Canceled_Orig As Decimal
        Public Property QTY_Canceled_Orig() As Decimal
            Get
                Return fQTY_Canceled_Orig
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTY_Canceled_Orig", fQTY_Canceled_Orig, value)
            End Set
        End Property
        Dim fOPOSTSUB As Decimal
        Public Property OPOSTSUB() As Decimal
            Get
                Return fOPOSTSUB
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OPOSTSUB", fOPOSTSUB, value)
            End Set
        End Property
        Dim fJOBNUMBR As String
        <Size(17)>
        Public Property JOBNUMBR() As String
            Get
                Return fJOBNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("JOBNUMBR", fJOBNUMBR, value)
            End Set
        End Property
        Dim fCOSTCODE As String
        <Size(27)>
        Public Property COSTCODE() As String
            Get
                Return fCOSTCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COSTCODE", fCOSTCODE, value)
            End Set
        End Property
        Dim fCOSTTYPE As Short
        Public Property COSTTYPE() As Short
            Get
                Return fCOSTTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("COSTTYPE", fCOSTTYPE, value)
            End Set
        End Property
        Dim fCURNCYID As String
        <Size(15)>
        Public Property CURNCYID() As String
            Get
                Return fCURNCYID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CURNCYID", fCURNCYID, value)
            End Set
        End Property
        Dim fCURRNIDX As Short
        Public Property CURRNIDX() As Short
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CURRNIDX", fCURRNIDX, value)
            End Set
        End Property
        Dim fXCHGRATE As Decimal
        Public Property XCHGRATE() As Decimal
            Get
                Return fXCHGRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("XCHGRATE", fXCHGRATE, value)
            End Set
        End Property
        Dim fRATECALC As Short
        Public Property RATECALC() As Short
            Get
                Return fRATECALC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RATECALC", fRATECALC, value)
            End Set
        End Property
        Dim fDENXRATE As Decimal
        Public Property DENXRATE() As Decimal
            Get
                Return fDENXRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DENXRATE", fDENXRATE, value)
            End Set
        End Property
        Dim fORUNTCST As Decimal
        Public Property ORUNTCST() As Decimal
            Get
                Return fORUNTCST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORUNTCST", fORUNTCST, value)
            End Set
        End Property
        Dim fOREXTCST As Decimal
        Public Property OREXTCST() As Decimal
            Get
                Return fOREXTCST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OREXTCST", fOREXTCST, value)
            End Set
        End Property
        Dim fLINEORIGIN As Short
        Public Property LINEORIGIN() As Short
            Get
                Return fLINEORIGIN
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LINEORIGIN", fLINEORIGIN, value)
            End Set
        End Property
        Dim fFREEONBOARD As POPGlobals.FOBTypes
        Public Property FREEONBOARD() As POPGlobals.FOBTypes
            Get
                Return fFREEONBOARD
            End Get
            Set(ByVal value As POPGlobals.FOBTypes)
                SetPropertyValue(Of Short)("FREEONBOARD", fFREEONBOARD, value)
            End Set
        End Property
        Dim fODECPLCU As Short
        Public Property ODECPLCU() As Short
            Get
                Return fODECPLCU
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ODECPLCU", fODECPLCU, value)
            End Set
        End Property
        Dim fCapital_Item As Byte
        Public Property Capital_Item() As Byte
            Get
                Return fCapital_Item
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Capital_Item", fCapital_Item, value)
            End Set
        End Property
        Dim fProduct_Indicator As Short
        Public Property Product_Indicator() As Short
            Get
                Return fProduct_Indicator
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Product_Indicator", fProduct_Indicator, value)
            End Set
        End Property
        Dim fSource_Document_Number As String
        <Size(11)>
        Public Property Source_Document_Number() As String
            Get
                Return fSource_Document_Number
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Source_Document_Number", fSource_Document_Number, value)
            End Set
        End Property
        Dim fSource_Document_Line_Num As Short
        Public Property Source_Document_Line_Num() As Short
            Get
                Return fSource_Document_Line_Num
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Source_Document_Line_Num", fSource_Document_Line_Num, value)
            End Set
        End Property
        Dim fRELEASEBYDATE As DateTime
        Public Property RELEASEBYDATE() As DateTime
            Get
                Return fRELEASEBYDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("RELEASEBYDATE", fRELEASEBYDATE, value)
            End Set
        End Property
        Dim fReleased_Date As DateTime
        Public Property Released_Date() As DateTime
            Get
                Return fReleased_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Released_Date", fReleased_Date, value)
            End Set
        End Property
        Dim fChange_Order_Flag As Short
        Public Property Change_Order_Flag() As Short
            Get
                Return fChange_Order_Flag
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Change_Order_Flag", fChange_Order_Flag, value)
            End Set
        End Property
        Dim fPurchase_IV_Item_Taxable As Short
        Public Property Purchase_IV_Item_Taxable() As Short
            Get
                Return fPurchase_IV_Item_Taxable
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Purchase_IV_Item_Taxable", fPurchase_IV_Item_Taxable, value)
            End Set
        End Property
        Dim fPurchase_Item_Tax_Schedu As String
        <Size(15)>
        Public Property Purchase_Item_Tax_Schedu() As String
            Get
                Return fPurchase_Item_Tax_Schedu
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Purchase_Item_Tax_Schedu", fPurchase_Item_Tax_Schedu, value)
            End Set
        End Property
        Dim fPurchase_Site_Tax_Schedu As String
        <Size(15)>
        Public Property Purchase_Site_Tax_Schedu() As String
            Get
                Return fPurchase_Site_Tax_Schedu
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Purchase_Site_Tax_Schedu", fPurchase_Site_Tax_Schedu, value)
            End Set
        End Property
        Dim fPURCHSITETXSCHSRC As Short
        Public Property PURCHSITETXSCHSRC() As Short
            Get
                Return fPURCHSITETXSCHSRC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PURCHSITETXSCHSRC", fPURCHSITETXSCHSRC, value)
            End Set
        End Property
        Dim fBSIVCTTL As Byte
        Public Property BSIVCTTL() As Byte
            Get
                Return fBSIVCTTL
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BSIVCTTL", fBSIVCTTL, value)
            End Set
        End Property
        Dim fTAXAMNT As Decimal
        Public Property TAXAMNT() As Decimal
            Get
                Return fTAXAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TAXAMNT", fTAXAMNT, value)
            End Set
        End Property
        Dim fORTAXAMT As Decimal
        Public Property ORTAXAMT() As Decimal
            Get
                Return fORTAXAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORTAXAMT", fORTAXAMT, value)
            End Set
        End Property
        Dim fBCKTXAMT As Decimal
        Public Property BCKTXAMT() As Decimal
            Get
                Return fBCKTXAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BCKTXAMT", fBCKTXAMT, value)
            End Set
        End Property
        Dim fOBTAXAMT As Decimal
        Public Property OBTAXAMT() As Decimal
            Get
                Return fOBTAXAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OBTAXAMT", fOBTAXAMT, value)
            End Set
        End Property
        Dim fLanded_Cost_Group_ID As String
        <Size(15)>
        Public Property Landed_Cost_Group_ID() As String
            Get
                Return fLanded_Cost_Group_ID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Landed_Cost_Group_ID", fLanded_Cost_Group_ID, value)
            End Set
        End Property
        Dim fPLNNDSPPLID As Short
        Public Property PLNNDSPPLID() As Short
            Get
                Return fPLNNDSPPLID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PLNNDSPPLID", fPLNNDSPPLID, value)
            End Set
        End Property
        Dim fSHIPMTHD As String
        <Size(15)>
        Public Property SHIPMTHD() As String
            Get
                Return fSHIPMTHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHIPMTHD", fSHIPMTHD, value)
            End Set
        End Property
        Dim fBackoutTradeDiscTax As Decimal
        Public Property BackoutTradeDiscTax() As Decimal
            Get
                Return fBackoutTradeDiscTax
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BackoutTradeDiscTax", fBackoutTradeDiscTax, value)
            End Set
        End Property
        Dim fOrigBackoutTradeDiscTax As Decimal
        Public Property OrigBackoutTradeDiscTax() As Decimal
            Get
                Return fOrigBackoutTradeDiscTax
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OrigBackoutTradeDiscTax", fOrigBackoutTradeDiscTax, value)
            End Set
        End Property
        Dim fLineNumber As Short
        Public Property LineNumber() As Short
            Get
                Return fLineNumber
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LineNumber", fLineNumber, value)
            End Set
        End Property
        Dim fORIGPRMDATE As DateTime
        Public Property ORIGPRMDATE() As DateTime
            Get
                Return fORIGPRMDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ORIGPRMDATE", fORIGPRMDATE, value)
            End Set
        End Property
        Dim fFSTRCPTDT As DateTime
        Public Property FSTRCPTDT() As DateTime
            Get
                Return fFSTRCPTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FSTRCPTDT", fFSTRCPTDT, value)
            End Set
        End Property
        Dim fLSTRCPTDT As DateTime
        Public Property LSTRCPTDT() As DateTime
            Get
                Return fLSTRCPTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTRCPTDT", fLSTRCPTDT, value)
            End Set
        End Property
        Dim fRELEASE As Short
        Public Property RELEASE() As Short
            Get
                Return fRELEASE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RELEASE", fRELEASE, value)
            End Set
        End Property
        Dim fADRSCODE As String
        <Size(15)>
        Public Property ADRSCODE() As String
            Get
                Return fADRSCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADRSCODE", fADRSCODE, value)
            End Set
        End Property
        Dim fCMPNYNAM As String
        <Size(65)>
        Public Property CMPNYNAM() As String
            Get
                Return fCMPNYNAM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CMPNYNAM", fCMPNYNAM, value)
            End Set
        End Property
        Dim fCONTACT As String
        <Size(61)>
        Public Property CONTACT() As String
            Get
                Return fCONTACT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CONTACT", fCONTACT, value)
            End Set
        End Property
        Dim fADDRESS1 As String
        <Size(61)>
        Public Property ADDRESS1() As String
            Get
                Return fADDRESS1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS1", fADDRESS1, value)
            End Set
        End Property
        Dim fADDRESS2 As String
        <Size(61)>
        Public Property ADDRESS2() As String
            Get
                Return fADDRESS2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS2", fADDRESS2, value)
            End Set
        End Property
        Dim fADDRESS3 As String
        <Size(61)>
        Public Property ADDRESS3() As String
            Get
                Return fADDRESS3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS3", fADDRESS3, value)
            End Set
        End Property
        Dim fCITY As String
        <Size(35)>
        Public Property CITY() As String
            Get
                Return fCITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CITY", fCITY, value)
            End Set
        End Property
        Dim fSTATE As String
        <Size(29)>
        Public Property STATE() As String
            Get
                Return fSTATE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STATE", fSTATE, value)
            End Set
        End Property
        Dim fZIPCODE As String
        <Size(11)>
        Public Property ZIPCODE() As String
            Get
                Return fZIPCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIPCODE", fZIPCODE, value)
            End Set
        End Property
        Dim fCCode As String
        <Size(7)>
        Public Property CCode() As String
            Get
                Return fCCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CCode", fCCode, value)
            End Set
        End Property
        Dim fCOUNTRY As String
        <Size(61)>
        Public Property COUNTRY() As String
            Get
                Return fCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
            End Set
        End Property
        Dim fPHONE1 As String
        <Size(21)>
        Public Property PHONE1() As String
            Get
                Return fPHONE1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE1", fPHONE1, value)
            End Set
        End Property
        Dim fPHONE2 As String
        <Size(21)>
        Public Property PHONE2() As String
            Get
                Return fPHONE2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE2", fPHONE2, value)
            End Set
        End Property
        Dim fPHONE3 As String
        <Size(21)>
        Public Property PHONE3() As String
            Get
                Return fPHONE3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE3", fPHONE3, value)
            End Set
        End Property
        Dim fFAX As String
        <Size(21)>
        Public Property FAX() As String
            Get
                Return fFAX
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FAX", fFAX, value)
            End Set
        End Property
        Dim fADDRSOURCE As Short
        Public Property ADDRSOURCE() As Short
            Get
                Return fADDRSOURCE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ADDRSOURCE", fADDRSOURCE, value)
            End Set
        End Property
        Dim fFlags As Short
        Public Property Flags() As Short
            Get
                Return fFlags
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Flags", fFlags, value)
            End Set
        End Property
        Dim fProjNum As String
        <Size(15)>
        Public Property ProjNum() As String
            Get
                Return fProjNum
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ProjNum", fProjNum, value)
            End Set
        End Property
        Dim fCostCatID As String
        <Size(15)>
        Public Property CostCatID() As String
            Get
                Return fCostCatID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CostCatID", fCostCatID, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID() As Integer
            Get
                Return fDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
            End Set
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
