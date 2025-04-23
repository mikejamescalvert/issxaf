Imports System
Imports DevExpress.Xpo
Namespace Objects.BM
    ''' <summary>
    ''' GP Table BM010115
    ''' </summary>

    <Persistent("BM010115")>
    Public Class BMBillOfMaterialDetail
        Inherits XPLiteObject

        Public Structure BillOfMaterialDetailKey
            Private fPPN_I As String
            <Persistent("PPN_I")>
            <Size(31)>
            Public Property PPN_I() As String
                Get
                    Return fPPN_I
                End Get
                Set(ByVal value As String)
                    fPPN_I = value
                End Set
            End Property
            Private fCPN_I As String
            <Persistent("CPN_I")>
            <Size(31)>
            Public Property CPN_I() As String
                Get
                    Return fCPN_I
                End Get
                Set(ByVal value As String)
                    fCPN_I = value
                End Set
            End Property
            Private fBOMCAT_I As Short
            <Persistent("BOMCAT_I")>
            Public Property BOMCAT_I() As Short
                Get
                    Return fBOMCAT_I
                End Get
                Set(ByVal value As Short)
                    fBOMCAT_I = value
                End Set
            End Property
            Private fBOMNAME_I As String
            <Persistent("BOMNAME_I")>
            <Size(15)>
            Public Property BOMNAME_I() As String
                Get
                    Return fBOMNAME_I
                End Get
                Set(ByVal value As String)
                    fBOMNAME_I = value
                End Set
            End Property
            Private fBOMSEQ_I As Integer
            <Persistent("BOMSEQ_I")>
            Public Property BOMSEQ_I() As Integer
                Get
                    Return fBOMSEQ_I
                End Get
                Set(ByVal value As Integer)
                    fBOMSEQ_I = value
                End Set
            End Property
        End Structure

        Dim fOid As BillOfMaterialDetailKey
        <Key()>
        <Persistent()>
        Public Property Oid() As BillOfMaterialDetailKey
            Get
                Return fOid
            End Get
            Set(ByVal value As BillOfMaterialDetailKey)
                SetPropertyValue(Of BillOfMaterialDetailKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fBOMTYPE_I As Short
        Public Property BOMTYPE_I() As Short
            Get
                Return fBOMTYPE_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BOMTYPE_I", fBOMTYPE_I, value)
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
        Dim fSUBCAT_I As Short
        Public Property SUBCAT_I() As Short
            Get
                Return fSUBCAT_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SUBCAT_I", fSUBCAT_I, value)
            End Set
        End Property
        Dim fSUBNAME_I As String
        <Size(15)>
        Public Property SUBNAME_I() As String
            Get
                Return fSUBNAME_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SUBNAME_I", fSUBNAME_I, value)
            End Set
        End Property
        Dim fSUB_REV_LEVEL_SEQ_I As Integer
        Public Property SUB_REV_LEVEL_SEQ_I() As Integer
            Get
                Return fSUB_REV_LEVEL_SEQ_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SUB_REV_LEVEL_SEQ_I", fSUB_REV_LEVEL_SEQ_I, value)
            End Set
        End Property
        Dim fQUANTITY_I As Decimal
        Public Property QUANTITY_I() As Decimal
            Get
                Return fQUANTITY_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QUANTITY_I", fQUANTITY_I, value)
            End Set
        End Property
        Dim fOPTPERCENT_I As Integer
        Public Property OPTPERCENT_I() As Integer
            Get
                Return fOPTPERCENT_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("OPTPERCENT_I", fOPTPERCENT_I, value)
            End Set
        End Property
        Dim fSCRAPPERCENT_I As Integer
        Public Property SCRAPPERCENT_I() As Integer
            Get
                Return fSCRAPPERCENT_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SCRAPPERCENT_I", fSCRAPPERCENT_I, value)
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
        Dim fEFFECTIVEINDATE_I As DateTime
        Public Property EFFECTIVEINDATE_I() As DateTime
            Get
                Return fEFFECTIVEINDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EFFECTIVEINDATE_I", fEFFECTIVEINDATE_I, value)
            End Set
        End Property
        Dim fEFFECTIVEOUTDATE_I As DateTime
        Public Property EFFECTIVEOUTDATE_I() As DateTime
            Get
                Return fEFFECTIVEOUTDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EFFECTIVEOUTDATE_I", fEFFECTIVEOUTDATE_I, value)
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
        <Size(31)>
        Public Property ALTERNATEPARTFOR_I() As String
            Get
                Return fALTERNATEPARTFOR_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ALTERNATEPARTFOR_I", fALTERNATEPARTFOR_I, value)
            End Set
        End Property
        Dim fALT_FOR_BOM_SEQ_I As Integer
        Public Property ALT_FOR_BOM_SEQ_I() As Integer
            Get
                Return fALT_FOR_BOM_SEQ_I
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ALT_FOR_BOM_SEQ_I", fALT_FOR_BOM_SEQ_I, value)
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
        Dim fLEADTIMEOFFSETINC_I As Short
        Public Property LEADTIMEOFFSETINC_I() As Short
            Get
                Return fLEADTIMEOFFSETINC_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LEADTIMEOFFSETINC_I", fLEADTIMEOFFSETINC_I, value)
            End Set
        End Property
        Dim fBOMUSERDEF1_I As String
        <Size(31)>
        Public Property BOMUSERDEF1_I() As String
            Get
                Return fBOMUSERDEF1_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOMUSERDEF1_I", fBOMUSERDEF1_I, value)
            End Set
        End Property
        Dim fBOMUSERDEF2_I As String
        <Size(31)>
        Public Property BOMUSERDEF2_I() As String
            Get
                Return fBOMUSERDEF2_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOMUSERDEF2_I", fBOMUSERDEF2_I, value)
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
        Dim fBOMENGAPPROVAL_I As Byte
        Public Property BOMENGAPPROVAL_I() As Byte
            Get
                Return fBOMENGAPPROVAL_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BOMENGAPPROVAL_I", fBOMENGAPPROVAL_I, value)
            End Set
        End Property
        Dim fWCID_I As String
        <Size(11)>
        Public Property WCID_I() As String
            Get
                Return fWCID_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("WCID_I", fWCID_I, value)
            End Set
        End Property
        Dim fLOCNCODE As String
        <Size(11)>
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
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
        <Size(15)>
        Public Property USERID() As String
            Get
                Return fUSERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERID", fUSERID, value)
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
        Dim fACTUAL_CONSUMED_CHECK_I As Byte
        Public Property ACTUAL_CONSUMED_CHECK_I() As Byte
            Get
                Return fACTUAL_CONSUMED_CHECK_I
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ACTUAL_CONSUMED_CHECK_I", fACTUAL_CONSUMED_CHECK_I, value)
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
        Dim fUOFM As String
        <Size(9)>
        Public Property UOFM() As String
            Get
                Return fUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOFM", fUOFM, value)
            End Set
        End Property
        Dim fU_Of_M_2 As String
        <Size(9)>
        Public Property U_Of_M_2() As String
            Get
                Return fU_Of_M_2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("U_Of_M_2", fU_Of_M_2, value)
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
        Dim fOFFSET_FROM_I As Short
        Public Property OFFSET_FROM_I() As Short
            Get
                Return fOFFSET_FROM_I
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("OFFSET_FROM_I", fOFFSET_FROM_I, value)
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
        Dim fMFGNOTEINDEX2_I As Decimal
        Public Property MFGNOTEINDEX2_I() As Decimal
            Get
                Return fMFGNOTEINDEX2_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MFGNOTEINDEX2_I", fMFGNOTEINDEX2_I, value)
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