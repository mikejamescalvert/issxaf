Imports System
Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Imports System.ComponentModel

Namespace Objects.PK

    Public Structure PickListItemKey
        Private _mMANUFACTUREORDER_I As String

        <Persistent("MANUFACTUREORDER_I")> _
        Public Property MANUFACTUREORDER_I() As String
            Get
                Return _mMANUFACTUREORDER_I
            End Get
            Set(ByVal value As String)
                If _mMANUFACTUREORDER_I = value Then
                    Return
                End If
                _mMANUFACTUREORDER_I = value
            End Set
        End Property
        Private _mSEQ_I As Integer

        <Persistent("SEQ_I")> _
        Public Property SEQ_I() As Integer
            Get
                Return _mSEQ_I
            End Get
            Set(ByVal value As Integer)
                If _mSEQ_I = value Then
                    Return
                End If
                _mSEQ_I = value
            End Set
        End Property
        Private _mPPN_I As String

        <Persistent("PPN_I")> _
        Public Property PPN_I() As String
            Get
                Return _mPPN_I
            End Get
            Set(ByVal value As String)
                If _mPPN_I = value Then
                    Return
                End If
                _mPPN_I = value
            End Set
        End Property
        Private _mITEMNMBR As String
        <Persistent("ITEMNMBR")> _
        Public Property ITEMNMBR() As String
            Get
                Return _mITEMNMBR
            End Get
            Set(ByVal value As String)
                If _mITEMNMBR = value Then
                    Return
                End If
                _mITEMNMBR = value
            End Set
        End Property
    End Structure
    ''' <summary>
    ''' GP Table PK010033
    ''' </summary>
    <Persistent("PK010033")> _
    <OptimisticLocking(False)> _
    <DefaultProperty("GPItem")> _
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()> _
    Public Class PKPickListItem
        Inherits XPLiteObject
        Dim fOid As PickListItemKey

        <Key()> _
        <Persistent()> _
        Public Property Oid() As PickListItemKey
            Get
                Return fOid
            End Get
            Set(ByVal value As PickListItemKey)
                SetPropertyValue(Of PickListItemKey)("Oid", fOid, value)
            End Set
        End Property
        'Dim fMANUFACTUREORDER_I As String
        '<Size(31)> _
        'Public Property MANUFACTUREORDER_I() As String
        '    Get
        '        Return fMANUFACTUREORDER_I
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("MANUFACTUREORDER_I", fMANUFACTUREORDER_I, value)
        '    End Set
        'End Property
        'Dim fSEQ_I As Integer
        'Public Property SEQ_I() As Integer
        '    Get
        '        Return fSEQ_I
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("SEQ_I", fSEQ_I, value)
        '    End Set
        'End Property
        'Dim fPPN_I As String
        '<Size(31)> _
        'Public Property PPN_I() As String
        '    Get
        '        Return fPPN_I
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("PPN_I", fPPN_I, value)
        '    End Set
        'End Property
        'Dim fITEMNMBR As String
        '<Size(31)> _
        'Public Property ITEMNMBR() As String
        '    Get
        '        Return fITEMNMBR
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
        '    End Set
        'End PropertyPickListItemKey
        Dim fMANUFACTUREORDERST_I As Short

        Public Property MANUFACTUREORDERST_I() As Short
            Get
                Return fMANUFACTUREORDERST_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MANUFACTUREORDERST_I", fMANUFACTUREORDERST_I, value)

            End Set
        End Property

        Dim fPOSITION_NUMBER As Short

        Public Property POSITION_NUMBER() As Short
            Get
                Return fPOSITION_NUMBER
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POSITION_NUMBER", fPOSITION_NUMBER, value)
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
        Dim fRTSEQNUM_I As String


        <Size(11)> _
        Public Property RTSEQNUM_I() As String
            Get
                Return fRTSEQNUM_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RTSEQNUM_I", fRTSEQNUM_I, value)
            End Set
        End Property
        Dim fMRPAMOUNT_I As Decimal

        Public Property MRPAMOUNT_I() As Decimal
            Get
                Return fMRPAMOUNT_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MRPAMOUNT_I", fMRPAMOUNT_I, value)
            End Set
        End Property
        Dim fMRPAMOUNT2_I As Decimal

        Public Property MRPAMOUNT2_I() As Decimal
            Get
                Return fMRPAMOUNT2_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MRPAMOUNT2_I", fMRPAMOUNT2_I, value)
            End Set
        End Property
        Dim fSUGGESTEDQTY_I As Decimal
        <Persistent("SUGGESTEDQTY_I")> _
        Public Property SuggestedQuantity() As Decimal
            Get
                Return fSUGGESTEDQTY_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SUGGESTEDQTY_I", fSUGGESTEDQTY_I, value)
            End Set
        End Property
        Dim fMRPISSUEDATE_I As DateTime

        Public Property MRPISSUEDATE_I() As DateTime
            Get
                Return fMRPISSUEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MRPISSUEDATE_I", fMRPISSUEDATE_I, value)
            End Set
        End Property
        Dim fMRPISSUETIME_I As DateTime

        Public Property MRPISSUETIME_I() As DateTime
            Get
                Return fMRPISSUETIME_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MRPISSUETIME_I", fMRPISSUETIME_I, value)
            End Set
        End Property
        Dim fALLOCATEDATEI As DateTime

        Public Property ALLOCATEDATEI() As DateTime
            Get
                Return fALLOCATEDATEI
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ALLOCATEDATEI", fALLOCATEDATEI, value)
            End Set
        End Property
        Dim fALLOCATETIMEI As DateTime

        Public Property ALLOCATETIMEI() As DateTime
            Get
                Return fALLOCATETIMEI
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ALLOCATETIMEI", fALLOCATETIMEI, value)
            End Set
        End Property
        Dim fWCID_I As String

        <Size(11)> _
        Public Property WCID_I() As String
            Get
                Return fWCID_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WCID_I", fWCID_I, value)
            End Set
        End Property
        Dim fBACKFLUSHITEM_I As Byte

        Public Property BACKFLUSHITEM_I() As Byte
            Get
                Return fBACKFLUSHITEM_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BACKFLUSHITEM_I", fBACKFLUSHITEM_I, value)
            End Set
        End Property
        Dim fICBACKORDER_I As Byte

        Public Property ICBACKORDER_I() As Byte
            Get
                Return fICBACKORDER_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ICBACKORDER_I", fICBACKORDER_I, value)
            End Set
        End Property
        Dim fALTERNATE_I As Byte

        Public Property ALTERNATE_I() As Byte
            Get
                Return fALTERNATE_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALTERNATE_I", fALTERNATE_I, value)
            End Set
        End Property
        Dim fALTERNATEPARTFOR_I As String

        <Size(31)> _
        Public Property ALTERNATEPARTFOR_I() As String
            Get
                Return fALTERNATEPARTFOR_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ALTERNATEPARTFOR_I", fALTERNATEPARTFOR_I, value)
            End Set
        End Property
        Dim fALT_FOR_SEQ_I As Integer

        Public Property ALT_FOR_SEQ_I() As Integer
            Get
                Return fALT_FOR_SEQ_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ALT_FOR_SEQ_I", fALT_FOR_SEQ_I, value)
            End Set
        End Property
        Dim fSUBASSEMBLY_I As Byte

        Public Property SUBASSEMBLY_I() As Byte
            Get
                Return fSUBASSEMBLY_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SUBASSEMBLY_I", fSUBASSEMBLY_I, value)
            End Set
        End Property
        Dim fSUBASSEMBLYOF_I As String

        <Size(31)> _
        Public Property SUBASSEMBLYOF_I() As String
            Get
                Return fSUBASSEMBLYOF_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SUBASSEMBLYOF_I", fSUBASSEMBLYOF_I, value)
            End Set
        End Property
        Dim fSUBASSEMBLY_OF_SEQ As Integer

        Public Property SUBASSEMBLY_OF_SEQ() As Integer
            Get
                Return fSUBASSEMBLY_OF_SEQ
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SUBASSEMBLY_OF_SEQ", fSUBASSEMBLY_OF_SEQ, value)
            End Set
        End Property
        Dim fBOMENGAPPROVAL_I As Byte

        Public Property BOMENGAPPROVAL_I() As Byte
            Get
                Return fBOMENGAPPROVAL_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BOMENGAPPROVAL_I", fBOMENGAPPROVAL_I, value)
            End Set
        End Property
        Dim fBOMSINGLELOT_I As Byte

        Public Property BOMSINGLELOT_I() As Byte
            Get
                Return fBOMSINGLELOT_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BOMSINGLELOT_I", fBOMSINGLELOT_I, value)
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
        Dim fALLOCATED_I As Byte

        Public Property ALLOCATED_I() As Byte
            Get
                Return fALLOCATED_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ALLOCATED_I", fALLOCATED_I, value)
            End Set
        End Property
        Dim fISSUED_I As Byte

        Public Property ISSUED_I() As Byte
            Get
                Return fISSUED_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ISSUED_I", fISSUED_I, value)
            End Set
        End Property
        Dim fFLOORSTOCK_I As Byte

        Public Property FLOORSTOCK_I() As Byte
            Get
                Return fFLOORSTOCK_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("FLOORSTOCK_I", fFLOORSTOCK_I, value)
            End Set
        End Property
        Dim fCALCMRP_I As Byte

        Public Property CALCMRP_I() As Byte
            Get
                Return fCALCMRP_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CALCMRP_I", fCALCMRP_I, value)
            End Set
        End Property
        Dim fPHANTOM_I As Byte

        Public Property PHANTOM_I() As Byte
            Get
                Return fPHANTOM_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("PHANTOM_I", fPHANTOM_I, value)
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
        Dim fALLOCATEUID_I As String

        <Size(15)> _
        Public Property ALLOCATEUID_I() As String
            Get
                Return fALLOCATEUID_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ALLOCATEUID_I", fALLOCATEUID_I, value)
            End Set
        End Property
        Dim fISSUEDUID_I As String

        <Size(15)> _
        Public Property ISSUEDUID_I() As String
            Get
                Return fISSUEDUID_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ISSUEDUID_I", fISSUEDUID_I, value)
            End Set
        End Property
        Dim fRELIEFCOST_I As Decimal

        Public Property RELIEFCOST_I() As Decimal
            Get
                Return fRELIEFCOST_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RELIEFCOST_I", fRELIEFCOST_I, value)
            End Set
        End Property
        Dim fRETURNTOSTOCK_I As Decimal

        Public Property RETURNTOSTOCK_I() As Decimal
            Get
                Return fRETURNTOSTOCK_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RETURNTOSTOCK_I", fRETURNTOSTOCK_I, value)
            End Set
        End Property
        Dim fNUMBERSCRAPPED_I As Decimal

        Public Property NUMBERSCRAPPED_I() As Decimal
            Get
                Return fNUMBERSCRAPPED_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NUMBERSCRAPPED_I", fNUMBERSCRAPPED_I, value)
            End Set
        End Property
        Dim fACTUAL_CONSUMED_I As Decimal

        Public Property ACTUAL_CONSUMED_I() As Decimal
            Get
                Return fACTUAL_CONSUMED_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ACTUAL_CONSUMED_I", fACTUAL_CONSUMED_I, value)
            End Set
        End Property
        Dim fPORDNMBR As String

        <Size(21)> _
        Public Property PORDNMBR() As String
            Get
                Return fPORDNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PORDNMBR", fPORDNMBR, value)
            End Set
        End Property
        Dim fPOLINE_I As Short

        Public Property POLINE_I() As Short
            Get
                Return fPOLINE_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POLINE_I", fPOLINE_I, value)
            End Set
        End Property
        Dim fQTY_ALLOWED_I As Decimal

        Public Property QTY_ALLOWED_I() As Decimal
            Get
                Return fQTY_ALLOWED_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTY_ALLOWED_I", fQTY_ALLOWED_I, value)
            End Set
        End Property
        Dim fCURRENT_CONSUMED_I As Decimal

        Public Property CURRENT_CONSUMED_I() As Decimal
            Get
                Return fCURRENT_CONSUMED_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CURRENT_CONSUMED_I", fCURRENT_CONSUMED_I, value)
            End Set
        End Property
        Dim fCURRENT_RTS_I As Decimal

        Public Property CURRENT_RTS_I() As Decimal
            Get
                Return fCURRENT_RTS_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CURRENT_RTS_I", fCURRENT_RTS_I, value)
            End Set
        End Property
        Dim fCURRENT_SCRAPPED_I As Decimal

        Public Property CURRENT_SCRAPPED_I() As Decimal
            Get
                Return fCURRENT_SCRAPPED_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CURRENT_SCRAPPED_I", fCURRENT_SCRAPPED_I, value)
            End Set
        End Property
        Dim fOPTIONED_ITEM_I As Byte

        Public Property OPTIONED_ITEM_I() As Byte
            Get
                Return fOPTIONED_ITEM_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("OPTIONED_ITEM_I", fOPTIONED_ITEM_I, value)
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
        Dim fPROMOTION_ID_I As String

        <Size(31)> _
        Public Property PROMOTION_ID_I() As String
            Get
                Return fPROMOTION_ID_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PROMOTION_ID_I", fPROMOTION_ID_I, value)
            End Set
        End Property
        Dim fACTUAL_CONSUMED_CHECK_I As Byte

        Public Property ACTUAL_CONSUMED_CHECK_I() As Byte
            Get
                Return fACTUAL_CONSUMED_CHECK_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ACTUAL_CONSUMED_CHECK_I", fACTUAL_CONSUMED_CHECK_I, value)
            End Set
        End Property
        Dim fREQDATE As DateTime
        <Persistent("REQDATE")> _
        Public Property RequestedDate() As DateTime
            Get
                Return fREQDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("REQDATE", fREQDATE, value)
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
        Dim fATYALLOC As Decimal

        Public Property ATYALLOC() As Decimal
            Get
                Return fATYALLOC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ATYALLOC", fATYALLOC, value)
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
        Dim fNON_INV_CRED_ACCT_IDX_I As Integer

        Public Property NON_INV_CRED_ACCT_IDX_I() As Integer
            Get
                Return fNON_INV_CRED_ACCT_IDX_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("NON_INV_CRED_ACCT_IDX_I", fNON_INV_CRED_ACCT_IDX_I, value)
            End Set
        End Property
        Dim fQTYBSUOM As Decimal

        Public Property QTYBSUOM() As Decimal
            Get
                Return fQTYBSUOM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYBSUOM", fQTYBSUOM, value)
            End Set
        End Property
        Dim fQTY_ISSUED_I As Decimal

        Public Property QTY_ISSUED_I() As Decimal
            Get
                Return fQTY_ISSUED_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTY_ISSUED_I", fQTY_ISSUED_I, value)
            End Set
        End Property
        Dim fQTY_BACKFLUSHED_I As Decimal

        Public Property QTY_BACKFLUSHED_I() As Decimal
            Get
                Return fQTY_BACKFLUSHED_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTY_BACKFLUSHED_I", fQTY_BACKFLUSHED_I, value)
            End Set
        End Property
        Dim fNON_INV_ITEM_DESC_I As String

        <Size(51)> _
        Public Property NON_INV_ITEM_DESC_I() As String
            Get
                Return fNON_INV_ITEM_DESC_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NON_INV_ITEM_DESC_I", fNON_INV_ITEM_DESC_I, value)
            End Set
        End Property
        Dim fLINK_TO_SEQUENCE_I As Integer

        Public Property LINK_TO_SEQUENCE_I() As Integer
            Get
                Return fLINK_TO_SEQUENCE_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("LINK_TO_SEQUENCE_I", fLINK_TO_SEQUENCE_I, value)
            End Set
        End Property
        Dim fFIXED_QTY_I As Decimal

        Public Property FIXED_QTY_I() As Decimal
            Get
                Return fFIXED_QTY_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FIXED_QTY_I", fFIXED_QTY_I, value)
            End Set
        End Property
        Dim fLEADTIMEOFFSET_I As Decimal

        Public Property LEADTIMEOFFSET_I() As Decimal
            Get
                Return fLEADTIMEOFFSET_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LEADTIMEOFFSET_I", fLEADTIMEOFFSET_I, value)
            End Set
        End Property
        Dim fOFFSET_FROM_I As Short

        Public Property OFFSET_FROM_I() As Short
            Get
                Return fOFFSET_FROM_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("OFFSET_FROM_I", fOFFSET_FROM_I, value)
            End Set
        End Property
        Dim fBOMUSERDEF1_I As String

        <Size(31)> _
        Public Property BOMUSERDEF1_I() As String
            Get
                Return fBOMUSERDEF1_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOMUSERDEF1_I", fBOMUSERDEF1_I, value)
            End Set
        End Property
        Dim fBOMUSERDEF2_I As String

        <Size(31)> _
        Public Property BOMUSERDEF2_I() As String
            Get
                Return fBOMUSERDEF2_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOMUSERDEF2_I", fBOMUSERDEF2_I, value)
            End Set
        End Property
        Dim fEXPLODE_QTY_I As Decimal

        Public Property EXPLODE_QTY_I() As Decimal
            Get
                Return fEXPLODE_QTY_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("EXPLODE_QTY_I", fEXPLODE_QTY_I, value)
            End Set
        End Property
        Dim fMFGNOTEINDEX_I As Decimal

        Public Property MFGNOTEINDEX_I() As Decimal
            Get
                Return fMFGNOTEINDEX_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MFGNOTEINDEX_I", fMFGNOTEINDEX_I, value)
            End Set
        End Property
        Dim fBOMSEQ_I As Integer

        Public Property BOMSEQ_I() As Integer
            Get
                Return fBOMSEQ_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("BOMSEQ_I", fBOMSEQ_I, value)
            End Set
        End Property
        Dim fPOSITION_NUMBER2 As Short

        Public Property POSITION_NUMBER2() As Short
            Get
                Return fPOSITION_NUMBER2
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POSITION_NUMBER2", fPOSITION_NUMBER2, value)
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

        Public Function GetGPItem() As IV.IVItem
            Return Session.FindObject(Of IV.IVItem)(New DevExpress.Data.Filtering.BinaryOperator("ITEMNMBR", Oid.ITEMNMBR, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
        End Function

    End Class
End Namespace
