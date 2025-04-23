Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM30201
    ''' </summary>
    <Persistent("RM30201")>
    Public Class RMHistoryTransactionApply
        Inherits XPLiteObject

        Public Structure RMHistoryTransactionApplyKey
            Private fAPTODCNM As String
            <Size(21)> _
            <Persistent("APTODCNM")>
            Public Property APTODCNM() As String
                Get
                    Return fAPTODCNM
                End Get
                Set(ByVal value As String)
                    fAPTODCNM = value
                End Set
            End Property
            Private fAPTODCTY As Short
            <Persistent("APTODCTY")>
            Public Property APTODCTY() As Short
                Get
                    Return fAPTODCTY
                End Get
                Set(ByVal value As Short)
                    fAPTODCTY = value
                End Set
            End Property
            Private fAPFRDCNM As String
            <Size(21)> _
            <Persistent("APFRDCNM")>
            Public Property APFRDCNM() As String
                Get
                    Return fAPFRDCNM
                End Get
                Set(ByVal value As String)
                    fAPFRDCNM = value
                End Set
            End Property
            Private fAPFRDCTY As Short
            <Persistent("APFRDCTY")>
            Public Property APFRDCTY() As Short
                Get
                    Return fAPFRDCTY
                End Get
                Set(ByVal value As Short)
                    fAPFRDCTY = value
                End Set
            End Property
        End Structure

        Dim fOid As RMHistoryTransactionApplyKey
        <Key()> _
        <Persistent()>
        Public Property Oid() As RMHistoryTransactionApplyKey
            Get
                Return fOid
            End Get
            Set(ByVal value As RMHistoryTransactionApplyKey)
                SetPropertyValue(Of RMHistoryTransactionApplyKey)("Oid", fOid, value)
            End Set
        End Property
        Dim fCUSTNMBR As String
        <Size(15)> _
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property
        Dim fCPRCSTNM As String
        <Size(15)> _
        Public Property CPRCSTNM() As String
            Get
                Return fCPRCSTNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CPRCSTNM", fCPRCSTNM, value)
            End Set
        End Property
        Dim fTRXSORCE As String
        <Size(13)> _
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXSORCE", fTRXSORCE, value)
            End Set
        End Property
        Dim fDATE1 As DateTime
        Public Property DATE1() As DateTime
            Get
                Return fDATE1
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DATE1", fDATE1, value)
            End Set
        End Property
        Dim fTIME1 As DateTime
        Public Property TIME1() As DateTime
            Get
                Return fTIME1
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("TIME1", fTIME1, value)
            End Set
        End Property
        Dim fGLPOSTDT As DateTime
        Public Property GLPOSTDT() As DateTime
            Get
                Return fGLPOSTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("GLPOSTDT", fGLPOSTDT, value)
            End Set
        End Property
        Dim fPOSTED As Byte
        Public Property POSTED() As Byte
            Get
                Return fPOSTED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("POSTED", fPOSTED, value)
            End Set
        End Property
        Dim fTAXDTLID As String
        <Size(15)> _
        Public Property TAXDTLID() As String
            Get
                Return fTAXDTLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXDTLID", fTAXDTLID, value)
            End Set
        End Property
        
        Dim fAPTODCDT As DateTime
        Public Property APTODCDT() As DateTime
            Get
                Return fAPTODCDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("APTODCDT", fAPTODCDT, value)
            End Set
        End Property
        Dim fApplyToGLPostDate As DateTime
        Public Property ApplyToGLPostDate() As DateTime
            Get
                Return fApplyToGLPostDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ApplyToGLPostDate", fApplyToGLPostDate, value)
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
        Dim fAPPTOAMT As Decimal
        Public Property APPTOAMT() As Decimal
            Get
                Return fAPPTOAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APPTOAMT", fAPPTOAMT, value)
            End Set
        End Property
        Dim fDISTKNAM As Decimal
        Public Property DISTKNAM() As Decimal
            Get
                Return fDISTKNAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISTKNAM", fDISTKNAM, value)
            End Set
        End Property
        Dim fDISAVTKN As Decimal
        Public Property DISAVTKN() As Decimal
            Get
                Return fDISAVTKN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DISAVTKN", fDISAVTKN, value)
            End Set
        End Property
        Dim fWROFAMNT As Decimal
        Public Property WROFAMNT() As Decimal
            Get
                Return fWROFAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WROFAMNT", fWROFAMNT, value)
            End Set
        End Property
        Dim fORAPTOAM As Decimal
        Public Property ORAPTOAM() As Decimal
            Get
                Return fORAPTOAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORAPTOAM", fORAPTOAM, value)
            End Set
        End Property
        Dim fORDISTKN As Decimal
        Public Property ORDISTKN() As Decimal
            Get
                Return fORDISTKN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDISTKN", fORDISTKN, value)
            End Set
        End Property
        Dim fORDATKN As Decimal
        Public Property ORDATKN() As Decimal
            Get
                Return fORDATKN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDATKN", fORDATKN, value)
            End Set
        End Property
        Dim fORWROFAM As Decimal
        Public Property ORWROFAM() As Decimal
            Get
                Return fORWROFAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORWROFAM", fORWROFAM, value)
            End Set
        End Property
        Dim fAPTOEXRATE As Decimal
        Public Property APTOEXRATE() As Decimal
            Get
                Return fAPTOEXRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APTOEXRATE", fAPTOEXRATE, value)
            End Set
        End Property
        Dim fAPTODENRATE As Decimal
        Public Property APTODENRATE() As Decimal
            Get
                Return fAPTODENRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APTODENRATE", fAPTODENRATE, value)
            End Set
        End Property
        Dim fAPTORTCLCMETH As Short
        Public Property APTORTCLCMETH() As Short
            Get
                Return fAPTORTCLCMETH
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("APTORTCLCMETH", fAPTORTCLCMETH, value)
            End Set
        End Property
        Dim fAPTOMCTRXSTT As Short
        Public Property APTOMCTRXSTT() As Short
            Get
                Return fAPTOMCTRXSTT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("APTOMCTRXSTT", fAPTOMCTRXSTT, value)
            End Set
        End Property
        
        Dim fAPFRDCDT As DateTime
        Public Property APFRDCDT() As DateTime
            Get
                Return fAPFRDCDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("APFRDCDT", fAPFRDCDT, value)
            End Set
        End Property
        Dim fApplyFromGLPostDate As DateTime
        Public Property ApplyFromGLPostDate() As DateTime
            Get
                Return fApplyFromGLPostDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ApplyFromGLPostDate", fApplyFromGLPostDate, value)
            End Set
        End Property
        Dim fFROMCURR As String
        <Size(15)> _
        Public Property FROMCURR() As String
            Get
                Return fFROMCURR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FROMCURR", fFROMCURR, value)
            End Set
        End Property
        Dim fAPFRMAPLYAMT As Decimal
        Public Property APFRMAPLYAMT() As Decimal
            Get
                Return fAPFRMAPLYAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APFRMAPLYAMT", fAPFRMAPLYAMT, value)
            End Set
        End Property
        Dim fAPFRMDISCTAKEN As Decimal
        Public Property APFRMDISCTAKEN() As Decimal
            Get
                Return fAPFRMDISCTAKEN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APFRMDISCTAKEN", fAPFRMDISCTAKEN, value)
            End Set
        End Property
        Dim fAPFRMDISCAVAIL As Decimal
        Public Property APFRMDISCAVAIL() As Decimal
            Get
                Return fAPFRMDISCAVAIL
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APFRMDISCAVAIL", fAPFRMDISCAVAIL, value)
            End Set
        End Property
        Dim fAPFRMWROFAMT As Decimal
        Public Property APFRMWROFAMT() As Decimal
            Get
                Return fAPFRMWROFAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APFRMWROFAMT", fAPFRMWROFAMT, value)
            End Set
        End Property
        Dim fActualApplyToAmount As Decimal
        Public Property ActualApplyToAmount() As Decimal
            Get
                Return fActualApplyToAmount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ActualApplyToAmount", fActualApplyToAmount, value)
            End Set
        End Property
        Dim fActualDiscTakenAmount As Decimal
        Public Property ActualDiscTakenAmount() As Decimal
            Get
                Return fActualDiscTakenAmount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ActualDiscTakenAmount", fActualDiscTakenAmount, value)
            End Set
        End Property
        Dim fActualDiscAvailTaken As Decimal
        Public Property ActualDiscAvailTaken() As Decimal
            Get
                Return fActualDiscAvailTaken
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ActualDiscAvailTaken", fActualDiscAvailTaken, value)
            End Set
        End Property
        Dim fActualWriteOffAmount As Decimal
        Public Property ActualWriteOffAmount() As Decimal
            Get
                Return fActualWriteOffAmount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ActualWriteOffAmount", fActualWriteOffAmount, value)
            End Set
        End Property
        Dim fAPFRMEXRATE As Decimal
        Public Property APFRMEXRATE() As Decimal
            Get
                Return fAPFRMEXRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APFRMEXRATE", fAPFRMEXRATE, value)
            End Set
        End Property
        Dim fAPFRMDENRATE As Decimal
        Public Property APFRMDENRATE() As Decimal
            Get
                Return fAPFRMDENRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APFRMDENRATE", fAPFRMDENRATE, value)
            End Set
        End Property
        Dim fAPFRMRTCLCMETH As Short
        Public Property APFRMRTCLCMETH() As Short
            Get
                Return fAPFRMRTCLCMETH
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("APFRMRTCLCMETH", fAPFRMRTCLCMETH, value)
            End Set
        End Property
        Dim fAPFRMMCTRXSTT As Short
        Public Property APFRMMCTRXSTT() As Short
            Get
                Return fAPFRMMCTRXSTT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("APFRMMCTRXSTT", fAPFRMMCTRXSTT, value)
            End Set
        End Property
        Dim fAPYFRMRNDAMT As Decimal
        Public Property APYFRMRNDAMT() As Decimal
            Get
                Return fAPYFRMRNDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APYFRMRNDAMT", fAPYFRMRNDAMT, value)
            End Set
        End Property
        Dim fAPYTORNDAMT As Decimal
        Public Property APYTORNDAMT() As Decimal
            Get
                Return fAPYTORNDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APYTORNDAMT", fAPYTORNDAMT, value)
            End Set
        End Property
        Dim fAPYTORNDDISC As Decimal
        Public Property APYTORNDDISC() As Decimal
            Get
                Return fAPYTORNDDISC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("APYTORNDDISC", fAPYTORNDDISC, value)
            End Set
        End Property
        Dim fOAPYFRMRNDAMT As Decimal
        Public Property OAPYFRMRNDAMT() As Decimal
            Get
                Return fOAPYFRMRNDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OAPYFRMRNDAMT", fOAPYFRMRNDAMT, value)
            End Set
        End Property
        Dim fOAPYTORNDAMT As Decimal
        Public Property OAPYTORNDAMT() As Decimal
            Get
                Return fOAPYTORNDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OAPYTORNDAMT", fOAPYTORNDAMT, value)
            End Set
        End Property
        Dim fOAPYTORNDDISC As Decimal
        Public Property OAPYTORNDDISC() As Decimal
            Get
                Return fOAPYTORNDDISC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("OAPYTORNDDISC", fOAPYTORNDDISC, value)
            End Set
        End Property
        Dim fGSTDSAMT As Decimal
        Public Property GSTDSAMT() As Decimal
            Get
                Return fGSTDSAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("GSTDSAMT", fGSTDSAMT, value)
            End Set
        End Property
        Dim fPPSAMDED As Decimal
        Public Property PPSAMDED() As Decimal
            Get
                Return fPPSAMDED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PPSAMDED", fPPSAMDED, value)
            End Set
        End Property
        Dim fRLGANLOS As Decimal
        Public Property RLGANLOS() As Decimal
            Get
                Return fRLGANLOS
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RLGANLOS", fRLGANLOS, value)
            End Set
        End Property
        Dim fSettled_Gain_CreditCurrT As Decimal
        Public Property Settled_Gain_CreditCurrT() As Decimal
            Get
                Return fSettled_Gain_CreditCurrT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Settled_Gain_CreditCurrT", fSettled_Gain_CreditCurrT, value)
            End Set
        End Property
        Dim fSettled_Loss_CreditCurrT As Decimal
        Public Property Settled_Loss_CreditCurrT() As Decimal
            Get
                Return fSettled_Loss_CreditCurrT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Settled_Loss_CreditCurrT", fSettled_Loss_CreditCurrT, value)
            End Set
        End Property
        Dim fSettled_Gain_DebitCurrTr As Decimal
        Public Property Settled_Gain_DebitCurrTr() As Decimal
            Get
                Return fSettled_Gain_DebitCurrTr
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Settled_Gain_DebitCurrTr", fSettled_Gain_DebitCurrTr, value)
            End Set
        End Property
        Dim fSettled_Loss_DebitCurrTr As Decimal
        Public Property Settled_Loss_DebitCurrTr() As Decimal
            Get
                Return fSettled_Loss_DebitCurrTr
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Settled_Loss_DebitCurrTr", fSettled_Loss_DebitCurrTr, value)
            End Set
        End Property
        Dim fSettled_Gain_DebitDiscAv As Decimal
        Public Property Settled_Gain_DebitDiscAv() As Decimal
            Get
                Return fSettled_Gain_DebitDiscAv
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Settled_Gain_DebitDiscAv", fSettled_Gain_DebitDiscAv, value)
            End Set
        End Property
        Dim fSettled_Loss_DebitDiscAv As Decimal
        Public Property Settled_Loss_DebitDiscAv() As Decimal
            Get
                Return fSettled_Loss_DebitDiscAv
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Settled_Loss_DebitDiscAv", fSettled_Loss_DebitDiscAv, value)
            End Set
        End Property
        Dim fRevaluation_Status As Short
        Public Property Revaluation_Status() As Short
            Get
                Return fRevaluation_Status
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Revaluation_Status", fRevaluation_Status, value)
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
