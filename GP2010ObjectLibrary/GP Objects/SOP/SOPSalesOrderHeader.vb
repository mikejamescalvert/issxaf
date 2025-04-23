Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation


Namespace Objects.SOP


    ''' <summary>
    ''' GP Table SOP10100
    ''' </summary>
    <Persistent("SOP10100")> _
    <OptimisticLocking(False)> _
    <DefaultProperty("Oid.SOPNUMBE")>
    Public Class SOPSalesOrderHeader
        Inherits XPBaseObject

        Public Structure SalesOrderHeaderKey
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
        End Structure

#Region "Properties"

        Private _mOid As SalesOrderHeaderKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As SalesOrderHeaderKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As SalesOrderHeaderKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property

        ' Private _mCustomer As RM.RMCustomer
        <PersistentAlias("[<RMCustomer>][CUSTNMBR = ^.CUSTNMBR].Single()")>
        Public ReadOnly Property Customer As RM.RMCustomer
            Get
                'If _mCustomer Is Nothing Then
                '    _mCustomer = Session.FindObject(Of RM.RMCustomer)(New BinaryOperator("CUSTNMBR", CUSTNMBR))
                'End If
                'Return _mCustomer
                Return TryCast(EvaluateAlias("Customer"), RM.RMCustomer)
            End Get
        End Property

        Dim fORIGTYPE As Short
        Public Property ORIGTYPE() As Short
            Get
                Return fORIGTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORIGTYPE", fORIGTYPE, value)
            End Set
        End Property
        Dim fORIGNUMB As String
        <Size(21)> _
        Public Property ORIGNUMB() As String
            Get
                Return fORIGNUMB
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORIGNUMB", fORIGNUMB, value)
            End Set
        End Property
        Dim fDOCID As String
        <Size(15)> _
        Public Property DOCID() As String
            Get
                Return fDOCID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DOCID", fDOCID, value)
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
        Dim fGLPOSTDT As DateTime
        Public Property GLPOSTDT() As DateTime
            Get
                Return fGLPOSTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("GLPOSTDT", fGLPOSTDT, value)
            End Set
        End Property
        Dim fQUOTEDAT As DateTime
        Public Property QUOTEDAT() As DateTime
            Get
                Return fQUOTEDAT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("QUOTEDAT", fQUOTEDAT, value)
            End Set
        End Property
        Dim fQUOEXPDA As DateTime
        Public Property QUOEXPDA() As DateTime
            Get
                Return fQUOEXPDA
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("QUOEXPDA", fQUOEXPDA, value)
            End Set
        End Property
        Dim fORDRDATE As DateTime
        Public Property ORDRDATE() As DateTime
            Get
                Return fORDRDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ORDRDATE", fORDRDATE, value)
            End Set
        End Property
        Dim fINVODATE As DateTime
        Public Property INVODATE() As DateTime
            Get
                Return fINVODATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("INVODATE", fINVODATE, value)
            End Set
        End Property
        Dim fBACKDATE As DateTime
        Public Property BACKDATE() As DateTime
            Get
                Return fBACKDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("BACKDATE", fBACKDATE, value)
            End Set
        End Property
        Dim fRETUDATE As DateTime
        Public Property RETUDATE() As DateTime
            Get
                Return fRETUDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("RETUDATE", fRETUDATE, value)
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
        Dim fREPTING As Byte
        Public Property REPTING() As Byte
            Get
                Return fREPTING
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("REPTING", fREPTING, value)
            End Set
        End Property
        Dim fTRXFREQU As Short
        Public Property TRXFREQU() As Short
            Get
                Return fTRXFREQU
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TRXFREQU", fTRXFREQU, value)
            End Set
        End Property
        Dim fTIMEREPD As Short
        Public Property TIMEREPD() As Short
            Get
                Return fTIMEREPD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TIMEREPD", fTIMEREPD, value)
            End Set
        End Property
        Dim fTIMETREP As Short
        Public Property TIMETREP() As Short
            Get
                Return fTIMETREP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TIMETREP", fTIMETREP, value)
            End Set
        End Property
        Dim fDYSTINCR As Short
        Public Property DYSTINCR() As Short
            Get
                Return fDYSTINCR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DYSTINCR", fDYSTINCR, value)
            End Set
        End Property
        Dim fDTLSTREP As DateTime
        Public Property DTLSTREP() As DateTime
            Get
                Return fDTLSTREP
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DTLSTREP", fDTLSTREP, value)
            End Set
        End Property
        Dim fDSTBTCH1 As String
        <Size(15)> _
        Public Property DSTBTCH1() As String
            Get
                Return fDSTBTCH1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DSTBTCH1", fDSTBTCH1, value)
            End Set
        End Property
        Dim fDSTBTCH2 As String
        <Size(15)> _
        Public Property DSTBTCH2() As String
            Get
                Return fDSTBTCH2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DSTBTCH2", fDSTBTCH2, value)
            End Set
        End Property
        Dim fUSDOCID1 As String
        <Size(15)> _
        Public Property USDOCID1() As String
            Get
                Return fUSDOCID1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USDOCID1", fUSDOCID1, value)
            End Set
        End Property
        Dim fUSDOCID2 As String
        <Size(15)> _
        Public Property USDOCID2() As String
            Get
                Return fUSDOCID2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USDOCID2", fUSDOCID2, value)
            End Set
        End Property
        Dim fDISCFRGT As Decimal
        Public Property DISCFRGT() As Decimal
            Get
                Return fDISCFRGT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISCFRGT", fDISCFRGT, value)
            End Set
        End Property
        Dim fORDAVFRT As Decimal
        Public Property ORDAVFRT() As Decimal
            Get
                Return fORDAVFRT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDAVFRT", fORDAVFRT, value)
            End Set
        End Property
        Dim fDISCMISC As Decimal
        Public Property DISCMISC() As Decimal
            Get
                Return fDISCMISC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISCMISC", fDISCMISC, value)
            End Set
        End Property
        Dim fORDAVMSC As Decimal
        Public Property ORDAVMSC() As Decimal
            Get
                Return fORDAVMSC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDAVMSC", fORDAVMSC, value)
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
        Dim fORDAVAMT As Decimal
        Public Property ORDAVAMT() As Decimal
            Get
                Return fORDAVAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDAVAMT", fORDAVAMT, value)
            End Set
        End Property
        Dim fDISCRTND As Decimal
        Public Property DISCRTND() As Decimal
            Get
                Return fDISCRTND
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISCRTND", fDISCRTND, value)
            End Set
        End Property
        Dim fORDISRTD As Decimal
        Public Property ORDISRTD() As Decimal
            Get
                Return fORDISRTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDISRTD", fORDISRTD, value)
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
        Dim fORDISTKN As Decimal
        Public Property ORDISTKN() As Decimal
            Get
                Return fORDISTKN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDISTKN", fORDISTKN, value)
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
        Dim fORDDLRAT As Decimal
        Public Property ORDDLRAT() As Decimal
            Get
                Return fORDDLRAT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDDLRAT", fORDDLRAT, value)
            End Set
        End Property
        Dim fDISAVTKN As Decimal
        Public Property DISAVTKN() As Decimal
            Get
                Return fDISAVTKN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISAVTKN", fDISAVTKN, value)
            End Set
        End Property
        Dim fORDATKN As Decimal
        Public Property ORDATKN() As Decimal
            Get
                Return fORDATKN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDATKN", fORDATKN, value)
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
        Dim fBCHSOURC As String
        <Size(15)> _
        Public Property BCHSOURC() As String
            Get
                Return fBCHSOURC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BCHSOURC", fBCHSOURC, value)
            End Set
        End Property
        Dim fBACHNUMB As String
        <Size(15)> _
        Public Property BACHNUMB() As String
            Get
                Return fBACHNUMB
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BACHNUMB", fBACHNUMB, value)
            End Set
        End Property
        Dim fCUSTNMBR As String
        <Size(15)> _
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property
        Public Function GetGPCustomer() As RM.RMCustomer
            Return Session.FindObject(GetType(RM.RMCustomer), New DevExpress.Data.Filtering.BinaryOperator("CUSTNMBR", Me.CUSTNMBR, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
        End Function

        Dim fCUSTNAME As String
        <Size(65)> _
        Public Property CUSTNAME() As String
            Get
                Return fCUSTNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNAME", fCUSTNAME, value)
            End Set
        End Property
        Dim fCSTPONBR As String
        <Size(21)> _
        Public Property CSTPONBR() As String
            Get
                Return fCSTPONBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CSTPONBR", fCSTPONBR, value)
            End Set
        End Property
        Dim fPROSPECT As Short
        Public Property PROSPECT() As Short
            Get
                Return fPROSPECT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PROSPECT", fPROSPECT, value)
            End Set
        End Property
        Dim fMSTRNUMB As Integer
        Public Property MSTRNUMB() As Integer
            Get
                Return fMSTRNUMB
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("MSTRNUMB", fMSTRNUMB, value)
            End Set
        End Property
        Dim fPCKSLPNO As String
        <Size(21)> _
        Public Property PCKSLPNO() As String
            Get
                Return fPCKSLPNO
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PCKSLPNO", fPCKSLPNO, value)
            End Set
        End Property
        Dim fPICTICNU As String
        <Size(21)> _
        Public Property PICTICNU() As String
            Get
                Return fPICTICNU
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PICTICNU", fPICTICNU, value)
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
        Dim fPRBTADCD As String
        <Size(15)> _
        Public Property PRBTADCD() As String
            Get
                Return fPRBTADCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRBTADCD", fPRBTADCD, value)
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
        Dim fPHNUMBR1 As String
        <Size(21)> _
        Public Property PHNUMBR1() As String
            Get
                Return fPHNUMBR1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHNUMBR1", fPHNUMBR1, value)
            End Set
        End Property
        Dim fPHNUMBR2 As String
        <Size(21)> _
        Public Property PHNUMBR2() As String
            Get
                Return fPHNUMBR2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHNUMBR2", fPHNUMBR2, value)
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
        Dim fCOMAPPTO As Short
        Public Property COMAPPTO() As Short
            Get
                Return fCOMAPPTO
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("COMAPPTO", fCOMAPPTO, value)
            End Set
        End Property
        Dim fCOMMAMNT As Decimal
        Public Property COMMAMNT() As Decimal
            Get
                Return fCOMMAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("COMMAMNT", fCOMMAMNT, value)
            End Set
        End Property
        Dim fOCOMMAMT As Decimal
        Public Property OCOMMAMT() As Decimal
            Get
                Return fOCOMMAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OCOMMAMT", fOCOMMAMT, value)
            End Set
        End Property
        Dim fCMMSLAMT As Decimal
        Public Property CMMSLAMT() As Decimal
            Get
                Return fCMMSLAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CMMSLAMT", fCMMSLAMT, value)
            End Set
        End Property
        Dim fORCOSAMT As Decimal
        Public Property ORCOSAMT() As Decimal
            Get
                Return fORCOSAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORCOSAMT", fORCOSAMT, value)
            End Set
        End Property
        Dim fNCOMAMNT As Decimal
        Public Property NCOMAMNT() As Decimal
            Get
                Return fNCOMAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NCOMAMNT", fNCOMAMNT, value)
            End Set
        End Property
        Dim fORNCMAMT As Decimal
        Public Property ORNCMAMT() As Decimal
            Get
                Return fORNCMAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORNCMAMT", fORNCMAMT, value)
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
        Dim fTRDISPCT As Short
        Public Property TRDISPCT() As Short
            Get
                Return fTRDISPCT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TRDISPCT", fTRDISPCT, value)
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
        Dim fORSUBTOT As Decimal
        Public Property ORSUBTOT() As Decimal
            Get
                Return fORSUBTOT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORSUBTOT", fORSUBTOT, value)
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
        Dim fOREMSUBT As Decimal
        Public Property OREMSUBT() As Decimal
            Get
                Return fOREMSUBT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OREMSUBT", fOREMSUBT, value)
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
        Dim fFRTAMNT As Decimal
        Public Property FRTAMNT() As Decimal
            Get
                Return fFRTAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FRTAMNT", fFRTAMNT, value)
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
        Dim fMISCAMNT As Decimal
        Public Property MISCAMNT() As Decimal
            Get
                Return fMISCAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MISCAMNT", fMISCAMNT, value)
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
        Dim fTXENGCLD As Byte
        Public Property TXENGCLD() As Byte
            Get
                Return fTXENGCLD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TXENGCLD", fTXENGCLD, value)
            End Set
        End Property
        Dim fTAXEXMT1 As String
        <Size(25)> _
        Public Property TAXEXMT1() As String
            Get
                Return fTAXEXMT1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXEXMT1", fTAXEXMT1, value)
            End Set
        End Property
        Dim fTAXEXMT2 As String
        <Size(25)> _
        Public Property TAXEXMT2() As String
            Get
                Return fTAXEXMT2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXEXMT2", fTAXEXMT2, value)
            End Set
        End Property
        Dim fTXRGNNUM As String
        <Size(25)> _
        Public Property TXRGNNUM() As String
            Get
                Return fTXRGNNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXRGNNUM", fTXRGNNUM, value)
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
        Dim fBSIVCTTL As Byte
        Public Property BSIVCTTL() As Byte
            Get
                Return fBSIVCTTL
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BSIVCTTL", fBSIVCTTL, value)
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
        Dim fFRGTTXBL As Short
        Public Property FRGTTXBL() As Short
            Get
                Return fFRGTTXBL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FRGTTXBL", fFRGTTXBL, value)
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
        Dim fMISCTXBL As Short
        Public Property MISCTXBL() As Short
            Get
                Return fMISCTXBL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MISCTXBL", fMISCTXBL, value)
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
        Dim fORBKTFRT As Decimal
        Public Property ORBKTFRT() As Decimal
            Get
                Return fORBKTFRT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORBKTFRT", fORBKTFRT, value)
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
        Dim fORBKTMSC As Decimal
        Public Property ORBKTMSC() As Decimal
            Get
                Return fORBKTMSC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORBKTMSC", fORBKTMSC, value)
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
        Dim fECTRX As Byte
        Public Property ECTRX() As Byte
            Get
                Return fECTRX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ECTRX", fECTRX, value)
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
        Dim fORDOCAMT As Decimal
        Public Property ORDOCAMT() As Decimal
            Get
                Return fORDOCAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDOCAMT", fORDOCAMT, value)
            End Set
        End Property
        Dim fPYMTRCVD As Decimal
        Public Property PYMTRCVD() As Decimal
            Get
                Return fPYMTRCVD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PYMTRCVD", fPYMTRCVD, value)
            End Set
        End Property
        Dim fORPMTRVD As Decimal
        Public Property ORPMTRVD() As Decimal
            Get
                Return fORPMTRVD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORPMTRVD", fORPMTRVD, value)
            End Set
        End Property
        Dim fDEPRECVD As Decimal
        Public Property DEPRECVD() As Decimal
            Get
                Return fDEPRECVD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DEPRECVD", fDEPRECVD, value)
            End Set
        End Property
        Dim fORDEPRVD As Decimal
        Public Property ORDEPRVD() As Decimal
            Get
                Return fORDEPRVD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDEPRVD", fORDEPRVD, value)
            End Set
        End Property
        Dim fCODAMNT As Decimal
        Public Property CODAMNT() As Decimal
            Get
                Return fCODAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CODAMNT", fCODAMNT, value)
            End Set
        End Property
        Dim fORCODAMT As Decimal
        Public Property ORCODAMT() As Decimal
            Get
                Return fORCODAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORCODAMT", fORCODAMT, value)
            End Set
        End Property
        Dim fACCTAMNT As Decimal
        Public Property ACCTAMNT() As Decimal
            Get
                Return fACCTAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ACCTAMNT", fACCTAMNT, value)
            End Set
        End Property
        Dim fORACTAMT As Decimal
        Public Property ORACTAMT() As Decimal
            Get
                Return fORACTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORACTAMT", fORACTAMT, value)
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
        Dim fUPSZONE As String
        <Size(3)> _
        Public Property UPSZONE() As String
            Get
                Return fUPSZONE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UPSZONE", fUPSZONE, value)
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
        Dim fPSTGSTUS As Short
        Public Property PSTGSTUS() As Short
            Get
                Return fPSTGSTUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PSTGSTUS", fPSTGSTUS, value)
            End Set
        End Property
        Dim fVOIDSTTS As Short
        Public Property VOIDSTTS() As Short
            Get
                Return fVOIDSTTS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("VOIDSTTS", fVOIDSTTS, value)
            End Set
        End Property
        Dim fALLOCABY As Short
        Public Property ALLOCABY() As Short
            Get
                Return fALLOCABY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ALLOCABY", fALLOCABY, value)
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
        <Size(15)> _
        Public Property RATETPID() As String
            Get
                Return fRATETPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RATETPID", fRATETPID, value)
            End Set
        End Property
        Dim fEXGTBLID As String
        <Size(15)> _
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
        Dim fDENXRATE As Decimal
        Public Property DENXRATE() As Decimal
            Get
                Return fDENXRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DENXRATE", fDENXRATE, value)
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
        Dim fRTCLCMTD As Short
        Public Property RTCLCMTD() As Short
            Get
                Return fRTCLCMTD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RTCLCMTD", fRTCLCMTD, value)
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
        Dim fREFRENCE As String
        <Size(31)> _
        Public Property REFRENCE() As String
            Get
                Return fREFRENCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REFRENCE", fREFRENCE, value)
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
        Dim fUSER2ENT As String
        <Size(15)> _
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
        Dim fTax_Date As DateTime
        Public Property Tax_Date() As DateTime
            Get
                Return fTax_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Tax_Date", fTax_Date, value)
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
        Dim fWITHHAMT As Decimal
        Public Property WITHHAMT() As Decimal
            Get
                Return fWITHHAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WITHHAMT", fWITHHAMT, value)
            End Set
        End Property
        Dim fSHPPGDOC As Byte
        Public Property SHPPGDOC() As Byte
            Get
                Return fSHPPGDOC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SHPPGDOC", fSHPPGDOC, value)
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
        Dim fDOCNCORR As String
        <Size(21)> _
        Public Property DOCNCORR() As String
            Get
                Return fDOCNCORR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DOCNCORR", fDOCNCORR, value)
            End Set
        End Property
        Dim fSEQNCORR As Short
        Public Property SEQNCORR() As Short
            Get
                Return fSEQNCORR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SEQNCORR", fSEQNCORR, value)
            End Set
        End Property
        Dim fSALEDATE As DateTime
        Public Property SALEDATE() As DateTime
            Get
                Return fSALEDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("SALEDATE", fSALEDATE, value)
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
        Dim fSOPSTATUS As Short
        Public Property SOPSTATUS() As Short
            Get
                Return fSOPSTATUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSTATUS", fSOPSTATUS, value)
            End Set
        End Property
        Dim fSHIPCOMPLETE As Byte
        Public Property SHIPCOMPLETE() As Byte
            Get
                Return fSHIPCOMPLETE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SHIPCOMPLETE", fSHIPCOMPLETE, value)
            End Set
        End Property
        Dim fDIRECTDEBIT As Byte
        Public Property DIRECTDEBIT() As Byte
            Get
                Return fDIRECTDEBIT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DIRECTDEBIT", fDIRECTDEBIT, value)
            End Set
        End Property
        Dim fWorkflowApprStatCreditLm As Short
        Public Property WorkflowApprStatCreditLm() As Short
            Get
                Return fWorkflowApprStatCreditLm
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WorkflowApprStatCreditLm", fWorkflowApprStatCreditLm, value)
            End Set
        End Property
        Dim fWorkflowPriorityCreditLm As Short
        Public Property WorkflowPriorityCreditLm() As Short
            Get
                Return fWorkflowPriorityCreditLm
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WorkflowPriorityCreditLm", fWorkflowPriorityCreditLm, value)
            End Set
        End Property
        Dim fWorkflowApprStatusQuote As Short
        Public Property WorkflowApprStatusQuote() As Short
            Get
                Return fWorkflowApprStatusQuote
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WorkflowApprStatusQuote", fWorkflowApprStatusQuote, value)
            End Set
        End Property
        Dim fWorkflowPriorityQuote As Short
        Public Property WorkflowPriorityQuote() As Short
            Get
                Return fWorkflowPriorityQuote
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WorkflowPriorityQuote", fWorkflowPriorityQuote, value)
            End Set
        End Property
        Dim fDEX_ROW_TS As DateTime
        Public Property DEX_ROW_TS() As DateTime
            Get
                Return fDEX_ROW_TS
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DEX_ROW_TS", fDEX_ROW_TS, value)
            End Set
        End Property

		'<Persistent("DEX_ROW_ID")> _
		'Private _mDEX_ROW_ID As Integer
		'Protected Overridable Sub SetDEX_ROW_ID(ByVal Value As Integer)
		'    SetPropertyValue("DEX_ROW_ID", _mDEX_ROW_ID, Value)
		'End Sub
		'<PersistentAlias("_mDEX_ROW_ID")> _
		'Public ReadOnly Property DEX_ROW_ID() As Integer
		'    Get
		'        Return _mDEX_ROW_ID
		'    End Get
		'End Property


        Private _mLineItems As XPCollection(Of SOPSalesOrderLineItem)

        Public ReadOnly Property LineItems() As XPCollection(Of SOPSalesOrderLineItem)
            Get
                If _mLineItems is Nothing Then
                    Dim GC As New DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.And, New DevExpress.Data.Filtering.BinaryOperator("Oid.SOPNUMBE", Oid.SOPNUMBE, DevExpress.Data.Filtering.BinaryOperatorType.Equal), New DevExpress.Data.Filtering.BinaryOperator("Oid.SOPTYPE", Oid.SOPTYPE, DevExpress.Data.Filtering.BinaryOperatorType.Equal))    
                    _mLineItems =  New XPCollection(Of SOPSalesOrderLineItem)(Me.Session, GC)
                End If
                Return _mLineItems
            End Get
        End Property



#End Region

#Region "Non Persistent Properties"


		Public ReadOnly Property TrackingNumbers As XPCollection(Of SOPTrackingNumber)
			Get
				Dim xpoGO As New DevExpress.Data.Filtering.GroupOperator
				With xpoGO.Operands
					.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.SOPNUMBE", Me.Oid.SOPNUMBE))
					.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.SOPTYPE", Me.Oid.SOPTYPE))
				End With

				Dim oXPC As New XPCollection(Of SOPTrackingNumber)(Me.Session, xpoGO)
				Return oXPC
			End Get
		End Property
        

        Public ReadOnly Property ProcessHolds As XPCollection(Of SOPSalesOrderProcessHold)
            Get
                Dim xpoGO As New GroupOperator
                With xpoGO.Operands
                    .Add(New BinaryOperator("Oid.SOPNUMBE", Me.Oid.SOPNUMBE))
                    .Add(New BinaryOperator("Oid.SOPTYPE", Me.Oid.SOPTYPE))
                End With
                Return New XPCollection(Of SOPSalesOrderProcessHold)(Me.Session, xpoGO)
            End Get
        End Property

        ''' <summary>
        ''' return true if order currently has and active process hold
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property HasActiveProcessHold As Boolean
            Get
                Dim xcl As New XPCollection(Of SOPSalesOrderProcessHold)(Me.Session, Me.ProcessHolds)
                xcl.Filter = New BinaryOperator("DELETE1", 0)
                return xcl.Count > 0 
            End Get
        End Property
        

        Public ReadOnly Property IsUnpaidInvoice As Boolean
            Get
                If Oid.SOPTYPE <> 3 Then
                    Return False
                Else
                    Return RM.Helpers.RMHelper.IsInvoiceUnpaid(Session, Oid.SOPNUMBE)
                End If
            End Get
        End Property


#End Region


#Region "Behaviors"

        Public Function GetUserDefinedFields() As SOPSalesOrderHeaderUserDefinedField
            Dim dgcGroupCriteria As New DevExpress.Data.Filtering.GroupOperator
            dgcGroupCriteria.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.SOPTYPE", Oid.SOPTYPE, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            dgcGroupCriteria.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("Oid.SOPNUMBE", Oid.SOPNUMBE, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
            Return Session.FindObject(Of SOPSalesOrderHeaderUserDefinedField)(dgcGroupCriteria)
        End Function
        Public Function HasTrackingNumber(ByVal TrackingNumber As String) As Boolean
            Dim xcl As New XPCollection(Of SOPTrackingNumber)(Session, Me.TrackingNumbers)
            xcl.Filter = New BinaryOperator("Oid.Tracking_Number", TrackingNumber)
            If xcl.Count > 0 Then
                Return True
            Else
                Return False

            End If
        End Function


        Public Function GetCommentTextContents() As String
            Dim xpoUDF As SOPSalesOrderHeaderUserDefinedField = Me.GetUserDefinedFields
            Dim str As New System.Text.StringBuilder
            If xpoUDF IsNot Nothing Then
                Return xpoUDF.CMMTTEXT
            Else
                Return Nothing
            End If
        End Function

#End Region

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Protected Overrides Sub OnLoaded()
            MyBase.OnLoaded()
            Me.LineItems.Load()
        End Sub

    End Class

End Namespace
