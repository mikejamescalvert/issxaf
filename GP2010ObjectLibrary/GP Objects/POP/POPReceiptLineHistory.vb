Imports System
Imports DevExpress.Xpo
Namespace Objects.POP
    ''' <summary>
    ''' GP Table POP30310
    ''' </summary>
    <Persistent("POP30310")> _
    <OptimisticLocking(False)>
    Public Class POPReceiptLineHistory
        Inherits XPLiteObject
        Public Structure POPReceiptLineHistoryKey
            Private fPOPRCTNM As String
            <Size(17)> _
            <Persistent("POPRCTNM")>
            Public Property POPRCTNM() As String
                Get
                    Return fPOPRCTNM
                End Get
                Set(ByVal value As String)
                    fPOPRCTNM = value
                End Set
            End Property
            Private fRCPTLNNM As Integer
            <Persistent("RCPTLNNM")>
            Public Property RCPTLNNM() As Integer
                Get
                    Return fRCPTLNNM
                End Get
                Set(ByVal value As Integer)
                    fRCPTLNNM = value
                End Set
            End Property
        End Structure

        Private _mOid As POPReceiptLineHistoryKey
        <Persistent()> _
        <Key(False)> _
        Public Property Oid() As POPReceiptLineHistoryKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As POPReceiptLineHistoryKey)
                _mOid = Value
            End Set
        End Property


        Dim fPONUMBER As String
        <Size(17)> _
        Public Property PONUMBER() As String
            Get
                Return fPONUMBER
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PONUMBER", fPONUMBER, value)
            End Set
        End Property
        Dim fITEMNMBR As String
        <Size(31)> _
        Public Property ITEMNMBR() As String
            Get
                Return fITEMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
            End Set
        End Property
        Dim fITEMDESC As String
        <Size(101)> _
        Public Property ITEMDESC() As String
            Get
                Return fITEMDESC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMDESC", fITEMDESC, value)
            End Set
        End Property
        Dim fVNDITNUM As String
        <Size(31)> _
        Public Property VNDITNUM() As String
            Get
                Return fVNDITNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDITNUM", fVNDITNUM, value)
            End Set
        End Property
        Dim fVNDITDSC As String
        <Size(101)> _
        Public Property VNDITDSC() As String
            Get
                Return fVNDITDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDITDSC", fVNDITDSC, value)
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
        Dim fACTLSHIP As DateTime
        Public Property ACTLSHIP() As DateTime
            Get
                Return fACTLSHIP
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ACTLSHIP", fACTLSHIP, value)
            End Set
        End Property
        Dim fCOMMNTID As String
        <Size(15)> _
        Public Property COMMNTID() As String
            Get
                Return fCOMMNTID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMNTID", fCOMMNTID, value)
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
        Dim fUOFM As String
        <Size(9)> _
        Public Property UOFM() As String
            Get
                Return fUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOFM", fUOFM, value)
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
        Dim fLOCNCODE As String
        <Size(11)> _
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_1 As Decimal
        Public Property RcptLineNoteIDArray_1() As Decimal
            Get
                Return fRcptLineNoteIDArray_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_1", fRcptLineNoteIDArray_1, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_2 As Decimal
        Public Property RcptLineNoteIDArray_2() As Decimal
            Get
                Return fRcptLineNoteIDArray_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_2", fRcptLineNoteIDArray_2, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_3 As Decimal
        Public Property RcptLineNoteIDArray_3() As Decimal
            Get
                Return fRcptLineNoteIDArray_3
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_3", fRcptLineNoteIDArray_3, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_4 As Decimal
        Public Property RcptLineNoteIDArray_4() As Decimal
            Get
                Return fRcptLineNoteIDArray_4
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_4", fRcptLineNoteIDArray_4, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_5 As Decimal
        Public Property RcptLineNoteIDArray_5() As Decimal
            Get
                Return fRcptLineNoteIDArray_5
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_5", fRcptLineNoteIDArray_5, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_6 As Decimal
        Public Property RcptLineNoteIDArray_6() As Decimal
            Get
                Return fRcptLineNoteIDArray_6
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_6", fRcptLineNoteIDArray_6, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_7 As Decimal
        Public Property RcptLineNoteIDArray_7() As Decimal
            Get
                Return fRcptLineNoteIDArray_7
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_7", fRcptLineNoteIDArray_7, value)
            End Set
        End Property
        Dim fRcptLineNoteIDArray_8 As Decimal
        Public Property RcptLineNoteIDArray_8() As Decimal
            Get
                Return fRcptLineNoteIDArray_8
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RcptLineNoteIDArray_8", fRcptLineNoteIDArray_8, value)
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
        Dim fTRXSORCE As String
        <Size(13)> _
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXSORCE", fTRXSORCE, value)
            End Set
        End Property
        Dim fJOBNUMBR As String
        <Size(17)> _
        Public Property JOBNUMBR() As String
            Get
                Return fJOBNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("JOBNUMBR", fJOBNUMBR, value)
            End Set
        End Property
        Dim fCOSTCODE As String
        <Size(27)> _
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
        Dim fCURRNIDX As Short
        Public Property CURRNIDX() As Short
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CURRNIDX", fCURRNIDX, value)
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
        Dim fODECPLCU As Short
        Public Property ODECPLCU() As Short
            Get
                Return fODECPLCU
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ODECPLCU", fODECPLCU, value)
            End Set
        End Property
        Dim fBOLPRONUMBER As String
        <Size(31)> _
        Public Property BOLPRONUMBER() As String
            Get
                Return fBOLPRONUMBER
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOLPRONUMBER", fBOLPRONUMBER, value)
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
        <Size(15)> _
        Public Property Purchase_Item_Tax_Schedu() As String
            Get
                Return fPurchase_Item_Tax_Schedu
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Purchase_Item_Tax_Schedu", fPurchase_Item_Tax_Schedu, value)
            End Set
        End Property
        Dim fPurchase_Site_Tax_Schedu As String
        <Size(15)> _
        Public Property Purchase_Site_Tax_Schedu() As String
            Get
                Return fPurchase_Site_Tax_Schedu
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Purchase_Site_Tax_Schedu", fPurchase_Site_Tax_Schedu, value)
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
        Dim fPURPVIDX As Integer
        Public Property PURPVIDX() As Integer
            Get
                Return fPURPVIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PURPVIDX", fPURPVIDX, value)
            End Set
        End Property
        Dim fSHIPMTHD As String
        <Size(15)> _
        Public Property SHIPMTHD() As String
            Get
                Return fSHIPMTHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHIPMTHD", fSHIPMTHD, value)
            End Set
        End Property
        Dim fLanded_Cost_Group_ID As String
        <Size(15)> _
        Public Property Landed_Cost_Group_ID() As String
            Get
                Return fLanded_Cost_Group_ID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Landed_Cost_Group_ID", fLanded_Cost_Group_ID, value)
            End Set
        End Property
        Dim fLanded_Cost_Warnings As Short
        Public Property Landed_Cost_Warnings() As Short
            Get
                Return fLanded_Cost_Warnings
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Landed_Cost_Warnings", fLanded_Cost_Warnings, value)
            End Set
        End Property
        Dim fLanded_Cost As Byte
        Public Property Landed_Cost() As Byte
            Get
                Return fLanded_Cost
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Landed_Cost", fLanded_Cost, value)
            End Set
        End Property
        Dim fInvoice_Match As Byte
        Public Property Invoice_Match() As Byte
            Get
                Return fInvoice_Match
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Invoice_Match", fInvoice_Match, value)
            End Set
        End Property
        Dim fRCPTRETNUM As String
        <Size(17)> _
        Public Property RCPTRETNUM() As String
            Get
                Return fRCPTRETNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RCPTRETNUM", fRCPTRETNUM, value)
            End Set
        End Property
        Dim fRCPTRETLNNUM As Integer
        Public Property RCPTRETLNNUM() As Integer
            Get
                Return fRCPTRETLNNUM
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RCPTRETLNNUM", fRCPTRETLNNUM, value)
            End Set
        End Property
        Dim fINVRETNUM As String
        <Size(17)> _
        Public Property INVRETNUM() As String
            Get
                Return fINVRETNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INVRETNUM", fINVRETNUM, value)
            End Set
        End Property
        Dim fINVRETLNNUM As Integer
        Public Property INVRETLNNUM() As Integer
            Get
                Return fINVRETLNNUM
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("INVRETLNNUM", fINVRETLNNUM, value)
            End Set
        End Property
        Dim fISLINEINTRA As Byte
        Public Property ISLINEINTRA() As Byte
            Get
                Return fISLINEINTRA
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ISLINEINTRA", fISLINEINTRA, value)
            End Set
        End Property
        Dim fProjNum As String
        <Size(15)> _
        Public Property ProjNum() As String
            Get
                Return fProjNum
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ProjNum", fProjNum, value)
            End Set
        End Property
        Dim fCostCatID As String
        <Size(15)> _
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
