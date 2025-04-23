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
    ''' GP Table SOP40200
    ''' </summary>
    <Persistent("SOP40200")> _
    <DefaultProperty("DOCID")> _
    <OptimisticLocking(False)> _
    Public Class SOPSalesDocumentType
        Inherits XPLiteObject
        Private _mOid As SalesDocumentTypeKey
        <Persistent()> _
        <Key()> _
        Public Property Oid() As SalesDocumentTypeKey
            Get
                Return _mOid
            End Get
            Set(ByVal value As SalesDocumentTypeKey)
                _mOid = value
            End Set
        End Property

        <PersistentAlias("Oid.DOCID")> _
        Public Property DOCID() As String
            Get
                Return CType(EvaluateAlias("DOCID"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("DOCID", _mOid.DOCID, Value)
            End Set
        End Property

        <PersistentAlias("Oid.SOPTYPE")> _
        Public Property SOPTYPE() As Short
            Get
                Return EvaluateAlias("SOPTYPE")
            End Get
            Set(ByVal Value As Short)
                SetPropertyValue("SOPTYPE", _mOid.SOPTYPE, Value)
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

        Dim fSETUPKEY As Short
        Public Property SETUPKEY() As Short
            Get
                Return fSETUPKEY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SETUPKEY", fSETUPKEY, value)
            End Set
        End Property
        Dim fDOCTYABR As String
        <Size(3)> _
        Public Property DOCTYABR() As String
            Get
                Return fDOCTYABR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DOCTYABR", fDOCTYABR, value)
            End Set
        End Property
        Dim fSOPNUMBE As String
        <Size(21)> _
        Public Property SOPNUMBE() As String
            Get
                Return fSOPNUMBE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPNUMBE", fSOPNUMBE, value)
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
        Dim fDOCUFORM As Short
        Public Property DOCUFORM() As Short
            Get
                Return fDOCUFORM
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DOCUFORM", fDOCUFORM, value)
            End Set
        End Property
        Dim fDAYTOEXP As Short
        Public Property DAYTOEXP() As Short
            Get
                Return fDAYTOEXP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DAYTOEXP", fDAYTOEXP, value)
            End Set
        End Property
        Dim fALLREPEA As Byte
        Public Property ALLREPEA() As Byte
            Get
                Return fALLREPEA
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLREPEA", fALLREPEA, value)
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
        Dim fUSEPROSP As Byte
        Public Property USEPROSP() As Byte
            Get
                Return fUSEPROSP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("USEPROSP", fUSEPROSP, value)
            End Set
        End Property
        Dim fUSNXTINV As Byte
        Public Property USNXTINV() As Byte
            Get
                Return fUSNXTINV
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("USNXTINV", fUSNXTINV, value)
            End Set
        End Property
        Dim fUSPFULPR As Byte
        Public Property USPFULPR() As Byte
            Get
                Return fUSPFULPR
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("USPFULPR", fUSPFULPR, value)
            End Set
        End Property
        Dim fQUOTOINV As Byte
        Public Property QUOTOINV() As Byte
            Get
                Return fQUOTOINV
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("QUOTOINV", fQUOTOINV, value)
            End Set
        End Property
        Dim fQUOTOORD As Byte
        Public Property QUOTOORD() As Byte
            Get
                Return fQUOTOORD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("QUOTOORD", fQUOTOORD, value)
            End Set
        End Property
        Dim fINVTOBAC As Byte
        Public Property INVTOBAC() As Byte
            Get
                Return fINVTOBAC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INVTOBAC", fINVTOBAC, value)
            End Set
        End Property
        Dim fBACTOINV As Byte
        Public Property BACTOINV() As Byte
            Get
                Return fBACTOINV
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BACTOINV", fBACTOINV, value)
            End Set
        End Property
        Dim fBACTOORD As Byte
        Public Property BACTOORD() As Byte
            Get
                Return fBACTOORD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BACTOORD", fBACTOORD, value)
            End Set
        End Property
        Dim fORDTOBAC As Byte
        Public Property ORDTOBAC() As Byte
            Get
                Return fORDTOBAC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ORDTOBAC", fORDTOBAC, value)
            End Set
        End Property
        Dim fORDTOORD As Byte
        Public Property ORDTOORD() As Byte
            Get
                Return fORDTOORD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ORDTOORD", fORDTOORD, value)
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
        Dim fQTYDEFAU As Short
        Public Property QTYDEFAU() As Short
            Get
                Return fQTYDEFAU
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("QTYDEFAU", fQTYDEFAU, value)
            End Set
        End Property
        Dim fSOPALLOW_1 As Byte
        Public Property SOPALLOW_1() As Byte
            Get
                Return fSOPALLOW_1
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_1", fSOPALLOW_1, value)
            End Set
        End Property
        Dim fSOPALLOW_2 As Byte
        Public Property SOPALLOW_2() As Byte
            Get
                Return fSOPALLOW_2
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_2", fSOPALLOW_2, value)
            End Set
        End Property
        Dim fSOPALLOW_3 As Byte
        Public Property SOPALLOW_3() As Byte
            Get
                Return fSOPALLOW_3
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_3", fSOPALLOW_3, value)
            End Set
        End Property
        Dim fSOPALLOW_4 As Byte
        Public Property SOPALLOW_4() As Byte
            Get
                Return fSOPALLOW_4
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_4", fSOPALLOW_4, value)
            End Set
        End Property
        Dim fSOPALLOW_5 As Byte
        Public Property SOPALLOW_5() As Byte
            Get
                Return fSOPALLOW_5
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_5", fSOPALLOW_5, value)
            End Set
        End Property
        Dim fSOPALLOW_6 As Byte
        Public Property SOPALLOW_6() As Byte
            Get
                Return fSOPALLOW_6
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_6", fSOPALLOW_6, value)
            End Set
        End Property
        Dim fSOPALLOW_7 As Byte
        Public Property SOPALLOW_7() As Byte
            Get
                Return fSOPALLOW_7
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_7", fSOPALLOW_7, value)
            End Set
        End Property
        Dim fSOPALLOW_8 As Byte
        Public Property SOPALLOW_8() As Byte
            Get
                Return fSOPALLOW_8
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_8", fSOPALLOW_8, value)
            End Set
        End Property
        Dim fSOPALLOW_9 As Byte
        Public Property SOPALLOW_9() As Byte
            Get
                Return fSOPALLOW_9
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_9", fSOPALLOW_9, value)
            End Set
        End Property
        Dim fSOPALLOW_10 As Byte
        Public Property SOPALLOW_10() As Byte
            Get
                Return fSOPALLOW_10
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPALLOW_10", fSOPALLOW_10, value)
            End Set
        End Property
        Dim fSOPPSSWD_1 As String
        <Size(11)> _
        Public Property SOPPSSWD_1() As String
            Get
                Return fSOPPSSWD_1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_1", fSOPPSSWD_1, value)
            End Set
        End Property
        Dim fSOPPSSWD_2 As String
        <Size(11)> _
        Public Property SOPPSSWD_2() As String
            Get
                Return fSOPPSSWD_2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_2", fSOPPSSWD_2, value)
            End Set
        End Property
        Dim fSOPPSSWD_3 As String
        <Size(11)> _
        Public Property SOPPSSWD_3() As String
            Get
                Return fSOPPSSWD_3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_3", fSOPPSSWD_3, value)
            End Set
        End Property
        Dim fSOPPSSWD_4 As String
        <Size(11)> _
        Public Property SOPPSSWD_4() As String
            Get
                Return fSOPPSSWD_4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_4", fSOPPSSWD_4, value)
            End Set
        End Property
        Dim fSOPPSSWD_5 As String
        <Size(11)> _
        Public Property SOPPSSWD_5() As String
            Get
                Return fSOPPSSWD_5
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_5", fSOPPSSWD_5, value)
            End Set
        End Property
        Dim fSOPPSSWD_6 As String
        <Size(11)> _
        Public Property SOPPSSWD_6() As String
            Get
                Return fSOPPSSWD_6
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_6", fSOPPSSWD_6, value)
            End Set
        End Property
        Dim fSOPPSSWD_7 As String
        <Size(11)> _
        Public Property SOPPSSWD_7() As String
            Get
                Return fSOPPSSWD_7
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_7", fSOPPSSWD_7, value)
            End Set
        End Property
        Dim fSOPPSSWD_8 As String
        <Size(11)> _
        Public Property SOPPSSWD_8() As String
            Get
                Return fSOPPSSWD_8
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_8", fSOPPSSWD_8, value)
            End Set
        End Property
        Dim fSOPPSSWD_9 As String
        <Size(11)> _
        Public Property SOPPSSWD_9() As String
            Get
                Return fSOPPSSWD_9
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_9", fSOPPSSWD_9, value)
            End Set
        End Property
        Dim fSOPPSSWD_10 As String
        <Size(11)> _
        Public Property SOPPSSWD_10() As String
            Get
                Return fSOPPSSWD_10
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPPSSWD_10", fSOPPSSWD_10, value)
            End Set
        End Property
        Dim fSOPSEQNC_1 As Short
        Public Property SOPSEQNC_1() As Short
            Get
                Return fSOPSEQNC_1
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_1", fSOPSEQNC_1, value)
            End Set
        End Property
        Dim fSOPSEQNC_2 As Short
        Public Property SOPSEQNC_2() As Short
            Get
                Return fSOPSEQNC_2
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_2", fSOPSEQNC_2, value)
            End Set
        End Property
        Dim fSOPSEQNC_3 As Short
        Public Property SOPSEQNC_3() As Short
            Get
                Return fSOPSEQNC_3
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_3", fSOPSEQNC_3, value)
            End Set
        End Property
        Dim fSOPSEQNC_4 As Short
        Public Property SOPSEQNC_4() As Short
            Get
                Return fSOPSEQNC_4
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_4", fSOPSEQNC_4, value)
            End Set
        End Property
        Dim fSOPSEQNC_5 As Short
        Public Property SOPSEQNC_5() As Short
            Get
                Return fSOPSEQNC_5
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_5", fSOPSEQNC_5, value)
            End Set
        End Property
        Dim fSOPSEQNC_6 As Short
        Public Property SOPSEQNC_6() As Short
            Get
                Return fSOPSEQNC_6
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_6", fSOPSEQNC_6, value)
            End Set
        End Property
        Dim fSOPSEQNC_7 As Short
        Public Property SOPSEQNC_7() As Short
            Get
                Return fSOPSEQNC_7
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_7", fSOPSEQNC_7, value)
            End Set
        End Property
        Dim fSOPSEQNC_8 As Short
        Public Property SOPSEQNC_8() As Short
            Get
                Return fSOPSEQNC_8
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSEQNC_8", fSOPSEQNC_8, value)
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
        Dim fALLBACKODPRT As Byte
        Public Property ALLBACKODPRT() As Byte
            Get
                Return fALLBACKODPRT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLBACKODPRT", fALLBACKODPRT, value)
            End Set
        End Property
        Dim fXORDINVC As Byte
        Public Property XORDINVC() As Byte
            Get
                Return fXORDINVC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("XORDINVC", fXORDINVC, value)
            End Set
        End Property
        Dim fUSDOCID3 As String
        <Size(15)> _
        Public Property USDOCID3() As String
            Get
                Return fUSDOCID3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USDOCID3", fUSDOCID3, value)
            End Set
        End Property
        Dim fWORKFLOWENABLED As Byte
        Public Property WORKFLOWENABLED() As Byte
            Get
                Return fWORKFLOWENABLED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("WORKFLOWENABLED", fWORKFLOWENABLED, value)
            End Set
        End Property
        Dim fUPDTONPRINT As Byte
        Public Property UPDTONPRINT() As Byte
            Get
                Return fUPDTONPRINT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("UPDTONPRINT", fUPDTONPRINT, value)
            End Set
        End Property
        Dim fCREDITLIMITHOLDID As String
        <Size(15)> _
        Public Property CREDITLIMITHOLDID() As String
            Get
                Return fCREDITLIMITHOLDID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CREDITLIMITHOLDID", fCREDITLIMITHOLDID, value)
            End Set
        End Property
        Dim fUPDTACTUALSHPDT As Byte
        Public Property UPDTACTUALSHPDT() As Byte
            Get
                Return fUPDTACTUALSHPDT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("UPDTACTUALSHPDT", fUPDTACTUALSHPDT, value)
            End Set
        End Property
        Dim fWORKFLOWHOLDID As String
        <Size(15)> _
        Public Property WORKFLOWHOLDID() As String
            Get
                Return fWORKFLOWHOLDID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WORKFLOWHOLDID", fWORKFLOWHOLDID, value)
            End Set
        End Property
        Dim fOVERRIDEIVCBILLQTY As Byte
        Public Property OVERRIDEIVCBILLQTY() As Byte
            Get
                Return fOVERRIDEIVCBILLQTY
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("OVERRIDEIVCBILLQTY", fOVERRIDEIVCBILLQTY, value)
            End Set
        End Property
        Dim fENABLEBACKORDER As Byte
        Public Property ENABLEBACKORDER() As Byte
            Get
                Return fENABLEBACKORDER
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ENABLEBACKORDER", fENABLEBACKORDER, value)
            End Set
        End Property
        Dim fENABLECANCELED As Byte
        Public Property ENABLECANCELED() As Byte
            Get
                Return fENABLECANCELED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ENABLECANCELED", fENABLECANCELED, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_1 As Byte
        Public Property SOPSTATUSACTIVE_1() As Byte
            Get
                Return fSOPSTATUSACTIVE_1
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_1", fSOPSTATUSACTIVE_1, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_2 As Byte
        Public Property SOPSTATUSACTIVE_2() As Byte
            Get
                Return fSOPSTATUSACTIVE_2
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_2", fSOPSTATUSACTIVE_2, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_3 As Byte
        Public Property SOPSTATUSACTIVE_3() As Byte
            Get
                Return fSOPSTATUSACTIVE_3
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_3", fSOPSTATUSACTIVE_3, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_4 As Byte
        Public Property SOPSTATUSACTIVE_4() As Byte
            Get
                Return fSOPSTATUSACTIVE_4
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_4", fSOPSTATUSACTIVE_4, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_5 As Byte
        Public Property SOPSTATUSACTIVE_5() As Byte
            Get
                Return fSOPSTATUSACTIVE_5
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_5", fSOPSTATUSACTIVE_5, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_6 As Byte
        Public Property SOPSTATUSACTIVE_6() As Byte
            Get
                Return fSOPSTATUSACTIVE_6
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_6", fSOPSTATUSACTIVE_6, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_7 As Byte
        Public Property SOPSTATUSACTIVE_7() As Byte
            Get
                Return fSOPSTATUSACTIVE_7
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_7", fSOPSTATUSACTIVE_7, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_8 As Byte
        Public Property SOPSTATUSACTIVE_8() As Byte
            Get
                Return fSOPSTATUSACTIVE_8
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_8", fSOPSTATUSACTIVE_8, value)
            End Set
        End Property
        Dim fSOPSTATUSACTIVE_9 As Byte
        Public Property SOPSTATUSACTIVE_9() As Byte
            Get
                Return fSOPSTATUSACTIVE_9
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SOPSTATUSACTIVE_9", fSOPSTATUSACTIVE_9, value)
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


        Public Structure SalesDocumentTypeKey
            Private fDOCID As String
            <Size(15)> _
            <Persistent("DOCID")> _
            <Browsable(False)> _
            Public Property DOCID() As String
                Get
                    Return fDOCID
                End Get
                Set(ByVal value As String)
                    fDOCID = value
                End Set
            End Property
            Private fSOPTYPE As Short
            <Persistent("SOPTYPE")> _
            <Browsable(False)> _
            Public Property SOPTYPE() As Short
                Get
                    Return fSOPTYPE
                End Get
                Set(ByVal value As Short)
                    fSOPTYPE = value
                End Set
            End Property
        End Structure
    End Class

End Namespace
