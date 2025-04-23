Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.GL
    ''' <summary>
    ''' GP Table GL10001
    ''' </summary>
    <Persistent("GL10001")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class GLLedgerDetail
        Inherits XPLiteObject

        Public Structure GLLedgerDetailKey
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
            Private fSQNCLINE As Decimal
            <Persistent("SQNCLINE")>
            Public Property SQNCLINE() As Decimal
                Get
                    Return fSQNCLINE
                End Get
                Set(ByVal value As Decimal)
                    fSQNCLINE = value
                End Set
            End Property
        End Structure

        Dim fOid As GLLedgerDetailKey
        <Key()> _
        <Persistent()>
        Public Property Oid() As GLLedgerDetailKey
            Get
                Return fOid
            End Get
            Set(ByVal value As GLLedgerDetailKey)
                SetPropertyValue(Of GLLedgerDetailKey)("Oid", fOid, value)
            End Set
        End Property
        Dim fBACHNUMB As String
        <Size(15)> _
        Public Property BACHNUMB() As String
            Get
                Return fBACHNUMB
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BACHNUMB", fBACHNUMB, value)
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
        Dim fXCHGRATE As Decimal
        Public Property XCHGRATE() As Decimal
            Get
                Return fXCHGRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("XCHGRATE", fXCHGRATE, value)
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
        Dim fCURRNIDX As Short
        Public Property CURRNIDX() As Short
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CURRNIDX", fCURRNIDX, value)
            End Set
        End Property
        Dim fACCTTYPE As Short
        Public Property ACCTTYPE() As Short
            Get
                Return fACCTTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ACCTTYPE", fACCTTYPE, value)
            End Set
        End Property
        Dim fFXDORVAR As Short
        Public Property FXDORVAR() As Short
            Get
                Return fFXDORVAR
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FXDORVAR", fFXDORVAR, value)
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
        Dim fPSTNGTYP As Short
        Public Property PSTNGTYP() As Short
            Get
                Return fPSTNGTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PSTNGTYP", fPSTNGTYP, value)
            End Set
        End Property
        Dim fDECPLACS As Short
        Public Property DECPLACS() As Short
            Get
                Return fDECPLACS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLACS", fDECPLACS, value)
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
        Dim fORTRXTYP As Short
        Public Property ORTRXTYP() As Short
            Get
                Return fORTRXTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORTRXTYP", fORTRXTYP, value)
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
        Dim fORTRXDESC As String
        <Size(31)> _
        Public Property ORTRXDESC() As String
            Get
                Return fORTRXDESC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORTRXDESC", fORTRXDESC, value)
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
        Dim fINTERID As String
        <Size(5)> _
        Public Property INTERID() As String
            Get
                Return fINTERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INTERID", fINTERID, value)
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
        Dim fLNESTAT As Short
        Public Property LNESTAT() As Short
            Get
                Return fLNESTAT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("LNESTAT", fLNESTAT, value)
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
