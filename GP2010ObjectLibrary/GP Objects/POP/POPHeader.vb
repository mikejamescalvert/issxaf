Imports DevExpress.Xpo
Imports System.ComponentModel

Namespace Objects.POP
    ''' <summary>
    ''' GP Table PM10100
    ''' </summary>
    <Persistent("POP10100")>
    <DefaultProperty("PONUMBER")>
    Public Class POPHeader
        Inherits XPLiteObject
        Dim fPONUMBER As String
        <Key()>
        <Size(17)>
        Public Property PONUMBER() As String
            Get
                Return fPONUMBER
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PONUMBER", fPONUMBER, value)
            End Set
        End Property
        Dim fPOSTATUS As Short
        Public Property POSTATUS() As Short
            Get
                Return fPOSTATUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POSTATUS", fPOSTATUS, value)
            End Set
        End Property
        Dim fSTATGRP As Short
        Public Property STATGRP() As Short
            Get
                Return fSTATGRP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("STATGRP", fSTATGRP, value)
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
        Dim fCONFIRM1 As String
        <Size(21)>
        Public Property CONFIRM1() As String
            Get
                Return fCONFIRM1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CONFIRM1", fCONFIRM1, value)
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
        Dim fLSTEDTDT As DateTime
        Public Property LSTEDTDT() As DateTime
            Get
                Return fLSTEDTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTEDTDT", fLSTEDTDT, value)
            End Set
        End Property
        Dim fLSTPRTDT As DateTime
        Public Property LSTPRTDT() As DateTime
            Get
                Return fLSTPRTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTPRTDT", fLSTPRTDT, value)
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
        Dim fREQDATE As DateTime
        Public Property REQDATE() As DateTime
            Get
                Return fREQDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("REQDATE", fREQDATE, value)
            End Set
        End Property
        Dim fREQTNDT As DateTime
        Public Property REQTNDT() As DateTime
            Get
                Return fREQTNDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("REQTNDT", fREQTNDT, value)
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
        Dim fREMSUBTO As Decimal
        Public Property REMSUBTO() As Decimal
            Get
                Return fREMSUBTO
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("REMSUBTO", fREMSUBTO, value)
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
        Dim fFRTAMNT As Decimal
        Public Property FRTAMNT() As Decimal
            Get
                Return fFRTAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FRTAMNT", fFRTAMNT, value)
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
        Dim fTAXAMNT As Decimal
        Public Property TAXAMNT() As Decimal
            Get
                Return fTAXAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TAXAMNT", fTAXAMNT, value)
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
        Dim fMINORDER As Decimal
        Public Property MINORDER() As Decimal
            Get
                Return fMINORDER
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MINORDER", fMINORDER, value)
            End Set
        End Property
        Dim fVADCDPAD As String
        <Size(15)>
        Public Property VADCDPAD() As String
            Get
                Return fVADCDPAD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VADCDPAD", fVADCDPAD, value)
            End Set
        End Property
        Dim fCMPANYID As Short
        Public Property CMPANYID() As Short
            Get
                Return fCMPANYID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CMPANYID", fCMPANYID, value)
            End Set
        End Property
        Dim fPRBTADCD As String
        <Size(15)>
        Public Property PRBTADCD() As String
            Get
                Return fPRBTADCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRBTADCD", fPRBTADCD, value)
            End Set
        End Property
        Dim fPRSTADCD As String
        <Size(15)>
        Public Property PRSTADCD() As String
            Get
                Return fPRSTADCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRSTADCD", fPRSTADCD, value)
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
        Dim fDSCDLRAM As Decimal
        Public Property DSCDLRAM() As Decimal
            Get
                Return fDSCDLRAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DSCDLRAM", fDSCDLRAM, value)
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
        Dim fDISAMTAV As Decimal
        Public Property DISAMTAV() As Decimal
            Get
                Return fDISAMTAV
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISAMTAV", fDISAMTAV, value)
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
        Dim fTRDPCTPR As Decimal
        Public Property TRDPCTPR() As Decimal
            Get
                Return fTRDPCTPR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TRDPCTPR", fTRDPCTPR, value)
            End Set
        End Property
        Dim fCUSTNMBR As String
        <Size(15)>
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property
        Dim fTIMESPRT As Short
        Public Property TIMESPRT() As Short
            Get
                Return fTIMESPRT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TIMESPRT", fTIMESPRT, value)
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
        Dim fPONOTIDS_1 As Decimal
        Public Property PONOTIDS_1() As Decimal
            Get
                Return fPONOTIDS_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_1", fPONOTIDS_1, value)
            End Set
        End Property
        Dim fPONOTIDS_2 As Decimal
        Public Property PONOTIDS_2() As Decimal
            Get
                Return fPONOTIDS_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_2", fPONOTIDS_2, value)
            End Set
        End Property
        Dim fPONOTIDS_3 As Decimal
        Public Property PONOTIDS_3() As Decimal
            Get
                Return fPONOTIDS_3
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_3", fPONOTIDS_3, value)
            End Set
        End Property
        Dim fPONOTIDS_4 As Decimal
        Public Property PONOTIDS_4() As Decimal
            Get
                Return fPONOTIDS_4
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_4", fPONOTIDS_4, value)
            End Set
        End Property
        Dim fPONOTIDS_5 As Decimal
        Public Property PONOTIDS_5() As Decimal
            Get
                Return fPONOTIDS_5
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_5", fPONOTIDS_5, value)
            End Set
        End Property
        Dim fPONOTIDS_6 As Decimal
        Public Property PONOTIDS_6() As Decimal
            Get
                Return fPONOTIDS_6
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_6", fPONOTIDS_6, value)
            End Set
        End Property
        Dim fPONOTIDS_7 As Decimal
        Public Property PONOTIDS_7() As Decimal
            Get
                Return fPONOTIDS_7
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_7", fPONOTIDS_7, value)
            End Set
        End Property
        Dim fPONOTIDS_8 As Decimal
        Public Property PONOTIDS_8() As Decimal
            Get
                Return fPONOTIDS_8
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_8", fPONOTIDS_8, value)
            End Set
        End Property
        Dim fPONOTIDS_9 As Decimal
        Public Property PONOTIDS_9() As Decimal
            Get
                Return fPONOTIDS_9
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_9", fPONOTIDS_9, value)
            End Set
        End Property
        Dim fPONOTIDS_10 As Decimal
        Public Property PONOTIDS_10() As Decimal
            Get
                Return fPONOTIDS_10
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_10", fPONOTIDS_10, value)
            End Set
        End Property
        Dim fPONOTIDS_11 As Decimal
        Public Property PONOTIDS_11() As Decimal
            Get
                Return fPONOTIDS_11
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_11", fPONOTIDS_11, value)
            End Set
        End Property
        Dim fPONOTIDS_12 As Decimal
        Public Property PONOTIDS_12() As Decimal
            Get
                Return fPONOTIDS_12
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_12", fPONOTIDS_12, value)
            End Set
        End Property
        Dim fPONOTIDS_13 As Decimal
        Public Property PONOTIDS_13() As Decimal
            Get
                Return fPONOTIDS_13
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_13", fPONOTIDS_13, value)
            End Set
        End Property
        Dim fPONOTIDS_14 As Decimal
        Public Property PONOTIDS_14() As Decimal
            Get
                Return fPONOTIDS_14
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_14", fPONOTIDS_14, value)
            End Set
        End Property
        Dim fPONOTIDS_15 As Decimal
        Public Property PONOTIDS_15() As Decimal
            Get
                Return fPONOTIDS_15
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PONOTIDS_15", fPONOTIDS_15, value)
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
        Dim fCANCSUB As Decimal
        Public Property CANCSUB() As Decimal
            Get
                Return fCANCSUB
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CANCSUB", fCANCSUB, value)
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
        Dim fOREMSUBT As Decimal
        Public Property OREMSUBT() As Decimal
            Get
                Return fOREMSUBT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OREMSUBT", fOREMSUBT, value)
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
        Dim fOriginating_Canceled_Sub As Decimal
        Public Property Originating_Canceled_Sub() As Decimal
            Get
                Return fOriginating_Canceled_Sub
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Originating_Canceled_Sub", fOriginating_Canceled_Sub, value)
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
        Dim fOMISCAMT As Decimal
        Public Property OMISCAMT() As Decimal
            Get
                Return fOMISCAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OMISCAMT", fOMISCAMT, value)
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
        Dim fORDDLRAT As Decimal
        Public Property ORDDLRAT() As Decimal
            Get
                Return fORDDLRAT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDDLRAT", fORDDLRAT, value)
            End Set
        End Property
        Dim fODISAMTAV As Decimal
        Public Property ODISAMTAV() As Decimal
            Get
                Return fODISAMTAV
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ODISAMTAV", fODISAMTAV, value)
            End Set
        End Property
        Dim fBUYERID As String
        <Size(15)>
        Public Property BUYERID() As String
            Get
                Return fBUYERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BUYERID", fBUYERID, value)
            End Set
        End Property
        Dim fONORDAMT As Decimal
        Public Property ONORDAMT() As Decimal
            Get
                Return fONORDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ONORDAMT", fONORDAMT, value)
            End Set
        End Property
        Dim fORORDAMT As Decimal
        Public Property ORORDAMT() As Decimal
            Get
                Return fORORDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORORDAMT", fORORDAMT, value)
            End Set
        End Property
        Dim fHOLD As Byte
        Public Property HOLD() As Byte
            Get
                Return fHOLD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("HOLD", fHOLD, value)
            End Set
        End Property
        Dim fONHOLDDATE As DateTime
        Public Property ONHOLDDATE() As DateTime
            Get
                Return fONHOLDDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ONHOLDDATE", fONHOLDDATE, value)
            End Set
        End Property
        Dim fONHOLDBY As String
        <Size(15)>
        Public Property ONHOLDBY() As String
            Get
                Return fONHOLDBY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ONHOLDBY", fONHOLDBY, value)
            End Set
        End Property
        Dim fHOLDREMOVEDATE As DateTime
        Public Property HOLDREMOVEDATE() As DateTime
            Get
                Return fHOLDREMOVEDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("HOLDREMOVEDATE", fHOLDREMOVEDATE, value)
            End Set
        End Property
        Dim fHOLDREMOVEBY As String
        <Size(15)>
        Public Property HOLDREMOVEBY() As String
            Get
                Return fHOLDREMOVEBY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HOLDREMOVEBY", fHOLDREMOVEBY, value)
            End Set
        End Property
        Dim fALLOWSOCMTS As Byte
        Public Property ALLOWSOCMTS() As Byte
            Get
                Return fALLOWSOCMTS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLOWSOCMTS", fALLOWSOCMTS, value)
            End Set
        End Property
        Dim fDISGRPER As Short
        Public Property DISGRPER() As Short
            Get
                Return fDISGRPER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DISGRPER", fDISGRPER, value)
            End Set
        End Property
        Dim fDUEGRPER As Short
        Public Property DUEGRPER() As Short
            Get
                Return fDUEGRPER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DUEGRPER", fDUEGRPER, value)
            End Set
        End Property
        Dim fRevision_Number As Short
        Public Property Revision_Number() As Short
            Get
                Return fRevision_Number
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Revision_Number", fRevision_Number, value)
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
        Dim fPO_Status_Orig As Short
        Public Property PO_Status_Orig() As Short
            Get
                Return fPO_Status_Orig
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PO_Status_Orig", fPO_Status_Orig, value)
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
        Dim fTXSCHSRC As Short
        Public Property TXSCHSRC() As Short
            Get
                Return fTXSCHSRC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TXSCHSRC", fTXSCHSRC, value)
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
        Dim fFlags As Short
        Public Property Flags() As Short
            Get
                Return fFlags
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Flags", fFlags, value)
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
        Dim fPOPCONTNUM As String
        <Size(21)>
        Public Property POPCONTNUM() As String
            Get
                Return fPOPCONTNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("POPCONTNUM", fPOPCONTNUM, value)
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
        Dim fCNTRLBLKTBY As Short
        Public Property CNTRLBLKTBY() As Short
            Get
                Return fCNTRLBLKTBY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CNTRLBLKTBY", fCNTRLBLKTBY, value)
            End Set
        End Property
        Dim fPURCHCMPNYNAM As String
        <Size(65)>
        Public Property PURCHCMPNYNAM() As String
            Get
                Return fPURCHCMPNYNAM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHCMPNYNAM", fPURCHCMPNYNAM, value)
            End Set
        End Property
        Dim fPURCHCONTACT As String
        <Size(61)>
        Public Property PURCHCONTACT() As String
            Get
                Return fPURCHCONTACT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHCONTACT", fPURCHCONTACT, value)
            End Set
        End Property
        Dim fPURCHADDRESS1 As String
        <Size(61)>
        Public Property PURCHADDRESS1() As String
            Get
                Return fPURCHADDRESS1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHADDRESS1", fPURCHADDRESS1, value)
            End Set
        End Property
        Dim fPURCHADDRESS2 As String
        <Size(61)>
        Public Property PURCHADDRESS2() As String
            Get
                Return fPURCHADDRESS2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHADDRESS2", fPURCHADDRESS2, value)
            End Set
        End Property
        Dim fPURCHADDRESS3 As String
        <Size(61)>
        Public Property PURCHADDRESS3() As String
            Get
                Return fPURCHADDRESS3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHADDRESS3", fPURCHADDRESS3, value)
            End Set
        End Property
        Dim fPURCHCITY As String
        <Size(35)>
        Public Property PURCHCITY() As String
            Get
                Return fPURCHCITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHCITY", fPURCHCITY, value)
            End Set
        End Property
        Dim fPURCHSTATE As String
        <Size(29)>
        Public Property PURCHSTATE() As String
            Get
                Return fPURCHSTATE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHSTATE", fPURCHSTATE, value)
            End Set
        End Property
        Dim fPURCHZIPCODE As String
        <Size(11)>
        Public Property PURCHZIPCODE() As String
            Get
                Return fPURCHZIPCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHZIPCODE", fPURCHZIPCODE, value)
            End Set
        End Property
        Dim fPURCHCCode As String
        <Size(7)>
        Public Property PURCHCCode() As String
            Get
                Return fPURCHCCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHCCode", fPURCHCCode, value)
            End Set
        End Property
        Dim fPURCHCOUNTRY As String
        <Size(61)>
        Public Property PURCHCOUNTRY() As String
            Get
                Return fPURCHCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHCOUNTRY", fPURCHCOUNTRY, value)
            End Set
        End Property
        Dim fPURCHPHONE1 As String
        <Size(21)>
        Public Property PURCHPHONE1() As String
            Get
                Return fPURCHPHONE1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHPHONE1", fPURCHPHONE1, value)
            End Set
        End Property
        Dim fPURCHPHONE2 As String
        <Size(21)>
        Public Property PURCHPHONE2() As String
            Get
                Return fPURCHPHONE2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHPHONE2", fPURCHPHONE2, value)
            End Set
        End Property
        Dim fPURCHPHONE3 As String
        <Size(21)>
        Public Property PURCHPHONE3() As String
            Get
                Return fPURCHPHONE3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHPHONE3", fPURCHPHONE3, value)
            End Set
        End Property
        Dim fPURCHFAX As String
        <Size(21)>
        Public Property PURCHFAX() As String
            Get
                Return fPURCHFAX
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PURCHFAX", fPURCHFAX, value)
            End Set
        End Property
        Dim fBLNKTLINEEXTQTYSUM As Decimal
        Public Property BLNKTLINEEXTQTYSUM() As Decimal
            Get
                Return fBLNKTLINEEXTQTYSUM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BLNKTLINEEXTQTYSUM", fBLNKTLINEEXTQTYSUM, value)
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
        Dim fWorkflow_Approval_Status As Short
        Public Property Workflow_Approval_Status() As Short
            Get
                Return fWorkflow_Approval_Status
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Workflow_Approval_Status", fWorkflow_Approval_Status, value)
            End Set
        End Property
        Dim fWorkflow_Priority As Short
        Public Property Workflow_Priority() As Short
            Get
                Return fWorkflow_Priority
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Workflow_Priority", fWorkflow_Priority, value)
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
