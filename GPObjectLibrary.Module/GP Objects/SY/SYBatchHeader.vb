Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.SY
    ''' <summary>
    ''' GP Table SY00500
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("SY00500")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class SYBatchHeader
        Inherits XPLiteObject

        Public Structure SYBatchHeaderKey
            Private fBCHSOURC As String
            <Persistent("BCHSOURC")>
            <Size(15)> _
            Public Property BCHSOURC() As String
                Get
                    Return fBCHSOURC
                End Get
                Set(ByVal value As String)
                    fBCHSOURC = value
                End Set
            End Property
            Private fBACHNUMB As String
            <Size(15)> _
            <Persistent("BACHNUMB")>
            Public Property BACHNUMB() As String
                Get
                    Return fBACHNUMB
                End Get
                Set(ByVal value As String)
                    fBACHNUMB = value
                End Set
            End Property
        End Structure

        Dim fOid As SYBatchHeaderKey
        <Key()> _
        <Persistent()>
        Public Property Oid() As SYBatchHeaderKey
            Get
                Return fOid
            End Get
            Set(ByVal value As SYBatchHeaderKey)
                SetPropertyValue(Of SYBatchHeaderKey)("Oid", fOid, value)
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

        Dim fSERIES As Short
        Public Property SERIES() As Short
            Get
                Return fSERIES
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SERIES", fSERIES, value)
            End Set
        End Property
        Dim fMKDTOPST As Byte
        Public Property MKDTOPST() As Byte
            Get
                Return fMKDTOPST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MKDTOPST", fMKDTOPST, value)
            End Set
        End Property
        Dim fNUMOFTRX As Integer
        Public Property NUMOFTRX() As Integer
            Get
                Return fNUMOFTRX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("NUMOFTRX", fNUMOFTRX, value)
            End Set
        End Property
        Dim fRECPSTGS As Short
        Public Property RECPSTGS() As Short
            Get
                Return fRECPSTGS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RECPSTGS", fRECPSTGS, value)
            End Set
        End Property
        Dim fDELBACH As Byte
        Public Property DELBACH() As Byte
            Get
                Return fDELBACH
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DELBACH", fDELBACH, value)
            End Set
        End Property
        Dim fMSCBDINC As Short
        Public Property MSCBDINC() As Short
            Get
                Return fMSCBDINC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MSCBDINC", fMSCBDINC, value)
            End Set
        End Property
        Dim fBACHFREQ As Short
        Public Property BACHFREQ() As Short
            Get
                Return fBACHFREQ
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BACHFREQ", fBACHFREQ, value)
            End Set
        End Property
        Dim fRCLPSTDT As DateTime
        Public Property RCLPSTDT() As DateTime
            Get
                Return fRCLPSTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("RCLPSTDT", fRCLPSTDT, value)
            End Set
        End Property
        Dim fNOFPSTGS As Short
        Public Property NOFPSTGS() As Short
            Get
                Return fNOFPSTGS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("NOFPSTGS", fNOFPSTGS, value)
            End Set
        End Property
        Dim fBCHCOMNT As String
        <Size(61)> _
        Public Property BCHCOMNT() As String
            Get
                Return fBCHCOMNT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BCHCOMNT", fBCHCOMNT, value)
            End Set
        End Property
        Dim fBRKDNALL As Byte
        Public Property BRKDNALL() As Byte
            Get
                Return fBRKDNALL
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("BRKDNALL", fBRKDNALL, value)
            End Set
        End Property
        Dim fCHKSPRTD As Byte
        Public Property CHKSPRTD() As Byte
            Get
                Return fCHKSPRTD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CHKSPRTD", fCHKSPRTD, value)
            End Set
        End Property
        Dim fRVRSBACH As Byte
        Public Property RVRSBACH() As Byte
            Get
                Return fRVRSBACH
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("RVRSBACH", fRVRSBACH, value)
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
        Dim fCHEKBKID As String
        <Size(15)> _
        Public Property CHEKBKID() As String
            Get
                Return fCHEKBKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CHEKBKID", fCHEKBKID, value)
            End Set
        End Property
        Dim fBCHTOTAL As Decimal
        Public Property BCHTOTAL() As Decimal
            Get
                Return fBCHTOTAL
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("BCHTOTAL", fBCHTOTAL, value)
            End Set
        End Property
        Dim fBACHDATE As DateTime
        Public Property BACHDATE() As DateTime
            Get
                Return fBACHDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("BACHDATE", fBACHDATE, value)
            End Set
        End Property
        Dim fBCHEMSG1 As Byte()
        Public Property BCHEMSG1() As Byte()
            Get
                Return fBCHEMSG1
            End Get
            Set(ByVal value As Byte())
                SetPropertyValue(Of Byte())("BCHEMSG1", fBCHEMSG1, value)
            End Set
        End Property
        Dim fBCHEMSG2 As Byte()
        Public Property BCHEMSG2() As Byte()
            Get
                Return fBCHEMSG2
            End Get
            Set(ByVal value As Byte())
                SetPropertyValue(Of Byte())("BCHEMSG2", fBCHEMSG2, value)
            End Set
        End Property
        Private _mGLBCHVAL As Byte()
        Public Property GLBCHVAL As Byte()
            Get
                Return _mGLBCHVAL
            End Get
            Set(ByVal Value As Byte())
                SetPropertyValue("GLBCHVAL", _mGLBCHVAL, Value)
            End Set
        End Property
        

        Dim fBCHSTRG1 As String
        <Size(21)> _
        Public Property BCHSTRG1() As String
            Get
                Return fBCHSTRG1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BCHSTRG1", fBCHSTRG1, value)
            End Set
        End Property
        Dim fBCHSTRG2 As String
        <Size(21)> _
        Public Property BCHSTRG2() As String
            Get
                Return fBCHSTRG2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BCHSTRG2", fBCHSTRG2, value)
            End Set
        End Property
        Dim fPOSTTOGL As Byte
        Public Property POSTTOGL() As Byte
            Get
                Return fPOSTTOGL
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("POSTTOGL", fPOSTTOGL, value)
            End Set
        End Property
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
            End Set
        End Property
        Dim fCREATDDT As DateTime
        Public Property CREATDDT() As DateTime
            Get
                Return fCREATDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CREATDDT", fCREATDDT, value)
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
        Dim fBCHSTTUS As Short
        Public Property BCHSTTUS() As Short
            Get
                Return fBCHSTTUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BCHSTTUS", fBCHSTTUS, value)
            End Set
        End Property
        Dim fCNTRLTRX As Integer
        Public Property CNTRLTRX() As Integer
            Get
                Return fCNTRLTRX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CNTRLTRX", fCNTRLTRX, value)
            End Set
        End Property
        Dim fCNTRLTOT As Decimal
        Public Property CNTRLTOT() As Decimal
            Get
                Return fCNTRLTOT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CNTRLTOT", fCNTRLTOT, value)
            End Set
        End Property
        Dim fPETRXCNT As Short
        Public Property PETRXCNT() As Short
            Get
                Return fPETRXCNT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PETRXCNT", fPETRXCNT, value)
            End Set
        End Property
        Dim fAPPROVL As Byte
        Public Property APPROVL() As Byte
            Get
                Return fAPPROVL
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("APPROVL", fAPPROVL, value)
            End Set
        End Property
        Dim fAPPRVLDT As DateTime
        Public Property APPRVLDT() As DateTime
            Get
                Return fAPPRVLDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("APPRVLDT", fAPPRVLDT, value)
            End Set
        End Property
        Dim fAPRVLUSERID As String
        <Size(15)> _
        Public Property APRVLUSERID() As String
            Get
                Return fAPRVLUSERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("APRVLUSERID", fAPRVLUSERID, value)
            End Set
        End Property
        Dim fORIGIN As Short
        Public Property ORIGIN() As Short
            Get
                Return fORIGIN
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORIGIN", fORIGIN, value)
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
        Dim fComputer_Check_Doc_Date As DateTime
        Public Property Computer_Check_Doc_Date() As DateTime
            Get
                Return fComputer_Check_Doc_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("Computer_Check_Doc_Date", fComputer_Check_Doc_Date, value)
            End Set
        End Property
        Dim fSort_Checks_By As Short
        Public Property Sort_Checks_By() As Short
            Get
                Return fSort_Checks_By
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Sort_Checks_By", fSort_Checks_By, value)
            End Set
        End Property
        Dim fSEPRMTNC As Byte
        Public Property SEPRMTNC() As Byte
            Get
                Return fSEPRMTNC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SEPRMTNC", fSEPRMTNC, value)
            End Set
        End Property
        Dim fREPRNTED As Short
        Public Property REPRNTED() As Short
            Get
                Return fREPRNTED
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("REPRNTED", fREPRNTED, value)
            End Set
        End Property
        Dim fCHKFRMTS As Short
        Public Property CHKFRMTS() As Short
            Get
                Return fCHKFRMTS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CHKFRMTS", fCHKFRMTS, value)
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
        Private _mCARDNAME As String
        <Size(20)>
        Public Property CARDNAME As String
            Get
                Return _mCARDNAME
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("CARDNAME", _mCARDNAME, Value)
            End Set
        End Property
        
        Dim fPmtMethod As Short
        Public Property PmtMethod() As Short
            Get
                Return fPmtMethod
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PmtMethod", fPmtMethod, value)
            End Set
        End Property
        Dim fEFTFileFormat As Short
        Public Property EFTFileFormat() As Short
            Get
                Return fEFTFileFormat
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("EFTFileFormat", fEFTFileFormat, value)
            End Set
        End Property
        Dim fWorkflow_Approval_Status As Short
        Public Property Workflow_Approval_Status() As Short
            Get
                Return fWorkflow_Approval_Status
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Workflow_Approval_Status", fWorkflow_Approval_Status, value)
            End Set
        End Property
        Dim fWorkflow_Priority As Short
        Public Property Workflow_Priority() As Short
            Get
                Return fWorkflow_Priority
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Workflow_Priority", fWorkflow_Priority, value)
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
        Dim fClearRecAmts As Byte
        Public Property ClearRecAmts() As Byte
            Get
                Return fClearRecAmts
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ClearRecAmts", fClearRecAmts, value)
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
            BCHEMSG1 = {Byte.Parse(0)}
            BCHEMSG2 = {Byte.Parse(0)}
            GLBCHVAL = {Byte.Parse(0)}
        End Sub
    End Class

End Namespace
