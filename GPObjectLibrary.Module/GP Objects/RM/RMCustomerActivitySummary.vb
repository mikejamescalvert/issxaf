Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00103
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("RM00103")> _
    <System.ComponentModel.DefaultProperty("CUSTNMBR")> _
    <OptimisticLocking(False)> _
    Public Class RMCustomerActivitySummary
        Inherits XPLiteObject
        Dim fTNSFCLIF As Decimal
        Public Property TNSFCLIF() As Decimal
            Get
                Return fTNSFCLIF
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TNSFCLIF", fTNSFCLIF, value)
            End Set
        End Property
        Dim fNONSFLIF As Integer
        Public Property NONSFLIF() As Integer
            Get
                Return fNONSFLIF
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("NONSFLIF", fNONSFLIF, value)
            End Set
        End Property
        Dim fCUSTNMBR As String
        <Key()> _
        <Size(15)> _
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property
        Dim fCUSTBLNC As Decimal
        Public Property CUSTBLNC() As Decimal
            Get
                Return fCUSTBLNC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CUSTBLNC", fCUSTBLNC, value)
            End Set
        End Property
        Dim fAGPERAMT_1 As Decimal
        Public Property AGPERAMT_1() As Decimal
            Get
                Return fAGPERAMT_1
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AGPERAMT_1", fAGPERAMT_1, value)
            End Set
        End Property
        Dim fAGPERAMT_2 As Decimal
        Public Property AGPERAMT_2() As Decimal
            Get
                Return fAGPERAMT_2
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AGPERAMT_2", fAGPERAMT_2, value)
            End Set
        End Property
        Dim fAGPERAMT_3 As Decimal
        Public Property AGPERAMT_3() As Decimal
            Get
                Return fAGPERAMT_3
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AGPERAMT_3", fAGPERAMT_3, value)
            End Set
        End Property
        Dim fAGPERAMT_4 As Decimal
        Public Property AGPERAMT_4() As Decimal
            Get
                Return fAGPERAMT_4
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AGPERAMT_4", fAGPERAMT_4, value)
            End Set
        End Property
        Dim fAGPERAMT_5 As Decimal
        Public Property AGPERAMT_5() As Decimal
            Get
                Return fAGPERAMT_5
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AGPERAMT_5", fAGPERAMT_5, value)
            End Set
        End Property
        Dim fAGPERAMT_6 As Decimal
        Public Property AGPERAMT_6() As Decimal
            Get
                Return fAGPERAMT_6
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AGPERAMT_6", fAGPERAMT_6, value)
            End Set
        End Property
        Dim fAGPERAMT_7 As Decimal
        Public Property AGPERAMT_7() As Decimal
            Get
                Return fAGPERAMT_7
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("AGPERAMT_7", fAGPERAMT_7, value)
            End Set
        End Property
        Dim fLASTAGED As DateTime
        Public Property LASTAGED() As DateTime
            Get
                Return fLASTAGED
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LASTAGED", fLASTAGED, value)
            End Set
        End Property
        Dim fFRSTINDT As DateTime
        Public Property FRSTINDT() As DateTime
            Get
                Return fFRSTINDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FRSTINDT", fFRSTINDT, value)
            End Set
        End Property
        Dim fLSTNSFCD As DateTime
        Public Property LSTNSFCD() As DateTime
            Get
                Return fLSTNSFCD
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTNSFCD", fLSTNSFCD, value)
            End Set
        End Property
        Dim fLPYMTAMT As Decimal
        Public Property LPYMTAMT() As Decimal
            Get
                Return fLPYMTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LPYMTAMT", fLPYMTAMT, value)
            End Set
        End Property
        Dim fLASTPYDT As DateTime
        Public Property LASTPYDT() As DateTime
            Get
                Return fLASTPYDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LASTPYDT", fLASTPYDT, value)
            End Set
        End Property
        Dim fLSTTRXDT As DateTime
        Public Property LSTTRXDT() As DateTime
            Get
                Return fLSTTRXDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTTRXDT", fLSTTRXDT, value)
            End Set
        End Property
        Dim fLSTTRXAM As Decimal
        Public Property LSTTRXAM() As Decimal
            Get
                Return fLSTTRXAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LSTTRXAM", fLSTTRXAM, value)
            End Set
        End Property
        Dim fLSTFCHAM As Decimal
        Public Property LSTFCHAM() As Decimal
            Get
                Return fLSTFCHAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LSTFCHAM", fLSTFCHAM, value)
            End Set
        End Property
        Dim fUPFCHYTD As Decimal
        Public Property UPFCHYTD() As Decimal
            Get
                Return fUPFCHYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UPFCHYTD", fUPFCHYTD, value)
            End Set
        End Property
        Dim fAVDTPLYR As Short
        Public Property AVDTPLYR() As Short
            Get
                Return fAVDTPLYR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("AVDTPLYR", fAVDTPLYR, value)
            End Set
        End Property
        Dim fAVDTPLIF As Short
        Public Property AVDTPLIF() As Short
            Get
                Return fAVDTPLIF
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("AVDTPLIF", fAVDTPLIF, value)
            End Set
        End Property
        Dim fAVGDTPYR As Short
        Public Property AVGDTPYR() As Short
            Get
                Return fAVGDTPYR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("AVGDTPYR", fAVGDTPYR, value)
            End Set
        End Property
        Dim fNUMADTPL As Integer
        Public Property NUMADTPL() As Integer
            Get
                Return fNUMADTPL
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("NUMADTPL", fNUMADTPL, value)
            End Set
        End Property
        Dim fNUMADTPY As Integer
        Public Property NUMADTPY() As Integer
            Get
                Return fNUMADTPY
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("NUMADTPY", fNUMADTPY, value)
            End Set
        End Property
        Dim fNUMADTPR As Integer
        Public Property NUMADTPR() As Integer
            Get
                Return fNUMADTPR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("NUMADTPR", fNUMADTPR, value)
            End Set
        End Property
        Dim fTDTKNYTD As Decimal
        Public Property TDTKNYTD() As Decimal
            Get
                Return fTDTKNYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTKNYTD", fTDTKNYTD, value)
            End Set
        End Property
        Dim fTDTKNLYR As Decimal
        Public Property TDTKNLYR() As Decimal
            Get
                Return fTDTKNLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTKNLYR", fTDTKNLYR, value)
            End Set
        End Property
        Dim fTDTKNLTD As Decimal
        Public Property TDTKNLTD() As Decimal
            Get
                Return fTDTKNLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTKNLTD", fTDTKNLTD, value)
            End Set
        End Property
        Dim fTDISAYTD As Decimal
        Public Property TDISAYTD() As Decimal
            Get
                Return fTDISAYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDISAYTD", fTDISAYTD, value)
            End Set
        End Property
        Dim fRETAINAG As Decimal
        Public Property RETAINAG() As Decimal
            Get
                Return fRETAINAG
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RETAINAG", fRETAINAG, value)
            End Set
        End Property
        Dim fTNSFCYTD As Decimal
        Public Property TNSFCYTD() As Decimal
            Get
                Return fTNSFCYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TNSFCYTD", fTNSFCYTD, value)
            End Set
        End Property
        Dim fNONSFYTD As Integer
        Public Property NONSFYTD() As Integer
            Get
                Return fNONSFYTD
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("NONSFYTD", fNONSFYTD, value)
            End Set
        End Property
        Dim fUNPSTDSA As Decimal
        Public Property UNPSTDSA() As Decimal
            Get
                Return fUNPSTDSA
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UNPSTDSA", fUNPSTDSA, value)
            End Set
        End Property
        Dim fUNPSTDCA As Decimal
        Public Property UNPSTDCA() As Decimal
            Get
                Return fUNPSTDCA
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UNPSTDCA", fUNPSTDCA, value)
            End Set
        End Property
        Dim fUNPSTOSA As Decimal
        Public Property UNPSTOSA() As Decimal
            Get
                Return fUNPSTOSA
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UNPSTOSA", fUNPSTOSA, value)
            End Set
        End Property
        Dim fUNPSTOCA As Decimal
        Public Property UNPSTOCA() As Decimal
            Get
                Return fUNPSTOCA
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UNPSTOCA", fUNPSTOCA, value)
            End Set
        End Property
        Dim fNCSCHPMT As Decimal
        Public Property NCSCHPMT() As Decimal
            Get
                Return fNCSCHPMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NCSCHPMT", fNCSCHPMT, value)
            End Set
        End Property
        Dim fTTLSLYTD As Decimal
        Public Property TTLSLYTD() As Decimal
            Get
                Return fTTLSLYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLSLYTD", fTTLSLYTD, value)
            End Set
        End Property
        Dim fTTLSLLTD As Decimal
        Public Property TTLSLLTD() As Decimal
            Get
                Return fTTLSLLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLSLLTD", fTTLSLLTD, value)
            End Set
        End Property
        Dim fTTLSLLYR As Decimal
        Public Property TTLSLLYR() As Decimal
            Get
                Return fTTLSLLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLSLLYR", fTTLSLLYR, value)
            End Set
        End Property
        Dim fTCOSTYTD As Decimal
        Public Property TCOSTYTD() As Decimal
            Get
                Return fTCOSTYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TCOSTYTD", fTCOSTYTD, value)
            End Set
        End Property
        Dim fTCOSTLTD As Decimal
        Public Property TCOSTLTD() As Decimal
            Get
                Return fTCOSTLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TCOSTLTD", fTCOSTLTD, value)
            End Set
        End Property
        Dim fTCOSTLYR As Decimal
        Public Property TCOSTLYR() As Decimal
            Get
                Return fTCOSTLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TCOSTLYR", fTCOSTLYR, value)
            End Set
        End Property
        Dim fTCSHRYTD As Decimal
        Public Property TCSHRYTD() As Decimal
            Get
                Return fTCSHRYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TCSHRYTD", fTCSHRYTD, value)
            End Set
        End Property
        Dim fTCSHRLTD As Decimal
        Public Property TCSHRLTD() As Decimal
            Get
                Return fTCSHRLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TCSHRLTD", fTCSHRLTD, value)
            End Set
        End Property
        Dim fTCSHRLYR As Decimal
        Public Property TCSHRLYR() As Decimal
            Get
                Return fTCSHRLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TCSHRLYR", fTCSHRLYR, value)
            End Set
        End Property
        Dim fTFNCHYTD As Decimal
        Public Property TFNCHYTD() As Decimal
            Get
                Return fTFNCHYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TFNCHYTD", fTFNCHYTD, value)
            End Set
        End Property
        Dim fTFNCHLTD As Decimal
        Public Property TFNCHLTD() As Decimal
            Get
                Return fTFNCHLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TFNCHLTD", fTFNCHLTD, value)
            End Set
        End Property
        Dim fTFNCHLYR As Decimal
        Public Property TFNCHLYR() As Decimal
            Get
                Return fTFNCHLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TFNCHLYR", fTFNCHLYR, value)
            End Set
        End Property
        Dim fFNCHCYTD As Decimal
        Public Property FNCHCYTD() As Decimal
            Get
                Return fFNCHCYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FNCHCYTD", fFNCHCYTD, value)
            End Set
        End Property
        Dim fFNCHLYRC As Decimal
        Public Property FNCHLYRC() As Decimal
            Get
                Return fFNCHLYRC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FNCHLYRC", fFNCHLYRC, value)
            End Set
        End Property
        Dim fTBDDTYTD As Decimal
        Public Property TBDDTYTD() As Decimal
            Get
                Return fTBDDTYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TBDDTYTD", fTBDDTYTD, value)
            End Set
        End Property
        Dim fTBDDTLYR As Decimal
        Public Property TBDDTLYR() As Decimal
            Get
                Return fTBDDTLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TBDDTLYR", fTBDDTLYR, value)
            End Set
        End Property
        Dim fTBDDTLTD As Decimal
        Public Property TBDDTLTD() As Decimal
            Get
                Return fTBDDTLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TBDDTLTD", fTBDDTLTD, value)
            End Set
        End Property
        Dim fTWVFCYTD As Decimal
        Public Property TWVFCYTD() As Decimal
            Get
                Return fTWVFCYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TWVFCYTD", fTWVFCYTD, value)
            End Set
        End Property
        Dim fTWVFCLTD As Decimal
        Public Property TWVFCLTD() As Decimal
            Get
                Return fTWVFCLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TWVFCLTD", fTWVFCLTD, value)
            End Set
        End Property
        Dim fTWVFCLYR As Decimal
        Public Property TWVFCLYR() As Decimal
            Get
                Return fTWVFCLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TWVFCLYR", fTWVFCLYR, value)
            End Set
        End Property
        Dim fTWROFYTD As Decimal
        Public Property TWROFYTD() As Decimal
            Get
                Return fTWROFYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TWROFYTD", fTWROFYTD, value)
            End Set
        End Property
        Dim fTWROFLTD As Decimal
        Public Property TWROFLTD() As Decimal
            Get
                Return fTWROFLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TWROFLTD", fTWROFLTD, value)
            End Set
        End Property
        Dim fTWROFLYR As Decimal
        Public Property TWROFLYR() As Decimal
            Get
                Return fTWROFLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TWROFLYR", fTWROFLYR, value)
            End Set
        End Property
        Dim fTTLINYTD As Integer
        Public Property TTLINYTD() As Integer
            Get
                Return fTTLINYTD
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TTLINYTD", fTTLINYTD, value)
            End Set
        End Property
        Dim fTTLINLTD As Integer
        Public Property TTLINLTD() As Integer
            Get
                Return fTTLINLTD
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TTLINLTD", fTTLINLTD, value)
            End Set
        End Property
        Dim fTTLINLYR As Integer
        Public Property TTLINLYR() As Integer
            Get
                Return fTTLINLYR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TTLINLYR", fTTLINLYR, value)
            End Set
        End Property
        Dim fTTLFCYTD As Integer
        Public Property TTLFCYTD() As Integer
            Get
                Return fTTLFCYTD
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TTLFCYTD", fTTLFCYTD, value)
            End Set
        End Property
        Dim fTTLFCLTD As Integer
        Public Property TTLFCLTD() As Integer
            Get
                Return fTTLFCLTD
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TTLFCLTD", fTTLFCLTD, value)
            End Set
        End Property
        Dim fTTLFCLYR As Integer
        Public Property TTLFCLYR() As Integer
            Get
                Return fTTLFCLYR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TTLFCLYR", fTTLFCLYR, value)
            End Set
        End Property
        Dim fWROFSLIF As Decimal
        Public Property WROFSLIF() As Decimal
            Get
                Return fWROFSLIF
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WROFSLIF", fWROFSLIF, value)
            End Set
        End Property
        Dim fWROFSLYR As Decimal
        Public Property WROFSLYR() As Decimal
            Get
                Return fWROFSLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WROFSLYR", fWROFSLYR, value)
            End Set
        End Property
        Dim fWROFSYTD As Decimal
        Public Property WROFSYTD() As Decimal
            Get
                Return fWROFSYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("WROFSYTD", fWROFSYTD, value)
            End Set
        End Property
        Dim fHIBALLYR As Decimal
        Public Property HIBALLYR() As Decimal
            Get
                Return fHIBALLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("HIBALLYR", fHIBALLYR, value)
            End Set
        End Property
        Dim fHIBALYTD As Decimal
        Public Property HIBALYTD() As Decimal
            Get
                Return fHIBALYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("HIBALYTD", fHIBALYTD, value)
            End Set
        End Property
        Dim fHIBALLTD As Decimal
        Public Property HIBALLTD() As Decimal
            Get
                Return fHIBALLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("HIBALLTD", fHIBALLTD, value)
            End Set
        End Property
        Dim fLASTSTDT As DateTime
        Public Property LASTSTDT() As DateTime
            Get
                Return fLASTSTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LASTSTDT", fLASTSTDT, value)
            End Set
        End Property
        Dim fLSTSTAMT As Decimal
        Public Property LSTSTAMT() As Decimal
            Get
                Return fLSTSTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LSTSTAMT", fLSTSTAMT, value)
            End Set
        End Property
        Dim fDEPRECV As Decimal
        Public Property DEPRECV() As Decimal
            Get
                Return fDEPRECV
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DEPRECV", fDEPRECV, value)
            End Set
        End Property
        Dim fONORDAMT As Decimal
        Public Property ONORDAMT() As Decimal
            Get
                Return fONORDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ONORDAMT", fONORDAMT, value)
            End Set
        End Property
        Dim fTTLRTYTD As Decimal
        Public Property TTLRTYTD() As Decimal
            Get
                Return fTTLRTYTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLRTYTD", fTTLRTYTD, value)
            End Set
        End Property
        Dim fTTLRTLTD As Decimal
        Public Property TTLRTLTD() As Decimal
            Get
                Return fTTLRTLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLRTLTD", fTTLRTLTD, value)
            End Set
        End Property
        Dim fTTLRTLYR As Decimal
        Public Property TTLRTLYR() As Decimal
            Get
                Return fTTLRTLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLRTLYR", fTTLRTLYR, value)
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
