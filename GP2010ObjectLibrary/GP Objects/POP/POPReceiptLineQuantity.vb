Imports System
Imports DevExpress.Xpo
Namespace Objects.POP
    ''' <summary>
    ''' GP Table POP10500
    ''' </summary>
    <Persistent("POP10500")>
    <OptimisticLocking(False)>
    Public Class POPReceiptLineQuantity
        Inherits XPLiteObject
        Public Structure POPReceiptLineQuantityKey
            Private fPONUMBER As String
            <Size(17)> _
            <Persistent("PONUMBER")>
            Public Property PONUMBER() As String
                Get
                    Return fPONUMBER
                End Get
                Set(ByVal value As String)
                    fPONUMBER = value
                End Set
            End Property
            Private fPOLNENUM As Integer
            <Persistent("POLNENUM")>
            Public Property POLNENUM() As Integer
                Get
                    Return fPOLNENUM
                End Get
                Set(ByVal value As Integer)
                    fPOLNENUM = value
                End Set
            End Property
            Private fPOPRCTNM As String
            <Size(17)> _
            <Persistent("POPRCTNM")>
            Public Property POPRCTNM() As String
                Get
                    Return fPOPRCTNM
                End Get
                Set(ByVal value As String)
                    fPOPRCTNM = value
                End Set
            End Property
            Private fRCPTLNNM As Integer
            <Persistent("RCPTLNNM")>
            Public Property RCPTLNNM() As Integer
                Get
                    Return fRCPTLNNM
                End Get
                Set(ByVal value As Integer)
                    fRCPTLNNM = value
                End Set
            End Property
        End Structure
        Private _mOid As POPReceiptLineQuantityKey
        <Persistent()> _
        <Key(False)> _
        Public Property Oid() As POPReceiptLineQuantityKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As POPReceiptLineQuantityKey)
                _mOid = Value
            End Set
        End Property


        Dim fQTYSHPPD As Decimal
        Public Property QTYSHPPD() As Decimal
            Get
                Return fQTYSHPPD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYSHPPD", fQTYSHPPD, value)
            End Set
        End Property
        Dim fQTYINVCD As Decimal
        Public Property QTYINVCD() As Decimal
            Get
                Return fQTYINVCD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYINVCD", fQTYINVCD, value)
            End Set
        End Property
        Dim fQTYREJ As Decimal
        Public Property QTYREJ() As Decimal
            Get
                Return fQTYREJ
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYREJ", fQTYREJ, value)
            End Set
        End Property
        Dim fQTYMATCH As Decimal
        Public Property QTYMATCH() As Decimal
            Get
                Return fQTYMATCH
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYMATCH", fQTYMATCH, value)
            End Set
        End Property
        Dim fQTYRESERVED As Decimal
        Public Property QTYRESERVED() As Decimal
            Get
                Return fQTYRESERVED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYRESERVED", fQTYRESERVED, value)
            End Set
        End Property
        Dim fQTYINVRESERVE As Decimal
        Public Property QTYINVRESERVE() As Decimal
            Get
                Return fQTYINVRESERVE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYINVRESERVE", fQTYINVRESERVE, value)
            End Set
        End Property
        Dim fStatus As Short
        Public Property Status() As Short
            Get
                Return fStatus
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Status", fStatus, value)
            End Set
        End Property
        Dim fUMQTYINB As Decimal
        Public Property UMQTYINB() As Decimal
            Get
                Return fUMQTYINB
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UMQTYINB", fUMQTYINB, value)
            End Set
        End Property
        Dim fOLDCUCST As Decimal
        Public Property OLDCUCST() As Decimal
            Get
                Return fOLDCUCST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OLDCUCST", fOLDCUCST, value)
            End Set
        End Property
        Dim fJOBNUMBR As String
        <Size(17)> _
        Public Property JOBNUMBR() As String
            Get
                Return fJOBNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("JOBNUMBR", fJOBNUMBR, value)
            End Set
        End Property
        Dim fCOSTCODE As String
        <Size(27)> _
        Public Property COSTCODE() As String
            Get
                Return fCOSTCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COSTCODE", fCOSTCODE, value)
            End Set
        End Property
        Dim fCOSTTYPE As Short
        Public Property COSTTYPE() As Short
            Get
                Return fCOSTTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("COSTTYPE", fCOSTTYPE, value)
            End Set
        End Property
        Dim fORCPTCOST As Decimal
        Public Property ORCPTCOST() As Decimal
            Get
                Return fORCPTCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORCPTCOST", fORCPTCOST, value)
            End Set
        End Property
        Dim fOSTDCOST As Decimal
        Public Property OSTDCOST() As Decimal
            Get
                Return fOSTDCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OSTDCOST", fOSTDCOST, value)
            End Set
        End Property
        Dim fAPPYTYPE As Short
        Public Property APPYTYPE() As Short
            Get
                Return fAPPYTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("APPYTYPE", fAPPYTYPE, value)
            End Set
        End Property
        Dim fPOPTYPE As Short
        Public Property POPTYPE() As Short
            Get
                Return fPOPTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("POPTYPE", fPOPTYPE, value)
            End Set
        End Property
        Dim fVENDORID As String
        <Size(15)> _
        Public Property VENDORID() As String
            Get
                Return fVENDORID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDORID", fVENDORID, value)
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
        Dim fTRXLOCTN As String
        <Size(11)> _
        Public Property TRXLOCTN() As String
            Get
                Return fTRXLOCTN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXLOCTN", fTRXLOCTN, value)
            End Set
        End Property
        Dim fDATERECD As DateTime
        Public Property DATERECD() As DateTime
            Get
                Return fDATERECD
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DATERECD", fDATERECD, value)
            End Set
        End Property
        Dim fRCTSEQNM As Integer
        Public Property RCTSEQNM() As Integer
            Get
                Return fRCTSEQNM
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RCTSEQNM", fRCTSEQNM, value)
            End Set
        End Property
        Dim fSPRCTSEQ As Integer
        Public Property SPRCTSEQ() As Integer
            Get
                Return fSPRCTSEQ
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SPRCTSEQ", fSPRCTSEQ, value)
            End Set
        End Property
        Dim fPCHRPTCT As Decimal
        Public Property PCHRPTCT() As Decimal
            Get
                Return fPCHRPTCT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PCHRPTCT", fPCHRPTCT, value)
            End Set
        End Property
        Dim fSPRCPTCT As Decimal
        Public Property SPRCPTCT() As Decimal
            Get
                Return fSPRCPTCT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SPRCPTCT", fSPRCPTCT, value)
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
        Dim fRUPPVAMT As Decimal
        Public Property RUPPVAMT() As Decimal
            Get
                Return fRUPPVAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RUPPVAMT", fRUPPVAMT, value)
            End Set
        End Property
        Dim fACPURIDX As Integer
        Public Property ACPURIDX() As Integer
            Get
                Return fACPURIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACPURIDX", fACPURIDX, value)
            End Set
        End Property
        Dim fINVINDX As Integer
        Public Property INVINDX() As Integer
            Get
                Return fINVINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("INVINDX", fINVINDX, value)
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
        Dim fXCHGRATE As Decimal
        Public Property XCHGRATE() As Decimal
            Get
                Return fXCHGRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("XCHGRATE", fXCHGRATE, value)
            End Set
        End Property
        Dim fRATECALC As Short
        Public Property RATECALC() As Short
            Get
                Return fRATECALC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RATECALC", fRATECALC, value)
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
        Dim fCapital_Item As Byte
        Public Property Capital_Item() As Byte
            Get
                Return fCapital_Item
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Capital_Item", fCapital_Item, value)
            End Set
        End Property
        Dim fProduct_Indicator As Short
        Public Property Product_Indicator() As Short
            Get
                Return fProduct_Indicator
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Product_Indicator", fProduct_Indicator, value)
            End Set
        End Property
        Dim fTotal_Landed_Cost_Amount As Decimal
        Public Property Total_Landed_Cost_Amount() As Decimal
            Get
                Return fTotal_Landed_Cost_Amount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Total_Landed_Cost_Amount", fTotal_Landed_Cost_Amount, value)
            End Set
        End Property
        Dim fQTYTYPE As Short
        Public Property QTYTYPE() As Short
            Get
                Return fQTYTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("QTYTYPE", fQTYTYPE, value)
            End Set
        End Property
        Dim fPosted_LC_PPV_Amount As Decimal
        Public Property Posted_LC_PPV_Amount() As Decimal
            Get
                Return fPosted_LC_PPV_Amount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Posted_LC_PPV_Amount", fPosted_LC_PPV_Amount, value)
            End Set
        End Property
        Dim fQTYREPLACED As Decimal
        Public Property QTYREPLACED() As Decimal
            Get
                Return fQTYREPLACED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYREPLACED", fQTYREPLACED, value)
            End Set
        End Property
        Dim fQTYINVADJ As Decimal
        Public Property QTYINVADJ() As Decimal
            Get
                Return fQTYINVADJ
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYINVADJ", fQTYINVADJ, value)
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
