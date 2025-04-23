Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Persistent.Base

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00102
    ''' </summary>
    <DefaultProperty("Oid.ITEMNMBR")>
    <Persistent("IV00102")>
    <OptimisticLocking(False)>
    Public Class IVItemQuantity
        Inherits XPLiteObject


        Public Structure ItemQuantityKey
            'Private fIVItem As IVItem
            '<Persistent("ITEMNMBR")> _
            '<NoForeignKey()>
            'Public Property IVItem As IVItem
            '    Get
            '        Return fIVItem
            '    End Get
            '    Set(value As IVItem)
            '        fIVItem = value
            '    End Set
            'End Property
            Private fITEMNMBR As String
            <Size(31)>
            <Persistent("ITEMNMBR")>
            Public Property ITEMNMBR() As String
                Get
                    Return fITEMNMBR
                End Get
                Set(ByVal value As String)
                    fITEMNMBR = value
                End Set
            End Property
            Private fLOCNCODE As String
            <Size(11)>
            <Persistent("LOCNCODE")>
            <VisibleInLookupListView(False)>
            Public Property LOCNCODE() As String
                Get
                    Return fLOCNCODE
                End Get
                Set(ByVal value As String)
                    fLOCNCODE = value
                End Set
            End Property
            Private fRCRDTYPE As Short
            <Persistent("RCRDTYPE")>
            Public Property RCRDTYPE() As Short
                Get
                    Return fRCRDTYPE
                End Get
                Set(ByVal value As Short)
                    fRCRDTYPE = value
                End Set
            End Property

        End Structure

        <PersistentAlias("[<IVItem>][ITEMNMBR = ^.Oid.ITEMNMBR].Single()")>
        Public ReadOnly Property IVItem As IV.IVItem
            Get
                Return TryCast(EvaluateAlias("IVItem"), IV.IVItem)
            End Get
        End Property
        'Public ReadOnly Property IVItemO As IV.IVItem
        '    Get
        '        Return Session.GetObjectByKey(Of IV.IVItem)(Oid.ITEMNMBR)
        '    End Get
        'End Property

        Private _mOid As ItemQuantityKey
        <Persistent()>
        <Key()>
        Public Property Oid() As ItemQuantityKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As ItemQuantityKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property
        Dim fBINNMBR As String
        <Size(21)>
        Public Property BINNMBR() As String
            Get
                Return fBINNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BINNMBR", fBINNMBR, value)
            End Set
        End Property
        Dim fPRIMVNDR As String
        <Size(15)>
        Public Property PRIMVNDR() As String
            Get
                Return fPRIMVNDR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRIMVNDR", fPRIMVNDR, value)
            End Set
        End Property
        Dim fITMFRFLG As Byte
        Public Property ITMFRFLG() As Byte
            Get
                Return fITMFRFLG
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ITMFRFLG", fITMFRFLG, value)
            End Set
        End Property
        Dim fBGNGQTY As Decimal
        Public Property BGNGQTY() As Decimal
            Get
                Return fBGNGQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BGNGQTY", fBGNGQTY, value)
            End Set
        End Property
        Dim fLSORDQTY As Decimal
        Public Property LSORDQTY() As Decimal
            Get
                Return fLSORDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LSORDQTY", fLSORDQTY, value)
            End Set
        End Property
        Dim fLRCPTQTY As Decimal
        Public Property LRCPTQTY() As Decimal
            Get
                Return fLRCPTQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LRCPTQTY", fLRCPTQTY, value)
            End Set
        End Property
        Dim fLSTORDDT As DateTime
        Public Property LSTORDDT() As DateTime
            Get
                Return fLSTORDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTORDDT", fLSTORDDT, value)
            End Set
        End Property
        Dim fLSORDVND As String
        <Size(15)>
        Public Property LSORDVND() As String
            Get
                Return fLSORDVND
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LSORDVND", fLSORDVND, value)
            End Set
        End Property
        Dim fLSRCPTDT As DateTime
        Public Property LSRCPTDT() As DateTime
            Get
                Return fLSRCPTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSRCPTDT", fLSRCPTDT, value)
            End Set
        End Property
        Dim fQTYRQSTN As Decimal
        Public Property QTYRQSTN() As Decimal
            Get
                Return fQTYRQSTN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYRQSTN", fQTYRQSTN, value)
            End Set
        End Property
        Dim fQTYONORD As Decimal
        Public Property QTYONORD() As Decimal
            Get
                Return fQTYONORD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYONORD", fQTYONORD, value)
            End Set
        End Property
        Dim fQTYBKORD As Decimal
        Public Property QTYBKORD() As Decimal
            Get
                Return fQTYBKORD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYBKORD", fQTYBKORD, value)
            End Set
        End Property
        Dim fQTY_Drop_Shipped As Decimal
        Public Property QTY_Drop_Shipped() As Decimal
            Get
                Return fQTY_Drop_Shipped
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTY_Drop_Shipped", fQTY_Drop_Shipped, value)
            End Set
        End Property
        Dim fQTYINUSE As Decimal
        Public Property QTYINUSE() As Decimal
            Get
                Return fQTYINUSE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYINUSE", fQTYINUSE, value)
            End Set
        End Property
        Dim fQTYINSVC As Decimal
        Public Property QTYINSVC() As Decimal
            Get
                Return fQTYINSVC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYINSVC", fQTYINSVC, value)
            End Set
        End Property
        Dim fQTYRTRND As Decimal
        Public Property QTYRTRND() As Decimal
            Get
                Return fQTYRTRND
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYRTRND", fQTYRTRND, value)
            End Set
        End Property
        Dim fQTYDMGED As Decimal
        Public Property QTYDMGED() As Decimal
            Get
                Return fQTYDMGED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYDMGED", fQTYDMGED, value)
            End Set
        End Property
        Dim fQTYONHND As Decimal
        Public Property QTYONHND() As Decimal
            Get
                Return fQTYONHND
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYONHND", fQTYONHND, value)
            End Set
        End Property
        Dim fATYALLOC As Decimal
        Public Property ATYALLOC() As Decimal
            Get
                Return fATYALLOC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ATYALLOC", fATYALLOC, value)
            End Set
        End Property
        Dim fQTYCOMTD As Decimal
        Public Property QTYCOMTD() As Decimal
            Get
                Return fQTYCOMTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYCOMTD", fQTYCOMTD, value)
            End Set
        End Property
        Dim fQTYSOLD As Decimal
        Public Property QTYSOLD() As Decimal
            Get
                Return fQTYSOLD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYSOLD", fQTYSOLD, value)
            End Set
        End Property
        Dim fNXTCNTDT As DateTime
        Public Property NXTCNTDT() As DateTime
            Get
                Return fNXTCNTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("NXTCNTDT", fNXTCNTDT, value)
            End Set
        End Property
        Dim fNXTCNTTM As DateTime
        Public Property NXTCNTTM() As DateTime
            Get
                Return fNXTCNTTM
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("NXTCNTTM", fNXTCNTTM, value)
            End Set
        End Property
        Dim fLSTCNTDT As DateTime
        Public Property LSTCNTDT() As DateTime
            Get
                Return fLSTCNTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTCNTDT", fLSTCNTDT, value)
            End Set
        End Property
        Dim fLSTCNTTM As DateTime
        Public Property LSTCNTTM() As DateTime
            Get
                Return fLSTCNTTM
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTCNTTM", fLSTCNTTM, value)
            End Set
        End Property
        Dim fSTCKCNTINTRVL As Short
        Public Property STCKCNTINTRVL() As Short
            Get
                Return fSTCKCNTINTRVL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("STCKCNTINTRVL", fSTCKCNTINTRVL, value)
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
        Dim fPLANNERID As String
        <Size(15)>
        Public Property PLANNERID() As String
            Get
                Return fPLANNERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PLANNERID", fPLANNERID, value)
            End Set
        End Property
        Dim fORDERPOLICY As Short
        Public Property ORDERPOLICY() As Short
            Get
                Return fORDERPOLICY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORDERPOLICY", fORDERPOLICY, value)
            End Set
        End Property
        Dim fFXDORDRQTY As Decimal
        Public Property FXDORDRQTY() As Decimal
            Get
                Return fFXDORDRQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FXDORDRQTY", fFXDORDRQTY, value)
            End Set
        End Property
        Dim fORDRPNTQTY As Decimal
        Public Property ORDRPNTQTY() As Decimal
            Get
                Return fORDRPNTQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDRPNTQTY", fORDRPNTQTY, value)
            End Set
        End Property
        Dim fNMBROFDYS As Short
        Public Property NMBROFDYS() As Short
            Get
                Return fNMBROFDYS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("NMBROFDYS", fNMBROFDYS, value)
            End Set
        End Property
        Dim fMNMMORDRQTY As Decimal
        Public Property MNMMORDRQTY() As Decimal
            Get
                Return fMNMMORDRQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MNMMORDRQTY", fMNMMORDRQTY, value)
            End Set
        End Property
        Dim fMXMMORDRQTY As Decimal
        Public Property MXMMORDRQTY() As Decimal
            Get
                Return fMXMMORDRQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MXMMORDRQTY", fMXMMORDRQTY, value)
            End Set
        End Property
        Dim fORDERMULTIPLE As Decimal
        Public Property ORDERMULTIPLE() As Decimal
            Get
                Return fORDERMULTIPLE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDERMULTIPLE", fORDERMULTIPLE, value)
            End Set
        End Property
        Dim fREPLENISHMENTMETHOD As Short
        Public Property REPLENISHMENTMETHOD() As Short
            Get
                Return fREPLENISHMENTMETHOD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("REPLENISHMENTMETHOD", fREPLENISHMENTMETHOD, value)
            End Set
        End Property
        Dim fSHRINKAGEFACTOR As Decimal
        Public Property SHRINKAGEFACTOR() As Decimal
            Get
                Return fSHRINKAGEFACTOR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SHRINKAGEFACTOR", fSHRINKAGEFACTOR, value)
            End Set
        End Property
        Dim fPRCHSNGLDTM As Decimal
        Public Property PRCHSNGLDTM() As Decimal
            Get
                Return fPRCHSNGLDTM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PRCHSNGLDTM", fPRCHSNGLDTM, value)
            End Set
        End Property
        Dim fMNFCTRNGFXDLDTM As Decimal
        Public Property MNFCTRNGFXDLDTM() As Decimal
            Get
                Return fMNFCTRNGFXDLDTM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MNFCTRNGFXDLDTM", fMNFCTRNGFXDLDTM, value)
            End Set
        End Property
        Dim fMNFCTRNGVRBLLDTM As Decimal
        Public Property MNFCTRNGVRBLLDTM() As Decimal
            Get
                Return fMNFCTRNGVRBLLDTM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MNFCTRNGVRBLLDTM", fMNFCTRNGVRBLLDTM, value)
            End Set
        End Property
        Dim fSTAGINGLDTME As Decimal
        Public Property STAGINGLDTME() As Decimal
            Get
                Return fSTAGINGLDTME
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("STAGINGLDTME", fSTAGINGLDTME, value)
            End Set
        End Property
        Dim fPLNNNGTMFNCDYS As Short
        Public Property PLNNNGTMFNCDYS() As Short
            Get
                Return fPLNNNGTMFNCDYS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PLNNNGTMFNCDYS", fPLNNNGTMFNCDYS, value)
            End Set
        End Property
        Dim fDMNDTMFNCPRDS As Short
        Public Property DMNDTMFNCPRDS() As Short
            Get
                Return fDMNDTMFNCPRDS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DMNDTMFNCPRDS", fDMNDTMFNCPRDS, value)
            End Set
        End Property
        Dim fINCLDDINPLNNNG As Byte
        Public Property INCLDDINPLNNNG() As Byte
            Get
                Return fINCLDDINPLNNNG
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLDDINPLNNNG", fINCLDDINPLNNNG, value)
            End Set
        End Property
        Dim fCALCULATEATP As Byte
        Public Property CALCULATEATP() As Byte
            Get
                Return fCALCULATEATP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CALCULATEATP", fCALCULATEATP, value)
            End Set
        End Property
        Dim fAUTOCHKATP As Byte
        Public Property AUTOCHKATP() As Byte
            Get
                Return fAUTOCHKATP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("AUTOCHKATP", fAUTOCHKATP, value)
            End Set
        End Property
        Dim fPLNFNLPAB As Byte
        Public Property PLNFNLPAB() As Byte
            Get
                Return fPLNFNLPAB
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("PLNFNLPAB", fPLNFNLPAB, value)
            End Set
        End Property
        Dim fFRCSTCNSMPTNPRD As Short
        Public Property FRCSTCNSMPTNPRD() As Short
            Get
                Return fFRCSTCNSMPTNPRD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FRCSTCNSMPTNPRD", fFRCSTCNSMPTNPRD, value)
            End Set
        End Property
        Dim fORDRUPTOLVL As Decimal
        Public Property ORDRUPTOLVL() As Decimal
            Get
                Return fORDRUPTOLVL
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDRUPTOLVL", fORDRUPTOLVL, value)
            End Set
        End Property
        Dim fSFTYSTCKQTY As Decimal
        Public Property SFTYSTCKQTY() As Decimal
            Get
                Return fSFTYSTCKQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SFTYSTCKQTY", fSFTYSTCKQTY, value)
            End Set
        End Property
        Dim fREORDERVARIANCE As Decimal
        Public Property REORDERVARIANCE() As Decimal
            Get
                Return fREORDERVARIANCE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("REORDERVARIANCE", fREORDERVARIANCE, value)
            End Set
        End Property
        Dim fPORECEIPTBIN As String
        <Size(15)>
        Public Property PORECEIPTBIN() As String
            Get
                Return fPORECEIPTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PORECEIPTBIN", fPORECEIPTBIN, value)
            End Set
        End Property
        Dim fPORETRNBIN As String
        <Size(15)>
        Public Property PORETRNBIN() As String
            Get
                Return fPORETRNBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PORETRNBIN", fPORETRNBIN, value)
            End Set
        End Property
        Dim fSOFULFILLMENTBIN As String
        <Size(15)>
        Public Property SOFULFILLMENTBIN() As String
            Get
                Return fSOFULFILLMENTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOFULFILLMENTBIN", fSOFULFILLMENTBIN, value)
            End Set
        End Property
        Dim fSORETURNBIN As String
        <Size(15)>
        Public Property SORETURNBIN() As String
            Get
                Return fSORETURNBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SORETURNBIN", fSORETURNBIN, value)
            End Set
        End Property
        Dim fBOMRCPTBIN As String
        <Size(15)>
        Public Property BOMRCPTBIN() As String
            Get
                Return fBOMRCPTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOMRCPTBIN", fBOMRCPTBIN, value)
            End Set
        End Property
        Dim fMATERIALISSUEBIN As String
        <Size(15)>
        Public Property MATERIALISSUEBIN() As String
            Get
                Return fMATERIALISSUEBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MATERIALISSUEBIN", fMATERIALISSUEBIN, value)
            End Set
        End Property
        Dim fMORECEIPTBIN As String
        <Size(15)>
        Public Property MORECEIPTBIN() As String
            Get
                Return fMORECEIPTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MORECEIPTBIN", fMORECEIPTBIN, value)
            End Set
        End Property
        Dim fREPAIRISSUESBIN As String
        <Size(15)>
        Public Property REPAIRISSUESBIN() As String
            Get
                Return fREPAIRISSUESBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REPAIRISSUESBIN", fREPAIRISSUESBIN, value)
            End Set
        End Property
        Dim fReplenishmentLevel As Short
        Public Property ReplenishmentLevel() As Short
            Get
                Return fReplenishmentLevel
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ReplenishmentLevel", fReplenishmentLevel, value)
            End Set
        End Property
        Dim fPOPOrderMethod As Short
        Public Property POPOrderMethod() As Short
            Get
                Return fPOPOrderMethod
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POPOrderMethod", fPOPOrderMethod, value)
            End Set
        End Property
        Dim fMasterLocationCode As String
        <Size(11)>
        Public Property MasterLocationCode() As String
            Get
                Return fMasterLocationCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MasterLocationCode", fMasterLocationCode, value)
            End Set
        End Property
        Dim fPOPVendorSelection As Short
        Public Property POPVendorSelection() As Short
            Get
                Return fPOPVendorSelection
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POPVendorSelection", fPOPVendorSelection, value)
            End Set
        End Property
        Dim fPOPPricingSelection As Short
        Public Property POPPricingSelection() As Short
            Get
                Return fPOPPricingSelection
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POPPricingSelection", fPOPPricingSelection, value)
            End Set
        End Property
        Dim fPurchasePrice As Decimal
        Public Property PurchasePrice() As Decimal
            Get
                Return fPurchasePrice
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PurchasePrice", fPurchasePrice, value)
            End Set
        End Property
        Dim fIncludeAllocations As Byte
        Public Property IncludeAllocations() As Byte
            Get
                Return fIncludeAllocations
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("IncludeAllocations", fIncludeAllocations, value)
            End Set
        End Property
        Dim fIncludeBackorders As Byte
        Public Property IncludeBackorders() As Byte
            Get
                Return fIncludeBackorders
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("IncludeBackorders", fIncludeBackorders, value)
            End Set
        End Property
        Dim fIncludeRequisitions As Byte
        Public Property IncludeRequisitions() As Byte
            Get
                Return fIncludeRequisitions
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("IncludeRequisitions", fIncludeRequisitions, value)
            End Set
        End Property
        Dim fPICKTICKETITEMOPT As Short
        Public Property PICKTICKETITEMOPT() As Short
            Get
                Return fPICKTICKETITEMOPT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PICKTICKETITEMOPT", fPICKTICKETITEMOPT, value)
            End Set
        End Property
        Dim fINCLDMRPMOVEIN As Byte
        Public Property INCLDMRPMOVEIN() As Byte
            Get
                Return fINCLDMRPMOVEIN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLDMRPMOVEIN", fINCLDMRPMOVEIN, value)
            End Set
        End Property
        Dim fINCLDMRPMOVEOUT As Byte
        Public Property INCLDMRPMOVEOUT() As Byte
            Get
                Return fINCLDMRPMOVEOUT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLDMRPMOVEOUT", fINCLDMRPMOVEOUT, value)
            End Set
        End Property
        Dim fINCLDMRPCANCEL As Byte
        Public Property INCLDMRPCANCEL() As Byte
            Get
                Return fINCLDMRPCANCEL
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLDMRPCANCEL", fINCLDMRPCANCEL, value)
            End Set
        End Property

        <PersistentAlias("QTYONHND - ATYALLOC")>
        Public ReadOnly Property AvailableQuantity As Decimal
            Get
                Return EvaluateAlias("AvailableQuantity")
            End Get
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