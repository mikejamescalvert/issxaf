Imports System
Imports DevExpress.Xpo

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV40100
    ''' </summary>
    <Persistent("IV40100")>
    <OptimisticLocking(False)>
    Public Class IVSetup
        Inherits XPLiteObject
        Dim fSETUPKEY As Short
        <Key()>
        Public Property SETUPKEY() As Short
            Get
                Return fSETUPKEY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SETUPKEY", fSETUPKEY, value)
            End Set
        End Property
        Dim fUSCATDSC_1 As String
        <Size(15)>
        Public Property USCATDSC_1() As String
            Get
                Return fUSCATDSC_1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATDSC_1", fUSCATDSC_1, value)
            End Set
        End Property
        Dim fUSCATDSC_2 As String
        <Size(15)>
        Public Property USCATDSC_2() As String
            Get
                Return fUSCATDSC_2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATDSC_2", fUSCATDSC_2, value)
            End Set
        End Property
        Dim fUSCATDSC_3 As String
        <Size(15)>
        Public Property USCATDSC_3() As String
            Get
                Return fUSCATDSC_3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATDSC_3", fUSCATDSC_3, value)
            End Set
        End Property
        Dim fUSCATDSC_4 As String
        <Size(15)>
        Public Property USCATDSC_4() As String
            Get
                Return fUSCATDSC_4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATDSC_4", fUSCATDSC_4, value)
            End Set
        End Property
        Dim fUSCATDSC_5 As String
        <Size(15)>
        Public Property USCATDSC_5() As String
            Get
                Return fUSCATDSC_5
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATDSC_5", fUSCATDSC_5, value)
            End Set
        End Property
        Dim fUSCATDSC_6 As String
        <Size(15)>
        Public Property USCATDSC_6() As String
            Get
                Return fUSCATDSC_6
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USCATDSC_6", fUSCATDSC_6, value)
            End Set
        End Property
        Dim fDCDCRADJ As Byte
        Public Property DCDCRADJ() As Byte
            Get
                Return fDCDCRADJ
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DCDCRADJ", fDCDCRADJ, value)
            End Set
        End Property
        Dim fACSGFLOC As Short
        Public Property ACSGFLOC() As Short
            Get
                Return fACSGFLOC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ACSGFLOC", fACSGFLOC, value)
            End Set
        End Property
        Dim fMAINLOCN As String
        <Size(11)>
        Public Property MAINLOCN() As String
            Get
                Return fMAINLOCN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MAINLOCN", fMAINLOCN, value)
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
        Dim fNXADJDOC As String
        <Size(21)>
        Public Property NXADJDOC() As String
            Get
                Return fNXADJDOC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NXADJDOC", fNXADJDOC, value)
            End Set
        End Property
        Dim fTXTRDNUM As String
        <Size(21)>
        Public Property TXTRDNUM() As String
            Get
                Return fTXTRDNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXTRDNUM", fTXTRDNUM, value)
            End Set
        End Property
        Dim fNXTVDNUM As String
        <Size(21)>
        Public Property NXTVDNUM() As String
            Get
                Return fNXTVDNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NXTVDNUM", fNXTVDNUM, value)
            End Set
        End Property
        Dim fNXPRDNUM As String
        <Size(21)>
        Public Property NXPRDNUM() As String
            Get
                Return fNXPRDNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NXPRDNUM", fNXPRDNUM, value)
            End Set
        End Property
        Dim fALADJOVR As Byte
        Public Property ALADJOVR() As Byte
            Get
                Return fALADJOVR
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALADJOVR", fALADJOVR, value)
            End Set
        End Property
        Dim fAVAROVRD As Byte
        Public Property AVAROVRD() As Byte
            Get
                Return fAVAROVRD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("AVAROVRD", fAVAROVRD, value)
            End Set
        End Property
        Dim fATRSOVRD As Byte
        Public Property ATRSOVRD() As Byte
            Get
                Return fATRSOVRD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ATRSOVRD", fATRSOVRD, value)
            End Set
        End Property
        Dim fATPSTVRNC As Byte
        Public Property ATPSTVRNC() As Byte
            Get
                Return fATPSTVRNC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ATPSTVRNC", fATPSTVRNC, value)
            End Set
        End Property
        Dim fENABLEMULTIBIN As Byte
        Public Property ENABLEMULTIBIN() As Byte
            Get
                Return fENABLEMULTIBIN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ENABLEMULTIBIN", fENABLEMULTIBIN, value)
            End Set
        End Property
        Dim fENPICKSHORTTSK As Byte
        Public Property ENPICKSHORTTSK() As Byte
            Get
                Return fENPICKSHORTTSK
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ENPICKSHORTTSK", fENPICKSHORTTSK, value)
            End Set
        End Property
        Dim fUSERID As String
        <Size(15)>
        Public Property USERID() As String
            Get
                Return fUSERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERID", fUSERID, value)
            End Set
        End Property
        Dim fDISABLEAVGPERPADJ As Byte
        Public Property DISABLEAVGPERPADJ() As Byte
            Get
                Return fDISABLEAVGPERPADJ
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DISABLEAVGPERPADJ", fDISABLEAVGPERPADJ, value)
            End Set
        End Property
        Dim fDISABLEPERPADJ As Byte
        Public Property DISABLEPERPADJ() As Byte
            Get
                Return fDISABLEPERPADJ
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DISABLEPERPADJ", fDISABLEPERPADJ, value)
            End Set
        End Property
        Dim fALLEXPLOTSIV As Byte
        Public Property ALLEXPLOTSIV() As Byte
            Get
                Return fALLEXPLOTSIV
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLEXPLOTSIV", fALLEXPLOTSIV, value)
            End Set
        End Property
        Dim fALLEXPLOTSIVPASS As String
        <Size(11)>
        Public Property ALLEXPLOTSIVPASS() As String
            Get
                Return fALLEXPLOTSIVPASS
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ALLEXPLOTSIVPASS", fALLEXPLOTSIVPASS, value)
            End Set
        End Property
        Dim fALLEXPLOTSOTHER As Byte
        Public Property ALLEXPLOTSOTHER() As Byte
            Get
                Return fALLEXPLOTSOTHER
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLEXPLOTSOTHER", fALLEXPLOTSOTHER, value)
            End Set
        End Property
        Dim fALLEXPLOTOTHERPASS As String
        <Size(11)>
        Public Property ALLEXPLOTOTHERPASS() As String
            Get
                Return fALLEXPLOTOTHERPASS
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ALLEXPLOTOTHERPASS", fALLEXPLOTOTHERPASS, value)
            End Set
        End Property
        Dim fUSEEXISTINGSNLOTS As Byte
        Public Property USEEXISTINGSNLOTS() As Byte
            Get
                Return fUSEEXISTINGSNLOTS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("USEEXISTINGSNLOTS", fUSEEXISTINGSNLOTS, value)
            End Set
        End Property
        Dim fASSIGNLOTNUMBY As Short
        Public Property ASSIGNLOTNUMBY() As Short
            Get
                Return fASSIGNLOTNUMBY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ASSIGNLOTNUMBY", fASSIGNLOTNUMBY, value)
            End Set
        End Property
        Dim fNXTSPNUM As String
        <Size(15)>
        Public Property NXTSPNUM() As String
            Get
                Return fNXTSPNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NXTSPNUM", fNXTSPNUM, value)
            End Set
        End Property
        Dim fVIALOCN As String
        <Size(11)>
        Public Property VIALOCN() As String
            Get
                Return fVIALOCN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VIALOCN", fVIALOCN, value)
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