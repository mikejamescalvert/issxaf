Imports System
Imports DevExpress.Xpo

Namespace Objects.WO

    ''' <summary>
    ''' GP Table WO010032
    ''' </summary>
    <Persistent("WO010032")> _
    <OptimisticLocking(False)> _
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()> _
    Public Class WOManufacturingOrderHeader
        Inherits XPLiteObject
        Dim fMANUFACTUREORDER_I As String
        <Key()> _
        <Size(31)> _
        Public Property MANUFACTUREORDER_I() As String
            Get
                Return fMANUFACTUREORDER_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MANUFACTUREORDER_I", fMANUFACTUREORDER_I, value)
            End Set
        End Property
        Dim fDSCRIPTN As String
        <Size(31)> _
        Public Property DSCRIPTN() As String
            Get
                Return fDSCRIPTN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DSCRIPTN", fDSCRIPTN, value)
            End Set
        End Property
        Dim fMANUFACTUREORDERST_I As Short
        Public Property MANUFACTUREORDERST_I() As Short
            Get
                Return fMANUFACTUREORDERST_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MANUFACTUREORDERST_I", fMANUFACTUREORDERST_I, value)
            End Set
        End Property
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
        Dim fARCHIVED_MO_I As Byte
        Public Property ARCHIVED_MO_I() As Byte
            Get
                Return fARCHIVED_MO_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ARCHIVED_MO_I", fARCHIVED_MO_I, value)
            End Set
        End Property
        Dim fBOMCAT_I As Short
        Public Property BOMCAT_I() As Short
            Get
                Return fBOMCAT_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BOMCAT_I", fBOMCAT_I, value)
            End Set
        End Property
        Dim fBOMNAME_I As String
        <Size(15)> _
        Public Property BOMNAME_I() As String
            Get
                Return fBOMNAME_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOMNAME_I", fBOMNAME_I, value)
            End Set
        End Property
        Dim fROUTINGNAME_I As String
        <Size(31)> _
        Public Property ROUTINGNAME_I() As String
            Get
                Return fROUTINGNAME_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ROUTINGNAME_I", fROUTINGNAME_I, value)
            End Set
        End Property
        Dim fENDQTY_I As Decimal
        Public Property ENDQTY_I() As Decimal
            Get
                Return fENDQTY_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ENDQTY_I", fENDQTY_I, value)
            End Set
        End Property
        Dim fSTARTQTY_I As Decimal
        Public Property STARTQTY_I() As Decimal
            Get
                Return fSTARTQTY_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("STARTQTY_I", fSTARTQTY_I, value)
            End Set
        End Property
        Dim fSTRTDATE As DateTime
        Public Property STRTDATE() As DateTime
            Get
                Return fSTRTDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("STRTDATE", fSTRTDATE, value)
            End Set
        End Property
        Dim fSTARTTIME_I As DateTime
        Public Property STARTTIME_I() As DateTime
            Get
                Return fSTARTTIME_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("STARTTIME_I", fSTARTTIME_I, value)
            End Set
        End Property
        Dim fENDDATE As DateTime
        Public Property ENDDATE() As DateTime
            Get
                Return fENDDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ENDDATE", fENDDATE, value)
            End Set
        End Property
        Dim fDRAWFROMSITE_I As String
        <Size(11)> _
        Public Property DRAWFROMSITE_I() As String
            Get
                Return fDRAWFROMSITE_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DRAWFROMSITE_I", fDRAWFROMSITE_I, value)
            End Set
        End Property
        Dim fCHANGEDATE_I As DateTime
        Public Property CHANGEDATE_I() As DateTime
            Get
                Return fCHANGEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CHANGEDATE_I", fCHANGEDATE_I, value)
            End Set
        End Property
        Dim fUSERID As String
        <Size(15)> _
        Public Property USERID() As String
            Get
                Return fUSERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERID", fUSERID, value)
            End Set
        End Property
        Dim fSCHEDULEMETHOD_I As Short
        Public Property SCHEDULEMETHOD_I() As Short
            Get
                Return fSCHEDULEMETHOD_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SCHEDULEMETHOD_I", fSCHEDULEMETHOD_I, value)
            End Set
        End Property
        Dim fPROJEMPLOYEEHRSSUM_I As Decimal
        Public Property PROJEMPLOYEEHRSSUM_I() As Decimal
            Get
                Return fPROJEMPLOYEEHRSSUM_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PROJEMPLOYEEHRSSUM_I", fPROJEMPLOYEEHRSSUM_I, value)
            End Set
        End Property
        Dim fPROJMACHINEHRSSUM_I As Decimal
        Public Property PROJMACHINEHRSSUM_I() As Decimal
            Get
                Return fPROJMACHINEHRSSUM_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PROJMACHINEHRSSUM_I", fPROJMACHINEHRSSUM_I, value)
            End Set
        End Property
        Dim fMATPROJCOSTI_1 As Decimal
        Public Property MATPROJCOSTI_1() As Decimal
            Get
                Return fMATPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MATPROJCOSTI_1", fMATPROJCOSTI_1, value)
            End Set
        End Property
        Dim fMATPROJCOSTI_2 As Decimal
        Public Property MATPROJCOSTI_2() As Decimal
            Get
                Return fMATPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MATPROJCOSTI_2", fMATPROJCOSTI_2, value)
            End Set
        End Property
        Dim fMATFIXOHDPROJCOSTI_1 As Decimal
        Public Property MATFIXOHDPROJCOSTI_1() As Decimal
            Get
                Return fMATFIXOHDPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MATFIXOHDPROJCOSTI_1", fMATFIXOHDPROJCOSTI_1, value)
            End Set
        End Property
        Dim fMATFIXOHDPROJCOSTI_2 As Decimal
        Public Property MATFIXOHDPROJCOSTI_2() As Decimal
            Get
                Return fMATFIXOHDPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MATFIXOHDPROJCOSTI_2", fMATFIXOHDPROJCOSTI_2, value)
            End Set
        End Property
        Dim fMATVAROHDPROJCOST_1 As Decimal
        Public Property MATVAROHDPROJCOST_1() As Decimal
            Get
                Return fMATVAROHDPROJCOST_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MATVAROHDPROJCOST_1", fMATVAROHDPROJCOST_1, value)
            End Set
        End Property
        Dim fMATVAROHDPROJCOST_2 As Decimal
        Public Property MATVAROHDPROJCOST_2() As Decimal
            Get
                Return fMATVAROHDPROJCOST_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MATVAROHDPROJCOST_2", fMATVAROHDPROJCOST_2, value)
            End Set
        End Property
        Dim fLABPROJCOSTI_1 As Decimal
        Public Property LABPROJCOSTI_1() As Decimal
            Get
                Return fLABPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LABPROJCOSTI_1", fLABPROJCOSTI_1, value)
            End Set
        End Property
        Dim fLABPROJCOSTI_2 As Decimal
        Public Property LABPROJCOSTI_2() As Decimal
            Get
                Return fLABPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LABPROJCOSTI_2", fLABPROJCOSTI_2, value)
            End Set
        End Property
        Dim fLABFIXOHDPROJCOSTI_1 As Decimal
        Public Property LABFIXOHDPROJCOSTI_1() As Decimal
            Get
                Return fLABFIXOHDPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LABFIXOHDPROJCOSTI_1", fLABFIXOHDPROJCOSTI_1, value)
            End Set
        End Property
        Dim fLABFIXOHDPROJCOSTI_2 As Decimal
        Public Property LABFIXOHDPROJCOSTI_2() As Decimal
            Get
                Return fLABFIXOHDPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LABFIXOHDPROJCOSTI_2", fLABFIXOHDPROJCOSTI_2, value)
            End Set
        End Property
        Dim fLABVAROHDPROJCOSTI_1 As Decimal
        Public Property LABVAROHDPROJCOSTI_1() As Decimal
            Get
                Return fLABVAROHDPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LABVAROHDPROJCOSTI_1", fLABVAROHDPROJCOSTI_1, value)
            End Set
        End Property
        Dim fLABVAROHDPROJCOSTI_2 As Decimal
        Public Property LABVAROHDPROJCOSTI_2() As Decimal
            Get
                Return fLABVAROHDPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LABVAROHDPROJCOSTI_2", fLABVAROHDPROJCOSTI_2, value)
            End Set
        End Property
        Dim fMACHPROJCOSTI_1 As Decimal
        Public Property MACHPROJCOSTI_1() As Decimal
            Get
                Return fMACHPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MACHPROJCOSTI_1", fMACHPROJCOSTI_1, value)
            End Set
        End Property
        Dim fMACHPROJCOSTI_2 As Decimal
        Public Property MACHPROJCOSTI_2() As Decimal
            Get
                Return fMACHPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MACHPROJCOSTI_2", fMACHPROJCOSTI_2, value)
            End Set
        End Property
        Dim fMACHFIXOHDPROJCOSTI_1 As Decimal
        Public Property MACHFIXOHDPROJCOSTI_1() As Decimal
            Get
                Return fMACHFIXOHDPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MACHFIXOHDPROJCOSTI_1", fMACHFIXOHDPROJCOSTI_1, value)
            End Set
        End Property
        Dim fMACHFIXOHDPROJCOSTI_2 As Decimal
        Public Property MACHFIXOHDPROJCOSTI_2() As Decimal
            Get
                Return fMACHFIXOHDPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MACHFIXOHDPROJCOSTI_2", fMACHFIXOHDPROJCOSTI_2, value)
            End Set
        End Property
        Dim fMACHVAROHDPROJCOSTI_1 As Decimal
        Public Property MACHVAROHDPROJCOSTI_1() As Decimal
            Get
                Return fMACHVAROHDPROJCOSTI_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MACHVAROHDPROJCOSTI_1", fMACHVAROHDPROJCOSTI_1, value)
            End Set
        End Property
        Dim fMACHVAROHDPROJCOSTI_2 As Decimal
        Public Property MACHVAROHDPROJCOSTI_2() As Decimal
            Get
                Return fMACHVAROHDPROJCOSTI_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MACHVAROHDPROJCOSTI_2", fMACHVAROHDPROJCOSTI_2, value)
            End Set
        End Property
        Dim fPOSTTOSITE_I As String
        <Size(11)> _
        Public Property POSTTOSITE_I() As String
            Get
                Return fPOSTTOSITE_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("POSTTOSITE_I", fPOSTTOSITE_I, value)
            End Set
        End Property
        Dim fLOTNUMBR As String
        <Size(21)> _
        Public Property LOTNUMBR() As String
            Get
                Return fLOTNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOTNUMBR", fLOTNUMBR, value)
            End Set
        End Property
        Dim fSCHEDULINGPREFEREN_I As String
        <Size(21)> _
        Public Property SCHEDULINGPREFEREN_I() As String
            Get
                Return fSCHEDULINGPREFEREN_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SCHEDULINGPREFEREN_I", fSCHEDULINGPREFEREN_I, value)
            End Set
        End Property
        Dim fPLANNAME_I As String
        <Size(15)> _
        Public Property PLANNAME_I() As String
            Get
                Return fPLANNAME_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PLANNAME_I", fPLANNAME_I, value)
            End Set
        End Property
        Dim fACTUALDEMAND_I As Decimal
        Public Property ACTUALDEMAND_I() As Decimal
            Get
                Return fACTUALDEMAND_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ACTUALDEMAND_I", fACTUALDEMAND_I, value)
            End Set
        End Property
        Dim fMANUFACTUREORDPRI_I As Short
        Public Property MANUFACTUREORDPRI_I() As Short
            Get
                Return fMANUFACTUREORDPRI_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MANUFACTUREORDPRI_I", fMANUFACTUREORDPRI_I, value)
            End Set
        End Property
        Dim fPartial_Purge_Date As DateTime
        Public Property Partial_Purge_Date() As DateTime
            Get
                Return fPartial_Purge_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Partial_Purge_Date", fPartial_Purge_Date, value)
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
        Dim fOUTSOURCED_I As Short
        Public Property OUTSOURCED_I() As Short
            Get
                Return fOUTSOURCED_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("OUTSOURCED_I", fOUTSOURCED_I, value)
            End Set
        End Property
        Dim fCOMPCALCOPTION As Short
        Public Property COMPCALCOPTION() As Short
            Get
                Return fCOMPCALCOPTION
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("COMPCALCOPTION", fCOMPCALCOPTION, value)
            End Set
        End Property
        Dim fCOMPLETECLOSEDATE As DateTime
        Public Property COMPLETECLOSEDATE() As DateTime
            Get
                Return fCOMPLETECLOSEDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("COMPLETECLOSEDATE", fCOMPLETECLOSEDATE, value)
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
        Dim fPLNNDSPPLID As Short
        Public Property PLNNDSPPLID() As Short
            Get
                Return fPLNNDSPPLID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PLNNDSPPLID", fPLNNDSPPLID, value)
            End Set
        End Property
        Dim fPICKNUMBER As String
        <Size(17)> _
        Public Property PICKNUMBER() As String
            Get
                Return fPICKNUMBER
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PICKNUMBER", fPICKNUMBER, value)
            End Set
        End Property
        Dim fQUICK_MO_I As Byte
        Public Property QUICK_MO_I() As Byte
            Get
                Return fQUICK_MO_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("QUICK_MO_I", fQUICK_MO_I, value)
            End Set
        End Property
        Dim fROUTING_REVISION_LEVEL As String
        <Size(51)> _
        Public Property ROUTING_REVISION_LEVEL() As String
            Get
                Return fROUTING_REVISION_LEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ROUTING_REVISION_LEVEL", fROUTING_REVISION_LEVEL, value)
            End Set
        End Property
        Dim fBOM_REVISION_LEVEL As String
        <Size(51)> _
        Public Property BOM_REVISION_LEVEL() As String
            Get
                Return fBOM_REVISION_LEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOM_REVISION_LEVEL", fBOM_REVISION_LEVEL, value)
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
