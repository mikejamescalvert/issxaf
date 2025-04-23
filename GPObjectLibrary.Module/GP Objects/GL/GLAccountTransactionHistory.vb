Imports System
Imports DevExpress.Xpo
Namespace Objects.GL

    ''' <summary>
    ''' GP Table GL30000
    ''' </summary>
    <Persistent("GL30000")> _
    <OptimisticLocking(False)> _
    Public Class GLAccountTransactionHistory
        Inherits XPLiteObject
        Dim fHSTYEAR As Short
        Public Property HSTYEAR() As Short
            Get
                Return fHSTYEAR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("HSTYEAR", fHSTYEAR, value)
            End Set
        End Property
        Dim fJRNENTRY As Integer
        Public Property JRNENTRY() As Integer
            Get
                Return fJRNENTRY
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("JRNENTRY", fJRNENTRY, value)
            End Set
        End Property
        Dim fRCTRXSEQ As Decimal
        Public Property RCTRXSEQ() As Decimal
            Get
                Return fRCTRXSEQ
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RCTRXSEQ", fRCTRXSEQ, value)
            End Set
        End Property
        Dim fSOURCDOC As String
        <Size(11)> _
        Public Property SOURCDOC() As String
            Get
                Return fSOURCDOC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOURCDOC", fSOURCDOC, value)
            End Set
        End Property
        Dim fREFRENCE As String
        <Size(31)> _
        Public Property REFRENCE() As String
            Get
                Return fREFRENCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REFRENCE", fREFRENCE, value)
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
        Dim fTRXDATE As DateTime
        Public Property TRXDATE() As DateTime
            Get
                Return fTRXDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("TRXDATE", fTRXDATE, value)
            End Set
        End Property
        Dim fACTINDX As Integer
        Public Property ACTINDX() As Integer
            Get
                Return fACTINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACTINDX", fACTINDX, value)
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
        Dim fPOLLDTRX As Byte
        Public Property POLLDTRX() As Byte
            Get
                Return fPOLLDTRX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("POLLDTRX", fPOLLDTRX, value)
            End Set
        End Property
        Dim fLASTUSER As String
        <Size(15)> _
        Public Property LASTUSER() As String
            Get
                Return fLASTUSER
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LASTUSER", fLASTUSER, value)
            End Set
        End Property
        Dim fLSTDTEDT As DateTime
        Public Property LSTDTEDT() As DateTime
            Get
                Return fLSTDTEDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTDTEDT", fLSTDTEDT, value)
            End Set
        End Property
        Dim fUSWHPSTD As String
        <Size(15)> _
        Public Property USWHPSTD() As String
            Get
                Return fUSWHPSTD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USWHPSTD", fUSWHPSTD, value)
            End Set
        End Property
        Dim fORGNTSRC As String
        <Size(15)> _
        Public Property ORGNTSRC() As String
            Get
                Return fORGNTSRC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORGNTSRC", fORGNTSRC, value)
            End Set
        End Property
        Dim fORGNATYP As Short
        Public Property ORGNATYP() As Short
            Get
                Return fORGNATYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORGNATYP", fORGNATYP, value)
            End Set
        End Property
        Dim fQKOFSET As Short
        Public Property QKOFSET() As Short
            Get
                Return fQKOFSET
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("QKOFSET", fQKOFSET, value)
            End Set
        End Property
        Dim fSERIES As Short
        Public Property SERIES() As Short
            Get
                Return fSERIES
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SERIES", fSERIES, value)
            End Set
        End Property
        Dim fORTRXTYP As Short
        Public Property ORTRXTYP() As Short
            Get
                Return fORTRXTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORTRXTYP", fORTRXTYP, value)
            End Set
        End Property
        Dim fORCTRNUM As String
        <Size(21)> _
        Public Property ORCTRNUM() As String
            Get
                Return fORCTRNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORCTRNUM", fORCTRNUM, value)
            End Set
        End Property
        Dim fORMSTRID As String
        <Size(31)> _
        Public Property ORMSTRID() As String
            Get
                Return fORMSTRID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORMSTRID", fORMSTRID, value)
            End Set
        End Property
        Dim fORMSTRNM As String
        <Size(65)> _
        Public Property ORMSTRNM() As String
            Get
                Return fORMSTRNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORMSTRNM", fORMSTRNM, value)
            End Set
        End Property
        Dim fORDOCNUM As String
        <Size(21)> _
        Public Property ORDOCNUM() As String
            Get
                Return fORDOCNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORDOCNUM", fORDOCNUM, value)
            End Set
        End Property
        Dim fORPSTDDT As DateTime
        Public Property ORPSTDDT() As DateTime
            Get
                Return fORPSTDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ORPSTDDT", fORPSTDDT, value)
            End Set
        End Property
        Dim fORTRXSRC As String
        <Size(13)> _
        Public Property ORTRXSRC() As String
            Get
                Return fORTRXSRC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORTRXSRC", fORTRXSRC, value)
            End Set
        End Property
        Dim fOrigDTASeries As Short
        Public Property OrigDTASeries() As Short
            Get
                Return fOrigDTASeries
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("OrigDTASeries", fOrigDTASeries, value)
            End Set
        End Property
        Dim fOrigSeqNum As Integer
        Public Property OrigSeqNum() As Integer
            Get
                Return fOrigSeqNum
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("OrigSeqNum", fOrigSeqNum, value)
            End Set
        End Property
        Dim fSEQNUMBR As Integer
        Public Property SEQNUMBR() As Integer
            Get
                Return fSEQNUMBR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SEQNUMBR", fSEQNUMBR, value)
            End Set
        End Property
        Dim fDTA_GL_Status As Short
        Public Property DTA_GL_Status() As Short
            Get
                Return fDTA_GL_Status
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DTA_GL_Status", fDTA_GL_Status, value)
            End Set
        End Property
        Dim fDTA_Index As Decimal
        Public Property DTA_Index() As Decimal
            Get
                Return fDTA_Index
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DTA_Index", fDTA_Index, value)
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
        Dim fXCHGRATE As Decimal
        Public Property XCHGRATE() As Decimal
            Get
                Return fXCHGRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("XCHGRATE", fXCHGRATE, value)
            End Set
        End Property
        Dim fEXCHDATE As DateTime
        Public Property EXCHDATE() As DateTime
            Get
                Return fEXCHDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EXCHDATE", fEXCHDATE, value)
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
        Dim fRTCLCMTD As Short
        Public Property RTCLCMTD() As Short
            Get
                Return fRTCLCMTD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RTCLCMTD", fRTCLCMTD, value)
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
        Dim fICTRX As Byte
        Public Property ICTRX() As Byte
            Get
                Return fICTRX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ICTRX", fICTRX, value)
            End Set
        End Property
        Dim fORCOMID As String
        <Size(5)> _
        Public Property ORCOMID() As String
            Get
                Return fORCOMID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORCOMID", fORCOMID, value)
            End Set
        End Property
        Dim fORIGINJE As Integer
        Public Property ORIGINJE() As Integer
            Get
                Return fORIGINJE
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ORIGINJE", fORIGINJE, value)
            End Set
        End Property
        Dim fPERIODID As Short
        Public Property PERIODID() As Short
            Get
                Return fPERIODID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PERIODID", fPERIODID, value)
            End Set
        End Property
        Dim fCRDTAMNT As Decimal
        Public Property CRDTAMNT() As Decimal
            Get
                Return fCRDTAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CRDTAMNT", fCRDTAMNT, value)
            End Set
        End Property
        Dim fDEBITAMT As Decimal
        Public Property DEBITAMT() As Decimal
            Get
                Return fDEBITAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DEBITAMT", fDEBITAMT, value)
            End Set
        End Property
        Dim fORCRDAMT As Decimal
        Public Property ORCRDAMT() As Decimal
            Get
                Return fORCRDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORCRDAMT", fORCRDAMT, value)
            End Set
        End Property
        Dim fORDBTAMT As Decimal
        Public Property ORDBTAMT() As Decimal
            Get
                Return fORDBTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDBTAMT", fORDBTAMT, value)
            End Set
        End Property
        Dim fDOCDATE As DateTime
        Public Property DOCDATE() As DateTime
            Get
                Return fDOCDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DOCDATE", fDOCDATE, value)
            End Set
        End Property
        Dim fPSTGNMBR As Integer
        Public Property PSTGNMBR() As Integer
            Get
                Return fPSTGNMBR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PSTGNMBR", fPSTGNMBR, value)
            End Set
        End Property
        Dim fPPSGNMBR As Integer
        Public Property PPSGNMBR() As Integer
            Get
                Return fPPSGNMBR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PPSGNMBR", fPPSGNMBR, value)
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
        Dim fMCTRXSTT As Short
        Public Property MCTRXSTT() As Short
            Get
                Return fMCTRXSTT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MCTRXSTT", fMCTRXSTT, value)
            End Set
        End Property
        Dim fCorrespondingUnit As String
        <Size(5)> _
        Public Property CorrespondingUnit() As String
            Get
                Return fCorrespondingUnit
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CorrespondingUnit", fCorrespondingUnit, value)
            End Set
        End Property
        Dim fVOIDED As Byte
        Public Property VOIDED() As Byte
            Get
                Return fVOIDED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("VOIDED", fVOIDED, value)
            End Set
        End Property
        Dim fBack_Out_JE As Integer
        Public Property Back_Out_JE() As Integer
            Get
                Return fBack_Out_JE
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Back_Out_JE", fBack_Out_JE, value)
            End Set
        End Property
        Dim fBack_Out_JE_Year As Short
        Public Property Back_Out_JE_Year() As Short
            Get
                Return fBack_Out_JE_Year
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Back_Out_JE_Year", fBack_Out_JE_Year, value)
            End Set
        End Property
        Dim fCorrecting_JE As Integer
        Public Property Correcting_JE() As Integer
            Get
                Return fCorrecting_JE
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Correcting_JE", fCorrecting_JE, value)
            End Set
        End Property
        Dim fCorrecting_JE_Year As Short
        Public Property Correcting_JE_Year() As Short
            Get
                Return fCorrecting_JE_Year
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Correcting_JE_Year", fCorrecting_JE_Year, value)
            End Set
        End Property
        Dim fOriginal_JE As Integer
        Public Property Original_JE() As Integer
            Get
                Return fOriginal_JE
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Original_JE", fOriginal_JE, value)
            End Set
        End Property
        Dim fOriginal_JE_Seq_Num As Decimal
        Public Property Original_JE_Seq_Num() As Decimal
            Get
                Return fOriginal_JE_Seq_Num
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Original_JE_Seq_Num", fOriginal_JE_Seq_Num, value)
            End Set
        End Property
        Dim fOriginal_JE_Year As Short
        Public Property Original_JE_Year() As Short
            Get
                Return fOriginal_JE_Year
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Original_JE_Year", fOriginal_JE_Year, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        <Key(True)> _
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
