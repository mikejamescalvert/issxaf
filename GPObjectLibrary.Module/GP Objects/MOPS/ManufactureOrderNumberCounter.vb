Imports System
Imports DevExpress.Xpo
Namespace Objects.MOPS
    ''' <summary>
    ''' GP Table MOPS0100
    ''' </summary>
    <Persistent("mops0100")> _
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()> _
    <OptimisticLocking(False)> _
    Public Class ManufactureOrderNumberCounter
        Inherits XPLiteObject
        Dim fMANUFACTUREORDER_I As String
        <Size(31)> _
        Public Property MANUFACTUREORDER_I() As String
            Get
                Return fMANUFACTUREORDER_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MANUFACTUREORDER_I", fMANUFACTUREORDER_I, value)
            End Set
        End Property
        Dim fCMPANYID As Short
        <Key()> _
        Public Property CMPANYID() As Short
            Get
                Return fCMPANYID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CMPANYID", fCMPANYID, value)
            End Set
        End Property
        Dim fDelete_Configured_BOM As Byte
        Public Property Delete_Configured_BOM() As Byte
            Get
                Return fDelete_Configured_BOM
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Delete_Configured_BOM", fDelete_Configured_BOM, value)
            End Set
        End Property
        Dim fArchive_Configured_BOM As Byte
        Public Property Archive_Configured_BOM() As Byte
            Get
                Return fArchive_Configured_BOM
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Archive_Configured_BOM", fArchive_Configured_BOM, value)
            End Set
        End Property
        Dim fRemove_Canceled_MO As Byte
        Public Property Remove_Canceled_MO() As Byte
            Get
                Return fRemove_Canceled_MO
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Remove_Canceled_MO", fRemove_Canceled_MO, value)
            End Set
        End Property
        Dim fRemove_Canceled_MO_Days As Short
        Public Property Remove_Canceled_MO_Days() As Short
            Get
                Return fRemove_Canceled_MO_Days
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Remove_Canceled_MO_Days", fRemove_Canceled_MO_Days, value)
            End Set
        End Property
        Dim fRemove_CF_MO As Byte
        Public Property Remove_CF_MO() As Byte
            Get
                Return fRemove_CF_MO
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Remove_CF_MO", fRemove_CF_MO, value)
            End Set
        End Property
        Dim fRemove_CF_MO_Days As Short
        Public Property Remove_CF_MO_Days() As Short
            Get
                Return fRemove_CF_MO_Days
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Remove_CF_MO_Days", fRemove_CF_MO_Days, value)
            End Set
        End Property
        Dim fRemove_LotSerial_MO As Byte
        Public Property Remove_LotSerial_MO() As Byte
            Get
                Return fRemove_LotSerial_MO
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Remove_LotSerial_MO", fRemove_LotSerial_MO, value)
            End Set
        End Property
        Dim fRemove_LotSerial_MO_Days As Short
        Public Property Remove_LotSerial_MO_Days() As Short
            Get
                Return fRemove_LotSerial_MO_Days
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Remove_LotSerial_MO_Days", fRemove_LotSerial_MO_Days, value)
            End Set
        End Property
        Dim fMOCloseOption As Short
        Public Property MOCloseOption() As Short
            Get
                Return fMOCloseOption
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MOCloseOption", fMOCloseOption, value)
            End Set
        End Property
        Dim fOSRCLABEL As String
        <Size(21)> _
        Public Property OSRCLABEL() As String
            Get
                Return fOSRCLABEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("OSRCLABEL", fOSRCLABEL, value)
            End Set
        End Property
        Dim fPROCESSSECURITY As String
        <Size(31)> _
        Public Property PROCESSSECURITY() As String
            Get
                Return fPROCESSSECURITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PROCESSSECURITY", fPROCESSSECURITY, value)
            End Set
        End Property
        Dim fPROCESSSECURITY2 As String
        <Size(31)> _
        Public Property PROCESSSECURITY2() As String
            Get
                Return fPROCESSSECURITY2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PROCESSSECURITY2", fPROCESSSECURITY2, value)
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
        Dim fMOPRCTNM As String
        <Size(21)> _
        Public Property MOPRCTNM() As String
            Get
                Return fMOPRCTNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MOPRCTNM", fMOPRCTNM, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_1 As Byte
        Public Property MOCLOSEOPTIONS_1() As Byte
            Get
                Return fMOCLOSEOPTIONS_1
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_1", fMOCLOSEOPTIONS_1, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_2 As Byte
        Public Property MOCLOSEOPTIONS_2() As Byte
            Get
                Return fMOCLOSEOPTIONS_2
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_2", fMOCLOSEOPTIONS_2, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_3 As Byte
        Public Property MOCLOSEOPTIONS_3() As Byte
            Get
                Return fMOCLOSEOPTIONS_3
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_3", fMOCLOSEOPTIONS_3, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_4 As Byte
        Public Property MOCLOSEOPTIONS_4() As Byte
            Get
                Return fMOCLOSEOPTIONS_4
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_4", fMOCLOSEOPTIONS_4, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_5 As Byte
        Public Property MOCLOSEOPTIONS_5() As Byte
            Get
                Return fMOCLOSEOPTIONS_5
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_5", fMOCLOSEOPTIONS_5, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_6 As Byte
        Public Property MOCLOSEOPTIONS_6() As Byte
            Get
                Return fMOCLOSEOPTIONS_6
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_6", fMOCLOSEOPTIONS_6, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_7 As Byte
        Public Property MOCLOSEOPTIONS_7() As Byte
            Get
                Return fMOCLOSEOPTIONS_7
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_7", fMOCLOSEOPTIONS_7, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_8 As Byte
        Public Property MOCLOSEOPTIONS_8() As Byte
            Get
                Return fMOCLOSEOPTIONS_8
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_8", fMOCLOSEOPTIONS_8, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_9 As Byte
        Public Property MOCLOSEOPTIONS_9() As Byte
            Get
                Return fMOCLOSEOPTIONS_9
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_9", fMOCLOSEOPTIONS_9, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_10 As Byte
        Public Property MOCLOSEOPTIONS_10() As Byte
            Get
                Return fMOCLOSEOPTIONS_10
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_10", fMOCLOSEOPTIONS_10, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_11 As Byte
        Public Property MOCLOSEOPTIONS_11() As Byte
            Get
                Return fMOCLOSEOPTIONS_11
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_11", fMOCLOSEOPTIONS_11, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_12 As Byte
        Public Property MOCLOSEOPTIONS_12() As Byte
            Get
                Return fMOCLOSEOPTIONS_12
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_12", fMOCLOSEOPTIONS_12, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_13 As Byte
        Public Property MOCLOSEOPTIONS_13() As Byte
            Get
                Return fMOCLOSEOPTIONS_13
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_13", fMOCLOSEOPTIONS_13, value)
            End Set
        End Property
        Dim fMOCLOSEOPTIONS_14 As Byte
        Public Property MOCLOSEOPTIONS_14() As Byte
            Get
                Return fMOCLOSEOPTIONS_14
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MOCLOSEOPTIONS_14", fMOCLOSEOPTIONS_14, value)
            End Set
        End Property
        Dim fALLOCATERELEASED As Byte
        Public Property ALLOCATERELEASED() As Byte
            Get
                Return fALLOCATERELEASED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLOCATERELEASED", fALLOCATERELEASED, value)
            End Set
        End Property
        Dim fCOMPLETEMOATCOMPCLOSE As Byte
        Public Property COMPLETEMOATCOMPCLOSE() As Byte
            Get
                Return fCOMPLETEMOATCOMPCLOSE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("COMPLETEMOATCOMPCLOSE", fCOMPLETEMOATCOMPCLOSE, value)
            End Set
        End Property
        Dim fCLOSEMOATCOMPCLOSE As Byte
        Public Property CLOSEMOATCOMPCLOSE() As Byte
            Get
                Return fCLOSEMOATCOMPCLOSE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CLOSEMOATCOMPCLOSE", fCLOSEMOATCOMPCLOSE, value)
            End Set
        End Property
        Dim fREVAL_IN_PROCESS_I As Byte
        Public Property REVAL_IN_PROCESS_I() As Byte
            Get
                Return fREVAL_IN_PROCESS_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("REVAL_IN_PROCESS_I", fREVAL_IN_PROCESS_I, value)
            End Set
        End Property
        Dim fRECONCILE_IN_PROCESS_I As Byte
        Public Property RECONCILE_IN_PROCESS_I() As Byte
            Get
                Return fRECONCILE_IN_PROCESS_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("RECONCILE_IN_PROCESS_I", fRECONCILE_IN_PROCESS_I, value)
            End Set
        End Property
        Dim fPRINT_PICKLIST_NOTES As Byte
        Public Property PRINT_PICKLIST_NOTES() As Byte
            Get
                Return fPRINT_PICKLIST_NOTES
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("PRINT_PICKLIST_NOTES", fPRINT_PICKLIST_NOTES, value)
            End Set
        End Property
        Dim fALLOCATE_REV_ISS_I As Byte
        Public Property ALLOCATE_REV_ISS_I() As Byte
            Get
                Return fALLOCATE_REV_ISS_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLOCATE_REV_ISS_I", fALLOCATE_REV_ISS_I, value)
            End Set
        End Property
        Dim fFLRSTCKACCNTINDEX As Integer
        Public Property FLRSTCKACCNTINDEX() As Integer
            Get
                Return fFLRSTCKACCNTINDEX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("FLRSTCKACCNTINDEX", fFLRSTCKACCNTINDEX, value)
            End Set
        End Property
        Dim fCBXALLOWNEGATIVEWIP As Byte
        Public Property CBXALLOWNEGATIVEWIP() As Byte
            Get
                Return fCBXALLOWNEGATIVEWIP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CBXALLOWNEGATIVEWIP", fCBXALLOWNEGATIVEWIP, value)
            End Set
        End Property
        Dim fMANUALSELECT As Byte
        Public Property MANUALSELECT() As Byte
            Get
                Return fMANUALSELECT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MANUALSELECT", fMANUALSELECT, value)
            End Set
        End Property
        Dim fDEF_PICKLIST_SORTBY As Short
        Public Property DEF_PICKLIST_SORTBY() As Short
            Get
                Return fDEF_PICKLIST_SORTBY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DEF_PICKLIST_SORTBY", fDEF_PICKLIST_SORTBY, value)
            End Set
        End Property
        Dim fMFGUSEALLCOLLECTED As Byte
        Public Property MFGUSEALLCOLLECTED() As Byte
            Get
                Return fMFGUSEALLCOLLECTED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MFGUSEALLCOLLECTED", fMFGUSEALLCOLLECTED, value)
            End Set
        End Property
        Dim fMFGUSEALLSETUP As Byte
        Public Property MFGUSEALLSETUP() As Byte
            Get
                Return fMFGUSEALLSETUP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MFGUSEALLSETUP", fMFGUSEALLSETUP, value)
            End Set
        End Property
        Dim fMFGUSEALLWIP As Byte
        Public Property MFGUSEALLWIP() As Byte
            Get
                Return fMFGUSEALLWIP
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MFGUSEALLWIP", fMFGUSEALLWIP, value)
            End Set
        End Property
        Dim fLOTSLCTNMTHD As Short
        Public Property LOTSLCTNMTHD() As Short
            Get
                Return fLOTSLCTNMTHD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LOTSLCTNMTHD", fLOTSLCTNMTHD, value)
            End Set
        End Property
        Dim fREQLNKNG As Byte
        Public Property REQLNKNG() As Byte
            Get
                Return fREQLNKNG
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("REQLNKNG", fREQLNKNG, value)
            End Set
        End Property
        Dim fUSE_DEFAULT_BIN As Byte
        Public Property USE_DEFAULT_BIN() As Byte
            Get
                Return fUSE_DEFAULT_BIN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("USE_DEFAULT_BIN", fUSE_DEFAULT_BIN, value)
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
