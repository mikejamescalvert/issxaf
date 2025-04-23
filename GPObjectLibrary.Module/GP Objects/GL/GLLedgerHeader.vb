Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.GL
    ''' <summary>
    ''' GP Table GL10000
    ''' </summary>
    <Persistent("GL10000")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class GLLedgerHeader
        Inherits XPLiteObject

        Public Structure GLLedgerHeaderKey
            Private fBACHNUMB As String
            <Size(15)>
            <Persistent("BACHNUMB")>
            Public Property BACHNUMB() As String
                Get
                    Return fBACHNUMB
                End Get
                Set(ByVal value As String)
                    fBACHNUMB = value
                End Set
            End Property
            Private fBCHSOURC As String
            <Size(15)>
            <Persistent("BCHSOURC")>
            Public Property BCHSOURC() As String
                Get
                    Return fBCHSOURC
                End Get
                Set(ByVal value As String)
                    fBCHSOURC = value
                End Set
            End Property
            Private fJRNENTRY As Integer
            <Persistent("JRNENTRY")>
            Public Property JRNENTRY() As Integer
                Get
                    Return fJRNENTRY
                End Get
                Set(ByVal value As Integer)
                    fJRNENTRY = value
                End Set
            End Property
        End Structure

        Dim fOid As GLLedgerHeaderKey
        <Key()>
        <Persistent()>
        Public Property Oid() As GLLedgerHeaderKey
            Get
                Return fOid
            End Get
            Set(ByVal value As GLLedgerHeaderKey)
                SetPropertyValue(Of GLLedgerHeaderKey)("Oid", fOid, value)
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
        <Size(11)>
        Public Property SOURCDOC() As String
            Get
                Return fSOURCDOC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOURCDOC", fSOURCDOC, value)
            End Set
        End Property
        Dim fREFRENCE As String
        <Size(31)>
        Public Property REFRENCE() As String
            Get
                Return fREFRENCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REFRENCE", fREFRENCE, value)
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
        Dim fRVRSNGDT As DateTime
        Public Property RVRSNGDT() As DateTime
            Get
                Return fRVRSNGDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("RVRSNGDT", fRVRSNGDT, value)
            End Set
        End Property
        Dim fRCRNGTRX As Byte
        Public Property RCRNGTRX() As Byte
            Get
                Return fRCRNGTRX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("RCRNGTRX", fRCRNGTRX, value)
            End Set
        End Property
        Dim fBALFRCLC As Short
        Public Property BALFRCLC() As Short
            Get
                Return fBALFRCLC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BALFRCLC", fBALFRCLC, value)
            End Set
        End Property
        Dim fPSTGSTUS As Short
        Public Property PSTGSTUS() As Short
            Get
                Return fPSTGSTUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PSTGSTUS", fPSTGSTUS, value)
            End Set
        End Property
        Dim fLASTUSER As String
        <Size(15)>
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
        <Size(15)>
        Public Property USWHPSTD() As String
            Get
                Return fUSWHPSTD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USWHPSTD", fUSWHPSTD, value)
            End Set
        End Property
        Dim fTRXTYPE As Short
        Public Property TRXTYPE() As Short
            Get
                Return fTRXTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TRXTYPE", fTRXTYPE, value)
            End Set
        End Property
        Dim fSQNCLINE As Decimal
        Public Property SQNCLINE() As Decimal
            Get
                Return fSQNCLINE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SQNCLINE", fSQNCLINE, value)
            End Set
        End Property
        Dim fTRXSORCE As String
        <Size(13)>
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXSORCE", fTRXSORCE, value)
            End Set
        End Property
        Dim fRVTRXSRC As String
        <Size(13)>
        Public Property RVTRXSRC() As String
            Get
                Return fRVTRXSRC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RVTRXSRC", fRVTRXSRC, value)
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
        <Size(13)>
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
        Dim fDTAControlNum As String
        <Size(21)>
        Public Property DTAControlNum() As String
            Get
                Return fDTAControlNum
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DTAControlNum", fDTAControlNum, value)
            End Set
        End Property
        Dim fDTATRXType As Short
        Public Property DTATRXType() As Short
            Get
                Return fDTATRXType
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DTATRXType", fDTATRXType, value)
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
        <Size(15)>
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
        <Size(15)>
        Public Property RATETPID() As String
            Get
                Return fRATETPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RATETPID", fRATETPID, value)
            End Set
        End Property
        Dim fEXGTBLID As String
        <Size(15)>
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
        Dim fPERIODID As Short
        Public Property PERIODID() As Short
            Get
                Return fPERIODID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PERIODID", fPERIODID, value)
            End Set
        End Property
        Dim fOPENYEAR As Short
        Public Property OPENYEAR() As Short
            Get
                Return fOPENYEAR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("OPENYEAR", fOPENYEAR, value)
            End Set
        End Property
        Dim fCLOSEDYR As Short
        Public Property CLOSEDYR() As Short
            Get
                Return fCLOSEDYR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CLOSEDYR", fCLOSEDYR, value)
            End Set
        End Property
        Dim fHISTRX As Byte
        Public Property HISTRX() As Byte
            Get
                Return fHISTRX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("HISTRX", fHISTRX, value)
            End Set
        End Property
        Dim fREVPRDID As Short
        Public Property REVPRDID() As Short
            Get
                Return fREVPRDID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("REVPRDID", fREVPRDID, value)
            End Set
        End Property
        Dim fREVYEAR As Short
        Public Property REVYEAR() As Short
            Get
                Return fREVYEAR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("REVYEAR", fREVYEAR, value)
            End Set
        End Property
        Dim fREVCLYR As Short
        Public Property REVCLYR() As Short
            Get
                Return fREVCLYR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("REVCLYR", fREVCLYR, value)
            End Set
        End Property
        Dim fREVHIST As Byte
        Public Property REVHIST() As Byte
            Get
                Return fREVHIST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("REVHIST", fREVHIST, value)
            End Set
        End Property
        Dim fERRSTATE As Integer
        Public Property ERRSTATE() As Integer
            Get
                Return fERRSTATE
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ERRSTATE", fERRSTATE, value)
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
        <Size(5)>
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
        Dim fICDISTS As Byte
        Public Property ICDISTS() As Byte
            Get
                Return fICDISTS
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ICDISTS", fICDISTS, value)
            End Set
        End Property
        Dim fPRNTSTUS As Short
        Public Property PRNTSTUS() As Short
            Get
                Return fPRNTSTUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PRNTSTUS", fPRNTSTUS, value)
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
        Dim fDOCDATE As DateTime
        Public Property DOCDATE() As DateTime
            Get
                Return fDOCDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DOCDATE", fDOCDATE, value)
            End Set
        End Property
        Dim fTax_Date As DateTime
        Public Property Tax_Date() As DateTime
            Get
                Return fTax_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Tax_Date", fTax_Date, value)
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
        Dim fOriginal_JE As Integer
        Public Property Original_JE() As Integer
            Get
                Return fOriginal_JE
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Original_JE", fOriginal_JE, value)
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
        Dim fOriginal_JE_Seq_Num As Decimal
        Public Property Original_JE_Seq_Num() As Decimal
            Get
                Return fOriginal_JE_Seq_Num
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Original_JE_Seq_Num", fOriginal_JE_Seq_Num, value)
            End Set
        End Property
        Dim fCorrecting_Trx_Type As Short
        Public Property Correcting_Trx_Type() As Short
            Get
                Return fCorrecting_Trx_Type
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Correcting_Trx_Type", fCorrecting_Trx_Type, value)
            End Set
        End Property
        Dim fLedger_ID As Short
        Public Property Ledger_ID() As Short
            Get
                Return fLedger_ID
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Ledger_ID", fLedger_ID, value)
            End Set
        End Property
        Dim fAdjustment_Transaction As Byte
        Public Property Adjustment_Transaction() As Byte
            Get
                Return fAdjustment_Transaction
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Adjustment_Transaction", fAdjustment_Transaction, value)
            End Set
        End Property
        Dim fDEX_ROW_TS As DateTime
        Public Property DEX_ROW_TS() As DateTime
            Get
                Return fDEX_ROW_TS
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DEX_ROW_TS", fDEX_ROW_TS, value)
            End Set
        End Property
        'Dim fDEX_ROW_ID As Integer
        'Public Property DEX_ROW_ID() As Integer
        '    Get
        '        Return fDEX_ROW_ID
        '    End Get
        '    Set(ByVal value As Integer)
        '        SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
        '    End Set
        'End Property
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
