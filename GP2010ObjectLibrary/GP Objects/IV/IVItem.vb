Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Data.Filtering

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00101
    ''' </summary>
    <Persistent("IV00101")>
    <System.ComponentModel.DefaultProperty("ITEMNMBR")>
    <OptimisticLocking(False)>
    Public Class IVItem
        Inherits XPLiteObject


#Region "Properties"
        Dim fITEMNMBR As String
        <System.ComponentModel.DisplayName("Item Key")>
        <VisibleInListView(True)>
        <Key()>
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
        <System.ComponentModel.DisplayName("Item Description")>
        <VisibleInListView(True)>
        <Size(101)>
        Public Property ITEMDESC() As String
            Get
                Return fITEMDESC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMDESC", fITEMDESC, value)
            End Set
        End Property
        Dim fNOTEINDX As Decimal
        <VisibleInListView(False)>
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fITMSHNAM As String
        <VisibleInListView(False)>
        <Size(15)>
        Public Property ITMSHNAM() As String
            Get
                Return fITMSHNAM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMSHNAM", fITMSHNAM, value)
            End Set
        End Property
        Dim fITEMTYPE As Short
        <VisibleInListView(False)>
        Public Property ITEMTYPE() As Short
            Get
                Return fITEMTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ITEMTYPE", fITEMTYPE, value)
            End Set
        End Property
        Dim fITMGEDSC As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property ITMGEDSC() As String
            Get
                Return fITMGEDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMGEDSC", fITMGEDSC, value)
            End Set
        End Property
        Dim fSTNDCOST As Decimal
        <VisibleInListView(False)>
        Public Property STNDCOST() As Decimal
            Get
                Return fSTNDCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("STNDCOST", fSTNDCOST, value)
            End Set
        End Property
        Dim fCURRCOST As Decimal
        <VisibleInListView(False)>
        Public Property CURRCOST() As Decimal
            Get
                Return fCURRCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CURRCOST", fCURRCOST, value)
            End Set
        End Property
        Dim fITEMSHWT As Integer
        <VisibleInListView(False)>
        Public Property ITEMSHWT() As Integer
            Get
                Return fITEMSHWT
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ITEMSHWT", fITEMSHWT, value)
            End Set
        End Property
        Dim fDECPLQTY As Short
        <VisibleInListView(False)>
        Public Property DECPLQTY() As Short
            Get
                Return fDECPLQTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLQTY", fDECPLQTY, value)
            End Set
        End Property
        Dim fDECPLCUR As Short
        <VisibleInListView(False)>
        Public Property DECPLCUR() As Short
            Get
                Return fDECPLCUR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLCUR", fDECPLCUR, value)
            End Set
        End Property
        Dim fITMTSHID As String
        <VisibleInListView(False)>
        <Size(15)>
        Public Property ITMTSHID() As String
            Get
                Return fITMTSHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMTSHID", fITMTSHID, value)
            End Set
        End Property
        Dim fTAXOPTNS As Short
        <VisibleInListView(False)>
        Public Property TAXOPTNS() As Short
            Get
                Return fTAXOPTNS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TAXOPTNS", fTAXOPTNS, value)
            End Set
        End Property
        Dim fIVIVINDX As Integer
        <VisibleInListView(False)>
        Public Property IVIVINDX() As Integer
            Get
                Return fIVIVINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVINDX", fIVIVINDX, value)
            End Set
        End Property
        Dim fIVIVOFIX As Integer
        <VisibleInListView(False)>
        Public Property IVIVOFIX() As Integer
            Get
                Return fIVIVOFIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVOFIX", fIVIVOFIX, value)
            End Set
        End Property
        Dim fIVCOGSIX As Integer
        <VisibleInListView(False)>
        Public Property IVCOGSIX() As Integer
            Get
                Return fIVCOGSIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVCOGSIX", fIVCOGSIX, value)
            End Set
        End Property
        Dim fIVSLSIDX As Integer
        <VisibleInListView(False)>
        Public Property IVSLSIDX() As Integer
            Get
                Return fIVSLSIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVSLSIDX", fIVSLSIDX, value)
            End Set
        End Property
        Dim fIVSLDSIX As Integer
        <VisibleInListView(False)>
        Public Property IVSLDSIX() As Integer
            Get
                Return fIVSLDSIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVSLDSIX", fIVSLDSIX, value)
            End Set
        End Property
        Dim fIVSLRNIX As Integer
        <VisibleInListView(False)>
        Public Property IVSLRNIX() As Integer
            Get
                Return fIVSLRNIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVSLRNIX", fIVSLRNIX, value)
            End Set
        End Property
        Dim fIVINUSIX As Integer
        <VisibleInListView(False)>
        Public Property IVINUSIX() As Integer
            Get
                Return fIVINUSIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVINUSIX", fIVINUSIX, value)
            End Set
        End Property
        Dim fIVINSVIX As Integer
        <VisibleInListView(False)>
        Public Property IVINSVIX() As Integer
            Get
                Return fIVINSVIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVINSVIX", fIVINSVIX, value)
            End Set
        End Property
        Dim fIVDMGIDX As Integer
        <VisibleInListView(False)>
        Public Property IVDMGIDX() As Integer
            Get
                Return fIVDMGIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVDMGIDX", fIVDMGIDX, value)
            End Set
        End Property
        Dim fIVVARIDX As Integer
        <VisibleInListView(False)>
        Public Property IVVARIDX() As Integer
            Get
                Return fIVVARIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVVARIDX", fIVVARIDX, value)
            End Set
        End Property
        Dim fDPSHPIDX As Integer
        <VisibleInListView(False)>
        Public Property DPSHPIDX() As Integer
            Get
                Return fDPSHPIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DPSHPIDX", fDPSHPIDX, value)
            End Set
        End Property
        Dim fPURPVIDX As Integer
        <VisibleInListView(False)>
        Public Property PURPVIDX() As Integer
            Get
                Return fPURPVIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PURPVIDX", fPURPVIDX, value)
            End Set
        End Property
        Dim fUPPVIDX As Integer
        <VisibleInListView(False)>
        Public Property UPPVIDX() As Integer
            Get
                Return fUPPVIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("UPPVIDX", fUPPVIDX, value)
            End Set
        End Property
        Dim fIVRETIDX As Integer
        <VisibleInListView(False)>
        Public Property IVRETIDX() As Integer
            Get
                Return fIVRETIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVRETIDX", fIVRETIDX, value)
            End Set
        End Property
        Dim fASMVRIDX As Integer
        <VisibleInListView(False)>
        Public Property ASMVRIDX() As Integer
            Get
                Return fASMVRIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ASMVRIDX", fASMVRIDX, value)
            End Set
        End Property
        Dim fITMCLSCD As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property ITMCLSCD() As String
            Get
                Return fITMCLSCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMCLSCD", fITMCLSCD, value)
            End Set
        End Property
        Dim fITMTRKOP As Short
        <VisibleInListView(False)>
        Public Property ITMTRKOP() As Short
            Get
                Return fITMTRKOP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ITMTRKOP", fITMTRKOP, value)
            End Set
        End Property
        Dim fLOTTYPE As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property LOTTYPE() As String
            Get
                Return fLOTTYPE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOTTYPE", fLOTTYPE, value)
            End Set
        End Property
        Dim fKPERHIST As Byte
        <VisibleInListView(False)>
        Public Property KPERHIST() As Byte
            Get
                Return fKPERHIST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPERHIST", fKPERHIST, value)
            End Set
        End Property
        Dim fKPTRXHST As Byte
        <VisibleInListView(False)>
        Public Property KPTRXHST() As Byte
            Get
                Return fKPTRXHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPTRXHST", fKPTRXHST, value)
            End Set
        End Property
        Dim fKPCALHST As Byte
        <VisibleInListView(False)>
        Public Property KPCALHST() As Byte
            Get
                Return fKPCALHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPCALHST", fKPCALHST, value)
            End Set
        End Property
        Dim fKPDSTHST As Byte
        <VisibleInListView(False)>
        Public Property KPDSTHST() As Byte
            Get
                Return fKPDSTHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPDSTHST", fKPDSTHST, value)
            End Set
        End Property
        Dim fALWBKORD As Byte
        <VisibleInListView(False)>
        Public Property ALWBKORD() As Byte
            Get
                Return fALWBKORD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALWBKORD", fALWBKORD, value)
            End Set
        End Property
        Dim fVCTNMTHD As Short
        <VisibleInListView(False)>
        Public Property VCTNMTHD() As Short
            Get
                Return fVCTNMTHD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("VCTNMTHD", fVCTNMTHD, value)
            End Set
        End Property
        Dim fUOMSCHDL As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property UOMSCHDL() As String
            Get
                Return fUOMSCHDL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOMSCHDL", fUOMSCHDL, value)
            End Set
        End Property
        Dim fALTITEM1 As String
        <VisibleInListView(False)>
        <Size(31)>
        Public Property ALTITEM1() As String
            Get
                Return fALTITEM1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ALTITEM1", fALTITEM1, value)
            End Set
        End Property
        Dim fALTITEM2 As String
        <VisibleInListView(False)>
        <Size(31)>
        Public Property ALTITEM2() As String
            Get
                Return fALTITEM2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ALTITEM2", fALTITEM2, value)
            End Set
        End Property
        Dim fUSCATVLS_1 As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property USCATVLS_1() As String
            Get
                Return fUSCATVLS_1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATVLS_1", fUSCATVLS_1, value)
            End Set
        End Property
        Dim fUSCATVLS_2 As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property USCATVLS_2() As String
            Get
                Return fUSCATVLS_2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATVLS_2", fUSCATVLS_2, value)
            End Set
        End Property
        Dim fUSCATVLS_3 As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property USCATVLS_3() As String
            Get
                Return fUSCATVLS_3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATVLS_3", fUSCATVLS_3, value)
            End Set
        End Property
        Dim fUSCATVLS_4 As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property USCATVLS_4() As String
            Get
                Return fUSCATVLS_4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATVLS_4", fUSCATVLS_4, value)
            End Set
        End Property
        Dim fUSCATVLS_5 As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property USCATVLS_5() As String
            Get
                Return fUSCATVLS_5
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATVLS_5", fUSCATVLS_5, value)
            End Set
        End Property
        Dim fUSCATVLS_6 As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property USCATVLS_6() As String
            Get
                Return fUSCATVLS_6
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATVLS_6", fUSCATVLS_6, value)
            End Set
        End Property
        Dim fMSTRCDTY As Short
        <VisibleInListView(False)>
        Public Property MSTRCDTY() As Short
            Get
                Return fMSTRCDTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MSTRCDTY", fMSTRCDTY, value)
            End Set
        End Property
        Dim fMODIFDT As DateTime
        <VisibleInListView(False)>
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
            End Set
        End Property
        Dim fCREATDDT As DateTime
        <VisibleInListView(False)>
        Public Property CREATDDT() As DateTime
            Get
                Return fCREATDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CREATDDT", fCREATDDT, value)
            End Set
        End Property
        Dim fWRNTYDYS As Short
        <VisibleInListView(False)>
        Public Property WRNTYDYS() As Short
            Get
                Return fWRNTYDYS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("WRNTYDYS", fWRNTYDYS, value)
            End Set
        End Property
        Dim fPRCLEVEL As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property PRCLEVEL() As String
            Get
                Return fPRCLEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCLEVEL", fPRCLEVEL, value)
            End Set
        End Property
        Dim fLOCNCODE As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
            End Set
        End Property
        Dim fPINFLIDX As Integer
        <VisibleInListView(False)>
        Public Property PINFLIDX() As Integer
            Get
                Return fPINFLIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PINFLIDX", fPINFLIDX, value)
            End Set
        End Property
        Dim fPURMCIDX As Integer
        <VisibleInListView(False)>
        Public Property PURMCIDX() As Integer
            Get
                Return fPURMCIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PURMCIDX", fPURMCIDX, value)
            End Set
        End Property
        Dim fIVINFIDX As Integer
        <VisibleInListView(False)>
        Public Property IVINFIDX() As Integer
            Get
                Return fIVINFIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVINFIDX", fIVINFIDX, value)
            End Set
        End Property
        Dim fINVMCIDX As Integer
        <VisibleInListView(False)>
        Public Property INVMCIDX() As Integer
            Get
                Return fINVMCIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("INVMCIDX", fINVMCIDX, value)
            End Set
        End Property
        Dim fCGSINFLX As Integer
        <VisibleInListView(False)>
        Public Property CGSINFLX() As Integer
            Get
                Return fCGSINFLX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CGSINFLX", fCGSINFLX, value)
            End Set
        End Property
        Dim fCGSMCIDX As Integer
        <VisibleInListView(False)>
        Public Property CGSMCIDX() As Integer
            Get
                Return fCGSMCIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CGSMCIDX", fCGSMCIDX, value)
            End Set
        End Property
        Dim fITEMCODE As String
        <VisibleInListView(False)>
        <Size(15)>
        Public Property ITEMCODE() As String
            Get
                Return fITEMCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMCODE", fITEMCODE, value)
            End Set
        End Property
        Dim fTCC As String
        <VisibleInListView(False)>
        <Size(31)>
        Public Property TCC() As String
            Get
                Return fTCC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TCC", fTCC, value)
            End Set
        End Property
        Dim fPriceGroup As String
        <VisibleInListView(False)>
        <Size(11)>
        Public Property PriceGroup() As String
            Get
                Return fPriceGroup
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PriceGroup", fPriceGroup, value)
            End Set
        End Property
        Dim fPRICMTHD As Short
        <VisibleInListView(False)>
        Public Property PRICMTHD() As Short
            Get
                Return fPRICMTHD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PRICMTHD", fPRICMTHD, value)
            End Set
        End Property
        Dim fPRCHSUOM As String
        <VisibleInListView(False)>
        <Size(9)>
        Public Property PRCHSUOM() As String
            Get
                Return fPRCHSUOM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCHSUOM", fPRCHSUOM, value)
            End Set
        End Property
        Dim fSELNGUOM As String
        <VisibleInListView(False)>
        <Size(9)>
        Public Property SELNGUOM() As String
            Get
                Return fSELNGUOM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SELNGUOM", fSELNGUOM, value)
            End Set
        End Property
        Dim fKTACCTSR As Short
        <VisibleInListView(False)>
        Public Property KTACCTSR() As Short
            Get
                Return fKTACCTSR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("KTACCTSR", fKTACCTSR, value)
            End Set
        End Property
        Dim fLASTGENSN As String
        <VisibleInListView(False)>
        <Size(21)>
        Public Property LASTGENSN() As String
            Get
                Return fLASTGENSN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LASTGENSN", fLASTGENSN, value)
            End Set
        End Property
        Dim fABCCODE As Short
        <VisibleInListView(False)>
        Public Property ABCCODE() As Short
            Get
                Return fABCCODE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ABCCODE", fABCCODE, value)
            End Set
        End Property
        Dim fRevalue_Inventory As Byte
        <VisibleInListView(False)>
        Public Property Revalue_Inventory() As Byte
            Get
                Return fRevalue_Inventory
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Revalue_Inventory", fRevalue_Inventory, value)
            End Set
        End Property
        Dim fTolerance_Percentage As Integer
        <VisibleInListView(False)>
        Public Property Tolerance_Percentage() As Integer
            Get
                Return fTolerance_Percentage
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Tolerance_Percentage", fTolerance_Percentage, value)
            End Set
        End Property
        Dim fPurchase_Item_Tax_Schedu As String
        <VisibleInListView(False)>
        <Size(15)>
        Public Property Purchase_Item_Tax_Schedu() As String
            Get
                Return fPurchase_Item_Tax_Schedu
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Purchase_Item_Tax_Schedu", fPurchase_Item_Tax_Schedu, value)
            End Set
        End Property
        Dim fPurchase_Tax_Options As Short
        <VisibleInListView(False)>
        Public Property Purchase_Tax_Options() As Short
            Get
                Return fPurchase_Tax_Options
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Purchase_Tax_Options", fPurchase_Tax_Options, value)
            End Set
        End Property
        Dim fITMPLNNNGTYP As Short
        <VisibleInListView(False)>
        Public Property ITMPLNNNGTYP() As Short
            Get
                Return fITMPLNNNGTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ITMPLNNNGTYP", fITMPLNNNGTYP, value)
            End Set
        End Property
        Dim fSTTSTCLVLPRCNTG As Short
        <VisibleInListView(False)>
        Public Property STTSTCLVLPRCNTG() As Short
            Get
                Return fSTTSTCLVLPRCNTG
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("STTSTCLVLPRCNTG", fSTTSTCLVLPRCNTG, value)
            End Set
        End Property
        Dim fCNTRYORGN As String
        <VisibleInListView(False)>
        <Size(7)>
        Public Property CNTRYORGN() As String
            Get
                Return fCNTRYORGN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CNTRYORGN", fCNTRYORGN, value)
            End Set
        End Property
        Dim fINACTIVE As Byte
        <VisibleInListView(False)>
        Public Property INACTIVE() As Byte
            Get
                Return fINACTIVE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INACTIVE", fINACTIVE, value)
            End Set
        End Property
        Dim fMINSHELF1 As Short
        <VisibleInListView(False)>
        Public Property MINSHELF1() As Short
            Get
                Return fMINSHELF1
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MINSHELF1", fMINSHELF1, value)
            End Set
        End Property
        Dim fMINSHELF2 As Short
        <VisibleInListView(False)>
        Public Property MINSHELF2() As Short
            Get
                Return fMINSHELF2
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MINSHELF2", fMINSHELF2, value)
            End Set
        End Property
        Dim fINCLUDEINDP As Byte
        <VisibleInListView(False)>
        Public Property INCLUDEINDP() As Byte
            Get
                Return fINCLUDEINDP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLUDEINDP", fINCLUDEINDP, value)
            End Set
        End Property
        Dim fLOTEXPWARN As Byte
        <VisibleInListView(False)>
        Public Property LOTEXPWARN() As Byte
            Get
                Return fLOTEXPWARN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("LOTEXPWARN", fLOTEXPWARN, value)
            End Set
        End Property
        Dim fLOTEXPWARNDAYS As Short
        <VisibleInListView(False)>
        Public Property LOTEXPWARNDAYS() As Short
            Get
                Return fLOTEXPWARNDAYS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LOTEXPWARNDAYS", fLOTEXPWARNDAYS, value)
            End Set
        End Property
        Dim fDEX_ROW_TS As DateTime
        <VisibleInListView(False)>
        Public Property DEX_ROW_TS() As DateTime
            Get
                Return fDEX_ROW_TS
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DEX_ROW_TS", fDEX_ROW_TS, value)
            End Set
        End Property


#End Region

#Region "Non Persistent Properties"
        ' Return Session.FindObject(Of IVItemCurrency)(New BinaryOperator("Oid.ITEMNMBR", ITEMNMBR))
        <PersistentAlias("[<IVItemCurrency>][Oid.ITEMNMBR = ^.ITEMNMBR].Single(LISTPRCE)")>
        Public ReadOnly Property ItemListPrice As Double
            Get
                Return EvaluateAlias("ItemListPrice")
            End Get
        End Property
        'Private _mItemListPrice As Double?
        'Public ReadOnly Property ItemListPriceO As Double?
        '    Get
        '        If Not _mItemListPrice.HasValue Then
        '            Dim LP As IV.IVItemCurrency
        '            LP = Me.GetListPrice
        '            If LP IsNot Nothing Then
        '                _mItemListPrice = LP.LISTPRCE
        '            End If
        '        End If
        '        Return _mItemListPrice
        '    End Get
        'End Property


        Private _mItemQuantities As XPCollection(Of IVItemQuantity)
        Public ReadOnly Property npItemQuantities As XPCollection(Of IVItemQuantity)
            Get
                _mItemQuantities = New XPCollection(Of IVItemQuantity)(Session, New BinaryOperator("Oid.ITEMNMBR", Me.ITEMNMBR))
                Return _mItemQuantities
            End Get
        End Property


#End Region


        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub


        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
        Public Function GetListPrice() As IVItemCurrency
            Return Session.FindObject(Of IVItemCurrency)(New BinaryOperator("Oid.ITEMNMBR", ITEMNMBR))
        End Function
        Public Function GetPriceForItemBasedOnMethod(ByVal LevelPrice As Decimal, ByVal QtyBsUom As Decimal)
            Dim lstPrice As IVItemCurrency
            Dim decPercent As Decimal
            Select Case PRICMTHD
                Case 1
                    'Currency Amount
                    Return LevelPrice
                Case 2
                    'Percent of List Price
                    lstPrice = GetListPrice()
                    If lstPrice Is Nothing Then
                        Return 0
                    End If
                    Return (lstPrice.LISTPRCE * (LevelPrice / 100)) * QtyBsUom
                Case 3
                    '% Markup - Current Cost
                    'lstPrice = GetListPrice()
                    'If lstPrice Is Nothing Then
                    '    Return 0
                    'End If
                    Return (CURRCOST + (CURRCOST * (LevelPrice / 100))) * QtyBsUom
                Case 4
                    '% Markup - Standard Cost
                    'lstPrice = GetListPrice()
                    'If lstPrice Is Nothing Then
                    '    Return 0
                    'End If
                    Return (STNDCOST + (STNDCOST * (LevelPrice / 100))) * QtyBsUom
                Case 5
                    '% Margin - Current Cost
                    'lstPrice = GetListPrice()
                    'If lstPrice Is Nothing Then
                    '    Return 0
                    'End If
                    decPercent = (100 - LevelPrice) / 100
                    Return (CURRCOST / decPercent) * QtyBsUom
                Case 6
                    '% Margin - Standard Cost
                    'lstPrice = GetListPrice()
                    'If lstPrice Is Nothing Then
                    '    Return 0
                    'End If
                    decPercent = (100 - LevelPrice) / 100
                    Return (STNDCOST / decPercent) * QtyBsUom
            End Select
            Return LevelPrice
        End Function
    End Class

End Namespace
