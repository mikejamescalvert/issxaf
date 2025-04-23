Imports DevExpress.Xpo

Namespace Objects.PM
    ''' <summary>
    ''' GP Table PM10000
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("PM10000")>
    Public Class PMWorkingPMTransaction
        Inherits XPLiteObject

        Public Structure PMWorkingPMTransactionKey
            Private fBACHNUMB As String
            <Size(15)> _
            <Persistent("BACHNUMB")>
            Public Property BACHNUMB() As String
                Get
                    Return fBACHNUMB
                End Get
                Set(ByVal value As String)
                    fBACHNUMB = value
                End Set
            End Property
            Private fBCHSOURC As String
			<Size(15)> _
			<Persistent("BCHSOURC")>
			Public Property BCHSOURC() As String
				Get
					Return fBCHSOURC
				End Get
				Set(ByVal value As String)
					fBCHSOURC = value
				End Set
			End Property
            Private fVCHNUMWK As String
			<Size(17)> _
			<Persistent("VCHNUMWK")>
			Public Property VCHNUMWK() As String
				Get
					Return fVCHNUMWK
				End Get
				Set(ByVal value As String)
					fVCHNUMWK = value
				End Set
			End Property
        End Structure

        Dim fOid As PMWorkingPMTransactionKey
        <Key()>
        <Persistent()>
        Public Property Oid() As PMWorkingPMTransactionKey
            Get
                Return fOid
            End Get
            Set(ByVal value As PMWorkingPMTransactionKey)
                SetPropertyValue(Of PMWorkingPMTransactionKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fVENDORID As String
        <Size(15)> _
        Public Property VENDORID() As String
            Get
                Return fVENDORID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDORID", fVENDORID, value)
            End Set
        End Property
        Dim fDOCNUMBR As String
        <Size(21)> _
        Public Property DOCNUMBR() As String
            Get
                Return fDOCNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DOCNUMBR", fDOCNUMBR, value)
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
        Dim fSOURCDOC As String
        <Size(11)> _
        Public Property SOURCDOC() As String
            Get
                Return fSOURCDOC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOURCDOC", fSOURCDOC, value)
            End Set
        End Property
        Dim fDOCAMNT As Decimal
        Public Property DOCAMNT() As Decimal
            Get
                Return fDOCAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DOCAMNT", fDOCAMNT, value)
            End Set
        End Property
        Dim fDOCDATE As DateTime
        Public Property DOCDATE() As DateTime
            Get
                Return fDOCDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DOCDATE", fDOCDATE, value)
            End Set
        End Property
        Dim fPSTGDATE As DateTime
        Public Property PSTGDATE() As DateTime
            Get
                Return fPSTGDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("PSTGDATE", fPSTGDATE, value)
            End Set
        End Property
        Dim fVADDCDPR As String
        <Size(15)> _
        Public Property VADDCDPR() As String
            Get
                Return fVADDCDPR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADDCDPR", fVADDCDPR, value)
            End Set
        End Property
        Dim fVADCDTRO As String
        <Size(15)> _
        Public Property VADCDTRO() As String
            Get
                Return fVADCDTRO
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADCDTRO", fVADCDTRO, value)
            End Set
        End Property
        Dim fPYMTRMID As String
        <Size(21)> _
        Public Property PYMTRMID() As String
            Get
                Return fPYMTRMID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PYMTRMID", fPYMTRMID, value)
            End Set
        End Property
        Dim fTAXSCHID As String
        <Size(15)> _
        Public Property TAXSCHID() As String
            Get
                Return fTAXSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXSCHID", fTAXSCHID, value)
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
        Dim fDSCDLRAM As Decimal
        Public Property DSCDLRAM() As Decimal
            Get
                Return fDSCDLRAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DSCDLRAM", fDSCDLRAM, value)
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
        Dim fPRCHAMNT As Decimal
        Public Property PRCHAMNT() As Decimal
            Get
                Return fPRCHAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PRCHAMNT", fPRCHAMNT, value)
            End Set
        End Property
        Dim fCHRGAMNT As Decimal
        Public Property CHRGAMNT() As Decimal
            Get
                Return fCHRGAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CHRGAMNT", fCHRGAMNT, value)
            End Set
        End Property
        Dim fCASHAMNT As Decimal
        Public Property CASHAMNT() As Decimal
            Get
                Return fCASHAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CASHAMNT", fCASHAMNT, value)
            End Set
        End Property
        Dim fCAMCBKID As String
        <Size(15)> _
        Public Property CAMCBKID() As String
            Get
                Return fCAMCBKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CAMCBKID", fCAMCBKID, value)
            End Set
        End Property
        Dim fCDOCNMBR As String
        <Size(21)> _
        Public Property CDOCNMBR() As String
            Get
                Return fCDOCNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CDOCNMBR", fCDOCNMBR, value)
            End Set
        End Property
        Dim fCAMTDATE As DateTime
        Public Property CAMTDATE() As DateTime
            Get
                Return fCAMTDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CAMTDATE", fCAMTDATE, value)
            End Set
        End Property
        Dim fCAMPMTNM As String
        <Size(21)> _
        Public Property CAMPMTNM() As String
            Get
                Return fCAMPMTNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CAMPMTNM", fCAMPMTNM, value)
            End Set
        End Property
        Dim fCHEKAMNT As Decimal
        Public Property CHEKAMNT() As Decimal
            Get
                Return fCHEKAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CHEKAMNT", fCHEKAMNT, value)
            End Set
        End Property
        Dim fCHAMCBID As String
        <Size(15)> _
        Public Property CHAMCBID() As String
            Get
                Return fCHAMCBID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHAMCBID", fCHAMCBID, value)
            End Set
        End Property
        Dim fCHEKDATE As DateTime
        Public Property CHEKDATE() As DateTime
            Get
                Return fCHEKDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CHEKDATE", fCHEKDATE, value)
            End Set
        End Property
        Dim fCAMPYNBR As String
        <Size(21)> _
        Public Property CAMPYNBR() As String
            Get
                Return fCAMPYNBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CAMPYNBR", fCAMPYNBR, value)
            End Set
        End Property
        Dim fCRCRDAMT As Decimal
        Public Property CRCRDAMT() As Decimal
            Get
                Return fCRCRDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CRCRDAMT", fCRCRDAMT, value)
            End Set
        End Property
        Dim fCCAMPYNM As String
        <Size(21)> _
        Public Property CCAMPYNM() As String
            Get
                Return fCCAMPYNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CCAMPYNM", fCCAMPYNM, value)
            End Set
        End Property
        Dim fCHEKNMBR As String
        <Size(21)> _
        Public Property CHEKNMBR() As String
            Get
                Return fCHEKNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHEKNMBR", fCHEKNMBR, value)
            End Set
        End Property
        Dim fCARDNAME As String
        <Size(15)> _
        Public Property CARDNAME() As String
            Get
                Return fCARDNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CARDNAME", fCARDNAME, value)
            End Set
        End Property
        Dim fCCRCTNUM As String
        <Size(21)> _
        Public Property CCRCTNUM() As String
            Get
                Return fCCRCTNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CCRCTNUM", fCCRCTNUM, value)
            End Set
        End Property
        Dim fCRCARDDT As DateTime
        Public Property CRCARDDT() As DateTime
            Get
                Return fCRCARDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CRCARDDT", fCRCARDDT, value)
            End Set
        End Property
        Dim fCURNCYID As String
        <Size(15)> _
        Public Property CURNCYID() As String
            Get
                Return fCURNCYID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CURNCYID", fCURNCYID, value)
            End Set
        End Property
        Dim fCHEKBKID As String
        <Size(15)> _
        Public Property CHEKBKID() As String
            Get
                Return fCHEKBKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHEKBKID", fCHEKBKID, value)
            End Set
        End Property
        Dim fTRXDSCRN As String
        <Size(31)> _
        Public Property TRXDSCRN() As String
            Get
                Return fTRXDSCRN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXDSCRN", fTRXDSCRN, value)
            End Set
        End Property
        Dim fUN1099AM As Decimal
        Public Property UN1099AM() As Decimal
            Get
                Return fUN1099AM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UN1099AM", fUN1099AM, value)
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
        Dim fTAXAMNT As Decimal
        Public Property TAXAMNT() As Decimal
            Get
                Return fTAXAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TAXAMNT", fTAXAMNT, value)
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
        Dim fTEN99AMNT As Decimal
        Public Property TEN99AMNT() As Decimal
            Get
                Return fTEN99AMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TEN99AMNT", fTEN99AMNT, value)
            End Set
        End Property
        Dim fMSCCHAMT As Decimal
        Public Property MSCCHAMT() As Decimal
            Get
                Return fMSCCHAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MSCCHAMT", fMSCCHAMT, value)
            End Set
        End Property
        Dim fPORDNMBR As String
        <Size(21)> _
        Public Property PORDNMBR() As String
            Get
                Return fPORDNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PORDNMBR", fPORDNMBR, value)
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
        Dim fDISAMTAV As Decimal
        Public Property DISAMTAV() As Decimal
            Get
                Return fDISAMTAV
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISAMTAV", fDISAMTAV, value)
            End Set
        End Property
        Dim fDISTKNAM As Decimal
        Public Property DISTKNAM() As Decimal
            Get
                Return fDISTKNAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISTKNAM", fDISTKNAM, value)
            End Set
        End Property
        Dim fAPDSTKAM As Decimal
        Public Property APDSTKAM() As Decimal
            Get
                Return fAPDSTKAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APDSTKAM", fAPDSTKAM, value)
            End Set
        End Property
        Dim fWROFAMNT As Decimal
        Public Property WROFAMNT() As Decimal
            Get
                Return fWROFAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WROFAMNT", fWROFAMNT, value)
            End Set
        End Property
        Dim fCURTRXAM As Decimal
        Public Property CURTRXAM() As Decimal
            Get
                Return fCURTRXAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CURTRXAM", fCURTRXAM, value)
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
        Dim fGSTDSAMT As Decimal
        Public Property GSTDSAMT() As Decimal
            Get
                Return fGSTDSAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("GSTDSAMT", fGSTDSAMT, value)
            End Set
        End Property
        Dim fPGRAMSBJ As Short
        Public Property PGRAMSBJ() As Short
            Get
                Return fPGRAMSBJ
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PGRAMSBJ", fPGRAMSBJ, value)
            End Set
        End Property
        Dim fPPSAMDED As Decimal
        Public Property PPSAMDED() As Decimal
            Get
                Return fPPSAMDED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PPSAMDED", fPPSAMDED, value)
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
        Dim fPSTGSTUS As Short
        Public Property PSTGSTUS() As Short
            Get
                Return fPSTGSTUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PSTGSTUS", fPSTGSTUS, value)
            End Set
        End Property
        Dim fPOSTED As Byte
        Public Property POSTED() As Byte
            Get
                Return fPOSTED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("POSTED", fPOSTED, value)
            End Set
        End Property
        Dim fAPPLDAMT As Decimal
        Public Property APPLDAMT() As Decimal
            Get
                Return fAPPLDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APPLDAMT", fAPPLDAMT, value)
            End Set
        End Property
        Dim fVCHRNMBR As String
        <Size(21)> _
        Public Property VCHRNMBR() As String
            Get
                Return fVCHRNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VCHRNMBR", fVCHRNMBR, value)
            End Set
        End Property
        Dim fCNTRLTYP As Short
        Public Property CNTRLTYP() As Short
            Get
                Return fCNTRLTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CNTRLTYP", fCNTRLTYP, value)
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
        Dim fMDFUSRID As String
        <Size(15)> _
        Public Property MDFUSRID() As String
            Get
                Return fMDFUSRID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MDFUSRID", fMDFUSRID, value)
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
        <Size(15)> _
        Public Property PTDUSRID() As String
            Get
                Return fPTDUSRID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PTDUSRID", fPTDUSRID, value)
            End Set
        End Property
        Dim fNOTEINDX As Decimal
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fBKTFRTAM As Decimal
        Public Property BKTFRTAM() As Decimal
            Get
                Return fBKTFRTAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BKTFRTAM", fBKTFRTAM, value)
            End Set
        End Property
        Dim fBKTMSCAM As Decimal
        Public Property BKTMSCAM() As Decimal
            Get
                Return fBKTMSCAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BKTMSCAM", fBKTMSCAM, value)
            End Set
        End Property
        Dim fBKTPURAM As Decimal
        Public Property BKTPURAM() As Decimal
            Get
                Return fBKTPURAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BKTPURAM", fBKTPURAM, value)
            End Set
        End Property
        Dim fPCHSCHID As String
        <Size(15)> _
        Public Property PCHSCHID() As String
            Get
                Return fPCHSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PCHSCHID", fPCHSCHID, value)
            End Set
        End Property
        Dim fFRTSCHID As String
        <Size(15)> _
        Public Property FRTSCHID() As String
            Get
                Return fFRTSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FRTSCHID", fFRTSCHID, value)
            End Set
        End Property
        Dim fMSCSCHID As String
        <Size(15)> _
        Public Property MSCSCHID() As String
            Get
                Return fMSCSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MSCSCHID", fMSCSCHID, value)
            End Set
        End Property
        Dim fPRINTED As Byte
        Public Property PRINTED() As Byte
            Get
                Return fPRINTED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("PRINTED", fPRINTED, value)
            End Set
        End Property
        Dim fPRCTDISC As Short
        Public Property PRCTDISC() As Short
            Get
                Return fPRCTDISC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PRCTDISC", fPRCTDISC, value)
            End Set
        End Property
        Dim fRETNAGAM As Decimal
        Public Property RETNAGAM() As Decimal
            Get
                Return fRETNAGAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RETNAGAM", fRETNAGAM, value)
            End Set
        End Property
        Dim fICTRX As Byte
        Public Property ICTRX() As Byte
            Get
                Return fICTRX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ICTRX", fICTRX, value)
            End Set
        End Property
        Dim fICDISTS As Byte
        Public Property ICDISTS() As Byte
            Get
                Return fICDISTS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ICDISTS", fICDISTS, value)
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
        Dim fPRCHDATE As DateTime
        Public Property PRCHDATE() As DateTime
            Get
                Return fPRCHDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("PRCHDATE", fPRCHDATE, value)
            End Set
        End Property
        Dim fCORRCTN As Byte
        Public Property CORRCTN() As Byte
            Get
                Return fCORRCTN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CORRCTN", fCORRCTN, value)
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
        Dim fCORRNXST As Byte
        Public Property CORRNXST() As Byte
            Get
                Return fCORRNXST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CORRNXST", fCORRNXST, value)
            End Set
        End Property
        Dim fVCHRNCOR As String
        <Size(21)> _
        Public Property VCHRNCOR() As String
            Get
                Return fVCHRNCOR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VCHRNCOR", fVCHRNCOR, value)
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
        Dim fAPLYWITH As Byte
        Public Property APLYWITH() As Byte
            Get
                Return fAPLYWITH
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("APLYWITH", fAPLYWITH, value)
            End Set
        End Property
        Dim fElectronic As Byte
        Public Property Electronic() As Byte
            Get
                Return fElectronic
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Electronic", fElectronic, value)
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
        Dim fDocPrinted As Byte
        Public Property DocPrinted() As Byte
            Get
                Return fDocPrinted
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DocPrinted", fDocPrinted, value)
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
        Dim fBackoutTradeDisc As Decimal
        Public Property BackoutTradeDisc() As Decimal
            Get
                Return fBackoutTradeDisc
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BackoutTradeDisc", fBackoutTradeDisc, value)
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


        Private _mAppliedTransactionLines As XPCollection(Of PMWorkingPMTransactionLine)
        Public ReadOnly Property AppliedTransactionLines() As XPCollection(Of PMWorkingPMTransactionLine)
            Get
                RefreshAppliedTransactionLines()
                Return _mAppliedTransactionLines
            End Get
        End Property

        Private Sub RefreshAppliedTransactionLines()
            Dim ddfFilter As DevExpress.Data.Filtering.GroupOperator
            If _mAppliedTransactionLines Is Nothing Then
                ddfFilter = New DevExpress.Data.Filtering.GroupOperator
                ddfFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.VCHRNMBR", Trim(VCHRNMBR) + "%", DevExpress.Data.Filtering.BinaryOperatorType.Like))
                ddfFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.DOCTYPE", DOCTYPE, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                _mAppliedTransactionLines = New XPCollection(Of PMWorkingPMTransactionLine)(Session, ddfFilter)
            End If
        End Sub

        <PersistentAlias("[<PMWorkingPMTransactionLine>][Oid.VCHRNMBR Like Concat(^.VCHRNMBR,'%') AND Oid.DOCTYPE = ^.DOCTYPE].Sum(APPLDAMT)")>
        Public ReadOnly Property AppliedAmount() As Decimal
            Get
                'Dim decAppliedAmount As Decimal = 0
                'For Each oAppliedTransactionLine As PMWorkingPMTransactionLine In AppliedTransactionLines
                '    decAppliedAmount += oAppliedTransactionLine.APPLDAMT
                'Next
                'Return decAppliedAmount
                Return EvaluateAlias("AppliedAmount")
            End Get
        End Property
        'Public ReadOnly Property AppliedAmountO() As Decimal
        '    Get
        '        Dim decAppliedAmount As Decimal = 0
        '        For Each oAppliedTransactionLine As PMWorkingPMTransactionLine In AppliedTransactionLines
        '            decAppliedAmount += oAppliedTransactionLine.APPLDAMT
        '        Next
        '        Return decAppliedAmount
        '    End Get
        'End Property


        Private _mDistributionLines As XPCollection(Of PMWorkingPMTransactionDistribution)
        Public ReadOnly Property DistributionLines() As XPCollection(Of PMWorkingPMTransactionDistribution)
            Get
                RefreshDistributionLines()
                Return _mDistributionLines
            End Get
        End Property

        Private Sub RefreshDistributionLines()
            Dim ddfFilter As DevExpress.Data.Filtering.GroupOperator
            If _mDistributionLines Is Nothing Then
                ddfFilter = New DevExpress.Data.Filtering.GroupOperator
                ddfFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.VCHRNMBR", Trim(VCHRNMBR) + "%", DevExpress.Data.Filtering.BinaryOperatorType.Like))
                ddfFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.DOCTYPE", DOCTYPE, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                _mDistributionLines = New XPCollection(Of PMWorkingPMTransactionDistribution)(Session, ddfFilter)
            End If
        End Sub

        Private _mNoteIndex As SY.SYNoteIndex
        <PersistentAlias("[<SYNoteIndex>][NOTEINDX = ^.NOTEINDX].Single()")>
        Public ReadOnly Property NoteIndex() As SY.SYNoteIndex
            Get
                'If _mNoteIndex Is Nothing Then
                '    _mNoteIndex = Session.FindObject(Of SY.SYNoteIndex)(New DevExpress.Data.Filtering.BinaryOperator("NOTEINDX", Me.NOTEINDX, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                'End If
                'Return _mNoteIndex
                Return TryCast(EvaluateAlias("NoteIndex"), SY.SYNoteIndex)
            End Get
        End Property

    End Class

End Namespace
