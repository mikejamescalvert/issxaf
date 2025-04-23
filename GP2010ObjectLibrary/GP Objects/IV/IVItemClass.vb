Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports System.ComponentModel

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV40400
    ''' </summary>
    <DefaultProperty("SummaryInfo")>
    <Persistent("IV40400")>
    Public Class IVItemClass
        Inherits XPLiteObject

        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <PersistentAlias("concat(ITMCLSCD,' - ',ITMCLSDC)")>
        Public ReadOnly Property SummaryInfo As String
            Get
                Return String.Format("{0} - {1}", ITMCLSCD, ITMCLSDC)
            End Get
        End Property

        Dim fITMCLSCD As String
        <Key()>
        <Size(11)>
        Public Property ITMCLSCD() As String
            Get
                Return fITMCLSCD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMCLSCD", fITMCLSCD, value)
            End Set
        End Property
        Dim fITMCLSDC As String
        <Size(31)>
        Public Property ITMCLSDC() As String
            Get
                Return fITMCLSDC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMCLSDC", fITMCLSDC, value)
            End Set
        End Property
        Dim fDEFLTCLS As Byte
        Public Property DEFLTCLS() As Byte
            Get
                Return fDEFLTCLS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DEFLTCLS", fDEFLTCLS, value)
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
        Dim fITEMTYPE As Short
        Public Property ITEMTYPE() As Short
            Get
                Return fITEMTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ITEMTYPE", fITEMTYPE, value)
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
        Dim fLOTTYPE As String
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
        Public Property KPERHIST() As Byte
            Get
                Return fKPERHIST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPERHIST", fKPERHIST, value)
            End Set
        End Property
        Dim fKPTRXHST As Byte
        Public Property KPTRXHST() As Byte
            Get
                Return fKPTRXHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPTRXHST", fKPTRXHST, value)
            End Set
        End Property
        Dim fKPCALHST As Byte
        Public Property KPCALHST() As Byte
            Get
                Return fKPCALHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPCALHST", fKPCALHST, value)
            End Set
        End Property
        Dim fKPDSTHST As Byte
        Public Property KPDSTHST() As Byte
            Get
                Return fKPDSTHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPDSTHST", fKPDSTHST, value)
            End Set
        End Property
        Dim fALWBKORD As Byte
        Public Property ALWBKORD() As Byte
            Get
                Return fALWBKORD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALWBKORD", fALWBKORD, value)
            End Set
        End Property
        Dim fITMGEDSC As String
        <Size(11)>
        Public Property ITMGEDSC() As String
            Get
                Return fITMGEDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMGEDSC", fITMGEDSC, value)
            End Set
        End Property
        Dim fTAXOPTNS As Short
        Public Property TAXOPTNS() As Short
            Get
                Return fTAXOPTNS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TAXOPTNS", fTAXOPTNS, value)
            End Set
        End Property
        Dim fITMTSHID As String
        <Size(15)>
        Public Property ITMTSHID() As String
            Get
                Return fITMTSHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITMTSHID", fITMTSHID, value)
            End Set
        End Property
        Dim fPurchase_Tax_Options As Short
        Public Property Purchase_Tax_Options() As Short
            Get
                Return fPurchase_Tax_Options
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Purchase_Tax_Options", fPurchase_Tax_Options, value)
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
        Dim fUOMSCHDL As String
        <Size(11)>
        Public Property UOMSCHDL() As String
            Get
                Return fUOMSCHDL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOMSCHDL", fUOMSCHDL, value)
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
        Dim fUSCATVLS_1 As String
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
        <Size(11)>
        Public Property USCATVLS_6() As String
            Get
                Return fUSCATVLS_6
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATVLS_6", fUSCATVLS_6, value)
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
        Dim fIVIVINDX As Integer
        Public Property IVIVINDX() As Integer
            Get
                Return fIVIVINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVINDX", fIVIVINDX, value)
            End Set
        End Property
        Dim fIVIVOFIX As Integer
        Public Property IVIVOFIX() As Integer
            Get
                Return fIVIVOFIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVOFIX", fIVIVOFIX, value)
            End Set
        End Property
        Dim fIVCOGSIX As Integer
        Public Property IVCOGSIX() As Integer
            Get
                Return fIVCOGSIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVCOGSIX", fIVCOGSIX, value)
            End Set
        End Property
        Dim fIVSLSIDX As Integer
        Public Property IVSLSIDX() As Integer
            Get
                Return fIVSLSIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVSLSIDX", fIVSLSIDX, value)
            End Set
        End Property
        Dim fIVSLDSIX As Integer
        Public Property IVSLDSIX() As Integer
            Get
                Return fIVSLDSIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVSLDSIX", fIVSLDSIX, value)
            End Set
        End Property
        Dim fIVSLRNIX As Integer
        Public Property IVSLRNIX() As Integer
            Get
                Return fIVSLRNIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVSLRNIX", fIVSLRNIX, value)
            End Set
        End Property
        Dim fIVINUSIX As Integer
        Public Property IVINUSIX() As Integer
            Get
                Return fIVINUSIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVINUSIX", fIVINUSIX, value)
            End Set
        End Property
        Dim fIVINSVIX As Integer
        Public Property IVINSVIX() As Integer
            Get
                Return fIVINSVIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVINSVIX", fIVINSVIX, value)
            End Set
        End Property
        Dim fIVDMGIDX As Integer
        Public Property IVDMGIDX() As Integer
            Get
                Return fIVDMGIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVDMGIDX", fIVDMGIDX, value)
            End Set
        End Property
        Dim fIVVARIDX As Integer
        Public Property IVVARIDX() As Integer
            Get
                Return fIVVARIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVVARIDX", fIVVARIDX, value)
            End Set
        End Property
        Dim fDPSHPIDX As Integer
        Public Property DPSHPIDX() As Integer
            Get
                Return fDPSHPIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DPSHPIDX", fDPSHPIDX, value)
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
        Dim fUPPVIDX As Integer
        Public Property UPPVIDX() As Integer
            Get
                Return fUPPVIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("UPPVIDX", fUPPVIDX, value)
            End Set
        End Property
        Dim fIVRETIDX As Integer
        Public Property IVRETIDX() As Integer
            Get
                Return fIVRETIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVRETIDX", fIVRETIDX, value)
            End Set
        End Property
        Dim fASMVRIDX As Integer
        Public Property ASMVRIDX() As Integer
            Get
                Return fASMVRIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ASMVRIDX", fASMVRIDX, value)
            End Set
        End Property
        Dim fPRCLEVEL As String
        <Size(11)>
        Public Property PRCLEVEL() As String
            Get
                Return fPRCLEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCLEVEL", fPRCLEVEL, value)
            End Set
        End Property
        Dim fPriceGroup As String
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
        Public Property PRICMTHD() As Short
            Get
                Return fPRICMTHD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PRICMTHD", fPRICMTHD, value)
            End Set
        End Property
        Dim fTCC As String
        <Size(31)>
        Public Property TCC() As String
            Get
                Return fTCC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TCC", fTCC, value)
            End Set
        End Property
        Dim fRevalue_Inventory As Byte
        Public Property Revalue_Inventory() As Byte
            Get
                Return fRevalue_Inventory
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Revalue_Inventory", fRevalue_Inventory, value)
            End Set
        End Property
        Dim fTolerance_Percentage As Integer
        Public Property Tolerance_Percentage() As Integer
            Get
                Return fTolerance_Percentage
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Tolerance_Percentage", fTolerance_Percentage, value)
            End Set
        End Property
        Dim fCNTRYORGN As String
        <Size(7)>
        Public Property CNTRYORGN() As String
            Get
                Return fCNTRYORGN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CNTRYORGN", fCNTRYORGN, value)
            End Set
        End Property
        Dim fSTTSTCLVLPRCNTG As Short
        Public Property STTSTCLVLPRCNTG() As Short
            Get
                Return fSTTSTCLVLPRCNTG
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("STTSTCLVLPRCNTG", fSTTSTCLVLPRCNTG, value)
            End Set
        End Property
        Dim fINCLUDEINDP As Byte
        Public Property INCLUDEINDP() As Byte
            Get
                Return fINCLUDEINDP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLUDEINDP", fINCLUDEINDP, value)
            End Set
        End Property
        Dim fLOTEXPWARN As Byte
        Public Property LOTEXPWARN() As Byte
            Get
                Return fLOTEXPWARN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("LOTEXPWARN", fLOTEXPWARN, value)
            End Set
        End Property
        Dim fLOTEXPWARNDAYS As Short
        Public Property LOTEXPWARNDAYS() As Short
            Get
                Return fLOTEXPWARNDAYS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LOTEXPWARNDAYS", fLOTEXPWARNDAYS, value)
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
