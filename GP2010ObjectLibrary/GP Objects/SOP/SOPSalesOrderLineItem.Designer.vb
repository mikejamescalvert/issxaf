Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10200
    ''' </summary>
    <Persistent("SOP10200")> _
	<OptimisticLocking(False)> _
	Partial Public Class SOPSalesOrderLineItem
		Inherits XPBaseObject

		Public Structure SalesOrderLineItemKey
			Private fSOPTYPE As Short
			<Persistent("SOPTYPE")> _
			Public Property SOPTYPE() As Short
				Get
					Return fSOPTYPE
				End Get
				Set(ByVal value As Short)
					fSOPTYPE = value
				End Set
			End Property
			Private fSOPNUMBE As String
			<Size(21)> _
			<Persistent("SOPNUMBE")> _
			Public Property SOPNUMBE() As String
				Get
					Return fSOPNUMBE
				End Get
				Set(ByVal value As String)
					fSOPNUMBE = value
				End Set
			End Property
			Private fLNITMSEQ As Integer
			<Persistent("LNITMSEQ")> _
			Public Property LNITMSEQ() As Integer
				Get
					Return fLNITMSEQ
				End Get
				Set(ByVal value As Integer)
					fLNITMSEQ = value
				End Set
			End Property
			Private fCMPNTSEQ As Integer
			<Persistent("CMPNTSEQ")> _
			Public Property CMPNTSEQ() As Integer
				Get
					Return fCMPNTSEQ
				End Get
				Set(ByVal value As Integer)
					fCMPNTSEQ = value
				End Set
			End Property
		End Structure

		Private _mOid As SalesOrderLineItemKey
		<Persistent()> _
		<Key()> _
		Public Property Oid() As SalesOrderLineItemKey
			Get
				Return _mOid
			End Get
			Set(ByVal Value As SalesOrderLineItemKey)
				_mOid = Value
			End Set
		End Property


#Region "Properties"




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
		Dim fNONINVEN As Short
		Public Property NONINVEN() As Short
			Get
				Return fNONINVEN
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("NONINVEN", fNONINVEN, value)
			End Set
		End Property
		Dim fDROPSHIP As Short
		Public Property DROPSHIP() As Short
			Get
				Return fDROPSHIP
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("DROPSHIP", fDROPSHIP, value)
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
		Dim fUNITCOST As Decimal
		Public Property UNITCOST() As Decimal
			Get
				Return fUNITCOST
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("UNITCOST", fUNITCOST, value)
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
		Dim fUNITPRCE As Decimal
		Public Property UNITPRCE() As Decimal
			Get
				Return fUNITPRCE
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("UNITPRCE", fUNITPRCE, value)
			End Set
		End Property
		Dim fORUNTPRC As Decimal
		Public Property ORUNTPRC() As Decimal
			Get
				Return fORUNTPRC
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("ORUNTPRC", fORUNTPRC, value)
			End Set
		End Property
		Dim fXTNDPRCE As Decimal
		Public Property XTNDPRCE() As Decimal
			Get
				Return fXTNDPRCE
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("XTNDPRCE", fXTNDPRCE, value)
			End Set
		End Property
		Dim fOXTNDPRC As Decimal
		Public Property OXTNDPRC() As Decimal
			Get
				Return fOXTNDPRC
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("OXTNDPRC", fOXTNDPRC, value)
			End Set
		End Property
		Dim fREMPRICE As Decimal
		Public Property REMPRICE() As Decimal
			Get
				Return fREMPRICE
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("REMPRICE", fREMPRICE, value)
			End Set
		End Property
		Dim fOREPRICE As Decimal
		Public Property OREPRICE() As Decimal
			Get
				Return fOREPRICE
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("OREPRICE", fOREPRICE, value)
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
		Dim fOREXTCST As Decimal
		Public Property OREXTCST() As Decimal
			Get
				Return fOREXTCST
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("OREXTCST", fOREXTCST, value)
			End Set
		End Property
		Dim fMRKDNAMT As Decimal
		Public Property MRKDNAMT() As Decimal
			Get
				Return fMRKDNAMT
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("MRKDNAMT", fMRKDNAMT, value)
			End Set
		End Property
		Dim fORMRKDAM As Decimal
		Public Property ORMRKDAM() As Decimal
			Get
				Return fORMRKDAM
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("ORMRKDAM", fORMRKDAM, value)
			End Set
		End Property
		Dim fMRKDNPCT As Short
		Public Property MRKDNPCT() As Short
			Get
				Return fMRKDNPCT
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("MRKDNPCT", fMRKDNPCT, value)
			End Set
		End Property
		Dim fMRKDNTYP As Short
		Public Property MRKDNTYP() As Short
			Get
				Return fMRKDNTYP
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("MRKDNTYP", fMRKDNTYP, value)
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
		Dim fCSLSINDX As Integer
		Public Property CSLSINDX() As Integer
			Get
				Return fCSLSINDX
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("CSLSINDX", fCSLSINDX, value)
			End Set
		End Property
		Dim fSLSINDX As Integer
		Public Property SLSINDX() As Integer
			Get
				Return fSLSINDX
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("SLSINDX", fSLSINDX, value)
			End Set
		End Property
		Dim fMKDNINDX As Integer
		Public Property MKDNINDX() As Integer
			Get
				Return fMKDNINDX
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("MKDNINDX", fMKDNINDX, value)
			End Set
		End Property
		Dim fRTNSINDX As Integer
		Public Property RTNSINDX() As Integer
			Get
				Return fRTNSINDX
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("RTNSINDX", fRTNSINDX, value)
			End Set
		End Property
		Dim fINUSINDX As Integer
		Public Property INUSINDX() As Integer
			Get
				Return fINUSINDX
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("INUSINDX", fINUSINDX, value)
			End Set
		End Property
		Dim fINSRINDX As Integer
		Public Property INSRINDX() As Integer
			Get
				Return fINSRINDX
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("INSRINDX", fINSRINDX, value)
			End Set
		End Property
		Dim fDMGDINDX As Integer
		Public Property DMGDINDX() As Integer
			Get
				Return fDMGDINDX
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("DMGDINDX", fDMGDINDX, value)
			End Set
		End Property
		Dim fITMTSHID As String
		<Size(15)> _
		Public Property ITMTSHID() As String
			Get
				Return fITMTSHID
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ITMTSHID", fITMTSHID, value)
			End Set
		End Property
		Dim fIVITMTXB As Short
		Public Property IVITMTXB() As Short
			Get
				Return fIVITMTXB
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("IVITMTXB", fIVITMTXB, value)
			End Set
		End Property
		Dim fBKTSLSAM As Decimal
		Public Property BKTSLSAM() As Decimal
			Get
				Return fBKTSLSAM
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("BKTSLSAM", fBKTSLSAM, value)
			End Set
		End Property
		Dim fORBKTSLS As Decimal
		Public Property ORBKTSLS() As Decimal
			Get
				Return fORBKTSLS
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("ORBKTSLS", fORBKTSLS, value)
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
		Dim fTXBTXAMT As Decimal
		Public Property TXBTXAMT() As Decimal
			Get
				Return fTXBTXAMT
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("TXBTXAMT", fTXBTXAMT, value)
			End Set
		End Property
		Dim fOTAXTAMT As Decimal
		Public Property OTAXTAMT() As Decimal
			Get
				Return fOTAXTAMT
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("OTAXTAMT", fOTAXTAMT, value)
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
		Dim fTRDISAMT As Decimal
		Public Property TRDISAMT() As Decimal
			Get
				Return fTRDISAMT
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("TRDISAMT", fTRDISAMT, value)
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
		Dim fDISCSALE As Decimal
		Public Property DISCSALE() As Decimal
			Get
				Return fDISCSALE
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("DISCSALE", fDISCSALE, value)
			End Set
		End Property
		Dim fORDAVSLS As Decimal
		Public Property ORDAVSLS() As Decimal
			Get
				Return fORDAVSLS
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("ORDAVSLS", fORDAVSLS, value)
			End Set
		End Property
		Dim fQUANTITY As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QUANTITY() As Decimal
			Get
				Return fQUANTITY
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QUANTITY", fQUANTITY, value)
			End Set
		End Property
		Dim fATYALLOC As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property ATYALLOC() As Decimal
			Get
				Return fATYALLOC
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("ATYALLOC", fATYALLOC, value)
			End Set
		End Property
		Dim fQTYINSVC As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYINSVC() As Decimal
			Get
				Return fQTYINSVC
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYINSVC", fQTYINSVC, value)
			End Set
		End Property
		Dim fQTYINUSE As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYINUSE() As Decimal
			Get
				Return fQTYINUSE
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYINUSE", fQTYINUSE, value)
			End Set
		End Property
		Dim fQTYDMGED As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYDMGED() As Decimal
			Get
				Return fQTYDMGED
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYDMGED", fQTYDMGED, value)
			End Set
		End Property
		Dim fQTYRTRND As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYRTRND() As Decimal
			Get
				Return fQTYRTRND
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYRTRND", fQTYRTRND, value)
			End Set
		End Property
		Dim fQTYONHND As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYONHND() As Decimal
			Get
				Return fQTYONHND
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYONHND", fQTYONHND, value)
			End Set
		End Property
		Dim fQTYCANCE As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYCANCE() As Decimal
			Get
				Return fQTYCANCE
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYCANCE", fQTYCANCE, value)
			End Set
		End Property
		Dim fQTYCANOT As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYCANOT() As Decimal
			Get
				Return fQTYCANOT
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYCANOT", fQTYCANOT, value)
			End Set
		End Property
		Dim fQTYONPO As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYONPO() As Decimal
			Get
				Return fQTYONPO
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYONPO", fQTYONPO, value)
			End Set
		End Property
		Dim fQTYORDER As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYORDER() As Decimal
			Get
				Return fQTYORDER
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYORDER", fQTYORDER, value)
			End Set
		End Property
		Dim fQTYPRBAC As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYPRBAC() As Decimal
			Get
				Return fQTYPRBAC
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYPRBAC", fQTYPRBAC, value)
			End Set
		End Property
		Dim fQTYPRBOO As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYPRBOO() As Decimal
			Get
				Return fQTYPRBOO
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYPRBOO", fQTYPRBOO, value)
			End Set
		End Property
		Dim fQTYPRINV As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYPRINV() As Decimal
			Get
				Return fQTYPRINV
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYPRINV", fQTYPRINV, value)
			End Set
		End Property
		Dim fQTYPRORD As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYPRORD() As Decimal
			Get
				Return fQTYPRORD
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYPRORD", fQTYPRORD, value)
			End Set
		End Property
		Dim fQTYPRVRECVD As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYPRVRECVD() As Decimal
			Get
				Return fQTYPRVRECVD
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYPRVRECVD", fQTYPRVRECVD, value)
			End Set
		End Property
		Dim fQTYRECVD As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYRECVD() As Decimal
			Get
				Return fQTYRECVD
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYRECVD", fQTYRECVD, value)
			End Set
		End Property
		Dim fQTYREMAI As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYREMAI() As Decimal
			Get
				Return fQTYREMAI
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYREMAI", fQTYREMAI, value)
			End Set
		End Property
		Dim fQTYREMBO As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYREMBO() As Decimal
			Get
				Return fQTYREMBO
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYREMBO", fQTYREMBO, value)
			End Set
		End Property
		Dim fQTYTBAOR As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYTBAOR() As Decimal
			Get
				Return fQTYTBAOR
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYTBAOR", fQTYTBAOR, value)
			End Set
		End Property
		Dim fQTYTOINV As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYTOINV() As Decimal
			Get
				Return fQTYTOINV
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYTOINV", fQTYTOINV, value)
			End Set
		End Property
		Dim fQTYTORDR As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYTORDR() As Decimal
			Get
				Return fQTYTORDR
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYTORDR", fQTYTORDR, value)
			End Set
		End Property
		Dim fQTYFULFI As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYFULFI() As Decimal
			Get
				Return fQTYFULFI
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYFULFI", fQTYFULFI, value)
			End Set
		End Property
		Dim fQTYSLCTD As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYSLCTD() As Decimal
			Get
				Return fQTYSLCTD
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYSLCTD", fQTYSLCTD, value)
			End Set
		End Property
		Dim fQTYBSUOM As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property QTYBSUOM() As Decimal
			Get
				Return fQTYBSUOM
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYBSUOM", fQTYBSUOM, value)
			End Set
		End Property
		Dim fEXTQTYAL As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property EXTQTYAL() As Decimal
			Get
				Return fEXTQTYAL
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("EXTQTYAL", fEXTQTYAL, value)
			End Set
		End Property
		Dim fEXTQTYSEL As Decimal
		<Custom("DisplayFormat", "{0:N}")>
		Public Property EXTQTYSEL() As Decimal
			Get
				Return fEXTQTYSEL
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("EXTQTYSEL", fEXTQTYSEL, value)
			End Set
		End Property
		Dim fReqShipDate As DateTime
		Public Property ReqShipDate() As DateTime
			Get
				Return fReqShipDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("ReqShipDate", fReqShipDate, value)
			End Set
		End Property
		Dim fFUFILDAT As DateTime
		Public Property FUFILDAT() As DateTime
			Get
				Return fFUFILDAT
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("FUFILDAT", fFUFILDAT, value)
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
		Dim fSALSTERR As String
		<Size(15)> _
		Public Property SALSTERR() As String
			Get
				Return fSALSTERR
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SALSTERR", fSALSTERR, value)
			End Set
		End Property
		Dim fSLPRSNID As String
		<Size(15)> _
		Public Property SLPRSNID() As String
			Get
				Return fSLPRSNID
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SLPRSNID", fSLPRSNID, value)
			End Set
		End Property
		Dim fPRCLEVEL As String
		<Size(11)> _
		Public Property PRCLEVEL() As String
			Get
				Return fPRCLEVEL
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("PRCLEVEL", fPRCLEVEL, value)
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
		Dim fBRKFLD1 As Short
		Public Property BRKFLD1() As Short
			Get
				Return fBRKFLD1
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("BRKFLD1", fBRKFLD1, value)
			End Set
		End Property
		Dim fBRKFLD2 As Short
		Public Property BRKFLD2() As Short
			Get
				Return fBRKFLD2
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("BRKFLD2", fBRKFLD2, value)
			End Set
		End Property
		Dim fBRKFLD3 As Short
		Public Property BRKFLD3() As Short
			Get
				Return fBRKFLD3
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("BRKFLD3", fBRKFLD3, value)
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
		Dim fORGSEQNM As Integer
		Public Property ORGSEQNM() As Integer
			Get
				Return fORGSEQNM
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("ORGSEQNM", fORGSEQNM, value)
			End Set
		End Property
		Dim fITEMCODE As String
		<Size(15)> _
		Public Property ITEMCODE() As String
			Get
				Return fITEMCODE
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ITEMCODE", fITEMCODE, value)
			End Set
		End Property
		Dim fPURCHSTAT As Short
		Public Property PURCHSTAT() As Short
			Get
				Return fPURCHSTAT
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("PURCHSTAT", fPURCHSTAT, value)
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
		Dim fDECPLCUR As Short
		Public Property DECPLCUR() As Short
			Get
				Return fDECPLCUR
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("DECPLCUR", fDECPLCUR, value)
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
		Dim fQTYTOSHP As Decimal
		Public Property QTYTOSHP() As Decimal
			Get
				Return fQTYTOSHP
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("QTYTOSHP", fQTYTOSHP, value)
			End Set
		End Property
		Dim fXFRSHDOC As Byte
		Public Property XFRSHDOC() As Byte
			Get
				Return fXFRSHDOC
			End Get
			Set(ByVal value As Byte)
				SetPropertyValue(Of Byte)("XFRSHDOC", fXFRSHDOC, value)
			End Set
		End Property
		Dim fEXCEPTIONALDEMAND As Byte
		Public Property EXCEPTIONALDEMAND() As Byte
			Get
				Return fEXCEPTIONALDEMAND
			End Get
			Set(ByVal value As Byte)
				SetPropertyValue(Of Byte)("EXCEPTIONALDEMAND", fEXCEPTIONALDEMAND, value)
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
		Dim fTXSCHSRC As Short
		Public Property TXSCHSRC() As Short
			Get
				Return fTXSCHSRC
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("TXSCHSRC", fTXSCHSRC, value)
			End Set
		End Property
		Dim fPRSTADCD As String
		<Size(15)> _
		Public Property PRSTADCD() As String
			Get
				Return fPRSTADCD
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("PRSTADCD", fPRSTADCD, value)
			End Set
		End Property
		Dim fShipToName As String
		<Size(65)> _
		Public Property ShipToName() As String
			Get
				Return fShipToName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ShipToName", fShipToName, value)
			End Set
		End Property
		Dim fCNTCPRSN As String
		<Size(61)> _
		Public Property CNTCPRSN() As String
			Get
				Return fCNTCPRSN
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CNTCPRSN", fCNTCPRSN, value)
			End Set
		End Property
		Dim fADDRESS1 As String
		<Size(61)> _
		Public Property ADDRESS1() As String
			Get
				Return fADDRESS1
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ADDRESS1", fADDRESS1, value)
			End Set
		End Property
		Dim fADDRESS2 As String
		<Size(61)> _
		Public Property ADDRESS2() As String
			Get
				Return fADDRESS2
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ADDRESS2", fADDRESS2, value)
			End Set
		End Property
		Dim fADDRESS3 As String
		<Size(61)> _
		Public Property ADDRESS3() As String
			Get
				Return fADDRESS3
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ADDRESS3", fADDRESS3, value)
			End Set
		End Property
		Dim fCITY As String
		<Size(35)> _
		Public Property CITY() As String
			Get
				Return fCITY
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CITY", fCITY, value)
			End Set
		End Property
		Dim fSTATE As String
		<Size(29)> _
		Public Property STATE() As String
			Get
				Return fSTATE
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("STATE", fSTATE, value)
			End Set
		End Property
		Dim fZIPCODE As String
		<Size(11)> _
		Public Property ZIPCODE() As String
			Get
				Return fZIPCODE
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ZIPCODE", fZIPCODE, value)
			End Set
		End Property
		Dim fCCode As String
		<Size(7)> _
		Public Property CCode() As String
			Get
				Return fCCode
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CCode", fCCode, value)
			End Set
		End Property
		Dim fCOUNTRY As String
		<Size(61)> _
		Public Property COUNTRY() As String
			Get
				Return fCOUNTRY
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
			End Set
		End Property
		Dim fPHONE1 As String
		<Size(21)> _
		Public Property PHONE1() As String
			Get
				Return fPHONE1
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("PHONE1", fPHONE1, value)
			End Set
		End Property
		Dim fPHONE2 As String
		<Size(21)> _
		Public Property PHONE2() As String
			Get
				Return fPHONE2
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("PHONE2", fPHONE2, value)
			End Set
		End Property
		Dim fPHONE3 As String
		<Size(21)> _
		Public Property PHONE3() As String
			Get
				Return fPHONE3
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("PHONE3", fPHONE3, value)
			End Set
		End Property
		Dim fFAXNUMBR As String
		<Size(21)> _
		Public Property FAXNUMBR() As String
			Get
				Return fFAXNUMBR
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("FAXNUMBR", fFAXNUMBR, value)
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
		Dim fBackoutTradeDisc As Decimal
		Public Property BackoutTradeDisc() As Decimal
			Get
				Return fBackoutTradeDisc
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("BackoutTradeDisc", fBackoutTradeDisc, value)
			End Set
		End Property
		Dim fOrigBackoutTradeDisc As Decimal
		Public Property OrigBackoutTradeDisc() As Decimal
			Get
				Return fOrigBackoutTradeDisc
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("OrigBackoutTradeDisc", fOrigBackoutTradeDisc, value)
			End Set
		End Property
		Dim fGPSFOINTEGRATIONID As String
		<Size(31)> _
		Public Property GPSFOINTEGRATIONID() As String
			Get
				Return fGPSFOINTEGRATIONID
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("GPSFOINTEGRATIONID", fGPSFOINTEGRATIONID, value)
			End Set
		End Property
		Dim fINTEGRATIONSOURCE As Short
		Public Property INTEGRATIONSOURCE() As Short
			Get
				Return fINTEGRATIONSOURCE
			End Get
			Set(ByVal value As Short)
				SetPropertyValue(Of Short)("INTEGRATIONSOURCE", fINTEGRATIONSOURCE, value)
			End Set
		End Property
		Dim fINTEGRATIONID As String
		<Size(31)> _
		Public Property INTEGRATIONID() As String
			Get
				Return fINTEGRATIONID
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("INTEGRATIONID", fINTEGRATIONID, value)
			End Set
		End Property
		Dim fCONTNBR As String
		<Size(11)> _
		Public Property CONTNBR() As String
			Get
				Return fCONTNBR
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CONTNBR", fCONTNBR, value)
			End Set
		End Property
		Dim fCONTLNSEQNBR As Decimal
		Public Property CONTLNSEQNBR() As Decimal
			Get
				Return fCONTLNSEQNBR
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue(Of Decimal)("CONTLNSEQNBR", fCONTLNSEQNBR, value)
			End Set
		End Property
		Dim fCONTSTARTDTE As DateTime
		Public Property CONTSTARTDTE() As DateTime
			Get
				Return fCONTSTARTDTE
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("CONTSTARTDTE", fCONTSTARTDTE, value)
			End Set
		End Property
		Dim fCONTENDDTE As DateTime
		Public Property CONTENDDTE() As DateTime
			Get
				Return fCONTENDDTE
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("CONTENDDTE", fCONTENDDTE, value)
			End Set
		End Property
		Dim fCONTITEMNBR As String
		<Size(31)> _
		Public Property CONTITEMNBR() As String
			Get
				Return fCONTITEMNBR
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CONTITEMNBR", fCONTITEMNBR, value)
			End Set
		End Property
		Dim fCONTSERIALNBR As String
		<Size(21)> _
		Public Property CONTSERIALNBR() As String
			Get
				Return fCONTSERIALNBR
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CONTSERIALNBR", fCONTSERIALNBR, value)
			End Set
		End Property
		Dim fBULKPICKPRNT As Byte
		Public Property BULKPICKPRNT() As Byte
			Get
				Return fBULKPICKPRNT
			End Get
			Set(ByVal value As Byte)
				SetPropertyValue(Of Byte)("BULKPICKPRNT", fBULKPICKPRNT, value)
			End Set
		End Property
		Dim fINDPICKPRNT As Byte
		Public Property INDPICKPRNT() As Byte
			Get
				Return fINDPICKPRNT
			End Get
			Set(ByVal value As Byte)
				SetPropertyValue(Of Byte)("INDPICKPRNT", fINDPICKPRNT, value)
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
		Dim fSOFULFILLMENTBIN As String
		<Size(15)> _
		Public Property SOFULFILLMENTBIN() As String
			Get
				Return fSOFULFILLMENTBIN
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SOFULFILLMENTBIN", fSOFULFILLMENTBIN, value)
			End Set
		End Property
		Dim fMULTIPLEBINS As Byte
		Public Property MULTIPLEBINS() As Byte
			Get
				Return fMULTIPLEBINS
			End Get
			Set(ByVal value As Byte)
				SetPropertyValue(Of Byte)("MULTIPLEBINS", fMULTIPLEBINS, value)
			End Set
		End Property


#End Region

#Region "Non-Persistent Properties"



#End Region


		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class

End Namespace