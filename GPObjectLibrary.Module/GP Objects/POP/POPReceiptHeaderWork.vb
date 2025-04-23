Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.POP
    ''' <summary>
    ''' GP Table POP10300
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("POP10300")>
    <System.ComponentModel.DefaultProperty("POPRCTNM")>
    <OptimisticLocking(False)>
    Public Class POPReceiptHeaderWork
        Inherits XPLiteObject
        Dim fPOPRCTNM As String
        <Key()>
        <Size(17)>
        Public Property POPRCTNM() As String
            Get
                Return fPOPRCTNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("POPRCTNM", fPOPRCTNM, value)
            End Set
        End Property

        Private _mPOPHDR1 As Byte()
        Public Property POPHDR1 As Byte()
            Get
                Return _mPOPHDR1
            End Get
            Set(ByVal Value As Byte())
                SetPropertyValue("POPHDR1", _mPOPHDR1, Value)
            End Set
        End Property

        Private _mPOPHDR2 As Byte()
        Public Property POPHDR2 As Byte()
            Get
                Return _mPOPHDR2
            End Get
            Set(ByVal Value As Byte())
                SetPropertyValue("POPHDR2", _mPOPHDR2, Value)
            End Set
        End Property

        Private _mPOPLNERR As Byte()
        Public Property POPLNERR As Byte()
            Get
                Return _mPOPLNERR
            End Get
            Set(ByVal Value As Byte())
                _mPOPLNERR = Value
            End Set
        End Property

        Dim fPOPTYPE As Short
        Public Property POPTYPE() As Short
            Get
                Return fPOPTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POPTYPE", fPOPTYPE, value)
            End Set
        End Property
        Dim fVNDDOCNM As String
        <Size(21)>
        Public Property VNDDOCNM() As String
            Get
                Return fVNDDOCNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDDOCNM", fVNDDOCNM, value)
            End Set
        End Property
        Dim freceiptdate As DateTime
        Public Property receiptdate() As DateTime
            Get
                Return freceiptdate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("receiptdate", freceiptdate, value)
            End Set
        End Property
        Dim fGLPOSTDT As DateTime
        Public Property GLPOSTDT() As DateTime
            Get
                Return fGLPOSTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("GLPOSTDT", fGLPOSTDT, value)
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
        Dim fBCHSOURC As String
        <Size(15)>
        Public Property BCHSOURC() As String
            Get
                Return fBCHSOURC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BCHSOURC", fBCHSOURC, value)
            End Set
        End Property
        Dim fBACHNUMB As String
        <Size(15)>
        Public Property BACHNUMB() As String
            Get
                Return fBACHNUMB
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BACHNUMB", fBACHNUMB, value)
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
        Dim fVENDNAME As String
        <Size(65)>
        Public Property VENDNAME() As String
            Get
                Return fVENDNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDNAME", fVENDNAME, value)
            End Set
        End Property
        Dim fSUBTOTAL As Decimal
        Public Property SUBTOTAL() As Decimal
            Get
                Return fSUBTOTAL
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SUBTOTAL", fSUBTOTAL, value)
            End Set
        End Property
        Dim fTRDISAMT As Decimal
        Public Property TRDISAMT() As Decimal
            Get
                Return fTRDISAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TRDISAMT", fTRDISAMT, value)
            End Set
        End Property
        Dim fTRDPCTPR As Decimal
        Public Property TRDPCTPR() As Decimal
            Get
                Return fTRDPCTPR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TRDPCTPR", fTRDPCTPR, value)
            End Set
        End Property
        Dim fFRTAMNT As Decimal
        Public Property FRTAMNT() As Decimal
            Get
                Return fFRTAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FRTAMNT", fFRTAMNT, value)
            End Set
        End Property
        Dim fMISCAMNT As Decimal
        Public Property MISCAMNT() As Decimal
            Get
                Return fMISCAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MISCAMNT", fMISCAMNT, value)
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
        Dim fTEN99AMNT As Decimal
        Public Property TEN99AMNT() As Decimal
            Get
                Return fTEN99AMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TEN99AMNT", fTEN99AMNT, value)
            End Set
        End Property
        Dim fPYMTRMID As String
        <Size(21)>
        Public Property PYMTRMID() As String
            Get
                Return fPYMTRMID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PYMTRMID", fPYMTRMID, value)
            End Set
        End Property
        Dim fDSCPCTAM As Short
        Public Property DSCPCTAM() As Short
            Get
                Return fDSCPCTAM
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DSCPCTAM", fDSCPCTAM, value)
            End Set
        End Property
        Dim fDSCDLRAM As Decimal
        Public Property DSCDLRAM() As Decimal
            Get
                Return fDSCDLRAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DSCDLRAM", fDSCDLRAM, value)
            End Set
        End Property
        Dim fDISAVAMT As Decimal
        Public Property DISAVAMT() As Decimal
            Get
                Return fDISAVAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISAVAMT", fDISAVAMT, value)
            End Set
        End Property
        Dim fDISCDATE As DateTime
        Public Property DISCDATE() As DateTime
            Get
                Return fDISCDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DISCDATE", fDISCDATE, value)
            End Set
        End Property
        Dim fDUEDATE As DateTime
        Public Property DUEDATE() As DateTime
            Get
                Return fDUEDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DUEDATE", fDUEDATE, value)
            End Set
        End Property
        Dim fREFRENCE As String
        <Size(31)>
        Public Property REFRENCE() As String
            Get
                Return fREFRENCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REFRENCE", fREFRENCE, value)
            End Set
        End Property
        Dim fRCPTNOTE_1 As Decimal
        Public Property RCPTNOTE_1() As Decimal
            Get
                Return fRCPTNOTE_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_1", fRCPTNOTE_1, value)
            End Set
        End Property
        Dim fRCPTNOTE_2 As Decimal
        Public Property RCPTNOTE_2() As Decimal
            Get
                Return fRCPTNOTE_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_2", fRCPTNOTE_2, value)
            End Set
        End Property
        Dim fRCPTNOTE_3 As Decimal
        Public Property RCPTNOTE_3() As Decimal
            Get
                Return fRCPTNOTE_3
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_3", fRCPTNOTE_3, value)
            End Set
        End Property
        Dim fRCPTNOTE_4 As Decimal
        Public Property RCPTNOTE_4() As Decimal
            Get
                Return fRCPTNOTE_4
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_4", fRCPTNOTE_4, value)
            End Set
        End Property
        Dim fRCPTNOTE_5 As Decimal
        Public Property RCPTNOTE_5() As Decimal
            Get
                Return fRCPTNOTE_5
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_5", fRCPTNOTE_5, value)
            End Set
        End Property
        Dim fRCPTNOTE_6 As Decimal
        Public Property RCPTNOTE_6() As Decimal
            Get
                Return fRCPTNOTE_6
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_6", fRCPTNOTE_6, value)
            End Set
        End Property
        Dim fRCPTNOTE_7 As Decimal
        Public Property RCPTNOTE_7() As Decimal
            Get
                Return fRCPTNOTE_7
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_7", fRCPTNOTE_7, value)
            End Set
        End Property
        Dim fRCPTNOTE_8 As Decimal
        Public Property RCPTNOTE_8() As Decimal
            Get
                Return fRCPTNOTE_8
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCPTNOTE_8", fRCPTNOTE_8, value)
            End Set
        End Property
        Dim fPOSTEDDT As DateTime
        Public Property POSTEDDT() As DateTime
            Get
                Return fPOSTEDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("POSTEDDT", fPOSTEDDT, value)
            End Set
        End Property
        Dim fPTDUSRID As String
        <Size(15)>
        Public Property PTDUSRID() As String
            Get
                Return fPTDUSRID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PTDUSRID", fPTDUSRID, value)
            End Set
        End Property
        Dim fUSER2ENT As String
        <Size(15)>
        Public Property USER2ENT() As String
            Get
                Return fUSER2ENT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USER2ENT", fUSER2ENT, value)
            End Set
        End Property
        Dim fCREATDDT As DateTime
        Public Property CREATDDT() As DateTime
            Get
                Return fCREATDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CREATDDT", fCREATDDT, value)
            End Set
        End Property
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
            End Set
        End Property
        Dim fTRXSORCE As String
        <Size(13)>
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXSORCE", fTRXSORCE, value)
            End Set
        End Property
        Dim fVCHRNMBR As String
        <Size(21)>
        Public Property VCHRNMBR() As String
            Get
                Return fVCHRNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VCHRNMBR", fVCHRNMBR, value)
            End Set
        End Property
        Dim fTax_Date As DateTime
        Public Property Tax_Date() As DateTime
            Get
                Return fTax_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Tax_Date", fTax_Date, value)
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
        Dim fRATETPID As String
        <Size(15)>
        Public Property RATETPID() As String
            Get
                Return fRATETPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RATETPID", fRATETPID, value)
            End Set
        End Property
        Dim fEXGTBLID As String
        <Size(15)>
        Public Property EXGTBLID() As String
            Get
                Return fEXGTBLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EXGTBLID", fEXGTBLID, value)
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
        Dim fEXCHDATE As DateTime
        Public Property EXCHDATE() As DateTime
            Get
                Return fEXCHDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EXCHDATE", fEXCHDATE, value)
            End Set
        End Property
        Dim fTIME1 As DateTime
        Public Property TIME1() As DateTime
            Get
                Return fTIME1
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("TIME1", fTIME1, value)
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
        Dim fMCTRXSTT As Short
        Public Property MCTRXSTT() As Short
            Get
                Return fMCTRXSTT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MCTRXSTT", fMCTRXSTT, value)
            End Set
        End Property
        Dim fORSUBTOT As Decimal
        Public Property ORSUBTOT() As Decimal
            Get
                Return fORSUBTOT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORSUBTOT", fORSUBTOT, value)
            End Set
        End Property
        Dim fORTDISAM As Decimal
        Public Property ORTDISAM() As Decimal
            Get
                Return fORTDISAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORTDISAM", fORTDISAM, value)
            End Set
        End Property
        Dim fORFRTAMT As Decimal
        Public Property ORFRTAMT() As Decimal
            Get
                Return fORFRTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORFRTAMT", fORFRTAMT, value)
            End Set
        End Property
        Dim fORMISCAMT As Decimal
        Public Property ORMISCAMT() As Decimal
            Get
                Return fORMISCAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORMISCAMT", fORMISCAMT, value)
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
        Dim fOR1099AM As Decimal
        Public Property OR1099AM() As Decimal
            Get
                Return fOR1099AM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OR1099AM", fOR1099AM, value)
            End Set
        End Property
        Dim fORDDLRAT As Decimal
        Public Property ORDDLRAT() As Decimal
            Get
                Return fORDDLRAT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDDLRAT", fORDDLRAT, value)
            End Set
        End Property
        Dim fORDAVAMT As Decimal
        Public Property ORDAVAMT() As Decimal
            Get
                Return fORDAVAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDAVAMT", fORDAVAMT, value)
            End Set
        End Property
        Dim fWITHHAMT As Decimal
        Public Property WITHHAMT() As Decimal
            Get
                Return fWITHHAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WITHHAMT", fWITHHAMT, value)
            End Set
        End Property
        Dim fSIMPLIFD As Byte
        Public Property SIMPLIFD() As Byte
            Get
                Return fSIMPLIFD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SIMPLIFD", fSIMPLIFD, value)
            End Set
        End Property
        Dim fBNKRCAMT As Decimal
        Public Property BNKRCAMT() As Decimal
            Get
                Return fBNKRCAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BNKRCAMT", fBNKRCAMT, value)
            End Set
        End Property
        Dim fECTRX As Byte
        Public Property ECTRX() As Byte
            Get
                Return fECTRX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ECTRX", fECTRX, value)
            End Set
        End Property
        Dim fTXRGNNUM As String
        <Size(25)>
        Public Property TXRGNNUM() As String
            Get
                Return fTXRGNNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXRGNNUM", fTXRGNNUM, value)
            End Set
        End Property
        Dim fTAXSCHID As String
        <Size(15)>
        Public Property TAXSCHID() As String
            Get
                Return fTAXSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXSCHID", fTAXSCHID, value)
            End Set
        End Property
        Dim fTXENGCLD As Byte
        Public Property TXENGCLD() As Byte
            Get
                Return fTXENGCLD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TXENGCLD", fTXENGCLD, value)
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
        Dim fPurchase_Freight_Taxable As Short
        Public Property Purchase_Freight_Taxable() As Short
            Get
                Return fPurchase_Freight_Taxable
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Purchase_Freight_Taxable", fPurchase_Freight_Taxable, value)
            End Set
        End Property
        Dim fPurchase_Misc_Taxable As Short
        Public Property Purchase_Misc_Taxable() As Short
            Get
                Return fPurchase_Misc_Taxable
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Purchase_Misc_Taxable", fPurchase_Misc_Taxable, value)
            End Set
        End Property
        Dim fFRTSCHID As String
        <Size(15)>
        Public Property FRTSCHID() As String
            Get
                Return fFRTSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FRTSCHID", fFRTSCHID, value)
            End Set
        End Property
        Dim fMSCSCHID As String
        <Size(15)>
        Public Property MSCSCHID() As String
            Get
                Return fMSCSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSCSCHID", fMSCSCHID, value)
            End Set
        End Property
        Dim fFRTTXAMT As Decimal
        Public Property FRTTXAMT() As Decimal
            Get
                Return fFRTTXAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FRTTXAMT", fFRTTXAMT, value)
            End Set
        End Property
        Dim fORFRTTAX As Decimal
        Public Property ORFRTTAX() As Decimal
            Get
                Return fORFRTTAX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORFRTTAX", fORFRTTAX, value)
            End Set
        End Property
        Dim fMSCTXAMT As Decimal
        Public Property MSCTXAMT() As Decimal
            Get
                Return fMSCTXAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MSCTXAMT", fMSCTXAMT, value)
            End Set
        End Property
        Dim fORMSCTAX As Decimal
        Public Property ORMSCTAX() As Decimal
            Get
                Return fORMSCTAX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORMSCTAX", fORMSCTAX, value)
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
        Dim fBackoutFreightTaxAmt As Decimal
        Public Property BackoutFreightTaxAmt() As Decimal
            Get
                Return fBackoutFreightTaxAmt
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BackoutFreightTaxAmt", fBackoutFreightTaxAmt, value)
            End Set
        End Property
        Dim fOrigBackoutFreightTaxAmt As Decimal
        Public Property OrigBackoutFreightTaxAmt() As Decimal
            Get
                Return fOrigBackoutFreightTaxAmt
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OrigBackoutFreightTaxAmt", fOrigBackoutFreightTaxAmt, value)
            End Set
        End Property
        Dim fBackoutMiscTaxAmt As Decimal
        Public Property BackoutMiscTaxAmt() As Decimal
            Get
                Return fBackoutMiscTaxAmt
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BackoutMiscTaxAmt", fBackoutMiscTaxAmt, value)
            End Set
        End Property
        Dim fOrigBackoutMiscTaxAmt As Decimal
        Public Property OrigBackoutMiscTaxAmt() As Decimal
            Get
                Return fOrigBackoutMiscTaxAmt
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OrigBackoutMiscTaxAmt", fOrigBackoutMiscTaxAmt, value)
            End Set
        End Property
        Dim fTaxInvReqd As Byte
        Public Property TaxInvReqd() As Byte
            Get
                Return fTaxInvReqd
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TaxInvReqd", fTaxInvReqd, value)
            End Set
        End Property
        Dim fTaxInvRecvd As Byte
        Public Property TaxInvRecvd() As Byte
            Get
                Return fTaxInvRecvd
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TaxInvRecvd", fTaxInvRecvd, value)
            End Set
        End Property
        Dim fAPLYWITH As Byte
        Public Property APLYWITH() As Byte
            Get
                Return fAPLYWITH
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("APLYWITH", fAPLYWITH, value)
            End Set
        End Property
        Dim fPPSTAXRT As Short
        Public Property PPSTAXRT() As Short
            Get
                Return fPPSTAXRT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PPSTAXRT", fPPSTAXRT, value)
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
        Dim fDocPrinted As Byte
        Public Property DocPrinted() As Byte
            Get
                Return fDocPrinted
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DocPrinted", fDocPrinted, value)
            End Set
        End Property
        Dim fTotal_Landed_Cost_Amount As Decimal
        Public Property Total_Landed_Cost_Amount() As Decimal
            Get
                Return fTotal_Landed_Cost_Amount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Total_Landed_Cost_Amount", fTotal_Landed_Cost_Amount, value)
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
        Dim fCBVAT As Byte
        Public Property CBVAT() As Byte
            Get
                Return fCBVAT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CBVAT", fCBVAT, value)
            End Set
        End Property
        Dim fVADCDTRO As String
        <Size(15)>
        Public Property VADCDTRO() As String
            Get
                Return fVADCDTRO
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADCDTRO", fVADCDTRO, value)
            End Set
        End Property
        Dim fTEN99TYPE As Short
        Public Property TEN99TYPE() As Short
            Get
                Return fTEN99TYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TEN99TYPE", fTEN99TYPE, value)
            End Set
        End Property
        Dim fTEN99BOXNUMBER As Short
        Public Property TEN99BOXNUMBER() As Short
            Get
                Return fTEN99BOXNUMBER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TEN99BOXNUMBER", fTEN99BOXNUMBER, value)
            End Set
        End Property
        Dim fREPLACEGOODS As Byte
        Public Property REPLACEGOODS() As Byte
            Get
                Return fREPLACEGOODS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("REPLACEGOODS", fREPLACEGOODS, value)
            End Set
        End Property
        Dim fINVOICEEXPECTED As Byte
        Public Property INVOICEEXPECTED() As Byte
            Get
                Return fINVOICEEXPECTED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INVOICEEXPECTED", fINVOICEEXPECTED, value)
            End Set
        End Property
        'Dim fDEX_ROW_ID As Integer
        'Public Property DEX_ROW_ID() As Integer
        '    Get
        '        Return fDEX_ROW_ID
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
        '    End Set
        'End Property
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
